namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_Unlocks : TdUIScene/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	[transient] public UIImage ArtworkBGImage;
	[transient] public UIImage ArtworkBGTopImage;
	[transient] public UIImage VideosBGImage;
	[transient] public UIImage VideosBGTopImage;
	[transient] public UIImage MusicBGImage;
	[transient] public UIImage MusicBGTopImage;
	[transient] public TdUITabControl TabControl;
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public virtual /*function */void OnTabPageActivated(UITabControl Sender, UITabPage NewlyActivePage, int PlayerIndex)
	{
		// stub
	}
	
	public override /*event */void OnPostTick(float DeltaTime, bool bTopmostScene)
	{
		// stub
	}
	
	public override /*function */void SetupButtonBar()
	{
		// stub
	}
	
	public virtual /*function */void OnCloseScene()
	{
		// stub
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public TdUIScene_Unlocks()
	{
		var Default__TdUIScene_Unlocks_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_Unlocks.SceneEventComponent' */;
		// Object Offset:0x006B6F46
		EventProvider = Default__TdUIScene_Unlocks_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_Unlocks.SceneEventComponent'*/;
	}
}
}