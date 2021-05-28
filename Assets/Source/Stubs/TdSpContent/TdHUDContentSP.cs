namespace MEdge.TdSpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHUDContentSP : TdHUDContent{
	public TdHUDContentSP()
	{
		// Object Offset:0x0002235F
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
			LoadAsset<TdUIScene_SPPause>("TdUI_InGame.TdSPPause")/*Ref TdUIScene_SPPause'TdUI_InGame.TdSPPause'*/,
			LoadAsset<TdUIScene_GameObjectives>("TdUI_InGame.TdGameObjectives")/*Ref TdUIScene_GameObjectives'TdUI_InGame.TdGameObjectives'*/,
			LoadAsset<TdUIScene_SPLevelRacePause>("TdUI_InGame_LevelRace.SPLevelRacePause")/*Ref TdUIScene_SPLevelRacePause'TdUI_InGame_LevelRace.SPLevelRacePause'*/,
			LoadAsset<TdUIScene_EndOfLevelRace>("TdUI_InGame_LevelRace.TdEndOfLevelRace")/*Ref TdUIScene_EndOfLevelRace'TdUI_InGame_LevelRace.TdEndOfLevelRace'*/,
		};
	}
}
}