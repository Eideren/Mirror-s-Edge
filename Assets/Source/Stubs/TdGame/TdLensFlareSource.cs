namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdLensFlareSource : LensFlareSource/*
		placeable
		hidecategories(Navigation)*/{
	public TdLensFlareSource()
	{
		var Default__TdLensFlareSource_DrawInnerCone0 = new DrawLightConeComponent
		{
		}/* Reference: DrawLightConeComponent'Default__TdLensFlareSource.DrawInnerCone0' */;
		var Default__TdLensFlareSource_DrawOuterCone0 = new DrawLightConeComponent
		{
		}/* Reference: DrawLightConeComponent'Default__TdLensFlareSource.DrawOuterCone0' */;
		var Default__TdLensFlareSource_DrawRadius0 = new DrawLightRadiusComponent
		{
		}/* Reference: DrawLightRadiusComponent'Default__TdLensFlareSource.DrawRadius0' */;
		var Default__TdLensFlareSource_LensFlareComponent0 = new LensFlareComponent
		{
			// Object Offset:0x01B73901
			PreviewInnerCone = Default__TdLensFlareSource_DrawInnerCone0/*Ref DrawLightConeComponent'Default__TdLensFlareSource.DrawInnerCone0'*/,
			PreviewOuterCone = Default__TdLensFlareSource_DrawOuterCone0/*Ref DrawLightConeComponent'Default__TdLensFlareSource.DrawOuterCone0'*/,
			PreviewRadius = Default__TdLensFlareSource_DrawRadius0/*Ref DrawLightRadiusComponent'Default__TdLensFlareSource.DrawRadius0'*/,
		}/* Reference: LensFlareComponent'Default__TdLensFlareSource.LensFlareComponent0' */;
		var Default__TdLensFlareSource_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdLensFlareSource.Sprite' */;
		var Default__TdLensFlareSource_ArrowComponent0 = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdLensFlareSource.ArrowComponent0' */;
		// Object Offset:0x00586C97
		LensFlareComp = Default__TdLensFlareSource_LensFlareComponent0/*Ref LensFlareComponent'Default__TdLensFlareSource.LensFlareComponent0'*/;
		bNoDelete = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdLensFlareSource_Sprite/*Ref SpriteComponent'Default__TdLensFlareSource.Sprite'*/,
			Default__TdLensFlareSource_DrawInnerCone0/*Ref DrawLightConeComponent'Default__TdLensFlareSource.DrawInnerCone0'*/,
			Default__TdLensFlareSource_DrawOuterCone0/*Ref DrawLightConeComponent'Default__TdLensFlareSource.DrawOuterCone0'*/,
			Default__TdLensFlareSource_DrawRadius0/*Ref DrawLightRadiusComponent'Default__TdLensFlareSource.DrawRadius0'*/,
			Default__TdLensFlareSource_LensFlareComponent0/*Ref LensFlareComponent'Default__TdLensFlareSource.LensFlareComponent0'*/,
			Default__TdLensFlareSource_ArrowComponent0/*Ref ArrowComponent'Default__TdLensFlareSource.ArrowComponent0'*/,
		};
	}
}
}