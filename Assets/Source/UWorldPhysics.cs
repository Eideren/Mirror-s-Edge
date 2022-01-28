namespace MEdge.Engine
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.CompilerServices;
	using Core;
	using Source;
	using UnityEngine;
	using FLOAT = System.Single;
	using INT = System.Int32;
	using FVector = Core.Object.Vector;
	using FRotator = Core.Object.Rotator;
	using FMatrix = Core.Object.Matrix;
	using UBOOL = System.Boolean;
	using FCheckResult = Source.DecFn.CheckResult;
	using DWORD = System.Int32;
	using Object = Core.Object;
	using static MEdge.Source.DecFn;
	using static MEdge.Core.Object;



	public partial class UWorld
	{
		const bool TRUE = true;
		const bool FALSE = false;

		UWorld GWorld => this;
		
		public IUWorld BackupHash => this;
		public IUWorld Hash => this;
		public WorldInfo GetWorldInfo() => WorldInfo;
		public float GetTimeSeconds() => GetWorldInfo().TimeSeconds;
		bool IUWorld.HasBegunPlay() => GetWorldInfo().bBegunPlay;
		public PhysicsVolume GetDefaultPhysicsVolume() => GetWorldInfo().GetDefaultPhysicsVolume();
		public bool InTick => true;
		public bool bPostTickComponentUpdate => false;

		public unsafe bool MoveActor( Actor Actor, in Object.Vector Delta, in Object.Rotator NewRotation, uint MoveFlags, ref DecFn.CheckResult Hit )
		{
			//SCOPE_CYCLE_COUNTER(STAT_MoveActorTime);

			//check(Actor!=NULL);

		/*#if defined(SHOW_MOVEACTOR_TAKING_LONG_TIME) || LOOKING_FOR_PERF_ISSUES
			DWORD MoveActorTakingLongTime=0;
			CLOCK_CYCLES(MoveActorTakingLongTime);
		#endif*/


			if ( Actor.bDeleteMe )
			{
				//debugf(TEXT("%s deleted move physics %d"),*Actor.GetName(),Actor.Physics);
				return false;
			}
			if( (Actor.bStatic || !Actor.bMovable) && HasBegunPlay )
				return false;

			// Init CheckResult
			Hit.Actor = null;
			Hit.Time  = 1f;

		/*#if !FINAL_RELEASE
			// Check to see if this move is illegal during this tick group
			if (InTick && TickGroup == TG_DuringAsyncWork && Actor.bBlockActors)
			{
				debugf(NAME_Error,TEXT("Can't move collidable actor (%s) during async work!"),*Actor.GetName());
			}
		#endif*/

			// Set up.
			FLOAT DeltaSize;
			FVector DeltaDir;
			if( Delta.IsZero() )
			{
				// Skip if no vector or rotation.
				if( NewRotation==Actor.Rotation && !Actor.bAlwaysEncroachCheck )
				{
					return true;
				}
				DeltaSize = 0f;
				DeltaDir = Delta;
			}
			else
			{
				DeltaSize = Delta.Size();
				DeltaDir = Delta/DeltaSize;
			}

			UBOOL bNoFail = (MoveFlags & MOVE_NoFail) != default;
			UBOOL bIgnoreBases = (MoveFlags & MOVE_IgnoreBases) != default;

			FMemMark Mark = new FMemMark(GMem);
			INT     MaybeTouched   = 0;
			FCheckResult* FirstHit = null;
			FVector FinalDelta = Delta;
			FRotator OldRotation = Actor.Rotation;
			UBOOL bMovementOccurred = TRUE;

			if ( Actor.IsEncroacher() )
			{
				if( Actor.bNoEncroachCheck || !Actor.bCollideActors || bNoFail )
				{
					// Update the location.
					Actor.Location += FinalDelta;
					Actor.Rotation = NewRotation;

					// Update any collision components.  If we are in the Tick phase, only upgrade components with collision.
					// This is done before moving attached actors so they can test for encroachment based on the correct mover position.
					// It is done before touch so that components are correctly up-to-date when we call Touch events. Things like
					// Kismet's touch event do an IsOverlapping - which requires the component to be in the right location.
					// This will not fix all problems with components being out of date though - for example, attachments of an Actor are not 
					// updated at this point.
					Actor.ForceUpdateComponents( GWorld.InTick );
				}
				else if( CheckEncroachment( Actor, Actor.Location + FinalDelta, NewRotation, true ) )
				{
					// Abort if encroachment declined.
					Mark.Pop();
					return false;
				}
				// if checkencroachment() doesn't fail, collision components will have been updated
			}
			else
			{
				// Perform movement collision checking if needed for this actor.
				if( (Actor.bCollideActors || Actor.bCollideWorld) &&
					Actor.CollisionComponent &&
					(DeltaSize != 0f) )
				{
					// Check collision along the line.
					DWORD TraceFlags = 0;
					if( (MoveFlags & MOVE_TraceHitMaterial) != default )
					{
						TraceFlags |= TRACE_Material;
					}
					
					if( Actor.bCollideActors )
					{
						TraceFlags |= TRACE_Pawns | TRACE_Others | TRACE_Volumes;
					}

					if( Actor.bCollideWorld )
					{
						TraceFlags |= TRACE_World;
					}

					if( Actor.bCollideComplex )
					{
						TraceFlags |= TRACE_ComplexCollision;
					}

					FVector ColCenter;

					if( Actor.CollisionComponent.IsValidComponent() )
					{
						if( !Actor.CollisionComponent.IsAttached() )
						{
							throw new Exception();
							//appErrorf(TEXT("%s collisioncomponent %s not initialized deleteme %d"),*Actor.GetName(), *Actor.CollisionComponent.GetName(), Actor.bDeleteMe);
						}
						ColCenter = Actor.CollisionComponent.Bounds.Origin;
					}
					else
					{
						ColCenter = Actor.Location;
					}

					FirstHit = this.MultiLineCheck
					(
						ref GMem,
						ColCenter + Delta,
						ColCenter,
						Actor.GetCylinderExtent(),
						(uint)TraceFlags,
						Actor
					);

					// Handle first blocking actor.
					if( Actor.bCollideWorld || Actor.bBlockActors )
					{
						Hit = new FCheckResult(1f);
						for( FCheckResult* Test=FirstHit; Test != null; Test=Test->GetNext() )
						{
							if( (!bIgnoreBases || !Actor.IsBasedOn(Test->Actor)) && !Test->Actor.IsBasedOn(Actor) )
							{
								MaybeTouched = 1;
								if( Actor.IsBlockedBy(Test->Actor,Test->Component) )
								{
									Hit = *Test;
									break;
								}
							}
						}
						/* logging for stuck in collision
						if ( Hit.bStartPenetrating && Actor.GetAPawn() )
						{
							if ( Hit.Actor )
								debugf(TEXT("Started penetrating %s time %f dot %f"), *Hit.Actor.GetName(), Hit.Time, (Delta.SafeNormal() | Hit.Normal));
							else
								debugf(TEXT("Started penetrating no actor time %f dot %f"), Hit.Time, (Delta.SafeNormal() | Hit.Normal));
						}
						*/
						FinalDelta = Delta * Hit.Time;
					}
				}

				if ( bMovementOccurred )
				{
					// Update the location.
					Actor.Location += FinalDelta;
					Actor.Rotation = NewRotation;

					// Update any collision components.  If we are in the Tick phase (and not in the final component update phase), only upgrade components with collision.
					// This is done before moving attached actors so they can test for encroachment based on the correct mover position.
					// It is done before touch so that components are correctly up-to-date when we call Touch events. Things like
					// Kismet's touch event do an IsOverlapping - which requires the component to be in the right location.
					// This will not fix all problems with components being out of date though - for example, attachments of an Actor are not 
					// updated at this point.
					Actor.ForceUpdateComponents( GWorld.InTick && !GWorld.bPostTickComponentUpdate );
				}
			}

			// Move the based actors (after encroachment checking).
			if( (Actor.Attached.Num() > 0) && bMovementOccurred )
			{
				// Move base.
				FRotator ReducedRotation = new FRotator(0,0,0);

				FMatrix OldMatrix = FRotationMatrix( OldRotation ).Transpose();
				FMatrix NewMatrix = FRotationMatrix( NewRotation );
				UBOOL bRotationChanged = (OldRotation != Actor.Rotation);
				if( bRotationChanged )
				{
					ReducedRotation = FRotator( ReduceAngle(Actor.Rotation.Pitch)	- ReduceAngle(OldRotation.Pitch),
												ReduceAngle(Actor.Rotation.Yaw)	- ReduceAngle(OldRotation.Yaw)	,
												ReduceAngle(Actor.Rotation.Roll)	- ReduceAngle(OldRotation.Roll) );
				}

				// Calculate new transform matrix of base actor (ignoring scale).
				FMatrix BaseTM = FRotationTranslationMatrix(Actor.Rotation, Actor.Location);

				List<(Actor Actor, Vector OldLocation, Rotator OldRotation)> savedPositions = null;
				//FSavedPosition* SavedPositions = NULL;

				for( INT i=0; i<Actor.Attached.Num(); i++ )
				{
					// For non-skeletal based actors. Skeletal-based actors are handled inside USkeletalMeshComponent::Update
					Actor Other = Actor.Attached[i];
					if ( Other && !Other.BaseSkelComponent )
					{
						savedPositions ??= new List<(Actor, Vector, Rotator)>();
						savedPositions.Add((Other, Other.Location, Other.Rotation));
						//SavedPositions = new(GMem) FSavedPosition(Other, Other.Location, Other.Rotation, SavedPositions);

						FVector   RotMotion = new FVector( 0, 0, 0 );
						FCheckResult OtherHit = new FCheckResult(1f);
						UBOOL bMoveFailed = FALSE;
						if( Other.Physics == Actor.EPhysics.PHYS_Interpolating || (Other.bHardAttach && !Other.bBlockActors) )
						{
							var HardRelMatrix = FRotationTranslationMatrix(Other.RelativeRotation, Other.RelativeLocation);
							FMatrix NewWorldTM = HardRelMatrix * BaseTM;
							FVector NewWorldPos = NewWorldTM.GetOrigin();
							FRotator NewWorldRot = NewWorldTM.Rotator();
							MoveActor( Other, NewWorldPos - Other.Location, NewWorldRot, MOVE_IgnoreBases, ref OtherHit );
							bMoveFailed = (OtherHit.Time < 1f) || (NewWorldRot != Other.Rotation);
						}
						else if ( Other.bIgnoreBaseRotation )
						{
							// move attached actor, ignoring effects of any changes in its base's rotation.
							MoveActor( Other, FinalDelta, Other.Rotation, MOVE_IgnoreBases, ref OtherHit );
						}
						else
						{
							FRotator finalRotation = Other.Rotation + ReducedRotation;

							if( bRotationChanged )
							{
								Other.UpdateBasedRotation(ref finalRotation, ReducedRotation);

								// Handle rotation-induced motion.
								RotMotion = NewMatrix.TransformFVector( OldMatrix.TransformFVector( Other.RelativeLocation ) ) - Other.RelativeLocation;
							}
							// move attached actor
							MoveActor( Other, FinalDelta + RotMotion, finalRotation, MOVE_IgnoreBases, ref OtherHit );
						}

						if( !bNoFail && !bMoveFailed &&
							// If neither actor should check for encroachment, skip overlapping test
						   ((!Actor.bNoEncroachCheck || !Other.bNoEncroachCheck ) &&
							 Other.IsBlockedBy( Actor, Actor.CollisionComponent )) )
						{
							// check if encroached
							// IsOverlapping() returns false for based actors, so temporarily clear the base.
							UBOOL bStillBased = (Other.Base == Actor);
							if ( bStillBased )
								Other.Base = null;
							UBOOL bStillEncroaching = Other.IsOverlapping(Actor);
							if ( bStillBased )
								Other.Base = Actor;
							// if encroachment declined, move back to old location
							if ( bStillEncroaching && Actor.EncroachingOn(Other) )
							{
								bMoveFailed = TRUE;
							}
						}
						if ( bMoveFailed )
						{
							Actor.Location -= FinalDelta;
							Actor.Rotation = OldRotation;
							Actor.ForceUpdateComponents( GWorld.InTick );
							for( int j = savedPositions.Count - 1; j >= 0; j-- )
							{
								var Pos = savedPositions[ i ];
								if ( Pos.Actor && !Pos.Actor.bDeleteMe )
								{
									MoveActor( Pos.Actor, Pos.OldLocation - Pos.Actor.Location, Pos.OldRotation, MOVE_IgnoreBases, ref OtherHit );
									if (bRotationChanged)
									{
										Pos.Actor.ReverseBasedRotation();
									}
								}
							}
							/*for( FSavedPosition* Pos = SavedPositions; Pos!=NULL; Pos=Pos.GetNext() )
							{
								if ( Pos.Actor && !Pos.Actor.bDeleteMe )
								{
									MoveActor( Pos.Actor, Pos.OldLocation - Pos.Actor.Location, Pos.OldRotation, MOVE_IgnoreBases, OtherHit );
									if (bRotationChanged)
									{
										Pos.Actor.ReverseBasedRotation();
									}
								}
							}*/
							Mark.Pop();
							return false;
						}
					}
				}
			}

			// update relative location of this actor
			if( Actor.Base && !Actor.bHardAttach && Actor.Physics != Actor.EPhysics.PHYS_Interpolating && !Actor.BaseSkelComponent )
			{
				Actor.RelativeLocation = Actor.Location - Actor.Base.Location;
				
				if( !Actor.Base.bWorldGeometry && (OldRotation != Actor.Rotation) )
				{
					Actor.UpdateRelativeRotation();
				}
			}

			// Handle bump and touch notifications.
			if( Hit.Actor )
			{
				// Notification that Actor has bumped against the level.
				if( Hit.Actor.bWorldGeometry )
				{
					Actor.NotifyBumpLevel(Hit.Location, Hit.Normal);
				}
				// Notify first bumped actor unless it's the level or the actor's base.
				else if( !Actor.IsBasedOn(Hit.Actor) )
				{
					// Notify both actors of the bump.
					Hit.Actor.NotifyBump(Actor, Actor.CollisionComponent, Hit.Normal);
					Actor.NotifyBump(Hit.Actor, Hit.Component, Hit.Normal);
				}
			}

			// Handle Touch notifications.
			if( MaybeTouched.AsBool() || (!Actor.bBlockActors && !Actor.bCollideWorld && Actor.bCollideActors) )
			{
				for( FCheckResult* Test=FirstHit; Test != null && Test->Time<Hit.Time; Test=Test->GetNext() )
				{
					if ( (!bIgnoreBases || !Actor.IsBasedOn(Test->Actor)) &&
						(!Actor.IsBlockedBy(Test->Actor,Test->Component)) && Actor != Test->Actor)
					{
						Actor.BeginTouch(Test->Actor, Test->Component, Test->Location, Test->Normal);
					}
				}
			}

			// UnTouch notifications.
			Actor.UnTouchActors();

			// Set actor zone.
			Actor.SetZone(FALSE,FALSE);
			Mark.Pop();

			// Update physics 'pushing' body.
			Actor.UpdatePushBody();

		/*#if defined(SHOW_MOVEACTOR_TAKING_LONG_TIME) || LOOKING_FOR_PERF_ISSUES
			UNCLOCK_CYCLES(MoveActorTakingLongTime);
			FLOAT MSec = MoveActorTakingLongTime * GSecondsPerCycle * 1000.f;
			if( MSec > SHOW_MOVEACTOR_TAKING_LONG_TIME_AMOUNT )
			{
				debugf( NAME_PerfWarning, TEXT("%10f executing MoveActor for %s"), MSec, *Actor.GetFullName() );
			}
		#endif*/

			// Return whether we moved at all.
			return Hit.Time>0f;
		}
		
		unsafe UBOOL CheckEncroachment
		(
			Actor			Actor,
			FVector			TestLocation,
			FRotator		TestRotation,
			UBOOL			bTouchNotify
		)
		{
			check(Actor);

			// If this actor doesn't need encroachment checking, allow the move.
			if (!Actor.bCollideActors && !Actor.IsEncroacher())
			{
				return false;
			}

			// set up matrices for calculating movement caused by mover rotation
			FMatrix WorldToLocal = default, TestLocalToWorld = default;
			FVector StartLocation = Actor.Location;
			FRotator StartRotation = Actor.Rotation;
			if ( Actor.IsEncroacher() )
			{
				// get old transform
				WorldToLocal = Actor.WorldToLocal();

				// move the actor 
				if ( (Actor.Location != TestLocation) || (Actor.Rotation != TestRotation) )
				{
					Actor.Location = TestLocation;
					Actor.Rotation = TestRotation;
					Actor.ForceUpdateComponents(GWorld.InTick);
				}
				TestLocalToWorld = Actor.LocalToWorld();
			}

			FLOAT ColRadius = default, ColHeight = default;
			Actor.GetBoundingCylinder(ref ColRadius, ref ColHeight);
			UBOOL bIsZeroExtent = (ColRadius == 0f) && (ColHeight == 0f);

			// Query the mover about what he wants to do with the actors he is encroaching.
			FMemMark Mark = new FMemMark(GMem);
			FCheckResult* FirstHit = Hash != null ? Hash.ActorEncroachmentCheck(ref GMem, Actor, TestLocation, TestRotation, TRACE_AllColliding & (~TRACE_LevelGeometry)) : null;	
			for( FCheckResult* Test = FirstHit; Test!=null; Test=Test->GetNext() )
			{
				if
				(	Test->Actor!=Actor
				&&	!Test->Actor.bWorldGeometry
				&&  !Test->Actor.IsBasedOn(Actor)
				&& (Test->Component == NULL || (bIsZeroExtent ? Test->Component.BlockZeroExtent : Test->Component.BlockNonZeroExtent))
				&&	Actor.IsBlockedBy( Test->Actor, Test->Component ) )
				{
					UBOOL bStillEncroaching = true;
					// Actors can be pushed by movers or karma stuff.
					if (Actor.IsEncroacher() && !Test->Actor.IsEncroacher() && Test->Actor.bPushedByEncroachers)
					{
						// check if mover can safely push encroached actor
						// Move test actor away from mover
						FVector MoveDir = TestLocation - StartLocation;
						FVector OldLoc = Test->Actor.Location;
						FVector Dest = Test->Actor.Location + MoveDir;
						if ( TestRotation != StartRotation )
						{
							FVector TestLocalLoc = WorldToLocal.TransformFVector(Test->Actor.Location);
							// multiply X 1.5 to account for max bounding box center to colliding edge dist change
							MoveDir += 1.5f * (TestLocalToWorld.TransformFVector(TestLocalLoc) - Test->Actor.Location);
						}
						// temporarily turn off blocking for encroacher, so it won't affect the movement
						UBOOL bRealBlockActors = Actor.bBlockActors;
						Actor.bBlockActors = FALSE;
						Test->Actor.MoveSmooth(MoveDir);

						// see if mover still encroaches test actor
						FCheckResult TestHit = new FCheckResult(1f);
						bStillEncroaching = Test->Actor.IsOverlapping(Actor, ref TestHit);
						if ( bStillEncroaching && Test->Actor.GetAPawn() )
						{
							// try moving away
							FCheckResult Hit = new FCheckResult(1f);
							Actor.ActorLineCheck(ref Hit, Actor.Location, Test->Actor.Location,FVector(0f,0f,0f), TRACE_AllColliding);
							if ( Hit.Time < 1f )
							{
								FVector PushOut = (Hit.Normal + FVector(0f,0f,0.1f)) * Test->Actor.GetAPawn().CylinderComponent.CollisionRadius;
								Test->Actor.MoveSmooth(PushOut);
								MoveDir += PushOut;
								bStillEncroaching = Test->Actor.IsOverlapping(Actor, ref TestHit);
							}
						}
						Actor.bBlockActors = bRealBlockActors;
						if ( !bStillEncroaching ) //push test actor back toward brush
						{
							MoveActor( Test->Actor, -1f * MoveDir, Test->Actor.Rotation, 0, ref TestHit );
						}
						Test->Actor.PushedBy(Actor);
					}
					if ( bStillEncroaching && Actor.EncroachingOn(Test->Actor) )
					{
						Mark.Pop();
					
						// move the encroacher back
						Actor.Location = StartLocation;
						Actor.Rotation = StartRotation;

						const UBOOL bTransformOnly = TRUE;
						Actor.ForceUpdateComponents(GWorld.InTick, bTransformOnly);
						return true;
					}
					else 
					{
						Actor.RanInto(Test->Actor);
					}
				}
			}

			// If bTouchNotify, send Touch and UnTouch notifies.
			if( bTouchNotify )
			{
				// UnTouch notifications.
				Actor.UnTouchActors();
			}

			// Notify the encroached actors but not the level.
			for( FCheckResult* Test = FirstHit; Test != null; Test=Test->GetNext() )
				if
				(	Test->Actor!=Actor
				&&	!Test->Actor.bWorldGeometry
				&&  !Test->Actor.IsBasedOn(Actor)
				&&	Test->Actor!=GetWorldInfo()
				&& (Test->Component == NULL || (bIsZeroExtent ? Test->Component.BlockZeroExtent : Test->Component.BlockNonZeroExtent)) )
				{
					if( Actor.IsBlockedBy(Test->Actor,Test->Component) )
					{
						Test->Actor.EncroachedBy(Actor);
					}
					else if (bTouchNotify)
					{
						// Make sure Test->Location is not Zero, if that's the case, use TestLocation
						FVector	HitLocation = Test->Location.IsZero() ? TestLocation : Test->Location;

						// Make sure we have a valid Normal
						FVector NormalDir = Test->Normal.IsZero() ? (TestLocation - Actor.Location) : Test->Normal;
						if( !NormalDir.IsZero() )
						{
							NormalDir.Normalize();
						}
						else
						{
							NormalDir = TestLocation - Test->Actor.Location;
							NormalDir.Normalize();
						}
						Actor.BeginTouch( Test->Actor, Test->Component, HitLocation, NormalDir );
					}
				}
									
			Mark.Pop();

			// Ok the move.
			return false;
		}

		public unsafe bool SingleLineCheck( ref DecFn.CheckResult Hit, Actor SourceActor, in Object.Vector End, in Object.Vector Start, int TraceFlags, in Object.Vector Extent = default, int SourceLight = 0 )
		{
			//SCOPE_CYCLE_COUNTER(STAT_SingleLineCheck);

			// Get list of hit actors.
			FMemMark Mark = new FMemMark(GMem);

			//If enabled, capture the callstack that triggered this linecheck
			//LINE_CHECK_TRACE(TraceFlags, &Extent);

			TraceFlags = TraceFlags | TRACE_SingleResult;
			FCheckResult* FirstHit = MultiLineCheck
			(
				ref GMem,
				End,
				Start,
				Extent,
				(uint)TraceFlags,
				SourceActor,
				SourceLight == 0 ? null : throw new NotImplementedException()
			);
			
			if( FirstHit != default )
			{
				Hit = *FirstHit;

				DetermineCorrectPhysicalMaterial<FCheckResult, FCheckResult>( Hit, Hit );	

				Hit.Material = Hit.Material ? Hit.Material.GetMaterial() : null;
			}
			else
			{
				Hit.Time = 1f;
				Hit.Actor = null;
			}

			Mark.Pop();
			return FirstHit==default;
		}
		
		/*template< typename HIT_DATA, typename OUT_STRUCT >
		*/static void DetermineCorrectPhysicalMaterial<T1, T2>( CheckResult HitData, CheckResult OutHitInfo/*const HIT_DATA& HitData, OUT_STRUCT& OutHitInfo*/ )
		{
			NativeMarkers.MarkUnimplemented();
			/*// check to see if this has a Physical Material Override.  If it does then use that
			if( ( HitData.Component != NULL )
			    && ( HitData.Component->PhysMaterialOverride != NULL )
			)
			{
				OutHitInfo.PhysMaterial = HitData.Component->PhysMaterialOverride;
			}
			// if the physical material is already set then we know we hit a skeletal mesh and should return that PhysMaterial
			else if( HitData.PhysMaterial != NULL )
			{
				OutHitInfo.PhysMaterial = HitData.PhysMaterial;
			}
			// else we need to look at the Material and use that for our PhysMaterial.
			// The GetPhysicalMaterial is virtual and will return the correct Material for all
			// Material Types
			// The PhysMaterial may still be null
			else if( HitData.Material != NULL )
			{
				OutHitInfo.PhysMaterial = HitData.Material->GetPhysicalMaterial();
			}
			// we have the case of a mesh inside a blocking volume when that mesh has no collision
			else if( FindPhysicalMaterialOnStaticMeshActor( HitData, OutHitInfo ) == TRUE )
			{
				// the FindPhysicalMaterialOnStaticMeshActor did the work
			}	
			else
			{
				OutHitInfo.PhysMaterial = NULL;
			}*/
		}

		public unsafe bool FindSpot( in Object.Vector Extent, ref Object.Vector Location, bool bUseComplexCollision )
		{
			FCheckResult Hit = new FCheckResult(1f);

			// check if fits at desired location
			if( !EncroachingWorldGeometry(ref Hit, Location, Extent, bUseComplexCollision) )
			{
				return TRUE;
			}

			if( Extent.IsZero() )
			{
				return FALSE;
			}

			FVector StartLoc = Location;

			// Check if slice fits
			INT bKeepTrying = 1;

			if( CheckSlice(ref Location, Extent, ref bKeepTrying) )
			{
				return TRUE;
			}
			else if( !(bKeepTrying != default) )
			{
				return FALSE;
			}

			// Try to fit half-slices
			Location = StartLoc;
			FVector SliceExtent = 0.5f * Extent;
			SliceExtent.Z = 1f;
			INT NumFit = 0;
			for (INT i=-1; i<2; i+=2)
			{
				for (INT j=-1; j<2; j+=2)
				{
					if( NumFit < 2 )
					{
						FVector SliceOffset = FVector(0.55f*Extent.X*i, 0.55f*Extent.Y*j, 0f);
						if( !EncroachingWorldGeometry(ref Hit, StartLoc+SliceOffset, SliceExtent, bUseComplexCollision) )
						{
							NumFit++;
							Location += 1.1f * SliceOffset;
						}
					}
				}
			}

			if( NumFit == 0 )
			{
				return FALSE;
			}

			// find full-sized slice to check
			if( NumFit == 1 )
			{
				Location = 2f * Location - StartLoc;
			}

			SingleLineCheck(ref Hit, null, Location, StartLoc, TRACE_World);
			if( Hit.Actor )
			{
				return FALSE;
			}

			if (!EncroachingWorldGeometry(ref Hit,Location, Extent, bUseComplexCollision) || CheckSlice(ref Location, Extent, ref bKeepTrying))
			{
				// adjust toward center
				SingleLineCheck(ref Hit, null, StartLoc + 0.2f * (StartLoc - Location), Location, TRACE_World, Extent);
				if( Hit.Actor )
				{
					Location = Hit.Location;
				}
				return TRUE;
			}
			return FALSE;
		}
		public UBOOL CheckSlice(ref FVector Location, in FVector Extent, ref INT bKeepTrying)
		{
			FCheckResult Hit = new FCheckResult(1f);
			FVector SliceExtent = Extent;
			SliceExtent.Z = 1f;
			bKeepTrying = 0;

			if( !EncroachingWorldGeometry(ref Hit, Location, SliceExtent) )
			{
				// trace down to find floor
				FVector Down = FVector(0f,0f,Extent.Z);
		
				SingleLineCheck(ref Hit, null, Location - 2f*Down, Location, TRACE_World, SliceExtent);

				FVector FloorNormal = Hit.Normal;
				if( !Hit.Actor || (Hit.Time > 0.5f) )
				{
					// assume ceiling was causing problem
					if( !Hit.Actor )
					{
						Location = Location - Down;
					}
					else
					{
						Location = Location - (2f*Hit.Time-1f) * Down + FVector(0f,0f,1f);
					}

					if( !EncroachingWorldGeometry(ref Hit,Location, Extent) )
					{
						// push back up to ceiling, and return
						SingleLineCheck( ref Hit, null, Location + Down, Location, TRACE_World, Extent );
						if( Hit.Actor )
						{
							Location = Hit.Location;
						}
						return TRUE;
					}
					else
					{
						// push out from floor, try to fit
						FloorNormal.Z = 0f;
						Location = Location + FloorNormal * Extent.X;
						return ( !EncroachingWorldGeometry( ref Hit,Location, Extent ) );
					}
				}
				else
				{
					// assume Floor was causing problem
					Location = Location + (0.5f-Hit.Time) * 2f*Down + FVector(0f,0f,1f);
					if( !EncroachingWorldGeometry(ref Hit, Location, Extent) )
					{
						return TRUE;
					}
					else
					{
						// push out from floor, try to fit
						FloorNormal.Z = 0f;
						Location = Location + FloorNormal * Extent.X;
						return ( !EncroachingWorldGeometry(ref Hit,Location, Extent) );
					}
				}
			}
			bKeepTrying = 1;
			return FALSE;
		}
		
		WorldInfo.ENetMode GetNetMode()
		{
			return (WorldInfo.ENetMode) GetWorldInfo().NetMode;
		}
		public unsafe bool FarMoveActor( Actor Actor, in Object.Vector DestLocation, bool test = false, bool bNoCheck = false, bool bAttachedMove = false )
		{
			//SCOPE_CYCLE_COUNTER(STAT_FarMoveActorTime);

			check(Actor!=NULL);
			if( (Actor.bStatic || !Actor.bMovable) && HasBegunPlay )
				return false;
			if ( test && (Actor.Location == DestLocation) )
				return true;

		/*#if !FINAL_RELEASE
			// Check to see if this move is illegal during this tick group
			if (InTick && TickGroup == TG_DuringAsyncWork && Actor.bBlockActors && !test)
			{
				debugf(NAME_Error,TEXT("Can't move collidable actor (%s) during async work!"),*Actor.GetName());
			}
		#endif*/

			FVector prevLocation = Actor.Location;
			FVector newLocation = DestLocation;
			bool result = true;

			if (!bNoCheck && (Actor.bCollideWorld || (Actor.bCollideWhenPlacing && (GetNetMode() != WorldInfo.ENetMode.NM_Client))) )
				result = FindSpot(Actor.GetCylinderExtent(), ref newLocation, Actor.bCollideComplex);

			if (result && !test && !bNoCheck)
				result = !CheckEncroachment( Actor, newLocation, Actor.Rotation, false);
			
			if( prevLocation != Actor.Location && !test && !Actor.IsEncroacher() ) // CheckEncroachment moved this actor (teleported), we're done
			{
				// todo: ensure the actor was placed back into the collision hash
				//debugf(TEXT("CheckEncroachment moved this actor, we're done!"));
				//farMoveStackCnt--;
				return result;
			}
			
			if( result )
			{
				//move based actors and remove base unles this farmove was done as a test
				if ( !test )
				{
					Actor.bJustTeleported = true;
					if ( !bAttachedMove )
						Actor.SetBase(null);
					for ( INT i=0; i<Actor.Attached.Num(); i++ )
					{
						if ( Actor.Attached[i] )
						{
							FarMoveActor(Actor.Attached[i],
								newLocation + Actor.Attached[i].Location - Actor.Location,false,bNoCheck,true);
						}
					}
				}
				Actor.Location = newLocation;
			}

			if (!test)
			{
				// Update any collision components.  If we are in the Tick phase, only update components with collision.
				Actor.ForceUpdateComponents( GWorld.InTick );
			}

			if ( !test && Actor.bCollideActors )
			{
				// remove actors that are no longer touched
				Actor.UnTouchActors();

				// touch actors
				Actor.FindTouchingActors();
			}

			// Set the zone after moving, so that if a PhysicsVolumeChange or ActorEntered/ActorLeaving message
			// tries to move the actor, the hashing will be correct.
			if( result )
			{
				Actor.SetZone( test,false );
			}

			return result;
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		public unsafe bool EncroachingWorldGeometry( ref DecFn.CheckResult Hit, in Object.Vector Location, in Object.Vector Extent, bool bUseComplexCollision=FALSE )
		{
			var unityExtent = Extent.ToUnityPos();
			var unityLoc = Location.ToUnityPos();

			var dwn = unityLoc - new Vector3( 0, unityExtent.y, 0 );
			var up = unityLoc + new Vector3( 0, unityExtent.y, 0 );

			var results = Physics.OverlapCapsule( dwn, up, unityExtent.x, -1, QueryTriggerInteraction.Ignore );
			
			int count = 0;
			foreach( Collider unityColl in results )
			{
				if( ExtractMappingData( unityColl, out var component, out var actor ) == false )
					continue;

				Hit = new CheckResult
				{
					Component = component,
					Actor = actor
				};
				return true;
			}

			return false;

			#if false
			FMemMark Mark = new FMemMark(GMem);
			FCheckResult* Hits = MultiPointCheck( GMem, Location, Extent, TRACE_World | TRACE_Blocking | TRACE_StopAtAnyHit | (bUseComplexCollision ? TRACE_ComplexCollision : 0) );
			if ( !(Hits != default) )
			{
				Mark.Pop();
				return false;
			}
			Hit = *Hits;
			Mark.Pop();
			return true;
			#endif
		}



		static ConditionalWeakTable<UnityEngine.Object, Core.Object> _mappingTable = new ConditionalWeakTable<UnityEngine.Object, Object>();



		static bool ExtractMappingData( Collider unityColl, out PrimitiveComponent component, out Actor actor )
		{
			if( _mappingTable.TryGetValue( unityColl.gameObject, out var GO ) )
				actor = (Actor)GO;
			else
				_mappingTable.Add( unityColl.gameObject, actor = new Actor
				{
					Name = unityColl.gameObject.name, 
					Location = unityColl.transform.position.ToUnrealPos(),
					Rotation = (Rotator)unityColl.transform.rotation,
				} );

			if( _mappingTable.TryGetValue( unityColl, out var value ) )
			{
				component = (PrimitiveComponent) value;
			}
			else
			{
				if( unityColl is BoxCollider bColl )
					component = new BrushComponent();
				else if( unityColl is CapsuleCollider capsule )
					component = new CylinderComponent();
				else if( unityColl is MeshCollider meshColl )
					component = new StaticMeshComponent();
				else
				{
					component = null;
					actor = null;
					return false;
				}

				_mappingTable.Add( unityColl, component );
			}

			return true;
		}



		public unsafe DecFn.CheckResult* ActorPointCheck( ref int Mem, in Object.Vector Location, in Object.Vector Extent, uint TraceFlags )
		{
			// Make a list of all actors which overlap with a cylinder at Location
			// with the given collision size.
			var unityExtent = Extent.ToUnityPos();
			var unityLoc = Location.ToUnityPos();

			var dwn = unityLoc - new Vector3( 0, unityExtent.y, 0 );
			var up = unityLoc + new Vector3( 0, unityExtent.y, 0 );

			bool filterOutTrigger = ( TraceFlags & TRACE_PhysicsVolumes ) == default;

			var results = Physics.OverlapCapsule( dwn, up, unityExtent.x, -1, 
				filterOutTrigger ? QueryTriggerInteraction.Ignore : QueryTriggerInteraction.Collide );
			
			var root = new CheckResult();
			var current = root;
			int count = 0;
			foreach( Collider unityColl in results )
			{
				if( unityColl.isTrigger != filterOutTrigger )
					continue;

				if( ExtractMappingData( unityColl, out var component, out var actor ) == false )
					continue;

				var next = new CheckResult
				{
					Component = component,
					Actor = actor
				};
				current.AssignNext(next);
				current = next;
				count++;
			}

			return count == 0 ? null : root.Next;

			#if false
			// First, see if this actors box overlaps tthe query point
			// If it doesn't - return straight away.
			//FBox TestBox = FBox(o->ChkStart - o->ChkExtent, o->ChkStart + o->ChkExtent);
			//if( !Box.Intersect(o->ChkBox) )
			//	return;

			for(INT i = 0; i<Primitives.Num(); i++)
			{
				UPrimitiveComponent*	TestPrimitive = Primitives(i);

				// Skip if we've already checked this actor.
				if (TestPrimitive->Tag != UPrimitiveComponent::CurrentTag)
				{
					TestPrimitive->Tag = UPrimitiveComponent::CurrentTag;

					AActor* PrimOwner = TestPrimitive->GetOwner();		
					if(PrimOwner)
					{
						UBOOL hitActorBox;
						{
							SCOPE_CYCLE_COUNTER_SLOW(STAT_BoxBoxTime);
							// Check actor box against query box.
							hitActorBox = BoxBoxIntersect(TestPrimitive->Bounds.GetBox(), o->ChkBox);
						}
						INC_DWORD_STAT_SLOW(STAT_BoxBoxCount);

		#if !CHECK_FALSE_NEG
						if(!hitActorBox)
						{
							continue;
						}
		#endif
						if ((o->bChkExtentIsZero ? TestPrimitive->BlockZeroExtent : TestPrimitive->BlockNonZeroExtent) &&
							TestPrimitive->ShouldCollide() &&
							PrimOwner->ShouldTrace(TestPrimitive,NULL, o->ChkTraceFlags) )
						{
							// Collision test.
							FCheckResult TestHit(1.f);
							if (TestPrimitive->PointCheck(TestHit, o->ChkStart, o->ChkExtent, o->ChkTraceFlags) == 0)
							{
								check(TestHit.Actor == PrimOwner);

		#if CHECK_FALSE_NEG
						if(!hitActorBox)
							debugf(TEXT("PC False Neg! : %s %s"), testActor->GetName());
		#endif

								FCheckResult* NewResult = new(*(o->ChkMem))FCheckResult(TestHit);
								NewResult->GetNext() = o->ChkResult;
								o->ChkResult = NewResult;
								if (o->ChkTraceFlags & TRACE_StopAtAnyHit)
									return;
							}
						}
					}
				}
			}
			// Now traverse children of this node if present.
			if(Children)
			{
				INT childIXs[8];
				INT numChildren = FindChildren(Bounds, o->ChkBox, childIXs);
				for(INT i = 0; i<numChildren; i++)
				{
					FOctreeNodeBounds	ChildBounds(Bounds,childIXs[i]);
					this->Children[childIXs[i]].ActorPointCheck(o,ChildBounds);
					// JTODO: Should we check TRACE_StopAtAnyHit and bail out early for Encroach check?
				}
			}
			#endif
		}
		
		
		
		
		
		//FOctreeNode*	RootNode;
		INT				OctreeTag;

		/// This is a bit nasty...
		// Temporary storage while recursing for line checks etc.
		/*FCheckResult**/object	ChkResult;
		//FMemStack*		ChkMem;
		FVector			ChkEnd;
		FVector			ChkStart; // aka Location
		FRotator		ChkRotation;
		FVector			ChkDir;
		FVector			ChkOneOverDir;
		FVector			ChkExtent;
		DWORD			ChkTraceFlags;
		Actor			ChkActor;
		LightComponent ChkLight;
		FLOAT			ChkRadiusSqr;
		Box			ChkBox;
		UBOOL		    ChkBlockRigidBodyOnly;
		/** whether or not ChkExtent.IsZero() is TRUE */
		UBOOL			bChkExtentIsZero;

		//TArray<UPrimitiveComponent*>	FailedPrims;
		/// 

		// Keeps track of shortest hit time so far.
		//FCheckResult*	ChkFirstResult;

		FVector			RayOrigin;
		INT				ParallelAxis;
		INT				NodeTransform;

		UBOOL			bShowOctree;
		
		
		
		
		
		
		
		public unsafe DecFn.CheckResult* ActorEncroachmentCheck( ref int Mem, Actor Actor, Object.Vector Location, Object.Rotator Rotation, int TraceFlags )
		{
			// If an Actors Spawn location is being blocked we call that Encroachment,
			// its when two Actors (or more) share the same physical space.
			
			//INC_DWORD_STAT(STAT_EncroachCheckCount);
			//SCOPE_CYCLE_COUNTER(STAT_EncroachCheckTime);

			// Fill in temporary data.
			ChkResult = null;

			if(!Actor.CollisionComponent)
				return null;

			PrimitiveComponent.CurrentTag++;

			// Get collision component bounding box at new location.
			if(Actor.CollisionComponent.IsValidComponent())
			{
				//ChkMem = &Mem;
				ChkActor = Actor;
				ChkTraceFlags = TraceFlags;

				// Save actor's location and rotation.
				Exchange( ref Location, ref Actor.Location );
				Exchange( ref Rotation, ref Actor.Rotation );
				try
				{
					if(!Actor.CollisionComponent.IsAttached())
					{
						throw new Exception();
						//debugf( TEXT("ActorEncroachmentCheck: Actor '%s' has uninitialised CollisionComponent!"), *Actor.GetName() );
					}
					else
					{
						ChkBox = Actor.CollisionComponent.Bounds.GetBox();
						if(ChkBox.IsValid != default)
						{
							Actor.OverlapAdjust = Actor.Location - Location;
							ChkBox.Min += Actor.OverlapAdjust;
							ChkBox.Max += Actor.OverlapAdjust;

							var center = (ChkBox.Min + ChkBox.Max).ToUnityPos() * 0.5f;
							var extent = (ChkBox.Max - ChkBox.Min).ToUnityPos();
							var results = Physics.OverlapBox( center, extent, Quaternion.identity, - 1, QueryTriggerInteraction.Ignore );

							var root = new CheckResult();
							var current = root;
							int count = 0;
							foreach( Collider unityColl in results )
							{
								if( ExtractMappingData( unityColl, out var component, out var actor ) == false )
									continue;

								var next = new CheckResult
								{
									Component = component,
									Actor = actor
								};
								current.AssignNext(next);
								current = next;
								count++;
							}

								
							//RootNode.ActorEncroachmentCheck(this, RootNodeBounds);

							Actor.OverlapAdjust = FVector(0f,0f,0f);
							
							return count == 0 ? null : root.Next;
						}
					}
				}
				finally
				{
					// Restore actor's location and rotation.
					Exchange( ref Location, ref Actor.Location );
					Exchange( ref Rotation, ref Actor.Rotation );
				}
			}

			return null;
		}
		
		void Swap<T>( ref T A, ref T B )
		{
			T Temp = A;
			A = B;
			B = Temp;
		}
		void Exchange<T>( ref T A, ref T B )
		{
			Swap(ref A, ref B);
		}

		public unsafe DecFn.CheckResult* MultiLineCheck( ref int Mem, in Object.Vector End, in Object.Vector Start, in Object.Vector Extent, uint TraceFlags, Actor SourceActor, LightComponent SourceLight = null )
		{

			bool filterOutTrigger = ( TraceFlags & TRACE_PhysicsVolumes ) == default;

			var delta = End.ToUnityPos() - Start.ToUnityPos();

			var totalDistance = delta.magnitude;
			RaycastHit[] hits;
			if( Extent == default )
			{
				hits = Physics.RaycastAll( Start.ToUnityPos(), delta.normalized, totalDistance, -1, QueryTriggerInteraction.Ignore );
			}
			else
			{
				var vertical = Extent.ToUnityPos().y;
				var radius = Extent.ToUnityPos().x;
				var p1 = Start.ToUnityPos() + new Vector3(0, vertical, 0);
				var p2 = Start.ToUnityPos() - new Vector3(0, vertical, 0);
				hits = Physics.CapsuleCastAll( p1, p2, radius, delta.normalized, totalDistance, -1, QueryTriggerInteraction.Ignore );
			}
			
			var root = new CheckResult();
			var current = root;
			int count = 0;
			foreach( var hit in hits )
			{
				var unityColl = hit.collider;
				if( ExtractMappingData( unityColl, out var component, out var actor ) == false )
					continue;

				var next = new CheckResult
				{
					Actor = actor,
					Location = hit.point.ToUnrealPos(),
					Normal = hit.normal.ToUnrealDir(),
					Time = hit.distance / totalDistance,
					Component = component,
				};
				current.AssignNext(next);
				current = next;
				count++;
			}

			return count == 0 ? null : root.Next;
			
			#if false
			//SCOPE_CYCLE_COUNTER(STAT_MultiLineCheck);

			INT NumHits=0;
			Span<FCheckResult> Hits = stackalloc FCheckResult[64];

			// Draw line that we are checking, and box showing extent at end of line, if non-zero
			/*if(this.bShowLineChecks && Extent.IsZero())
			{
				LineBatcher.DrawLine(Start, End, FColor(0, 255, 128), SDPG_World);
		
			}
			else if(this.bShowExtentLineChecks && !Extent.IsZero())
			{
				LineBatcher.DrawLine(Start, End, FColor(0, 255, 255), SDPG_World);
				DrawWireBox(LineBatcher,FBox(End-Extent, End+Extent), FColor(0, 255, 255), SDPG_World);
			}*/

			FLOAT Dilation = 1f;
			FVector NewEnd = End;

			// Check for collision with the level, and cull by the end point for speed.
			INT WorldNum = 0;
	
			{
				//SCOPE_CYCLE_COUNTER(STAT_Col_Level);
				if( (TraceFlags & TRACE_Level) != default && BSPLineCheck( Hits[NumHits], NULL, End, Start, Extent, TraceFlags )==0 )
				{
					Hits[NumHits].Actor = GetWorldInfo();
					FLOAT Dist = (Hits[NumHits].Location - Start).Size();
					Hits[NumHits].Time *= Dilation;
					Dilation = Min(1f, Hits[NumHits].Time * (Dist + 5)/(Dist+0.0001f));
					NewEnd = Start + (End - Start) * Dilation;
					WorldNum = NumHits;
					NumHits++;
				}
			}

			if(Dilation > SMALL_NUMBER)
			{
				//SCOPE_CYCLE_COUNTER(STAT_Col_Actors);
				if( !(NumHits != default) || !((TraceFlags & TRACE_StopAtAnyHit) != default) )
				{
					// Check with actors.
					if( (TraceFlags & TRACE_Hash) != default && Hash != default )
					{
						for( FCheckResult* Link=Hash.ActorLineCheck( Mem, NewEnd, Start, Extent, TraceFlags, SourceActor, SourceLight ); Link && NumHits<ARRAY_COUNT(Hits); Link=Link->GetNext() )
						{
							Link->Time *= Dilation;
							Hits[NumHits++] = *Link;
						}
					}
				}
			}

			// Sort the list.
			FCheckResult* Result = null;
			if( NumHits != default )
			{
				//SCOPE_CYCLE_COUNTER(STAT_Col_Sort);
				appQsort( Hits, NumHits, sizeof(Hits[0]), (QSORT_COMPARE)FCheckResult::CompareHits );
				Result = new(Mem,NumHits)FCheckResult;
				for( INT i=0; i<NumHits; i++ )
				{
					Result[i]      = Hits[i];
					Result[i].Next = (i+1<NumHits) ? &Result[i+1] : null;
				}
			}

			return Result;
			#endif
		}
	}
}