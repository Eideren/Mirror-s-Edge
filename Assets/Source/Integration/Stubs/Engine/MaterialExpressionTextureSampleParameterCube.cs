namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialExpressionTextureSampleParameterCube : MaterialExpressionTextureSampleParameter/* within Material*//*
		native
		collapsecategories
		hidecategories(Object,Object,Object)*/{
	public new Material Outer => base.Outer as Material;
	
	public MaterialExpressionTextureSampleParameterCube()
	{
		// Object Offset:0x00359785
		Texture = LoadAsset<TextureCube>("EngineResources.DefaultTextureCube")/*Ref TextureCube'EngineResources.DefaultTextureCube'*/;
	}
}
}