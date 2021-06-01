namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPlaceableCheckpoint : NavigationPoint, 
		TdCheckpointVolumeListener/*
		abstract
		native
		notplaceable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public/*(CheckpointSettings)*/ bool bEnabled;
	public bool bActive;
	public/*(CheckpointSettings)*/ bool bShouldBeBased;
	public /*private transient */TdCheckpointListener Listener;
	public /*transient */int ActiveIndex;
	public /*const export editinline */StaticMeshComponent CheckpointMesh;
	public/*(CheckpointSettings)*/ TdCheckpointVolume TouchVolume;
	
	public override Reset_del Reset { get => bfield_Reset ?? TdPlaceableCheckpoint_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => TdPlaceableCheckpoint_Reset;
	public /*function */void TdPlaceableCheckpoint_Reset()
	{
	
	}
	
	public virtual /*function */int GetNumTracks()
	{
	
		return default;
	}
	
	public virtual /*function */int GetTrackIndex(int ArrayIdx)
	{
	
		return default;
	}
	
	public virtual /*function */int GetOrderIndex(int ArrayIdx)
	{
	
		return default;
	}
	
	public virtual /*function */int GetOrderIndexForTrack(int TrackIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void SetLastCheckpoint(int TrackIndex)
	{
	
	}
	
	public virtual /*function */bool ShouldGenerateTrackData(int TrackIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void SetListener(TdCheckpointListener InListener)
	{
	
	}
	
	public virtual /*function */void Show(bool bShow, /*optional */int? _Track = default, /*optional */bool? _bNoFade = default)
	{
	
	}
	
	public virtual /*function */bool IsCheckpointInTrack(int TrackIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void SetDirectionHint(Object.Rotator NextCheckpointHint)
	{
	
	}
	
	public virtual /*function */void OnTouchedVolume(TdPlayerPawn Pawn, TdPlayerController Controller)
	{
	
	}
	
	public override Touch_del Touch { get => bfield_Touch ?? TdPlaceableCheckpoint_Touch; set => bfield_Touch = value; } Touch_del bfield_Touch;
	public override Touch_del global_Touch => TdPlaceableCheckpoint_Touch;
	public /*event */void TdPlaceableCheckpoint_Touch(Actor Other, PrimitiveComponent OtherComp, Object.Vector HitLocation, Object.Vector HitNormal)
	{
	
	}
	protected override void RestoreDefaultFunction()
	{
		Reset = null;
		Touch = null;
	
	}
	public TdPlaceableCheckpoint()
	{
		// Object Offset:0x0060E364
		bEnabled = true;
		bActive = true;
		bShouldBeBased = true;
		CheckpointMesh = new StaticMeshComponent
		{
			// Object Offset:0x00674D37
			HiddenGame = true,
			CastShadow = false,
			bAcceptsLights = false,
			CollideActors = false,
			BlockRigidBody = false,
		}/* Reference: StaticMeshComponent'Default__TdPlaceableCheckpoint.MyMesh' */;
		CylinderComponent = new CylinderComponent
		{
			// Object Offset:0x00674CB3
			CollisionHeight = 100.0f,
			CollisionRadius = 100.0f,
			CollideActors = true,
		}/* Reference: CylinderComponent'Default__TdPlaceableCheckpoint.CollisionCylinder' */;
		GoodSprite = LoadAsset<SpriteComponent>("Default__TdPlaceableCheckpoint.Sprite")/*Ref SpriteComponent'Default__TdPlaceableCheckpoint.Sprite'*/;
		BadSprite = LoadAsset<SpriteComponent>("Default__TdPlaceableCheckpoint.Sprite2")/*Ref SpriteComponent'Default__TdPlaceableCheckpoint.Sprite2'*/;
		bCollideActors = true;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdPlaceableCheckpoint.Sprite")/*Ref SpriteComponent'Default__TdPlaceableCheckpoint.Sprite'*/,
			LoadAsset<SpriteComponent>("Default__TdPlaceableCheckpoint.Sprite2")/*Ref SpriteComponent'Default__TdPlaceableCheckpoint.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__TdPlaceableCheckpoint.Arrow")/*Ref ArrowComponent'Default__TdPlaceableCheckpoint.Arrow'*/,
			new CylinderComponent
			{
				// Object Offset:0x00674CB3
				CollisionHeight = 100.0f,
				CollisionRadius = 100.0f,
				CollideActors = true,
			}/* Reference: CylinderComponent'Default__TdPlaceableCheckpoint.CollisionCylinder' */,
			LoadAsset<PathRenderingComponent>("Default__TdPlaceableCheckpoint.PathRenderer")/*Ref PathRenderingComponent'Default__TdPlaceableCheckpoint.PathRenderer'*/,
			new StaticMeshComponent
			{
				// Object Offset:0x00674D37
				HiddenGame = true,
				CastShadow = false,
				bAcceptsLights = false,
				CollideActors = false,
				BlockRigidBody = false,
			}/* Reference: StaticMeshComponent'Default__TdPlaceableCheckpoint.MyMesh' */,
		};
		CollisionComponent = new CylinderComponent
		{
			// Object Offset:0x00674CB3
			CollisionHeight = 100.0f,
			CollisionRadius = 100.0f,
			CollideActors = true,
		}/* Reference: CylinderComponent'Default__TdPlaceableCheckpoint.CollisionCylinder' */;
	}
}
}