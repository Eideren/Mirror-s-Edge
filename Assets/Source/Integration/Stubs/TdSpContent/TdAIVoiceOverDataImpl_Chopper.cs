namespace MEdge.TdSpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAIVoiceOverDataImpl_Chopper : TdAIVoiceOverData{
	public TdAIVoiceOverDataImpl_Chopper()
	{
		// Object Offset:0x0000A232
		VOs = new array<TdAIVoiceOverManager.AIVoiceOver>
		{
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "",
				spamTime = 0.0f,
				Prio = 0.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.0f,
				bCanRepeat = false,
				voices = 0,
				SCue = default,
				NextVariation = 0,
				AnimName = (name)"None",
				bLoopVoiceAnim = false,
				bRadio = false,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "",
				spamTime = 0.0f,
				Prio = 0.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.0f,
				bCanRepeat = false,
				voices = 0,
				SCue = default,
				NextVariation = 0,
				AnimName = (name)"None",
				bLoopVoiceAnim = false,
				bRadio = false,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "",
				spamTime = 0.0f,
				Prio = 0.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.0f,
				bCanRepeat = false,
				voices = 0,
				SCue = default,
				NextVariation = 0,
				AnimName = (name)"None",
				bLoopVoiceAnim = false,
				bRadio = false,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "",
				spamTime = 0.0f,
				Prio = 0.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.0f,
				bCanRepeat = false,
				voices = 0,
				SCue = default,
				NextVariation = 0,
				AnimName = (name)"None",
				bLoopVoiceAnim = false,
				bRadio = false,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "",
				spamTime = 0.0f,
				Prio = 0.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.0f,
				bCanRepeat = false,
				voices = 0,
				SCue = default,
				NextVariation = 0,
				AnimName = (name)"None",
				bLoopVoiceAnim = false,
				bRadio = false,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "",
				spamTime = 0.0f,
				Prio = 0.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.0f,
				bCanRepeat = false,
				voices = 0,
				SCue = default,
				NextVariation = 0,
				AnimName = (name)"None",
				bLoopVoiceAnim = false,
				bRadio = false,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "",
				spamTime = 0.0f,
				Prio = 0.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.0f,
				bCanRepeat = false,
				voices = 0,
				SCue = default,
				NextVariation = 0,
				AnimName = (name)"None",
				bLoopVoiceAnim = false,
				bRadio = false,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "",
				spamTime = 0.0f,
				Prio = 0.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.0f,
				bCanRepeat = false,
				voices = 0,
				SCue = default,
				NextVariation = 0,
				AnimName = (name)"None",
				bLoopVoiceAnim = false,
				bRadio = false,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "",
				spamTime = 0.0f,
				Prio = 0.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.0f,
				bCanRepeat = false,
				voices = 0,
				SCue = default,
				NextVariation = 0,
				AnimName = (name)"None",
				bLoopVoiceAnim = false,
				bRadio = false,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "",
				spamTime = 0.0f,
				Prio = 0.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.0f,
				bCanRepeat = false,
				voices = 0,
				SCue = default,
				NextVariation = 0,
				AnimName = (name)"None",
				bLoopVoiceAnim = false,
				bRadio = false,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "",
				spamTime = 0.0f,
				Prio = 0.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.0f,
				bCanRepeat = false,
				voices = 0,
				SCue = default,
				NextVariation = 0,
				AnimName = (name)"None",
				bLoopVoiceAnim = false,
				bRadio = false,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "",
				spamTime = 0.0f,
				Prio = 0.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.0f,
				bCanRepeat = false,
				voices = 0,
				SCue = default,
				NextVariation = 0,
				AnimName = (name)"None",
				bLoopVoiceAnim = false,
				bRadio = false,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "",
				spamTime = 0.0f,
				Prio = 0.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.0f,
				bCanRepeat = false,
				voices = 0,
				SCue = default,
				NextVariation = 0,
				AnimName = (name)"None",
				bLoopVoiceAnim = false,
				bRadio = false,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "",
				spamTime = 0.0f,
				Prio = 0.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.0f,
				bCanRepeat = false,
				voices = 0,
				SCue = default,
				NextVariation = 0,
				AnimName = (name)"None",
				bLoopVoiceAnim = false,
				bRadio = false,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "",
				spamTime = 0.0f,
				Prio = 0.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.0f,
				bCanRepeat = false,
				voices = 0,
				SCue = default,
				NextVariation = 0,
				AnimName = (name)"None",
				bLoopVoiceAnim = false,
				bRadio = false,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "",
				spamTime = 0.0f,
				Prio = 0.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.0f,
				bCanRepeat = false,
				voices = 0,
				SCue = default,
				NextVariation = 0,
				AnimName = (name)"None",
				bLoopVoiceAnim = false,
				bRadio = false,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "",
				spamTime = 0.0f,
				Prio = 0.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.0f,
				bCanRepeat = false,
				voices = 0,
				SCue = default,
				NextVariation = 0,
				AnimName = (name)"None",
				bLoopVoiceAnim = false,
				bRadio = false,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "",
				spamTime = 0.0f,
				Prio = 0.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.0f,
				bCanRepeat = false,
				voices = 0,
				SCue = default,
				NextVariation = 0,
				AnimName = (name)"None",
				bLoopVoiceAnim = false,
				bRadio = false,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "",
				spamTime = 0.0f,
				Prio = 0.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.0f,
				bCanRepeat = false,
				voices = 0,
				SCue = default,
				NextVariation = 0,
				AnimName = (name)"None",
				bLoopVoiceAnim = false,
				bRadio = false,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "",
				spamTime = 0.0f,
				Prio = 0.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.0f,
				bCanRepeat = false,
				voices = 0,
				SCue = default,
				NextVariation = 0,
				AnimName = (name)"None",
				bLoopVoiceAnim = false,
				bRadio = false,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "",
				spamTime = 0.0f,
				Prio = 0.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.0f,
				bCanRepeat = false,
				voices = 0,
				SCue = default,
				NextVariation = 0,
				AnimName = (name)"None",
				bLoopVoiceAnim = false,
				bRadio = false,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "",
				spamTime = 0.0f,
				Prio = 0.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.0f,
				bCanRepeat = false,
				voices = 0,
				SCue = default,
				NextVariation = 0,
				AnimName = (name)"None",
				bLoopVoiceAnim = false,
				bRadio = false,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "",
				spamTime = 0.0f,
				Prio = 0.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.0f,
				bCanRepeat = false,
				voices = 0,
				SCue = default,
				NextVariation = 0,
				AnimName = (name)"None",
				bLoopVoiceAnim = false,
				bRadio = false,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "",
				spamTime = 0.0f,
				Prio = 0.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.0f,
				bCanRepeat = false,
				voices = 0,
				SCue = default,
				NextVariation = 0,
				AnimName = (name)"None",
				bLoopVoiceAnim = false,
				bRadio = false,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "",
				spamTime = 0.0f,
				Prio = 0.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.0f,
				bCanRepeat = false,
				voices = 0,
				SCue = default,
				NextVariation = 0,
				AnimName = (name)"None",
				bLoopVoiceAnim = false,
				bRadio = false,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "",
				spamTime = 0.0f,
				Prio = 0.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.0f,
				bCanRepeat = false,
				voices = 0,
				SCue = default,
				NextVariation = 0,
				AnimName = (name)"None",
				bLoopVoiceAnim = false,
				bRadio = false,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "",
				spamTime = 0.0f,
				Prio = 0.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.0f,
				bCanRepeat = false,
				voices = 0,
				SCue = default,
				NextVariation = 0,
				AnimName = (name)"None",
				bLoopVoiceAnim = false,
				bRadio = false,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "",
				spamTime = 0.0f,
				Prio = 0.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.0f,
				bCanRepeat = false,
				voices = 0,
				SCue = default,
				NextVariation = 0,
				AnimName = (name)"None",
				bLoopVoiceAnim = false,
				bRadio = false,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "",
				spamTime = 0.0f,
				Prio = 0.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.0f,
				bCanRepeat = false,
				voices = 0,
				SCue = default,
				NextVariation = 0,
				AnimName = (name)"None",
				bLoopVoiceAnim = false,
				bRadio = false,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "Chopper fire!",
				spamTime = 35.0f,
				Prio = 50.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 5.0f,
				bCanRepeat = false,
				voices = 1,
				SCue = new array<TdAIVoiceOverManager.CueInfo>
				{
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_Chopper_CUE.Single.A_VO_AI_Chopper_Fire_3_Cue")/*Ref SoundCue'A_VO_AI_Chopper_CUE.Single.A_VO_AI_Chopper_Fire_3_Cue'*/,
						},
						NextSubVariant = 0,
					},
				},
				NextVariation = 0,
				AnimName = (name)"voicedummy",
				bLoopVoiceAnim = true,
				bRadio = false,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "Chopper halt!",
				spamTime = 45.0f,
				Prio = 30.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 1.50f,
				bCanRepeat = false,
				voices = 1,
				SCue = new array<TdAIVoiceOverManager.CueInfo>
				{
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_Chopper_CUE.Single.A_VO_AI_Chopper_Halt_1_Cue")/*Ref SoundCue'A_VO_AI_Chopper_CUE.Single.A_VO_AI_Chopper_Halt_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_Chopper_CUE.Single.A_VO_AI_Chopper_Halt_3_Cue")/*Ref SoundCue'A_VO_AI_Chopper_CUE.Single.A_VO_AI_Chopper_Halt_3_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_Chopper_CUE.Single.A_VO_AI_Chopper_Halt_4_Cue")/*Ref SoundCue'A_VO_AI_Chopper_CUE.Single.A_VO_AI_Chopper_Halt_4_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_Chopper_CUE.Single.A_VO_AI_Chopper_Halt_5_Cue")/*Ref SoundCue'A_VO_AI_Chopper_CUE.Single.A_VO_AI_Chopper_Halt_5_Cue'*/,
						},
						NextSubVariant = 0,
					},
				},
				NextVariation = 0,
				AnimName = (name)"voicedummy",
				bLoopVoiceAnim = true,
				bRadio = false,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "Chopper Pursuit!",
				spamTime = 45.0f,
				Prio = 30.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 2.50f,
				bCanRepeat = false,
				voices = 1,
				SCue = new array<TdAIVoiceOverManager.CueInfo>
				{
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_Chopper_CUE.Single.A_VO_AI_Chopper_Pursuit_6_Cue")/*Ref SoundCue'A_VO_AI_Chopper_CUE.Single.A_VO_AI_Chopper_Pursuit_6_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_Chopper_CUE.Single.A_VO_AI_Chopper_Pursuit_7_Cue")/*Ref SoundCue'A_VO_AI_Chopper_CUE.Single.A_VO_AI_Chopper_Pursuit_7_Cue'*/,
						},
						NextSubVariant = 0,
					},
				},
				NextVariation = 0,
				AnimName = (name)"voicedummy",
				bLoopVoiceAnim = true,
				bRadio = false,
			},
		};
		FirstVO = 29;
		LastVo = 31;
	}
}
}