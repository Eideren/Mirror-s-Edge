namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdMove_UNKNOWN
{
  public override unsafe void PrePerformPhysics(float DeltaTime)
  {
    WorldInfo v3 = default; // eax
    float v4 = default; // xmm0_4
    TdPawn v5 = default; // ecx
    Rotator v6 = default; // [esp-Ch] [ebp-28h]
    float v7 = default; // [esp+Ch] [ebp-10h]
  
    v3 = GWorld.GetWorldInfo();
    if ( !(*(int (__thiscall **)(GameInfo ))(v3.Game.VfTableObject.Dummy + 796))(v3.Game) )
    {
      v4 = this.MoveActiveTime * 3.3333333f;
      v7 = v4;
      if ( v4 >= 1.0f )
      {
        v4 = 1.0f;
        v7 = 1.0f;
      }
      v5 = this.PawnOwner;
      v6.Pitch = v5.Rotation.Pitch;
      v6.Yaw = (int)(float)((float)((float)SLODWORD(this.SlideAbortTime) * v4) + (float)SLODWORD(this.SlideAbortSpeed));
      v6.Roll = v5.Rotation.Roll;
      v5.SetRotation(v6);
      this.PawnOwner.LegRotation = (int)(float)((float)((float)this.SlideAngleTarget * v7) + (float)SLODWORD(this.MaxFloorInclineZ));
    }
  }

  public unsafe void CheckAutoMoves3(float DeltaTime)
  {
    ;
  }
}
}
