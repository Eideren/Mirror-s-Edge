namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FailedConnect : LocalMessage/*
		abstract*/{
	public /*const localized */StaticArray<String, String, String, String>/*[4]*/ FailMessage;
	
	public /*function */static int GetFailSwitch(String FailString)
	{
		// stub
		return default;
	}
	
	public /*function */static String GetString(/*optional */int? _Switch = default, /*optional */bool? _bPRI1HUD = default, /*optional */PlayerReplicationInfo? _RelatedPRI_1 = default, /*optional */PlayerReplicationInfo? _RelatedPRI_2 = default, /*optional */Object? _OptionalObject = default)
	{
		// stub
		return default;
	}
	
	public FailedConnect()
	{
		// Object Offset:0x0031D02C
		FailMessage = new StaticArray<String, String, String, String>/*[4]*/()
		{ 
			[0] = "FAILED TO JOIN GAME.  NEED PASSWORD.",
			[1] = "FAILED TO JOIN GAME.  WRONG PASSWORD.",
			[2] = "FAILED TO JOIN GAME.  GAME HAS STARTED.",
			[3] = "FAILED TO JOIN GAME.",
	 	};
		bIsUnique = true;
		DrawColor = new Color
		{
			R=255,
			G=0,
			B=128,
			A=255
		};
		FontSize = 1;
	}
}
}