namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataStore_StringAliasMap : UIDataStore/*
		transient
		native
		config(Game)
		hidecategories(Object,UIRoot)*/{
	public partial struct /*native */UIMenuInputMap
	{
		public name FieldName;
		public name Set;
		public String MappedText;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0042CC3C
	//		FieldName = (name)"None";
	//		Set = (name)"None";
	//		MappedText = "";
	//	}
	};
	
	[config] public array</*config */UIDataStore_StringAliasMap.UIMenuInputMap> MenuInputMapArray;
	[native, Const, transient] public/*private*/ Object.Map_Mirror MenuInputSets;
	[Const, transient] public int PlayerIndex;
	
	// Export UUIDataStore_StringAliasMap::execGetPlayerOwner(FFrame&, void* const)
	public virtual /*native final function */LocalPlayer GetPlayerOwner()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_StringAliasMap::execFindMappingWithFieldName(FFrame&, void* const)
	public virtual /*native final function */int FindMappingWithFieldName(/*optional */String? _FieldName = default, /*optional */String? _SetName = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_StringAliasMap::execGetStringWithFieldName(FFrame&, void* const)
	public virtual /*native function */int GetStringWithFieldName(String FieldName, ref String MappedString)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public UIDataStore_StringAliasMap()
	{
		// Object Offset:0x0042CF5F
		PlayerIndex = -1;
		Tag = (name)"StringAliasMap";
	}
}
}