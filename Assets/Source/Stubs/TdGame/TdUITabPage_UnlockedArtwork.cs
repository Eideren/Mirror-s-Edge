namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUITabPage_UnlockedArtwork : TdUITabPage/*
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */UIList ArtworkList;
	public /*transient */UIImage ArtworkImage;
	public /*transient */UILabel ArtworkDescriptionLabel;
	public /*transient */UILabel ArtworkImageLoadLabel;
	public /*transient */TdUITabControl OwnerTabControl;
	public /*transient */TdUIButtonBar ButtonBar;
	public UIDataStore_TdUnlocksData UnlocksData;
	public UIScene ImageOverlayScene;
	public /*private transient */UIRoot.UIProviderFieldValue ImageFieldValue;
	public /*private transient */bool bArtworkImageIsDirty;
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public virtual /*function */void LinkSceneWidgets()
	{
	
	}
	
	public virtual /*function */void OnArtworkList_ValueChanged(UIObject Sender, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */void TickArtworkUnlock(float DeltaTime)
	{
	
	}
	
	public virtual /*function */void RefreshArtworkImage()
	{
	
	}
	
	public virtual /*function */void RefreshButtonBar()
	{
	
	}
	
	public virtual /*function */bool OnButtonBar_Back(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_View(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void ViewImage()
	{
	
	}
	
	public virtual /*function */void OnImageSceneOpened(UIScene ActivatedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*function */void OnImageSceneFullyOpened(UIScene OpenedScene)
	{
	
	}
	
	public virtual /*function */void OnWriteProfileSettings_Complete(bool bSuccess)
	{
	
	}
	
	public virtual /*function */void ArtworkList_OnSubmitSelection(UIList Sender, /*optional */int? _PlayerIndex = default)
	{
	
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public TdUITabPage_UnlockedArtwork()
	{
		// Object Offset:0x006B9CB4
		bArtworkImageIsDirty = true;
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUITabPage_UnlockedArtwork.WidgetEventComponent")/*Ref UIComp_Event'Default__TdUITabPage_UnlockedArtwork.WidgetEventComponent'*/;
	}
}
}