namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdReflectionVolume : Volume/*
		placeable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public TdReflectionVolume()
	{
		// Object Offset:0x0065485F
		BrushComponent = new BrushComponent
		{
			// Object Offset:0x01AB479A
			bUseAsOccluder = false,
			bAcceptsLights = false,
			CollideActors = false,
			BlockNonZeroExtent = false,
		}/* Reference: BrushComponent'Default__TdReflectionVolume.BrushComponent0' */;
		bCollideActors = false;
		Components = new array</*export editinline */ActorComponent>
		{
			new BrushComponent
			{
				// Object Offset:0x01AB479A
				bUseAsOccluder = false,
				bAcceptsLights = false,
				CollideActors = false,
				BlockNonZeroExtent = false,
			}/* Reference: BrushComponent'Default__TdReflectionVolume.BrushComponent0' */,
		};
		CollisionComponent = new BrushComponent
		{
			// Object Offset:0x01AB479A
			bUseAsOccluder = false,
			bAcceptsLights = false,
			CollideActors = false,
			BlockNonZeroExtent = false,
		}/* Reference: BrushComponent'Default__TdReflectionVolume.BrushComponent0' */;
	}
}
}