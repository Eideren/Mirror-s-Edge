namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Settings : Object/*
		abstract
		native*/{
	public enum EOnlineDataAdvertisementType 
	{
		ODAT_DontAdvertise,
		ODAT_OnlineService,
		ODAT_QoS,
		ODAT_MAX
	};
	
	public enum ESettingsDataType 
	{
		SDT_Empty,
		SDT_Int32,
		SDT_Int64,
		SDT_Double,
		SDT_String,
		SDT_Float,
		SDT_Blob,
		SDT_DateTime,
		SDT_MAX
	};
	
	public enum EPropertyValueMappingType 
	{
		PVMT_RawValue,
		PVMT_PredefinedValues,
		PVMT_Ranged,
		PVMT_IdMapped,
		PVMT_MAX
	};
	
	public partial struct /*native */LocalizedStringSetting
	{
		public int Id;
		public int ValueIndex;
		public Settings.EOnlineDataAdvertisementType AdvertisementType;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003617DD
	//		Id = 0;
	//		ValueIndex = 0;
	//		AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise;
	//	}
	};
	
	public partial struct /*native */SettingsData
	{
		[Const] public Settings.ESettingsDataType Type;
		[Const] public int Value1;
		[native, Const, transient] public Object.Pointer Value2;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00363718
	//		Type = Settings.ESettingsDataType.SDT_Empty;
	//		Value1 = 0;
	//	}
	};
	
	public partial struct /*native */SettingsProperty
	{
		public int PropertyId;
		public Settings.SettingsData Data;
		public Settings.EOnlineDataAdvertisementType AdvertisementType;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00363818
	//		PropertyId = 0;
	//		Data = new Settings.SettingsData
	//		{
	//			Type = Settings.ESettingsDataType.SDT_Empty,
	//			Value1 = 0,
	//		};
	//		AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise;
	//	}
	};
	
	public partial struct /*native */StringIdToStringMapping
	{
		[Const] public int Id;
		[Const, localized] public name Name;
		[Const] public bool bIsWildcard;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00363974
	//		Id = 0;
	//		Name = (name)"None";
	//		bIsWildcard = false;
	//	}
	};
	
	public partial struct /*native */LocalizedStringSettingMetaData
	{
		[Const] public int Id;
		[Const] public name Name;
		[Const, localized] public String ColumnHeaderText;
		[Const] public array<Settings.StringIdToStringMapping> ValueMappings;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00363AE8
	//		Id = 0;
	//		Name = (name)"None";
	//		ColumnHeaderText = "";
	//		ValueMappings = default;
	//	}
	};
	
	public partial struct /*native */IdToStringMapping
	{
		[Const] public int Id;
		[Const, localized] public name Name;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00363BEC
	//		Id = 0;
	//		Name = (name)"None";
	//	}
	};
	
	public partial struct /*native */SettingsPropertyPropertyMetaData
	{
		[Const] public int Id;
		[Const] public name Name;
		[Const, localized] public String ColumnHeaderText;
		[Const] public Settings.EPropertyValueMappingType MappingType;
		[Const] public array<Settings.IdToStringMapping> ValueMappings;
		[Const] public array<Settings.SettingsData> PredefinedValues;
		[Const] public float MinVal;
		[Const] public float MaxVal;
		[Const] public float RangeIncrement;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00363E98
	//		Id = 0;
	//		Name = (name)"None";
	//		ColumnHeaderText = "";
	//		MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue;
	//		ValueMappings = default;
	//		PredefinedValues = default;
	//		MinVal = 0.0f;
	//		MaxVal = 0.0f;
	//		RangeIncrement = 0.0f;
	//	}
	};
	
	public array<Settings.LocalizedStringSetting> LocalizedSettings;
	public array<Settings.SettingsProperty> Properties;
	public array<Settings.LocalizedStringSettingMetaData> LocalizedSettingsMappings;
	public array<Settings.SettingsPropertyPropertyMetaData> PropertyMappings;
	
	// Export USettings::execSetSettingsDataString(FFrame&, void* const)
	public /*native function */static void SetSettingsDataString(ref Settings.SettingsData Data, String InString)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export USettings::execSetSettingsDataFloat(FFrame&, void* const)
	public /*native function */static void SetSettingsDataFloat(ref Settings.SettingsData Data, float InFloat)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export USettings::execSetSettingsDataInt(FFrame&, void* const)
	public /*native function */static void SetSettingsDataInt(ref Settings.SettingsData Data, int InInt)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export USettings::execSetSettingsDataDateTime(FFrame&, void* const)
	public /*native function */static void SetSettingsDataDateTime(ref Settings.SettingsData Data, int InInt1, int InInt2)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export USettings::execSetSettingsDataBlob(FFrame&, void* const)
	public /*native function */static void SetSettingsDataBlob(ref Settings.SettingsData Data, ref array<byte> InBlob)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export USettings::execSetSettingsData(FFrame&, void* const)
	public /*native function */static void SetSettingsData(ref Settings.SettingsData Data, ref Settings.SettingsData Data2Copy)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export USettings::execEmptySettingsData(FFrame&, void* const)
	public /*native function */static void EmptySettingsData(ref Settings.SettingsData Data)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export USettings::execGetSettingsDataString(FFrame&, void* const)
	public /*native function */static String GetSettingsDataString(ref Settings.SettingsData Data)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export USettings::execGetSettingsDataFloat(FFrame&, void* const)
	public /*native function */static float GetSettingsDataFloat(ref Settings.SettingsData Data)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export USettings::execGetSettingsDataInt(FFrame&, void* const)
	public /*native function */static int GetSettingsDataInt(ref Settings.SettingsData Data)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export USettings::execGetSettingsDataBlob(FFrame&, void* const)
	public /*native function */static void GetSettingsDataBlob(ref Settings.SettingsData Data, ref array<byte> OutBlob)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export USettings::execGetSettingsDataDateTime(FFrame&, void* const)
	public /*native function */static void GetSettingsDataDateTime(ref Settings.SettingsData Data, ref int OutInt1, ref int OutInt2)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export USettings::execSetStringSettingValue(FFrame&, void* const)
	public virtual /*native function */void SetStringSettingValue(int StringSettingId, int ValueIndex, bool bShouldAutoAdd)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export USettings::execGetStringSettingValue(FFrame&, void* const)
	public virtual /*native function */bool GetStringSettingValue(int StringSettingId, ref int ValueIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export USettings::execGetStringSettingValueNames(FFrame&, void* const)
	public virtual /*native function */bool GetStringSettingValueNames(int StringSettingId, ref array<Settings.IdToStringMapping> Values)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export USettings::execSetStringSettingValueByName(FFrame&, void* const)
	public virtual /*native function */void SetStringSettingValueByName(name StringSettingName, int ValueIndex, bool bShouldAutoAdd)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export USettings::execGetStringSettingValueByName(FFrame&, void* const)
	public virtual /*native function */bool GetStringSettingValueByName(name StringSettingName, ref int ValueIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export USettings::execGetStringSettingId(FFrame&, void* const)
	public virtual /*native function */bool GetStringSettingId(name StringSettingName, ref int StringSettingId)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export USettings::execGetStringSettingName(FFrame&, void* const)
	public virtual /*native function */name GetStringSettingName(int StringSettingId)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export USettings::execGetStringSettingColumnHeader(FFrame&, void* const)
	public virtual /*native function */String GetStringSettingColumnHeader(int StringSettingId)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export USettings::execIsWildcardStringSetting(FFrame&, void* const)
	public virtual /*native function */bool IsWildcardStringSetting(int StringSettingId)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export USettings::execGetStringSettingValueName(FFrame&, void* const)
	public virtual /*native function */name GetStringSettingValueName(int StringSettingId, int ValueIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export USettings::execGetStringSettingValueNameByName(FFrame&, void* const)
	public virtual /*native function */name GetStringSettingValueNameByName(name StringSettingName)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export USettings::execSetStringSettingValueFromStringByName(FFrame&, void* const)
	public virtual /*native function */bool SetStringSettingValueFromStringByName(name StringSettingName, /*const */ref String NewValue)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export USettings::execGetPropertyId(FFrame&, void* const)
	public virtual /*native function */bool GetPropertyId(name PropertyName, ref int PropertyId)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export USettings::execGetPropertyName(FFrame&, void* const)
	public virtual /*native function */name GetPropertyName(int PropertyId)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export USettings::execGetPropertyColumnHeader(FFrame&, void* const)
	public virtual /*native function */String GetPropertyColumnHeader(int PropertyId)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export USettings::execGetPropertyAsString(FFrame&, void* const)
	public virtual /*native function */String GetPropertyAsString(int PropertyId)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export USettings::execGetPropertyAsStringByName(FFrame&, void* const)
	public virtual /*native function */String GetPropertyAsStringByName(name PropertyName)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export USettings::execSetPropertyFromStringByName(FFrame&, void* const)
	public virtual /*native function */bool SetPropertyFromStringByName(name PropertyName, /*const */ref String NewValue)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export USettings::execSetFloatProperty(FFrame&, void* const)
	public virtual /*native function */void SetFloatProperty(int PropertyId, float Value)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export USettings::execGetFloatProperty(FFrame&, void* const)
	public virtual /*native function */bool GetFloatProperty(int PropertyId, ref float Value)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export USettings::execSetIntProperty(FFrame&, void* const)
	public virtual /*native function */void SetIntProperty(int PropertyId, int Value)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export USettings::execGetIntProperty(FFrame&, void* const)
	public virtual /*native function */bool GetIntProperty(int PropertyId, ref int Value)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export USettings::execSetStringProperty(FFrame&, void* const)
	public virtual /*native function */void SetStringProperty(int PropertyId, String Value)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export USettings::execGetStringProperty(FFrame&, void* const)
	public virtual /*native function */bool GetStringProperty(int PropertyId, ref String Value)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export USettings::execGetPropertyType(FFrame&, void* const)
	public virtual /*native function */Settings.ESettingsDataType GetPropertyType(int PropertyId)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export USettings::execUpdateStringSettings(FFrame&, void* const)
	public virtual /*native function */void UpdateStringSettings(/*const */ref array<Settings.LocalizedStringSetting> Settings, /*optional */bool? _bShouldAddIfMissing = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export USettings::execUpdateProperties(FFrame&, void* const)
	public virtual /*native function */void UpdateProperties(/*const */ref array<Settings.SettingsProperty> Props, /*optional */bool? _bShouldAddIfMissing = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export USettings::execHasProperty(FFrame&, void* const)
	public virtual /*native function */bool HasProperty(int PropertyId)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export USettings::execHasStringSetting(FFrame&, void* const)
	public virtual /*native function */bool HasStringSetting(int SettingId)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export USettings::execGetPropertyMappingType(FFrame&, void* const)
	public virtual /*native function */bool GetPropertyMappingType(int PropertyId, ref Settings.EPropertyValueMappingType OutType)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export USettings::execGetPropertyRange(FFrame&, void* const)
	public virtual /*native function */bool GetPropertyRange(int PropertyId, ref float OutMinValue, ref float OutMaxValue, ref float RangeIncrement, ref byte bFormatAsInt)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export USettings::execSetRangedPropertyValue(FFrame&, void* const)
	public virtual /*native function */bool SetRangedPropertyValue(int PropertyId, float NewValue)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export USettings::execGetRangedPropertyValue(FFrame&, void* const)
	public virtual /*native function */bool GetRangedPropertyValue(int PropertyId, ref float OutValue)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export USettings::execGetQoSAdvertisedProperties(FFrame&, void* const)
	public virtual /*native function */void GetQoSAdvertisedProperties(ref array<Settings.SettingsProperty> QoSProps)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export USettings::execGetQoSAdvertisedStringSettings(FFrame&, void* const)
	public virtual /*native function */void GetQoSAdvertisedStringSettings(ref array<Settings.LocalizedStringSetting> QoSSettings)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export USettings::execAppendDataBindingsToURL(FFrame&, void* const)
	public virtual /*native function */void AppendDataBindingsToURL(ref String URL)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export USettings::execAppendPropertiesToURL(FFrame&, void* const)
	public virtual /*native function */void AppendPropertiesToURL(ref String URL)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export USettings::execAppendContextsToURL(FFrame&, void* const)
	public virtual /*native function */void AppendContextsToURL(ref String URL)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export USettings::execBuildURL(FFrame&, void* const)
	public virtual /*native function */void BuildURL(ref String URL)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export USettings::execUpdateFromURL(FFrame&, void* const)
	public virtual /*native function */void UpdateFromURL(/*const */ref String URL, GameInfo Game)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
}
}