namespace MEdge.GameFramework{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class GamePlayerInput : PlayerInput/* within GamePlayerController*//*
		transient
		native
		config(Input)
		hidecategories(Object,UIRoot)*/{
	public new GamePlayerController Outer => base.Outer as GamePlayerController;
	
}
}