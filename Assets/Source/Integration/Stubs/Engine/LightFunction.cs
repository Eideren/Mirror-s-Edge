namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class LightFunction : Object/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	[Category] [Const] public MaterialInterface SourceMaterial;
	[Category] public Object.Vector Scale;
	
	public LightFunction()
	{
		// Object Offset:0x00351A65
		Scale = new Vector
		{
			X=1024.0f,
			Y=1024.0f,
			Z=1024.0f
		};
	}
}
}