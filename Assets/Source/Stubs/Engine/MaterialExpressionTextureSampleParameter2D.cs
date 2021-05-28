namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialExpressionTextureSampleParameter2D : MaterialExpressionTextureSampleParameter/* within Material*//*
		native
		collapsecategories
		hidecategories(Object,Object,Object)*/{
	public new Material Outer => base.Outer as Material;
	
	public MaterialExpressionTextureSampleParameter2D()
	{
		// Object Offset:0x0035946B
		Texture = LoadAsset<Texture2D>("EngineResources.DefaultTexture")/*Ref Texture2D'EngineResources.DefaultTexture'*/;
	}
}
}