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
	
	public/*(Color)*/ /*interp */Object.LinearColor OcclusionColor;
	public/*(Color)*/ float OcclusionPower;
	public/*(Color)*/ float OcclusionScale;
	public/*(Color)*/ float OcclusionBias;
	public/*(Color)*/ float MinOcclusion;
	public/*(Occlusion)*/ float OcclusionRadius;
	public/*(Occlusion)*/ float OcclusionAttenuation;
	public/*(Occlusion)*/ float HaloDistanceThreshold;
	public/*(Occlusion)*/ float HaloOcclusion;
	public/*(Occlusion)*/ AmbientOcclusionEffect.EAmbientOcclusionQuality OcclusionQuality;
	public/*(Occlusion)*/ float OcclusionFadeoutMinDistance;
	public/*(Occlusion)*/ float OcclusionFadeoutMaxDistance;
	public/*(Filter)*/ float EdgeDistanceThreshold;
	public/*(Filter)*/ float EdgeDistanceScale;
	public/*(Filter)*/ float FilterDistanceScale;
	public/*(Filter)*/ int FilterSize;
	public/*(History)*/ float HistoryDistanceThreshold;
	public/*(History)*/ float HistoryConvergenceTime;
	
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