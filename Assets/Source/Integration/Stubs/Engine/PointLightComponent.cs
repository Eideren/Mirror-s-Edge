namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PointLightComponent : LightComponent/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	[Category] [interp] public float ShadowRadiusMultiplier;
	[Category] public float PointLightRadius;
	[Category("Baker")] public bool bUseBakerCutOffRadius;
	[Category("Baker")] public float BakerCutOffRadius;
	[Category] public int Photons;
	[Category] public int PhotonIntensity;
	[Category] [interp] public float Radius;
	[Category] [interp] public float FalloffExponent;
	[Category] public float ShadowFalloffExponent;
	[Const] public Object.Matrix CachedParentToWorld;
	[Category] [Const] public Object.Vector Translation;
	[Const, export, editinline] public DrawLightRadiusComponent PreviewLightRadius;
	
	// Export UPointLightComponent::execSetTranslation(FFrame&, void* const)
	public virtual /*native final function */void SetTranslation(Object.Vector NewTranslation)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public PointLightComponent()
	{
		// Object Offset:0x003A293D
		ShadowRadiusMultiplier = 1.10f;
		PointLightRadius = 20.0f;
		BakerCutOffRadius = 1024.0f;
		Photons = 100000;
		PhotonIntensity = 1;
		Radius = 1024.0f;
		FalloffExponent = 2.0f;
		ShadowFalloffExponent = 2.0f;
	}
}
}