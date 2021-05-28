namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqVar_AIGroup : SeqVar_Object/*
		native
		hidecategories(Object)*/{
	public/*()*/ string GroupName;
	public/*()*/ /*editinline */AIGroup TheGroup;
	
	public SeqVar_AIGroup()
	{
		// Object Offset:0x004A91E8
		GroupName = "Unnamed Group";
		ObjName = "Group";
		ObjCategory = "AI";
		ObjColor = new Color
		{
			R=255,
			G=128,
			B=0,
			A=255
		};
	}
}
}