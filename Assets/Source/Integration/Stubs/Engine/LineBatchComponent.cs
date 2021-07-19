namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class LineBatchComponent : PrimitiveComponent/*
		native
		noexport*/{
	[native, Const, noexport] public Object.Pointer FPrimitiveDrawInterfaceVfTable;
	[native, Const, noexport] public Object.Pointer FPrimitiveDrawInterfaceView;
	[native, Const, transient] public array<Object.Pointer> BatchedLines;
	[native, Const, transient] public float DefaultLifeTime;
	
}
}