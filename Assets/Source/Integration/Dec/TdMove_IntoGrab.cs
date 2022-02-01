// NO OVERWRITE

namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdMove_IntoGrab
{
  public override unsafe bool TestCanTransitionInto_Maybe()
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
    deltaAndVel_Scaled_Saturated = (float)((float)(deltaAndVel + (float)(0.0f * 0.0f)) * 0.0049999999d);
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

    v19 = ClassT<TdMovementVolume>();//E_GetClass_();
    return E_TryFindPhysicsVolumeAtThisLocation_Maybe(this.PawnOwner.MoveLedgeLocation, v19) == null;
  }

  public override unsafe void CheckAutoMoves()
  {
    TdPawn v2 = default; // ecx
    TdPawn v3 = default; // ecx
    double v4 = default; // st6
    double v5 = default; // st5
    float v6 = default; // edx
    float v7 = default; // eax
    float v8 = default; // edx
    TdPawn v9 = default; // eax
    float v10 = default; // ecx
    float v11 = default; // edx
    TdPawn v12 = default; // eax
    float v13 = default; // ecx
    float v14 = default; // edx
    TdPawn v15 = default; // ecx
    float v16 = default; // xmm1_4
    float v17 = default; // edx
    float v18 = default; // xmm0_4
    float v19 = default; // edx
    float v20 = default; // eax
    float v21 = default; // xmm2_4
    float v22 = default; // xmm1_4
    float v23 = default; // xmm3_4
    float v24 = default; // xmm0_4
    float v25 = default; // xmm2_4
    float v26 = default; // eax
    float v27 = default; // xmm2_4
    float v28 = default; // xmm0_4
    //Vector *v29; // esi
    float BaseExtent = default; // [esp+Ch] [ebp-44h]
    float v31 = default; // [esp+10h] [ebp-40h]
    Vector a3 = default; // [esp+14h] [ebp-3Ch] BYREF
    Vector a2 = default; // [esp+24h] [ebp-2Ch] BYREF
    Vector a4 = default; // [esp+30h] [ebp-20h] BYREF
    float v35 = default; // [esp+40h] [ebp-10h]
  
    v2 = this.PawnOwner;
    if ( (fabs(v2.Velocity.X) >= 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ || fabs(v2.Velocity.Y) >= 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ || fabs(v2.Velocity.Z) >= 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/) && v2.OldMovementState != MOVE_GrabTransfer )
    {
      this.PawnOwner.MoveLedgeResult = this.FindAutoMoveLedge(ref a2, ref a3, ref a4, v2.Location, v2.Rotation, this.HandPlantCheckDistance, 1);
      if ( this.PawnOwner.MoveLedgeResult == 2 )
      {
        if ( this.CanDoMove() )// UTdMove_IntoGrab::CanDoMove
        {
          v3 = this.PawnOwner;
          v4 = v3.Location.Y - v3.MoveLocation.Y;
          v5 = v3.Location.X - v3.MoveLocation.X;
          if ( sqrt(v5 * v5 + v4 * v4) > this.MinGrabLedgeAdjustDistance )
          {
            v6 = a2.Y;
            v3.MoveLedgeLocation.X = a2.X;
            v7 = a2.Z;
            v3.MoveLedgeLocation.Y = v6;
            v8 = a3.Y;
            v3.MoveLedgeLocation.Z = v7;
            v9 = this.PawnOwner;
            v9.MoveLedgeNormal.X = a3.X;
            v10 = a3.Z;
            v9.MoveLedgeNormal.Y = v8;
            v11 = a4.X;
            v9.MoveLedgeNormal.Z = v10;
            v12 = this.PawnOwner;
            v13 = a4.Y;
            v12.MoveNormal.X = v11;
            v14 = a4.Z;
            v12.MoveNormal.Y = v13;
            v12.MoveNormal.Z = v14;
            v15 = this.PawnOwner;
            v16 = v15.MoveNormal.X;
            v17 = v15.MoveLedgeLocation.X;
            BaseExtent = v15.CylinderComponent.CollisionRadius;
            v18 = (float)(v16 * v16) + (float)(v15.MoveNormal.Y * v15.MoveNormal.Y);
            a2.Y = v15.MoveLedgeLocation.Y;
            a2.X = v17;
            a2.Z = v15.MoveLedgeLocation.Z;
            v35 = v18;
            if ( v18 == 1.0f )
            {
              if ( v15.MoveNormal.Z == 0.0f )
              {
                v19 = v15.MoveNormal.Y;
                a3.X = v15.MoveNormal.X;
                v20 = v15.MoveNormal.Z;
                a3.Y = v19;
                a3.Z = v20;
  LABEL_16:
                v31 = this.CalculateRelativeExtent(BaseExtent);
                v22 = a2.Z - this.GrabDesiredLedgeOffset.Z;
                v23 = a3.Y * (float)(v31 + BaseExtent);
                v24 = a3.Z * (float)(v31 + BaseExtent);
                v25 = a2.Y;
                a2.X = a2.X + (float)(a3.X * (float)(v31 + BaseExtent));
                v26 = a2.X;
                this.PreciseLocation.X = a2.X;
                v27 = v25 + v23;
                a2.Y = v27;
                this.PreciseLocation.Y = v27;
                v28 = v24 + v22;
                a2.Z = v28;
                this.PreciseLocation.Z = v28;
                this.PawnOwner.MoveLocation.X = v26;
                this.PawnOwner.MoveLocation.Y = v27;
                this.PawnOwner.MoveLocation.Z = v28;
                return;
              }
              a3.X = v16;
              a3.Y = v15.MoveNormal.Y;
            }
            else if ( v18 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
            {
              a3.X = 3.0f;
              v21 = 1.0f / fsqrt(v35);
              a4.X = (float)(3.0f - (float)((float)(v21 * v35) * v21)) * (float)(v21 * 0.5f);
              a3.X = v15.MoveNormal.X * a4.X;
              a3.Y = v15.MoveNormal.Y * a4.X;
            }
            else
            {
              a3.X = 0.0f;
              a3.Y = 0.0f;
            }
            a3.Z = 0.0f;
            v31 = this.CalculateRelativeExtent(BaseExtent);
            v22 = a2.Z - this.GrabDesiredLedgeOffset.Z;
            v23 = a3.Y * (float)(v31 + BaseExtent);
            v24 = a3.Z * (float)(v31 + BaseExtent);
            v25 = a2.Y;
            a2.X = a2.X + (float)(a3.X * (float)(v31 + BaseExtent));
            v26 = a2.X;
            this.PreciseLocation.X = a2.X;
            v27 = v25 + v23;
            a2.Y = v27;
            this.PreciseLocation.Y = v27;
            v28 = v24 + v22;
            a2.Z = v28;
            this.PreciseLocation.Z = v28;
            this.PawnOwner.MoveLocation.X = v26;
            this.PawnOwner.MoveLocation.Y = v27;
            this.PawnOwner.MoveLocation.Z = v28;
            return;
          }
        }
      }
    }
  }
}
}
