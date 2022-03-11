// NO OVERWRITE

namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdMove_GrabTransfer
{
  public unsafe bool SomeMultiLineCheck(CheckResult *a2, ref Vector a3, ref Vector a4, ref Vector a5)
  {
    int v5 = default; // ebp
    CheckResult *v6; // ebx
    int v8 = default; // [esp+Ch] [ebp-8h]
  
    v5 = FMemMark_Maybe;
    v8 = GMem;
    v6 = GWorld.MultiLineCheck(ref GMem, a3, a4, a5, 8u, this.PawnOwner, null);
    if(v6 != default)
    {
      qmemcpy(ref *a2, *v6, 0x4Cu);
    }
    else
    {
      a2->Time = 1.0f;
      a2->Actor = default;
    }
    if ( v5 != FMemMark_Maybe )
      FMemMark_Pop_Maybe(ref GMem, v5);
    GMem = v8;
    return v6 != default;
  }

  public unsafe bool CheckReachableTransferLedge(ref Vector a2, ref Vector a3, ref Vector a4, ref Vector a5)
  {
    TdPawn v6 = default; // eax
    Actor v7 = default; // eax
    TdPawn v8 = default; // eax
    TdPawn v9 = default; // ebp
    int v10 = default; // ebx
    Rotator *v11; // edi
    Rotator *v12; // eax
    float v13 = default; // ecx
    float v14 = default; // edx
    float v15 = default; // eax
    Rotator *v16; // eax
    bool v17 = default; // zf
    int v18 = default; // ecx
    int v19 = default; // edx
    EMoveActionHint v20 = default; // al
    CylinderComponent v21 = default; // ecx
    Controller v22 = default; // ebp
    float v23 = default; // edx
    float v24 = default; // ebp
    int v25 = default; // ecx
    TdPawn v26 = default; // eax
    float v28 = default; // xmm0_4
    TdMove_Grab v29 = default; // eax
    float v30 = default; // xmm4_4
    float v31 = default; // xmm5_4
    float v32 = default; // ebx
    float v33 = default; // ebp
    TdMove_Grab v34 = default; // edi
    float v35 = default; // xmm0_4
    float v36 = default; // xmm2_4
    float v37 = default; // xmm4_4
    float v38 = default; // edx
    float v39 = default; // edx
    float v40 = default; // ecx
    float v41 = default; // edx
    Rotator v42 = default; // [esp-Ch] [ebp-80h]
    float a11 = default; // [esp+18h] [ebp-5Ch]
    float v44 = default; // [esp+18h] [ebp-5Ch]
    TdPawn v45 = default; // [esp+1Ch] [ebp-58h]
    float BaseExtent = default; // [esp+1Ch] [ebp-58h]
    Vector v47 = default; // [esp+20h] [ebp-54h]
    Vector v48 = default; // [esp+30h] [ebp-44h]
    Vector v49 = default; // [esp+30h] [ebp-44h]
    Vector rot_then_vec = default; // [esp+3Ch] [ebp-38h] BYREF
    Vector rot_then_vec2 = default; // [esp+4Ch] [ebp-28h] BYREF
    Vector rot_then_vec3 = default; // [esp+58h] [ebp-1Ch] BYREF
    float v53 = default; // [esp+64h] [ebp-10h]
  
    v6 = this.PawnOwner;
    v48 = v6.Location;
    a11 = this.Allowed2DTransferDistance;
    v7 = (Actor )v6.Class.GetDefaultObject(0);
    v8 = E_TryCastTo<TdPawn>(v7);
    v9 = this.PawnOwner;
    v10 = v9.Rotation.Pitch;
    rot_then_vec.Y.LODWORD(v9.Rotation.Yaw);
    v45 = v8;
    rot_then_vec.Z.LODWORD(v9.Rotation.Roll);
    v11 = E_ClipAmountOfTurns( v9.Rotation, (Rotator *)&rot_then_vec3);
    v12 = E_ClipAmountOfTurns( v9.Controller.Rotation, (Rotator *)&rot_then_vec2);
    v13.LODWORD(v12->Pitch - v11->Pitch);
    v14.LODWORD(v12->Yaw - v11->Yaw);
    v15.LODWORD(v12->Roll - v11->Roll);
    rot_then_vec2.X = v13;
    rot_then_vec2.Y = v14;
    rot_then_vec2.Z = v15;
    v16 = E_ClipAmountOfTurns(*(Rotator *)&rot_then_vec2, (Rotator *)&rot_then_vec3);
    v17 = this.TransferHint == MAH_None;
    v18 = v16->Pitch;
    v19 = v16->Yaw;
    rot_then_vec2.Z.LODWORD(v16->Roll);
    if ( v17 && v18 > 4096 && (uint)(v19 + 0x1FFF) <= 0x3FFE )
      this.TransferHint = MAH_Up;
    v20 = this.TransferHint;
    switch ( (int)v20 )
    {
      case (int)MAH_Up:
        v21 = v45.CylinderComponent;
        v48.Z = (float)(v21.CollisionHeight * 2.0f) + v48.Z;
        a11 = v21.CollisionRadius * 2.0f;
        break;
      case (int)MAH_Left:
        rot_then_vec.Y.LODWORD(LODWORD(rot_then_vec.Y) - (0x4000));
        break;
      case (int)MAH_Right:
        rot_then_vec.Y.LODWORD(LODWORD(rot_then_vec.Y) + (0x4000));
        break;
    }
    if(v20 != default)
    {
      v24 = rot_then_vec.Z;
    }
    else
    {
      v22 = v9.Controller;
      var y = v22.Rotation.Yaw;
      v23 = *(float *)&y;
      v10 = v22.Rotation.Pitch;
      var r = v22.Rotation.Roll;
      v24 = *(float *)&r;
      rot_then_vec.Y = v23;
    }
    v25 = LOWORD(rot_then_vec.Y);
    if ( LOWORD(rot_then_vec.Y) > 0x7FFFu )
      v25 = LOWORD(rot_then_vec.Y) - 0x10000;
    v42.Pitch = v10;
    *(_QWORD *)&v42.Yaw = __PAIR64__((int)LODWORD(v24), v25);
    if ( this.FindAutoMoveLedge(ref rot_then_vec2, ref rot_then_vec3, ref rot_then_vec, v48, v42, a11, 0) == 2 )
    {
      v26 = this.PawnOwner;
      if ( (float)((float)((float)(v26.MoveNormal.Y * rot_then_vec.Y) + (float)(v26.MoveNormal.Z * rot_then_vec.Z)) + (float)(v26.MoveNormal.X * rot_then_vec.X)) <= 0.99000001d )
      {
        if ( this.TransferHint != MAH_Up )
          goto LABEL_23;
      }
      else if ( this.TransferHint != MAH_Up )
      {
        return false;
      }
      v28 = rot_then_vec2.Z - v26.MoveLedgeLocation.Z;
      if ( v28 <= this.AllowedZTransferDistance && v28 >= 1.0f )
      {
        goto LABEL_23;
      }
    }
    else
    {
      SetFromBitfield(ref this.PawnOwner.bDisableSkelControlSpring, 32, this.PawnOwner.bDisableSkelControlSpring.AsBitfield(32) & (0xFFFFF7FF));
    }
    return false;
    LABEL_23:
    v29 = E_TryCastTo<TdMove_Grab>(v26.Moves[3]);
    v30 = rot_then_vec.Y;
    v31 = rot_then_vec.X;
    v32 = rot_then_vec2.X;
    v33 = rot_then_vec2.Y;
    v34 = v29;
    BaseExtent = v45.CylinderComponent.CollisionRadius;
    v35 = (float)(v30 * v30) + (float)(v31 * v31);
    v49 = rot_then_vec2;
    v53 = v35;
    if ( v35 == 1.0f )
    {
      if ( rot_then_vec.Z == 0.0f )
      {
        v47 = rot_then_vec;
        goto LABEL_32;
      }
      v47.X = rot_then_vec.X;
    }
    else
    {
      if ( v35 < SMALL_NUMBER )
      {
        v47.X = 0.0f;
        v47.Y = 0.0f;
        v47.Z = 0.0f;
        goto LABEL_32;
      }
      v36 = 1.0f / fsqrt(v53);
      rot_then_vec.X = (float)(3.0f - (float)((float)(v36 * v53) * v36)) * (float)(v36 * 0.5f);
      v47.X = rot_then_vec.X * v31;
      v30 = rot_then_vec.Y * rot_then_vec.X;
    }
    v47.Y = v30;
    v47.Z = 0.0f;
    goto LABEL_32;
    
    LABEL_32:
    v44 = this.CalculateRelativeExtent(BaseExtent);
    v37 = rot_then_vec2.Z - v34.GrabDesiredLedgeOffset.Z;
    a2.X = v49.X + (float)(v47.X * (float)(v44 + BaseExtent));
    a2.Y = v49.Y + (float)(v47.Y * (float)(v44 + BaseExtent));
    v38 = rot_then_vec2.Z;
    a2.Z = (float)(v47.Z * (float)(v44 + BaseExtent)) + v37;
    a4.X = v32;
    a4.Y = v33;
    a4.Z = v38;
    a3.X = v47.X;
    a3.Y = v47.Y;
    v39 = rot_then_vec3.X;
    a3.Z = v47.Z;
    v40 = rot_then_vec3.Y;
    a5.X = v39;
    v41 = rot_then_vec3.Z;
    a5.Y = v40;
    a5.Z = v41;
    SetFromBitfield(ref this.PawnOwner.bDisableSkelControlSpring, 32, this.PawnOwner.bDisableSkelControlSpring.AsBitfield(32) | (0x800u));
    return true;
  }

  public unsafe bool CheckReachableTransferMoveVolume(ref Vector a2, ref Vector a3, ref Vector a4)
  {
    TdPawn v5 = default; // edi
    Matrix *v6; // eax
    float v7 = default; // xmm1_4
    float v8 = default; // xmm2_4
    float v9 = default; // xmm3_4
    EMoveActionHint v10 = default; // al
    Vector *v11; // eax
    float v12 = default; // ecx
    float v13 = default; // edx
    float v14 = default; // xmm5_4
    float v15 = default; // xmm6_4
    float v16 = default; // xmm0_4
    float v17 = default; // xmm2_4
    TdPawn v18 = default; // ecx
    Actor v19 = default; // eax
    TdPawn v20 = default; // eax
    TdPawn v21 = default; // ecx
    float v22 = default; // edx
    float v23 = default; // xmm3_4
    float v24 = default; // xmm2_4
    float v25 = default; // xmm0_4
    float v26 = default; // xmm1_4
    float v27 = default; // xmm3_4
    float v28 = default; // xmm2_4
    CheckResult *v29; // edi
    TdLadderVolume v30 = default; // eax
    TdLadderVolume v31 = default; // ecx
    float v32 = default; // xmm0_4
    int v33 = default; // edi
    int v34 = default; // eax
    int v35 = default; // eax
    TdLadderVolume v36 = default; // esi
    float v37 = default; // ecx
    Vector v39 = default; // [esp+1Ch] [ebp-A8h] BYREF
    Vector a2a = default; // [esp+28h] [ebp-9Ch] BYREF
    Vector v41 = default; // [esp+38h] [ebp-8Ch] BYREF
    Vector v42 = default; // [esp+44h] [ebp-80h]
    TdMove_Climb v43 = default; // [esp+54h] [ebp-70h]
    Vector a5 = default; // [esp+58h] [ebp-6Ch] BYREF
    Matrix matrix_then_FCheckResult = default; // [esp+64h] [ebp-60h] BYREF
    int v46 = default; // [esp+A4h] [ebp-20h]
    int v47 = default; // [esp+A8h] [ebp-1Ch]
    int v48 = default; // [esp+ACh] [ebp-18h]
    float v49 = default; // [esp+B4h] [ebp-10h]
  
    v5 = this.PawnOwner;
    v6 = FRotationMatrix(&matrix_then_FCheckResult, v5.Rotation);
    v7 = v6->YPlane.X;
    v39.X = v7;
    v8 = v6->YPlane.Y;
    v39.Y = v8;
    v9 = v6->YPlane.Z;
    v10 = this.TransferHint;
    v39.Z = v9;
    switch ( (int)v10 )
    {
      case (int)MAH_Right:
        goto LABEL_4;
      case (int)MAH_Left:
        v39.X = -0.0f - v7;
        v39.Y = -0.0f - v8;
        v39.Z = -0.0f - v9;
  LABEL_4:
        v42 = v39;
        break;
      case (int)MAH_None:
        v11 = v5.Controller.Rotation.Vector(&a2a);
        v12 = v11->Y;
        v42.X = v11->X;
        v13 = v11->Z;
        v42.Y = v12;
        v42.Z = v13;
        break;
    }
    v14 = v42.Y;
    v15 = v42.X;
    v16 = (float)(v14 * v14) + (float)(v15 * v15);
    matrix_then_FCheckResult.ZPlane.Y = float.NaN;
    v46 = -1;
    matrix_then_FCheckResult.XPlane.X = 0.0f;
    matrix_then_FCheckResult.XPlane.Y = 0.0f;
    matrix_then_FCheckResult.XPlane.Z = 0.0f;
    matrix_then_FCheckResult.XPlane.W = 0.0f;
    matrix_then_FCheckResult.YPlane.X = 0.0f;
    matrix_then_FCheckResult.YPlane.Y = 0.0f;
    matrix_then_FCheckResult.YPlane.Z = 0.0f;
    matrix_then_FCheckResult.YPlane.W = 0.0f;
    matrix_then_FCheckResult.ZPlane.X = 1.0f;
    matrix_then_FCheckResult.ZPlane.Z = 0.0f;
    matrix_then_FCheckResult.ZPlane.W = 0.0f;
    matrix_then_FCheckResult.WPlane.X = 0.0f;
    matrix_then_FCheckResult.WPlane.Y = 0.0f;
    matrix_then_FCheckResult.WPlane.Z = 0.0f;
    matrix_then_FCheckResult.WPlane.W = 0.0f;
    v47 = default;
    v48 = default;
    v49 = v16;
    if ( v16 == 1.0f )
    {
      if ( v42.Z == 0.0f )
      {
        a2a.X = v42.X;
        a2a.Y = v42.Y;
        a2a.Z = 0.0f;
        goto LABEL_16;
      }
      a2a.X = v42.X;
      a2a.Y = v14;
      goto LABEL_15;
    }
    if ( v16 >= SMALL_NUMBER )
    {
      v42.X = 3.0f;
      v43 = null;//(TdMove_Climb )1056964608;// This variable is unused afaict, just written to further down
      v17 = 1.0f / fsqrt(v49);
      a2a.X = (float)(3.0f - (float)((float)(v17 * v49) * v17)) * (float)(v17 * 0.5f);
      a2a.X = a2a.X * v15;
      v14 = v42.Y * (float)((float)(3.0f - (float)((float)(v17 * v49) * v17)) * (float)(v17 * 0.5f));
      a2a.Y = v14;
      goto LABEL_15;
    }
    a2a.X = 0.0f;
    a2a.Y = 0.0f;
  LABEL_15:
    a2a.Z = 0.0f;
  LABEL_16:
    this.PawnOwner.GetCylinderExtent(&a5);
    v18 = this.PawnOwner;
    a5.Z = this.HandPlantExtentCheckHeight;
    v41.X = 0.0f;
    v41.Y = 0.0f;
    v41.Z = 0.0f;
    v39.X = 0.0f;
    v39.Y = 0.0f;
    v39.Z = 0.0f;
    v19 = (Actor )v18.Class.GetDefaultObject(0);
    v20 = E_TryCastTo<TdPawn>(v19);
    v21 = this.PawnOwner;
    v22 = v21.Location.X;
    v23 = this.HandPlantExtentCheckWidth;
    //v21 = (TdPawn )((byte *)v21 + 0xE8);// Ptr to this.PawnOwner.Location
    v41.X = v22;
    v41.Y = (v21.Location.Y);
    v41.Z = (v21.Location.Z);
    v24 = a2a.Z * v23;
    v25 = (float)((float)(v23 * a2a.X) * 2.0f) + v22;
    v26 = (float)(a2a.Y * v23) * 2.0f;
    v27 = this.Allowed2DTransferDistance;
    v41.Z = (float)((float)(v24 * 2.0f) + v41.Z) + this.HandPlantCheckHeight;
    v41.X = v25;
    v41.Y = v26 + v41.Y;
    v28 = v41.Z - v20.CylinderComponent.CollisionHeight;
    a2a.X = (float)(v27 * a2a.X) + v25;
    a2a.Y = (float)(a2a.Y * v27) + v41.Y;
    v39 = a2a;
    a2a.Z = (float)(a2a.Z * v27) + v28;
    v41.Z = v28;
    this.TransferLadder = default;
    if ( SomeMultiLineCheck((CheckResult *)&matrix_then_FCheckResult, ref v39, ref v41, ref a5) )
    {
      v43 = E_TryCastTo<TdMove_Climb>(this.PawnOwner.Moves[21]);
      v29 = (CheckResult *)&matrix_then_FCheckResult;
      do
      {
        v30 = E_TryCastTo<TdLadderVolume>(v29->Actor);
        if(v30 != default)
        {
          if ( this.PawnOwner.MovementState != MOVE_Climb || v43.Ladder != v30 )
            this.TransferLadder = v30;
        }
        v29 = (CheckResult *)v29->Next;
      }
      while(v29 != default);
    }
    v31 = this.TransferLadder;
    if ( default == v31 )
      return false;
    v32 = v41.Z;
    a4.X = v31.Center.X;
    a4.Y = v31.Center.Y;
    a4.Z = v32;
    v33 = this.TransferLadder.GetLastStep();// GetLastStep
    v34 = this.TransferLadder.GetClosestStep(this.PawnOwner.Location.Z);// GetClosestStep
    v35 = v34 < 0 ? 0 : v34;
    if ( v35 > v33 )
      v35 = v33;
    a2 = *this.TransferLadder.GetLadderLocation( &a2a, v35);// GetLadderLocation
    v36 = this.TransferLadder;
    v37 = v36.WallNormal.X;
    //v36 = (TdLadderVolume )((byte *)v36 + 0x244);// ptr to WallNormal
    a3.X = v37;
    a3.Y = (v36.WallNormal.Y);
    a3.Z = (v36.WallNormal.Z);
    return true;
  }

  public unsafe bool CheckContextMove(ref Vector out_MoveLocation, ref Vector out_MoveNormal, ref Vector out_LedgeLocation, ref Vector out_LedgeNormal)
  {
    TdMove_Grab v6 = default; // edi
    TdPawn v7 = default; // eax
    bool result = default; // eax
    EMoveActionHint v9 = default; // cl
    TdPawn v10 = default; // ebp
    Rotator *v11; // edi
    Rotator *v12; // eax
    int v13 = default; // ecx
    int v14 = default; // edx
    Rotator *v15; // eax
    int v16 = default; // edx
    int v17 = default; // ecx
    EMoveActionHint v18 = default; // al
    Rotator a5a = default; // [esp+8h] [ebp-18h] BYREF
    Rotator v20 = default; // [esp+14h] [ebp-Ch] BYREF
  
    v6 = E_TryCastTo<TdMove_Grab>(this.PawnOwner.Moves[3]);
    v7 = this.PawnOwner;
    if ( default == v7.Controller )
      return false;
    this.TransferHint = MAH_None;
    v9 = v7.MoveActionHint;
    if(v9 != default)
    {
      if ( v9 != MAH_Down )
      {
        if ( v7.MovementState != MOVE_Climb || v9 == MAH_Up )
        {
          if ( v6.IsHangingFree() )// UTdMove_Grab::IsHangingFree
          {
            if ( v6.IsHangingFree() )
            {
              if ( this.PawnOwner.MoveActionHint == MAH_Up )
                this.TransferHint = MAH_Up;
            }
          }
          else
          {
            this.TransferHint = this.PawnOwner.MoveActionHint;
          }
        }
        else
        {
          this.TransferHint = v9;
        }
      }
    }
    v10 = this.PawnOwner;
    v11 = E_ClipAmountOfTurns( v10.Rotation, &a5a);
    v12 = E_ClipAmountOfTurns( v10.Controller.Rotation, &v20);
    v13 = v12->Pitch - v11->Pitch;
    v14 = v12->Yaw - v11->Yaw;
    a5a.Roll = v12->Roll - v11->Roll;
    a5a.Pitch = v13;
    a5a.Yaw = v14;
    v15 = E_ClipAmountOfTurns(a5a, &v20);
    v16 = v15->Roll;
    a5a.Pitch = v15->Pitch;
    v17 = v15->Yaw;
    v18 = this.TransferHint;
    a5a.Roll = v16;
    if ( v18 == MAH_Up && (v17 < -8192 || v17 > 0x2000) || v18 == MAH_Left && (v17 > 0x2000 || v17 < -16384) || v18 == MAH_Right && (v17 < -8192 || v17 > 0x4000) )
      this.TransferHint = MAH_None;
    if ( CheckReachableTransferMoveVolume(ref out_MoveLocation, ref out_MoveNormal, ref out_LedgeLocation) )
    {
      this.TransferMove = MOVE_IntoClimb;
      result = true;
    }
    else if ( CheckReachableTransferLedge(ref out_MoveLocation, ref out_MoveNormal, ref out_LedgeLocation, ref out_LedgeNormal) )
    {
      this.TransferMove = MOVE_IntoGrab;
      result = true;
    }
    else
    {
      result = default;
    }
    return result != default;
  }
}
}
