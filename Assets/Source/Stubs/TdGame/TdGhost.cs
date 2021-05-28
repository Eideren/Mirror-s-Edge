namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdGhost : Object/*
		native*/{
	public partial struct /*native */TdGhostInfo
	{
		public int StretchId;
		public string PlayerName;
		public float TotalTime;
		public int GhostTag;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0054D7E5
	//		StretchId = 0;
	//		PlayerName = "";
	//		TotalTime = 0.0f;
	//		GhostTag = 0;
	//	}
	};
	
	public TdGhost.TdGhostInfo Info;
	public array<byte> RawBytes;
	
}
}