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
	
	public/*(Mesh)*/ StaticMesh Mesh;
	public/*(Mesh)*/ bool CastShadows;
	public/*(Mesh)*/ bool DoCollisions;
	public/*(Mesh)*/ bool bOverrideMaterial;
	public/*(Mesh)*/ ParticleModuleTypeDataMesh.EMeshScreenAlignment MeshAlignment;
	
}
}