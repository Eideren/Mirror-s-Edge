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
	
	public /*config */array</*config */UIDataStore_StringAliasMap.UIMenuInputMap> MenuInputMapArray;
	public /*private native const transient */Object.Map_Mirror MenuInputSets;
	public /*const transient */int PlayerIndex;
	
	// Export UUIDataStore_StringAliasMap::execGetPlayerOwner(FFrame&, void* const)
	public virtual /*native final function */LocalPlayer GetPlayerOwner()
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UUIDataStore_StringAliasMap::execFindMappingWithFieldName(FFrame&, void* const)
	public virtual /*native final function */int FindMappingWithFieldName(/*optional */String? _FieldName = default, /*optional */String? _SetName = default)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UUIDataStore_StringAliasMap::execGetStringWithFieldName(FFrame&, void* const)
	public virtual /*native function */int GetStringWithFieldName(String FieldName, ref String MappedString)
	{
		 // #warning NATIVE FUNCTION !
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