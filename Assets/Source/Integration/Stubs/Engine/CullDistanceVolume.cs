namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CullDistanceVolume : Volume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display,Advanced,Attachment,Collision,Volume)*/{
	public partial struct /*native */CullDistanceSizePair
	{
		[Category] public float Size;
		[Category] public float CullDistance;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002F4D53
	//		Size = 0.0f;
	//		CullDistance = 0.0f;
	//	}
	};
	
	[Category] public array<CullDistanceVolume.CullDistanceSizePair> CullDistances;
	[Category] public bool bEnabled;
	
	public CullDistanceVolume()
	{
		var Default__CullDistanceVolume_BrushComponent0 = new BrushComponent
		{
			// Object Offset:0x00465F1F
			CollideActors = false,
			BlockNonZeroExtent = false,
		}/* Reference: BrushComponent'Default__CullDistanceVolume.BrushComponent0' */;
		// Object Offset:0x002F4E1F
		CullDistances = new array<CullDistanceVolume.CullDistanceSizePair>
		{
			new CullDistanceVolume.CullDistanceSizePair
			{
				Size = 0.0f,
				CullDistance = 0.0f,
			},
			new CullDistanceVolume.CullDistanceSizePair
			{
				Size = 10000.0f,
				CullDistance = 0.0f,
			},
		};
		bEnabled = true;
		BrushComponent = Default__CullDistanceVolume_BrushComponent0/*Ref BrushComponent'Default__CullDistanceVolume.BrushComponent0'*/;
		bCollideActors = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__CullDistanceVolume_BrushComponent0/*Ref BrushComponent'Default__CullDistanceVolume.BrushComponent0'*/,
		};
		CollisionComponent = Default__CullDistanceVolume_BrushComponent0/*Ref BrushComponent'Default__CullDistanceVolume.BrushComponent0'*/;
		SupportedEvents = default;
	}
}
}