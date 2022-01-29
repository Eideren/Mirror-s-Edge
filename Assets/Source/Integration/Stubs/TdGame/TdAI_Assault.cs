namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAI_Assault : TdAIController/*
		native
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public bool bGrenadeExploded;
	public Object.Vector Explosion;
	
	public override /*event */bool ThrowGrenadeRequest(TdGrenadeTargetArea TargetArea)
	{
		// stub
		return default;
	}
	
	public override /*function */void NotifyGrenadeExploded(Object.Vector ExplosionLocation, float Lifetime)
	{
		// stub
	}
	
	public virtual /*function */void ResetCombatRange()
	{
		// stub
	}
	
	public override Tick_del eventTick { get => bfield_Tick ?? TdAI_Assault_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => TdAI_Assault_Tick;
	public /*event */void TdAI_Assault_Tick(float DeltaTime)
	{
		// stub
	}
	protected override void RestoreDefaultFunction()
	{
		eventTick = null;
	
	}
	public TdAI_Assault()
	{
		var Default__TdAI_Assault_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdAI_Assault.Sprite' */;
		// Object Offset:0x004D0DEF
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdAI_Assault_Sprite/*Ref SpriteComponent'Default__TdAI_Assault.Sprite'*/,
		};
	}
}
}