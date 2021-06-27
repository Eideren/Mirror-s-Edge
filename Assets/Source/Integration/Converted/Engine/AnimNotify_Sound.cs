namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimNotify_Sound : AnimNotify/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	public/*()*/ SoundCue SoundCue;
	public/*()*/ bool bFollowActor;
	public/*()*/ name BoneName;
	
	public AnimNotify_Sound()
	{
		// Object Offset:0x002A00A3
		bFollowActor = true;
	}
}
}