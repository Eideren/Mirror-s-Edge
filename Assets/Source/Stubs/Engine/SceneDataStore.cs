namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SceneDataStore : UIDataStore, 
		UIListElementProvider,UIListElementCellProvider/*
		notransient
		native
		hidecategories(Object,UIRoot)*/{
	public /*private native const noexport */Object.Pointer VfTable_IUIListElementProvider;
	public /*private native const noexport */Object.Pointer VfTable_IUIListElementCellProvider;
	public /*const transient */UIScene OwnerScene;
	public /*protected */UIDynamicFieldProvider SceneDataProvider;
	
	public virtual /*final function */bool AddField(name FieldName, /*optional */UIRoot.EUIDataProviderFieldType? _FieldType/* = default*/, /*optional */bool? _bPersistent/* = default*/, /*optional */ref int out_InsertPosition/* = default*/)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */bool RemoveField(name FieldName)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */int FindFieldIndex(name FieldName, /*optional */bool? _bSearchPersistentFields = default)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */bool ClearFields(/*optional */bool? _bReinitializeRuntimeFields = default)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */bool GetCollectionValueArray(name FieldName, ref array<String> out_DataValueArray, /*optional */bool? _bPersistent = default, /*optional */name? _CellTag = default)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */bool SetCollectionValueArray(name FieldName, /*const */ref array<String> CollectionValues, /*optional */bool? _bClearExisting = default, /*optional */int? _InsertIndex = default, /*optional */bool? _bPersistent = default, /*optional */name? _CellTag = default)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */bool InsertCollectionValue(name FieldName, /*const */ref String NewValue, /*optional */int? _InsertIndex = default, /*optional */bool? _bPersistent = default, /*optional */bool? _bAllowDuplicateValues = default, /*optional */name? _CellTag = default)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */bool RemoveCollectionValue(name FieldName, /*const */ref String ValueToRemove, /*optional */bool? _bPersistent = default, /*optional */name? _CellTag = default)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */bool RemoveCollectionValueByIndex(name FieldName, int ValueIndex, /*optional */bool? _bPersistent = default, /*optional */name? _CellTag = default)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */bool ReplaceCollectionValue(name FieldName, /*const */ref String CurrentValue, /*const */ref String NewValue, /*optional */bool? _bPersistent = default, /*optional */name? _CellTag = default)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */bool ReplaceCollectionValueByIndex(name FieldName, int ValueIndex, /*const */ref String NewValue, /*optional */bool? _bPersistent = default, /*optional */name? _CellTag = default)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */bool ClearCollectionValueArray(name FieldName, /*optional */bool? _bPersistent = default, /*optional */name? _CellTag = default)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */bool GetCollectionValue(name FieldName, int ValueIndex, ref String out_Value, /*optional */bool? _bPersistent = default, /*optional */name? _CellTag = default)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */int FindCollectionValueIndex(name FieldName, /*const */ref String ValueToFind, /*optional */bool? _bPersistent = default, /*optional */name? _CellTag = default)
	{
		// stub
		return default;
	}
	
	public SceneDataStore()
	{
		// Object Offset:0x003B3A39
		Tag = (name)"SCENE_DATASTORE_TAG";
	}
}
}