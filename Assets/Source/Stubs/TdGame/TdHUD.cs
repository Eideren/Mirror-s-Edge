namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHUD : HUD/*
		transient
		native
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public enum EDamageType 
	{
		EDT_Bullet,
		EDT_Taser,
		EDT_ElectricShock,
		EDT_Explosion,
		EDT_Fall,
		EDT_Melee,
		EDT_FlashBang,
		EDT_HeavyFlashBang,
		EDT_MAX
	};
	
	public bool bDisplayConsoleMessages;
	public bool bDisplayGameMessages;
	public bool bCrosshairOnEnemy;
	public /*transient */bool bAnimatedFocusDistance;
	public /*private transient */bool bIsFadingIn;
	public /*private transient */bool bUseRealTimeFade;
	public /*const */Font TinyFont;
	public /*const */Font SmallFont;
	public /*const */Font MediumFont;
	public /*const */Font LargeFont;
	public String AnnouncerClassName;
	public String HUDContentClassName;
	public Core.ClassT<TdHUDContent> HUDContentClass;
	public float TargetingMaxDistance;
	public Object.Vector TargetingHitLocation;
	public float TargetingHitDistance;
	public Actor TargetingActor;
	public /*transient */UIScene PauseSceneRef;
	public /*transient */UIScene InGameMenuRef;
	public /*transient */UIScene DiskAccessIndicatorScene;
	public /*transient */UIScene DiskAccessIndicatorInstance;
	public /*config */float FontDSOffset;
	public /*config */Object.Color FontDSColor;
	public/*()*/ /*editinline */TdHudEffectManager EffectManager;
	public /*private */MaterialEffect FadeEffect;
	public /*private transient */MaterialInstanceConstant FadeEffectMaterialInstance;
	public /*private transient */float FadeInTime;
	public /*private transient */float FadeOutTime;
	public /*protected transient */float FadeAmount;
	public /*private transient */float LatentFadeIn;
	public /*private transient */float LastRealTimeHUDRenderTime;
	public /*transient */float RealTimeRenderDelta;
	public TdHUDDebug DebugHUD;
	public /*transient */int PendingPauseTicks;
	public /*delegate*/TdHUD.OnMaxFade __OnMaxFade__Delegate;
	public /*delegate*/TdHUD.OnDoneFade __OnDoneFade__Delegate;
	
	public delegate void OnMaxFade();
	
	public delegate void OnDoneFade();
	
	// Export UTdHUD::execSetPostProcessVars(FFrame&, void* const)
	public virtual /*native final function */void SetPostProcessVars(float DeltaTime, float RealTimeDelta)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdHUD::execLinkToHudScene(FFrame&, void* const)
	public virtual /*native function */void LinkToHudScene(UIScene SceneToLink)
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*function */void ToggleReactionTime(bool toggle)
	{
	
	}
	
	public override /*function */void PreBeginPlay()
	{
	
	}
	
	public virtual /*function */void LinkHUDContent()
	{
	
	}
	
	public override /*function */void PostBeginPlay()
	{
	
	}
	
	public override Tick_del Tick { get => bfield_Tick ?? TdHUD_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => TdHUD_Tick;
	public /*simulated function */void TdHUD_Tick(float DeltaTime)
	{
	
	}
	
	public override /*event */void Destroyed()
	{
	
	}
	
	public virtual /*function */void LoadHUDContent(Core.ClassT<TdHUDContent> ContentClass)
	{
	
	}
	
	public virtual /*exec function */void TriggerUIBlurIn(float BlurInTime)
	{
	
	}
	
	public virtual /*exec function */void TriggerUIBlurOut(float BlurOutTime)
	{
	
	}
	
	public virtual /*exec function */void TriggerCustomColorBlink(float InFadeOutTime, float InFadeInTime, float R, float G, float B, /*optional */bool? _bRealTime = default, /*optional *//*delegate*/TdHUD.OnMaxFade? _InOnMaxFade = default)
	{
	
	}
	
	public virtual /*exec function */void TriggerCustomBlink(float InFadeOutTime, float InFadeInTime, /*optional */bool? _bRealTime = default, /*optional *//*delegate*/TdHUD.OnMaxFade? _InOnMaxFade = default)
	{
	
	}
	
	public virtual /*exec function */void TriggerCustomColorFadeIn(float Time, Object.LinearColor FadeColor, /*optional */bool? _bRealTime = default, /*optional *//*delegate*/TdHUD.OnMaxFade? _InOnDone = default, /*optional */bool? _bForceFullFadeAmount = default)
	{
	
	}
	
	public virtual /*exec function */void TriggerCustomColorFadeOut(float Time, Object.LinearColor FadeColor, /*optional */bool? _bRealTime = default, /*optional *//*delegate*/TdHUD.OnMaxFade? _InOnDone = default)
	{
	
	}
	
	public virtual /*private final function */void TriggerCustomFadeIn(float Time, /*optional */bool? _bRealTime = default, /*optional *//*delegate*/TdHUD.OnMaxFade? _InOnDone = default, /*optional */bool? _bForceFullFadeAmount = default)
	{
	
	}
	
	public virtual /*private final function */void TriggerCustomFadeOut(float Time, /*optional */bool? _bRealTime = default, /*optional *//*delegate*/TdHUD.OnMaxFade? _InOnDone = default)
	{
	
	}
	
	public virtual /*function */void ToggleZoomState(bool bZoom)
	{
	
	}
	
	public virtual /*function */void PauseGame()
	{
	
	}
	
	public virtual /*private final function */void OnPauseSceneOpened(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*function */void UnPauseGame(UIScene DeactivatedScene)
	{
	
	}
	
	public virtual /*function */void DelayedPauseGame()
	{
	
	}
	
	public virtual /*function */void OpenInGameMenu()
	{
	
	}
	
	public virtual /*function */bool IsInMainMenu()
	{
	
		return default;
	}
	
	public virtual /*function */void PlayTakeHit(Object.Vector HitDir, int Damage, Core.ClassT<DamageType> DamageType)
	{
	
	}
	
	public virtual /*function */void EndLaserEffect()
	{
	
	}
	
	public override /*function */void PlayerOwnerDied()
	{
	
	}
	
	public virtual /*function */void PlayerOwnerRestart()
	{
	
	}
	
	public override Reset_del Reset { get => bfield_Reset ?? TdHUD_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => TdHUD_Reset;
	public /*function */void TdHUD_Reset()
	{
	
	}
	
	public virtual /*function */void OpenSceneByName(name SceneToShow)
	{
	
	}
	
	public virtual /*function */void CloseSceneByName(name SceneToClose)
	{
	
	}
	
	public virtual /*event */void SetFocusDistance(float NewDistance)
	{
	
	}
	
	public virtual /*function */void ToggleToneMapping()
	{
	
	}
	
	public virtual /*function */void ComputeHUDPosition(float PosX, float PosY, float Width, float Height, ref Object.Vector2D FinalPos)
	{
	
	}
	
	public virtual /*function */void ClearLocalMessages()
	{
	
	}
	
	public override /*function */void DrawMessage(int MessageIdx, float PosY, ref float DX, ref float DY)
	{
	
	}
	
	public virtual /*function */void GetScreenCoordsEx(float PosX, float PosY, ref float ScreenX, ref float ScreenY, ref HUD.HudLocalizedMessage InMessage)
	{
	
	}
	
	public virtual /*function */void DrawTextWithOutLine(float XPos, float YPos, float OffsetX, float OffsetY, String TextToDraw, Object.Color TextColor)
	{
	
	}
	
	public virtual /*function */String GetTimeString(float Seconds)
	{
	
		return default;
	}
	
	public virtual /*function */String GetFormattedTime(int Time)
	{
	
		return default;
	}
	
	public override /*function */void DrawHUD()
	{
	
	}
	
	public virtual /*function */void DrawDeadHUD()
	{
	
	}
	
	public virtual /*function */void DrawLivingHUD()
	{
	
	}
	
	public virtual /*function */void DrawWarmupHUD()
	{
	
	}
	
	public virtual /*function */void DrawPausedHUD()
	{
	
	}
	
	public virtual /*function */void ProjectOntoScreen(Object.Vector WorldLocation, Object.Vector WorldOffset, Object.Vector2D ClipXBounds, Object.Vector2D ClipYBounds, ref Object.Vector ScreenLocation)
	{
	
	}
	
	public /*function */static Font GetFontSizeIndex(int FontSize)
	{
	
		return default;
	}
	
	public override /*event */void PostRender()
	{
	
	}
	
	public virtual /*event */void NotifyDiskAccess(bool IsAccessing, TsSystem.ETsDiskAccess AccessType)
	{
	
	}
	protected override void RestoreDefaultFunction()
	{
		Tick = null;
		Reset = null;
	
	}
	public TdHUD()
	{
		// Object Offset:0x005561A6
		TinyFont = LoadAsset<MultiFont>("UI_Fonts_Final.Helvetica_Small_Bold")/*Ref MultiFont'UI_Fonts_Final.Helvetica_Small_Bold'*/;
		SmallFont = LoadAsset<MultiFont>("UI_Fonts_Final.Helvetica_Small_Bold")/*Ref MultiFont'UI_Fonts_Final.Helvetica_Small_Bold'*/;
		MediumFont = LoadAsset<MultiFont>("UI_Fonts_Final.Helvetica_Large_Normal")/*Ref MultiFont'UI_Fonts_Final.Helvetica_Large_Normal'*/;
		LargeFont = LoadAsset<MultiFont>("UI_Fonts_Final.Helvetica_Headline_Thick_Italic")/*Ref MultiFont'UI_Fonts_Final.Helvetica_Headline_Thick_Italic'*/;
		HUDContentClassName = "TdGame.TdHUDContent";
		TargetingMaxDistance = 10000.0f;
		FontDSOffset = 0.040f;
		FontDSColor = new Color
		{
			R=0,
			G=80,
			B=130,
			A=128
		};
		FadeInTime = 1.0f;
		FadeOutTime = 1.0f;
		bAlwaysTick = true;
	}
}
}