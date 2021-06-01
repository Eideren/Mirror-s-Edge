namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAIVoiceOverManager : Actor/*
		native
		notplaceable
		hidecategories(Navigation)*/{
	public enum EVoiceOver 
	{
		VO_Advance,
		VO_AdvanceAnswer,
		VO_AllDead,
		VO_Contact,
		VO_ContactAnswer,
		VO_CoveringFire,
		VO_Engage,
		VO_Follow,
		VO_GetInCover,
		VO_Hold,
		VO_HitMelee,
		VO_HitParry,
		VO_ImHit,
		VO_InPosition,
		VO_ManDown,
		VO_MoveBack,
		VO_MovingBack,
		VO_OutOfRange,
		VO_OutOfRangeAnswer,
		VO_Pistol,
		VO_PullingOut,
		VO_PursueSuspect,
		VO_Rifle,
		VO_ShesClose,
		VO_Shotgun,
		VO_Snatch,
		VO_Suppressed,
		VO_TakingFire,
		VO_ThrowingGrenade,
		VO_Chopper_Fire,
		VO_Chopper_Halt,
		VO_Chopper_Pursuit,
		VO_Count,
		VO_None,
		VO_MAX
	};
	
	public partial struct /*native */CueInfo
	{
		public array<SoundCue> Cues;
		public int NextSubVariant;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x004F8527
	//		Cues = default;
	//		NextSubVariant = 0;
	//	}
	};
	
	public partial struct /*native */AIVoiceOver
	{
		public String outText;
		public float spamTime;
		public float Prio;
		public float triggeredTime;
		public float currentPrio;
		public int minFriends;
		public float minDelayTime;
		public float maxDelayTime;
		public bool bCanRepeat;
		public int voices;
		public array<TdAIVoiceOverManager.CueInfo> SCue;
		public int NextVariation;
		public name AnimName;
		public bool bLoopVoiceAnim;
		public bool bRadio;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x004F885F
	//		outText = "";
	//		spamTime = 0.0f;
	//		Prio = 0.0f;
	//		triggeredTime = 0.0f;
	//		currentPrio = 0.0f;
	//		minFriends = 0;
	//		minDelayTime = 0.0f;
	//		maxDelayTime = 0.0f;
	//		bCanRepeat = false;
	//		voices = 0;
	//		SCue = default;
	//		NextVariation = 0;
	//		AnimName = (name)"None";
	//		bLoopVoiceAnim = false;
	//		bRadio = false;
	//	}
	};
	
	public partial struct /*native */AIVoiceItem
	{
		public TdAIVoiceOverManager.EVoiceOver VO;
		public Pawn Speaker;
		public TdBotPawn BotSpeaker;
		public float TimeTriggered;
		public int voice;
		public TdAIVoiceOverManager.EVoiceOver answer;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x004F8E8A
	//		VO = TdAIVoiceOverManager.EVoiceOver.VO_Advance;
	//		Speaker = default;
	//		BotSpeaker = default;
	//		TimeTriggered = 0.0f;
	//		voice = 0;
	//		answer = TdAIVoiceOverManager.EVoiceOver.VO_Advance;
	//	}
	};
	
	public partial struct /*native */SoundHistoryItem
	{
		public TdAIVoiceOverManager.EVoiceOver VO;
		public float timePlayed;
		public int variation;
		public int subvariant;
		public int voice;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x004F9052
	//		VO = TdAIVoiceOverManager.EVoiceOver.VO_Advance;
	//		timePlayed = 0.0f;
	//		variation = 0;
	//		subvariant = 0;
	//		voice = 0;
	//	}
	};
	
	public partial struct /*native */PostponedSoundCue
	{
		public SoundCue Cue;
		public float PostponedUntil;
		public Pawn Source;
		public TdBotPawn BotSource;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x004F91D6
	//		Cue = default;
	//		PostponedUntil = 0.0f;
	//		Source = default;
	//		BotSource = default;
	//	}
	};
	
	public TdAIManager AIManager;
	public float NextTriggerDelay;
	public TdAIVoiceOverManager.EVoiceOver LastVo;
	public Pawn LastSpeaker;
	public TdBotPawn LastSpeakerBot;
	public array<TdAIVoiceOverManager.AIVoiceItem> ChatterQueue;
	public array<TdAIVoiceOverManager.AIVoiceOver> VoiceOvers;
	public array<float> NoiseHistory;
	public float LastTriggerTime;
	public float QuietUntil;
	public float FriendsNearDistance;
	public/*()*/ float PrioRecoveryTime;
	public/*()*/ float WindowSize;
	public/*()*/ float NoiseFactor;
	public array<TdAIVoiceOverManager.SoundHistoryItem> DebugHistory;
	public int VoiceCounter;
	public array<SoundCue> RadioStart;
	public array<SoundCue> RadioStop;
	public array<TdAIVoiceOverManager.PostponedSoundCue> PostponedItems;
	public /*private transient */bool bMuted;
	
	public override /*event */void PostBeginPlay()
	{
	
	}
	
	public virtual /*protected function */void InitializeVoiceOvers()
	{
	
	}
	
	public virtual /*protected function */bool ReadVOData(Core.ClassT<TdAIVoiceOverData> Data)
	{
	
		return default;
	}
	
	public override Reset_del Reset { get => bfield_Reset ?? TdAIVoiceOverManager_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => TdAIVoiceOverManager_Reset;
	public /*function */void TdAIVoiceOverManager_Reset()
	{
	
	}
	
	public virtual /*function */int GetVoiceNumber()
	{
	
		return default;
	}
	
	public virtual /*protected function */int GetVariation(TdAIVoiceOverManager.EVoiceOver VO, int voice, ref int subvariant)
	{
	
		return default;
	}
	
	public virtual /*function */void TriggerVO(Pawn Bot, int VO, int voice, /*optional */int? _answer = default)
	{
	
	}
	
	public virtual /*private final function */TdAIVoiceOverManager.AIVoiceItem InitItem(TdAIVoiceOverManager.EVoiceOver VO, Pawn Bot, float TimeTriggered, int voice, /*optional */TdAIVoiceOverManager.EVoiceOver? _answer = default)
	{
	
		return default;
	}
	
	public virtual /*function */float PlayWithRadioNoise(SoundCue Cue, Pawn Source)
	{
	
		return default;
	}
	
	public virtual /*event */void Mute()
	{
	
	}
	
	public virtual /*event */void UnMute()
	{
	
	}
	
	public virtual /*protected event */void Speak(TdAIVoiceOverManager.EVoiceOver VO, Pawn Speaker, int voice, TdAIVoiceOverManager.EVoiceOver answer)
	{
	
	}
	
	public virtual /*private final function */Pawn FindFriendWithVoice(Pawn Bot, int voice)
	{
	
		return default;
	}
	
	// Export UTdAIVoiceOverManager::execNoiseLevel(FFrame&, void* const)
	public virtual /*private native final function */float NoiseLevel()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */void DrawDebugInfo(Canvas aCanvas)
	{
	
	}
	
	public virtual /*private final function */bool IsDelayed(int VO)
	{
	
		return default;
	}
	
	public virtual /*function */void RemoveSpeaker(Pawn Speaker)
	{
	
	}
	
	public virtual /*function */void SetLastSpeaker(Pawn Speaker)
	{
	
	}
	protected override void RestoreDefaultFunction()
	{
		Reset = null;
	
	}
	public TdAIVoiceOverManager()
	{
		// Object Offset:0x004FB2F3
		FriendsNearDistance = 3000.0f;
		PrioRecoveryTime = 20.0f;
		WindowSize = 30.0f;
		NoiseFactor = 20.0f;
	}
}
}