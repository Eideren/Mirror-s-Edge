namespace MEdge.IpDrv{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class OnlineSubsystemCommonImpl : OnlineSubsystem/*
		native
		config(Engine)*/{
	[native, Const, transient] public Object.Pointer VoiceEngine;
	[config] public int MaxLocalTalkers;
	[config] public int MaxRemoteTalkers;
	[config] public bool bIsUsingSpeechRecognition;
	public OnlineGameInterfaceImpl GameInterfaceImpl;
	
	public virtual /*event */String GetPlayerNicknameFromIndex(int UserIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*event */OnlineSubsystem.UniqueNetId GetPlayerUniqueNetIdFromIndex(int UserIndex)
	{
		// stub
		return default;
	}
	
	public OnlineSubsystemCommonImpl()
	{
		// Object Offset:0x000078A0
		MaxLocalTalkers = 1;
		MaxRemoteTalkers = 16;
	}
}
}