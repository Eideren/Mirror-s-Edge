namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUITabPage_UnlockedVideos : TdUITabPage/*
		hidecategories(Object,UIRoot,Object)*/{
	[transient] public UIList VideosList;
	[transient] public UILabel VideosDescriptionLabel;
	[transient] public UIImage VideosPreviewImage;
	[transient] public UILabel VideosPreviewLoadLabel;
	[transient] public TdUITabControl OwnerTabControl;
	[transient] public TdUIButtonBar ButtonBar;
	public UIDataStore_TdUnlocksData UnlocksData;
	[transient] public/*private*/ bool bPreviewImageIsDirty;
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public virtual /*function */void LinkSceneWidgets()
	{
		// stub
	}
	
	public virtual /*function */void OnVideosList_ValueChanged(UIObject Sender, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void TickPreviewImageUnlock(float DeltaTime)
	{
		// stub
	}
	
	public virtual /*function */void RefreshPreviewImage()
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
	
	public virtual /*function */bool OnButtonBar_Play(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void GetPathFromResourceParm(ref String VideoPath, ref String ImagePath)
	{
		// stub
	}
	
	public virtual /*function */void PlayMovie()
	{
		// stub
	}
	
	public virtual /*function */void OnWriteProfileSettings_Complete(bool bSuccess)
	{
		// stub
	}
	
	public virtual /*function */void VideosList_OnSubmitSelection(UIList Sender, /*optional */int? _PlayerIndex = default)
	{
		// stub
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public TdUITabPage_UnlockedVideos()
	{
		var Default__TdUITabPage_UnlockedVideos_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUITabPage_UnlockedVideos.WidgetEventComponent' */;
		// Object Offset:0x006BBDD3
		bPreviewImageIsDirty = true;
		EventProvider = Default__TdUITabPage_UnlockedVideos_WidgetEventComponent/*Ref UIComp_Event'Default__TdUITabPage_UnlockedVideos.WidgetEventComponent'*/;
	}
}
}