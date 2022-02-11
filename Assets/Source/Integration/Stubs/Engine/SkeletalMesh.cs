namespace MEdge.Engine{
	using System.Collections.Generic;
	using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SkeletalMesh : Object/*
		native
		noexport
		hidecategories(Object)*/{
	public enum ClothBoneType 
	{
		CLOTHBONE_Fixed,
		CLOTHBONE_BreakableAttachment,
		CLOTHBONE_MAX
	};
	
	public partial struct /*native */BoneMirrorInfo
	{
		[Category] public int SourceIndex;
		[Category] public Object.EAxis BoneFlipAxis;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003E4FA3
	//		SourceIndex = 0;
	//		BoneFlipAxis = Object.EAxis.AXIS_NONE;
	//	}
	};
	
	public partial struct /*native */SkeletalMeshLODInfo
	{
		[Category] public float DisplayFactor;
		[Category] public float LODHysteresis;
		[Category] [editfixedsize] public array<int> LODMaterialMap;
		[Category] [editfixedsize] public array<bool> bEnableShadowCasting;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003E5127
	//		DisplayFactor = 0.0f;
	//		LODHysteresis = 0.0f;
	//		LODMaterialMap = default;
	//		bEnableShadowCasting = default;
	//	}
	};
	
	public partial struct /*native */ClothSpecialBoneInfo
	{
		[Category] public name BoneName;
		[Category] public SkeletalMesh.ClothBoneType BoneType;
		[Const] public array<int> AttachedVertexIndices;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003E52B7
	//		BoneName = (name)"None";
	//		BoneType = SkeletalMesh.ClothBoneType.CLOTHBONE_Fixed;
	//		AttachedVertexIndices = default;
	//	}
	};
	
	[native, Const] public Object.BoxSphereBounds Bounds;
	[Category] [native, Const] public array<MaterialInterface> Materials;
	[Category] [native, Const] public Object.Vector Origin;
	[Category] [native, Const] public Object.Rotator RotOrigin;
	[native, Const] public array<AnimNode.FMeshBone> RefSkeleton;
	[native, Const] public int SkeletalDepth;
	[native, Const] public /*map<0,0>*/Dictionary<name, int> NameIndexMap;
	[native, Const] public/*private*/ Object.IndirectArray_Mirror LODModels;
	[native, Const] public array<Object.Matrix> RefBasesInvMatrix;
	[Category] [editfixedsize] public array<SkeletalMesh.BoneMirrorInfo> SkelMirrorTable;
	[Category] public Object.EAxis SkelMirrorAxis;
	[Category] public Object.EAxis SkelMirrorFlipAxis;
	public array<SkeletalMeshSocket> Sockets;
	[Category] [editfixedsize] public array<SkeletalMesh.SkeletalMeshLODInfo> LODInfo;
	[Category] public array<name> PerPolyCollisionBones;
	[Category] public array<name> AddToParentPerPolyCollisionBone;
	[native, Const] public/*private*/ array<int> PerPolyBoneKDOPs;
	[Category] public bool bPerPolyUseSoftWeighting;
	[Category] public bool bUseSimpleLineCollision;
	[Category] public bool bUseSimpleBoxCollision;
	[Category] [Const] public bool bForceCPUSkinning;
	[Category] [Const] public bool bUseFullPrecisionUVs;
	[Category] public FaceFXAsset FaceFXAsset;
	[Category] [editoronly] public PhysicsAsset BoundsPreviewAsset;
	[Category] public int LODBiasPC;
	[Category] public int LODBiasPS3;
	[Category] public int LODBiasXbox360;
	[native, Const, transient] public array<Object.Pointer> ClothMesh;
	[native, Const, transient] public array<float> ClothMeshScale;
	[Const] public array<int> ClothToGraphicsVertMap;
	[Const] public array<int> ClothWeldingMap;
	[Const] public int ClothWeldingDomain;
	[Const] public array<int> ClothWeldedIndices;
	[Category("Cloth")] [Const] public bool bForceNoWelding;
	[Const] public int NumFreeClothVerts;
	[Const] public array<int> ClothIndexBuffer;
	[Category("Cloth")] [Const] public array<name> ClothBones;
	[Category("Cloth")] [Const] public bool bEnableClothBendConstraints;
	[Category("Cloth")] [Const] public bool bEnableClothDamping;
	[Category("Cloth")] [Const] public bool bUseClothCOMDamping;
	[Category("Cloth")] [Const] public float ClothStretchStiffness;
	[Category("Cloth")] [Const] public float ClothBendStiffness;
	[Category("Cloth")] [Const] public float ClothDensity;
	[Category("Cloth")] [Const] public float ClothThickness;
	[Category("Cloth")] [Const] public float ClothDamping;
	[Category("Cloth")] [Const] public int ClothIterations;
	[Category("Cloth")] [Const] public float ClothFriction;
	[Category("Cloth")] [Const] public float ClothRelativeGridSpacing;
	[Category("Cloth")] [Const] public float ClothPressure;
	[Category("Cloth")] [Const] public float ClothCollisionResponseCoefficient;
	[Category("Cloth")] [Const] public float ClothAttachmentResponseCoefficient;
	[Category("Cloth")] [Const] public float ClothAttachmentTearFactor;
	[Category("Cloth")] [Const] public float ClothSleepLinearVelocity;
	[Category("Cloth")] [Const] public bool bEnableClothOrthoBendConstraints;
	[Category("Cloth")] [Const] public bool bEnableClothSelfCollision;
	[Category("Cloth")] [Const] public bool bEnableClothPressure;
	[Category("Cloth")] [Const] public bool bEnableClothTwoWayCollision;
	[Category("Cloth")] [Const] public array<SkeletalMesh.ClothSpecialBoneInfo> ClothSpecialBones;
	[Category("Cloth")] [Const] public bool bEnableClothLineChecks;
	[Category("Cloth")] [Const] public bool bClothMetal;
	[Category("Cloth")] [Const] public float ClothMetalImpulseThreshold;
	[Category("Cloth")] [Const] public float ClothMetalPenetrationDepth;
	[Category("Cloth")] [Const] public float ClothMetalMaxDeformationDistance;
	[Category("Cloth")] [Const] public bool bEnableClothTearing;
	[Category("Cloth")] [Const] public float ClothTearFactor;
	[Category("Cloth")] [Const] public int ClothTearReserve;
	[native, Const] public Object.Map_Mirror ClothTornTriMap;
	[native, Const] public array<bool> GraphicsIndexIsCloth;
	[native, Const, transient] public int ReleaseResourcesFence;
	[Const] public Object.Guid SkelMeshGUID;
	[Category] [editconst] public int NumUVSets;
	[transient] public bool bDeferredProcessing;
	
	public SkeletalMesh()
	{
		// Object Offset:0x003E534B
		SkelMirrorAxis = Object.EAxis.AXIS_X;
		SkelMirrorFlipAxis = Object.EAxis.AXIS_Z;
		bUseSimpleLineCollision = true;
		bUseSimpleBoxCollision = true;
		ClothStretchStiffness = 1.0f;
		ClothBendStiffness = 1.0f;
		ClothDensity = 1.0f;
		ClothThickness = 0.50f;
		ClothDamping = 0.50f;
		ClothIterations = 5;
		ClothFriction = 0.50f;
		ClothRelativeGridSpacing = 1.0f;
		ClothPressure = 1.0f;
		ClothCollisionResponseCoefficient = 0.20f;
		ClothAttachmentResponseCoefficient = 0.20f;
		ClothAttachmentTearFactor = 1.50f;
		ClothSleepLinearVelocity = -1.0f;
		ClothMetalImpulseThreshold = 10.0f;
		ClothTearFactor = 3.50f;
		ClothTearReserve = 128;
	}
}
}