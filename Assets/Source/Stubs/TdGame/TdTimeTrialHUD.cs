namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdTimeTrialHUD : TdSPHUD/*
		transient
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public/*(HUDIcons)*/ Object.Vector2D RaceTimerPos;
	public/*(HUDIcons)*/ Object.Vector2D SpeedPos;
	public/*(HUDIcons)*/ Object.Vector2D RaceProgressPos;
	public/*(HUDIcons)*/ Object.Vector2D StarRatingPos;
	public/*(HUDIcons)*/ float StarFadeTime;
	public/*(HUDIcons)*/ float StarCompletedAlpha;
	public/*(HUDIcons)*/ float StarFailedAlpha;
	public/*(HUDIcons)*/ float RaceProgressBarHeight;
	public/*(HUDIcons)*/ float ProgressBarAlpha;
	public/*(HUDIcons)*/ float ProgressBarCompletedAlpha;
	public/*(HUDIcons)*/ float ProgressBarWidth;
	public/*(HUDIcons)*/ float ProgressBarFadeTime;
	public /*transient */StaticArray<Texture2D, Texture2D, Texture2D>/*[3]*/ BottomBar;
	public /*transient */StaticArray<Texture2D, Texture2D, Texture2D>/*[3]*/ MiddleBar;
	public /*transient */StaticArray<Texture2D, Texture2D, Texture2D>/*[3]*/ TopBar;
	public /*transient */Texture2D Star;
	public /*transient */array<float> HUDProgressFade;
	public /*transient */StaticArray<float, float, float>/*[3]*/ StarRatingAlpha;
	public /*transient */String SpeedUnitString;
	public /*transient */int MeasurementUnits;
	public ParticleSystem CheckPointEffectParticles;
	public float CheckPointDistanceInCameraDirection;
	
	public override /*function */void LoadHUDContent(Core.ClassT<TdHUDContent> ContentClass)
	{
	
	}
	
	public override /*event */void PostBeginPlay()
	{
	
	}
	
	public virtual /*function */void CacheMeasurementUnitInfo()
	{
	
	}
	
	public override /*function */void DrawLivingHUD()
	{
	
	}
	
	public virtual /*function */void TriggerRestartRaceblink()
	{
	
	}
	
	public virtual /*private final function */void TriggerRestartRaceblinkCallback()
	{
	
	}
	
	public override /*function */void PauseGame()
	{
	
	}
	
	public virtual /*function */void DrawSpeed(ref float PosY)
	{
	
	}
	
	public virtual /*function */void DrawTrackProgress(TdSPTimeTrialGame Game)
	{
	
	}
	
	public virtual /*function */void DrawStarRating(TdSPTimeTrialGame Game)
	{
	
	}
	
	public virtual /*function */void DrawRaceTimer(TdSPTimeTrialGame Game)
	{
	
	}
	
	public override /*function */void OpenInGameMenu()
	{
	
	}
	
	public override /*function */void PlayerOwnerRestart()
	{
	
	}
	
	public override /*function */void UnPauseGame(UIScene DeactivatedScene)
	{
	
	}
	
	public virtual /*function */void TriggerCheckPointEffect()
	{
	
	}
	
	public override /*function */void ActivatePopUp(TdSPHUD.EPopUpType Type, float Duration, String Message)
	{
	
	}
	
	public TdTimeTrialHUD()
	{
		// Object Offset:0x00678AFB
		RaceTimerPos = new Vector2D
		{
			X=1056.0f,
			Y=55.0f
		};
		SpeedPos = new Vector2D
		{
			X=1060.0f,
			Y=625.0f
		};
		RaceProgressPos = new Vector2D
		{
			X=110.0f,
			Y=660.0f
		};
		StarRatingPos = new Vector2D
		{
			X=1056.0f,
			Y=61.0f
		};
		StarFadeTime = 0.750f;
		StarCompletedAlpha = 255.0f;
		StarFailedAlpha = 60.0f;
		RaceProgressBarHeight = 600.0f;
		ProgressBarAlpha = 60.0f;
		ProgressBarCompletedAlpha = 140.0f;
		ProgressBarWidth = 20.0f;
		ProgressBarFadeTime = 0.180f;
		CheckPointEffectParticles = LoadAsset<TdParticleSystem>("FX_FirstPEffects.Effects.PS_FX_FullScreenFX_TTGateEffect_01")/*Ref TdParticleSystem'FX_FirstPEffects.Effects.PS_FX_FullScreenFX_TTGateEffect_01'*/;
		CheckPointDistanceInCameraDirection = 250.0f;
		ReactionCrossHair = LoadAsset<Texture2D>("TdUIResources_InGame.CrossHair_Unarmed")/*Ref Texture2D'TdUIResources_InGame.CrossHair_Unarmed'*/;
		bDisplayGameMessages = true;
		AnnouncerClassName = "TdTTContent.TdTTAnnouncer";
		HUDContentClassName = "TdTTContent.TdHUDContentTimeTrial";
	}
}
}