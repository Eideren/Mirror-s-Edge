namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIAction_JoinOnlineGame : UIAction/*
		native
		hidecategories(Object)*/{
	public OnlineGameSearch.OnlineGameSearchResult PendingGameJoin;
	public WorldInfo CachedWorldInfo;
	public bool bIsDone;
	public bool bResult;
	
	public virtual /*event */void JoinOnlineGame(byte ControllerId, OnlineGameSearch.OnlineGameSearchResult GameToJoin, WorldInfo InWorldInfo)
	{
	
	}
	
	public virtual /*function */void OnJoinGameComplete(bool bWasSuccessful)
	{
	
	}
	
	public virtual /*function */String BuildJoinURL(String ResolvedConnectionURL)
	{
	
		return default;
	}
	
	public UIAction_JoinOnlineGame()
	{
		// Object Offset:0x0040ECD4
		bAutoTargetOwner = true;
		bLatentExecution = true;
		bAutoActivateOutputLinks = false;
		OutputLinks = new array<SequenceOp.SeqOpOutputLink>
		{
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Failure",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				ActivateDelay = 0.0f,
				DrawY = 0,
				bHidden = false,
			},
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Success",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				ActivateDelay = 0.0f,
				DrawY = 0,
				bHidden = false,
			},
		};
		ObjName = "Join Online Game";
		ObjCategory = "Online";
	}
}
}