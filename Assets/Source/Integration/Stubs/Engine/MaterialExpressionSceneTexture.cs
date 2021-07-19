namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialExpressionSceneTexture : MaterialExpression/* within Material*//*
		native
		collapsecategories
		hidecategories(Object)*/{
	public enum ESceneTextureType 
	{
		SceneTex_Lighting,
		SceneTex_Downsampled8,
		SceneTex_MAX
	};
	
	public new Material Outer => base.Outer as Material;
	
	public MaterialExpression.ExpressionInput Coordinates;
	[Category] public MaterialExpressionSceneTexture.ESceneTextureType SceneTextureType;
	[Category] public bool ScreenAlign;
	
}
}