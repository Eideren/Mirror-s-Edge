namespace MEdge.Source
{
	using Core;
	using Engine;
	using TdGame;
	using UnityEngine;



	public class UnityTdSwingVolume : MonoBehaviour
	{
		public bool bSnapToCenter;
		public bool bThickGrip;
		TdSwingVolume _unrealInstance;



		void SyncTdSwingVolume()
		{
			// Of course I have to do this kind of bullshit as unity doesn't handle property in the editor
			// Otherwise I would just sync when property changes ...
			_unrealInstance.bThickGrip = bThickGrip;
			_unrealInstance.bSnapToCenter = bSnapToCenter;
			_unrealInstance.Rotation = this.transform.rotation.ToUnrealRot();
			_unrealInstance.Location = this.transform.position.ToUnrealPos();
		}



		public TdSwingVolume GetUnrealObject
		{
			get
			{
				if( _unrealInstance != null )
					return _unrealInstance;
				
				UWorld.Instance.LowFrequencyUpdate.Add( SyncTdSwingVolume );
				_unrealInstance = new TdSwingVolume
				{
					Name = $"TdSwingVolume_{gameObject.name}",
				};
				SyncTdSwingVolume();
				return _unrealInstance;
			}
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