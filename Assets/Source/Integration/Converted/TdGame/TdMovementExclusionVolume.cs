namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMovementExclusionVolume : PhysicsVolume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display,AI,Interaction,PhysicsVolume,Volume)*/{
	public/*()*/ bool bExcludeFootMoves;
	public/*()*/ bool bExcludeHandMoves;
	
	public TdMovementExclusionVolume()
	{
		var Default__TdMovementExclusionVolume_BrushComponent0 = new BrushComponent
		{
			// Object Offset:0x01AB4746
			BlockNonZeroExtent = false,
		}/* Reference: BrushComponent'Default__TdMovementExclusionVolume.BrushComponent0' */;
		// Object Offset:0x005F2773
		bExcludeFootMoves = true;
		bExcludeHandMoves = true;
		BrushColor = new Color
		{
			R=255,
			G=255,
			B=0,
			A=255
		};
		bColored = true;
		BrushComponent = Default__TdMovementExclusionVolume_BrushComponent0/*Ref BrushComponent'Default__TdMovementExclusionVolume.BrushComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdMovementExclusionVolume_BrushComponent0/*Ref BrushComponent'Default__TdMovementExclusionVolume.BrushComponent0'*/,
		};
		CollisionComponent = Default__TdMovementExclusionVolume_BrushComponent0/*Ref BrushComponent'Default__TdMovementExclusionVolume.BrushComponent0'*/;
		SupportedEvents = default;
	}
}
}