namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class JuicePerformancePoint : Keypoint/*
		native
		placeable
		hidecategories(Navigation)*/{
	public/*(PerformancePoint)*/ String PointName;
	public array<LevelStreaming> StreamingLevels;
	
	public JuicePerformancePoint()
	{
		var Default__JuicePerformancePoint_Sprite = new SpriteComponent
		{
			// Object Offset:0x004CFBA2
			Sprite = LoadAsset<Texture2D>("TdEditorResources.PerformancePointIcon")/*Ref Texture2D'TdEditorResources.PerformancePointIcon'*/,
		}/* Reference: SpriteComponent'Default__JuicePerformancePoint.Sprite' */;
		// Object Offset:0x0034817C
		Components = new array</*export editinline */ActorComponent>
		{
			Default__JuicePerformancePoint_Sprite,
			Default__JuicePerformancePoint_Sprite,
		};
	}
}
}