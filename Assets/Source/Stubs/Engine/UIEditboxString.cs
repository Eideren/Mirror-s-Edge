namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIEditboxString : UIString/* within UIEditBox*//*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public new UIEditBox Outer => base.Outer as UIEditBox;
	
}
}