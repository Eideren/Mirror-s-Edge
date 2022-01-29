namespace MEdge.Engine
{
	using System;
	using System.Reflection;
	using Core;
	using static UnityEngine.Debug;
    using Object = Core.Object;



    public partial class Actor
    {
	    public bool IsEncroacher() => bCollideActors && ( Physics == EPhysics.PHYS_RigidBody || Physics == EPhysics.PHYS_Interpolating );
	    
	    
        // Export UActor::execSpawn(FFrame&, void* const)
        public virtual /*native final function */ T Spawn<T>(Core.ClassT<T> SpawnClass, /*optional */
            Actor SpawnOwner = default, /*optional */Core.name? SpawnTag = default, /*optional */
            Object.Vector? SpawnLocation = default, /*optional */Object.Rotator? SpawnRotation = default, /*optional */
            Actor ActorTemplate = default, /*optional */bool? bNoCollisionFail = default) where T : Actor
        {
            // Decompiled from _E_UActor_execSpawn
            var result = UWorldBridge.GetUWorld().E_UWorld_SpawnActor( SpawnClass, 0, 0, SpawnLocation ?? Location, SpawnRotation ?? Rotation, ActorTemplate, bNoCollisionFail ?? false /* probably */, 0, SpawnOwner, this.Instigator, false );
            if( result != null && SpawnTag != null )
            {
                result.Tag = SpawnTag.Value;
            }
            return result;
        }
        
	
        // Export UActor::execDestroy(FFrame&, void* const)
        public virtual /*native(279) final function */bool Destroy()
        {
            LogWarning( "Destroy not implemented yet" );
            return true;
        }
        
        // Export UActor::execAllActors(FFrame&, void* const)
        public virtual /*native(304) final iterator function */System.Collections.Generic.IEnumerable<Actor/* Actor*/> AllActors(Core.ClassT<Actor> BaseClass)
        {
	        foreach( var actor in WorldInfo._allActors )
	        {
		        if( BaseClass.IsBaseOf( actor.Class ) )
			        yield return actor;
	        }
        }

        // Export UActor::execDynamicActors(FFrame&, void* const)
        public virtual /*native(313) final iterator function */System.Collections.Generic.IEnumerable<Actor/* Actor*/> DynamicActors(Core.ClassT<Actor> BaseClass)
        {
	        foreach( var actor in WorldInfo._allActors )
	        {
		        if( actor.bStatic == false && BaseClass.IsBaseOf( actor.Class ) )
			        yield return actor;
	        }
        }
        
        // Export UActor::execLocalPlayerControllers(FFrame&, void* const)
        public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<PlayerController/* PC*/> LocalPlayerControllers(Core.ClassT<PlayerController> BaseClass)
        {
	        foreach( var actor in WorldInfo._allActors )
	        {
		        if( BaseClass.IsBaseOf( actor.Class ) )
			        yield return actor as PlayerController;
	        }
        }
        
        public virtual /*native(305) final iterator function */System.Collections.Generic.IEnumerable<Actor/* Actor*/> ChildActors(Core.ClassT<Actor> BaseClass)
        {
	        foreach( var component in this.Children )
	        {
		        if( BaseClass.IsBaseOf( component.Class ) )
			        yield return component;
	        }
        }
	
        // Export UActor::execBasedActors(FFrame&, void* const)
        public virtual /*native(306) final iterator function */System.Collections.Generic.IEnumerable<Actor/* Actor*/> BasedActors(Core.ClassT<Actor> BaseClass)
        {
	        foreach( var component in this.Attached )
	        {
		        if( BaseClass.IsBaseOf( component.Class ) )
			        yield return component;
	        }
        }
	
        // Export UActor::execTouchingActors(FFrame&, void* const)
        public virtual /*native(307) final iterator function */System.Collections.Generic.IEnumerable<Actor/* Actor*/> TouchingActors(Core.ClassT<Actor> BaseClass)
        {
	        foreach( var component in this.Touching )
	        {
		        if( BaseClass.IsBaseOf( component.Class ) )
			        yield return component;
	        }
        }

		// Export UActor::execComponentList(FFrame&, void* const)
		public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<ActorComponent/* out_Component*/> ComponentList(Class BaseClass)
		{
			foreach( var component in this.Components )
			{
				if( BaseClass.IsBaseOf( component.Class ) )
					yield return component;
			}
		}

		// Export UActor::execAllOwnedComponents(FFrame&, void* const)
		public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<ActorComponent/* OutComponent*/> AllOwnedComponents(Core.ClassT<Component> BaseClass)
		{
			foreach( var component in this.AllComponents )
			{
				if( BaseClass.IsBaseOf( component.Class ) )
					yield return component;
			}
		}
        
		// Export UActor::execTraceActors(FFrame&, void* const)
		public virtual /*native(309) final iterator function */System.Collections.Generic.IEnumerable<(Actor/* Actor*/,Object.Vector/* HitLoc*/,Object.Vector/* HitNorm*/,Actor.TraceHitInfo/* HitInfo*/)> TraceActors(Core.ClassT<Actor> BaseClass, Object.Vector End, /*optional */Object.Vector? _Start/* = default*/, /*optional */Object.Vector? _Extent/* = default*/, /*optional */int? _ExtraTraceFlags = default)
		{
			NativeMarkers.MarkUnimplemented();
			yield break;
		}

		// Export UActor::execVisibleActors(FFrame&, void* const)
		public virtual /*native(311) final iterator function */System.Collections.Generic.IEnumerable<Actor/* Actor*/> VisibleActors(Core.ClassT<Actor> BaseClass, /*optional */float? _Radius = default, /*optional */Object.Vector? _Loc = default)
		{
			NativeMarkers.MarkUnimplemented();
			yield break;
		}

		// Export UActor::execVisibleCollidingActors(FFrame&, void* const)
		public virtual /*native(312) final iterator function */System.Collections.Generic.IEnumerable<Actor/* Actor*/> VisibleCollidingActors(Core.ClassT<Actor> BaseClass, float Radius, /*optional */Object.Vector? _Loc = default, /*optional */bool? _bIgnoreHidden = default)
		{
			NativeMarkers.MarkUnimplemented();
			yield break;
		}

		// Export UActor::execCollidingActors(FFrame&, void* const)
		public virtual /*native(321) final iterator function */System.Collections.Generic.IEnumerable<Actor/* Actor*/> CollidingActors(Core.ClassT<Actor> BaseClass, float Radius, /*optional */Object.Vector? _Loc = default, /*optional */bool? _bUseOverlapCheck = default)
		{
			NativeMarkers.MarkUnimplemented();
			yield break;
		}

		// Export UActor::execOverlappingActors(FFrame&, void* const)
		public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<Actor/* out_Actor*/> OverlappingActors(Core.ClassT<Actor> BaseClass, float Radius, /*optional */Object.Vector? _Loc = default, /*optional */bool? _bIgnoreHidden = default)
		{
			NativeMarkers.MarkUnimplemented();
			yield break;
		}
	
		// Export UActor::execGetGravityZ(FFrame&, void* const)
		public virtual /*native function */float GetGravityZ()
		{
			return WorldInfo.GetGravityZ();
		}
	
		// Export UActor::execSetPhysics(FFrame&, void* const)
		//public virtual /*native(3970) final function */void SetPhysics(Actor.EPhysics newPhysics)
		//{
		//	this.Physics = newPhysics;
		//	NativeMarkers.MarkUnimplemented();
		//}
		
		// Export UActor::execAttachComponent(FFrame&, void* const)
		public virtual /*native final function */void AttachComponent(ActorComponent NewComponent)
		{
			if(this.Components.Find( NewComponent ) == -1)
				this.Components.Add( NewComponent );
		}

		// Export UActor::execDetachComponent(FFrame&, void* const)
		public virtual /*native final function */void DetachComponent(ActorComponent ExComponent)
		{
			this.Components.RemoveItem(ExComponent);
		}
		
		// Export UActor::execSetLocation(FFrame&, void* const)
		public virtual /*native(267) final function */bool SetLocation(Object.Vector NewLocation)
		{
			this.Location = NewLocation;
			// This method might need to check for encroachment ?
			NativeMarkers.MarkUnimplemented();
			return true;
		}

		// Export UActor::execSetRotation(FFrame&, void* const)
		public virtual /*native(299) final function */bool SetRotation(Object.Rotator NewRotation)
		{
			this.Rotation = NewRotation;
			// This method might need to check for encroachment ?
			NativeMarkers.MarkUnimplemented();
			return true;
		}
	
		// Export UActor::execSetOwner(FFrame&, void* const)
		public virtual /*native(272) final function */void SetOwner(Actor NewOwner)
		{
			if (Owner != NewOwner && !IsPendingKill())
			{
				if (NewOwner != NULL && NewOwner.IsOwnedBy(this))
				{
					debugf("NAME_Error", TEXT("SetOwner(): Failed to set '%s' owner of '%s' because it would cause an Owner loop"), NewOwner.Name, NewOwner.Name);
					return;
				}

				// Sets this actor's parent to the specified actor.
				Actor OldOwner = Owner;
				if( Owner != NULL )
				{
					Owner.LostChild( this );
					if (OldOwner != Owner)
					{
						// LostChild() resulted in another SetOwner()
						return;
					}
					// remove from old owner's Children array
					//verifySlow(Owner->Children.RemoveItem(this) == 1);
				}

				Owner = NewOwner;

				if( Owner != NULL )
				{
					// add to new owner's Children array
					checkSlow(!Owner.Children.ContainsItem(this));
					Owner.Children.AddItem(this);

					Owner.GainedChild( this );
					if (Owner != NewOwner)
					{
						// GainedChild() resulted in another SetOwner()
						return;
					}
				}

				// mark all components for which Owner is relevant for visibility to be updated
				MarkOwnerRelevantComponentsDirty(this);

				bNetDirty = TRUE;
			}
		}
		
		// Export UActor::execIsOwnedBy(FFrame&, void* const)
		public virtual /*native final function */bool IsOwnedBy(Actor TestOwner)
		{
			for( Actor Arg=this; Arg; Arg=Arg.Owner )
			{
				if( Arg == TestOwner )
					return true;
			}
			return false;
		}
	    
		static void MarkOwnerRelevantComponentsDirty(Actor TheActor)
		{
			NativeMarkers.MarkUnimplemented();
		}
		public override bool IsPendingKill()
		{
			return bDeleteMe || HasAnyFlags(EObjectFlags.RF_PendingKill);
		}
		
		public virtual /*native(280) final function */void SetTimer(float Rate, /*optional */bool? _inbLoop = default, /*optional */name? _inTimerFunc = default, /*optional */Object _inObj = default)
		{
			var bLoop = _inbLoop ?? false;
			var FuncName = _inTimerFunc ?? "Timer";
			var inObj = _inObj ?? this;
			
			if (bStatic)
			{
				debugf("NAME_Error", TEXT("SetTimer() called on bStatic Actor %s"), Name);
			}
			else
			{
				if( !inObj ) { inObj = this; }

				// search for an existing timer first
				bool bFoundEntry = false;
				for (var Idx = 0; Idx < Timers.Num() && !bFoundEntry; Idx++)
				{
					// If matching function and object
					if( Timers[Idx].FuncName == FuncName &&
					    Timers[Idx].TimerObj == inObj )
					{
						bFoundEntry = true;
						// if given a 0.f rate, disable the timer
						if (Rate == 0f)
						{
							// timer will be cleared in UpdateTimers
							Timers[Idx].Rate = 0f;
						}
						// otherwise update with new rate
						else
						{
							Timers[Idx].bLoop = bLoop;
							Timers[Idx].Rate = Rate;
							Timers[Idx].Count = 0f;
						}
					}
				}
				// if no timer was found, add a new one
				if (!bFoundEntry)
				{
					/*#ifdef _DEBUG
					// search for the function and assert that it exists
					UFunction *newFunc = inObj->FindFunctionChecked(FuncName);
					newFunc = NULL;
					#endif*/
					//int Idx = Timers.AddZeroed();
					Timers.Add( new TimerData
					{
						TimerObj = inObj,
						FuncName = FuncName,
						bLoop = bLoop,
						Rate = Rate,
						Count = 0f,
					} );
					/*Timers[Idx].TimerObj = inObj;
					Timers[Idx].FuncName = FuncName;
					Timers[Idx].bLoop = bLoop;
					Timers[Idx].Rate = Rate;
					Timers[Idx].Count = 0f;*/
				}
			}
		}
		
		public virtual /*native final function */void ClearTimer(/*optional */name? FuncName = default, /*optional */Object inObj = default)
		{
			FuncName ??= "Timer";
			if( !inObj ) { inObj = this; }

			for (var Idx = 0; Idx < Timers.Num(); Idx++)
			{
				// If matching function and object
				if( Timers[Idx].FuncName == FuncName &&
				    Timers[Idx].TimerObj == inObj )
				{
					// set the rate to 0.f and let UpdateTimers clear it
					Timers[Idx].Rate = 0f;
				}
			}
		}
		
		public void UpdateTimers(float DeltaSeconds)
		{
			// split into two loops to avoid infinite loop where
			// the timer is called, causes settimer to be called
			// again with a rate less than our current delta
			// and causing an invalid index to be accessed
			for (int Idx = 0; Idx < Timers.Num(); Idx++)
			{
				// just increment the counters
				Timers[Idx].Count += DeltaSeconds;
			}

			bool bRemoveTimer = false;
			
			for (int Idx = 0; Idx < Timers.Num() && !IsPendingKill(); Idx++)
			{
				// check for a cleared timer
				// we check this here instead of the previous loop so that if a timer function that is called clears some other timer, that other timer doesn't get called (since its Rate would then be zero)
				if (Timers[Idx].Rate == 0f)
				{
					Timers.Remove(Idx--, 1);
				}
				else if (Timers[Idx].Rate < Timers[Idx].Count)
				{
					Object TimerObj = Timers[Idx].TimerObj;

					bRemoveTimer = false;

					// calculate how many times the timer may have elapsed
					// (for large delta times on looping timers)
					int CallCount = Timers[Idx].bLoop ? (int)(Timers[Idx].Count/Timers[Idx].Rate) : 1;
					
					// lookup the function to call
					var flags = BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic;


					Timer_del Func;
					if( TimerObj is Actor a && Timers[ Idx ].FuncName == "Timer" )
					{
						Func = a.Timer;
					} 
					else if( TimerObj.GetType().GetProperty( Timers[ Idx ].FuncName, flags ) is PropertyInfo p && p.GetValue( TimerObj ) is Delegate d )
					{
						Func = () => d.DynamicInvoke();
					}
					else if( TimerObj.GetType().GetMethod( Timers[ Idx ].FuncName, flags ) is MethodInfo m )
					{
						Func = () => m.Invoke( TimerObj, null );
					}
					else
					{
						throw new Exception();
					}
					//Function Func = TimerObj.FindFunction();
					// if we didn't find the function, or it's not looping
					if( Func == NULL ||
						!Timers[Idx].bLoop )
					{
						if( Func == NULL ) 
						{
							debugf("NAME_Warning",
								TEXT("Failed to find function %s for timer in actor %s"),
								Timers[Idx].FuncName.ToString(), TimerObj.Name );
						}
						// mark the timer for removal
						bRemoveTimer = true;
					}
					else
					{
						// otherwise reset for loop
						Timers[Idx].Count -= CallCount * Timers[Idx].Rate;
					}

					// now call the function
					if( Func != NULL )
					{
						// allocate null func params
						//void *FuncParms = appAlloca(Func.ParmsSize);
						while( CallCount > 0 )
						{
							// make sure any params are cleared
							//appMemzero(FuncParms, Func->ParmsSize);

							// and call the function
							Func.Invoke();
							//TimerObj.ProcessEvent(Func,FuncParms);
							CallCount--;
							
							// Make sure Timer is still relevant
							if( !IsPendingKill() )
							{
								// check to see if the timer was cleared from the last call
								if( Timers[Idx].Rate == 0 )
								{
									// mark the timer for removal
									bRemoveTimer = true;
									break;
								}
								else if( Timers[Idx].Count == 0f )
								{
									// If timer has been re set, then do not flag for removal.
									bRemoveTimer = false;
								}
							}
						}
					}

					//check to see if this timer should be removed
					if( bRemoveTimer && 
						!IsPendingKill() )
					{
						Timers.Remove(Idx--,1);
					}
				}
			}
		}
    }
}