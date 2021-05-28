namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAIBlockingVolume : BlockingVolume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public TdAIBlockingVolume()
	{
		// Object Offset:0x004E7DBC
		BrushComponent = new BrushComponent
		{
			// Object Offset:0x01AB456A
			BlockActors = false,
			BlockZeroExtent = true,
			BlockRigidBody = false,
		}/* Reference: BrushComponent'Default__TdAIBlockingVolume.BrushComponent0' */;
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new BrushComponent
			{
				// Object Offset:0x01AB456A
				BlockActors = false,
				BlockZeroExtent = true,
				BlockRigidBody = false,
			}/* Reference: BrushComponent'Default__TdAIBlockingVolume.BrushComponent0' */,
		};
		CollisionComponent = new BrushComponent
		{
			// Object Offset:0x01AB456A
			BlockActors = false,
			BlockZeroExtent = true,
			BlockRigidBody = false,
		}/* Reference: BrushComponent'Default__TdAIBlockingVolume.BrushComponent0' */;
	}
}
}