namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdMove_IntoGrab
{
  public override unsafe bool CanDoMove()
  {
    TdPawn v2 = default; // eax
    float locDeltaX = default; // xmm5_4
    float offsetDeltaZ = default; // xmm0_4
    float velY = default; // ecx
    float locDeltaY = default; // xmm4_4
    float offsetAndLocDelta = default; // xmm7_4
    float locDeltaYSqr = default; // xmm3_4
    float locDelta2DSqr = default; // xmm0_4
    float velZ = default; // edx
    float locDeltaXNrml = default; // xmm0_4
    float iSqrt = default; // xmm2_4
    float deltaAndVel = default; // xmm1_4
    float clampVal = default; // xmm0_4
    float deltaAndVel_Scaled_Saturated = default; // xmm1_4
    TdPawn pawn = default; // eax
    TdPawn pawn2 = default; // ecx
    Object v19 = default; // eax
    float offsetDeltaZ2 = default; // [esp+14h] [ebp-4Ch]
    float nrmlz = default; // [esp+18h] [ebp-48h]
    Vector dir = default; // [esp+28h] [ebp-38h] BYREF
    float velX = default; // [esp+34h] [ebp-2Ch]
    float velY2 = default; // [esp+38h] [ebp-28h]
    float velZ2 = default; // [esp+3Ch] [ebp-24h]
    float v26 = default; // [esp+40h] [ebp-20h]
    float locDelta2DSqr2 = default; // [esp+50h] [ebp-10h]
  
    v2 = this.PawnOwner;
    if ( v2.EvadeTimer > 0.0f )
      return false;
    locDeltaX = v2.MoveLedgeLocation.X - v2.Location.X;
    offsetDeltaZ = v2.MoveLedgeLocation.Z - this.GrabDesiredLedgeOffset.Z;
    velY = v2.Velocity.Y;
    locDeltaY = v2.MoveLedgeLocation.Y - v2.Location.Y;
    offsetAndLocDelta = offsetDeltaZ - v2.Location.Z;
    offsetDeltaZ2 = offsetDeltaZ;
    locDeltaYSqr = locDeltaY * locDeltaY;
    locDelta2DSqr = (float)(locDeltaX * locDeltaX) + (float)(locDeltaY * locDeltaY);
    velX = v2.Velocity.X;
    velZ = v2.Velocity.Z;
    velY2 = velY;
    velZ2 = velZ;
    locDelta2DSqr2 = locDelta2DSqr;
    if ( locDelta2DSqr == 1.0f )
    {
      if ( offsetAndLocDelta == 0.0f )
      {
        dir.X = locDeltaX;
        locDeltaXNrml = locDeltaX;
        dir.Y = locDeltaY;
        dir.Z = 0.0f;
      }
      else
      {
        locDeltaXNrml = locDeltaX;
      }
    }
    else if ( locDelta2DSqr >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
    {
      v26 = 3.0f;
      iSqrt = 1.0f / fsqrt(locDelta2DSqr2);
      nrmlz = (float)(3.0f - (float)((float)(iSqrt * locDelta2DSqr2) * iSqrt)) * (float)(iSqrt * 0.5f);
      locDeltaYSqr = locDeltaY * locDeltaY;
      locDeltaXNrml = nrmlz * locDeltaX;
      locDeltaY = locDeltaY * nrmlz;
    }
    else
    {
      locDeltaXNrml = 0.0f;
      locDeltaY = 0.0f;
    }
    deltaAndVel = (float)(velY2 * locDeltaY) + (float)(locDeltaXNrml * velX);
    clampVal = (float)(0.40000001d);
    deltaAndVel_Scaled_Saturated = (float)(deltaAndVel + (float)(0.0f * 0.0f)) * 0.0049999999d;
    if ( deltaAndVel_Scaled_Saturated < 0.40000001d || ((clampVal = 1.0f) is object && deltaAndVel_Scaled_Saturated > 1.0f) )
      deltaAndVel_Scaled_Saturated = clampVal;
    if ( (float)((float)((float)(offsetAndLocDelta * offsetAndLocDelta) + (float)(locDeltaX * locDeltaX)) + locDeltaYSqr) > (float)((float)(this.IntoGrabMaxDistance * deltaAndVel_Scaled_Saturated)
                                                                                                                                  * (float)(this.IntoGrabMaxDistance * deltaAndVel_Scaled_Saturated)) )
      return false;                                   // Outside of max range
    pawn = this.PawnOwner;
    if ( pawn.Velocity.Z >= 0.0f && (pawn.MoveLedgeLocation.Z > (float)(pawn.CylinderComponent.CollisionHeight + pawn.Location.Z) || pawn.MovementState != MOVE_WallClimbing) )
      return false;
    if ( (float)(pawn.MoveLedgeLocation.Z - pawn.Location.Z) < 0.0f )
      return false;
    if ( this.GrabMinGrabableZNormal > pawn.MoveLedgeNormal.Z )
      return false;
    pawn.Rotation.Vector(&dir);
    pawn2 = this.PawnOwner;
    if ( cos(this.IntoGrabMaxAngle * 0.017453292f) > -pawn2.MoveNormal.X * dir.X + -pawn2.MoveNormal.Y * dir.Y + -pawn2.MoveNormal.Z * dir.Z
      || this.IntoGrabMinInitialAlignSpeed > (float)((float)((float)(pawn2.Velocity.Z * (float)(-0.0f - pawn2.MoveNormal.Z)) + (float)(pawn2.Velocity.Y * (float)(-0.0f - pawn2.MoveNormal.Y)))
                                                    + (float)(pawn2.Velocity.X * (float)(-0.0f - pawn2.MoveNormal.X)))
      || pawn2.Velocity.Z < 0.0f && offsetDeltaZ2 > pawn2.Location.Z )
    {
      return false;
    }
    v19 = E_GetClass_TdMovementVolume();
    return E_TryFindPhysicsVolumeAtThisLocation_Maybe(this.PawnOwner.MoveLedgeLocation, v19) == 0;
  }

  public override unsafe void CheckAutoMoves(float DeltaTime)
  {
    TdPawn v3 = default; // ecx
    TdPawn v4 = default; // ecx
    double v5 = default; // st6
    double v6 = default; // st5
    float v7 = default; // edx
    float v8 = default; // eax
    float v9 = default; // edx
    TdPawn v10 = default; // eax
    float v11 = default; // ecx
    float v12 = default; // edx
    TdPawn v13 = default; // eax
    float v14 = default; // ecx
    float v15 = default; // edx
    TdPawn v16 = default; // ecx
    float v17 = default; // xmm1_4
    float v18 = default; // edx
    float v19 = default; // xmm0_4
    float v20 = default; // edx
    float v21 = default; // eax
    float v22 = default; // xmm2_4
    float v23 = default; // xmm1_4
    float v24 = default; // xmm3_4
    float v25 = default; // xmm0_4
    float v26 = default; // xmm2_4
    float v27 = default; // eax
    float v28 = default; // xmm2_4
    float v29 = default; // xmm0_4
    Vector *v30; // esi
    float BaseExtent = default; // [esp+Ch] [ebp-44h]
    float v32 = default; // [esp+10h] [ebp-40h]
    Vector a3 = default; // [esp+14h] [ebp-3Ch] BYREF
    Vector a2 = default; // [esp+24h] [ebp-2Ch] BYREF
    Vector a4 = default; // [esp+30h] [ebp-20h] BYREF
    float v36 = default; // [esp+40h] [ebp-10h]
  
    v3 = this.PawnOwner;
    if ( (fabs(v3.Velocity.X) >= 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ || fabs(v3.Velocity.Y) >= 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ || fabs(v3.Velocity.Z) >= 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/) && v3.OldMovementState != MOVE_GrabTransfer )
    {
      this.PawnOwner.MoveLedgeResult = this.FindAutoMoveLedge(&a2, &a3, &a4, v3.Location, v3.Rotation, this.HandPlantCheckDistance, 1);
      if ( this.PawnOwner.MoveLedgeResult == 2 )
      {
        if ( this.0x011F9C30() )// 0x011F9C30, UTdMove_IntoGrab::IsMoveLedgeReachable_OrSomething
        {
          v4 = this.PawnOwner;
          v5 = v4.Location.Y - v4.MoveLocation.Y;
          v6 = v4.Location.X - v4.MoveLocation.X;
          if ( sqrt(v6 * v6 + v5 * v5) > this.MinGrabLedgeAdjustDistance )
          {
            v7 = a2.Y;
            v4.MoveLedgeLocation.X = a2.X;
            v8 = a2.Z;
            v4.MoveLedgeLocation.Y = v7;
            v9 = a3.Y;
            v4.MoveLedgeLocation.Z = v8;
            v10 = this.PawnOwner;
            v10.MoveLedgeNormal.X = a3.X;
            v11 = a3.Z;
            v10.MoveLedgeNormal.Y = v9;
            v12 = a4.X;
            v10.MoveLedgeNormal.Z = v11;
            v13 = this.PawnOwner;
            v14 = a4.Y;
            v13.MoveNormal.X = v12;
            v15 = a4.Z;
            v13 = (TdPawn )((byte *)v13 + 0x630);// Ptr to MoveNormal
            *(float *)&v13.ObjectInternalInteger = v14;
            *(float *)&v13.ObjectFlags_A = v15;
            v16 = this.PawnOwner;
            v17 = v16.MoveNormal.X;
            v18 = v16.MoveLedgeLocation.X;
            BaseExtent = v16.CylinderComponent.CollisionRadius;
            v19 = (float)(v17 * v17) + (float)(v16.MoveNormal.Y * v16.MoveNormal.Y);
            a2.Y = v16.MoveLedgeLocation.Y;
            a2.X = v18;
            a2.Z = v16.MoveLedgeLocation.Z;
            v36 = v19;
            if ( v19 == 1.0f )
            {
              if ( v16.MoveNormal.Z == 0.0f )
              {
                v20 = v16.MoveNormal.Y;
                a3.X = v16.MoveNormal.X;
                v21 = v16.MoveNormal.Z;
                a3.Y = v20;
                a3.Z = v21;
  LABEL_16:
                v32 = this.CalculateRelativeExtent(BaseExtent);
                v23 = a2.Z - this.GrabDesiredLedgeOffset.Z;
                v24 = a3.Y * (float)(v32 + BaseExtent);
                v25 = a3.Z * (float)(v32 + BaseExtent);
                v26 = a2.Y;
                a2.X = a2.X + (float)(a3.X * (float)(v32 + BaseExtent));
                v27 = a2.X;
                this.PreciseLocation.X = a2.X;
                v28 = v26 + v24;
                a2.Y = v28;
                this.PreciseLocation.Y = v28;
                v29 = v25 + v23;
                a2.Z = v29;
                this.PreciseLocation.Z = v29;
fixed(var ptr1 =&this.PawnOwner.MoveLocation)
                v30 =  ptr1;
                v30->X = v27;
                v30->Y = v28;
                v30->Z = v29;
                return;
              }
              a3.X = v17;
              a3.Y = v16.MoveNormal.Y;
            }
            else if ( v19 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
            {
              a3.X = 3.0f;
              v22 = 1.0f / fsqrt(v36);
              a4.X = (float)(3.0f - (float)((float)(v22 * v36) * v22)) * (float)(v22 * 0.5f);
              a3.X = v16.MoveNormal.X * a4.X;
              a3.Y = v16.MoveNormal.Y * a4.X;
            }
            else
            {
              a3.X = 0.0f;
              a3.Y = 0.0f;
            }
            a3.Z = 0.0f;
            goto LABEL_16;
          }
        }
      }
    }
  }
}
}
