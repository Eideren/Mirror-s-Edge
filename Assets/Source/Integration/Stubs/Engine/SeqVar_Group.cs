namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqVar_Group : SeqVar_Object/*
		native
		hidecategories(Object)*/{
	[Category] public name GroupName;
	[transient] public bool bCachedList;
	[transient] public array<Object> Actors;
	
	public SeqVar_Group()
	{
		// Object Offset:0x003E0239
		ObjName = "Group";
	}
}
}