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
	
	}
	
	public virtual /*function */void ScaleHeight()
	{
	
	}
	
	public virtual /*function */void SetUpCheckpoint(bool bIsLastCheckpoint)
	{
	
	}
	
	public override /*function */int GetNumTracks()
	{
	
		return default;
	}
	
	public override /*function */bool ShouldGenerateTrackData(int TrackIndex)
	{
	
		return default;
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
	
	public override /*function */void SetLastCheckpoint(int TrackIndex)
	{
	
	}
	
	public virtual /*function */bool IsLastcheckpointInTrack(int Track)
	{
	
		return default;
	}
	
	public virtual /*function */bool HasIntermediateTimeInTrack(int Track)
	{
	
		return default;
	}
	
	public override /*function */void SetDirectionHint(Object.Rotator NextCheckpointHint)
	{
	
	}
	
	public override /*function */void Show(bool bShow, /*optional */int? _Track = default, /*optional */bool? _bNoFade = default)
	{
	
	}
	
	
	protected /*function */void TdTimerCheckpoint_Fading_Tick(float DeltaTime)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Fading()/*state Fading*/
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
		// Object Offset:0x00676817
		InitialHeight = -1.0f;
		InitialRadius = -1.0f;
		EffectPSComponent = new ParticleSystemComponent
		{
			// Object Offset:0x01D750CB
			Template = LoadAsset<ParticleSystem>("TT_Checkpoints.Effects.PS_FX_Arrows_01")/*Ref ParticleSystem'TT_Checkpoints.Effects.PS_FX_Arrows_01'*/,
		}/* Reference: ParticleSystemComponent'Default__TdTimerCheckpoint.ArrowComponent' */;
		FadeTime = 0.50f;
		CheckpointTimeMesh = new StaticMeshComponent
		{
			// Object Offset:0x02EA6F67
			StaticMesh = LoadAsset<StaticMesh>("TT_Checkpoints.S_Checkpoint_Time_01")/*Ref StaticMesh'TT_Checkpoints.S_Checkpoint_Time_01'*/,
			HiddenGame = true,
			CastShadow = false,
			bAcceptsLights = false,
			CollideActors = false,
			BlockRigidBody = false,
		}/* Reference: StaticMeshComponent'Default__TdTimerCheckpoint.MyTimerMesh' */;
		CheckpointFinishlineMesh = new StaticMeshComponent
		{
			// Object Offset:0x02EA6E6B
			StaticMesh = LoadAsset<StaticMesh>("TT_Checkpoints.S_Checkpoint_Finish_01")/*Ref StaticMesh'TT_Checkpoints.S_Checkpoint_Finish_01'*/,
			HiddenGame = true,
			CastShadow = false,
			bAcceptsLights = false,
			CollideActors = false,
			BlockRigidBody = false,
		}/* Reference: StaticMeshComponent'Default__TdTimerCheckpoint.MyFinishlineMesh' */;
		CheckpointMesh = new StaticMeshComponent
		{
			// Object Offset:0x02EA6F2F
			StaticMesh = LoadAsset<StaticMesh>("TT_Checkpoints.S_Checkpoint_01")/*Ref StaticMesh'TT_Checkpoints.S_Checkpoint_01'*/,
		}/* Reference: StaticMeshComponent'Default__TdTimerCheckpoint.MyMesh' */;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdTimerCheckpoint.CollisionCylinder")/*Ref CylinderComponent'Default__TdTimerCheckpoint.CollisionCylinder'*/;
		GoodSprite = new SpriteComponent
		{
			// Object Offset:0x02E52819
			Sprite = LoadAsset<Texture2D>("TdEditorResources.Timer")/*Ref Texture2D'TdEditorResources.Timer'*/,
		}/* Reference: SpriteComponent'Default__TdTimerCheckpoint.Sprite' */;
		BadSprite = LoadAsset<SpriteComponent>("Default__TdTimerCheckpoint.Sprite2")/*Ref SpriteComponent'Default__TdTimerCheckpoint.Sprite2'*/;
		bStatic = false;
		Components = new array</*export editinline */ActorComponent>
		{
			new SpriteComponent
			{
				// Object Offset:0x02E52819
				Sprite = LoadAsset<Texture2D>("TdEditorResources.Timer")/*Ref Texture2D'TdEditorResources.Timer'*/,
			}/* Reference: SpriteComponent'Default__TdTimerCheckpoint.Sprite' */,
			LoadAsset<SpriteComponent>("Default__TdTimerCheckpoint.Sprite2")/*Ref SpriteComponent'Default__TdTimerCheckpoint.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__TdTimerCheckpoint.Arrow")/*Ref ArrowComponent'Default__TdTimerCheckpoint.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__TdTimerCheckpoint.CollisionCylinder")/*Ref CylinderComponent'Default__TdTimerCheckpoint.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__TdTimerCheckpoint.PathRenderer")/*Ref PathRenderingComponent'Default__TdTimerCheckpoint.PathRenderer'*/,
			new StaticMeshComponent
			{
				// Object Offset:0x02EA6F2F
				StaticMesh = LoadAsset<StaticMesh>("TT_Checkpoints.S_Checkpoint_01")/*Ref StaticMesh'TT_Checkpoints.S_Checkpoint_01'*/,
			}/* Reference: StaticMeshComponent'Default__TdTimerCheckpoint.MyMesh' */,
			new StaticMeshComponent
			{
				// Object Offset:0x02EA6F67
				StaticMesh = LoadAsset<StaticMesh>("TT_Checkpoints.S_Checkpoint_Time_01")/*Ref StaticMesh'TT_Checkpoints.S_Checkpoint_Time_01'*/,
				HiddenGame = true,
				CastShadow = false,
				bAcceptsLights = false,
				CollideActors = false,
				BlockRigidBody = false,
			}/* Reference: StaticMeshComponent'Default__TdTimerCheckpoint.MyTimerMesh' */,
			new StaticMeshComponent
			{
				// Object Offset:0x02EA6E6B
				StaticMesh = LoadAsset<StaticMesh>("TT_Checkpoints.S_Checkpoint_Finish_01")/*Ref StaticMesh'TT_Checkpoints.S_Checkpoint_Finish_01'*/,
				HiddenGame = true,
				CastShadow = false,
				bAcceptsLights = false,
				CollideActors = false,
				BlockRigidBody = false,
			}/* Reference: StaticMeshComponent'Default__TdTimerCheckpoint.MyFinishlineMesh' */,
			new ParticleSystemComponent
			{
				// Object Offset:0x01D750CB
				Template = LoadAsset<ParticleSystem>("TT_Checkpoints.Effects.PS_FX_Arrows_01")/*Ref ParticleSystem'TT_Checkpoints.Effects.PS_FX_Arrows_01'*/,
			}/* Reference: ParticleSystemComponent'Default__TdTimerCheckpoint.ArrowComponent' */,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdTimerCheckpoint.CollisionCylinder")/*Ref CylinderComponent'Default__TdTimerCheckpoint.CollisionCylinder'*/;
	}
}
}