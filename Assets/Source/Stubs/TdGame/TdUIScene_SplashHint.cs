namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_SplashHint : TdUIScene/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */UILabel TitleLabel;
	public /*transient */UILabel SectionLabel;
	public /*transient */UILabel DescriptionLabel;
	public /*transient */UIImage HintImage;
	public TdProfileSettings Profile;
	public int HintNumber;
	public String CurrentMap;
	public /*private */float ActivateTimer;
	public /*private */bool bInputActive;
	
	public override /*event */void Initialized()
	{
	
	}
	
	public virtual /*function */void SetupHint(int Number)
	{
	
	}
	
	public override /*function */void SetupButtonBar()
	{
	
	}
	
	public virtual /*function */bool OnButtonBar_Accept(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void OnCloseScene()
	{
	
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public override /*event */void OnPostTick(float DeltaTime, bool bTopmostScene)
	{
	
	}
	
	public virtual /*private final function */void ActivateInput(bool bActive)
	{
	
	}
	
	public virtual /*function */void InitSceneLabels()
	{
	
	}
	
	public TdUIScene_SplashHint()
	{
		// Object Offset:0x005638DF
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_SplashHint.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_SplashHint.SceneEventComponent'*/;
	}
}
}