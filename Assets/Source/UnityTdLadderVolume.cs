namespace MEdge.Source
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using Core;
	using TdGame;
	using UnityEngine;



	public class UnityTdLadderVolume : VolumeProxy<TdLadderVolume>
	{
		public float StepHeight = 32f;
		public float XYOffsetLadder = -32f;
		public float XYOffsetPipe = -40.92f;
		public float ZOffsetLadder = 0f;
		public float ZOffsetPipe = -5.0f;
		public List<Vector3> SplineControls = new(){ new Vector3(0, -1f, 0f), new Vector3(0, 1f, 0f) };
		public TdLadderVolume.ELadderType LadderType = TdLadderVolume.ELadderType.LT_Ladder;
		public bool bCanExitAtTop = true;

		public Vector3 WallNormal => - transform.forward;



		public Vector3 TransformNoScale( Vector3 pt ) => this.transform.position + this.transform.rotation * pt;



		public Vector3 InverseTransformNoScale( Vector3 pt ) => Quaternion.Inverse( this.transform.rotation ) * (pt - this.transform.position);



		/// <summary>
		/// Resulting positions are local to the object, use <see cref="TransformNoScale"/> to get the world pos for those steps
		/// </summary>
		public StepsEnum EnumSteps() => new StepsEnum( SplineControls, StepHeight/100f );



		protected override void SyncVolume( TdLadderVolume volume )
		{
			if( SplineControls.Count < 2 )
			{
				Debug.LogWarning("Spline with less than two control");
				return;
			}
			
			volume.SplineLocations.Empty();
			var length = 0f;
			Vector3 previous = default;
			for( int i = 0; i < SplineControls.Count; i++ )
			{
				var v3 = SplineControls[i];
				v3 = TransformNoScale( v3 );
				volume.SplineLocations.Add( v3.ToUnrealPos() );
				if( i != 0 )
					length += Vector3.Distance( v3, previous );

				previous = v3;
			}
			
			volume.NumSplineSegments = SplineControls.Count;
			volume.Start = volume.SplineLocations[ 0 ];
			volume.End = volume.SplineLocations[ ^1 ];
			volume.Middle = ( volume.Start + volume.End ) * 0.5f; // This might not be right
			volume.SplineLength = length;
			
			volume.MoveDirection = transform.up.ToUnrealDir();
			volume.WallNormal = WallNormal.ToUnrealDir();

			volume.bCanExitAtTop = bCanExitAtTop;
			volume.LadderType = LadderType;
			volume.StepHeight = StepHeight;
			volume.ZOffsetLadder = ZOffsetLadder;
			volume.ZOffsetPipe = ZOffsetPipe;
			volume.XYOffsetLadder = XYOffsetLadder;
			volume.XYOffsetPipe = XYOffsetPipe;

			if( volume.LadderType == TdLadderVolume.ELadderType.LT_Ladder )
			{
				volume.LadderSteps.Empty();
				volume.PawnLadderLocations.Empty();
				foreach( var pt in EnumSteps() )
				{
					var ptWorld = TransformNoScale( pt ).ToUnrealPos();
					volume.LadderSteps.Add( ptWorld );
					volume.PawnLadderLocations.Add( ptWorld );
				}
			}
		}



		void OnDrawGizmos()
		{
			if( SplineControls.Count < 2 )
				return;
			
			Vector3 previous = default;
			for( int i = 0; i < SplineControls.Count; i++ )
			{
				var v3 = SplineControls[i];
				v3 = TransformNoScale( v3 );
				if( i != 0 )
					Gizmos.DrawLine( v3, previous );

				previous = v3;
			}

			// Draw climbing side arrow
			{
				var start = SplineControls[ 0 ];
				var end = SplineControls[ ^1 ];
				var mid = (start + end) * 0.5f;
				var dir = Vector3.Normalize(end - start);
				
				mid = TransformNoScale( mid );
				mid += WallNormal * 0.2f;

				start = mid - dir*0.5f;
				end = mid + dir*0.5f;
				
				Gizmos.DrawLine( start, end );
				Gizmos.DrawRay( end, (-dir + transform.right * 0.5f) * 0.125f );
				Gizmos.DrawRay( end, (-dir - transform.right * 0.5f) * 0.125f );
			}
			
			Vector3 edge;
			if( LadderType == TdLadderVolume.ELadderType.LT_Ladder )
			{
				edge = default;
				foreach( var pt in EnumSteps() )
				{
					var lastStep = TransformNoScale( pt );
					DrawBox( (lastStep, new Vector3(0.25f, 0.02f, 0.02f)), transform.rotation );
					edge = lastStep;
				}
			}
			else
			{
				edge = TransformNoScale(SplineControls[^1]);
			}

			// Draw exit arrow
			{
				Vector3 end = edge - WallNormal*0.5f;
				Gizmos.DrawLine(edge, end);
				Gizmos.DrawRay(end, (WallNormal+transform.right * 0.5f) * 0.125f);
				Gizmos.DrawRay(end, (WallNormal-transform.right * 0.5f) * 0.125f);
			}
		}



		static void DrawBox( in (Vector3 center, Vector3 extent) box, in Quaternion quat )
		{
			var a = Vector3.forward + Vector3.up + Vector3.right;
			var b = Vector3.forward + Vector3.up + Vector3.left;
			var c = Vector3.forward + Vector3.down + Vector3.left;
			var d = Vector3.forward + Vector3.down + Vector3.right;
			Span<Vector3> extent = stackalloc Vector3[ 2 ] {box.extent, new Vector3( box.extent.z, box.extent.y, box.extent.x )};
			for( int i = 0; i < 4; i++ )
			{
				var q = quat * Quaternion.AngleAxis( 90f*i, Vector3.up );
				var a2 = box.center + q * Vector3.Scale( a, extent[i%2]);
				var b2 = box.center + q * Vector3.Scale( b, extent[i%2]);
				var c2 = box.center + q * Vector3.Scale( c, extent[i%2]);
				var d2 = box.center + q * Vector3.Scale( d, extent[i%2]);
				Gizmos.DrawLine( a2, b2 );
				Gizmos.DrawLine( b2, c2 );
				Gizmos.DrawLine( c2, d2 );
			}
		}



		public struct StepsEnum : IEnumerator<Vector3>, IEnumerable<Vector3>
		{
			IList<Vector3> _coll;
			float _distBetweenSteps;
			float _distLeft;
			float _distToNextStep;
			float _segmentDist;
			int _i;



			public Vector3 Current{ get; private set; }


			object IEnumerator.Current => Current;
			
			
			public StepsEnum( IList<Vector3> coll, float distBetweenSteps )
			{
				_coll = coll;
				_distBetweenSteps = distBetweenSteps;
				_distLeft = 0f;
				_distToNextStep = _distBetweenSteps;
				_segmentDist = 0f;
				_i = 0;
				Current = default;
				if( _distToNextStep <= 0f )
					throw new Exception();
			}



			public bool MoveNext()
			{
				do
				{
					if( _distLeft >= _distToNextStep )
					{
						// The segment we processed still has space to insert a step
						_distLeft -= _distToNextStep; // Remove the space we take for this step
						_distToNextStep = _distBetweenSteps; // Reset dist to next step to its maximum

						var prev = _coll[ _i - 1 ];
						var next = _coll[ _i ];

						var t = ( _segmentDist - _distLeft ) / _segmentDist;
						Current = Vector3.Lerp( prev, next, t );
						return true;
					}
					
					if( _i+1 < _coll.Count )
					{
						_i++;
						var prev = _coll[ _i - 1 ];
						var next = _coll[ _i ];
						_segmentDist = Vector3.Distance( prev, next );
						
						_distToNextStep -= _distLeft;
						_distLeft = _segmentDist;
						continue;
					}
					
					return false;
				} while( true );
			}



			public void Reset()
			{
				_distLeft = 0f;
				_distToNextStep = _distBetweenSteps;
				_i = 0;
				Current = default;
			}



			public void Dispose()
			{
				
			}



			public StepsEnum GetEnumerator() => this;
			IEnumerator<Vector3> IEnumerable<Vector3>.GetEnumerator() => throw new System.NotImplementedException();
			IEnumerator IEnumerable.GetEnumerator() => throw new System.NotImplementedException();
		}
	}
}