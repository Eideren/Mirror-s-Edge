namespace MEdge.Engine
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.CompilerServices;
	using Core;
	using Source;
	using UnityEngine;
	using Color = UnityEngine.Color;
	using FCheckResult = Source.DecFn.CheckResult;
	using FVector = MEdge.Core.Object.Vector;



	public partial class UWorld
	{
		public bool DrawDebugTraces{ get; set; } = true;

		/// <summary>
		/// Far from perfect, need to tweak stuff that uses this value
		/// </summary>
		static float defaultContactOffset => 0*Physics.defaultContactOffset;
		static Collider[] _colliderCache = new Collider[16];
		static RaycastHit[] _hitCache = new RaycastHit[16];
		static (RaycastHit hit, (float length, Vector3 dir) pen)[] _sortCache = new (RaycastHit, (float, Vector3))[16];
		static ConditionalWeakTable<UnityEngine.Object, Core.Object> _mappingTable = new ConditionalWeakTable<UnityEngine.Object, Core.Object>();
		static RaycastComparer _raycastComparer = new();




		BoxCollider BoxForTests;



		static PenComparer _penComparer = new PenComparer();
		class PenComparer : IComparer<(RaycastHit hit, (float length, Vector3 dir) pen)>
		{
			public int Compare( (RaycastHit hit, (float length, Vector3 dir) pen) x, (RaycastHit hit, (float length, Vector3 dir) pen) y )
			{
				if( x.hit.distance != y.hit.distance )
					return x.hit.distance.CompareTo(y.hit.distance); // Smallest dist first
				// Then when dist is zero, largest penetration length must be first
				return y.pen.length.CompareTo( x.pen.length );
			}
		}



		public unsafe FCheckResult* MultiLineCheck( ref int Mem, in FVector End, in FVector Start, in FVector Extent, uint TraceFlags, Actor SourceActor, LightComponent SourceLight = null )
		{
			bool testTrigger = ( TraceFlags & TRACE_PhysicsVolumes ) != default;

			var delta = End.ToUnityPos() - Start.ToUnityPos();

			var totalDistance = delta.magnitude;
			var root = new FCheckResult();
			int count = 0;
			Vector3 center;
			if( Extent == default )
			{
				center = Start.ToUnityPos();
				var hits = Physics.RaycastNonAlloc( Start.ToUnityPos(), delta.normalized, _hitCache, totalDistance, -1, testTrigger ? QueryTriggerInteraction.Collide : QueryTriggerInteraction.Ignore );
				Array.Sort(_hitCache, 0, hits, _raycastComparer);
				var current = root;
				//foreach( var hit in hits )
				for( int i = 0; i < hits; i++ )
				{
					var hit = _hitCache[i];
					var unityColl = hit.collider;
					if( unityColl.isTrigger != testTrigger )
						continue;
				
					if( ExtractMappingData( unityColl, out var component, out var actor ) == false )
						continue;

					var next = new FCheckResult
					{
						Actor = actor,
						Location = hit.point.ToUnrealPos(),
						Normal = hit.normal.ToUnrealDir(),
						Time = hit.distance / totalDistance,
						Component = component,
						Material = Asset.GetDefaultMatFor("Concrete"),
						PhysMaterial = Asset.GetDefaultPhysMat("Concrete"),
					};
					current.AssignNext(next);
					if( count == 0 )
						root = current;
					current = next;
					count++;
				}

				if( DrawDebugTraces )
				{
					for( var ptr = count == 0 ? null : root.Next; ptr != null; ptr = ptr->Next )
						Debug.DrawRay( ptr->Location.ToUnityPos(), ptr->Normal.ToUnityDir(), Color.yellow, 0.1f );
			
					Debug.DrawRay( center, delta, Color.green );
					if(count != 0)
						Debug.DrawRay( center, delta * root.Next->Time, Color.red );
				}
			}
			else
			{
				UnrealToUnityBox( Start, Extent, out var box );

				var hits = Physics.BoxCastNonAlloc( box.center, box.extent, delta.normalized, _hitCache, Quaternion.identity, totalDistance, -1, QueryTriggerInteraction.Ignore );

				// Makes sure hits are sorted
				// We also need to sort based on how much this box is already penetrating objects at the starting point
				int sortCacheLength = 0;
				for( int i = 0; i < hits; i++ )
				{
					ref var hit = ref _hitCache[i];
					if( hit.collider.isTrigger != testTrigger )
						continue;
					
					float length = 0f;
					Vector3 direction = default;
					if( hit.distance == 0f && hit.point == default )
					{
						ComputePenetration( hit.collider, box, out length, out direction );
						if( Vector3.Dot( direction, -delta.normalized ) < 0f )
						{
							// Filtering out hits that are within the starting box and are not exactly in the way of the trace
							continue;
						}
					}

					int sortPos;
					// Loop in the array in reverse as this hit is more likely to be at the end of the array than the start
					// Since boxcast is already sorting by distance
					for( sortPos = sortCacheLength-1; sortPos >= 0; sortPos-- )
					{
						ref var other = ref _sortCache[sortPos];
						if( other.hit.distance < hit.distance )
						{
							// Going in reverse so insert right after the distance smaller to this one
							break;
						}

						if( other.hit.distance == hit.distance && other.pen.length >= length )
						{
							// Going in reverse so insert after the one with a larger penetration, that one is more significant
							break;
						}
					}

					sortPos += 1; // Going in reverse so we have to increase by one
					if (sortPos < sortCacheLength) // If we're actually inserting in the array make space for this value
						Array.Copy(_sortCache, sortPos, _sortCache, sortPos + 1, sortCacheLength - sortPos);
					_sortCache[ sortPos ].hit = hit;
					_sortCache[ sortPos ].pen.dir = direction;
					_sortCache[ sortPos ].pen.length = length;
					
					sortCacheLength++;
				}

				var current = root;
				for( int i = 0; i < sortCacheLength; i++ )
				{
					var ( hit, penData ) = _sortCache[ i ];

					if( ExtractMappingData( hit.collider, out var component, out var actor ) == false )
						continue;
					
					var next = new FCheckResult
					{
						Actor = actor,
						Component = component,
					};
					
					// This indicates a test that already intersects at origin
					bool penetrating = hit.distance == 0f && hit.point == default;
					if( penetrating )
					{
						// Looks to be this value when looking at the source, I'm not sure to be honest
						next.Normal = (-delta).normalized.ToUnrealDir();
						next.Location = (Start.ToUnityPos() + penData.dir * penData.length).ToUnrealPos();
						next.bStartPenetrating = true;
						next.Time = 0f;
					}
					else
					{
						next.Normal = hit.normal.ToUnrealDir();
						next.Location = (Start.ToUnityPos() + delta.normalized * hit.distance).ToUnrealPos();
						next.Time = Mathf.Max(hit.distance - defaultContactOffset, 0f) / totalDistance;
					}

					next.Material = Asset.GetDefaultMatFor( "Concrete" );
					next.PhysMaterial = next.Material.GetPhysicalMaterial();

					current.AssignNext(next);
					if( count == 0 )
						root = current;
					current = next;
					count++;
				}

				if( DrawDebugTraces )
				{
					if( count == 0 )
					{
						DrawBox(box, delta, 0.05f, new Color(0f, 1f, 0f, 0.25f));
					}
					else
					{
						DrawBox(box, delta, 0.05f, new Color(1f, 0f, 0f, 0.25f));
						DrawBox(box, delta * root.Next->Time, 0.05f, new Color(1f, 0f, 0f, 0.5f));
					}
				}
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


		public unsafe DecFn.CheckResult* ActorPointCheck( ref int Mem, in FVector Location, in FVector Extent, uint TraceFlags )
		{
			// Make a list of all actors which overlap with a cylinder at Location
			// with the given collision size.

			bool testTrigger = ( TraceFlags & TRACE_PhysicsVolumes ) != default;

			UnrealToUnityBox( Location, Extent, out var box );
			var colliderCount = Physics.OverlapBoxNonAlloc( box.center, box.extent, _colliderCache, Quaternion.identity, -1, QueryTriggerInteraction.Ignore );
			
			var root = new FCheckResult();
			var current = root;
			int count = 0;
			for( int i = 0; i < colliderCount; i++ )
			{
				var coll = _colliderCache[i];
				if( coll.isTrigger != testTrigger )
					continue;

				if( ExtractMappingData( coll, out var component, out var actor ) == false )
					continue;

				if( ComputePenetration( coll, box, out var length, out var direction ) == false )
					continue;

				var next = new FCheckResult
				{
					Component = component,
					Actor = actor,
					Time = 0f,
					Location = Location + (direction * length).ToUnrealPos(),
					Normal = direction.ToUnrealDir(),
					Material = Asset.GetDefaultMatFor("Concrete"),
					PhysMaterial = Asset.GetDefaultPhysMat("Concrete"),
				};
				current.AssignNext(next);
				if( count == 0 )
					root = current;
				current = next;
				count++;
			}
			
			if(DrawDebugTraces)
				DrawBox(box, default, 0.05f, count == 0 ? Color.cyan : Color.magenta);

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



		public class RaycastComparer : IComparer<RaycastHit>
		{
			public int Compare( RaycastHit x, RaycastHit y ) => x.distance.CompareTo( y.distance );
		}



		bool ComputePenetration(Collider otherCollider, (Vector3 center, Vector3 extent) box, out float length, out Vector3 direction)
		{
			if( BoxForTests == null )
			{
				BoxForTests ??= new GameObject(nameof(BoxForTests)).AddComponent<BoxCollider>();
				BoxForTests.gameObject.SetActive(false);
			}
				
			// Epsilon otherwise hits considered as intersecting are not detected as such through ComputePenetration 
			BoxForTests.size = box.extent * 2f + Vector3.one * defaultContactOffset;
			
			BoxForTests.gameObject.SetActive(true);
			
			bool boxTest = Physics.ComputePenetration(
				BoxForTests, box.center, Quaternion.identity,
				otherCollider, otherCollider.transform.position, otherCollider.transform.rotation, 
				out direction, out length
			);
			if( boxTest == false )
			{
				// Get an accurate direction for the rest of the logic by enlarging it
				BoxForTests.size = box.extent * 2.1f + Vector3.one * defaultContactOffset;
				Physics.ComputePenetration(
					BoxForTests, box.center, Quaternion.identity,
					otherCollider, otherCollider.transform.position, otherCollider.transform.rotation, 
					out direction, out _
				);
			}

			/*if( boxTest == false )
			{
				BoxForTests.transform.position = box.center;
				Debug.LogError($"Unexpected intersection test result with {otherCollider.gameObject.name}: {box.center}, {BoxForTests.size}");
				UnityEditor.EditorApplication.isPaused = true;
				throw new Exception();
			}*/
						
			BoxForTests.gameObject.SetActive(false);
			return boxTest;
		}



		static bool ExtractMappingData( Collider unityColl, out PrimitiveComponent component, out Actor actor )
		{
			if( _mappingTable.TryGetValue( unityColl.gameObject, out var GO ) )
				actor = (Actor)GO;
			else
				_mappingTable.Add( unityColl.gameObject, actor = new Actor
				{
					Name = unityColl.gameObject.name, 
					Location = unityColl.transform.position.ToUnrealPos(),
					Rotation = unityColl.transform.rotation.ToUnrealRot(),
					bWorldGeometry = true,
					bBlockActors = true
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

				component.BlockActors = true;
				_mappingTable.Add( unityColl, component );
			}

			return true;
		}



		static void UnrealToUnityBox( in FVector pivotPos, in FVector halfExtent, out (Vector3 center, Vector3 extent) box )
		{
			var unityExtent = halfExtent.ToUnityPos();
			var unityLoc = pivotPos.ToUnityPos();

			if( unityExtent.x < 0 || unityExtent.y < 0 || unityExtent.z < 0 )
				throw new Exception();
			if( Physics.queriesHitBackfaces )
				throw new Exception("Disable Physics Backface queries, collision test are likely to misbehave");
			
			box = ( unityLoc, unityExtent );
		}
		
		
		
		
		static void DrawCapsule(in (Vector3 bot, Vector3 top, float radius) capsule, int subdiv = 6)
		{
			( Vector3 bot, Vector3 top, float radius ) = capsule;
			var cross = Vector3.right;
			var topEnd = top + new Vector3( 0, radius, 0 );
			var botEnd = bot - new Vector3( 0, radius, 0 );
			for( int i = 0; i < subdiv; i++ )
			{
				var prevBotVert = bot + cross * radius;
				var prevTopVert = top + cross * radius;
				cross = Quaternion.AngleAxis( 360f / subdiv, Vector3.up ) * cross;
				var botVert = bot + cross * radius;
				var topVert = top + cross * radius;
				Debug.DrawLine( botVert, topVert, Color.magenta );
				Debug.DrawLine( botVert, botEnd, Color.magenta );
				Debug.DrawLine( topVert, topEnd, Color.magenta );
				Debug.DrawLine( topVert, prevTopVert, Color.magenta );
				Debug.DrawLine( botVert, prevBotVert, Color.magenta );
			}
		}



		static void DrawBox( in (Vector3 center, Vector3 extent) box, Vector3 displacement = default, float duration = 0f, Color? col = null )
		{
			Color actualCol = col ?? Color.green;
			var a = Vector3.forward + Vector3.up + Vector3.right;
			var b = Vector3.forward + Vector3.up + Vector3.left;
			var c = Vector3.forward + Vector3.down + Vector3.left;
			var d = Vector3.forward + Vector3.down + Vector3.right;
			bool doDisplace = displacement != default;
			for( int i = 0; i < 4; i++ )
			{
				var a2 = box.center + Vector3.Scale( Quaternion.AngleAxis(i * 90f, Vector3.up) * a, box.extent);
				var b2 = box.center + Vector3.Scale( Quaternion.AngleAxis(i * 90f, Vector3.up) * b, box.extent);
				var c2 = box.center + Vector3.Scale( Quaternion.AngleAxis(i * 90f, Vector3.up) * c, box.extent);
				var d2 = box.center + Vector3.Scale( Quaternion.AngleAxis(i * 90f, Vector3.up) * d, box.extent);
				Debug.DrawLine( a2, b2, actualCol, duration * Time.timeScale );
				Debug.DrawLine( b2, c2, actualCol, duration * Time.timeScale );
				Debug.DrawLine( c2, d2, actualCol, duration * Time.timeScale );
				if( doDisplace )
				{
					for( int j = 0; j < 4; j++ )
					{
						var da2 = a2 + displacement;
						var db2 = b2 + displacement;
						var dc2 = c2 + displacement;
						var dd2 = d2 + displacement;
						Debug.DrawLine( da2, db2, actualCol, duration * Time.timeScale );
						Debug.DrawLine( db2, dc2, actualCol, duration * Time.timeScale );
						Debug.DrawLine( dc2, dd2, actualCol, duration * Time.timeScale );
						
						Debug.DrawLine( da2, a2, actualCol, duration * Time.timeScale );
						Debug.DrawLine( db2, b2, actualCol, duration * Time.timeScale );
						Debug.DrawLine( dc2, c2, actualCol, duration * Time.timeScale );
						Debug.DrawLine( dd2, d2, actualCol, duration * Time.timeScale );
					}
				}
			}
		}
	}
}