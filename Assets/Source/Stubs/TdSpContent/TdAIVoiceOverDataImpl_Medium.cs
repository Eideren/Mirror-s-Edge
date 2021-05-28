namespace MEdge.TdSpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAIVoiceOverDataImpl_Medium : TdAIVoiceOverData{
	public TdAIVoiceOverDataImpl_Medium()
	{
		// Object Offset:0x00012652
		VOs = new array<TdAIVoiceOverManager.AIVoiceOver>
		{
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "Advance!",
				spamTime = 15.0f,
				Prio = 40.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 1,
				minDelayTime = 0.0f,
				maxDelayTime = 1.0f,
				bCanRepeat = true,
				voices = 2,
				SCue = new array<TdAIVoiceOverManager.CueInfo>
				{
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_Decision_5_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_Decision_5_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_Decision_6_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_Decision_6_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_Decision_7_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_Decision_7_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_Decision_8_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_Decision_8_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue'*/,
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
				outText = "Advance answer!",
				spamTime = 15.0f,
				Prio = 60.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 1,
				minDelayTime = 0.0f,
				maxDelayTime = 5.0f,
				bCanRepeat = true,
				voices = 2,
				SCue = new array<TdAIVoiceOverManager.CueInfo>
				{
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue'*/,
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
				outText = "Alldead!",
				spamTime = 0.0f,
				Prio = 70.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 7.0f,
				maxDelayTime = 10.0f,
				bCanRepeat = true,
				voices = 2,
				SCue = new array<TdAIVoiceOverManager.CueInfo>
				{
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_CombatEnding_15_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_CombatEnding_15_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_CombatEnding_16_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_CombatEnding_16_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_CombatEnding_17_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_CombatEnding_17_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_CombatEnding_18_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_CombatEnding_18_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_CombatEnding_19_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_CombatEnding_19_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_CombatEnding_20_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_CombatEnding_20_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
				},
				NextVariation = 0,
				AnimName = (name)"voicedummy",
				bLoopVoiceAnim = true,
				bRadio = true,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "Contact!",
				spamTime = 45.0f,
				Prio = 70.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 1.0f,
				bCanRepeat = false,
				voices = 2,
				SCue = new array<TdAIVoiceOverManager.CueInfo>
				{
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_CombatStart_1_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_CombatStart_1_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_CombatStart_2_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_CombatStart_2_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_CombatStart_3_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_CombatStart_3_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_CombatStart_4_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_CombatStart_4_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue'*/,
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
				outText = "Contact answer",
				spamTime = 60.0f,
				Prio = 70.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 1.0f,
				maxDelayTime = 3.0f,
				bCanRepeat = false,
				voices = 2,
				SCue = new array<TdAIVoiceOverManager.CueInfo>
				{
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_CombatStart_17_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_CombatStart_17_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_CombatStart_18_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_CombatStart_18_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_CombatStart_19_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_CombatStart_19_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_CombatStart_20_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_CombatStart_20_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
				},
				NextVariation = 0,
				AnimName = (name)"voicedummy",
				bLoopVoiceAnim = true,
				bRadio = true,
			},
			new TdAIVoiceOverManager.AIVoiceOver
			{
				outText = "Covering Fire!",
				spamTime = 10.0f,
				Prio = 70.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 1,
				minDelayTime = 0.0f,
				maxDelayTime = 0.50f,
				bCanRepeat = true,
				voices = 2,
				SCue = new array<TdAIVoiceOverManager.CueInfo>
				{
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue'*/,
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
				outText = "Engage!",
				spamTime = 5.0f,
				Prio = 50.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 1,
				minDelayTime = 0.0f,
				maxDelayTime = 0.50f,
				bCanRepeat = true,
				voices = 2,
				SCue = new array<TdAIVoiceOverManager.CueInfo>
				{
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_Decision_3_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_Decision_3_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_Decision_4_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_Decision_4_1_Cue'*/,
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
				outText = "Follow!",
				spamTime = 25.0f,
				Prio = 40.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.50f,
				bCanRepeat = true,
				voices = 2,
				SCue = new array<TdAIVoiceOverManager.CueInfo>
				{
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue'*/,
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
				outText = "Get in cover!",
				spamTime = 5.0f,
				Prio = 40.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 1,
				minDelayTime = 1.0f,
				maxDelayTime = 2.50f,
				bCanRepeat = true,
				voices = 2,
				SCue = new array<TdAIVoiceOverManager.CueInfo>
				{
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue'*/,
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
				outText = "Hold!",
				spamTime = 15.0f,
				Prio = 30.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 1,
				minDelayTime = 0.0f,
				maxDelayTime = 1.0f,
				bCanRepeat = true,
				voices = 2,
				SCue = new array<TdAIVoiceOverManager.CueInfo>
				{
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_CombatStart_15_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_CombatStart_15_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_CombatStart_16_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_CombatStart_16_1_Cue'*/,
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
				outText = "Ouch!",
				spamTime = 0.0f,
				Prio = 100.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.10f,
				bCanRepeat = true,
				voices = 2,
				SCue = new array<TdAIVoiceOverManager.CueInfo>
				{
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_Success_11_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_Success_11_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_Success_12_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_Success_12_1_Cue'*/,
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
				outText = "bonk",
				spamTime = 0.0f,
				Prio = 100.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.10f,
				bCanRepeat = true,
				voices = 2,
				SCue = new array<TdAIVoiceOverManager.CueInfo>
				{
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_Success_13_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_Success_13_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_Success_14_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_Success_14_1_Cue'*/,
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
				outText = "In position!",
				spamTime = 8.0f,
				Prio = 30.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 1.0f,
				bCanRepeat = true,
				voices = 2,
				SCue = new array<TdAIVoiceOverManager.CueInfo>
				{
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue'*/,
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
				outText = "Man down!",
				spamTime = 8.0f,
				Prio = 90.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 1,
				minDelayTime = 1.0f,
				maxDelayTime = 2.0f,
				bCanRepeat = true,
				voices = 2,
				SCue = new array<TdAIVoiceOverManager.CueInfo>
				{
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_Success_3_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_Success_3_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_Success_4_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_Success_4_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue'*/,
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
				outText = "Move back!",
				spamTime = 8.0f,
				Prio = 70.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 1,
				minDelayTime = 0.0f,
				maxDelayTime = 0.50f,
				bCanRepeat = true,
				voices = 2,
				SCue = new array<TdAIVoiceOverManager.CueInfo>
				{
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue'*/,
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
				outText = "Move back!",
				spamTime = 8.0f,
				Prio = 70.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 1,
				minDelayTime = 0.0f,
				maxDelayTime = 0.50f,
				bCanRepeat = true,
				voices = 2,
				SCue = new array<TdAIVoiceOverManager.CueInfo>
				{
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue'*/,
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
				outText = "Pistol!",
				spamTime = 25.0f,
				Prio = 70.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 1,
				minDelayTime = 1.0f,
				maxDelayTime = 5.0f,
				bCanRepeat = true,
				voices = 2,
				SCue = new array<TdAIVoiceOverManager.CueInfo>
				{
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue'*/,
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
				outText = "Pulling Out!",
				spamTime = 25.0f,
				Prio = 40.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 1,
				minDelayTime = 0.0f,
				maxDelayTime = 2.0f,
				bCanRepeat = true,
				voices = 2,
				SCue = new array<TdAIVoiceOverManager.CueInfo>
				{
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_CombatEnding_7_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_CombatEnding_7_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_CombatEnding_8_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_CombatEnding_8_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue'*/,
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
				outText = "Rifle!",
				spamTime = 25.0f,
				Prio = 70.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 1,
				minDelayTime = 1.0f,
				maxDelayTime = 5.0f,
				bCanRepeat = true,
				voices = 2,
				SCue = new array<TdAIVoiceOverManager.CueInfo>
				{
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue'*/,
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
				outText = "Shotgun!",
				spamTime = 25.0f,
				Prio = 70.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 1,
				minDelayTime = 1.0f,
				maxDelayTime = 5.0f,
				bCanRepeat = true,
				voices = 2,
				SCue = new array<TdAIVoiceOverManager.CueInfo>
				{
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue'*/,
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
				outText = "Snatch!",
				spamTime = 25.0f,
				Prio = 90.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 0,
				minDelayTime = 0.0f,
				maxDelayTime = 0.50f,
				bCanRepeat = true,
				voices = 2,
				SCue = new array<TdAIVoiceOverManager.CueInfo>
				{
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_Compliment_15_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_Compliment_15_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_Compliment_16_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_Compliment_16_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_Compliment_17_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_Compliment_17_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_Compliment_18_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_Compliment_18_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_Compliment_19_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_Compliment_19_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_Compliment_20_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_Compliment_20_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_Compliment_21_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_Compliment_21_1_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_CUE.Single.A_VO_AI_Compliment_22_1_Cue")/*Ref SoundCue'A_VO_AI_CUE.Single.A_VO_AI_Compliment_22_1_Cue'*/,
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
				outText = "Suppressed!",
				spamTime = 5.0f,
				Prio = 40.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 1,
				minDelayTime = 0.0f,
				maxDelayTime = 1.0f,
				bCanRepeat = true,
				voices = 2,
				SCue = new array<TdAIVoiceOverManager.CueInfo>
				{
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_L2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Long_2_Cue'*/,
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
				outText = "Taking fire!",
				spamTime = 5.0f,
				Prio = 50.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 1,
				minDelayTime = 0.0f,
				maxDelayTime = 1.0f,
				bCanRepeat = true,
				voices = 2,
				SCue = new array<TdAIVoiceOverManager.CueInfo>
				{
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue'*/,
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
				outText = "Throwing Grenade!",
				spamTime = 15.0f,
				Prio = 50.0f,
				triggeredTime = 0.0f,
				currentPrio = 0.0f,
				minFriends = 1,
				minDelayTime = 0.0f,
				maxDelayTime = 0.20f,
				bCanRepeat = true,
				voices = 2,
				SCue = new array<TdAIVoiceOverManager.CueInfo>
				{
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue'*/,
						},
						NextSubVariant = 0,
					},
					new TdAIVoiceOverManager.CueInfo
					{
						Cues = new array<SoundCue>
						{
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S1_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_1_Cue'*/,
							LoadAsset<SoundCue>("A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue")/*Ref SoundCue'A_VO_AI_RadioChatter_S2_Cue.Single.A_VO_AI_RadioChatter_Nonsense_Short_2_Cue'*/,
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
		RadioStart = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Start_1_Cue")/*Ref SoundCue'A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Start_1_Cue'*/,
			LoadAsset<SoundCue>("A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Start_2_Cue")/*Ref SoundCue'A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Start_2_Cue'*/,
			LoadAsset<SoundCue>("A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Start_3_Cue")/*Ref SoundCue'A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Start_3_Cue'*/,
			LoadAsset<SoundCue>("A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Start_4_Cue")/*Ref SoundCue'A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Start_4_Cue'*/,
			LoadAsset<SoundCue>("A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Start_5_Cue")/*Ref SoundCue'A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Start_5_Cue'*/,
			LoadAsset<SoundCue>("A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Start_6_Cue")/*Ref SoundCue'A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Start_6_Cue'*/,
			LoadAsset<SoundCue>("A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Start_7_Cue")/*Ref SoundCue'A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Start_7_Cue'*/,
			LoadAsset<SoundCue>("A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Start_8_Cue")/*Ref SoundCue'A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Start_8_Cue'*/,
			LoadAsset<SoundCue>("A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Start_9_Cue")/*Ref SoundCue'A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Start_9_Cue'*/,
			LoadAsset<SoundCue>("A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Start_10_Cue")/*Ref SoundCue'A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Start_10_Cue'*/,
		};
		RadioStop = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Stop_1_Cue")/*Ref SoundCue'A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Stop_1_Cue'*/,
			LoadAsset<SoundCue>("A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Stop_2_Cue")/*Ref SoundCue'A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Stop_2_Cue'*/,
			LoadAsset<SoundCue>("A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Stop_3_Cue")/*Ref SoundCue'A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Stop_3_Cue'*/,
			LoadAsset<SoundCue>("A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Stop_4_Cue")/*Ref SoundCue'A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Stop_4_Cue'*/,
			LoadAsset<SoundCue>("A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Stop_5_Cue")/*Ref SoundCue'A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Stop_5_Cue'*/,
			LoadAsset<SoundCue>("A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Stop_6_Cue")/*Ref SoundCue'A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Stop_6_Cue'*/,
			LoadAsset<SoundCue>("A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Stop_7_Cue")/*Ref SoundCue'A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Stop_7_Cue'*/,
			LoadAsset<SoundCue>("A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Stop_8_Cue")/*Ref SoundCue'A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Stop_8_Cue'*/,
			LoadAsset<SoundCue>("A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Stop_9_Cue")/*Ref SoundCue'A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Stop_9_Cue'*/,
			LoadAsset<SoundCue>("A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Stop_10_Cue")/*Ref SoundCue'A_VO_AI_Radio_CUE.Single.A_VO_AI_Radio_Stop_10_Cue'*/,
		};
		LastVo = 28;
	}
}
}