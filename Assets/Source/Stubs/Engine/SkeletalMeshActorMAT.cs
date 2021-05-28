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
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshActorMAT::execMAT_SetAnimPosition(FFrame&, void* const)
	public virtual /*native function */void MAT_SetAnimPosition(name SlotName, int ChannelIndex, name InAnimSeqName, float InPosition, bool bFireNotifies, bool bLooping)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshActorMAT::execMAT_SetAnimWeights(FFrame&, void* const)
	public virtual /*native function */void MAT_SetAnimWeights(array<Actor.AnimSlotInfo> SlotInfos)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshActorMAT::execMAT_FinishAnimControl(FFrame&, void* const)
	public virtual /*native function */void MAT_FinishAnimControl()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshActorMAT::execMAT_SetMorphWeight(FFrame&, void* const)
	public virtual /*native function */void MAT_SetMorphWeight(name MorphNodeName, float MorphWeight)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshActorMAT::execMAT_SetSkelControlScale(FFrame&, void* const)
	public virtual /*native function */void MAT_SetSkelControlScale(name SkelControlName, float Scale)
	{
		#warning NATIVE FUNCTION !
	}
	
	public override /*simulated event */void BeginAnimControl(array<AnimSet> InAnimSets)
	{
	
	}
	
	public override /*simulated event */void SetAnimPosition(name SlotName, int ChannelIndex, name InAnimSeqName, float InPosition, bool bFireNotifies, bool bLooping)
	{
	
	}
	
	public override /*simulated event */void SetAnimWeights(array<Actor.AnimSlotInfo> SlotInfos)
	{
	
	}
	
	public override /*simulated event */void FinishAnimControl()
	{
	
	}
	
	public override /*event */void SetMorphWeight(name MorphNodeName, float MorphWeight)
	{
	
	}
	
	public override /*event */void SetSkelControlScale(name SkelControlName, float Scale)
	{
	
	}
	
	public SkeletalMeshActorMAT()
	{
		// Object Offset:0x003E7CE4
		SkeletalMeshComponent = new SkeletalMeshComponent
		{
			// Object Offset:0x003E7EBF
			Animations = default,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__SkeletalMeshActorMAT.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__SkeletalMeshActorMAT.MyLightEnvironment'*/,
		}/* Reference: SkeletalMeshComponent'Default__SkeletalMeshActorMAT.SkeletalMeshComponent0' */;
		LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__SkeletalMeshActorMAT.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__SkeletalMeshActorMAT.MyLightEnvironment'*/;
		FacialAudioComp = LoadAsset<AudioComponent>("Default__SkeletalMeshActorMAT.FaceAudioComponent")/*Ref AudioComponent'Default__SkeletalMeshActorMAT.FaceAudioComponent'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<DynamicLightEnvironmentComponent>("Default__SkeletalMeshActorMAT.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__SkeletalMeshActorMAT.MyLightEnvironment'*/,
			//Components[1]=
			new SkeletalMeshComponent
			{
				// Object Offset:0x003E7EBF
				Animations = default,
				LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__SkeletalMeshActorMAT.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__SkeletalMeshActorMAT.MyLightEnvironment'*/,
			}/* Reference: SkeletalMeshComponent'Default__SkeletalMeshActorMAT.SkeletalMeshComponent0' */,
			LoadAsset<AudioComponent>("Default__SkeletalMeshActorMAT.FaceAudioComponent")/*Ref AudioComponent'Default__SkeletalMeshActorMAT.FaceAudioComponent'*/,
		};
		CollisionComponent = new SkeletalMeshComponent
		{
			// Object Offset:0x003E7EBF
			Animations = default,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__SkeletalMeshActorMAT.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__SkeletalMeshActorMAT.MyLightEnvironment'*/,
		}/* Reference: SkeletalMeshComponent'Default__SkeletalMeshActorMAT.SkeletalMeshComponent0' */;
	}
}
}