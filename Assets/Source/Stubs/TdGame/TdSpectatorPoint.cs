namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSpectatorPoint : CameraActor/*
		placeable
		hidecategories(Navigation)*/{
	public/*()*/ int OrderIndex;
	
	public TdSpectatorPoint()
	{
		var Default__TdSpectatorPoint_DrawFrust0 = new DrawFrustumComponent
		{
		}/* Reference: DrawFrustumComponent'Default__TdSpectatorPoint.DrawFrust0' */;
		var Default__TdSpectatorPoint_CamMesh0 = new StaticMeshComponent
		{
		}/* Reference: StaticMeshComponent'Default__TdSpectatorPoint.CamMesh0' */;
		// Object Offset:0x0065BDAD
		DrawFrustum = Default__TdSpectatorPoint_DrawFrust0/*Ref DrawFrustumComponent'Default__TdSpectatorPoint.DrawFrust0'*/;
		MeshComp = Default__TdSpectatorPoint_CamMesh0/*Ref StaticMeshComponent'Default__TdSpectatorPoint.CamMesh0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdSpectatorPoint_CamMesh0/*Ref StaticMeshComponent'Default__TdSpectatorPoint.CamMesh0'*/,
			Default__TdSpectatorPoint_DrawFrust0/*Ref DrawFrustumComponent'Default__TdSpectatorPoint.DrawFrust0'*/,
		};
	}
}
}