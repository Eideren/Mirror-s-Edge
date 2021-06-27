namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PortalVolume : Volume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display,Advanced,Attachment,Collision,Volume)*/{
	public array<PortalTeleporter> Portals;
	
	public PortalVolume()
	{
		var Default__PortalVolume_BrushComponent0 = new BrushComponent
		{
			// Object Offset:0x004661BF
			CollideActors = false,
			BlockNonZeroExtent = false,
		}/* Reference: BrushComponent'Default__PortalVolume.BrushComponent0' */;
		// Object Offset:0x003A4346
		BrushComponent = Default__PortalVolume_BrushComponent0/*Ref BrushComponent'Default__PortalVolume.BrushComponent0'*/;
		bCollideActors = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__PortalVolume_BrushComponent0/*Ref BrushComponent'Default__PortalVolume.BrushComponent0'*/,
		};
		CollisionComponent = Default__PortalVolume_BrushComponent0/*Ref BrushComponent'Default__PortalVolume.BrushComponent0'*/;
		SupportedEvents = new array< Core.ClassT<SequenceEvent> >
		{
			ClassT<SeqEvent_Touch>(),
		};
	}
}
}