namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAI_Dummy : TdAIController/*
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public bool bCanSee;
	public bool bCanHear;
	
	public override SeePlayer_del SeePlayer { get => bfield_SeePlayer ?? TdAI_Dummy_SeePlayer; set => bfield_SeePlayer = value; } SeePlayer_del bfield_SeePlayer;
	public override SeePlayer_del global_SeePlayer => TdAI_Dummy_SeePlayer;
	public /*event */void TdAI_Dummy_SeePlayer(Pawn aPawn)
	{
		// stub
	}
	
	public override /*event */void HearNoise(float Loudness, Actor NoiseMaker, /*optional */name? _NoiseType = default)
	{
		// stub
	}
	
	public override AllowFire_del AllowFire { get => bfield_AllowFire ?? TdAI_Dummy_AllowFire; set => bfield_AllowFire = value; } AllowFire_del bfield_AllowFire;
	public override AllowFire_del global_AllowFire => TdAI_Dummy_AllowFire;
	public /*event */bool TdAI_Dummy_AllowFire()
	{
		// stub
		return default;
	}
	
	public override TestCombatTransitions_del TestCombatTransitions { get => bfield_TestCombatTransitions ?? TdAI_Dummy_TestCombatTransitions; set => bfield_TestCombatTransitions = value; } TestCombatTransitions_del bfield_TestCombatTransitions;
	public override TestCombatTransitions_del global_TestCombatTransitions => TdAI_Dummy_TestCombatTransitions;
	public /*function */void TdAI_Dummy_TestCombatTransitions()
	{
		// stub
	}
	
	public override UpdatePawnFocus_del UpdatePawnFocus { get => bfield_UpdatePawnFocus ?? TdAI_Dummy_UpdatePawnFocus; set => bfield_UpdatePawnFocus = value; } UpdatePawnFocus_del bfield_UpdatePawnFocus;
	public override UpdatePawnFocus_del global_UpdatePawnFocus => TdAI_Dummy_UpdatePawnFocus;
	public /*function */void TdAI_Dummy_UpdatePawnFocus()
	{
		// stub
	}
	protected override void RestoreDefaultFunction()
	{
		SeePlayer = null;
		AllowFire = null;
		TestCombatTransitions = null;
		UpdatePawnFocus = null;
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) DoNothing()/*auto state DoNothing*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "DoNothing": return DoNothing();
			default: return base.FindState(stateName);
		}
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) GetAutoState()
	{
	
	return DoNothing();
	}
	public TdAI_Dummy()
	{
		var Default__TdAI_Dummy_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdAI_Dummy.Sprite' */;
		// Object Offset:0x004DC407
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdAI_Dummy_Sprite/*Ref SpriteComponent'Default__TdAI_Dummy.Sprite'*/,
		};
	}
}
}