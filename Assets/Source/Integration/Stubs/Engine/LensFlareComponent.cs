namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class LensFlareComponent : PrimitiveComponent/*
		native
		editinlinenew
		hidecategories(Object,Physics,Collision)*/{
	public partial struct LensFlareElementInstance
	{
	};
	
	[Category] [Const] public LensFlare Template;
	[Const, export, editinline] public DrawLightConeComponent PreviewInnerCone;
	[Const, export, editinline] public DrawLightConeComponent PreviewOuterCone;
	[Const, export, editinline] public DrawLightRadiusComponent PreviewRadius;
	[Category] public bool bAutoActivate;
	[transient] public bool bIsActive;
	[transient] public bool bHasTranslucency;
	[transient] public bool bHasUnlitTranslucency;
	[transient] public bool bHasUnlitDistortion;
	[transient] public bool bUsesSceneColor;
	[transient] public float OuterCone;
	[transient] public float InnerCone;
	[transient] public float ConeFudgeFactor;
	[transient] public float Radius;
	[Category("Rendering")] public Object.LinearColor SourceColor;
	[native, Const] public Object.Pointer ReleaseResourcesFence;
	
	// Export ULensFlareComponent::execSetTemplate(FFrame&, void* const)
	public virtual /*native final function */void SetTemplate(LensFlare NewTemplate)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export ULensFlareComponent::execSetSourceColor(FFrame&, void* const)
	public virtual /*native function */void SetSourceColor(Object.LinearColor InSourceColor)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export ULensFlareComponent::execSetIsActive(FFrame&, void* const)
	public virtual /*native function */void SetIsActive(bool bInIsActive)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
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