namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_LoadLevel : TdUIScene_SubMenu/*
		native
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	[transient] public UIPanel BgPanel;
	[transient] public UIPanel MapPreviewPanel;
	[transient] public UIPanel LevelPanel;
	[transient] public UIPanel CheckpointPanel;
	[transient] public UIImage BgImage;
	[Category("Private")] [transient] public UIPanel LevelStatsPanel;
	[Category("Private")] [transient] public UILabel BagsFoundDataLabel;
	public UIDataStore_TdTimeTrialData TimeTrialData;
	public float AnimDuration;
	public float AnimTimeCount;
	public bool bSceneInitialized;
	public bool bToggleVisible;
	public float BgPanelDefaultY;
	public float MapPreviewPanelDefaultY;
	public float LevelPanelDefaultY;
	public float LevelPanelDefaultHeight;
	public float CheckpointPanelDefaultY;
	public float CheckpointPanelDefaultHeight;
	public float BgImageDefaultY;
	public float BgImageDefaultHeight;
	[transient] public UITdOptionButton LevelOptionButton;
	public UIScene LoadCheckpointScene;
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public override /*event */void SceneActivated(bool bInitialActivation)
	{
		// stub
	}
	
	public override /*function */void TopSceneChanged(UIScene NewTopScene)
	{
		// stub
	}
	
	public override /*function */void SetupButtonBar()
	{
		// stub
	}
	
	public virtual /*function */bool OnButtonBar_Back(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_Accept(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnLevelOptionButton_ValueChanged(UIObject Sender, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void OnCloseScene()
	{
		// stub
	}
	
	public virtual /*function */void UpdateLevelData()
	{
		// stub
	}
	
	public virtual /*function */void OnReadTimesCompleteDelegate(bool bSuccessful)
	{
		// stub
	}
	
	public virtual /*function */void UpdateLevelEvent()
	{
		// stub
	}
	
	public virtual /*function */void TryOpenScene()
	{
		// stub
	}
	
	public virtual /*function */void OnCloseScene_StartGame(UIScene ClosedScene)
	{
		// stub
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public TdUIScene_LoadLevel()
	{
		var Default__TdUIScene_LoadLevel_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_LoadLevel.SceneEventComponent' */;
		// Object Offset:0x0069C045
		AnimDuration = 0.30f;
		EventProvider = Default__TdUIScene_LoadLevel_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_LoadLevel.SceneEventComponent'*/;
	}
}
}