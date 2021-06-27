namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimNodeEditInfo_AimOffset : AnimNodeEditInfo/*
		native*/{
	public /*native const */Object.Pointer EditWindow;
	public AnimNodeAimOffset EditNode;
	
	public AnimNodeEditInfo_AimOffset()
	{
		// Object Offset:0x0001A014
		AnimNodeClass = ClassT<AnimNodeAimOffset>()/*Ref Class'AnimNodeAimOffset'*/;
	}
}
}