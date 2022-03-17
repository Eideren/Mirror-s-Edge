// NO OVERWRITE

namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdMove_Grab
{
  public override unsafe EMoveAimMode GetAimMode(int a2)
  {
    TdPawn v3 = default; // eax
    TdPawn v4 = default; // ecx
    Controller v5 = default; // eax
    int v6 = default; // edx
    int v7 = default; // edx
    int v8 = default; // eax
    float v9 = default; // xmm0_4
    float v10 = default; // xmm1_4
    EMoveAimMode result = default; // al
    Rotator v12 = default; // [esp+4h] [ebp-18h] BYREF
    Rotator a5 = default; // [esp+10h] [ebp-Ch] BYREF
  
    if ( this.IsHangingFree() )// IsHangingFree
      return this.AimMode;
    if ( default == a2 )
      return this.AimMode;
    v3 = this.PawnOwner;
    if( default == v3.Controller )
      return this.AimMode;
    v4 = this.PawnOwner;
    v5 = v3.Controller;
    v6 = v5.Rotation.Pitch - v4.Rotation.Pitch;
    //v5 = (Controller )((byte *)v5 + 0xF4);// to v5.Rotation
    v12.Pitch = v6;
    v7 = v5.Rotation.Yaw - v4.Rotation.Yaw;
    v8 = v5.Rotation.Roll - v4.Rotation.Roll;
    v12.Yaw = v7;
    v12.Roll = v8;
    v9 = (float)(int)E_ClipAmountOfTurns(v12, &a5)->Yaw;
    v10 = this.StartTurningAngle;
    if ( v9 > v10 )
      return (EMoveAimMode)1;
    if ( (float)(-0.0f - v10) > v9 )
      result = MAM_Left;
    else
      result = this.AimMode;
    return result;
  }

  public unsafe bool IsHangingFree()
  {
    bool result = default; // eax
  
    result = true;
    if ( this.GrabType != EGrabType.GT_LegsFree || (this.bIsWithinForwardView.AsBitfield(8) & 4) != 0 )// 4 => bSlopedLedge
      result = default;
    return result != default;
  }

  public unsafe void UpdateShimmy(float DeltaTime)
  {
    Matrix *v3; // eax
    float v4 = default; // xmm5_4
    float v5 = default; // xmm4_4
    float v6 = default; // xmm1_4
    float v7 = default; // xmm0_4
    float v8 = default; // xmm0_4
    float v9 = default; // xmm2_4
    float v10 = default; // xmm2_4
    float v11 = default; // xmm1_4
    TdPawn v12 = default; // eax
    float v13 = default; // xmm2_4
    float v14 = default; // xmm0_4
    int v15 = default; // edi
    int v16 = default; // eax
    int v17 = default; // [esp+Ch] [ebp-74h] BYREF
    float v18 = default; // [esp+10h] [ebp-70h]
    float v19 = default; // [esp+14h] [ebp-6Ch]
    float v20 = default; // [esp+18h] [ebp-68h]
    float v21 = default; // [esp+20h] [ebp-60h]
    float v22 = default; // [esp+24h] [ebp-5Ch]
    uint v23 = default; // [esp+28h] [ebp-58h]
    float v24 = default; // [esp+30h] [ebp-50h]
    Matrix v25 = default; // [esp+40h] [ebp-40h] BYREF
  
    v3 = FRotationMatrix(&v25, this.PawnOwner.Rotation);
    v4 = v3->YPlane.X;
    v5 = v3->YPlane.Y;
    v6 = v3->YPlane.Z;
    v7 = (float)(v5 * v5) + (float)(v4 * v4);
    v18 = v4;
    v19 = v5;
    v20 = v6;
    v24 = v7;
    if ( v7 == 1.0f )
    {
      if ( v6 == 0.0f )
      {
        v21 = v18;
        v8 = v18;
        v22 = v19;
        v5 = v19;
        v23 = LODWORD(v20);
        v9 = v20;
        goto LABEL_9;
      }
      v8 = v4;
    }
    else if ( v7 >= SMALL_NUMBER )
    {
      v18 = 3.0f;
      v17 = 1056964608;
      v10 = 1.0f / fsqrt(v24);
      v21 = (float)(3.0f - (float)((float)(v10 * v24) * v10)) * (float)(v10 * 0.5f);
      v8 = v21 * v4;
      v5 = v5 * v21;
    }
    else
    {
      v8 = 0.0f;
      v5 = 0.0f;
    }
    v9 = 0.0f;
  LABEL_9:
    v11 = this.CustomAnimNode.NodeTotalWeight * this.ShimmyVelocity;
    v12 = this.PawnOwner;
    v21 = v8 * v11;
    //v12 = (TdPawn )((byte *)v12 + 0x100);// ptr to Velocity
    v12.Velocity.X = v8 * v11;
    v22 = v5 * v11;
    v13 = v9 * v11;
    //v23 = (uint)v13;
    v12.Velocity.Y = v5 * v11;
    v12.Velocity.Z = v13;
    v14 = this.ShimmyTime - DeltaTime;
    this.ShimmyTime = v14;
    if ( v14 < 0.0f && this.ShimmyVelocity < 0.0001f )
    {
      v15 = this.VfTableObject.Dummy;
      v17 = default;
      CallUFunction(this.AbortShimmy, this, v16, &v17, 0);
    }
  }

  public unsafe EGrabType CheckWallLegPlacement()
  {
    TdPawn v2 = default; // ecx
    Vector *v3; // ecx
    float v4 = default; // xmm7_4
    float v5 = default; // edx
    float v6 = default; // eax
    float v7 = default; // ecx
    float v8 = default; // xmm0_4
    float v9 = default; // xmm2_4
    TdPawn v10 = default; // ecx
    float v11 = default; // xmm1_4
    float v12 = default; // xmm2_4
    float v13 = default; // xmm5_4
    CylinderComponent v14 = default; // eax
    float v15 = default; // xmm0_4
    CylinderComponent v16 = default; // edx
    float v17 = default; // xmm4_4
    float v18 = default; // xmm1_4
    float v19 = default; // xmm4_4
    float v20 = default; // xmm3_4
    float v21 = default; // xmm2_4
    float v22 = default; // xmm0_4
    float v23 = default; // edx
    float v24 = default; // eax
    float v25 = default; // ecx
    float v26 = default; // xmm0_4
    float v27 = default; // xmm2_4
    double v28 = default; // st7
    double v29 = default; // st6
    float v30 = default; // xmm0_4
    float v31 = default; // xmm0_4
    double v32 = default; // st7
    TdPawn v34 = default; // eax
    float v35 = default; // xmm2_4
    float v36 = default; // xmm1_4
    float v37 = default; // xmm2_4
    float v38 = default; // xmm3_4
    float v39 = default; // xmm1_4
    Vector a4 = default; // [esp+0h] [ebp-C8h] BYREF
    float v41 = default; // [esp+Ch] [ebp-BCh]
    float v42 = default; // [esp+10h] [ebp-B8h]
    float v43 = default; // [esp+14h] [ebp-B4h]
    float v44 = default; // [esp+18h] [ebp-B0h]
    float v45 = default; // [esp+1Ch] [ebp-ACh]
    float v46 = default; // [esp+20h] [ebp-A8h]
    Vector a2 = default; // [esp+28h] [ebp-A0h] BYREF
    float v48 = default; // [esp+34h] [ebp-94h]
    float v49 = default; // [esp+38h] [ebp-90h]
    float v50 = default; // [esp+3Ch] [ebp-8Ch]
    Vector a3 = default; // [esp+44h] [ebp-84h] BYREF
    Vector a5 = default; // [esp+50h] [ebp-78h] BYREF
    CheckResult v53 = default; // [esp+5Ch] [ebp-6Ch] BYREF
    int v54 = default; // [esp+A4h] [ebp-24h]
    float v55 = default; // [esp+A8h] [ebp-20h]
    float v56 = default; // [esp+B8h] [ebp-10h]
  
    v53.Item = -1;
    v53.LevelIndex = -1;
    v2 = this.PawnOwner;
    v53.Next = default;
    v53.Actor = default;
    v53.Material = default;
    v53.PhysMaterial = default;
    v53.Component = default;
    v53.BoneName = default;
    v53.Level = default;
    v53.bStartPenetrating = default;
    v54 = default;
    v53.Location.X = 0.0f;
    v53.Location.Y = 0.0f;
    v53.Location.Z = 0.0f;
    v53.Normal.X = 0.0f;
    v53.Normal.Y = 0.0f;
    v53.Normal.Z = 0.0f;
    v53.Time = 1.0f;
    v3 = v2.Rotation.Vector(&a2);
    v4 = v3->X;
    v55 = (float)(v4 * v4) + (float)(v3->Y * v3->Y);
    if ( v55 == 1.0f )
    {
      if ( v3->Z == 0.0f )
      {
        v5 = v3->X;
        v6 = v3->Y;
        v7 = v3->Z;
        v44 = v5;
        v4 = v5;
        v45 = v6;
        v46 = v7;
        goto LABEL_10;
      }
      v8 = v3->Y;
      v45 = v8;
      goto LABEL_9;
    }
    if ( v55 >= SMALL_NUMBER )
    {
      v44 = 3.0f;
      v41 = 0.5f;
      v9 = 1.0f / fsqrt(v55);
      v48 = (float)(3.0f - (float)((float)(v9 * v55) * v9)) * (float)(v9 * 0.5f);
      v4 = v48 * v3->X;
      v8 = v3->Y * v48;
  LABEL_8:
      v45 = v8;
      goto LABEL_9;
    }
    v4 = 0.0f;
    v45 = 0.0f;
  LABEL_9:
    v44 = v4;
    v46 = 0.0f;
  LABEL_10:
    v10 = this.PawnOwner;
    v11 = this.HandPlantExtentCheckWidth * 0.5f;
    v12 = v45 - (float)(v46 * 0.0f);
    v13 = (float)(v46 * 0.0f) - v4;
    a4 = v10.Location;
    a5.X = v11;
    a5.Y = v11;
    a5.Z = v11;
    v14 = v10.CylinderComponent;
    v15 = (float)(v4 * 0.0f) - (float)(v45 * 0.0f);
    a2.X = -0.0f - v12;
    a2.Z = -0.0f - v15;
    a4.Z = (float)(v14.CollisionHeight - this.HangFreeZDistanceCheck) + a4.Z;
    v16 = v10.CylinderComponent;
    a2.Y = -0.0f - v13;
    v17 = v16.CollisionRadius - v11;
    a4.Z = (float)(v15 * v17) + a4.Z;
    v18 = a4.Y + (float)(v13 * v17);
    a4.Y = v18;
    v19 = a4.X + (float)(v12 * v17);
    a4.X = v19;
    v20 = v10.MoveNormal.Y;
    v21 = v10.MoveNormal.X;
    v43 = v10.CylinderComponent.CollisionRadius;
    v22 = (float)(v21 * v21) + (float)(v20 * v20);
    v56 = v22;
    if ( v22 == 1.0f )
    {
      if ( v10.MoveNormal.Z == 0.0f )
      {
        v23 = v10.MoveNormal.X;
        v24 = v10.MoveNormal.Y;
        v25 = v10.MoveNormal.Z;
        v48 = v23;
        v49 = v24;
        v50 = v25;
      }
      else
      {
        v26 = v10.MoveNormal.Y;
        v48 = v21;
        v49 = v26;
      }
    }
    else if ( v22 >= SMALL_NUMBER )
    {
      v55 = 3.0f;
      v41 = 0.5f;
      v27 = 1.0f / fsqrt(v56);
      v48 = (float)(3.0f - (float)((float)(v27 * v56) * v27)) * (float)(v27 * 0.5f);
      v19 = a4.X;
      v48 = v48 * v10.MoveNormal.X;
      v49 = v10.MoveNormal.Y * (float)((float)(3.0f - (float)((float)(v27 * v56) * v27)) * (float)(v27 * 0.5f));
      v18 = a4.Y;
    }
    else
    {
      v48 = 0.0f;
      v49 = 0.0f;
    }
    v28 = fabs(v49);
    v42 = (float)v28;
    v29 = fabs(v48);
    v41 = (float)v29;
    if ( v29 < v28 )
      v30 = v42;
    else
      v30 = v41;
    v41 = v30;
    v31 = v30 * v30;
    if ( v31 < 1.0f )
      v42 = v31;
    else
      v42 = 1.0f;
    v42 = (float)((sqrt(1.0f - v42) * v41 * 0.82842702d + 1.0f) * v43);
    v43 = v42 + 32.0f;
    a3.X = (float)((float)(v42 + 32.0f) * v4) + v19;
    a3.Y = (float)(v45 * (float)(v42 + 32.0f)) + v18;
    a3.Z = (float)(v46 * (float)(v42 + 32.0f)) + a4.Z;
    if ( default == this.MovementLineCheck(ref v53, &a3, &a4, &a5, 140494) )
    {
      v34 = this.PawnOwner;
      v35 = this.HandPlantExtentCheckWidth * 0.5f;
      a4 = v34.Location;
      a4.Z = (float)(v34.CylinderComponent.CollisionHeight - this.HangFreeZDistanceCheck) + a4.Z;
      v36 = v34.CylinderComponent.CollisionRadius - v35;
      v37 = (float)(v36 * a2.X) + a4.X;
      v38 = (float)(a2.Y * v36) + a4.Y;
      v39 = (float)(a2.Z * v36) + a4.Z;
      a2.X = (float)(v43 * v44) + v37;
      a2.Y = (float)(v45 * v43) + v38;
      a2.Z = (float)(v46 * v43) + v39;
      a3 = a2;
      a4.X = v37;
      a4.Y = v38;
      a4.Z = v39;
      if ( default == this.MovementLineCheck(ref v53, &a3, &a4, &a5, 140494) )
        return (EGrabType)1;
    }
    v32 = sqrt((a4.X - v53.Location.X) * (a4.X - v53.Location.X) + (a4.Y - v53.Location.Y) * (a4.Y - v53.Location.Y)) - v42;
    v43 = (float)v32;
    if ( v32 < 0.0f )
      this.DistanceToWallFromFeet = 0.0f;
    else
      this.DistanceToWallFromFeet = v43;
    return 0;
  }

  public override unsafe void PrePerformPhysics(float DeltaTime)
  {
    byte v3 = default; // bl
    // int (__thiscall *v4)(TdMove_Grab ); // edx
    EGrabType v5 = default; // al
    EGrabType v6 = default; // cl
    Matrix *v7; // eax
    float v8 = default; // xmm4_4
    float v9 = default; // xmm1_4
    float v10 = default; // xmm2_4
    float v11 = default; // xmm3_4
    Vector *v12; // ecx
    float v13 = default; // eax
    float v14 = default; // edx
    float v15 = default; // xmm5_4
    float v16 = default; // xmm0_4
    float v17 = default; // edx
    float v18 = default; // eax
    float v19 = default; // xmm0_4
    float v20 = default; // xmm1_4
    float v21 = default; // xmm2_4
    TdPawn v22 = default; // eax
    int v23 = default; // edx
    float v24 = default; // xmm2_4
    float v25 = default; // xmm0_4
    int v26 = default; // eax
    float v27 = default; // edx
    TdPawn v28 = default; // eax
    float v29 = default; // ecx
    float v30 = default; // edx
    float v31 = default; // ecx
    TdPawn v32 = default; // eax
    float v33 = default; // edx
    float v34 = default; // xmm0_4
    TdPawn v35 = default; // eax
    int v36 = default; // edi
    float v37 = default; // xmm1_4
    float v38 = default; // xmm3_4
    float v39 = default; // ecx
    float v40 = default; // xmm0_4
    int v41 = default; // eax
    TdPawn v42 = default; // eax
    int v43 = default; // edi
    int v44 = default; // eax
    float v45 = default; // edx
    float v46 = default; // ecx
    float v47 = default; // edx
    TdPawn v48 = default; // eax
    float v49 = default; // ecx
    float v50 = default; // edx
    float v51 = default; // ecx
    float v52 = default; // edx
    Vector *v53; // eax
    float v54 = default; // ecx
    Vector v55 = default; // [esp-18h] [ebp-E0h]
    Rotator v56 = default; // [esp-Ch] [ebp-D4h]
    Rotator v57 = default; // [esp-Ch] [ebp-D4h]
    int v58 = default; // [esp+20h] [ebp-A8h] BYREF
    float v59 = default; // [esp+24h] [ebp-A4h]
    float v60 = default; // [esp+28h] [ebp-A0h]
    float v61 = default; // [esp+2Ch] [ebp-9Ch]
    Vector a4 = default; // [esp+30h] [ebp-98h] BYREF
    byte* v63 = stackalloc byte[4]; // [esp+3Ch] [ebp-8Ch]
    Vector a3 = default; // [esp+40h] [ebp-88h] BYREF
    Vector a2 = default; // [esp+4Ch] [ebp-7Ch] BYREF
    Vector vect_then_rotator2 = default; // [esp+58h] [ebp-70h] BYREF
    Vector vect_then_rotator = default; // [esp+68h] [ebp-60h] BYREF
    float v68 = default; // [esp+78h] [ebp-50h]
    Matrix v69 = default; // [esp+88h] [ebp-40h] BYREF
    byte v70 = default; // [esp+F0h] [ebp+28h]
  
    base.PrePerformPhysics(DeltaTime);
    if ( this.CurrentShimmyMove != EShimmyType.ShimmyAroundCorner )
    {
      v3 = 12;
      if ( this.ShimmyVelocity >= 0.0f )
        v3 = 14;
      // v4 = *(int (__thiscall **)(TdMove_Grab ))(this.VfTableObject.Dummy + 300);
      v63[0] = v3;
      v5 = this.CheckWallLegPlacement();
      v6 = this.GrabType;
      if ( v5 != v6 )
      {
        this.GrabType = v5;
        this.PreviousGrabType = v6;
        this.UpdateGrabType(v3 == 12);
      }
      v7 = FRotationMatrix(&v69, this.PawnOwner.Rotation);
      v8 = 0.0f;
      v9 = v7->YPlane.X;
      v10 = v7->YPlane.Y;
      v11 = v7->YPlane.Z;
      vect_then_rotator.X = v9;
      vect_then_rotator.Y = v10;
      vect_then_rotator.Z = v11;
      a2.X = 0.0f;
      a2.Y = 0.0f;
      a2.Z = 0.0f;
      a3.X = 0.0f;
      a3.Y = 0.0f;
      a3.Z = 0.0f;
      a4.X = 0.0f;
      a4.Y = 0.0f;
      a4.Z = 0.0f;
      if ( v3 == 12 )
      {
        vect_then_rotator2.X = -0.0f - v9;
        vect_then_rotator2.Y = -0.0f - v10;
        vect_then_rotator2.Z = -0.0f - v11;
        v12 = &vect_then_rotator2;
      }
      else
      {
        v12 = &vect_then_rotator;
      }
      v13 = v12->Y;
      v59 = v12->X;
      v14 = v12->Z;
      v60 = v13;
      v15 = v13;
      v16 = (float)(v15 * v15) + (float)(v59 * v59);
      v61 = v14;
      v68 = v16;
      if ( v16 == 1.0f )
      {
        if ( v61 == 0.0f )
        {
          v17 = v12->Y;
          v59 = v12->X;
          v18 = v12->Z;
          v19 = v59;
          v60 = v17;
          v20 = v17;
          v61 = v18;
          v8 = v18;
          goto LABEL_17;
        }
        v19 = v59;
      }
      else
      {
        if ( v16 < SMALL_NUMBER )
        {
          v19 = 0.0f;
          v20 = 0.0f;
          goto LABEL_17;
        }
        vect_then_rotator.X = 3.0f;
        v58 = 1056964608;
        v21 = 1.0f / fsqrt(v68);
        vect_then_rotator2.X = (float)(3.0f - (float)((float)(v21 * v68) * v21)) * (float)(v21 * 0.5f);
        v19 = vect_then_rotator2.X * v59;
        v15 = v13 * vect_then_rotator2.X;
      }
      v20 = v15;
  LABEL_17:
      v22 = this.PawnOwner;
      v23 = v22.Rotation.Pitch;
      v24 = v22.Location.X + (float)(v19 * 5.0f);
      v60 = v22.Location.Y + (float)(v20 * 5.0f);
      v25 = v22.Location.Z;
      v56.Pitch = v23;
      v56.Yaw = v22.Rotation.Yaw;
      v56.Roll = v22.Rotation.Roll;
      v59 = v24;
      *(_QWORD *)&v55.X = __PAIR64__(LODWORD(v60), LODWORD(v24));
      v61 = v25 + (float)(v8 * 5.0f);
      v55.Z = v61;
      if ( this.FindAutoMoveLedge(ref a2, ref a3, ref a4, v55, v56, 30.0f, 0) == 2 )
      {
        v42 = this.PawnOwner;
        if ( (float)((float)((float)(v42.MoveNormal.Z * a4.Z) + (float)(v42.MoveNormal.Y * a4.Y)) + (float)(v42.MoveNormal.X * a4.X)) >= 0.98000002d )
        {
          v45 = a2.Y;
          v42.MoveLedgeLocation.X = a2.X;
          v46 = a2.Z;
          v42.MoveLedgeLocation.Y = v45;
          v47 = a3.X;
          v42.MoveLedgeLocation.Z = v46;
          v48 = this.PawnOwner;
          v49 = a3.Y;
          v48.MoveLedgeNormal.X = v47;
          v50 = a3.Z;
          //v48 = (TdPawn )((byte *)v48 + 0x654);// now points to MoveLedgeNormal
          v48.MoveLedgeNormal.Y = v49;
          v51 = a4.X;
          v48.MoveLedgeNormal.Z = v50;
          v52 = a4.Y;
          this.PawnOwner.MoveNormal.X = v51;
          v54 = a4.Z;
          this.PawnOwner.MoveNormal.Y = v52;
          this.PawnOwner.MoveNormal.Z = v54;
  LABEL_25:
          if ( fabs(this.ShimmyVelocity) > 0.0f )
            UpdateShimmy(DeltaTime);
          return;
        }
      }
      else
      {
        this.CanShimmyAroundCorner( (EMovementAction)(v63[ 0 ]) );
        if(v26 != default)
        {
          vect_then_rotator2.Y.LODWORD(this.TargetYaw);
          vect_then_rotator2.X = 0.0f;
          vect_then_rotator2.Z = 0.0f;
          v57 = *E_ClipAmountOfTurns(*(Rotator *)&vect_then_rotator2, (Rotator *)&vect_then_rotator);
          if ( this.FindAutoMoveLedge(ref a2, ref a3, ref a4, this.TargetLocation, v57, this.HandPlantCheckDistance, 0) == 2 )
          {
            this.PawnOwner.MoveLedgeLocation = a2;
            v27 = a3.Y;
            v28 = this.PawnOwner;
            v28.MoveLedgeNormal.X = a3.X;
            v29 = a3.Z;
            v28.MoveLedgeNormal.Y = v27;
            v30 = a4.X;
            v28.MoveLedgeNormal.Z = v29;
            v31 = a4.Y;
            v32 = this.PawnOwner;
            v32.MoveNormal.X = v30;
            v33 = a4.Z;
            v32.MoveNormal.Y = v31;
            v32.MoveNormal.Z = v33;
            v34 = this.RelativeExtent + this.GrabDesiredLedgeOffset.X;
            v35 = this.PawnOwner;
            v36 = this.VfTableObject.Dummy;
            v37 = (float)(v35.MoveNormal.X * v34) + v35.MoveLedgeLocation.X;
            v38 = v35.MoveNormal.Z * v34;
            v60 = v35.MoveLedgeLocation.Y + (float)(v35.MoveNormal.Y * v34);
            v39 = v60;
            v40 = v35.MoveLedgeLocation.Z + v38;
            v59 = v37;
            this.TargetLocation.X = v37;
            this.TargetLocation.Y = v39;
            v61 = v40;
            this.TargetLocation.Z = v40;
            this.TargetLocation.Z = this.TargetLocation.Z - this.GrabDesiredLedgeOffset.Z;
            v58 = default;
            CallUFunction(this.AbortShimmy, this, v41, &v58, 0);
            this.StartShimmyAroundCorner((EMovementAction)v70);
            return;
          }
        }
      }
      v43 = this.VfTableObject.Dummy;
      this.ShimmyVelocity = 0.0f;
      v58 = 1;
      CallUFunction(this.AbortShimmy, this, v44, &v58, 0);
      if ( fabs(this.ShimmyVelocity) > 0.0f )
        UpdateShimmy(DeltaTime);
      return;
    }
  }
}
}
