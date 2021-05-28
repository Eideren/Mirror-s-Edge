namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DynamicCameraActor : CameraActor/*
		native
		notplaceable
		hidecategories(Navigation)*/{
	public DynamicCameraActor()
	{
		// Object Offset:0x0031224E
		DrawFrustum = LoadAsset<DrawFrustumComponent>("Default__DynamicCameraActor.DrawFrust0")/*Ref DrawFrustumComponent'Default__DynamicCameraActor.DrawFrust0'*/;
		MeshComp = LoadAsset<StaticMeshComponent>("Default__DynamicCameraActor.CamMesh0")/*Ref StaticMeshComponent'Default__DynamicCameraActor.CamMesh0'*/;
		bNoDelete = false;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<StaticMeshComponent>("Default__DynamicCameraActor.CamMesh0")/*Ref StaticMeshComponent'Default__DynamicCameraActor.CamMesh0'*/,
			LoadAsset<DrawFrustumComponent>("Default__DynamicCameraActor.DrawFrust0")/*Ref DrawFrustumComponent'Default__DynamicCameraActor.DrawFrust0'*/,
		};
	}
}
}