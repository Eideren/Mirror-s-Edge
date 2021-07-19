namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDynamicFieldProvider : UIDataProvider/*
		notransient
		native
		config(UI)
		perobjectconfig
		hidecategories(Object,UIRoot)*/{
	[Category] [config] public/*protected*/ array</*config */UIRoot.UIProviderScriptFieldValue> PersistentDataFields;
	[Category] [transient] public/*protected*/ array<UIRoot.UIProviderScriptFieldValue> RuntimeDataFields;
	[native, Const] public/*protected*/ Object.Map_Mirror PersistentCollectionData;
	[native, Const, transient] public/*protected*/ Object.Map_Mirror RuntimeCollectionData;
	
	// Export UUIDynamicFieldProvider::execInitializeRuntimeFields(FFrame&, void* const)
	public virtual /*native function */void InitializeRuntimeFields()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIDynamicFieldProvider::execAddField(FFrame&, void* const)
	public virtual /*native final function */bool AddField(name FieldName, /*optional */UIRoot.EUIDataProviderFieldType? _FieldType/* = default*/, /*optional */bool? _bPersistent/* = default*/, /*optional */ref int out_InsertPosition/* = default*/)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execRemoveField(FFrame&, void* const)
	public virtual /*native final function */bool RemoveField(name FieldName)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execFindFieldIndex(FFrame&, void* const)
	public virtual /*native final function */int FindFieldIndex(name FieldName, /*optional */bool? _bSearchPersistentFields = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execClearFields(FFrame&, void* const)
	public virtual /*native final function */bool ClearFields(/*optional */bool? _bReinitializeRuntimeFields = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execGetField(FFrame&, void* const)
	public virtual /*native final function */bool GetField(name FieldName, ref UIRoot.UIProviderScriptFieldValue out_Field)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execSetField(FFrame&, void* const)
	public virtual /*native final function */bool SetField(name FieldName, /*const */ref UIRoot.UIProviderScriptFieldValue FieldValue, /*optional */bool? _bChangeExistingOnly = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execSavePersistentProviderData(FFrame&, void* const)
	public virtual /*native final function */void SavePersistentProviderData()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIDynamicFieldProvider::execGetCollectionValueSchema(FFrame&, void* const)
	public virtual /*native final function */bool GetCollectionValueSchema(name FieldName, ref array<name> out_CellTagArray, /*optional */bool? _bPersistent = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execGetCollectionValueArray(FFrame&, void* const)
	public virtual /*native final function */bool GetCollectionValueArray(name FieldName, ref array<String> out_DataValueArray, /*optional */bool? _bPersistent = default, /*optional */name? _CellTag = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execSetCollectionValueArray(FFrame&, void* const)
	public virtual /*native final function */bool SetCollectionValueArray(name FieldName, /*const */ref array<String> CollectionValues, /*optional */bool? _bClearExisting = default, /*optional */int? _InsertIndex = default, /*optional */bool? _bPersistent = default, /*optional */name? _CellTag = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execInsertCollectionValue(FFrame&, void* const)
	public virtual /*native final function */bool InsertCollectionValue(name FieldName, /*const */ref String NewValue, /*optional */int? _InsertIndex = default, /*optional */bool? _bPersistent = default, /*optional */bool? _bAllowDuplicateValues = default, /*optional */name? _CellTag = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execRemoveCollectionValue(FFrame&, void* const)
	public virtual /*native final function */bool RemoveCollectionValue(name FieldName, /*const */ref String ValueToRemove, /*optional */bool? _bPersistent = default, /*optional */name? _CellTag = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execRemoveCollectionValueByIndex(FFrame&, void* const)
	public virtual /*native final function */bool RemoveCollectionValueByIndex(name FieldName, int ValueIndex, /*optional */bool? _bPersistent = default, /*optional */name? _CellTag = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execReplaceCollectionValue(FFrame&, void* const)
	public virtual /*native final function */bool ReplaceCollectionValue(name FieldName, /*const */ref String CurrentValue, /*const */ref String NewValue, /*optional */bool? _bPersistent = default, /*optional */name? _CellTag = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execReplaceCollectionValueByIndex(FFrame&, void* const)
	public virtual /*native final function */bool ReplaceCollectionValueByIndex(name FieldName, int ValueIndex, /*const */ref String NewValue, /*optional */bool? _bPersistent = default, /*optional */name? _CellTag = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execClearCollectionValueArray(FFrame&, void* const)
	public virtual /*native final function */bool ClearCollectionValueArray(name FieldName, /*optional */bool? _bPersistent = default, /*optional */name? _CellTag = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execGetCollectionValue(FFrame&, void* const)
	public virtual /*native final function */bool GetCollectionValue(name FieldName, int ValueIndex, ref String out_Value, /*optional */bool? _bPersistent = default, /*optional */name? _CellTag = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execFindCollectionValueIndex(FFrame&, void* const)
	public virtual /*native final function */int FindCollectionValueIndex(name FieldName, /*const */ref String ValueToFind, /*optional */bool? _bPersistent = default, /*optional */name? _CellTag = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public UIDynamicFieldProvider()
	{
		// Object Offset:0x0042EC67
		WriteAccessType = UIDataProvider.EProviderAccessType.ACCESS_WriteAll;
	}
}
}