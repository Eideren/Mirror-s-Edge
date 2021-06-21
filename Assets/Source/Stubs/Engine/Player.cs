namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Player : Object/*
		transient
		native
		config(Engine)*/{
	public /*private native const noexport */Object.Pointer VfTable_FExec;
	public /*const transient */PlayerController Actor;
	public /*const */int CurrentNetSpeed;
	public /*globalconfig */int ConfiguredInternetSpeed;
	public /*globalconfig */int ConfiguredLanSpeed;
	public /*config */float PP_DesaturationMultiplier;
	public /*config */float PP_HighlightsMultiplier;
	public /*config */float PP_MidTonesMultiplier;
	public /*config */float PP_ShadowsMultiplier;
	
	// Export UPlayer::execSwitchController(FFrame&, void* const)
	public virtual /*native function */void SwitchController(PlayerController PC)
	{
		#warning NATIVE FUNCTION !
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