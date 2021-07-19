namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FluidSurfaceActor : Actor/*
		native
		placeable
		hidecategories(Navigation)*/{
	[Category] [Const, editconst, export, editinline] public FluidSurfaceComponent Fluid;
	
	public FluidSurfaceActor()
	{
		var Default__FluidSurfaceActor_NewFluidComponent = new FluidSurfaceComponent
		{
		}/* Reference: FluidSurfaceComponent'Default__FluidSurfaceActor.NewFluidComponent' */;
		// Object Offset:0x0031DCB5
		Fluid = Default__FluidSurfaceActor_NewFluidComponent/*Ref FluidSurfaceComponent'Default__FluidSurfaceActor.NewFluidComponent'*/;
		bMovable = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__FluidSurfaceActor_NewFluidComponent/*Ref FluidSurfaceComponent'Default__FluidSurfaceActor.NewFluidComponent'*/,
		};
	}
}
}