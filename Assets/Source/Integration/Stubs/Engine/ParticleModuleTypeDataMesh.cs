namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleTypeDataMesh : ParticleModuleTypeDataBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public enum EMeshScreenAlignment 
	{
		PSMA_MeshFaceCameraWithRoll,
		PSMA_MeshFaceCameraWithSpin,
		PSMA_MeshFaceCameraWithLockedAxis,
		PSMA_MAX
	};
	
	[Category("Mesh")] public StaticMesh Mesh;
	[Category("Mesh")] public bool CastShadows;
	[Category("Mesh")] public bool DoCollisions;
	[Category("Mesh")] public bool bOverrideMaterial;
	[Category("Mesh")] public ParticleModuleTypeDataMesh.EMeshScreenAlignment MeshAlignment;
	
}
}