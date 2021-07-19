namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class LightComponent : ActorComponent/*
		abstract
		native
		collapsecategories
		noexport*/{
	public enum ELightAffectsClassification 
	{
		LAC_USER_SELECTED,
		LAC_DYNAMIC_AFFECTING,
		LAC_STATIC_AFFECTING,
		LAC_DYNAMIC_AND_STATIC_AFFECTING,
		LAC_MAX
	};
	
	public enum ELightShadowMode 
	{
		LightShadow_Normal,
		LightShadow_Modulate,
		LightShadow_ModulateBetter,
		LightShadow_MAX
	};
	
	public enum EShadowProjectionTechnique 
	{
		ShadowProjTech_Default,
		ShadowProjTech_PCF,
		ShadowProjTech_VSM,
		ShadowProjTech_BPCF_Low,
		ShadowProjTech_BPCF_Medium,
		ShadowProjTech_BPCF_High,
		ShadowProjTech_MAX
	};
	
	public enum EShadowFilterQuality 
	{
		SFQ_Low,
		SFQ_Medium,
		SFQ_High,
		SFQ_MAX
	};
	
	public partial struct LightingChannelContainer
	{
		public bool bInitialized;
		[Category] public bool BSP;
		[Category] public bool Static;
		[Category] public bool Dynamic;
		[Category] public bool CompositeDynamic;
		[Category] public bool Skybox;
		[Category] public bool Unnamed_1;
		[Category] public bool Unnamed_2;
		[Category] public bool Unnamed_3;
		[Category] public bool Unnamed_4;
		[Category] public bool Unnamed_5;
		[Category] public bool Unnamed_6;
		[Category] public bool Cinematic_1;
		[Category] public bool Cinematic_2;
		[Category] public bool Cinematic_3;
		[Category] public bool Cinematic_4;
		[Category] public bool Cinematic_5;
		[Category] public bool Cinematic_6;
		[Category] public bool Gameplay_1;
		[Category] public bool Gameplay_2;
		[Category] public bool Gameplay_3;
		[Category] public bool Gameplay_4;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0025BE04
	//		bInitialized = false;
	//		BSP = false;
	//		Static = false;
	//		Dynamic = false;
	//		CompositeDynamic = false;
	//		Skybox = false;
	//		Unnamed = false;
	//		Unnamed = false;
	//		Unnamed = false;
	//		Unnamed = false;
	//		Unnamed = false;
	//		Unnamed = false;
	//		Cinematic = false;
	//		Cinematic = false;
	//		Cinematic = false;
	//		Cinematic = false;
	//		Cinematic = false;
	//		Cinematic = false;
	//		Gameplay = false;
	//		Gameplay = false;
	//		Gameplay = false;
	//		Gameplay = false;
	//	}
	};
	
	[noimport, native, Const, transient] public/*private*/ Object.Pointer SceneInfo;
	[native, Const, transient] public Object.Matrix WorldToLight;
	[native, Const, transient] public Object.Matrix LightToWorld;
	[duplicatetransient, Const] public Object.Guid LightGuid;
	[duplicatetransient, Const] public Object.Guid LightmapGuid;
	[Category] [interp, Const] public float Brightness;
	[Category] [interp, Const] public Object.Color LightColor;
	[Category] [Const, export, editinline] public LightFunction Function;
	[Category] [Const] public bool bEnabled;
	[Category] [Const] public bool CastShadows;
	[Category] [Const] public bool CastStaticShadows;
	[Category] public bool CastDynamicShadows;
	[Category] public bool bCastCompositeShadow;
	[Const, deprecated] public bool RequireDynamicShadows;
	[Category] [Const] public bool bForceDynamicLight;
	[Category] [Const] public bool UseDirectLightMap;
	[Const] public bool bHasLightEverBeenBuiltIntoLightMap;
	[Category] [Const] public bool bOnlyAffectSameAndSpecifiedLevels;
	[Category] [Const] public bool bCanAffectDynamicPrimitivesOutsideDynamicChannel;
	[Category] [Const, export, editinline] public LightEnvironmentComponent LightEnvironment;
	[Category] [Const] public array<name> OtherLevelsToAffect;
	[Category] [Const] public LightComponent.LightingChannelContainer LightingChannels;
	[Category] public bool bUseVolumes;
	[Category] [editoronly, Const] public array<Brush> InclusionVolumes;
	[Category] [editoronly, Const] public array<Brush> ExclusionVolumes;
	[native, Const] public array<Object.Pointer> InclusionConvexVolumes;
	[native, Const] public array<Object.Pointer> ExclusionConvexVolumes;
	[Category] [Const, editconst] public LightComponent.ELightAffectsClassification LightAffectsClassification;
	[Category] public LightComponent.ELightShadowMode LightShadowMode;
	[Category] public Object.LinearColor ModShadowColor;
	[Category] public float ModShadowFadeoutTime;
	[Category] public float ModShadowFadeoutExponent;
	[duplicatetransient, native, Const] public int LightListIndex;
	[Category] public LightComponent.EShadowProjectionTechnique ShadowProjectionTechnique;
	[Category] public LightComponent.EShadowFilterQuality ShadowFilterQuality;
	[Category] public int MinShadowResolution;
	[Category] public int MaxShadowResolution;
	
	// Export ULightComponent::execSetEnabled(FFrame&, void* const)
	public virtual /*native final function */void SetEnabled(bool bSetEnabled)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export ULightComponent::execSetLightProperties(FFrame&, void* const)
	public virtual /*native final function */void SetLightProperties(/*optional */float? _NewBrightness = default, /*optional */Object.Color? _NewLightColor = default, /*optional */LightFunction _NewLightFunction = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export ULightComponent::execGetOrigin(FFrame&, void* const)
	public virtual /*native final function */Object.Vector GetOrigin()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export ULightComponent::execGetDirection(FFrame&, void* const)
	public virtual /*native final function */Object.Vector GetDirection()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export ULightComponent::execUpdateColorAndBrightness(FFrame&, void* const)
	public virtual /*native final function */void UpdateColorAndBrightness()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public virtual /*function */void OnUpdatePropertyLightColor()
	{
		// stub
	}
	
	public virtual /*function */void OnUpdatePropertyBrightness()
	{
		// stub
	}
	
	public LightComponent()
	{
		// Object Offset:0x0030D5EC
		Brightness = 1.0f;
		LightColor = new Color
		{
			R=255,
			G=255,
			B=255,
			A=0
		};
		bEnabled = true;
		CastShadows = true;
		CastStaticShadows = true;
		CastDynamicShadows = true;
		LightingChannels = new LightComponent.LightingChannelContainer
		{
			bInitialized = true,
			BSP = true,
			Static = true,
			Dynamic = true,
			CompositeDynamic = true,
			Skybox = false,
			Unnamed_1 = false,
			Unnamed_2 = false,
			Unnamed_3 = false,
			Unnamed_4 = false,
			Unnamed_5 = false,
			Unnamed_6 = false,
			Cinematic_1 = false,
			Cinematic_2 = false,
			Cinematic_3 = false,
			Cinematic_4 = false,
			Cinematic_5 = false,
			Cinematic_6 = false,
			Gameplay_1 = false,
			Gameplay_2 = false,
			Gameplay_3 = false,
			Gameplay_4 = false,
		};
		ModShadowColor = new LinearColor
		{
			R=0.0f,
			G=0.0f,
			B=0.0f,
			A=1.0f
		};
		ModShadowFadeoutExponent = 3.0f;
	}
}
}