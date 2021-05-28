namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FluidSurfaceActor : Actor/*
		native
		placeable
		hidecategories(Navigation)*/{
	public/*()*/ /*const editconst export editinline */FluidSurfaceComponent Fluid;
	
	public FluidSurfaceActor()
	{
		// Object Offset:0x0031DCB5
		Fluid = LoadAsset<FluidSurfaceComponent>("Default__FluidSurfaceActor.NewFluidComponent")/*Ref FluidSurfaceComponent'Default__FluidSurfaceActor.NewFluidComponent'*/;
		bMovable = false;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<FluidSurfaceComponent>("Default__FluidSurfaceActor.NewFluidComponent")/*Ref FluidSurfaceComponent'Default__FluidSurfaceActor.NewFluidComponent'*/,
		};
	}
}
}