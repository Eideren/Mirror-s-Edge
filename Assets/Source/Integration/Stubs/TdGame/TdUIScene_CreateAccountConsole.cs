namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_CreateAccountConsole : TdUIScene_SubMenu, 
		TdUIScene_CreateAccountInterface/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	[transient] public UIEditBox LoginNameEditbox;
	[transient] public UIEditBox PasswordEditbox;
	[transient] public UIEditBox CurrentActiveEditbox;
	[transient] public/*private*/ String CreateAccountDone_LocError;
	public /*delegate*/TdUIScene_CreateAccountConsole.ConfirmCreateAccountConsole __ConfirmCreateAccountConsole__Delegate;
	public /*delegate*/TdUIScene_CreateAccountConsole.UserAbort __UserAbort__Delegate;
	
	public delegate void ConfirmCreateAccountConsole(String Email, String Password, bool bAllowEaEmail, bool bAllowThirdPartyEmail);
	
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
	
	public virtual /*function */bool OnButtonBar_Continue(UIScreenObject Sender, int PlayerIndex)
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
	
	public virtual /*function */void SetValues(String Email, String Password, bool bAllowEaEmail, bool bAllowTPEmail)
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
	
	public virtual /*function */void TryContinue()
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
	
	public virtual /*function */void CreateAccountDone(int Error, /*optional */String? _LocError = default)
	{
		// stub
	}
	
	public virtual /*function */void SetSceneDeactivatedDelegate(/*delegate*/UIScene.OnSceneDeactivated SceneDeactivated)
	{
		// stub
	}
	
	public virtual /*private final function */void CreateAccountError_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public TdUIScene_CreateAccountConsole()
	{
		var Default__TdUIScene_CreateAccountConsole_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_CreateAccountConsole.SceneEventComponent' */;
		// Object Offset:0x00691EF7
		EventProvider = Default__TdUIScene_CreateAccountConsole_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_CreateAccountConsole.SceneEventComponent'*/;
	}
}
}