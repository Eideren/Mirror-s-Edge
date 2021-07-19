namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIRaceProgressBar : TdUIObject/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public enum EPB_Type 
	{
		EPB_TimeDiff,
		EPB_Length,
		EPB_MAX
	};
	
	[Category] public TdUIRaceProgressBar.EPB_Type BarType;
	[transient] public array<float> SectionData;
	[transient] public array<float> SectionPctLength;
	[transient] public array<String> SectionTexts;
	[transient] public array<int> SectionTextureId;
	[transient] public StaticArray<Texture2D, Texture2D, Texture2D>/*[3]*/ BottomBar;
	[transient] public StaticArray<Texture2D, Texture2D, Texture2D>/*[3]*/ MiddleBar;
	[transient] public StaticArray<Texture2D, Texture2D, Texture2D>/*[3]*/ TopBar;
	[Category] public bool bHorisontalBar;
	[Category] public bool bDrawDropShadow;
	[Category] public float BarPctPosition;
	[Category] public float TextPctOffset;
	[Category] public float DropShadowHorisontalOffset;
	[Category] public float DropShadowVerticalOffset;
	
	// Export UTdUIRaceProgressBar::execUpdateSectionData(FFrame&, void* const)
	public virtual /*private native final function */void UpdateSectionData()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public virtual /*function */void SetProgressBarInfo(array<float> InSectionData, array<float> InSectionPctLength)
	{
		// stub
	}
	
	public TdUIRaceProgressBar()
	{
		var Default__TdUIRaceProgressBar_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIRaceProgressBar.WidgetEventComponent' */;
		// Object Offset:0x0068CD18
		SectionData = new array<float>
		{
			53.350f,
			25.20f,
			-124.350f,
			112.350f,
			-47.350f,
		};
		SectionPctLength = new array<float>
		{
			0.10f,
			0.20f,
			0.30f,
			0.10f,
			0.30f,
		};
		bDrawDropShadow = true;
		BarPctPosition = 0.50f;
		DropShadowHorisontalOffset = 0.060f;
		DropShadowVerticalOffset = 0.060f;
		PrimaryStyle = new UIRoot.UIStyleReference
		{
			RequiredStyleClass = ClassT<UIStyle_Combo>()/*Ref Class'UIStyle_Combo'*/,
		};
		EventProvider = Default__TdUIRaceProgressBar_WidgetEventComponent/*Ref UIComp_Event'Default__TdUIRaceProgressBar.WidgetEventComponent'*/;
	}
}
}