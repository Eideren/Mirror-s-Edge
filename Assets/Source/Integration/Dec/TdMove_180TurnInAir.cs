namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdMove_180TurnInAir
{
  public override unsafe void PrePerformPhysics(float DeltaTime)
  {
    TdPawn v3 = default; // esi
    int v4 = default; // edi
    int v5 = default; // eax
    byte* v6 = stackalloc byte[4]; // [esp+Ch] [ebp-10h] BYREF
    int v7 = default; // [esp+10h] [ebp-Ch]
    int v8 = default; // [esp+14h] [ebp-8h]
    int v9 = default; // [esp+18h] [ebp-4h]
  
    base.PrePerformPhysics(DeltaTime);
    v3 = this.PawnOwner;
    if(v3 != default)
    {
      if ( this.MoveActiveTime > 0.30000001d && v3.VelocityMagnitude < 0.1f )
      {
        v4 = v3.VfTableObject.Dummy;
        v9 = default;
        v7 = default;
        v8 = default;
        v6[0] = 20;
        v3.SetMove((EMovement)20);
      }
    }
  }
}
}
