namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AmbientOcclusionEffect : PostProcessEffect/*
		native
		hidecategories(Object)*/{
	public enum EAmbientOcclusionQuality 
	{
		AO_High,
		AO_Medium,
		AO_Low,
		AO_MAX
	};
	
	[Category("Color")] [interp] public Object.LinearColor OcclusionColor;
	[Category("Color")] public float OcclusionPower;
	[Category("Color")] public float OcclusionScale;
	[Category("Color")] public float OcclusionBias;
	[Category("Color")] public float MinOcclusion;
	[Category("Occlusion")] public float OcclusionRadius;
	[Category("Occlusion")] public float OcclusionAttenuation;
	[Category("Occlusion")] public float HaloDistanceThreshold;
	[Category("Occlusion")] public float HaloOcclusion;
	[Category("Occlusion")] public AmbientOcclusionEffect.EAmbientOcclusionQuality OcclusionQuality;
	[Category("Occlusion")] public float OcclusionFadeoutMinDistance;
	[Category("Occlusion")] public float OcclusionFadeoutMaxDistance;
	[Category("Filter")] public float EdgeDistanceThreshold;
	[Category("Filter")] public float EdgeDistanceScale;
	[Category("Filter")] public float FilterDistanceScale;
	[Category("Filter")] public int FilterSize;
	[Category("History")] public float HistoryDistanceThreshold;
	[Category("History")] public float HistoryConvergenceTime;
	
	public AmbientOcclusionEffect()
	{
		// Object Offset:0x0028D498
		OcclusionColor = new LinearColor
		{
			R=0.0f,
			G=0.0f,
			B=0.0f,
			A=1.0f
		};
		OcclusionPower = 4.0f;
		OcclusionScale = 20.0f;
		OcclusionBias = -0.30f;
		MinOcclusion = 0.050f;
		OcclusionRadius = 40.0f;
		OcclusionAttenuation = 50.0f;
		HaloDistanceThreshold = 70.0f;
		HaloOcclusion = 0.020f;
		OcclusionQuality = AmbientOcclusionEffect.EAmbientOcclusionQuality.AO_Medium;
		OcclusionFadeoutMinDistance = 40000.0f;
		OcclusionFadeoutMaxDistance = 65000.0f;
		EdgeDistanceThreshold = 40.0f;
		EdgeDistanceScale = 0.0010f;
		FilterDistanceScale = 10.0f;
		FilterSize = 12;
		HistoryDistanceThreshold = 20.0f;
		HistoryConvergenceTime = 0.50f;
		bAffectsLightingOnly = true;
		SceneDPG = Scene.ESceneDepthPriorityGroup.SDPG_World;
	}
}
}