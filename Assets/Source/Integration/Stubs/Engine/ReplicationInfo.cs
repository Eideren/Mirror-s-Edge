namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ReplicationInfo : Info/*
		abstract
		native
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public ReplicationInfo()
	{
		// Object Offset:0x002E9558
		bAlwaysRelevant = true;
		Components = default;
		RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy;
	}
}
}