namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class LiftExit : NavigationPoint/*
		native
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public/*()*/ LiftCenter MyLiftCenter;
	public/*()*/ bool bExitOnly;
	
	public virtual /*function */bool CanBeReachedFromLiftBy(Pawn Other)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void WaitForLift(Pawn Other)
	{
		// stub
	}
	
	public override /*event */bool SuggestMovePreparation(Pawn Other)
	{
		// stub
		return default;
	}
	
	public LiftExit()
	{
		var Default__LiftExit_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__LiftExit.CollisionCylinder' */;
		var Default__LiftExit_Sprite = new SpriteComponent
		{
			// Object Offset:0x004CFCE2
			Sprite = LoadAsset<Texture2D>("EngineResources.lift_exit")/*Ref Texture2D'EngineResources.lift_exit'*/,
		}/* Reference: SpriteComponent'Default__LiftExit.Sprite' */;
		var Default__LiftExit_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__LiftExit.Sprite2' */;
		var Default__LiftExit_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__LiftExit.Arrow' */;
		var Default__LiftExit_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__LiftExit.PathRenderer' */;
		// Object Offset:0x00351822
		bNeverUseStrafing = true;
		bForceNoStrafing = true;
		bSpecialMove = true;
		CylinderComponent = Default__LiftExit_CollisionCylinder/*Ref CylinderComponent'Default__LiftExit.CollisionCylinder'*/;
		GoodSprite = Default__LiftExit_Sprite/*Ref SpriteComponent'Default__LiftExit.Sprite'*/;
		BadSprite = Default__LiftExit_Sprite2/*Ref SpriteComponent'Default__LiftExit.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__LiftExit_Sprite/*Ref SpriteComponent'Default__LiftExit.Sprite'*/,
			Default__LiftExit_Sprite2/*Ref SpriteComponent'Default__LiftExit.Sprite2'*/,
			Default__LiftExit_Arrow/*Ref ArrowComponent'Default__LiftExit.Arrow'*/,
			Default__LiftExit_CollisionCylinder/*Ref CylinderComponent'Default__LiftExit.CollisionCylinder'*/,
			Default__LiftExit_PathRenderer/*Ref PathRenderingComponent'Default__LiftExit.PathRenderer'*/,
		};
		CollisionComponent = Default__LiftExit_CollisionCylinder/*Ref CylinderComponent'Default__LiftExit.CollisionCylinder'*/;
	}
}
}