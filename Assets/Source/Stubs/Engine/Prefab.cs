namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Prefab : Object/*
		native*/{
	public /*const */int PrefabVersion;
	public /*const */array<Object> PrefabArchetypes;
	public /*const */array<Object> RemovedArchetypes;
	public /*const */Sequence PrefabSequence;
	public /*editoronly const */Texture2D PrefabPreview;
	
}
}