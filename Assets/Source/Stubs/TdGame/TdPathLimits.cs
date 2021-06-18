namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPathLimits : Info/*
		native
		placeable
		hidecategories(Navigation,Movement,Collision)*/{
	public/*(VolumeLimits)*/ Volume VolumeLimit;
	public/*()*/ float LimitRadius;
	public/*()*/ float LimitHeight;
	public bool bEnabled;
	
	// Export UTdPathLimits::execContains(FFrame&, void* const)
	public virtual /*native function */bool Contains(Object.Vector TestLocation)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*simulated function */void OnToggle(SeqAct_Toggle Action)
	{
	
	}
	
	public TdPathLimits()
	{
		var Default__TdPathLimits_Sprite = new SpriteComponent
		{
			// Object Offset:0x02E524F1
			Sprite = LoadAsset<Texture2D>("EditorMaterials.CovergroupIcon")/*Ref Texture2D'EditorMaterials.CovergroupIcon'*/,
		}/* Reference: SpriteComponent'Default__TdPathLimits.Sprite' */;
		var Default__TdPathLimits_LimitsRenderer = new TdPathLimitsRenderingComponent
		{
			// Object Offset:0x0312212E
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: TdPathLimitsRenderingComponent'Default__TdPathLimits.LimitsRenderer' */;
		// Object Offset:0x0060A2E2
		bEnabled = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdPathLimits_Sprite,
			Default__TdPathLimits_LimitsRenderer,
		};
	}
}
}