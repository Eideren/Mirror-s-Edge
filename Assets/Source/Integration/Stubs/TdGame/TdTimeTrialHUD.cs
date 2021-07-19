namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdTimeTrialHUD : TdSPHUD/*
		transient
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	[Category("HUDIcons")] public Object.Vector2D RaceTimerPos;
	[Category("HUDIcons")] public Object.Vector2D SpeedPos;
	[Category("HUDIcons")] public Object.Vector2D RaceProgressPos;
	[Category("HUDIcons")] public Object.Vector2D StarRatingPos;
	[Category("HUDIcons")] public float StarFadeTime;
	[Category("HUDIcons")] public float StarCompletedAlpha;
	[Category("HUDIcons")] public float StarFailedAlpha;
	[Category("HUDIcons")] public float RaceProgressBarHeight;
	[Category("HUDIcons")] public float ProgressBarAlpha;
	[Category("HUDIcons")] public float ProgressBarCompletedAlpha;
	[Category("HUDIcons")] public float ProgressBarWidth;
	[Category("HUDIcons")] public float ProgressBarFadeTime;
	[transient] public StaticArray<Texture2D, Texture2D, Texture2D>/*[3]*/ BottomBar;
	[transient] public StaticArray<Texture2D, Texture2D, Texture2D>/*[3]*/ MiddleBar;
	[transient] public StaticArray<Texture2D, Texture2D, Texture2D>/*[3]*/ TopBar;
	[transient] public Texture2D Star;
	[transient] public array<float> HUDProgressFade;
	[transient] public StaticArray<float, float, float>/*[3]*/ StarRatingAlpha;
	[transient] public String SpeedUnitString;
	[transient] public int MeasurementUnits;
	public ParticleSystem CheckPointEffectParticles;
	public float CheckPointDistanceInCameraDirection;
	
	public override /*function */void LoadHUDContent(Core.ClassT<TdHUDContent> ContentClass)
	{
		// stub
	}
	
	public override /*event */void PostBeginPlay()
	{
		// stub
	}
	
	public virtual /*function */void CacheMeasurementUnitInfo()
	{
		// stub
	}
	
	public override /*function */void DrawLivingHUD()
	{
		// stub
	}
	
	public virtual /*function */void TriggerRestartRaceblink()
	{
		// stub
	}
	
	public virtual /*private final function */void TriggerRestartRaceblinkCallback()
	{
		// stub
	}
	
	public override /*function */void PauseGame()
	{
		// stub
	}
	
	public virtual /*function */void DrawSpeed(ref float PosY)
	{
		// stub
	}
	
	public virtual /*function */void DrawTrackProgress(TdSPTimeTrialGame Game)
	{
		// stub
	}
	
	public virtual /*function */void DrawStarRating(TdSPTimeTrialGame Game)
	{
		// stub
	}
	
	public virtual /*function */void DrawRaceTimer(TdSPTimeTrialGame Game)
	{
		// stub
	}
	
	public override /*function */void OpenInGameMenu()
	{
		// stub
	}
	
	public override /*function */void PlayerOwnerRestart()
	{
		// stub
	}
	
	public override /*function */void UnPauseGame(UIScene DeactivatedScene)
	{
		// stub
	}
	
	public virtual /*function */void TriggerCheckPointEffect()
	{
		// stub
	}
	
	public override /*function */void ActivatePopUp(TdSPHUD.EPopUpType Type, float Duration, String Message)
	{
		// stub
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