﻿namespace MEdge.Engine
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
		public bool MoveActor( Actor Actor, in Object.Vector Delta, in Object.Rotator NewRotation, uint MoveFlags, ref Source.DecFn.CheckResult Hit );
		public unsafe bool SingleLineCheck( ref DecFn.CheckResult a2, Actor a3, in Object.Vector a4, in Object.Vector a5, int a6, in Object.Vector a7 = default, int a8 = 0 );
		public unsafe DecFn.CheckResult* MultiLineCheck( ref int Mem, in Object.Vector End, in Object.Vector Start, in Object.Vector Extent, uint TraceFlags, Actor SourceActor, LightComponent SourceLight );
		public unsafe bool FindSpot( in Object.Vector Extent, ref Object.Vector Location, bool bUseComplexCollision );
		public unsafe bool FarMoveActor( Actor Actor, in Object.Vector DestLocation, bool test = false, bool bNoCheck = false, bool bAttachedMove = false );
		public unsafe bool EncroachingWorldGeometry( ref DecFn.CheckResult Hit, in Object.Vector Location, in Object.Vector Extent, bool bUseComplexCollision );
		public float GetTimeSeconds();
		public bool HasBegunPlay();
		public IUWorld BackupHash{ get; }
		public IUWorld Hash{ get; }
		public unsafe DecFn.CheckResult* ActorPointCheck( ref int Mem, in Object.Vector Location, in Object.Vector Extent, uint TraceFlags );
		public WorldInfo GetWorldInfo();
		public T SpawnActor<T>(Core.ClassT<T> c) where T : Actor;
		public PhysicsVolume GetDefaultPhysicsVolume();
		public unsafe DecFn.CheckResult* ActorEncroachmentCheck( ref int Mem, Actor Actor, Object.Vector Location, Object.Rotator Rotation, int TraceFlags );
	}
}