namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdSkelControlFootPlacement
{
  public override unsafe void CalculateNewBoneTransforms(int BoneIndex, SkeletalMeshComponent SkelComp, ref array<Matrix> OutBoneTransforms)
  {
    NativeMarkers.MarkUnimplemented();
    base.CalculateNewBoneTransforms( BoneIndex, SkelComp, ref OutBoneTransforms );
    return;
    #if UNUSED
    TdSkelControlFootPlacement v4 = default; // esi
    int *v6; // eax
    int v7 = default; // ebx
    TdPawn v8 = default; // eax
    float v9 = default; // xmm7_4
    float *v10; // edx
    Matrix *v11; // eax
    float v12 = default; // xmm3_4
    float v13 = default; // xmm4_4
    float v14 = default; // xmm5_4
    float v15 = default; // xmm0_4
    float v16 = default; // xmm1_4
    float v17 = default; // xmm2_4
    Matrix *v18; // ebx
    float v19 = default; // xmm0_4
    float v20 = default; // xmm1_4
    float v21 = default; // xmm2_4
    float v22 = default; // xmm3_4
    float v23 = default; // xmm4_4
    float v24 = default; // xmm2_4
    float v25 = default; // xmm3_4
    float v26 = default; // xmm6_4
    float v27 = default; // xmm4_4
    float v28 = default; // xmm5_4
    float v29 = default; // xmm5_4
    float v30 = default; // xmm6_4
    float v31 = default; // xmm7_4
    float v32 = default; // xmm0_4
    float v33 = default; // xmm2_4
    float v34 = default; // xmm7_4
    float v35 = default; // xmm0_4
    int v36 = default; // edx
    Matrix *v37; // eax
    int v38 = default; // edx
    float v39 = default; // xmm0_4
    float v40 = default; // xmm7_4
    float v41 = default; // xmm1_4
    float v42 = default; // xmm3_4
    float v43 = default; // xmm0_4
    float v44 = default; // xmm2_4
    float v45 = default; // xmm0_4
    float v46 = default; // xmm1_4
    float v47 = default; // xmm2_4
    float v48 = default; // xmm2_4
    float v49 = default; // ecx
    float v50 = default; // xmm0_4
    // int (__stdcall *v51)(Vector *, Vector *, Vector *, float *); // edx
    int v52 = default; // eax
    float v53 = default; // xmm0_4
    uint v54 = default; // ecx
    uint v55 = default; // eax
    float v56 = default; // xmm1_4
    float v57 = default; // xmm0_4
    double v58 = default; // st7
    uint v59 = default; // ecx
    float v60 = default; // eax
    float v61 = default; // edx
    float *v62; // eax
    bool v63 = default; // zf
    uint v64 = default; // eax
    ref array<Matrix> v65; // edi
    float v66 = default; // xmm6_4
    float v67 = default; // xmm3_4
    float v68 = default; // xmm4_4
    float v69 = default; // xmm7_4
    float v70 = default; // xmm5_4
    float v71 = default; // xmm2_4
    float v72 = default; // xmm0_4
    Matrix *v73; // eax
    uint v74 = default; // ecx
    Matrix *v75; // eax
    Vector *v76; // eax
    float v77 = default; // xmm5_4
    float v78 = default; // xmm4_4
    float v79 = default; // xmm1_4
    float v80 = default; // xmm2_4
    float v81 = default; // xmm0_4
    float v82 = default; // xmm2_4
    Matrix *v83; // eax
    Matrix *v84; // edi
    Matrix *v85; // eax
    float v86 = default; // xmm0_4
    Matrix *v87; // eax
    Rotator *v88; // eax
    int v89 = default; // eax
    Rotator *v90; // eax
    int v91 = default; // ecx
    uint v92 = default; // eax
    Matrix *v93; // esi
    Matrix *v94; // eax
    float v95 = default; // xmm0_4
    float v96 = default; // xmm1_4
    float v97 = default; // xmm2_4
    float *v98; // [esp+14h] [ebp-168h]
    float v99 = default; // [esp+18h] [ebp-164h]
    Matrix *anglea; // [esp+18h] [ebp-164h]
    float angleb = default; // [esp+18h] [ebp-164h]
    float anglec = default; // [esp+18h] [ebp-164h]
    Vector vecThenRot2 = default; // [esp+34h] [ebp-148h] BYREF
    Vector a2 = default; // [esp+44h] [ebp-138h] BYREF
    Vector vecThenRot = default; // [esp+54h] [ebp-128h] BYREF
    float v106 = default; // [esp+64h] [ebp-118h]
    float v107 = default; // [esp+68h] [ebp-114h]
    float v108 = default; // [esp+6Ch] [ebp-110h]
    float v109 = default; // [esp+70h] [ebp-10Ch] BYREF
    float Angle = default; // [esp+74h] [ebp-108h] BYREF
    Vector v111 = default; // [esp+78h] [ebp-104h]
    int v112 = default; // [esp+88h] [ebp-F4h]
    Quat a1 = default; // [esp+8Ch] [ebp-F0h] BYREF
    float v114 = default; // [esp+A0h] [ebp-DCh] BYREF
    float v115 = default; // [esp+A4h] [ebp-D8h]
    float v116 = default; // [esp+A8h] [ebp-D4h]
    //float v117 = default; // [esp+ACh] [ebp-D0h]
    TdSkelControlFootPlacement v118 = default; // [esp+B0h] [ebp-CCh]
    float *v119; // [esp+B4h] [ebp-C8h]
    Vector v120 = default; // [esp+B8h] [ebp-C4h] BYREF
    Vector v121 = default; // [esp+C4h] [ebp-B8h] BYREF
    Vector v122 = default; // [esp+D0h] [ebp-ACh] BYREF
    Matrix SrcMatrix = default; // [esp+DCh] [ebp-A0h] BYREF
    //float *deltaTime; // [esp+120h] [ebp-5Ch]
    int v125 = default; // [esp+124h] [ebp-58h]
    int v126 = default; // [esp+128h] [ebp-54h]
    Quat v127 = default; // [esp+12Ch] [ebp-50h] BYREF
    Matrix out = default; // [esp+13Ch] [ebp-40h] BYREF
  
    v4 = this;
    v6 = SkelComp.SkeletalMesh.RefSkeleton.Data;
    v7 = v6[18 * v6[18 * BoneIndex + 14] + 14];
    v126 = v6[18 * BoneIndex + 14];
    v118 = this;
    //v117 = COERCE_FLOAT(GWorld.GetWorldInfo());
    v8 = E_TryCastTo<TdPawn>(SkelComp.Owner);
    v7 <<= 6;
    v9 = SkelComp.LocalToWorld.YPlane.X;
    v10 = (float *)&v8.VfTableObject.Dummy;
    v11 = SkelComp.SpaceBases.Data;
    v12 = *(float *)((byte *)&v11->WPlane.X + v7);
    v13 = *(float *)((byte *)&v11->WPlane.Y + v7);
    v14 = *(float *)((byte *)&v11->WPlane.Z + v7);
    v15 = (float)(SkelComp.LocalToWorld.YPlane.X * v13) + (float)(SkelComp.LocalToWorld.ZPlane.X * v14);
    v16 = SkelComp.LocalToWorld.XPlane.X * v12;
    v17 = SkelComp.LocalToWorld.YPlane.Y * v13;
    v125 = v7;
    v18 = ref SkelComp.LocalToWorld;
    v19 = v15 + v16;
    v20 = (float)((float)((float)(SkelComp.LocalToWorld.XPlane.Y * v12) + v17) + (float)(SkelComp.LocalToWorld.ZPlane.Y * v14)) + SkelComp.LocalToWorld.WPlane.Y;
    v21 = SkelComp.LocalToWorld.XPlane.Z * v12;
    v22 = SkelComp.LocalToWorld.YPlane.Z * v13;
    v23 = SkelComp.LocalToWorld.ZPlane.X;
    v24 = (float)((float)(v21 + v22) + (float)(SkelComp.LocalToWorld.ZPlane.Z * v14)) + SkelComp.LocalToWorld.WPlane.Z;
    v120.X = v19 + SkelComp.LocalToWorld.WPlane.X;
    v120.Y = v20;
    v120.Z = v24;
    v25 = v11[BoneIndex].WPlane.X;
    v26 = v11[BoneIndex].WPlane.Z;
    v111.Y = v11[BoneIndex].WPlane.Y;
    v27 = (float)((float)((float)(v23 * v26) + (float)(v9 * v111.Y)) + (float)(v25 * SkelComp.LocalToWorld.XPlane.X)) + SkelComp.LocalToWorld.WPlane.X;
    v28 = SkelComp.LocalToWorld.XPlane.Y;
    v119 = v10;
    Angle.LODWORD(BoneIndex << 6);
    v111.X = v25;
    v111.Z = v26;
    a1.X = v27;
    v29 = (float)((float)((float)(v28 * v25) + (float)(SkelComp.LocalToWorld.ZPlane.Y * v26)) + (float)(SkelComp.LocalToWorld.YPlane.Y * v111.Y)) + SkelComp.LocalToWorld.WPlane.Y;
    v30 = (float)((float)((float)(SkelComp.LocalToWorld.XPlane.Z * v25) + (float)(SkelComp.LocalToWorld.ZPlane.Z * v26)) + (float)(SkelComp.LocalToWorld.YPlane.Z * v111.Y)) + SkelComp.LocalToWorld.WPlane.Z;
    v31 = v29 - v20;
    vecThenRot2.Z = v30 - v24;
    v32 = (float)((float)((float)(v27 - v120.X) * (float)(v27 - v120.X)) + (float)(vecThenRot2.Z * vecThenRot2.Z)) + (float)(v31 * v31);
    a1.Y = v29;
    a1.Z = v30;
    vecThenRot2.X = v27 - v120.X;
    vecThenRot2.Y = v29 - v20;
    v127.X = v32;
    if ( v32 == 1.0f )
    {
      a2 = vecThenRot2;
      v33 = vecThenRot2.X;
  LABEL_6:
      v34 = 0.0f;
      goto LABEL_7;
    }
    if ( v32 >= SMALL_NUMBER )
    {
      v106 = 0.5f;
      v35 = fsqrt(v127.X);
      vecThenRot.X = (float)(3.0f - (float)((float)((float)(1.0f / v35) * v127.X) * (float)(1.0f / v35))) * (float)((float)(1.0f / v35) * 0.5f);
      v33 = vecThenRot.X * vecThenRot2.X;
      a2.X = vecThenRot.X * vecThenRot2.X;
      a2.Y = v31 * vecThenRot.X;
      a2.Z = vecThenRot2.Z * vecThenRot.X;
      goto LABEL_6;
    }
    v34 = 0.0f;
    v33 = 0.0f;
    a2.X = 0.0f;
    a2.Y = 0.0f;
    a2.Z = 0.0f;
  LABEL_7:
    vecThenRot.X = 0.0f;
    if ( !v10 )
      goto LABEL_15;
    if ( this.BoneAxis == AXIS_X )
      goto LABEL_13;
    if ( this.BoneAxis == AXIS_Y )
    {
      v36 = 1;
      goto LABEL_14;
    }
    if ( this.BoneAxis != AXIS_Z )
    {
  LABEL_13:
      v36 = default;
      goto LABEL_14;
    }
    v36 = 2;
  LABEL_14:
    v37 = ref SkelComp.SpaceBases[BoneIndex];
    v38 = 16 * v36;
    v39 = (float)((this.bInvertBoneAxis.AsBitfield(4) & 1) != default ? -1 : 1) * 10.0f;
    v40 = (float)(*(float *)((byte *)&v37->XPlane.Y + v38) * v39) + v111.Y;
    v41 = (float)(*(float *)((byte *)&v37->XPlane.X + v38) * v39) + v111.X;
    v42 = (float)(*(float *)((byte *)&v37->XPlane.Z + v38) * v39) + v111.Z;
    v43 = SkelComp.LocalToWorld.ZPlane.X;
    v44 = SkelComp.LocalToWorld.YPlane.X * v40;
    vecThenRot2.X = v41;
    v45 = (float)((float)((float)(v43 * v42) + v44) + (float)(v41 * SkelComp.LocalToWorld.XPlane.X)) + SkelComp.LocalToWorld.WPlane.X;
    v46 = (float)((float)((float)(SkelComp.LocalToWorld.ZPlane.Y * v42) + (float)(SkelComp.LocalToWorld.YPlane.Y * v40)) + (float)(SkelComp.LocalToWorld.XPlane.Y * v41)) + SkelComp.LocalToWorld.WPlane.Y;
    v47 = SkelComp.LocalToWorld.ZPlane.Z * v42;
    vecThenRot2.Z = v42;
    v48 = (float)((float)((float)(v47 + (float)(SkelComp.LocalToWorld.YPlane.Z * v40)) + (float)(SkelComp.LocalToWorld.XPlane.Z * vecThenRot2.X)) + SkelComp.LocalToWorld.WPlane.Z) - v30;
    vecThenRot2.Y = v46 - v29;
    vecThenRot2.Z = v48;
    v49 = v48;
    v33 = a2.X;
    vecThenRot2.X = v45 - v27;
    vecThenRot.Y = v46 - v29;
    v34 = v46 - v29;
    vecThenRot.X = v45 - v27;
    vecThenRot.Z = v49;
  LABEL_15:
    v50 = (float)(v4.FootOffset + v4.MaxDownAdjustment) + 10.0f;
    v51 = *(int (__stdcall **)(Vector *, Vector *, Vector *, float *))(SkelComp.VfTableObject.Dummy + 540);
    v121.X = (float)(vecThenRot.X + v27) + (float)(v50 * v33);
    v121.Y = (float)(v34 + v29) + (float)(a2.Y * v50);
    v121.Z = v30 + (float)(a2.Z * v50);
    *(float *)&v52 = COERCE_FLOAT(v51(&v120, &v121, &v122, &v114));
    v53 = (float)((float)(v115 + v114) * 0.0f) + v116;
    v54 = v4.bInvertFootUpAxis.AsBitfield(9) & 0xFFFFFFDF | 0x10;
    v106 = *(float *)&v52;
    SetFromBitfield(ref v4.bInvertFootUpAxis, 9, v54);
    if ( v53 < 0.5f )
    {
      v106 = 0.0f;
      SetFromBitfield(ref v4.bInvertFootUpAxis, 9, v54 & 0xFFFFFFEF);
  LABEL_17:
      v55 = v4.bInvertFootUpAxis.AsBitfield(9);
      if ( (v55 & 8) != default )
        SetFromBitfield(ref v4.bInvertFootUpAxis, 9, v55 & 0xFFFFFFEF);
      v56 = v4.MaxDownAdjustment;
      v57 = (float)(v56 * a2.X) + a1.X;
      vecThenRot.Y = (float)(a2.Y * v56) + a1.Y;
      vecThenRot.Z = (float)(a2.Z * v56) + a1.Z;
      goto LABEL_20;
    }
    if ( *(float *)&v52 == 0.0f )
      goto LABEL_17;
    v66 = a1.X;
    v67 = a2.X;
    v68 = a2.Z;
    v69 = a1.Y;
    v70 = v4.MaxDownAdjustment;
    v71 = a2.Y;
    v72 = (float)((float)((float)((float)(v122.X - a1.X) * a2.X) + (float)((float)(v122.Z - a1.Z) * a2.Z)) + (float)((float)(v122.Y - a1.Y) * a2.Y)) - v4.FootOffset;
    if ( v72 < (float)(-0.0f - v4.MaxUpAdjustment) )
      v72 = -0.0f - v4.MaxUpAdjustment;
    if ( v70 >= v72 )
      v70 = v72;
    if ( (v54 & 8) != default && v70 >= 0.0f )
      SetFromBitfield(ref v4.bInvertFootUpAxis, 9, v54 & 0xFFFFFFEF);
    v57 = (float)(v67 * v70) + v66;
    vecThenRot.Y = (float)(v71 * v70) + v69;
    vecThenRot.Z = (float)(v68 * v70) + a1.Z;
  LABEL_20:
    vecThenRot.X = v57;
    v107 = v57;
    v109 = vecThenRot.Z;
    v108 = vecThenRot.Y;
    v112 = default;
    if ( v119 && (float)((float)((float)(v119[169] + v119[168]) * 0.0f) + v119[170]) != 1.0f )
      v112 = 1;
    if(GIsEditor != default)
      v112 = 1;
    if ( (v4.bInvertFootUpAxis.AsBitfield(9) & 0x100) != default )
      v4.InterpolatedPosition = v109;
    v99 = v4.PositionInterpolationSpeed;
    //deltaTime = ;
    v58 = E_WeirdAssScalingThing(ref v4.InterpolatedPosition, &v109, GWorld.GetWorldInfo().DeltaSeconds, v99);
    var v117 = (float)v58;
    v4.InterpolatedPosition = (float)v58;
    if ( fabs(v109 - v58) > 0.050000001d )
      SetFromBitfield(ref v4.bInvertFootUpAxis, 9, v4.bInvertFootUpAxis.AsBitfield(9) | (0x10u));
    v59 = v4.bInvertFootUpAxis.AsBitfield(9);
    if ( (v59 & 0x80u) != default )
      v109 = v117;
    v60 = v108;
    v4.EffectorLocation.X = v107;
    v61 = v109;
    v4.EffectorLocation.Y = v60;
    v62 = v119;
    v63 = v119 == 0;
    v4.EffectorLocation.Z = v61;
    v4.EffectorLocationSpace = BCS_WorldSpace;
    if ( !v63 && v62[362] == 0.0f && !v112 )
      SetFromBitfield(ref v4.bInvertFootUpAxis, 9, v59 & 0xFFFFFFEF);
    v64 = v4.bInvertFootUpAxis.AsBitfield(9);
    if ( (v64 & 2) == default )
      SetFromBitfield(ref v4.bInvertFootUpAxis, 9, v64 & 0xFFFFFFEF);
    if ( (v4.bInvertFootUpAxis.AsBitfield(9) & 0x10) != default )
    {
      v65 = OutBoneTransforms;
      v4.CalculateNewBoneTransforms(BoneIndex, SkelComp, OutBoneTransforms);
    }
    else
    {
      OutBoneTransforms.Add(3, 64, 8);
      qmemcpy(OutBoneTransforms.Data, (byte *)SkelComp.SpaceBases.Data + v125, sizeof(Matrix));
      qmemcpy(&OutBoneTransforms[1], ref SkelComp.SpaceBases[v126], sizeof(OutBoneTransforms[1]));
      qmemcpy(&OutBoneTransforms[2], (byte *)SkelComp.SpaceBases.Data + LODWORD(Angle), sizeof(OutBoneTransforms[2]));
      v4 = v118;
      v65 = OutBoneTransforms;
    }
    v73 = v65.Data + 2.Mult(&SrcMatrix, v18);
    v74 = v4.bInvertFootUpAxis.AsBitfield(9);
    vecThenRot = v73->WPlane.Vector;
    if ( (v74 & 4) != default && v112 && v106 != 0.0f && sqrt((vecThenRot.X - v107) * (vecThenRot.X - v107) + (vecThenRot.Z - v109) * (vecThenRot.Z - v109) + (vecThenRot.Y - v108) * (vecThenRot.Y - v108)) < 1.0f && (v114 != 0.0f || v115 != 0.0f || v116 != 0.0f) )
    {
      SetFromBitfield(ref v4.bInvertFootUpAxis, 9, v74 | 0x20);
      anglea = v65.Data + 2;
      v75 = FRotationMatrix(&out, ref v4.FootRotOffset);
      v75->Mult(&SrcMatrix, anglea);
      v76 = vecThenRot2.GetAxisDirVector(v4.FootUpAxis, v4.bInvertFootUpAxis.AsBitfield(9) & 1);
      v77 = v76->Z;
      v78 = v76->Y;
      v79 = (float)((float)((float)(SrcMatrix.XPlane.Y * v76->X) + (float)(SrcMatrix.ZPlane.Y * v77)) + (float)(SrcMatrix.YPlane.Y * v78)) + (float)(SrcMatrix.WPlane.Y * 0.0f);
      v80 = (float)((float)((float)(SrcMatrix.XPlane.Z * v76->X) + (float)(SrcMatrix.ZPlane.Z * v77)) + (float)(SrcMatrix.YPlane.Z * v78)) + (float)(SrcMatrix.WPlane.Z * 0.0f);
      a2.X = (float)((float)((float)(SrcMatrix.XPlane.X * v76->X) + (float)(SrcMatrix.ZPlane.X * v77)) + (float)(SrcMatrix.YPlane.X * v78)) + (float)(SrcMatrix.WPlane.X * 0.0f);
      a2.Z = v80;
      v81 = (float)((float)(a2.X * a2.X) + (float)(v80 * v80)) + (float)(v79 * v79);
      a2.Y = v79;
      v111.X = v81;
      if ( v81 == 1.0f )
      {
        v111 = a2;
      }
      else if ( v81 >= SMALL_NUMBER )
      {
        v127.X = 3.0f;
        Angle = 0.5f;
        v82 = 1.0f / fsqrt(v111.X);
        vecThenRot2.X = (float)(3.0f - (float)((float)(v82 * v111.X) * v82)) * (float)(v82 * 0.5f);
        v111.X = vecThenRot2.X * a2.X;
        v111.Y = a2.Y * vecThenRot2.X;
        v111.Z = a2.Z * vecThenRot2.X;
      }
      else
      {
        v111.X = 0.0f;
        v111.Y = 0.0f;
        v111.Z = 0.0f;
      }
      a2 = v111;
      VectorMatrixInverse(v18, &SrcMatrix);
      vecThenRot.X = (float)((float)((float)(SrcMatrix.XPlane.X * v114) + (float)(SrcMatrix.YPlane.X * v115)) + (float)(SrcMatrix.ZPlane.X * v116)) + (float)(SrcMatrix.WPlane.X * 0.0f);
      vecThenRot.Y = (float)((float)((float)(SrcMatrix.XPlane.Y * v114) + (float)(SrcMatrix.YPlane.Y * v115)) + (float)(SrcMatrix.ZPlane.Y * v116)) + (float)(SrcMatrix.WPlane.Y * 0.0f);
      vecThenRot.Z = (float)((float)((float)(SrcMatrix.XPlane.Z * v114) + (float)(SrcMatrix.YPlane.Z * v115)) + (float)(SrcMatrix.ZPlane.Z * v116)) + (float)(SrcMatrix.WPlane.Z * 0.0f);
      FQuatFindBetween(&a1, &a2, &vecThenRot);
      v106 = v4.MaxFootOrientAdjust * 0.017453292f;
      a1.ToAxisAndAngle(&vecThenRot2, &Angle);
      angleb = ::Clamp(Angle, -0.0f - v106, v106);
      a1 = *v127.FQuat_0(vecThenRot2, angleb);
      vecThenRot2.X = 0.0f;
      *(_QWORD *)&vecThenRot2.Y = 0L;
      SrcMatrix.FQuatRotationTranslationMatrix(&a1, &vecThenRot2);
      v83 = v65.Data;
      vecThenRot2 = v65[2].WPlane.Vector;
      v83[2].WPlane.X = 0.0f;
      v83[2].WPlane.Y = 0.0f;
      v83[2].WPlane.Z = 0.0f;
      v84 = v65.Data + 2;
      v85 = v84->Mult(&out, &SrcMatrix);
      v86 = vecThenRot2.X;
      qmemcpy(v84, v85, sizeof(Matrix));
      v4 = v118;
      v87 = OutBoneTransforms.Data + 2;
      v87->WPlane.X = v86;
      *(_QWORD *)&v87->WPlane.Y = *(_QWORD *)&vecThenRot2.Y;
      v65 = OutBoneTransforms;
    }
    if ( (v4.bInvertFootUpAxis.AsBitfield(9) & 0x100) != default )
    {
      v88 = v65.Data + 2.Rotator((Rotator *)&vecThenRot);
      v4.InterpolatedRotation.Pitch = v88->Pitch;
      v4.InterpolatedRotation.Yaw = v88->Yaw;
      v89 = v88->Roll;
      SetFromBitfield(ref v4.bInvertFootUpAxis, 9, v4.bInvertFootUpAxis.AsBitfield(9) & (0xFFFFFEFF));
      v4.InterpolatedRotation.Roll = v89;
    }
    anglec = v4.RotationInterpolationSpeed;
    v98 = GWorld.GetWorldInfo().DeltaSeconds;
    v90 = v65.Data + 2.Rotator((Rotator *)&vecThenRot);
    v4.InterpolatedRotation = *RInterpTo((Rotator *)&vecThenRot2, ref v4.InterpolatedRotation, v90, v98, anglec);
    v91 = v65.Data + 2.Rotator((Rotator *)&vecThenRot).Yaw;
    v92 = v4.bInvertFootUpAxis.AsBitfield(9);
    v4.InterpolatedRotation.Yaw = v91;
    if ( (v92 & 4) != default && (v92 & 0x40) != default && (v92 & 0x20) != default )
    {
      v93 = FRotationMatrix(&out, ref v4.InterpolatedRotation);
      v94 = OutBoneTransforms.Data;
      v95 = OutBoneTransforms[2].WPlane.X;
      v96 = OutBoneTransforms[2].WPlane.Y;
      v97 = OutBoneTransforms[2].WPlane.Z;
      qmemcpy(&SrcMatrix, v93, sizeof(SrcMatrix));
      SrcMatrix.WPlane.X = v95;
      SrcMatrix.WPlane.Y = v96;
      SrcMatrix.WPlane.Z = v97;
      qmemcpy(&v94[2], &SrcMatrix, sizeof(Matrix));
    }
    #endif
  }
}
}
