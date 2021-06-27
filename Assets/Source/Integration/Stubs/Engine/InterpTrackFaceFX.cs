namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InterpTrackFaceFX : InterpTrack/*
		native
		collapsecategories
		hidecategories(Object)*/{
	public partial struct /*native */FaceFXTrackKey
	{
		public float StartTime;
		public String FaceFXGroupName;
		public String FaceFXSeqName;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00342231
	//		StartTime = 0.0f;
	//		FaceFXGroupName = "";
	//		FaceFXSeqName = "";
	//	}
	};
	
	public/*()*/ array<FaceFXAnimSet> FaceFXAnimSets;
	public array<InterpTrackFaceFX.FaceFXTrackKey> FaceFXSeqs;
	public /*transient */FaceFXAsset CachedActorFXAsset;
	
	public InterpTrackFaceFX()
	{
		// Object Offset:0x0034234D
		TrackInstClass = ClassT<InterpTrackInstFaceFX>()/*Ref Class'InterpTrackInstFaceFX'*/;
		TrackTitle = "FaceFX";
		bOnePerGroup = true;
	}
}
}