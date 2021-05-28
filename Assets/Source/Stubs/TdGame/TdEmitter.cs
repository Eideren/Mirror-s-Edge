namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdEmitter : Emitter/*
		native
		placeable
		hidecategories(Navigation)*/{
	public virtual /*simulated function */void KillProjectile()
	{
	
	}
	
	public TdEmitter()
	{
		// Object Offset:0x00544290
		ParticleSystemComponent = new ParticleSystemComponent
		{
			// Object Offset:0x01D7500F
			bOverrideLODMethod = true,
			SecondsBeforeInactive = 0.0f,
			LODMethod = ParticleSystem.ParticleSystemLODMethod.PARTICLESYSTEMLODMETHOD_DirectSet,
		}/* Reference: ParticleSystemComponent'Default__TdEmitter.ParticleSystemComponent0' */;
		bDestroyOnSystemFinish = true;
		bNoDelete = false;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdEmitter.Sprite")/*Ref SpriteComponent'Default__TdEmitter.Sprite'*/,
			//Components[1]=
			new ParticleSystemComponent
			{
				// Object Offset:0x01D7500F
				bOverrideLODMethod = true,
				SecondsBeforeInactive = 0.0f,
				LODMethod = ParticleSystem.ParticleSystemLODMethod.PARTICLESYSTEMLODMETHOD_DirectSet,
			}/* Reference: ParticleSystemComponent'Default__TdEmitter.ParticleSystemComponent0' */,
			LoadAsset<ArrowComponent>("Default__TdEmitter.ArrowComponent0")/*Ref ArrowComponent'Default__TdEmitter.ArrowComponent0'*/,
		};
		LifeSpan = 7.0f;
	}
}
}