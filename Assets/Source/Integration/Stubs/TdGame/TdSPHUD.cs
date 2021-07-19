namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSPHUD : TdHUD/*
		transient
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public enum EPopUpType 
	{
		PUT_None,
		PUT_Sniper,
		PUT_Objective,
		PUT_Tutorial,
		PUT_Bag,
		PUT_Skip,
		PUT_MAX
	};
	
	public/*private*/ TdProfileSettings.EReticuleValues DrawReticuleFlag;
	public/*private*/ TdSPHUD.EPopUpType PopUpType;
	public/*private*/ bool bIsInZoomState;
	[Category] [config] public bool bDisableDrawCrossHair;
	public/*private*/ Object.Vector2D PopUpPos;
	public/*private*/ float PopUpDuration;
	public/*private*/ float PopUpStartTime;
	public/*private*/ String PopUpMessage;
	[Const] public Font ButtonFontPS3;
	[Const] public Font ButtonFontXBOX;
	[Const] public Texture2D UnarmedCrossHair;
	[Const] public Texture2D ReactionCrossHair;
	[Const] public Texture2D WeaponCrossHair;
	[Const] public Texture2D BagIcon;
	[Const] public Texture2D CheckIcon;
	
	public override /*function */void LoadHUDContent(Core.ClassT<TdHUDContent> ContentClass)
	{
		// stub
	}
	
	public override /*function */void DrawLivingHUD()
	{
		// stub
	}
	
	public override /*function */void ToggleZoomState(bool bZoom)
	{
		// stub
	}
	
	public virtual /*function */void SetDrawCrosshairFlag(TdProfileSettings.EReticuleValues flag)
	{
		// stub
	}
	
	public virtual /*function */void ActivatePopUp(TdSPHUD.EPopUpType Type, float Duration, String Message)
	{
		// stub
	}
	
	public virtual /*function */String BuildBagString()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void DrawPopUp()
	{
		// stub
	}
	
	public virtual /*private final function */String LocalizeKeyCommand(String KeyCommand)
	{
		// stub
		return default;
	}
	
	public TdSPHUD()
	{
		// Object Offset:0x0065D521
		DrawReticuleFlag = TdProfileSettings.EReticuleValues.TdReticule_On;
		PopUpPos = new Vector2D
		{
			X=96.0f,
			Y=80.0f
		};
		ButtonFontPS3 = LoadAsset<MultiFont>("UI_Fonts_PS3.UI_Fonts_PS3Buttons")/*Ref MultiFont'UI_Fonts_PS3.UI_Fonts_PS3Buttons'*/;
		ButtonFontXBOX = LoadAsset<MultiFont>("UI_Fonts_Xbox.UI_Fonts_XboxButtons")/*Ref MultiFont'UI_Fonts_Xbox.UI_Fonts_XboxButtons'*/;
		UnarmedCrossHair = LoadAsset<Texture2D>("TdUIResources_InGame.CrossHair_Unarmed")/*Ref Texture2D'TdUIResources_InGame.CrossHair_Unarmed'*/;
		ReactionCrossHair = LoadAsset<Texture2D>("TdUIResources_InGame.CrossHair_Reaction")/*Ref Texture2D'TdUIResources_InGame.CrossHair_Reaction'*/;
		WeaponCrossHair = LoadAsset<Texture2D>("TdUIResources_InGame.CrossHair_Weapon")/*Ref Texture2D'TdUIResources_InGame.CrossHair_Weapon'*/;
		BagIcon = LoadAsset<Texture2D>("TdUIResources.Icons.Icon_Bag_White_Outline")/*Ref Texture2D'TdUIResources.Icons.Icon_Bag_White_Outline'*/;
		CheckIcon = LoadAsset<Texture2D>("TdUIResources.Icons.Icon_Check_White_Outline")/*Ref Texture2D'TdUIResources.Icons.Icon_Check_White_Outline'*/;
		HUDContentClassName = "TdSpContent.TdHUDContentSP";
	}
}
}