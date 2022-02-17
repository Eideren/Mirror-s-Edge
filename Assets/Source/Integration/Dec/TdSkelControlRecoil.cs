namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdSkelControlRecoil
{
  public override unsafe void TickSkelControl(float DeltaSeconds, SkeletalMeshComponent SkelComp)
  {
    float v3 = default; // xmm0_4
    float v4 = default; // xmm1_4
    float v5 = default; // xmm0_4
  
    base.TickSkelControl(DeltaSeconds, SkelComp);
    v3 = this.RecoverDelay;
    if ( v3 <= 0.0f )
    {
      v4 = this.EffectorLocation.X;
      if ( v4 > 0.0f )
      {
        v5 = (float)(this.InterpFactor * v4) * DeltaSeconds;
        if ( this.MinInterpValue >= v5 )
          v5 = this.MinInterpValue;
        this.EffectorLocation.X = v4 - v5;
      }
    }
    else
    {
      this.RecoverDelay = v3 - DeltaSeconds;
    }
  }
}
}
