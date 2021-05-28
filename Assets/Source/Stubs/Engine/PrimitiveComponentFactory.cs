namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PrimitiveComponentFactory : Object/*
		abstract
		native*/{
	public/*(Collision)*/ /*const */bool CollideActors;
	public/*(Collision)*/ /*const */bool BlockActors;
	public/*(Collision)*/ /*const */bool BlockZeroExtent;
	public/*(Collision)*/ /*const */bool BlockNonZeroExtent;
	public/*(Collision)*/ /*const */bool BlockRigidBody;
	public/*(Rendering)*/ bool HiddenGame;
	public/*(Rendering)*/ bool HiddenEditor;
	public/*(Rendering)*/ bool CastShadow;
	
}
}