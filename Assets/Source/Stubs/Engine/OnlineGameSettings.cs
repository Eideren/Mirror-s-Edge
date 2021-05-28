namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class OnlineGameSettings : Settings/*
		native*/{
	public /*databinding */int NumPublicConnections;
	public /*databinding */int NumPrivateConnections;
	public /*databinding */int NumOpenPublicConnections;
	public /*databinding */int NumOpenPrivateConnections;
	public /*const */StaticArray<byte, byte, byte, byte, byte, byte, byte, byte>/*[8]*/ ServerNonce;
	public int MaxSearchResults;
	public /*databinding */bool bShouldAdvertise;
	public /*databinding */bool bIsLanMatch;
	public /*databinding */bool bUsesStats;
	public /*databinding */bool bAllowJoinInProgress;
	public /*databinding */bool bAllowInvites;
	public /*databinding */bool bUsesPresence;
	public /*databinding */bool bAllowJoinViaPresence;
	public /*databinding */bool bUsesArbitration;
	public /*const */bool bWasFromInvite;
	public /*databinding */bool bIsDedicated;
	public /*databinding */bool bIsListPlay;
	public /*databinding */bool bIsGoldOnlyListPlay;
	public /*databinding */string OwningPlayerName;
	public OnlineSubsystem.UniqueNetId OwningPlayerId;
	public /*databinding */int PingInMs;
	public /*databinding */float AverageSkillRating;
	
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