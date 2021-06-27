namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_TdCredits : TdUIScene/*
		native
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public partial struct /*native */TdCreditsSubBlock
	{
		public String SubHeader;
		public array<String> Names;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00562347
	//		SubHeader = "";
	//		Names = default;
	//	}
	};
	
	public partial struct /*native */TdCreditsBlock
	{
		public String BlockHeader;
		public array<TdUIScene_TdCredits.TdCreditsSubBlock> SubBlocks;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00562443
	//		BlockHeader = "";
	//		SubBlocks = default;
	//	}
	};
	
	public /*private transient */UIPanel CreditsPanel;
	public /*private transient */UIImage LogoImage;
	public /*private transient */UIImage StickImage;
	public /*private transient */TdMenuPostProcesWrapper PanelBGRenderer;
	public /*private transient */array<TdUIScene_TdCredits.TdCreditsBlock> CreditBlocks;
	public /*private transient */float StartTime;
	public /*private transient */float ScrollSpeed;
	public /*private transient */Object.LinearColor CurrentCreditsTextColor;
	public /*private transient */int MaxBlocksToRead;
	public /*private transient */int NumBlocks;
	public /*private transient */int BlockWindowOffset;
	public /*private transient */float BlockYOffset;
	public /*private */StaticArray<MultiFont, MultiFont, MultiFont>/*[3]*/ Fonts;
	public /*private */bool bIsFinalCredits;
	public /*delegate*/TdUIScene_TdCredits.OnCloseCredits __OnCloseCredits__Delegate;
	
	public /*private final */delegate void OnCloseCredits();
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public virtual /*function */void UpdateSceneWidgets()
	{
		// stub
	}
	
	public override /*event */void SceneDeactivated()
	{
		// stub
	}
	
	public override /*event */void OnPostTick(float DeltaTime, bool bTopmostScene)
	{
		// stub
	}
	
	public virtual /*function */void SetFinalCredits(/*delegate*/TdUIScene_TdCredits.OnCloseCredits OnClose)
	{
		// stub
	}
	
	public virtual /*function */void OnCloseScene()
	{
		// stub
	}
	
	public virtual /*function */void SceneClosed(UIScene ClosedScene)
	{
		// stub
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public TdUIScene_TdCredits()
	{
		var Default__TdUIScene_TdCredits_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_TdCredits.SceneEventComponent' */;
		// Object Offset:0x00562E75
		ScrollSpeed = 14.90f;
		CurrentCreditsTextColor = new LinearColor
		{
			R=0.0f,
			G=0.0f,
			B=0.0f,
			A=1.0f
		};
		MaxBlocksToRead = 6;
		EventProvider = Default__TdUIScene_TdCredits_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_TdCredits.SceneEventComponent'*/;
	}
}
}