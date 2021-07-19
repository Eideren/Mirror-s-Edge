namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleLocationEmitter : ParticleModuleLocationBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public enum ELocationEmitterSelectionMethod 
	{
		ELESM_Random,
		ELESM_Sequential,
		ELESM_MAX
	};
	
	[Category("Location")] [noclear, export] public name EmitterName;
	[Category("Location")] public ParticleModuleLocationEmitter.ELocationEmitterSelectionMethod SelectionMethod;
	[Category("Location")] public bool InheritSourceVelocity;
	[Category("Location")] public bool bInheritSourceRotation;
	[Category("Location")] public float InheritSourceVelocityScale;
	[Category("Location")] public float InheritSourceRotationScale;
	
	public ParticleModuleLocationEmitter()
	{
		// Object Offset:0x0037E51C
		InheritSourceVelocityScale = 1.0f;
		InheritSourceRotationScale = 1.0f;
		bSpawnModule = true;
	}
}
}