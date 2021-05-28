namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAimBotBase : Object/* within TdAIController*//*
		native*/{
	public new TdAIController Outer => base.Outer as TdAIController;
	
	public/*()*/ float MaxDispersion;
	public/*()*/ float MinDispersion;
	public/*()*/ float MinOffset;
	public/*()*/ float MaxYOffset;
	public/*()*/ float MinYOffset;
	public/*()*/ float ImprovementRate_Far;
	public/*()*/ float ImprovementRate_Medium;
	public/*()*/ float ImprovementRate_Near;
	public/*()*/ float MovementRateX;
	public/*()*/ float MovementRateY;
	public/*()*/ float MoveSidewaysMultiplier;
	public/*()*/ float MoveAwayMultiplier;
	public/*()*/ float MoveTowardMultiplier;
	public /*protected */float ImprovementRate;
	public /*protected */float OverriddenImprovementRate;
	public /*protected */Weapon CurrentWeapon;
	public /*protected */float BaseDispersion;
	public /*protected */float BaseOffset;
	public /*protected */float BaseYOffset;
	
	// Export UTdAimBotBase::execTick(FFrame&, void* const)
	public virtual /*native function */void Tick(float DeltaTime)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdAimBotBase::execGetImprovementRate(FFrame&, void* const)
	public virtual /*native function */float GetImprovementRate()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */void Render(TdPlayerPawn PlayerPawn)
	{
	
	}
	
	public virtual /*function */Object.Vector GetAimLocation(TdPlayerPawn Target, /*optional */bool bUseFullDispersion = default)
	{
	
		return default;
	}
	
	public virtual /*function */float GetDispersionModifier()
	{
	
		return default;
	}
	
	public virtual /*function */void SetWeapon(Weapon iWeapon)
	{
	
	}
	
	public virtual /*function */bool IsHitRelevant(Core.ClassT<DamageType> DamageType, name BoneName)
	{
	
		return default;
	}
	
	public virtual /*function */float GetOffsetThreshold()
	{
	
		return default;
	}
	
	public virtual /*function */float GetOffset()
	{
	
		return default;
	}
	
	// Export UTdAimBotBase::execGetMaxOffset(FFrame&, void* const)
	public virtual /*native final function */float GetMaxOffset()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */float GetMinOffset()
	{
	
		return default;
	}
	
	public virtual /*function */void OverrideImprovementRate(float NewImprovementRate)
	{
	
	}
	
	public virtual /*function */float GetSidewaysMultiplier()
	{
	
		return default;
	}
	
	public virtual /*function */float GetAwayMultiplier()
	{
	
		return default;
	}
	
	public virtual /*function */float GetTowardMultiplier()
	{
	
		return default;
	}
	
	public virtual /*function */bool MoveControlledDisperion()
	{
	
		return default;
	}
	
	public virtual /*function */bool CanHit()
	{
	
		return default;
	}
	
}
}