namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqVar_AITemplate : SeqVar_Object/*
		native
		hidecategories(Object)*/{
	public/*()*/ Core.ClassT<AITemplate> Template;
	
	public SeqVar_AITemplate()
	{
		// Object Offset:0x004A94B2
		Template = ClassT<AITemplate_Default>()/*Ref Class'AITemplate_Default'*/;
		ObjClassVersion = 2;
		ObjName = "Takedown AI Template";
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