namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class LevelStreaming : Object/*
		abstract
		native
		editinlinenew*/{
	public/*()*/ /*const editconst */name PackageName;
	public /*const transient */Level LoadedLevel;
	public/*()*/ /*const */Object.Vector Offset;
	public /*const */Object.Vector OldOffset;
	public /*const transient */bool bIsVisible;
	public /*const transient */bool bHasLoadRequestPending;
	public /*const transient */bool bHasUnloadRequestPending;
	public/*()*/ /*const */bool bShouldBeVisibleInEditor;
	public /*const */bool bBoundingBoxVisible;
	public/*()*/ /*const */bool bLocked;
	public/*()*/ /*const */bool bIsFullyStatic;
	public /*const transient */bool bShouldBeLoaded;
	public /*const transient */bool bShouldBeVisible;
	public /*transient */bool bShouldBlockOnLoad;
	public /*const transient */bool bIsRequestingUnloadAndRemoval;
	public/*()*/ /*const */Object.Color DrawColor;
	public/*()*/ /*const editconst */array</*editconst */LevelStreamingVolume> EditorStreamingVolumes;
	public/*()*/ float MinTimeBetweenVolumeUnloadRequests;
	public /*const transient */float LastVolumeUnloadRequestTime;
	
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