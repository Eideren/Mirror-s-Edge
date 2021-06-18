namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSniperSpot : NavigationPoint/*
		native
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public bool Occupied;
	public/*(NavigationPoint)*/ bool Crouch;
	public/*(NavigationPoint)*/ float AttackVolumeHeight;
	public/*(NavigationPoint)*/ float AttackVolumeAngle;
	public/*(NavigationPoint)*/ float AttackVolumeRadius;
	public/*(NavigationPoint)*/ float AttackVolumeInnerRadius;
	
	// Export UTdSniperSpot::execPointInside(FFrame&, void* const)
	public virtual /*native function */bool PointInside(Object.Vector Point)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public TdSniperSpot()
	{
		var Default__TdSniperSpot_Sprite = new SpriteComponent
		{
			// Object Offset:0x02E525B9
			Sprite = LoadAsset<Texture2D>("TdEditorResources.SuppressIcon")/*Ref Texture2D'TdEditorResources.SuppressIcon'*/,
		}/* Reference: SpriteComponent'Default__TdSniperSpot.Sprite' */;
		// Object Offset:0x006595AA
		Crouch = true;
		AttackVolumeHeight = 2000.0f;
		AttackVolumeAngle = 45.0f;
		AttackVolumeRadius = 3000.0f;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdSniperSpot.CollisionCylinder")/*Ref CylinderComponent'Default__TdSniperSpot.CollisionCylinder'*/;
		GoodSprite = Default__TdSniperSpot_Sprite;
		BadSprite = LoadAsset<SpriteComponent>("Default__TdSniperSpot.Sprite2")/*Ref SpriteComponent'Default__TdSniperSpot.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdSniperSpot_Sprite,
			LoadAsset<SpriteComponent>("Default__TdSniperSpot.Sprite2")/*Ref SpriteComponent'Default__TdSniperSpot.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__TdSniperSpot.Arrow")/*Ref ArrowComponent'Default__TdSniperSpot.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__TdSniperSpot.CollisionCylinder")/*Ref CylinderComponent'Default__TdSniperSpot.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__TdSniperSpot.PathRenderer")/*Ref PathRenderingComponent'Default__TdSniperSpot.PathRenderer'*/,
			LoadAsset<TdSniperNodeRenderingComponent>("Default__TdSniperSpot.NodeRenderer")/*Ref TdSniperNodeRenderingComponent'Default__TdSniperSpot.NodeRenderer'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdSniperSpot.CollisionCylinder")/*Ref CylinderComponent'Default__TdSniperSpot.CollisionCylinder'*/;
	}
}
}