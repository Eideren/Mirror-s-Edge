namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SkeletalMeshActorMAT : SkeletalMeshActor/*
		native
		placeable
		hidecategories(Navigation)*/{
	public /*transient */array<AnimNodeSlot> SlotNodes;
	
	// Export USkeletalMeshActorMAT::execMAT_BeginAnimControl(FFrame&, void* const)
	public virtual /*native function */void MAT_BeginAnimControl(array<AnimSet> InAnimSets)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export USkeletalMeshActorMAT::execMAT_SetAnimPosition(FFrame&, void* const)
	public virtual /*native function */void MAT_SetAnimPosition(name SlotName, int ChannelIndex, name InAnimSeqName, float InPosition, bool bFireNotifies, bool bLooping)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export USkeletalMeshActorMAT::execMAT_SetAnimWeights(FFrame&, void* const)
	public virtual /*native function */void MAT_SetAnimWeights(array<Actor.AnimSlotInfo> SlotInfos)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export USkeletalMeshActorMAT::execMAT_FinishAnimControl(FFrame&, void* const)
	public virtual /*native function */void MAT_FinishAnimControl()
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export USkeletalMeshActorMAT::execMAT_SetMorphWeight(FFrame&, void* const)
	public virtual /*native function */void MAT_SetMorphWeight(name MorphNodeName, float MorphWeight)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export USkeletalMeshActorMAT::execMAT_SetSkelControlScale(FFrame&, void* const)
	public virtual /*native function */void MAT_SetSkelControlScale(name SkelControlName, float Scale)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	public override /*simulated event */void BeginAnimControl(array<AnimSet> InAnimSets)
	{
		// stub
	}
	
	public override /*simulated event */void SetAnimPosition(name SlotName, int ChannelIndex, name InAnimSeqName, float InPosition, bool bFireNotifies, bool bLooping)
	{
		// stub
	}
	
	public override /*simulated event */void SetAnimWeights(array<Actor.AnimSlotInfo> SlotInfos)
	{
		// stub
	}
	
	public override /*simulated event */void FinishAnimControl()
	{
		// stub
	}
	
	public override /*event */void SetMorphWeight(name MorphNodeName, float MorphWeight)
	{
		// stub
	}
	
	public override /*event */void SetSkelControlScale(name SkelControlName, float Scale)
	{
		// stub
	}
	
	public SkeletalMeshActorMAT()
	{
		var Default__SkeletalMeshActorMAT_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__SkeletalMeshActorMAT.MyLightEnvironment' */;
		var Default__SkeletalMeshActorMAT_SkeletalMeshComponent0 = new SkeletalMeshComponent
		{
			// Object Offset:0x003E7EBF
			Animations = default,
			LightEnvironment = Default__SkeletalMeshActorMAT_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__SkeletalMeshActorMAT.MyLightEnvironment'*/,
		}/* Reference: SkeletalMeshComponent'Default__SkeletalMeshActorMAT.SkeletalMeshComponent0' */;
		var Default__SkeletalMeshActorMAT_FaceAudioComponent = new AudioComponent
		{
		}/* Reference: AudioComponent'Default__SkeletalMeshActorMAT.FaceAudioComponent' */;
		// Object Offset:0x003E7CE4
		SkeletalMeshComponent = Default__SkeletalMeshActorMAT_SkeletalMeshComponent0/*Ref SkeletalMeshComponent'Default__SkeletalMeshActorMAT.SkeletalMeshComponent0'*/;
		LightEnvironment = Default__SkeletalMeshActorMAT_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__SkeletalMeshActorMAT.MyLightEnvironment'*/;
		FacialAudioComp = Default__SkeletalMeshActorMAT_FaceAudioComponent/*Ref AudioComponent'Default__SkeletalMeshActorMAT.FaceAudioComponent'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__SkeletalMeshActorMAT_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__SkeletalMeshActorMAT.MyLightEnvironment'*/,
			Default__SkeletalMeshActorMAT_SkeletalMeshComponent0/*Ref SkeletalMeshComponent'Default__SkeletalMeshActorMAT.SkeletalMeshComponent0'*/,
			Default__SkeletalMeshActorMAT_FaceAudioComponent/*Ref AudioComponent'Default__SkeletalMeshActorMAT.FaceAudioComponent'*/,
		};
		CollisionComponent = Default__SkeletalMeshActorMAT_SkeletalMeshComponent0/*Ref SkeletalMeshComponent'Default__SkeletalMeshActorMAT.SkeletalMeshComponent0'*/;
	}
}
}