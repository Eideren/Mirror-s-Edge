namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_CreateAccountPC : TdUIScene_SubMenu, 
		TdUIScene_CreateAccountInterface/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public const int MAX_PASSWD_LENGTH = 28;
	
	public /*transient */UIEditBox LoginNameEditbox;
	public /*transient */UIEditBox PasswordEditbox;
	public /*transient */UIEditBox VerifyPasswordEditbox;
	public /*transient */UIEditBox YearEditbox;
	public /*transient */UIEditBox MonthEditbox;
	public /*transient */UIEditBox DayEditbox;
	public /*transient */UIComboBox CountryCombo;
	public /*transient */UIComboBox LanguageCombo;
	public /*transient */UIImage ComboListBG;
	public UIDataStore_TdLoginData LoginData;
	public /*transient */string CreateAccountFail_LocError;
	public /*delegate*/TdUIScene_CreateAccountPC.UserAbort __UserAbort__Delegate;
	public /*delegate*/TdUIScene_CreateAccountPC.CreateAccountOnPC __CreateAccountOnPC__Delegate;
	
	public delegate void UserAbort();
	
	public delegate void CreateAccountOnPC(TpConnection.TpCreateAccountParams Params);
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public virtual /*function */void OnCountryComboList_VisibilityChanged(UIScreenObject SourceWidget, bool bIsVisible)
	{
	
	}
	
	public override /*function */void SetupButtonBar()
	{
	
	}
	
	public virtual /*function */void SetValues(bool bAllowEaEmail, bool bAllowTPEmail)
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
	
	public virtual /*function */void OnCloseScene()
	{
	
	}
	
	public virtual /*function */void OnSceneClosed_UserAbort(UIScene ClosedScene)
	{
	
	}
	
	public virtual /*function */void TryContinue()
	{
	
	}
	
	public virtual /*private final function */void TryContinueFail_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*function */void CreateAccountDone(int Error, /*optional */string LocError = default)
	{
	
	}
	
	public virtual /*function */void SetSceneDeactivatedDelegate(/*delegate*/UIScene.OnSceneDeactivated SceneDeactivated)
	{
	
	}
	
	public virtual /*private final function */void CreateAccountFail_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public TdUIScene_CreateAccountPC()
	{
		// Object Offset:0x00693443
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_CreateAccountPC.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_CreateAccountPC.SceneEventComponent'*/;
	}
}
}