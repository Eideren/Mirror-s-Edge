namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class LineBatchComponent : PrimitiveComponent/*
		native
		noexport*/{
	public /*native const noexport */Object.Pointer FPrimitiveDrawInterfaceVfTable;
	public /*native const noexport */Object.Pointer FPrimitiveDrawInterfaceView;
	public /*native const transient */array<Object.Pointer> BatchedLines;
	public /*native const transient */float DefaultLifeTime;
	
}
}