namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSpectatorPoint : CameraActor/*
		placeable
		hidecategories(Navigation)*/{
	public/*()*/ int OrderIndex;
	
	public TdSpectatorPoint()
	{
		// Object Offset:0x0065BDAD
		DrawFrustum = LoadAsset<DrawFrustumComponent>("Default__TdSpectatorPoint.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdSpectatorPoint.DrawFrust0'*/;
		MeshComp = LoadAsset<StaticMeshComponent>("Default__TdSpectatorPoint.CamMesh0")/*Ref StaticMeshComponent'Default__TdSpectatorPoint.CamMesh0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<StaticMeshComponent>("Default__TdSpectatorPoint.CamMesh0")/*Ref StaticMeshComponent'Default__TdSpectatorPoint.CamMesh0'*/,
			LoadAsset<DrawFrustumComponent>("Default__TdSpectatorPoint.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdSpectatorPoint.DrawFrust0'*/,
		};
	}
}
}