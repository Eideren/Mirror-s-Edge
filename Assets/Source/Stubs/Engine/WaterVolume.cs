namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class WaterVolume : PhysicsVolume/*
		notplaceable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public/*()*/ SoundCue EntrySound;
	public/*()*/ SoundCue ExitSound;
	public/*()*/ Core.ClassT<Actor> EntryActor;
	public/*()*/ Core.ClassT<Actor> ExitActor;
	public/*()*/ Core.ClassT<Actor> PawnEntryActor;
	
	public override Touch_del Touch { get => bfield_Touch ?? WaterVolume_Touch; set => bfield_Touch = value; } Touch_del bfield_Touch;
	public override Touch_del global_Touch => WaterVolume_Touch;
	public /*simulated event */void WaterVolume_Touch(Actor Other, PrimitiveComponent OtherComp, Object.Vector HitLocation, Object.Vector HitNormal)
	{
	
	}
	
	public virtual /*function */void PlayEntrySplash(Actor Other)
	{
	
	}
	
	public override UnTouch_del UnTouch { get => bfield_UnTouch ?? WaterVolume_UnTouch; set => bfield_UnTouch = value; } UnTouch_del bfield_UnTouch;
	public override UnTouch_del global_UnTouch => WaterVolume_UnTouch;
	public /*event */void WaterVolume_UnTouch(Actor Other)
	{
	
	}
	
	public virtual /*function */void PlayExitSplash(Actor Other)
	{
	
	}
	protected override void RestoreDefaultFunction()
	{
		Touch = null;
		UnTouch = null;
	
	}
	public WaterVolume()
	{
		var Default__WaterVolume_BrushComponent0 = new BrushComponent
		{
			// Object Offset:0x004662F3
			RBChannel = PrimitiveComponent.ERBCollisionChannel.RBCC_Water,
		}/* Reference: BrushComponent'Default__WaterVolume.BrushComponent0' */;
		// Object Offset:0x00459E27
		bWaterVolume = true;
		FluidFriction = 2.40f;
		LocationName = "under water";
		BrushComponent = Default__WaterVolume_BrushComponent0/*Ref BrushComponent'Default__WaterVolume.BrushComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__WaterVolume_BrushComponent0/*Ref BrushComponent'Default__WaterVolume.BrushComponent0'*/,
		};
		CollisionComponent = Default__WaterVolume_BrushComponent0/*Ref BrushComponent'Default__WaterVolume.BrushComponent0'*/;
	}
}
}