namespace MEdge.IpDrv{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class OnlineSubsystemCommonImpl : OnlineSubsystem/*
		native
		config(Engine)*/{
	public /*native const transient */Object.Pointer VoiceEngine;
	public /*config */int MaxLocalTalkers;
	public /*config */int MaxRemoteTalkers;
	public /*config */bool bIsUsingSpeechRecognition;
	public OnlineGameInterfaceImpl GameInterfaceImpl;
	
	public virtual /*event */string GetPlayerNicknameFromIndex(int UserIndex)
	{
	
		return default;
	}
	
	public virtual /*event */OnlineSubsystem.UniqueNetId GetPlayerUniqueNetIdFromIndex(int UserIndex)
	{
	
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