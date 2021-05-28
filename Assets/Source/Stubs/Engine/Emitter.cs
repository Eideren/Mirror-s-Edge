namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Emitter : Actor/*
		native
		placeable
		hidecategories(Navigation)*/{
	public/*()*/ /*const editconst export editinline */ParticleSystemComponent ParticleSystemComponent;
	public bool bDestroyOnSystemFinish;
	public /*repnotify */bool bCurrentlyActive;
	
	//replication
	//{
	//	 if(bNoDelete)
	//		bCurrentlyActive;
	//}
	
	// Export UEmitter::execSetTemplate(FFrame&, void* const)
	public virtual /*native event */void SetTemplate(ParticleSystem NewTemplate, /*optional */bool bDestroyOnFinish = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	public override /*simulated event */void PostBeginPlay()
	{
	
	}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
	
	}
	
	public virtual /*function */void OnParticleSystemFinished(ParticleSystemComponent FinishedComponent)
	{
	
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
	
	public virtual /*simulated function */void SetColorParameter(name ParameterName, Object.Color Param)
	{
	
	}
	
	public virtual /*simulated function */void SetExtColorParameter(name ParameterName, byte Red, byte Green, byte Blue, byte Alpha)
	{
	
	}
	
	public virtual /*simulated function */void SetActorParameter(name ParameterName, Actor Param)
	{
	
	}
	
	public virtual /*simulated function */void OnSetParticleSysParam(SeqAct_SetParticleSysParam Action)
	{
	
	}
	
	public Emitter()
	{
		// Object Offset:0x00316C09
		ParticleSystemComponent = new ParticleSystemComponent
		{
			// Object Offset:0x00317DC7
			SecondsBeforeInactive = 1.0f,
		}/* Reference: ParticleSystemComponent'Default__Emitter.ParticleSystemComponent0' */;
		bNoDelete = true;
		bHardAttach = true;
		bGameRelevant = true;
		bEdShouldSnap = true;
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new SpriteComponent
			{
				// Object Offset:0x00317D07
				Sprite = LoadAsset<Texture2D>("EngineResources.S_Emitter")/*Ref Texture2D'EngineResources.S_Emitter'*/,
				bIsScreenSizeScaled = true,
				ScreenSize = 0.00250f,
				HiddenGame = true,
				AlwaysLoadOnClient = false,
				AlwaysLoadOnServer = false,
			}/* Reference: SpriteComponent'Default__Emitter.Sprite' */,
			//Components[1]=
			new ParticleSystemComponent
			{
				// Object Offset:0x00317DC7
				SecondsBeforeInactive = 1.0f,
			}/* Reference: ParticleSystemComponent'Default__Emitter.ParticleSystemComponent0' */,
			//Components[2]=
			new ArrowComponent
			{
				// Object Offset:0x00317DFB
				ArrowColor = new Color
				{
					R=0,
					G=255,
					B=128,
					A=255
				},
				ArrowSize = 1.50f,
			}/* Reference: ArrowComponent'Default__Emitter.ArrowComponent0' */,
		};
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
	}
}
}