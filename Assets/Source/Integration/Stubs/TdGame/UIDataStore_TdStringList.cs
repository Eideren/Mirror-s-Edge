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
		[Const, localized] public String ColumnHeaderText;
		public String CurrentValue;
		public int DefaultValueIndex;
		[Const, localized] public array</*localized */String> Strings;
		[transient] public UIDataProvider_TdStringArray DataProvider;
	
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
	
	[native, Const, noexport] public/*private*/ Object.Pointer VfTable_IUIListElementProvider;
	[native, Const, noexport] public/*private*/ Object.Pointer VfTable_IUIListElementCellProvider;
	[config] public array</*config */UIDataStore_TdStringList.EStringListData> StringData;
	
	public override /*event */void Registered(LocalPlayer PlayerOwner)
	{
		// stub
	}
	
	// Export UUIDataStore_TdStringList::execGetFieldIndex(FFrame&, void* const)
	public virtual /*native function */int GetFieldIndex(name FieldName)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_TdStringList::execAddStr(FFrame&, void* const)
	public virtual /*native function */void AddStr(name FieldName, String NewString, /*optional */bool? _bBatchOp = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIDataStore_TdStringList::execInsertStr(FFrame&, void* const)
	public virtual /*native function */void InsertStr(name FieldName, String NewString, int InsertIndex, /*optional */bool? _bBatchOp = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIDataStore_TdStringList::execRemoveStr(FFrame&, void* const)
	public virtual /*native function */void RemoveStr(name FieldName, String StringToRemove, /*optional */bool? _bBatchOp = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIDataStore_TdStringList::execRemoveStrByIndex(FFrame&, void* const)
	public virtual /*native function */void RemoveStrByIndex(name FieldName, int Index, /*optional */int? _Count = default, /*optional */bool? _bBatchOp = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIDataStore_TdStringList::execEmpty(FFrame&, void* const)
	public virtual /*native function */void Empty(name FieldName, /*optional */bool? _bBatchOp = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIDataStore_TdStringList::execFindStr(FFrame&, void* const)
	public virtual /*native function */int FindStr(name FieldName, String SearchString)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_TdStringList::execGetStr(FFrame&, void* const)
	public virtual /*native function */String GetStr(name FieldName, int StrIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_TdStringList::execGetList(FFrame&, void* const)
	public virtual /*native function */array<String> GetList(name FieldName)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*event */bool GetCurrentValue(name FieldName, ref String out_Value)
	{
		// stub
		return default;
	}
	
	public virtual /*event */int GetCurrentValueIndex(name FieldName)
	{
		// stub
		return default;
	}
	
	public virtual /*event */int SetCurrentValueIndex(name FieldName, int NewValueIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*event */int Num(name FieldName)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void ResetValueIndex(name FieldName)
	{
		// stub
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
				Strings = new array</*localized */String>
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
				Strings = new array</*localized */String>
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
				Strings = new array</*localized */String>
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
				Strings = new array</*localized */String>
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
				Strings = new array</*localized */String>
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
				Strings = new array</*localized */String>
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
				Strings = new array</*localized */String>
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
				Strings = new array</*localized */String>
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
				Strings = new array</*localized */String>
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