namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PlayerManagerInteraction : Interaction/* within GameViewportClient*//*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public new GameViewportClient Outer => base.Outer as GameViewportClient;
	
}
}