namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CullDistanceVolume : Volume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display,Advanced,Attachment,Collision,Volume)*/{
	public partial struct /*native */CullDistanceSizePair
	{
		public/*()*/ float Size;
		public/*()*/ float CullDistance;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002F4D53
	//		Size = 0.0f;
	//		CullDistance = 0.0f;
	//	}
	};
	
	public/*()*/ array<CullDistanceVolume.CullDistanceSizePair> CullDistances;
	public/*()*/ bool bEnabled;
	
	public CullDistanceVolume()
	{
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
		BrushComponent = new BrushComponent
		{
			// Object Offset:0x00465F1F
			CollideActors = false,
			BlockNonZeroExtent = false,
		}/* Reference: BrushComponent'Default__CullDistanceVolume.BrushComponent0' */;
		bCollideActors = false;
		Components = new array</*export editinline */ActorComponent>
		{
			new BrushComponent
			{
				// Object Offset:0x00465F1F
				CollideActors = false,
				BlockNonZeroExtent = false,
			}/* Reference: BrushComponent'Default__CullDistanceVolume.BrushComponent0' */,
		};
		CollisionComponent = new BrushComponent
		{
			// Object Offset:0x00465F1F
			CollideActors = false,
			BlockNonZeroExtent = false,
		}/* Reference: BrushComponent'Default__CullDistanceVolume.BrushComponent0' */;
		SupportedEvents = default;
	}
}
}