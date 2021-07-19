namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SpotLightComponent : PointLightComponent/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	[Category] public float InnerConeAngle;
	[Category] public float OuterConeAngle;
	[Const, export, editinline] public DrawLightConeComponent PreviewInnerCone;
	[Const, export, editinline] public DrawLightConeComponent PreviewOuterCone;
	[Category] public float SpotLightPenumbraAngle;
	
	public SpotLightComponent()
	{
		// Object Offset:0x003ED0B6
		OuterConeAngle = 44.0f;
		SpotLightPenumbraAngle = 10.0f;
	}
}
}