namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdTriggerVolume : TriggerVolume/*
		placeable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public TdTriggerVolume()
	{
		var Default__TdTriggerVolume_BrushComponent0 = new BrushComponent
		{
		}/* Reference: BrushComponent'Default__TdTriggerVolume.BrushComponent0' */;
		// Object Offset:0x0067B46F
		BrushComponent = Default__TdTriggerVolume_BrushComponent0/*Ref BrushComponent'Default__TdTriggerVolume.BrushComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdTriggerVolume_BrushComponent0/*Ref BrushComponent'Default__TdTriggerVolume.BrushComponent0'*/,
		};
		CollisionComponent = Default__TdTriggerVolume_BrushComponent0/*Ref BrushComponent'Default__TdTriggerVolume.BrushComponent0'*/;
		SupportedEvents = new array< Core.ClassT<SequenceEvent> >
		{
			ClassT<SeqEvent_Touch>(),
			ClassT<SeqEvent_TakeDamage>(),
			ClassT<SeqEvent_TdTouch>(),
		};
	}
}
}