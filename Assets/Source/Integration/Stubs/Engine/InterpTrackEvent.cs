namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InterpTrackEvent : InterpTrack/*
		native
		collapsecategories
		hidecategories(Object)*/{
	public partial struct /*native */EventTrackKey
	{
		public float Time;
		[Category] public name EventName;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00341F38
	//		Time = 0.0f;
	//		EventName = (name)"None";
	//	}
	};
	
	public array<InterpTrackEvent.EventTrackKey> EventTrack;
	[Category] public bool bFireEventsWhenForwards;
	[Category] public bool bFireEventsWhenBackwards;
	[Category] public bool bFireEventsWhenJumpingForwards;
	
	public InterpTrackEvent()
	{
		// Object Offset:0x00342060
		bFireEventsWhenForwards = true;
		bFireEventsWhenBackwards = true;
		TrackInstClass = ClassT<InterpTrackInstEvent>()/*Ref Class'InterpTrackInstEvent'*/;
		TrackTitle = "Event";
	}
}
}