namespace MEdge.Engine
{
	using System;
	using System.Runtime.CompilerServices;
	using Object = Core.Object;



	public static class UWorldBridge
	{
		public static Func<IUWorld> GetUWorld{ get; set; }
	}



	public interface IUWorld
	{
		public T E_UWorld_SpawnActor<T>( Core.ClassT<T> SpawnClass, int a3, float a4, Object.Vector SpawnLocation, Object.Rotator SpawnRotation, Actor ActorTemplate, bool bNoCollisionFail, int networkRelatedParam, Actor SpawnOwner, Pawn Instigator, bool bProbablyNoFail ) where T : Actor;
		public TClass LoadAsset<TClass>( Core.String assetPath ) where TClass : new();
		public ConditionalWeakTable<object, object> UScriptToUnity{ get; }
	}
}