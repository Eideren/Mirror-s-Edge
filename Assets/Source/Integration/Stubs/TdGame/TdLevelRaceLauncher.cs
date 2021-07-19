namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdLevelRaceLauncher : Object/* within TdUIScene*/{
	public new TdUIScene Outer => base.Outer as TdUIScene;
	
	public/*private*/ UIDataStore_TdTimeTrialData TimeTrialData;
	public/*private*/ TdUIScene_LoadIndicator LoadIndicator;
	public/*private*/ bool bDataReadCorrectly;
	public/*private*/ bool bStartOnlineMode;
	public/*private*/ String ErrorTitle;
	public/*private*/ String ErrorMessage;
	public/*private*/ int RaceModeId;
	[transient] public LocalPlayer PlayerOwner;
	public /*delegate*/TdLevelRaceLauncher.OnRaceLauncherFinished __OnRaceLauncherFinished__Delegate;
	
	public delegate void OnRaceLauncherFinished(int Result);
	
	public virtual /*function */void StartStretch(int InRaceModeId, bool bOnlineMode, LocalPlayer Player, /*delegate*/TdLevelRaceLauncher.OnRaceLauncherFinished OnFinish)
	{
		// stub
	}
	
	public virtual /*private final function */void OnStretchDataReadComplete(bool bSuccess)
	{
		// stub
	}
	
	public virtual /*private final function */void ShowLoadMessage()
	{
		// stub
	}
	
	public virtual /*private final function */void OnShowLoadingScene_Init(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void OnLoadMessageClosed(UIScene Scene)
	{
		// stub
	}
	
	public virtual /*private final function */void CloseLoadMessage()
	{
		// stub
	}
	
	public virtual /*private final function */void OnStartStretch()
	{
		// stub
	}
	
	public virtual /*private final function */void OnStartRaceErrorMessage_Init(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void OnStartRaceErrorMessagePreSelection(TdUIScene_MessageBox InMessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void OnLoadFailedQuitToMain(TdUIScene_MessageBox InMessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void SetErrorMessage(String Title, String Message)
	{
		// stub
	}
	
}
}