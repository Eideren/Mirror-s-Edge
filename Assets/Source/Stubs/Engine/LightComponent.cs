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
		public/*()*/ bool BSP;
		public/*()*/ bool Static;
		public/*()*/ bool Dynamic;
		public/*()*/ bool CompositeDynamic;
		public/*()*/ bool Skybox;
		public/*()*/ bool Unnamed_1;
		public/*()*/ bool Unnamed_2;
		public/*()*/ bool Unnamed_3;
		public/*()*/ bool Unnamed_4;
		public/*()*/ bool Unnamed_5;
		public/*()*/ bool Unnamed_6;
		public/*()*/ bool Cinematic_1;
		public/*()*/ bool Cinematic_2;
		public/*()*/ bool Cinematic_3;
		public/*()*/ bool Cinematic_4;
		public/*()*/ bool Cinematic_5;
		public/*()*/ bool Cinematic_6;
		public/*()*/ bool Gameplay_1;
		public/*()*/ bool Gameplay_2;
		public/*()*/ bool Gameplay_3;
		public/*()*/ bool Gameplay_4;
	
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
	
	public /*private noimport native const transient */Object.Pointer SceneInfo;
	public /*native const transient */Object.Matrix WorldToLight;
	public /*native const transient */Object.Matrix LightToWorld;
	public /*duplicatetransient const */Object.Guid LightGuid;
	public /*duplicatetransient const */Object.Guid LightmapGuid;
	public/*()*/ /*interp const */float Brightness;
	public/*()*/ /*interp const */Object.Color LightColor;
	public/*()*/ /*const export editinline */LightFunction Function;
	public/*()*/ /*const */bool bEnabled;
	public/*()*/ /*const */bool CastShadows;
	public/*()*/ /*const */bool CastStaticShadows;
	public/*()*/ bool CastDynamicShadows;
	public/*()*/ bool bCastCompositeShadow;
	public /*const deprecated */bool RequireDynamicShadows;
	public/*()*/ /*const */bool bForceDynamicLight;
	public/*()*/ /*const */bool UseDirectLightMap;
	public /*const */bool bHasLightEverBeenBuiltIntoLightMap;
	public/*()*/ /*const */bool bOnlyAffectSameAndSpecifiedLevels;
	public/*()*/ /*const */bool bCanAffectDynamicPrimitivesOutsideDynamicChannel;
	public/*()*/ /*const export editinline */LightEnvironmentComponent LightEnvironment;
	public/*()*/ /*const */array<name> OtherLevelsToAffect;
	public/*()*/ /*const */LightComponent.LightingChannelContainer LightingChannels;
	public/*()*/ bool bUseVolumes;
	public/*()*/ /*editoronly const */array<Brush> InclusionVolumes;
	public/*()*/ /*editoronly const */array<Brush> ExclusionVolumes;
	public /*native const */array<Object.Pointer> InclusionConvexVolumes;
	public /*native const */array<Object.Pointer> ExclusionConvexVolumes;
	public/*()*/ /*const editconst */LightComponent.ELightAffectsClassification LightAffectsClassification;
	public/*()*/ LightComponent.ELightShadowMode LightShadowMode;
	public/*()*/ Object.LinearColor ModShadowColor;
	public/*()*/ float ModShadowFadeoutTime;
	public/*()*/ float ModShadowFadeoutExponent;
	public /*duplicatetransient native const */int LightListIndex;
	public/*()*/ LightComponent.EShadowProjectionTechnique ShadowProjectionTechnique;
	public/*()*/ LightComponent.EShadowFilterQuality ShadowFilterQuality;
	public/*()*/ int MinShadowResolution;
	public/*()*/ int MaxShadowResolution;
	
	// Export ULightComponent::execSetEnabled(FFrame&, void* const)
	public virtual /*native final function */void SetEnabled(bool bSetEnabled)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export ULightComponent::execSetLightProperties(FFrame&, void* const)
	public virtual /*native final function */void SetLightProperties(/*optional */float? _NewBrightness = default, /*optional */Object.Color? _NewLightColor = default, /*optional */LightFunction? _NewLightFunction = default)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export ULightComponent::execGetOrigin(FFrame&, void* const)
	public virtual /*native final function */Object.Vector GetOrigin()
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export ULightComponent::execGetDirection(FFrame&, void* const)
	public virtual /*native final function */Object.Vector GetDirection()
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export ULightComponent::execUpdateColorAndBrightness(FFrame&, void* const)
	public virtual /*native final function */void UpdateColorAndBrightness()
	{
		#warning NATIVE FUNCTION !
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