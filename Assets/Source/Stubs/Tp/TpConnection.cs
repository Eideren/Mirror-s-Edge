namespace MEdge.Tp{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TpConnection : TpSystemHandler/*
		abstract
		transient
		native*/{
	public enum TpConnectionError 
	{
		kTpCe_Ok,
		kTpCe_ConnectionFailed,
		kTpCe_SocketCreateFailed,
		kTpCe_NameLookupFailed,
		kTpCe_ServerForcedLogoff,
		kTpCe_Disconnected,
		kTpCe_ActivityTimeout,
		kTpCe_MemoryAuthFailed,
		kTpCe_Banned,
		kTpCe_CommunicatorInitFailed,
		kTpCe_GameBrowserInitFailed,
		kTpCe_ClubManagerInitFailed,
		kTpCe_AchievementInitFailed,
		kTpCe_AssociationInitFailed,
		kTpCe_SilentLoginFailed,
		kTpCe_OnlineRestricted,
		kTpCe_MinPingSiteCheckFailed,
		kTpCe_XblNotAvailable,
		kTpCe_XblInviteUserNotFound,
		kTpCe_XblNoValidProfile,
		kTpCe_XblServiceBusy,
		kTpCe_XblUpdateRequired,
		kTpCe_Ps3npNotAvailable,
		kTpCe_Ps3NoNetworkConnection,
		kTpCe_Ps3npStartFailed,
		kTpCe_Unknown,
		kTpCe_MAX
	};
	
	public partial struct /*native */TpCreateAccountParams
	{
		public string Name;
		public string Password;
		public int BirthYear;
		public int BirthMonth;
		public int BirthDay;
		public string ZipCode;
		public string IsoCountry;
		public string ParentalEmail;
		public bool bAllowEaEmail;
		public bool bAllowThirdPartyEmail;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0003A5F1
	//		Name = "";
	//		Password = "";
	//		BirthYear = 0;
	//		BirthMonth = 0;
	//		BirthDay = 0;
	//		ZipCode = "";
	//		IsoCountry = "";
	//		ParentalEmail = "";
	//		bAllowEaEmail = false;
	//		bAllowThirdPartyEmail = false;
	//	}
	};
	
	public partial struct /*native */TpCreateAccountCountry
	{
		public /*init */string Description;
		public /*init */string ISOCode;
		public int ParentalControlAgeLimit;
		public int RegistrationAgeLimit;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0003A7F1
	//		Description = "";
	//		ISOCode = "";
	//		ParentalControlAgeLimit = 0;
	//		RegistrationAgeLimit = 0;
	//	}
	};
	
	public /*private transient */bool bLanGame;
	public /*private transient */byte ActiveControllerId;
	public /*delegate*/TpConnection.OnConnectionFailed __OnConnectionFailed__Delegate;
	public /*delegate*/TpConnection.OnConnectionReady __OnConnectionReady__Delegate;
	public /*delegate*/TpConnection.OnLoginReady __OnLoginReady__Delegate;
	public /*delegate*/TpConnection.OnConnectionChange __OnConnectionChange__Delegate;
	public /*delegate*/TpConnection.OnPartiallyLoggedIn __OnPartiallyLoggedIn__Delegate;
	public /*delegate*/TpConnection.OnLoginAccountError __OnLoginAccountError__Delegate;
	public /*delegate*/TpConnection.OnLoginPersonaError __OnLoginPersonaError__Delegate;
	public /*delegate*/TpConnection.OnCreateAccountReady __OnCreateAccountReady__Delegate;
	public /*delegate*/TpConnection.OnCreateAccountError __OnCreateAccountError__Delegate;
	public /*delegate*/TpConnection.OnDisplayCountrySelect __OnDisplayCountrySelect__Delegate;
	public /*delegate*/TpConnection.OnGetTOS __OnGetTOS__Delegate;
	public /*delegate*/TpConnection.OnDisplayPersonas __OnDisplayPersonas__Delegate;
	public /*delegate*/TpConnection.OnCreatePersonaError __OnCreatePersonaError__Delegate;
	public /*delegate*/TpConnection.OnDisconnect __OnDisconnect__Delegate;
	public /*delegate*/TpConnection.OnDisplayConfirmMessage __OnDisplayConfirmMessage__Delegate;
	public /*delegate*/TpConnection.OnDisplayParentalEmail __OnDisplayParentalEmail__Delegate;
	
	// Export UTpConnection::execConnectAsync(FFrame&, void* const)
	public virtual /*native simulated function */void ConnectAsync()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTpConnection::execConnectSilentAsync(FFrame&, void* const)
	public virtual /*native simulated function */void ConnectSilentAsync(/*optional */string? _EncLogin = default, /*optional */string? _Persona = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	public delegate void OnConnectionFailed(TpConnection.TpConnectionError InError);
	
	public delegate void OnConnectionReady(string EncLogin, string Persona);
	
	public delegate void OnLoginReady();
	
	public delegate void OnConnectionChange(bool bConnected);
	
	// Export UTpConnection::execLoginAccountAsync(FFrame&, void* const)
	public virtual /*native simulated function */void LoginAccountAsync(string InName, string InPasswd)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTpConnection::execLoginEncAccountAsync(FFrame&, void* const)
	public virtual /*native simulated function */void LoginEncAccountAsync(string EncLogin)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTpConnection::execLoginPersonaAsync(FFrame&, void* const)
	public virtual /*native simulated function */void LoginPersonaAsync(string InName)
	{
		#warning NATIVE FUNCTION !
	}
	
	public delegate void OnPartiallyLoggedIn(array<string> InSubNames);
	
	public delegate void OnLoginAccountError(TpAccount.TpAccountError InError);
	
	public delegate void OnLoginPersonaError(int ErrorCode);
	
	// Export UTpConnection::execPrepareCreateAccountAsync(FFrame&, void* const)
	public virtual /*native simulated function */void PrepareCreateAccountAsync()
	{
		#warning NATIVE FUNCTION !
	}
	
	public delegate void OnCreateAccountReady(string Email, string Pass, bool bAllowEaEmail, bool bAllowTPEmail, bool bIsConsole);
	
	// Export UTpConnection::execCreateAccountAsync(FFrame&, void* const)
	public virtual /*native simulated function */bool CreateAccountAsync(TpConnection.TpCreateAccountParams InParams)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTpConnection::execCreateAccountConsoleAsync(FFrame&, void* const)
	public virtual /*native simulated function */void CreateAccountConsoleAsync(string Email, string Pass, bool bAllowEaEmail, bool bAllowThirdPartyEmail)
	{
		#warning NATIVE FUNCTION !
	}
	
	public delegate void OnCreateAccountError(TpAccount.TpAccountError InError);
	
	public delegate void OnDisplayCountrySelect(array<TpConnection.TpCreateAccountCountry> Countries);
	
	// Export UTpConnection::execCreateAccountGetTOSAsync(FFrame&, void* const)
	public virtual /*native simulated function */void CreateAccountGetTOSAsync(string ISOCode)
	{
		#warning NATIVE FUNCTION !
	}
	
	public delegate void OnGetTOS(string TOSText);
	
	// Export UTpConnection::execCreateAccountAcceptTOSAsync(FFrame&, void* const)
	public virtual /*native simulated function */void CreateAccountAcceptTOSAsync(bool Accept)
	{
		#warning NATIVE FUNCTION !
	}
	
	public delegate void OnDisplayPersonas(array<string> Personas);
	
	// Export UTpConnection::execCreatePersonaAsync(FFrame&, void* const)
	public virtual /*native simulated function */void CreatePersonaAsync(string Persona)
	{
		#warning NATIVE FUNCTION !
	}
	
	public delegate void OnCreatePersonaError(int ErrorCode);
	
	// Export UTpConnection::execDisconnectAsync(FFrame&, void* const)
	public virtual /*native simulated function */void DisconnectAsync()
	{
		#warning NATIVE FUNCTION !
	}
	
	public delegate void OnDisconnect();
	
	// Export UTpConnection::execConfirmMessage(FFrame&, void* const)
	public virtual /*native simulated function */void ConfirmMessage()
	{
		#warning NATIVE FUNCTION !
	}
	
	public delegate void OnDisplayConfirmMessage(string Message);
	
	// Export UTpConnection::execConfirmParentalEmail(FFrame&, void* const)
	public virtual /*native simulated function */void ConfirmParentalEmail(string Email)
	{
		#warning NATIVE FUNCTION !
	}
	
	public delegate void OnDisplayParentalEmail();
	
	// Export UTpConnection::execRepromptDisplay(FFrame&, void* const)
	public virtual /*native simulated function */void RepromptDisplay()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTpConnection::execSetActiveControllerId(FFrame&, void* const)
	public virtual /*native simulated function */void SetActiveControllerId(byte LocalUserNum)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTpConnection::execIsAuthenticated(FFrame&, void* const)
	public virtual /*native simulated function */bool IsAuthenticated()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*final simulated function */bool IsLanGame()
	{
	
		return default;
	}
	
	// Export UTpConnection::execIsConnected(FFrame&, void* const)
	public virtual /*native simulated function */bool IsConnected()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTpConnection::execIsLoggedIn(FFrame&, void* const)
	public virtual /*native simulated function */bool IsLoggedIn()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
}
}