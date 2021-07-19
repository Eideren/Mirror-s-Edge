namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DebugCameraController : PlayerController/*
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public PlayerController OryginalControllerRef;
	public Player OryginalPlayer;
	public bool bIsFrozenRendering;
	[export, editinline] public DrawFrustumComponent DrawFrustum;
	
	public override /*simulated event */void PostBeginPlay()
	{
		// stub
	}
	
	public virtual /*function */void OnActivate(PlayerController PC)
	{
		// stub
	}
	
	public virtual /*function */void OnDeactivate(PlayerController PC)
	{
		// stub
	}
	
	public virtual /*exec function */void SetFreezeRendering()
	{
		// stub
	}
	
	public virtual /*exec function */void MoreSpeed()
	{
		// stub
	}
	
	public virtual /*exec function */void NormalSpeed()
	{
		// stub
	}
	
	public virtual /*function */void DisableDebugCamera()
	{
		// stub
	}
	
	public DebugCameraController()
	{
		var Default__DebugCameraController_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__DebugCameraController.CollisionCylinder' */;
		var Default__DebugCameraController_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__DebugCameraController.Sprite' */;
		// Object Offset:0x002FA0A1
		InputClass = ClassT<DebugCameraInput>()/*Ref Class'DebugCameraInput'*/;
		CylinderComponent = Default__DebugCameraController_CollisionCylinder/*Ref CylinderComponent'Default__DebugCameraController.CollisionCylinder'*/;
		bHidden = false;
		bHiddenEd = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__DebugCameraController_Sprite/*Ref SpriteComponent'Default__DebugCameraController.Sprite'*/,
			Default__DebugCameraController_CollisionCylinder/*Ref CylinderComponent'Default__DebugCameraController.CollisionCylinder'*/,
		};
		CollisionComponent = Default__DebugCameraController_CollisionCylinder/*Ref CylinderComponent'Default__DebugCameraController.CollisionCylinder'*/;
	}
}
}