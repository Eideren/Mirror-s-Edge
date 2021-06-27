namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleTypeDataTrail2 : ParticleModuleTypeDataBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public/*(Trail)*/ int TessellationFactor;
	public float TessellationFactorDistance;
	public/*(Trail)*/ float TessellationStrength;
	public/*(Trail)*/ int TextureTile;
	public int Sheets;
	public/*(Trail)*/ int MaxTrailCount;
	public/*(Trail)*/ int MaxParticleInTrailCount;
	public/*(Rendering)*/ bool RenderGeometry;
	public/*(Rendering)*/ bool RenderDirectLine;
	public/*(Rendering)*/ bool RenderLines;
	public/*(Rendering)*/ bool RenderTessellation;
	
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