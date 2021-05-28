namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataStore_TdStringList : UIDataStore, 
		UIListElementProvider,UIListElementCellProvider/*
		transient
		native
		config(Game)
		hidecategories(Object,UIRoot)*/{
	public const int INVALIDFIELD = -1;
	
	public partial struct /*native */EStringListData
	{
		public name Tag;
		public /*const localized */string ColumnHeaderText;
		public string CurrentValue;
		public int DefaultValueIndex;
		public /*const localized */array</*localized */string> Strings;
		public /*transient */UIDataProvider_TdStringArray DataProvider;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x006E4554
	//		Tag = (name)"None";
	//		ColumnHeaderText = "";
	//		CurrentValue = "";
	//		DefaultValueIndex = 0;
	//		Strings = default;
	//		DataProvider = default;
	//	}
	};
	
	public /*private native const noexport */Object.Pointer VfTable_IUIListElementProvider;
	public /*private native const noexport */Object.Pointer VfTable_IUIListElementCellProvider;
	public /*config */array</*config */UIDataStore_TdStringList.EStringListData> StringData;
	
	public override /*event */void Registered(LocalPlayer PlayerOwner)
	{
	
	}
	
	// Export UUIDataStore_TdStringList::execGetFieldIndex(FFrame&, void* const)
	public virtual /*native function */int GetFieldIndex(name FieldName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDataStore_TdStringList::execAddStr(FFrame&, void* const)
	public virtual /*native function */void AddStr(name FieldName, string NewString, /*optional */bool bBatchOp = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIDataStore_TdStringList::execInsertStr(FFrame&, void* const)
	public virtual /*native function */void InsertStr(name FieldName, string NewString, int InsertIndex, /*optional */bool bBatchOp = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIDataStore_TdStringList::execRemoveStr(FFrame&, void* const)
	public virtual /*native function */void RemoveStr(name FieldName, string StringToRemove, /*optional */bool bBatchOp = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIDataStore_TdStringList::execRemoveStrByIndex(FFrame&, void* const)
	public virtual /*native function */void RemoveStrByIndex(name FieldName, int Index, /*optional */int Count = default, /*optional */bool bBatchOp = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIDataStore_TdStringList::execEmpty(FFrame&, void* const)
	public virtual /*native function */void Empty(name FieldName, /*optional */bool bBatchOp = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIDataStore_TdStringList::execFindStr(FFrame&, void* const)
	public virtual /*native function */int FindStr(name FieldName, string SearchString)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDataStore_TdStringList::execGetStr(FFrame&, void* const)
	public virtual /*native function */string GetStr(name FieldName, int StrIndex)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIDataStore_TdStringList::execGetList(FFrame&, void* const)
	public virtual /*native function */array<string> GetList(name FieldName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*event */bool GetCurrentValue(name FieldName, ref string out_Value)
	{
	
		return default;
	}
	
	public virtual /*event */int GetCurrentValueIndex(name FieldName)
	{
	
		return default;
	}
	
	public virtual /*event */int SetCurrentValueIndex(name FieldName, int NewValueIndex)
	{
	
		return default;
	}
	
	public virtual /*event */int Num(name FieldName)
	{
	
		return default;
	}
	
	public virtual /*function */void ResetValueIndex(name FieldName)
	{
	
	}
	
	public UIDataStore_TdStringList()
	{
		// Object Offset:0x006E5524
		StringData = new array</*config */UIDataStore_TdStringList.EStringListData>
		{
			new UIDataStore_TdStringList.EStringListData
			{
				Tag = (name)"Fullscreen",
				ColumnHeaderText = "Fullscreen",
				CurrentValue = "",
				DefaultValueIndex = 1,
				Strings = new array</*localized */string>
				{
					"FULLSCREEN",
					"WINDOWED",
				},
				DataProvider = default,
			},
			new UIDataStore_TdStringList.EStringListData
			{
				Tag = (name)"ScreenResolution",
				ColumnHeaderText = "Resolution",
				CurrentValue = "",
				DefaultValueIndex = 0,
				Strings = new array</*localized */string>
				{
					"800x600",
					"960x720",
					"1024x768",
					"1280x720",
					"1600x1200",
				},
				DataProvider = default,
			},
			new UIDataStore_TdStringList.EStringListData
			{
				Tag = (name)"VSync",
				ColumnHeaderText = "VSync",
				CurrentValue = "",
				DefaultValueIndex = 0,
				Strings = new array</*localized */string>
				{
					"OFF",
					"ON",
				},
				DataProvider = default,
			},
			new UIDataStore_TdStringList.EStringListData
			{
				Tag = (name)"TextureDetail",
				ColumnHeaderText = "TextureDetail",
				CurrentValue = "",
				DefaultValueIndex = 2,
				Strings = new array</*localized */string>
				{
					"LOWEST",
					"LOW",
					"MEDIUM",
					"HIGH",
					"HIGHEST",
				},
				DataProvider = default,
			},
			new UIDataStore_TdStringList.EStringListData
			{
				Tag = (name)"GraphicsQuality",
				ColumnHeaderText = "GraphicsQuality",
				CurrentValue = "",
				DefaultValueIndex = 2,
				Strings = new array</*localized */string>
				{
					"LOWEST",
					"LOW",
					"MEDIUM",
					"HIGH",
					"HIGHEST",
				},
				DataProvider = default,
			},
			new UIDataStore_TdStringList.EStringListData
			{
				Tag = (name)"AudioDevices",
				ColumnHeaderText = "AudioDevices",
				CurrentValue = "",
				DefaultValueIndex = 0,
				Strings = new array</*localized */string>
				{
					"HARDWARE",
					"GENERIC SOFTWARE",
				},
				DataProvider = default,
			},
			new UIDataStore_TdStringList.EStringListData
			{
				Tag = (name)"TTCompareData",
				ColumnHeaderText = "TTCompareData",
				CurrentValue = "",
				DefaultValueIndex = 0,
				Strings = new array</*localized */string>
				{
					"TARGET TIME",
					"WORLD'S BEST",
					"PLAYER BEST",
					"FRIEND'S BEST",
				},
				DataProvider = default,
			},
			new UIDataStore_TdStringList.EStringListData
			{
				Tag = (name)"Antialiasing",
				ColumnHeaderText = "Antialiasing",
				CurrentValue = "",
				DefaultValueIndex = 0,
				Strings = new array</*localized */string>
				{
					"OFF",
				},
				DataProvider = default,
			},
			new UIDataStore_TdStringList.EStringListData
			{
				Tag = (name)"PhysXSupport",
				ColumnHeaderText = "PhysXSupport",
				CurrentValue = "",
				DefaultValueIndex = 0,
				Strings = new array</*localized */string>
				{
					"OFF",
					"ON",
				},
				DataProvider = default,
			},
		};
		Tag = (name)"TdStringList";
		WriteAccessType = UIDataProvider.EProviderAccessType.ACCESS_WriteAll;
	}
}
}