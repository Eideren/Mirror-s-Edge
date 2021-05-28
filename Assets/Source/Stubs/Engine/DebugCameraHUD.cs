namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DebugCameraHUD : HUD/*
		transient
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public override /*simulated event */void PostBeginPlay()
	{
	
	}
	
	public override /*event */void PostRender()
	{
	
	}
	
	public DebugCameraHUD()
	{
		// Object Offset:0x002FFA98
		bHidden = false;
	}
}
}