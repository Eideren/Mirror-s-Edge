namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMoveVolumeRenderComponent : StaticMeshComponent/*
		native
		editinlinenew
		hidecategories(Object)
		autoexpandcategories(Collision,Rendering,Lighting)*/{
	[editoronly] public StaticMesh LadderStepMesh;
	[editoronly] public StaticMesh BalanceWalkMesh;
	[editoronly] public StaticMesh PawnLocationMesh;
	[editoronly] public StaticMesh MoveDirectionMesh;
	[editoronly] public StaticMesh FloorDirectionMesh;
	[editoronly] public StaticMesh ZipLineMesh;
	
	public TdMoveVolumeRenderComponent()
	{
		// Object Offset:0x0050D2F8
		LadderStepMesh = LoadAsset<StaticMesh>("MoveVolumeMeshes.S_LadderStep4x4x40_01")/*Ref StaticMesh'MoveVolumeMeshes.S_LadderStep4x4x40_01'*/;
		BalanceWalkMesh = LoadAsset<StaticMesh>("MoveVolumeMeshes.S_Cube32x32x4")/*Ref StaticMesh'MoveVolumeMeshes.S_Cube32x32x4'*/;
		PawnLocationMesh = LoadAsset<StaticMesh>("MoveVolumeMeshes.S_SmallGreenArrow")/*Ref StaticMesh'MoveVolumeMeshes.S_SmallGreenArrow'*/;
		MoveDirectionMesh = LoadAsset<StaticMesh>("MoveVolumeMeshes.S_GreenArrow")/*Ref StaticMesh'MoveVolumeMeshes.S_GreenArrow'*/;
		FloorDirectionMesh = LoadAsset<StaticMesh>("MoveVolumeMeshes.S_SmallYellowArrow")/*Ref StaticMesh'MoveVolumeMeshes.S_SmallYellowArrow'*/;
		ZipLineMesh = LoadAsset<StaticMesh>("MoveVolumeMeshes.S_Cylinder4x32")/*Ref StaticMesh'MoveVolumeMeshes.S_Cylinder4x32'*/;
		StaticMesh = LoadAsset<StaticMesh>("MoveVolumeMeshes.S_LadderStep4x4x40_01")/*Ref StaticMesh'MoveVolumeMeshes.S_LadderStep4x4x40_01'*/;
		HiddenGame = true;
		bAcceptsDecals = false;
		CastShadow = false;
		bAcceptsLights = false;
		CollideActors = false;
		BlockActors = false;
		BlockZeroExtent = false;
		BlockNonZeroExtent = false;
		BlockRigidBody = false;
		AlwaysLoadOnClient = false;
		AlwaysLoadOnServer = false;
	}
}
}