namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdTriggerSubtitle : SequenceAction/*
		native
		hidecategories(Object)*/{
	[Category] public array<SoundNodeWave.SubtitleCue> Subtitles;
	[Category] public float Priority;
	[Category] public bool bManualWordWrap;
	[Category] public float Duration;
	
	public override /*event */bool IsValidUISequenceObject(/*optional */UIScreenObject _TargetObject = default)
	{
		// stub
		return default;
	}
	
	public SeqAct_TdTriggerSubtitle()
	{
		// Object Offset:0x004A346C
		Priority = 0.20f;
		Duration = 5.0f;
		ObjName = "Trigger a subtitle text string";
		ObjCategory = "Takedown";
	}
}
}