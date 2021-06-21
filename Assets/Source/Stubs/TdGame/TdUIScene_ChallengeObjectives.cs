namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_ChallengeObjectives : TdUIScene_ObjectivesScene/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public override /*function */void SetupButtonBar()
	{
		// stub
	}
	
	public virtual /*function */void OnFinishedObjectivesList_SubmitSelection(UIList Sender, /*optional */int? _PlayerIndex = default)
	{
		// stub
	}
	
	public override /*function */void OnTabPageActivated(UITabControl Sender, UITabPage NewlyActivePage, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */bool OnButtonBar_StartChallenge(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void StartChallenge()
	{
		// stub
	}
	
	public override /*function */void OnCloseScene()
	{
		// stub
	}
	
	public virtual /*function */void OnSceneDeactivated_RestartMovementChallenge(UIScene ClosedScene)
	{
		// stub
	}
	
	public virtual /*function */void OnSceneDeactivated_RestartCurrentMovementChallenge(UIScene ClosedScene)
	{
		// stub
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public TdUIScene_ChallengeObjectives()
	{
		var Default__TdUIScene_ChallengeObjectives_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_ChallengeObjectives.SceneEventComponent' */;
		// Object Offset:0x0068FD95
		ObjectivesToReadFieldName = (name)"Challenges";
		FinishedObjectivesToReadFieldName = (name)"FinishedChallenges";
		EventProvider = Default__TdUIScene_ChallengeObjectives_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_ChallengeObjectives.SceneEventComponent'*/;
	}
}
}