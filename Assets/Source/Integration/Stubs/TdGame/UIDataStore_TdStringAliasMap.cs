namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataStore_TdStringAliasMap : UIDataStore_StringAliasMap/*
		transient
		native
		config(Game)
		hidecategories(Object,UIRoot)*/{
	public /*config */int FakePlatform;
	public /*transient */bool bControllerConnected;
	
	// Export UUIDataStore_TdStringAliasMap::execGetStringWithFieldName(FFrame&, void* const)
	public override /*native function */int GetStringWithFieldName(String FieldName, ref String MappedString)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public override /*event */void Registered(LocalPlayer PlayerOwner)
	{
		// stub
	}
	
	public override /*event */void Unregistered(LocalPlayer PlayerOwner)
	{
		// stub
	}
	
	public virtual /*function */void OnControllerChange(int ControllerId, bool Connected)
	{
		// stub
	}
	
	public UIDataStore_TdStringAliasMap()
	{
		// Object Offset:0x006E23F6
		FakePlatform = -1;
		MenuInputMapArray = new array</*config */UIDataStore_StringAliasMap.UIMenuInputMap>
		{
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"None",
				Set = (name)"None",
				MappedText = "",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"Accept",
				Set = (name)"360",
				MappedText = "<Strings:TdGameUI.TdButtonFont.Xenon_A>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"Cancel",
				Set = (name)"360",
				MappedText = "<Strings:TdGameUI.TdButtonFont.Xenon_B>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"Conditional1",
				Set = (name)"360",
				MappedText = "<Strings:TdGameUI.TdButtonFont.Xenon_X>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"Conditional2",
				Set = (name)"360",
				MappedText = "<Strings:TdGameUI.TdButtonFont.Xenon_Y>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"Start",
				Set = (name)"360",
				MappedText = "<Strings:TdGameUI.TdButtonFont.Xenon_Start>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"back",
				Set = (name)"360",
				MappedText = "<Strings:TdGameUI.TdButtonFont.Xenon_Back>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"LeftBumper",
				Set = (name)"360",
				MappedText = "<Strings:TdGameUI.TdButtonFont.Xenon_LeftBumper>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"RightBumper",
				Set = (name)"360",
				MappedText = "<Strings:TdGameUI.TdButtonFont.Xenon_RightBumper>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"LeftTrigger",
				Set = (name)"360",
				MappedText = "<Strings:TdGameUI.TdButtonFont.Xenon_LeftTrigger>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"RightTrigger",
				Set = (name)"360",
				MappedText = "<Strings:TdGameUI.TdButtonFont.Xenon_RightTrigger>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"BothTrigger",
				Set = (name)"360",
				MappedText = "<Strings:TdGameUI.TdButtonFont.Xenon_BothTrigger>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"AnyKey",
				Set = (name)"360",
				MappedText = "<Strings:TdGameUI.TdButtonFont.Xenon_A>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"LeftStick",
				Set = (name)"360",
				MappedText = "<Strings:TdGameUI.TdButtonFont.Xenon_LeftStick>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"RightStick",
				Set = (name)"360",
				MappedText = "<Strings:TdGameUI.TdButtonFont.Xenon_RightStick>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"RightStickButton",
				Set = (name)"360",
				MappedText = "<Strings:TdGameUI.TdButtonFont.Xenon_RightStickButton>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"StickHorizontal",
				Set = (name)"360",
				MappedText = "<Strings:TdGameUI.TdButtonFont.Xenon_HorizontalStick>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"StickVertical",
				Set = (name)"360",
				MappedText = "<Strings:TdGameUI.TdButtonFont.Xenon_VerticalStick>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"Accept",
				Set = (name)"PS3",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PS3_A>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"Cancel",
				Set = (name)"PS3",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PS3_B>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"Conditional1",
				Set = (name)"PS3",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PS3_X>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"Conditional2",
				Set = (name)"PS3",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PS3_Y>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"Start",
				Set = (name)"PS3",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PS3_Start>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"back",
				Set = (name)"PS3",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PS3_Back>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"LeftBumper",
				Set = (name)"PS3",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PS3_LeftBumper>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"RightBumper",
				Set = (name)"PS3",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PS3_RightBumper>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"LeftTrigger",
				Set = (name)"PS3",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PS3_LeftTrigger>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"RightTrigger",
				Set = (name)"PS3",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PS3_RightTrigger>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"BothTrigger",
				Set = (name)"PS3",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PS3_BothTrigger>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"AnyKey",
				Set = (name)"PS3",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PS3_A>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"LeftStick",
				Set = (name)"PS3",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PS3_LeftStick>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"RightStick",
				Set = (name)"PS3",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PS3_RightStick>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"RightStickButton",
				Set = (name)"PS3",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PS3_RightStickButton>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"StickHorizontal",
				Set = (name)"PS3",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PS3_HorizontalStick>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"StickVertical",
				Set = (name)"PS3",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PS3_VerticalStick>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"SixAxis_Disarm",
				Set = (name)"PS3",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PS3_SA_Disarm>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"SixAxis_BalanceWalk",
				Set = (name)"PS3",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PS3_SA_BalanceWalk>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"SixAxis_SkillRoll",
				Set = (name)"PS3",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PS3_SA_SkillRoll>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"Accept",
				Set = (name)"PC",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PC_Button>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"Cancel",
				Set = (name)"PC",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PC_Button>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"Conditional1",
				Set = (name)"PC",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PC_Button>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"Conditional2",
				Set = (name)"PC",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PC_Button>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"Start",
				Set = (name)"PC",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PC_Button>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"LeftBumper",
				Set = (name)"PC",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PC_Button>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"RightBumper",
				Set = (name)"PC",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PC_Button>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"LeftTrigger",
				Set = (name)"PC",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PC_Button>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"RightTrigger",
				Set = (name)"PC",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PC_Button>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"BothTrigger",
				Set = (name)"PC",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PC_2Buttons>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"AnyKey",
				Set = (name)"PC",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PC_Button>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"LeftStick",
				Set = (name)"PC",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PC_Button>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"RightStick",
				Set = (name)"PC",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PC_Button>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"StickHorizontal",
				Set = (name)"PC",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PC_Button>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"StickVertical",
				Set = (name)"PC",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PC_Button>",
			},
			new UIDataStore_StringAliasMap.UIMenuInputMap
			{
				FieldName = (name)"RightStickButton",
				Set = (name)"PC",
				MappedText = "<Strings:TdGameUI.TdButtonFont.PC_Button>",
			},
		};
	}
}
}