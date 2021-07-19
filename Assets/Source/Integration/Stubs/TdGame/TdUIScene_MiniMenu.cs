namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_MiniMenu : TdUIScene_Overlay/*
		native
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	[transient] public UIList OptionList;
	[transient] public UILabel TitleLabel;
	[transient] public UILabel SubtitleLabel;
	public/*private*/ UIDataStore_TdMiniMenuData MenuData;
	public name MenuDataStoreName;
	[transient] public/*private*/ array<String> Options;
	[transient] public/*private*/ array< /*delegate*/TdUIScene_MiniMenu.OnOptionCallback > OptionCallbacks;
	public /*delegate*/TdUIScene_MiniMenu.OnOptionCallback __OnOptionCallback__Delegate;
	
	public /*private final */delegate void OnOptionCallback();
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public override /*function */void SetupButtonBar()
	{
		// stub
	}
	
	public virtual /*function */bool OnButtonBar_Back(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
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
	
	public override /*event */void SceneDeactivated()
	{
		// stub
	}
	
	public virtual /*function */void OnOptionsList_SubmitSelection(UIList Sender, /*optional */int? _PlayerIndex = default)
	{
		// stub
	}
	
	public virtual /*function */void AddOption(String Option, /*delegate*/TdUIScene_MiniMenu.OnOptionCallback CallbackFunc)
	{
		// stub
	}
	
	public virtual /*function */void OnOptionSelected()
	{
		// stub
	}
	
	public virtual /*function */void FireOptionSelected(/*delegate*/TdUIScene_MiniMenu.OnOptionCallback OptionCallback)
	{
		// stub
	}
	
	public virtual /*function */void OnSceneClosed_FireOption(UIScene ClosedScene)
	{
		// stub
	}
	
	public virtual /*function */bool OnMBInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public TdUIScene_MiniMenu()
	{
		var Default__TdUIScene_MiniMenu_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_MiniMenu.SceneEventComponent' */;
		// Object Offset:0x0055C188
		MenuDataStoreName = (name)"TdMiniMenuData";
		EventProvider = Default__TdUIScene_MiniMenu_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_MiniMenu.SceneEventComponent'*/;
	}
}
}