namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SceneCaptureCubeMapActor : SceneCaptureActor/*
		native
		placeable
		hidecategories(Navigation)*/{
	public /*const export editinline */StaticMeshComponent StaticMesh;
	public /*transient */MaterialInstanceConstant CubeMaterialInst;
	
	public SceneCaptureCubeMapActor()
	{
		// Object Offset:0x003B25DB
		StaticMesh = new StaticMeshComponent
		{
			// Object Offset:0x00579A42
			StaticMesh = LoadAsset<StaticMesh>("EditorMeshes.TexPropSphere")/*Ref StaticMesh'EditorMeshes.TexPropSphere'*/,
			HiddenGame = true,
			CastShadow = false,
			bAcceptsLights = false,
			CollideActors = false,
			Scale3D = new Vector
			{
				X=0.60f,
				Y=0.60f,
				Z=0.60f
			},
		}/* Reference: StaticMeshComponent'Default__SceneCaptureCubeMapActor.StaticMeshComponent0' */;
		SceneCapture = LoadAsset<SceneCaptureCubeMapComponent>("Default__SceneCaptureCubeMapActor.SceneCaptureCubeMapComponent0")/*Ref SceneCaptureCubeMapComponent'Default__SceneCaptureCubeMapActor.SceneCaptureCubeMapComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SceneCaptureCubeMapComponent>("Default__SceneCaptureCubeMapActor.SceneCaptureCubeMapComponent0")/*Ref SceneCaptureCubeMapComponent'Default__SceneCaptureCubeMapActor.SceneCaptureCubeMapComponent0'*/,
			//Components[1]=
			new StaticMeshComponent
			{
				// Object Offset:0x00579A42
				StaticMesh = LoadAsset<StaticMesh>("EditorMeshes.TexPropSphere")/*Ref StaticMesh'EditorMeshes.TexPropSphere'*/,
				HiddenGame = true,
				CastShadow = false,
				bAcceptsLights = false,
				CollideActors = false,
				Scale3D = new Vector
				{
					X=0.60f,
					Y=0.60f,
					Z=0.60f
				},
			}/* Reference: StaticMeshComponent'Default__SceneCaptureCubeMapActor.StaticMeshComponent0' */,
		};
	}
}
}