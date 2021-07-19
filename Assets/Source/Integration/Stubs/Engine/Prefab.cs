namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Prefab : Object/*
		native*/{
	[Const] public int PrefabVersion;
	[Const] public array<Object> PrefabArchetypes;
	[Const] public array<Object> RemovedArchetypes;
	[Const] public Sequence PrefabSequence;
	[editoronly, Const] public Texture2D PrefabPreview;
	
}
}