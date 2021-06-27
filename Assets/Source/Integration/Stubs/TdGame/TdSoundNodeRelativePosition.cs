namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSoundNodeRelativePosition : SoundNode/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public/*()*/ bool bCalculateOnce;
	public/*()*/ bool bDebugDraw;
	public/*()*/ bool bRelativeToCamera;
	public/*()*/ Object.Vector RelativePos;
	
	public TdSoundNodeRelativePosition()
	{
		// Object Offset:0x0065B509
		bCalculateOnce = true;
	}
}
}