namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimNodeSequenceBlendByAim : AnimNodeSequenceBlendBase/*
		native
		hidecategories(Object,Object,Animations)*/{
	[Category] public Object.Vector2D Aim;
	[Category] public Object.Vector2D HorizontalRange;
	[Category] public Object.Vector2D VerticalRange;
	[Category] public Object.Vector2D AngleOffset;
	[Category] public name AnimName_LU;
	[Category] public name AnimName_LC;
	[Category] public name AnimName_LD;
	[Category] public name AnimName_CU;
	[Category] public name AnimName_CC;
	[Category] public name AnimName_CD;
	[Category] public name AnimName_RU;
	[Category] public name AnimName_RC;
	[Category] public name AnimName_RD;
	
	public AnimNodeSequenceBlendByAim()
	{
		// Object Offset:0x0029DD78
		HorizontalRange = new Vector2D
		{
			X=-1.0f,
			Y=1.0f
		};
		VerticalRange = new Vector2D
		{
			X=-1.0f,
			Y=1.0f
		};
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