namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdJumpNode : TdMoveNode/*
		native
		config(PathfindingCosts)
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public/*(Settings)*/ float ForcedSpeed;
	public bool bFallOff;
	public float MaxShortJump;
	public float MaxMediumJump;
	
	public TdJumpNode()
	{
		// Object Offset:0x0057E690
		ForcedSpeed = 720.0f;
		MaxShortJump = 480.0f;
		MaxMediumJump = 650.0f;
		MoveReachspecClass = ClassT<TdReachSpec_Jump>()/*Ref Class'TdReachSpec_Jump'*/;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdJumpNode.CollisionCylinder")/*Ref CylinderComponent'Default__TdJumpNode.CollisionCylinder'*/;
		GoodSprite = LoadAsset<SpriteComponent>("Default__TdJumpNode.Sprite")/*Ref SpriteComponent'Default__TdJumpNode.Sprite'*/;
		BadSprite = LoadAsset<SpriteComponent>("Default__TdJumpNode.Sprite2")/*Ref SpriteComponent'Default__TdJumpNode.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdJumpNode.Sprite")/*Ref SpriteComponent'Default__TdJumpNode.Sprite'*/,
			LoadAsset<SpriteComponent>("Default__TdJumpNode.Sprite2")/*Ref SpriteComponent'Default__TdJumpNode.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__TdJumpNode.Arrow")/*Ref ArrowComponent'Default__TdJumpNode.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__TdJumpNode.CollisionCylinder")/*Ref CylinderComponent'Default__TdJumpNode.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__TdJumpNode.PathRenderer")/*Ref PathRenderingComponent'Default__TdJumpNode.PathRenderer'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdJumpNode.CollisionCylinder")/*Ref CylinderComponent'Default__TdJumpNode.CollisionCylinder'*/;
	}
}
}