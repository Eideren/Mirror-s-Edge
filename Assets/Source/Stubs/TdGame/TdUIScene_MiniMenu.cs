namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_MiniMenu : TdUIScene_Overlay/*
		native
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */UIList OptionList;
	public /*transient */UILabel TitleLabel;
	public /*transient */UILabel SubtitleLabel;
	public /*private */UIDataStore_TdMiniMenuData MenuData;
	public name MenuDataStoreName;
	public /*private transient */array<String> Options;
	public /*private transient */array< /*delegate*/TdUIScene_MiniMenu.OnOptionCallback > OptionCallbacks;
	public /*delegate*/TdUIScene_MiniMenu.OnOptionCallback __OnOptionCallback__Delegate;
	
	public /*private final */delegate void OnOptionCallback();
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public override /*function */void SetupButtonBar()
	{
	
	}
	
	public virtual /*function */bool OnButtonBar_Back(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_Accept(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void OnCloseScene()
	{
	
	}
	
	public override /*event */void SceneDeactivated()
	{
	
	}
	
	public virtual /*function */void OnOptionsList_SubmitSelection(UIList Sender, /*optional */int? _PlayerIndex = default)
	{
	
	}
	
	public virtual /*function */void AddOption(String Option, /*delegate*/TdUIScene_MiniMenu.OnOptionCallback CallbackFunc)
	{
	
	}
	
	public virtual /*function */void OnOptionSelected()
	{
	
	}
	
	public virtual /*function */void FireOptionSelected(/*delegate*/TdUIScene_MiniMenu.OnOptionCallback OptionCallback)
	{
	
	}
	
	public virtual /*function */void OnSceneClosed_FireOption(UIScene ClosedScene)
	{
	
	}
	
	public virtual /*function */bool OnMBInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public TdUIScene_MiniMenu()
	{
		// Object Offset:0x0055C188
		MenuDataStoreName = (name)"TdMiniMenuData";
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_MiniMenu.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_MiniMenu.SceneEventComponent'*/;
	}
}
}