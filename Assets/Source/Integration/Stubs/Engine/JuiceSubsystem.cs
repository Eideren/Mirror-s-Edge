namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class JuiceSubsystem : Subsystem/*
		transient
		native
		config(Juice)
		perobjectconfig*/{
	[config] public String ServerIP;
	[config] public String BackupServerIP;
	[config] public float FPSLowerThreshold;
	[config] public bool bRecordLevelStats;
	[config] public String BuildName;
	public Object.Double LevelStartTime;
	
	// Export UJuiceSubsystem::execGetSubsystem(FFrame&, void* const)
	public /*native event */static JuiceSubsystem GetSubsystem()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UJuiceSubsystem::execJuiceGameEvent(FFrame&, void* const)
	public /*native event */static void JuiceGameEvent(String Category, String EventName, String Outcome, int IValue, float FValue, String StrResult, String MapName, Object.Vector MapLoc)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public /*event */static void LevelEvent(String Category, String EventName, String Outcome, int IValue, float FValue, String StrResult, Object.Vector MapLoc)
	{
		// stub
	}
	
	// Export UJuiceSubsystem::execLevelEventD(FFrame&, void* const)
	public /*native event */static void LevelEventD(int Group, int Channel, int Level, String Category, String EventName, String Outcome, int IValue, float FValue, String StrResult, Object.Vector MapLoc)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UJuiceSubsystem::execLevelStatI(FFrame&, void* const)
	public /*native event */static void LevelStatI(String Category, String StatName, int StatValue)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UJuiceSubsystem::execTriggerEvent(FFrame&, void* const)
	public /*native event */static void TriggerEvent(String EventName, String EventParam)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UJuiceSubsystem::execGameEventD(FFrame&, void* const)
	public /*native event */static void GameEventD(int Group, int Channel, int Level, String Category, String EventName, String Outcome, int IValue, float FValue, String StrResult, String MapName, Object.Vector MapLoc)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UJuiceSubsystem::execGameStatF(FFrame&, void* const)
	public /*native event */static void GameStatF(String Category, String StatName, float StatValue)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UJuiceSubsystem::execGameStatI(FFrame&, void* const)
	public /*native event */static void GameStatI(String Category, String StatName, int StatValue)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UJuiceSubsystem::execAssetCoverage(FFrame&, void* const)
	public /*native event */static void AssetCoverage(String Category, String assetName, int numHits)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UJuiceSubsystem::execSetChannelLevel(FFrame&, void* const)
	public /*native event */static void SetChannelLevel(int Group, int Category, int Level)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UJuiceSubsystem::execGetMapName(FFrame&, void* const)
	public /*native event */static String GetMapName()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UJuiceSubsystem::execGetBuildInfo(FFrame&, void* const)
	public /*native event */static String GetBuildInfo()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UJuiceSubsystem::execLevelStart(FFrame&, void* const)
	public /*native event */static void LevelStart()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UJuiceSubsystem::execOpenFile(FFrame&, void* const)
	public /*native function */static int OpenFile(String Filename, /*optional */bool? _bOpenForWrite = default, /*optional */bool? _bText = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UJuiceSubsystem::execCloseFile(FFrame&, void* const)
	public /*native function */static void CloseFile(int FileHandle)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UJuiceSubsystem::execWriteToFile(FFrame&, void* const)
	public /*native function */static void WriteToFile(int FileHandle, String TextToWrite)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UJuiceSubsystem::execFlushFile(FFrame&, void* const)
	public /*native function */static void FlushFile(int FileHandle)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
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