﻿namespace MEdge.Engine
{
    using System;
    using Physics = UnityEngine.Physics;
    using V3 = UnityEngine.Vector3;
    using Collider = UnityEngine.Collider;
    using Object = Core.Object;
    using static UnityEngine.Debug;



    public class UWorld
	{
        public WorldInfo.ENetMode NetMode{ get; private set; }
        Actor _defaultOuter = new Actor();
        WorldInfo _worldInfo = new WorldInfo();

        UnityEngine.BoxCollider _cacheCollider = new UnityEngine.BoxCollider();




        bool FindSpot(Object.Vector extent, ref Object.Vector position, bool bComplex)
        {
            Collider[] colliders = new Collider[ 1 ];
            int iterations = 0;
            _cacheCollider.size = (V3) extent;
            while(Physics.OverlapBoxNonAlloc( (V3) position, ((V3) extent) / 2f, colliders ) > 0)
            {
                var otherCollider = colliders[ 0 ];
                if( false == Physics.ComputePenetration( _cacheCollider, (V3) position, default,
                    otherCollider, otherCollider.transform.position, otherCollider.transform.rotation,
                    out var direction, out var distance ) )
                {
                    return true;
                }

                position += (Object.Vector) direction * distance;
                
                if( iterations++ > 8 )
                    return false;
            }

            return true;
        }



        //, _E_struct_FVector *SpawnLocation, _E_struct_FRotator *SpawnRotation, _E_struct_AActor *ActorTemplate, int bNoCollisionFail, int networkRelatedParam, _E_struct_AActor *SpawnOwner, _E_struct_APawn *Instigator, int bProbablyNoFail
        public T E_UWorld_SpawnActor<T>(Core.ClassT<T> SpawnClass, int a3, float a4, Object.Vector SpawnLocation, Object.Rotator SpawnRotation, Actor ActorTemplate, bool bNoCollisionFail, int networkRelatedParam, Actor SpawnOwner, Pawn Instigator, bool bProbablyNoFail) where T : Actor
		{
            #warning implement this maybe
            bool bUWorldHasBegunPlay = true;
            var bUWorldHasBegunPlay2 = bUWorldHasBegunPlay;
            bool bUWorldHasBegunPlay3 = bUWorldHasBegunPlay;
            var SpawnClassCopy = SpawnClass;
            if( SpawnClass == null )
                return null;
            /*
            v16 = *(_DWORD *)&SpawnClass->_E_struct_UState::UnknownData00[72];
            if ( ((unsigned int)&dword_2000000 & v16) != 0 )
                return 0;
            if ( (v16 & 1) != 0 )
                return 0;
            privateStaticClass = E_AActor_ReturnPrivateStaticClass();
            if ( !E_maybe_IsThisClassBeforeComparand(SpawnClassCopy, privateStaticClass) )
                return 0;*/
            var networkRelatedBool = !bUWorldHasBegunPlay2;
            var actorTemplateCopy = ActorTemplate;
            //if ( !networkRelatedBool && ((E_UClass_GetDefaultObject(SpawnClassCopy, 0)->bExludeHandMoves & bStatic) != 0 || (E_UClass_GetDefaultObject(SpawnClassCopy, 0)->bExludeHandMoves & bNoDelete) != 0) )
            if ( !networkRelatedBool && ((SpawnClassCopy.DefaultAs<Actor>().bStatic != false || SpawnClassCopy.DefaultAs<Actor>().bNoDelete != false) ))
            {
                if ( !bProbablyNoFail )
                    return null;
            }
            if ( actorTemplateCopy != null )
            {
                if( actorTemplateCopy.Class != SpawnClassCopy && !bProbablyNoFail )
                    return null;
            }
            else
            {
                actorTemplateCopy = SpawnClassCopy.DefaultAs<Actor>();
            }
            /*v21 = SpawnLocation->Y;
            v22 = SpawnLocation->Z;
            spawnLocation2.X = SpawnLocation->X;
            spawnLocation2.Y = v21;
            spawnLocation2.Z = v22;
            v23 = actorTemplateCopy->bForceDemoRelevant;
            if ( (v23 < 0 || (v23 & bCollideWhenPlacing) != 0 && E_maybe_UWorld_GetNetMode(thisUWorldCopy) != 3) && !bNoCollisionFail )*/
            if ( (actorTemplateCopy.bCollideWhenPlacing != false && this.NetMode != (WorldInfo.ENetMode)3) && !bNoCollisionFail )
            {
                Object.Vector extent;
                if( actorTemplateCopy.CollisionComponent is CylinderComponent cc )
                {
                    extent = new Object.Vector( cc.CollisionRadius, cc.CollisionRadius, cc.CollisionHeight );
                }
                else// if ( actorTemplateCopy.CollisionComponent is BrushComponent bc )
                {
                    extent = default;
                    LogWarning( $"Attempted to spawn actor with unimplemented bounds getter for collision component '{actorTemplateCopy.CollisionComponent.GetType()}'" );
                }

                if( ! FindSpot( extent, ref SpawnLocation, actorTemplateCopy.bCollideComplex ) )
                {
                    LogWarning( $"Could not {nameof(FindSpot)} @ {SpawnLocation} to spawn {actorTemplateCopy}" );
                    return null;
                }
            }
            //spawnOwnerCopy = SpawnOwner;
            Actor newOuter;
            if( SpawnOwner != null )
                newOuter = (Actor) SpawnOwner.Outer;
            else // Need to verify how that works
                newOuter = _defaultOuter;// *(_E_struct_AActor **)&thisUWorldCopy->UnknownData_[24];
            // Need to verify this as well
            var constructedActor = SpawnClassCopy.New( newOuter );////E_UObject_StaticConstructObject(SpawnClassCopy, newOuter, a3, SLODWORD(a4), 0, 1, actorTemplateCopy, 0, 0);
            /*constructedActorCopy = constructedActor;
            if ( dword_2018700 )
                sub_B81580(newOuter);
            sub_806170((int *)&newOuter->bExludeHandMoves, &constructedActorCopy);
            refToConstructedActorTag = &constructedActor->Tag;
            a3 = 0;
            a4 = 0.0;*/
            //if ( E_mabye_CompFNameEquality(&constructedActor->Tag, (_E_struct_FName *)&a3) )// Is the constructed actor tag not yet set
            if( constructedActor.Tag == default )
            {
                /*if ( SpawnClassCopy->ObjectInternalInteger == -1 )
                    name = (_E_struct_FName *)sub_1117920(&a3, (int)refToConstructedActorTag, (wchar_t *)L"<uninitialized>", 1, 1);
                else*/
                    var name = SpawnClassCopy.Name;
                constructedActor.Tag = name;
                //refToConstructedActorTag->Index = name->Index;
                //constructedActor->Tag.Number = name->Number;
            }
            //constructedActor->bExludeHandMoves ^= (constructedActor->bExludeHandMoves ^ ((*(_DWORD *)&this->UnknownData_[252] == 0) << 7)) & bTicked;
            #warning Ticked setter not quite figured out yet
            constructedActor.bTicked = false/*!Ticked*/;
            constructedActor.CreationTime = UnityEngine.Time.time;//E_UWorld_GetTimeSeconds(this);
            //ptrToSomeKindOfWorldInfo = E_GetSomeKindOfPtrToWorldInfo(this);
            networkRelatedBool = networkRelatedParam == 0;
            constructedActor.WorldInfo = _worldInfo;
            if ( !networkRelatedBool )
            {
                var v31 = constructedActor.Role;
                constructedActor.Role = constructedActor.RemoteRole;
                constructedActor.RemoteRole = v31;
            }
            constructedActor.Location = SpawnLocation;
            constructedActor.Rotation = SpawnRotation;
            // .text:00C18C00 ConditionalForceUpdateComponents
            #warning ConditionalForceUpdateComponents
            //(*(void (__thiscall **)(_E_struct_AActor *, _DWORD, _DWORD))(constructedActor->VfTableObject.Dummy + 760))(constructedActor, 0, 0);
            constructedActor.PhysicsVolume = _worldInfo.PhysicsVolume ?? throw new NullReferenceException();
            constructedActor.SetOwner(SpawnOwner);
            constructedActor.Instigator = Instigator;



            if( bUWorldHasBegunPlay3 )
            {
                #warning InitRBPhys
                // .text:00EA1DF0 InitRBPhys
                //(*(void (__thiscall **)(_E_struct_AActor *))(constructedActor->VfTableObject.Dummy + 568))(constructedActor);
            }

            //if ( !dword_2027FC0 )
            {
                #warning InitExecution and SetDefaultCollisionType
                // .text:01105300, InitExecution?
                //(*(void (__thiscall **)(_E_struct_AActor *))(constructedActor->VfTableObject.Dummy + 260))(constructedActor);
                // .text:00BA6D80, AActor_Spawned -> inlined E_AActor_SetDefaultCollisionType
                //(*(void (__thiscall **)(_E_struct_AActor *))(constructedActor->VfTableObject.Dummy + 380))(constructedActor);
            }
            
            if ( bUWorldHasBegunPlay3 )
            {
                // .text:00C10830, PreBeginPlay
                constructedActor.PreBeginPlay();
                //(*(void (__thiscall **)(_E_struct_AActor *))(constructedActor->VfTableObject.Dummy + 472))(constructedActor);
                if ( (constructedActor.bDeleteMe) != false && !bProbablyNoFail )
                    return null;
                for ( int i = 0; i < constructedActor.Components.Length; ++i )
                {
                    var v34 = constructedActor.Components;
                    networkRelatedBool = v34[i] == null;
                    var v35 = v34[i] as ActorComponent;
                    if( ! networkRelatedBool )
                    {
                        #warning maybe start component state here ?
                        //E_UActorComponent_ConditionalBeginPlay(*v35);
                    }
                }
            }
            if ( bNoCollisionFail )
            {
                if ( (constructedActor.bCollideActors) != false )
                {
                    LogWarning( "FindTouchingActors not implemented yet!" );
                    //E_AActor_FindTouchingActors(constructedActor);
                    if ( (constructedActor.bDeleteMe) != false && !bProbablyNoFail )
                        return null;
                }
            }
            #warning no CheckEncroachment
            /*else if ( E_UWorld_CheckEncroachment(this, constructedActor, constructedActor->Location.X, constructedActor->Location.Y, constructedActor->Location.Z, constructedActor->Rotation.Pitch, constructedActor->Rotation.Yaw, constructedActor->Rotation.Roll, 1) )
            {
                E_UWorld_DestroyActor(this, constructedActor, 0, 1);
                return null;
            }*/
            if ( bUWorldHasBegunPlay3 )
            {
                // .text:00C10790 E_AActor_PostBeginPlay
                constructedActor.PostBeginPlay();
                constructedActor.SetInitialState();
                //(*(void (__thiscall **)(_E_struct_AActor *))(constructedActor->VfTableObject.Dummy + 476))(constructedActor);
                if ( (constructedActor.bDeleteMe) != false && !bProbablyNoFail )
                    return null;
            }
            /*if ( *(_DWORD *)&this->UnknownData_[248] )
                E_TArray_AddItem((_E_struct_TArray *)&this->UnknownData_[236], &constructedActorCopy);*/
            /* Not sure what this is about
            if ( !bUWorldHasBegunPlay3 )
            {
                constructedActor->bExludeHandMoves |= bDeleteMe;
                (*(void (__thiscall **)(_E_struct_AActor *, _DWORD))(constructedActor->VfTableObject.Dummy + 24))(constructedActor, 0);// .text:01104B00
                constructedActor->bExludeHandMoves &= 0xFFFFFFBF;
            }*/
            return constructedActor;
		}
	}
}