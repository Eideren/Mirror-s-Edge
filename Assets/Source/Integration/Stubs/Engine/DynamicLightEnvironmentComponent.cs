namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DynamicLightEnvironmentComponent : LightEnvironmentComponent/*
		native*/{
	[native, Const, transient] public/*private*/ Object.Pointer State;
	[Category] public float InvisibleUpdateTime;
	[Category] public float MinTimeBetweenFullUpdates;
	[Category] public int NumVolumeVisibilitySamples;
	[Category] public Object.LinearColor AmbientShadowColor;
	[Category] public Object.Vector AmbientShadowSourceDirection;
	[Category] public Object.LinearColor AmbientGlow;
	[Category] public float LightDesaturation;
	[Category] public float LightDistance;
	[Category] public float ShadowDistance;
	[Category] public bool bCastShadows;
	[Category] public bool bDynamic;
	[Category] public bool bSynthesizePointLight;
	[Category] public bool bSynthesizeSHLight;
	[Category] public float ModShadowFadeoutTime;
	[Category] public float ModShadowFadeoutExponent;
	[Category] public LightComponent.EShadowFilterQuality ShadowFilterQuality;
	[Category] public LightComponent.ELightShadowMode LightShadowMode;
	[Category] public float BouncedLightingIntensity;
	[Category] public float BouncedLightingDesaturation;
	
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