namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdGameTypeSPSettings : TdGameTypeSettings/*
		config(GameTypeSettings)*/{
	public TdGameTypeSPSettings()
	{
		// Object Offset:0x0054A9F0
		AimAssistYawBias = 1.0f;
		AimAssistPitchBias = 1.0f;
	}
}
}