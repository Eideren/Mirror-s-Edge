namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_AccountLoginPC : TdUIScene_SubMenu/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public const int MAX_PASSWD_LENGTH = 28;
	
	[transient] public UIEditBox LoginNameEditbox;
	[transient] public UIEditBox PasswordEditbox;
	[transient] public UIEditBox CurrentActiveEditbox;
	public /*delegate*/TdUIScene_AccountLoginPC.LoginAccount __LoginAccount__Delegate;
	public /*delegate*/TdUIScene_AccountLoginPC.PrepareCreateAccount __PrepareCreateAccount__Delegate;
	public /*delegate*/TdUIScene_AccountLoginPC.UserAbort __UserAbort__Delegate;
	
	public delegate void LoginAccount(String Email, String Password);
	
	public delegate void PrepareCreateAccount();
	
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
	
	public virtual /*function */bool OnButtonBar_Login(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_CreateAccount(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_EditEditbox(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnCloseScene()
	{
		// stub
	}
	
	public virtual /*function */void OnSceneClosed_UserAbort(UIScene ClosedScene)
	{
		// stub
	}
	
	public virtual /*function */void OnEditBoxChanged(UIObject Sender, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */bool GetUserData(ref String LoginName, ref String Password)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void TryLogin()
	{
		// stub
	}
	
	public virtual /*function */void OnSceneClosed_Login(UIScene ClosedScene)
	{
		// stub
	}
	
	public virtual /*function */void OnEditEditbox()
	{
		// stub
	}
	
	public virtual /*function */void OnKeyboardInput_Complete(bool bWasSuccessful)
	{
		// stub
	}
	
	public virtual /*function */void OnCreateAccount()
	{
		// stub
	}
	
	public virtual /*function */void OnCreateAccount_Prepare(UIScene ClosedScene)
	{
		// stub
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public TdUIScene_AccountLoginPC()
	{
		var Default__TdUIScene_AccountLoginPC_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_AccountLoginPC.SceneEventComponent' */;
		// Object Offset:0x0068E16B
		EventProvider = Default__TdUIScene_AccountLoginPC_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_AccountLoginPC.SceneEventComponent'*/;
	}
}
}