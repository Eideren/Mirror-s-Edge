namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdCheckpointVolume : Volume/*
		placeable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public /*transient */array<TdCheckpointVolumeListener> Listeners;
	
	public virtual /*function */void AddListener(TdCheckpointVolumeListener InListener)
	{
		/*local */int Idx = default;
	
		Idx = 0;
		J0x07:{}
		if(Idx < Listeners.Length)
		{
			if(EqualEqual_InterfaceInterface(Listeners[Idx], InListener))
			{
				return;
			}
			++ Idx;
			goto J0x07;
		}
		Listeners[Listeners.Length] = InListener;
	}
	
	public override Touch_del Touch { get => bfield_Touch ?? TdCheckpointVolume_Touch; set => bfield_Touch = value; } Touch_del bfield_Touch;
	public override Touch_del global_Touch => TdCheckpointVolume_Touch;
	public /*event */void TdCheckpointVolume_Touch(Actor Other, PrimitiveComponent OtherComp, Object.Vector HitLocation, Object.Vector HitNormal)
	{
		/*local */TdPlayerPawn Player = default;
		/*local */TdPlayerController PlayerController = default;
		/*local */int Idx = default;
	
		Player = ((Other) as TdPlayerPawn);
		if(Player != default)
		{
			PlayerController = ((Player.Controller) as TdPlayerController);
			Idx = 0;
			J0x3C:{}
			if(Idx < Listeners.Length)
			{
				Listeners[Idx].OnTouchedVolume(Player, PlayerController);
				++ Idx;
				goto J0x3C;
			}
		}
	}
	protected override void RestoreDefaultFunction()
	{
		Touch = null;
	
	}
	public TdCheckpointVolume()
	{
		// Object Offset:0x0053642D
		BrushComponent = new BrushComponent
		{
			// Object Offset:0x01AB4666
			bAcceptsLights = false,
		}/* Reference: BrushComponent'Default__TdCheckpointVolume.BrushComponent0' */;
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new BrushComponent
			{
				// Object Offset:0x01AB4666
				bAcceptsLights = false,
			}/* Reference: BrushComponent'Default__TdCheckpointVolume.BrushComponent0' */,
		};
		CollisionComponent = new BrushComponent
		{
			// Object Offset:0x01AB4666
			bAcceptsLights = false,
		}/* Reference: BrushComponent'Default__TdCheckpointVolume.BrushComponent0' */;
	}
}
}