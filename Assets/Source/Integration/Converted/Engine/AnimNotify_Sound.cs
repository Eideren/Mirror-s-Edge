namespace MEdge.Engine{
	using System;using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimNotify_Sound : AnimNotify/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	[Category] public SoundCue SoundCue;
	[Category] public bool bFollowActor;
	[Category] public name BoneName;



	public override void Notify( AnimNodeSequence NodeSeq )
	{
		throw new NotImplementedException();
	}



	public AnimNotify_Sound()
	{
		// Object Offset:0x002A00A3
		bFollowActor = true;
	}
}
}