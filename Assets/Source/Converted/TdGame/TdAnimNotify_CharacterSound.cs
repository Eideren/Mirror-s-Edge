namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAnimNotify_CharacterSound : AnimNotify/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	public enum CharacterSoundTriggerType 
	{
		ECSBreath_Soft_Short,
		ECSBreath_Soft_Long,
		ECSBreath_Medium_Short,
		ECSBreath_Medium_Long,
		ECSBreath_Hard_Short,
		ECSBreath_Hard_Long,
		ECSBreath_Jump,
		ECSBreath_Snatch,
		ECSOral_Impact_Soft,
		ECSOral_Impact_Medium,
		ECSOral_Impact_Hard,
		ECSOral_Strain_Soft,
		ECSOral_Strain_Medium,
		ECSOral_Strain_Hard,
		ECSOral_Jump,
		ECSOral_Snatch,
		ECSOral_Vault,
		ECSOral_Die,
		ECSClothing_Crouch,
		ECSClothing_Walk,
		ECSClothing_Run,
		ECSMisc_Vault,
		CharacterSoundTriggerType_MAX
	};
	
	public/*()*/ bool bFollowActor;
	public/*()*/ name BoneName;
	public/*()*/ TdAnimNotify_CharacterSound.CharacterSoundTriggerType TriggerType;
	
	public TdAnimNotify_CharacterSound()
	{
		// Object Offset:0x00508C2E
		bFollowActor = true;
		TriggerType = TdAnimNotify_CharacterSound.CharacterSoundTriggerType.ECSBreath_Soft_Long;
	}
}
}