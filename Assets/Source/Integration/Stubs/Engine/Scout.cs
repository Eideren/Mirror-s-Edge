namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Scout : Pawn/*
		transient
		native
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public partial struct /*native */PathSizeInfo
	{
		public name Desc;
		public float Radius;
		public float Height;
		public float CrouchHeight;
		public byte PathColor;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003B4042
	//		Desc = (name)"None";
	//		Radius = 0.0f;
	//		Height = 0.0f;
	//		CrouchHeight = 0.0f;
	//		PathColor = 0;
	//	}
	};
	
	public array<Scout.PathSizeInfo> PathSizes;
	public float TestJumpZ;
	public float TestGroundSpeed;
	public float TestMaxFallSpeed;
	public float TestFallSpeed;
	[Const] public float MaxLandingVelocity;
	public int MinNumPlayerStarts;
	public Core.ClassT<ReachSpec> DefaultReachSpecClass;
	
	public override /*simulated event */void PreBeginPlay()
	{
		// stub
	}
	
	public Scout()
	{
		var Default__Scout_SceneCaptureCharacterComponent0 = new SceneCaptureCharacterComponent
		{
		}/* Reference: SceneCaptureCharacterComponent'Default__Scout.SceneCaptureCharacterComponent0' */;
		var Default__Scout_DrawFrust0 = new DrawFrustumComponent
		{
		}/* Reference: DrawFrustumComponent'Default__Scout.DrawFrust0' */;
		var Default__Scout_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__Scout.CollisionCylinder' */;
		// Object Offset:0x003B42C0
		PathSizes = new array<Scout.PathSizeInfo>
		{
			new Scout.PathSizeInfo
			{
				Desc = (name)"Human",
				Radius = 48.0f,
				Height = 80.0f,
				CrouchHeight = 0.0f,
				PathColor = 0,
			},
			new Scout.PathSizeInfo
			{
				Desc = (name)"Common",
				Radius = 72.0f,
				Height = 100.0f,
				CrouchHeight = 0.0f,
				PathColor = 0,
			},
			new Scout.PathSizeInfo
			{
				Desc = (name)"Max",
				Radius = 120.0f,
				Height = 120.0f,
				CrouchHeight = 0.0f,
				PathColor = 0,
			},
			new Scout.PathSizeInfo
			{
				Desc = (name)"Vehicle",
				Radius = 260.0f,
				Height = 120.0f,
				CrouchHeight = 0.0f,
				PathColor = 0,
			},
		};
		TestJumpZ = 420.0f;
		TestGroundSpeed = 600.0f;
		TestMaxFallSpeed = 2500.0f;
		TestFallSpeed = 1200.0f;
		MinNumPlayerStarts = 1;
		DefaultReachSpecClass = ClassT<ReachSpec>()/*Ref Class'ReachSpec'*/;
		AccelRate = 1.0f;
		SceneCapture = Default__Scout_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__Scout.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = Default__Scout_DrawFrust0/*Ref DrawFrustumComponent'Default__Scout.DrawFrust0'*/;
		CylinderComponent = Default__Scout_CollisionCylinder/*Ref CylinderComponent'Default__Scout.CollisionCylinder'*/;
		bCollideActors = false;
		bCollideWorld = false;
		bBlockActors = false;
		bProjTarget = false;
		bPathColliding = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__Scout_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__Scout.SceneCaptureCharacterComponent0'*/,
			Default__Scout_DrawFrust0/*Ref DrawFrustumComponent'Default__Scout.DrawFrust0'*/,
			Default__Scout_CollisionCylinder/*Ref CylinderComponent'Default__Scout.CollisionCylinder'*/,
		};
		RemoteRole = Actor.ENetRole.ROLE_None;
		CollisionComponent = Default__Scout_CollisionCylinder/*Ref CylinderComponent'Default__Scout.CollisionCylinder'*/;
	}
}
}