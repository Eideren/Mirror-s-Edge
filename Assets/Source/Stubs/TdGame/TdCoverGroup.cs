namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdCoverGroup : CoverGroup/*
		native
		placeable
		hidecategories(Navigation,Movement,Collision)*/{
	public/*(CoverVolume)*/ TdCoverGroupVolume RestraintVolume;
	public/*()*/ /*editconst */array</*editconst */Actor.NavReference> GeneratedCoverLinkRefs;
	
	// Export UTdCoverGroup::execEnableGroup(FFrame&, void* const)
	public override /*native function */void EnableGroup()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdCoverGroup::execDisableGroup(FFrame&, void* const)
	public override /*native function */void DisableGroup()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdCoverGroup::execToggleGroup(FFrame&, void* const)
	public override /*native function */void ToggleGroup()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdCoverGroup::execContains(FFrame&, void* const)
	public override /*native function */bool Contains(CoverLink Link)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public TdCoverGroup()
	{
		// Object Offset:0x0053E0E8
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new SpriteComponent
			{
				// Object Offset:0x02E51EC5
				Scale = 2.0f,
			}/* Reference: SpriteComponent'Default__TdCoverGroup.Sprite' */,
			LoadAsset<CoverGroupRenderingComponent>("Default__TdCoverGroup.CoverGroupRenderer")/*Ref CoverGroupRenderingComponent'Default__TdCoverGroup.CoverGroupRenderer'*/,
			//Components[2]=
			new TdCoverGroupRenderingComponent
			{
				// Object Offset:0x03121A3E
				AlwaysLoadOnClient = false,
				AlwaysLoadOnServer = false,
			}/* Reference: TdCoverGroupRenderingComponent'Default__TdCoverGroup.TdCoverGroupRenderer' */,
		};
	}
}
}