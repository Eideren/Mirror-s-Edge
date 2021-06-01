namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class LocalMessage : Object/*
		abstract*/{
	public bool bIsSpecial;
	public bool bIsUnique;
	public bool bIsPartiallyUnique;
	public bool bIsConsoleMessage;
	public bool bBeep;
	public bool bCountInstances;
	public bool bDrawOutline;
	public float Lifetime;
	public Object.Color DrawColor;
	public float PosY;
	public int FontSize;
	
	public /*simulated function */static SoundCue Get3DAnnouncementSound(/*optional */int? _Switch = default, /*optional */PlayerReplicationInfo? _RelatedPRI_1 = default, /*optional */PlayerReplicationInfo? _RelatedPRI_2 = default)
	{
	
		return default;
	}
	
	public /*function */static int GetMessageArea(/*optional */int? _Switch = default)
	{
	
		return default;
	}
	
	public /*function */static void ClientReceive(PlayerController P, /*optional */int? _Switch = default, /*optional */PlayerReplicationInfo? _RelatedPRI_1 = default, /*optional */PlayerReplicationInfo? _RelatedPRI_2 = default, /*optional */Object? _OptionalObject = default)
	{
	
	}
	
	public /*function */static String GetString(/*optional */int? _Switch = default, /*optional */bool? _bPRI1HUD = default, /*optional */PlayerReplicationInfo? _RelatedPRI_1 = default, /*optional */PlayerReplicationInfo? _RelatedPRI_2 = default, /*optional */Object? _OptionalObject = default)
	{
	
		return default;
	}
	
	public /*function */static Object.Color GetConsoleColor(PlayerReplicationInfo RelatedPRI_1)
	{
	
		return default;
	}
	
	public /*function */static Object.Color GetColor(/*optional */int? _Switch = default, /*optional */PlayerReplicationInfo? _RelatedPRI_1 = default, /*optional */PlayerReplicationInfo? _RelatedPRI_2 = default, /*optional */Object? _OptionalObject = default)
	{
	
		return default;
	}
	
	public /*function */static float GetPos(int Switch, HUD myHUD)
	{
	
		return default;
	}
	
	public /*function */static int GetFontSize(int Switch, PlayerReplicationInfo RelatedPRI1, PlayerReplicationInfo RelatedPRI2, PlayerReplicationInfo LocalPlayer)
	{
	
		return default;
	}
	
	public /*function */static float GetLifeTime(int Switch)
	{
	
		return default;
	}
	
	public /*function */static bool IsConsoleMessage(int Switch)
	{
	
		return default;
	}
	
	public /*function */static bool IsKeyObjectiveMessage(int Switch)
	{
	
		return default;
	}
	
	public /*function */static bool PartiallyDuplicates(int Switch1, int Switch2, Object OptionalObject1, Object OptionalObject2)
	{
	
		return default;
	}
	
	public LocalMessage()
	{
		// Object Offset:0x0031CC21
		bIsSpecial = true;
		bIsConsoleMessage = true;
		Lifetime = 3.0f;
		DrawColor = new Color
		{
			R=255,
			G=255,
			B=255,
			A=255
		};
		PosY = 0.830f;
	}
}
}