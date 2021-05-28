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
	
	public virtual /*final function */bool AddField(name FieldName, /*optional */UIRoot.EUIDataProviderFieldType FieldType/* = default*/, /*optional */bool bPersistent/* = default*/, /*optional */ref int out_InsertPosition/* = default*/)
	{
	
		return default;
	}
	
	public virtual /*final function */bool RemoveField(name FieldName)
	{
	
		return default;
	}
	
	public virtual /*final function */int FindFieldIndex(name FieldName, /*optional */bool bSearchPersistentFields = default)
	{
	
		return default;
	}
	
	public virtual /*final function */bool ClearFields(/*optional */bool bReinitializeRuntimeFields = default)
	{
	
		return default;
	}
	
	public virtual /*final function */bool GetCollectionValueArray(name FieldName, ref array<string> out_DataValueArray, /*optional */bool bPersistent = default, /*optional */name CellTag = default)
	{
	
		return default;
	}
	
	public virtual /*final function */bool SetCollectionValueArray(name FieldName, /*const */ref array<string> CollectionValues, /*optional */bool bClearExisting = default, /*optional */int InsertIndex = default, /*optional */bool bPersistent = default, /*optional */name CellTag = default)
	{
	
		return default;
	}
	
	public virtual /*final function */bool InsertCollectionValue(name FieldName, /*const */ref string NewValue, /*optional */int InsertIndex = default, /*optional */bool bPersistent = default, /*optional */bool bAllowDuplicateValues = default, /*optional */name CellTag = default)
	{
	
		return default;
	}
	
	public virtual /*final function */bool RemoveCollectionValue(name FieldName, /*const */ref string ValueToRemove, /*optional */bool bPersistent = default, /*optional */name CellTag = default)
	{
	
		return default;
	}
	
	public virtual /*final function */bool RemoveCollectionValueByIndex(name FieldName, int ValueIndex, /*optional */bool bPersistent = default, /*optional */name CellTag = default)
	{
	
		return default;
	}
	
	public virtual /*final function */bool ReplaceCollectionValue(name FieldName, /*const */ref string CurrentValue, /*const */ref string NewValue, /*optional */bool bPersistent = default, /*optional */name CellTag = default)
	{
	
		return default;
	}
	
	public virtual /*final function */bool ReplaceCollectionValueByIndex(name FieldName, int ValueIndex, /*const */ref string NewValue, /*optional */bool bPersistent = default, /*optional */name CellTag = default)
	{
	
		return default;
	}
	
	public virtual /*final function */bool ClearCollectionValueArray(name FieldName, /*optional */bool bPersistent = default, /*optional */name CellTag = default)
	{
	
		return default;
	}
	
	public virtual /*final function */bool GetCollectionValue(name FieldName, int ValueIndex, ref string out_Value, /*optional */bool bPersistent = default, /*optional */name CellTag = default)
	{
	
		return default;
	}
	
	public virtual /*final function */int FindCollectionValueIndex(name FieldName, /*const */ref string ValueToFind, /*optional */bool bPersistent = default, /*optional */name CellTag = default)
	{
	
		return default;
	}
	
	public SceneDataStore()
	{
		// Object Offset:0x003B3A39
		Tag = (name)"SCENE_DATASTORE_TAG";
	}
}
}