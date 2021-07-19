namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class OnlineGameSettings : Settings/*
		native*/{
	[databinding] public int NumPublicConnections;
	[databinding] public int NumPrivateConnections;
	[databinding] public int NumOpenPublicConnections;
	[databinding] public int NumOpenPrivateConnections;
	[Const] public StaticArray<byte, byte, byte, byte, byte, byte, byte, byte>/*[8]*/ ServerNonce;
	public int MaxSearchResults;
	[databinding] public bool bShouldAdvertise;
	[databinding] public bool bIsLanMatch;
	[databinding] public bool bUsesStats;
	[databinding] public bool bAllowJoinInProgress;
	[databinding] public bool bAllowInvites;
	[databinding] public bool bUsesPresence;
	[databinding] public bool bAllowJoinViaPresence;
	[databinding] public bool bUsesArbitration;
	[Const] public bool bWasFromInvite;
	[databinding] public bool bIsDedicated;
	[databinding] public bool bIsListPlay;
	[databinding] public bool bIsGoldOnlyListPlay;
	[databinding] public String OwningPlayerName;
	public OnlineSubsystem.UniqueNetId OwningPlayerId;
	[databinding] public int PingInMs;
	[databinding] public float AverageSkillRating;
	
	public OnlineGameSettings()
	{
		// Object Offset:0x00366C34
		bShouldAdvertise = true;
		bUsesStats = true;
		bAllowJoinInProgress = true;
		bAllowInvites = true;
		bUsesPresence = true;
		bAllowJoinViaPresence = true;
	}
}
}