namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqVar_ObjectVolume : SeqVar_Object/*
		native
		hidecategories(Object)*/{
	public float LastUpdateTime;
	public array<Object> ContainedObjects;
	public/*()*/ array< Class > ExcludeClassList;
	public/*()*/ bool bCollidingOnly;
	
	public SeqVar_ObjectVolume()
	{
		// Object Offset:0x003E0CD5
		ExcludeClassList = new array< Class >
		{
			ClassT<Trigger>(),
			ClassT<Volume>(),
		};
		bCollidingOnly = true;
		ObjName = "Object Volume";
	}
}
}