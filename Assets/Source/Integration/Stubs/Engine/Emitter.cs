namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Emitter : Actor/*
		native
		placeable
		hidecategories(Navigation)*/{
	[Category] [Const, editconst, export, editinline] public ParticleSystemComponent ParticleSystemComponent;
	public bool bDestroyOnSystemFinish;
	[repnotify] public bool bCurrentlyActive;
	
	//replication
	//{
	//	 if(bNoDelete)
	//		bCurrentlyActive;
	//}
	
	// Export UEmitter::execSetTemplate(FFrame&, void* const)
	public virtual /*native event */void SetTemplate(ParticleSystem NewTemplate, /*optional */bool? _bDestroyOnFinish = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public override /*simulated event */void PostBeginPlay()
	{
		// stub
	}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
		// stub
	}
	
	public virtual /*function */void OnParticleSystemFinished(ParticleSystemComponent FinishedComponent)
	{
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
	
	public virtual /*simulated function */void SetColorParameter(name ParameterName, Object.Color Param)
	{
		// stub
	}
	
	public virtual /*simulated function */void SetExtColorParameter(name ParameterName, byte Red, byte Green, byte Blue, byte Alpha)
	{
		// stub
	}
	
	public virtual /*simulated function */void SetActorParameter(name ParameterName, Actor Param)
	{
		// stub
	}
	
	public virtual /*simulated function */void OnSetParticleSysParam(SeqAct_SetParticleSysParam Action)
	{
		// stub
	}
	
	public Emitter()
	{
		var Default__Emitter_ParticleSystemComponent0 = new ParticleSystemComponent
		{
			// Object Offset:0x00317DC7
			SecondsBeforeInactive = 1.0f,
		}/* Reference: ParticleSystemComponent'Default__Emitter.ParticleSystemComponent0' */;
		var Default__Emitter_Sprite = new SpriteComponent
		{
			// Object Offset:0x00317D07
			Sprite = LoadAsset<Texture2D>("EngineResources.S_Emitter")/*Ref Texture2D'EngineResources.S_Emitter'*/,
			bIsScreenSizeScaled = true,
			ScreenSize = 0.00250f,
			HiddenGame = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: SpriteComponent'Default__Emitter.Sprite' */;
		var Default__Emitter_ArrowComponent0 = new ArrowComponent
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
		}/* Reference: ArrowComponent'Default__Emitter.ArrowComponent0' */;
		// Object Offset:0x00316C09
		ParticleSystemComponent = Default__Emitter_ParticleSystemComponent0/*Ref ParticleSystemComponent'Default__Emitter.ParticleSystemComponent0'*/;
		bNoDelete = true;
		bHardAttach = true;
		bGameRelevant = true;
		bEdShouldSnap = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__Emitter_Sprite/*Ref SpriteComponent'Default__Emitter.Sprite'*/,
			Default__Emitter_ParticleSystemComponent0/*Ref ParticleSystemComponent'Default__Emitter.ParticleSystemComponent0'*/,
			Default__Emitter_ArrowComponent0/*Ref ArrowComponent'Default__Emitter.ArrowComponent0'*/,
		};
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
	}
}
}