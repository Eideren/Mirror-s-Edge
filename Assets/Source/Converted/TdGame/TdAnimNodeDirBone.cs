namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAnimNodeDirBone : AnimNodeAimOffset/*
		native
		hidecategories(Object,Object,Object)*/{
	public/*()*/ bool bUsePitch;
	public/*()*/ bool bInvertXAxis;
	public array<TdAnimNodeDirBone> FriendNodes;
	
	public override /*event */void EditorProfileUpdated(name ProfileName)
	{
		SetActiveProfileByName(ProfileName);
	}
	
}
}