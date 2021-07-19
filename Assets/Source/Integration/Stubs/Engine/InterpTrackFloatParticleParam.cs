namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InterpTrackFloatParticleParam : InterpTrackFloatBase/*
		native
		collapsecategories
		hidecategories(Object)*/{
	[Category] public name ParamName;
	
	public InterpTrackFloatParticleParam()
	{
		// Object Offset:0x00342653
		TrackInstClass = ClassT<InterpTrackInstFloatParticleParam>()/*Ref Class'InterpTrackInstFloatParticleParam'*/;
		TrackTitle = "Float Particle Param";
	}
}
}