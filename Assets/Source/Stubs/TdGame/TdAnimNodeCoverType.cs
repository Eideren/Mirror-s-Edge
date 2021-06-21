namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAnimNodeCoverType : TdAnimNodeState/*
		native
		hidecategories(Object,Object,Object)*/{
	public/*()*/ /*editoronly transient */array<CoverLink.ECoverType> EnumStates;
	
	public override /*event */void OnInit()
	{
		// stub
	}
	
	public override /*event */void OverrideStateMapping()
	{
		// stub
	}
	
	public TdAnimNodeCoverType()
	{
		// Object Offset:0x00501342
		EnumStringName = "ECoverType";
	}
}
}