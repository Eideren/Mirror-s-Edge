namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleTypeDataTrail2 : ParticleModuleTypeDataBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	[Category("Trail")] public int TessellationFactor;
	public float TessellationFactorDistance;
	[Category("Trail")] public float TessellationStrength;
	[Category("Trail")] public int TextureTile;
	public int Sheets;
	[Category("Trail")] public int MaxTrailCount;
	[Category("Trail")] public int MaxParticleInTrailCount;
	[Category("Rendering")] public bool RenderGeometry;
	[Category("Rendering")] public bool RenderDirectLine;
	[Category("Rendering")] public bool RenderLines;
	[Category("Rendering")] public bool RenderTessellation;
	
	public ParticleModuleTypeDataTrail2()
	{
		// Object Offset:0x00385ABB
		TessellationFactor = 1;
		TessellationStrength = 25.0f;
		TextureTile = 1;
		Sheets = 1;
		MaxTrailCount = 1;
		RenderGeometry = true;
	}
}
}