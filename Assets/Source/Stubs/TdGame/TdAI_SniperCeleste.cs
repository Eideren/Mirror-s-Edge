namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAI_SniperCeleste : TdAI_Sniper/*
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public override UpdatePose_del UpdatePose { get => bfield_UpdatePose ?? TdAI_SniperCeleste_UpdatePose; set => bfield_UpdatePose = value; } UpdatePose_del bfield_UpdatePose;
	public override UpdatePose_del global_UpdatePose => TdAI_SniperCeleste_UpdatePose;
	public /*function */void TdAI_SniperCeleste_UpdatePose()
	{
	
	}
	
	public override LaserActive_del LaserActive { get => bfield_LaserActive ?? TdAI_SniperCeleste_LaserActive; set => bfield_LaserActive = value; } LaserActive_del bfield_LaserActive;
	public override LaserActive_del global_LaserActive => TdAI_SniperCeleste_LaserActive;
	public /*function */bool TdAI_SniperCeleste_LaserActive()
	{
	
		return default;
	}
	
	public override /*function */TdAIController.EDisarmState QueryDisarmState(TdPawn Disarmer)
	{
	
		return default;
	}
	
	public override CheckCrouching_del CheckCrouching { get => bfield_CheckCrouching ?? TdAI_SniperCeleste_CheckCrouching; set => bfield_CheckCrouching = value; } CheckCrouching_del bfield_CheckCrouching;
	public override CheckCrouching_del global_CheckCrouching => TdAI_SniperCeleste_CheckCrouching;
	public /*function */void TdAI_SniperCeleste_CheckCrouching()
	{
	
	}
	protected override void RestoreDefaultFunction()
	{
		UpdatePose = null;
		LaserActive = null;
		CheckCrouching = null;
	
	}
	public TdAI_SniperCeleste()
	{
		var Default__TdAI_SniperCeleste_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdAI_SniperCeleste.Sprite' */;
		// Object Offset:0x004E2744
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdAI_SniperCeleste_Sprite/*Ref SpriteComponent'Default__TdAI_SniperCeleste.Sprite'*/,
		};
	}
}
}