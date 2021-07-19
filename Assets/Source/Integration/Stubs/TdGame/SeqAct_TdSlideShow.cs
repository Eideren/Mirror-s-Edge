namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdSlideShow : SequenceAction/*
		hidecategories(Object)*/{
	[Category] public array<Texture2D> Pictures;
	[Category] public array<float> PictureDisplayTimes;
	[Category] public float TransitionSpeed;
	[Category] public bool bBlackStart;
	[Category] public SoundCue SoundCue;
	
	public override /*event */bool IsValidUISequenceObject(/*optional */UIScreenObject _TargetObject = default)
	{
		// stub
		return default;
	}
	
	public SeqAct_TdSlideShow()
	{
		// Object Offset:0x004A03F7
		TransitionSpeed = 2.0f;
		ObjName = "TdSlideshow";
		ObjCategory = "Toggle";
	}
}
}