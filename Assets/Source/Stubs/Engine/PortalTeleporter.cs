namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PortalTeleporter : SceneCapturePortalActor/*
		abstract
		native
		notplaceable
		hidecategories(Navigation)*/{
	public/*()*/ PortalTeleporter SisterPortal;
	public/*()*/ int TextureResolutionX;
	public/*()*/ int TextureResolutionY;
	public PortalMarker MyMarker;
	public/*()*/ bool bMovablePortal;
	public bool bAlwaysTeleportNonPawns;
	public bool bCanTeleportVehicles;
	
	// Export UPortalTeleporter::execTransformActor(FFrame&, void* const)
	public virtual /*native final function */bool TransformActor(Actor A)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UPortalTeleporter::execTransformVectorDir(FFrame&, void* const)
	public virtual /*native final function */Object.Vector TransformVectorDir(Object.Vector V)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UPortalTeleporter::execTransformHitLocation(FFrame&, void* const)
	public virtual /*native final function */Object.Vector TransformHitLocation(Object.Vector HitLocation)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UPortalTeleporter::execCreatePortalTexture(FFrame&, void* const)
	public virtual /*native final function */TextureRenderTarget2D CreatePortalTexture()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override /*simulated function */bool StopsProjectile(Projectile P)
	{
	
		return default;
	}
	
	public PortalTeleporter()
	{
		var Default__PortalTeleporter_StaticMeshComponent2 = new StaticMeshComponent
		{
			// Object Offset:0x0057990E
			HiddenGame = false,
			CollideActors = true,
		}/* Reference: StaticMeshComponent'Default__PortalTeleporter.StaticMeshComponent2' */;
		var Default__PortalTeleporter_SceneCapturePortalComponent0 = new SceneCapturePortalComponent
		{
		}/* Reference: SceneCapturePortalComponent'Default__PortalTeleporter.SceneCapturePortalComponent0' */;
		var Default__PortalTeleporter_StaticMeshComponent1 = new StaticMeshComponent
		{
		}/* Reference: StaticMeshComponent'Default__PortalTeleporter.StaticMeshComponent1' */;
		// Object Offset:0x003A40CF
		TextureResolutionX = 256;
		TextureResolutionY = 256;
		bAlwaysTeleportNonPawns = true;
		StaticMesh = Default__PortalTeleporter_StaticMeshComponent2/*Ref StaticMeshComponent'Default__PortalTeleporter.StaticMeshComponent2'*/;
		SceneCapture = Default__PortalTeleporter_SceneCapturePortalComponent0/*Ref SceneCapturePortalComponent'Default__PortalTeleporter.SceneCapturePortalComponent0'*/;
		bWorldGeometry = true;
		bMovable = false;
		bCollideActors = true;
		bBlockActors = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__PortalTeleporter_SceneCapturePortalComponent0/*Ref SceneCapturePortalComponent'Default__PortalTeleporter.SceneCapturePortalComponent0'*/,
			Default__PortalTeleporter_StaticMeshComponent1/*Ref StaticMeshComponent'Default__PortalTeleporter.StaticMeshComponent1'*/,
			Default__PortalTeleporter_StaticMeshComponent2/*Ref StaticMeshComponent'Default__PortalTeleporter.StaticMeshComponent2'*/,
		};
		CollisionComponent = Default__PortalTeleporter_StaticMeshComponent2/*Ref StaticMeshComponent'Default__PortalTeleporter.StaticMeshComponent2'*/;
	}
}
}