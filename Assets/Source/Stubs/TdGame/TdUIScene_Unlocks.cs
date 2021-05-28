namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_Unlocks : TdUIScene/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */UIImage ArtworkBGImage;
	public /*transient */UIImage ArtworkBGTopImage;
	public /*transient */UIImage VideosBGImage;
	public /*transient */UIImage VideosBGTopImage;
	public /*transient */UIImage MusicBGImage;
	public /*transient */UIImage MusicBGTopImage;
	public /*transient */TdUITabControl TabControl;
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public virtual /*function */void OnTabPageActivated(UITabControl Sender, UITabPage NewlyActivePage, int PlayerIndex)
	{
	
	}
	
	public override /*event */void OnPostTick(float DeltaTime, bool bTopmostScene)
	{
	
	}
	
	public override /*function */void SetupButtonBar()
	{
	
	}
	
	public virtual /*function */void OnCloseScene()
	{
	
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public TdUIScene_Unlocks()
	{
		// Object Offset:0x006B6F46
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_Unlocks.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_Unlocks.SceneEventComponent'*/;
	}
}
}