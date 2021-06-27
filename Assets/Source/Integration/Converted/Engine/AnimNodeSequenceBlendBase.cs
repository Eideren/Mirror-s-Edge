namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimNodeSequenceBlendBase : AnimNodeSequence/*
		abstract
		native
		hidecategories(Object,Object)*/{
	public partial struct /*native */AnimInfo
	{
		public /*const */name AnimSeqName;
		public /*const transient */AnimSequence AnimSeq;
		public /*const transient */int AnimLinkupIndex;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0029D6CD
	//		AnimSeqName = (name)"None";
	//		AnimSeq = default;
	//		AnimLinkupIndex = 0;
	//	}
	};
	
	public partial struct /*native */AnimBlendInfo
	{
		public/*()*/ name AnimName;
		public AnimNodeSequenceBlendBase.AnimInfo AnimInfo;
		public float Weight;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0029D7E5
	//		AnimName = (name)"None";
	//		AnimInfo = new AnimNodeSequenceBlendBase.AnimInfo
	//		{
	//			AnimSeqName = (name)"None",
	//			AnimSeq = default,
	//			AnimLinkupIndex = 0,
	//		};
	//		Weight = 0.0f;
	//	}
	};
	
	public/*(Animations)*/ /*editfixedsize export editinline */array</*export editinline */AnimNodeSequenceBlendBase.AnimBlendInfo> Anims;
	
	public AnimNodeSequenceBlendBase()
	{
		// Object Offset:0x0029D909
		Anims = new array</*export editinline */AnimNodeSequenceBlendBase.AnimBlendInfo>
		{
			new AnimNodeSequenceBlendBase.AnimBlendInfo
			{
				AnimName = (name)"None",
				AnimInfo = new AnimNodeSequenceBlendBase.AnimInfo
				{
					AnimSeqName = (name)"None",
					AnimSeq = default,
					AnimLinkupIndex = 0,
				},
				Weight = 1.0f,
			},
			new AnimNodeSequenceBlendBase.AnimBlendInfo
			{
				AnimName = (name)"None",
				AnimInfo = new AnimNodeSequenceBlendBase.AnimInfo
				{
					AnimSeqName = (name)"None",
					AnimSeq = default,
					AnimLinkupIndex = 0,
				},
				Weight = 0.0f,
			},
		};
	}
}
}