namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleBeamBase : ParticleModule/*
		abstract
		native
		editinlinenew
		hidecategories(Object,Object)*/{
	public enum Beam2SourceTargetMethod 
	{
		PEB2STM_Default,
		PEB2STM_UserSet,
		PEB2STM_Emitter,
		PEB2STM_Particle,
		PEB2STM_Actor,
		PEB2STM_MAX
	};
	
	public enum Beam2SourceTargetTangentMethod 
	{
		PEB2STTM_Direct,
		PEB2STTM_UserSet,
		PEB2STTM_Distribution,
		PEB2STTM_Emitter,
		PEB2STTM_MAX
	};
	
}
}