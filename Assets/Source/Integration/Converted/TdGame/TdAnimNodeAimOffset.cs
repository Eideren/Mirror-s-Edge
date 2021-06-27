namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAnimNodeAimOffset : AnimNodeAimOffset/*
		native
		hidecategories(Object,Object,Object)*/{
	public/*()*/ bool bInterpolateHorizontalAiming;
	public/*()*/ bool bAimSourceIsLegRotation;
	public/*()*/ bool bManualAim;
	public/*()*/ float HorizontalInterpolationSpeed;
	public /*transient */Object.Vector2D WantedAiming;
	public /*native */float DeltaTime;
	public /*native */float InterpolationValue;
	
	public virtual /*event */void OnBecameRelevant()
	{
		if(bInterpolateHorizontalAiming)
		{
			Aim.X = 0.0f;
			WantedAiming.X = 0.0f;
			InterpolationValue = 0.0f;
		}
	}
	
	public override /*event */void EditorProfileUpdated(name ProfileName)
	{
		SetActiveProfileByName(ProfileName);
	}
	
	public TdAnimNodeAimOffset()
	{
		// Object Offset:0x004FCA9E
		HorizontalInterpolationSpeed = 0.30f;
	}
}
}