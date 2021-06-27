namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleSpriteEmitter : ParticleEmitter/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public enum EParticleScreenAlignment 
	{
		PSA_Square,
		PSA_Rectangle,
		PSA_Velocity,
		PSA_TypeSpecific,
		PSA_MAX
	};
	
}
}