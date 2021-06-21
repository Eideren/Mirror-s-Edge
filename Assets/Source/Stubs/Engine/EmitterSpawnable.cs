namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class EmitterSpawnable : Emitter/*
		notplaceable
		hidecategories(Navigation)*/{
	public /*repnotify */ParticleSystem ParticleTemplate;
	
	//replication
	//{
	//	 if(bNetInitial)
	//		ParticleTemplate;
	//}
	
	public override /*simulated event */void SetTemplate(ParticleSystem NewTemplate, /*optional */bool? _bDestroyOnFinish = default)
	{
		// stub
	}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
		// stub
	}
	
	public EmitterSpawnable()
	{
		var Default__EmitterSpawnable_ParticleSystemComponent0 = new ParticleSystemComponent
		{
			// Object Offset:0x004CAC52
			SecondsBeforeInactive = 0.0f,
		}/* Reference: ParticleSystemComponent'Default__EmitterSpawnable.ParticleSystemComponent0' */;
		var Default__EmitterSpawnable_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__EmitterSpawnable.Sprite' */;
		var Default__EmitterSpawnable_ArrowComponent0 = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__EmitterSpawnable.ArrowComponent0' */;
		// Object Offset:0x00318006
		ParticleSystemComponent = Default__EmitterSpawnable_ParticleSystemComponent0/*Ref ParticleSystemComponent'Default__EmitterSpawnable.ParticleSystemComponent0'*/;
		bDestroyOnSystemFinish = true;
		bNoDelete = false;
		bNetTemporary = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__EmitterSpawnable_Sprite/*Ref SpriteComponent'Default__EmitterSpawnable.Sprite'*/,
			Default__EmitterSpawnable_ParticleSystemComponent0/*Ref ParticleSystemComponent'Default__EmitterSpawnable.ParticleSystemComponent0'*/,
			Default__EmitterSpawnable_ArrowComponent0/*Ref ArrowComponent'Default__EmitterSpawnable.ArrowComponent0'*/,
		};
	}
}
}