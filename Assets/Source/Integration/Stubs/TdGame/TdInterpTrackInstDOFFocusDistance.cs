namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdInterpTrackInstDOFFocusDistance : InterpTrackInst/*
		native*/{
	public float OldFocusDistance;
	public float OldMaxFarBlurAmount;
	public bool bOldShowInEditor;
	[transient] public DOFAndBloomEffect Effect;
	
}
}