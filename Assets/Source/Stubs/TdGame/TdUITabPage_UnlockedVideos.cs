namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUITabPage_UnlockedVideos : TdUITabPage/*
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */UIList VideosList;
	public /*transient */UILabel VideosDescriptionLabel;
	public /*transient */UIImage VideosPreviewImage;
	public /*transient */UILabel VideosPreviewLoadLabel;
	public /*transient */TdUITabControl OwnerTabControl;
	public /*transient */TdUIButtonBar ButtonBar;
	public UIDataStore_TdUnlocksData UnlocksData;
	public /*private transient */bool bPreviewImageIsDirty;
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public virtual /*function */void LinkSceneWidgets()
	{
	
	}
	
	public virtual /*function */void OnVideosList_ValueChanged(UIObject Sender, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */void TickPreviewImageUnlock(float DeltaTime)
	{
	
	}
	
	public virtual /*function */void RefreshPreviewImage()
	{
	
	}
	
	public virtual /*function */void RefreshButtonBar()
	{
	
	}
	
	public virtual /*function */bool OnButtonBar_Back(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_Play(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void GetPathFromResourceParm(ref string VideoPath, ref string ImagePath)
	{
	
	}
	
	public virtual /*function */void PlayMovie()
	{
	
	}
	
	public virtual /*function */void OnWriteProfileSettings_Complete(bool bSuccess)
	{
	
	}
	
	public virtual /*function */void VideosList_OnSubmitSelection(UIList Sender, /*optional */int? _PlayerIndex = default)
	{
	
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public TdUITabPage_UnlockedVideos()
	{
		// Object Offset:0x006BBDD3
		bPreviewImageIsDirty = true;
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUITabPage_UnlockedVideos.WidgetEventComponent")/*Ref UIComp_Event'Default__TdUITabPage_UnlockedVideos.WidgetEventComponent'*/;
	}
}
}