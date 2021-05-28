namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ClipPadEntry : Object/*
		native
		hidecategories(Object)*/{
	public/*()*/ string Title;
	public/*()*/ string Text;
	
	public ClipPadEntry()
	{
		// Object Offset:0x002BC8EE
		Title = "Untitled";
	}
}
}