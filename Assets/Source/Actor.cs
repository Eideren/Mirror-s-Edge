namespace MEdge.Engine
{
    using System;
    using System.Collections.Generic;
    using Object = Core.Object;



    public partial class Actor
    {
        // Export UActor::execSpawn(FFrame&, void* const)
        //public virtual /*native final function */Actor Spawn(Core.ClassT<Actor> SpawnClass, /*optional */Actor SpawnOwner = default, /*optional */name SpawnTag = default, /*optional */Object.Vector SpawnLocation = default, /*optional */Object.Rotator SpawnRotation = default, /*optional */Actor ActorTemplate = default, /*optional */bool bNoCollisionFail = default)
        //{
        //    #warning NATIVE FUNCTION !
        //    return default;
        //}
        public virtual /*native final function */ T Spawn<T>(Core.ClassT<T> SpawnClass, /*optional */
            Actor SpawnOwner = default, /*optional */Core.name? SpawnTag = default, /*optional */
            Object.Vector? SpawnLocation = default, /*optional */Object.Rotator? SpawnRotation = default, /*optional */
            Actor ActorTemplate = default, /*optional */bool? bNoCollisionFail = default) where T : Actor
        {
            //return this.Spawn( SpawnClass as Core.ClassT<Actor>, SpawnOwner, SpawnTag, SpawnLocation, SpawnRotation, ActorTemplate, bNoCollisionFail ) as T;
            if( ActorTemplate != default )
            {
                UnityEngine.Debug.LogWarning( $"Request to spawn with specific {nameof(ActorTemplate)} '{ActorTemplate}', feature not implemented" );
            }
            T Actor = SpawnClass.New();
            
            if( Actor.bStatic || Actor.bNoDelete )
                return null;
            
            if( bNoCollisionFail == false && (Actor.bCollideWorld || Actor.bCollideWhenPlacing) )
                if( !FindSpot( Actor.CollisionComponent.Bounds.BoxExtent, ref Location ) )
                    return null;
            
            
            Actor.Tag = SpawnTag ?? SpawnClass.Name;
            Actor.WorldInfo = this.WorldInfo ?? throw new NullReferenceException();
            Actor.bTicked = true; // Maybe ?
            
            Actor.Location = SpawnLocation ?? default;
            Actor.Rotation = SpawnRotation ?? default;
            // if( Actor->bCollideActors && Hash  )
            //      Hash->AddActor( Actor );

            Actor.PhysicsVolume = WorldInfo.PhysicsVolume ?? throw new NullReferenceException();

            if( SpawnOwner != null )
            {
                Actor.SetOwner( SpawnOwner );
                SpawnOwner.GainedChild( Actor ); /* Maybe? */
            }

            Actor.Instigator = Instigator;
            
            #error enable state stuff
            
            Actor.PreBeginPlay();
            if( Actor.bDeleteMe )
                return null;
            
            Actor.SetZone(true/*maybe?*/);
            Actor.PhysicsVolume.ActorEnteredVolume(  );
            
            if( bNoCollisionFail == false )
            {
                /*if( Actor.bCollideActors && Hash )
                    Hash->RemoveActor( Actor );
 
                if( CheckEncroachment( Actor, Actor->Location, Actor->Rotation, 1 ) )
                {
                    DestroyActor( Actor );
                    return NULL;
                }
                
                if( Actor.bCollideActors && Hash )
                    Hash->AddActor( Actor );*/
            }
            
            Actor.PostBeginPlay();
            if( Actor.bDeleteMe )
                return null; // Not documented, maybe shouldn't be here
            
            Actor.SetInitialState();
            if( Actor.bDeleteMe )
                return null; // Not documented, maybe shouldn't be here
            
            if( !GIsEditor && Actor.Base == null && Actor.bCollideWorld && Actor.bShouldBaseAtStartup 
                && ((Actor.Physics == EPhysics.PHYS_None) || (Actor.Physics == EPhysics.PHYS_Rotating)) )
                Actor.FindBase();

            if( Actor.bDeleteMe == false )
            {
                AllActorsCollection.Add( Actor );
                return Actor;
            }
            return null;
        }
        
	
        // Export UActor::execDestroy(FFrame&, void* const)
        public virtual /*native(279) final function */bool Destroy()
        {
            // https://wiki.beyondunreal.com/What_happens_when_an_Actor_is_destroyed
            // https://wiki.beyondunreal.com/Legacy:Destroying_Objects
            // https://wiki.beyondunreal.com/Legacy:Creating_Actors_And_Objects
            
            // Do note that network logic is not implemented AT ALL,
            // see links above if you want to deal with that

            if( bNoDelete || bStatic )
                return false;

            if( bDeleteMe )
                return true;
            
            AllActorsCollection.Remove( this );
            
            // bPendingDelete
            bPendingDelete = true;
            
            // EndState()
            if(String.IsNullOrEmpty(this.GetStateName().Value) == false)
                #error how to properly call endstate
                this.EndState();
            
            // Destroyed()
            this.Destroyed();
            
            // Detach(), BaseChanged()
            if( this.Base != null )
            {
                this.Base.Detach(this);
                this.Base = null;
                BaseChange();
                foreach( var attachedChild in Attached )
                {
                    Detach(attachedChild);
                    attachedChild.Base = null;
                    attachedChild.BaseChange();
                }
                Attached.Remove(0, Attached.Length);
            }

            // UnTouch()
            foreach( var actor in Touching )
                actor.UnTouch( this );
            Touching.Remove(0, Touching.Length);

            // Owner.LostChild()
            this.Owner?.LostChild(this);
            /*foreach( var child in Children )
                child.Owner = null;
            Children.Remove(0, Children.Length);*/
            
            
            // The line below is really stupid but that's how UE3 handles it so I'll mirror those issues:
            
            // Be careful about calling Destroy() on an actor currently being destroyed.
            // This subsequent Destroy() call will processed as usual, so you will have to
            // manually implement something to break out of this recursion before it crashes the engine
            // with an infinite script recursion error.
            // Once an "inner" Destroy() call succeeds, any "outer" Destroy() will short-circuit and return True without calling any additional events.
            // -- beyondunreal
            
            bDeleteMe = true;
            return true;
        }



        static HashSet<Actor> AllActorsCollection = new HashSet<Actor>();
    }
}