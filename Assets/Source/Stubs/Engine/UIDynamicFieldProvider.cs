namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDynamicFieldProvider : UIDataProvider/*
		notransient
		native
		config(UI)
		perobjectconfig
		hidecategories(Object,UIRoot)*/{
	public/*()*/ /*protected config */array</*config */UIRoot.UIProviderScriptFieldValue> PersistentDataFields;
	public/*()*/ /*protected transient */array<UIRoot.UIProviderScriptFieldValue> RuntimeDataFields;
	public /*protected native const */Object.Map_Mirror PersistentCollectionData;
	public /*protected native const transient */Object.Map_Mirror RuntimeCollectionData;
	
	// Export UUIDynamicFieldProvider::execInitializeRuntimeFields(FFrame&, void* const)
	public virtual /*native function */void InitializeRuntimeFields()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIDynamicFieldProvider::execAddField(FFrame&, void* const)
	public virtual /*native final function */bool AddField(name FieldName, /*optional */UIRoot.EUIDataProviderFieldType? _FieldType/* = default*/, /*optional */bool? _bPersistent/* = default*/, /*optional */ref int out_InsertPosition/* = default*/)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execRemoveField(FFrame&, void* const)
	public virtual /*native final function */bool RemoveField(name FieldName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execFindFieldIndex(FFrame&, void* const)
	public virtual /*native final function */int FindFieldIndex(name FieldName, /*optional */bool? _bSearchPersistentFields = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execClearFields(FFrame&, void* const)
	public virtual /*native final function */bool ClearFields(/*optional */bool? _bReinitializeRuntimeFields = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execGetField(FFrame&, void* const)
	public virtual /*native final function */bool GetField(name FieldName, ref UIRoot.UIProviderScriptFieldValue out_Field)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execSetField(FFrame&, void* const)
	public virtual /*native final function */bool SetField(name FieldName, /*const */ref UIRoot.UIProviderScriptFieldValue FieldValue, /*optional */bool? _bChangeExistingOnly = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execSavePersistentProviderData(FFrame&, void* const)
	public virtual /*native final function */void SavePersistentProviderData()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIDynamicFieldProvider::execGetCollectionValueSchema(FFrame&, void* const)
	public virtual /*native final function */bool GetCollectionValueSchema(name FieldName, ref array<name> out_CellTagArray, /*optional */bool? _bPersistent = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execGetCollectionValueArray(FFrame&, void* const)
	public virtual /*native final function */bool GetCollectionValueArray(name FieldName, ref array<string> out_DataValueArray, /*optional */bool? _bPersistent = default, /*optional */name? _CellTag = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execSetCollectionValueArray(FFrame&, void* const)
	public virtual /*native final function */bool SetCollectionValueArray(name FieldName, /*const */ref array<string> CollectionValues, /*optional */bool? _bClearExisting = default, /*optional */int? _InsertIndex = default, /*optional */bool? _bPersistent = default, /*optional */name? _CellTag = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execInsertCollectionValue(FFrame&, void* const)
	public virtual /*native final function */bool InsertCollectionValue(name FieldName, /*const */ref string NewValue, /*optional */int? _InsertIndex = default, /*optional */bool? _bPersistent = default, /*optional */bool? _bAllowDuplicateValues = default, /*optional */name? _CellTag = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execRemoveCollectionValue(FFrame&, void* const)
	public virtual /*native final function */bool RemoveCollectionValue(name FieldName, /*const */ref string ValueToRemove, /*optional */bool? _bPersistent = default, /*optional */name? _CellTag = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execRemoveCollectionValueByIndex(FFrame&, void* const)
	public virtual /*native final function */bool RemoveCollectionValueByIndex(name FieldName, int ValueIndex, /*optional */bool? _bPersistent = default, /*optional */name? _CellTag = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execReplaceCollectionValue(FFrame&, void* const)
	public virtual /*native final function */bool ReplaceCollectionValue(name FieldName, /*const */ref string CurrentValue, /*const */ref string NewValue, /*optional */bool? _bPersistent = default, /*optional */name? _CellTag = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execReplaceCollectionValueByIndex(FFrame&, void* const)
	public virtual /*native final function */bool ReplaceCollectionValueByIndex(name FieldName, int ValueIndex, /*const */ref string NewValue, /*optional */bool? _bPersistent = default, /*optional */name? _CellTag = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execClearCollectionValueArray(FFrame&, void* const)
	public virtual /*native final function */bool ClearCollectionValueArray(name FieldName, /*optional */bool? _bPersistent = default, /*optional */name? _CellTag = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execGetCollectionValue(FFrame&, void* const)
	public virtual /*native final function */bool GetCollectionValue(name FieldName, int ValueIndex, ref string out_Value, /*optional */bool? _bPersistent = default, /*optional */name? _CellTag = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDynamicFieldProvider::execFindCollectionValueIndex(FFrame&, void* const)
	public virtual /*native final function */int FindCollectionValueIndex(name FieldName, /*const */ref string ValueToFind, /*optional */bool? _bPersistent = default, /*optional */name? _CellTag = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public UIDynamicFieldProvider()
	{
		// Object Offset:0x0042EC67
		WriteAccessType = UIDataProvider.EProviderAccessType.ACCESS_WriteAll;
	}
}
}