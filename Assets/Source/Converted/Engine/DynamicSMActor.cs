namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DynamicSMActor : Actor/*
		abstract
		native
		notplaceable
		hidecategories(Navigation)*/{
	public/*()*/ /*const editconst export editinline */StaticMeshComponent StaticMeshComponent;
	public/*()*/ /*const editconst export editinline */LightEnvironmentComponent LightEnvironment;
	public /*repnotify */StaticMesh ReplicatedMesh;
	public /*repnotify */MaterialInterface ReplicatedMaterial;
	public /*repnotify */Object.Vector ReplicatedMeshTranslation;
	public /*repnotify */Object.Rotator ReplicatedMeshRotation;
	public /*repnotify */Object.Vector ReplicatedMeshScale3D;
	public/*()*/ bool bPawnCanBaseOn;
	public/*()*/ bool bSafeBaseIfAsleep;
	
	//replication
	//{
	//	 if(bNetDirty)
	//		ReplicatedMaterial, ReplicatedMesh, 
	//		ReplicatedMeshRotation, ReplicatedMeshScale3D, 
	//		ReplicatedMeshTranslation;
	//}
	
	public override /*event */void PostBeginPlay()
	{
		base.PostBeginPlay();
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
	
	public virtual /*function */void SetStaticMesh(StaticMesh NewMesh, /*optional */Object.Vector NewTranslation = default, /*optional */Object.Rotator NewRotation = default, /*optional */Object.Vector NewScale3D = default)
	{
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
		if(bPawnCanBaseOn || (bSafeBaseIfAsleep && StaticMeshComponent != default) && !StaticMeshComponent.RigidBodyIsAwake(default(name)))
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
		// Object Offset:0x00312EFB
		StaticMeshComponent = new StaticMeshComponent
		{
			// Object Offset:0x0031312D
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__DynamicSMActor.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__DynamicSMActor.MyLightEnvironment'*/,
			BlockRigidBody = false,
		}/* Reference: StaticMeshComponent'Default__DynamicSMActor.StaticMeshComponent0' */;
		LightEnvironment = new DynamicLightEnvironmentComponent
		{
			// Object Offset:0x003130F9
			bEnabled = false,
		}/* Reference: DynamicLightEnvironmentComponent'Default__DynamicSMActor.MyLightEnvironment' */;
		bPawnCanBaseOn = true;
		bGameRelevant = true;
		bEdShouldSnap = true;
		bPathColliding = true;
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new DynamicLightEnvironmentComponent
			{
				// Object Offset:0x003130F9
				bEnabled = false,
			}/* Reference: DynamicLightEnvironmentComponent'Default__DynamicSMActor.MyLightEnvironment' */,
			//Components[1]=
			new StaticMeshComponent
			{
				// Object Offset:0x0031312D
				LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__DynamicSMActor.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__DynamicSMActor.MyLightEnvironment'*/,
				BlockRigidBody = false,
			}/* Reference: StaticMeshComponent'Default__DynamicSMActor.StaticMeshComponent0' */,
		};
		RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy;
		CollisionComponent = new StaticMeshComponent
		{
			// Object Offset:0x0031312D
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__DynamicSMActor.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__DynamicSMActor.MyLightEnvironment'*/,
			BlockRigidBody = false,
		}/* Reference: StaticMeshComponent'Default__DynamicSMActor.StaticMeshComponent0' */;
	}
}
}