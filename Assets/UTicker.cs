namespace MEdge.Source
{
	using Engine;
	using TdGame;
	using UnityEngine;
	using Object = Core.Object;



	public class UTicker : MonoBehaviour, IUObject
	{
		public Actor ObjectToTick;



		void Start()
		{
			ObjectToTick = UWorld.Instance.E_UWorld_SpawnActor( Object.ClassT<TdPlayerPawn>(), 0, 0, (Object.Vector)this.transform.position, (Object.Rotator)this.transform.rotation, null, false, 0, null, null, false );
		}



		void Update()
		{
			ObjectToTick?.Tick(Time.deltaTime);
		}



		public Object GetUObject() => ObjectToTick;
	}
}