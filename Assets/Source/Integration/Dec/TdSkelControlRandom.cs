// NO OVERWRITE

namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdSkelControlRandom
{
  public override unsafe void TickSkelControl(float DeltaSeconds, SkeletalMeshComponent SkelComp)
  {
    float v4 = default; // xmm0_4
    TdPawn v5 = default; // ebp
    int v6 = default; // eax
    uint v7 = default; // ebx
    int v8 = default; // ecx
    int v9 = default; // edi
    int v10 = default; // eax
    int v11 = default; // edx
    float v12 = default; // xmm0_4
    float v13 = default; // xmm0_4
    int v14 = default; // xmm1_4
    int v15 = default; // ecx
    float v16 = default; // xmm0_4
    int v17 = default; // eax
    uint v18 = default; // eax
    int v19 = default; // ecx
    float v20 = default; // [esp+Ch] [ebp-4h]
  
    v4 = this.TimeToUpdate;
    if ( v4 <= 0.0f )
    {
      v5 = E_TryCastTo<TdPawn>(SkelComp.Owner);
      v6 = rand();
      v7 = this.bAlwaysSwitchSign.AsBitfield(2);
      v8 = v6 % (this.MaxAngle - this.MinAngle + 1) + this.MinAngle;
      this.TargetAngle = v8;
      if ( (v7 & 1) != default )
      {
        if(v8 != default)
        {
          v9 = v8;
          if ( v8 < 0 )
            v9 = -v8;
          v10 = v8 / v9;
        }
        else
        {
          v10 = default;
        }
        v11 = this.LastSign;
        if ( v10 == v11 )
          this.TargetAngle = -v8;
        this.LastSign = -v11;
      }
      if ( (v7 & 2) != default )
      {
        if ( !v5 )
        {
  LABEL_23:
          this.TimeToUpdate = this.Frequency;
          this.BoneRotation.Pitch = default;
          this.BoneRotation.Yaw = default;
          this.BoneRotation.Roll = default;
          goto LABEL_25;
        }
        v12 = this.MinVelocity;
        v20 = (float)(sqrt(v5.Velocity.Y * v5.Velocity.Y + v5.Velocity.X * v5.Velocity.X));
        if ( v12 < v20 )
          v12 = v20;
        v13 = v12 / this.MaxVelocity;
        v14 = default;
        if ( v13 < 0.0f || ((v14 = 1065353216) is object && v13 > 1.0f) )
          v13 = *(float *)&v14;
        this.TargetAngle = (int)(float)((float)this.TargetAngle * v13);
      }
      if ( v5 && (v5.GetWeaponType() == EWT_Heavy || v5.WeaponAnimState == EWeaponAnimState.WS_Ready) )
        this.TargetAngle = default;
      this.TimeToUpdate = this.Frequency;
      this.BoneRotation.Pitch = default;
      this.BoneRotation.Yaw = default;
      this.BoneRotation.Roll = default;
      goto LABEL_25;
    }
    this.TimeToUpdate = v4 - DeltaSeconds;
  LABEL_25:
    v15 = this.CurrentAngle;
    v16 = (float)(this.TargetInterpolationTime * DeltaSeconds) * 30.0f;
    v17 = (ushort)(this.TargetAngle - v15);
    if ( (uint)v17 > 0x7FFF )
      v17 = v17 - (0x10000);
    if ( v16 >= 1.0f )
      v16 = 1.0f;
    v18 = (ushort)(v15 + (int)(float)((float)v17 * v16));
    if ( v18 > 0x7FFF )
      v18 = v18 - (0x10000);
    v19 = (byte)this.AffectedAxis - 1;
    this.CurrentAngle = (int)v18;
    if(v19 != default)
    {
      if ( v19 == 1 )
        this.BoneRotation.Roll = (int)v18;
      else
        this.BoneRotation.Yaw = (int)v18;
    }
    else
    {
      this.BoneRotation.Pitch = (int)v18;
    }
    base.TickSkelControl(DeltaSeconds, SkelComp);
  }
}
}
