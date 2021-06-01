namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_CreateAccountConfirm : TdUIScene_SubMenu/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */UIEditBox LoginNameEditbox;
	public /*transient */UIEditBox PasswordEditbox;
	public /*transient */bool bAllowEaEmailHided;
	public /*transient */bool bAllowThirdPartyEmailHided;
	public /*delegate*/TdUIScene_CreateAccountConfirm.CreateAccount __CreateAccount__Delegate;
	
	public delegate void CreateAccount(String LoginName, String Password, bool bAllowEaEmail, bool bAllowThirdPartyEmail);
	
	public override /*function */void SetupButtonBar()
	{
	
	}
	
	public virtual /*function */bool OnButtonBar_Back(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_Submit(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void OnCloseScene()
	{
	
	}
	
	public virtual /*function */void OnSubmit()
	{
	
	}
	
	public virtual /*function */void OnSceneClosed_Submit(UIScene ClosedScene)
	{
	
	}
	
	public virtual /*function */void SetUserLoginData(String LoginName, String Password, bool bAllowEaEmail, bool bAllowThirdPartyEmail)
	{
	
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public TdUIScene_CreateAccountConfirm()
	{
		// Object Offset:0x00690871
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_CreateAccountConfirm.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_CreateAccountConfirm.SceneEventComponent'*/;
	}
}
}