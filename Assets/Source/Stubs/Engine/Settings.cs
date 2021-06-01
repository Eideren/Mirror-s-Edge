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
		public /*const */Settings.ESettingsDataType Type;
		public /*const */int Value1;
		public /*native const transient */Object.Pointer Value2;
	
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
		public /*const */int Id;
		public /*const localized */name Name;
		public /*const */bool bIsWildcard;
	
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
		public /*const */int Id;
		public /*const */name Name;
		public /*const localized */String ColumnHeaderText;
		public /*const */array<Settings.StringIdToStringMapping> ValueMappings;
	
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
		public /*const */int Id;
		public /*const localized */name Name;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00363BEC
	//		Id = 0;
	//		Name = (name)"None";
	//	}
	};
	
	public partial struct /*native */SettingsPropertyPropertyMetaData
	{
		public /*const */int Id;
		public /*const */name Name;
		public /*const localized */String ColumnHeaderText;
		public /*const */Settings.EPropertyValueMappingType MappingType;
		public /*const */array<Settings.IdToStringMapping> ValueMappings;
		public /*const */array<Settings.SettingsData> PredefinedValues;
		public /*const */float MinVal;
		public /*const */float MaxVal;
		public /*const */float RangeIncrement;
	
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
		#warning NATIVE FUNCTION !
	}
	
	// Export USettings::execSetSettingsDataFloat(FFrame&, void* const)
	public /*native function */static void SetSettingsDataFloat(ref Settings.SettingsData Data, float InFloat)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USettings::execSetSettingsDataInt(FFrame&, void* const)
	public /*native function */static void SetSettingsDataInt(ref Settings.SettingsData Data, int InInt)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USettings::execSetSettingsDataDateTime(FFrame&, void* const)
	public /*native function */static void SetSettingsDataDateTime(ref Settings.SettingsData Data, int InInt1, int InInt2)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USettings::execSetSettingsDataBlob(FFrame&, void* const)
	public /*native function */static void SetSettingsDataBlob(ref Settings.SettingsData Data, ref array<byte> InBlob)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USettings::execSetSettingsData(FFrame&, void* const)
	public /*native function */static void SetSettingsData(ref Settings.SettingsData Data, ref Settings.SettingsData Data2Copy)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USettings::execEmptySettingsData(FFrame&, void* const)
	public /*native function */static void EmptySettingsData(ref Settings.SettingsData Data)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USettings::execGetSettingsDataString(FFrame&, void* const)
	public /*native function */static String GetSettingsDataString(ref Settings.SettingsData Data)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USettings::execGetSettingsDataFloat(FFrame&, void* const)
	public /*native function */static float GetSettingsDataFloat(ref Settings.SettingsData Data)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USettings::execGetSettingsDataInt(FFrame&, void* const)
	public /*native function */static int GetSettingsDataInt(ref Settings.SettingsData Data)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USettings::execGetSettingsDataBlob(FFrame&, void* const)
	public /*native function */static void GetSettingsDataBlob(ref Settings.SettingsData Data, ref array<byte> OutBlob)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USettings::execGetSettingsDataDateTime(FFrame&, void* const)
	public /*native function */static void GetSettingsDataDateTime(ref Settings.SettingsData Data, ref int OutInt1, ref int OutInt2)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USettings::execSetStringSettingValue(FFrame&, void* const)
	public virtual /*native function */void SetStringSettingValue(int StringSettingId, int ValueIndex, bool bShouldAutoAdd)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USettings::execGetStringSettingValue(FFrame&, void* const)
	public virtual /*native function */bool GetStringSettingValue(int StringSettingId, ref int ValueIndex)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USettings::execGetStringSettingValueNames(FFrame&, void* const)
	public virtual /*native function */bool GetStringSettingValueNames(int StringSettingId, ref array<Settings.IdToStringMapping> Values)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USettings::execSetStringSettingValueByName(FFrame&, void* const)
	public virtual /*native function */void SetStringSettingValueByName(name StringSettingName, int ValueIndex, bool bShouldAutoAdd)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USettings::execGetStringSettingValueByName(FFrame&, void* const)
	public virtual /*native function */bool GetStringSettingValueByName(name StringSettingName, ref int ValueIndex)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USettings::execGetStringSettingId(FFrame&, void* const)
	public virtual /*native function */bool GetStringSettingId(name StringSettingName, ref int StringSettingId)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USettings::execGetStringSettingName(FFrame&, void* const)
	public virtual /*native function */name GetStringSettingName(int StringSettingId)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USettings::execGetStringSettingColumnHeader(FFrame&, void* const)
	public virtual /*native function */String GetStringSettingColumnHeader(int StringSettingId)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USettings::execIsWildcardStringSetting(FFrame&, void* const)
	public virtual /*native function */bool IsWildcardStringSetting(int StringSettingId)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USettings::execGetStringSettingValueName(FFrame&, void* const)
	public virtual /*native function */name GetStringSettingValueName(int StringSettingId, int ValueIndex)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USettings::execGetStringSettingValueNameByName(FFrame&, void* const)
	public virtual /*native function */name GetStringSettingValueNameByName(name StringSettingName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USettings::execSetStringSettingValueFromStringByName(FFrame&, void* const)
	public virtual /*native function */bool SetStringSettingValueFromStringByName(name StringSettingName, /*const */ref String NewValue)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USettings::execGetPropertyId(FFrame&, void* const)
	public virtual /*native function */bool GetPropertyId(name PropertyName, ref int PropertyId)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USettings::execGetPropertyName(FFrame&, void* const)
	public virtual /*native function */name GetPropertyName(int PropertyId)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USettings::execGetPropertyColumnHeader(FFrame&, void* const)
	public virtual /*native function */String GetPropertyColumnHeader(int PropertyId)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USettings::execGetPropertyAsString(FFrame&, void* const)
	public virtual /*native function */String GetPropertyAsString(int PropertyId)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USettings::execGetPropertyAsStringByName(FFrame&, void* const)
	public virtual /*native function */String GetPropertyAsStringByName(name PropertyName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USettings::execSetPropertyFromStringByName(FFrame&, void* const)
	public virtual /*native function */bool SetPropertyFromStringByName(name PropertyName, /*const */ref String NewValue)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USettings::execSetFloatProperty(FFrame&, void* const)
	public virtual /*native function */void SetFloatProperty(int PropertyId, float Value)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USettings::execGetFloatProperty(FFrame&, void* const)
	public virtual /*native function */bool GetFloatProperty(int PropertyId, ref float Value)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USettings::execSetIntProperty(FFrame&, void* const)
	public virtual /*native function */void SetIntProperty(int PropertyId, int Value)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USettings::execGetIntProperty(FFrame&, void* const)
	public virtual /*native function */bool GetIntProperty(int PropertyId, ref int Value)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USettings::execSetStringProperty(FFrame&, void* const)
	public virtual /*native function */void SetStringProperty(int PropertyId, String Value)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USettings::execGetStringProperty(FFrame&, void* const)
	public virtual /*native function */bool GetStringProperty(int PropertyId, ref String Value)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USettings::execGetPropertyType(FFrame&, void* const)
	public virtual /*native function */Settings.ESettingsDataType GetPropertyType(int PropertyId)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USettings::execUpdateStringSettings(FFrame&, void* const)
	public virtual /*native function */void UpdateStringSettings(/*const */ref array<Settings.LocalizedStringSetting> Settings, /*optional */bool? _bShouldAddIfMissing = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USettings::execUpdateProperties(FFrame&, void* const)
	public virtual /*native function */void UpdateProperties(/*const */ref array<Settings.SettingsProperty> Props, /*optional */bool? _bShouldAddIfMissing = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USettings::execHasProperty(FFrame&, void* const)
	public virtual /*native function */bool HasProperty(int PropertyId)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USettings::execHasStringSetting(FFrame&, void* const)
	public virtual /*native function */bool HasStringSetting(int SettingId)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USettings::execGetPropertyMappingType(FFrame&, void* const)
	public virtual /*native function */bool GetPropertyMappingType(int PropertyId, ref Settings.EPropertyValueMappingType OutType)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USettings::execGetPropertyRange(FFrame&, void* const)
	public virtual /*native function */bool GetPropertyRange(int PropertyId, ref float OutMinValue, ref float OutMaxValue, ref float RangeIncrement, ref byte bFormatAsInt)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USettings::execSetRangedPropertyValue(FFrame&, void* const)
	public virtual /*native function */bool SetRangedPropertyValue(int PropertyId, float NewValue)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USettings::execGetRangedPropertyValue(FFrame&, void* const)
	public virtual /*native function */bool GetRangedPropertyValue(int PropertyId, ref float OutValue)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USettings::execGetQoSAdvertisedProperties(FFrame&, void* const)
	public virtual /*native function */void GetQoSAdvertisedProperties(ref array<Settings.SettingsProperty> QoSProps)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USettings::execGetQoSAdvertisedStringSettings(FFrame&, void* const)
	public virtual /*native function */void GetQoSAdvertisedStringSettings(ref array<Settings.LocalizedStringSetting> QoSSettings)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USettings::execAppendDataBindingsToURL(FFrame&, void* const)
	public virtual /*native function */void AppendDataBindingsToURL(ref String URL)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USettings::execAppendPropertiesToURL(FFrame&, void* const)
	public virtual /*native function */void AppendPropertiesToURL(ref String URL)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USettings::execAppendContextsToURL(FFrame&, void* const)
	public virtual /*native function */void AppendContextsToURL(ref String URL)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USettings::execBuildURL(FFrame&, void* const)
	public virtual /*native function */void BuildURL(ref String URL)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USettings::execUpdateFromURL(FFrame&, void* const)
	public virtual /*native function */void UpdateFromURL(/*const */ref String URL, GameInfo Game)
	{
		#warning NATIVE FUNCTION !
	}
	
}
}