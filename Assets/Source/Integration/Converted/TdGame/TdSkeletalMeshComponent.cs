namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSkeletalMeshComponent : SkeletalMeshComponent/*
		native
		editinlinenew
		hidecategories(Object)*/{
	[Category] public float FOV;
	
	// Export UTdSkeletalMeshComponent::execDrawAnims(FFrame&, void* const)
	public virtual /*native final function */void DrawAnims(Canvas Canvas, name StartingPoint)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UTdSkeletalMeshComponent::execDrawAnimsWeight(FFrame&, void* const)
	public virtual /*native final function */void DrawAnimsWeight(Canvas Canvas, name StartingPoint)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UTdSkeletalMeshComponent::execFlushAnimSequenceTimeLine(FFrame&, void* const)
	public virtual /*native final function */void FlushAnimSequenceTimeLine()
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UTdSkeletalMeshComponent::execFlushAnimSequenceWeightBoxes(FFrame&, void* const)
	public virtual /*native final function */void FlushAnimSequenceWeightBoxes()
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UTdSkeletalMeshComponent::execIsChildBoneOf(FFrame&, void* const)
	public virtual /*native final function */bool IsChildBoneOf(name BoneName, name ParentBoneName)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UTdSkeletalMeshComponent::execGetPhysicalMaterialFromBone(FFrame&, void* const)
	public virtual /*native final function */PhysicalMaterial GetPhysicalMaterialFromBone(name BoneName)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
}
}