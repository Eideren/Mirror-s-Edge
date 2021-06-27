namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PhATSkeletalMeshComponent : SkeletalMeshComponent/*
		native
		editinlinenew
		hidecategories(Object)*/{
	public /*native const transient */Object.Pointer PhATPtr;
	public /*native const transient */array<Object.Matrix> AnimationSpaceBases;
	
	public PhATSkeletalMeshComponent()
	{
		var Default__PhATSkeletalMeshComponent_AnimNodeSeq0 = new AnimNodeSequence
		{
			// Object Offset:0x0003137B
			bLooping = true,
		}/* Reference: AnimNodeSequence'Default__PhATSkeletalMeshComponent.AnimNodeSeq0' */;
		// Object Offset:0x0002794A
		Animations = Default__PhATSkeletalMeshComponent_AnimNodeSeq0/*Ref AnimNodeSequence'Default__PhATSkeletalMeshComponent.AnimNodeSeq0'*/;
		PhysicsWeight = 1.0f;
		ForcedLodModel = 1;
		bHasPhysicsAssetInstance = true;
		bUpdateJointsFromAnimation = true;
		RBCollideWithChannels = new PrimitiveComponent.RBCollisionChannelContainer
		{
			Default = true,
		};
	}
}
}