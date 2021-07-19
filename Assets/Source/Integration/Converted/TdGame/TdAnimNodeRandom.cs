namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAnimNodeRandom : TdAnimNodeBlendList/*
		native
		hidecategories(Object,Object,Object)*/{
	public partial struct /*native */TdRandomAnimInfo
	{
		[Category] public float Chance;
		[Category] public byte LoopCountMin;
		[Category] public byte LoopCountMax;
		public byte LoopCount;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00505CC9
	//		Chance = 1.0f;
	//		LoopCountMin = 0;
	//		LoopCountMax = 0;
	//		LoopCount = 0;
	//	}
	};
	
	[Category] [editinline] public array</*editinline */TdAnimNodeRandom.TdRandomAnimInfo> RandomInfo;
	[Category] public bool bRunOnce;
	[Category] public bool bCallPlayOnChild;
	
	// Export UTdAnimNodeRandom::execChooseNextAnimation(FFrame&, void* const)
	public virtual /*native function */void ChooseNextAnimation()
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	public override /*event */void OnBecomeRelevant()
	{
		ChooseNextAnimation();
	}
	
	public TdAnimNodeRandom()
	{
		// Object Offset:0x00505E75
		bCallPlayOnChild = true;
		ActiveChildIndex = -1;
	}
}
}