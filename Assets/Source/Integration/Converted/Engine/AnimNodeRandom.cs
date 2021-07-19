namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimNodeRandom : AnimNodeBlendList/*
		native
		hidecategories(Object,Object,Object,Object)*/{
	public partial struct /*native */RandomAnimInfo
	{
		[Category] public float Chance;
		[Category] public byte LoopCountMin;
		[Category] public byte LoopCountMax;
		[Category] public float BlendInTime;
		[Category] public Object.Vector2D PlayRateRange;
		[transient] public byte LoopCount;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0029CADE
	//		Chance = 1.0f;
	//		LoopCountMin = 0;
	//		LoopCountMax = 0;
	//		BlendInTime = 0.250f;
	//		PlayRateRange = new Vector2D
	//		{
	//			X=1.0f,
	//			Y=1.0f
	//		};
	//		LoopCount = 0;
	//	}
	};
	
	[Category] [editfixedsize, editinline] public array</*editinline */AnimNodeRandom.RandomAnimInfo> RandomInfo;
	[transient] public AnimNodeSequence PlayingSeqNode;
	[transient] public int PendingChildIndex;
	
	public AnimNodeRandom()
	{
		// Object Offset:0x0029CC4D
		PendingChildIndex = -1;
		ActiveChildIndex = -1;
	}
}
}