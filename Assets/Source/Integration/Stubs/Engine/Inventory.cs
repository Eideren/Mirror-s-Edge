// NO OVERWRITE

namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Inventory : Actor/*
		abstract
		native
		nativereplication
		notplaceable
		hidecategories(Navigation)*/{
	public enum EInventorySlot 
	{
		EISlot_None,
		EISlot_LightWeapon,
		EISlot_HeavyWeapon,
		EISlot_MAX
	};
	
	public Inventory Inventory_; // Renamed C# naming scheme
	public InventoryManager InvManager;
	public /*databinding const localized */String ItemName;
	public bool bRenderOverlays;
	public bool bReceiveOwnerEvents;
	public bool bDropOnDeath;
	public bool bDelayedSpawn;
	public bool bPredictRespawns;
	public /*transient */Inventory.EInventorySlot InventorySlot;
	public /*const */Inventory.EInventorySlot DefaultInventorySlot;
	public/*()*/ float RespawnTime;
	public float MaxDesireability;
	public/*()*/ /*databinding const localized */String PickupMessage;
	public/*()*/ SoundCue PickupSound;
	public/*()*/ String PickupForce;
	public Core.ClassT<DroppedPickup> DroppedPickupClass;
	public /*export editinline */PrimitiveComponent DroppedPickupMesh;
	public /*export editinline */PrimitiveComponent PickupFactoryMesh;
	public /*export editinline */ParticleSystemComponent DroppedPickupParticles;
	
	//replication
	//{
	//	 if(((((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/)) && bNetDirty) && bNetOwner)
	//		InvManager, Inventory;
	//
	//	 if(((((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/)) && bNetDirty) && bNetOwner)
	//		InventorySlot;
	//}
	
	public virtual /*function */void AssignToSlot(Inventory.EInventorySlot Slot)
	{
	
	}
	
	public virtual /*simulated function */void RenderOverlays(HUD H)
	{
	
	}
	
	public virtual /*simulated function */void ActiveRenderOverlays(HUD H)
	{
	
	}
	
	public override /*simulated function */String GetHumanReadableName()
	{
	
		return default;
	}
	
	public override /*event */void Destroyed()
	{
	
	}
	
	public /*function */static float BotDesireability(Actor PickupHolder, Pawn P, Controller C)
	{
	
		return default;
	}
	
	public /*function */static float DetourWeight(Pawn Other, float PathWeight)
	{
	
		return default;
	}
	
	public virtual /*final function */void GiveTo(Pawn Other)
	{
	
	}
	
	public virtual /*function */void AnnouncePickup(Pawn Other)
	{
	
	}
	
	public virtual /*function */void GivenTo(Pawn thisPawn, /*optional */bool? _bDoNotActivate = default)
	{
	
	}
	
	public virtual /*reliable client simulated function */void ClientGivenTo(Pawn NewOwner, bool bDoNotActivate)
	{
	
	}
	
	public virtual /*function */void ItemRemovedFromInvManager()
	{
	
	}
	
	public virtual /*function */bool DenyPickupQuery(Core.ClassT<Inventory> ItemClass, Actor Pickup)
	{
	
		return default;
	}
	
	public virtual /*function */void DropFrom(Object.Vector StartLocation, Object.Vector StartVelocity)
	{
	
	}
	
	public /*function */static String GetLocalString(/*optional */int? _Switch = default, /*optional */PlayerReplicationInfo? _RelatedPRI_1 = default, /*optional */PlayerReplicationInfo? _RelatedPRI_2 = default)
	{
	
		return default;
	}
	
	public virtual /*function */void OwnerEvent(name EventName)
	{
	
	}
	
	public Inventory()
	{
		var Default__Inventory_Sprite = new SpriteComponent
		{
			// Object Offset:0x004CFB36
			HiddenGame = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: SpriteComponent'Default__Inventory.Sprite' */;
		// Object Offset:0x003454F7
		MaxDesireability = 0.10f;
		DroppedPickupClass = ClassT<DroppedPickup>()/*Ref Class'DroppedPickup'*/;
		bHidden = true;
		bOnlyRelevantToOwner = true;
		bReplicateMovement = false;
		bOnlyDirtyReplication = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__Inventory_Sprite/*Ref SpriteComponent'Default__Inventory.Sprite'*/,
		};
		RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy;
		NetPriority = 1.40f;
	}
}
}