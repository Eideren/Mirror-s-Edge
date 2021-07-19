namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUITabPage_UnlockedArtwork : TdUITabPage/*
		hidecategories(Object,UIRoot,Object)*/{
	[transient] public UIList ArtworkList;
	[transient] public UIImage ArtworkImage;
	[transient] public UILabel ArtworkDescriptionLabel;
	[transient] public UILabel ArtworkImageLoadLabel;
	[transient] public TdUITabControl OwnerTabControl;
	[transient] public TdUIButtonBar ButtonBar;
	public UIDataStore_TdUnlocksData UnlocksData;
	public UIScene ImageOverlayScene;
	[transient] public/*private*/ UIRoot.UIProviderFieldValue ImageFieldValue;
	[transient] public/*private*/ bool bArtworkImageIsDirty;
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public virtual /*function */void LinkSceneWidgets()
	{
		// stub
	}
	
	public virtual /*function */void OnArtworkList_ValueChanged(UIObject Sender, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void TickArtworkUnlock(float DeltaTime)
	{
		// stub
	}
	
	public virtual /*function */void RefreshArtworkImage()
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
	
	public virtual /*function */bool OnButtonBar_View(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void ViewImage()
	{
		// stub
	}
	
	public virtual /*function */void OnImageSceneOpened(UIScene ActivatedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*function */void OnImageSceneFullyOpened(UIScene OpenedScene)
	{
		// stub
	}
	
	public virtual /*function */void OnWriteProfileSettings_Complete(bool bSuccess)
	{
		// stub
	}
	
	public virtual /*function */void ArtworkList_OnSubmitSelection(UIList Sender, /*optional */int? _PlayerIndex = default)
	{
		// stub
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public TdUITabPage_UnlockedArtwork()
	{
		var Default__TdUITabPage_UnlockedArtwork_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUITabPage_UnlockedArtwork.WidgetEventComponent' */;
		// Object Offset:0x006B9CB4
		bArtworkImageIsDirty = true;
		EventProvider = Default__TdUITabPage_UnlockedArtwork_WidgetEventComponent/*Ref UIComp_Event'Default__TdUITabPage_UnlockedArtwork.WidgetEventComponent'*/;
	}
}
}