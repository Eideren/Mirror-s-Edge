namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdTrigger : Trigger/*
		native
		placeable
		hidecategories(Navigation)*/{
	public enum ETriggerInteractType 
	{
		TIT_Button,
		TIT_Valve,
		TIT_ButtonHigh,
		TIT_MAX
	};
	
	public bool Enabled;
	[Category("ValveSettings")] public bool bValveStartOpen;
	[Category("ValveSettings")] public int NumberOfRevs;
	public/*protected*/ Texture2D ValveTexture;
	public/*protected*/ Texture2D ButtonTexture;
	[export, editinline] public/*protected*/ SpriteComponent EditorSprite;
	[export, editinline] public/*private*/ TdDrawArcComponent ArcComponent;
	[Category] public TdTrigger.ETriggerInteractType TriggerType;
	[Category] public float AngleLimit;
	[transient] public/*private*/ int CurrentRev;
	
	public override /*simulated event */void PostBeginPlay()
	{
		base.PostBeginPlay();
		InitTrigger();
	}
	
	public override Reset_del Reset { get => bfield_Reset ?? TdTrigger_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => TdTrigger_Reset;
	public /*event */void TdTrigger_Reset()
	{
		InitTrigger();
	}
	
	public virtual /*simulated function */void InitTrigger()
	{
		if(bValveStartOpen)
		{
			CurrentRev = NumberOfRevs;
		}
		if(ArcComponent != default)
		{
			ArcComponent.ArcAngle = AngleLimit;
		}
	}
	
	public virtual /*simulated function */void IncreaseRevCount()
	{
		++ CurrentRev;
		if(CurrentRev >= NumberOfRevs)
		{
			CurrentRev = NumberOfRevs;
		}
	}
	
	public virtual /*simulated function */void DecreaseRevCount()
	{
		-- CurrentRev;
		if(CurrentRev < 0)
		{
			CurrentRev = 0;
		}
	}
	
	public virtual /*simulated function */int GetRevCount()
	{
		return CurrentRev;
	}
	
	public virtual /*simulated function */void OnToggle(SeqAct_Toggle Action)
	{
		/*local */int Idx = default;
		/*local */array<SequenceEvent> out_EventList = default;
	
		FindEventsOfClass(ClassT<SeqEvent_TdTouch>(), ref/*probably?*/ out_EventList, default(bool?));
		Idx = 0;
		J0x18:{}
		if(Idx < out_EventList.Length)
		{
			if(Action.InputLinks[0].bHasImpulse)
			{
				Enabled = true;			
			}
			else
			{
				if(Action.InputLinks[1].bHasImpulse)
				{
					Enabled = false;				
				}
				else
				{
					if(Action.InputLinks[2].bHasImpulse)
					{
						Enabled = !Enabled;
					}
				}
			}
			CollisionComponent.SetActorCollision(Enabled, false);
			if(((int)RemoteRole) == ((int)Actor.ENetRole.ROLE_None/*0*/))
			{
				RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy/*1*/;
				bAlwaysRelevant = true;
				NetUpdateFrequency = 0.10f;
			}
			SetNetUpdateTime(WorldInfo.TimeSeconds - 1.0f);
			++ Idx;
			goto J0x18;
		}
	}
	protected override void RestoreDefaultFunction()
	{
		Reset = null;
	
	}
	public TdTrigger()
	{
		var Default__TdTrigger_Sprite = new SpriteComponent
		{
			// Object Offset:0x0067B218
			Sprite = LoadAsset<Texture2D>("TdEditorResources.ButtonIcon")/*Ref Texture2D'TdEditorResources.ButtonIcon'*/,
			Scale = 0.10f,
		}/* Reference: SpriteComponent'Default__TdTrigger.Sprite' */;
		var Default__TdTrigger_ArcObject = new TdDrawArcComponent
		{
			// Object Offset:0x0067B2E8
			Rotation = new Rotator
			{
				Pitch=0,
				Yaw=16384,
				Roll=0
			},
		}/* Reference: TdDrawArcComponent'Default__TdTrigger.ArcObject' */;
		var Default__TdTrigger_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdTrigger.CollisionCylinder' */;
		var Default__TdTrigger_TriggerDir = new ArrowComponent
		{
			// Object Offset:0x0067B280
			ArrowColor = new Color
			{
				R=255,
				G=128,
				B=0,
				A=255
			},
			Rotation = new Rotator
			{
				Pitch=0,
				Yaw=16384,
				Roll=0
			},
		}/* Reference: ArrowComponent'Default__TdTrigger.TriggerDir' */;
		// Object Offset:0x0067AFC1
		Enabled = true;
		NumberOfRevs = 1;
		ValveTexture = LoadAsset<Texture2D>("TdEditorResources.ValveIcon")/*Ref Texture2D'TdEditorResources.ValveIcon'*/;
		ButtonTexture = LoadAsset<Texture2D>("TdEditorResources.ButtonIcon")/*Ref Texture2D'TdEditorResources.ButtonIcon'*/;
		EditorSprite = Default__TdTrigger_Sprite/*Ref SpriteComponent'Default__TdTrigger.Sprite'*/;
		ArcComponent = Default__TdTrigger_ArcObject/*Ref TdDrawArcComponent'Default__TdTrigger.ArcObject'*/;
		AngleLimit = 175.0f;
		CylinderComponent = Default__TdTrigger_CollisionCylinder/*Ref CylinderComponent'Default__TdTrigger.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdTrigger_Sprite/*Ref SpriteComponent'Default__TdTrigger.Sprite'*/,
			Default__TdTrigger_CollisionCylinder/*Ref CylinderComponent'Default__TdTrigger.CollisionCylinder'*/,
			Default__TdTrigger_TriggerDir/*Ref ArrowComponent'Default__TdTrigger.TriggerDir'*/,
			Default__TdTrigger_ArcObject/*Ref TdDrawArcComponent'Default__TdTrigger.ArcObject'*/,
		};
		CollisionComponent = Default__TdTrigger_CollisionCylinder/*Ref CylinderComponent'Default__TdTrigger.CollisionCylinder'*/;
		SupportedEvents = new array< Core.ClassT<SequenceEvent> >
		{
			ClassT<SeqEvent_Touch>(),
			ClassT<SeqEvent_Destroyed>(),
			ClassT<SeqEvent_TakeDamage>(),
			ClassT<SeqEvent_Used>(),
			ClassT<SeqEvent_TdTouch>(),
			ClassT<SeqEvent_TdUsed>(),
		};
	}
}
}