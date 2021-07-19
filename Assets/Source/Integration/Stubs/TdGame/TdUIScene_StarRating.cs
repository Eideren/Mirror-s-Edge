namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_StarRating : TdUIScene/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	[transient] public UILabel TotalText;
	[transient] public UILabel StarsText;
	[transient] public UILabel UnlockText;
	[transient] public UIImage LeftStar;
	[transient] public UIImage CenterStar;
	[transient] public UIImage RightStar;
	[transient] public UIImage TotalStar;
	[transient] public int NewLevelStarRating;
	[transient] public int OldLevelStarRating;
	[transient] public int OldTotalStarRating;
	[Category("Sound")] public SoundCue StarSound;
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public virtual /*function */void InitializeScene(UIDataStore_TdTimeTrialData TimeTrialData, int CurrentStretchProviderIdx)
	{
		// stub
	}
	
	public override /*function */void AnimEnd(UIObject AnimTarget, int AnimIndex, UIAnimationSeq AnimSeq)
	{
		// stub
	}
	
	public virtual /*function */void SetStarsText(int Stars, String MapName)
	{
		// stub
	}
	
	public virtual /*function */void SetTotalText(int Stars, TdTTResult TTResult)
	{
		// stub
	}
	
	public virtual /*function */void SetStarRating(UIDataStore_TdTimeTrialData TimeTrialData, int CurrentStretchProviderIdx)
	{
		// stub
	}
	
	public override /*function */void SetupButtonBar()
	{
		// stub
	}
	
	public virtual /*function */bool OnButtonBar_Continue(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnContinue()
	{
		// stub
	}
	
	public virtual /*private final function */void OnContinue_Done(UIScene OpenedScene)
	{
		// stub
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public TdUIScene_StarRating()
	{
		var Default__TdUIScene_StarRating_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_StarRating.SceneEventComponent' */;
		// Object Offset:0x006AD5C1
		EventProvider = Default__TdUIScene_StarRating_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_StarRating.SceneEventComponent'*/;
	}
}
}