namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimNodeSequenceBlendByAim : AnimNodeSequenceBlendBase/*
		native
		hidecategories(Object,Object,Animations)*/{
	public/*()*/ Object.Vector2D Aim;
	public/*()*/ Object.Vector2D HorizontalRange;
	public/*()*/ Object.Vector2D VerticalRange;
	public/*()*/ Object.Vector2D AngleOffset;
	public/*()*/ name AnimName_LU;
	public/*()*/ name AnimName_LC;
	public/*()*/ name AnimName_LD;
	public/*()*/ name AnimName_CU;
	public/*()*/ name AnimName_CC;
	public/*()*/ name AnimName_CD;
	public/*()*/ name AnimName_RU;
	public/*()*/ name AnimName_RC;
	public/*()*/ name AnimName_RD;
	
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