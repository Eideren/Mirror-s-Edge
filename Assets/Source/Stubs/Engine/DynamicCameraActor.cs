namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DynamicCameraActor : CameraActor/*
		native
		notplaceable
		hidecategories(Navigation)*/{
	public DynamicCameraActor()
	{
		var Default__DynamicCameraActor_DrawFrust0 = new DrawFrustumComponent
		{
		}/* Reference: DrawFrustumComponent'Default__DynamicCameraActor.DrawFrust0' */;
		var Default__DynamicCameraActor_CamMesh0 = new StaticMeshComponent
		{
		}/* Reference: StaticMeshComponent'Default__DynamicCameraActor.CamMesh0' */;
		// Object Offset:0x0031224E
		DrawFrustum = Default__DynamicCameraActor_DrawFrust0/*Ref DrawFrustumComponent'Default__DynamicCameraActor.DrawFrust0'*/;
		MeshComp = Default__DynamicCameraActor_CamMesh0/*Ref StaticMeshComponent'Default__DynamicCameraActor.CamMesh0'*/;
		bNoDelete = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__DynamicCameraActor_CamMesh0/*Ref StaticMeshComponent'Default__DynamicCameraActor.CamMesh0'*/,
			Default__DynamicCameraActor_DrawFrust0/*Ref DrawFrustumComponent'Default__DynamicCameraActor.DrawFrust0'*/,
		};
	}
}
}