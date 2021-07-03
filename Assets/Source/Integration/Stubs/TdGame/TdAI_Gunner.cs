namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAI_Gunner : TdAIController/*
		native
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public override TestCombatTransitions_del TestCombatTransitions { get => bfield_TestCombatTransitions ?? TdAI_Gunner_TestCombatTransitions; set => bfield_TestCombatTransitions = value; } TestCombatTransitions_del bfield_TestCombatTransitions;
	public override TestCombatTransitions_del global_TestCombatTransitions => TdAI_Gunner_TestCombatTransitions;
	public /*function */void TdAI_Gunner_TestCombatTransitions()
	{
		// stub
	}
	
	public override /*function */bool CanSearch()
	{
		// stub
		return default;
	}
	
	public override /*function */bool CanInvestigate()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool CanSetGoal()
	{
		// stub
		return default;
	}
	
	public override UpdatePose_del UpdatePose { get => bfield_UpdatePose ?? TdAI_Gunner_UpdatePose; set => bfield_UpdatePose = value; } UpdatePose_del bfield_UpdatePose;
	public override UpdatePose_del global_UpdatePose => TdAI_Gunner_UpdatePose;
	public /*function */void TdAI_Gunner_UpdatePose()
	{
		// stub
	}
	
	// Export UTdAI_Gunner::execUpdateAnchor(FFrame&, void* const)
	public override /*native function */void UpdateAnchor()
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	public override UpdatePawnFocus_del UpdatePawnFocus { get => bfield_UpdatePawnFocus ?? TdAI_Gunner_UpdatePawnFocus; set => bfield_UpdatePawnFocus = value; } UpdatePawnFocus_del bfield_UpdatePawnFocus;
	public override UpdatePawnFocus_del global_UpdatePawnFocus => TdAI_Gunner_UpdatePawnFocus;
	public /*function */void TdAI_Gunner_UpdatePawnFocus()
	{
		// stub
	}
	protected override void RestoreDefaultFunction()
	{
		TestCombatTransitions = null;
		UpdatePose = null;
		UpdatePawnFocus = null;
	
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) SuppressFromVehicle()/*state SuppressFromVehicle extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "SuppressFromVehicle": return SuppressFromVehicle();
			default: return base.FindState(stateName);
		}
	}
	public TdAI_Gunner()
	{
		var Default__TdAI_Gunner_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdAI_Gunner.Sprite' */;
		// Object Offset:0x004DC889
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdAI_Gunner_Sprite/*Ref SpriteComponent'Default__TdAI_Gunner.Sprite'*/,
		};
	}
}
}