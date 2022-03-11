// NO OVERWRITE

namespace MEdge.TdGame{
using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdMove_Balance
{
  public override unsafe void UpdateMoveTimer(float a2)
  {
    float v3 = default; // xmm0_4
    float v4 = default; // xmm0_4
    int v5 = default; // edi
    int v6 = default; // eax
    bool v7 = default; // zf
    TdBalanceWalkVolume v8 = default; // ecx
    float v9 = default; // xmm1_4
    Vector *v10; // eax
    TdPawn v11 = default; // eax
    float v12 = default; // xmm1_4
    float v13 = default; // xmm2_4
    Rotator *v14; // eax
    float v15 = default; // [esp+40h] [ebp-80h]
    Vector v16 = default; // [esp+44h] [ebp-7Ch] BYREF
    Vector v17 = default; // [esp+50h] [ebp-70h] BYREF
    Vector Delta = default; // [esp+5Ch] [ebp-64h] BYREF
    Rotator out_a = default; // [esp+68h] [ebp-58h] BYREF
    CheckResult Hit = default; // [esp+74h] [ebp-4Ch] BYREF
    int v21 = default; // [esp+BCh] [ebp-4h]
  
    v3 = this.Timer;
    if ( v3 > 0.0f )
    {
      v4 = v3 - a2;
      this.Timer = v4;
      if ( v4 <= 0.0f )
      {
        v5 = this.VfTableObject.Dummy;
        this.Timer = 0.0f;
        CallUFunction(this.OnMoveTimer, this, v6, 0, 0);
      }
    }
    v7 = (this.bIsFacingForward.AsBitfield(3) & 4) == 0;
    this.MoveActiveTime = this.MoveActiveTime + a2;
    if(v7 != default)
    {
      if ( E_TryCastTo<TdPlayerController>(this.PawnOwner.Controller) )
      {
        this.Volume.FindClosestPointOnDSpline(
          this.PawnOwner.Location,
          ref v17,
          ref this.CurrentParamOnCurve,
          (int)this.CurrentParamOnCurve);
        v8 = this.Volume;
        v9 = this.CurrentParamOnCurve;
        v17.Z = this.PawnOwner.Location.Z;
        v10 = v8.GetSlopeOnSpline(&Delta, v9 / (float)v8.SplineLocations.Count);
        v7 = (this.bIsFacingForward.AsBitfield(3) & 1) == 0;
        v16 = *v10;
        if(v7 != default)
        {
          Delta.X = v16.X * -1.0f;
          Delta.Y = v16.Y * -1.0f;
          Delta.Z = v16.Z * -1.0f;
          v16.X = v16.X * -1.0f;
          v16.Y = v16.Y * -1.0f;
          v16.Z = v16.Z * -1.0f;
        }
        v16.Z = 0.0f;
        v16.Normalize();
        Hit.Location.X = 0.0f;
        Hit.Location.Y = 0.0f;
        Hit.Location.Z = 0.0f;
        Hit.Normal.X = 0.0f;
        Hit.Normal.Y = 0.0f;
        Hit.Normal.Z = 0.0f;
        Hit.Time = 1.0f;
        Hit.Item = -1;
        Hit.LevelIndex = -1;
        v11 = this.PawnOwner;
        Hit.Next = default;
        Hit.Actor = default;
        Hit.Material = default;
        Hit.PhysMaterial = default;
        Hit.Component = default;
        Hit.BoneName = default;
        Hit.Level = default;
        Hit.bStartPenetrating = default;
        v21 = default;
        v12 = (float)(v17.Y - v11.Location.Y) * a2;
        v13 = (float)(v17.Z - v11.Location.Z) * a2;
        v15 = (float)(sqrt(v11.Velocity.Y * v11.Velocity.Y + v11.Velocity.X * v11.Velocity.X) * 0.0033333334f);
        Delta.X = (float)((float)((float)(v17.X - v11.Location.X) * a2) * 10.0f) * v15;
        Delta.Y = (float)(v12 * 10.0f) * v15;
        Delta.Z = (float)(v13 * 10.0f) * v15;
        v14 = E_DirToRotator(v16, &out_a);
        GWorld.MoveActor(this.PawnOwner, Delta, *v14, 0, ref Hit);
      }
    }
  }

  public override unsafe void PrePerformPhysics(float DeltaTime)
  {
    TdPawn v3 = default; // eax
    Vector *v4; // eax
    TdPawn v5 = default; // ecx
    float v6 = default; // xmm1_4
    float v7 = default; // xmm0_4
    double v8 = default; // st7
    float v9 = default; // xmm1_4
    Controller v10 = default; // eax
    int v11 = default; // edx
    float v12 = default; // xmm0_4
    int v13 = default; // edx
    int v14 = default; // eax
    float v15 = default; // xmm0_4
    float v16 = default; // xmm1_4
    float v17 = default; // xmm0_4
    float v19 = default; // xmm0_4
    uint v20 = default; // ecx
    float v21 = default; // xmm0_4
    bool v22 = default; // cc
    float v23 = default; // [esp+8h] [ebp-28h]
    float v24 = default; // [esp+Ch] [ebp-24h]
    float v25 = default; // [esp+Ch] [ebp-24h]
    float v26 = default; // [esp+10h] [ebp-20h]
    float v27 = default; // [esp+14h] [ebp-1Ch]
    Vector a2 = default; // [esp+18h] [ebp-18h] BYREF
    Rotator a5 = default; // [esp+24h] [ebp-Ch] BYREF
    float DeltaTimea = default; // [esp+34h] [ebp+4h]
  
    base.PrePerformPhysics(DeltaTime);
    if ( (this.bIsFacingForward.AsBitfield(3) & 4) == 0 )
    {
      v3 = this.PawnOwner;
      if ( v3.Controller )
      {
        v4 = v3.Rotation.Vector(&a2);
        v5 = this.PawnOwner;
        v6 = (float)((float)(v5.Acceleration.Z * (float)((float)(v4->X * 0.0f) - (float)(v4->Y * 0.0f))) + (float)(v5.Acceleration.Y * (float)((float)(v4->Z * 0.0f) - v4->X))) + (float)(v5.Acceleration.X * (float)(v4->Y - (float)(v4->Z * 0.0f)));
        v7 = -1.0f;
        if ( v6 >= -1.0f
          && ((v7 = (float)((float)(v5.Acceleration.Z * (float)((float)(v4->X * 0.0f) - (float)(v4->Y * 0.0f))) + (float)(v5.Acceleration.Y * (float)((float)(v4->Z * 0.0f) - v4->X))) + (float)(v5.Acceleration.X * (float)(v4->Y - (float)(v4->Z * 0.0f)))) is object &&
              v6 > 1.0f) )
        {
          v23 = 1.0f;
        }
        else
        {
          v23 = v7;
        }
        v27 = this.BalanceFactor;
        v26 = (float)(sin(v27 * 1.5707964f));
        v8 = sqrt(v5.Velocity.Y * v5.Velocity.Y + v5.Velocity.X * v5.Velocity.X) * 0.0033333334f;
        if ( v8 < 0.0f )
        {
          v9 = 0.0f;
        }
        else
        {
          v9 = (float)v8;
          v24 = (float)v8;
          if ( v24 > 1.0f )
            v9 = 1.0f;
        }
        v10 = v5.Controller;
        v11 = v10.Rotation.Pitch - v5.Rotation.Pitch;
        v12 = this.SpeedInfluence;
        //v10 = (Controller )((byte *)v10 + 0xF4);// Controller.Rotation
        a2.X.LODWORD(v11);                      // Re-use of a2, consider its type as a Rotator from now on
        v13 = v10.Rotation.Yaw - v5.Rotation.Yaw;
        v14 = v10.Rotation.Roll - v5.Rotation.Roll;
        v25 = (float)(v12 * v9) + 1.0f;
        a2.Y.LODWORD(v13);
        a2.Z.LODWORD(v14);
        v15 = (float)(int)E_ClipAmountOfTurns(*(Rotator *)&a2, &a5)->Yaw * 0.00012207031f;
        if ( v15 < -1.0f )
        {
          v16 = -1.0f;
        }
        else
        {
          v16 = v15;
          if ( v15 > 1.0f )
            v16 = 1.0f;
        }
        v17 = (float)((float)((float)((float)(this.CameraInfluence * v16) + (float)(this.GravityInfluence * v26)) + (float)(this.ControlInfluence * v23)) + this.ExternalForce) * v25;
        v19 = (float)(v17 * DeltaTime) + v27;
        if ( v19 >= -1.0f )
        {
          if ( v19 > 1.0f )
            v19 = 1.0f;
        }
        else
        {
          v19 = -1.0f;
        }
        v20 = this.bIsFacingForward.AsBitfield(3);
        DeltaTimea = v19;
        this.BalanceFactor = v19;
        if ( (v20 & 2) != 0 )
        {
          v21 = this.CounterTimer + DeltaTime;
          v22 = v21 <= this.TimeToCounter;
          this.CounterTimer = v21;
          if(v22 != default)
          {
            if ( fabs(DeltaTimea) <= 0.89999998d )
              SetFromBitfield(ref this.bIsFacingForward, 3, v20 & ~2u);
          }
          else
          {
            this.Falloff();
          }
        }
        else if ( fabs(v19) >= 1.0f )
        {
          this.CounterTimer = 0.0f;
          SetFromBitfield(ref this.bIsFacingForward, 3, v20 | 2);
        }
      }
    }
  }
}
}
