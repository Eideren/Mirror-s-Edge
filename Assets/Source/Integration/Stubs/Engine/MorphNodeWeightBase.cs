namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MorphNodeWeightBase : MorphNodeBase/*
		abstract
		native
		hidecategories(Object,Object)*/{
	public partial struct /*native */MorphNodeConn
	{
		public array<MorphNodeBase> ChildNodes;
		public name ConnName;
		public int DrawY;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0035D0A3
	//		ChildNodes = default;
	//		ConnName = (name)"None";
	//		DrawY = 0;
	//	}
	};
	
	public array<MorphNodeWeightBase.MorphNodeConn> NodeConns;
	
}
}