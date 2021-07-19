namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InterpTrackDirector : InterpTrack/*
		native
		collapsecategories
		hidecategories(Object)*/{
	public partial struct /*native */DirectorTrackCut
	{
		public float Time;
		public float TransitionTime;
		[Category] public name TargetCamGroup;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00341D00
	//		Time = 0.0f;
	//		TransitionTime = 0.0f;
	//		TargetCamGroup = (name)"None";
	//	}
	};
	
	public array<InterpTrackDirector.DirectorTrackCut> CutTrack;
	
	public InterpTrackDirector()
	{
		// Object Offset:0x00341DC0
		TrackInstClass = ClassT<InterpTrackInstDirector>()/*Ref Class'InterpTrackInstDirector'*/;
		TrackTitle = "Director";
		bOnePerGroup = true;
		bDirGroupOnly = true;
	}
}
}