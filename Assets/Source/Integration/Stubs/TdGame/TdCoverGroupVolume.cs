namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdCoverGroupVolume : Volume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public/*()*/ /*editconst */array</*editconst */TdCoverGroup> Owners;
	
	public override /*simulated function */void OnToggle(SeqAct_Toggle Action)
	{
		// stub
	}
	
	public override /*simulated event */void CollisionChanged()
	{
		// stub
	}
	
	
	protected (System.Action<name>, StateFlow, System.Action<name>) AssociatedTouch()/*state AssociatedTouch*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "AssociatedTouch": return AssociatedTouch();
			default: return base.FindState(stateName);
		}
	}
	public TdCoverGroupVolume()
	{
		var Default__TdCoverGroupVolume_BrushComponent0 = new BrushComponent
		{
		}/* Reference: BrushComponent'Default__TdCoverGroupVolume.BrushComponent0' */;
		// Object Offset:0x0053E539
		BrushColor = new Color
		{
			R=255,
			G=128,
			B=0,
			A=255
		};
		bColored = true;
		BrushComponent = Default__TdCoverGroupVolume_BrushComponent0/*Ref BrushComponent'Default__TdCoverGroupVolume.BrushComponent0'*/;
		bCollideActors = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdCoverGroupVolume_BrushComponent0/*Ref BrushComponent'Default__TdCoverGroupVolume.BrushComponent0'*/,
		};
		CollisionComponent = Default__TdCoverGroupVolume_BrushComponent0/*Ref BrushComponent'Default__TdCoverGroupVolume.BrushComponent0'*/;
	}
}
}