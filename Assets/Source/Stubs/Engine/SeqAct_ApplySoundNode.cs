namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_ApplySoundNode : SequenceAction/*
		native
		hidecategories(Object)*/{
	public/*()*/ SoundCue PlaySound;
	public/*()*/ /*editinline */SoundNode ApplyNode;
	
	public SeqAct_ApplySoundNode()
	{
		// Object Offset:0x003B88EB
		ObjName = "Apply Sound Node";
		ObjCategory = "Sound";
	}
}
}