namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CameraModifier : Object/*
		native*/{
	public /*protected */bool bDisabled;
	public bool bPendingDisable;
	public/*(Debug)*/ bool bDebug;
	public Camera CameraOwner;
	
	public virtual /*function */void Init()
	{
	
	}
	
	public virtual /*function */bool ModifyCamera(Camera Camera, float DeltaTime, ref Object.TPOV OutPOV)
	{
	
		return default;
	}
	
	public virtual /*function */bool AddCameraModifier(Camera Camera)
	{
	
		return default;
	}
	
	public virtual /*function */bool RemoveCameraModifier(Camera Camera)
	{
	
		return default;
	}
	
	public virtual /*simulated function */bool IsDisabled()
	{
	
		return default;
	}
	
	public virtual /*function */void DisableModifier()
	{
	
	}
	
	public virtual /*function */void EnableModifier()
	{
	
	}
	
	public virtual /*function */void ToggleModifier()
	{
	
	}
	
	public virtual /*simulated function */bool ProcessViewRotation(Actor ViewTarget, float DeltaTime, ref Object.Rotator out_ViewRotation, ref Object.Rotator out_DeltaRot)
	{
	
		return default;
	}
	
}
}