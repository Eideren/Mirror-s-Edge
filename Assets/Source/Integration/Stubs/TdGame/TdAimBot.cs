namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAimBot : TdAimBotBase/* within TdAIController*//*
		native*/{
	public new TdAIController Outer => base.Outer as TdAIController;
	
	public Object.Vector CurrentLocation;
	public float TimeOfLastShot;
	public float CurrentX;
	public float CurrentY;
	public float TargetX;
	public float TargetY;
	public float DiffX;
	
	// Export UTdAimBot::execGetImprovementRate(FFrame&, void* const)
	public override /*native function */float GetImprovementRate()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
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
	
	// Export UTdAimBot::execTick(FFrame&, void* const)
	public override /*native function */void Tick(float DeltaTime)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTdAimBot::execUpdateDispersion(FFrame&, void* const)
	public virtual /*native function */void UpdateDispersion(float DeltaTime)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public override /*function */void Render(TdPlayerPawn Target)
	{
		// stub
	}
	
	public override /*function */bool IsHitRelevant(Core.ClassT<DamageType> DamageType, name BoneName)
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */bool ShouldMiss()
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */bool IsBulletDamage(Core.ClassT<DamageType> DamageType)
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */Object.Vector StartBurst(TdPlayerPawn Target, Weapon WeaponUsed)
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */float sign(float X)
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */Object.Vector GetNextLocation(TdPlayerPawn Target)
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */Object.Vector GetTargetLocation(TdPlayerPawn Target)
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */Object.Vector GetTargetViewpointLocation(TdPlayerPawn Target)
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */float GetDispersionWidth(TdPlayerPawn Target)
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */float GetDispersionOffset(TdPlayerPawn Target)
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */float GetDispersionHeight(TdPlayerPawn Target)
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */Object.Vector GetTargetPoint(Object.Vector StartLocation, Object.Vector TargetLocation, float X, float Y)
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */Object.Vector GetOffsetPoint(Object.Vector StartLocation, Object.Vector TargetLocation, float X, float Y)
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */Object.Vector PickPoint(TdPlayerPawn Target)
	{
		// stub
		return default;
	}
	
}
}