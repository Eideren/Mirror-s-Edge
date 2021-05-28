namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class LensFlareComponent : PrimitiveComponent/*
		native
		editinlinenew
		hidecategories(Object,Physics,Collision)*/{
	public partial struct LensFlareElementInstance
	{
	};
	
	public/*()*/ /*const */LensFlare Template;
	public /*const export editinline */DrawLightConeComponent PreviewInnerCone;
	public /*const export editinline */DrawLightConeComponent PreviewOuterCone;
	public /*const export editinline */DrawLightRadiusComponent PreviewRadius;
	public/*()*/ bool bAutoActivate;
	public /*transient */bool bIsActive;
	public /*transient */bool bHasTranslucency;
	public /*transient */bool bHasUnlitTranslucency;
	public /*transient */bool bHasUnlitDistortion;
	public /*transient */bool bUsesSceneColor;
	public /*transient */float OuterCone;
	public /*transient */float InnerCone;
	public /*transient */float ConeFudgeFactor;
	public /*transient */float Radius;
	public/*(Rendering)*/ Object.LinearColor SourceColor;
	public /*native const */Object.Pointer ReleaseResourcesFence;
	
	// Export ULensFlareComponent::execSetTemplate(FFrame&, void* const)
	public virtual /*native final function */void SetTemplate(LensFlare NewTemplate)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export ULensFlareComponent::execSetSourceColor(FFrame&, void* const)
	public virtual /*native function */void SetSourceColor(Object.LinearColor InSourceColor)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export ULensFlareComponent::execSetIsActive(FFrame&, void* const)
	public virtual /*native function */void SetIsActive(bool bInIsActive)
	{
		#warning NATIVE FUNCTION !
	}
	
	public LensFlareComponent()
	{
		// Object Offset:0x0034F7E1
		bAutoActivate = true;
		SourceColor = new LinearColor
		{
			R=1.0f,
			G=1.0f,
			B=1.0f,
			A=1.0f
		};
		bTickInEditor = true;
		TickGroup = Object.ETickingGroup.TG_PostAsyncWork;
	}
}
}