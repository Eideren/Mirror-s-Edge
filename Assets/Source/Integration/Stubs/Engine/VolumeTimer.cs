namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class VolumeTimer : Info/*
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public PhysicsVolume V;
	
	public override /*event */void eventPostBeginPlay()
	{
		// stub
	}
	
	public override Timer_del Timer { get => bfield_Timer ?? VolumeTimer_Timer; set => bfield_Timer = value; } Timer_del bfield_Timer;
	public override Timer_del global_Timer => VolumeTimer_Timer;
	public /*event */void VolumeTimer_Timer()
	{
		// stub
	}
	protected override void RestoreDefaultFunction()
	{
		Timer = null;
	
	}
	public VolumeTimer()
	{
		var Default__VolumeTimer_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__VolumeTimer.Sprite' */;
		// Object Offset:0x00459833
		Components = new array</*export editinline */ActorComponent>
		{
			Default__VolumeTimer_Sprite/*Ref SpriteComponent'Default__VolumeTimer.Sprite'*/,
		};
	}
}
}