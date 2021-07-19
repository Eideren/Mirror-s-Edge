namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPlaceableCheckpoint : NavigationPoint, 
		TdCheckpointVolumeListener/*
		abstract
		native
		notplaceable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	[Category("CheckpointSettings")] public bool bEnabled;
	public bool bActive;
	[Category("CheckpointSettings")] public bool bShouldBeBased;
	[transient] public/*private*/ TdCheckpointListener Listener;
	[transient] public int ActiveIndex;
	[Const, export, editinline] public StaticMeshComponent CheckpointMesh;
	[Category("CheckpointSettings")] public TdCheckpointVolume TouchVolume;
	
	public override Reset_del Reset { get => bfield_Reset ?? TdPlaceableCheckpoint_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => TdPlaceableCheckpoint_Reset;
	public /*function */void TdPlaceableCheckpoint_Reset()
	{
		// stub
	}
	
	public virtual /*function */int GetNumTracks()
	{
		// stub
		return default;
	}
	
	public virtual /*function */int GetTrackIndex(int ArrayIdx)
	{
		// stub
		return default;
	}
	
	public virtual /*function */int GetOrderIndex(int ArrayIdx)
	{
		// stub
		return default;
	}
	
	public virtual /*function */int GetOrderIndexForTrack(int TrackIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void SetLastCheckpoint(int TrackIndex)
	{
		// stub
	}
	
	public virtual /*function */bool ShouldGenerateTrackData(int TrackIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void SetListener(TdCheckpointListener InListener)
	{
		// stub
	}
	
	public virtual /*function */void Show(bool bShow, /*optional */int? _Track = default, /*optional */bool? _bNoFade = default)
	{
		// stub
	}
	
	public virtual /*function */bool IsCheckpointInTrack(int TrackIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void SetDirectionHint(Object.Rotator NextCheckpointHint)
	{
		// stub
	}
	
	public virtual /*function */void OnTouchedVolume(TdPlayerPawn Pawn, TdPlayerController Controller)
	{
		// stub
	}
	
	public override Touch_del Touch { get => bfield_Touch ?? TdPlaceableCheckpoint_Touch; set => bfield_Touch = value; } Touch_del bfield_Touch;
	public override Touch_del global_Touch => TdPlaceableCheckpoint_Touch;
	public /*event */void TdPlaceableCheckpoint_Touch(Actor Other, PrimitiveComponent OtherComp, Object.Vector HitLocation, Object.Vector HitNormal)
	{
		// stub
	}
	protected override void RestoreDefaultFunction()
	{
		Reset = null;
		Touch = null;
	
	}
	public TdPlaceableCheckpoint()
	{
		var Default__TdPlaceableCheckpoint_MyMesh = new StaticMeshComponent
		{
			// Object Offset:0x00674D37
			HiddenGame = true,
			CastShadow = false,
			bAcceptsLights = false,
			CollideActors = false,
			BlockRigidBody = false,
		}/* Reference: StaticMeshComponent'Default__TdPlaceableCheckpoint.MyMesh' */;
		var Default__TdPlaceableCheckpoint_CollisionCylinder = new CylinderComponent
		{
			// Object Offset:0x00674CB3
			CollisionHeight = 100.0f,
			CollisionRadius = 100.0f,
			CollideActors = true,
		}/* Reference: CylinderComponent'Default__TdPlaceableCheckpoint.CollisionCylinder' */;
		var Default__TdPlaceableCheckpoint_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdPlaceableCheckpoint.Sprite' */;
		var Default__TdPlaceableCheckpoint_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdPlaceableCheckpoint.Sprite2' */;
		var Default__TdPlaceableCheckpoint_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdPlaceableCheckpoint.Arrow' */;
		var Default__TdPlaceableCheckpoint_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__TdPlaceableCheckpoint.PathRenderer' */;
		// Object Offset:0x0060E364
		bEnabled = true;
		bActive = true;
		bShouldBeBased = true;
		CheckpointMesh = Default__TdPlaceableCheckpoint_MyMesh/*Ref StaticMeshComponent'Default__TdPlaceableCheckpoint.MyMesh'*/;
		CylinderComponent = Default__TdPlaceableCheckpoint_CollisionCylinder/*Ref CylinderComponent'Default__TdPlaceableCheckpoint.CollisionCylinder'*/;
		GoodSprite = Default__TdPlaceableCheckpoint_Sprite/*Ref SpriteComponent'Default__TdPlaceableCheckpoint.Sprite'*/;
		BadSprite = Default__TdPlaceableCheckpoint_Sprite2/*Ref SpriteComponent'Default__TdPlaceableCheckpoint.Sprite2'*/;
		bCollideActors = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdPlaceableCheckpoint_Sprite/*Ref SpriteComponent'Default__TdPlaceableCheckpoint.Sprite'*/,
			Default__TdPlaceableCheckpoint_Sprite2/*Ref SpriteComponent'Default__TdPlaceableCheckpoint.Sprite2'*/,
			Default__TdPlaceableCheckpoint_Arrow/*Ref ArrowComponent'Default__TdPlaceableCheckpoint.Arrow'*/,
			Default__TdPlaceableCheckpoint_CollisionCylinder/*Ref CylinderComponent'Default__TdPlaceableCheckpoint.CollisionCylinder'*/,
			Default__TdPlaceableCheckpoint_PathRenderer/*Ref PathRenderingComponent'Default__TdPlaceableCheckpoint.PathRenderer'*/,
			Default__TdPlaceableCheckpoint_MyMesh/*Ref StaticMeshComponent'Default__TdPlaceableCheckpoint.MyMesh'*/,
		};
		CollisionComponent = Default__TdPlaceableCheckpoint_CollisionCylinder/*Ref CylinderComponent'Default__TdPlaceableCheckpoint.CollisionCylinder'*/;
	}
}
}