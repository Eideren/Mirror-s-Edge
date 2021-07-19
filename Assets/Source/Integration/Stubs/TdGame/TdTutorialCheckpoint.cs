// NO OVERWRITE

namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdTutorialCheckpoint : TdPlaceableCheckpoint/*
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public partial struct TutorialCriteria
	{
		[Category] public TdPawn.EMovement MovementCriteria;
		#warning renamed, c# naming scheme
		[Category] public TdSPTutorialGame.ETutorialEvents TutorialCriteria_;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0067D75C
	//		MovementCriteria = TdPawn.EMovement.MOVE_None;
	//		TutorialCriteria = TdSPTutorialGame.ETutorialEvents.ETE_None;
	//	}
	};
	
	public partial struct CheckPointTrackIndex
	{
		[Category] public array<TdTutorialCheckpoint.TutorialCriteria> CompletionCriteria;
		[Category] public TdSPTutorialGame.EMovementChallenge TrackIndex;
		[Category] public int OrderIndex;
		[Category] public bool bIsOptional;
		[Category] public bool bResetPlayerIfFailed;
		[Category] public array<TdTutorialCheckpoint.TutorialCriteria> ResetCriteria;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0067D948
	//		CompletionCriteria = default;
	//		TrackIndex = TdSPTutorialGame.EMovementChallenge.EMC_None;
	//		OrderIndex = 0;
	//		bIsOptional = false;
	//		bResetPlayerIfFailed = false;
	//		ResetCriteria = default;
	//	}
	};
	
	[Category("CheckpointSettings")] public array<TdTutorialCheckpoint.CheckPointTrackIndex> BelongToTracks;
	
	public override /*function */int GetNumTracks()
	{
		// stub
		return default;
	}
	
	public virtual /*function */int GetArrayIndexForTrack(int TrackIndex)
	{
		// stub
		return default;
	}
	
	public override /*function */bool IsCheckpointInTrack(int TrackIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool ShouldResetPlayer(int TrackIndex, TdPawn.EMovement CurrentMove, TdSPTutorialGame.ETutorialEvents CurrentTutorialEvent)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool IsOptional(int TrackIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool CanCompleteCheckpoint(int TrackIndex, TdPawn.EMovement CurrentMove, TdSPTutorialGame.ETutorialEvents CurrentTutorialEvent)
	{
		// stub
		return default;
	}
	
	public override /*function */void Show(bool bShow, /*optional */int? _Track = default, /*optional */bool? _bNoFade = default)
	{
		// stub
	}
	
	public override /*function */int GetTrackIndex(int ArrayIdx)
	{
		// stub
		return default;
	}
	
	public override /*function */int GetOrderIndex(int ArrayIdx)
	{
		// stub
		return default;
	}
	
	public override /*function */int GetOrderIndexForTrack(int TrackIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */bool BelongsToTrack(int TrackIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool HasCompletionCriterias(int TrackIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void SendCompletedEvent(int TrackIndex)
	{
		// stub
	}
	
	public TdTutorialCheckpoint()
	{
		var Default__TdTutorialCheckpoint_MyMesh = new StaticMeshComponent
		{
			// Object Offset:0x02EA702B
			StaticMesh = LoadAsset<StaticMesh>("TT_Checkpoints.S_Checkpoint_01")/*Ref StaticMesh'TT_Checkpoints.S_Checkpoint_01'*/,
			HiddenEditor = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
			Scale3D = new Vector
			{
				X=1.0f,
				Y=1.0f,
				Z=14.0f
			},
		}/* Reference: StaticMeshComponent'Default__TdTutorialCheckpoint.MyMesh' */;
		var Default__TdTutorialCheckpoint_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdTutorialCheckpoint.CollisionCylinder' */;
		var Default__TdTutorialCheckpoint_Sprite = new SpriteComponent
		{
			// Object Offset:0x02E528E5
			Sprite = LoadAsset<Texture2D>("TdEditorResources.TutorialInformation")/*Ref Texture2D'TdEditorResources.TutorialInformation'*/,
		}/* Reference: SpriteComponent'Default__TdTutorialCheckpoint.Sprite' */;
		var Default__TdTutorialCheckpoint_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdTutorialCheckpoint.Sprite2' */;
		var Default__TdTutorialCheckpoint_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdTutorialCheckpoint.Arrow' */;
		var Default__TdTutorialCheckpoint_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__TdTutorialCheckpoint.PathRenderer' */;
		// Object Offset:0x0067E9D6
		CheckpointMesh = Default__TdTutorialCheckpoint_MyMesh/*Ref StaticMeshComponent'Default__TdTutorialCheckpoint.MyMesh'*/;
		CylinderComponent = Default__TdTutorialCheckpoint_CollisionCylinder/*Ref CylinderComponent'Default__TdTutorialCheckpoint.CollisionCylinder'*/;
		GoodSprite = Default__TdTutorialCheckpoint_Sprite/*Ref SpriteComponent'Default__TdTutorialCheckpoint.Sprite'*/;
		BadSprite = Default__TdTutorialCheckpoint_Sprite2/*Ref SpriteComponent'Default__TdTutorialCheckpoint.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdTutorialCheckpoint_Sprite/*Ref SpriteComponent'Default__TdTutorialCheckpoint.Sprite'*/,
			Default__TdTutorialCheckpoint_Sprite2/*Ref SpriteComponent'Default__TdTutorialCheckpoint.Sprite2'*/,
			Default__TdTutorialCheckpoint_Arrow/*Ref ArrowComponent'Default__TdTutorialCheckpoint.Arrow'*/,
			Default__TdTutorialCheckpoint_CollisionCylinder/*Ref CylinderComponent'Default__TdTutorialCheckpoint.CollisionCylinder'*/,
			Default__TdTutorialCheckpoint_PathRenderer/*Ref PathRenderingComponent'Default__TdTutorialCheckpoint.PathRenderer'*/,
			Default__TdTutorialCheckpoint_MyMesh/*Ref StaticMeshComponent'Default__TdTutorialCheckpoint.MyMesh'*/,
		};
		CollisionComponent = Default__TdTutorialCheckpoint_CollisionCylinder/*Ref CylinderComponent'Default__TdTutorialCheckpoint.CollisionCylinder'*/;
		SupportedEvents = new array< Core.ClassT<SequenceEvent> >
		{
			ClassT<SeqEvent_Touch>(),
			ClassT<SeqEvent_Destroyed>(),
			ClassT<SeqEvent_TakeDamage>(),
			ClassT<SeqEvt_TdTutorialCheckpointCompleted>(),
		};
	}
}
}