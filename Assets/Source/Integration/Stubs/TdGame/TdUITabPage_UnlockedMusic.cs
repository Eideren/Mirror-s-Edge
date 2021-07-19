namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUITabPage_UnlockedMusic : TdUITabPage/*
		hidecategories(Object,UIRoot,Object)*/{
	[transient] public UIList MusicList;
	[transient] public UILabel MusicDescriptionLabel;
	[transient] public TdUITabControl OwnerTabControl;
	[transient] public TdUIButtonBar ButtonBar;
	public UIDataStore_TdUnlocksData UnlocksData;
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public virtual /*function */void LinkSceneWidgets()
	{
		// stub
	}
	
	public virtual /*function */void OnMusicList_ValueChanged(UIObject Sender, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void RefreshButtonBar()
	{
		// stub
	}
	
	public virtual /*function */bool OnButtonBar_Back(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_PlayMusic(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void PlayMusic()
	{
		// stub
	}
	
	public virtual /*function */void OnWriteProfileSettings_Complete(bool bSuccess)
	{
		// stub
	}
	
	public virtual /*function */void MusicList_OnSubmitSelection(UIList Sender, /*optional */int? _PlayerIndex = default)
	{
		// stub
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public TdUITabPage_UnlockedMusic()
	{
		var Default__TdUITabPage_UnlockedMusic_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUITabPage_UnlockedMusic.WidgetEventComponent' */;
		// Object Offset:0x006BAA2D
		EventProvider = Default__TdUITabPage_UnlockedMusic_WidgetEventComponent/*Ref UIComp_Event'Default__TdUITabPage_UnlockedMusic.WidgetEventComponent'*/;
	}
}
}