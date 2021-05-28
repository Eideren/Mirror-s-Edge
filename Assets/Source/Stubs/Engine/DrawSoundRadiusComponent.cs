namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DrawSoundRadiusComponent : DrawSphereComponent/*
		native
		editinlinenew
		collapsecategories
		noexport
		hidecategories(Object,Physics,Collision,PrimitiveComponent,Rendering)*/{
	public DrawSoundRadiusComponent()
	{
		// Object Offset:0x0028F3CD
		SphereColor = new Color
		{
			R=173,
			G=239,
			B=231,
			A=255
		};
		SphereSides = 32;
		AlwaysLoadOnClient = false;
		AlwaysLoadOnServer = false;
		AbsoluteScale = true;
	}
}
}