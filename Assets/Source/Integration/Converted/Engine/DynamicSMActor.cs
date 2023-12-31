namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DynamicSMActor : Actor/*
		abstract
		native
		notplaceable
		hidecategories(Navigation)*/{
	[Category] [Const, editconst, export, editinline] public StaticMeshComponent StaticMeshComponent;
	[Category] [Const, editconst, export, editinline] public LightEnvironmentComponent LightEnvironment;
	[repnotify] public StaticMesh ReplicatedMesh;
	[repnotify] public MaterialInterface ReplicatedMaterial;
	[repnotify] public Object.Vector ReplicatedMeshTranslation;
	[repnotify] public Object.Rotator ReplicatedMeshRotation;
	[repnotify] public Object.Vector ReplicatedMeshScale3D;
	[Category] public bool bPawnCanBaseOn;
	[Category] public bool bSafeBaseIfAsleep;
	
	//replication
	//{
	//	 if(bNetDirty)
	//		ReplicatedMaterial, ReplicatedMesh, 
	//		ReplicatedMeshRotation, ReplicatedMeshScale3D, 
	//		ReplicatedMeshTranslation;
	//}
	
	public override /*event */void eventPostBeginPlay()
	{
		base.eventPostBeginPlay();
		ReplicatedMesh = StaticMeshComponent.StaticMesh;
	}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
		if(VarName == "ReplicatedMesh")
		{
			StaticMeshComponent.SetStaticMesh(ReplicatedMesh);		
		}
		else
		{
			if(VarName == "ReplicatedMaterial")
			{
				StaticMeshComponent.SetMaterial(0, ReplicatedMaterial);			
			}
			else
			{
				if(VarName == "ReplicatedMeshTranslation")
				{
					StaticMeshComponent.SetTranslation(ReplicatedMeshTranslation);				
				}
				else
				{
					if(VarName == "ReplicatedMeshRotation")
					{
						StaticMeshComponent.SetRotation(ReplicatedMeshRotation);					
					}
					else
					{
						if(VarName == "ReplicatedMeshScale3D")
						{
							StaticMeshComponent.SetScale3D(ReplicatedMeshScale3D);						
						}
						else
						{
							base.ReplicatedEvent(VarName);
						}
					}
				}
			}
		}
	}
	
	public virtual /*function */void OnSetStaticMesh(SeqAct_SetStaticMesh Action)
	{
		if((Action.NewStaticMesh != default) && Action.NewStaticMesh != StaticMeshComponent.StaticMesh)
		{
			StaticMeshComponent.SetStaticMesh(Action.NewStaticMesh);
			ReplicatedMesh = Action.NewStaticMesh;
			ForceNetRelevant();
		}
	}
	
	public virtual /*function */void OnSetMaterial(SeqAct_SetMaterial Action)
	{
		StaticMeshComponent.SetMaterial(Action.MaterialIndex, Action.NewMaterial);
		if(Action.MaterialIndex == 0)
		{
			ReplicatedMaterial = Action.NewMaterial;
			ForceNetRelevant();
		}
	}
	
	public virtual /*function */void SetStaticMesh(StaticMesh NewMesh, /*optional */Object.Vector? _NewTranslation = default, /*optional */Object.Rotator? _NewRotation = default, /*optional */Object.Vector? _NewScale3D = default)
	{
		var NewTranslation = _NewTranslation ?? default;
		var NewRotation = _NewRotation ?? default;
		var NewScale3D = _NewScale3D ?? default;
		StaticMeshComponent.SetStaticMesh(NewMesh);
		StaticMeshComponent.SetTranslation(NewTranslation);
		StaticMeshComponent.SetRotation(NewRotation);
		if(!IsZero(NewScale3D))
		{
			StaticMeshComponent.SetScale3D(NewScale3D);
			ReplicatedMeshScale3D = NewScale3D;
		}
		ReplicatedMesh = NewMesh;
		ReplicatedMeshTranslation = NewTranslation;
		ReplicatedMeshRotation = NewRotation;
		ForceNetRelevant();
	}
	
	public virtual /*simulated function */bool CanBasePawn(Pawn P)
	{
		if((bPawnCanBaseOn || (bSafeBaseIfAsleep && StaticMeshComponent != default) && !StaticMeshComponent.RigidBodyIsAwake(default(name?))))
		{
			return true;
		}
		return false;
	}
	
	public override /*event */void Attach(Actor Other)
	{
		/*local */Pawn P = default;
	
		base.Attach(Other);
		if(bSafeBaseIfAsleep)
		{
			P = ((Other) as Pawn);
			if(P != default)
			{
				SetPhysics(Actor.EPhysics.PHYS_None/*0*/);
			}
		}
	}
	
	public override /*event */void Detach(Actor Other)
	{
		/*local */int Idx = default;
		/*local */Pawn P = default, Test = default;
		/*local */bool bResetPhysics = default;
	
		base.Detach(Other);
		P = ((Other) as Pawn);
		if(P != default)
		{
			bResetPhysics = true;
			Idx = 0;
			J0x35:{}
			if(Idx < Attached.Length)
			{
				Test = ((Attached[Idx]) as Pawn);
				if((Test != default) && Test != P)
				{
					bResetPhysics = false;
					goto J0x8C;
				}
				++ Idx;
				goto J0x35;
			}
			J0x8C:{}
			if(bResetPhysics)
			{
				SetPhysics(Actor.EPhysics.PHYS_RigidBody/*10*/);
			}
		}
	}
	
	public DynamicSMActor()
	{
		var Default__DynamicSMActor_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
			// Object Offset:0x003130F9
			bEnabled = false,
		}/* Reference: DynamicLightEnvironmentComponent'Default__DynamicSMActor.MyLightEnvironment' */;
		var Default__DynamicSMActor_StaticMeshComponent0 = new StaticMeshComponent
		{
			// Object Offset:0x0031312D
			LightEnvironment = Default__DynamicSMActor_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__DynamicSMActor.MyLightEnvironment'*/,
			BlockRigidBody = false,
		}/* Reference: StaticMeshComponent'Default__DynamicSMActor.StaticMeshComponent0' */;
		// Object Offset:0x00312EFB
		StaticMeshComponent = Default__DynamicSMActor_StaticMeshComponent0/*Ref StaticMeshComponent'Default__DynamicSMActor.StaticMeshComponent0'*/;
		LightEnvironment = Default__DynamicSMActor_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__DynamicSMActor.MyLightEnvironment'*/;
		bPawnCanBaseOn = true;
		bGameRelevant = true;
		bEdShouldSnap = true;
		bPathColliding = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__DynamicSMActor_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__DynamicSMActor.MyLightEnvironment'*/,
			Default__DynamicSMActor_StaticMeshComponent0/*Ref StaticMeshComponent'Default__DynamicSMActor.StaticMeshComponent0'*/,
		};
		RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy;
		CollisionComponent = Default__DynamicSMActor_StaticMeshComponent0/*Ref StaticMeshComponent'Default__DynamicSMActor.StaticMeshComponent0'*/;
	}
}
}