// NO OVERWRITE

namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdSkelControlLazySpring
{
  public unsafe void UpdateLazyRotation(Controller a2)
  {
    int v2 = default; // eax
  
    if ( this.SourceAxis != default )
    {
      if ( this.SourceAxis == SpringAxis.SAPitch )
      {
        v2 = a2.Rotation.Pitch;
      }
      else
      {
        if ( this.SourceAxis != SpringAxis.SARoll )
          return;
        v2 = a2.Rotation.Roll;
      }
    }
    else
    {
      v2 = a2.Rotation.Yaw;
    }
    v2 = (ushort)v2;
    if ( (ushort)v2 > 0x7FFFu )
      v2 = (ushort)v2 - 0x10000;
    this.LazyRotation = v2;
  }

  // 49:           || (*(int (**)(void))(myAnimationController->VfTableObject.Dummy + 820))())// Use lazy spring and is not disabled
  public override unsafe void TickSkelControl(float DeltaSeconds, SkeletalMeshComponent SkelComp)
  {
    TdPawn v3 = default; // ebp
    Actor v4 = default; // eax
    Controller v5 = default; // ebx
    bool v6 = default; // edi
    TdAIAnimationController v7 = default; // eax
    double v8 = default; // st7
    short v9 = default; // di
    float v10 = default; // xmm0_4
    int v11 = default; // eax
    double v12 = default; // st7
    float v13 = default; // xmm2_4
    float v14 = default; // xmm0_4
    int v15 = default; // edi
    uint v16 = default; // eax
    float v17 = default; // xmm0_4
    float v18 = default; // xmm0_4
    float v19 = default; // xmm0_4
    int v20 = default; // edx
    int v21 = default; // [esp-4h] [ebp-24h]
    float NewStrength = default; // [esp+0h] [ebp-20h]
    float InBlendTime = default; // [esp+4h] [ebp-1Ch]
    int InBlendTimea = default; // [esp+4h] [ebp-1Ch]
    int InBlendTimeb = default; // [esp+4h] [ebp-1Ch]
    float v26 = default; // [esp+18h] [ebp-8h]
    float v27 = default; // [esp+18h] [ebp-8h]
    float v28 = default; // [esp+1Ch] [ebp-4h]
    float v29 = default; // [esp+1Ch] [ebp-4h]
    float v30 = default; // [esp+1Ch] [ebp-4h]
    float v31 = default; // [esp+1Ch] [ebp-4h]
  
    v3 = E_TryCastTo<TdPawn>(SkelComp.Owner);
    if ( !v3 )
      return;
    v4 = SkelComp.Owner;
    if ( !v4 )
      return;
    v5 = E_TryCastTo<Pawn>(v4).Controller;
    if ( !v5 )
      return;
    v6 = (this.bScaleByVelocity.AsBitfield(3) & 1) != default || v3.GetAimMode(false) != MAM_NoHands;
    if ( (!E_TryCastTo<TdBotPawn>(v3) || (v7 = E_TryCastTo<TdBotPawn>(v3).myAnimationController) == default /*|| (*(int (**)(void))(v7.VfTableObject.Dummy + 820))()*/) && v6 )
    {
      if ( this.ControlStrength <= 0.0f )
      {
        UpdateLazyRotation(v5);
        InBlendTime = 0.1f;
        v8 = 1.0f;
        NewStrength = (float)v8;
        this.SetSkelControlStrength(NewStrength, InBlendTime);
        goto LABEL_17;
      }
    }
    else if ( this.ControlStrength >= 1.0f )
    {
      InBlendTime = 0.1f;
      v8 = 0.0f;
  LABEL_16:
      NewStrength = (float)v8;
      this.SetSkelControlStrength(NewStrength, InBlendTime);
      goto LABEL_17;
    }
  LABEL_17:
    if ( this.ControlStrength > 0.0000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
    {
      if ( this.SourceAxis == SpringAxis.SAPitch )
      {
        InBlendTimea = v5.Rotation.Pitch;
      }
      else if ( this.SourceAxis == SpringAxis.SARoll )
      {
        InBlendTimea = v5.Rotation.Roll;
      }
      else
      {
        InBlendTimea = v5.Rotation.Yaw;
      }
      v9 = (short)E_WrapRot((ushort)InBlendTimea);
      if ( this.InterpolateTime < 0.029999999d )
        v26 = (float)(0.029999999d);
      else
        v26 = this.InterpolateTime;
      if ( (this.bScaleByVelocity.AsBitfield(3) & 2) != default )
        v10 = GWorld.GetWorldInfo().SavedDeltaSeconds;
      else
        v10 = DeltaSeconds;
      v11 = (ushort)(v9 - LOWORD(this.LazyRotation));
      if ( (uint)v11 > 0x7FFF )
        v11 = v11 - (0x10000);
      v12 = (float)v11;
      if ( (float)v11 == 0.0f )
      {
        v13 = 0.0f;
      }
      else
      {
        v28 = (float)(v12 / fabs(v12));
        v13 = v28;
      }
      v29 = (float)(fabs(v12));
      v14 = (float)(v10 / v26) * v29;
      if ( v14 <= 1.0f )
        v14 = 1.0f;
      if ( v14 >= v29 )
        v14 = v29;
      this.LazyRotation = this.LazyRotation + ((int)(float)(v13 * v14));
      v15 = (ushort)(v9 - LOWORD(this.LazyRotation));
      if ( v15 > 0x7FFF )
        v15 = v15 - (0x10000);
      v16 = this.bScaleByVelocity.AsBitfield(3);
      if ( (v16 & 4) != default && v15 < 0 )
        v15 = -v15;
      if ( (v16 & 1) != default )
      {
        v17 = this.MinVelocity;
        v30 = (float)(sqrt(v3.Velocity.Y * v3.Velocity.Y + v3.Velocity.X * v3.Velocity.X));
        if ( v17 < v30 )
          v17 = v30;
        v18 = v17 / this.MaxVelocity;
        if ( v18 >= 0.0f )
        {
          if ( v18 > 1.0f )
            v18 = 1.0f;
        }
        else
        {
          v18 = 0.0f;
        }
        v15 = (int)(float)((float)v15 * v18);
      }
      v27 = this.SpringMultiplier;
      if ( v3.GetWeaponType() == EWT_Heavy )
        v19 = this.HeavyWeaponModifier * v27;
      else
        v19 = v27;
      v31 = (float)v15 * v19;
      v20 = this.MinAngle;
      if ( this.AffectedAxis == SpringAxis.SAPitch )
      {
        this.BoneRotation.Pitch = E_ClampInt((int)v31, v20, this.MaxAngle);
      }
      else
      {
        InBlendTimeb = this.MaxAngle;
        v21 = (int)v31;
        if ( this.AffectedAxis == SpringAxis.SARoll )
          this.BoneRotation.Roll = E_ClampInt(v21, v20, InBlendTimeb);
        else
          this.BoneRotation.Yaw = E_ClampInt(v21, v20, InBlendTimeb);
      }
      SetFromBitfield(ref this.bApplyTranslation, 4, this.bApplyTranslation.AsBitfield(4) & 0xFFFFFFFE | 4);
    }
    base.TickSkelControl(DeltaSeconds, SkelComp);
  }
}
}
