namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PointLightComponent : LightComponent/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	public/*()*/ /*interp */float ShadowRadiusMultiplier;
	public/*()*/ float PointLightRadius;
	public/*(Baker)*/ bool bUseBakerCutOffRadius;
	public/*(Baker)*/ float BakerCutOffRadius;
	public/*()*/ int Photons;
	public/*()*/ int PhotonIntensity;
	public/*()*/ /*interp */float Radius;
	public/*()*/ /*interp */float FalloffExponent;
	public/*()*/ float ShadowFalloffExponent;
	public /*const */Object.Matrix CachedParentToWorld;
	public/*()*/ /*const */Object.Vector Translation;
	public /*const export editinline */DrawLightRadiusComponent PreviewLightRadius;
	
	// Export UPointLightComponent::execSetTranslation(FFrame&, void* const)
	public virtual /*native final function */void SetTranslation(Object.Vector NewTranslation)
	{
		#warning NATIVE FUNCTION !
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