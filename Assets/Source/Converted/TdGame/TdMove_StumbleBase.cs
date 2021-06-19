// NO OVERWRITE

namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_StumbleBase : TdPhysicsMove/*
		config(PawnMovement)*/{
	public enum EStumbleState 
	{
		ESS_HitNone,
		ESS_HitMeleeBack,
		ESS_HitMeleeBackHead,
		ESS_HitMeleeFrontLeft,
		ESS_HitMeleeFrontRight,
		ESS_HitMeleeBargeFront,
		ESS_HitMeleeCrouchFront,
		ESS_HitMeleeSlideFront,
		ESS_HitMeleeWallrunRight,
		ESS_HitMeleeWallrunLeft,
		ESS_HitMeleeAirHeadFront,
		ESS_HitMeleeAirBodyFront,
		ESS_HitMeleeVaultKick,
		ESS_HitMeleeSoccerKick,
		ESS_HitBulletFront,
		ESS_HitBulletFrontHead,
		ESS_HitBulletBack,
		ESS_HitSpecialBulletFront,
		ESS_HitSpecialBulletHead,
		ESS_HitSpecialBulletBack,
		ESS_HitBarbedWireFront,
		ESS_MAX
	};
	
	public Object.Vector DamageLocation;
	public Object.Vector damageMomentum;
	public Object.Vector InstigatorLocation;
	public TdPawn Instigator;
	public Core.ClassT<DamageType> HitDamageType;
	public float DirectionalBias;
	public TdMove_StumbleBase.EStumbleState StumbleState;
	
	public override /*simulated function */void StartMove()
	{
		base.StartMove();
		StumbleState = ((TdMove_StumbleBase.EStumbleState)GetStumbleState());
	}
	
	public virtual /*function */TdMove_StumbleBase.EStumbleState GetStumbleState()
	{
		/*local */Object.Vector HitHeight = default, Hit2D = default;
		/*local */float HitSide = default;
		/*local */TdMove_StumbleBase.EStumbleState ResultStumbleState = default;
	
		HitHeight = DamageLocation - (PawnOwner.Location - (vect(0.0f, 0.0f, 1.0f) * PawnOwner.CylinderComponent.CollisionHeight));
		Hit2D = InstigatorLocation - PawnOwner.Location;
		Hit2D.Z = 0.0f;
		Hit2D = Normal(Hit2D);
		HitSide = Dot(Hit2D, ((Vector)(PawnOwner.Rotation)));
		
			if(HitDamageType.IsA(ClassT<TdDmgType_Barge>())){
				if(HitSide > 0.0f)
				{
					ResultStumbleState = TdMove_StumbleBase.EStumbleState.ESS_HitMeleeBargeFront/*5*/;				
				}
				else
				{
					ResultStumbleState = TdMove_StumbleBase.EStumbleState.ESS_HitMeleeBack/*1*/;
				}
			}
			if(HitDamageType.IsA(ClassT<TdDmgType_BarbedWire>())){
				ResultStumbleState = ((TdMove_StumbleBase.EStumbleState)((HitSide > 0.0f) ? 1 : 20));
			}
			if(HitDamageType.IsA(ClassT<TdDmgType_Melee>()) 
			   || HitDamageType.IsA(ClassT<TdDmgType_MeleeLeft>()) 
			   || HitDamageType.IsA(ClassT<TdDmgType_MeleeRight>()) 
			   || HitDamageType.IsA(ClassT<TdDmgType_Sniper_Bullet>()) 
			   || HitDamageType.IsA(ClassT<TdDmgType_Shove>())){
				if(HitSide > 0.0f)
				{
					ResultStumbleState = ((TdMove_StumbleBase.EStumbleState)((HitDamageType == ClassT<TdDmgType_MeleeRight>()) ? 4 : 3));				
				}
				else
				{
					ResultStumbleState = ((TdMove_StumbleBase.EStumbleState)((HitHeight.Z > 145.0f) ? 2 : 1));
				}
			}
			if(HitDamageType.IsA(ClassT<TdDmgType_MeleeVaultKick>())){
				ResultStumbleState = TdMove_StumbleBase.EStumbleState.ESS_HitMeleeVaultKick/*12*/;
			}
			if(HitDamageType.IsA(ClassT<TdDmgType_MeleeAir>())){
				if(HitSide > 0.0f)
				{
					ResultStumbleState = ((TdMove_StumbleBase.EStumbleState)((HitHeight.Z < 100.0f) ? 11 : 10));				
				}
				else
				{
					ResultStumbleState = ((TdMove_StumbleBase.EStumbleState)((HitHeight.Z > 100.0f) ? 2 : 1));
				}
			}
			if(HitDamageType.IsA(ClassT<TdDmgType_MeleeCrouch>())){
				if(HitSide > 0.0f)
				{
					ResultStumbleState = TdMove_StumbleBase.EStumbleState.ESS_HitMeleeCrouchFront/*6*/;				
				}
				else
				{
					ResultStumbleState = ((TdMove_StumbleBase.EStumbleState)((HitHeight.Z > 145.0f) ? 2 : 1));
				}
			}
			if(HitDamageType.IsA(ClassT<TdDmgType_MeleeSlide>())){
				if(HitSide > 0.0f)
				{
					ResultStumbleState = TdMove_StumbleBase.EStumbleState.ESS_HitMeleeSlideFront/*7*/;				
				}
				else
				{
					ResultStumbleState = ((TdMove_StumbleBase.EStumbleState)((HitHeight.Z > 145.0f) ? 2 : 1));
				}
			}
			if(HitDamageType.IsA(ClassT<TdDmgType_MeleeWallRun>())){
				if(HitSide > 0.0f)
				{
					ResultStumbleState = ((TdMove_StumbleBase.EStumbleState)((Cross(((Vector)(PawnOwner.Rotation)), (Instigator.Location - PawnOwner.Location)).Z > 0.0f) ? 9 : 8));				
				}
				else
				{
					ResultStumbleState = ((TdMove_StumbleBase.EStumbleState)((HitHeight.Z > 145.0f) ? 2 : 1));
				}
			}
			if(HitDamageType.IsA(ClassT<TdDmgType_MeleeSoccerKick>())){
				ResultStumbleState = TdMove_StumbleBase.EStumbleState.ESS_HitMeleeSoccerKick/*13*/;
			}
			if(HitDamageType.IsA(ClassT<TdDmgType_Shotgun>()) 
			   || HitDamageType.IsA(ClassT<TdDmgType_Taser>())){
				if(HitSide < 0.0f)
				{
					ResultStumbleState = TdMove_StumbleBase.EStumbleState.ESS_HitSpecialBulletBack/*19*/;				
				}
				else
				{
					if(HitHeight.Z > 145.0f)
					{
						ResultStumbleState = TdMove_StumbleBase.EStumbleState.ESS_HitSpecialBulletHead/*18*/;					
					}
					else
					{
						ResultStumbleState = TdMove_StumbleBase.EStumbleState.ESS_HitSpecialBulletFront/*17*/;
					}
				}
			}
			if(HitDamageType.IsA(ClassT<TdDmgType_LowCaliber_Bullet>()) 
			   || HitDamageType.IsA(ClassT<TdDmgType_HighCaliber_Bullet>())){
				if(HitSide < 0.0f)
				{
					ResultStumbleState = TdMove_StumbleBase.EStumbleState.ESS_HitBulletBack/*16*/;				
				}
				else
				{
					ResultStumbleState = TdMove_StumbleBase.EStumbleState.ESS_HitBulletFront/*14*/;
				}
			}
		
		if(bDebugMove)
		{
			TdDebugOutput.DrawVector(PawnOwner.Location, ((Vector)(PawnOwner.Rotation)), 30.0f, 0, 100, 0, true);
			TdDebugOutput.DrawVector(PawnOwner.Location, Hit2D, 30.0f, 0, 0, 255, true);
			TdDebugOutput.DrawVector(DamageLocation, damageMomentum, 30.0f, 255, 0, 0, true);
		}
		return ((TdMove_StumbleBase.EStumbleState)ResultStumbleState);
	}
	
	public TdMove_StumbleBase()
	{
		// Object Offset:0x005AA246
		DirectionalBias = 0.50f;
		MovementGroup = TdMove.EMovementGroup.MG_TwoHandsBusy;
		DisableMovementTime = -1.0f;
		DisableLookTime = -1.0f;
	}
}
}