namespace MEdge.Core{
using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Commandlet : Object/*
		abstract
		transient
		native*/{
	public /*const localized */String HelpDescription;
	public /*const localized */String HelpUsage;
	public /*const localized */String HelpWebLink;
	public /*const localized */array</*localized */String> HelpParamNames;
	public /*const localized */array</*localized */String> HelpParamDescriptions;
	public bool IsServer;
	public bool IsClient;
	public bool IsEditor;
	public bool LogToConsole;
	public bool ShowErrorCount;
	
	// Export UCommandlet::execMain(FFrame&, void* const)
	public virtual /*native event */int Main(String Params)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public Commandlet()
	{
		// Object Offset:0x0002DD85
		IsServer = true;
		IsClient = true;
		IsEditor = true;
		ShowErrorCount = true;
	}
}
}