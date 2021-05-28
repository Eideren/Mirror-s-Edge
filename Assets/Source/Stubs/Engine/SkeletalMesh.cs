namespace MEdge.Engine{
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
		public/*()*/ int SourceIndex;
		public/*()*/ Object.EAxis BoneFlipAxis;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003E4FA3
	//		SourceIndex = 0;
	//		BoneFlipAxis = Object.EAxis.AXIS_NONE;
	//	}
	};
	
	public partial struct /*native */SkeletalMeshLODInfo
	{
		public/*()*/ float DisplayFactor;
		public/*()*/ float LODHysteresis;
		public/*()*/ /*editfixedsize */array<int> LODMaterialMap;
		public/*()*/ /*editfixedsize */array<bool> bEnableShadowCasting;
	
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
		public/*()*/ name BoneName;
		public/*()*/ SkeletalMesh.ClothBoneType BoneType;
		public /*const */array<int> AttachedVertexIndices;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003E52B7
	//		BoneName = (name)"None";
	//		BoneType = SkeletalMesh.ClothBoneType.CLOTHBONE_Fixed;
	//		AttachedVertexIndices = default;
	//	}
	};
	
	public /*native const */Object.BoxSphereBounds Bounds;
	public/*()*/ /*native const */array<MaterialInterface> Materials;
	public/*()*/ /*native const */Object.Vector Origin;
	public/*()*/ /*native const */Object.Rotator RotOrigin;
	public /*native const */array<int> RefSkeleton;
	public /*native const */int SkeletalDepth;
	public /*native const *//*map<0,0>*/map<object, object> NameIndexMap;
	public /*private native const */Object.IndirectArray_Mirror LODModels;
	public /*native const */array<Object.Matrix> RefBasesInvMatrix;
	public/*()*/ /*editfixedsize */array<SkeletalMesh.BoneMirrorInfo> SkelMirrorTable;
	public/*()*/ Object.EAxis SkelMirrorAxis;
	public/*()*/ Object.EAxis SkelMirrorFlipAxis;
	public array<SkeletalMeshSocket> Sockets;
	public/*()*/ /*editfixedsize */array<SkeletalMesh.SkeletalMeshLODInfo> LODInfo;
	public/*()*/ array<name> PerPolyCollisionBones;
	public/*()*/ array<name> AddToParentPerPolyCollisionBone;
	public /*private native const */array<int> PerPolyBoneKDOPs;
	public/*()*/ bool bPerPolyUseSoftWeighting;
	public/*()*/ bool bUseSimpleLineCollision;
	public/*()*/ bool bUseSimpleBoxCollision;
	public/*()*/ /*const */bool bForceCPUSkinning;
	public/*()*/ /*const */bool bUseFullPrecisionUVs;
	public/*()*/ FaceFXAsset FaceFXAsset;
	public/*()*/ /*editoronly */PhysicsAsset BoundsPreviewAsset;
	public/*()*/ int LODBiasPC;
	public/*()*/ int LODBiasPS3;
	public/*()*/ int LODBiasXbox360;
	public /*native const transient */array<Object.Pointer> ClothMesh;
	public /*native const transient */array<float> ClothMeshScale;
	public /*const */array<int> ClothToGraphicsVertMap;
	public /*const */array<int> ClothWeldingMap;
	public /*const */int ClothWeldingDomain;
	public /*const */array<int> ClothWeldedIndices;
	public/*(Cloth)*/ /*const */bool bForceNoWelding;
	public /*const */int NumFreeClothVerts;
	public /*const */array<int> ClothIndexBuffer;
	public/*(Cloth)*/ /*const */array<name> ClothBones;
	public/*(Cloth)*/ /*const */bool bEnableClothBendConstraints;
	public/*(Cloth)*/ /*const */bool bEnableClothDamping;
	public/*(Cloth)*/ /*const */bool bUseClothCOMDamping;
	public/*(Cloth)*/ /*const */float ClothStretchStiffness;
	public/*(Cloth)*/ /*const */float ClothBendStiffness;
	public/*(Cloth)*/ /*const */float ClothDensity;
	public/*(Cloth)*/ /*const */float ClothThickness;
	public/*(Cloth)*/ /*const */float ClothDamping;
	public/*(Cloth)*/ /*const */int ClothIterations;
	public/*(Cloth)*/ /*const */float ClothFriction;
	public/*(Cloth)*/ /*const */float ClothRelativeGridSpacing;
	public/*(Cloth)*/ /*const */float ClothPressure;
	public/*(Cloth)*/ /*const */float ClothCollisionResponseCoefficient;
	public/*(Cloth)*/ /*const */float ClothAttachmentResponseCoefficient;
	public/*(Cloth)*/ /*const */float ClothAttachmentTearFactor;
	public/*(Cloth)*/ /*const */float ClothSleepLinearVelocity;
	public/*(Cloth)*/ /*const */bool bEnableClothOrthoBendConstraints;
	public/*(Cloth)*/ /*const */bool bEnableClothSelfCollision;
	public/*(Cloth)*/ /*const */bool bEnableClothPressure;
	public/*(Cloth)*/ /*const */bool bEnableClothTwoWayCollision;
	public/*(Cloth)*/ /*const */array<SkeletalMesh.ClothSpecialBoneInfo> ClothSpecialBones;
	public/*(Cloth)*/ /*const */bool bEnableClothLineChecks;
	public/*(Cloth)*/ /*const */bool bClothMetal;
	public/*(Cloth)*/ /*const */float ClothMetalImpulseThreshold;
	public/*(Cloth)*/ /*const */float ClothMetalPenetrationDepth;
	public/*(Cloth)*/ /*const */float ClothMetalMaxDeformationDistance;
	public/*(Cloth)*/ /*const */bool bEnableClothTearing;
	public/*(Cloth)*/ /*const */float ClothTearFactor;
	public/*(Cloth)*/ /*const */int ClothTearReserve;
	public /*native const */Object.Map_Mirror ClothTornTriMap;
	public /*native const */array<bool> GraphicsIndexIsCloth;
	public /*native const transient */int ReleaseResourcesFence;
	public /*const */Object.Guid SkelMeshGUID;
	public/*()*/ /*editconst */int NumUVSets;
	public /*transient */bool bDeferredProcessing;
	
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