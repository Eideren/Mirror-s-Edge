namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SkeletalMeshActor : Actor/*
		native
		placeable
		hidecategories(Navigation)*/{
	public/*()*/ /*export editinline */SkeletalMeshComponent SkeletalMeshComponent;
	public/*()*/ /*const editconst export editinline */LightEnvironmentComponent LightEnvironment;
	public /*export editinline */AudioComponent FacialAudioComp;
	public /*repnotify */SkeletalMesh ReplicatedMesh;
	public/*(Interaction)*/ /*const */float LOILookAtDelay;
	public/*(Interaction)*/ /*const */float LOIProximityDelay;
	public/*(Interaction)*/ /*const */float LOIMinDuration;
	public/*(Interaction)*/ /*const */float LOIDistance;
	public/*(Interaction)*/ /*const */bool LOIUse2DDistance;
	public/*(Interaction)*/ /*const */array<name> LOIGroups;
	public /*private */TdLOIAddOnObject TdLOIAddOn;
	
	//replication
	//{
	//	 if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		ReplicatedMesh;
	//}
	
	public override /*event */void PostBeginPlay()
	{
	
	}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
	
	}
	
	public override TakeDamage_del TakeDamage { get => bfield_TakeDamage ?? SkeletalMeshActor_TakeDamage; set => bfield_TakeDamage = value; } TakeDamage_del bfield_TakeDamage;
	public override TakeDamage_del global_TakeDamage => SkeletalMeshActor_TakeDamage;
	public /*event */void SkeletalMeshActor_TakeDamage(int DamageAmount, Controller EventInstigator, Object.Vector HitLocation, Object.Vector Momentum, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo? _HitInfo = default, /*optional */Actor? _DamageCauser = default)
	{
	
	}
	
	public virtual /*simulated function */void OnToggle(SeqAct_Toggle Action)
	{
	
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
	
	public override /*simulated event */bool PlayActorFaceFXAnim(FaceFXAnimSet AnimSet, String GroupName, String SeqName)
	{
	
		return default;
	}
	
	public override /*simulated event */void StopActorFaceFXAnim()
	{
	
	}
	
	public override /*simulated event */AudioComponent GetFaceFXAudioComponent()
	{
	
		return default;
	}
	
	public virtual /*simulated function */void OnPlayFaceFXAnim(SeqAct_PlayFaceFXAnim inAction)
	{
	
	}
	
	public override /*simulated event */FaceFXAsset GetActorFaceFXAsset()
	{
	
		return default;
	}
	
	public override /*simulated function */bool IsActorPlayingFaceFXAnim()
	{
	
		return default;
	}
	
	public virtual /*event */void OnSetSkeletalMesh(SeqAct_SetSkeletalMesh Action)
	{
	
	}
	
	public virtual /*event */void OnSetMaterial(SeqAct_SetMaterial Action)
	{
	
	}
	
	public override /*simulated event */void ShutDown()
	{
	
	}
	
	public override /*function */void DoKismetAttachment(Actor Attachment, SeqAct_AttachToActor Action)
	{
	
	}
	
	public override /*function */void AssignPlayerToLOI(Actor Player)
	{
	
	}
	
	public override /*event */void ActivateLOI()
	{
	
	}
	
	public override /*function */void OnDeactivateLOI(SeqAct_DeactivateLOI Sender)
	{
	
	}
	
	public override /*function */void OnActivateLOI(SeqAct_ActivateLOI Sender)
	{
	
	}
	protected override void RestoreDefaultFunction()
	{
		TakeDamage = null;
	
	}
	public SkeletalMeshActor()
	{
		var Default__SkeletalMeshActor_AnimNodeSeq0 = new AnimNodeSequence
		{
		}/* Reference: AnimNodeSequence'Default__SkeletalMeshActor.AnimNodeSeq0' */;
		var Default__SkeletalMeshActor_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
			// Object Offset:0x003E7270
			bEnabled = false,
		}/* Reference: DynamicLightEnvironmentComponent'Default__SkeletalMeshActor.MyLightEnvironment' */;
		var Default__SkeletalMeshActor_SkeletalMeshComponent0 = new SkeletalMeshComponent
		{
			// Object Offset:0x003E72A4
			Animations = Default__SkeletalMeshActor_AnimNodeSeq0/*Ref AnimNodeSequence'Default__SkeletalMeshActor.AnimNodeSeq0'*/,
			bForceMeshObjectUpdates = true,
			LightEnvironment = Default__SkeletalMeshActor_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__SkeletalMeshActor.MyLightEnvironment'*/,
			CollideActors = true,
			BlockZeroExtent = true,
			RBChannel = PrimitiveComponent.ERBCollisionChannel.RBCC_GameplayPhysics,
			RBCollideWithChannels = new PrimitiveComponent.RBCollisionChannelContainer
			{
				Default = true,
				GameplayPhysics = true,
				EffectPhysics = true,
			},
		}/* Reference: SkeletalMeshComponent'Default__SkeletalMeshActor.SkeletalMeshComponent0' */;
		var Default__SkeletalMeshActor_FaceAudioComponent = new AudioComponent
		{
		}/* Reference: AudioComponent'Default__SkeletalMeshActor.FaceAudioComponent' */;
		// Object Offset:0x003E6F63
		SkeletalMeshComponent = Default__SkeletalMeshActor_SkeletalMeshComponent0/*Ref SkeletalMeshComponent'Default__SkeletalMeshActor.SkeletalMeshComponent0'*/;
		LightEnvironment = Default__SkeletalMeshActor_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__SkeletalMeshActor.MyLightEnvironment'*/;
		FacialAudioComp = Default__SkeletalMeshActor_FaceAudioComponent/*Ref AudioComponent'Default__SkeletalMeshActor.FaceAudioComponent'*/;
		LOILookAtDelay = -1.0f;
		LOIMinDuration = 1.50f;
		LOIDistance = 1500.0f;
		bNoDelete = true;
		bCollideActors = true;
		bProjTarget = true;
		bEdShouldSnap = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__SkeletalMeshActor_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__SkeletalMeshActor.MyLightEnvironment'*/,
			Default__SkeletalMeshActor_SkeletalMeshComponent0/*Ref SkeletalMeshComponent'Default__SkeletalMeshActor.SkeletalMeshComponent0'*/,
			Default__SkeletalMeshActor_FaceAudioComponent/*Ref AudioComponent'Default__SkeletalMeshActor.FaceAudioComponent'*/,
		};
		CollisionComponent = Default__SkeletalMeshActor_SkeletalMeshComponent0/*Ref SkeletalMeshComponent'Default__SkeletalMeshActor.SkeletalMeshComponent0'*/;
	}
}
}