namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdLensFlareSource : LensFlareSource/*
		placeable
		hidecategories(Navigation)*/{
	public TdLensFlareSource()
	{
		// Object Offset:0x00586C97
		LensFlareComp = new LensFlareComponent
		{
			// Object Offset:0x01B73901
			PreviewInnerCone = LoadAsset<DrawLightConeComponent>("Default__TdLensFlareSource.DrawInnerCone0")/*Ref DrawLightConeComponent'Default__TdLensFlareSource.DrawInnerCone0'*/,
			PreviewOuterCone = LoadAsset<DrawLightConeComponent>("Default__TdLensFlareSource.DrawOuterCone0")/*Ref DrawLightConeComponent'Default__TdLensFlareSource.DrawOuterCone0'*/,
			PreviewRadius = LoadAsset<DrawLightRadiusComponent>("Default__TdLensFlareSource.DrawRadius0")/*Ref DrawLightRadiusComponent'Default__TdLensFlareSource.DrawRadius0'*/,
		}/* Reference: LensFlareComponent'Default__TdLensFlareSource.LensFlareComponent0' */;
		bNoDelete = false;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdLensFlareSource.Sprite")/*Ref SpriteComponent'Default__TdLensFlareSource.Sprite'*/,
			LoadAsset<DrawLightConeComponent>("Default__TdLensFlareSource.DrawInnerCone0")/*Ref DrawLightConeComponent'Default__TdLensFlareSource.DrawInnerCone0'*/,
			LoadAsset<DrawLightConeComponent>("Default__TdLensFlareSource.DrawOuterCone0")/*Ref DrawLightConeComponent'Default__TdLensFlareSource.DrawOuterCone0'*/,
			LoadAsset<DrawLightRadiusComponent>("Default__TdLensFlareSource.DrawRadius0")/*Ref DrawLightRadiusComponent'Default__TdLensFlareSource.DrawRadius0'*/,
			//Components[4]=
			new LensFlareComponent
			{
				// Object Offset:0x01B73901
				PreviewInnerCone = LoadAsset<DrawLightConeComponent>("Default__TdLensFlareSource.DrawInnerCone0")/*Ref DrawLightConeComponent'Default__TdLensFlareSource.DrawInnerCone0'*/,
				PreviewOuterCone = LoadAsset<DrawLightConeComponent>("Default__TdLensFlareSource.DrawOuterCone0")/*Ref DrawLightConeComponent'Default__TdLensFlareSource.DrawOuterCone0'*/,
				PreviewRadius = LoadAsset<DrawLightRadiusComponent>("Default__TdLensFlareSource.DrawRadius0")/*Ref DrawLightRadiusComponent'Default__TdLensFlareSource.DrawRadius0'*/,
			}/* Reference: LensFlareComponent'Default__TdLensFlareSource.LensFlareComponent0' */,
			LoadAsset<ArrowComponent>("Default__TdLensFlareSource.ArrowComponent0")/*Ref ArrowComponent'Default__TdLensFlareSource.ArrowComponent0'*/,
		};
	}
}
}