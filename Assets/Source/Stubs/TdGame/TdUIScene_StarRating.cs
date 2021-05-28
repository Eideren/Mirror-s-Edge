namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_StarRating : TdUIScene/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */UILabel TotalText;
	public /*transient */UILabel StarsText;
	public /*transient */UILabel UnlockText;
	public /*transient */UIImage LeftStar;
	public /*transient */UIImage CenterStar;
	public /*transient */UIImage RightStar;
	public /*transient */UIImage TotalStar;
	public /*transient */int NewLevelStarRating;
	public /*transient */int OldLevelStarRating;
	public /*transient */int OldTotalStarRating;
	public/*(Sound)*/ SoundCue StarSound;
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public virtual /*function */void InitializeScene(UIDataStore_TdTimeTrialData TimeTrialData, int CurrentStretchProviderIdx)
	{
	
	}
	
	public override /*function */void AnimEnd(UIObject AnimTarget, int AnimIndex, UIAnimationSeq AnimSeq)
	{
	
	}
	
	public virtual /*function */void SetStarsText(int Stars, string MapName)
	{
	
	}
	
	public virtual /*function */void SetTotalText(int Stars, TdTTResult TTResult)
	{
	
	}
	
	public virtual /*function */void SetStarRating(UIDataStore_TdTimeTrialData TimeTrialData, int CurrentStretchProviderIdx)
	{
	
	}
	
	public override /*function */void SetupButtonBar()
	{
	
	}
	
	public virtual /*function */bool OnButtonBar_Continue(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void OnContinue()
	{
	
	}
	
	public virtual /*private final function */void OnContinue_Done(UIScene OpenedScene)
	{
	
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public TdUIScene_StarRating()
	{
		// Object Offset:0x006AD5C1
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_StarRating.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_StarRating.SceneEventComponent'*/;
	}
}
}