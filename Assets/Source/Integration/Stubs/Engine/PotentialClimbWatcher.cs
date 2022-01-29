namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PotentialClimbWatcher : Info/*
		native
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public override Tick_del eventTick { get => bfield_Tick ?? PotentialClimbWatcher_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => PotentialClimbWatcher_Tick;
	public /*simulated event */void PotentialClimbWatcher_Tick(float DeltaTime)
	{
		// stub
	}
	protected override void RestoreDefaultFunction()
	{
		eventTick = null;
	
	}
	public PotentialClimbWatcher()
	{
		var Default__PotentialClimbWatcher_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__PotentialClimbWatcher.Sprite' */;
		// Object Offset:0x003A7903
		Components = new array</*export editinline */ActorComponent>
		{
			Default__PotentialClimbWatcher_Sprite/*Ref SpriteComponent'Default__PotentialClimbWatcher.Sprite'*/,
		};
	}
}
}