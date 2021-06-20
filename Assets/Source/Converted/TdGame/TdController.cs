namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public interface TdController : Interface/*
		abstract
		native*/{
	public /*function */Object.Vector GetFloor()
	{
	
		return default;
	}
	
	public /*function */void SetCameraRotationAid(Object.Rotator desiredRot)
	{
	
	}
	
	public /*function */void OnMovementStateChange(name NewState)
	{
	
	}
	
}
}