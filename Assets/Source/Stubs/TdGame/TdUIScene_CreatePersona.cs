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
	
	public delegate void CreatePersona(string Persona);
	
	public delegate void LoginPersona(string Persona);
	
	public delegate void UserAbort();
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public override /*function */void SetupButtonBar()
	{
	
	}
	
	public virtual /*function */bool OnButtonBar_Cancel(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_Submit(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void OnPersonasList_ValueChanged(UIObject Sender, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */void SetListPersonas(array<string> Personas)
	{
	
	}
	
	public virtual /*function */void UpdatePersonasBox()
	{
	
	}
	
	public virtual /*function */void OnSubmit()
	{
	
	}
	
	public virtual /*private final function */void OnCloseScene_LoginPersona(UIScene ClosedScene)
	{
	
	}
	
	public virtual /*private final function */void OnCloseScene_CreatePersona(UIScene ClosedScene)
	{
	
	}
	
	public virtual /*function */void OnSubmitError_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*function */void OnCancel()
	{
	
	}
	
	public virtual /*function */void PersonasList_OnSubmitSelection(UIList Sender, /*optional */int? _PlayerIndex = default)
	{
	
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public TdUIScene_CreatePersona()
	{
		// Object Offset:0x006944A0
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_CreatePersona.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_CreatePersona.SceneEventComponent'*/;
	}
}
}