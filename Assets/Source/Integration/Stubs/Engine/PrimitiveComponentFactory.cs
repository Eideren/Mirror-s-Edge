namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PrimitiveComponentFactory : Object/*
		abstract
		native*/{
	[Category("Collision")] [Const] public bool CollideActors;
	[Category("Collision")] [Const] public bool BlockActors;
	[Category("Collision")] [Const] public bool BlockZeroExtent;
	[Category("Collision")] [Const] public bool BlockNonZeroExtent;
	[Category("Collision")] [Const] public bool BlockRigidBody;
	[Category("Rendering")] public bool HiddenGame;
	[Category("Rendering")] public bool HiddenEditor;
	[Category("Rendering")] public bool CastShadow;
	
}
}