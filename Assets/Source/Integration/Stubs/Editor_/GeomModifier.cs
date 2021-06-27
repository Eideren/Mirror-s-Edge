namespace MEdge.Editor{
using Core; using Engine; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class GeomModifier : Object/*
		abstract
		native
		hidecategories(Object,GeomModifier)*/{
	public/*()*/ String Description;
	public/*()*/ bool bPushButton;
	public/*()*/ bool bInitialized;
	
	public GeomModifier()
	{
		// Object Offset:0x00011D27
		Description = "None";
	}
}
}