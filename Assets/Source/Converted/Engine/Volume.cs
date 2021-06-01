namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Volume : Brush/*
		native
		nativereplication
		notplaceable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public Actor AssociatedActor;
	public/*(Location)*/ int LocationPriority;
	public/*(Location)*/ /*const localized */String LocationName;
	public/*()*/ bool bForcePawnWalk;
	public/*()*/ bool bProcessAllActors;
	
	// Export UVolume::execEncompasses(FFrame&, void* const)
	public virtual /*native function */bool Encompasses(Actor Other)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override /*event */void PostBeginPlay()
	{
		base.PostBeginPlay();
		if(AssociatedActor != default)
		{
			GotoState("AssociatedTouch", default(name?), default(bool?), default(bool?));
			InitialState = GetStateName();
		}
	}
	
	public override /*simulated function */String GetLocationStringFor(PlayerReplicationInfo PRI)
	{
		return LocationName;
	}
	
	public override /*simulated function */void DisplayDebug(HUD HUD, ref float out_YL, ref float out_YPos)
	{
		base.DisplayDebug(HUD, ref/*probably?*/ out_YL, ref/*probably?*/ out_YPos);
		HUD.Canvas.DrawText("AssociatedActor " + ((AssociatedActor)).ToString(), false, default(float?), default(float?));
		out_YPos += out_YL;
		HUD.Canvas.SetPos(4.0f, out_YPos);
	}
	
	public virtual /*simulated function */void OnToggle(SeqAct_Toggle Action)
	{
		if(Action.InputLinks[0].bHasImpulse)
		{
			if(!bCollideActors)
			{
				SetCollision(true, bBlockActors, default(bool?));
			}
			CollisionComponent.SetBlockRigidBody(true);		
		}
		else
		{
			if(Action.InputLinks[1].bHasImpulse)
			{
				if(bCollideActors)
				{
					SetCollision(false, bBlockActors, default(bool?));
				}
				CollisionComponent.SetBlockRigidBody(false);			
			}
			else
			{
				if(Action.InputLinks[2].bHasImpulse)
				{
					SetCollision(!bCollideActors, bBlockActors, default(bool?));
					CollisionComponent.SetBlockRigidBody(!CollisionComponent.BlockRigidBody);
				}
			}
		}
		ForceNetRelevant();
		SetForcedInitialReplicatedProperty(ObjectConst<BoolProperty>("bCollideActors"), bCollideActors == DefaultAs<Actor>().bCollideActors);
	}
	
	public override /*simulated event */void CollisionChanged()
	{
		CollisionComponent.SetBlockRigidBody(bCollideActors);
	}
	
	public virtual /*event */void ProcessActorSetVolume(Actor Other)
	{
	
	}
	
	
	protected /*event */void Volume_AssociatedTouch_Touch(Actor Other, PrimitiveComponent OtherComp, Object.Vector HitLocation, Object.Vector HitNormal)// state function
	{
		AssociatedActor.Touch(Other, OtherComp, HitLocation, HitNormal);
	}
	
	protected /*event */void Volume_AssociatedTouch_UnTouch(Actor Other)// state function
	{
		AssociatedActor.UnTouch(Other);
	}
	
	protected /*event */void Volume_AssociatedTouch_BeginState(name PreviousStateName)// state function
	{
		/*local */Actor A = default;
	
		
		// foreach TouchingActors(ClassT<Actor>(), ref/*probably?*/ A)
		using var e0 = TouchingActors(ClassT<Actor>()).GetEnumerator();
		while(e0.MoveNext() && (A = (Actor)e0.Current) == A)
		{
			Touch(A, default, A.Location, vect(0.0f, 0.0f, 1.0f));		
		}	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) AssociatedTouch()/*state AssociatedTouch*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = default)
		{
			Touch = Volume_AssociatedTouch_Touch;
			UnTouch = Volume_AssociatedTouch_UnTouch;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (Volume_AssociatedTouch_BeginState, StateFlow, null);
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "AssociatedTouch": return AssociatedTouch();
			default: return base.FindState(stateName);
		}
	}
	public Volume()
	{
		// Object Offset:0x002B21CB
		BrushComponent = new BrushComponent
		{
			// Object Offset:0x002B234A
			bAcceptsLights = true,
			LightingChannels = new LightComponent.LightingChannelContainer
			{
				bInitialized = true,
				Dynamic = true,
			},
			CollideActors = true,
			BlockNonZeroExtent = true,
			AlwaysLoadOnClient = true,
			AlwaysLoadOnServer = true,
		}/* Reference: BrushComponent'Default__Volume.BrushComponent0' */;
		bSkipActorPropertyReplication = true;
		bCollideActors = true;
		Components = new array</*export editinline */ActorComponent>
		{
			new BrushComponent
			{
				// Object Offset:0x002B234A
				bAcceptsLights = true,
				LightingChannels = new LightComponent.LightingChannelContainer
				{
					bInitialized = true,
					Dynamic = true,
				},
				CollideActors = true,
				BlockNonZeroExtent = true,
				AlwaysLoadOnClient = true,
				AlwaysLoadOnServer = true,
			}/* Reference: BrushComponent'Default__Volume.BrushComponent0' */,
		};
		CollisionComponent = new BrushComponent
		{
			// Object Offset:0x002B234A
			bAcceptsLights = true,
			LightingChannels = new LightComponent.LightingChannelContainer
			{
				bInitialized = true,
				Dynamic = true,
			},
			CollideActors = true,
			BlockNonZeroExtent = true,
			AlwaysLoadOnClient = true,
			AlwaysLoadOnServer = true,
		}/* Reference: BrushComponent'Default__Volume.BrushComponent0' */;
	}
}
}