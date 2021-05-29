namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdGameUISceneClient : GameUISceneClient/* within UIInteraction*//*
		transient
		native
		config(UI)
		hidecategories(Object,UIRoot)*/{
	public new UIInteraction Outer => base.Outer as UIInteraction;
	
	public int LastViewportX;
	public /*const */name ResourceDataStoreName;
	public/*(Debug)*/ bool bShowRenderTimes;
	public float PreRenderTime;
	public float RenderTime;
	public float TickTime;
	public float AvgTime;
	public float AvgRenderTime;
	public float FrameCount;
	public float StringRenderTime;
	public /*private */string LoadingSceneText;
	public Object.Color SceneFadeColor;
	public /*transient */UIScene DiskAccessScene;
	public /*private transient */int BGSatMask;
	public /*delegate*/UIScene.OnSceneActivated StoredMsgBoxInit;
	public /*delegate*/TdGameUISceneClient.LoadingSceneOpened __LoadingSceneOpened__Delegate;
	public /*delegate*/TdGameUISceneClient.LoadingSceneFullyOpened __LoadingSceneFullyOpened__Delegate;
	
	public delegate void LoadingSceneOpened(UIScene OpenedScene, bool bInitialActivation);
	
	public delegate void LoadingSceneFullyOpened(UIScene OpenedScene);
	
	public override /*event */void ActivateBGSaturation(bool bActive, int Mask)
	{
	
	}
	
	public virtual /*function */bool IsTransitioning()
	{
	
		return default;
	}
	
	public virtual /*function */void OpenSceneEx(UIScene SceneToOpen, /*optional */LocalPlayer? _Player = default, /*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default, /*optional *//*delegate*/UIScene.OnSceneActivated? _SceneDelegate = default)
	{
	
	}
	
	public virtual /*function */UIScene InstantOpenScene(UIScene SceneToOpen, LocalPlayer Player, /*optional *//*delegate*/UIScene.OnSceneActivated? _SceneDelegate = default, /*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default)
	{
	
		return default;
	}
	
	public virtual /*function */void OpenMessageBox(/*delegate*/UIScene.OnSceneActivated MsgBoxInit, /*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default)
	{
	
	}
	
	public virtual /*function */void OpenTinyMessageBox(/*delegate*/UIScene.OnSceneActivated MsgBoxInit, /*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default)
	{
	
	}
	
	public virtual /*function */void OpenImageMessageBox(/*delegate*/UIScene.OnSceneActivated MsgBoxInit, /*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default)
	{
	
	}
	
	public virtual /*function */void OnMsgBoxInit(UIScene ActivatedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*function */void OpenLoadingScene(string Text, LocalPlayer Player, /*optional *//*delegate*/TdGameUISceneClient.LoadingSceneOpened? _SceneOpened = default, /*optional *//*delegate*/TdUIScene.OnSceneFullyOpened? _SceneFullyOpened = default)
	{
	
	}
	
	public virtual /*private final function */void LoadingScene_Init(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*function */void LoadingScene_FullyOpened(UIScene OpenedScene)
	{
	
	}
	
	public virtual /*function */UIDataStore FindDataStore(name DataStoreTag, /*optional */LocalPlayer? _InPlayerOwner = default)
	{
	
		return default;
	}
	
	public virtual /*function */UIDataStore_TdGameData GetGameDataStore()
	{
	
		return default;
	}
	
	public override /*function */void NotifyGameSessionEnded()
	{
	
	}
	
	public override /*function */void NotifyOnlineServiceStatusChanged(OnlineSubsystem.EOnlineServerConnectionStatus NewConnectionStatus)
	{
	
	}
	
	// Export UTdGameUISceneClient::execOpenDiskAccessScene(FFrame&, void* const)
	public virtual /*native final function */bool OpenDiskAccessScene(UIScene Scene, /*optional */ref UIScene OpenedScene/* = default*/)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdGameUISceneClient::execCloseDiskAccessScene(FFrame&, void* const)
	public virtual /*native final function */bool CloseDiskAccessScene()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdGameUISceneClient::execForceStopMovie(FFrame&, void* const)
	public virtual /*native function */void ForceStopMovie()
	{
		#warning NATIVE FUNCTION !
	}
	
	public TdGameUISceneClient()
	{
		// Object Offset:0x0054CA65
		ResourceDataStoreName = (name)"TdGameData";
		SceneFadeColor = new Color
		{
			R=255,
			G=255,
			B=255,
			A=200
		};
		AnimSequencePool = new array<UIAnimationSeq>
		{
			//AnimSequencePool[0]=
			new UIAnimationSeq
			{
				// Object Offset:0x03741CD2
				SeqName = (name)"FirstStarFadeIn",
				SeqDuration = 1.0f,
				Tracks = new array<UIAnimation.UIAnimTrack>
				{
					new UIAnimation.UIAnimTrack
					{
						TrackType = UIAnimation.EUIAnimType.EAT_Opacity,
						TrackWidgetTag = (name)"None",
						KeyFrames = new array<UIAnimation.UIAnimationKeyFrame>
						{
							new UIAnimation.UIAnimationKeyFrame
							{
								TimeMark = 0.0f,
								Data = new UIAnimation.UIAnimationRawData
								{
									DestAsFloat = 0.20f,
									DestAsColor = new LinearColor
									{
										R=0.0f,
										G=0.0f,
										B=0.0f,
										A=1.0f
									},
									DestAsRotator = new Rotator
									{
										Pitch=0,
										Yaw=0,
										Roll=0
									},
									DestAsVector = new Vector
									{
										X=0.0f,
										Y=0.0f,
										Z=0.0f
									},
									DestAsNotify = new UIAnimation.UIAnimationNotify
									{
										NotifyType = UIAnimation.EUIAnimNotifyType.EANT_WidgetFunction,
										NotifyName = (name)"None",
									},
								},
							},
							new UIAnimation.UIAnimationKeyFrame
							{
								TimeMark = 0.50f,
								Data = new UIAnimation.UIAnimationRawData
								{
									DestAsFloat = 0.20f,
									DestAsColor = new LinearColor
									{
										R=0.0f,
										G=0.0f,
										B=0.0f,
										A=1.0f
									},
									DestAsRotator = new Rotator
									{
										Pitch=0,
										Yaw=0,
										Roll=0
									},
									DestAsVector = new Vector
									{
										X=0.0f,
										Y=0.0f,
										Z=0.0f
									},
									DestAsNotify = new UIAnimation.UIAnimationNotify
									{
										NotifyType = UIAnimation.EUIAnimNotifyType.EANT_WidgetFunction,
										NotifyName = (name)"None",
									},
								},
							},
							new UIAnimation.UIAnimationKeyFrame
							{
								TimeMark = 1.0f,
								Data = new UIAnimation.UIAnimationRawData
								{
									DestAsFloat = 1.0f,
									DestAsColor = new LinearColor
									{
										R=0.0f,
										G=0.0f,
										B=0.0f,
										A=1.0f
									},
									DestAsRotator = new Rotator
									{
										Pitch=0,
										Yaw=0,
										Roll=0
									},
									DestAsVector = new Vector
									{
										X=0.0f,
										Y=0.0f,
										Z=0.0f
									},
									DestAsNotify = new UIAnimation.UIAnimationNotify
									{
										NotifyType = UIAnimation.EUIAnimNotifyType.EANT_WidgetFunction,
										NotifyName = (name)"None",
									},
								},
							},
						},
					},
				},
			}/* Reference: UIAnimationSeq'Default__TdGameUISceneClient.seqFirstStarFadeIn' */,
			//AnimSequencePool[1]=
			new UIAnimationSeq
			{
				// Object Offset:0x037427CA
				SeqName = (name)"StarFadeIn",
				SeqDuration = 0.50f,
				Tracks = new array<UIAnimation.UIAnimTrack>
				{
					new UIAnimation.UIAnimTrack
					{
						TrackType = UIAnimation.EUIAnimType.EAT_Opacity,
						TrackWidgetTag = (name)"None",
						KeyFrames = new array<UIAnimation.UIAnimationKeyFrame>
						{
							new UIAnimation.UIAnimationKeyFrame
							{
								TimeMark = 0.0f,
								Data = new UIAnimation.UIAnimationRawData
								{
									DestAsFloat = 0.20f,
									DestAsColor = new LinearColor
									{
										R=0.0f,
										G=0.0f,
										B=0.0f,
										A=1.0f
									},
									DestAsRotator = new Rotator
									{
										Pitch=0,
										Yaw=0,
										Roll=0
									},
									DestAsVector = new Vector
									{
										X=0.0f,
										Y=0.0f,
										Z=0.0f
									},
									DestAsNotify = new UIAnimation.UIAnimationNotify
									{
										NotifyType = UIAnimation.EUIAnimNotifyType.EANT_WidgetFunction,
										NotifyName = (name)"None",
									},
								},
							},
							new UIAnimation.UIAnimationKeyFrame
							{
								TimeMark = 1.0f,
								Data = new UIAnimation.UIAnimationRawData
								{
									DestAsFloat = 1.0f,
									DestAsColor = new LinearColor
									{
										R=0.0f,
										G=0.0f,
										B=0.0f,
										A=1.0f
									},
									DestAsRotator = new Rotator
									{
										Pitch=0,
										Yaw=0,
										Roll=0
									},
									DestAsVector = new Vector
									{
										X=0.0f,
										Y=0.0f,
										Z=0.0f
									},
									DestAsNotify = new UIAnimation.UIAnimationNotify
									{
										NotifyType = UIAnimation.EUIAnimNotifyType.EANT_WidgetFunction,
										NotifyName = (name)"None",
									},
								},
							},
						},
					},
				},
			}/* Reference: UIAnimationSeq'Default__TdGameUISceneClient.seqStarFadeIn' */,
			//AnimSequencePool[2]=
			new UIAnimationSeq
			{
				// Object Offset:0x03741802
				SeqName = (name)"ControllerFlash",
				SeqDuration = 0.250f,
				Tracks = new array<UIAnimation.UIAnimTrack>
				{
					new UIAnimation.UIAnimTrack
					{
						TrackType = UIAnimation.EUIAnimType.EAT_Color,
						TrackWidgetTag = (name)"None",
						KeyFrames = new array<UIAnimation.UIAnimationKeyFrame>
						{
							new UIAnimation.UIAnimationKeyFrame
							{
								TimeMark = 0.0f,
								Data = new UIAnimation.UIAnimationRawData
								{
									DestAsFloat = 0.0f,
									DestAsColor = new LinearColor
									{
										R=1.0f,
										G=1.0f,
										B=1.0f,
										A=1.0f
									},
									DestAsRotator = new Rotator
									{
										Pitch=0,
										Yaw=0,
										Roll=0
									},
									DestAsVector = new Vector
									{
										X=0.0f,
										Y=0.0f,
										Z=0.0f
									},
									DestAsNotify = new UIAnimation.UIAnimationNotify
									{
										NotifyType = UIAnimation.EUIAnimNotifyType.EANT_WidgetFunction,
										NotifyName = (name)"None",
									},
								},
							},
							new UIAnimation.UIAnimationKeyFrame
							{
								TimeMark = 0.250f,
								Data = new UIAnimation.UIAnimationRawData
								{
									DestAsFloat = 0.0f,
									DestAsColor = new LinearColor
									{
										R=2.0f,
										G=2.0f,
										B=2.0f,
										A=1.0f
									},
									DestAsRotator = new Rotator
									{
										Pitch=0,
										Yaw=0,
										Roll=0
									},
									DestAsVector = new Vector
									{
										X=0.0f,
										Y=0.0f,
										Z=0.0f
									},
									DestAsNotify = new UIAnimation.UIAnimationNotify
									{
										NotifyType = UIAnimation.EUIAnimNotifyType.EANT_WidgetFunction,
										NotifyName = (name)"None",
									},
								},
							},
							new UIAnimation.UIAnimationKeyFrame
							{
								TimeMark = 1.0f,
								Data = new UIAnimation.UIAnimationRawData
								{
									DestAsFloat = 0.0f,
									DestAsColor = new LinearColor
									{
										R=1.0f,
										G=1.0f,
										B=1.0f,
										A=1.0f
									},
									DestAsRotator = new Rotator
									{
										Pitch=0,
										Yaw=0,
										Roll=0
									},
									DestAsVector = new Vector
									{
										X=0.0f,
										Y=0.0f,
										Z=0.0f
									},
									DestAsNotify = new UIAnimation.UIAnimationNotify
									{
										NotifyType = UIAnimation.EUIAnimNotifyType.EANT_WidgetFunction,
										NotifyName = (name)"None",
									},
								},
							},
						},
					},
				},
			}/* Reference: UIAnimationSeq'Default__TdGameUISceneClient.seqControllerFlash' */,
			//AnimSequencePool[3]=
			new UIAnimationSeq
			{
				// Object Offset:0x037421A2
				SeqName = (name)"LogoFade",
				SeqDuration = 11.0f,
				Tracks = new array<UIAnimation.UIAnimTrack>
				{
					new UIAnimation.UIAnimTrack
					{
						TrackType = UIAnimation.EUIAnimType.EAT_Opacity,
						TrackWidgetTag = (name)"None",
						KeyFrames = new array<UIAnimation.UIAnimationKeyFrame>
						{
							new UIAnimation.UIAnimationKeyFrame
							{
								TimeMark = 0.0f,
								Data = new UIAnimation.UIAnimationRawData
								{
									DestAsFloat = 0.0f,
									DestAsColor = new LinearColor
									{
										R=0.0f,
										G=0.0f,
										B=0.0f,
										A=1.0f
									},
									DestAsRotator = new Rotator
									{
										Pitch=0,
										Yaw=0,
										Roll=0
									},
									DestAsVector = new Vector
									{
										X=0.0f,
										Y=0.0f,
										Z=0.0f
									},
									DestAsNotify = new UIAnimation.UIAnimationNotify
									{
										NotifyType = UIAnimation.EUIAnimNotifyType.EANT_WidgetFunction,
										NotifyName = (name)"None",
									},
								},
							},
							new UIAnimation.UIAnimationKeyFrame
							{
								TimeMark = 0.090f,
								Data = new UIAnimation.UIAnimationRawData
								{
									DestAsFloat = 1.0f,
									DestAsColor = new LinearColor
									{
										R=0.0f,
										G=0.0f,
										B=0.0f,
										A=1.0f
									},
									DestAsRotator = new Rotator
									{
										Pitch=0,
										Yaw=0,
										Roll=0
									},
									DestAsVector = new Vector
									{
										X=0.0f,
										Y=0.0f,
										Z=0.0f
									},
									DestAsNotify = new UIAnimation.UIAnimationNotify
									{
										NotifyType = UIAnimation.EUIAnimNotifyType.EANT_WidgetFunction,
										NotifyName = (name)"None",
									},
								},
							},
							new UIAnimation.UIAnimationKeyFrame
							{
								TimeMark = 0.820f,
								Data = new UIAnimation.UIAnimationRawData
								{
									DestAsFloat = 1.0f,
									DestAsColor = new LinearColor
									{
										R=0.0f,
										G=0.0f,
										B=0.0f,
										A=1.0f
									},
									DestAsRotator = new Rotator
									{
										Pitch=0,
										Yaw=0,
										Roll=0
									},
									DestAsVector = new Vector
									{
										X=0.0f,
										Y=0.0f,
										Z=0.0f
									},
									DestAsNotify = new UIAnimation.UIAnimationNotify
									{
										NotifyType = UIAnimation.EUIAnimNotifyType.EANT_WidgetFunction,
										NotifyName = (name)"None",
									},
								},
							},
							new UIAnimation.UIAnimationKeyFrame
							{
								TimeMark = 1.0f,
								Data = new UIAnimation.UIAnimationRawData
								{
									DestAsFloat = 0.0f,
									DestAsColor = new LinearColor
									{
										R=0.0f,
										G=0.0f,
										B=0.0f,
										A=1.0f
									},
									DestAsRotator = new Rotator
									{
										Pitch=0,
										Yaw=0,
										Roll=0
									},
									DestAsVector = new Vector
									{
										X=0.0f,
										Y=0.0f,
										Z=0.0f
									},
									DestAsNotify = new UIAnimation.UIAnimationNotify
									{
										NotifyType = UIAnimation.EUIAnimNotifyType.EANT_WidgetFunction,
										NotifyName = (name)"None",
									},
								},
							},
						},
					},
				},
			}/* Reference: UIAnimationSeq'Default__TdGameUISceneClient.seqLogoFade' */,
		};
	}
}
}