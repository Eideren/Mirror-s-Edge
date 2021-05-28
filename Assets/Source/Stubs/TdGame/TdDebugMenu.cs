namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdDebugMenu : Interaction/* within TdGameViewportClient*//*
		transient
		hidecategories(Object,UIRoot)*/{
	public new TdGameViewportClient Outer => base.Outer as TdGameViewportClient;
	
}
}