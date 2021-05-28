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
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*simulated function */void OnToggle(SeqAct_Toggle Action)
	{
	
	}
	
	public virtual /*simulated function */void SetFloatParameter(name ParameterName, float Param)
	{
	
	}
	
	public virtual /*simulated function */void SetVectorParameter(name ParameterName, Object.Vector Param)
	{
	
	}
	
	public virtual /*simulated function */void SetColorParameter(name ParameterName, Object.LinearColor Param)
	{
	
	}
	
	public virtual /*simulated function */void SetExtColorParameter(name ParameterName, float Red, float Green, float Blue, float Alpha)
	{
	
	}
	
	public virtual /*simulated function */void SetActorParameter(name ParameterName, Actor Param)
	{
	
	}
	
	public LensFlareSource()
	{
		// Object Offset:0x0034FEE3
		LensFlareComp = new LensFlareComponent
		{
			// Object Offset:0x0046A69B
			PreviewInnerCone = LoadAsset<DrawLightConeComponent>("Default__LensFlareSource.DrawInnerCone0")/*Ref DrawLightConeComponent'Default__LensFlareSource.DrawInnerCone0'*/,
			PreviewOuterCone = LoadAsset<DrawLightConeComponent>("Default__LensFlareSource.DrawOuterCone0")/*Ref DrawLightConeComponent'Default__LensFlareSource.DrawOuterCone0'*/,
			PreviewRadius = LoadAsset<DrawLightRadiusComponent>("Default__LensFlareSource.DrawRadius0")/*Ref DrawLightRadiusComponent'Default__LensFlareSource.DrawRadius0'*/,
		}/* Reference: LensFlareComponent'Default__LensFlareSource.LensFlareComponent0' */;
		bNoDelete = true;
		bHardAttach = true;
		bGameRelevant = true;
		bEdShouldSnap = true;
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new SpriteComponent
			{
				// Object Offset:0x004CFBD6
				Sprite = LoadAsset<Texture2D>("EngineResources.S_Emitter")/*Ref Texture2D'EngineResources.S_Emitter'*/,
				bIsScreenSizeScaled = true,
				ScreenSize = 0.00250f,
				HiddenGame = true,
				AlwaysLoadOnClient = false,
				AlwaysLoadOnServer = false,
			}/* Reference: SpriteComponent'Default__LensFlareSource.Sprite' */,
			LoadAsset<DrawLightConeComponent>("Default__LensFlareSource.DrawInnerCone0")/*Ref DrawLightConeComponent'Default__LensFlareSource.DrawInnerCone0'*/,
			//Components[2]=
			new DrawLightConeComponent
			{
				// Object Offset:0x00468B3F
				ConeColor = new Color
				{
					R=200,
					G=255,
					B=255,
					A=255
				},
			}/* Reference: DrawLightConeComponent'Default__LensFlareSource.DrawOuterCone0' */,
			LoadAsset<DrawLightRadiusComponent>("Default__LensFlareSource.DrawRadius0")/*Ref DrawLightRadiusComponent'Default__LensFlareSource.DrawRadius0'*/,
			//Components[4]=
			new LensFlareComponent
			{
				// Object Offset:0x0046A69B
				PreviewInnerCone = LoadAsset<DrawLightConeComponent>("Default__LensFlareSource.DrawInnerCone0")/*Ref DrawLightConeComponent'Default__LensFlareSource.DrawInnerCone0'*/,
				PreviewOuterCone = LoadAsset<DrawLightConeComponent>("Default__LensFlareSource.DrawOuterCone0")/*Ref DrawLightConeComponent'Default__LensFlareSource.DrawOuterCone0'*/,
				PreviewRadius = LoadAsset<DrawLightRadiusComponent>("Default__LensFlareSource.DrawRadius0")/*Ref DrawLightRadiusComponent'Default__LensFlareSource.DrawRadius0'*/,
			}/* Reference: LensFlareComponent'Default__LensFlareSource.LensFlareComponent0' */,
			//Components[5]=
			new ArrowComponent
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
			}/* Reference: ArrowComponent'Default__LensFlareSource.ArrowComponent0' */,
		};
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
	}
}
}