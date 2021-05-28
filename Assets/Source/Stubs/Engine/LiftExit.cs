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
	
		return default;
	}
	
	public virtual /*function */void WaitForLift(Pawn Other)
	{
	
	}
	
	public override /*event */bool SuggestMovePreparation(Pawn Other)
	{
	
		return default;
	}
	
	public LiftExit()
	{
		// Object Offset:0x00351822
		bNeverUseStrafing = true;
		bForceNoStrafing = true;
		bSpecialMove = true;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__LiftExit.CollisionCylinder")/*Ref CylinderComponent'Default__LiftExit.CollisionCylinder'*/;
		GoodSprite = new SpriteComponent
		{
			// Object Offset:0x004CFCE2
			Sprite = LoadAsset<Texture2D>("EngineResources.lift_exit")/*Ref Texture2D'EngineResources.lift_exit'*/,
		}/* Reference: SpriteComponent'Default__LiftExit.Sprite' */;
		BadSprite = LoadAsset<SpriteComponent>("Default__LiftExit.Sprite2")/*Ref SpriteComponent'Default__LiftExit.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new SpriteComponent
			{
				// Object Offset:0x004CFCE2
				Sprite = LoadAsset<Texture2D>("EngineResources.lift_exit")/*Ref Texture2D'EngineResources.lift_exit'*/,
			}/* Reference: SpriteComponent'Default__LiftExit.Sprite' */,
			LoadAsset<SpriteComponent>("Default__LiftExit.Sprite2")/*Ref SpriteComponent'Default__LiftExit.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__LiftExit.Arrow")/*Ref ArrowComponent'Default__LiftExit.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__LiftExit.CollisionCylinder")/*Ref CylinderComponent'Default__LiftExit.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__LiftExit.PathRenderer")/*Ref PathRenderingComponent'Default__LiftExit.PathRenderer'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__LiftExit.CollisionCylinder")/*Ref CylinderComponent'Default__LiftExit.CollisionCylinder'*/;
	}
}
}