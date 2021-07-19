namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_SplashHint : TdUIScene/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	[transient] public UILabel TitleLabel;
	[transient] public UILabel SectionLabel;
	[transient] public UILabel DescriptionLabel;
	[transient] public UIImage HintImage;
	public TdProfileSettings Profile;
	public int HintNumber;
	public String CurrentMap;
	public/*private*/ float ActivateTimer;
	public/*private*/ bool bInputActive;
	
	public override /*event */void Initialized()
	{
		// stub
	}
	
	public virtual /*function */void SetupHint(int Number)
	{
		// stub
	}
	
	public override /*function */void SetupButtonBar()
	{
		// stub
	}
	
	public virtual /*function */bool OnButtonBar_Accept(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
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
	
	public override /*event */void OnPostTick(float DeltaTime, bool bTopmostScene)
	{
		// stub
	}
	
	public virtual /*private final function */void ActivateInput(bool bActive)
	{
		// stub
	}
	
	public virtual /*function */void InitSceneLabels()
	{
		// stub
	}
	
	public TdUIScene_SplashHint()
	{
		var Default__TdUIScene_SplashHint_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_SplashHint.SceneEventComponent' */;
		// Object Offset:0x005638DF
		EventProvider = Default__TdUIScene_SplashHint_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_SplashHint.SceneEventComponent'*/;
	}
}
}