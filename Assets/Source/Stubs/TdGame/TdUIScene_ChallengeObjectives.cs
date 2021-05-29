namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_ChallengeObjectives : TdUIScene_ObjectivesScene/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public override /*function */void SetupButtonBar()
	{
	
	}
	
	public virtual /*function */void OnFinishedObjectivesList_SubmitSelection(UIList Sender, /*optional */int? _PlayerIndex = default)
	{
	
	}
	
	public override /*function */void OnTabPageActivated(UITabControl Sender, UITabPage NewlyActivePage, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */bool OnButtonBar_StartChallenge(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void StartChallenge()
	{
	
	}
	
	public override /*function */void OnCloseScene()
	{
	
	}
	
	public virtual /*function */void OnSceneDeactivated_RestartMovementChallenge(UIScene ClosedScene)
	{
	
	}
	
	public virtual /*function */void OnSceneDeactivated_RestartCurrentMovementChallenge(UIScene ClosedScene)
	{
	
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public TdUIScene_ChallengeObjectives()
	{
		// Object Offset:0x0068FD95
		ObjectivesToReadFieldName = (name)"Challenges";
		FinishedObjectivesToReadFieldName = (name)"FinishedChallenges";
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_ChallengeObjectives.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_ChallengeObjectives.SceneEventComponent'*/;
	}
}
}