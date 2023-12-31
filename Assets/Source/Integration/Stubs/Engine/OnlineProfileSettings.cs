namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class OnlineProfileSettings : Object/*
		native*/{
	public enum EOnlineProfilePropertyOwner 
	{
		OPPO_None,
		OPPO_OnlineService,
		OPPO_Game,
		OPPO_MAX
	};
	
	public enum EProfileSettingID 
	{
		PSI_Unknown,
		PSI_ControllerVibration,
		PSI_YInversion,
		PSI_GamerCred,
		PSI_GamerRep,
		PSI_VoiceMuted,
		PSI_VoiceThruSpeakers,
		PSI_VoiceVolume,
		PSI_GamerPictureKey,
		PSI_GamerMotto,
		PSI_GamerTitlesPlayed,
		PSI_GamerAchievementsEarned,
		PSI_GameDifficulty,
		PSI_ControllerSensitivity,
		PSI_PreferredColor1,
		PSI_PreferredColor2,
		PSI_AutoAim,
		PSI_AutoCenter,
		PSI_MovementControl,
		PSI_RaceTransmission,
		PSI_RaceCameraLocation,
		PSI_RaceBrakeControl,
		PSI_RaceAcceleratorControl,
		PSI_GameCredEarned,
		PSI_GameAchievementsEarned,
		PSI_EndLiveIds,
		PSI_ProfileVersionNum,
		PSI_ProfileSaveCount,
		PSI_MAX
	};
	
	public enum EOnlineProfileAsyncState 
	{
		OPAS_None,
		OPAS_Read,
		OPAS_Write,
		OPAS_MAX
	};
	
	public enum EProfileDifficultyOptions 
	{
		PDO_Normal,
		PDO_Easy,
		PDO_Hard,
		PDO_MAX
	};
	
	public enum EProfileControllerSensitivityOptions 
	{
		PCSO_Medium,
		PCSO_Low,
		PCSO_High,
		PCSO_MAX
	};
	
	public enum EProfilePreferredColorOptions 
	{
		PPCO_None,
		PPCO_Black,
		PPCO_White,
		PPCO_Yellow,
		PPCO_Orange,
		PPCO_Pink,
		PPCO_Red,
		PPCO_Purple,
		PPCO_Blue,
		PPCO_Green,
		PPCO_Brown,
		PPCO_Silver,
		PPCO_MAX
	};
	
	public enum EProfileAutoAimOptions 
	{
		PAAO_Off,
		PAAO_On,
		PAAO_MAX
	};
	
	public enum EProfileAutoCenterOptions 
	{
		PACO_Off,
		PACO_On,
		PACO_MAX
	};
	
	public enum EProfileMovementControlOptions 
	{
		PMCO_L_Thumbstick,
		PMCO_R_Thumbstick,
		PMCO_MAX
	};
	
	public enum EProfileRaceTransmissionOptions 
	{
		PRTO_Auto,
		PRTO_Manual,
		PRTO_MAX
	};
	
	public enum EProfileRaceCameraLocationOptions 
	{
		PRCLO_Behind,
		PRCLO_Front,
		PRCLO_Inside,
		PRCLO_MAX
	};
	
	public enum EProfileRaceBrakeControlOptions 
	{
		PRBCO_Trigger,
		PRBCO_Button,
		PRBCO_MAX
	};
	
	public enum EProfileRaceAcceleratorControlOptions 
	{
		PRACO_Trigger,
		PRACO_Button,
		PRACO_MAX
	};
	
	public enum EProfileYInversionOptions 
	{
		PYIO_Off,
		PYIO_On,
		PYIO_MAX
	};
	
	public enum EProfileXInversionOptions 
	{
		PXIO_Off,
		PXIO_On,
		PXIO_MAX
	};
	
	public enum EProfileControllerVibrationToggleOptions 
	{
		PCVTO_Off,
		PCVTO_IgnoreThis,
		PCVTO_IgnoreThis2,
		PCVTO_On,
		PCVTO_MAX
	};
	
	public enum EProfileVoiceThruSpeakersOptions 
	{
		PVTSO_Off,
		PVTSO_On,
		PVTSO_Both,
		PVTSO_MAX
	};
	
	public partial struct /*native */OnlineProfileSetting
	{
		public OnlineProfileSettings.EOnlineProfilePropertyOwner Owner;
		public Settings.SettingsProperty ProfileSetting;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0036F1D9
	//		Owner = OnlineProfileSettings.EOnlineProfilePropertyOwner.OPPO_None;
	//		ProfileSetting = new Settings.SettingsProperty
	//		{
	//			PropertyId = 0,
	//			Data = new Settings.SettingsData
	//			{
	//				Type = Settings.ESettingsDataType.SDT_Empty,
	//				Value1 = 0,
	//			},
	//			AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
	//		};
	//	}
	};
	
	[Const] public int VersionNumber;
	public array<int> ProfileSettingIds;
	public array<OnlineProfileSettings.OnlineProfileSetting> ProfileSettings;
	public array<OnlineProfileSettings.OnlineProfileSetting> DefaultSettings;
	[Const] public array<Settings.IdToStringMapping> OwnerMappings;
	public array<Settings.SettingsPropertyPropertyMetaData> ProfileMappings;
	[Const] public OnlineProfileSettings.EOnlineProfileAsyncState AsyncState;
	
	// Export UOnlineProfileSettings::execGetProfileSettingId(FFrame&, void* const)
	public virtual /*native function */bool GetProfileSettingId(name ProfileSettingName, ref int ProfileSettingId)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UOnlineProfileSettings::execGetProfileSettingName(FFrame&, void* const)
	public virtual /*native function */name GetProfileSettingName(int ProfileSettingId)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UOnlineProfileSettings::execGetProfileSettingColumnHeader(FFrame&, void* const)
	public virtual /*native function */String GetProfileSettingColumnHeader(int ProfileSettingId)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UOnlineProfileSettings::execIsProfileSettingIdMapped(FFrame&, void* const)
	public virtual /*native function */bool IsProfileSettingIdMapped(int ProfileSettingId)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UOnlineProfileSettings::execGetProfileSettingValue(FFrame&, void* const)
	public virtual /*native function */bool GetProfileSettingValue(int ProfileSettingId, ref String Value)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UOnlineProfileSettings::execGetProfileSettingValueName(FFrame&, void* const)
	public virtual /*native function */name GetProfileSettingValueName(int ProfileSettingId)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UOnlineProfileSettings::execGetProfileSettingValues(FFrame&, void* const)
	public virtual /*native function */bool GetProfileSettingValues(int ProfileSettingId, ref array<name> Values)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UOnlineProfileSettings::execGetProfileSettingValueByName(FFrame&, void* const)
	public virtual /*native function */bool GetProfileSettingValueByName(name ProfileSettingName, ref String Value)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UOnlineProfileSettings::execSetProfileSettingValueByName(FFrame&, void* const)
	public virtual /*native function */bool SetProfileSettingValueByName(name ProfileSettingName, /*const */ref String NewValue)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UOnlineProfileSettings::execSetProfileSettingValue(FFrame&, void* const)
	public virtual /*native function */bool SetProfileSettingValue(int ProfileSettingId, /*const */ref String NewValue)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UOnlineProfileSettings::execGetProfileSettingValueId(FFrame&, void* const)
	public virtual /*native function */bool GetProfileSettingValueId(int ProfileSettingId, ref int ValueId)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UOnlineProfileSettings::execGetProfileSettingValueInt(FFrame&, void* const)
	public virtual /*native function */bool GetProfileSettingValueInt(int ProfileSettingId, ref int Value)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UOnlineProfileSettings::execGetProfileSettingValueFloat(FFrame&, void* const)
	public virtual /*native function */bool GetProfileSettingValueFloat(int ProfileSettingId, ref float Value)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UOnlineProfileSettings::execSetProfileSettingValueId(FFrame&, void* const)
	public virtual /*native function */bool SetProfileSettingValueId(int ProfileSettingId, int Value)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UOnlineProfileSettings::execSetProfileSettingValueInt(FFrame&, void* const)
	public virtual /*native function */bool SetProfileSettingValueInt(int ProfileSettingId, int Value)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UOnlineProfileSettings::execSetProfileSettingValueFloat(FFrame&, void* const)
	public virtual /*native function */bool SetProfileSettingValueFloat(int ProfileSettingId, float Value)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UOnlineProfileSettings::execSetToDefaults(FFrame&, void* const)
	public virtual /*native event */void SetToDefaults()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public virtual /*event */void ScriptSetToDefaults()
	{
		// stub
	}
	
	// Export UOnlineProfileSettings::execAppendVersionToReadIds(FFrame&, void* const)
	public virtual /*native function */void AppendVersionToReadIds()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UOnlineProfileSettings::execAppendVersionToSettings(FFrame&, void* const)
	public virtual /*native function */void AppendVersionToSettings()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UOnlineProfileSettings::execGetVersionNumber(FFrame&, void* const)
	public virtual /*native function */int GetVersionNumber()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UOnlineProfileSettings::execSetDefaultVersionNumber(FFrame&, void* const)
	public virtual /*native function */void SetDefaultVersionNumber()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UOnlineProfileSettings::execGetProfileSettingMappingType(FFrame&, void* const)
	public virtual /*native function */bool GetProfileSettingMappingType(int ProfileId, ref Settings.EPropertyValueMappingType OutType)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UOnlineProfileSettings::execGetProfileSettingRange(FFrame&, void* const)
	public virtual /*native function */bool GetProfileSettingRange(int ProfileId, ref float OutMinValue, ref float OutMaxValue, ref float RangeIncrement, ref byte bFormatAsInt)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UOnlineProfileSettings::execSetRangedProfileSettingValue(FFrame&, void* const)
	public virtual /*native function */bool SetRangedProfileSettingValue(int ProfileId, float NewValue)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UOnlineProfileSettings::execGetRangedProfileSettingValue(FFrame&, void* const)
	public virtual /*native function */bool GetRangedProfileSettingValue(int ProfileId, ref float OutValue)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*event */bool IsProfileSettingEnabled(name FieldName, int Index)
	{
		// stub
		return default;
	}
	
	public OnlineProfileSettings()
	{
		// Object Offset:0x00370AE3
		VersionNumber = -1;
		OwnerMappings = new array<Settings.IdToStringMapping>
		{
			new Settings.IdToStringMapping
			{
				Id = 0,
				Name = (name)"None",
			},
			new Settings.IdToStringMapping
			{
				Id = 1,
				Name = (name)"Online Service Setting",
			},
			new Settings.IdToStringMapping
			{
				Id = 2,
				Name = (name)"Game Setting",
			},
		};
		ProfileMappings = new array<Settings.SettingsPropertyPropertyMetaData>
		{
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 1,
				Name = (name)"Controller Vibration",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_IdMapped,
				ValueMappings = new array<Settings.IdToStringMapping>
				{
					new Settings.IdToStringMapping
					{
						Id = 0,
						Name = (name)"Off",
					},
					new Settings.IdToStringMapping
					{
						Id = 3,
						Name = (name)"On",
					},
				},
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 2,
				Name = (name)"Invert Y",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_IdMapped,
				ValueMappings = new array<Settings.IdToStringMapping>
				{
					new Settings.IdToStringMapping
					{
						Id = 0,
						Name = (name)"Off",
					},
					new Settings.IdToStringMapping
					{
						Id = 1,
						Name = (name)"On",
					},
				},
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 5,
				Name = (name)"Mute Voice",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_IdMapped,
				ValueMappings = new array<Settings.IdToStringMapping>
				{
					new Settings.IdToStringMapping
					{
						Id = 0,
						Name = (name)"No",
					},
					new Settings.IdToStringMapping
					{
						Id = 1,
						Name = (name)"Yes",
					},
				},
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 6,
				Name = (name)"Voice Via Speakers",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_IdMapped,
				ValueMappings = new array<Settings.IdToStringMapping>
				{
					new Settings.IdToStringMapping
					{
						Id = 0,
						Name = (name)"Off",
					},
					new Settings.IdToStringMapping
					{
						Id = 1,
						Name = (name)"On",
					},
					new Settings.IdToStringMapping
					{
						Id = 2,
						Name = (name)"Both",
					},
				},
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 7,
				Name = (name)"Voice Volume",
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
				Id = 12,
				Name = (name)"Difficulty Level",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_IdMapped,
				ValueMappings = new array<Settings.IdToStringMapping>
				{
					new Settings.IdToStringMapping
					{
						Id = 0,
						Name = (name)"Normal",
					},
					new Settings.IdToStringMapping
					{
						Id = 1,
						Name = (name)"Easy",
					},
					new Settings.IdToStringMapping
					{
						Id = 2,
						Name = (name)"Hard",
					},
				},
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 13,
				Name = (name)"Controller Sensitivity",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_IdMapped,
				ValueMappings = new array<Settings.IdToStringMapping>
				{
					new Settings.IdToStringMapping
					{
						Id = 0,
						Name = (name)"Medium",
					},
					new Settings.IdToStringMapping
					{
						Id = 1,
						Name = (name)"Low",
					},
					new Settings.IdToStringMapping
					{
						Id = 2,
						Name = (name)"High",
					},
				},
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 14,
				Name = (name)"First Preferred Color",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_IdMapped,
				ValueMappings = new array<Settings.IdToStringMapping>
				{
					new Settings.IdToStringMapping
					{
						Id = 0,
						Name = (name)"None",
					},
					new Settings.IdToStringMapping
					{
						Id = 1,
						Name = (name)"Black",
					},
					new Settings.IdToStringMapping
					{
						Id = 2,
						Name = (name)"White",
					},
					new Settings.IdToStringMapping
					{
						Id = 3,
						Name = (name)"Yellow",
					},
					new Settings.IdToStringMapping
					{
						Id = 4,
						Name = (name)"Orange",
					},
					new Settings.IdToStringMapping
					{
						Id = 5,
						Name = (name)"Pink",
					},
					new Settings.IdToStringMapping
					{
						Id = 6,
						Name = (name)"Red",
					},
					new Settings.IdToStringMapping
					{
						Id = 7,
						Name = (name)"Purple",
					},
					new Settings.IdToStringMapping
					{
						Id = 8,
						Name = (name)"Blue",
					},
					new Settings.IdToStringMapping
					{
						Id = 9,
						Name = (name)"Green",
					},
					new Settings.IdToStringMapping
					{
						Id = 10,
						Name = (name)"Brown",
					},
					new Settings.IdToStringMapping
					{
						Id = 11,
						Name = (name)"Silver",
					},
				},
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 15,
				Name = (name)"Second Preferred Color",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_IdMapped,
				ValueMappings = new array<Settings.IdToStringMapping>
				{
					new Settings.IdToStringMapping
					{
						Id = 0,
						Name = (name)"None",
					},
					new Settings.IdToStringMapping
					{
						Id = 1,
						Name = (name)"Black",
					},
					new Settings.IdToStringMapping
					{
						Id = 2,
						Name = (name)"White",
					},
					new Settings.IdToStringMapping
					{
						Id = 3,
						Name = (name)"Yellow",
					},
					new Settings.IdToStringMapping
					{
						Id = 4,
						Name = (name)"Orange",
					},
					new Settings.IdToStringMapping
					{
						Id = 5,
						Name = (name)"Pink",
					},
					new Settings.IdToStringMapping
					{
						Id = 6,
						Name = (name)"Red",
					},
					new Settings.IdToStringMapping
					{
						Id = 7,
						Name = (name)"Purple",
					},
					new Settings.IdToStringMapping
					{
						Id = 8,
						Name = (name)"Blue",
					},
					new Settings.IdToStringMapping
					{
						Id = 9,
						Name = (name)"Green",
					},
					new Settings.IdToStringMapping
					{
						Id = 10,
						Name = (name)"Brown",
					},
					new Settings.IdToStringMapping
					{
						Id = 11,
						Name = (name)"Silver",
					},
				},
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 16,
				Name = (name)"Auto Aim",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_IdMapped,
				ValueMappings = new array<Settings.IdToStringMapping>
				{
					new Settings.IdToStringMapping
					{
						Id = 0,
						Name = (name)"Off",
					},
					new Settings.IdToStringMapping
					{
						Id = 1,
						Name = (name)"On",
					},
				},
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 17,
				Name = (name)"Auto Center",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_IdMapped,
				ValueMappings = new array<Settings.IdToStringMapping>
				{
					new Settings.IdToStringMapping
					{
						Id = 0,
						Name = (name)"Off",
					},
					new Settings.IdToStringMapping
					{
						Id = 1,
						Name = (name)"On",
					},
				},
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 18,
				Name = (name)"Movement Control",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_IdMapped,
				ValueMappings = new array<Settings.IdToStringMapping>
				{
					new Settings.IdToStringMapping
					{
						Id = 0,
						Name = (name)"Left Thumbstick",
					},
					new Settings.IdToStringMapping
					{
						Id = 1,
						Name = (name)"Right Thumbstick",
					},
				},
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 19,
				Name = (name)"Transmission Preference",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_IdMapped,
				ValueMappings = new array<Settings.IdToStringMapping>
				{
					new Settings.IdToStringMapping
					{
						Id = 0,
						Name = (name)"Auto",
					},
					new Settings.IdToStringMapping
					{
						Id = 1,
						Name = (name)"Manual",
					},
				},
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 20,
				Name = (name)"Race Camera Preference",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_IdMapped,
				ValueMappings = new array<Settings.IdToStringMapping>
				{
					new Settings.IdToStringMapping
					{
						Id = 0,
						Name = (name)"Behind",
					},
					new Settings.IdToStringMapping
					{
						Id = 1,
						Name = (name)"Front",
					},
					new Settings.IdToStringMapping
					{
						Id = 2,
						Name = (name)"Inside",
					},
				},
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 21,
				Name = (name)"Brake Preference",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_IdMapped,
				ValueMappings = new array<Settings.IdToStringMapping>
				{
					new Settings.IdToStringMapping
					{
						Id = 0,
						Name = (name)"Trigger",
					},
					new Settings.IdToStringMapping
					{
						Id = 1,
						Name = (name)"Button",
					},
				},
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 22,
				Name = (name)"Accelerator Preference",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_IdMapped,
				ValueMappings = new array<Settings.IdToStringMapping>
				{
					new Settings.IdToStringMapping
					{
						Id = 0,
						Name = (name)"Trigger",
					},
					new Settings.IdToStringMapping
					{
						Id = 1,
						Name = (name)"Button",
					},
				},
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
		};
	}
}
}