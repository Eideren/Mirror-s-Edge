namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdCrowdSpawner : SeqAct_CrowdSpawner/*
		hidecategories(Object)*/{
	public SeqAct_TdCrowdSpawner()
	{
		// Object Offset:0x004977D3
		CrowdNodeClass = ClassT<TdCrowdPathNode>()/*Ref Class'TdCrowdPathNode'*/;
		ActionDuration = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SeqAct_TdCrowdSpawner.DistributionActionDuration")/*Ref DistributionFloatUniform'Default__SeqAct_TdCrowdSpawner.DistributionActionDuration'*/,
		};
		ActionInterval = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SeqAct_TdCrowdSpawner.DistributionActionInterval")/*Ref DistributionFloatUniform'Default__SeqAct_TdCrowdSpawner.DistributionActionInterval'*/,
		};
		TargetActionInterval = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SeqAct_TdCrowdSpawner.DistributionTargetActionInterval")/*Ref DistributionFloatUniform'Default__SeqAct_TdCrowdSpawner.DistributionTargetActionInterval'*/,
		};
		ObjName = "Td Crowd Spawner";
	}
}
}