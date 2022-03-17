namespace MEdge.Source
{
	using TdGame;
	using UnityEngine;



	public class UnityTdSwingVolume : VolumeProxy<TdSwingVolume>
	{
		public bool bSnapToCenter;
		public bool bThickGrip;



		protected override void SyncVolume(TdSwingVolume volume)
		{
			// Of course I have to do this kind of bullshit as unity doesn't handle property in the editor
			// Otherwise I would just sync when property changes ...
			volume.bThickGrip = bThickGrip;
			volume.bSnapToCenter = bSnapToCenter;
		}



		void OnDrawGizmos()
		{
			var subdiv = 16;
			
			var thisPos = transform.position;
			var p = transform.forward * 0.5f;
			var prevP = p;
			Quaternion rotOffset = Quaternion.AngleAxis( 180f / subdiv, transform.right );
			for( int i = 0; i < subdiv; i++ )
			{
				p = rotOffset * prevP;
				Gizmos.DrawLine( thisPos+p, thisPos+prevP );
				Gizmos.DrawLine( thisPos+p*0.8f, thisPos+prevP*0.8f );
				prevP = p;
			}
			
			Gizmos.DrawLine( thisPos+transform.right*0.2f, thisPos-transform.right*0.2f );
			Gizmos.DrawLine( thisPos+transform.forward*0.2f, thisPos-transform.forward*0.2f );
		}
	}
}