namespace MEdge.Engine
{
	using System;
	using System.Runtime.CompilerServices;
	using Source;
	using UnityEditor;
	using Object = Core.Object;



	public static class UWorldBridge
	{
		public static Func<IUWorld> GetUWorld{ get; set; }
	}



	public interface IUWorld
	{
		public T E_UWorld_SpawnActor<T>( Core.ClassT<T> SpawnClass, int a3, float a4, Object.Vector SpawnLocation, Object.Rotator SpawnRotation, Actor ActorTemplate, bool bNoCollisionFail, int networkRelatedParam, Actor SpawnOwner, Pawn Instigator, bool bProbablyNoFail ) where T : Actor;
		public TClass LoadAsset<TClass>( Core.String assetPath ) where TClass : new();
		public ConditionalWeakTable<object, UnityEngine.Object> UScriptToUnity{ get; }
		public unsafe bool MoveActor( Actor Actor, Object.Vector* Delta, Object.Rotator* NewRotation, uint MoveFlags, Source.DecFn.CheckResult* Hit );
		public unsafe bool SingleLineCheck( DecFn.CheckResult* a2, Actor a3, Object.Vector* a4, Object.Vector* a5, int a6, Object.Vector* a7, int a8 );
		public unsafe DecFn.CheckResult* MultiPointCheck( uint* Mem, Object.Vector* Location, Object.Vector* Extent, uint TraceFlags );
		public unsafe DecFn.CheckResult* MultiLineCheck( uint* Mem, Object.Vector* End, Object.Vector* Start, Object.Vector* Extent, uint TraceFlags, Actor SourceActor, LightComponent SourceLight );
		public unsafe bool FindSpot( Object.Vector* Extent, Object.Vector* Location, bool bUseComplexCollision );
		public unsafe bool FarMoveActor( Actor Actor, Object.Vector* DestLocation, bool test, bool bNoCheck, bool bAttachedMove );
		public unsafe bool EncroachingWorldGeometry( DecFn.CheckResult* Hit, Object.Vector* Location, Object.Vector* Extent, bool bUseComplexCollision );
		public float GetTimeSeconds();
		public bool HasBegunPlay();
	}
}