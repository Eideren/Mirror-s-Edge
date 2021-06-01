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
	
		return default;
	}
	
	public virtual /*function */void MarkInvestigated(float GameTime)
	{
	
	}
	
	public TdInterestPoint()
	{
		// Object Offset:0x0057BC9D
		InvestigationDistance = -1.0f;
		InvestigationInterval = 10.0f;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdInterestPoint.CollisionCylinder")/*Ref CylinderComponent'Default__TdInterestPoint.CollisionCylinder'*/;
		GoodSprite = new SpriteComponent
		{
			// Object Offset:0x02E5208D
			Sprite = LoadAsset<Texture2D>("TdEditorResources.InvestigateIcon")/*Ref Texture2D'TdEditorResources.InvestigateIcon'*/,
		}/* Reference: SpriteComponent'Default__TdInterestPoint.Sprite' */;
		BadSprite = LoadAsset<SpriteComponent>("Default__TdInterestPoint.Sprite2")/*Ref SpriteComponent'Default__TdInterestPoint.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			new SpriteComponent
			{
				// Object Offset:0x02E5208D
				Sprite = LoadAsset<Texture2D>("TdEditorResources.InvestigateIcon")/*Ref Texture2D'TdEditorResources.InvestigateIcon'*/,
			}/* Reference: SpriteComponent'Default__TdInterestPoint.Sprite' */,
			LoadAsset<SpriteComponent>("Default__TdInterestPoint.Sprite2")/*Ref SpriteComponent'Default__TdInterestPoint.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__TdInterestPoint.Arrow")/*Ref ArrowComponent'Default__TdInterestPoint.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__TdInterestPoint.CollisionCylinder")/*Ref CylinderComponent'Default__TdInterestPoint.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__TdInterestPoint.PathRenderer")/*Ref PathRenderingComponent'Default__TdInterestPoint.PathRenderer'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdInterestPoint.CollisionCylinder")/*Ref CylinderComponent'Default__TdInterestPoint.CollisionCylinder'*/;
	}
}
}