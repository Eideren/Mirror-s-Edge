namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdOnlineLoginHandler : Object{
	public /*transient */TpConnection Connection;
	public /*transient */TpSystemBase SystemBase;
	public /*transient */OnlineSubsystem OnlineSub;
	public /*transient */OnlinePlayerInterface PlayerInterface;
	public TdGameUISceneClient SceneClient;
	public /*transient */UIScene AccountLoginPC;
	public /*transient */UIScene TOS;
	public /*transient */UIScene CreateAccountConsole;
	public /*transient */UIScene CreateAccountConfirm;
	public /*transient */UIScene CreateAccountPC;
	public /*transient */UIScene OnlineCheck;
	public /*transient */UIScene CreatePersonaScene;
	public /*transient */UIScene ParentalEmailScene;
	public /*transient */TdUIScene_CreateAccountInterface CreateAccountInstance;
	public /*transient */TdUIScene_MessageBox ModalConnectingMessageBox;
	public /*transient */bool bSkipSilentLoginAccount;
	public /*transient */bool bIsInLoginProcess;
	public /*transient */bool ConnectionRequired;
	public /*private transient */bool bAcceptEAMailParam;
	public /*private transient */bool bAcceptThirdPartyMailParam;
	public /*private transient */bool bAcceptParam;
	public /*private transient */bool bIsConsoleParam;
	public /*transient */int LocalUserNum;
	public /*transient */string LatestCreatedPersona;
	public /*transient */array<TpConnection.TpCreateAccountCountry> TOSCountries;
	public /*transient */LocalPlayer PlayerOwner;
	public /*private transient */string EmailStrParam;
	public /*private transient */string PasswdStrParam;
	public /*private transient */string PersonaStrParam;
	public /*private transient */string MessageParam;
	public /*private transient */string TOSStrParam;
	public /*private transient */TpConnection.TpCreateAccountParams CreateAccountParam;
	public /*private transient */TpAccount.TpAccountError AccountErrParam;
	public /*private transient */array<string> PersonasListParam;
	public /*delegate*/TdOnlineLoginHandler.OnPlayOffline __OnPlayOffline__Delegate;
	public /*delegate*/TdOnlineLoginHandler.OnConnectedAndFriendsLoaded __OnConnectedAndFriendsLoaded__Delegate;
	public /*delegate*/TdOnlineLoginHandler.OnModalBoxOpened __OnModalBoxOpened__Delegate;
	public /*delegate*/TdOnlineLoginHandler.OnModalBoxClosed __OnModalBoxClosed__Delegate;
	
	public delegate void OnPlayOffline(/*optional */UIScene.ESceneTransitionAnim SceneAnim = default);
	
	public delegate void OnConnectedAndFriendsLoaded(/*optional */UIScene.ESceneTransitionAnim SceneAnim = default);
	
	public delegate void OnModalBoxOpened();
	
	public delegate void OnModalBoxClosed();
	
	public virtual /*function */void SetLocalUserNum(int Value)
	{
	
	}
	
	public virtual /*function */void Initialize(TdGameUISceneClient SClient, LocalPlayer Owner)
	{
	
	}
	
	public virtual /*function */void Finalize()
	{
	
	}
	
	public virtual /*function */void OnConnectionChange(OnlineSubsystem.EOnlineServerConnectionStatus ConnectionStatus)
	{
	
	}
	
	public virtual /*function */bool IsInLoginProcess()
	{
	
		return default;
	}
	
	public virtual /*function */void StartConnection(bool IsConnectionRequired)
	{
	
	}
	
	public virtual /*function */void VerifyVersion()
	{
	
	}
	
	public virtual /*private final function */void OnVerifyVersion(string CurrentVersion)
	{
	
	}
	
	public virtual /*private final function */void ShowNoConnection()
	{
	
	}
	
	public virtual /*private final function */void ShowNoConnection_Init(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void ShowBadVersion()
	{
	
	}
	
	public virtual /*private final function */void ShowBadVersion_Init(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void OnShowBadVersion_Response(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */void OnStartConnection()
	{
	
	}
	
	public virtual /*private final function */void LoginAccount(string Email, string Password)
	{
	
	}
	
	public virtual /*private final function */void OnLoginAccount()
	{
	
	}
	
	public virtual /*private final function */void AcceptTOS(bool Accept)
	{
	
	}
	
	public virtual /*private final function */void OnAcceptTOS()
	{
	
	}
	
	public virtual /*private final function */void ConfirmCreateAccountConsole(string Email, string Password, bool bAllowEaEmail, bool bAllowThirdPartyEmail)
	{
	
	}
	
	public virtual /*private final function */void CreateAccountConfirm_Opened(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void CreateAccountOnConsole(string LoginName, string Password, bool bAllowEaEmail, bool bAllowThirdPartyEmail)
	{
	
	}
	
	public virtual /*private final function */void OnCreateAccountOnConsole()
	{
	
	}
	
	public virtual /*private final function */void CreateAccountOnPC(TpConnection.TpCreateAccountParams Params)
	{
	
	}
	
	public virtual /*private final function */void OnCreateAccountOnPC()
	{
	
	}
	
	public virtual /*private final function */void OnCreateAccountAsync_Fail()
	{
	
	}
	
	public virtual /*private final function */void UserAbort()
	{
	
	}
	
	public virtual /*function */void OnUserAbort_ModalClosed()
	{
	
	}
	
	public virtual /*private final function */void Disconnect()
	{
	
	}
	
	public virtual /*private final function */void PrepareCreateAccount()
	{
	
	}
	
	public virtual /*private final function */void OnPrepareCreateAccount()
	{
	
	}
	
	public virtual /*private final function */void CreatePersona(string Persona)
	{
	
	}
	
	public virtual /*private final function */void OnCreatePersona()
	{
	
	}
	
	public virtual /*private final function */void LoginPersona(string Persona)
	{
	
	}
	
	public virtual /*private final function */void OnLoginPersona()
	{
	
	}
	
	public virtual /*private final function */void ConfirmParentalEmail(string Email)
	{
	
	}
	
	public virtual /*private final function */void OnConfirmParentalEmail()
	{
	
	}
	
	public virtual /*private final function */void OnFriendsListLoaded(bool bInOk)
	{
	
	}
	
	public virtual /*private final function */void OnFriendsListLoaded_ModalClosed()
	{
	
	}
	
	public virtual /*private final function */void OnCreatePersonaError(int ErrorCode)
	{
	
	}
	
	public virtual /*private final function */void OnCreatePersonaError_ModalClosed()
	{
	
	}
	
	public virtual /*private final function */void OnCreatePersonaError_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void OnLoginPersonaError(int ErrorCode)
	{
	
	}
	
	public virtual /*private final function */void OnLoginPersonaError_ModalClosed()
	{
	
	}
	
	public virtual /*private final function */void OnLoginPersonaError_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void OnCreateAccountError(TpAccount.TpAccountError InError)
	{
	
	}
	
	public virtual /*private final function */void OnCreateAccountError_ModalClosed()
	{
	
	}
	
	public virtual /*private final function */void OnCreateAccountReady(string Email, string Pass, bool bAllowEaEmail, bool bAllowTPEmail, bool bIsConsole)
	{
	
	}
	
	public virtual /*private final function */void OnCreateAccountReady_ModalClosed()
	{
	
	}
	
	public virtual /*private final function */void CreateAccountConsole_Opened(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void CreateAccountPC_Opened(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void OnDisplayCountrySelect(array<TpConnection.TpCreateAccountCountry> Countries)
	{
	
	}
	
	public virtual /*private final function */void OnLoginAccountError(TpAccount.TpAccountError InError)
	{
	
	}
	
	public virtual /*private final function */void OnLoginAccountError_ModalClosed()
	{
	
	}
	
	public virtual /*private final function */void OnLoginAccountError_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void OnLoginReady()
	{
	
	}
	
	public virtual /*private final function */void OnLoginReady_ModalClosed()
	{
	
	}
	
	public virtual /*private final function */void AccountLoginPC_Opened(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void OnDisplayPersonas(array<string> Personas)
	{
	
	}
	
	public virtual /*private final function */void OnDisplayPersonas_ModalClosed()
	{
	
	}
	
	public virtual /*private final function */void OnDisplayPersonas_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void CreatePersonaScene_Opened(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void OnGetTOS(string TOSText)
	{
	
	}
	
	public virtual /*private final function */void OnGetTOS_ModalClosed()
	{
	
	}
	
	public virtual /*private final function */void TOS_Opened(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void OnConnectionReady(string EncLogin, string Persona)
	{
	
	}
	
	public virtual /*private final function */void OnConnectionFailed(TpConnection.TpConnectionError InError)
	{
	
	}
	
	public virtual /*private final function */void OnConnectionFailed_ModalClosed()
	{
	
	}
	
	public virtual /*private final function */void OnDisconnect()
	{
	
	}
	
	public virtual /*private final function */void OnDisplayConfirmMessage(string Message)
	{
	
	}
	
	public virtual /*private final function */void OnDisplayConfirmMessage_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void OnDisplayParentalEmail()
	{
	
	}
	
	public virtual /*private final function */void OnDisplayParentalEmail_ModalClosed()
	{
	
	}
	
	public virtual /*private final function */void ParentalEmailScene_Opened(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void OnSuccess()
	{
	
	}
	
	public virtual /*private final function */void OnSucces_ClosedModal()
	{
	
	}
	
	public virtual /*private final function */void OnFailure(bool UserAbort)
	{
	
	}
	
	public virtual /*private final function */void OnFailure_Disconnect_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void OnFailure_ShowOffline_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void ShowOffline()
	{
	
	}
	
	public virtual /*private final function */void OnlineCheck_Opened(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void PlayOfflineCallback()
	{
	
	}
	
	public virtual /*private final function */void OnDisconnect_MessageBoxCallback(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*private final function */void OnShowOffline_MessageBoxCallback(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*private final function */void OnConfirmMessage_MessageBoxCallback(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*private final function */void OnRepromptDisplay_MessageBoxCallback(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*private final function */void OnModalBoxCancel_MessageBoxCallback(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*private final function */void OnModalBoxPreSelecting()
	{
	
	}
	
	public virtual /*private final function */void OnCreatePersonaDone_MessageBoxCallback(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*private final function */void ShowModalBox(/*delegate*/TdOnlineLoginHandler.OnModalBoxOpened ModalBoxOpened, /*optional */UIScene.ESceneTransitionAnim SceneAnim = default)
	{
	
	}
	
	public virtual /*private final function */void ShowModalBox_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*function */void OnNotifyModalBoxCancel(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*private final function */void OnModalBoxFullyOpened(UIScene OpenedScene)
	{
	
	}
	
	public virtual /*private final function */void CloseModalBox(/*delegate*/TdOnlineLoginHandler.OnModalBoxClosed ModalBoxClosed)
	{
	
	}
	
	public virtual /*private final function */void ModalBoxAboutToDie()
	{
	
	}
	
}
}