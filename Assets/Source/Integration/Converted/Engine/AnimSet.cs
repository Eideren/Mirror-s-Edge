namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimSet : Object/*
		native
		hidecategories(Object)*/{
	public partial struct /*native */AnimSetMeshLinkup
	{
		public Object.Guid SkelMeshLinkupGUID;
		public array<int> BoneToTrackTable;
		public array<byte> BoneUseAnimTranslation;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002A0C1B
	//		SkelMeshLinkupGUID = new Guid
	//		{
	//			A=0,
	//			B=0,
	//			C=0,
	//			D=0
	//		};
	//		BoneToTrackTable = default;
	//		BoneUseAnimTranslation = default;
	//	}
	};
	
	[Category] public bool bAnimRotationOnly;
	public array<name> TrackBoneNames;
	public array<AnimSequence> Sequences;
	[transient] public array<AnimSet.AnimSetMeshLinkup> LinkupCache;
	[Category] public array<name> UseTranslationBoneNames;
	public name PreviewSkelMeshName;
	
	public AnimSet()
	{
		// Object Offset:0x002A0DD3
		bAnimRotationOnly = true;
	}
}
}