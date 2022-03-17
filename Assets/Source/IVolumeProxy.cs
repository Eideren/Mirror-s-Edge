namespace MEdge.Source
{
	using Core;
	using Engine;
	using UnityEngine;



	public abstract class VolumeProxy : MonoBehaviour
	{
		public abstract MEdge.Engine.Volume UnrealVolume{ get; }
	}



	public abstract class VolumeProxy<T> : VolumeProxy where T : Volume, new()
	{
		T _unrealInstance;



		public override Volume UnrealVolume
		{
			get
			{
				if( _unrealInstance != null )
					return _unrealInstance;
				
				UWorld.Instance.LowFrequencyUpdate.Add( SyncVolumeOuter );
				_unrealInstance = new T
				{
					Name = $"{typeof(T).Name}_{gameObject.name}",
				};
				SyncVolumeOuter();
				return _unrealInstance;
			}
		}



		protected void SyncVolumeOuter()
		{
			// Of course I have to do this kind of bullshit as unity doesn't handle property in the editor
			// Otherwise I would just sync when property changes ...
			_unrealInstance.Rotation = this.transform.rotation.ToUnrealRot();
			_unrealInstance.Location = this.transform.position.ToUnrealPos();
			SyncVolume( _unrealInstance );
		}



		protected abstract void SyncVolume( T volume );
	}
}