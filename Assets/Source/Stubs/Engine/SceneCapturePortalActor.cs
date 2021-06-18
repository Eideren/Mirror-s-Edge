namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SceneCapturePortalActor : SceneCaptureReflectActor/*
		native
		placeable
		hidecategories(Navigation)*/{
	public SceneCapturePortalActor()
	{
		var Default__SceneCapturePortalActor_StaticMeshComponent2 = new StaticMeshComponent
		{
			// Object Offset:0x003A3BD4
			StaticMesh = LoadAsset<StaticMesh>("EditorMeshes.TexPropPlane")/*Ref StaticMesh'EditorMeshes.TexPropPlane'*/,
			HiddenGame = true,
			CastShadow = false,
			CollideActors = false,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: StaticMeshComponent'Default__SceneCapturePortalActor.StaticMeshComponent2' */;
		var Default__SceneCapturePortalActor_StaticMeshComponent1 = new StaticMeshComponent
		{
			// Object Offset:0x003A3AC8
			StaticMesh = LoadAsset<StaticMesh>("EditorMeshes.MatineeCam_SM")/*Ref StaticMesh'EditorMeshes.MatineeCam_SM'*/,
			HiddenGame = true,
			bUseAsOccluder = false,
			CastShadow = false,
			CollideActors = false,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
			Scale3D = new Vector
			{
				X=-1.0f,
				Y=1.0f,
				Z=1.0f
			},
		}/* Reference: StaticMeshComponent'Default__SceneCapturePortalActor.StaticMeshComponent1' */;
		// Object Offset:0x003A3989
		StaticMesh = Default__SceneCapturePortalActor_StaticMeshComponent2;
		SceneCapture = LoadAsset<SceneCapturePortalComponent>("Default__SceneCapturePortalActor.SceneCapturePortalComponent0")/*Ref SceneCapturePortalComponent'Default__SceneCapturePortalActor.SceneCapturePortalComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SceneCapturePortalComponent>("Default__SceneCapturePortalActor.SceneCapturePortalComponent0")/*Ref SceneCapturePortalComponent'Default__SceneCapturePortalActor.SceneCapturePortalComponent0'*/,
			Default__SceneCapturePortalActor_StaticMeshComponent1,
			Default__SceneCapturePortalActor_StaticMeshComponent2,
		};
		Rotation = new Rotator
		{
			Pitch=0,
			Yaw=0,
			Roll=0
		};
	}
}
}