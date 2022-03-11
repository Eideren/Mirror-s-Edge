namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdSkelControlLimb
{
  public unsafe Vector * ConstrainBone_orsomething(Vector *output, ref Vector location, SkeletalMeshComponent a4, int BoneIndex)
  {
    Matrix *v6; // eax
    float v7 = default; // xmm4_4
    float v8 = default; // xmm5_4
    float v9 = default; // xmm0_4
    float v10 = default; // xmm1_4
    float v11 = default; // xmm2_4
    Vector *result; // eax
    float v13 = default; // edx
    float v14 = default; // xmm1_4
    float v15 = default; // ecx
    float v16 = default; // xmm2_4
    float v17 = default; // xmm0_4
    float v18 = default; // xmm0_4
    float v19 = default; // xmm1_4
    float v20 = default; // xmm4_4
    float v21 = default; // xmm0_4
    float v22 = default; // xmm1_4
    float v23 = default; // xmm5_4
    float v24 = default; // xmm1_4
    float v25 = default; // xmm2_4
    float v26 = default; // [esp+4h] [ebp-8Ch]
    Matrix DstMatrix = default; // [esp+10h] [ebp-80h] BYREF
    Matrix SrcMatrix = default; // [esp+50h] [ebp-40h] BYREF
  
    DstMatrix = a4.CalcComponentToFrameMatrix(BoneIndex, this.EffectorLocationSpace, this.EffectorSpaceBoneName);
    SrcMatrix = DstMatrix.Inverse();
    v6 = &SrcMatrix;
    v7 = location.Y;
    v8 = location.Z;
    v9 = (float)((float)((float)(v6->YPlane.X * v7) + (float)(v6->ZPlane.X * v8)) + (float)(v6->XPlane.X * location.X)) + v6->WPlane.X;
    v10 = (float)((float)((float)(v6->YPlane.Y * v7) + (float)(v6->ZPlane.Y * v8)) + (float)(v6->XPlane.Y * location.X)) + v6->WPlane.Y;
    v11 = (float)((float)((float)(v6->YPlane.Z * v7) + (float)(v6->ZPlane.Z * v8)) + (float)(v6->XPlane.Z * location.X)) + v6->WPlane.Z;
    result = output;
    output->X = v9;
    v13 = v10;
    v14 = this.MinLocation.X;
    v15 = v11;
    v16 = this.MaxLocation.X;
    output->Y = v13;
    output->Z = v15;
    v17 = output->X;
    if ( output->X < v14 )
      v17 = v14;
    if ( v16 >= v17 )
      v16 = v17;
    v18 = output->Y;
    v19 = this.MinLocation.Y;
    v20 = this.MaxLocation.Y;
    output->X = v16;
    if ( v18 < v19 )
      v18 = v19;
    if ( v20 >= v18 )
      v20 = v18;
    v21 = output->Z;
    v22 = this.MinLocation.Z;
    v23 = this.MaxLocation.Z;
    output->Y = v20;
    if ( v21 < v22 )
      v21 = v22;
    if ( v23 >= v21 )
      v23 = v21;
    v24 = (float)((float)((float)(DstMatrix.YPlane.Y * v20) + (float)(DstMatrix.ZPlane.Y * v23)) + (float)(DstMatrix.XPlane.Y * v16)) + DstMatrix.WPlane.Y;
    v26 = (float)((float)((float)(DstMatrix.YPlane.X * v20) + (float)(DstMatrix.ZPlane.X * v23)) + (float)(DstMatrix.XPlane.X * v16)) + DstMatrix.WPlane.X;
    v25 = (float)((float)((float)(DstMatrix.YPlane.Z * v20) + (float)(DstMatrix.ZPlane.Z * v23)) + (float)(DstMatrix.XPlane.Z * v16)) + DstMatrix.WPlane.Z;
    output->X = v26;
    output->Y = v24;
    output->Z = v25;
    return result;
  }

  public override unsafe void CalculateNewBoneTransforms(int BoneIndex, SkeletalMeshComponent SkelComp, ref array<Matrix> OutBoneTransforms)
  {
    uint v4 = default; // eax
    Quat *v5; // eax
    Matrix *v6; // edi
    float v7 = default; // xmm1_4
    float v8 = default; // xmm2_4
    WorldInfo v9 = default; // [esp+18h] [ebp-6Ch]
    Rotator quatThenRot = default; // [esp+1Ch] [ebp-68h] BYREF
    Rotator a2 = default; // [esp+2Ch] [ebp-58h] BYREF
    Rotator vecThenRot2 = default; // [esp+38h] [ebp-4Ch] BYREF
    Matrix v13 = default; // [esp+44h] [ebp-40h] BYREF
  
    v9 = GWorld.GetWorldInfo();
    v4 = this.bDisableRotationAdjustment.AsBitfield(3);
    if ( (v4 & 2) != default )
    {
      if ( (v4 & 4) != default )
        ConstrainBone_orsomething((Vector *)&vecThenRot2, ref this.TargetLocation, SkelComp, BoneIndex);
      this.EffectorLocation = *E_SomeKindOfLerp((Vector *)&vecThenRot2, ref this.EffectorLocation, ref this.TargetLocation, ref v9.DeltaSeconds, 6.0f);
    }
    else if ( (v4 & 4) != default )
    {
      this.EffectorLocation = *ConstrainBone_orsomething((Vector *)&vecThenRot2, ref this.EffectorLocation, SkelComp, BoneIndex);
    }
    base.CalculateNewBoneTransforms(BoneIndex, SkelComp, ref OutBoneTransforms);
    if ( (this.bDisableRotationAdjustment.AsBitfield(3) & 1) != default )
    {
      var q = SkelComp.GetBoneQuaternion(
        SkelComp.SkeletalMesh.RefSkeleton[SkelComp.SkeletalMesh.RefSkeleton[SkelComp.SkeletalMesh.RefSkeleton[BoneIndex].ParentIndex].ParentIndex].Name,
        1);
      E_Quat2Rot(&vecThenRot2, &q);
      a2 = OutBoneTransforms.Data[0].Rotator();
      quatThenRot.Pitch = a2.Pitch;
      quatThenRot.Roll = vecThenRot2.Roll;
      quatThenRot.Yaw = a2.Yaw;
      FRotationMatrix(&v13, quatThenRot);
      //v6 = OutBoneTransforms.Data;
      v7 = OutBoneTransforms[0].WPlane.Y;
      v8 = OutBoneTransforms[0].WPlane.Z;
      v13.WPlane.X = OutBoneTransforms[0].WPlane.X;
      v13.WPlane.Y = v7;
      v13.WPlane.Z = v8;
      OutBoneTransforms[0] = v13;
    }
  }
}
}
