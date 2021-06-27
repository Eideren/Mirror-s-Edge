namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DynamicLightEnvironmentComponent : LightEnvironmentComponent/*
		native*/{
	public /*private native const transient */Object.Pointer State;
	public/*()*/ float InvisibleUpdateTime;
	public/*()*/ float MinTimeBetweenFullUpdates;
	public/*()*/ int NumVolumeVisibilitySamples;
	public/*()*/ Object.LinearColor AmbientShadowColor;
	public/*()*/ Object.Vector AmbientShadowSourceDirection;
	public/*()*/ Object.LinearColor AmbientGlow;
	public/*()*/ float LightDesaturation;
	public/*()*/ float LightDistance;
	public/*()*/ float ShadowDistance;
	public/*()*/ bool bCastShadows;
	public/*()*/ bool bDynamic;
	public/*()*/ bool bSynthesizePointLight;
	public/*()*/ bool bSynthesizeSHLight;
	public/*()*/ float ModShadowFadeoutTime;
	public/*()*/ float ModShadowFadeoutExponent;
	public/*()*/ LightComponent.EShadowFilterQuality ShadowFilterQuality;
	public/*()*/ LightComponent.ELightShadowMode LightShadowMode;
	public/*()*/ float BouncedLightingIntensity;
	public/*()*/ float BouncedLightingDesaturation;
	
	public DynamicLightEnvironmentComponent()
	{
		// Object Offset:0x002EDE03
		InvisibleUpdateTime = 4.0f;
		MinTimeBetweenFullUpdates = 0.30f;
		NumVolumeVisibilitySamples = 1;
		AmbientShadowColor = new LinearColor
		{
			R=0.150f,
			G=0.150f,
			B=0.150f,
			A=1.0f
		};
		AmbientShadowSourceDirection = new Vector
		{
			X=0.0f,
			Y=0.0f,
			Z=1.0f
		};
		AmbientGlow = new LinearColor
		{
			R=0.0f,
			G=0.0f,
			B=0.0f,
			A=1.0f
		};
		LightDistance = 1.50f;
		ShadowDistance = 1.0f;
		bCastShadows = true;
		bDynamic = true;
		bSynthesizePointLight = true;
		bSynthesizeSHLight = true;
		ModShadowFadeoutExponent = 3.0f;
		LightShadowMode = LightComponent.ELightShadowMode.LightShadow_Modulate;
		BouncedLightingIntensity = 0.10f;
		BouncedLightingDesaturation = -1.0f;
		TickGroup = Object.ETickingGroup.TG_PostUpdateWork;
	}
}
}