namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SoundNodeRandom : SoundNode/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public/*()*/ /*editfixedsize */array<float> Weights;
	public/*()*/ bool bRandomizeWithoutReplacement;
	public /*transient */array<bool> HasBeenUsed;
	public /*transient */int NumRandomUsed;
	
	public SoundNodeRandom()
	{
		// Object Offset:0x003EA6BE
		bRandomizeWithoutReplacement = true;
	}
}
}