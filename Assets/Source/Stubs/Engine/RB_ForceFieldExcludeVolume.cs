namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_ForceFieldExcludeVolume : Volume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public/*()*/ int ForceFieldChannel;
	
	public RB_ForceFieldExcludeVolume()
	{
		// Object Offset:0x003AD86A
		ForceFieldChannel = 1;
		BrushComponent = new BrushComponent
		{
			// Object Offset:0x00466267
			BlockNonZeroExtent = false,
		}/* Reference: BrushComponent'Default__RB_ForceFieldExcludeVolume.BrushComponent0' */;
		Components = new array</*export editinline */ActorComponent>
		{
			new BrushComponent
			{
				// Object Offset:0x00466267
				BlockNonZeroExtent = false,
			}/* Reference: BrushComponent'Default__RB_ForceFieldExcludeVolume.BrushComponent0' */,
		};
		CollisionComponent = new BrushComponent
		{
			// Object Offset:0x00466267
			BlockNonZeroExtent = false,
		}/* Reference: BrushComponent'Default__RB_ForceFieldExcludeVolume.BrushComponent0' */;
	}
}
}