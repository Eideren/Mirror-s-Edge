namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InterpTrackInstSound : InterpTrackInst/*
		native*/{
	public float LastUpdatePosition;
	[export, editinline, transient] public AudioComponent PlayAudioComp;
	
}
}