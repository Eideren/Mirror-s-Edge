namespace MEdge.Source
{
	using System.Collections.Generic;
	using Core;
	using TdGame;
	using UnityEngine;



	public class UnityTdZiplineVolume : VolumeProxy<TdZiplineVolume>
	{
		public float LandingStrip;
		public List<Vector3> SplineControls = new(){ new Vector3(0f, 0f, -1f), new Vector3(0f, 0f, 1f) };



		public Vector3 Transform( Vector3 pt ) => this.transform.TransformPoint(pt);
		public Vector3 InverseTransform( Vector3 pt ) => this.transform.InverseTransformPoint(pt);

		protected override void SyncVolume( TdZiplineVolume volume )
		{
			volume.SplineLocations.Empty();
			var length = 0f;
			Vector3 previous = default;
			for( int i = 0; i < SplineControls.Count; i++ )
			{
				var v3 = SplineControls[i];
				v3 = Transform( v3 );
				volume.SplineLocations.Add( v3.ToUnrealPos() );
				if( i != 0 )
					length += Vector3.Distance( v3, previous );

				previous = v3;
			}
			
			volume.LandingStrip = LandingStrip;
			volume.NumSplineSegments = SplineControls.Count;
			volume.Start = volume.SplineLocations[ 0 ];
			volume.End = volume.SplineLocations[ ^1 ];
			volume.Middle = ( volume.Start + volume.End ) * 0.5f; // This might not be right
			volume.SplineLength = length;
			
			volume.MoveDirection = transform.forward.ToUnrealDir();
		}
		
		
		
		void OnDrawGizmos()
		{
			if( SplineControls.Count < 2 )
				return;
			
			Vector3 previous = default;
			for( int i = 0; i < SplineControls.Count; i++ )
			{
				var v3 = SplineControls[i];
				v3 = Transform( v3 );
				if( i != 0 )
					Gizmos.DrawLine( v3, previous );

				previous = v3;
			}

			// Draw zip direction
			{
				var start = Transform(SplineControls[ 0 ]);
				var end = Transform(SplineControls[ ^1 ]);
				var mid = (start + end) * 0.5f;
				var dir = Vector3.Normalize(end - start);
				
				mid += transform.up * 0.2f;

				start = mid - dir*0.5f;
				end = mid + dir*0.5f;
				
				Gizmos.DrawLine( start, end );
				Gizmos.DrawRay( end, (-dir + transform.right * 0.5f) * 0.125f );
				Gizmos.DrawRay( end, (-dir - transform.right * 0.5f) * 0.125f );
			}
		}
	}
}