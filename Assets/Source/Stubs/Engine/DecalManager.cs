namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DecalManager : Actor/*
		native
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public partial struct /*native */ActiveDecalInfo
	{
		public /*export editinline */DecalComponent Decal;
		public float LifetimeRemaining;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00308D0B
	//		Decal = default;
	//		LifetimeRemaining = 0.0f;
	//	}
	};
	
	public /*protected export editinline */DecalComponent DecalTemplate;
	public /*export editinline */array</*export editinline */DecalComponent> PoolDecals;
	public /*globalconfig */int MaxActiveDecals;
	public /*globalconfig */bool bLogPoolOverflow;
	public /*globalconfig */bool bLogPoolOverflowList;
	public /*globalconfig */float DecalLifeSpan;
	public array<DecalManager.ActiveDecalInfo> ActiveDecals;
	
	// Export UDecalManager::execAreDynamicDecalsEnabled(FFrame&, void* const)
	public /*native final function */static bool AreDynamicDecalsEnabled()
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public virtual /*event */void DecalFinished(DecalComponent Decal)
	{
		// stub
	}
	
	public virtual /*function */bool CanSpawnDecals()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void ResetPool()
	{
		// stub
	}
	
	public virtual /*function */DecalComponent SpawnDecal(MaterialInterface DecalMaterial, Object.Vector DecalLocation, Object.Rotator DecalOrientation, float Width, float Height, float Thickness, bool bNoClip, /*optional */float? _DecalRotation = default, /*optional */PrimitiveComponent? _HitComponent = default, /*optional */bool? _bProjectOnTerrain = default, /*optional */bool? _bProjectOnSkeletalMeshes = default, /*optional */name? _HitBone = default, /*optional */int? _HitNodeIndex = default, /*optional */int? _HitLevelIndex = default, /*optional */float? _InDecalLifeSpan = default)
	{
		// stub
		return default;
	}
	
	public DecalManager()
	{
		var Default__DecalManager_BaseDecal = new DecalComponent
		{
		}/* Reference: DecalComponent'Default__DecalManager.BaseDecal' */;
		// Object Offset:0x003095F4
		DecalTemplate = Default__DecalManager_BaseDecal/*Ref DecalComponent'Default__DecalManager.BaseDecal'*/;
		MaxActiveDecals = 100;
		DecalLifeSpan = 30.0f;
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
	}
}
}