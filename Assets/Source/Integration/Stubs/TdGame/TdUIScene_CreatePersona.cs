namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_CreatePersona : TdUIScene_SubMenu/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */UIList PersonasList;
	public /*transient */UIEditBox PersonaEditbox;
	public UIDataStore_TdLoginData LoginData;
	public /*delegate*/TdUIScene_CreatePersona.CreatePersona __CreatePersona__Delegate;
	public /*delegate*/TdUIScene_CreatePersona.LoginPersona __LoginPersona__Delegate;
	public /*delegate*/TdUIScene_CreatePersona.UserAbort __UserAbort__Delegate;
	
	public delegate void CreatePersona(String Persona);
	
	public delegate void LoginPersona(String Persona);
	
	public delegate void UserAbort();
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public override /*function */void SetupButtonBar()
	{
		// stub
	}
	
	public virtual /*function */bool OnButtonBar_Cancel(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_Submit(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnPersonasList_ValueChanged(UIObject Sender, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void SetListPersonas(array<String> Personas)
	{
		// stub
	}
	
	public virtual /*function */void UpdatePersonasBox()
	{
		// stub
	}
	
	public virtual /*function */void OnSubmit()
	{
		// stub
	}
	
	public virtual /*private final function */void OnCloseScene_LoginPersona(UIScene ClosedScene)
	{
		// stub
	}
	
	public virtual /*private final function */void OnCloseScene_CreatePersona(UIScene ClosedScene)
	{
		// stub
	}
	
	public virtual /*function */void OnSubmitError_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*function */void OnCancel()
	{
		// stub
	}
	
	public virtual /*function */void PersonasList_OnSubmitSelection(UIList Sender, /*optional */int? _PlayerIndex = default)
	{
		// stub
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public TdUIScene_CreatePersona()
	{
		var Default__TdUIScene_CreatePersona_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_CreatePersona.SceneEventComponent' */;
		// Object Offset:0x006944A0
		EventProvider = Default__TdUIScene_CreatePersona_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_CreatePersona.SceneEventComponent'*/;
	}
}
}