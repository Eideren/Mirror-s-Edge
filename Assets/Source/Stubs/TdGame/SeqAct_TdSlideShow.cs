namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdSlideShow : SequenceAction/*
		hidecategories(Object)*/{
	public/*()*/ array<Texture2D> Pictures;
	public/*()*/ array<float> PictureDisplayTimes;
	public/*()*/ float TransitionSpeed;
	public/*()*/ bool bBlackStart;
	public/*()*/ SoundCue SoundCue;
	
	public override /*event */bool IsValidUISequenceObject(/*optional */UIScreenObject? _TargetObject = default)
	{
	
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