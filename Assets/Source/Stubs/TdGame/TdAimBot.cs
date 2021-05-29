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
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override /*function */Object.Vector GetAimLocation(TdPlayerPawn Target, /*optional */bool? _bUseFullDispersion = default)
	{
	
		return default;
	}
	
	public override /*function */float GetDispersionModifier()
	{
	
		return default;
	}
	
	// Export UTdAimBot::execTick(FFrame&, void* const)
	public override /*native function */void Tick(float DeltaTime)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdAimBot::execUpdateDispersion(FFrame&, void* const)
	public virtual /*native function */void UpdateDispersion(float DeltaTime)
	{
		#warning NATIVE FUNCTION !
	}
	
	public override /*function */void Render(TdPlayerPawn Target)
	{
	
	}
	
	public override /*function */bool IsHitRelevant(Core.ClassT<DamageType> DamageType, name BoneName)
	{
	
		return default;
	}
	
	public virtual /*private final function */bool ShouldMiss()
	{
	
		return default;
	}
	
	public virtual /*private final function */bool IsBulletDamage(Core.ClassT<DamageType> DamageType)
	{
	
		return default;
	}
	
	public virtual /*private final function */Object.Vector StartBurst(TdPlayerPawn Target, Weapon WeaponUsed)
	{
	
		return default;
	}
	
	public virtual /*private final function */float sign(float X)
	{
	
		return default;
	}
	
	public virtual /*private final function */Object.Vector GetNextLocation(TdPlayerPawn Target)
	{
	
		return default;
	}
	
	public virtual /*private final function */Object.Vector GetTargetLocation(TdPlayerPawn Target)
	{
	
		return default;
	}
	
	public virtual /*private final function */Object.Vector GetTargetViewpointLocation(TdPlayerPawn Target)
	{
	
		return default;
	}
	
	public virtual /*private final function */float GetDispersionWidth(TdPlayerPawn Target)
	{
	
		return default;
	}
	
	public virtual /*private final function */float GetDispersionOffset(TdPlayerPawn Target)
	{
	
		return default;
	}
	
	public virtual /*private final function */float GetDispersionHeight(TdPlayerPawn Target)
	{
	
		return default;
	}
	
	public virtual /*private final function */Object.Vector GetTargetPoint(Object.Vector StartLocation, Object.Vector TargetLocation, float X, float Y)
	{
	
		return default;
	}
	
	public virtual /*private final function */Object.Vector GetOffsetPoint(Object.Vector StartLocation, Object.Vector TargetLocation, float X, float Y)
	{
	
		return default;
	}
	
	public virtual /*private final function */Object.Vector PickPoint(TdPlayerPawn Target)
	{
	
		return default;
	}
	
}
}