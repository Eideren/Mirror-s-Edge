namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdCoverGroup : CoverGroup/*
		native
		placeable
		hidecategories(Navigation,Movement,Collision)*/{
	[Category("CoverVolume")] public TdCoverGroupVolume RestraintVolume;
	[Category] [editconst] public array</*editconst */Actor.NavReference> GeneratedCoverLinkRefs;
	
	// Export UTdCoverGroup::execEnableGroup(FFrame&, void* const)
	public override /*native function */void EnableGroup()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTdCoverGroup::execDisableGroup(FFrame&, void* const)
	public override /*native function */void DisableGroup()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTdCoverGroup::execToggleGroup(FFrame&, void* const)
	public override /*native function */void ToggleGroup()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTdCoverGroup::execContains(FFrame&, void* const)
	public override /*native function */bool Contains(CoverLink Link)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public TdCoverGroup()
	{
		var Default__TdCoverGroup_Sprite = new SpriteComponent
		{
			// Object Offset:0x02E51EC5
			Scale = 2.0f,
		}/* Reference: SpriteComponent'Default__TdCoverGroup.Sprite' */;
		var Default__TdCoverGroup_CoverGroupRenderer = new CoverGroupRenderingComponent
		{
		}/* Reference: CoverGroupRenderingComponent'Default__TdCoverGroup.CoverGroupRenderer' */;
		var Default__TdCoverGroup_TdCoverGroupRenderer = new TdCoverGroupRenderingComponent
		{
			// Object Offset:0x03121A3E
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: TdCoverGroupRenderingComponent'Default__TdCoverGroup.TdCoverGroupRenderer' */;
		// Object Offset:0x0053E0E8
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdCoverGroup_Sprite/*Ref SpriteComponent'Default__TdCoverGroup.Sprite'*/,
			Default__TdCoverGroup_CoverGroupRenderer/*Ref CoverGroupRenderingComponent'Default__TdCoverGroup.CoverGroupRenderer'*/,
			Default__TdCoverGroup_TdCoverGroupRenderer/*Ref TdCoverGroupRenderingComponent'Default__TdCoverGroup.TdCoverGroupRenderer'*/,
		};
	}
}
}