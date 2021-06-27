namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SceneCapture2DActor : SceneCaptureActor/*
		native
		placeable
		hidecategories(Navigation)*/{
	public /*const export editinline */DrawFrustumComponent DrawFrustum;
	
	public SceneCapture2DActor()
	{
		var Default__SceneCapture2DActor_DrawFrust0 = new DrawFrustumComponent
		{
			// Object Offset:0x00468A7F
			FrustumColor = new Color
			{
				R=255,
				G=255,
				B=255,
				A=255
			},
		}/* Reference: DrawFrustumComponent'Default__SceneCapture2DActor.DrawFrust0' */;
		var Default__SceneCapture2DActor_SceneCapture2DComponent0 = new SceneCapture2DComponent
		{
		}/* Reference: SceneCapture2DComponent'Default__SceneCapture2DActor.SceneCapture2DComponent0' */;
		var Default__SceneCapture2DActor_CamMesh0 = new StaticMeshComponent
		{
			// Object Offset:0x00579962
			StaticMesh = LoadAsset<StaticMesh>("EditorMeshes.MatineeCam_SM")/*Ref StaticMesh'EditorMeshes.MatineeCam_SM'*/,
			HiddenGame = true,
			bUseAsOccluder = false,
			CastShadow = false,
			CollideActors = false,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: StaticMeshComponent'Default__SceneCapture2DActor.CamMesh0' */;
		// Object Offset:0x003B22ED
		DrawFrustum = Default__SceneCapture2DActor_DrawFrust0/*Ref DrawFrustumComponent'Default__SceneCapture2DActor.DrawFrust0'*/;
		SceneCapture = Default__SceneCapture2DActor_SceneCapture2DComponent0/*Ref SceneCapture2DComponent'Default__SceneCapture2DActor.SceneCapture2DComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__SceneCapture2DActor_SceneCapture2DComponent0/*Ref SceneCapture2DComponent'Default__SceneCapture2DActor.SceneCapture2DComponent0'*/,
			Default__SceneCapture2DActor_CamMesh0/*Ref StaticMeshComponent'Default__SceneCapture2DActor.CamMesh0'*/,
			Default__SceneCapture2DActor_DrawFrust0/*Ref DrawFrustumComponent'Default__SceneCapture2DActor.DrawFrust0'*/,
		};
	}
}
}