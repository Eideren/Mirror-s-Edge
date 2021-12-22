// NO OVERWRITE

namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdMove_EnterCover
{
  public override unsafe void PrePerformPhysics(float DeltaTime)
  {
    NativeMarkers.MarkUnimplemented();
    /*uint v3 = default; // eax
    TdPawn v4 = default; // eax
    double v5 = default; // st6
    double v6 = default; // st5
    TdPawn v7 = default; // eax
    float v8 = default; // edx
  
    base.PrePerformPhysics(DeltaTime);
    v3 = this.bPerformedPhysics.AsBitfield(2);
    if ( (v3 & 1) != 0 && (v3 & 2) != 0 )
    {
      v4 = this.PawnOwner;
      v5 = this.PreviousLocation.Y - v4.Location.Y;
      v6 = this.PreviousLocation.X - v4.Location.X;
      if ( this.PreciseLocationSpeed * DeltaTime * 0.25f > sqrt(v6 * v6 + v5 * v5) )
        this.CallFailedToReachPreciseLocation();
    }
    v7 = this.PawnOwner;
    SetFromBitfield(ref this.bPerformedPhysics, 2, this.bPerformedPhysics.AsBitfield(2) | (1u));
    v8 = v7.Location.X;
    v7 = (TdPawn )((byte *)v7 + 0xE8);
    this.PreviousLocation.X = v8;
    this.PreviousLocation.Y.LODWORD(v7.ObjectInternalInteger);
    this.PreviousLocation.Z.LODWORD(v7.ObjectFlags_A);*/
  }
}
}
