namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class BrowserManager : Object/*
		native
		config(Editor)*/{
	public partial struct /*native */BrowserPaneInfo
	{
		public int PaneID;
		public String WxWindowClassName;
		public String FriendlyName;
		public /*const */int CloneOfPaneID;
		public /*const */int CloneNumber;
		public /*const transient */Object.Pointer WxBrowserPtr;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0001A6E7
	//		PaneID = 0;
	//		WxWindowClassName = "";
	//		FriendlyName = "";
	//		CloneOfPaneID = 0;
	//		CloneNumber = 0;
	//		WxBrowserPtr = default;
	//	}
	};
	
	public /*config */array</*config */BrowserManager.BrowserPaneInfo> BrowserPanes;
	public bool bHasCreatedPanes;
	public /*config */int LastSelectedPaneID;
	public /*const transient */Object.Pointer DockingContainerPtr;
	public /*const transient */Object.Pointer FloatingWindowsArrayPtr;
	public /*const transient */Object.Pointer BrowserMenuPtr;
	public /*const transient */UISceneManager UISceneManager;
	
	public BrowserManager()
	{
		// Object Offset:0x0001A91B
		BrowserPanes = new array</*config */BrowserManager.BrowserPaneInfo>
		{
			new BrowserManager.BrowserPaneInfo
			{
				PaneID = 0,
				WxWindowClassName = "WxGenericBrowser",
				FriendlyName = "GenericBrowser",
				CloneOfPaneID = -1,
				CloneNumber = -1,
				WxBrowserPtr = default,
			},
			new BrowserManager.BrowserPaneInfo
			{
				PaneID = 1,
				WxWindowClassName = "WxActorBrowser",
				FriendlyName = "ActorBrowser",
				CloneOfPaneID = -1,
				CloneNumber = -1,
				WxBrowserPtr = default,
			},
			new BrowserManager.BrowserPaneInfo
			{
				PaneID = 2,
				WxWindowClassName = "WxGroupBrowser",
				FriendlyName = "GroupBrowser",
				CloneOfPaneID = -1,
				CloneNumber = -1,
				WxBrowserPtr = default,
			},
			new BrowserManager.BrowserPaneInfo
			{
				PaneID = 3,
				WxWindowClassName = "WxLevelBrowser",
				FriendlyName = "LevelBrowser",
				CloneOfPaneID = -1,
				CloneNumber = -1,
				WxBrowserPtr = default,
			},
			new BrowserManager.BrowserPaneInfo
			{
				PaneID = 4,
				WxWindowClassName = "WxReferencedAssetsBrowser",
				FriendlyName = "ReferencedAssetsBrowser",
				CloneOfPaneID = -1,
				CloneNumber = -1,
				WxBrowserPtr = default,
			},
			new BrowserManager.BrowserPaneInfo
			{
				PaneID = 5,
				WxWindowClassName = "WxTerrainBrowser",
				FriendlyName = "TerrainBrowser",
				CloneOfPaneID = -1,
				CloneNumber = -1,
				WxBrowserPtr = default,
			},
			new BrowserManager.BrowserPaneInfo
			{
				PaneID = 6,
				WxWindowClassName = "WxPrimitiveStatsBrowser",
				FriendlyName = "Primitive Stats",
				CloneOfPaneID = -1,
				CloneNumber = -1,
				WxBrowserPtr = default,
			},
			new BrowserManager.BrowserPaneInfo
			{
				PaneID = 7,
				WxWindowClassName = "WxDynamicShadowStatsBrowser",
				FriendlyName = "Dynamic Shadow Stats",
				CloneOfPaneID = -1,
				CloneNumber = -1,
				WxBrowserPtr = default,
			},
			new BrowserManager.BrowserPaneInfo
			{
				PaneID = 8,
				WxWindowClassName = "WxSceneManager",
				FriendlyName = "SceneManager",
				CloneOfPaneID = -1,
				CloneNumber = -1,
				WxBrowserPtr = default,
			},
			new BrowserManager.BrowserPaneInfo
			{
				PaneID = 30,
				WxWindowClassName = "WxLogBrowser",
				FriendlyName = "LogBrowser",
				CloneOfPaneID = -1,
				CloneNumber = -1,
				WxBrowserPtr = default,
			},
		};
	}
}
}