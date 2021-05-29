namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdLookAtPoint : Keypoint/*
		placeable
		hidecategories(Navigation)*/{
	public float LookAtInterpolationTime;
	public float LookAtInterpolationTimer;
	public float LookAtDurationTimer;
	public /*transient */Object.Vector ActivatedLocation;
	public/*()*/ bool bDoNotRegisterAsLookAt;
	public/*()*/ bool bAutoRegisterOnStartup;
	
	public override /*event */void PostBeginPlay()
	{
		if(!bDoNotRegisterAsLookAt && bAutoRegisterOnStartup)
		{
			RegisterLookAtPoint(default);
		}
	}
	
	public override /*event */void Destroyed()
	{
		if(!bDoNotRegisterAsLookAt)
		{
			UnRegisterLookAtPoint();
		}
	}
	
	public virtual /*function */void OnTdActivateLookAtPoint(SeqAct_TdActivateLookAtPoint Action)
	{
		if(bDoNotRegisterAsLookAt)
		{
			if(Action.InputLinks[0].bHasImpulse)
			{
				SetupTime(Action.LookAtInterpolationTime, Action.LookAtDuration);
				RegisterLookAtPoint(true);
				ActivatedLocation = Location;			
			}
			else
			{
				if(Action.InputLinks[1].bHasImpulse)
				{
					UnRegisterLookAtPoint();
				}
			}		
		}
		else
		{
			if(Action != default)
			{
				if(Action.InputLinks[0].bHasImpulse)
				{
					RegisterLookAtPoint(default);				
				}
				else
				{
					if(Action.InputLinks[1].bHasImpulse)
					{
						UnRegisterLookAtPoint();
					}
				}
			}
		}
	}
	
	public virtual /*function */void RegisterLookAtPoint(/*optional */bool? _bForceLookAt = default)
	{
		/*local */TdGameInfo GInfo = default;
	
		var bForceLookAt = _bForceLookAt ?? default;
		GInfo = ((WorldInfo.Game) as TdGameInfo);
		if(GInfo != default)
		{
			GInfo.RegisterLookAtPoint(this, bForceLookAt);
		}
	}
	
	public virtual /*function */void SetupTime(float InLookAtInterpolationTime, float InLookAtDuration)
	{
		LookAtInterpolationTimer = FMax(DefaultAs<TdLookAtPoint>().LookAtInterpolationTimer, InLookAtInterpolationTime);
		LookAtInterpolationTime = LookAtInterpolationTimer;
		LookAtDurationTimer = InLookAtDuration;
	}
	
	public virtual /*simulated function */void UpdateViewRotation(Object.Rotator InViewRotation, float DeltaTime, ref Object.Rotator out_DeltaRot, Object.Vector PlayerLocation)
	{
		/*local */Object.Rotator WantedRotation = default, Delta = default, HeadRot = default;
		/*local */float InterpVal = default;
		/*local */TdPlayerController PC = default;
	
		LookAtInterpolationTimer -= DeltaTime;
		LookAtInterpolationTimer = FMax(0.00000010f, LookAtInterpolationTimer);
		if(LookAtDurationTimer != -1.0f)
		{
			LookAtDurationTimer -= DeltaTime;
			LookAtDurationTimer = FMax(0.0f, LookAtDurationTimer);
		}
		InterpVal = LookAtInterpolationTimer / LookAtInterpolationTime;
		InterpVal = 1.0f - Square(InterpVal);
		WantedRotation = Normalize(((Rotator)(Location - PlayerLocation)));
		HeadRot = Normalize(InViewRotation);
		Delta = RLerp(HeadRot, WantedRotation, InterpVal, true);
		out_DeltaRot = Delta - HeadRot;
		if((Abs(((float)(out_DeltaRot.Yaw))) < 64.0f) && WorldInfo.Game.IsA("TdSPTutorialGame"))
		{
			
			// foreach WorldInfo.AllControllers(ClassT<TdPlayerController>(), ref/*probably?*/ PC)
			using var e269 = WorldInfo.AllControllers(ClassT<TdPlayerController>()).GetEnumerator();
			while(e269.MoveNext() && (PC = (TdPlayerController)e269.Current) == PC)
			{
				((PC.Pawn) as TdTutorialPawn).OnTutorialEvent(2);			
			}		
		}
		if((bDoNotRegisterAsLookAt && LookAtDurationTimer <= 0.0f) && LookAtDurationTimer != -1.0f)
		{
			UnRegisterLookAtPoint();		
		}
		else
		{
			if(ActivatedLocation != Location)
			{
				LookAtInterpolationTimer = LookAtInterpolationTime;
				ActivatedLocation = Location;
			}
		}
	}
	
	public virtual /*function */void UnRegisterLookAtPoint()
	{
		/*local */TdGameInfo GInfo = default;
	
		GInfo = ((WorldInfo.Game) as TdGameInfo);
		if(GInfo != default)
		{
			GInfo.UnRegisterLookAtPoint(this);
		}
	}
	
	public TdLookAtPoint()
	{
		// Object Offset:0x0058D368
		LookAtInterpolationTimer = 0.10f;
		LookAtDurationTimer = 0.50f;
		bStatic = false;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdLookAtPoint.Sprite")/*Ref SpriteComponent'Default__TdLookAtPoint.Sprite'*/,
		};
	}
}
}