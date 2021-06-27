namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InterpTrackToggle : InterpTrack/*
		native
		collapsecategories
		hidecategories(Object)*/{
	public enum ETrackToggleAction 
	{
		ETTA_Off,
		ETTA_On,
		ETTA_Toggle,
		ETTA_MAX
	};
	
	public partial struct /*native */ToggleTrackKey
	{
		public float Time;
		public/*()*/ InterpTrackToggle.ETrackToggleAction ToggleAction;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00344108
	//		Time = 0.0f;
	//		ToggleAction = InterpTrackToggle.ETrackToggleAction.ETTA_Off;
	//	}
	};
	
	public array<InterpTrackToggle.ToggleTrackKey> ToggleTrack;
	public/*()*/ bool bFireEventsWhenJumpingForwards;
	public/*()*/ bool bActivateSystemEachUpdate;
	
	public InterpTrackToggle()
	{
		// Object Offset:0x00344204
		bFireEventsWhenJumpingForwards = true;
		TrackInstClass = ClassT<InterpTrackInstToggle>()/*Ref Class'InterpTrackInstToggle'*/;
		TrackTitle = "Toggle";
	}
}
}