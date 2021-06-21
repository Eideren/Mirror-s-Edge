namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMPHUD : TdHUD/*
		transient
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public StaticArray<Texture2D, Texture2D>/*[2]*/ AmmoCountTexture;
	public StaticArray<Texture2D, Texture2D>/*[2]*/ ClipCountTexture;
	public StaticArray<Texture2D, Texture2D>/*[2]*/ PlayerIconTexture;
	public/*(HUDIcons)*/ Object.Vector2D AmmoCountOffsetPos;
	public/*(HUDIcons)*/ Object.Vector2D ClipCountPos;
	public/*(HUDIcons)*/ Object.Vector2D PlayerIconPos;
	public/*(HUDIcons)*/ Object.Vector2D RoundTimerPos;
	public/*(HUDIcons)*/ Object.Vector2D ScorePos;
	public/*(HUDIcons)*/ Object.Vector2D WarmupTimerPos;
	public /*const localized */String GameTimeLeft;
	public /*const localized */String WarmupTimeLeft;
	public /*const localized */String WaitingForPlayers;
	
	public override /*function */void LoadHUDContent(Core.ClassT<TdHUDContent> ContentClass)
	{
		// stub
	}
	
	public virtual /*function */void DisplayTeam()
	{
		// stub
	}
	
	public virtual /*function */void DrawPawnOverlays()
	{
		// stub
	}
	
	public virtual /*function */void DrawRoundTimer()
	{
		// stub
	}
	
	public virtual /*function */void DrawScore()
	{
		// stub
	}
	
	public virtual /*function */void DrawPawnNameOverlay(TdPawn ATdPawn, Object.Vector CameraRotation)
	{
		// stub
	}
	
	public virtual /*function */void DrawWarmupTimer(TdGameReplicationInfo MyGRI)
	{
		// stub
	}
	
	public virtual /*function */void DrawWaitingForMorePlayers()
	{
		// stub
	}
	
	public override /*function */void DrawWarmupHUD()
	{
		// stub
	}
	
	public override /*function */void DrawLivingHUD()
	{
		// stub
	}
	
	public virtual /*function */void DisplayWeaponAmmo(TdWeapon Weapon)
	{
		// stub
	}
	
	public override /*function */void ProjectOntoScreen(Object.Vector WorldLocation, Object.Vector WorldOffset, Object.Vector2D ClipXBounds, Object.Vector2D ClipYBounds, ref Object.Vector ScreenLocation)
	{
		// stub
	}
	
	public override /*function */void PlayerOwnerDied()
	{
		// stub
	}
	
	public TdMPHUD()
	{
		// Object Offset:0x005F8F2E
		AmmoCountOffsetPos = new Vector2D
		{
			X=1.0f,
			Y=-15.0f
		};
		ClipCountPos = new Vector2D
		{
			X=-1244.0f,
			Y=-705.0f
		};
		PlayerIconPos = new Vector2D
		{
			X=60.0f,
			Y=-696.0f
		};
		RoundTimerPos = new Vector2D
		{
			X=-1214.0f,
			Y=35.0f
		};
		WarmupTimerPos = new Vector2D
		{
			X=640.0f,
			Y=500.0f
		};
		bDisplayConsoleMessages = true;
		bDisplayGameMessages = true;
		AnnouncerClassName = "TdMpContent.TdMPAnnouncer";
		HUDContentClassName = "TdMpContent.TdHUDContentMP";
	}
}
}