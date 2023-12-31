namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAITestScripts : Actor/*
		notplaceable
		hidecategories(Navigation)*/{
	public/*private*/ TdAIController AIController;
	public/*private*/ Object.Vector TargetLocation;
	public/*private*/ Object.Vector PlayerLocation;
	public/*private*/ int TestAngle;
	public/*private*/ int AngleStep;
	public/*private*/ int FocusAngle;
	public/*private*/ int FocusAngleStep;
	public/*private*/ float PauseTime;
	public/*private*/ float LongPauseTime;
	public/*private*/ int ActiveTestNr;
	public/*private*/ int ActiveSubTestNr;
	public/*private*/ bool bRunAllTests;
	public/*private*/ bool bHasReachedTarget;
	public bool bDrawDebug;
	public bool bUsePerfectStop;
	public/*private*/ TdCheatManager CheatManager;
	public/*private*/ Actor DestinationActor;
	public/*private*/ Object.Vector OldDebugPos;
	public/*private*/ float Distance;
	
	public virtual /*function */void Init(TdCheatManager InCheatManager, TdAIController Controller)
	{
		// stub
	}
	
	public virtual /*function */void RunAllTests()
	{
		// stub
	}
	
	public virtual /*function */void TestStartRunNativeAngles()
	{
		// stub
	}
	
	public virtual /*function */void TestStartRunAllAngles()
	{
		// stub
	}
	
	public virtual /*function */void TestStartRunAllAnglesLegRotation()
	{
		// stub
	}
	
	public virtual /*function */void TestStartRunDynamicAngles()
	{
		// stub
	}
	
	public virtual /*function */void TestStartWalkNativeAngles()
	{
		// stub
	}
	
	public virtual /*function */void TestStartWalkAllAngles()
	{
		// stub
	}
	
	public virtual /*function */void TestStartWalkAllAnglesLegRotation()
	{
		// stub
	}
	
	public virtual /*function */void TestStopRunAnimAngles()
	{
		// stub
	}
	
	public virtual /*function */void TestStopRunAllAngles()
	{
		// stub
	}
	
	public virtual /*function */void TestStopRunDynamicTarget()
	{
		// stub
	}
	
	public virtual /*function */void TestStopWalkAnimAngles()
	{
		// stub
	}
	
	public virtual /*function */void TestStopWalkAllAngles()
	{
		// stub
	}
	
	public virtual /*function */void TestStopWalkDynamicTarget()
	{
		// stub
	}
	
	public virtual /*function */void TestTurningAnimAngles()
	{
		// stub
	}
	
	public virtual /*function */void TestTurningAllAngles()
	{
		// stub
	}
	
	public virtual /*function */void TestTurningRandomAngles()
	{
		// stub
	}
	
	public virtual /*function */void StartTestAimPoses()
	{
		// stub
	}
	
	public virtual /*function */void BackOneTest()
	{
		// stub
	}
	
	public virtual /*function */void NextTest()
	{
		// stub
	}
	
	public virtual /*function */void SlomoSpeed(float SlomoSpeed)
	{
		// stub
	}
	
	public virtual /*private final function */Object.Vector GetMoveToLocation(float Angle)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void SetAiRotation(int AiRotation)
	{
		// stub
	}
	
	public virtual /*function */void PutAiInPositionForStartTest()
	{
		// stub
	}
	
	public virtual /*function */void PutPlayerInDefaultPosition()
	{
		// stub
	}
	
	public virtual /*function */bool HasReachedTarget(Object.Vector Target)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool HasReachedStopTarget(Object.Vector Target)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void PutAiInPositionForStopTest(float Angle, float Dist)
	{
		// stub
	}
	
	public virtual /*function */void PutPlayerInPositionForTurningTest(float Angle)
	{
		// stub
	}
	
	public virtual /*function */Object.Vector GetStopLocation()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void AdjustRotationForMovingBackwards(float Angle)
	{
		// stub
	}
	
	public virtual /*function */void DrawDebug()
	{
		// stub
	}
	
	
	protected /*function */void TdAITestScripts_TestStartRun_AnimationAngles_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*function */void TdAITestScripts_TestStartRun_AnimationAngles_EndState(name NextStateName)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) TestStartRun_AnimationAngles()/*state TestStartRun_AnimationAngles*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAITestScripts_TestStartRun_AllAngles_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*function */void TdAITestScripts_TestStartRun_AllAngles_EndState(name NextStateName)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) TestStartRun_AllAngles()/*state TestStartRun_AllAngles*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAITestScripts_TestStartRun_LegRotation_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*function */void TdAITestScripts_TestStartRun_LegRotation_EndState(name NextStateName)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) TestStartRun_LegRotation()/*state TestStartRun_LegRotation*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAITestScripts_TestStartRun_DynamicAngle_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*function */void TdAITestScripts_TestStartRun_DynamicAngle_EndState(name NextStateName)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) TestStartRun_DynamicAngle()/*state TestStartRun_DynamicAngle*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAITestScripts_TestStartWalk_AnimationAngles_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*function */void TdAITestScripts_TestStartWalk_AnimationAngles_EndState(name NextStateName)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) TestStartWalk_AnimationAngles()/*state TestStartWalk_AnimationAngles*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAITestScripts_TestStartWalk_AllAngles_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*function */void TdAITestScripts_TestStartWalk_AllAngles_EndState(name NextStateName)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) TestStartWalk_AllAngles()/*state TestStartWalk_AllAngles*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAITestScripts_TestStartWalk_LegRotation_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*function */void TdAITestScripts_TestStartWalk_LegRotation_EndState(name NextStateName)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) TestStartWalk_LegRotation()/*state TestStartWalk_LegRotation*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAITestScripts_TestStopRun_AnimationAngles_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) TestStopRun_AnimationAngles()/*state TestStopRun_AnimationAngles*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAITestScripts_TestStopRun_AllAngles_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*function */void TdAITestScripts_TestStopRun_AllAngles_EndState(name NextStateName)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) TestStopRun_AllAngles()/*state TestStopRun_AllAngles*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAITestScripts_TestStopRun_DynamicTarget_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*function */void TdAITestScripts_TestStopRun_DynamicTarget_EndState(name NextStateName)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) TestStopRun_DynamicTarget()/*state TestStopRun_DynamicTarget*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAITestScripts_TestStopWalk_AnimationAngles_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*function */void TdAITestScripts_TestStopWalk_AnimationAngles_EndState(name NextStateName)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) TestStopWalk_AnimationAngles()/*state TestStopWalk_AnimationAngles*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAITestScripts_TestStopWalk_AllAngels_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*function */void TdAITestScripts_TestStopWalk_AllAngels_EndState(name NextStateName)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) TestStopWalk_AllAngels()/*state TestStopWalk_AllAngels*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAITestScripts_TestStopWalk_DynamicTarget_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*function */void TdAITestScripts_TestStopWalk_DynamicTarget_EndState(name NextStateName)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) TestStopWalk_DynamicTarget()/*state TestStopWalk_DynamicTarget*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAITestScripts_TestStandingTurning_AnimationAngles_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*function */void TdAITestScripts_TestStandingTurning_AnimationAngles_EndState(name NextStateName)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) TestStandingTurning_AnimationAngles()/*state TestStandingTurning_AnimationAngles*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAITestScripts_TestStandingTurning_AllAngles_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*function */void TdAITestScripts_TestStandingTurning_AllAngles_EndState(name NextStateName)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) TestStandingTurning_AllAngles()/*state TestStandingTurning_AllAngles*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAITestScripts_TestStandingTurning_AllAnglesLegOffset_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*function */void TdAITestScripts_TestStandingTurning_AllAnglesLegOffset_EndState(name NextStateName)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) TestStandingTurning_AllAnglesLegOffset()/*state TestStandingTurning_AllAnglesLegOffset*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAITestScripts_TestStandingTurning_OrdinaryTurningSystem_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) TestStandingTurning_OrdinaryTurningSystem()/*state TestStandingTurning_OrdinaryTurningSystem*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAITestScripts_TestAimPoses_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*function */void TdAITestScripts_TestAimPoses_EndState(name NextStateName)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) TestAimPoses()/*state TestAimPoses*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "TestStartRun_AnimationAngles": return TestStartRun_AnimationAngles();
			case "TestStartRun_AllAngles": return TestStartRun_AllAngles();
			case "TestStartRun_LegRotation": return TestStartRun_LegRotation();
			case "TestStartRun_DynamicAngle": return TestStartRun_DynamicAngle();
			case "TestStartWalk_AnimationAngles": return TestStartWalk_AnimationAngles();
			case "TestStartWalk_AllAngles": return TestStartWalk_AllAngles();
			case "TestStartWalk_LegRotation": return TestStartWalk_LegRotation();
			case "TestStopRun_AnimationAngles": return TestStopRun_AnimationAngles();
			case "TestStopRun_AllAngles": return TestStopRun_AllAngles();
			case "TestStopRun_DynamicTarget": return TestStopRun_DynamicTarget();
			case "TestStopWalk_AnimationAngles": return TestStopWalk_AnimationAngles();
			case "TestStopWalk_AllAngels": return TestStopWalk_AllAngels();
			case "TestStopWalk_DynamicTarget": return TestStopWalk_DynamicTarget();
			case "TestStandingTurning_AnimationAngles": return TestStandingTurning_AnimationAngles();
			case "TestStandingTurning_AllAngles": return TestStandingTurning_AllAngles();
			case "TestStandingTurning_AllAnglesLegOffset": return TestStandingTurning_AllAnglesLegOffset();
			case "TestStandingTurning_OrdinaryTurningSystem": return TestStandingTurning_OrdinaryTurningSystem();
			case "TestAimPoses": return TestAimPoses();
			default: return base.FindState(stateName);
		}
	}
	public TdAITestScripts()
	{
		// Object Offset:0x004F80F8
		AngleStep = 15;
		FocusAngleStep = 30;
		PauseTime = 2.0f;
		LongPauseTime = 3.0f;
	}
}
}