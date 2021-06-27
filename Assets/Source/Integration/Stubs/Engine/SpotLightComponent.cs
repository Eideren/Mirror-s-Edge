namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SpotLightComponent : PointLightComponent/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public/*()*/ float InnerConeAngle;
	public/*()*/ float OuterConeAngle;
	public /*const export editinline */DrawLightConeComponent PreviewInnerCone;
	public /*const export editinline */DrawLightConeComponent PreviewOuterCone;
	public/*()*/ float SpotLightPenumbraAngle;
	
	public SpotLightComponent()
	{
		// Object Offset:0x003ED0B6
		OuterConeAngle = 44.0f;
		SpotLightPenumbraAngle = 10.0f;
	}
}
}