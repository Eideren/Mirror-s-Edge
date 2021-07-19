namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ASVSkelComponent : SkeletalMeshComponent/*
		transient
		native
		editinlinenew
		hidecategories(Object)*/{
	[native, Const] public Object.Pointer AnimSetViewerPtr;
	public bool bRenderRawSkeleton;
	public bool bDrawMesh;
	public Object.Color BoneColor;
	
	public ASVSkelComponent()
	{
		// Object Offset:0x0001A4F4
		bDrawMesh = true;
		BoneColor = new Color
		{
			R=230,
			G=230,
			B=255,
			A=0
		};
	}
}
}