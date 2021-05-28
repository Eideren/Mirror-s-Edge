namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class JuiceSubsystem : Subsystem/*
		transient
		native
		config(Juice)
		perobjectconfig*/{
	public /*config */string ServerIP;
	public /*config */string BackupServerIP;
	public /*config */float FPSLowerThreshold;
	public /*config */bool bRecordLevelStats;
	public /*config */string BuildName;
	public Object.Double LevelStartTime;
	
	// Export UJuiceSubsystem::execGetSubsystem(FFrame&, void* const)
	public /*native event */static JuiceSubsystem GetSubsystem()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UJuiceSubsystem::execJuiceGameEvent(FFrame&, void* const)
	public /*native event */static void JuiceGameEvent(string Category, string EventName, string Outcome, int IValue, float FValue, string StrResult, string MapName, Object.Vector MapLoc)
	{
		#warning NATIVE FUNCTION !
	}
	
	public /*event */static void LevelEvent(string Category, string EventName, string Outcome, int IValue, float FValue, string StrResult, Object.Vector MapLoc)
	{
	
	}
	
	// Export UJuiceSubsystem::execLevelEventD(FFrame&, void* const)
	public /*native event */static void LevelEventD(int Group, int Channel, int Level, string Category, string EventName, string Outcome, int IValue, float FValue, string StrResult, Object.Vector MapLoc)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UJuiceSubsystem::execLevelStatI(FFrame&, void* const)
	public /*native event */static void LevelStatI(string Category, string StatName, int StatValue)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UJuiceSubsystem::execTriggerEvent(FFrame&, void* const)
	public /*native event */static void TriggerEvent(string EventName, string EventParam)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UJuiceSubsystem::execGameEventD(FFrame&, void* const)
	public /*native event */static void GameEventD(int Group, int Channel, int Level, string Category, string EventName, string Outcome, int IValue, float FValue, string StrResult, string MapName, Object.Vector MapLoc)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UJuiceSubsystem::execGameStatF(FFrame&, void* const)
	public /*native event */static void GameStatF(string Category, string StatName, float StatValue)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UJuiceSubsystem::execGameStatI(FFrame&, void* const)
	public /*native event */static void GameStatI(string Category, string StatName, int StatValue)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UJuiceSubsystem::execAssetCoverage(FFrame&, void* const)
	public /*native event */static void AssetCoverage(string Category, string assetName, int numHits)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UJuiceSubsystem::execSetChannelLevel(FFrame&, void* const)
	public /*native event */static void SetChannelLevel(int Group, int Category, int Level)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UJuiceSubsystem::execGetMapName(FFrame&, void* const)
	public /*native event */static string GetMapName()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UJuiceSubsystem::execGetBuildInfo(FFrame&, void* const)
	public /*native event */static string GetBuildInfo()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UJuiceSubsystem::execLevelStart(FFrame&, void* const)
	public /*native event */static void LevelStart()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UJuiceSubsystem::execOpenFile(FFrame&, void* const)
	public /*native function */static int OpenFile(string Filename, /*optional */bool bOpenForWrite = default, /*optional */bool bText = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UJuiceSubsystem::execCloseFile(FFrame&, void* const)
	public /*native function */static void CloseFile(int FileHandle)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UJuiceSubsystem::execWriteToFile(FFrame&, void* const)
	public /*native function */static void WriteToFile(int FileHandle, string TextToWrite)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UJuiceSubsystem::execFlushFile(FFrame&, void* const)
	public /*native function */static void FlushFile(int FileHandle)
	{
		#warning NATIVE FUNCTION !
	}
	
	public JuiceSubsystem()
	{
		// Object Offset:0x00349448
		ServerIP = "10.21.160.195";
		BackupServerIP = "10.20.9.242";
		FPSLowerThreshold = 3.0f;
		bRecordLevelStats = true;
		BuildName = "PC_340430";
	}
}
}