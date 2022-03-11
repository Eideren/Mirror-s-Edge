// NO OVERWRITE

namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdMove_Climb
{
  public override unsafe EMoveAimMode GetAimMode(int aimingOnly)
  {
    TdPawn v3 = default; // eax
    TdPawn v4 = default; // ecx
    Controller v5 = default; // eax
    int v6 = default; // edx
    int v7 = default; // edx
    int v8 = default; // eax
    int v9 = default; // eax
    int v10 = default; // ecx
    EMoveAimMode result = default; // al
    Rotator v12 = default; // [esp+4h] [ebp-18h] BYREF
    Rotator a5 = default; // [esp+10h] [ebp-Ch] BYREF
  
    if ( default == aimingOnly )
      return this.AimMode;
    v3 = this.PawnOwner;
    if ( default == v3.Controller )
      return this.AimMode;
    v4 = this.PawnOwner;
    v5 = v3.Controller;
    v6 = v5.Rotation.Pitch - v4.Rotation.Pitch;
    //v5 = (Controller )((byte *)v5 + 244);// Controller ptr to Controller.Rotation.Pitch ptr
    v12.Pitch = v6;
    v7 = v5.Rotation.Yaw - v4.Rotation.Yaw;
    v8 = v5.Rotation.Roll - v4.Rotation.Roll;
    v12.Yaw = v7;
    v12.Roll = v8;
    v9 = E_ClipAmountOfTurns(v12, &a5)->Yaw;
    v10 = this.StartTurningAngle;
    if ( v9 > v10 )
      return (EMoveAimMode)1;
    if ( v9 < -v10 )
      result = MAM_Left;
    else
      result = this.AimMode;
    return result;
  }

  public override unsafe void PrePerformPhysics(float DeltaTime)
  {
    TdPawn v3 = default; // eax
    TdPawn v4 = default; // edx
  
    v3 = this.PawnOwner;
    if ( v3.Role < ROLE_AutonomousProxy )
    {
      base.PrePerformPhysics(DeltaTime);
      return;
    }
    if ( (v3.bDisableSkelControlSpring.AsBitfield(32) & 32) != 0 )
    {
      this.PawnOwner.Velocity.Z = v3.GetGravityZ() * DeltaTime * 0.5f + this.PawnOwner.Velocity.Z;// v3.GetGravityZ()
      v4 = this.PawnOwner;
      if ( v4.MoveActionHint != MAH_Down || SLOBYTE(v4.bDisableSkelControlSpring.AsBitfield(32)) >= 0 || this.Ladder.GetClosestStep((float)(v4.Velocity.Z * DeltaTime) + this.PawnOwner.Location.Z) < 2 )// TdLadderVolume::GetClosestStep
      {
        this.StopClimbDownFast();
        base.PrePerformPhysics(DeltaTime);
        return;
      }
    }
    else if ( (this.bIsPlayingAnimation == false) )
    {
      v3.Velocity.Z = 0.0f;
    }
    base.PrePerformPhysics(DeltaTime);
  }
}
}
