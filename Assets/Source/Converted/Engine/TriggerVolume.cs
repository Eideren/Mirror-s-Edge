namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TriggerVolume : Volume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public override /*simulated event */void PostBeginPlay()
	{
		base.PostBeginPlay();
		if(BrushComponent != default)
		{
			bProjTarget = BrushComponent.BlockZeroExtent;
		}
	}
	
	public override /*simulated function */bool StopsProjectile(Projectile P)
	{
		return false;
	}
	
	public TriggerVolume()
	{
		var Default__TriggerVolume_BrushComponent0 = new BrushComponent
		{
		}/* Reference: BrushComponent'Default__TriggerVolume.BrushComponent0' */;
		// Object Offset:0x003133C6
		BrushColor = new Color
		{
			R=100,
			G=255,
			B=100,
			A=255
		};
		bColored = true;
		BrushComponent = Default__TriggerVolume_BrushComponent0/*Ref BrushComponent'Default__TriggerVolume.BrushComponent0'*/;
		bProjTarget = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TriggerVolume_BrushComponent0/*Ref BrushComponent'Default__TriggerVolume.BrushComponent0'*/,
		};
		CollisionComponent = Default__TriggerVolume_BrushComponent0/*Ref BrushComponent'Default__TriggerVolume.BrushComponent0'*/;
		SupportedEvents = new array< Core.ClassT<SequenceEvent> >
		{
			ClassT<SeqEvent_Touch>(),
			ClassT<SeqEvent_TakeDamage>(),
		};
	}
}
}