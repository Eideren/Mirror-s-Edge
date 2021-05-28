namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MeshComponentFactory : PrimitiveComponentFactory/*
		abstract
		native*/{
	public/*(Rendering)*/ array<MaterialInterface> Materials;
	
	public MeshComponentFactory()
	{
		// Object Offset:0x0035C899
		CastShadow = true;
	}
}
}