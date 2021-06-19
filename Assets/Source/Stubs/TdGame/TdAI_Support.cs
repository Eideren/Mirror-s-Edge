namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAI_Support : TdAIController/*
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public TdSuppressionSpot SuppressionSpot;
	public bool HaveReachedSuppressionSpot;
	
	public override TestCombatTransitions_del TestCombatTransitions { get => bfield_TestCombatTransitions ?? TdAI_Support_TestCombatTransitions; set => bfield_TestCombatTransitions = value; } TestCombatTransitions_del bfield_TestCombatTransitions;
	public override TestCombatTransitions_del global_TestCombatTransitions => TdAI_Support_TestCombatTransitions;
	public /*function */void TdAI_Support_TestCombatTransitions()
	{
	
	}
	
	public delegate bool RotationDiffNotTooLarge_del();
	public virtual RotationDiffNotTooLarge_del RotationDiffNotTooLarge { get => bfield_RotationDiffNotTooLarge ?? (()=>default); set => bfield_RotationDiffNotTooLarge = value; } RotationDiffNotTooLarge_del bfield_RotationDiffNotTooLarge;
	public virtual RotationDiffNotTooLarge_del global_RotationDiffNotTooLarge => ()=>default;
	protected override void RestoreDefaultFunction()
	{
		TestCombatTransitions = null;
	
	}
	
	protected /*function */void TdAI_Support_HoldAndSuppress_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*function */void TdAI_Support_HoldAndSuppress_EndState(name NextStateName)// state function
	{
	
	}
	
	protected /*function */bool TdAI_Support_HoldAndSuppress_RotationDiffNotTooLarge()// state function
	{
	
		return default;
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) HoldAndSuppress()/*state HoldAndSuppress extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "HoldAndSuppress": return HoldAndSuppress();
			default: return base.FindState(stateName);
		}
	}
	public TdAI_Support()
	{
		var Default__TdAI_Support_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdAI_Support.Sprite' */;
		// Object Offset:0x004E2E88
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdAI_Support_Sprite/*Ref SpriteComponent'Default__TdAI_Support.Sprite'*/,
		};
	}
}
}