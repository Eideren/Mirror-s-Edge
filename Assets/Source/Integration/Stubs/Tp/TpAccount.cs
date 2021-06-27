namespace MEdge.Tp{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TpAccount : TpSystemHandler/*
		abstract
		transient
		native*/{
	public enum TpAccountError 
	{
		kTpAe_Ok,
		kTpAe_AuthFail,
		kTpAe_AccountNotFound,
		kTpAe_AccountDisabled,
		kTpAe_AccountBanned,
		kTpAe_NoData,
		kTpAe_AccountPending,
		kTpAe_AccountTentative,
		kTpAe_AccountNeedsParentalVerification,
		kTpAe_NotEntitled,
		kTpAe_TooManyLoginAttempts,
		kTpAe_InvalidPassword,
		kTpAe_GameNotRegistered,
		kTpAe_TooManyPasswordRecoveries,
		kTpAe_TooManyNameRecoveries,
		kTpAe_EmailNotFound,
		kTpAe_PasswordNotFound,
		kTpAe_NameAlreadyInUse,
		kTpAe_EmailBlocked,
		kTpAe_PasswordNotChanged,
		kTpAe_TooManyPersonas,
		kTpAe_PersonaDisabledByCsr,
		kTpAe_UserTooYoung,
		kTpAe_RegCodeAlreadyInUse,
		kTpAe_InvalidRegCode,
		kTpAe_GameAlreadyRegistered,
		kTpAe_AccountNotAuthenticated,
		kTpAe_CreditCardsNotAvailable,
		kTpAe_XblBillingIsNotAvailable,
		kTpAe_Ps3npServiceFailure,
		kTpAe_InvalidEnvironment,
		kTpAe_SearchOwnerNamePrefixEmpty,
		kTpAe_SearchOwnerNamePrefixTooShort,
		kTpAe_SearchOwnerInvalidSearchType,
		kTpAe_SearchOwnerTooManyResultsFound,
		kTpAe_SearchOwnerInvalidNamespaceid,
		kTpAe_AccountDeactivated,
		kTpAe_AccountMerged,
		kTpAe_TosOutOfDate,
		kTpAe_Unknown,
		kTpAe_MAX
	};
	
}
}