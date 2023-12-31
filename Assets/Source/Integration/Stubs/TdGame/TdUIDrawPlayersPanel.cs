namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIDrawPlayersPanel : TdUIDrawPanel/*
		abstract
		native
		hidecategories(Object,UIRoot,Object)*/{
	public partial struct /*native */TdPlayerSlot
	{
		public TdPlayerReplicationInfo TdPRI;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00684104
	//		TdPRI = default;
	//	}
	};
	
	public partial struct /*native */TdTeamPlayerSlots
	{
		public array<TdUIDrawPlayersPanel.TdPlayerSlot> Slots;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x006841B8
	//		Slots = default;
	//	}
	};
	
	[Category("Sound")] public name ClickedCue;
	[transient] public UIDataStore_TdGameData TdGameData;
	[Category] public name ResourceDataStoreName;
	public/*protected*/ int MaxTeams;
	public/*protected*/ int MaxPlayersInTeam;
	public int SelectedTeam;
	public int SelectedPlayer;
	[Category("TdUIDrawPanel")] public Font SelectedFont;
	[Category("TdUIDrawPanel")] public Font UnselectedFont;
	[Category("TdUIDrawPanel")] public Object.Color PlayerSlotBGColor;
	[Category("TdUIDrawPanel")] public Object.Color PlayerSlotSelectedBgColor;
	[Category("TdUIDrawPanel")] public int TeamSpacing;
	public array<TdUIDrawPlayersPanel.TdTeamPlayerSlots> TeamSlots;
	public /*delegate*/TdUIDrawPlayersPanel.OnPlayerSlotClicked __OnPlayerSlotClicked__Delegate;
	
	public delegate void OnPlayerSlotClicked(TdPlayerReplicationInfo TdPRI);
	
	public override /*function */void PostInitialize()
	{
		// stub
	}
	
	public virtual /*function */void UpdatePlayers(array<PlayerReplicationInfo> pris)
	{
		// stub
	}
	
	public virtual /*protected function */bool Draw(Canvas C)
	{
		// stub
		return default;
	}
	
	public virtual /*protected function */void DrawTeam(Canvas C, int TeamIndex, int X, int Y, int XL, int YL)
	{
		// stub
	}
	
	public virtual /*protected function */void DrawPlayerSlotBG(Canvas C, int TeamIndex, int PlayerSlotIndex, int X, int Y, int XL, int YL)
	{
		// stub
	}
	
	public virtual /*protected function */void DrawPlayer(Canvas C, TdPlayerReplicationInfo TdPRI, int TeamIndex, bool bIsSelected, int Left, int Top, int Width, int Height)
	{
		// stub
	}
	
	public virtual /*function */bool TdUIDrawPlayerPanel_OnClicked(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */TdPlayerReplicationInfo GetSelectedTdPRI()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void SetSelectedSlot(int TeamIndex, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */int GetMaxPlayersInTeam()
	{
		// stub
		return default;
	}
	
	public virtual /*function */int GetMaxTeams()
	{
		// stub
		return default;
	}
	
	public TdUIDrawPlayersPanel()
	{
		var Default__TdUIDrawPlayersPanel_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIDrawPlayersPanel.WidgetEventComponent' */;
		// Object Offset:0x0068517F
		ClickedCue = (name)"Clicked";
		ResourceDataStoreName = (name)"TdGameData";
		MaxTeams = 2;
		MaxPlayersInTeam = 6;
		SelectedFont = LoadAsset<MultiFont>("UI_Fonts_Final.Helvetica_Small_Normal")/*Ref MultiFont'UI_Fonts_Final.Helvetica_Small_Normal'*/;
		UnselectedFont = LoadAsset<MultiFont>("UI_Fonts_Final.Helvetica_Small_Normal")/*Ref MultiFont'UI_Fonts_Final.Helvetica_Small_Normal'*/;
		PlayerSlotBGColor = new Color
		{
			R=0,
			G=0,
			B=0,
			A=255
		};
		PlayerSlotSelectedBgColor = new Color
		{
			R=200,
			G=0,
			B=0,
			A=255
		};
		TeamSpacing = 20;
		__DrawDelegate__Delegate = (C) => Draw(C);
		__OnClicked__Delegate = (EventObject, PlayerIndex) => TdUIDrawPlayerPanel_OnClicked(EventObject, PlayerIndex);
		DefaultStates = new array< Core.ClassT<UIState> >
		{
			ClassT<UIState_Enabled>(),
			ClassT<UIState_Disabled>(),
			ClassT<UIState_Focused>(),
			ClassT<UIState_Focused>(),
			ClassT<UIState_Active>(),
			ClassT<UIState_Pressed>(),
		};
		EventProvider = Default__TdUIDrawPlayersPanel_WidgetEventComponent/*Ref UIComp_Event'Default__TdUIDrawPlayersPanel.WidgetEventComponent'*/;
	}
}
}