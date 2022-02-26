// NO OVERWRITE

namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdMove
{
  public unsafe bool CallOnCanDoMove()
  {
    int v2 = default; // edi
    int v3 = default; // eax
    bool v5 = default; // [esp+Ch] [ebp-4h] BYREF
  
    v2 = this.VfTableObject.Dummy;
    v5 = default;
    CallUFunction(this.OnCanDoMove, this, v3, &v5, 0);
    return v5 != default;
  }

  public unsafe void CallFailedToReachPreciseLocation()
  {
    int v2 = default; // edi
    int v3 = default; // eax
  
    v2 = this.VfTableObject.Dummy;
    CallUFunction(this.FailedToReachPreciseLocation, this, v3, 0, 0);
  }

  public virtual unsafe void UpdateMoveTimer(float DeltaTime)
  {
    float v3 = default; // xmm0_4
    float v4 = default; // xmm0_4
    int v5 = default; // edi
    int v6 = default; // eax
  
    v3 = this.Timer;
    if ( v3 > 0.0f )
    {
      v4 = v3 - DeltaTime;
      this.Timer = v4;
      if ( v4 <= 0.0f )
      {
        v5 = this.VfTableObject.Dummy;
        this.Timer = 0.0f;
        CallUFunction(this.OnMoveTimer, this, v6, 0, 0);
      }
    }
    this.MoveActiveTime = this.MoveActiveTime + DeltaTime;
  }

  public unsafe EMoveAimMode GetAimMode( bool aimingOnly ) => GetAimMode(aimingOnly ? 1 : 0);
  public virtual unsafe EMoveAimMode GetAimMode(int a2)
  {
    return this.AimMode;
  }

  public unsafe void GetLastMovementTraceInfoStatic(ref Actor HitActor, uint *ExcludeHandMoves, uint *ExcludeFootMoves)
  {
    uint v3 = default; // eax
  
    HitActor = static_FCheckResult.Actor;
    if ( static_FCheckResult.Actor )
      v3 = static_FCheckResult.Actor.bExludeHandMoves.AsBitfield(32) & 1;
    else
      v3 = default;
    *ExcludeHandMoves = v3;
    if ( static_FCheckResult.Actor )
      *ExcludeFootMoves = (static_FCheckResult.Actor.bExludeHandMoves.AsBitfield(32) >> 1) & 1;
    else
      *ExcludeFootMoves = default;
  }

  public unsafe float CalculateRelativeExtent(float BaseExtent)
  {
    TdPawn v2 = default; // edx
    float v3 = default; // xmm2_4
    float v4 = default; // xmm1_4
    //Vector *v5; // edx
    float v6 = default; // xmm0_4
    float v7 = default; // xmm2_4
    double v8 = default; // st6
    double v9 = default; // st7
    Vector *v10; // ecx
    float v11 = default; // xmm0_4
    float v12 = default; // xmm1_4
    float v13 = default; // xmm0_4
    double v14 = default; // rt1
    double v15 = default; // st6
    double v16 = default; // st7
    double v17 = default; // st6
    float v18 = default; // xmm0_4
    float v19 = default; // xmm0_4
    float v21 = default; // [esp+0h] [ebp-58h]
    float v22 = default; // [esp+0h] [ebp-58h]
    float v23 = default; // [esp+4h] [ebp-54h]
    float v24 = default; // [esp+4h] [ebp-54h]
    Vector v25 = default; // [esp+8h] [ebp-50h]
    float v26 = default; // [esp+18h] [ebp-40h]
    Vector a2a = default; // [esp+28h] [ebp-30h] BYREF
    float v28 = default; // [esp+38h] [ebp-20h]
    float v29 = default; // [esp+48h] [ebp-10h]
  
    v2 = this.PawnOwner;
    v3 = v2.MoveNormal.Y;
    v4 = v2.MoveNormal.X;
    v6 = (float)(v4 * v4) + (float)(v3 * v3);
    if ( v6 == 1.0f )
    {
      if ( v2.MoveNormal.Z == 0.0f )
      {
        v25 = v2.MoveNormal;
        goto LABEL_9;
      }
      v25.X = v4;
      v25.Y = v2.MoveNormal.Y;
    }
    else if ( v6 >= SMALL_NUMBER )
    {
      v7 = 1.0f / fsqrt(v6);
      a2a.X = (float)(3.0f - (float)((float)(v7 * v6) * v7)) * (float)(v7 * 0.5f);
      v25.Y = a2a.X * v2.MoveNormal.Y;
      v25.X = v2.MoveNormal.X * a2a.X;
    }
    else
    {
      v25.X = 0.0f;
      v25.Y = 0.0f;
    }
    v25.Z = 0.0f;
  LABEL_9:
    v8 = v25.X;
    v9 = v25.Y;
    if ( sqrt(v25.Z * v25.Z + v8 * v8 + v25.Y * v25.Y) <= 0.0001f )
    {
      v10 = this.PawnOwner.Rotation.Vector(&a2a);
      v11 = v10->X;
      v29 = (float)(v11 * v11) + (float)(v10->Y * v10->Y);
      if ( v29 == 1.0f )
      {
        if ( v10->Z == 0.0f )
          v11 = v10->X;
        v12 = v10->Y;
      }
      else if ( v29 >= SMALL_NUMBER )
      {
        v28 = 3.0f;
        v13 = fsqrt(v29);
        v26 = (float)(3.0f - (float)((float)((float)(1.0f / v13) * v29) * (float)(1.0f / v13))) * (float)((float)(1.0f / v13) * 0.5f);
        v11 = v10->X * v26;
        v12 = v10->Y * v26;
      }
      else
      {
        v11 = 0.0f;
        v12 = 0.0f;
      }
      v9 = (float)(-0.0f - v12);
      v8 = (float)(-0.0f - v11);
    }
    v14 = v8;
    v15 = fabs(v9);
    v21 = (float)v15;
    v16 = v15;
    v17 = fabs(v14);
    if ( v17 < v16 )
    {
      v18 = v21;
    }
    else
    {
      v23 = (float)v17;
      v18 = v23;
    }
    v24 = v18;
    v19 = v18 * v18;
    if ( v19 < 1.0f )
      v22 = v19;
    else
      v22 = 1.0f;
    return (float)(sqrt(1.0f - v22) * v24 * BaseExtent * 0.82842702d);
  }

  public unsafe bool MovementLineCheck(ref CheckResult a2, Vector *a3, Vector *a4, Vector *a5, uint TraceFlags)
  {
    TdPawn v7 = default; // ecx
    uint v8 = default; // ebx
    int v9 = default; // esi
    uint v10 = default; // ebx
    CheckResult *v11; // edx
    MaterialInterface v12 = default; // ecx
    MaterialInterface v13 = default; // eax
    int v15 = default; // [esp+10h] [ebp-8h]
    int v16 = default; // [esp+14h] [ebp-4h]
    CheckResult *TraceFlagsa; // [esp+2Ch] [ebp+14h]
  
    v7 = this.PawnOwner;
    v8 = v7.bForceDemoRelevant.AsBitfield(32);
    SetFromBitfield(ref v7.bForceDemoRelevant, 32, v8 | 2147483648);
    v9 = FMemMark_Maybe;
    v15 = GMem;
    v10 = v8 >> 31;
    v16 = FMemMark_Maybe;
    v11 = GWorld.MultiLineCheck(ref GMem, *a3, *a4, *a5, TraceFlags | 0x400u, this.PawnOwner, null);
    TraceFlagsa = v11;
    if(v11 != default)
    {
      qmemcpy(ref a2, *v11, 0x4Cu);
      v12 = a2.Material;
      if(v12 != default)
      {
        v13 = (MaterialInterface )v12.GetMaterial( /*dword_1FFA334*/0);// UMaterial::GetMaterial
        v11 = TraceFlagsa;
        v9 = v16;
        a2.Material = v13;
      }
      else
      {
        v9 = v16;
        a2.Material = default;
      }
    }
    else
    {
      a2.Time = 1.0f;
      a2.Actor = default;
    }
    if ( v9 != FMemMark_Maybe )
    {
      FMemMark_Pop_Maybe(ref GMem, v9);
      v11 = TraceFlagsa;
    }
    GMem = v15;
    SetFromBitfield(ref this.PawnOwner.bForceDemoRelevant, 32, this.PawnOwner.bForceDemoRelevant.AsBitfield(32) & ~2147483648 | (v10 << 31));
    return v11 != default;
  }

  public unsafe bool FindLedge(ref LedgeHitInfo out_LedgeHit, Vector Start, Vector End, Vector Extent)
  {
    float v5 = default; // xmm5_4
    float v6 = default; // xmm6_4
    float v7 = default; // xmm7_4
    float v9 = default; // xmm0_4
    float v10 = default; // xmm5_4
    float v11 = default; // xmm6_4
    float v12 = default; // xmm2_4
    float v13 = default; // xmm0_4
    float v14 = default; // xmm2_4
    float v15 = default; // xmm1_4
    float v16 = default; // ebx
    float v17 = default; // xmm5_4
    float v18 = default; // edi
    float v19 = default; // esi
    float v20 = default; // xmm0_4
    float v21 = default; // xmm1_4
    float v22 = default; // xmm2_4
    double v23 = default; // st6
    double v24 = default; // st4
    float v25 = default; // xmm0_4
    float v26 = default; // xmm0_4
    float v27 = default; // xmm3_4
    double v28 = default; // st7
    Vector v30 = default; // [esp-1Ch] [ebp-B4h]
    float v31 = default; // [esp+0h] [ebp-98h]
    float v32 = default; // [esp+0h] [ebp-98h]
    float v33 = default; // [esp+0h] [ebp-98h]
    Vector v34 = default; // [esp+4h] [ebp-94h] BYREF
    Vector v35 = default; // [esp+14h] [ebp-84h] BYREF
    float v36 = default; // [esp+24h] [ebp-74h]
    float v37 = default; // [esp+28h] [ebp-70h]
    CheckResult a2a = default; // [esp+2Ch] [ebp-6Ch] BYREF
    int v39 = default; // [esp+74h] [ebp-24h]
    float v40 = default; // [esp+78h] [ebp-20h]
    float v41 = default; // [esp+88h] [ebp-10h]
  
    v5 = End.Y - Start.Y;
    v6 = End.Z - Start.Z;
    v7 = End.X - Start.X;
    a2a.Next = default;
    a2a.Actor = default;
    a2a.Material = default;
    a2a.PhysMaterial = default;
    a2a.Component = default;
    a2a.BoneName = default;
    a2a.Level = default;
    a2a.bStartPenetrating = default;
    v39 = default;
    v37 = this.PawnOwner.LedgeFindDepth;
    v9 = (float)((float)(v6 * v6) + (float)(v5 * v5)) + (float)(v7 * v7);
    a2a.Location.X = 0.0f;
    a2a.Location.Y = 0.0f;
    a2a.Location.Z = 0.0f;
    a2a.Normal = default;
    a2a.Time = 0.0f;
    a2a.Item = -1;
    a2a.LevelIndex = -1;
    v35.X = End.X - Start.X;
    v35.Y = End.Y - Start.Y;
    v35.Z = End.Z - Start.Z;
    v40 = v9;
    if ( v9 == 1.0f )
    {
      v34 = v35;
      v10 = v35.Y;
    }
    else
    {
      if ( v9 < SMALL_NUMBER )
      {
        v11 = 0.0f;
        v10 = 0.0f;
        v34.X = 0.0f;
        v34.Y = 0.0f;
        v34.Z = 0.0f;
        goto LABEL_7;
      }
      v12 = 1.0f / fsqrt(v40);
      v35.X = (float)(3.0f - (float)((float)(v12 * v40) * v12)) * (float)(v12 * 0.5f);
      v10 = v5 * v35.X;
      v34.X = v35.X * v7;
      v34.Y = v10;
      v34.Z = v6 * v35.X;
    }
    v11 = v34.X;
  LABEL_7:
    v13 = (float)(v10 * v10) + (float)(v11 * v11);
    v41 = v13;
    if ( v13 != 1.0f )
    {
      if ( v13 < SMALL_NUMBER )
      {
        v35.X = 0.0f;
        v35.Y = 0.0f;
  LABEL_15:
        v35.Z = 0.0f;
        goto LABEL_16;
      }
      v40 = 3.0f;
      v14 = 1.0f / fsqrt(v41);
      v15 = (float)(3.0f - (float)((float)(v14 * v41) * v14)) * (float)(v14 * 0.5f);
      v35.X = v15 * v11;
      v10 = v10 * v15;
  LABEL_14:
      v35.Y = v10;
      v35.Z = 0.0f;
      goto LABEL_16;
    }
    if ( v34.Z != 0.0f )
    {
      v35.X = v11;
      v35.Y = v10;
      v35.Z = 0.0f;
      goto LABEL_16;
    }
    v35.X = v34.X;
    v35.Y = v34.Y;
    v35.Z = 0.0f;
  LABEL_16:
    if ( default == MovementLineCheck(ref a2a, &End, &Start, &Extent, 9422) || a2a.Time <= 0.0f )
      return false;
    v16 = a2a.Normal.Z;
    v17 = a2a.Normal.Y;
    v18 = a2a.Normal.Y;
    v19 = a2a.Normal.X;
    v20 = (float)(v17 * v17) + (float)(a2a.Normal.X * a2a.Normal.X);
    v40 = v20;
    if ( v20 == 1.0f )
    {
      if ( a2a.Normal.Z == 0.0f )
      {
        v34.X = a2a.Normal.X;
        v21 = a2a.Normal.X;
        v34.Y = a2a.Normal.Y;
        v34.Z = 0f;
        v17 = a2a.Normal.Y;
        goto LABEL_26;
      }
      v21 = a2a.Normal.X;
    }
    else if ( v20 >= SMALL_NUMBER )
    {
      v41 = 3.0f;
      v22 = 1.0f / fsqrt(v40);
      v34.X = (float)(3.0f - (float)((float)(v22 * v40) * v22)) * (float)(v22 * 0.5f);
      v21 = v34.X * a2a.Normal.X;
      v17 = a2a.Normal.Y * v34.X;
    }
    else
    {
      v21 = 0.0f;
      v17 = 0.0f;
    }
    v34.X = v21;
    v34.Y = v17;
    v34.Z = 0.0f;
  LABEL_26:
    v23 = fabs(v34.Y);
    v36 = (float)v23;
    v24 = fabs(v34.X);
    if ( v24 < v23 )
    {
      v25 = v36;
    }
    else
    {
      v31 = (float)v24;
      v25 = v31;
    }
    v32 = v25;
    v26 = v25 * v25;
    if ( v26 < 1.0f )
      v36 = v26;
    else
      v36 = 1.0f;
    v33 = (float)((sqrt(1.0f - v36) * v32 * 0.82842702d + 1.0f) * Extent.X);
    v27 = v33;
    v28 = fabs(v34.Y * v35.Y + v34.Z * v35.Z + v34.X * v35.X);
    v36 = (float)v28;
    if ( v28 > 0.0f )
      v27 = v33 / v36;
    v34.Y = a2a.Location.Y + (float)(v35.Y * v27);
    v34.X = (float)(v35.X * v27) + a2a.Location.X;
    Start.Y = v34.Y - (float)(v17 * v37);
    End.Y = Start.Y;
    Start.X = v34.X - (float)(v21 * v37);
    Start.Z = (float)((float)((float)(v35.Z * v27) + a2a.Location.Z) - (float)(0.0f * v37)) + Extent.Z;
    End.X = Start.X;
    End.Z = Start.Z - (float)(Extent.Z * 2.0f);
    v35.X = 0.0f;
    v35.Y = 0.0f;
    v35.Z = 0.0f;
    if ( MovementLineCheck(ref a2a, &End, &Start, &v35, 9422) && a2a.Time > 0.0f )
    {
      v30.X = v19;
      *(_QWORD *)&v30.Y = __PAIR64__(LODWORD(v16), LODWORD(v18));
      v34.Z = a2a.Location.Z;
      E_FLedgeHitInfo_FillWith(ref out_LedgeHit, &a2a, &v34, a2a.Normal, v30);
      return true;
    }
    return false;
  }

  public unsafe int FindLedgeEx(ref LedgeHitInfo out_LedgeHit, Vector Start, Vector End, Vector Extent)
  {
    float v5 = default; // xmm5_4
    float v6 = default; // xmm6_4
    float v7 = default; // xmm7_4
    float v9 = default; // xmm0_4
    float v10 = default; // xmm5_4
    float v11 = default; // xmm6_4
    float v12 = default; // xmm2_4
    float v13 = default; // xmm0_4
    float v14 = default; // xmm2_4
    float v15 = default; // ebx
    float v16 = default; // xmm5_4
    float v17 = default; // edi
    float v18 = default; // esi
    float v19 = default; // xmm0_4
    float v20 = default; // xmm1_4
    float v21 = default; // xmm2_4
    double v22 = default; // st6
    double v23 = default; // st4
    float v24 = default; // xmm0_4
    float v25 = default; // xmm0_4
    float v26 = default; // xmm3_4
    double v27 = default; // st7
    Vector v29 = default; // [esp-28h] [ebp-E4h]
    Vector v30 = default; // [esp-1Ch] [ebp-D8h]
    Vector v31 = default; // [esp-1Ch] [ebp-D8h]
    float v32 = default; // [esp+0h] [ebp-BCh]
    float v33 = default; // [esp+0h] [ebp-BCh]
    float v34 = default; // [esp+0h] [ebp-BCh]
    Vector v35 = default; // [esp+4h] [ebp-B8h] BYREF
    Vector v36 = default; // [esp+14h] [ebp-A8h] BYREF
    float v37 = default; // [esp+24h] [ebp-98h]
    Vector a3 = default; // [esp+28h] [ebp-94h] BYREF
    Vector a4 = default; // [esp+34h] [ebp-88h] BYREF
    Vector a5 = default; // [esp+40h] [ebp-7Ch] BYREF
    CheckResult a2 = default; // [esp+4Ch] [ebp-70h] BYREF
    int v42 = default; // [esp+94h] [ebp-28h]
    float v43 = default; // [esp+98h] [ebp-24h]
    float v44 = default; // [esp+9Ch] [ebp-20h]
    float v45 = default; // [esp+ACh] [ebp-10h]
  
    v5 = End.Y - Start.Y;
    v6 = End.Z - Start.Z;
    v7 = End.X - Start.X;
    a2.Next = default;
    a2.Actor = default;
    a2.Material = default;
    a2.PhysMaterial = default;
    a2.Component = default;
    a2.BoneName = default;
    a2.Level = default;
    a2.bStartPenetrating = default;
    v42 = default;
    v43 = this.PawnOwner.LedgeFindDepth;
    v9 = (float)((float)(v6 * v6) + (float)(v5 * v5)) + (float)(v7 * v7);
    a2.Location.X = 0.0f;
    a2.Location.Y = 0.0f;
    a2.Location.Z = 0.0f;
    a2.Normal = default;
    a2.Time = 0.0f;
    a2.Item = -1;
    a2.LevelIndex = -1;
    a3.X = End.X - Start.X;
    a3.Y = End.Y - Start.Y;
    a3.Z = End.Z - Start.Z;
    v44 = v9;
    if ( v9 == 1.0f )
    {
      v35 = a3;
      v10 = a3.Y;
    }
    else
    {
      if ( v9 < SMALL_NUMBER )
      {
        v11 = 0.0f;
        v10 = 0.0f;
        v35.X = 0.0f;
        v35.Y = 0.0f;
        v35.Z = 0.0f;
        goto LABEL_7;
      }
      v12 = 1.0f / fsqrt(v44);
      v36.X = (float)(3.0f - (float)((float)(v12 * v44) * v12)) * (float)(v12 * 0.5f);
      v10 = v5 * v36.X;
      v35.X = v36.X * v7;
      v35.Y = v10;
      v35.Z = v6 * v36.X;
    }
    v11 = v35.X;
  LABEL_7:
    v13 = (float)(v10 * v10) + (float)(v11 * v11);
    v45 = v13;
    if ( v13 == 1.0f )
    {
      if ( v35.Z == 0.0f )
      {
        v36.X = v35.X;
        v36.Y = v35.Y;
        v36.Z = 0.0f;
        goto LABEL_16;
      }
      v36.X = v11;
      v36.Y = v10;
      goto LABEL_15;
    }
    if ( v13 >= SMALL_NUMBER )
    {
      v44 = 3.0f;
      v14 = 1.0f / fsqrt(v45);
      v36.X = (float)(3.0f - (float)((float)(v14 * v45) * v14)) * (float)(v14 * 0.5f);
      v10 = v10 * v36.X;
      v36.X = v36.X * v11;
  LABEL_14:
      v36.Y = v10;
      goto LABEL_15;
    }
    v36.X = 0.0f;
    v36.Y = 0.0f;
  LABEL_15:
    v36.Z = 0.0f;
  LABEL_16:
    a5.X = Extent.X;
    a5.Y = Extent.Y;
    a4.Y = Start.Y;
    a3.Y = Start.Y;
    a4.X = Start.X;
    a3.X = Start.X;
    a4.Z = Start.Z - (float)(Extent.Z - 1.0f);
    a3.Z = (float)(Extent.Z - 1.0f) + Start.Z;
    a5.Z = 1.0f;
    if ( MovementLineCheck(ref a2, &a3, &a4, &a5, 9414) && a2.Time > 0.0f || default == MovementLineCheck(ref a2, &End, &Start, &Extent, 9422) || a2.Time <= 0.0f )
      return 0;
    v15 = a2.Normal.Z;
    v16 = a2.Normal.Y;
    v17 = a2.Normal.Y;
    v18 = a2.Normal.X;
    v19 = (float)(v16 * v16) + (float)(a2.Normal.X * a2.Normal.X);
    v44 = v19;
    if ( v19 != 1.0f )
    {
      if ( v19 >= SMALL_NUMBER )
      {
        v45 = 3.0f;
        v21 = 1.0f / fsqrt(v44);
        v35.X = (float)(3.0f - (float)((float)(v21 * v44) * v21)) * (float)(v21 * 0.5f);
        v20 = v35.X * a2.Normal.X;
        v16 = a2.Normal.Y * v35.X;
      }
      else
      {
        v20 = 0.0f;
        v16 = 0.0f;
      }
      v35.X = v20;
      v35.Y = v16;
      v35.Z = 0.0f;
      goto LABEL_28;
    }
    if ( a2.Normal.Z != 0.0f )
    {
      v20 = a2.Normal.X;
  LABEL_27:
      v35.X = v20;
      v35.Y = v16;
      v35.Z = 0.0f;
      goto LABEL_28;
    }
    v35.X = a2.Normal.X;
    v20 = a2.Normal.X;
    v35.Y = a2.Normal.Y;
    v35.Z = 0f;
    v16 = a2.Normal.Y;
  LABEL_28:
    v22 = fabs(v35.Y);
    v37 = (float)v22;
    v23 = fabs(v35.X);
    if ( v23 < v22 )
    {
      v24 = v37;
    }
    else
    {
      v32 = (float)v23;
      v24 = v32;
    }
    v33 = v24;
    v25 = v24 * v24;
    if ( v25 < 1.0f )
      v37 = v25;
    else
      v37 = 1.0f;
    v34 = (float)((sqrt(1.0f - v37) * v33 * 0.82842702d + 1.0f) * Extent.X);
    v26 = v34;
    v27 = fabs(v35.Y * v36.Y + v35.Z * v36.Z + v35.X * v36.X);
    v37 = (float)v27;
    if ( v27 > 0.0f )
      v26 = v34 / v37;
    v36.Y = a2.Location.Y + (float)(v36.Y * v26);
    v36.X = (float)(v36.X * v26) + a2.Location.X;
    Start.Y = v36.Y - (float)(v16 * v43);
    End.Y = Start.Y;
    Start.X = v36.X - (float)(v20 * v43);
    Start.Z = (float)((float)((float)(v36.Z * v26) + a2.Location.Z) - (float)(0.0f * v43)) + Extent.Z;
    End.X = Start.X;
    End.Z = Start.Z - (float)(Extent.Z * 2.0f);
    v35.X = 0.0f;
    v35.Y = 0.0f;
    v35.Z = 0.0f;
    if ( default == MovementLineCheck(ref a2, &End, &Start, &v35, 9422) )
    {
      v31.X = v18;
      v31.Y = v17;
      v31.Z = v15;
      v36.Z = a2.Location.Z;
  LABEL_43:
      v29.X = v18;
      *(_QWORD *)&v29.Y = __PAIR64__(LODWORD(v15), LODWORD(v17));
      E_FLedgeHitInfo_FillWith(ref out_LedgeHit, &a2, &v36, v29, v31);
      return 1;
    }
    if ( a2.Time > 0.0f )
    {
      v30.X = v18;
      *(_QWORD *)&v30.Y = __PAIR64__(LODWORD(v15), LODWORD(v17));
      v36.Z = a2.Location.Z;
      E_FLedgeHitInfo_FillWith(ref out_LedgeHit, &a2, &v36, a2.Normal, v30);
      return 2;
    }
    Start.Z = Start.Z - (float)((float)(Start.Z - End.Z) * 0.5f);
    v35.X = 0.0f;
    v35.Y = 0.0f;
    v35.Z = 0.0f;
    if ( MovementLineCheck(ref a2, &End, &Start, &v35, 9422) )
    {
      v31.X = v18;
      *(_QWORD *)&v31.Y = __PAIR64__(LODWORD(v15), LODWORD(v17));
      v36.Z = a2.Location.Z;
      if ( a2.Time > 0.0f )
      {
        E_FLedgeHitInfo_FillWith(ref out_LedgeHit, &a2, &v36, a2.Normal, v31);
        return 2;
      }
      v29.X = v18;
      *(_QWORD *)&v29.Y = __PAIR64__(LODWORD(v15), LODWORD(v17));
      E_FLedgeHitInfo_FillWith(ref out_LedgeHit, &a2, &v36, v29, v31);
      return 1;
    }
    return 0;
  }



  CheckResult static_FCheckResult;

  public unsafe bool MovementTrace( ref Vector HitLocation, ref Vector HitNormal, Vector End, Vector Start, Vector Extent, bool FindClosest ) => MovementTrace(ref HitLocation, ref HitNormal, End, Start, Extent, FindClosest ? 1 : 0);
  public unsafe bool MovementTrace(ref Vector HitLocation, ref Vector HitNormal, Vector End, Vector Start, Vector Extent, int FindClosest)
  {
    if ( default == MovementLineCheck(ref static_FCheckResult, &End, &Start, &Extent, FindClosest != default ? 9422u : 8910u) )
      return false;
    HitLocation = static_FCheckResult.Location;
    HitNormal = static_FCheckResult.Normal;
    return true;
  }

  public unsafe bool MovementTraceForBlocking(Vector End, Vector Start, Vector Extent)
  {
    /*Vector a5 = default; // [esp+0h] [ebp-Ch] BYREF
  
    a5 = Extent;
    Extent = Start;
    Start = End;*/
    return MovementLineCheck(ref static_FCheckResult, &End, &Start, &Extent, 8910) != default;
  }

  public unsafe bool MovementTraceForBlockingEx(Vector End, Vector Start, Vector Extent, ref Vector HitLocation, ref Vector HitNormal)
  {
    Vector a5 = default; // [esp+0h] [ebp-Ch] BYREF
  
    a5 = Extent;
    Extent = Start;
    Start = End;
    if ( default == MovementLineCheck(ref static_FCheckResult, &Start, &Extent, &a5, 8910) )
      return false;
    HitLocation = static_FCheckResult.Location;
    HitNormal = static_FCheckResult.Normal;
    return true;
  }

  public unsafe bool MovementTraceForBlockingBetweenActors(Vector End, Vector Start)
  {
    Vector a5 = default; // [esp+0h] [ebp-Ch] BYREF
  
    a5.X = 2.0f;
    a5.Y = 2.0f;
    a5.Z = 2.0f;
    return MovementLineCheck(ref static_FCheckResult, &End, &Start, &a5, 128) != default;
  }

  public unsafe bool TestCanUnCrouch()
  {
    TdPawn v2 = default; // eax
    float v3 = default; // ebx
    float v4 = default; // ebp
    float v5 = default; // edi
    Actor v6 = default; // eax
    CylinderComponent v7 = default; // eax
    Vector v9 = default; // [esp-24h] [ebp-4Ch]
    Vector v10 = default; // [esp-18h] [ebp-40h]
    Vector v11 = default; // [esp-Ch] [ebp-34h]
  
    v2 = this.PawnOwner;
    v3 = v2.Location.Y;
    v4 = v2.Location.Z;
    v5 = v2.Location.X;
    /*if ( default == TdPawn_Class )
    {
      TdPawn_Class = (Object )sub_12C2C40((int)L"TdGame");
      sub_12B2BE0();
    }*/
    
    v6 = Object.ClassT<TdPawn>().DefaultAs<Actor>();
    v7 = E_TryCastTo<TdPawn>(v6).CylinderComponent;
    v11.X = v7.CollisionRadius;
    v11.Y = v11.X;
    v11.Z = v7.CollisionHeight;
    v10.X = v5;
    *(_QWORD *)&v10.Y = __PAIR64__(LODWORD(v4), LODWORD(v3));
    *(_QWORD *)&v9.X = __PAIR64__(LODWORD(v3), LODWORD(v5));
    v9.Z = (float)((float)(v11.Z * 2.0f) - 122.0f) + v4;
    return default == MovementTraceForBlocking(v9, v10, v11);
  }

  public unsafe float GetSpeedModifier()
  {
    return (float)(this.SpeedModifier);
  }

  public virtual unsafe void CheckAutoMoves()
  {
    ;
  }

  public virtual unsafe bool TestCanTransitionInto_Maybe()
  {
    return false;
  }

  public virtual unsafe void PrePerformPhysics(float DeltaTime)
  {
    uint v3 = default; // eax
    TdPawn v4 = default; // edi
    EPreciseLocationMode v5 = default; // cl
    double v6 = default; // st5
    double v7 = default; // st4
    double v8 = default; // st6
    double v9 = default; // st5
    double v10 = default; // st6
    double v11 = default; // st5
    float v12 = default; // xmm3_4
    float v13 = default; // xmm6_4
    float v14 = default; // xmm4_4
    float v15 = default; // xmm5_4
    float v16 = default; // xmm4_4
    float v17 = default; // xmm5_4
    float v18 = default; // xmm0_4
    float v19 = default; // xmm1_4
    float v20 = default; // xmm4_4
    float v21 = default; // xmm5_4
    float v22 = default; // xmm2_4
    float v23 = default; // xmm2_4
    //Vector *v24; // eax
    //Vector *v25; // eax
    int v26 = default; // xmm5_4
    float v27 = default; // xmm4_4
    int v28 = default; // xmm1_4
    float v29 = default; // xmm0_4
    float v30 = default; // xmm1_4
    float v31 = default; // xmm2_4
    float v32 = default; // xmm2_4
    float v33 = default; // xmm3_4
    //Vector *v34; // eax
    //Vector *v35; // eax
    double v36 = default; // st7
    int v37 = default; // xmm5_4
    float v38 = default; // xmm4_4
    int v39 = default; // xmm1_4
    float v40 = default; // xmm0_4
    float v41 = default; // xmm0_4
    float v42 = default; // xmm2_4
    float v43 = default; // xmm1_4
    TdPawn v44 = default; // ecx
    // double (__thiscall *v45)(TdPawn ); // eax
    float v46 = default; // xmm0_4
    TdPawn v47 = default; // edi
    float v48 = default; // xmm3_4
    float v49 = default; // xmm0_4
    //Vector *v50; // eax
    double v51 = default; // st7
    int v52 = default; // xmm5_4
    float v53 = default; // xmm4_4
    int v54 = default; // xmm1_4
    float v55 = default; // xmm0_4
    float v56 = default; // xmm0_4
    float v57 = default; // xmm2_4
    float v58 = default; // xmm1_4
    TdPawn v59 = default; // ecx
    // double (__thiscall *v60)(TdPawn ); // eax
    double v61 = default; // st7
    float v62 = default; // xmm1_4
    float v63 = default; // xmm0_4
    double v64 = default; // st6
    TdPawn v65 = default; // edi
    double v66 = default; // st7
    float v67 = default; // xmm0_4
    double v68 = default; // st7
    int v69 = default; // xmm5_4
    float v70 = default; // xmm4_4
    int v71 = default; // xmm1_4
    float v72 = default; // xmm0_4
    float v73 = default; // xmm1_4
    float v74 = default; // xmm2_4
    float v75 = default; // xmm2_4
    float v76 = default; // xmm2_4
    TdPawn v77 = default; // edi
    float v78 = default; // xmm3_4
    float v79 = default; // xmm1_4
    float v80 = default; // xmm1_4
    uint v81 = default; // ebx
    TdPawn v82 = default; // edx
    float v83 = default; // xmm2_4
    int v84 = default; // ecx
    int v85 = default; // eax
    int v86 = default; // edi
    uint v87 = default; // eax
    Controller v88 = default; // ebx
    int v89 = default; // ecx
    Controller v90 = default; // edx
    TdPawn v91 = default; // edx
    uint v92 = default; // eax
    int v93 = default; // ebx
    int v94 = default; // edi
    int v95 = default; // eax
    uint v96 = default; // eax
    int v97 = default; // edi
    int v98 = default; // eax
    uint v99 = default; // eax
    int v100 = default; // edi
    int v101 = default; // eax
    uint v102 = default; // eax
    int v103 = default; // edi
    int v104 = default; // eax
    uint v105 = default; // eax
    int v106 = default; // edi
    int v107 = default; // eax
    Vector v108 = default; // [esp-4h] [ebp-B8h]
    float v109 = default; // [esp+4h] [ebp-B0h]
    float v110 = default; // [esp+4h] [ebp-B0h]
    float v111 = default; // [esp+4h] [ebp-B0h]
    Vector vec_then_rotator = default; // [esp+18h] [ebp-9Ch] BYREF
    float v113 = default; // [esp+28h] [ebp-8Ch]
    Vector Delta = default; // [esp+2Ch] [ebp-88h] BYREF
    float v115 = default; // [esp+38h] [ebp-7Ch]
    float v116 = default; // [esp+3Ch] [ebp-78h]
    float v117 = default; // [esp+40h] [ebp-74h]
    float v118 = default; // [esp+44h] [ebp-70h]
    float v119 = default; // [esp+48h] [ebp-6Ch]
    float v120 = default; // [esp+58h] [ebp-5Ch]
    CheckResult Hit = default; // [esp+68h] [ebp-4Ch] BYREF
    int v122 = default; // [esp+B0h] [ebp-4h]
  
    v3 = this.bDebugMove.AsBitfield(29);
    if ( (v3 & 16384) != default && (v3 & 32768) == default )
    {
      v4 = this.PawnOwner;
      v5 = this.PreciseLocationInterpMode;
      v6 = this.PreciseLocation.Z - v4.Location.Z;
      v7 = this.PreciseLocation.Y - v4.Location.Y;
      v8 = v7 * v7 + v6 * v6;
      v9 = this.PreciseLocation.X - v4.Location.X;
      v113 = (float)(sqrt(v9 * v9 + v8));
      v10 = this.PreciseLocation.Y - v4.Location.Y;
      v11 = this.PreciseLocation.X - v4.Location.X;
      v118 = (float)(sqrt(v11 * v11 + v10 * v10));
      if ( v5 == PLM_Walk )
        v12 = v118;
      else
        v12 = v113;
      if ( v12 <= 2.0f )
      {
        SetFromBitfield(ref this.bDebugMove, 29, v3 | 32768);
      }
      else
      {
        switch ( (int)v5 )
        {
          case (int)PLM_Fly:
            v116 = Min(v113 / DeltaTime, this.PreciseLocationSpeed);
            v13 = this.PreciseLocation.X - v4.Location.X;
            v14 = this.PreciseLocation.Y;
            v15 = this.PreciseLocation.Z;
            Delta.X = v13;
            v16 = v14 - v4.Location.Y;
            Delta.Y = v16;
            v17 = v15 - v4.Location.Z;
            v18 = (float)((float)(v17 * v17) + (float)(v16 * v16)) + (float)(v13 * v13);
            Delta.Z = v17;
            v119 = v18;
            if ( v18 == 1.0f )
            {
              vec_then_rotator = Delta;
              v19 = Delta.X;
              v20 = Delta.Y;
              v21 = Delta.Z;
            }
            else if ( v18 >= SMALL_NUMBER )
            {
              v120 = 3.0f;
              v113 = 0.5f;
              v22 = 1.0f / fsqrt(v119);
              vec_then_rotator.X = (float)(3.0f - (float)((float)(v22 * v119) * v22)) * (float)(v22 * 0.5f);
              v19 = vec_then_rotator.X * v13;
              v20 = v16 * vec_then_rotator.X;
              v21 = v17 * vec_then_rotator.X;
            }
            else
            {
              v19 = 0.0f;
              v20 = 0.0f;
              v21 = 0.0f;
            }
            v23 = v116;
            vec_then_rotator.X = v19 * v116;
            this.PawnOwner.Velocity.X = v19 * v116;
            vec_then_rotator.Y = v20 * v23;
            this.PawnOwner.Velocity.Y = v20 * v23;
            vec_then_rotator.Z = v21 * v23;
            this.PawnOwner.Velocity.Z = v21 * v23;
            vec_then_rotator.X = 0.0f;
            this.PawnOwner.Acceleration.X = 0.0f;
            *(_QWORD *)&vec_then_rotator.Y = default;// set Y&Z to zero
            this.PawnOwner.Acceleration.Y = 0.0f;
            this.PawnOwner.Acceleration.Z = 0.0f;
            break;
          case (int)PLM_Walk:
            v116 = Min(v118 / DeltaTime, this.PreciseLocationSpeed);
            *(float *)&v26 = this.PreciseLocation.X - v4.Location.X;
            v27 = this.PreciseLocation.Y - v4.Location.Y;
            *(float *)&v28 = this.PreciseLocation.Z - v4.Location.Z;
            v29 = (float)(v27 * v27) + (float)(*(float *)&v26 * *(float *)&v26);
            vec_then_rotator.X = *(float *)&v26;
            vec_then_rotator.Y = v27;
            vec_then_rotator.Z.LODWORD(v28);
            v120 = v29;
            if ( v29 == 1.0f )
            {
              if ( *(float *)&v28 == 0.0f )
              {
                Delta = vec_then_rotator;
                v30 = vec_then_rotator.X;
                v27 = vec_then_rotator.Y;
                v31 = vec_then_rotator.Z;
                goto LABEL_22;
              }
              v30 = *(float *)&v26;
            }
            else if ( v29 >= SMALL_NUMBER )
            {
              v119 = 3.0f;
              v113 = 0.5f;
              v32 = 1.0f / fsqrt(v120);
              vec_then_rotator.X = (float)(3.0f - (float)((float)(v32 * v120) * v32)) * (float)(v32 * 0.5f);
              v27 = v27 * vec_then_rotator.X;
              v30 = vec_then_rotator.X * *(float *)&v26;
            }
            else
            {
              v30 = 0.0f;
              v27 = 0.0f;
            }
            v31 = 0.0f;
  LABEL_22:
            v33 = v116;
            vec_then_rotator.X = v30 * v116;
            this.PawnOwner.Velocity.X = v30 * v116;
            vec_then_rotator.Y = v27 * v33;
            this.PawnOwner.Velocity.Y = v27 * v33;
            vec_then_rotator.Z = v31 * v33;
            this.PawnOwner.Velocity.Z = v31 * v33;
            vec_then_rotator.X = 0.0f;
            this.PawnOwner.Acceleration.X = 0.0f;
            *(_QWORD *)&vec_then_rotator.Y = default;// set y&Z to zero
            this.PawnOwner.Acceleration.Y = 0.0f;
            this.PawnOwner.Acceleration.Z = 0.0f;
            break;
          case (int)PLM_Jump:
            v36 = this.PreciseLocationSpeed;
            v117 = 1.0f / DeltaTime;
            v109 = (float)v36;
            v115 = Min((float)(1.0f / DeltaTime) * v118, v109);
            *(float *)&v37 = this.PreciseLocation.X - v4.Location.X;
            v38 = this.PreciseLocation.Y - v4.Location.Y;
            *(float *)&v39 = this.PreciseLocation.Z - v4.Location.Z;
            v40 = (float)(v38 * v38) + (float)(*(float *)&v37 * *(float *)&v37);
            vec_then_rotator.X = *(float *)&v37;
            vec_then_rotator.Y = v38;
            vec_then_rotator.Z.LODWORD(v39);
            v120 = v40;
            if ( v40 == 1.0f )
            {
              if ( *(float *)&v39 == 0.0f )
              {
                Delta = vec_then_rotator;
                v41 = vec_then_rotator.X;
                v38 = vec_then_rotator.Y;
              }
              else
              {
                v41 = *(float *)&v37;
              }
            }
            else if ( v40 >= SMALL_NUMBER )
            {
              v119 = 3.0f;
              v113 = 0.5f;
              v42 = 1.0f / fsqrt(v120);
              vec_then_rotator.X = (float)(3.0f - (float)((float)(v42 * v120) * v42)) * (float)(v42 * 0.5f);
              v41 = vec_then_rotator.X * *(float *)&v37;
              v38 = v38 * vec_then_rotator.X;
            }
            else
            {
              v41 = 0.0f;
              v38 = 0.0f;
            }
            v43 = v115;
            this.PawnOwner.Velocity.X = v41 * v115;
            this.PawnOwner.Velocity.Y = v38 * v43;
            v44 = this.PawnOwner;
            // v45 = *(double (__thiscall **)(TdPawn ))(v44.VfTableObject.Dummy + 308);
            v113 = this.PreciseLocation.Z - v44.Location.Z;
            v116 = (float)(fabs(v44.GetGravityZ()));
            if ( v113 < 0.0f )
            {
              v47 = this.PawnOwner;
              v48 = v47.Velocity.Z;
              if ( v118 <= 0.0f )
                v49 = -0.0f - v116;
              else
                v49 = (float)((float)(v113 - (float)((float)(v118 / v115) * v48)) * 2.0f) / (float)((float)(v118 / v115) * (float)(v118 / v115));
              v47.Velocity.Z = Max(v117 * v113, (float)(v49 * DeltaTime) + v48);
            }
            else
            {
              if ( v118 <= 0.0f )
                v46 = 640.0f;
              else
                v46 = (float)(v115 / v118) * (float)(v113 * 2.0f);
              v115 = v46;
              this.PawnOwner.Velocity.Z = Min(v117 * v113, v46);
            }
            goto LABEL_39;
          case (int)PLM_SimJump:
            v51 = this.PreciseLocationSpeed;
            v117 = 1.0f / DeltaTime;
            v110 = (float)v51;
            v116 = Min((float)(1.0f / DeltaTime) * v118, v110);
            *(float *)&v52 = this.PreciseLocation.X - v4.Location.X;
            v53 = this.PreciseLocation.Y - v4.Location.Y;
            *(float *)&v54 = this.PreciseLocation.Z - v4.Location.Z;
            v55 = (float)(v53 * v53) + (float)(*(float *)&v52 * *(float *)&v52);
            vec_then_rotator.X = *(float *)&v52;
            vec_then_rotator.Y = v53;
            vec_then_rotator.Z.LODWORD(v54);
            v120 = v55;
            if ( v55 == 1.0f )
            {
              if ( *(float *)&v54 == 0.0f )
              {
                Delta = vec_then_rotator;
                v56 = vec_then_rotator.X;
                v53 = vec_then_rotator.Y;
              }
              else
              {
                v56 = *(float *)&v52;
              }
            }
            else if ( v55 >= SMALL_NUMBER )
            {
              v119 = 3.0f;
              v113 = 0.5f;
              v57 = 1.0f / fsqrt(v120);
              vec_then_rotator.X = (float)(3.0f - (float)((float)(v57 * v120) * v57)) * (float)(v57 * 0.5f);
              v56 = vec_then_rotator.X * *(float *)&v52;
              v53 = v53 * vec_then_rotator.X;
            }
            else
            {
              v56 = 0.0f;
              v53 = 0.0f;
            }
            v58 = v116;
            this.PawnOwner.Velocity.X = v56 * v116;
            this.PawnOwner.Velocity.Y = v53 * v58;
            v59 = this.PawnOwner;
            // v60 = *(double (__thiscall **)(TdPawn ))(v59.VfTableObject.Dummy + 308);
            v115 = this.PreciseLocation.Z - v59.Location.Z;
            v61 = fabs(v59.GetGravityZ());
            v113 = (float)v61;
            v62 = v115;
            if ( (float)(v118 / v116) <= DeltaTime )
            {
              if ( v115 <= 0.0f )
              {
                v67 = v117;
                this.PawnOwner.Velocity.Z = this.PawnOwner.Velocity.Z - (float)(v113 * DeltaTime);
                v65 = this.PawnOwner;
                v66 = Max(v67 * v62, v65.Velocity.Z);
              }
              else
              {
                v63 = v117 * v115;
                v64 = sqrt(v115 / v61);
                this.PawnOwner.Velocity.Z = (float)(v61 * v64 + v61 * v64);
                v65 = this.PawnOwner;
                v66 = Min(v63, v65.Velocity.Z);
              }
              v65.Velocity.Z = (float)v66;
            }
            else
            {
              this.PawnOwner.Velocity.Z = (float)(v115 / (float)(v118 / v116)) + (float)((float)((float)(v118 / v116) * v113) * 0.5f);
            }
  LABEL_39:
            vec_then_rotator.X = 0.0f;
            this.PawnOwner.Acceleration.X = 0.0f;
            *(_QWORD *)&vec_then_rotator.Y = default;// set y&Z to zero
            this.PawnOwner.Acceleration.Y = 0.0f;
            this.PawnOwner.Acceleration.Z = 0.0f;
            break;
          case (int)PLM_Fall:
            v68 = this.PreciseLocationSpeed;
            v117 = 1.0f / DeltaTime;
            v111 = (float)v68;
            v116 = Min((float)(1.0f / DeltaTime) * v118, v111);
            *(float *)&v69 = this.PreciseLocation.X - v4.Location.X;
            v70 = this.PreciseLocation.Y - v4.Location.Y;
            *(float *)&v71 = this.PreciseLocation.Z - v4.Location.Z;
            v72 = (float)(v70 * v70) + (float)(*(float *)&v69 * *(float *)&v69);
            vec_then_rotator.X = *(float *)&v69;
            vec_then_rotator.Y = v70;
            vec_then_rotator.Z.LODWORD(v71);
            v120 = v72;
            if ( v72 == 1.0f )
            {
              if ( *(float *)&v71 == 0.0f )
              {
                Delta = vec_then_rotator;
                v73 = vec_then_rotator.X;
                v70 = vec_then_rotator.Y;
              }
              else
              {
                v73 = *(float *)&v69;
              }
            }
            else if ( v72 >= SMALL_NUMBER )
            {
              v119 = 3.0f;
              v113 = 0.5f;
              v74 = 1.0f / fsqrt(v120);
              vec_then_rotator.X = (float)(3.0f - (float)((float)(v74 * v120) * v74)) * (float)(v74 * 0.5f);
              v70 = v70 * vec_then_rotator.X;
              v73 = vec_then_rotator.X * *(float *)&v69;
            }
            else
            {
              v73 = 0.0f;
              v70 = 0.0f;
            }
            v75 = v116;
            this.PawnOwner.Velocity.X = v73 * v116;
            this.PawnOwner.Velocity.Y = v70 * v75;
            v76 = DeltaTime * this.PreciseLocationSpeed;
            this.PawnOwner.Acceleration.X = 0.0f;
            this.PawnOwner.Acceleration.Y = 0.0f;
            v77 = this.PawnOwner;
            v113 = v77.Velocity.Z;
            if ( v113 >= 0.0f )
              break;
            v78 = v77.Location.Z;
            v79 = this.PreciseLocation.Z;
            if( v79 > v78 )
            {
              SetFromBitfield(ref this.bDebugMove, 29, this.bDebugMove.AsBitfield(29) & (~573440u));
              CallFailedToReachPreciseLocation();
              break;
            }

            if ( v76 > v118 )
            {
              v113 = Max((float)(v79 - v78) * v117, v113);
              v80 = v77.Velocity.Y;
              vec_then_rotator.X = (float)(v77.Velocity.X * DeltaTime) + v77.Location.X;
              vec_then_rotator.Y = v77.Location.Y + (float)(v80 * DeltaTime);
              vec_then_rotator.Z = v77.Location.Z + (float)(v113 * DeltaTime);
              v108 = *v77.GetCylinderExtent(&Delta);
              if ( MovementTraceForBlocking(vec_then_rotator, this.PawnOwner.Location, v108) )
              {
  LABEL_62:
                SetFromBitfield(ref this.bDebugMove, 29, this.bDebugMove.AsBitfield(29) & (~573440u));
                CallFailedToReachPreciseLocation();
              }
              else
              {
                this.PawnOwner.Velocity.Z = v113 - this.PawnOwner.GetGravityZ() * DeltaTime;// GetGravityZ
              }
            }
            break;
          default:
            break;
        }
      }
    }
    v81 = this.bDebugMove.AsBitfield(29);
    if ( (v81 & 131072) != default && (v81 & 262144) == default )
    {
      v82 = this.PawnOwner;
      v83 = this.PreciseRotationInterpolationTime;
      vec_then_rotator = (Vector)v82.Rotation;
      if ( v83 <= DeltaTime )
      {
        v89 = this.PreciseRotation.Yaw;
        vec_then_rotator.Y.LODWORD(v89);
        SetFromBitfield(ref this.bDebugMove, 29, v81 | 262144);
        if ( ((v81 | 262144) & 4096) == default )
        {
          v90 = v82.Controller;
          if(v90 != default)
            v90.Rotation.Yaw = v89;
        }
      }
      else
      {
        v84 = v82.Rotation.Yaw;
        v85 = (ushort)(this.PreciseRotation.Yaw - v84);
        if ( (uint)v85 > 0x7FFF )
          v85 = v85 - (0x10000);
        v86 = (int)(float)((float)v85 * (float)(DeltaTime / v83));
        v87 = (ushort)(v84 + v86);
        if ( v87 > 0x7FFF )
          v87 = v87 - (0x10000);
        vec_then_rotator.Y.LODWORD(v87);
        if ( (v81 & 0x1000) == default )
        {
          v88 = v82.Controller;
          if(v88 != default)
            v88.Rotation.Yaw = E_WrapRot((ushort)(v86 + v88.Rotation.Yaw));
        }
        this.PreciseRotationInterpolationTime = this.PreciseRotationInterpolationTime - DeltaTime;
      }
      v91 = this.PawnOwner;
      Hit.Item = -1;
      Hit.LevelIndex = -1;
      Hit.Next = default;
      Hit.Actor = default;
      Hit.Location.X = 0.0f;
      Hit.Location.Y = 0.0f;
      Hit.Location.Z = 0.0f;
      Hit.Normal.X = 0.0f;
      Hit.Normal.Y = 0.0f;
      Hit.Normal.Z = 0.0f;
      Hit.Time = 1.0f;
      Hit.Material = default;
      Hit.PhysMaterial = default;
      Hit.Component = default;
      Hit.BoneName = default;
      Hit.Level = default;
      Hit.bStartPenetrating = default;
      v122 = default;
      Delta.X = 0.0f;
      Delta.Y = 0.0f;
      Delta.Z = 0.0f;
      GWorld.MoveActor(v91, ref Delta, ref *(Rotator *)&vec_then_rotator, 0, ref Hit);
      this.PawnOwner.DesiredRotation.Yaw = this.PawnOwner.Rotation.Yaw;
    }
    v92 = this.bDebugMove.AsBitfield(29);
    v93 = default;
    if ( (v92 & 32768) != default )
    {
      v94 = this.VfTableObject.Dummy;
      SetFromBitfield(ref this.bDebugMove, 29, v92 & ~49152u);
      CallUFunction(this.ReachedPreciseLocation, this, v95, 0, 0);
      v96 = this.bDebugMove.AsBitfield(29);
      if ( (v96 & 131072) == default || (v96 & 262144) != default )
      {
        v93 = 1;
        if ( (v96 & 524288) == default )
        {
          v97 = this.VfTableObject.Dummy;
          CallUFunction(this.ReachedPreciseLocationAndRotation, this, v98, 0, 0);
        }
      }
      else
      {
        SetFromBitfield(ref this.bDebugMove, 29, v96 | 524288);
      }
    }
    v99 = this.bDebugMove.AsBitfield(29);
    if ( (v99 & 262144) != default )
    {
      v100 = this.VfTableObject.Dummy;
      SetFromBitfield(ref this.bDebugMove, 29, v99 & ~393216u);
      CallUFunction(this.ReachedPreciseRotation, this, v101, 0, 0);
      v102 = this.bDebugMove.AsBitfield(29);
      if ( (v102 & 16384) == default || (v102 & 32768) != default )
      {
        v93 = 1;
        if ( (v102 & 524288) == default )
        {
          v103 = this.VfTableObject.Dummy;
          CallUFunction(this.ReachedPreciseLocationAndRotation, this, v104, 0, 0);
        }
      }
      else
      {
        SetFromBitfield(ref this.bDebugMove, 29, v102 | 524288);
      }
    }
    v105 = this.bDebugMove.AsBitfield(29);
    if ( (v105 & 524288) != default )
    {
      if(v93 != default)
      {
        v106 = this.VfTableObject.Dummy;
        SetFromBitfield(ref this.bDebugMove, 29, v105 & ~966656u);
        CallUFunction(this.ReachedPreciseLocationAndRotation, this, v107, 0, 0);
      }
    }
  }

  public unsafe TdMovementExclusionVolume  GetMovementExclusionVolume(Vector Loc)
  {
    int v2 = default; // ebp
    TdMovementExclusionVolume v3 = default; // ebx
    CheckResult *v4; // esi
    Class v5 = default; // ecx
    Actor v6 = default; // edi
    Class v7 = default; // eax
    Vector v9 = default; // [esp+0h] [ebp-18h] BYREF
    int v10 = default; // [esp+14h] [ebp-4h]
  
    v2 = GMem;
    v10 = FMemMark_Maybe;
    v9.X = default;
    v9.Y = default;
    v9.Z = default;
    v3 = default;
    try
    {
      v4 = (CheckResult *)GWorld.BackupHash.ActorPointCheck(ref GMem, Loc, v9, 0x8000u);
      if( v4 == null )
        return null;
      v5 = ClassT<TdMovementExclusionVolume>();
      do
      {
        v6 = v4 -> Actor;
        if( v6 == null )
          continue;

        v7 = v6.Class;
        if( v7 != default && v5.IsBaseOf(v7) )
        {
          return (TdMovementExclusionVolume)v6;
        }
      } while((v4 = v4->Next) != null);

      return null;
    }
    finally
    {
      if ( v10 != FMemMark_Maybe )
        FMemMark_Pop_Maybe(ref GMem, v10);
      GMem = v2;
    }

    /*if ( default == v4 )
      goto LABEL_13;
    v5 = Object.ClassT<TdMovementExclusionVolume>();
    while(1 != default)
    {
      v6 = v4->Actor;
      if ( default == v6 )
        goto LABEL_10;
      if ( default == v5 )
      {
        dword_2056158 = (int)sub_12016D0((int)L"TdGame");
        sub_11F39A0();
        v5 = dword_2056158;
      }
      v7 = v6.Class;
      if(v7 != default)
        break;
  LABEL_9:
      if ( default == v5 )
        goto LABEL_12;
  LABEL_10:
      v4 = (CheckResult *)v4->Next;
      if ( default == v4 )
        goto LABEL_13;
    }
    while ( v7 != (Class )v5 )
    {
      v7 = (Class )v7.Next;
      if ( default == v7 )
        goto LABEL_9;
    }
  LABEL_12:
    v3 = (TdMovementExclusionVolume )v6;
  LABEL_13:
    if ( v10 != FMemMark_Maybe )
      FMemMark_Pop_Maybe(ref GMem, v10);
    GMem = v2;
    return v3;*/
  }

  public unsafe bool FindLedgeInFrontOfPlayer(ref Vector out_LedgeLocation, ref Vector out_LedgeNormal, ref Vector out_MoveNormal)
  {
    TdPawn v5 = default; // eax
    float v6 = default; // ebx
    float v7 = default; // ebp
    float v8 = default; // edi
    Vector *v9; // ecx
    float v10 = default; // xmm0_4
    float v11 = default; // xmm1_4
    float v12 = default; // xmm4_4
    float v13 = default; // xmm0_4
    float v14 = default; // xmm1_4
    TdPawn v15 = default; // eax
    float v16 = default; // xmm2_4
    float v17 = default; // edx
    float v18 = default; // edi
    float v19 = default; // ebx
    float v20 = default; // ecx
    float v21 = default; // edx
    float v22 = default; // ecx
    uint v23 = default; // eax
    Vector v25 = default; // [esp-24h] [ebp-ACh]
    Vector v26 = default; // [esp-18h] [ebp-A0h]
    Vector v27 = default; // [esp-Ch] [ebp-94h]
    Vector a2a = default; // [esp+30h] [ebp-58h] BYREF
    float v29 = default; // [esp+3Ch] [ebp-4Ch]
    float v30 = default; // [esp+4Ch] [ebp-3Ch]
    LedgeHitInfo out_LedgeHit = default; // [esp+5Ch] [ebp-2Ch] BYREF
  
    v5 = this.PawnOwner;
    v6 = v5.Location.Y;
    v7 = v5.Location.Z;
    v8 = v5.Location.X;
    v9 = v5.Rotation.Vector(&a2a);
    v10 = v9->X;
    v30 = (float)(v10 * v10) + (float)(v9->Y * v9->Y);
    if ( v30 == 1.0f )
    {
      v11 = 0.0f;
      if ( v9->Z == 0.0f )
      {
        v10 = v9->X;
        v12 = v9->Y;
        v11 = v9->Z;
      }
      else
      {
        v12 = v9->Y;
      }
    }
    else
    {
      if ( v30 >= SMALL_NUMBER )
      {
        v29 = 3.0f;
        v13 = fsqrt(v30);
        v14 = (float)(3.0f - (float)((float)((float)(1.0f / v13) * v30) * (float)(1.0f / v13))) * (float)((float)(1.0f / v13) * 0.5f);
        v10 = v9->X * v14;
        v12 = v9->Y * v14;
      }
      else
      {
        v10 = 0.0f;
        v12 = 0.0f;
      }
      v11 = 0.0f;
    }
    v15 = this.PawnOwner;
    v16 = v15.LedgeFindDistance;
    v26.X = v8 + (float)(v10 * v16);
    v26.Y = v6 + (float)(v16 * v12);
    v26.Z = v7 + (float)(v11 * v16);
    v25.X = v8;
    *(_QWORD *)&v25.Y = __PAIR64__(LODWORD(v7), LODWORD(v6));
    if ( default == FindLedge(ref out_LedgeHit, v25, v26, v15.LedgeFindExtent) )
      return false;
    v17 = out_LedgeHit.LedgeNormal.Y;
    v18 = out_LedgeHit.LedgeLocation.Z;
    v19 = out_LedgeHit.MoveNormal.X;
    out_LedgeNormal.X = out_LedgeHit.LedgeNormal.X;
    v20 = out_LedgeHit.LedgeNormal.Z;
    out_LedgeNormal.Y = v17;
    v21 = out_LedgeHit.LedgeLocation.Y;
    out_LedgeNormal.Z = v20;
    v22 = out_LedgeHit.LedgeLocation.X;
    out_LedgeLocation.X = out_LedgeHit.LedgeLocation.X;
    out_LedgeLocation.Y = v21;
    out_LedgeLocation.Z = v18;
    out_MoveNormal.X = v19;
    out_MoveNormal.Y = out_LedgeHit.MoveNormal.Y;
    out_MoveNormal.Z = out_LedgeHit.MoveNormal.Z;
    this.PawnOwner.MovementActor = out_LedgeHit.MoveActor;
    v27.X = v22;
    *(_QWORD *)&v27.Y = __PAIR64__(LODWORD(v18), LODWORD(v21));
    this.PawnOwner.MovementExclusionVolume = GetMovementExclusionVolume(v27);
    v23 = out_LedgeHit.FeetExcluded.AsBitfield(2) << 9;
    SetFromBitfield(ref this.PawnOwner.bDisableSkelControlSpring, 32, this.PawnOwner.bDisableSkelControlSpring.AsBitfield(32) ^ ((this.PawnOwner.bDisableSkelControlSpring.AsBitfield(32) ^ (out_LedgeHit.FeetExcluded.AsBitfield(2) << 7)) & 0x100));
    SetFromBitfield(ref this.PawnOwner.bDisableSkelControlSpring, 32, this.PawnOwner.bDisableSkelControlSpring.AsBitfield(32) ^ ((this.PawnOwner.bDisableSkelControlSpring.AsBitfield(32) ^ v23) & 0x200));
    return true;
  }

  public unsafe void CallOnAnimationStopped(AnimNodeSequence a2)
  {
    int v3 = default; // edi
    int v4 = default; // eax
  
    v3 = this.VfTableObject.Dummy;
    this.OnAnimationStopped(a2);
  }
}
}
