namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DrawLightConeComponent : DrawConeComponent/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Physics,Collision,PrimitiveComponent,Rendering)*/{
	public DrawLightConeComponent()
	{
		// Object Offset:0x0031083B
		AlwaysLoadOnClient = false;
		AlwaysLoadOnServer = false;
		AbsoluteScale = true;
	}
}
}