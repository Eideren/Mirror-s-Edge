namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class LensFlareSource : Actor/*
		native
		placeable
		hidecategories(Navigation)*/{
	public/*()*/ /*const editconst export editinline */LensFlareComponent LensFlareComp;
	public /*repnotify */bool bCurrentlyActive;
	
	//replication
	//{
	//	 if(bNoDelete)
	//		bCurrentlyActive;
	//}
	
	// Export ULensFlareSource::execSetTemplate(FFrame&, void* const)
	public virtual /*native final function */void SetTemplate(LensFlare NewTemplate)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	public virtual /*simulated function */void OnToggle(SeqAct_Toggle Action)
	{
		// stub
	}
	
	public virtual /*simulated function */void SetFloatParameter(name ParameterName, float Param)
	{
		// stub
	}
	
	public virtual /*simulated function */void SetVectorParameter(name ParameterName, Object.Vector Param)
	{
		// stub
	}
	
	public virtual /*simulated function */void SetColorParameter(name ParameterName, Object.LinearColor Param)
	{
		// stub
	}
	
	public virtual /*simulated function */void SetExtColorParameter(name ParameterName, float Red, float Green, float Blue, float Alpha)
	{
		// stub
	}
	
	public virtual /*simulated function */void SetActorParameter(name ParameterName, Actor Param)
	{
		// stub
	}
	
	public LensFlareSource()
	{
		var Default__LensFlareSource_DrawInnerCone0 = new DrawLightConeComponent
		{
		}/* Reference: DrawLightConeComponent'Default__LensFlareSource.DrawInnerCone0' */;
		var Default__LensFlareSource_DrawOuterCone0 = new DrawLightConeComponent
		{
			// Object Offset:0x00468B3F
			ConeColor = new Color
			{
				R=200,
				G=255,
				B=255,
				A=255
			},
		}/* Reference: DrawLightConeComponent'Default__LensFlareSource.DrawOuterCone0' */;
		var Default__LensFlareSource_DrawRadius0 = new DrawLightRadiusComponent
		{
		}/* Reference: DrawLightRadiusComponent'Default__LensFlareSource.DrawRadius0' */;
		var Default__LensFlareSource_LensFlareComponent0 = new LensFlareComponent
		{
			// Object Offset:0x0046A69B
			PreviewInnerCone = Default__LensFlareSource_DrawInnerCone0/*Ref DrawLightConeComponent'Default__LensFlareSource.DrawInnerCone0'*/,
			PreviewOuterCone = Default__LensFlareSource_DrawOuterCone0/*Ref DrawLightConeComponent'Default__LensFlareSource.DrawOuterCone0'*/,
			PreviewRadius = Default__LensFlareSource_DrawRadius0/*Ref DrawLightRadiusComponent'Default__LensFlareSource.DrawRadius0'*/,
		}/* Reference: LensFlareComponent'Default__LensFlareSource.LensFlareComponent0' */;
		var Default__LensFlareSource_Sprite = new SpriteComponent
		{
			// Object Offset:0x004CFBD6
			Sprite = LoadAsset<Texture2D>("EngineResources.S_Emitter")/*Ref Texture2D'EngineResources.S_Emitter'*/,
			bIsScreenSizeScaled = true,
			ScreenSize = 0.00250f,
			HiddenGame = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: SpriteComponent'Default__LensFlareSource.Sprite' */;
		var Default__LensFlareSource_ArrowComponent0 = new ArrowComponent
		{
			// Object Offset:0x00465B4F
			ArrowColor = new Color
			{
				R=0,
				G=255,
				B=128,
				A=255
			},
			ArrowSize = 1.50f,
		}/* Reference: ArrowComponent'Default__LensFlareSource.ArrowComponent0' */;
		// Object Offset:0x0034FEE3
		LensFlareComp = Default__LensFlareSource_LensFlareComponent0/*Ref LensFlareComponent'Default__LensFlareSource.LensFlareComponent0'*/;
		bNoDelete = true;
		bHardAttach = true;
		bGameRelevant = true;
		bEdShouldSnap = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__LensFlareSource_Sprite/*Ref SpriteComponent'Default__LensFlareSource.Sprite'*/,
			Default__LensFlareSource_DrawInnerCone0/*Ref DrawLightConeComponent'Default__LensFlareSource.DrawInnerCone0'*/,
			Default__LensFlareSource_DrawOuterCone0/*Ref DrawLightConeComponent'Default__LensFlareSource.DrawOuterCone0'*/,
			Default__LensFlareSource_DrawRadius0/*Ref DrawLightRadiusComponent'Default__LensFlareSource.DrawRadius0'*/,
			Default__LensFlareSource_LensFlareComponent0/*Ref LensFlareComponent'Default__LensFlareSource.LensFlareComponent0'*/,
			Default__LensFlareSource_ArrowComponent0/*Ref ArrowComponent'Default__LensFlareSource.ArrowComponent0'*/,
		};
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
	}
}
}