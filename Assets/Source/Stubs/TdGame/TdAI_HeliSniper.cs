namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAI_HeliSniper : TdAIController/*
		native
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	// Export UTdAI_HeliSniper::execUpdateAnchor(FFrame&, void* const)
	public override /*native function */void UpdateAnchor()
	{
		#warning NATIVE FUNCTION !
	}
	
	public override UpdatePose_del UpdatePose { get => bfield_UpdatePose ?? TdAI_HeliSniper_UpdatePose; set => bfield_UpdatePose = value; } UpdatePose_del bfield_UpdatePose;
	public override UpdatePose_del global_UpdatePose => TdAI_HeliSniper_UpdatePose;
	public /*function */void TdAI_HeliSniper_UpdatePose()
	{
	
	}
	
	public override ShouldEnterMelee_del ShouldEnterMelee { get => bfield_ShouldEnterMelee ?? TdAI_HeliSniper_ShouldEnterMelee; set => bfield_ShouldEnterMelee = value; } ShouldEnterMelee_del bfield_ShouldEnterMelee;
	public override ShouldEnterMelee_del global_ShouldEnterMelee => TdAI_HeliSniper_ShouldEnterMelee;
	public /*function */bool TdAI_HeliSniper_ShouldEnterMelee(float Range)
	{
	
		return default;
	}
	protected override void RestoreDefaultFunction()
	{
		UpdatePose = null;
		ShouldEnterMelee = null;
	
	}
	public TdAI_HeliSniper()
	{
		var Default__TdAI_HeliSniper_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdAI_HeliSniper.Sprite' */;
		// Object Offset:0x004DCAA9
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdAI_HeliSniper_Sprite/*Ref SpriteComponent'Default__TdAI_HeliSniper.Sprite'*/,
		};
	}
}
}