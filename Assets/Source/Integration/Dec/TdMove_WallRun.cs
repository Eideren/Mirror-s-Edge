// NO OVERWRITE

namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdMove_WallRun
{
  public unsafe bool FindWallSide(EMovement WallRunSide, ref LedgeHitInfo out_LedgeHit)
  {
    TdPawn v4 = default; // ecx
    float v5 = default; // xmm5_4
    TdPawn v6 = default; // eax
    float v7 = default; // xmm0_4
    float v8 = default; // xmm2_4
    float v9 = default; // xmm0_4
    TdPawn v10 = default; // eax
    float v11 = default; // xmm3_4
    float v12 = default; // xmm2_4
    float v13 = default; // xmm0_4
    float v14 = default; // xmm4_4
    float v15 = default; // xmm0_4
    float v16 = default; // xmm4_4
    float v17 = default; // xmm2_4
    float v18 = default; // xmm1_4
    float v19 = default; // xmm2_4
    float v20 = default; // xmm0_4
    float v21 = default; // xmm3_4
    float v22 = default; // xmm0_4
    float v23 = default; // xmm7_4
    float v24 = default; // xmm6_4
    float v25 = default; // xmm0_4
    float v26 = default; // xmm1_4
    float v27 = default; // xmm7_4
    float v28 = default; // xmm6_4
    float v29 = default; // xmm0_4
    float v30 = default; // xmm3_4
    float v31 = default; // xmm2_4
    TdPawn v32 = default; // ecx
    float v33 = default; // xmm7_4
    float v34 = default; // xmm6_4
    float v35 = default; // xmm0_4
    float v36 = default; // xmm3_4
    Vector *v37; // eax
    TdPawn v38 = default; // ecx
    float v39 = default; // xmm5_4
    float v40 = default; // xmm4_4
    float v41 = default; // xmm0_4
    float v42 = default; // xmm2_4
    float v43 = default; // xmm4_4
    (float, float) v44 = default; // rdi
    float v45 = default; // ebx
    float v46 = default; // xmm0_4
    float v47 = default; // xmm2_4
    double v48 = default; // st7
    float v49 = default; // xmm4_4
    float v50 = default; // xmm0_4
    float v51 = default; // xmm2_4
    float v52 = default; // xmm0_4
    float v53 = default; // xmm1_4
    float v54 = default; // xmm0_4
    float v55 = default; // xmm3_4
    double v56 = default; // st7
    Vector v58 = default; // [esp-10h] [ebp-F8h]
    Vector v59 = default; // [esp-4h] [ebp-ECh]
    float v60 = default; // [esp+0h] [ebp-E8h]
    float Tolerance = default; // [esp+4h] [ebp-E4h]
    Vector v62 = default; // [esp+14h] [ebp-D4h] BYREF
    Vector a4 = default; // [esp+24h] [ebp-C4h] BYREF
    float v64 = default; // [esp+30h] [ebp-B8h]
    float v65 = default; // [esp+34h] [ebp-B4h]
    Vector v66 = default; // [esp+38h] [ebp-B0h]
    Vector v67 = default; // [esp+48h] [ebp-A0h] BYREF
    Vector a5 = default; // [esp+58h] [ebp-90h] BYREF
    Vector a3 = default; // [esp+64h] [ebp-84h] BYREF
    Vector v70 = default; // [esp+70h] [ebp-78h]
    Vector a2 = default; // [esp+80h] [ebp-68h] BYREF
    CheckResult v72 = default; // [esp+8Ch] [ebp-5Ch] BYREF
    int v73 = default; // [esp+D4h] [ebp-14h]
    float v74 = default; // [esp+D8h] [ebp-10h]
  
    v72.Item = -1;
    v72.LevelIndex = -1;
    v4 = this.PawnOwner;
    v72.Next = default;
    v72.Actor = default;
    v72.Material = default;
    v72.PhysMaterial = default;
    v72.Component = default;
    v72.BoneName = default;
    v72.Level = default;
    v72.bStartPenetrating = default;
    v73 = default;
    v72.Location.X = 0.0f;
    v72.Location.Y = 0.0f;
    v72.Location.Z = 0.0f;
    v72.Normal.X = 0.0f;
    v72.Normal.Y = 0.0f;
    v72.Normal.Z = 0.0f;
    v72.Time = 1.0f;
    v4.Rotation.Vector(&a2);
    if ( WallRunSide == MOVE_WallRunningRight )
      v5 = -1.0f;
    else
      v5 = 1.0f;
    v6 = this.PawnOwner;
    a4.X = v6.Location.X;
    a4.Y = v6.Location.Y;
    v7 = this.WallRunningMinWallHeight;
    a4.Z = v6.Location.Z;
    v8 = this.WallRunningStrafeCheckDistance;
    a4.Z = (float)(v7 - 2.0f) + a4.Z;
    v9 = a4.Z - v6.CylinderComponent.CollisionHeight;
    v62.Z = (float)((float)(a2.X * 0.0f) - (float)(a2.Y * 0.0f)) * v5;
    v62.X = (float)(a2.Y - (float)(a2.Z * 0.0f)) * v5;
    v62.Y = (float)((float)(a2.Z * 0.0f) - a2.X) * v5;
    a3.X = a4.X + (float)(v62.X * v8);
    a4.Z = v9;
    a3.Y = a4.Y + (float)(v62.Y * v8);
    a3.Z = (float)(v62.Z * v8) + v9;
    a5.X = v6.CylinderComponent.CollisionRadius;
    a5.Y = a5.X;
    a5.Z = 2.0f;
    if ( default == this.MovementLineCheck(ref v72, &a3, &a4, &a5, 9422) )
      return false;
    if ( cos(this.WallRunningStrafeStartAngle * 0.017453292f) > fabs(-v72.Normal.X * v62.X + -v72.Normal.Z * v62.Z + -v72.Normal.Y * v62.Y) )
      return false;
    v10 = this.PawnOwner;
    if ( v10.bIllegalLedgeTimer > 0.0f && (float)((float)((float)(v10.IllegalLedgeNormal.Z * v72.Normal.Z) + (float)(v10.IllegalLedgeNormal.Y * v72.Normal.Y)) + (float)(v10.IllegalLedgeNormal.X * v72.Normal.X)) < -0.98000002d )
      return false;
    v11 = WallRunSide == MOVE_WallRunningRight ? -1.0f : 1.0f;
    if ( (float)((float)((float)(v10.Velocity.Z * (float)((float)((float)(v72.Normal.X * 0.0f) - (float)(v72.Normal.Y * 0.0f)) * v11)) + (float)(v10.Velocity.Y * (float)((float)((float)(v72.Normal.Z * 0.0f) - v72.Normal.X) * v11)))
               + (float)(v10.Velocity.X * (float)((float)(v72.Normal.Y - (float)(v72.Normal.Z * 0.0f)) * v11))) < 0.0f )
      return false;
    v12 = this.WallRunningStrafeCheckDistance;
    v66.X = v72.Location.X;
    v66.Y = v72.Location.Y;
    a4.X = v10.Location.X;
    v66.Z = v72.Location.Z;
    a4.Y = v10.Location.Y;
    a4.Z = v10.Location.Z;
    a4.Z = (float)(v10.MaxStepHeight + a4.Z) + 2.0f;
    v13 = a4.Z - v10.CylinderComponent.CollisionHeight;
    a3.X = (float)(v12 * v62.X) + a4.X;
    a3.Y = (float)(v62.Y * v12) + a4.Y;
    a3.Z = (float)(v62.Z * v12) + v13;
    a4.Z = v13;
    if ( default == this.MovementLineCheck(ref v72, &a3, &a4, &a5, 9422) )
      return false;
    v14 = v66.Z - v72.Location.Z;
    v62.X = v66.X - v72.Location.X;
    v15 = (float)((float)(v62.X * v62.X) + (float)(v14 * v14)) + (float)((float)(v66.Y - v72.Location.Y) * (float)(v66.Y - v72.Location.Y));
    v62.Y = v66.Y - v72.Location.Y;
    v62.Z = v66.Z - v72.Location.Z;
    v70.X = v15;
    if ( v15 == 1.0f )
    {
      v67 = v62;
      v16 = v62.Z;
    }
    else
    {
      if ( v15 < SMALL_NUMBER )
        return false;
      v62.X = 3.0f;
      v64 = 0.5f;
      v17 = 1.0f / fsqrt(v70.X);
      v67.X = (float)(3.0f - (float)((float)(v17 * v70.X) * v17)) * (float)(v17 * 0.5f);
      v16 = v14 * v67.X;
    }
    if ( v16 < 0.95999998d )
      return false;
    v62.Y = v72.Location.Y - a4.Y;
    v64 = (float)(-fabs((float)(v72.Location.X - a4.X) * v72.Normal.X + (float)(v72.Location.Y - a4.Y) * v72.Normal.Y + v72.Normal.Z * 0.0f));
    v18 = (float)(v72.Location.X - a4.X) - (float)(v64 * v72.Normal.X);
    v19 = (float)(v72.Location.Y - a4.Y) - (float)(v72.Normal.Y * v64);
    v20 = -0.0f - (float)(v72.Normal.Z * v64);
    if ( (float)((float)((float)(v18 * a2.X) + (float)(a2.Z * v20)) + (float)(v19 * a2.Y)) <= 0.0f )
      v21 = -1.0f;
    else
      v21 = 1.0f;
    v62.X = v18 * v21;
    v62.Y = v19 * v21;
    v62.Z = v20 * v21;
    v62.Normalize();
    v22 = this.WallRunningVelocityStartLimit;
    v23 = this.WallRunningHorisontalAlignSpeed;
    v67.Z = v22 * v62.Z;
    v24 = (float)((float)(-0.0f - v72.Normal.X) * v23) + (float)(v62.X * v22);
    v65 = -0.0f - v72.Normal.Z;
    v25 = (float)((float)(-0.0f - v72.Normal.Y) * v23) + (float)(v62.Y * v22);
    v26 = (float)((float)(-0.0f - v72.Normal.Z) * v23) + v67.Z;
    v27 = v24;
    v28 = v25;
    v29 = (float)(v27 * v27) + (float)(v28 * v28);
    v62.X = v27;
    v62.Y = v28;
    v62.Z = v26;
    v70.X = v29;
    if ( v29 == 1.0f )
    {
      if ( v26 == 0.0f )
      {
        v70 = v62;
        v30 = v62.X;
        goto LABEL_30;
      }
      v30 = v27;
      v70.Z = 0.0f;
      v70.Y = v28;
      goto LABEL_29;
    }
    if ( v29 >= SMALL_NUMBER )
    {
      v62.X = 3.0f;
      v64 = 0.5f;
      v31 = 1.0f / fsqrt(v70.X);
      v67.X = (float)(3.0f - (float)((float)(v31 * v70.X) * v31)) * (float)(v31 * 0.5f);
      v28 = v28 * v67.X;
      v30 = v67.X * v27;
  LABEL_28:
      v70.Z = 0.0f;
      v70.Y = v28;
      goto LABEL_29;
    }
    v30 = 0.0f;
    v70.Y = 0.0f;
    v70.Z = 0.0f;
  LABEL_29:
    v70.X = v30;
  LABEL_30:
    v32 = this.PawnOwner;
    v33 = this.WallRunningStrafeCheckDistance;
    a4 = v32.Location;
    v34 = v30;
    v35 = 1.0f / (float)((float)((float)(v65 * v70.Z) + (float)((float)(-0.0f - v72.Normal.Y) * v70.Y)) + (float)((float)(-0.0f - v72.Normal.X) * v30));
    v36 = (float)(v32.MaxStepHeight * 0.5f) + a4.Z;
    v62.Y = (float)((float)(v70.Y * v33) * v35) + a4.Y;
    v62.X = (float)(v35 * (float)(v34 * v33)) + a4.X;
    v62.Z = (float)((float)(v70.Z * v33) * v35) + v36;
    a4.Z = v36;
    a3 = v62;
    v37 = v32.GetCylinderExtent(&v67);
    a5.X = v37->X;
    v38 = this.PawnOwner;
    a5.Y = v37->Y;
    a5.Z = v37->Z;
    a5.Z = a5.Z - (float)(v38.MaxStepHeight * 0.5f);
    if ( default == this.MovementLineCheck(ref v72, &a3, &a4, &a5, 9439) )
      return false;
    v39 = v72.Location.X - v66.X;
    v40 = v72.Location.Y - v66.Y;
    v41 = (float)(v40 * v40) + (float)(v39 * v39);
    v67.X = v72.Location.X - v66.X;
    v67.Y = v72.Location.Y - v66.Y;
    v67.Z = v72.Location.Z - v66.Z;
    v66.X = v41;
    if ( v41 == 1.0f )
    {
      if ( (float)(v72.Location.Z - v66.Z) == 0.0f )
      {
        v62 = v67;
        goto LABEL_40;
      }
      v62.X = v39;
      v62.Y = v40;
      goto LABEL_39;
    }
    if ( v41 >= SMALL_NUMBER )
    {
      v65 = 0.5f;
      v42 = 1.0f / fsqrt(v66.X);
      v67.X = (float)(3.0f - (float)((float)(v42 * v66.X) * v42)) * (float)(v42 * 0.5f);
      v62.X = v67.X * v39;
      v40 = v40 * v67.X;
  LABEL_38:
      v62.Y = v40;
      goto LABEL_39;
    }
    v62.X = 0.0f;
    v62.Y = 0.0f;
  LABEL_39:
    v62.Z = 0.0f;
  LABEL_40:
    if ( fabs(v62.X * v72.Normal.X + v62.Z * v72.Normal.Z + v62.Y * v72.Normal.Y) >= 0.1f )
      return false;
    v43 = v72.Normal.Y;
    var cpy2 = v72.Normal;
    v44 = (cpy2.Y, cpy2.Z);               // set Y&Z
    v45 = v72.Normal.X;
    v46 = (float)(v72.Normal.X * v72.Normal.X) + (float)(v43 * v43);
    v66.X = v46;
    if ( v46 == 1.0f )
    {
      if ( v72.Normal.Z == 0.0f )
      {
        v62.X = v72.Normal.X;
        v62.Y = v72.Normal.Y;
        v62.Z = 0.0f;
        goto LABEL_50;
      }
      v62.X = v72.Normal.X;
      v62.Y = v43;
      goto LABEL_49;
    }
    if ( v46 >= SMALL_NUMBER )
    {
      v65 = 0.5f;
      v47 = 1.0f / fsqrt(v66.X);
      v67.X = (float)(3.0f - (float)((float)(v47 * v66.X) * v47)) * (float)(v47 * 0.5f);
      v62.X = v67.X * v72.Normal.X;
      v43 = v72.Normal.Y * v67.X;
  LABEL_48:
      v62.Y = v43;
      goto LABEL_49;
    }
    v62.X = 0.0f;
    v62.Y = 0.0f;
  LABEL_49:
    v62.Z = 0.0f;
  LABEL_50:
    Tolerance = (float)(fabs(v62.Y));
    v60 = (float)(fabs(v62.X));
    v48 = Max(v60, Tolerance);
    v65 = (float)v48;
    if ( (float)(v65 * v65) < 1.0f )
      v64 = v65 * v65;
    else
      v64 = 1.0f;
    v49 = v70.Y;
    v50 = (float)(v49 * v49) + (float)(v70.X * v70.X);
    v74 = v50;
    v64 = (float)((v48 * sqrt(1.0f - v64) * 0.82842702d + 1.0f) * a5.X);
    if ( v50 != 1.0f )
    {
      if ( v50 < SMALL_NUMBER )
      {
        v52 = 0.0f;
        v53 = 0.0f;
        v51 = 0.0f;
  LABEL_61:
        v66.X = v52;
        v66.Y = v53;
        v66.Z = 0.0f;
        goto LABEL_62;
      }
      v66.X = 3.0f;
      v65 = 0.5f;
      v54 = fsqrt(v74);
      v67.X = (float)(3.0f - (float)((float)((float)(1.0f / v54) * v74) * (float)(1.0f / v54))) * (float)((float)(1.0f / v54) * 0.5f);
      v51 = 0.0f;
      v52 = v67.X * v70.X;
      v49 = v70.Y * v67.X;
  LABEL_60:
      v53 = v49;
      v66.X = v52;
      v66.Y = v53;
      v66.Z = 0.0f;
      goto LABEL_62;
    }
    v51 = 0.0f;
    if ( v70.Z != 0.0f )
    {
      v52 = v70.X;
      v53 = v49;
      v66.X = v52;
      v66.Y = v53;
      v66.Z = 0.0f;
      goto LABEL_62;
    }
    v66 = v70;
    v52 = v70.X;
    v53 = v70.Y;
    v51 = v70.Z;
  LABEL_62:
    v55 = v64;
    v56 = fabs(v66.Y * v62.Y + v66.X * v62.X + v66.Z * v62.Z);
    v65 = (float)v56;
    if ( v56 > 0.0f )
      v55 = v64 / v65;
    v59.X = v45;
    v59.Y = v44.Item1;                      // set Y&Z
    v59.Z = v44.Item2;                      // set Y&Z
    v58.X = v45;
    v58.Y = v44.Item1;                      // set Y&Z
    v58.Z = v44.Item2;                      // set Y&Z
    v67.X = (float)(v52 * v55) + v72.Location.X;
    v67.Y = (float)(v53 * v55) + v72.Location.Y;
    v67.Z = (float)(v51 * v55) + v72.Location.Z;
    E_FLedgeHitInfo_FillWith(ref out_LedgeHit, &v72, &v67, v58, v59);
    return true;
  }



  static uint hasinit_wallrun_pawn_collradius_const;
  static Vector wallrun_pawn_collradius_const;
  public unsafe EMovement FindWallForward(ref LedgeHitInfo out_LedgeHit)
  {
    TdPawn v3 = default; // ecx
    TdPawn v4 = default; // eax
    float v5 = default; // xmm1_4
    float v6 = default; // xmm3_4
    TdPawn v7 = default; // eax
    float v8 = default; // xmm0_4
    float v9 = default; // xmm2_4
    float v10 = default; // xmm0_4
    float v11 = default; // xmm5_4
    float v12 = default; // xmm0_4
    float v13 = default; // xmm1_4
    float v14 = default; // xmm2_4
    float v15 = default; // xmm3_4
    TdPawn v16 = default; // ecx
    float v17 = default; // xmm2_4
    float v18 = default; // xmm1_4
    float v19 = default; // xmm0_4
    //Vector *v20; // ecx
    float v21 = default; // xmm0_4
    float v22 = default; // xmm4_4
    float v23 = default; // xmm5_4
    float v24 = default; // xmm0_4
    float v25 = default; // xmm2_4
    float v26 = default; // xmm0_4
    float v27 = default; // xmm1_4
    float v28 = default; // xmm4_4
    float v29 = default; // xmm5_4
    float v30 = default; // xmm0_4
    float v31 = default; // xmm7_4
    float v32 = default; // xmm2_4
    TdPawn v33 = default; // ecx
    float v34 = default; // xmm6_4
    float v35 = default; // xmm0_4
    float v36 = default; // xmm3_4
    float v37 = default; // xmm5_4
    float v38 = default; // xmm4_4
    float v39 = default; // xmm0_4
    float v40 = default; // xmm2_4
    float v41 = default; // xmm5_4
    (float, float) v42 = default; // rdi
    float v43 = default; // ebx
    float v44 = default; // xmm0_4
    float v45 = default; // xmm2_4
    double v46 = default; // st7
    float v47 = default; // xmm4_4
    float v48 = default; // xmm0_4
    float v49 = default; // xmm0_4
    float v50 = default; // xmm1_4
    float v51 = default; // xmm2_4
    float v52 = default; // xmm2_4
    float v53 = default; // xmm3_4
    double v54 = default; // st7
    EMovement result = default; // al
    Vector v56 = default; // [esp-10h] [ebp-108h]
    Vector v57 = default; // [esp-4h] [ebp-FCh]
    float v58 = default; // [esp+0h] [ebp-F8h]
    float Tolerance = default; // [esp+4h] [ebp-F4h]
    Vector v60 = default; // [esp+14h] [ebp-E4h]
    float v61 = default; // [esp+14h] [ebp-E4h]
    float v62 = default; // [esp+14h] [ebp-E4h]
    Vector v63 = default; // [esp+14h] [ebp-E4h]
    float v64 = default; // [esp+14h] [ebp-E4h]
    float v65 = default; // [esp+18h] [ebp-E0h]
    float v66 = default; // [esp+24h] [ebp-D4h]
    float v67 = default; // [esp+24h] [ebp-D4h]
    float v68 = default; // [esp+24h] [ebp-D4h]
    float v69 = default; // [esp+24h] [ebp-D4h]
    float v70 = default; // [esp+24h] [ebp-D4h]
    float v71 = default; // [esp+28h] [ebp-D0h]
    float v72 = default; // [esp+28h] [ebp-D0h]
    float v73 = default; // [esp+28h] [ebp-D0h]
    Vector a4 = default; // [esp+2Ch] [ebp-CCh] BYREF
    Vector v75 = default; // [esp+38h] [ebp-C0h] BYREF
    Vector a2a = default; // [esp+48h] [ebp-B0h] BYREF
    Vector a3 = default; // [esp+54h] [ebp-A4h] BYREF
    Vector v78 = default; // [esp+60h] [ebp-98h]
    float v79 = default; // [esp+70h] [ebp-88h]
    float v80 = default; // [esp+74h] [ebp-84h]
    Vector a5 = default; // [esp+78h] [ebp-80h] BYREF
    Vector v82 = default; // [esp+84h] [ebp-74h] BYREF
    CheckResult v83 = default; // [esp+94h] [ebp-64h] BYREF
    int v84 = default; // [esp+DCh] [ebp-1Ch]
    float v85 = default; // [esp+E0h] [ebp-18h]
    float v86 = default; // [esp+E4h] [ebp-14h]
    float v87 = default; // [esp+E8h] [ebp-10h]
  
    v83.Item = -1;
    v83.LevelIndex = -1;
    v3 = this.PawnOwner;
    v83.Next = default;
    v83.Actor = default;
    v83.Material = default;
    v83.PhysMaterial = default;
    v83.Component = default;
    v83.BoneName = default;
    v83.Level = default;
    v83.bStartPenetrating = default;
    v84 = default;
    v83.Location.X = 0.0f;
    v83.Location.Y = 0.0f;
    v83.Location.Z = 0.0f;
    v83.Normal.X = 0.0f;
    v83.Normal.Y = 0.0f;
    v83.Normal.Z = 0.0f;
    v83.Time = 1.0f;
    v3.Rotation.Vector(&a2a);
    v4 = this.PawnOwner;
    a4 = v4.Location;
    v5 = v4.SpeedMaxBaseVelocity;
    v6 = 0.0f;
    v85 = (float)(sqrt(v4.Velocity.Y * v4.Velocity.Y + v4.Velocity.X * v4.Velocity.X));
    if ( (float)(v85 - v5) >= 0.0f )
      v6 = v85 - v5;
    v80 = (float)((float)((float)((float)(this.ContextMoveDistanceMultiplier - 1.0f) * v6) / (float)(v4.GroundSpeed - v5)) + 1.0f) * this.WallRunningForwardCheckDistance;
    a3.X = (float)(a2a.X * v80) + a4.X;
    a3.Y = a4.Y + (float)(a2a.Y * v80);
    a3.Z = (float)(a2a.Z * v80) + a4.Z;
    if ( (hasinit_wallrun_pawn_collradius_const & 1) == default )
    {
      hasinit_wallrun_pawn_collradius_const = hasinit_wallrun_pawn_collradius_const | (1u);
      wallrun_pawn_collradius_const.X = v4.CylinderComponent.CollisionRadius;
      wallrun_pawn_collradius_const.Y = wallrun_pawn_collradius_const.X;
      wallrun_pawn_collradius_const.Z = 2.0f;
    }

    var cpy = wallrun_pawn_collradius_const;
    if ( default == this.MovementLineCheck(ref v83, &a3, &a4, &cpy, 9422) )
      return 0;
    v66 = (float)((float)((float)(-0.0f - v83.Normal.X) * a2a.X) + (float)((float)(-0.0f - v83.Normal.Z) * a2a.Z)) + (float)((float)(-0.0f - v83.Normal.Y) * a2a.Y);
    if ( cos((90.0f - this.WallRunningForwardMinStartAngle) * 0.017453292f) > v66 )
      return 0;
    if ( v66 > cos(0.017453292f * (90.0f - this.WallRunningForwardMaxStartAngle)) )
      return 0;
    v7 = this.PawnOwner;
    if ( v7.bIllegalLedgeTimer > 0.0f && (float)((float)((float)(v7.IllegalLedgeNormal.Z * v83.Normal.Z) + (float)(v7.IllegalLedgeNormal.Y * v83.Normal.Y)) + (float)(v83.Normal.X * v7.IllegalLedgeNormal.X)) > 0.98000002d )
      return 0;
    a4.Z = (float)((float)(this.WallRunningMinWallHeight - 2.0f) - (float)((float)(1.0f - (float)((float)((float)((float)(-0.0f - v83.Normal.X) * a2a.X) + (float)((float)(-0.0f - v83.Normal.Z) * a2a.Z)) + (float)((float)(-0.0f - v83.Normal.Y) * a2a.Y))) * 50.0f))
         + a4.Z;
    v8 = a4.Z - v7.CylinderComponent.CollisionHeight;
    a3.X = (float)(a2a.X * v80) + a4.X;
    a3.Y = (float)(a2a.Y * v80) + a4.Y;
    a3.Z = (float)(a2a.Z * v80) + v8;
    a4.Z = v8;
    if ( default == this.MovementLineCheck(ref v83, &a3, &a4, &cpy, 9422) )
      return 0;
    v9 = v83.Normal.Y - (float)(v83.Normal.Z * 0.0f);
    v10 = (float)(v83.Normal.Z * 0.0f) - v83.Normal.X;
    v11 = (float)((float)((float)(v9 * a2a.X) + (float)((float)((float)(v83.Normal.X * 0.0f) - (float)(v83.Normal.Y * 0.0f)) * a2a.Z)) + (float)(v10 * a2a.Y)) >= 0.0f ? 1.0f : -1.0f;
    if ( (float)((float)((float)(this.PawnOwner.Velocity.Z * (float)((float)((float)(v83.Normal.X * 0.0f) - (float)(v83.Normal.Y * 0.0f)) * v11)) + (float)(this.PawnOwner.Velocity.Y * (float)(v10 * v11)))
               + (float)((float)(v9 * v11) * this.PawnOwner.Velocity.X)) < 0.0f )
      return 0;
    v75.X = v83.Location.X - a4.X;
    v75.Y = v83.Location.Y - a4.Y;
    v82 = v83.Location;
    v67 = (float)(-fabs((float)(v83.Location.X - a4.X) * v83.Normal.X + (float)(v83.Location.Y - a4.Y) * v83.Normal.Y + (float)(v83.Normal.Z * 0.0f)));
    v12 = (float)(v83.Location.X - a4.X) - (float)(v67 * v83.Normal.X);
    v13 = (float)(v83.Location.Y - a4.Y) - (float)(v83.Normal.Y * v67);
    v14 = -0.0f - (float)(v83.Normal.Z * v67);
    if ( (float)((float)((float)(v12 * a2a.X) + (float)(v13 * a2a.Y)) + (float)(a2a.Z * v14)) <= 0.0f )
      v15 = -1.0f;
    else
      v15 = 1.0f;
    v75.X = v12 * v15;
    v75.Y = v13 * v15;
    v75.Z = v15 * v14;
    v75.Normalize();
    v16 = this.PawnOwner;
    v17 = v16.Velocity.Y;
    v18 = v16.Velocity.Z;
    v19 = v16.Velocity.X;
/*fixed(var ptr1 =&v16.Velocity)
    v20 =  ptr1;*/
    v21 = (float)((float)(v19 * v19) + (float)(v17 * v17)) + (float)(v18 * v18);
    v87 = v21;
    if ( v21 == 1.0f )
    {
      v60 = v16.Velocity;
      v22 = v16.Velocity.X;
      v23 = v60.Y;
  LABEL_23:
      v24 = 0.0f;
      goto LABEL_24;
    }
    if ( v21 >= SMALL_NUMBER )
    {
      v78.X = 3.0f;
      v25 = 1.0f / fsqrt(v87);
      v61 = (float)(3.0f - (float)((float)(v25 * v87) * v25)) * (float)(v25 * 0.5f);
      v22 = v16.Velocity.X * v61;
      v23 = v61 * v16.Velocity.Y;
      v26 = v61 * v16.Velocity.Z;
      v60.X = v22;
      v60.Y = v23;
      v60.Z = v26;
      v24 = 0.0f;
      goto LABEL_24;
    }
    v24 = 0.0f;
    v22 = 0.0f;
    v23 = 0.0f;
    v60.X = 0.0f;
    v60.Y = 0.0f;
    v60.Z = 0.0f;
  LABEL_24:
    v27 = this.WallRunningMoveToIntoPositionDegreeThreshold * 0.011111111f;
    if ( v27 >= 0.0f && ((v24 = this.WallRunningMoveToIntoPositionDegreeThreshold * 0.011111111f) is object && v27 > 1.0f) )
      v79 = 1.0f;
    else
      v79 = v24;
    v86 = -0.0f - v83.Normal.X;
    v80 = -0.0f - v83.Normal.Y;
    v68 = -0.0f - v83.Normal.Z;
    v71 = Max(v79, (float)((float)((float)(-0.0f - v83.Normal.Z) * v60.Z) + (float)((float)(-0.0f - v83.Normal.Y) * v23)) + (float)((float)(-0.0f - v83.Normal.X) * v22));
    v79 = Max(v79, (float)((float)(v60.X * v75.X) + (float)(v60.Y * v75.Y)) + (float)(v60.Z * v75.Z));
    v28 = (float)((float)(v86 * v85) * v71) + (float)((float)(v75.X * v85) * v79);
    v29 = (float)((float)(v80 * v85) * v71) + (float)((float)(v75.Y * v85) * v79);
    v30 = (float)(v29 * v29) + (float)(v28 * v28);
    v75.X = v30;
    if ( v30 == 1.0f )
    {
      if ( (float)((float)((float)(v68 * v85) * v71) + (float)((float)(v75.Z * v85) * v79)) == 0.0f )
      {
        v78.X = v28;
        v31 = v28;
        v78.Y = (float)((float)(v80 * v85) * v71) + (float)((float)(v75.Y * v85) * v79);
        v78.Z = (float)((float)(v68 * v85) * v71) + (float)((float)(v75.Z * v85) * v79);
        goto LABEL_37;
      }
      v31 = v28;
      v78.Z = 0.0f;
      v78.Y = v29;
      goto LABEL_36;
    }
    if ( v30 >= SMALL_NUMBER )
    {
      v87 = 3.0f;
      v32 = 1.0f / fsqrt(v75.X);
      v62 = (float)(3.0f - (float)((float)(v32 * v75.X) * v32)) * (float)(v32 * 0.5f);
      v29 = v29 * v62;
      v31 = v62 * v28;
  LABEL_35:
      v78.Z = 0.0f;
      v78.Y = v29;
      goto LABEL_36;
    }
    v31 = 0.0f;
    v78.Y = 0.0f;
    v78.Z = 0.0f;
  LABEL_36:
    v78.X = v31;
  LABEL_37:
    v33 = this.PawnOwner;
    v34 = this.WallRunningForwardCheckDistance;
    a4 = v33.Location;
    v35 = 1.0f / (float)((float)((float)(v68 * v78.Z) + (float)(v80 * v78.Y)) + (float)(v86 * v31));
    v36 = (float)(v33.MaxStepHeight * 0.5f) + a4.Z;
    a3.Y = (float)((float)(v78.Y * v34) * v35) + a4.Y;
    a3.X = (float)(v35 * (float)(v31 * v34)) + a4.X;
    a4.Z = v36;
    a3.Z = (float)((float)(v78.Z * v34) * v35) + v36;
    v33.GetCylinderExtent(&a5);
    a5.Z = a5.Z - (float)(this.PawnOwner.MaxStepHeight * 0.5f);
    if ( default == this.MovementLineCheck(ref v83, &a3, &a4, &a5, 9439) )
      return 0;
    v37 = v82.X - v83.Location.X;
    v38 = v82.Y - v83.Location.Y;
    v39 = (float)(v38 * v38) + (float)(v37 * v37);
    v75.X = v82.X - v83.Location.X;
    v75.Y = v82.Y - v83.Location.Y;
    v75.Z = v82.Z - v83.Location.Z;
    if ( v39 == 1.0f )
    {
      if ( (float)(v82.Z - v83.Location.Z) == 0.0f )
      {
        v63 = v75;
        goto LABEL_47;
      }
      v63.X = v82.X - v83.Location.X;
      v63.Y = v38;
      goto LABEL_46;
    }
    if ( v39 >= SMALL_NUMBER )
    {
      v87 = 3.0f;
      v40 = 1.0f / fsqrt(v39);
      v82.X = (float)(3.0f - (float)((float)(v40 * v39) * v40)) * (float)(v40 * 0.5f);
      v63.X = v82.X * v37;
      v38 = v38 * v82.X;
  LABEL_45:
      v63.Y = v38;
      goto LABEL_46;
    }
    v63.X = 0.0f;
    v63.Y = 0.0f;
  LABEL_46:
    v63.Z = 0.0f;
  LABEL_47:
    if ( fabs(v63.X * v83.Normal.X + v63.Z * v83.Normal.Z + v63.Y * v83.Normal.Y) > 0.05f )
      return 0;
    v41 = v83.Normal.Y;
    var cpy2 = v83.Normal;
    v42 = (cpy2.Y, cpy2.Z);               // set Y&Z
    v43 = v83.Normal.X;
    v44 = (float)(v83.Normal.X * v83.Normal.X) + (float)(v41 * v41);
    if ( v44 == 1.0f )
    {
      if ( v83.Normal.Z == 0.0f )
      {
        v64 = v83.Normal.X;
        v65 = v83.Normal.Y;
        goto LABEL_56;
      }
      v64 = v83.Normal.X;
    }
    else
    {
      if ( v44 < SMALL_NUMBER )
      {
        v64 = 0.0f;
        v65 = 0.0f;
        goto LABEL_56;
      }
      v87 = 3.0f;
      v45 = 1.0f / fsqrt(v44);
      v82.X = (float)(3.0f - (float)((float)(v45 * v44) * v45)) * (float)(v45 * 0.5f);
      v64 = v82.X * v83.Normal.X;
      v41 = v83.Normal.Y * v82.X;
    }
    v65 = v41;
  LABEL_56:
    Tolerance = (float)(fabs(v65));
    v58 = (float)(fabs(v64));
    v46 = Max(v58, Tolerance);
    v72 = (float)v46;
    if ( (float)(v72 * v72) < 1.0f )
      v69 = v72 * v72;
    else
      v69 = 1.0f;
    v47 = v78.Y;
    v48 = (float)(v47 * v47) + (float)(v78.X * v78.X);
    v75.X = v48;
    v70 = (float)((v46 * sqrt(1.0f - v69) * 0.82842702d + 1.0f) * a5.X);
    if ( v48 != 1.0f )
    {
      if ( v48 < SMALL_NUMBER )
      {
        v49 = 0.0f;
        v50 = 0.0f;
  LABEL_67:
        v51 = 0.0f;
        v75.X = v49;
        v75.Y = v50;
        v75.Z = 0.0f;
        goto LABEL_68;
      }
      v87 = 3.0f;
      v52 = 1.0f / fsqrt(v75.X);
      v82.X = (float)(3.0f - (float)((float)(v52 * v75.X) * v52)) * (float)(v52 * 0.5f);
      v49 = v82.X * v78.X;
      v47 = v78.Y * v82.X;
  LABEL_66:
      v50 = v47;
      v51 = 0.0f;
      v75.X = v49;
      v75.Y = v50;
      v75.Z = 0.0f;
      goto LABEL_68;
    }
    if ( v78.Z != 0.0f )
    {
      v49 = v78.X;
      v50 = v47;
      v51 = 0.0f;
      v75.X = v49;
      v75.Y = v50;
      v75.Z = 0.0f;
      goto LABEL_68;
    }
    v75 = v78;
    v49 = v78.X;
    v50 = v78.Y;
    v51 = v78.Z;
  LABEL_68:
    v53 = v70;
    v54 = fabs(v75.Y * v65 + v75.X * v64 + v75.Z * 0.0f);
    if ( v54 > 0.0f )
    {
      v73 = (float)v54;
      v53 = v70 / v73;
    }
    v57.X = v43;
    v57.Y = v42.Item1;                      // set Y&Z
    v57.Z = v42.Item2;
    v56.X = v43;
    v56.Y = v42.Item1;                      // set Y&Z
    v56.Z = v42.Item2;
    v82.X = (float)(v49 * v53) + v83.Location.X;
    v82.Y = (float)(v50 * v53) + v83.Location.Y;
    v82.Z = (float)(v51 * v53) + v83.Location.Z;
    E_FLedgeHitInfo_FillWith(ref out_LedgeHit, &v83, &v82, v56, v57);
    if ( (float)((float)((float)((float)(-0.0f - v83.Normal.Z) * (float)(-0.0f - (float)((float)(a2a.X * 0.0f) - (float)(a2a.Y * 0.0f)))) + (float)((float)(-0.0f - v83.Normal.Y) * (float)(-0.0f - (float)((float)(a2a.Z * 0.0f) - a2a.X))))
               + (float)((float)(-0.0f - v83.Normal.X) * (float)(-0.0f - (float)(a2a.Y - (float)(a2a.Z * 0.0f))))) <= 0.0f )
      result = MOVE_WallRunningLeft;
    else
      result = MOVE_WallRunningRight;
    return result;
  }

  public override unsafe void PrePerformPhysics(float DeltaTime)
  {
    TdPawn v3 = default; // edi
    int v4 = default; // esi
    int v5 = default; // eax
    //void (__thiscall **v6)(TdPawn , int, _DWORD, _DWORD); // ebp
    int v7 = default; // eax
    TdPawn v8 = default; // ecx
    int v9 = default; // eax
    EMovement v10 = default; // cl
    TdPawn v11 = default; // eax
    double v12 = default; // st6
    float v13 = default; // xmm1_4
    double v14 = default; // st5
    float v15 = default; // xmm0_4
    float v16 = default; // xmm4_4
    float v17 = default; // xmm5_4
    float v18 = default; // xmm1_4
    float v19 = default; // xmm0_4
    float v20 = default; // xmm0_4
    float v21 = default; // xmm2_4
    TdPawn v22 = default; // eax
    float v23 = default; // xmm0_4
    float v24 = default; // xmm5_4
    float v25 = default; // xmm1_4
    TdPawn v26 = default; // ecx
    TdPawn v27 = default; // ecx
    TdPawn v28 = default; // eax
    float v29 = default; // xmm0_4
    float v30 = default; // [esp+20h] [ebp-34h]
    Vector rotator_then_vec = default; // [esp+34h] [ebp-20h] BYREF
    int v32 = default; // [esp+40h] [ebp-14h]
    float v33 = default; // [esp+44h] [ebp-10h]
  
    this.FrictionModifier = 0.0f;
    base.PrePerformPhysics(DeltaTime);
    v3 = this.PawnOwner;
    if ( v3.Physics == PHYS_Falling )
    {
      v4 = v3.VfTableObject.Dummy;
      v32 = default;
      rotator_then_vec.Y = 0.0f;
      rotator_then_vec.Z = 0.0f;
      rotator_then_vec.X.LOBYTE(2);
      v3.SetMove((EMovement)2);
    }
    else
    {
      if ( v3.VelocityMagnitude < 0.1f )
      {
        v3.FallingOffWall();
        /*v6 = (void (__thiscall **)(TdPawn , int, _DWORD, _DWORD))(v3.VfTableObject.Dummy + 244);
        v7 = v3.FindFunctionChecked(FallingOffWall1, FallingOffWall2, 0);
        (*v6)(v3, v7, 0, 0);*/
        v8 = this.PawnOwner;
        if ( v8.Physics == PHYS_WallRunning )
          v8.setPhysics( 2, default, new Vector(default, default, COERCE_FLOAT(1065353216)));// setPhysics
      }
      if ( (this.PlayCameraHitWallEffect.AsBitfield(5) & 0x10) == default && this.MoveActiveTime > 0.30000001d )
      {
        v9 = (ushort)E_DirToRotator( this.WallNormal, (Rotator *)&rotator_then_vec)->Yaw;
        if ( v9 > 0x7FFF )
          v9 = v9 - (0x10000);
        v10 = this.PawnOwner.MovementState;
        if ( v10 == MOVE_WallRunningRight )
        {
          this.MaxContraintWorld = v9 + 20000;
        }
        else if ( v10 == MOVE_WallRunningLeft )
        {
          this.MinContraintWorld = v9 - 20000;
        }
        SetFromBitfield(ref this.PlayCameraHitWallEffect, 5, this.PlayCameraHitWallEffect.AsBitfield(5) | (0x10u));
      }
      if ( (this.PlayCameraHitWallEffect.AsBitfield(5) & 2) != default )
      {
        v11 = this.PawnOwner;
        v12 = v11.Velocity.X * v11.Velocity.X;
        v13 = v11.Floor.X;
        v14 = v11.Velocity.Y;
        v15 = v11.Floor.Z * 0.0f;
        v16 = v11.Floor.Y - v15;
        v17 = v15 - v13;
        v18 = (float)(v13 * 0.0f) - (float)(v11.Floor.Y * 0.0f);
        v19 = (float)(v17 * v17) + (float)(v16 * v16);
        v33 = v19;
        v30 = (float)(sqrt(v14 * v14 + v12));
        if ( v19 == 1.0f )
        {
          if ( v18 == 0.0f )
          {
            rotator_then_vec.X = v16;
            v20 = v16;
            rotator_then_vec.Y = v17;
            rotator_then_vec.Z = 0.0f;
          }
          else
          {
            v20 = v16;
          }
        }
        else if ( v19 >= SMALL_NUMBER )
        {
          v21 = 1.0f / fsqrt(v33);
          rotator_then_vec.X = (float)(3.0f - (float)((float)(v21 * v33) * v21)) * (float)(v21 * 0.5f);
          v20 = rotator_then_vec.X * v16;
          v17 = v17 * rotator_then_vec.X;
        }
        else
        {
          v20 = 0.0f;
          v17 = 0.0f;
        }
        v22 = this.PawnOwner;
        v23 = v20 * v30;
        v24 = v17 * v30;
        if ( v22.MovementState == MOVE_WallRunningLeft )
          v25 = 1.0f;
        else
          v25 = -1.0f;
        v22.Velocity.X = v25 * v23;
        this.PawnOwner.Velocity.Y = v25 * v24;
        this.FrictionModifier = this.WallRunningHorisontalFriction;
      }
      if ( (this.PlayCameraHitWallEffect.AsBitfield(5) & 4) == default )
      {
        v26 = this.PawnOwner;
        if ( this.WallRunningVelocityStopLimit <= v26.Velocity.Z )
        {
          v26.Acceleration.X = 0.0f;
          v26.Acceleration.Y = 0.0f;
          v26.Acceleration.Z = 0.0f;
          v28 = this.PawnOwner;
          if ( v28.Velocity.Z <= 0.0f )
            v29 = this.WallRunningHorisontalDeceleration;
          else
            v29 = this.WallRunningHorisontalAcceleration;
          v28.Acceleration.Z = -0.0f - v29;
        }
        else
        {
          v26.FallingOffWall();
          v27 = this.PawnOwner;
          if ( v27.Physics == PHYS_WallRunning )
            v27.setPhysics( 2, default, new Vector(0, 0, COERCE_FLOAT(1065353216)));// setPhysics
        }
      }
    }
  }
}
}
