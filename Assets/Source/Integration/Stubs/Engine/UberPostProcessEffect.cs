namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UberPostProcessEffect : DOFAndBloomEffect/*
		native
		hidecategories(Object)*/{
	public/*()*/ Object.Vector SceneShadows;
	public/*()*/ Object.Vector SceneHighLights;
	public/*()*/ Object.Vector SceneMidTones;
	public/*()*/ float SceneDesaturation;
	
	public UberPostProcessEffect()
	{
		// Object Offset:0x00400269
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
	}
}
}