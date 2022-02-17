namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdSkelControlAim1p
{
  public unsafe void UpdateTransformation_probably(TdPlayerPawn a2)
  {
    Controller v3 = default; // ecx
    int v4 = default; // eax
    int v5 = default; // ebx
    int v6 = default; // ecx
    int v7 = default; // edx
    int v8 = default; // ecx
    int v9 = default; // eax
    int v10 = default; // eax
    int v11 = default; // ecx
    int v12 = default; // ebp
    float v13 = default; // ecx
    float v14 = default; // edx
    Rotator rollThenVector = default; // [esp+10h] [ebp-18h] BYREF
    Rotator a5 = default; // [esp+1Ch] [ebp-Ch] BYREF
  
    if(a2 != default)
    {
      v3 = a2.Controller;
      if(v3 != default)
      {
        v4 = v3.Rotation.Yaw;
        v5 = v3.Rotation.Pitch;
        v6 = v3.Rotation.Roll - a2.Rotation.Roll;
        v7 = v5 - a2.Rotation.Pitch;
        rollThenVector.Yaw = v4 - a2.Rotation.Yaw;
        rollThenVector.Roll = v6;
        rollThenVector.Pitch = v7;
        a5 = rollThenVector;
        a5.Normalize();
        v8 = a5.Yaw;
        rollThenVector.Pitch = default;
        rollThenVector.Yaw = default;
        this.BoneTranslation.X = 0.0f;
        this.BoneTranslation.Y = 0.0f;
        v9 = (int)this.AimingType;
        this.BoneRotation.Pitch = v8;
        rollThenVector.Roll = default;
        this.BoneRotation.Roll = -v5;
        this.BoneRotationSpace = EBoneControlSpace.BCS_ComponentSpace;
        this.BoneTranslation.Z = 0.0f;
        this.BoneTranslationSpace = EBoneControlSpace.BCS_BoneSpace;
        if ( v9 == 2 || v9 == 3 )
        {
          v10 = a2.PlayerCameraRotation.Roll;
          v11 = a2.PlayerCameraRotation.Yaw;
          a5.Pitch = a2.PlayerCameraRotation.Pitch;
          a5.Roll = v10;
          *(Vector*)&rollThenVector = a2.SwanNeck1p.GetSwanNeckPos(new Rotator(0, v11, 0));// GetSwanNeckPos
          v13 = *(float *)&rollThenVector.Yaw;
          v14 = *(float *)&rollThenVector.Roll;
          this.BoneTranslation.X.LODWORD(rollThenVector.Pitch);
          this.BoneTranslation.Y = v13;
          this.BoneTranslation.Z = v14;
          this.BoneTranslationSpace = EBoneControlSpace.BCS_WorldSpace;
        }
      }
    }
  }

  public override unsafe void TickSkelControl(float DeltaSeconds, SkeletalMeshComponent SkelComp)
  {
    TdPawn v5 = default; // eax
    TdPawn v6 = default; // esi
    EMoveAimMode v7 = default; // al
    EAimingType v8 = default; // cl
    float v9 = default; // xmm0_4
    bool v10 = default; // zf
    EMovement v11 = default; // al
    double v12 = default; // st7
    float InBlendTime = default; // [esp+4h] [ebp-10h]
    float SkelCompa = default; // [esp+1Ch] [ebp+8h]
  
    if(SkelComp != default)
    {
      v5 = E_TryCastTo<TdPawn>(SkelComp.Owner);
      v6 = v5;
      if(v5 != default)
      {
        v7 = v5.GetAimMode(true);
        v8 = this.AimingType;
        v9 = 0.0f;
        SkelCompa = 0.0f;
        if ( v8 == EAimingType.TDEAT_Right )
        {
          v10 = v7 == MAM_Right;
        }
        else
        {
          if ( v8 != EAimingType.TDEAT_Left )
            goto LABEL_11;
          v10 = v7 == MAM_Left;
        }
        if ( v10 || v7 == MAM_TwoHanded )
          v9 = 1.0f;
        SkelCompa = v9;
  LABEL_11:
        v11 = v6.MovementState;
        if ( (v11 == MOVE_Melee || v11 == MOVE_MeleeCrouch) && this.ControlStrength != v9 )
        {
          v12 = 0.1f;
        }
        else
        {
          if ( this.ControlStrength == v9 )
          {
  LABEL_18:
            base.TickSkelControl(DeltaSeconds, SkelComp);
            return;
          }
          v12 = 0.5f;
        }
        InBlendTime = (float)v12;
        this.SetSkelControlStrength(SkelCompa, InBlendTime);
        base.TickSkelControl(DeltaSeconds, SkelComp);
        return;
      }
    }
  }

  public override unsafe void CalculateNewBoneTransforms(int BoneIndex, SkeletalMeshComponent SkelComp, ref array<Matrix> OutBoneTransforms)
  {
    TdPawn v4 = default; // eax
  
    if(SkelComp != default)
      v4 = E_TryCastTo<TdPawn>(SkelComp.Owner);
    else
      v4 = default;
    this.UpdateTransformation_probably(v4 as TdPlayerPawn);// UpdateTransformation_probably, 0x12220c0
    base.CalculateNewBoneTransforms(BoneIndex, SkelComp, ref OutBoneTransforms);
  }
}
}
