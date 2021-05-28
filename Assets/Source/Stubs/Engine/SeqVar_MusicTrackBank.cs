namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqVar_MusicTrackBank : SeqVar_Object/*
		native
		hidecategories(Object)*/{
	public/*()*/ array<MusicTrackDataStructures.MusicTrackStruct> MusicTrackBank;
	
	public SeqVar_MusicTrackBank()
	{
		// Object Offset:0x003E067A
		SupportedClasses = default;
		ObjName = "Music Track Bank";
		ObjCategory = "Sound";
	}
}
}