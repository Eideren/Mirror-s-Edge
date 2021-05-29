namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_CreateAccountConsole : TdUIScene_SubMenu, 
		TdUIScene_CreateAccountInterface/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */UIEditBox LoginNameEditbox;
	public /*transient */UIEditBox PasswordEditbox;
	public /*transient */UIEditBox CurrentActiveEditbox;
	public /*private transient */string CreateAccountDone_LocError;
	public /*delegate*/TdUIScene_CreateAccountConsole.ConfirmCreateAccountConsole __ConfirmCreateAccountConsole__Delegate;
	public /*delegate*/TdUIScene_CreateAccountConsole.UserAbort __UserAbort__Delegate;
	
	public delegate void ConfirmCreateAccountConsole(string Email, string Password, bool bAllowEaEmail, bool bAllowThirdPartyEmail);
	
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
	
	public virtual /*function */bool OnButtonBar_Continue(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_EditEditbox(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void OnCloseScene()
	{
	
	}
	
	public virtual /*function */void OnSceneClosed_UserAbort(UIScene ClosedScene)
	{
	
	}
	
	public virtual /*function */void SetValues(string Email, string Password, bool bAllowEaEmail, bool bAllowTPEmail)
	{
	
	}
	
	public virtual /*function */void OnEditBoxChanged(UIObject Sender, int PlayerIndex)
	{
	
	}
	
	public virtual /*private final function */bool GetUserData(ref string LoginName, ref string Password)
	{
	
		return default;
	}
	
	public virtual /*function */void TryContinue()
	{
	
	}
	
	public virtual /*function */void OnEditEditbox()
	{
	
	}
	
	public virtual /*function */void OnKeyboardInput_Complete(bool bWasSuccessful)
	{
	
	}
	
	public virtual /*function */void CreateAccountDone(int Error, /*optional */string? _LocError = default)
	{
	
	}
	
	public virtual /*function */void SetSceneDeactivatedDelegate(/*delegate*/UIScene.OnSceneDeactivated SceneDeactivated)
	{
	
	}
	
	public virtual /*private final function */void CreateAccountError_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public TdUIScene_CreateAccountConsole()
	{
		// Object Offset:0x00691EF7
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_CreateAccountConsole.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_CreateAccountConsole.SceneEventComponent'*/;
	}
}
}