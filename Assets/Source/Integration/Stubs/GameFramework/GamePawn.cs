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
		// stub
	}
	
	public GamePawn()
	{
		var Default__GamePawn_SceneCaptureCharacterComponent0 = new SceneCaptureCharacterComponent
		{
		}/* Reference: SceneCaptureCharacterComponent'Default__GamePawn.SceneCaptureCharacterComponent0' */;
		var Default__GamePawn_DrawFrust0 = new DrawFrustumComponent
		{
		}/* Reference: DrawFrustumComponent'Default__GamePawn.DrawFrust0' */;
		var Default__GamePawn_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__GamePawn.CollisionCylinder' */;
		var Default__GamePawn_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__GamePawn.Sprite' */;
		var Default__GamePawn_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__GamePawn.Arrow' */;
		// Object Offset:0x000070F6
		SceneCapture = Default__GamePawn_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__GamePawn.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = Default__GamePawn_DrawFrust0/*Ref DrawFrustumComponent'Default__GamePawn.DrawFrust0'*/;
		CylinderComponent = Default__GamePawn_CollisionCylinder/*Ref CylinderComponent'Default__GamePawn.CollisionCylinder'*/;
		bCanBeAdheredTo = true;
		bCanBeFrictionedTo = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__GamePawn_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__GamePawn.SceneCaptureCharacterComponent0'*/,
			Default__GamePawn_DrawFrust0/*Ref DrawFrustumComponent'Default__GamePawn.DrawFrust0'*/,
			Default__GamePawn_Sprite/*Ref SpriteComponent'Default__GamePawn.Sprite'*/,
			Default__GamePawn_CollisionCylinder/*Ref CylinderComponent'Default__GamePawn.CollisionCylinder'*/,
			Default__GamePawn_Arrow/*Ref ArrowComponent'Default__GamePawn.Arrow'*/,
		};
		CollisionComponent = Default__GamePawn_CollisionCylinder/*Ref CylinderComponent'Default__GamePawn.CollisionCylinder'*/;
	}
}
}