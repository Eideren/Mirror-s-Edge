namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SceneCaptureReflectActor : SceneCaptureActor/*
		native
		placeable
		hidecategories(Navigation)*/{
	public/*()*/ /*const export editinline */StaticMeshComponent StaticMesh;
	public /*transient */MaterialInstanceConstant ReflectMaterialInst;
	public/*()*/ /*const */Volume ReflectionVolume;
	
	public override /*function */void PostBeginPlay()
	{
	
	}
	
	public SceneCaptureReflectActor()
	{
		var Default__SceneCaptureReflectActor_StaticMeshComponent0 = new StaticMeshComponent
		{
			// Object Offset:0x00579B16
			StaticMesh = LoadAsset<StaticMesh>("EditorMeshes.TexPropPlane")/*Ref StaticMesh'EditorMeshes.TexPropPlane'*/,
			HiddenGame = true,
			CastShadow = false,
			bAcceptsLights = false,
			CollideActors = false,
			Scale3D = new Vector
			{
				X=4.0f,
				Y=4.0f,
				Z=4.0f
			},
		}/* Reference: StaticMeshComponent'Default__SceneCaptureReflectActor.StaticMeshComponent0' */;
		var Default__SceneCaptureReflectActor_SceneCaptureReflectComponent0 = new SceneCaptureReflectComponent
		{
		}/* Reference: SceneCaptureReflectComponent'Default__SceneCaptureReflectActor.SceneCaptureReflectComponent0' */;
		var Default__SceneCaptureReflectActor_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__SceneCaptureReflectActor.Sprite' */;
		// Object Offset:0x003A361B
		StaticMesh = Default__SceneCaptureReflectActor_StaticMeshComponent0/*Ref StaticMeshComponent'Default__SceneCaptureReflectActor.StaticMeshComponent0'*/;
		SceneCapture = Default__SceneCaptureReflectActor_SceneCaptureReflectComponent0/*Ref SceneCaptureReflectComponent'Default__SceneCaptureReflectActor.SceneCaptureReflectComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__SceneCaptureReflectActor_Sprite/*Ref SpriteComponent'Default__SceneCaptureReflectActor.Sprite'*/,
			Default__SceneCaptureReflectActor_SceneCaptureReflectComponent0/*Ref SceneCaptureReflectComponent'Default__SceneCaptureReflectActor.SceneCaptureReflectComponent0'*/,
			Default__SceneCaptureReflectActor_StaticMeshComponent0/*Ref StaticMeshComponent'Default__SceneCaptureReflectActor.StaticMeshComponent0'*/,
		};
		Rotation = new Rotator
		{
			Pitch=16384,
			Yaw=0,
			Roll=0
		};
	}
}
}