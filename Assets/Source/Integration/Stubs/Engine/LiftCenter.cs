namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class LiftCenter : NavigationPoint/*
		native
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public InterpActor MyLift;
	public float MaxDist2D;
	public Object.Vector LiftOffset;
	public bool bJumpLift;
	public float CollisionHeight;
	public/*()*/ Trigger LiftTrigger;
	
	public override /*event */void PostBeginPlay()
	{
		// stub
	}
	
	public override /*event */Actor SpecialHandling(Pawn Other)
	{
		// stub
		return default;
	}
	
	public override /*event */bool SuggestMovePreparation(Pawn Other)
	{
		// stub
		return default;
	}
	
	public override /*function */bool ProceedWithMove(Pawn Other)
	{
		// stub
		return default;
	}
	
	public LiftCenter()
	{
		var Default__LiftCenter_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__LiftCenter.CollisionCylinder' */;
		var Default__LiftCenter_Sprite = new SpriteComponent
		{
			// Object Offset:0x004CFC96
			Sprite = LoadAsset<Texture2D>("EngineResources.lift_center")/*Ref Texture2D'EngineResources.lift_center'*/,
		}/* Reference: SpriteComponent'Default__LiftCenter.Sprite' */;
		var Default__LiftCenter_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__LiftCenter.Sprite2' */;
		var Default__LiftCenter_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__LiftCenter.Arrow' */;
		var Default__LiftCenter_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__LiftCenter.PathRenderer' */;
		// Object Offset:0x003510D7
		MaxDist2D = 400.0f;
		CollisionHeight = 50.0f;
		bNeverUseStrafing = true;
		bForceNoStrafing = true;
		bSpecialMove = true;
		bNoAutoConnect = true;
		ExtraCost = 400;
		CylinderComponent = Default__LiftCenter_CollisionCylinder/*Ref CylinderComponent'Default__LiftCenter.CollisionCylinder'*/;
		GoodSprite = Default__LiftCenter_Sprite/*Ref SpriteComponent'Default__LiftCenter.Sprite'*/;
		BadSprite = Default__LiftCenter_Sprite2/*Ref SpriteComponent'Default__LiftCenter.Sprite2'*/;
		bStatic = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__LiftCenter_Sprite/*Ref SpriteComponent'Default__LiftCenter.Sprite'*/,
			Default__LiftCenter_Sprite2/*Ref SpriteComponent'Default__LiftCenter.Sprite2'*/,
			Default__LiftCenter_Arrow/*Ref ArrowComponent'Default__LiftCenter.Arrow'*/,
			Default__LiftCenter_CollisionCylinder/*Ref CylinderComponent'Default__LiftCenter.CollisionCylinder'*/,
			Default__LiftCenter_PathRenderer/*Ref PathRenderingComponent'Default__LiftCenter.PathRenderer'*/,
		};
		CollisionComponent = Default__LiftCenter_CollisionCylinder/*Ref CylinderComponent'Default__LiftCenter.CollisionCylinder'*/;
	}
}
}