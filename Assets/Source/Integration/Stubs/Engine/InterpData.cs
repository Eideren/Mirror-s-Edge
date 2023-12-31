namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InterpData : SequenceVariable/*
		native
		hidecategories(Object)*/{
	public float InterpLength;
	public float PathBuildTime;
	[export] public array</*export */InterpGroup> InterpGroups;
	[export] public InterpCurveEdSetup CurveEdSetup;
	[editoronly] public array<InterpFilter> InterpFilters;
	[editoronly] public InterpFilter SelectedFilter;
	[editoronly, transient] public array<InterpFilter> DefaultFilters;
	public float EdSectionStart;
	public float EdSectionEnd;
	
	public InterpData()
	{
		var Default__InterpData_FilterAll = new InterpFilter
		{
			// Object Offset:0x0046A5C3
			Caption = "All",
		}/* Reference: InterpFilter'Default__InterpData.FilterAll' */;
		var Default__InterpData_FilterCameras = new InterpFilter_Classes
		{
			// Object Offset:0x0046A5EF
			ClassToFilterBy = ClassT<CameraActor>()/*Ref Class'CameraActor'*/,
			Caption = "Cameras",
		}/* Reference: InterpFilter_Classes'Default__InterpData.FilterCameras' */;
		var Default__InterpData_FilterSkeletalMeshes = new InterpFilter_Classes
		{
			// Object Offset:0x0046A63B
			ClassToFilterBy = ClassT<SkeletalMeshActor>()/*Ref Class'SkeletalMeshActor'*/,
			Caption = "Skeletal Meshes",
		}/* Reference: InterpFilter_Classes'Default__InterpData.FilterSkeletalMeshes' */;
		// Object Offset:0x00340B07
		InterpLength = 5.0f;
		DefaultFilters = new array<InterpFilter>
		{
			Default__InterpData_FilterAll/*Ref InterpFilter'Default__InterpData.FilterAll'*/,
			Default__InterpData_FilterCameras/*Ref InterpFilter_Classes'Default__InterpData.FilterCameras'*/,
			Default__InterpData_FilterSkeletalMeshes/*Ref InterpFilter_Classes'Default__InterpData.FilterSkeletalMeshes'*/,
		};
		EdSectionStart = 1.0f;
		EdSectionEnd = 2.0f;
		ObjName = "Matinee Data";
		ObjColor = new Color
		{
			R=255,
			G=128,
			B=0,
			A=255
		};
	}
}
}