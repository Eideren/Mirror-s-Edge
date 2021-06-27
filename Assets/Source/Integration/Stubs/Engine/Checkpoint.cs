namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Checkpoint : NavigationPoint/*
		abstract
		native
		notplaceable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public /*const export editinline */RequestedTextureResources CheckpointTextureResources;
	
	public Checkpoint()
	{
		var Default__Checkpoint_CheckpointTextureResourcesObject = new RequestedTextureResources
		{
		}/* Reference: RequestedTextureResources'Default__Checkpoint.CheckpointTextureResourcesObject' */;
		var Default__Checkpoint_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__Checkpoint.CollisionCylinder' */;
		var Default__Checkpoint_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__Checkpoint.Sprite' */;
		var Default__Checkpoint_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__Checkpoint.Sprite2' */;
		var Default__Checkpoint_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__Checkpoint.Arrow' */;
		var Default__Checkpoint_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__Checkpoint.PathRenderer' */;
		// Object Offset:0x002BC650
		CheckpointTextureResources = Default__Checkpoint_CheckpointTextureResourcesObject/*Ref RequestedTextureResources'Default__Checkpoint.CheckpointTextureResourcesObject'*/;
		CylinderComponent = Default__Checkpoint_CollisionCylinder/*Ref CylinderComponent'Default__Checkpoint.CollisionCylinder'*/;
		GoodSprite = Default__Checkpoint_Sprite/*Ref SpriteComponent'Default__Checkpoint.Sprite'*/;
		BadSprite = Default__Checkpoint_Sprite2/*Ref SpriteComponent'Default__Checkpoint.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__Checkpoint_Sprite/*Ref SpriteComponent'Default__Checkpoint.Sprite'*/,
			Default__Checkpoint_Sprite2/*Ref SpriteComponent'Default__Checkpoint.Sprite2'*/,
			Default__Checkpoint_Arrow/*Ref ArrowComponent'Default__Checkpoint.Arrow'*/,
			Default__Checkpoint_CollisionCylinder/*Ref CylinderComponent'Default__Checkpoint.CollisionCylinder'*/,
			Default__Checkpoint_PathRenderer/*Ref PathRenderingComponent'Default__Checkpoint.PathRenderer'*/,
		};
		CollisionComponent = Default__Checkpoint_CollisionCylinder/*Ref CylinderComponent'Default__Checkpoint.CollisionCylinder'*/;
	}
}
}