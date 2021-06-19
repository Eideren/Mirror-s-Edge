namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAI_MeleeDummy : TdAI_Dummy/*
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public Object.Vector pos;
	
	public override /*event */void NotifyEnemyVisibilityChange(bool visible)
	{
	
	}
	
	public delegate void TestMelee_del();
	public virtual TestMelee_del TestMelee { get => bfield_TestMelee ?? TdAI_MeleeDummy_TestMelee; set => bfield_TestMelee = value; } TestMelee_del bfield_TestMelee;
	public virtual TestMelee_del global_TestMelee => TdAI_MeleeDummy_TestMelee;
	public /*function */void TdAI_MeleeDummy_TestMelee()
	{
	
	}
	
	public override TestCombatTransitions_del TestCombatTransitions { get => bfield_TestCombatTransitions ?? TdAI_MeleeDummy_TestCombatTransitions; set => bfield_TestCombatTransitions = value; } TestCombatTransitions_del bfield_TestCombatTransitions;
	public override TestCombatTransitions_del global_TestCombatTransitions => TdAI_MeleeDummy_TestCombatTransitions;
	public /*function */void TdAI_MeleeDummy_TestCombatTransitions()
	{
	
	}
	protected override void RestoreDefaultFunction()
	{
		TestMelee = null;
		TestCombatTransitions = null;
	
	}
	
	protected /*function */void TdAI_MeleeDummy_WaitToMelee_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*function */void TdAI_MeleeDummy_WaitToMelee_ContinuedState()// state function
	{
	
	}
	
	protected /*function */void TdAI_MeleeDummy_WaitToMelee_TestMelee()// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) WaitToMelee()/*auto state WaitToMelee extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Melee1()/*state Melee1 extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "WaitToMelee": return WaitToMelee();
			case "Melee1": return Melee1();
			default: return base.FindState(stateName);
		}
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) GetAutoState()
	{
	
	return WaitToMelee();
	}
	public TdAI_MeleeDummy()
	{
		var Default__TdAI_MeleeDummy_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdAI_MeleeDummy.Sprite' */;
		// Object Offset:0x004DCF8E
		bCanSee = true;
		bCanHear = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdAI_MeleeDummy_Sprite/*Ref SpriteComponent'Default__TdAI_MeleeDummy.Sprite'*/,
		};
		RotationRate = new Rotator
		{
			Pitch=30000,
			Yaw=15000,
			Roll=2048
		};
	}
}
}