namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIPrefabInstance : UIObject/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	[archetype, Const] public UIPrefab SourcePrefab;
	[Const] public int PrefabInstanceVersion;
	[native, Const] public /*map<0,0>*/map<object, object> ArchetypeToInstanceMap;
	[editoronly, Const] public int PI_PackageVersion;
	[editoronly, Const] public int PI_LicenseePackageVersion;
	[editoronly, Const] public int PI_DataOffset;
	[editoronly, Const] public array<byte> PI_Bytes;
	[editoronly, Const] public array<Object> PI_CompleteObjects;
	[editoronly, Const] public array<Object> PI_ReferencedObjects;
	[editoronly, Const] public array<String> PI_SavedNames;
	[native, Const] public /*map<0,0>*/map<object, object> PI_ObjectMap;
	
	// Export UUIPrefabInstance::execDetachFromSourcePrefab(FFrame&, void* const)
	public virtual /*native final function */void DetachFromSourcePrefab()
	{
		NativeMarkers.MarkUnimplemented();
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