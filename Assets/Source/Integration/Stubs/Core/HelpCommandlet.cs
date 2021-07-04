namespace MEdge.Core{
using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class HelpCommandlet : Commandlet/*
		transient
		native*/{
	// Export UHelpCommandlet::execMain(FFrame&, void* const)
	public override /*native event */int Main(String Params)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public HelpCommandlet()
	{
		// Object Offset:0x0002E2C8
		HelpDescription = "This commandlet displays help information on other commandlets";
		HelpUsage = "gamename.exe help <list | commandletname | webhelp commandletname>";
		HelpWebLink = "https://udn.epicgames.com/bin/view/Three/HelpCommandlet";
		HelpParamNames = new array</*localized */String>
		{
			"list",
			"commandlet name",
			"webhelp",
		};
		HelpParamDescriptions = new array</*localized */String>
		{
			"Lists all commandlets that are available",
			"Displays help information for the specified commandlet",
			"Launches a browser with the URL of the web page that documents the commandlet",
		};
	}
}
}