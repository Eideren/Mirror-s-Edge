namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAnimNodeBalanceWalk : TdAnimNodeBlendList/*
		native
		hidecategories(Object,Object,Object)*/{
	public TdAnimNodeBalanceWalk()
	{
		// Object Offset:0x004FE50D
		Children = new array</*export editinline */AnimNodeBlendBase.AnimBlendChild>
		{
			new AnimNodeBlendBase.AnimBlendChild
			{
				Name = (name)"Danger Left",
				Anim = default,
				Weight = 0.0f,
				TotalWeight = 0.0f,
				bHasRootMotion = 0,
				RootMotion = new AnimNode.BoneAtom
				{
					Rotation = new Quat
					{
						X=0.0f,
						Y=0.0f,
						Z=0.0f,
						W=0.0f
					},
					Translation = new Vector
					{
						X=0.0f,
						Y=0.0f,
						Z=0.0f
					},
					Scale = 0.0f,
				},
				bMirrorSkeleton = false,
				DrawY = 0,
			},
			new AnimNodeBlendBase.AnimBlendChild
			{
				Name = (name)"Default",
				Anim = default,
				Weight = 0.0f,
				TotalWeight = 0.0f,
				bHasRootMotion = 0,
				RootMotion = new AnimNode.BoneAtom
				{
					Rotation = new Quat
					{
						X=0.0f,
						Y=0.0f,
						Z=0.0f,
						W=0.0f
					},
					Translation = new Vector
					{
						X=0.0f,
						Y=0.0f,
						Z=0.0f
					},
					Scale = 0.0f,
				},
				bMirrorSkeleton = false,
				DrawY = 0,
			},
			new AnimNodeBlendBase.AnimBlendChild
			{
				Name = (name)"Danger Right",
				Anim = default,
				Weight = 0.0f,
				TotalWeight = 0.0f,
				bHasRootMotion = 0,
				RootMotion = new AnimNode.BoneAtom
				{
					Rotation = new Quat
					{
						X=0.0f,
						Y=0.0f,
						Z=0.0f,
						W=0.0f
					},
					Translation = new Vector
					{
						X=0.0f,
						Y=0.0f,
						Z=0.0f
					},
					Scale = 0.0f,
				},
				bMirrorSkeleton = false,
				DrawY = 0,
			},
			new AnimNodeBlendBase.AnimBlendChild
			{
				Name = (name)"Crouch",
				Anim = default,
				Weight = 0.0f,
				TotalWeight = 0.0f,
				bHasRootMotion = 0,
				RootMotion = new AnimNode.BoneAtom
				{
					Rotation = new Quat
					{
						X=0.0f,
						Y=0.0f,
						Z=0.0f,
						W=0.0f
					},
					Translation = new Vector
					{
						X=0.0f,
						Y=0.0f,
						Z=0.0f
					},
					Scale = 0.0f,
				},
				bMirrorSkeleton = false,
				DrawY = 0,
			},
		};
		bFixNumChildren = true;
	}
}
}