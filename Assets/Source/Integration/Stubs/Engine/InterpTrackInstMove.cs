namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InterpTrackInstMove : InterpTrackInst/*
		native*/{
	public Object.Vector ResetLocation;
	public Object.Rotator ResetRotation;
	public Object.Matrix InitialTM;
	public Object.Quat InitialQuat;
	
}
}