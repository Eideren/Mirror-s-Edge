namespace MEdge.TdTuContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdEditor;

public partial class TdHUDContentTutorial : TdHUDContent{
	public TdHUDContentTutorial()
	{
		// Object Offset:0x00001C98
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
			LoadAsset<TdUIScene_TutorialPause>("TdUI_InGame_Tutorial.TdTutorialPause")/*Ref TdUIScene_TutorialPause'TdUI_InGame_Tutorial.TdTutorialPause'*/,
			LoadAsset<TdUIScene_TutorialHUDMessage>("TdUI_InGame_Tutorial.TutorialMessage")/*Ref TdUIScene_TutorialHUDMessage'TdUI_InGame_Tutorial.TutorialMessage'*/,
			LoadAsset<TdUIScene_ChallengeObjectives>("TdUI_InGame_Tutorial.TdChallengeObjectives")/*Ref TdUIScene_ChallengeObjectives'TdUI_InGame_Tutorial.TdChallengeObjectives'*/,
		};
	}
}
}