namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIPrefabInstance : UIObject/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public /*archetype const */UIPrefab SourcePrefab;
	public /*const */int PrefabInstanceVersion;
	public /*native const *//*map<0,0>*/map<object, object> ArchetypeToInstanceMap;
	public /*editoronly const */int PI_PackageVersion;
	public /*editoronly const */int PI_LicenseePackageVersion;
	public /*editoronly const */int PI_DataOffset;
	public /*editoronly const */array<byte> PI_Bytes;
	public /*editoronly const */array<Object> PI_CompleteObjects;
	public /*editoronly const */array<Object> PI_ReferencedObjects;
	public /*editoronly const */array<String> PI_SavedNames;
	public /*native const *//*map<0,0>*/map<object, object> PI_ObjectMap;
	
	// Export UUIPrefabInstance::execDetachFromSourcePrefab(FFrame&, void* const)
	public virtual /*native final function */void DetachFromSourcePrefab()
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	public UIPrefabInstance()
	{
		var Default__UIPrefabInstance_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIPrefabInstance.WidgetEventComponent' */;
		// Object Offset:0x00448439
		PI_PackageVersion = -1;
		PI_LicenseePackageVersion = -1;
		EventProvider = Default__UIPrefabInstance_WidgetEventComponent/*Ref UIComp_Event'Default__UIPrefabInstance.WidgetEventComponent'*/;
	}
}
}