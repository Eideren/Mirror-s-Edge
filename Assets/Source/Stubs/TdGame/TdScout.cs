namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdScout : Scout/*
		transient
		native
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public Core.ClassT<TdPawn> PrototypePawnClass;
	
	public TdScout()
	{
		var Default__TdScout_CollisionCylinder = new CylinderComponent
		{
			// Object Offset:0x01AB4DE2
			CollisionRadius = 30.0f,
		}/* Reference: CylinderComponent'Default__TdScout.CollisionCylinder' */;
		// Object Offset:0x00655FED
		PrototypePawnClass = ClassT<TdBotPawn>()/*Ref Class'TdBotPawn'*/;
		PathSizes = new array<Scout.PathSizeInfo>
		{
			new Scout.PathSizeInfo
			{
				Desc = (name)"Crouched",
				Radius = 30.0f,
				Height = 60.0f,
				CrouchHeight = 0.0f,
				PathColor = 0,
			},
			new Scout.PathSizeInfo
			{
				Desc = (name)"Human",
				Radius = 30.0f,
				Height = 90.0f,
				CrouchHeight = 0.0f,
				PathColor = 0,
			},
			new Scout.PathSizeInfo
			{
				Desc = (name)"Small",
				Radius = 72.0f,
				Height = 90.0f,
				CrouchHeight = 0.0f,
				PathColor = 0,
			},
			new Scout.PathSizeInfo
			{
				Desc = (name)"Common",
				Radius = 100.0f,
				Height = 90.0f,
				CrouchHeight = 0.0f,
				PathColor = 0,
			},
			new Scout.PathSizeInfo
			{
				Desc = (name)"Max",
				Radius = 150.0f,
				Height = 90.0f,
				CrouchHeight = 0.0f,
				PathColor = 0,
			},
			new Scout.PathSizeInfo
			{
				Desc = (name)"CommonPath",
				Radius = 250.0f,
				Height = 90.0f,
				CrouchHeight = 0.0f,
				PathColor = 0,
			},
			new Scout.PathSizeInfo
			{
				Desc = (name)"WidePath",
				Radius = 350.0f,
				Height = 90.0f,
				CrouchHeight = 0.0f,
				PathColor = 0,
			},
		};
		TestJumpZ = 322.0f;
		TestGroundSpeed = 440.0f;
		TestMaxFallSpeed = 400.0f;
		DefaultReachSpecClass = ClassT<TdReachSpec>()/*Ref Class'TdReachSpec'*/;
		MaxJumpHeight = 25.0f;
		WalkableFloorZ = 0.80f;
		bCanWalkOffLedges = true;
		SceneCapture = LoadAsset<SceneCaptureCharacterComponent>("Default__TdScout.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdScout.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = LoadAsset<DrawFrustumComponent>("Default__TdScout.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdScout.DrawFrust0'*/;
		CylinderComponent = Default__TdScout_CollisionCylinder;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SceneCaptureCharacterComponent>("Default__TdScout.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdScout.SceneCaptureCharacterComponent0'*/,
			LoadAsset<DrawFrustumComponent>("Default__TdScout.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdScout.DrawFrust0'*/,
			Default__TdScout_CollisionCylinder,
		};
		CollisionComponent = Default__TdScout_CollisionCylinder;
	}
}
}