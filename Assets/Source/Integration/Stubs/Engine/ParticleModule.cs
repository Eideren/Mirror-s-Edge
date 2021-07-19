namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModule : Object/*
		abstract
		native
		editinlinenew
		hidecategories(Object)*/{
	public enum EModuleType 
	{
		EPMT_General,
		EPMT_TypeData,
		EPMT_Beam,
		EPMT_Trail,
		EPMT_Spawn,
		EPMT_Required,
		EPMT_MAX
	};
	
	public enum EParticleSourceSelectionMethod 
	{
		EPSSM_Random,
		EPSSM_Sequential,
		EPSSM_MAX
	};
	
	public partial struct /*native transient */ParticleCurvePair
	{
		[init] public String CurveName;
		[init] public Object CurveObject;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003786F0
	//		CurveName = "";
	//		CurveObject = default;
	//	}
	};
	
	public bool bSpawnModule;
	public bool bUpdateModule;
	public bool bCurvesAsColor;
	[Category("Cascade")] public bool b3DDrawMode;
	public bool bSupported3DDrawMode;
	public bool bEnabled;
	public bool bEditable;
	public bool LODDuplicate;
	[Category("Cascade")] public Object.Color ModuleEditorColor;
	[Const] public byte LODValidity;
	public array<name> IdenticalIgnoreProperties;
	
	public ParticleModule()
	{
		// Object Offset:0x003789D0
		bEnabled = true;
		bEditable = true;
		LODDuplicate = true;
		IdenticalIgnoreProperties = new array<name>
		{
			(name)"bSpawnModule",
			(name)"bUpdateModule",
			(name)"bCurvesAsColor",
			(name)"b3DDrawMode",
			(name)"bSupported3DDrawMode",
			(name)"bEditable",
			(name)"ModuleEditorColor",
			(name)"IdenticalIgnoreProperties",
			(name)"LODValidity",
		};
	}
}
}