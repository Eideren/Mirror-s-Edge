namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIComp_ListComponentBase : UIComponent/* within UIList*//*
		abstract
		native
		hidecategories(Object)*/{
	public new UIList Outer => base.Outer as UIList;
	
}
}