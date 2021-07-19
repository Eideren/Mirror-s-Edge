namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdOnlineLoginHandler : Object{
	[transient] public TpConnection Connection;
	[transient] public TpSystemBase SystemBase;
	[transient] public OnlineSubsystem OnlineSub;
	[transient] public OnlinePlayerInterface PlayerInterface;
	public TdGameUISceneClient SceneClient;
	[transient] public UIScene AccountLoginPC;
	[transient] public UIScene TOS;
	[transient] public UIScene CreateAccountConsole;
	[transient] public UIScene CreateAccountConfirm;
	[transient] public UIScene CreateAccountPC;
	[transient] public UIScene OnlineCheck;
	[transient] public UIScene CreatePersonaScene;
	[transient] public UIScene ParentalEmailScene;
	[transient] public TdUIScene_CreateAccountInterface CreateAccountInstance;
	[transient] public TdUIScene_MessageBox ModalConnectingMessageBox;
	[transient] public bool bSkipSilentLoginAccount;
	[transient] public bool bIsInLoginProcess;
	[transient] public bool ConnectionRequired;
	[transient] public/*private*/ bool bAcceptEAMailParam;
	[transient] public/*private*/ bool bAcceptThirdPartyMailParam;
	[transient] public/*private*/ bool bAcceptParam;
	[transient] public/*private*/ bool bIsConsoleParam;
	[transient] public int LocalUserNum;
	[transient] public String LatestCreatedPersona;
	[transient] public array<TpConnection.TpCreateAccountCountry> TOSCountries;
	[transient] public LocalPlayer PlayerOwner;
	[transient] public/*private*/ String EmailStrParam;
	[transient] public/*private*/ String PasswdStrParam;
	[transient] public/*private*/ String PersonaStrParam;
	[transient] public/*private*/ String MessageParam;
	[transient] public/*private*/ String TOSStrParam;
	[transient] public/*private*/ TpConnection.TpCreateAccountParams CreateAccountParam;
	[transient] public/*private*/ TpAccount.TpAccountError AccountErrParam;
	[transient] public/*private*/ array<String> PersonasListParam;
	public /*delegate*/TdOnlineLoginHandler.OnPlayOffline __OnPlayOffline__Delegate;
	public /*delegate*/TdOnlineLoginHandler.OnConnectedAndFriendsLoaded __OnConnectedAndFriendsLoaded__Delegate;
	public /*delegate*/TdOnlineLoginHandler.OnModalBoxOpened __OnModalBoxOpened__Delegate;
	public /*delegate*/TdOnlineLoginHandler.OnModalBoxClosed __OnModalBoxClosed__Delegate;
	
	public delegate void OnPlayOffline(/*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default);
	
	public delegate void OnConnectedAndFriendsLoaded(/*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default);
	
	public delegate void OnModalBoxOpened();
	
	public delegate void OnModalBoxClosed();
	
	public virtual /*function */void SetLocalUserNum(int Value)
	{
		// stub
	}
	
	public virtual /*function */void Initialize(TdGameUISceneClient SClient, LocalPlayer Owner)
	{
		// stub
	}
	
	public virtual /*function */void Finalize()
	{
		// stub
	}
	
	public virtual /*function */void OnConnectionChange(OnlineSubsystem.EOnlineServerConnectionStatus ConnectionStatus)
	{
		// stub
	}
	
	public virtual /*function */bool IsInLoginProcess()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void StartConnection(bool IsConnectionRequired)
	{
		// stub
	}
	
	public virtual /*function */void VerifyVersion()
	{
		// stub
	}
	
	public virtual /*private final function */void OnVerifyVersion(String CurrentVersion)
	{
		// stub
	}
	
	public virtual /*private final function */void ShowNoConnection()
	{
		// stub
	}
	
	public virtual /*private final function */void ShowNoConnection_Init(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void ShowBadVersion()
	{
		// stub
	}
	
	public virtual /*private final function */void ShowBadVersion_Init(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void OnShowBadVersion_Response(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void OnStartConnection()
	{
		// stub
	}
	
	public virtual /*private final function */void LoginAccount(String Email, String Password)
	{
		// stub
	}
	
	public virtual /*private final function */void OnLoginAccount()
	{
		// stub
	}
	
	public virtual /*private final function */void AcceptTOS(bool Accept)
	{
		// stub
	}
	
	public virtual /*private final function */void OnAcceptTOS()
	{
		// stub
	}
	
	public virtual /*private final function */void ConfirmCreateAccountConsole(String Email, String Password, bool bAllowEaEmail, bool bAllowThirdPartyEmail)
	{
		// stub
	}
	
	public virtual /*private final function */void CreateAccountConfirm_Opened(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void CreateAccountOnConsole(String LoginName, String Password, bool bAllowEaEmail, bool bAllowThirdPartyEmail)
	{
		// stub
	}
	
	public virtual /*private final function */void OnCreateAccountOnConsole()
	{
		// stub
	}
	
	public virtual /*private final function */void CreateAccountOnPC(TpConnection.TpCreateAccountParams Params)
	{
		// stub
	}
	
	public virtual /*private final function */void OnCreateAccountOnPC()
	{
		// stub
	}
	
	public virtual /*private final function */void OnCreateAccountAsync_Fail()
	{
		// stub
	}
	
	public virtual /*private final function */void UserAbort()
	{
		// stub
	}
	
	public virtual /*function */void OnUserAbort_ModalClosed()
	{
		// stub
	}
	
	public virtual /*private final function */void Disconnect()
	{
		// stub
	}
	
	public virtual /*private final function */void PrepareCreateAccount()
	{
		// stub
	}
	
	public virtual /*private final function */void OnPrepareCreateAccount()
	{
		// stub
	}
	
	public virtual /*private final function */void CreatePersona(String Persona)
	{
		// stub
	}
	
	public virtual /*private final function */void OnCreatePersona()
	{
		// stub
	}
	
	public virtual /*private final function */void LoginPersona(String Persona)
	{
		// stub
	}
	
	public virtual /*private final function */void OnLoginPersona()
	{
		// stub
	}
	
	public virtual /*private final function */void ConfirmParentalEmail(String Email)
	{
		// stub
	}
	
	public virtual /*private final function */void OnConfirmParentalEmail()
	{
		// stub
	}
	
	public virtual /*private final function */void OnFriendsListLoaded(bool bInOk)
	{
		// stub
	}
	
	public virtual /*private final function */void OnFriendsListLoaded_ModalClosed()
	{
		// stub
	}
	
	public virtual /*private final function */void OnCreatePersonaError(int ErrorCode)
	{
		// stub
	}
	
	public virtual /*private final function */void OnCreatePersonaError_ModalClosed()
	{
		// stub
	}
	
	public virtual /*private final function */void OnCreatePersonaError_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void OnLoginPersonaError(int ErrorCode)
	{
		// stub
	}
	
	public virtual /*private final function */void OnLoginPersonaError_ModalClosed()
	{
		// stub
	}
	
	public virtual /*private final function */void OnLoginPersonaError_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void OnCreateAccountError(TpAccount.TpAccountError InError)
	{
		// stub
	}
	
	public virtual /*private final function */void OnCreateAccountError_ModalClosed()
	{
		// stub
	}
	
	public virtual /*private final function */void OnCreateAccountReady(String Email, String Pass, bool bAllowEaEmail, bool bAllowTPEmail, bool bIsConsole)
	{
		// stub
	}
	
	public virtual /*private final function */void OnCreateAccountReady_ModalClosed()
	{
		// stub
	}
	
	public virtual /*private final function */void CreateAccountConsole_Opened(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void CreateAccountPC_Opened(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void OnDisplayCountrySelect(array<TpConnection.TpCreateAccountCountry> Countries)
	{
		// stub
	}
	
	public virtual /*private final function */void OnLoginAccountError(TpAccount.TpAccountError InError)
	{
		// stub
	}
	
	public virtual /*private final function */void OnLoginAccountError_ModalClosed()
	{
		// stub
	}
	
	public virtual /*private final function */void OnLoginAccountError_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void OnLoginReady()
	{
		// stub
	}
	
	public virtual /*private final function */void OnLoginReady_ModalClosed()
	{
		// stub
	}
	
	public virtual /*private final function */void AccountLoginPC_Opened(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void OnDisplayPersonas(array<String> Personas)
	{
		// stub
	}
	
	public virtual /*private final function */void OnDisplayPersonas_ModalClosed()
	{
		// stub
	}
	
	public virtual /*private final function */void OnDisplayPersonas_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void CreatePersonaScene_Opened(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void OnGetTOS(String TOSText)
	{
		// stub
	}
	
	public virtual /*private final function */void OnGetTOS_ModalClosed()
	{
		// stub
	}
	
	public virtual /*private final function */void TOS_Opened(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void OnConnectionReady(String EncLogin, String Persona)
	{
		// stub
	}
	
	public virtual /*private final function */void OnConnectionFailed(TpConnection.TpConnectionError InError)
	{
		// stub
	}
	
	public virtual /*private final function */void OnConnectionFailed_ModalClosed()
	{
		// stub
	}
	
	public virtual /*private final function */void OnDisconnect()
	{
		// stub
	}
	
	public virtual /*private final function */void OnDisplayConfirmMessage(String Message)
	{
		// stub
	}
	
	public virtual /*private final function */void OnDisplayConfirmMessage_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void OnDisplayParentalEmail()
	{
		// stub
	}
	
	public virtual /*private final function */void OnDisplayParentalEmail_ModalClosed()
	{
		// stub
	}
	
	public virtual /*private final function */void ParentalEmailScene_Opened(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void OnSuccess()
	{
		// stub
	}
	
	public virtual /*private final function */void OnSucces_ClosedModal()
	{
		// stub
	}
	
	public virtual /*private final function */void OnFailure(bool UserAbort)
	{
		// stub
	}
	
	public virtual /*private final function */void OnFailure_Disconnect_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void OnFailure_ShowOffline_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void ShowOffline()
	{
		// stub
	}
	
	public virtual /*private final function */void OnlineCheck_Opened(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void PlayOfflineCallback()
	{
		// stub
	}
	
	public virtual /*private final function */void OnDisconnect_MessageBoxCallback(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void OnShowOffline_MessageBoxCallback(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void OnConfirmMessage_MessageBoxCallback(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void OnRepromptDisplay_MessageBoxCallback(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void OnModalBoxCancel_MessageBoxCallback(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void OnModalBoxPreSelecting()
	{
		// stub
	}
	
	public virtual /*private final function */void OnCreatePersonaDone_MessageBoxCallback(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void ShowModalBox(/*delegate*/TdOnlineLoginHandler.OnModalBoxOpened ModalBoxOpened, /*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default)
	{
		// stub
	}
	
	public virtual /*private final function */void ShowModalBox_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*function */void OnNotifyModalBoxCancel(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void OnModalBoxFullyOpened(UIScene OpenedScene)
	{
		// stub
	}
	
	public virtual /*private final function */void CloseModalBox(/*delegate*/TdOnlineLoginHandler.OnModalBoxClosed ModalBoxClosed)
	{
		// stub
	}
	
	public virtual /*private final function */void ModalBoxAboutToDie()
	{
		// stub
	}
	
}
}