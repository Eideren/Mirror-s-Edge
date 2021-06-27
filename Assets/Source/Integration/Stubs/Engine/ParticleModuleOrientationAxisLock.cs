namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleOrientationAxisLock : ParticleModuleOrientationBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public enum EParticleAxisLock 
	{
		EPAL_NONE,
		EPAL_X,
		EPAL_Y,
		EPAL_Z,
		EPAL_NEGATIVE_X,
		EPAL_NEGATIVE_Y,
		EPAL_NEGATIVE_Z,
		EPAL_ROTATE_X,
		EPAL_ROTATE_Y,
		EPAL_ROTATE_Z,
		EPAL_MAX
	};
	
	public/*(Orientation)*/ ParticleModuleOrientationAxisLock.EParticleAxisLock LockAxisFlags;
	
	public ParticleModuleOrientationAxisLock()
	{
		// Object Offset:0x003808B4
		bSpawnModule = true;
		bUpdateModule = true;
	}
}
}