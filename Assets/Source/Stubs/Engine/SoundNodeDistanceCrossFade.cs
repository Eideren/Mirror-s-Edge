namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SoundNodeDistanceCrossFade : SoundNode/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public partial struct /*native */DistanceDatum
	{
		public/*()*/ DistributionFloat.RawDistributionFloat FadeInDistance;
		public/*()*/ DistributionFloat.RawDistributionFloat FadeOutDistance;
		public/*()*/ float Volume;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003E92ED
	//		FadeInDistance = new DistributionFloat.RawDistributionFloat
	//		{
	//			Distribution = default,
	//			Type = 0,
	//			Op = 0,
	//			LookupTableNumElements = 0,
	//			LookupTableChunkSize = 0,
	//			LookupTable = default,
	//			LookupTableTimeScale = 0.0f,
	//			LookupTableStartTime = 0.0f,
	//		};
	//		FadeOutDistance = new DistributionFloat.RawDistributionFloat
	//		{
	//			Distribution = default,
	//			Type = 0,
	//			Op = 0,
	//			LookupTableNumElements = 0,
	//			LookupTableChunkSize = 0,
	//			LookupTable = default,
	//			LookupTableTimeScale = 0.0f,
	//			LookupTableStartTime = 0.0f,
	//		};
	//		Volume = 1.0f;
	//	}
	};
	
	public/*()*/ /*editfixedsize export */array</*export */SoundNodeDistanceCrossFade.DistanceDatum> CrossFadeInput;
	
}
}