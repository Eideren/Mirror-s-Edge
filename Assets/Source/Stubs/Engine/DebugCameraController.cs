namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DebugCameraController : PlayerController/*
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public PlayerController OryginalControllerRef;
	public Player OryginalPlayer;
	public bool bIsFrozenRendering;
	public /*export editinline */DrawFrustumComponent DrawFrustum;
	
	public override /*simulated event */void PostBeginPlay()
	{
	
	}
	
	public virtual /*function */void OnActivate(PlayerController PC)
	{
	
	}
	
	public virtual /*function */void OnDeactivate(PlayerController PC)
	{
	
	}
	
	public virtual /*exec function */void SetFreezeRendering()
	{
	
	}
	
	public virtual /*exec function */void MoreSpeed()
	{
	
	}
	
	public virtual /*exec function */void NormalSpeed()
	{
	
	}
	
	public virtual /*function */void DisableDebugCamera()
	{
	
	}
	
	public DebugCameraController()
	{
		// Object Offset:0x002FA0A1
		InputClass = ClassT<DebugCameraInput>()/*Ref Class'DebugCameraInput'*/;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__DebugCameraController.CollisionCylinder")/*Ref CylinderComponent'Default__DebugCameraController.CollisionCylinder'*/;
		bHidden = false;
		bHiddenEd = false;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__DebugCameraController.Sprite")/*Ref SpriteComponent'Default__DebugCameraController.Sprite'*/,
			LoadAsset<CylinderComponent>("Default__DebugCameraController.CollisionCylinder")/*Ref CylinderComponent'Default__DebugCameraController.CollisionCylinder'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__DebugCameraController.CollisionCylinder")/*Ref CylinderComponent'Default__DebugCameraController.CollisionCylinder'*/;
	}
}
}