namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdProfileSettings : OnlineProfileSettings/*
		native*/{
	public const int MAX_NUM_KEY_BINDS = 4;
	public const int TDPID_ControllerVibration = 250;
	public const int TDPID_YInversion = 251;
	public const int TDPID_GameDifficulty = 252;
	public const int TDPID_AutoAim = 253;
	public const int TDPID_MeasurementUnits = 255;
	public const int TDPID_FaithOVision = 256;
	public const int TDPID_Reticule = 257;
	public const int TDPID_MasterVolume = 300;
	public const int TDPID_MusicVolume = 302;
	public const int TDPID_DialogueVolume = 303;
	public const int TDPID_Brightness = 350;
	public const int TDPID_ScreenResX = 351;
	public const int TDPID_ScreenResY = 352;
	public const int TDPID_Contrast = 353;
	public const int TDPID_Sensitivity = 400;
	public const int TDPID_ControllerConfig = 401;
	public const int TDPID_ControllerTilt = 402;
	public const int TDPID_KeyAction_1 = 501;
	public const int TDPID_KeyAction_2 = 502;
	public const int TDPID_KeyAction_3 = 503;
	public const int TDPID_KeyAction_4 = 504;
	public const int TDPID_KeyAction_5 = 505;
	public const int TDPID_KeyAction_6 = 506;
	public const int TDPID_KeyAction_7 = 507;
	public const int TDPID_KeyAction_8 = 508;
	public const int TDPID_KeyAction_9 = 509;
	public const int TDPID_KeyAction_10 = 510;
	public const int TDPID_KeyAction_11 = 511;
	public const int TDPID_KeyAction_12 = 512;
	public const int TDPID_KeyAction_13 = 513;
	public const int TDPID_KeyAction_14 = 514;
	public const int TDPID_KeyAction_15 = 515;
	public const int TDPID_KeyAction_16 = 516;
	public const int TDPID_KeyAction_17 = 517;
	public const int TDPID_KeyAction_18 = 518;
	public const int TDPID_KeyAction_19 = 519;
	public const int TDPID_KeyAction_20 = 520;
	public const int TDPID_KeyAction_21 = 521;
	public const int TDPID_KeyAction_22 = 522;
	public const int TDPID_KeyAction_23 = 523;
	public const int TDPID_KeyAction_24 = 524;
	public const int TDPID_KeyAction_25 = 525;
	public const int TDPID_KeyAction_26 = 526;
	public const int TDPID_KeyAction_27 = 527;
	public const int TDPID_KeyAction_28 = 528;
	public const int TDPID_KeyAction_29 = 529;
	public const int TDPID_KeyAction_30 = 530;
	public const int TDPID_KeyAction_31 = 531;
	public const int TDPID_KeyAction_32 = 532;
	public const int TDPID_KeyAction_33 = 533;
	public const int TDPID_KeyAction_34 = 534;
	public const int TDPID_KeyAction_35 = 535;
	public const int TDPID_KeyAction_36 = 536;
	public const int TDPID_KeyAction_37 = 537;
	public const int TDPID_KeyAction_38 = 538;
	public const int TDPID_KeyAction_39 = 539;
	public const int TDPID_KeyAction_40 = 540;
	public const int TDPID_KeyAction_41 = 541;
	public const int TDPID_KeyAction_42 = 542;
	public const int TDPID_KeyAction_43 = 543;
	public const int TDPID_KeyAction_44 = 544;
	public const int TDPID_KeyAction_45 = 545;
	public const int TDPID_KeyAction_46 = 546;
	public const int TDPID_KeyAction_47 = 547;
	public const int TDPID_KeyAction_48 = 548;
	public const int TDPID_KeyAction_49 = 549;
	public const int TDPID_OnlineEncLogin = 700;
	public const int TDPID_OnlinePersona = 701;
	public const int TDPID_LastSavedMap = 900;
	public const int TDPID_LastSavedCheckpoint = 901;
	public const int TDPID_Level_NumHeavyLangings = 902;
	public const int TDPID_Level_NumTakeBulletDamage = 903;
	public const int TDPID_Level_NumBulletsFired = 904;
	public const int TDPID_Game_NumGiveBulletDamage = 905;
	public const int TDPID_Game_NumDisarms = 906;
	public const int TDPID_Game_NumMeleeKills = 907;
	public const int TDPID_Game_NumAirMeleeKills = 908;
	public const int TDPID_Subtitles = 1000;
	public const int TDPID_LevelUnlockMask = 1001;
	public const int TDPID_LevelUnlockMaskHard = 1002;
	public const int TDPID_ProRunner = 1003;
	public const int MAX_LEVELS = 10;
	public const int TDPID_HiddenBagMask = 1020;
	public const int MAX_BAGS = 30;
	public const int TDPID_TimeTrialUnlockMask = 1150;
	public const int TDPID_TimeTrialQualifierMask = 1151;
	public const int TDPID_TimeTrialRating = 1152;
	public const int TDPID_StretchTime_00 = 1200;
	public const int TDPID_StretchTime_01 = 1201;
	public const int TDPID_StretchTime_02 = 1202;
	public const int TDPID_StretchTime_03 = 1203;
	public const int TDPID_StretchTime_04 = 1204;
	public const int TDPID_StretchTime_05 = 1205;
	public const int TDPID_StretchTime_06 = 1206;
	public const int TDPID_StretchTime_07 = 1207;
	public const int TDPID_StretchTime_08 = 1208;
	public const int TDPID_StretchTime_09 = 1209;
	public const int TDPID_StretchTime_10 = 1210;
	public const int TDPID_StretchTime_11 = 1211;
	public const int TDPID_StretchTime_12 = 1212;
	public const int TDPID_StretchTime_13 = 1213;
	public const int TDPID_StretchTime_14 = 1214;
	public const int TDPID_StretchTime_15 = 1215;
	public const int TDPID_StretchTime_16 = 1216;
	public const int TDPID_StretchTime_17 = 1217;
	public const int TDPID_StretchTime_18 = 1218;
	public const int TDPID_StretchTime_19 = 1219;
	public const int TDPID_StretchTime_20 = 1220;
	public const int TDPID_StretchTime_21 = 1221;
	public const int TDPID_StretchTime_22 = 1222;
	public const int TDPID_StretchTime_23 = 1223;
	public const int TDPID_StretchTime_24 = 1224;
	public const int TDPID_StretchTime_25 = 1225;
	public const int TDPID_StretchTime_26 = 1226;
	public const int TDPID_StretchTime_27 = 1227;
	public const int TDPID_StretchTime_28 = 1228;
	public const int TDPID_StretchTime_29 = 1229;
	public const int TDPID_StretchTime_30 = 1230;
	public const int TDPID_StretchTime_31 = 1231;
	public const int TDPID_StretchTime_32 = 1232;
	public const int TDPID_StretchTime_33 = 1233;
	public const int TDPID_ViewedUnlocksFlags1 = 1260;
	public const int TDPID_ViewedUnlocksFlags2 = 1261;
	public const int TDPID_ViewedUnlocksFlags3 = 1262;
	public const int TDPID_ViewedUnlocksFlags4 = 1263;
	public const int TDPID_HintsShownFlags = 1300;
	
	public enum EControllerVibrationValues 
	{
		TdVibr_Off,
		TdVibr_On,
		TdVibr_MAX
	};
	
	public enum EYInversionValues 
	{
		TdYInvert_Normal,
		TdYInvert_Inverse,
		TdYInvert_MAX
	};
	
	public enum EDifficultySettingValue 
	{
		TdDiff_Easy,
		TdDiff_Normal,
		TdDiff_Hard,
		TdDiff_MAX
	};
	
	public enum EAutoAimValues 
	{
		TdAutoAim_Off,
		TdAutoAim_On,
		TdAutoAim_MAX
	};
	
	public enum EControllerConfigValues 
	{
		TdControllerConf_1,
		TdControllerConf_2,
		TdControllerConf_3,
		TdControllerConf_4,
		TdControllerConf_MAX
	};
	
	public enum EProfileControllerTiltValues 
	{
		TdTILT_Off,
		TdTILT_On,
		TdTILT_MAX
	};
	
	public enum ESubValues 
	{
		TdSub_Off,
		TdSub_On,
		TdSub_MAX
	};
	
	public enum EMeasurementUnitsValues 
	{
		TdMeasurementUnit_Metric,
		TdMeasurementUnit_Imperial,
		TdMeasurementUnit_MAX
	};
	
	public enum EFaithOVisionValues 
	{
		TdFaithOVision_Off,
		TdFaithOVision_Environment,
		TdFaithOVision_On,
		TdFaithOVision_MAX
	};
	
	public enum EReticuleValues 
	{
		TdReticule_Off,
		TdReticule_WeaponOnly,
		TdReticule_On,
		TdReticule_MAX
	};
	
	public enum EDigitalButtonActions 
	{
		DBA_None,
		DBA_MoveForward,
		DBA_MoveBackward,
		DBA_StrafeLeft,
		DBA_StrafeRight,
		DBA_TurnLeft,
		DBA_TurnRight,
		DBA_LookUp,
		DBA_LookDown,
		DBA_Pause,
		DBA_Move_Gamepad,
		DBA_Strafe_Gamepad,
		DBA_Turn_Gamepad,
		DBA_Look_Gamepad,
		DBA_Fire,
		DBA_Jump,
		DBA_Crouch,
		DBA_Use,
		DBA_InGameMenu,
		DBA_LookBehind,
		DBA_ReactionTime,
		DBA_SwitchWeapon,
		DBA_ZoomWeapon,
		DBA_LookAt,
		DBA_WalkMod,
		DBA_MAX
	};
	
	public enum ETDBindableKeys 
	{
		TDBND_Unbound,
		TDBND_MouseX,
		TDBND_MouseY,
		TDBND_MouseScrollUp,
		TDBND_MouseScrollDown,
		TDBND_LeftMouseButton,
		TDBND_RightMouseButton,
		TDBND_MiddleMouseButton,
		TDBND_ThumbMouseButton,
		TDBND_BackSpace,
		TDBND_Tab,
		TDBND_Enter,
		TDBND_Pause,
		TDBND_CapsLock,
		TDBND_Escape,
		TDBND_SpaceBar,
		TDBND_PageUp,
		TDBND_PageDown,
		TDBND_End,
		TDBND_Home,
		TDBND_Left,
		TDBND_Up,
		TDBND_Right,
		TDBND_Down,
		TDBND_Insert,
		TDBND_Delete,
		TDBND_Zero,
		TDBND_One,
		TDBND_Two,
		TDBND_Three,
		TDBND_Four,
		TDBND_Five,
		TDBND_Six,
		TDBND_Seven,
		TDBND_Eight,
		TDBND_Nine,
		TDBND_A,
		TDBND_B,
		TDBND_C,
		TDBND_D,
		TDBND_E,
		TDBND_F,
		TDBND_G,
		TDBND_H,
		TDBND_I,
		TDBND_J,
		TDBND_K,
		TDBND_L,
		TDBND_M,
		TDBND_N,
		TDBND_O,
		TDBND_P,
		TDBND_Q,
		TDBND_R,
		TDBND_S,
		TDBND_T,
		TDBND_U,
		TDBND_V,
		TDBND_W,
		TDBND_X,
		TDBND_Y,
		TDBND_Z,
		TDBND_NumPadZero,
		TDBND_NumPadOne,
		TDBND_NumPadTwo,
		TDBND_NumPadThree,
		TDBND_NumPadFour,
		TDBND_NumPadFive,
		TDBND_NumPadSix,
		TDBND_NumPadSeven,
		TDBND_NumPadEight,
		TDBND_NumPadNine,
		TDBND_Multiply,
		TDBND_Add,
		TDBND_Subtract,
		TDBND_Decimal,
		TDBND_Divide,
		TDBND_F1,
		TDBND_F2,
		TDBND_F3,
		TDBND_F4,
		TDBND_F5,
		TDBND_F6,
		TDBND_F7,
		TDBND_F8,
		TDBND_F9,
		TDBND_F10,
		TDBND_F11,
		TDBND_F12,
		TDBND_NumLock,
		TDBND_ScrollLock,
		TDBND_LeftShift,
		TDBND_RightShift,
		TDBND_LeftControl,
		TDBND_RightControl,
		TDBND_LeftAlt,
		TDBND_RightAlt,
		TDBND_Semicolon,
		TDBND_Equals,
		TDBND_Comma,
		TDBND_Underscore,
		TDBND_Period,
		TDBND_Slash,
		TDBND_Tilde,
		TDBND_LeftBracket,
		TDBND_Backslash,
		TDBND_RightBracket,
		TDBND_Quote,
		TDBND_MAX
	};
	
	public enum ETDGamepadKeys 
	{
		TDPAD_LeftX,
		TDPAD_LeftY,
		TDPAD_RightX,
		TDPAD_RightY,
		TDPAD_ButtonA,
		TDPAD_ButtonB,
		TDPAD_ButtonX,
		TDPAD_ButtonY,
		TDPAD_Start,
		TDPAD_Back,
		TDPAD_RightShoulder,
		TDPAD_LeftShoulder,
		TDPAD_RightTrigger,
		TDPAD_LeftTrigger,
		TDPAD_RightThumbstickPressed,
		TDPAD_LeftThumbstickPressed,
		TDPAD_DPadUp,
		TDPAD_DPadDown,
		TDPAD_DPadLeft,
		TDPAD_DPadRight,
		TDPAD_AccelX,
		TDPAD_AccelY,
		TDPAD_AccelZ,
		TDPAD_Gyro,
		TDPAD_MAX
	};
	
	public enum ETTDifficulty 
	{
		ETTD_Easy,
		ETTD_Medium,
		ETTD_Hard,
		ETTD_Expert,
		ETTD_All,
		ETTD_MAX
	};
	
	public partial struct /*native */TTUnLockCriteria
	{
		public TdSPTimeTrialGame.ETTStretch CompletedTT;
		public TdSPTimeTrialGame.ETTStretch UnlocksTT;
		public TdProfileSettings.ETTDifficulty Difficulty;
		public float QualifierTime;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00634D85
	//		CompletedTT = TdSPTimeTrialGame.ETTStretch.ETTS_None;
	//		UnlocksTT = TdSPTimeTrialGame.ETTStretch.ETTS_None;
	//		Difficulty = TdProfileSettings.ETTDifficulty.ETTD_Easy;
	//		QualifierTime = 0.0f;
	//	}
	};
	
	public array<string> DigitalButtonActionsToCommandMapping;
	public /*transient */array<name> KeyMappingArray;
	public /*transient */array<name> GamepadMappingArray;
	public /*transient */array<int> TTUnlockLevelCompletedMap;
	public /*transient */array<TdProfileSettings.TTUnLockCriteria> TTUnlockTTCompletedMap;
	
	public virtual /*function */void ResetIdsToDefault(array<int> ProfileIds)
	{
	
	}
	
	public virtual /*function */void ResetIdToDefault(int ProfileId)
	{
	
	}
	
	public virtual /*function */void SetHintShown(int HintId)
	{
	
	}
	
	public virtual /*event */bool IsHintShown(int HintId)
	{
	
		return default;
	}
	
	public virtual /*function */void SetUnlockViewed(int UnlockProfileId)
	{
	
	}
	
	public virtual /*event */bool IsUnlockViewed(int UnlockProfileId)
	{
	
		return default;
	}
	
	// Export UTdProfileSettings::execGetTTStretchTotalTimeOnly(FFrame&, void* const)
	public virtual /*native function */bool GetTTStretchTotalTimeOnly(int ProfileSettingId, ref float TotalTime)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdProfileSettings::execSetTTStretchTime(FFrame&, void* const)
	public virtual /*private native final function */bool SetTTStretchTime(int ProfileSettingId, float TotalTime, ref array<float> IntermediateTimes, float AverageSpeed, float DistanceRun)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdProfileSettings::execGetTTStretchTime(FFrame&, void* const)
	public virtual /*private native final function */bool GetTTStretchTime(int ProfileSettingId, ref float TotalTime, ref array<float> IntermediateTimes, ref float AverageSpeed, ref float DistanceRun)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */bool GetTotalTimeOnlyForStretch(int Stretch, ref float TotalTime)
	{
	
		return default;
	}
	
	public virtual /*function */bool GetTTTimeForStretch(int Stretch, ref float TotalTime, ref array<float> IntermediateTimes, ref float AverageSpeed, ref float DistanceRun)
	{
	
		return default;
	}
	
	public virtual /*function */bool SetTTTimeForStretch(int Stretch, float TotalTime, ref array<float> IntermediateTimes, float AverageSpeed, float DistanceRun)
	{
	
		return default;
	}
	
	public virtual /*function */int GetTimeTrialRating()
	{
	
		return default;
	}
	
	public virtual /*function */bool SetTimeTrialRating(int Value)
	{
	
		return default;
	}
	
	public virtual /*function */bool IsAllLevelsUnlocked(/*optional */bool bHardDifficulty = default)
	{
	
		return default;
	}
	
	public virtual /*function */bool IsLevelUnlocked(int LevelIndex, /*optional */bool bHardDifficulty = default)
	{
	
		return default;
	}
	
	public virtual /*function */bool UnlockLevel(int LevelIndex, /*optional */bool bHardDifficulty = default)
	{
	
		return default;
	}
	
	public virtual /*function */bool LockLevel(int LevelIndex, /*optional */bool bHardDifficulty = default)
	{
	
		return default;
	}
	
	public virtual /*function */bool LockAllLevels()
	{
	
		return default;
	}
	
	public virtual /*function */bool UnlockAllLevels()
	{
	
		return default;
	}
	
	public virtual /*function */bool IsHiddenBagFound(int BagIndex)
	{
	
		return default;
	}
	
	public virtual /*function */int NumBagsFoundTotal()
	{
	
		return default;
	}
	
	public virtual /*function */int NumBagsFoundForLevel(int LevelIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool IsAllBagsFound()
	{
	
		return default;
	}
	
	public virtual /*function */bool IsXBagsFound(TdStatsManager StatsManager)
	{
	
		return default;
	}
	
	public virtual /*function */bool SetTTStretchCompletedUnderQualifyerTime(int StretchIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool IsTTStretchCompletedUnderQualifyerTime(int StretchIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool IsTTStretchUnlocked(int StretchIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void LockAllTTStretches()
	{
	
	}
	
	public virtual /*function */void UnLockAllTTStretches()
	{
	
	}
	
	public virtual /*function */bool UnlockTTStretch(int StretchIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool LockTTStretch(int StretchIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool IsAllTTStretchesUnlocked()
	{
	
		return default;
	}
	
	public virtual /*function */bool IsAllTTStretchesCompletedUnderQualifierTime(int Difficulty)
	{
	
		return default;
	}
	
	public virtual /*function */void OnTTStretchCompleted(int TTStretch, float TotalTime, array<float> IntermediateTimes, float AverageSpeed, float DistanceRun, int UnlockIdx)
	{
	
	}
	
	public virtual /*function */void MarkCompletedUnderQualifyerTime(int CompletedTTStretch, float TotalTime)
	{
	
	}
	
	public virtual /*function */name CanUnlockTTStretch(int CompletedTTStretch, float TotalTime)
	{
	
		return default;
	}
	
	public virtual /*function */void OnLevelCompleted(int LevelIndex)
	{
	
	}
	
	public virtual /*function */bool GetProfileSettingValueIntByName(name SettingName, ref int OutValue)
	{
	
		return default;
	}
	
	public virtual /*function */bool GetProfileSettingValueFloatByName(name SettingName, ref float OutValue)
	{
	
		return default;
	}
	
	public virtual /*function */bool GetProfileSettingValueStringByName(name SettingName, ref string OutValue)
	{
	
		return default;
	}
	
	public virtual /*function */bool GetProfileSettingValueIdByName(name SettingName, ref int OutValue)
	{
	
		return default;
	}
	
	// Export UTdProfileSettings::execResetKeysToDefault(FFrame&, void* const)
	public /*native function */static void ResetKeysToDefault(/*optional */LocalPlayer InPlayerOwner = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdProfileSettings::execSetToDefaults(FFrame&, void* const)
	public override /*native event */void SetToDefaults()
	{
		#warning NATIVE FUNCTION !
	}
	
	public override /*event */void ScriptSetToDefaults()
	{
	
	}
	
	public virtual /*function */void StoreKeys(/*optional */PlayerInput PInput = default)
	{
	
	}
	
	public virtual /*function */void StoreKeyBindings(array<Input.KeyBind> Bindings)
	{
	
	}
	
	public virtual /*function */int GetProfileIDForDBA(TdProfileSettings.EDigitalButtonActions KeyAction)
	{
	
		return default;
	}
	
	public virtual /*function */int GetDBAFromCommand(string Command)
	{
	
		return default;
	}
	
	public virtual /*function */void GetKeyNamesFromDBA(TdProfileSettings.EDigitalButtonActions DBACommand, ref array<name> KeyNames, PlayerInput PInput)
	{
	
	}
	
	public virtual /*function */void SetKeyBindingUsingCommand(string KeyCommand, StaticArray<name, name, name, name>/*[4]*/ KeyBinds)
	{
	
	}
	
	public virtual /*function */name FindKeyName(TdProfileSettings.ETDBindableKeys KeyEnum)
	{
	
		return default;
	}
	
	public virtual /*function */int FindKeyEnum(name KeyName)
	{
	
		return default;
	}
	
	public virtual /*function */void SetKeyBinding(TdProfileSettings.EDigitalButtonActions KeyAction, StaticArray<name, name, name, name>/*[4]*/ KeyBinds)
	{
	
	}
	
	public virtual /*function */void UnbindKey(PlayerInput PInput, name BindName)
	{
	
	}
	
	public virtual /*function */void ApplyAllKeyBindings(PlayerInput PInput)
	{
	
	}
	
	public virtual /*function */void ApplyKeyBindings(PlayerInput PInput)
	{
	
	}
	
	public virtual /*function */void ApplyGamepadBindings(PlayerInput PInput, /*optional */array<Input.KeyBind> PresetMappings = default)
	{
	
	}
	
	public virtual /*function */array<Input.KeyBind> GetGamepadBinds()
	{
	
		return default;
	}
	
	public virtual /*function */array<Input.KeyBind> GetGamepadLayoutBinds(array<Input.KeyBind> GamepadBinds, TdProfileSettings.EControllerConfigValues Layout)
	{
	
		return default;
	}
	
	public virtual /*protected function */void InvertControllerConf_Sticks(ref array<Input.KeyBind> Binds)
	{
	
	}
	
	public virtual /*protected function */void InvertControllerConf_Buttons(ref array<Input.KeyBind> Binds)
	{
	
	}
	
	public virtual /*private final function */void InvertGamepadBinds(StaticArray<string, string, string, string>/*[4]*/ KeysToInvert, ref array<Input.KeyBind> Binds)
	{
	
	}
	
	public virtual /*function */void ApplyControllerBindings(PlayerInput PInput)
	{
	
	}
	
	public virtual /*function */void ApplyKeyBinding(PlayerInput PInput, TdProfileSettings.EDigitalButtonActions Action)
	{
	
	}
	
	public virtual /*function */void RemoveDBABindings(PlayerInput PInput)
	{
	
	}
	
	public virtual /*function */bool IsKeyBoundToCommand(PlayerInput PInput, string Command, string Key)
	{
	
		return default;
	}
	
	public virtual /*function */bool SetLastSavedMap(string MapName)
	{
	
		return default;
	}
	
	public virtual /*function */bool SetLastSavedCheckpoint(string CheckpointName)
	{
	
		return default;
	}
	
	public virtual /*function */bool GetLastSavedMap(ref string MapName)
	{
	
		return default;
	}
	
	public virtual /*function */bool GetLastSavedCheckpoint(ref string CheckpointName)
	{
	
		return default;
	}
	
	public override /*event */bool IsProfileSettingEnabled(name FieldName, int Index)
	{
	
		return default;
	}
	
	public TdProfileSettings()
	{
		// Object Offset:0x0063B771
		DigitalButtonActionsToCommandMapping = new array<string>
		{
			"GBA_None",
			"GBA_MoveForward",
			"GBA_MoveBackward",
			"GBA_StrafeLeft",
			"GBA_StrafeRight",
			"GBA_TurnLeft",
			"GBA_TurnRight",
			"GBA_LookUp",
			"GBA_LookDown",
			"GBA_Pause",
			"GBA_Move_Gamepad",
			"GBA_Strafe_Gamepad",
			"GBA_Turn_Gamepad",
			"GBA_Look_Gamepad",
			"GBA_Fire",
			"GBA_Jump",
			"GBA_Crouch",
			"GBA_Use",
			"GBA_InGameMenu",
			"GBA_LookBehind",
			"GBA_ReactionTime",
			"GBA_SwitchWeapon",
			"GBA_ZoomWeapon",
			"GBA_LookAt",
			"GBA_WalkMod",
		};
		KeyMappingArray = new array<name>
		{
			(name)"None",
			(name)"MouseX",
			(name)"MouseY",
			(name)"MouseScrollUp",
			(name)"MouseScrollDown",
			(name)"LeftMouseButton",
			(name)"RightMouseButton",
			(name)"MiddleMouseButton",
			(name)"ThumbMouseButton",
			(name)"BackSpace",
			(name)"TAB",
			(name)"Enter",
			(name)"Pause",
			(name)"CapsLock",
			(name)"Escape",
			(name)"SpaceBar",
			(name)"PageUp",
			(name)"PageDown",
			(name)"End",
			(name)"Home",
			(name)"Left",
			(name)"Up",
			(name)"Right",
			(name)"Down",
			(name)"Insert",
			(name)"Delete",
			(name)"ZERO",
			(name)"ONE",
			(name)"TWO",
			(name)"THREE",
			(name)"FOUR",
			(name)"FIVE",
			(name)"SIX",
			(name)"SEVEN",
			(name)"EIGHT",
			(name)"NINE",
			(name)"A",
			(name)"B",
			(name)"C",
			(name)"D",
			(name)"E",
			(name)"F",
			(name)"G",
			(name)"H",
			(name)"I",
			(name)"J",
			(name)"K",
			(name)"L",
			(name)"M",
			(name)"N",
			(name)"O",
			(name)"P",
			(name)"Q",
			(name)"R",
			(name)"S",
			(name)"T",
			(name)"U",
			(name)"V",
			(name)"W",
			(name)"X",
			(name)"Y",
			(name)"Z",
			(name)"NumPadZero",
			(name)"NumPadOne",
			(name)"NumPadTwo",
			(name)"NumPadThree",
			(name)"NumPadFour",
			(name)"NumPadFive",
			(name)"NumPadSix",
			(name)"NumPadSeven",
			(name)"NumPadEight",
			(name)"NumPadNine",
			(name)"None",
			(name)"None",
			(name)"None",
			(name)"None",
			(name)"None",
			(name)"F1",
			(name)"F2",
			(name)"F3",
			(name)"F4",
			(name)"F5",
			(name)"F6",
			(name)"F7",
			(name)"F8",
			(name)"F9",
			(name)"F10",
			(name)"F11",
			(name)"F12",
			(name)"NumLock",
			(name)"ScrollLock",
			(name)"LeftShift",
			(name)"RightShift",
			(name)"LeftControl",
			(name)"RightControl",
			(name)"LeftAlt",
			(name)"RightAlt",
		};
		GamepadMappingArray = new array<name>
		{
			(name)"XboxTypeS_LeftX",
			(name)"XboxTypeS_LeftY",
			(name)"XboxTypeS_RightX",
			(name)"XboxTypeS_RightY",
			(name)"XboxTypeS_A",
			(name)"XboxTypeS_B",
			(name)"XboxTypeS_X",
			(name)"XboxTypeS_Y",
			(name)"XboxTypeS_Start",
			(name)"XboxTypeS_Back",
			(name)"XboxTypeS_RightShoulder",
			(name)"XboxTypeS_LeftShoulder",
			(name)"XboxTypeS_RightTrigger",
			(name)"XboxTypeS_LeftTrigger",
			(name)"XboxTypeS_LeftThumbstick",
			(name)"XboxTypeS_RightThumbstick",
			(name)"XboxTypeS_DPad_Up",
			(name)"XboxTypeS_DPad_Down",
			(name)"XboxTypeS_DPad_Left",
			(name)"XboxTypeS_DPad_Right",
			(name)"SIXAXIS_AccelX",
			(name)"SIXAXIS_AccelY",
			(name)"SIXAXIS_AccelZ",
			(name)"SIXAXIS_Gyro",
		};
		TTUnlockLevelCompletedMap = new array<int>
		{
			15,
			4,
			23,
			6,
			1,
			2,
			14,
			17,
			24,
			12,
			18,
		};
		TTUnlockTTCompletedMap = new array<TdProfileSettings.TTUnLockCriteria>
		{
			new TdProfileSettings.TTUnLockCriteria
			{
				CompletedTT = TdSPTimeTrialGame.ETTStretch.ETTS_TutorialA01,
				UnlocksTT = TdSPTimeTrialGame.ETTStretch.ETTS_TutorialA02,
				Difficulty = TdProfileSettings.ETTDifficulty.ETTD_Medium,
				QualifierTime = 1000.0f,
			},
			new TdProfileSettings.TTUnLockCriteria
			{
				CompletedTT = TdSPTimeTrialGame.ETTStretch.ETTS_TutorialA02,
				UnlocksTT = TdSPTimeTrialGame.ETTStretch.ETTS_TutorialA03,
				Difficulty = TdProfileSettings.ETTDifficulty.ETTD_Hard,
				QualifierTime = 1000.0f,
			},
			new TdProfileSettings.TTUnLockCriteria
			{
				CompletedTT = TdSPTimeTrialGame.ETTStretch.ETTS_TutorialA03,
				UnlocksTT = TdSPTimeTrialGame.ETTStretch.ETTS_None,
				Difficulty = TdProfileSettings.ETTDifficulty.ETTD_Hard,
				QualifierTime = 1000.0f,
			},
			new TdProfileSettings.TTUnLockCriteria
			{
				CompletedTT = TdSPTimeTrialGame.ETTStretch.ETTS_EdgeA01,
				UnlocksTT = TdSPTimeTrialGame.ETTStretch.ETTS_None,
				Difficulty = TdProfileSettings.ETTDifficulty.ETTD_Easy,
				QualifierTime = 1000.0f,
			},
			new TdProfileSettings.TTUnLockCriteria
			{
				CompletedTT = TdSPTimeTrialGame.ETTStretch.ETTS_EscapeB01,
				UnlocksTT = TdSPTimeTrialGame.ETTStretch.ETTS_EscapeA01,
				Difficulty = TdProfileSettings.ETTDifficulty.ETTD_Medium,
				QualifierTime = 1000.0f,
			},
			new TdProfileSettings.TTUnLockCriteria
			{
				CompletedTT = TdSPTimeTrialGame.ETTStretch.ETTS_EscapeA01,
				UnlocksTT = TdSPTimeTrialGame.ETTStretch.ETTS_None,
				Difficulty = TdProfileSettings.ETTDifficulty.ETTD_Medium,
				QualifierTime = 1000.0f,
			},
			new TdProfileSettings.TTUnLockCriteria
			{
				CompletedTT = TdSPTimeTrialGame.ETTStretch.ETTS_StormdrainA02,
				UnlocksTT = TdSPTimeTrialGame.ETTStretch.ETTS_StormdrainB01,
				Difficulty = TdProfileSettings.ETTDifficulty.ETTD_Medium,
				QualifierTime = 1000.0f,
			},
			new TdProfileSettings.TTUnLockCriteria
			{
				CompletedTT = TdSPTimeTrialGame.ETTStretch.ETTS_StormdrainB01,
				UnlocksTT = TdSPTimeTrialGame.ETTStretch.ETTS_StormdrainB02,
				Difficulty = TdProfileSettings.ETTDifficulty.ETTD_Medium,
				QualifierTime = 1000.0f,
			},
			new TdProfileSettings.TTUnLockCriteria
			{
				CompletedTT = TdSPTimeTrialGame.ETTStretch.ETTS_StormdrainB02,
				UnlocksTT = TdSPTimeTrialGame.ETTStretch.ETTS_StormdrainB03,
				Difficulty = TdProfileSettings.ETTDifficulty.ETTD_Hard,
				QualifierTime = 1000.0f,
			},
			new TdProfileSettings.TTUnLockCriteria
			{
				CompletedTT = TdSPTimeTrialGame.ETTStretch.ETTS_StormdrainB03,
				UnlocksTT = TdSPTimeTrialGame.ETTStretch.ETTS_None,
				Difficulty = TdProfileSettings.ETTDifficulty.ETTD_Expert,
				QualifierTime = 1000.0f,
			},
			new TdProfileSettings.TTUnLockCriteria
			{
				CompletedTT = TdSPTimeTrialGame.ETTStretch.ETTS_CranesA01,
				UnlocksTT = TdSPTimeTrialGame.ETTStretch.ETTS_CranesC01,
				Difficulty = TdProfileSettings.ETTDifficulty.ETTD_Easy,
				QualifierTime = 1000.0f,
			},
			new TdProfileSettings.TTUnLockCriteria
			{
				CompletedTT = TdSPTimeTrialGame.ETTStretch.ETTS_CranesC01,
				UnlocksTT = TdSPTimeTrialGame.ETTStretch.ETTS_CranesB02,
				Difficulty = TdProfileSettings.ETTDifficulty.ETTD_Medium,
				QualifierTime = 1000.0f,
			},
			new TdProfileSettings.TTUnLockCriteria
			{
				CompletedTT = TdSPTimeTrialGame.ETTStretch.ETTS_CranesB02,
				UnlocksTT = TdSPTimeTrialGame.ETTStretch.ETTS_None,
				Difficulty = TdProfileSettings.ETTDifficulty.ETTD_Medium,
				QualifierTime = 1000.0f,
			},
			new TdProfileSettings.TTUnLockCriteria
			{
				CompletedTT = TdSPTimeTrialGame.ETTStretch.ETTS_CranesB01,
				UnlocksTT = TdSPTimeTrialGame.ETTStretch.ETTS_None,
				Difficulty = TdProfileSettings.ETTDifficulty.ETTD_Hard,
				QualifierTime = 1000.0f,
			},
			new TdProfileSettings.TTUnLockCriteria
			{
				CompletedTT = TdSPTimeTrialGame.ETTStretch.ETTS_MallA01,
				UnlocksTT = TdSPTimeTrialGame.ETTStretch.ETTS_None,
				Difficulty = TdProfileSettings.ETTDifficulty.ETTD_Medium,
				QualifierTime = 1000.0f,
			},
			new TdProfileSettings.TTUnLockCriteria
			{
				CompletedTT = TdSPTimeTrialGame.ETTStretch.ETTS_FactoryA01,
				UnlocksTT = TdSPTimeTrialGame.ETTStretch.ETTS_None,
				Difficulty = TdProfileSettings.ETTDifficulty.ETTD_Expert,
				QualifierTime = 1000.0f,
			},
			new TdProfileSettings.TTUnLockCriteria
			{
				CompletedTT = TdSPTimeTrialGame.ETTStretch.ETTS_CranesD01,
				UnlocksTT = TdSPTimeTrialGame.ETTStretch.ETTS_None,
				Difficulty = TdProfileSettings.ETTDifficulty.ETTD_Hard,
				QualifierTime = 1000.0f,
			},
			new TdProfileSettings.TTUnLockCriteria
			{
				CompletedTT = TdSPTimeTrialGame.ETTStretch.ETTS_ConvoyB01,
				UnlocksTT = TdSPTimeTrialGame.ETTStretch.ETTS_ConvoyB02,
				Difficulty = TdProfileSettings.ETTDifficulty.ETTD_Medium,
				QualifierTime = 1000.0f,
			},
			new TdProfileSettings.TTUnLockCriteria
			{
				CompletedTT = TdSPTimeTrialGame.ETTStretch.ETTS_ConvoyB02,
				UnlocksTT = TdSPTimeTrialGame.ETTStretch.ETTS_ConvoyA01,
				Difficulty = TdProfileSettings.ETTDifficulty.ETTD_Medium,
				QualifierTime = 1000.0f,
			},
			new TdProfileSettings.TTUnLockCriteria
			{
				CompletedTT = TdSPTimeTrialGame.ETTStretch.ETTS_ConvoyA01,
				UnlocksTT = TdSPTimeTrialGame.ETTStretch.ETTS_ConvoyA02,
				Difficulty = TdProfileSettings.ETTDifficulty.ETTD_Expert,
				QualifierTime = 1000.0f,
			},
			new TdProfileSettings.TTUnLockCriteria
			{
				CompletedTT = TdSPTimeTrialGame.ETTStretch.ETTS_ConvoyA02,
				UnlocksTT = TdSPTimeTrialGame.ETTStretch.ETTS_None,
				Difficulty = TdProfileSettings.ETTDifficulty.ETTD_Expert,
				QualifierTime = 1000.0f,
			},
			new TdProfileSettings.TTUnLockCriteria
			{
				CompletedTT = TdSPTimeTrialGame.ETTStretch.ETTS_SkyscraperA01,
				UnlocksTT = TdSPTimeTrialGame.ETTStretch.ETTS_SkyscraperB01,
				Difficulty = TdProfileSettings.ETTDifficulty.ETTD_Hard,
				QualifierTime = 1000.0f,
			},
			new TdProfileSettings.TTUnLockCriteria
			{
				CompletedTT = TdSPTimeTrialGame.ETTStretch.ETTS_SkyscraperB01,
				UnlocksTT = TdSPTimeTrialGame.ETTStretch.ETTS_None,
				Difficulty = TdProfileSettings.ETTDifficulty.ETTD_Hard,
				QualifierTime = 1000.0f,
			},
		};
		VersionNumber = 61;
		ProfileSettingIds = new array<int>
		{
			250,
			251,
			252,
			253,
			255,
			256,
			257,
			300,
			302,
			303,
			350,
			351,
			352,
			353,
			400,
			401,
			402,
			1000,
			501,
			502,
			503,
			504,
			505,
			506,
			507,
			508,
			509,
			510,
			511,
			512,
			513,
			514,
			515,
			516,
			517,
			518,
			519,
			520,
			521,
			522,
			523,
			524,
			525,
			526,
			527,
			528,
			529,
			530,
			531,
			532,
			533,
			534,
			535,
			536,
			537,
			538,
			539,
			540,
			541,
			542,
			543,
			544,
			545,
			546,
			547,
			548,
			549,
			700,
			701,
			900,
			901,
			1001,
			1002,
			1003,
			902,
			903,
			904,
			905,
			906,
			907,
			908,
			1020,
			1150,
			1151,
			1152,
			1200,
			1201,
			1202,
			1203,
			1204,
			1205,
			1206,
			1207,
			1208,
			1209,
			1210,
			1211,
			1212,
			1213,
			1214,
			1215,
			1216,
			1217,
			1218,
			1219,
			1220,
			1221,
			1222,
			1223,
			1224,
			1225,
			1226,
			1227,
			1228,
			1229,
			1230,
			1231,
			1232,
			1233,
			1260,
			1261,
			1262,
			1263,
			1300,
		};
		DefaultSettings = new array<OnlineProfileSettings.OnlineProfileSetting>
		{
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 250,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 1,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 251,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 252,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 1,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 253,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 1,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 255,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 256,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 2,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 257,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 2,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 300,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 10,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 302,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 5,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 303,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 8,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 350,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 5,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 351,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 1024,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 352,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 768,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 353,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 5,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 400,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 5,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 401,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 402,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 1,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 501,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 502,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 503,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 504,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 505,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 506,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 507,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 508,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 509,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 510,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 511,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 512,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 513,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 514,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 515,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 516,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 517,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 518,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 519,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 520,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 521,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 522,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 523,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 524,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 525,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 526,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 527,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 528,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 529,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 530,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 531,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 532,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 533,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 534,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 535,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 536,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 537,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 538,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 539,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 540,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 541,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 542,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 543,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 544,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 545,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 546,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 547,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 548,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 549,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 700,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_String,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 701,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_String,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 900,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_String,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 901,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_String,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1000,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1001,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1002,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1003,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 902,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 903,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 904,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 905,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 906,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 907,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 908,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1020,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1150,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1151,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1152,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1200,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1201,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1202,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1203,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1204,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1205,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1206,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1207,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1208,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1209,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1210,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1211,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1212,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1213,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1214,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1215,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1216,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1217,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1218,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1219,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1220,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1221,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1222,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1223,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1224,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1225,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1226,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1227,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1228,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1229,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1230,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1231,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1232,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1233,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Blob,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1260,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1261,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1262,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1263,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
			new OnlineProfileSettings.OnlineProfileSetting
			{
				Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_Game,
				ProfileSetting = new Settings.SettingsProperty
				{
					PropertyId = 1300,
					Data = new Settings.SettingsData
					{
						Type = Settings.ESettingsDataType.SDT_Int32,
						Value1 = 0,
					},
					AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
				},
			},
		};
		ProfileMappings = new array<Settings.SettingsPropertyPropertyMetaData>
		{
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 250,
				Name = (name)"ControllerVibration",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_IdMapped,
				ValueMappings = new array<Settings.IdToStringMapping>
				{
					new Settings.IdToStringMapping
					{
						Id = 0,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.Off>",
					},
					new Settings.IdToStringMapping
					{
						Id = 1,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.On>",
					},
				},
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 251,
				Name = (name)"InvertYAxis",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_IdMapped,
				ValueMappings = new array<Settings.IdToStringMapping>
				{
					new Settings.IdToStringMapping
					{
						Id = 0,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.Normal>",
					},
					new Settings.IdToStringMapping
					{
						Id = 1,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.Inverted>",
					},
				},
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 252,
				Name = (name)"GameDifficulty",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_IdMapped,
				ValueMappings = new array<Settings.IdToStringMapping>
				{
					new Settings.IdToStringMapping
					{
						Id = 0,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.Easy>",
					},
					new Settings.IdToStringMapping
					{
						Id = 1,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.Normal>",
					},
					new Settings.IdToStringMapping
					{
						Id = 2,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.Hard>",
					},
				},
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 253,
				Name = (name)"AutoAim",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_IdMapped,
				ValueMappings = new array<Settings.IdToStringMapping>
				{
					new Settings.IdToStringMapping
					{
						Id = 0,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.Off>",
					},
					new Settings.IdToStringMapping
					{
						Id = 1,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.On>",
					},
				},
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 255,
				Name = (name)"MeasurementUnits",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_IdMapped,
				ValueMappings = new array<Settings.IdToStringMapping>
				{
					new Settings.IdToStringMapping
					{
						Id = 0,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.Metric>",
					},
					new Settings.IdToStringMapping
					{
						Id = 1,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.Imperial>",
					},
				},
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 256,
				Name = (name)"FaithOVision",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_IdMapped,
				ValueMappings = new array<Settings.IdToStringMapping>
				{
					new Settings.IdToStringMapping
					{
						Id = 2,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.On>",
					},
					new Settings.IdToStringMapping
					{
						Id = 1,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.Environment>",
					},
					new Settings.IdToStringMapping
					{
						Id = 0,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.Off>",
					},
				},
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 257,
				Name = (name)"Reticule",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_IdMapped,
				ValueMappings = new array<Settings.IdToStringMapping>
				{
					new Settings.IdToStringMapping
					{
						Id = 0,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.Off>",
					},
					new Settings.IdToStringMapping
					{
						Id = 1,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.WeaponOnly>",
					},
					new Settings.IdToStringMapping
					{
						Id = 2,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.On>",
					},
				},
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 300,
				Name = (name)"MasterVolume",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 302,
				Name = (name)"MusicVolume",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 303,
				Name = (name)"DialogueVolume",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 350,
				Name = (name)"Brightness",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 351,
				Name = (name)"ScreenResolutionX",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 352,
				Name = (name)"ScreenResolutionY",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 353,
				Name = (name)"Contrast",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 400,
				Name = (name)"Sensitivity",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 401,
				Name = (name)"ControllerConfig",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_IdMapped,
				ValueMappings = new array<Settings.IdToStringMapping>
				{
					new Settings.IdToStringMapping
					{
						Id = 0,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.TypeA>",
					},
					new Settings.IdToStringMapping
					{
						Id = 1,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.TypeB>",
					},
					new Settings.IdToStringMapping
					{
						Id = 2,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.TypeC>",
					},
					new Settings.IdToStringMapping
					{
						Id = 3,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.TypeD>",
					},
				},
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 402,
				Name = (name)"ControllerTilt",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_IdMapped,
				ValueMappings = new array<Settings.IdToStringMapping>
				{
					new Settings.IdToStringMapping
					{
						Id = 1,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.On>",
					},
					new Settings.IdToStringMapping
					{
						Id = 0,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.Off>",
					},
				},
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1000,
				Name = (name)"GameSubtitles",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_IdMapped,
				ValueMappings = new array<Settings.IdToStringMapping>
				{
					new Settings.IdToStringMapping
					{
						Id = 0,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.Off>",
					},
					new Settings.IdToStringMapping
					{
						Id = 1,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.On>",
					},
				},
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 501,
				Name = (name)"KeyAction_1",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 502,
				Name = (name)"KeyAction_2",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 503,
				Name = (name)"KeyAction_3",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 504,
				Name = (name)"KeyAction_4",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 505,
				Name = (name)"KeyAction_5",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 506,
				Name = (name)"KeyAction_6",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 507,
				Name = (name)"KeyAction_7",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 508,
				Name = (name)"KeyAction_8",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 509,
				Name = (name)"KeyAction_9",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 510,
				Name = (name)"KeyAction_10",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 511,
				Name = (name)"KeyAction_11",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 512,
				Name = (name)"KeyAction_12",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 513,
				Name = (name)"KeyAction_13",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 514,
				Name = (name)"KeyAction_14",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 515,
				Name = (name)"KeyAction_15",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 516,
				Name = (name)"KeyAction_16",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 517,
				Name = (name)"KeyAction_17",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 518,
				Name = (name)"KeyAction_18",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 519,
				Name = (name)"KeyAction_19",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 520,
				Name = (name)"KeyAction_20",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 521,
				Name = (name)"KeyAction_21",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 522,
				Name = (name)"KeyAction_22",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 523,
				Name = (name)"KeyAction_23",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 524,
				Name = (name)"KeyAction_24",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 525,
				Name = (name)"KeyAction_25",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 526,
				Name = (name)"KeyAction_26",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 527,
				Name = (name)"KeyAction_27",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 528,
				Name = (name)"KeyAction_28",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 529,
				Name = (name)"KeyAction_29",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 530,
				Name = (name)"KeyAction_30",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 531,
				Name = (name)"KeyAction_31",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 532,
				Name = (name)"KeyAction_32",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 533,
				Name = (name)"KeyAction_33",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 534,
				Name = (name)"KeyAction_34",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 535,
				Name = (name)"KeyAction_35",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 536,
				Name = (name)"KeyAction_36",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 537,
				Name = (name)"KeyAction_37",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 538,
				Name = (name)"KeyAction_38",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 539,
				Name = (name)"KeyAction_39",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 540,
				Name = (name)"KeyAction_40",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 541,
				Name = (name)"KeyAction_41",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 542,
				Name = (name)"KeyAction_42",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 543,
				Name = (name)"KeyAction_43",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 544,
				Name = (name)"KeyAction_44",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 545,
				Name = (name)"KeyAction_45",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 546,
				Name = (name)"KeyAction_46",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 547,
				Name = (name)"KeyAction_47",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 548,
				Name = (name)"KeyAction_48",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 549,
				Name = (name)"KeyAction_49",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 900,
				Name = (name)"LastSavedMap",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 901,
				Name = (name)"LastSavedCheckpoint",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1001,
				Name = (name)"Level Unlocked Mask",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1002,
				Name = (name)"Level Unlocked Mask",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1003,
				Name = (name)"Possibility to get prorunner",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 902,
				Name = (name)"Number of heavy handings",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 903,
				Name = (name)"Number of times taken bullet damage",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 904,
				Name = (name)"Number of bullets fired",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 905,
				Name = (name)"Number of times given bullet damage",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 906,
				Name = (name)"Number of disarms",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 907,
				Name = (name)"Number of melee kills",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 908,
				Name = (name)"Number of melee air kills",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1020,
				Name = (name)"Hidden Bag Mask",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1150,
				Name = (name)"TimeTrialUnlockMask",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1151,
				Name = (name)"TimeTrialQualifierMask",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1152,
				Name = (name)"TimeTrialRating",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1200,
				Name = (name)"Personal Time for Stretch 00",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1201,
				Name = (name)"Personal Time for Stretch 01",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1202,
				Name = (name)"Personal Time for Stretch 02",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1203,
				Name = (name)"Personal Time for Stretch 03",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1204,
				Name = (name)"Personal Time for Stretch 04",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1205,
				Name = (name)"Personal Time for Stretch 05",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1206,
				Name = (name)"Personal Time for Stretch 06",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1207,
				Name = (name)"Personal Time for Stretch 07",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1208,
				Name = (name)"Personal Time for Stretch 08",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1209,
				Name = (name)"Personal Time for Stretch 09",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1210,
				Name = (name)"Personal Time for Stretch 10",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1211,
				Name = (name)"Personal Time for Stretch 11",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1212,
				Name = (name)"Personal Time for Stretch 12",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1213,
				Name = (name)"Personal Time for Stretch 13",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1214,
				Name = (name)"Personal Time for Stretch 14",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1215,
				Name = (name)"Personal Time for Stretch 15",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1216,
				Name = (name)"Personal Time for Stretch 16",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1217,
				Name = (name)"Personal Time for Stretch 17",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1218,
				Name = (name)"Personal Time for Stretch 18",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1219,
				Name = (name)"Personal Time for Stretch 19",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1220,
				Name = (name)"Personal Time for Stretch 20",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1221,
				Name = (name)"Personal Time for Stretch 21",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1222,
				Name = (name)"Personal Time for Stretch 22",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1223,
				Name = (name)"Personal Time for Stretch 23",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1224,
				Name = (name)"Personal Time for Stretch 24",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1225,
				Name = (name)"Personal Time for Stretch 25",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1226,
				Name = (name)"Personal Time for Stretch 26",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1227,
				Name = (name)"Personal Time for Stretch 27",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1228,
				Name = (name)"Personal Time for Stretch 28",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1229,
				Name = (name)"Personal Time for Stretch 29",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1230,
				Name = (name)"Personal Time for Stretch 30",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1231,
				Name = (name)"Personal Time for Stretch 31",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1232,
				Name = (name)"Personal Time for Stretch 32",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1233,
				Name = (name)"Personal Time for Stretch 33",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 700,
				Name = (name)"OnlineEncLogin",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 701,
				Name = (name)"OnlinePersona",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1260,
				Name = (name)"ViewedUnlocksFlags1",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1261,
				Name = (name)"ViewedUnlocksFlags2",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1262,
				Name = (name)"ViewedUnlocksFlags3",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1263,
				Name = (name)"ViewedUnlocksFlags4",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1300,
				Name = (name)"HintsShownFlags",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
		};
	}
}
}