namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdTimerCheckpoint : TdPlaceableCheckpoint/*
		config(Game)
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public partial struct CheckPointTrackIndex
	{
		public/*()*/ TdSPTimeTrialGame.ETTStretch TrackIndex;
		public/*()*/ int OrderIndex;
		public/*()*/ bool bNoIntermediateTime;
		public bool bLastCheckpoint;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00674EC3
	//		TrackIndex = TdSPTimeTrialGame.ETTStretch.ETTS_None;
	//		OrderIndex = 0;
	//		bNoIntermediateTime = false;
	//		bLastCheckpoint = false;
	//	}
	};
	
	public/*(CheckpointSettings)*/ array<TdTimerCheckpoint.CheckPointTrackIndex> BelongToTracks;
	public/*(CheckpointSettings)*/ float CustomHeight;
	public/*(CheckpointSettings)*/ float CustomWidthScale;
	public/*(CheckpointSettings)*/ bool bNoRespawn;
	public /*transient */float InitialHeight;
	public /*transient */float InitialRadius;
	public /*export editinline */ParticleSystemComponent EffectPSComponent;
	public ParticleSystem ArrowEffect;
	public /*transient */StaticArray<MaterialInstanceConstant, MaterialInstanceConstant>/*[2]*/ CheckpointMaterials;
	public /*transient */float FadeParam;
	public /*transient */float FadeTarget;
	public /*config */float FadeTime;
	public /*const export editinline */StaticMeshComponent CheckpointTimeMesh;
	public /*const export editinline */StaticMeshComponent CheckpointFinishlineMesh;
	public /*export editinline transient */StaticMeshComponent CurrentMesh;
	
	public virtual /*private final function */void AlignToGround(bool bIsLastCheckpoint)
	{
		// stub
	}
	
	public virtual /*function */void ScaleHeight()
	{
		// stub
	}
	
	public virtual /*function */void SetUpCheckpoint(bool bIsLastCheckpoint)
	{
		// stub
	}
	
	public override /*function */int GetNumTracks()
	{
		// stub
		return default;
	}
	
	public override /*function */bool ShouldGenerateTrackData(int TrackIndex)
	{
		// stub
		return default;
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
	
	public override /*function */void SetLastCheckpoint(int TrackIndex)
	{
		// stub
	}
	
	public virtual /*function */bool IsLastcheckpointInTrack(int Track)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool HasIntermediateTimeInTrack(int Track)
	{
		// stub
		return default;
	}
	
	public override /*function */void SetDirectionHint(Object.Rotator NextCheckpointHint)
	{
		// stub
	}
	
	public override /*function */void Show(bool bShow, /*optional */int? _Track = default, /*optional */bool? _bNoFade = default)
	{
		// stub
	}
	
	
	protected /*function */void TdTimerCheckpoint_Fading_Tick(float DeltaTime)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) Fading()/*state Fading*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "Fading": return Fading();
			default: return base.FindState(stateName);
		}
	}
	public TdTimerCheckpoint()
	{
		var Default__TdTimerCheckpoint_ArrowComponent = new ParticleSystemComponent
		{
			// Object Offset:0x01D750CB
			Template = LoadAsset<ParticleSystem>("TT_Checkpoints.Effects.PS_FX_Arrows_01")/*Ref ParticleSystem'TT_Checkpoints.Effects.PS_FX_Arrows_01'*/,
		}/* Reference: ParticleSystemComponent'Default__TdTimerCheckpoint.ArrowComponent' */;
		var Default__TdTimerCheckpoint_MyTimerMesh = new StaticMeshComponent
		{
			// Object Offset:0x02EA6F67
			StaticMesh = LoadAsset<StaticMesh>("TT_Checkpoints.S_Checkpoint_Time_01")/*Ref StaticMesh'TT_Checkpoints.S_Checkpoint_Time_01'*/,
			HiddenGame = true,
			CastShadow = false,
			bAcceptsLights = false,
			CollideActors = false,
			BlockRigidBody = false,
		}/* Reference: StaticMeshComponent'Default__TdTimerCheckpoint.MyTimerMesh' */;
		var Default__TdTimerCheckpoint_MyFinishlineMesh = new StaticMeshComponent
		{
			// Object Offset:0x02EA6E6B
			StaticMesh = LoadAsset<StaticMesh>("TT_Checkpoints.S_Checkpoint_Finish_01")/*Ref StaticMesh'TT_Checkpoints.S_Checkpoint_Finish_01'*/,
			HiddenGame = true,
			CastShadow = false,
			bAcceptsLights = false,
			CollideActors = false,
			BlockRigidBody = false,
		}/* Reference: StaticMeshComponent'Default__TdTimerCheckpoint.MyFinishlineMesh' */;
		var Default__TdTimerCheckpoint_MyMesh = new StaticMeshComponent
		{
			// Object Offset:0x02EA6F2F
			StaticMesh = LoadAsset<StaticMesh>("TT_Checkpoints.S_Checkpoint_01")/*Ref StaticMesh'TT_Checkpoints.S_Checkpoint_01'*/,
		}/* Reference: StaticMeshComponent'Default__TdTimerCheckpoint.MyMesh' */;
		var Default__TdTimerCheckpoint_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdTimerCheckpoint.CollisionCylinder' */;
		var Default__TdTimerCheckpoint_Sprite = new SpriteComponent
		{
			// Object Offset:0x02E52819
			Sprite = LoadAsset<Texture2D>("TdEditorResources.Timer")/*Ref Texture2D'TdEditorResources.Timer'*/,
		}/* Reference: SpriteComponent'Default__TdTimerCheckpoint.Sprite' */;
		var Default__TdTimerCheckpoint_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdTimerCheckpoint.Sprite2' */;
		var Default__TdTimerCheckpoint_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdTimerCheckpoint.Arrow' */;
		var Default__TdTimerCheckpoint_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__TdTimerCheckpoint.PathRenderer' */;
		// Object Offset:0x00676817
		InitialHeight = -1.0f;
		InitialRadius = -1.0f;
		EffectPSComponent = Default__TdTimerCheckpoint_ArrowComponent/*Ref ParticleSystemComponent'Default__TdTimerCheckpoint.ArrowComponent'*/;
		FadeTime = 0.50f;
		CheckpointTimeMesh = Default__TdTimerCheckpoint_MyTimerMesh/*Ref StaticMeshComponent'Default__TdTimerCheckpoint.MyTimerMesh'*/;
		CheckpointFinishlineMesh = Default__TdTimerCheckpoint_MyFinishlineMesh/*Ref StaticMeshComponent'Default__TdTimerCheckpoint.MyFinishlineMesh'*/;
		CheckpointMesh = Default__TdTimerCheckpoint_MyMesh/*Ref StaticMeshComponent'Default__TdTimerCheckpoint.MyMesh'*/;
		CylinderComponent = Default__TdTimerCheckpoint_CollisionCylinder/*Ref CylinderComponent'Default__TdTimerCheckpoint.CollisionCylinder'*/;
		GoodSprite = Default__TdTimerCheckpoint_Sprite/*Ref SpriteComponent'Default__TdTimerCheckpoint.Sprite'*/;
		BadSprite = Default__TdTimerCheckpoint_Sprite2/*Ref SpriteComponent'Default__TdTimerCheckpoint.Sprite2'*/;
		bStatic = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdTimerCheckpoint_Sprite/*Ref SpriteComponent'Default__TdTimerCheckpoint.Sprite'*/,
			Default__TdTimerCheckpoint_Sprite2/*Ref SpriteComponent'Default__TdTimerCheckpoint.Sprite2'*/,
			Default__TdTimerCheckpoint_Arrow/*Ref ArrowComponent'Default__TdTimerCheckpoint.Arrow'*/,
			Default__TdTimerCheckpoint_CollisionCylinder/*Ref CylinderComponent'Default__TdTimerCheckpoint.CollisionCylinder'*/,
			Default__TdTimerCheckpoint_PathRenderer/*Ref PathRenderingComponent'Default__TdTimerCheckpoint.PathRenderer'*/,
			Default__TdTimerCheckpoint_MyMesh/*Ref StaticMeshComponent'Default__TdTimerCheckpoint.MyMesh'*/,
			Default__TdTimerCheckpoint_MyTimerMesh/*Ref StaticMeshComponent'Default__TdTimerCheckpoint.MyTimerMesh'*/,
			Default__TdTimerCheckpoint_MyFinishlineMesh/*Ref StaticMeshComponent'Default__TdTimerCheckpoint.MyFinishlineMesh'*/,
			Default__TdTimerCheckpoint_ArrowComponent/*Ref ParticleSystemComponent'Default__TdTimerCheckpoint.ArrowComponent'*/,
		};
		CollisionComponent = Default__TdTimerCheckpoint_CollisionCylinder/*Ref CylinderComponent'Default__TdTimerCheckpoint.CollisionCylinder'*/;
	}
}
}