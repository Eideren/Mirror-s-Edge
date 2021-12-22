namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdMove_Melee
{
  public override unsafe void PrePerformPhysics(float DeltaTime)
  {
    TdPlayerController v3 = default; // eax
    float v4 = default; // ecx
    float v5 = default; // edx
    TdPawn v6 = default; // ecx
    Quat *v7; // eax
    Vector *v8; // edi
    Vector *v9; // eax
    float v10 = default; // xmm0_4
    float v11 = default; // eax
    TdPawn v12 = default; // ecx
    Vector *v13; // eax
    float v14 = default; // ecx
    float v15 = default; // edx
    float v16 = default; // eax
    TdPawn v17 = default; // eax
    float v18 = default; // xmm3_4
    float v19 = default; // xmm0_4
    TdPawn v20 = default; // eax
    float v21 = default; // ecx
    float v22 = default; // edx
    Vector v23 = default; // [esp-8h] [ebp-9Ch]
    Vector v24 = default; // [esp-4h] [ebp-98h]
    Vector v25 = default; // [esp+14h] [ebp-80h] BYREF
    Vector v26 = default; // [esp+20h] [ebp-74h] BYREF
    Vector a2 = default; // [esp+2Ch] [ebp-68h] BYREF
    Quat out_data = default; // [esp+38h] [ebp-5Ch] BYREF
    CheckResult v29 = default; // [esp+48h] [ebp-4Ch] BYREF
    int v30 = default; // [esp+90h] [ebp-4h]
  
    base.PrePerformPhysics(DeltaTime);
    if ( this.PawnOwner.IsLocallyControlled() )
    {
      if ( this.PawnOwner.Controller )
      {
        if ( (this.bTargeting.AsBitfield(2) & 1) != 0 && default == this.TargetPawn )
        {
          v3 = E_TryCastTo<TdPlayerController>(this.PawnOwner.Controller);
          if(v3 != default)
            this.TargetPawn = (TdPawn )v3.0x011C30A0( this.TargetingMaxDistance);// 0x011C30A0
        }
        if ( (this.bTargeting.AsBitfield(2) & 2) != 0 )
        {
          v4 = this.TraceOffset.X;
          v5 = this.TraceOffset.Y;
          v29.Item = -1;
          v29.LevelIndex = -1;
          v24.X = v4;
          v24.Y = v5;
          v24.Z = this.TraceOffset.Z;
          v6 = this.PawnOwner;
          v29.Actor = default;
          v29.Location.X = 0.0f;
          v29.Location.Y = 0.0f;
          v29.Location.Z = 0.0f;
          v29.Normal.X = 0.0f;
          v29.Normal.Y = 0.0f;
          v29.Normal.Z = 0.0f;
          v29.Time = 0.0f;
          v29.Material = default;
          v29.PhysMaterial = default;
          v29.Component = default;
          v29.BoneName = default;
          v29.Level = default;
          v29.bStartPenetrating = default;
          v30 = default;
fixed(var ptr1 =&v6.Rotation)
          v7 = E_QuatFromRotator( ptr1, &out_data);
          v8 = v7->RotateVector(&v26, v24);
          v9 = this.PawnOwner.Mesh1p.GetBoneLocation(&a2, this.HitDetectionBone, 0);
          v25.X = v8->X + v9->X;
          v25.Y = v8->Y + v9->Y;
          v10 = v8->Z + v9->Z;
          v11 = v25.Y;
          v25.Z = v10;
          this.HitDetectionStart.X = v25.X;
          this.HitDetectionStart.Y = v11;
          this.HitDetectionStart.Z = v10;
          v12 = this.PawnOwner;
          v25.X = this.HitDetectionStart.X - this.HitDetectionLastStart.X;
          v25.Y = this.HitDetectionStart.Y - this.HitDetectionLastStart.Y;
          v25.Z = this.HitDetectionStart.Z - this.HitDetectionLastStart.Z;
          v23 = *v12.Rotation.Vector(&a2);
          v13 = E_SomeVectorFunc(&v26, v25, v23, 35.0f);
          v14 = v13->X;
          v15 = v13->Y;
          v16 = v13->Z;
          v25.X = v14;
          v25.Y = v15;
          v25.Z = v16;
          v25.SafeNormal(0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/);
          v17 = this.PawnOwner;
          v18 = this.HitDetectionStart.X + (float)(v25.X * 10.0f);
          v25.Y = this.HitDetectionStart.Y + (float)(v25.Y * 10.0f);
          v19 = this.HitDetectionStart.Z;
          v25.X = v18;
          v25.Z = v19 + (float)(v25.Z * 10.0f);
fixed(var ptr2 =&this.TraceExtent)
fixed(var ptr3 =&this.HitDetectionStart)
          if ( default == GWorld.SingleLineCheck(&v29, v17, &v25,  ptr3, 1,  ptr2, 0) )
          {
            v20 = E_TryCastTo<TdPawn>(v29.Actor);
            E_Call_TriggerDamage(this, v20);
          }
          v21 = this.HitDetectionStart.Y;
          v22 = this.HitDetectionStart.Z;
          this.HitDetectionLastStart.X = this.HitDetectionStart.X;
          this.HitDetectionLastStart.Y = v21;
          this.HitDetectionLastStart.Z = v22;
        }
      }
    }
  }
}
}
