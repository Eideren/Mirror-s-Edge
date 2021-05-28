namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FogVolumeConstantDensityComponent : FogVolumeDensityComponent/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public/*()*/ /*interp */float Density;
	
	public FogVolumeConstantDensityComponent()
	{
		// Object Offset:0x0031E699
		Density = 0.00050f;
	}
}
}