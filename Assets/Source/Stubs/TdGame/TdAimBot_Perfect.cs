namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAimBot_Perfect : TdAimBotBase/* within TdAIController*//*
		native*/{
	public new TdAIController Outer => base.Outer as TdAIController;
	
	public override /*function */Object.Vector GetAimLocation(TdPlayerPawn Target, /*optional */bool? _bUseFullDispersion = default)
	{
		// stub
		return default;
	}
	
	public override /*function */float GetDispersionModifier()
	{
		// stub
		return default;
	}
	
	public override /*function */void SetWeapon(Weapon iWeapon)
	{
		// stub
	}
	
	public override /*function */bool IsHitRelevant(Core.ClassT<DamageType> DamageType, name BoneName)
	{
		// stub
		return default;
	}
	
}
}