namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataProvider : UIRoot/*
		abstract
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public enum EProviderAccessType 
	{
		ACCESS_ReadOnly,
		ACCESS_WriteAll,
		ACCESS_MAX
	};
	
	public partial struct /*native transient */UIDataProviderField
	{
		public /*init */name FieldTag;
		public /*init */UIRoot.EUIDataProviderFieldType FieldType;
		public /*init */array<UIDataProvider> FieldProviders;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002F5112
	//		FieldTag = (name)"None";
	//		FieldType = UIRoot.EUIDataProviderFieldType.DATATYPE_Property;
	//		FieldProviders = default;
	//	}
	};
	
	public UIDataProvider.EProviderAccessType WriteAccessType;
	public array< /*delegate*/UIDataProvider.OnDataProviderPropertyChange > ProviderChangedNotifies;
	public /*delegate*/UIDataProvider.OnDataProviderPropertyChange __OnDataProviderPropertyChange__Delegate;
	
	public delegate void OnDataProviderPropertyChange(UIDataProvider SourceProvider, /*optional */name? _PropTag = default);
	
	public virtual /*event */void NotifyPropertyChanged(/*optional */name? _PropTag = default)
	{
		// stub
	}
	
	public virtual /*protected final function */void AddPropertyNotificationChangeRequest(/*delegate*/UIDataProvider.OnDataProviderPropertyChange InDelegate)
	{
		// stub
	}
	
	public virtual /*protected final function */void RemovePropertyNotificationChangeRequest(/*delegate*/UIDataProvider.OnDataProviderPropertyChange InDelegate)
	{
		// stub
	}
	
	public virtual /*event */void GetSupportedScriptFields(ref array<UIDataProvider.UIDataProviderField> out_Fields)
	{
		// stub
	}
	
	public virtual /*event */bool GetFieldValue(String FieldName, ref UIRoot.UIProviderScriptFieldValue FieldValue, /*optional */int? _ArrayIndex = default)
	{
		// stub
		return default;
	}
	
	public virtual /*event */bool SetFieldValue(String FieldName, /*const */ref UIRoot.UIProviderScriptFieldValue FieldValue, /*optional */int? _ArrayIndex = default)
	{
		// stub
		return default;
	}
	
	public virtual /*event */String GenerateScriptMarkupString(name DataTag)
	{
		// stub
		return default;
	}
	
	public virtual /*event */String GenerateFillerData(String DataTag)
	{
		// stub
		return default;
	}
	
	// Export UUIDataProvider::execGetFieldValueFromScript(FFrame&, void* const)
	public virtual /*native function */bool GetFieldValueFromScript(String FieldName, ref UIRoot.UIProviderFieldValue FieldValue, /*optional */int? _ArrayIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
}
}