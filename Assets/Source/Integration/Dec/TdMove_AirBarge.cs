// NO OVERWRITE
namespace MEdge.TdGame{
using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdMove_AirBarge
{
  public override unsafe void PrePerformPhysics(float DeltaTime)
  {
    TdPawn v3 = default; // eax
    uint v4 = default; // eax
    float v5 = default; // xmm2_4
    float v6 = default; // xmm1_4
    TdPawn v7 = default; // ecx
    float v8 = default; // xmm2_4
    float v9 = default; // xmm0_4
    float v10 = default; // xmm1_4
    Vector *v11; // eax
    bool v12 = default; // zf
    TdPawn v13 = default; // eax
    float v14 = default; // xmm1_4
    TdPawn v15 = default; // eax
    float v16 = default; // xmm2_4
    float v17 = default; // ecx
    Vector Delta = default; // [esp+Ch] [ebp-B4h] BYREF
    float v19 = default; // [esp+18h] [ebp-A8h]
    CheckResult Hit = default; // [esp+1Ch] [ebp-A4h] BYREF
    int v21 = default; // [esp+64h] [ebp-5Ch]
    CheckResult v22 = default; // [esp+68h] [ebp-58h] BYREF
    int v23 = default; // [esp+B0h] [ebp-10h]
    Vector a2 = default; // [esp+B4h] [ebp-Ch] BYREF
  
    base.PrePerformPhysics(DeltaTime);
    v3 = this.PawnOwner;
    if(v3 != default)
    {
      if ( v3.MoveActionHint == (TdPawn.EMoveActionHint) 4 )
      {
        v4 = this.bHasDealtDamage.AsBitfield(2);
        if ( (v4 & 1) == 0 && (v4 & 2) != 0 )     // 1.bHasDealtDamage, 2.bBargeWithHands
          this.AbortBarge();
      }
    }
    v5 = this.HeightBoostLeft;
    if ( v5 > 0.0f )
    {
      v6 = (float)(this.TotalHeightBoost / this.HeightBoostDuration) * DeltaTime;
      v7 = this.PawnOwner;
      v22.Location.X = 0.0f;
      v22.Location.Y = 0.0f;
      v22.Location.Z = 0.0f;
      v22.Normal.X = 0.0f;
      v22.Normal.Y = 0.0f;
      v22.Normal.Z = 0.0f;
      v22.Time = 0.0f;
      this.HeightBoostLeft = v5 - v6;
      v22.Next = default;
      v22.Actor = default;
      v22.Item = -1;
      v22.Material = default;
      v22.PhysMaterial = default;
      v22.Component = default;
      v22.BoneName = default;
      v22.Level = default;
      v22.LevelIndex = -1;
      v22.bStartPenetrating = default;
      v23 = default;
      v8 = v7.Location.X;
      v9 = v7.Location.Z + 30.0f;
      v19 = v6;
      v10 = v7.Location.Y;
      Delta.X = v8;
      Delta.Y = v10;
      Delta.Z = v9;
      v11 = E_GetDefaultCollExtent(v7, &a2);
      v12 = GWorld.EncroachingWorldGeometry(ref v22, Delta, *v11, true) == false;
      v13 = this.PawnOwner;
      if(v12 != default)
      {
        Hit.Location.X = 0.0f;
        Hit.Location.Y = 0.0f;
        Hit.Location.Z = 0.0f;
        Hit.Normal.X = 0.0f;
        Hit.Normal.Y = 0.0f;
        Hit.Normal.Z = 0.0f;
        Delta.X = 0.0f;
        Delta.Y = 0.0f;
        Hit.Next = default;
        Hit.Actor = default;
        Hit.Time = 1.0f;
        Hit.Item = -1;
        Hit.Material = default;
        Hit.PhysMaterial = default;
        Hit.Component = default;
        Hit.BoneName = default;
        Hit.Level = default;
        Hit.LevelIndex = -1;
        Hit.bStartPenetrating = default;
        v21 = default;
        Delta.Z = v19;
fixed(Rotator* ptr1 =&v13.Rotation)
        GWorld.MoveActor(v13, ref Delta, ref *ptr1, 0, ref Hit);
      }
      else
      {
        v14 = v13.Velocity.Z;
        if ( v14 > 0.0f )
          v14 = 0.0f;
        v13.Velocity.Z = v14;
      }
    }
    if ( this.PreCollisionVelocity.X != 0.0f || this.PreCollisionVelocity.Y != 0.0f || this.PreCollisionVelocity.Z != 0.0f )
    {
      v15 = this.PawnOwner;
      Delta.X = this.PreCollisionVelocity.X * 0.5f;
      Delta.Y = this.PreCollisionVelocity.Y * 0.5f;
      v16 = this.PreCollisionVelocity.Z;
      v17 = Delta.Y;
      v15.Velocity.X = Delta.X;
      //v15 = (TdPawn )((byte *)v15 + 0x100);// ptr to Velocity
      v15.Velocity.Y = v17;//*(float *)&v15.ObjectInternalInteger = v17;
      v15.Velocity.Z = v16 * 0.5f;//*(float *)&v15.ObjectFlags_A = v16 * 0.5f;
      this.PreCollisionVelocity.X = 0.0f;
      this.PreCollisionVelocity.Y = 0.0f;
      this.PreCollisionVelocity.Z = 0.0f;
    }
  }
}
}
