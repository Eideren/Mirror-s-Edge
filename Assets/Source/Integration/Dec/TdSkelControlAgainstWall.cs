// NO OVERWRITE

namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdSkelControlAgainstWall
{
  public override unsafe void TickSkelControl(float DeltaSeconds, SkeletalMeshComponent SkelComp)
  {
    SkeletalMeshComponent v3 = default; // edi
    TdPawn v5 = default; // eax
    float v6 = default; // xmm0_4
    float v7 = default; // xmm1_4
    float v8 = default; // xmm2_4
    float v9 = default; // xmm0_4
    float v10 = default; // xmm1_4
    float v11 = default; // xmm2_4
    float v12 = default; // xmm0_4
    EAgainstWallState v13 = default; // cl
    Vector v14 = default; // rax
    Matrix *v15; // eax
    float v16 = default; // xmm1_4
    float v17 = default; // xmm2_4
    float v18 = default; // eax
    float v19 = default; // xmm1_4
    float v20 = default; // ecx
    float v21 = default; // xmm2_4
    float v22 = default; // xmm0_4
    float v23 = default; // xmm0_4
    float v24 = default; // xmm1_4
    float v25 = default; // xmm1_4
    float v26 = default; // xmm2_4
    float v27 = default; // xmm0_4
    Vector output = default; // [esp+1Ch] [ebp-4Ch] BYREF
    Matrix SrcMatrix = default; // [esp+28h] [ebp-40h] BYREF
  
    v3 = SkelComp;
    base.TickSkelControl(DeltaSeconds, SkelComp);
    v5 = E_TryCastTo<TdPawn>(v3.Owner);
    if(v5 != default)
    {
      v13 = v5.AgainstWallState;
      if ( v13 == EAgainstWallState.AW_AgainstWall || this.bLeftHand != default && v13 == EAgainstWallState.AW_AgainstWallLeft || (this.bLeftHand == false) && v13 == EAgainstWallState.AW_AgainstWallRight )
      {
        Vector v;
        if ( this.bLeftHand != default )
          v = v5.AgainstWallLeftHand;
        else
          v = v5.AgainstWallRightHand;
        v14.Z = v.X;
        v14.Y = v.Y;
        v14.X = v.Z;
        output.X = this.HandOffset.X + v14.Z;
        output.Y = this.HandOffset.Y + v14.Y;
        output.Z = this.HandOffset.Z + v14.X;
        SrcMatrix = v3.LocalToWorld.Inverse();
        v15 = &SrcMatrix;
        v16 = (float)((float)((float)(v15->ZPlane.Y * output.Z) + (float)(v15->YPlane.Y * output.Y)) + (float)(v15->XPlane.Y * output.X)) + v15->WPlane.Y;
        v17 = (float)((float)((float)(v15->ZPlane.Z * output.Z) + (float)(v15->YPlane.Z * output.Y)) + (float)(v15->XPlane.Z * output.X)) + v15->WPlane.Z;
        output.X = (float)((float)((float)(v15->ZPlane.X * output.Z) + (float)(v15->YPlane.X * output.Y)) + (float)(output.X * v15->XPlane.X)) + v15->WPlane.X;
        output.Y = v16;
        v18 = v16;
        v19 = this.MinLocation.X;
        output.Z = v17;
        v20 = v17;
        v21 = this.MaxLocation.X;
        this.TargetLocation.X = output.X;
        this.TargetLocation.Y = v18;
        this.TargetLocation.Z = v20;
        v22 = this.TargetLocation.X;
        if ( v22 < v19 )
          v22 = v19;
        if ( v21 >= v22 )
          v21 = v22;
        v23 = this.TargetLocation.Y;
        v24 = this.MinLocation.Y;
        this.TargetLocation.X = v21;
        if ( v23 < v24 )
          v23 = v24;
        if ( this.MaxLocation.Y < v23 )
          v23 = this.MaxLocation.Y;
        v25 = this.MinLocation.Z;
        v26 = this.MaxLocation.Z;
        this.TargetLocation.Y = v23;
        v27 = this.TargetLocation.Z;
        if ( v27 < v25 )
          v27 = v25;
        if ( v26 < v27 )
          v27 = v26;
        this.TargetLocation.Z = v27;
      }
      this.EffectorLocation = *E_SomeKindOfLerp(&output, ref this.EffectorLocation, ref this.TargetLocation, ref DeltaSeconds, 6.0f);
      this.EffectorLocationSpace = EBoneControlSpace.BCS_ComponentSpace;
    }
    else
    {
      v6 = this.EffectorLocation.X;
      if ( v6 < this.MinLocation.X )
        v6 = this.MinLocation.X;
      if ( this.MaxLocation.X < v6 )
        v6 = this.MaxLocation.X;
      v7 = this.MinLocation.Y;
      v8 = this.MaxLocation.Y;
      this.EffectorLocation.X = v6;
      v9 = this.EffectorLocation.Y;
      if ( v9 < v7 )
        v9 = v7;
      if ( v8 < v9 )
        v9 = v8;
      v10 = this.MinLocation.Z;
      v11 = this.MaxLocation.Z;
      this.EffectorLocation.Y = v9;
      v12 = this.EffectorLocation.Z;
      if ( v12 < v10 )
        v12 = v10;
      if ( v11 < v12 )
        v12 = v11;
      this.EffectorLocation.Z = v12;
    }
  }
}
}
