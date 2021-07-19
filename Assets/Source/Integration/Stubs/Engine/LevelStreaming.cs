namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class LevelStreaming : Object/*
		abstract
		native
		editinlinenew*/{
	[Category] [Const, editconst] public name PackageName;
	[Const, transient] public Level LoadedLevel;
	[Category] [Const] public Object.Vector Offset;
	[Const] public Object.Vector OldOffset;
	[Const, transient] public bool bIsVisible;
	[Const, transient] public bool bHasLoadRequestPending;
	[Const, transient] public bool bHasUnloadRequestPending;
	[Category] [Const] public bool bShouldBeVisibleInEditor;
	[Const] public bool bBoundingBoxVisible;
	[Category] [Const] public bool bLocked;
	[Category] [Const] public bool bIsFullyStatic;
	[Const, transient] public bool bShouldBeLoaded;
	[Const, transient] public bool bShouldBeVisible;
	[transient] public bool bShouldBlockOnLoad;
	[Const, transient] public bool bIsRequestingUnloadAndRemoval;
	[Category] [Const] public Object.Color DrawColor;
	[Category] [Const, editconst] public array</*editconst */LevelStreamingVolume> EditorStreamingVolumes;
	[Category] public float MinTimeBetweenVolumeUnloadRequests;
	[Const, transient] public float LastVolumeUnloadRequestTime;
	
	public LevelStreaming()
	{
		// Object Offset:0x00350465
		bShouldBeVisibleInEditor = true;
		DrawColor = new Color
		{
			R=255,
			G=255,
			B=255,
			A=255
		};
		MinTimeBetweenVolumeUnloadRequests = 2.0f;
	}
}
}