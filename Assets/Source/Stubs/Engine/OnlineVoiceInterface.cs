namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public interface OnlineVoiceInterface : Interface/*
		abstract*/{
	public /*delegate*/OnlineVoiceInterface.OnPlayerTalking __OnPlayerTalking__Delegate{ get; }
	public /*delegate*/OnlineVoiceInterface.OnRecognitionComplete __OnRecognitionComplete__Delegate{ get; }
	
	public /*function */bool RegisterLocalTalker(byte LocalUserNum);
	
	public /*function */bool UnregisterLocalTalker(byte LocalUserNum);
	
	public /*function */bool RegisterRemoteTalker(OnlineSubsystem.UniqueNetId PlayerId);
	
	public /*function */bool UnregisterRemoteTalker(OnlineSubsystem.UniqueNetId PlayerId);
	
	public /*function */bool IsLocalPlayerTalking(byte LocalUserNum);
	
	public /*function */bool IsRemotePlayerTalking(OnlineSubsystem.UniqueNetId PlayerId);
	
	public /*function */bool IsHeadsetPresent(byte LocalUserNum);
	
	public /*function */bool SetRemoteTalkerPriority(byte LocalUserNum, OnlineSubsystem.UniqueNetId PlayerId, int Priority);
	
	public /*function */bool MuteRemoteTalker(byte LocalUserNum, OnlineSubsystem.UniqueNetId PlayerId);
	
	public /*function */bool UnmuteRemoteTalker(byte LocalUserNum, OnlineSubsystem.UniqueNetId PlayerId);
	
	public delegate void OnPlayerTalking(OnlineSubsystem.UniqueNetId Player);
	
	public /*function */void AddPlayerTalkingDelegate(/*delegate*/OnlineVoiceInterface.OnPlayerTalking TalkerDelegate);
	
	public /*function */void ClearPlayerTalkingDelegate(/*delegate*/OnlineVoiceInterface.OnPlayerTalking TalkerDelegate);
	
	public /*function */void StartNetworkedVoice(byte LocalUserNum);
	
	public /*function */void StopNetworkedVoice(byte LocalUserNum);
	
	public /*function */bool StartSpeechRecognition(byte LocalUserNum);
	
	public /*function */bool StopSpeechRecognition(byte LocalUserNum);
	
	public /*function */bool GetRecognitionResults(byte LocalUserNum, ref array<OnlineSubsystem.SpeechRecognizedWord> Words);
	
	public delegate void OnRecognitionComplete();
	
	public /*function */void AddRecognitionCompleteDelegate(byte LocalUserNum, /*delegate*/OnlineVoiceInterface.OnRecognitionComplete RecognitionDelegate);
	
	public /*function */void ClearRecognitionCompleteDelegate(byte LocalUserNum, /*delegate*/OnlineVoiceInterface.OnRecognitionComplete RecognitionDelegate);
	
	public /*function */bool SelectVocabulary(byte LocalUserNum, int VocabularyId);
	
	public /*function */bool SetSpeechRecognitionObject(byte LocalUserNum, SpeechRecognition SpeechRecogObj);
	
	public /*function */bool MuteAll(byte LocalUserNum, bool bAllowFriends);
	
	public /*function */bool UnmuteAll(byte LocalUserNum);
	
}
}