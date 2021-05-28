namespace MEdge.GameFramework{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class GamePawn : Pawn/*
		abstract
		native
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public virtual /*simulated function */void GetTargetFrictionCylinder(ref float CylinderRadius, ref float CylinderHeight)
	{
	
	}
	
	public GamePawn()
	{
		// Object Offset:0x000070F6
		SceneCapture = LoadAsset<SceneCaptureCharacterComponent>("Default__GamePawn.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__GamePawn.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = LoadAsset<DrawFrustumComponent>("Default__GamePawn.DrawFrust0")/*Ref DrawFrustumComponent'Default__GamePawn.DrawFrust0'*/;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__GamePawn.CollisionCylinder")/*Ref CylinderComponent'Default__GamePawn.CollisionCylinder'*/;
		bCanBeAdheredTo = true;
		bCanBeFrictionedTo = true;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SceneCaptureCharacterComponent>("Default__GamePawn.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__GamePawn.SceneCaptureCharacterComponent0'*/,
			LoadAsset<DrawFrustumComponent>("Default__GamePawn.DrawFrust0")/*Ref DrawFrustumComponent'Default__GamePawn.DrawFrust0'*/,
			LoadAsset<SpriteComponent>("Default__GamePawn.Sprite")/*Ref SpriteComponent'Default__GamePawn.Sprite'*/,
			LoadAsset<CylinderComponent>("Default__GamePawn.CollisionCylinder")/*Ref CylinderComponent'Default__GamePawn.CollisionCylinder'*/,
			LoadAsset<ArrowComponent>("Default__GamePawn.Arrow")/*Ref ArrowComponent'Default__GamePawn.Arrow'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__GamePawn.CollisionCylinder")/*Ref CylinderComponent'Default__GamePawn.CollisionCylinder'*/;
	}
}
}