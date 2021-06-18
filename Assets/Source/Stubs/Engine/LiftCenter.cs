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
	
	}
	
	public override /*event */Actor SpecialHandling(Pawn Other)
	{
	
		return default;
	}
	
	public override /*event */bool SuggestMovePreparation(Pawn Other)
	{
	
		return default;
	}
	
	public override /*function */bool ProceedWithMove(Pawn Other)
	{
	
		return default;
	}
	
	public LiftCenter()
	{
		var Default__LiftCenter_Sprite = new SpriteComponent
		{
			// Object Offset:0x004CFC96
			Sprite = LoadAsset<Texture2D>("EngineResources.lift_center")/*Ref Texture2D'EngineResources.lift_center'*/,
		}/* Reference: SpriteComponent'Default__LiftCenter.Sprite' */;
		// Object Offset:0x003510D7
		MaxDist2D = 400.0f;
		CollisionHeight = 50.0f;
		bNeverUseStrafing = true;
		bForceNoStrafing = true;
		bSpecialMove = true;
		bNoAutoConnect = true;
		ExtraCost = 400;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__LiftCenter.CollisionCylinder")/*Ref CylinderComponent'Default__LiftCenter.CollisionCylinder'*/;
		GoodSprite = Default__LiftCenter_Sprite;
		BadSprite = LoadAsset<SpriteComponent>("Default__LiftCenter.Sprite2")/*Ref SpriteComponent'Default__LiftCenter.Sprite2'*/;
		bStatic = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__LiftCenter_Sprite,
			LoadAsset<SpriteComponent>("Default__LiftCenter.Sprite2")/*Ref SpriteComponent'Default__LiftCenter.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__LiftCenter.Arrow")/*Ref ArrowComponent'Default__LiftCenter.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__LiftCenter.CollisionCylinder")/*Ref CylinderComponent'Default__LiftCenter.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__LiftCenter.PathRenderer")/*Ref PathRenderingComponent'Default__LiftCenter.PathRenderer'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__LiftCenter.CollisionCylinder")/*Ref CylinderComponent'Default__LiftCenter.CollisionCylinder'*/;
	}
}
}