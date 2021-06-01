namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InterpData : SequenceVariable/*
		native
		hidecategories(Object)*/{
	public float InterpLength;
	public float PathBuildTime;
	public /*export */array</*export */InterpGroup> InterpGroups;
	public /*export */InterpCurveEdSetup CurveEdSetup;
	public /*editoronly */array<InterpFilter> InterpFilters;
	public /*editoronly */InterpFilter SelectedFilter;
	public /*editoronly transient */array<InterpFilter> DefaultFilters;
	public float EdSectionStart;
	public float EdSectionEnd;
	
	public InterpData()
	{
		// Object Offset:0x00340B07
		InterpLength = 5.0f;
		DefaultFilters = new array<InterpFilter>
		{
			new InterpFilter
			{
				// Object Offset:0x0046A5C3
				Caption = "All",
			}/* Reference: InterpFilter'Default__InterpData.FilterAll' */,
			new InterpFilter_Classes
			{
				// Object Offset:0x0046A5EF
				ClassToFilterBy = ClassT<CameraActor>()/*Ref Class'CameraActor'*/,
				Caption = "Cameras",
			}/* Reference: InterpFilter_Classes'Default__InterpData.FilterCameras' */,
			new InterpFilter_Classes
			{
				// Object Offset:0x0046A63B
				ClassToFilterBy = ClassT<SkeletalMeshActor>()/*Ref Class'SkeletalMeshActor'*/,
				Caption = "Skeletal Meshes",
			}/* Reference: InterpFilter_Classes'Default__InterpData.FilterSkeletalMeshes' */,
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