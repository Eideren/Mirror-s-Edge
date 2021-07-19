namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIAnimation : UIRoot/*
		abstract
		native
		hidecategories(Object,UIRoot)*/{
	public enum EUIAnimType 
	{
		EAT_None,
		EAT_Position,
		EAT_RelPosition,
		EAT_Rotation,
		EAT_RelRotation,
		EAT_Color,
		EAT_Opacity,
		EAT_Visibility,
		EAT_Scale,
		EAT_Left,
		EAT_Top,
		EAT_Right,
		EAT_Bottom,
		EAT_MAX
	};
	
	public enum EUIAnimNotifyType 
	{
		EANT_WidgetFunction,
		EANT_SceneFunction,
		EANT_KismetEvent,
		EANT_Sound,
		EANT_MAX
	};
	
	public partial struct /*native */UIAnimationNotify
	{
		public UIAnimation.EUIAnimNotifyType NotifyType;
		public name NotifyName;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002D34F3
	//		NotifyType = UIAnimation.EUIAnimNotifyType.EANT_WidgetFunction;
	//		NotifyName = (name)"None";
	//	}
	};
	
	public partial struct /*native */UIAnimationRawData
	{
		public float DestAsFloat;
		public Object.LinearColor DestAsColor;
		public Object.Rotator DestAsRotator;
		public Object.Vector DestAsVector;
		public UIAnimation.UIAnimationNotify DestAsNotify;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002D3657
	//		DestAsFloat = 0.0f;
	//		DestAsColor = new LinearColor
	//		{
	//			R=0.0f,
	//			G=0.0f,
	//			B=0.0f,
	//			A=1.0f
	//		};
	//		DestAsRotator = new Rotator
	//		{
	//			Pitch=0,
	//			Yaw=0,
	//			Roll=0
	//		};
	//		DestAsVector = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		DestAsNotify = new UIAnimation.UIAnimationNotify
	//		{
	//			NotifyType = UIAnimation.EUIAnimNotifyType.EANT_WidgetFunction,
	//			NotifyName = (name)"None",
	//		};
	//	}
	};
	
	public partial struct /*native */UIAnimationKeyFrame
	{
		public float TimeMark;
		public UIAnimation.UIAnimationRawData Data;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002D37F7
	//		TimeMark = 0.0f;
	//		Data = new UIAnimation.UIAnimationRawData
	//		{
	//			DestAsFloat = 0.0f,
	//			DestAsColor = new LinearColor
	//			{
	//				R=0.0f,
	//				G=0.0f,
	//				B=0.0f,
	//				A=1.0f
	//			},
	//			DestAsRotator = new Rotator
	//			{
	//				Pitch=0,
	//				Yaw=0,
	//				Roll=0
	//			},
	//			DestAsVector = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			DestAsNotify = new UIAnimation.UIAnimationNotify
	//			{
	//				NotifyType = UIAnimation.EUIAnimNotifyType.EANT_WidgetFunction,
	//				NotifyName = (name)"None",
	//			},
	//		};
	//	}
	};
	
	public partial struct /*native */UIAnimTrack
	{
		public UIAnimation.EUIAnimType TrackType;
		public name TrackWidgetTag;
		public array<UIAnimation.UIAnimationKeyFrame> KeyFrames;
		[transient] public UIObject TargetWidget;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002D3A6B
	//		TrackType = UIAnimation.EUIAnimType.EAT_None;
	//		TrackWidgetTag = (name)"None";
	//		KeyFrames = default;
	//		TargetWidget = default;
	//	}
	};
	
	public partial struct /*native */UIAnimSeqRef
	{
		public UIAnimationSeq SeqRef;
		public float PlaybackRate;
		public float AnimTime;
		public bool bIsPlaying;
		public bool bIsLooping;
		public int LoopCount;
		public Object.Vector InitialRenderOffset;
		public Object.Rotator InitialRotation;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002D3C87
	//		SeqRef = default;
	//		PlaybackRate = 0.0f;
	//		AnimTime = 0.0f;
	//		bIsPlaying = false;
	//		bIsLooping = false;
	//		LoopCount = 0;
	//		InitialRenderOffset = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		InitialRotation = new Rotator
	//		{
	//			Pitch=0,
	//			Yaw=0,
	//			Roll=0
	//		};
	//	}
	};
	
}
}