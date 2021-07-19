namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CrowdAttractor : Actor/*
		native
		placeable
		hidecategories(Navigation,Advanced,Collision,Display,Actor)*/{
	public enum ECrowdAttractorMode 
	{
		ECAM_MoveTarget,
		ECAM_Repulsor,
		ECAM_MAX
	};
	
	[Category] [interp] public float Attraction;
	[Category] public bool bAttractorEnabled;
	[Category] public bool bAttractionFalloff;
	[Category] public bool bActionAtThisAttractor;
	[Category] public bool bKillWhenReached;
	[Category] public float ActionRadiusScale;
	[Category] [export, editinline] public CylinderComponent CylinderComponent;
	public float AttractionRadius;
	public float AttractionHeight;
	[Category] public float KillDist;
	[Category] public Actor ActionTarget;
	[Category] public CrowdAttractor.ECrowdAttractorMode Mode;
	
	public virtual /*simulated function */void OnToggle(SeqAct_Toggle Action)
	{
		// stub
	}
	
	public CrowdAttractor()
	{
		var Default__CrowdAttractor_CollisionCylinder = new CylinderComponent
		{
			// Object Offset:0x004664BB
			CollisionHeight = 40.0f,
			CollisionRadius = 200.0f,
			CylinderColor = new Color
			{
				R=0,
				G=255,
				B=0,
				A=255
			},
			bDrawBoundingBox = false,
			bDrawNonColliding = true,
		}/* Reference: CylinderComponent'Default__CrowdAttractor.CollisionCylinder' */;
		var Default__CrowdAttractor_Sprite = new SpriteComponent
		{
			// Object Offset:0x004CF7E6
			HiddenGame = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: SpriteComponent'Default__CrowdAttractor.Sprite' */;
		// Object Offset:0x002F4703
		Attraction = 1.0f;
		bAttractorEnabled = true;
		bAttractionFalloff = true;
		ActionRadiusScale = 1.0f;
		CylinderComponent = Default__CrowdAttractor_CollisionCylinder/*Ref CylinderComponent'Default__CrowdAttractor.CollisionCylinder'*/;
		AttractionRadius = 200.0f;
		AttractionHeight = 40.0f;
		KillDist = 256.0f;
		bNoDelete = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__CrowdAttractor_CollisionCylinder/*Ref CylinderComponent'Default__CrowdAttractor.CollisionCylinder'*/,
			Default__CrowdAttractor_Sprite/*Ref SpriteComponent'Default__CrowdAttractor.Sprite'*/,
		};
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
		CollisionComponent = Default__CrowdAttractor_CollisionCylinder/*Ref CylinderComponent'Default__CrowdAttractor.CollisionCylinder'*/;
	}
}
}