namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUITabPage_UnlockedMusic : TdUITabPage/*
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */UIList MusicList;
	public /*transient */UILabel MusicDescriptionLabel;
	public /*transient */TdUITabControl OwnerTabControl;
	public /*transient */TdUIButtonBar ButtonBar;
	public UIDataStore_TdUnlocksData UnlocksData;
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public virtual /*function */void LinkSceneWidgets()
	{
	
	}
	
	public virtual /*function */void OnMusicList_ValueChanged(UIObject Sender, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */void RefreshButtonBar()
	{
	
	}
	
	public virtual /*function */bool OnButtonBar_Back(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_PlayMusic(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void PlayMusic()
	{
	
	}
	
	public virtual /*function */void OnWriteProfileSettings_Complete(bool bSuccess)
	{
	
	}
	
	public virtual /*function */void MusicList_OnSubmitSelection(UIList Sender, /*optional */int? _PlayerIndex = default)
	{
	
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public TdUITabPage_UnlockedMusic()
	{
		// Object Offset:0x006BAA2D
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUITabPage_UnlockedMusic.WidgetEventComponent")/*Ref UIComp_Event'Default__TdUITabPage_UnlockedMusic.WidgetEventComponent'*/;
	}
}
}