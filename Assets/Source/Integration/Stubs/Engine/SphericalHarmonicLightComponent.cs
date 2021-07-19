namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SphericalHarmonicLightComponent : LightComponent/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	[Category] public Object.SHVectorRGB WorldSpaceIncidentLighting;
	
	public SphericalHarmonicLightComponent()
	{
		// Object Offset:0x003ECF23
		CastShadows = false;
		bCastCompositeShadow = true;
	}
}
}