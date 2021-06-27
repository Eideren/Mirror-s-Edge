namespace MEdge.TdTTContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTuContent; using TdEditor;

public partial class TdHUDContentTimeTrial : TdHUDContent{
	public TdHUDContentTimeTrial()
	{
		// Object Offset:0x00005431
		Textures = new array<Texture2D>
		{
			LoadAsset<Texture2D>("TdUIResources_InGame_TimeTrial.CP_Bar_BOTTOM_Green")/*Ref Texture2D'TdUIResources_InGame_TimeTrial.CP_Bar_BOTTOM_Green'*/,
			LoadAsset<Texture2D>("TdUIResources_InGame_TimeTrial.CP_Bar_BOTTOM_Red")/*Ref Texture2D'TdUIResources_InGame_TimeTrial.CP_Bar_BOTTOM_Red'*/,
			LoadAsset<Texture2D>("TdUIResources_InGame_TimeTrial.CP_Bar_BOTTOM_White")/*Ref Texture2D'TdUIResources_InGame_TimeTrial.CP_Bar_BOTTOM_White'*/,
			LoadAsset<Texture2D>("TdUIResources_InGame_TimeTrial.CP_Bar_MIDDLE_Green")/*Ref Texture2D'TdUIResources_InGame_TimeTrial.CP_Bar_MIDDLE_Green'*/,
			LoadAsset<Texture2D>("TdUIResources_InGame_TimeTrial.CP_Bar_MIDDLE_Red")/*Ref Texture2D'TdUIResources_InGame_TimeTrial.CP_Bar_MIDDLE_Red'*/,
			LoadAsset<Texture2D>("TdUIResources_InGame_TimeTrial.CP_Bar_MIDDLE_White")/*Ref Texture2D'TdUIResources_InGame_TimeTrial.CP_Bar_MIDDLE_White'*/,
			LoadAsset<Texture2D>("TdUIResources_InGame_TimeTrial.CP_Bar_TOP_White")/*Ref Texture2D'TdUIResources_InGame_TimeTrial.CP_Bar_TOP_White'*/,
			LoadAsset<Texture2D>("TdUIResources_InGame_TimeTrial.CP_Bar_TOP_Red")/*Ref Texture2D'TdUIResources_InGame_TimeTrial.CP_Bar_TOP_Red'*/,
			LoadAsset<Texture2D>("TdUIResources_InGame_TimeTrial.CP_Bar_TOP_Green")/*Ref Texture2D'TdUIResources_InGame_TimeTrial.CP_Bar_TOP_Green'*/,
			LoadAsset<Texture2D>("TdUIResources_InGame_TimeTrial.StarSmall")/*Ref Texture2D'TdUIResources_InGame_TimeTrial.StarSmall'*/,
		};
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
			LoadAsset<TdUIScene_StartRace>("TdUI_InGame_TimeTrial.TdStartRace")/*Ref TdUIScene_StartRace'TdUI_InGame_TimeTrial.TdStartRace'*/,
			LoadAsset<TdUIScene_EndOfRace>("TdUI_InGame_TimeTrial.TdEndOfRace")/*Ref TdUIScene_EndOfRace'TdUI_InGame_TimeTrial.TdEndOfRace'*/,
			LoadAsset<TdUIScene_StarRating>("TdUI_InGame_TimeTrial.TdStarRating")/*Ref TdUIScene_StarRating'TdUI_InGame_TimeTrial.TdStarRating'*/,
			LoadAsset<TdUIScene_NewRecord>("TdUI_InGame_TimeTrial.TdNewRecord")/*Ref TdUIScene_NewRecord'TdUI_InGame_TimeTrial.TdNewRecord'*/,
			LoadAsset<TdUIScene_TimeTrialPause>("TdUI_InGame_TimeTrial.TdTimeTrialPause")/*Ref TdUIScene_TimeTrialPause'TdUI_InGame_TimeTrial.TdTimeTrialPause'*/,
		};
	}
}
}