namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSkelControlRecoil : TdSkelControlLimb/*
		native
		hidecategories(Object)*/{
	public float InterpFactor;
	public float MinInterpValue;
	public float CurrentRecoil;
	public float TargetRecoil;
	public float RecoverDelay;
	
	public virtual /*function */void AddImpulse(float Value, float delay, float Min, float Max)
	{
		EffectorLocation.X = FClamp(EffectorLocation.X + Value, Min, Max);
		RecoverDelay = delay;
	}
	
	public TdSkelControlRecoil()
	{
		// Object Offset:0x00657DEC
		InterpFactor = 15.0f;
		MinInterpValue = 0.050f;
	}
}
}