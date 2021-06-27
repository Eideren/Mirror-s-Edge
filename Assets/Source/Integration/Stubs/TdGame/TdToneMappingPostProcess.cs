namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdToneMappingPostProcess : PostProcessEffect/*
		native
		hidecategories(Object)*/{
	public/*()*/ Object.Vector SceneShadows;
	public/*()*/ Object.Vector SceneHighLights;
	public/*()*/ Object.Vector SceneMidTones;
	public/*()*/ float SceneDesaturation;
	public/*()*/ float ExposureManual;
	public/*()*/ float ExposureSpeedUp;
	public/*()*/ float ExposureSpeedDown;
	public/*()*/ float ExposureHigh;
	public/*()*/ float ExposureLow;
	public float Debug;
	
	public TdToneMappingPostProcess()
	{
		// Object Offset:0x0067A7D8
		SceneShadows = new Vector
		{
			X=0.0f,
			Y=0.0f,
			Z=-0.0030f
		};
		SceneHighLights = new Vector
		{
			X=0.80f,
			Y=0.80f,
			Z=0.80f
		};
		SceneMidTones = new Vector
		{
			X=1.30f,
			Y=1.30f,
			Z=1.30f
		};
		SceneDesaturation = 0.40f;
		ExposureManual = 1.0f;
		ExposureSpeedUp = 0.2750f;
		ExposureSpeedDown = 0.4750f;
		ExposureHigh = 8.0f;
		ExposureLow = 0.850f;
	}
}
}