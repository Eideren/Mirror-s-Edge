namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdMove_WallClimb
{
  public override unsafe bool CanDoMove()
  {
    TdPawn v2 = default; // eax
    float v4 = default; // xmm1_4
    float v5 = default; // xmm0_4
    Vector *v6; // ecx
    float v7 = default; // xmm2_4
    float v8 = default; // xmm3_4
    float v9 = default; // xmm0_4
    float v10 = default; // xmm1_4
    float v11 = default; // xmm2_4
    float v12 = default; // xmm1_4
    float v13 = default; // xmm0_4
    TdPawn v14 = default; // ecx
    float v15 = default; // xmm2_4
    float v16 = default; // xmm3_4
    float v17 = default; // xmm0_4
    float v18 = default; // edx
    float v19 = default; // eax
    float v20 = default; // xmm2_4
    double v21 = default; // st7
    TdPawn v22 = default; // eax
    Vector *v23; // ecx
    float v24 = default; // xmm6_4
    float v25 = default; // xmm5_4
    float v26 = default; // xmm0_4
    float v27 = default; // edx
    float v28 = default; // eax
    float v29 = default; // xmm7_4
    float v30 = default; // xmm2_4
    TdPawn v31 = default; // ecx
    float v32 = default; // xmm1_4
    float v33 = default; // xmm0_4
    Vector *v34; // ecx
    float v35 = default; // xmm2_4
    float v36 = default; // edx
    float v37 = default; // eax
    float v38 = default; // ecx
    float v39 = default; // xmm2_4
    float v40 = default; // xmm0_4
    TdPawn v41 = default; // ecx
    float v42 = default; // xmm2_4
    float *v43; // ecx
    float v44 = default; // xmm1_4
    float v45 = default; // xmm0_4
    float v46 = default; // xmm2_4
    float v47 = default; // [esp+0h] [ebp-BCh]
    float v48 = default; // [esp+4h] [ebp-B8h]
    float v49 = default; // [esp+Ch] [ebp-B0h]
    float v50 = default; // [esp+Ch] [ebp-B0h]
    float v51 = default; // [esp+10h] [ebp-ACh]
    float v52 = default; // [esp+10h] [ebp-ACh]
    float v53 = default; // [esp+14h] [ebp-A8h]
    float v54 = default; // [esp+14h] [ebp-A8h]
    float v55 = default; // [esp+18h] [ebp-A4h]
    float v56 = default; // [esp+18h] [ebp-A4h]
    float v57 = default; // [esp+1Ch] [ebp-A0h]
    float v58 = default; // [esp+1Ch] [ebp-A0h]
    Vector a3 = default; // [esp+24h] [ebp-98h] BYREF
    Vector a2 = default; // [esp+34h] [ebp-88h] BYREF
    Vector a4 = default; // [esp+44h] [ebp-78h] BYREF
    float v62 = default; // [esp+50h] [ebp-6Ch]
    float v63 = default; // [esp+60h] [ebp-5Ch]
    CheckResult v64 = default; // [esp+70h] [ebp-4Ch] BYREF
  
    v2 = this.PawnOwner;
    if ( default == v2.Controller )
      return false;
    if ( v2.MoveActionHint != MAH_Up )
      return false;
    v4 = v2.Location.Y - v2.MoveLedgeLocation.Y;
    v5 = v2.Location.X - v2.MoveLedgeLocation.X;
    if ( (float)((float)(v4 * v4) + (float)(v5 * v5)) > (float)(this.WallClimbingMaxDistance2D * this.WallClimbingMaxDistance2D) )
      return false;
    if ( v2.MoveLedgeResult != 2 )
      goto LABEL_31;
    if ( this.MinWallHeight > (float)((float)(v2.MoveLedgeLocation.Z - v2.Location.Z) + v2.CylinderComponent.CollisionHeight) )
      return false;
    v64.Ctor(COERCE_INT(1.0f), 0);
    v6 = this.PawnOwner.Rotation.Vector(&a2);
    v7 = v6->Y;
    v8 = v6->X;
    v9 = (float)(v8 * v8) + (float)(v7 * v7);
    v63 = v9;
    if ( v9 == 1.0f )
    {
      v10 = 0.0f;
      if ( v6->Z == 0.0f )
      {
        v53 = v6->X;
        v55 = v6->Y;
        v57 = v6->Z;
        goto LABEL_15;
      }
      v53 = v8;
      v55 = v7;
    }
    else if ( v9 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
    {
      v62 = 3.0f;
      v11 = 1.0f / fsqrt(v63);
      v12 = (float)(3.0f - (float)((float)(v11 * v63) * v11)) * (float)(v11 * 0.5f);
      v53 = v6->X * v12;
      v13 = v6->Y * v12;
      v10 = 0.0f;
      v55 = v13;
    }
    else
    {
      v10 = 0.0f;
      v53 = 0.0f;
      v55 = 0.0f;
    }
    v57 = 0.0f;
  LABEL_15:
    v14 = this.PawnOwner;
    a4 = v14.Location;
    a4.Z = (float)(v14.CylinderComponent.CollisionHeight - 64.0f) + a4.Z;
    v15 = v14.MoveNormal.Y;
    v16 = v14.MoveNormal.X;
    v49 = v14.CylinderComponent.CollisionRadius;
    v17 = (float)(v16 * v16) + (float)(v15 * v15);
    v62 = v17;
    if ( v17 == 1.0f )
    {
      if ( v14.MoveNormal.Z == 0.0f )
      {
        v18 = v14.MoveNormal.Y;
        a2.X = v14.MoveNormal.X;
        v19 = v14.MoveNormal.Z;
        a2.Y = v18;
        a2.Z = v19;
      }
      else
      {
        a2.X = v16;
        a2.Y = v15;
      }
    }
    else
    {
      if ( v17 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
      {
        v63 = 3.0f;
        v20 = 1.0f / fsqrt(v62);
        a2.X = (float)(3.0f - (float)((float)(v20 * v62) * v20)) * (float)(v20 * 0.5f);
        a2.X = a2.X * v14.MoveNormal.X;
        v10 = v14.MoveNormal.Y * (float)((float)(3.0f - (float)((float)(v20 * v62) * v20)) * (float)(v20 * 0.5f));
      }
      else
      {
        a2.X = 0.0f;
      }
      a2.Y = v10;
    }
    v48 = (float)(fabs(a2.Y));
    v47 = (float)(fabs(a2.X));
    v21 = Max(v47, v48);
    v51 = (float)v21;
    if ( (float)(v51 * v51) < 1.0f )
      v52 = v51 * v51;
    else
      v52 = 1.0f;
    v50 = (float)((v21 * sqrt(1.0f - v52) * 0.82842702d + 1.0f) * v49 + 8.0f);
    a3.Y = a4.Y + (float)(v55 * v50);
    a3.X = a4.X + (float)(v50 * v53);
    a3.Z = (float)(v57 * v50) + a4.Z;
    a2.X = 0.0f;
    a2.Y = 0.0f;
    a2.Z = 0.0f;
    if ( default == this.MovementLineCheck(&v64, &a3, &a4, &a2, 140494) || v64.Actor && (v64.Actor.bExludeHandMoves.AsBitfield(32) & 2) != 0 || v64.Component && (v64.Component.bUseViewOwnerDepthPriorityGroup.AsBitfield(21) & 0x200) != 0 )
      return false;
  LABEL_31:
    v22 = this.PawnOwner;
    if ( (float)(this.WallClimbingVelocityStartLimit * this.WallClimbingVelocityStartLimit) > (float)((float)(v22.Velocity.X * v22.Velocity.X) + (float)(v22.Velocity.Y * v22.Velocity.Y)) || v22.Velocity.Z <= 0.0f )
      return false;
    v23 = v22.Controller.Pawn::Rotation.Vector(&a2);
    v24 = v23->Y;
    v25 = v23->X;
    v26 = (float)(v25 * v25) + (float)(v24 * v24);
    v62 = v26;
    if ( v26 == 1.0f )
    {
      if ( v23->Z == 0.0f )
      {
        v27 = v23->Y;
        a3.X = v23->X;
        v28 = v23->Z;
        v25 = a3.X;
        a3.Y = v27;
        v24 = v27;
        a3.Z = v28;
        v29 = v28;
        goto LABEL_40;
      }
    }
    else if ( v26 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
    {
      v63 = 3.0f;
      v30 = 1.0f / fsqrt(v62);
      a3.X = (float)(3.0f - (float)((float)(v30 * v62) * v30)) * (float)(v30 * 0.5f);
      v25 = v23->X * a3.X;
      v24 = v23->Y * a3.X;
    }
    else
    {
      v25 = 0.0f;
      v24 = 0.0f;
    }
    v29 = 0.0f;
  LABEL_40:
    v31 = this.PawnOwner;
    v32 = v31.Velocity.Y;
    v33 = v31.Velocity.X;
fixed(var ptr1 =&v31.Velocity)
    v34 =  ptr1;
    v35 = (float)(v33 * v33) + (float)(v32 * v32);
    v62 = v35;
    if ( v35 == 1.0f )
    {
      if ( v34->Z == 0.0f )
      {
        v36 = v34->X;
        v37 = v34->Y;
        v38 = v34->Z;
        a3.X = v36;
        v33 = v36;
        a3.Y = v37;
        v32 = v37;
        a3.Z = v38;
        v39 = v38;
        goto LABEL_47;
      }
    }
    else if ( v35 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
    {
      v63 = 3.0f;
      v40 = fsqrt(v62);
      a3.X = (float)(3.0f - (float)((float)((float)(1.0f / v40) * v62) * (float)(1.0f / v40))) * (float)((float)(1.0f / v40) * 0.5f);
      v33 = a3.X * v34->X;
      v32 = v34->Y * a3.X;
    }
    else
    {
      v33 = 0.0f;
      v32 = 0.0f;
    }
    v39 = 0.0f;
  LABEL_47:
    if ( (float)((float)((float)(v39 * v29) + (float)(v32 * v24)) + (float)(v33 * v25)) < 0.0f )
      return false;
    v41 = this.PawnOwner;
    v42 = v41.MoveNormal.X;
    a3.X = -0.0f - v25;
fixed(var ptr2 =&v41.MoveNormal.X)
    v43 =  ptr2;
    a3.Z = -0.0f - v29;
    a3.Y = -0.0f - v24;
    v44 = v43[1];
    v45 = (float)(v42 * v42) + (float)(v44 * v44);
    v62 = v45;
    if ( v45 == 1.0f )
    {
      if ( v43[2] == 0.0f )
      {
        v54 = *v43;
        v56 = v43[1];
        v58 = v43[2];
        return cos(this.WallClimbingVerticalStartAngle * 0.017453292f) <= fabs(v58 * a3.Z + v56 * a3.Y + v54 * a3.X);
      }
      v54 = v42;
      goto LABEL_55;
    }
    if ( v45 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
    {
      v63 = 3.0f;
      v46 = 1.0f / fsqrt(v62);
      a2.X = (float)(3.0f - (float)((float)(v46 * v62) * v46)) * (float)(v46 * 0.5f);
      v54 = *v43 * a2.X;
      v44 = v43[1] * a2.X;
  LABEL_55:
      v56 = v44;
      goto LABEL_56;
    }
    v54 = 0.0f;
    v56 = 0.0f;
  LABEL_56:
    v58 = 0.0f;
    return cos(this.WallClimbingVerticalStartAngle * 0.017453292f) <= fabs(v58 * a3.Z + v56 * a3.Y + v54 * a3.X);
  }

  public unsafe void CheckDoubleJump()
  {
    int v2 = default; // edi
    int v3 = default; // eax
    uint v4 = default; // eax
    TdPawn v5 = default; // eax
    TdPawn v6 = default; // edx
    float v7 = default; // xmm2_4
    float v8 = default; // xmm1_4
    float v9 = default; // xmm0_4
    Vector *v10; // edx
    float v11 = default; // xmm0_4
    float v12 = default; // xmm2_4
    float v13 = default; // [esp+0h] [ebp-34h]
    Vector v14 = default; // [esp+4h] [ebp-30h]
    float v15 = default; // [esp+14h] [ebp-20h]
  
    v4 = this.bHasReachedWall.AsBitfield(3);
    if ( (v4 & 4) == 0 && (v4 & 2) != 0 )
    {
      v5 = this.PawnOwner;
      if ( this.MinUpwardsVelocityToDoubleJump > v5.Velocity.Z && (float)(this.PossibleEdgeDestination.Z - this.GroundZLoc) < 480.0f )
      {
        if ( (float)((float)((float)((float)(this.PossibleEdgeDestination.Z - (float)(v5.CylinderComponent.CollisionHeight + v5.Location.Z)) + 4.0f) * this.WallClimbingGravity) * 4.0f) < 0.0099999998d )
          v13 = (float)(0.0099999998d);
        else
          v13 = (float)((float)((float)(this.PossibleEdgeDestination.Z - (float)(v5.CylinderComponent.CollisionHeight + v5.Location.Z)) + 4.0f) * this.WallClimbingGravity) * 4.0f;
        v5.Velocity.Z = sqrt(v13);
        v6 = this.PawnOwner;
        v7 = v6.Velocity.Y;
        v8 = v6.Velocity.Z;
        v9 = v6.Velocity.X;
fixed(var ptr1 =&v6.Velocity)
        v10 =  ptr1;
        v11 = (float)((float)(v9 * v9) + (float)(v7 * v7)) + (float)(v8 * v8);
        if ( v11 == 1.0f )
        {
          v14 = *v10;
        }
        else if ( v11 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
        {
          v12 = 1.0f / fsqrt(v11);
          v15 = (float)(3.0f - (float)((float)(v12 * v11) * v12)) * (float)(v12 * 0.5f);
          v14.X = v10->X * v15;
          v14.Y = v10->Y * v15;
          v14.Z = v10->Z * v15;
        }
        else
        {
          v14.X = 0.0f;
          v14.Y = 0.0f;
          v14.Z = 0.0f;
        }
        this.PawnOwner.Acceleration = v14;
        SetFromBitfield(ref this.bHasReachedWall, 3, this.bHasReachedWall.AsBitfield(3) | (4u));
        v2 = this.VfTableObject.Dummy;
        CallUFunction(this.PerformDoubleJump, this, v3);
      }
    }
  }

  public unsafe bool DetectPossibleHandPlant()
  {
    TdPawn v2 = default; // eax
    double v3 = default; // st7
    float v4 = default; // edx
    float v5 = default; // xmm3_4
    float v6 = default; // xmm1_4
    float v7 = default; // xmm0_4
    float v8 = default; // ecx
    float v9 = default; // xmm2_4
    uint v10 = default; // edx
    float v11 = default; // xmm0_4
    float v12 = default; // xmm1_4
    float v13 = default; // edx
    float v14 = default; // eax
    Vector v16 = default; // [esp-18h] [ebp-48h]
    Rotator v17 = default; // [esp-Ch] [ebp-3Ch]
    float a11 = default; // [esp+0h] [ebp-30h]
    Vector a2 = default; // [esp+Ch] [ebp-24h] BYREF
    Vector a4 = default; // [esp+18h] [ebp-18h] BYREF
    Vector a3 = default; // [esp+24h] [ebp-Ch] BYREF
  
    v2 = this.PawnOwner;
    v3 = this.HandPlantCheckDistance;
    v4 = v2.MoveLedgeLocation.Y;
    v5 = v2.MoveNormal.X;
    v6 = v2.MoveNormal.Y;
    v7 = v2.MoveNormal.Z;
    a2.X = v2.MoveLedgeLocation.X;
    v8 = v2.MoveLedgeLocation.Z;
    a2.Y = v4;
    v9 = v2.CylinderComponent.CollisionRadius;
    v10 = v2.Rotation.Pitch;
    a2.Z = v8;
    a11 = (float)v3;
    v17.Pitch = v10;
    *(_QWORD *)&v17.Yaw = *(_QWORD *)&v2.Rotation.Yaw;// Copy as a 64bit value to assign both yaw and roll
    v11 = (float)((float)(v7 * v9) + v8) + 215.0f;
    v12 = (float)(v6 * v9) + a2.Y;
    a2.X = a2.X + (float)(v5 * v9);
    v16.X = a2.X;
    a2.Y = v12;
    *(_QWORD *)&v16.Y = __PAIR64__(LODWORD(v11), LODWORD(v12));
    a2.Z = v11;
    this.PawnOwner.MoveLedgeResult = this.FindAutoMoveLedge(&a2, &a3, &a4, v16, v17, a11, 1);
    if ( this.PawnOwner.MoveLedgeResult != 2 )
      return false;
    v13 = a2.Y;
    v14 = a2.Z;
    this.PossibleEdgeDestination.X = a2.X;
    this.PossibleEdgeDestination.Y = v13;
    this.PossibleEdgeDestination.Z = v14;
    return true;
  }

  public override unsafe void PrePerformPhysics(float DeltaTime)
  {
    TdPawn v3 = default; // edi
    int v4 = default; // esi
    int v5 = default; // eax
    TdPawn v6 = default; // eax
    float v7 = default; // ecx
    float v8 = default; // edx
    float v9 = default; // xmm5_4
    float v10 = default; // xmm1_4
    float v11 = default; // xmm0_4
    float v12 = default; // xmm1_4
    TdPawn v13 = default; // eax
    float v14 = default; // [esp+10h] [ebp-18h]
    float v15 = default; // [esp+14h] [ebp-14h]
    float v16 = default; // [esp+18h] [ebp-10h] BYREF
    float v17 = default; // [esp+1Ch] [ebp-Ch]
    float v18 = default; // [esp+20h] [ebp-8h]
    int v19 = default; // [esp+24h] [ebp-4h]
  
    this.FrictionModifier = 0.0f;
    base.PrePerformPhysics(DeltaTime);
    v3 = this.PawnOwner;
    if ( v3.Physics == 2 )
    {
      v4 = v3.VfTableObject.Dummy;
      LOBYTE(v16) = 2;
      v19 = default;
      v17 = 0.0f;
      v18 = 0.0f;
      CallUFunction(v3.SetMove, v3, v5, &v16, 0);
    }
    else
    {
      if ( (this.bHasReachedWall.AsBitfield(3) & 2) == 0 )
      {
        if ( this.DetectPossibleHandPlant() )// TdMove_WallClimb::DetectPossibleHandPlant
          this.FoundPossibleHandPlant();
      }
      this.CheckDoubleJump();// CheckDoubleJump
      if ( (this.bHasReachedWall.AsBitfield(3) & 1) != 0 )
      {
        v6 = this.PawnOwner;
        v7 = v6.Velocity.X;
        v17 = v6.Velocity.Y;
        v8 = v6.Floor.X;
        v9 = v17;
        v16 = v7;
        v18 = v6.Velocity.Z;
        v10 = v18;
        v15 = v6.Floor.Z;
        v14 = v6.Floor.Y;
        v11 = (float)((float)(v18 * v15) + (float)(v7 * v8)) + (float)(v14 * v17);
        v16 = v7 - (float)(v11 * v8);
        v6.Velocity.X = v16;
        v17 = v9 - (float)(v14 * v11);
        v12 = v10 - (float)(v15 * v11);
        v18 = v12;
        v6.Velocity.Y = v17;
        v6.Velocity.Z = v12;
        this.FrictionModifier = this.WallClimbingVerticalFriction;
      }
      v13 = this.PawnOwner;
      v16 = 0.0f;
      v13 = (TdPawn )((byte *)v13 + 0x10C);// v13 points to Acceleration now
      v13.VfTableObject.Dummy = default;
      v17 = 0.0f;
      v18 = 0.0f;
      v13.ObjectInternalInteger = default;
      v13.ObjectFlags_A = default;
      this.PawnOwner.Acceleration.Z = -0.0f - this.WallClimbingGravity;
    }
  }
}
}
