namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ReverbVolume : Volume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display,Advanced,Attachment,Collision,Volume)*/{
	public enum ReverbPreset 
	{
		REVERB_Default,
		REVERB_Bathroom,
		REVERB_StoneRoom,
		REVERB_Auditorium,
		REVERB_ConcertHall,
		REVERB_Cave,
		REVERB_Hallway,
		REVERB_StoneCorridor,
		REVERB_Alley,
		REVERB_Forest,
		REVERB_City,
		REVERB_Mountains,
		REVERB_Quarry,
		REVERB_Plain,
		REVERB_ParkingLot,
		REVERB_SewerPipe,
		REVERB_Underwater,
		REVERB_SmallRoom,
		REVERB_MediumRoom,
		REVERB_LargeRoom,
		REVERB_MediumHall,
		REVERB_LargeHall,
		REVERB_Plate,
		REVERB_MAX
	};
	
	public partial struct /*native */ReverbSettings
	{
		[Category] public ReverbVolume.ReverbPreset ReverbType;
		[Category] public float Volume;
		[Category] public float FadeTime;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C59F5
	//		ReverbType = ReverbVolume.ReverbPreset.REVERB_Default;
	//		Volume = 0.50f;
	//		FadeTime = 2.0f;
	//	}
	};
	
	[Category] public float Priority;
	[Category] public ReverbVolume.ReverbSettings Settings;
	[noimport, Const, transient] public ReverbVolume NextLowerPriorityVolume;
	
	public ReverbVolume()
	{
		var Default__ReverbVolume_BrushComponent0 = new BrushComponent
		{
			// Object Offset:0x0046629F
			CollideActors = false,
			BlockNonZeroExtent = false,
		}/* Reference: BrushComponent'Default__ReverbVolume.BrushComponent0' */;
		// Object Offset:0x003B036B
		Settings = new ReverbVolume.ReverbSettings
		{
			ReverbType = ReverbVolume.ReverbPreset.REVERB_Default,
			Volume = 0.50f,
			FadeTime = 2.0f,
		};
		BrushComponent = Default__ReverbVolume_BrushComponent0/*Ref BrushComponent'Default__ReverbVolume.BrushComponent0'*/;
		bCollideActors = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__ReverbVolume_BrushComponent0/*Ref BrushComponent'Default__ReverbVolume.BrushComponent0'*/,
		};
		CollisionComponent = Default__ReverbVolume_BrushComponent0/*Ref BrushComponent'Default__ReverbVolume.BrushComponent0'*/;
		SupportedEvents = new array< Core.ClassT<SequenceEvent> >
		{
			ClassT<SeqEvent_Touch>(),
		};
	}
}
}