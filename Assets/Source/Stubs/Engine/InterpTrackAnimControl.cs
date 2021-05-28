namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InterpTrackAnimControl : InterpTrackFloatBase/*
		native
		collapsecategories
		hidecategories(Object)*/{
	public partial struct /*native */AnimControlTrackKey
	{
		public float StartTime;
		public name AnimSeqName;
		public float AnimStartOffset;
		public float AnimEndOffset;
		public float AnimPlayRate;
		public bool bLooping;
		public bool bReverse;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0034179B
	//		StartTime = 0.0f;
	//		AnimSeqName = (name)"None";
	//		AnimStartOffset = 0.0f;
	//		AnimEndOffset = 0.0f;
	//		AnimPlayRate = 0.0f;
	//		bLooping = false;
	//		bReverse = false;
	//	}
	};
	
	public array<AnimSet> AnimSets;
	public/*()*/ /*editconst */name SlotName;
	public array<InterpTrackAnimControl.AnimControlTrackKey> AnimSeqs;
	
	public InterpTrackAnimControl()
	{
		// Object Offset:0x0034189B
		TrackInstClass = ClassT<InterpTrackInstAnimControl>()/*Ref Class'InterpTrackInstAnimControl'*/;
		TrackTitle = "Anim";
		bIsAnimControlTrack = true;
	}
}
}