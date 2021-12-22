// NO OVERWRITE

namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdMove_Falling
{
  public override unsafe void UpdateMoveTimer(float a2)
  {
    float v3 = default; // xmm1_4
    float v4 = default; // xmm1_4
    int v5 = default; // ebx
    int v6 = default; // eax
    bool v7 = default; // zf
    TdPawn v8 = default; // ecx
    float v9 = default; // xmm1_4
    float v10 = default; // xmm3_4
    float v11 = default; // xmm2_4
    float v12 = default; // xmm4_4
    Vector v13 = default; // [esp+Ch] [ebp-70h] BYREF
    Vector v14 = default; // [esp+18h] [ebp-64h] BYREF
    Vector v15 = default; // [esp+24h] [ebp-58h] BYREF
    CheckResult v16 = default; // [esp+30h] [ebp-4Ch] BYREF
    int v17 = default; // [esp+78h] [ebp-4h]
  
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
    v7 = (this.bCloseToGround == false);
    this.MoveActiveTime = this.MoveActiveTime + a2;
    if(v7 != default)
    {
      v8 = this.PawnOwner;
      if ( sqrt(v8.Velocity.Y * v8.Velocity.Y + v8.Velocity.X * v8.Velocity.X) > 10.0f )
      {
        v16.Time = 1.0f;
        v16.Location.X = 0.0f;
        v16.Location.Y = 0.0f;
        v16.Location.Z = 0.0f;
        v16.Normal.X = 0.0f;
        v16.Normal.Y = 0.0f;
        v16.Normal.Z = 0.0f;
        v16.Item = -1;
        v16.LevelIndex = -1;
        v16.Next = default;
        v16.Actor = default;
        v16.Material = default;
        v16.PhysMaterial = default;
        v16.Component = default;
        v16.BoneName = default;
        v16.Level = default;
        v16.bStartPenetrating = default;
        v17 = default;
        v13 = v8.Velocity;
        v9 = v13.X;
        v10 = v13.Y;
        v11 = v13.Z;
        v13 = v8.Location;
        v12 = v13.Z - v8.CylinderComponent.CollisionHeight;
        v14.X = 0.0f;
        v14.Y = 0.0f;
        v14.Z = 0.0f;
        v13.Z = v12;
        v15.X = (float)(v9 * 0.40000001d) + v13.X;
        v15.Y = v13.Y + (float)(v10 * 0.40000001d);
        v15.Z = (float)(v11 * 0.40000001d) + v12;
        SetFromBitfield(ref this.bCloseToGround, 1, this.bCloseToGround.AsBitfield(1) ^ ((this.bCloseToGround.AsBitfield(1) ^ (default == GWorld.SingleLineCheck(&v16, v8, &v15, &v13, 8415, &v14, 0) ? 1u : 0u)) & 1u));
        if ( (this.bCloseToGround.AsBitfield(1) & 1) != 0 )
          this.CloseToGround();
      }
    }
  }

  public override unsafe void PrePerformPhysics(float DeltaTime)
  {
    float v3 = default; // xmm0_4
    bool v4 = default; // cf
    bool v5 = default; // zf
  
    base.PrePerformPhysics(DeltaTime);
    v3 = DeltaTime + this.AirTime;
    v4 = v3 < this.StickyAimAfterAirTime;
    v5 = v3 == this.StickyAimAfterAirTime;
    this.AirTime = v3;
    if ( v4 || v5 )
      SetFromBitfield(ref this.bDebugMove, 29, this.bDebugMove.AsBitfield(29) & (~0x1000000u));
    else
      SetFromBitfield(ref this.bDebugMove, 29, this.bDebugMove.AsBitfield(29) | 0x1000000);// 0x1000000
  }
}
}
