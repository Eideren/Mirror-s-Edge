namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_CreateAccountPC : TdUIScene_SubMenu, 
		TdUIScene_CreateAccountInterface/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public const int MAX_PASSWD_LENGTH = 28;
	
	[transient] public UIEditBox LoginNameEditbox;
	[transient] public UIEditBox PasswordEditbox;
	[transient] public UIEditBox VerifyPasswordEditbox;
	[transient] public UIEditBox YearEditbox;
	[transient] public UIEditBox MonthEditbox;
	[transient] public UIEditBox DayEditbox;
	[transient] public UIComboBox CountryCombo;
	[transient] public UIComboBox LanguageCombo;
	[transient] public UIImage ComboListBG;
	public UIDataStore_TdLoginData LoginData;
	[transient] public String CreateAccountFail_LocError;
	public /*delegate*/TdUIScene_CreateAccountPC.UserAbort __UserAbort__Delegate;
	public /*delegate*/TdUIScene_CreateAccountPC.CreateAccountOnPC __CreateAccountOnPC__Delegate;
	
	public delegate void UserAbort();
	
	public delegate void CreateAccountOnPC(TpConnection.TpCreateAccountParams Params);
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public virtual /*function */void OnCountryComboList_VisibilityChanged(UIScreenObject SourceWidget, bool bIsVisible)
	{
		// stub
	}
	
	public override /*function */void SetupButtonBar()
	{
		// stub
	}
	
	public virtual /*function */void SetValues(bool bAllowEaEmail, bool bAllowTPEmail)
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
	
	public virtual /*function */void OnCloseScene()
	{
		// stub
	}
	
	public virtual /*function */void OnSceneClosed_UserAbort(UIScene ClosedScene)
	{
		// stub
	}
	
	public virtual /*function */void TryContinue()
	{
		// stub
	}
	
	public virtual /*private final function */void TryContinueFail_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
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
	
	public virtual /*private final function */void CreateAccountFail_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public TdUIScene_CreateAccountPC()
	{
		var Default__TdUIScene_CreateAccountPC_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_CreateAccountPC.SceneEventComponent' */;
		// Object Offset:0x00693443
		EventProvider = Default__TdUIScene_CreateAccountPC_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_CreateAccountPC.SceneEventComponent'*/;
	}
}
}