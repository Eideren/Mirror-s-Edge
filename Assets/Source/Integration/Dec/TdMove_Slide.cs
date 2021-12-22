namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdMove_Slide
{
  public unsafe bool FloorDeclineTooSteep()
  {
    return (this.PawnOwner.Floor.Y + this.PawnOwner.Floor.X) * 0.0f - this.PawnOwner.Floor.Z * 1.0f > -0.72f;
  }

  public unsafe bool ShouldAbortMove()
  {
    TdPawn result = default; // eax
  
    result = this.PawnOwner;
    if ( result.MoveActionHint != MAH_Down )
      return (float)(this.SlideAbortSpeed * this.SlideAbortSpeed) > (float)((float)((float)(result.Velocity.X * result.Velocity.X) + (float)(result.Velocity.Y * result.Velocity.Y)) + (float)(result.Velocity.Z * result.Velocity.Z));
    LOBYTE(result) = 1;
    return (bool)result != default;
  }

  public override unsafe void PrePerformPhysics(float DeltaTime)
  {
    TdPawn v3 = default; // eax
    TdPawn v4 = default; // ecx
    int v5 = default; // eax
    int v6 = default; // edi
    TdPawn v7 = default; // eax
    EMoveActionHint v8 = default; // cl
    Vector *v9; // eax
    Rotator *v10; // eax
    TdPawn v11 = default; // edx
    int v12 = default; // ecx
    SkelControlSingleBone v13 = default; // eax
    uint v14 = default; // eax
    float v15 = default; // [esp+8h] [ebp-28h]
    Vector v16 = default; // [esp+Ch] [ebp-24h]
    Rotator out_a = default; // [esp+18h] [ebp-18h] BYREF
    Vector vect_then_rotator = default; // [esp+24h] [ebp-Ch] BYREF
  
    base.PrePerformPhysics(DeltaTime);
    v3 = this.PawnOwner;
    if ( v3.Controller )
    {
      if ( v3.Health > 0 )
      {
        if ( this.0x011F8640() )// 0x011F8640, UTdMove_Slide::ShouldStopSliding_Maybe
          this.AbortMove();
        v4 = this.PawnOwner;
        v5 = (ushort)(LOWORD(v4.Controller.Pawn::Rotation.Yaw) - LOWORD(v4.Rotation.Yaw));
        if ( (uint)v5 > 32767 )
          v5 = v5 - (65536);
        v6 = (int)(float)((float)(DeltaTime * 0.2f) * (float)v5);
fixed(var ptr1 =&v4.Velocity)
        E_DirToRotator( ptr1, &out_a);
        v7 = this.PawnOwner;
        v8 = v7.MoveActionHint;
        if ( v8 == MAH_Left )
        {
          v6 = v6 + ((int)(float)(DeltaTime * -2000.0f));
        }
        else if ( v8 == MAH_Right )
        {
          v6 = v6 + ((int)(float)(DeltaTime * 2000.0f));
        }
        out_a.Yaw = out_a.Yaw + (v6);
        v7.Rotation.Yaw = v7.Rotation.Yaw + (v6);
        v15 = (float)(sqrt(this.PawnOwner.Velocity.Y * this.PawnOwner.Velocity.Y + this.PawnOwner.Velocity.X * this.PawnOwner.Velocity.X));
        v9 = out_a.Vector(&vect_then_rotator);
        v16.X = v9->X * v15;
        v16.Y = v9->Y * v15;
        v16.Z = v15 * v9->Z;
        this.PawnOwner.Velocity = v16;
fixed(var ptr2 =&this.PawnOwner.Floor)
        v10 = E_DirToRotator( ptr2, (Rotator *)&vect_then_rotator);
        v11 = this.PawnOwner;
        v12 = 16384 - v10->Pitch;
        this.SlideAngleTarget = v12;
        v13 = v11.SwingControl1p;
        if(v13 != default)
        {
          v14 = (ushort)(int)(float)((float)(v12 - v13.BoneRotation.Roll) * (float)(DeltaTime * 10.0f));
          if ( v14 > 32767 )
            v14 = v14 - (65536);
          v11.SwingControl1p.BoneRotation.Roll = v11.SwingControl1p.BoneRotation.Roll + (v14);
          this.PawnOwner.SwingControl3p.BoneRotation.Roll = this.PawnOwner.SwingControl1p.BoneRotation.Roll;
        }
        SetFromBitfield(ref this.PawnOwner.bDisableSkelControlSpring, 32, this.PawnOwner.bDisableSkelControlSpring.AsBitfield(32) ^ ((this.PawnOwner.bDisableSkelControlSpring.AsBitfield(32) ^ (2 * this.TestCanUnCrouch())) & 2));
      }
    }
  }
}
}
