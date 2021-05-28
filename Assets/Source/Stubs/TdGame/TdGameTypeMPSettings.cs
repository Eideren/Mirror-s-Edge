namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdGameTypeMPSettings : TdGameTypeSettings/*
		config(GameTypeSettings)*/{
	public TdGameTypeMPSettings()
	{
		// Object Offset:0x0054A949
		AimAssistYawBias = 0.60f;
		AimAssistPitchBias = 1.0f;
	}
}
}