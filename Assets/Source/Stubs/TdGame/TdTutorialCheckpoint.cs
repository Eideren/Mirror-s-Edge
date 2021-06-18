// NO OVERWRITE

namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdTutorialCheckpoint : TdPlaceableCheckpoint/*
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public partial struct TutorialCriteria
	{
		public/*()*/ TdPawn.EMovement MovementCriteria;
		#warning renamed, c# naming scheme
		public/*()*/ TdSPTutorialGame.ETutorialEvents TutorialCriteria_;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0067D75C
	//		MovementCriteria = TdPawn.EMovement.MOVE_None;
	//		TutorialCriteria = TdSPTutorialGame.ETutorialEvents.ETE_None;
	//	}
	};
	
	public partial struct CheckPointTrackIndex
	{
		public/*()*/ array<TdTutorialCheckpoint.TutorialCriteria> CompletionCriteria;
		public/*()*/ TdSPTutorialGame.EMovementChallenge TrackIndex;
		public/*()*/ int OrderIndex;
		public/*()*/ bool bIsOptional;
		public/*()*/ bool bResetPlayerIfFailed;
		public/*()*/ array<TdTutorialCheckpoint.TutorialCriteria> ResetCriteria;
	
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
	
	public/*(CheckpointSettings)*/ array<TdTutorialCheckpoint.CheckPointTrackIndex> BelongToTracks;
	
	public override /*function */int GetNumTracks()
	{
	
		return default;
	}
	
	public virtual /*function */int GetArrayIndexForTrack(int TrackIndex)
	{
	
		return default;
	}
	
	public override /*function */bool IsCheckpointInTrack(int TrackIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool ShouldResetPlayer(int TrackIndex, TdPawn.EMovement CurrentMove, TdSPTutorialGame.ETutorialEvents CurrentTutorialEvent)
	{
	
		return default;
	}
	
	public virtual /*function */bool IsOptional(int TrackIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool CanCompleteCheckpoint(int TrackIndex, TdPawn.EMovement CurrentMove, TdSPTutorialGame.ETutorialEvents CurrentTutorialEvent)
	{
	
		return default;
	}
	
	public override /*function */void Show(bool bShow, /*optional */int? _Track = default, /*optional */bool? _bNoFade = default)
	{
	
	}
	
	public override /*function */int GetTrackIndex(int ArrayIdx)
	{
	
		return default;
	}
	
	public override /*function */int GetOrderIndex(int ArrayIdx)
	{
	
		return default;
	}
	
	public override /*function */int GetOrderIndexForTrack(int TrackIndex)
	{
	
		return default;
	}
	
	public virtual /*private final function */bool BelongsToTrack(int TrackIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool HasCompletionCriterias(int TrackIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void SendCompletedEvent(int TrackIndex)
	{
	
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
		var Default__TdTutorialCheckpoint_Sprite = new SpriteComponent
		{
			// Object Offset:0x02E528E5
			Sprite = LoadAsset<Texture2D>("TdEditorResources.TutorialInformation")/*Ref Texture2D'TdEditorResources.TutorialInformation'*/,
		}/* Reference: SpriteComponent'Default__TdTutorialCheckpoint.Sprite' */;
		// Object Offset:0x0067E9D6
		CheckpointMesh = Default__TdTutorialCheckpoint_MyMesh;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdTutorialCheckpoint.CollisionCylinder")/*Ref CylinderComponent'Default__TdTutorialCheckpoint.CollisionCylinder'*/;
		GoodSprite = Default__TdTutorialCheckpoint_Sprite;
		BadSprite = LoadAsset<SpriteComponent>("Default__TdTutorialCheckpoint.Sprite2")/*Ref SpriteComponent'Default__TdTutorialCheckpoint.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdTutorialCheckpoint_Sprite,
			LoadAsset<SpriteComponent>("Default__TdTutorialCheckpoint.Sprite2")/*Ref SpriteComponent'Default__TdTutorialCheckpoint.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__TdTutorialCheckpoint.Arrow")/*Ref ArrowComponent'Default__TdTutorialCheckpoint.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__TdTutorialCheckpoint.CollisionCylinder")/*Ref CylinderComponent'Default__TdTutorialCheckpoint.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__TdTutorialCheckpoint.PathRenderer")/*Ref PathRenderingComponent'Default__TdTutorialCheckpoint.PathRenderer'*/,
			Default__TdTutorialCheckpoint_MyMesh,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdTutorialCheckpoint.CollisionCylinder")/*Ref CylinderComponent'Default__TdTutorialCheckpoint.CollisionCylinder'*/;
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