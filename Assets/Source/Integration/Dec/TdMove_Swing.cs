// NO OVERWRITE

namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdMove_Swing
{
  public unsafe void UpdateShimmy(float a2)
  {
    int v3 = default; // edi
    int v4 = default; // eax
    float v5 = default; // edx
    float v6 = default; // xmm0_4
    float v7 = default; // eax
    float v8 = default; // [esp+8h] [ebp-10h]
  
    if ( (this.bIsInterpolatingInto.AsBitfield(3) & 2) != default )
    {
      v8 = this.CustomAnimNode.NodeTotalWeight * this.ShimmyVelocity * a2;
      if ( this.CanShimmy(((v8))) )// UTdMove_Swing::CanShimmy
      {
        v5 = this.SwingLocation.Y + (float)(this.BarDirection.Y * v8);
        v6 = this.ShimmyTime - a2;
        v7 = this.SwingLocation.Z + (float)(this.BarDirection.Z * v8);
        this.SwingLocation.X = this.SwingLocation.X + (float)(this.BarDirection.X * v8);
        this.SwingLocation.Y = v5;
        this.SwingLocation.Z = v7;
        this.ShimmyTime = v6;
        if ( v6 < 0.0f )
          this.AbortShimmy();
      }
      else
      {
        v3 = this.VfTableObject.Dummy;
        CallUFunction(this.AbortShimmy, this, v4, 0, 0);
      }
    }
  }

  public unsafe bool CanShimmy(float a2)
  {
    TdSwingVolume v3 = default; // ecx
    bool result = default; // eax
  
    v3 = this.Volume;
    if(v3 != default)
      result = v3.Encompasses(new Vector(this.SwingLocation.X + (float)(this.BarDirection.X * a2), this.SwingLocation.Y + (float)(this.BarDirection.Y * a2), this.SwingLocation.Z + (float)(this.BarDirection.Z * a2)));
    else
      result = default;
    return result != default;
  }

  public unsafe Vector * GetPawnLocation(Vector *a2, float a3)
  {
    double v3 = default; // st7
    float v4 = default; // xmm1_4
    float v5 = default; // xmm2_4
    float v6 = default; // xmm3_4
    float v7 = default; // xmm4_4
    float v8 = default; // xmm1_4
    float v9 = default; // xmm2_4
    float v10 = default; // xmm5_4
    float v11 = default; // xmm0_4
    float v12 = default; // xmm3_4
    float v13 = default; // xmm5_4
    float v14 = default; // xmm1_4
    float v15 = default; // xmm1_4
    float v16 = default; // xmm2_4
    float v17 = default; // xmm2_4
    float v18 = default; // xmm0_4
    Vector v20 = default; // [esp+8h] [ebp-Ch] BYREF
    float a3a = default; // [esp+1Ch] [ebp+8h]
    float a3b = default; // [esp+1Ch] [ebp+8h]
  
    v3 = a3;
    a3a = (float)(sin(a3));
    v4 = this.SwingDirection.X * a3a;
    v5 = this.SwingDirection.Y * a3a;
    v6 = this.SwingDirection.Z * a3a;
    a3b = (float)(cos(v3));
    v7 = (float)(a3b * 0.0f) - v4;
    v8 = this.SwingPendulumLength;
    v9 = (float)((float)(a3b * 0.0f) - v5) * v8;
    v10 = a3b - v6;
    v11 = this.SwingLocation.X - (float)(v7 * v8);
    v12 = this.SwingLocation.X - v11;
    v13 = v10 * v8;
    v14 = this.SwingLocation.Y;
    a2->X = v11;
    v15 = v14 - v9;
    v16 = this.SwingLocation.Z;
    v20.Y = this.SwingLocation.Y - v15;
    v17 = v16 - v13;
    v18 = this.SwingLocation.Z - v17;
    a2->Y = v15;
    a2->Z = v17;
    v20.X = v12;
    v20.Z = v18;
    v20.Normalize();// Wth is going on here, v20 is a locally declared variable, which is normalized and not used anywhere ?
    return a2;
  }

  public override unsafe void UpdateMoveTimer(float a2)
  {
    int v2 = default; // edi
    int v3 = default; // esi
    float v5 = default; // xmm0_4
    float v6 = default; // xmm0_4
    int v7 = default; // edi
    int v8 = default; // eax
    TdPawn v9 = default; // edi
    int v10 = default; // edi
    int v11 = default; // eax
    int v12 = default; // [esp+4h] [ebp-70h]
    int v13 = default; // [esp+8h] [ebp-6Ch]
    float v14 = default; // [esp+18h] [ebp-5Ch] BYREF
    Vector Line = default; // [esp+1Ch] [ebp-58h] BYREF
    Vector a2a = default; // [esp+28h] [ebp-4Ch] BYREF
    Matrix v17 = default; // [esp+34h] [ebp-40h] BYREF
  
    NativeMarkers.MarkUnimplemented("This function has been decompiled in a weird way, I wouldn't trust it");
    
    v13 = v3;                                     // Suspicious
    v5 = this.Timer;
    v12 = v2;                                     // So is this
    if ( v5 > 0.0f )
    {
      v6 = v5 - a2;
      this.Timer = v6;
      if ( v6 <= 0.0f )
      {
        v7 = this.VfTableObject.Dummy;
        this.Timer = 0.0f;
        CallUFunction(this.OnMoveTimer, this, v8, 0, 0);
      }
    }
    v9 = this.PawnOwner;
    this.MoveActiveTime = this.MoveActiveTime + a2;
    if ( v9.Role < ROLE_AutonomousProxy )
    {
      if ( v9.ActiveMovementVolume )
      {
        Line = FRotationMatrix(&v17, v9.ActiveMovementVolume.Rotation)->YPlane.Vector;
fixed(Vector* ptr2 =&this.SwingLocation)
fixed(Vector* ptr3 =&v9.ActiveMovementVolume.Location)
fixed(Vector* ptr4 =&v9.Location)
        Source.DecFn.PointDistToLine( ptr4, &Line,  ptr3,  ptr2);
        this.SwingDirection = *this.PawnOwner.Rotation.Vector(&a2a);
      }
      this.SwingAngle = this.GetPawnAngle(
                           this.PawnOwner.Location);
    }
    v10 = this.VfTableObject.Dummy;
    v14 = this.SwingAngle;
    this.SetPawnRotation(v14); //CallUFunction(, this, v11, &v14, 0, v12, v13);
  }

  public unsafe float GetPawnAngle(Vector a1)
  {
    Rotator *v2; // eax
    float v3 = default; // xmm1_4
    double v4 = default; // st7
    float v5 = default; // xmm0_4
    float v7 = default; // [esp+8h] [ebp-9Ch]
    float v8 = default; // [esp+8h] [ebp-9Ch]
    Vector v9 = default; // [esp+Ch] [ebp-98h] BYREF
    Vector rot_then_vec = default; // [esp+18h] [ebp-8Ch] BYREF
    Matrix DstMatrix = default; // [esp+24h] [ebp-80h] BYREF
    Matrix SrcMatrix = default; // [esp+64h] [ebp-40h] BYREF
  
    v9.X = a1.X - this.SwingLocation.X;
    v9.Y = a1.Y - this.SwingLocation.Y;
    v9.Z = a1.Z - this.SwingLocation.Z;
    v2 = E_DirToRotator( this.SwingDirection, (Rotator *)&rot_then_vec);
    FRotationMatrix(&SrcMatrix, *v2);
    DstMatrix = SrcMatrix.Inverse();
    rot_then_vec.Z = (float)((float)((float)(DstMatrix.XPlane.Z * v9.X) + (float)(DstMatrix.ZPlane.Z * v9.Z)) + (float)(DstMatrix.YPlane.Z * v9.Y)) + DstMatrix.WPlane.Z;
    rot_then_vec.X = (float)((float)((float)(DstMatrix.ZPlane.X * v9.Z) + (float)(DstMatrix.XPlane.X * v9.X)) + (float)(DstMatrix.YPlane.X * v9.Y)) + DstMatrix.WPlane.X;
    rot_then_vec.Y = (float)((float)((float)(DstMatrix.XPlane.Y * v9.X) + (float)(DstMatrix.ZPlane.Y * v9.Z)) + (float)(DstMatrix.YPlane.Y * v9.Y)) + DstMatrix.WPlane.Y;
    v9.Z = rot_then_vec.Z;
    v9.X = rot_then_vec.X;
    v9.Y = 0.0f;
    v9.Normalize();
    v3 = -1.0f;
    if ( v9.Z <= 0.0f )
    {
      if ( v9.X < -1.0f || ((v3 = 1.0f) is object && v9.X >= 1.0f) )
        v7 = v3;
      else
        v7 = v9.X;
      v4 = asin(v7);
    }
    else if ( v9.X < -1.0f || ((v3 = 1.0f) is object && v9.X >= 1.0f) )
    {
      v4 = 3.1415927f - asin(v3);
    }
    else
    {
      v4 = 3.1415927f - asin(v9.X);
    }
    v8 = (float)v4;
    v5 = v8;
    if ( v8 > 3.1415927f )
      v5 = v8 - 6.2831855f;
    return (float)(v5);
  }

  public unsafe TdSwingVolume  CheckForTargetVolume(Vector a1)
  {
    float v3 = default; // xmm1_4
    TdSwingVolume v4 = default; // eax
    float v5 = default; // xmm2_4
    float v6 = default; // xmm1_4
    float v7 = default; // xmm0_4
    float v8 = default; // xmm4_4
    float v9 = default; // xmm3_4
    float v10 = default; // xmm4_4
    float v11 = default; // xmm2_4
    float v12 = default; // xmm0_4
    float v13 = default; // xmm3_4
    float v14 = default; // xmm0_4
    float v15 = default; // xmm1_4
    float v16 = default; // xmm2_4
    int v17 = default; // edi
    int v18 = default; // ecx
    float v19 = default; // xmm2_4
    float v20 = default; // xmm3_4
    TdSwingVolume result = default; // eax
    Vector a4a = default; // [esp+0h] [ebp-7Ch] BYREF
    float v23 = default; // [esp+Ch] [ebp-70h]
    float v24 = default; // [esp+10h] [ebp-6Ch]
    float v25 = default; // [esp+14h] [ebp-68h]
    Vector a5 = default; // [esp+18h] [ebp-64h] BYREF
    Vector a3a = default; // [esp+24h] [ebp-58h] BYREF
    CheckResult a2a = default; // [esp+30h] [ebp-4Ch] BYREF
    int v29 = default; // [esp+78h] [ebp-4h]
  
    v3 = (float)(500.0f / this.MaxSwingVelocity) * this.SwingVelocity;
    a2a.Next = default;
    a2a.Actor = default;
    a2a.Location.X = 0.0f;
    a2a.Location.Y = 0.0f;
    a2a.Location.Z = 0.0f;
    a2a.Normal.X = 0.0f;
    a2a.Normal.Y = 0.0f;
    a2a.Normal.Z = 0.0f;
    a2a.Time = 1.0f;
    a2a.Item = -1;
    a2a.Material = default;
    a2a.PhysMaterial = default;
    a2a.Component = default;
    a2a.BoneName = default;
    a2a.Level = default;
    a2a.LevelIndex = -1;
    a2a.bStartPenetrating = default;
    v29 = default;
    if ( v3 <= 0.0f )
      v3 = 0.0f;
    v4 = this.Volume;
    v5 = this.SwingDirection.X * 100.0f;
    v6 = v3 + 100.0f;
    v7 = v4.Location.Y + (float)(this.SwingDirection.Y * 100.0f);
    v8 = v4.Location.X;
    a4a.Z = v4.Location.Z + (float)(this.SwingDirection.Z * 100.0f);
    v9 = this.SwingDirection.Z;
    v10 = v8 + v5;
    v11 = this.SwingDirection.Y;
    a4a.Y = v7;
    v12 = this.SwingDirection.X;
    v13 = v9 * v6;
    a4a.X = v10;
    v14 = v12 * v6;
    v15 = v4.Location.Y + (float)(v11 * v6);
    v16 = v4.Location.Z + v13;
    a3a.X = v4.Location.X + v14;
    a3a.Y = v15;
    a3a.Z = v16;
    v17 = default;
    while(1 != default)
    {
      a5.X = 1.0f;
      a5.Y = 1.0f;
      a5.Z = 1.0f;
      if ( default == this.MovementLineCheck(ref a2a, &a3a, &a4a, &a5, 1032) )
        break;
      v18 = v17++;
      if ( v18 > 10 )
        break;
      v19 = this.SwingDirection.Z * 10.0f;
      v20 = a2a.Location.X + (float)(this.SwingDirection.X * 10.0f);
      v24 = a2a.Location.Y + (float)(this.SwingDirection.Y * 10.0f);
      v23 = v20;
      a4a.X = v20;
      v25 = a2a.Location.Z + v19;
      a4a.Y = v24;
      a4a.Z = a2a.Location.Z + v19;
      result = E_TryCastTo<TdSwingVolume>(a2a.Actor);
      if ( result && result != this.Volume )
        return result;
    }
    return default;
  }

  public override unsafe void PrePerformPhysics(float DeltaTime)
  {
    TdPawn v3 = default; // ecx
    uint v4 = default; // edx
    EMoveActionHint v5 = default; // cl
    float v6 = default; // xmm0_4
    float v7 = default; // xmm0_4
    float v8 = default; // xmm1_4
    float v9 = default; // xmm0_4
    float v10 = default; // xmm2_4
    bool v11 = default; // cf
    float v12 = default; // xmm2_4
    float v13 = default; // xmm0_4
    float v14 = default; // xmm1_4
    float v15 = default; // xmm1_4
    float v16 = default; // xmm0_4
    uint v17 = default; // ecx
    TdPawn v18 = default; // eax
    float v19 = default; // xmm2_4
    float v20 = default; // xmm3_4
    float v21 = default; // xmm1_4
    float v22 = default; // xmm0_4
    TdSwingVolume v23 = default; // ecx
    double v24 = default; // st6
    double v25 = default; // st5
    float v26 = default; // xmm2_4
    float v27 = default; // xmm3_4
    float v28 = default; // xmm0_4
    float v29 = default; // [esp+14h] [ebp-1Ch]
    float v30 = default; // [esp+14h] [ebp-1Ch]
    float v31 = default; // [esp+14h] [ebp-1Ch]
    float v32 = default; // [esp+14h] [ebp-1Ch]
    float v33 = default; // [esp+14h] [ebp-1Ch]
    Vector v34 = default; // [esp+18h] [ebp-18h] BYREF
    Vector v35 = default; // [esp+24h] [ebp-Ch]
  
    v3 = this.PawnOwner;
    if ( v3.Role >= ROLE_AutonomousProxy )
    {
      v4 = this.bIsInterpolatingInto.AsBitfield(3);
      if ( (v4 & 1) == default )
        this.SwingVelocity = this.SwingVelocity - (float)(sin(this.SwingAngle) * DeltaTime * 10.0f);
      if ( (v4 & 1) == default )
        this.SwingVelocity = this.SwingVelocity - (float)((float)(this.SwingVelocity * DeltaTime) * 0.80000001d);
      if ( (v4 & 1) == default && (v4 & 6) == default )
      {
        v5 = v3.MoveActionHint;
        if ( v5 == MAH_Up && ((v6 = this.SwingVelocity) is object && v6 >= 0.0f) )
        {
          this.SwingVelocity = (float)(DeltaTime * 3.0f) + v6;
        }
        else if ( v5 == MAH_Down )
        {
          v7 = this.SwingVelocity;
          if ( v7 <= 0.0f )
            this.SwingVelocity = v7 - (float)(DeltaTime * 3.0f);
        }
      }
      v8 = this.SwingAngle;
      if ( v8 <= 0.0f )
      {
        if ( v8 >= 0.0f )
        {
          goto LABEL_21;
        }
        v9 = this.SwingVelocity;
        v30 = (float)(-(cos(v8) * this.MaxSwingVelocity));
        v10 = v30;
        v11 = v9 < v30;
      }
      else
      {
        v9 = this.SwingVelocity;
        v29 = (float)(cos(v8) * this.MaxSwingVelocity);
        v10 = v29;
        v11 = v29 < v9;
      }
      if(v11 != default)
        v9 = v10;
      this.SwingVelocity = v9;
      goto LABEL_21;
    }
  LABEL_43:
    base.PrePerformPhysics(DeltaTime);
    return;
    
  LABEL_21:
    v12 = v8;
    v31 = v8;
    if ( (v4 & 1) == default )
    {
      v13 = (float)(this.SwingVelocity * DeltaTime) + v8;
      v14 = -3.1415927f;
      if ( v13 < -3.1415927f || ((v14 = 3.1415927f) is object && v13 > 3.1415927f) )
        v13 = v14;
      this.SwingAngle = v13;
    }
    if ( (v4 & 4) != default )
    {
      if ( v12 == 0.0f )
      {
        v15 = 0.0f;
      }
      else
      {
        v32 = (float)(v31 / fabs(v31));
        v15 = v32;
      }
      if ( this.SwingAngle == 0.0f )
      {
        v16 = 0.0f;
      }
      else
      {
        v33 = (float)(this.SwingAngle / fabs(this.SwingAngle));
        v16 = v33;
      }
      if ( v15 != v16 )
        this.OnMoveTimer();
    }
    this.UpdateShimmy( (DeltaTime));// UTdMove_Swing::UpdateShimmy
    this.GetPawnLocation( &v34, this.SwingAngle);// UTdMove_Swing::GetPawnLocation
    v17 = this.bIsInterpolatingInto.AsBitfield(3);
    if ( (v17 & 1) != default )
    {
      v18 = this.PawnOwner;
      v19 = v34.Y - v18.Location.Y;
      v20 = v34.Z - v18.Location.Z;
      v21 = v34.X - v18.Location.X;
      if ( (float)((float)((float)(v20 * v20) + (float)(v19 * v19)) + (float)(v21 * v21)) >= 4.0f )
      {
        v22 = this.MoveActiveTime / this.AnimBlendTime;
        v35.X = v18.Location.X + (float)(v21 * v22);
        v35.Y = v18.Location.Y + (float)(v19 * v22);
        v35.Z = v18.Location.Z + (float)(v20 * v22);
        v34 = v35;
      }
      else
      {
        SetFromBitfield(ref this.bIsInterpolatingInto, 3, v17 & ~1u);
      }
    }
    v23 = this.Volume;
    if ( (v23.bSnapToCenter.AsBitfield(2) & 1) != default )
    {
      v24 = this.SwingLocation.Y - v23.Location.Y;
      v25 = this.SwingLocation.X - v23.Location.X;
      if ( sqrt(v25 * v25 + v24 * v24) > 0.00000001f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
      {
        v26 = (float)((float)(this.SwingLocation.Z - v23.Location.Z) * DeltaTime) * 2.0f;
        v27 = this.SwingLocation.X - (float)((float)((float)(this.SwingLocation.X - v23.Location.X) * DeltaTime) * 2.0f);
        this.SwingLocation.Y = this.SwingLocation.Y - (float)((float)((float)(this.SwingLocation.Y - v23.Location.Y) * DeltaTime) * 2.0f);
        v28 = this.SwingLocation.Z - v26;
        this.SwingLocation.X = v27;
        this.SwingLocation.Z = v28;
      }
    }
    this.PawnOwner.SetLocation(v34);
    goto LABEL_43;
  }
}
}
