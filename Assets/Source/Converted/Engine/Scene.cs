namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Scene : Object/*
		native*/{
	public const int SDPG_NumBits = 3;
	
	public enum ESceneDepthPriorityGroup 
	{
		SDPG_UnrealEdBackground,
		SDPG_World,
		SDPG_Intermediate,
		SDPG_Foreground,
		SDPG_UnrealEdForeground,
		SDPG_PostProcess,
		SDPG_MAX
	};
	
	public enum EDetailMode 
	{
		DM_Low,
		DM_Medium,
		DM_High,
		DM_MAX
	};
	
}
}