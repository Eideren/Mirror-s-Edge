namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleColorByParameter : ParticleModuleColorBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	[Category("Color")] public name ColorParam;
	[Category("Color")] public Object.Color DefaultColor;
	
	public ParticleModuleColorByParameter()
	{
		// Object Offset:0x0037C9B7
		DefaultColor = new Color
		{
			R=255,
			G=255,
			B=255,
			A=255
		};
		bSpawnModule = true;
	}
}
}