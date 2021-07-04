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
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public TdSniperSpot()
	{
		var Default__TdSniperSpot_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdSniperSpot.CollisionCylinder' */;
		var Default__TdSniperSpot_Sprite = new SpriteComponent
		{
			// Object Offset:0x02E525B9
			Sprite = LoadAsset<Texture2D>("TdEditorResources.SuppressIcon")/*Ref Texture2D'TdEditorResources.SuppressIcon'*/,
		}/* Reference: SpriteComponent'Default__TdSniperSpot.Sprite' */;
		var Default__TdSniperSpot_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdSniperSpot.Sprite2' */;
		var Default__TdSniperSpot_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdSniperSpot.Arrow' */;
		var Default__TdSniperSpot_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__TdSniperSpot.PathRenderer' */;
		var Default__TdSniperSpot_NodeRenderer = new TdSniperNodeRenderingComponent
		{
		}/* Reference: TdSniperNodeRenderingComponent'Default__TdSniperSpot.NodeRenderer' */;
		// Object Offset:0x006595AA
		Crouch = true;
		AttackVolumeHeight = 2000.0f;
		AttackVolumeAngle = 45.0f;
		AttackVolumeRadius = 3000.0f;
		CylinderComponent = Default__TdSniperSpot_CollisionCylinder/*Ref CylinderComponent'Default__TdSniperSpot.CollisionCylinder'*/;
		GoodSprite = Default__TdSniperSpot_Sprite/*Ref SpriteComponent'Default__TdSniperSpot.Sprite'*/;
		BadSprite = Default__TdSniperSpot_Sprite2/*Ref SpriteComponent'Default__TdSniperSpot.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdSniperSpot_Sprite/*Ref SpriteComponent'Default__TdSniperSpot.Sprite'*/,
			Default__TdSniperSpot_Sprite2/*Ref SpriteComponent'Default__TdSniperSpot.Sprite2'*/,
			Default__TdSniperSpot_Arrow/*Ref ArrowComponent'Default__TdSniperSpot.Arrow'*/,
			Default__TdSniperSpot_CollisionCylinder/*Ref CylinderComponent'Default__TdSniperSpot.CollisionCylinder'*/,
			Default__TdSniperSpot_PathRenderer/*Ref PathRenderingComponent'Default__TdSniperSpot.PathRenderer'*/,
			Default__TdSniperSpot_NodeRenderer/*Ref TdSniperNodeRenderingComponent'Default__TdSniperSpot.NodeRenderer'*/,
		};
		CollisionComponent = Default__TdSniperSpot_CollisionCylinder/*Ref CylinderComponent'Default__TdSniperSpot.CollisionCylinder'*/;
	}
}
}