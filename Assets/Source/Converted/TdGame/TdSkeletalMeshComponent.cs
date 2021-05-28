namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSkeletalMeshComponent : SkeletalMeshComponent/*
		native
		editinlinenew
		hidecategories(Object)*/{
	public/*()*/ float FOV;
	
	// Export UTdSkeletalMeshComponent::execDrawAnims(FFrame&, void* const)
	public virtual /*native final function */void DrawAnims(Canvas Canvas, name StartingPoint)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdSkeletalMeshComponent::execDrawAnimsWeight(FFrame&, void* const)
	public virtual /*native final function */void DrawAnimsWeight(Canvas Canvas, name StartingPoint)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdSkeletalMeshComponent::execFlushAnimSequenceTimeLine(FFrame&, void* const)
	public virtual /*native final function */void FlushAnimSequenceTimeLine()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdSkeletalMeshComponent::execFlushAnimSequenceWeightBoxes(FFrame&, void* const)
	public virtual /*native final function */void FlushAnimSequenceWeightBoxes()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdSkeletalMeshComponent::execIsChildBoneOf(FFrame&, void* const)
	public virtual /*native final function */bool IsChildBoneOf(name BoneName, name ParentBoneName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdSkeletalMeshComponent::execGetPhysicalMaterialFromBone(FFrame&, void* const)
	public virtual /*native final function */PhysicalMaterial GetPhysicalMaterialFromBone(name BoneName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
}
}