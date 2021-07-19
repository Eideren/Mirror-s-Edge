namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSkelControlAim1p : SkelControlSingleBone/*
		native
		config(Animation)
		hidecategories(Object)*/{
	public enum EAimingType 
	{
		TDEAT_NoAim,
		TDEAT_UpperBody,
		TDEAT_Right,
		TDEAT_Left,
		TDEAT_MAX
	};
	
	[Category] public bool bApplySwanNeckTranslation;
	public bool bBlendInUnarmedAim;
	[config] public float UnarmedAimingMomentumThreshold;
	[config] public float UnarmedAimingBlendInTime;
	[config] public float UnarmedAimingBlendOutTime;
	public float CurrentUnarmedAimingMomentumThreshold;
	[Category("Aiming")] public TdSkelControlAim1p.EAimingType AimingType;
	
	// Export UTdSkelControlAim1p::execUpdateTransformation(FFrame&, void* const)
	public virtual /*native function */void UpdateTransformation(TdPawn PawnOwner)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	public virtual /*event */void OnInit()
	{
		CurrentUnarmedAimingMomentumThreshold = UnarmedAimingMomentumThreshold;
	}
	
	public TdSkelControlAim1p()
	{
		// Object Offset:0x00656A89
		bApplySwanNeckTranslation = true;
		UnarmedAimingMomentumThreshold = 100.0f;
		UnarmedAimingBlendInTime = 0.50f;
		UnarmedAimingBlendOutTime = 0.20f;
		CurrentUnarmedAimingMomentumThreshold = 330.0f;
	}
}
}