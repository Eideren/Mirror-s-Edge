namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PostProcessEffect : Object/*
		native
		hidecategories(Object)*/{
	public/*()*/ bool bShowInEditor;
	public/*()*/ bool bShowInGame;
	public/*()*/ bool bUseWorldSettings;
	public bool bAffectsLightingOnly;
	public/*()*/ name EffectName;
	public int NodePosY;
	public int NodePosX;
	public int DrawWidth;
	public int DrawHeight;
	public int OutDrawY;
	public int InDrawY;
	public/*()*/ Scene.ESceneDepthPriorityGroup SceneDPG;
	
	public PostProcessEffect()
	{
		// Object Offset:0x0028D071
		bShowInEditor = true;
		bShowInGame = true;
		SceneDPG = Scene.ESceneDepthPriorityGroup.SDPG_PostProcess;
	}
}
}