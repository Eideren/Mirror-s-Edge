namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class StaticMeshActor : StaticMeshActorBase/*
		native
		placeable
		hidecategories(Navigation)*/{
	public/*()*/ /*const editconst export editinline */StaticMeshComponent StaticMeshComponent;
	public/*(Interaction)*/ /*const */float LOIProximityDelay;
	public/*(Interaction)*/ /*const */float LOILookAtDelay;
	public/*(Interaction)*/ /*const */float LOIMinDuration;
	public/*(Interaction)*/ /*const */float LOIDistance;
	public/*(Interaction)*/ /*const */Object.Vector LOIDirection;
	public/*(Interaction)*/ /*const */float LOIAngle;
	public/*(Interaction)*/ /*const */Object.Vector LOIOffset;
	public/*(Interaction)*/ /*const */bool LOIUse2DDistance;
	public/*(Baker)*/ /*const */bool bForceSlowGIForAlpha;
	public/*(Interaction)*/ /*const */array<name> LOIGroups;
	public /*private */TdLOIAddOnStaticMeshActor TdLOIAddOn;
	
	public override /*event */void PreBeginPlay()
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
	
	public StaticMeshActor()
	{
		// Object Offset:0x003EE14E
		StaticMeshComponent = new StaticMeshComponent
		{
			// Object Offset:0x00579BEA
			bAllowApproximateOcclusion = true,
			bForceDirectLightMap = true,
			bCastDynamicShadow = false,
		}/* Reference: StaticMeshComponent'Default__StaticMeshActor.StaticMeshComponent0' */;
		LOILookAtDelay = -1.0f;
		LOIMinDuration = 1.50f;
		LOIDistance = 1500.0f;
		LOIDirection = new Vector
		{
			X=0.0f,
			Y=1.0f,
			Z=0.0f
		};
		Components = new array</*export editinline */ActorComponent>
		{
			new StaticMeshComponent
			{
				// Object Offset:0x00579BEA
				bAllowApproximateOcclusion = true,
				bForceDirectLightMap = true,
				bCastDynamicShadow = false,
			}/* Reference: StaticMeshComponent'Default__StaticMeshActor.StaticMeshComponent0' */,
			new TdLOIRenderingComponent
			{
				// Object Offset:0x00579C76
				AlwaysLoadOnClient = false,
				AlwaysLoadOnServer = false,
			}/* Reference: TdLOIRenderingComponent'Default__StaticMeshActor.LOIRenderer' */,
		};
		CollisionComponent = new StaticMeshComponent
		{
			// Object Offset:0x00579BEA
			bAllowApproximateOcclusion = true,
			bForceDirectLightMap = true,
			bCastDynamicShadow = false,
		}/* Reference: StaticMeshComponent'Default__StaticMeshActor.StaticMeshComponent0' */;
	}
}
}