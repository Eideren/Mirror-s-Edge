namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_CreateAccountConfirm : TdUIScene_SubMenu/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	[transient] public UIEditBox LoginNameEditbox;
	[transient] public UIEditBox PasswordEditbox;
	[transient] public bool bAllowEaEmailHided;
	[transient] public bool bAllowThirdPartyEmailHided;
	public /*delegate*/TdUIScene_CreateAccountConfirm.CreateAccount __CreateAccount__Delegate;
	
	public delegate void CreateAccount(String LoginName, String Password, bool bAllowEaEmail, bool bAllowThirdPartyEmail);
	
	public override /*function */void SetupButtonBar()
	{
		// stub
	}
	
	public virtual /*function */bool OnButtonBar_Back(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_Submit(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnCloseScene()
	{
		// stub
	}
	
	public virtual /*function */void OnSubmit()
	{
		// stub
	}
	
	public virtual /*function */void OnSceneClosed_Submit(UIScene ClosedScene)
	{
		// stub
	}
	
	public virtual /*function */void SetUserLoginData(String LoginName, String Password, bool bAllowEaEmail, bool bAllowThirdPartyEmail)
	{
		// stub
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public TdUIScene_CreateAccountConfirm()
	{
		var Default__TdUIScene_CreateAccountConfirm_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_CreateAccountConfirm.SceneEventComponent' */;
		// Object Offset:0x00690871
		EventProvider = Default__TdUIScene_CreateAccountConfirm_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_CreateAccountConfirm.SceneEventComponent'*/;
	}
}
}