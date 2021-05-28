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
	
	public /*private */TdProfileSettings.EReticuleValues DrawReticuleFlag;
	public /*private */TdSPHUD.EPopUpType PopUpType;
	public /*private */bool bIsInZoomState;
	public/*()*/ /*config */bool bDisableDrawCrossHair;
	public /*private */Object.Vector2D PopUpPos;
	public /*private */float PopUpDuration;
	public /*private */float PopUpStartTime;
	public /*private */string PopUpMessage;
	public /*const */Font ButtonFontPS3;
	public /*const */Font ButtonFontXBOX;
	public /*const */Texture2D UnarmedCrossHair;
	public /*const */Texture2D ReactionCrossHair;
	public /*const */Texture2D WeaponCrossHair;
	public /*const */Texture2D BagIcon;
	public /*const */Texture2D CheckIcon;
	
	public override /*function */void LoadHUDContent(Core.ClassT<TdHUDContent> ContentClass)
	{
	
	}
	
	public override /*function */void DrawLivingHUD()
	{
	
	}
	
	public override /*function */void ToggleZoomState(bool bZoom)
	{
	
	}
	
	public virtual /*function */void SetDrawCrosshairFlag(TdProfileSettings.EReticuleValues flag)
	{
	
	}
	
	public virtual /*function */void ActivatePopUp(TdSPHUD.EPopUpType Type, float Duration, string Message)
	{
	
	}
	
	public virtual /*function */string BuildBagString()
	{
	
		return default;
	}
	
	public virtual /*function */void DrawPopUp()
	{
	
	}
	
	public virtual /*private final function */string LocalizeKeyCommand(string KeyCommand)
	{
	
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