namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdConfinedVolumePathNode : VolumePathNode/*
		native
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	[Category("NavigationPoint")] public float MaxRadius;
	[Category("NavigationPoint")] public float MaxHeight;
	public String name2;
	public float CalculatedRadius;
	public float CalculatedHeight;
	
	public TdConfinedVolumePathNode()
	{
		var Default__TdConfinedVolumePathNode_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdConfinedVolumePathNode.CollisionCylinder' */;
		var Default__TdConfinedVolumePathNode_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdConfinedVolumePathNode.Sprite' */;
		var Default__TdConfinedVolumePathNode_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdConfinedVolumePathNode.Sprite2' */;
		var Default__TdConfinedVolumePathNode_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdConfinedVolumePathNode.Arrow' */;
		var Default__TdConfinedVolumePathNode_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__TdConfinedVolumePathNode.PathRenderer' */;
		// Object Offset:0x0050969E
		MaxRadius = 1000.0f;
		MaxHeight = 1000.0f;
		CalculatedRadius = 1000.0f;
		CalculatedHeight = 1000.0f;
		bNoAutoConnect = false;
		CylinderComponent = Default__TdConfinedVolumePathNode_CollisionCylinder/*Ref CylinderComponent'Default__TdConfinedVolumePathNode.CollisionCylinder'*/;
		GoodSprite = Default__TdConfinedVolumePathNode_Sprite/*Ref SpriteComponent'Default__TdConfinedVolumePathNode.Sprite'*/;
		BadSprite = Default__TdConfinedVolumePathNode_Sprite2/*Ref SpriteComponent'Default__TdConfinedVolumePathNode.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdConfinedVolumePathNode_Sprite/*Ref SpriteComponent'Default__TdConfinedVolumePathNode.Sprite'*/,
			Default__TdConfinedVolumePathNode_Sprite2/*Ref SpriteComponent'Default__TdConfinedVolumePathNode.Sprite2'*/,
			Default__TdConfinedVolumePathNode_Arrow/*Ref ArrowComponent'Default__TdConfinedVolumePathNode.Arrow'*/,
			Default__TdConfinedVolumePathNode_CollisionCylinder/*Ref CylinderComponent'Default__TdConfinedVolumePathNode.CollisionCylinder'*/,
			Default__TdConfinedVolumePathNode_PathRenderer/*Ref PathRenderingComponent'Default__TdConfinedVolumePathNode.PathRenderer'*/,
		};
		CollisionComponent = Default__TdConfinedVolumePathNode_CollisionCylinder/*Ref CylinderComponent'Default__TdConfinedVolumePathNode.CollisionCylinder'*/;
	}
}
}