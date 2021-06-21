namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CameraMode : Object/*
		native*/{
	public virtual /*simulated function */void ProcessViewRotation(float DeltaTime, Actor ViewTarget, ref Object.Rotator out_ViewRotation, ref Object.Rotator out_DeltaRot)
	{
		// stub
	}
	
	public virtual /*function */bool AllowPawnRotation()
	{
		// stub
		return default;
	}
	
}
}