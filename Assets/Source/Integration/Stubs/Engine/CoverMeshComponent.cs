namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CoverMeshComponent : StaticMeshComponent/*
		native
		editinlinenew
		hidecategories(Object)
		autoexpandcategories(Collision,Rendering,Lighting)*/{
	public partial struct /*native */CoverMeshes
	{
		public StaticMesh Base;
		public StaticMesh LeanLeft;
		public StaticMesh LeanRight;
		public StaticMesh Climb;
		public StaticMesh Mantle;
		public StaticMesh SlipLeft;
		public StaticMesh SlipRight;
		public StaticMesh SwatLeft;
		public StaticMesh SwatRight;
		public StaticMesh PopUp;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002E3C54
	//		Base = default;
	//		LeanLeft = default;
	//		LeanRight = default;
	//		Climb = default;
	//		Mantle = default;
	//		SlipLeft = default;
	//		SlipRight = default;
	//		SwatLeft = default;
	//		SwatRight = default;
	//		PopUp = default;
	//	}
	};
	
	[editoronly] public array<CoverMeshComponent.CoverMeshes> Meshes;
	public Object.Vector LocationOffset;
	[editoronly] public StaticMesh AutoAdjustOn;
	[editoronly] public StaticMesh AutoAdjustOff;
	[editoronly] public StaticMesh Disabled;
	
	public CoverMeshComponent()
	{
		// Object Offset:0x002E3E94
		Meshes = new array<CoverMeshComponent.CoverMeshes>
		{
			new CoverMeshComponent.CoverMeshes
			{
				Base = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy__BASE_TALL")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy__BASE_TALL'*/,
				LeanLeft = default,
				LeanRight = default,
				Climb = default,
				Mantle = default,
				SlipLeft = default,
				SlipRight = default,
				SwatLeft = default,
				SwatRight = default,
				PopUp = default,
			},
			new CoverMeshComponent.CoverMeshes
			{
				Base = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy__BASE_TALL")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy__BASE_TALL'*/,
				LeanLeft = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy_LeanLeftS")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy_LeanLeftS'*/,
				LeanRight = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy_LeanRightS")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy_LeanRightS'*/,
				Climb = default,
				Mantle = default,
				SlipLeft = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy_CoverSlipLeft")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy_CoverSlipLeft'*/,
				SlipRight = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy_CoverSlipRight")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy_CoverSlipRight'*/,
				SwatLeft = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy_SwatLeft")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy_SwatLeft'*/,
				SwatRight = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy_SwatRight")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy_SwatRight'*/,
				PopUp = default,
			},
			new CoverMeshComponent.CoverMeshes
			{
				Base = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy__BASE_SHORT")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy__BASE_SHORT'*/,
				LeanLeft = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy_LeanLeftM")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy_LeanLeftM'*/,
				LeanRight = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy_LeanRightM")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy_LeanRightM'*/,
				Climb = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy_Climb")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy_Climb'*/,
				Mantle = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy_Mantle")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy_Mantle'*/,
				SlipLeft = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy_CoverSlipLeft")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy_CoverSlipLeft'*/,
				SlipRight = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy_CoverSlipRight")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy_CoverSlipRight'*/,
				SwatLeft = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy_SwatLeft")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy_SwatLeft'*/,
				SwatRight = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy_SwatRight")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy_SwatRight'*/,
				PopUp = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy_PopUp")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy_PopUp'*/,
			},
			new CoverMeshComponent.CoverMeshes
			{
				Base = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy__BASE_SHORT")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy__BASE_SHORT'*/,
				LeanLeft = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy_LeanLeftM")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy_LeanLeftM'*/,
				LeanRight = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy_LeanRightM")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy_LeanRightM'*/,
				Climb = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy_Climb")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy_Climb'*/,
				Mantle = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy_Mantle")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy_Mantle'*/,
				SlipLeft = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy_CoverSlipLeft")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy_CoverSlipLeft'*/,
				SlipRight = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy_CoverSlipRight")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy_CoverSlipRight'*/,
				SwatLeft = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy_SwatLeft")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy_SwatLeft'*/,
				SwatRight = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy_SwatRight")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy_SwatRight'*/,
				PopUp = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy_PopUp")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy_PopUp'*/,
			},
		};
		LocationOffset = new Vector
		{
			X=0.0f,
			Y=0.0f,
			Z=-60.0f
		};
		AutoAdjustOn = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy_AutoAdjust")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy_AutoAdjust'*/;
		AutoAdjustOff = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy_AutoAdjustOff")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy_AutoAdjustOff'*/;
		Disabled = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy_Enabled")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy_Enabled'*/;
		StaticMesh = LoadAsset<StaticMesh>("NodeBuddies.3D_Icons.NodeBuddy__BASE_TALL")/*Ref StaticMesh'NodeBuddies.3D_Icons.NodeBuddy__BASE_TALL'*/;
		HiddenGame = true;
		bAcceptsDecals = false;
		CastShadow = false;
		bAcceptsLights = false;
		CollideActors = false;
		BlockActors = false;
		BlockZeroExtent = false;
		BlockNonZeroExtent = false;
		BlockRigidBody = false;
		AlwaysLoadOnClient = false;
		AlwaysLoadOnServer = false;
	}
}
}