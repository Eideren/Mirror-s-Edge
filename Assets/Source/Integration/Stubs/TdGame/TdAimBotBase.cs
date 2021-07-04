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
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTdAimBotBase::execGetImprovementRate(FFrame&, void* const)
	public virtual /*native function */float GetImprovementRate()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*function */void Render(TdPlayerPawn PlayerPawn)
	{
		// stub
	}
	
	public virtual /*function */Object.Vector GetAimLocation(TdPlayerPawn Target, /*optional */bool? _bUseFullDispersion = default)
	{
		// stub
		return default;
	}
	
	public virtual /*function */float GetDispersionModifier()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void SetWeapon(Weapon iWeapon)
	{
		// stub
	}
	
	public virtual /*function */bool IsHitRelevant(Core.ClassT<DamageType> DamageType, name BoneName)
	{
		// stub
		return default;
	}
	
	public virtual /*function */float GetOffsetThreshold()
	{
		// stub
		return default;
	}
	
	public virtual /*function */float GetOffset()
	{
		// stub
		return default;
	}
	
	// Export UTdAimBotBase::execGetMaxOffset(FFrame&, void* const)
	public virtual /*native final function */float GetMaxOffset()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*function */float GetMinOffset()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OverrideImprovementRate(float NewImprovementRate)
	{
		// stub
	}
	
	public virtual /*function */float GetSidewaysMultiplier()
	{
		// stub
		return default;
	}
	
	public virtual /*function */float GetAwayMultiplier()
	{
		// stub
		return default;
	}
	
	public virtual /*function */float GetTowardMultiplier()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool MoveControlledDisperion()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool CanHit()
	{
		// stub
		return default;
	}
	
}
}