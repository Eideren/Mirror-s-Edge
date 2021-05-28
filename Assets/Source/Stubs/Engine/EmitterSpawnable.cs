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
	
	public override /*simulated event */void SetTemplate(ParticleSystem NewTemplate, /*optional */bool bDestroyOnFinish = default)
	{
	
	}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
	
	}
	
	public EmitterSpawnable()
	{
		// Object Offset:0x00318006
		ParticleSystemComponent = new ParticleSystemComponent
		{
			// Object Offset:0x004CAC52
			SecondsBeforeInactive = 0.0f,
		}/* Reference: ParticleSystemComponent'Default__EmitterSpawnable.ParticleSystemComponent0' */;
		bDestroyOnSystemFinish = true;
		bNoDelete = false;
		bNetTemporary = true;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__EmitterSpawnable.Sprite")/*Ref SpriteComponent'Default__EmitterSpawnable.Sprite'*/,
			//Components[1]=
			new ParticleSystemComponent
			{
				// Object Offset:0x004CAC52
				SecondsBeforeInactive = 0.0f,
			}/* Reference: ParticleSystemComponent'Default__EmitterSpawnable.ParticleSystemComponent0' */,
			LoadAsset<ArrowComponent>("Default__EmitterSpawnable.ArrowComponent0")/*Ref ArrowComponent'Default__EmitterSpawnable.ArrowComponent0'*/,
		};
	}
}
}