namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPathLimitsVolume : Volume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public bool bEnabled;
	
	public override /*simulated function */void OnToggle(SeqAct_Toggle Action)
	{
		if(Action.InputLinks[0].bHasImpulse)
		{
			bEnabled = true;
		}
		if(Action.InputLinks[1].bHasImpulse)
		{
			bEnabled = false;
		}
		if(Action.InputLinks[2].bHasImpulse)
		{
			bEnabled = !bEnabled;
		}
	}
	
	public override /*simulated event */void CollisionChanged()
	{
	
	}
	
	
	protected (System.Action<name>, StateFlow, System.Action<name>) AssociatedTouch()/*state AssociatedTouch*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = default)
		{
			/*ignores*/ Touch = (a,b,c,d)=>{}; UnTouch = (a)=>{};
	
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (null, StateFlow, null);
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "AssociatedTouch": return AssociatedTouch();
			default: return base.FindState(stateName);
		}
	}
	public TdPathLimitsVolume()
	{
		// Object Offset:0x0060A773
		bEnabled = true;
		BrushColor = new Color
		{
			R=255,
			G=128,
			B=0,
			A=255
		};
		bColored = true;
		BrushComponent = LoadAsset<BrushComponent>("Default__TdPathLimitsVolume.BrushComponent0")/*Ref BrushComponent'Default__TdPathLimitsVolume.BrushComponent0'*/;
		bCollideActors = false;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<BrushComponent>("Default__TdPathLimitsVolume.BrushComponent0")/*Ref BrushComponent'Default__TdPathLimitsVolume.BrushComponent0'*/,
		};
		CollisionComponent = LoadAsset<BrushComponent>("Default__TdPathLimitsVolume.BrushComponent0")/*Ref BrushComponent'Default__TdPathLimitsVolume.BrushComponent0'*/;
	}
}
}