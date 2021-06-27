namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdInterestPoint : NavigationPoint/*
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public/*()*/ float InvestigationDistance;
	public/*()*/ float InvestigationInterval;
	public /*protected */float InvestigationTime;
	
	public virtual /*function */bool ShouldBeInvestigated(float GameTime)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void MarkInvestigated(float GameTime)
	{
		// stub
	}
	
	public TdInterestPoint()
	{
		var Default__TdInterestPoint_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdInterestPoint.CollisionCylinder' */;
		var Default__TdInterestPoint_Sprite = new SpriteComponent
		{
			// Object Offset:0x02E5208D
			Sprite = LoadAsset<Texture2D>("TdEditorResources.InvestigateIcon")/*Ref Texture2D'TdEditorResources.InvestigateIcon'*/,
		}/* Reference: SpriteComponent'Default__TdInterestPoint.Sprite' */;
		var Default__TdInterestPoint_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdInterestPoint.Sprite2' */;
		var Default__TdInterestPoint_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdInterestPoint.Arrow' */;
		var Default__TdInterestPoint_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__TdInterestPoint.PathRenderer' */;
		// Object Offset:0x0057BC9D
		InvestigationDistance = -1.0f;
		InvestigationInterval = 10.0f;
		CylinderComponent = Default__TdInterestPoint_CollisionCylinder/*Ref CylinderComponent'Default__TdInterestPoint.CollisionCylinder'*/;
		GoodSprite = Default__TdInterestPoint_Sprite/*Ref SpriteComponent'Default__TdInterestPoint.Sprite'*/;
		BadSprite = Default__TdInterestPoint_Sprite2/*Ref SpriteComponent'Default__TdInterestPoint.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdInterestPoint_Sprite/*Ref SpriteComponent'Default__TdInterestPoint.Sprite'*/,
			Default__TdInterestPoint_Sprite2/*Ref SpriteComponent'Default__TdInterestPoint.Sprite2'*/,
			Default__TdInterestPoint_Arrow/*Ref ArrowComponent'Default__TdInterestPoint.Arrow'*/,
			Default__TdInterestPoint_CollisionCylinder/*Ref CylinderComponent'Default__TdInterestPoint.CollisionCylinder'*/,
			Default__TdInterestPoint_PathRenderer/*Ref PathRenderingComponent'Default__TdInterestPoint.PathRenderer'*/,
		};
		CollisionComponent = Default__TdInterestPoint_CollisionCylinder/*Ref CylinderComponent'Default__TdInterestPoint.CollisionCylinder'*/;
	}
}
}