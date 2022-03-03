namespace MEdge.Engine{
	using System;using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimNotify_Footstep : AnimNotify/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	[Category] public int FootDown;
	
	public override void Notify( AnimNodeSequence NodeSeq )
	{
		throw new NotImplementedException();
	}
}
}