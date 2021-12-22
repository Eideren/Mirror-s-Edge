// NO OVERWRITE

namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdMove_Coil
{
  public override unsafe void PrePerformPhysics(float DeltaTime)
  {
    float v3 = default; // xmm2_4
    float v4 = default; // xmm1_4
    TdPawn v5 = default; // esi
    Vector Delta = default; // [esp+8h] [ebp-58h] BYREF
    CheckResult Hit = default; // [esp+14h] [ebp-4Ch] BYREF
    int v8 = default; // [esp+5Ch] [ebp-4h]
  
    base.PrePerformPhysics(DeltaTime);
    v3 = this.HeightBoostLeft;
    if ( v3 > 0.0f )
    {
      v4 = (float)(this.TotalHeightBoost / this.HeightBoostDuration) * DeltaTime;
      Hit.Item = -1;
      Hit.LevelIndex = -1;
      this.HeightBoostLeft = v3 - v4;
      v5 = this.PawnOwner;
      Hit.Next = default;
      Hit.Actor = default;
      Hit.Material = default;
      Hit.PhysMaterial = default;
      Hit.Component = default;
      Hit.BoneName = default;
      Hit.Level = default;
      Hit.bStartPenetrating = default;
      v8 = default;
      Hit.Location.X = 0.0f;
      Hit.Location.Y = 0.0f;
      Hit.Location.Z = 0.0f;
      Hit.Normal.X = 0.0f;
      Hit.Normal.Y = 0.0f;
      Hit.Normal.Z = 0.0f;
      Hit.Time = 1.0f;
      Delta.X = 0.0f;
      Delta.Y = 0.0f;
      Delta.Z = v4;
fixed(Rotator* ptr1 =&v5.Rotation)
      GWorld.MoveActor(v5, &Delta,  ptr1, 0, &Hit);
    }
  }
}
}
