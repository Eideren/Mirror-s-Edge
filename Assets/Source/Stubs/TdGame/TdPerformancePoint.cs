namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPerformancePoint : Keypoint/*
		native
		placeable
		hidecategories(Navigation)*/{
	public TdPerformancePoint()
	{
		// Object Offset:0x0060AA45
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new SpriteComponent
			{
				// Object Offset:0x02E52525
				Sprite = LoadAsset<Texture2D>("TdEditorResources.PerformancePointIcon")/*Ref Texture2D'TdEditorResources.PerformancePointIcon'*/,
			}/* Reference: SpriteComponent'Default__TdPerformancePoint.Sprite' */,
			//Components[1]=
			new SpriteComponent
			{
				// Object Offset:0x02E52525
				Sprite = LoadAsset<Texture2D>("TdEditorResources.PerformancePointIcon")/*Ref Texture2D'TdEditorResources.PerformancePointIcon'*/,
			}/* Reference: SpriteComponent'Default__TdPerformancePoint.Sprite' */,
		};
	}
}
}