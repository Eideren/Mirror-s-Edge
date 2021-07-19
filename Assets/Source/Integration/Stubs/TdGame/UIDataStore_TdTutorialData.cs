namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataStore_TdTutorialData : UIDataStore_TdGameResource, 
		UIListElementCellProvider/*
		transient
		native
		config(Game)
		hidecategories(Object,UIRoot)*/{
	[native, Const, noexport] public/*private*/ Object.Pointer VfTable_IUIListElementCellProvider;
	public int CurrentTutorialChallengeId;
	public LocalPlayer PlayerOwner;
	
	// Export UUIDataStore_TdTutorialData::execGetChallengeIdFromIndex(FFrame&, void* const)
	public virtual /*native function */int GetChallengeIdFromIndex(int Index)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_TdTutorialData::execGetTimeForChallengeGrade(FFrame&, void* const)
	public virtual /*native function */float GetTimeForChallengeGrade(int ChallengeId, int Grade)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public override /*event */void Registered(LocalPlayer Player)
	{
		// stub
	}
	
	public virtual /*private final event */TdProfileSettings GetProfileSettings()
	{
		// stub
		return default;
	}
	
	public UIDataStore_TdTutorialData()
	{
		// Object Offset:0x006EC426
		ElementProviderTypes = new array</*config */UIDataStore_GameResource.GameResourceDataProvider>
		{
			new UIDataStore_GameResource.GameResourceDataProvider
			{
				ProviderTag = (name)"TdTutorialChallenges",
				ProviderClassName = "TdGame.UIDataProvider_TdTutorialChallenge",
				ProviderClass = default,
			},
		};
		Tag = (name)"TdTutorialData";
	}
}
}