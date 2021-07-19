namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Player : Object/*
		transient
		native
		config(Engine)*/{
	[native, Const, noexport] public/*private*/ Object.Pointer VfTable_FExec;
	[Const, transient] public PlayerController Actor;
	[Const] public int CurrentNetSpeed;
	[globalconfig] public int ConfiguredInternetSpeed;
	[globalconfig] public int ConfiguredLanSpeed;
	[config] public float PP_DesaturationMultiplier;
	[config] public float PP_HighlightsMultiplier;
	[config] public float PP_MidTonesMultiplier;
	[config] public float PP_ShadowsMultiplier;
	
	// Export UPlayer::execSwitchController(FFrame&, void* const)
	public virtual /*native function */void SwitchController(PlayerController PC)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public Player()
	{
		// Object Offset:0x00351F94
		ConfiguredInternetSpeed = 10000;
		ConfiguredLanSpeed = 20000;
		PP_DesaturationMultiplier = 1.0f;
		PP_HighlightsMultiplier = 1.0f;
		PP_MidTonesMultiplier = 1.0f;
		PP_ShadowsMultiplier = 1.0f;
	}
}
}