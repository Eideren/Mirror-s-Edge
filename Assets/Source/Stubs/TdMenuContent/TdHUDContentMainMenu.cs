namespace MEdge.TdMenuContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHUDContentMainMenu : TdHUDContent{
	public TdHUDContentMainMenu()
	{
		// Object Offset:0x000012C8
		Scenes = new array<UIScene>
		{
			LoadAsset<TdUIScene_MiniMenu>("TdUI.TdMiniMenu")/*Ref TdUIScene_MiniMenu'TdUI.TdMiniMenu'*/,
			LoadAsset<TdUIScene_LoadIndicator>("TdUI.TdLoadIndicator")/*Ref TdUIScene_LoadIndicator'TdUI.TdLoadIndicator'*/,
			LoadAsset<TdUIScene_LoadIndicator>("TdUI.TdDiskAccessIndicator")/*Ref TdUIScene_LoadIndicator'TdUI.TdDiskAccessIndicator'*/,
			LoadAsset<TdUIScene_PauseOptions>("TdUI.TdPauseOptions")/*Ref TdUIScene_PauseOptions'TdUI.TdPauseOptions'*/,
			LoadAsset<TdUIScene_MessageBox>("TdUI.TdMessageBox")/*Ref TdUIScene_MessageBox'TdUI.TdMessageBox'*/,
			LoadAsset<TdUIScene_MessageBox>("TdUI.TdTinyMessageBox")/*Ref TdUIScene_MessageBox'TdUI.TdTinyMessageBox'*/,
			LoadAsset<TdUIScene_ImageMessageBox>("TdUI.TdImageMessageBox")/*Ref TdUIScene_ImageMessageBox'TdUI.TdImageMessageBox'*/,
			LoadAsset<TdUIScene_SupersMessage>("TdUI.TdSupersMessage")/*Ref TdUIScene_SupersMessage'TdUI.TdSupersMessage'*/,
			LoadAsset<TdUIScene_TdCredits>("TdUI.TdCredits")/*Ref TdUIScene_TdCredits'TdUI.TdCredits'*/,
			LoadAsset<TdUIScene_SplashHint>("TdUI_InGame.TdSplashHint")/*Ref TdUIScene_SplashHint'TdUI_InGame.TdSplashHint'*/,
			LoadAsset<TdUIScene_ControlsSettings>("TdUI_Options.TdControlsSettings")/*Ref TdUIScene_ControlsSettings'TdUI_Options.TdControlsSettings'*/,
			LoadAsset<TdUIScene_ControlsSettingsPC>("TdUI_Options.TdControlsSettingsPC")/*Ref TdUIScene_ControlsSettingsPC'TdUI_Options.TdControlsSettingsPC'*/,
			LoadAsset<TdUIScene_ControlsSettings>("TdUI_Options.TdControlsSettingsPS3")/*Ref TdUIScene_ControlsSettings'TdUI_Options.TdControlsSettingsPS3'*/,
			LoadAsset<TdUIScene_AudioSettings>("TdUI_Options.TdAudioSettings")/*Ref TdUIScene_AudioSettings'TdUI_Options.TdAudioSettings'*/,
			LoadAsset<TdUIScene_VideoSettings>("TdUI_Options.TdVideoSettings")/*Ref TdUIScene_VideoSettings'TdUI_Options.TdVideoSettings'*/,
			LoadAsset<TdUIScene_VideoSettingsPC>("TdUI_Options.TdVideoSettingsPC")/*Ref TdUIScene_VideoSettingsPC'TdUI_Options.TdVideoSettingsPC'*/,
			LoadAsset<TdUIScene_GameSettings>("TdUI_Options.TdGameSettings")/*Ref TdUIScene_GameSettings'TdUI_Options.TdGameSettings'*/,
			LoadAsset<TdUIScene_KeyMappings>("TdUI_Options.TdKeyMappings")/*Ref TdUIScene_KeyMappings'TdUI_Options.TdKeyMappings'*/,
			LoadAsset<TdUIScene_MainMenu>("TdUI_FrontEnd.TdMainMenu")/*Ref TdUIScene_MainMenu'TdUI_FrontEnd.TdMainMenu'*/,
			LoadAsset<TdUIScene_LoadCheckpoint>("TdUI_FrontEnd.TdLoadCheckpoint")/*Ref TdUIScene_LoadCheckpoint'TdUI_FrontEnd.TdLoadCheckpoint'*/,
			LoadAsset<TdUIScene_DifficultySettings>("TdUI_FrontEnd.TdDifficultySettings")/*Ref TdUIScene_DifficultySettings'TdUI_FrontEnd.TdDifficultySettings'*/,
			LoadAsset<TdUIScene_LoadLevel>("TdUI_FrontEnd.TdLoadLevel")/*Ref TdUIScene_LoadLevel'TdUI_FrontEnd.TdLoadLevel'*/,
			LoadAsset<TdUIScene_Unlocks>("TdUI_FrontEnd.TdUnlocks")/*Ref TdUIScene_Unlocks'TdUI_FrontEnd.TdUnlocks'*/,
			LoadAsset<TdUIScene_BigOverlayImage>("TdUI_FrontEnd.TdBigOverlayImage")/*Ref TdUIScene_BigOverlayImage'TdUI_FrontEnd.TdBigOverlayImage'*/,
			LoadAsset<TdUIScene_TimeTrial>("TdUI_FrontEnd_TimeTrial.TdTTSelectStretchOffline")/*Ref TdUIScene_TimeTrial'TdUI_FrontEnd_TimeTrial.TdTTSelectStretchOffline'*/,
			LoadAsset<TdUIScene_TimeTrial>("TdUI_FrontEnd_TimeTrial.TdTTSelectStretch")/*Ref TdUIScene_TimeTrial'TdUI_FrontEnd_TimeTrial.TdTTSelectStretch'*/,
			LoadAsset<TdUIScene_SPLevelRace>("TdUI_FrontEnd_LevelRace.TdLRSelectLevelOffline")/*Ref TdUIScene_SPLevelRace'TdUI_FrontEnd_LevelRace.TdLRSelectLevelOffline'*/,
			LoadAsset<TdUIScene_SPLevelRace>("TdUI_FrontEnd_LevelRace.TdLRSelectLevel")/*Ref TdUIScene_SPLevelRace'TdUI_FrontEnd_LevelRace.TdLRSelectLevel'*/,
			LoadAsset<TdUIScene_SPLeaderboard>("TdUI_FrontEnd_Online.TdSPLeaderboard")/*Ref TdUIScene_SPLeaderboard'TdUI_FrontEnd_Online.TdSPLeaderboard'*/,
			LoadAsset<TdUIScene_SPLeaderboard>("TdUI_FrontEnd_Online.TdSPLeaderboardPC")/*Ref TdUIScene_SPLeaderboard'TdUI_FrontEnd_Online.TdSPLeaderboardPC'*/,
			LoadAsset<TdUIScene_SendMessage>("TdUI_FrontEnd_Online.TdSendMessage")/*Ref TdUIScene_SendMessage'TdUI_FrontEnd_Online.TdSendMessage'*/,
			LoadAsset<TdUIScene_Friends>("TdUI_FrontEnd_Online.TdFriends")/*Ref TdUIScene_Friends'TdUI_FrontEnd_Online.TdFriends'*/,
			LoadAsset<TdUIScene_AccountLoginPC>("TdUI_FrontEnd_Online.TdAccountLoginPC")/*Ref TdUIScene_AccountLoginPC'TdUI_FrontEnd_Online.TdAccountLoginPC'*/,
			LoadAsset<TdUIScene_TOS>("TdUI_FrontEnd_Online.TdTOS")/*Ref TdUIScene_TOS'TdUI_FrontEnd_Online.TdTOS'*/,
			LoadAsset<TdUIScene_CreateAccountConsole>("TdUI_FrontEnd_Online.TdCreateAccountConsole")/*Ref TdUIScene_CreateAccountConsole'TdUI_FrontEnd_Online.TdCreateAccountConsole'*/,
			LoadAsset<TdUIScene_CreateAccountConfirm>("TdUI_FrontEnd_Online.TdCreateAccountConfirm")/*Ref TdUIScene_CreateAccountConfirm'TdUI_FrontEnd_Online.TdCreateAccountConfirm'*/,
			LoadAsset<TdUIScene_CreateAccountPC>("TdUI_FrontEnd_Online.TdCreateAccountPC")/*Ref TdUIScene_CreateAccountPC'TdUI_FrontEnd_Online.TdCreateAccountPC'*/,
			LoadAsset<TdUIScene_OnlineCheck>("TdUI_FrontEnd_Online.TdOnlineCheck")/*Ref TdUIScene_OnlineCheck'TdUI_FrontEnd_Online.TdOnlineCheck'*/,
			LoadAsset<TdUIScene_CreatePersona>("TdUI_FrontEnd_Online.TdCreatePersona")/*Ref TdUIScene_CreatePersona'TdUI_FrontEnd_Online.TdCreatePersona'*/,
			LoadAsset<TdUIScene_ParentalEmail>("TdUI_FrontEnd_Online.TdParentalEmail")/*Ref TdUIScene_ParentalEmail'TdUI_FrontEnd_Online.TdParentalEmail'*/,
		};
		SoundCues = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Sniper_BarretM95.Fire.Fire3P")/*Ref SoundCue'A_WP_Sniper_BarretM95.Fire.Fire3P'*/,
		};
	}
}
}