namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class LevelStreamingVolume : Volume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display,Advanced,Attachment,Collision,Volume)*/{
	public enum EStreamingVolumeUsage 
	{
		SVB_Loading,
		SVB_LoadingAndVisibility,
		SVB_VisibilityBlockingOnLoad,
		SVB_BlockingOnLoad,
		SVB_LoadingNotVisible,
		SVB_MAX
	};
	
	public/*()*/ /*noimport const editconst */array</*editconst */LevelStreaming> StreamingLevels;
	public/*()*/ bool bEditorPreVisOnly;
	public/*()*/ bool bDisabled;
	public/*()*/ LevelStreamingVolume.EStreamingVolumeUsage Usage;
	
	public override /*simulated function */void OnToggle(SeqAct_Toggle Action)
	{
	
	}
	
	public LevelStreamingVolume()
	{
		var Default__LevelStreamingVolume_BrushComponent0 = new BrushComponent
		{
			// Object Offset:0x0046606F
			CollideActors = false,
			BlockNonZeroExtent = false,
		}/* Reference: BrushComponent'Default__LevelStreamingVolume.BrushComponent0' */;
		// Object Offset:0x003508FD
		BrushComponent = Default__LevelStreamingVolume_BrushComponent0/*Ref BrushComponent'Default__LevelStreamingVolume.BrushComponent0'*/;
		bCollideActors = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__LevelStreamingVolume_BrushComponent0/*Ref BrushComponent'Default__LevelStreamingVolume.BrushComponent0'*/,
		};
		CollisionComponent = Default__LevelStreamingVolume_BrushComponent0/*Ref BrushComponent'Default__LevelStreamingVolume.BrushComponent0'*/;
		SupportedEvents = new array< Core.ClassT<SequenceEvent> >
		{
			ClassT<SeqEvent_Touch>(),
		};
	}
}
}