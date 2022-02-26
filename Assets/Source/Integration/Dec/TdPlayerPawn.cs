namespace MEdge.TdGame{
  using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.Engine.AnimNodeSequence.ERootBoneAxis; using static MEdge.Core.Object.EAxis; using static MEdge.Engine.AnimNodeSequence.ERootRotationOption; using static MEdge.TdGame.TdPawn.EAgainstWallState; using static MEdge.TdGame.TdPawn.EWeaponAnimState; using static MEdge.Engine.SkeletalMeshComponent.ERootMotionMode; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdPlayerPawn
{
  // Same as APawn::NewFallVelocity
  public override unsafe Vector NewFallVelocity(Vector OldVelocity, Vector OldAcceleration, float timeTick)
  {
    Vector returnVal = default;
    // void (__thiscall *GetNetBuoyancy)(TdPlayerPawn , float *, float *); // eax
    Vector *result; // eax
    float v7 = default; // xmm6_4
    float v8 = default; // xmm4_4
    float v9 = default; // xmm5_4
    float NetBuoyancy = default; // [esp+8h] [ebp-8h] BYREF
    float NetFluidFriction = default; // [esp+Ch] [ebp-4h] BYREF
  
    // GetNetBuoyancy = *(void (__thiscall **)(TdPlayerPawn , float *, float *))(this.VfTableObject.Dummy + 520);
    NetBuoyancy = 0.0f;
    NetFluidFriction = 0.0f;
    this.GetNetBuoyancy(ref NetBuoyancy, ref NetFluidFriction);// APawn::GetNetBuoyancy
    //result = returnVal;
    v7 = 1.0f - (float)(NetFluidFriction * timeTick);
    v8 = (float)(OldVelocity.Y * v7) + (float)((float)((float)(1.0f - NetBuoyancy) * OldAcceleration.Y) * timeTick);
    v9 = (float)(OldVelocity.Z * v7) + (float)((float)(OldAcceleration.Z * (float)(1.0f - NetBuoyancy)) * timeTick);
    returnVal.X = (float)(OldVelocity.X * v7) + (float)((float)(OldAcceleration.X * (float)(1.0f - NetBuoyancy)) * timeTick);
    returnVal.Y = v8;
    returnVal.Z = v9;
    return returnVal;
  }

  public override unsafe void SetBase(Actor NewBase, Vector NewFloor, int bNotifyActor = 1, SkeletalMeshComponent SkelComp = null, name AttachName = default)
  {
    if ( (this.bHasMorphNodes.AsBitfield(7) & 32) == default )
      base.SetBase(NewBase, NewFloor, bNotifyActor, SkelComp, AttachName);
  }

  public override unsafe float GetMobilityMultiplier()
  {
    float v1 = default; // xmm0_4
    float v2 = default; // xmm2_4
    double result = default; // st7
  
    v1 = (float)(1.0f - (float)(this.TaserDamageLevel * 0.0099999998d));
    v2 = 0.0f;
    if ( v1 >= 0.0f && ((v2 = 1.0f - (float)(this.TaserDamageLevel * 0.0099999998d))is object && v1 > 1.0f) )
      result = 1.0f;
    else
      result = v2;
    return (float)(result);
  }

  public unsafe void Update1pArms(float DeltaTime)
  {
    MaterialInterface v3; // eax
    MaterialInstanceConstant v4 = default; // edi
    Vector *v5; // ebx
    int v6 = default; // eax
    Matrix *v7; // eax
    Vector *v8; // ebx
    int v9 = default; // eax
    Matrix *v10; // eax
    float v11 = default; // xmm0_4
    name[] v12; // ebx
    Vector *v13; // eax
    name[] v14; // ebx
    Vector *v15; // eax
    name[] v16; // ebx
    Vector *v17; // eax
    name[] v18; // ebx
    Vector *v19; // eax
    int v20 = default; // xmm1_4
    float v21 = default; // xmm0_4
    float v22 = default; // xmm0_4
    Vector *v23; // [esp+9Ch] [ebp-B0h]
    Vector *v24; // [esp+9Ch] [ebp-B0h]
    Vector *v25; // [esp+9Ch] [ebp-B0h]
    float v26 = default; // [esp+9Ch] [ebp-B0h]
    Vector *v27; // [esp+9Ch] [ebp-B0h]
    Vector *v28; // [esp+9Ch] [ebp-B0h]
    float v29 = default; // [esp+A0h] [ebp-ACh]
    float v30 = default; // [esp+A0h] [ebp-ACh]
    float v31 = default; // [esp+A4h] [ebp-A8h]
    float v32 = default; // [esp+A4h] [ebp-A8h]
    Vector *v33; // [esp+A8h] [ebp-A4h]
    float v34 = default; // [esp+A8h] [ebp-A4h]
    float v35 = default; // [esp+ACh] [ebp-A0h]
    float v36 = default; // [esp+B0h] [ebp-9Ch]
    Vector output = default; // [esp+B4h] [ebp-98h] BYREF
    Vector v38 = default; // [esp+C0h] [ebp-8Ch] BYREF
    Matrix SrcMatrix = default; // [esp+CCh] [ebp-80h] BYREF
    Matrix a2 = default; // [esp+10Ch] [ebp-40h] BYREF
  
    if ( this.Mesh )
    {
      v3 = this.Mesh.GetMaterial( 0);// GetMaterial
      v4 = E_TryCastTo<MaterialInstanceConstant>(v3);
      if(v4 != default)
      {
        v5 = this.Mesh.GetBoneAxis(&output, this.BoneNames1p[1], AXIS_Z);
        v6 = this.Mesh.MatchRefBone("RightForeArm"/*_dword_2056794*/);
        v7 = this.Mesh.GetBoneMatrix(&a2, v6);
        VectorMatrixInverse(v7, &SrcMatrix);
        v29 = (float)((float)((float)(SrcMatrix.ZPlane.Y * v5->Z) + (float)(SrcMatrix.YPlane.Y * v5->Y)) + (float)(SrcMatrix.XPlane.Y * v5->X)) + (float)(SrcMatrix.WPlane.Y * 0.0f);
        v8 = this.Mesh.GetBoneAxis(&output, this.BoneNames1p[7], AXIS_Z);
        v9 = this.Mesh.MatchRefBone("LeftForeArm");
        v10 = this.Mesh.GetBoneMatrix(&a2, v9);
        VectorMatrixInverse(v10, &SrcMatrix);
        v11 = (float)((float)(SrcMatrix.XPlane.Y * v8->X) + (float)(SrcMatrix.ZPlane.Y * v8->Z)) + (float)(SrcMatrix.YPlane.Y * v8->Y);
        v12 = this.BoneNames1p.Data;
        v31 = v11 + (float)(SrcMatrix.WPlane.Y * 0.0f);
        v23 = this.Mesh.GetBoneAxis(&output, v12[3], AXIS_Y);
        v13 = this.Mesh.GetBoneAxis(&v38, v12[2], AXIS_Y);
        if ( (float)((float)((float)(v23->Z * v13->Z) + (float)(v23->Y * v13->Y)) + (float)(v13->X * v23->X)) > 0.0f )
          v36 = (float)((float)(v23->Z * v13->Z) + (float)(v23->Y * v13->Y)) + (float)(v13->X * v23->X);
        else
          v36 = 0.0f;
        v14 = this.BoneNames1p.Data;
        v24 = this.Mesh.GetBoneAxis(&v38, v14[5], AXIS_Y);
        v15 = this.Mesh.GetBoneAxis(&output, v14[4], AXIS_Y);
        if ( (float)((float)((float)(v24->Z * v15->Z) + (float)(v24->Y * v15->Y)) + (float)(v15->X * v24->X)) > 0.0f )
          v35 = (float)((float)(v24->Z * v15->Z) + (float)(v24->Y * v15->Y)) + (float)(v15->X * v24->X);
        else
          v35 = 0.0f;
        v16 = this.BoneNames1p.Data;
        v25 = this.Mesh.GetBoneAxis(&v38, v16[9], AXIS_Y);
        v17 = this.Mesh.GetBoneAxis(&output, v16[8], AXIS_Y);
        if ( (float)((float)((float)(v25->Z * v17->Z) + (float)(v25->Y * v17->Y)) + (float)(v25->X * v17->X)) > 0.0f )
          v26 = (float)((float)(v25->Z * v17->Z) + (float)(v25->Y * v17->Y)) + (float)(v25->X * v17->X);
        else
          v26 = 0.0f;
        v18 = this.BoneNames1p.Data;
        v33 = this.Mesh.GetBoneAxis(&v38, v18[11], AXIS_Y);
        v19 = this.Mesh.GetBoneAxis(&output, v18[10], AXIS_Y);
        if ( (float)((float)((float)(v33->Z * v19->Z) + (float)(v33->Y * v19->Y)) + (float)(v33->X * v19->X)) > 0.0f )
          v34 = (float)((float)(v33->Z * v19->Z) + (float)(v33->Y * v19->Y)) + (float)(v33->X * v19->X);
        else
          v34 = 0.0f;
        if ( v29 >= -1.0f )
        {
          if ( v29 >= 1.0f )
            v29 = 1.0f;
        }
        else
        {
          v29 = -1.0f;
        }
        v20 = -1082130432;
        v30 = (float)(asin(v29) * 0.63661975f);
        if ( v31 < -1.0f || ((v20 = 1065353216) is object && v31 >= 1.0f) )
          v31 = *(float *)&v20;
        v32 = (float)(asin(v31) * 0.63661975f);
        v4.SetScalarParameterValue( this.HandNormalMapNames1p[0], v35);// SetScalarParameterValue
        v4.SetScalarParameterValue( this.HandNormalMapNames1p[1], v35);// SetScalarParameterValue
        v4.SetScalarParameterValue( this.HandNormalMapNames1p[2], v35);// SetScalarParameterValue
        v4.SetScalarParameterValue( this.HandNormalMapNames1p[3], v36);// SetScalarParameterValue
        v4.SetScalarParameterValue( this.HandNormalMapNames1p[4], v36);// SetScalarParameterValue
        v4.SetScalarParameterValue( this.HandNormalMapNames1p[5], v34);// SetScalarParameterValue
        v4.SetScalarParameterValue( this.HandNormalMapNames1p[6], v34);// SetScalarParameterValue
        v4.SetScalarParameterValue( this.HandNormalMapNames1p[7], v34);// SetScalarParameterValue
        v4.SetScalarParameterValue( this.HandNormalMapNames1p[8], v26);// SetScalarParameterValue
        v4.SetScalarParameterValue( this.HandNormalMapNames1p[9], v26);// SetScalarParameterValue
        if ( (this.bHasMorphNodes.AsBitfield(7) & 1) != default )
        {
          if ( v30 > 0.0f )
            v27 = (Vector*)(&v30);
          else
            v27 = default;
          this.MorphNodeWeight1p.Data[0].SetNodeWeight(v27->X);// SetNodeWeight
          v21 = v30;
          if ( v30 >= 0.0f )
            v21 = 0.0f;
          this.MorphNodeWeight1p.Data[1].SetNodeWeight(v21 * -1.0f);// UMorphNodeWeight::SetNodeWeight
          if ( v32 > 0.0f )
            v28 = (Vector*)(&v32);
          else
            v28 = default;
          this.MorphNodeWeight1p.Data[2].SetNodeWeight(v28->X);// UMorphNodeWeight::SetNodeWeight
          v22 = v32;
          if ( v32 >= 0.0f )
            v22 = 0.0f;
          this.MorphNodeWeight1p.Data[3].SetNodeWeight(v22 * -1.0f);// UMorphNodeWeight::SetNodeWeight
        }
      }
    }
  }

  public unsafe EAgainstWallState CheckAgainstWall()
  {
    EWeaponType v2 = default; // bl
    float v3 = default; // eax
    float v4 = default; // ecx
    float v5 = default; // edx
    float v6 = default; // xmm7_4
    float v7 = default; // xmm4_4
    float v8 = default; // xmm0_4
    EMovement v9 = default; // al
    float v10 = default; // xmm0_4
    float v11 = default; // xmm4_4
    float v12 = default; // xmm0_4
    float v13 = default; // xmm2_4
    float v14 = default; // xmm3_4
    float v15 = default; // xmm7_4
    float v16 = default; // xmm4_4
    int v17 = default; // edi
    int v18 = default; // ebp
    bool v19 = default; // zf
    Class v20 = default; // eax
    float v21 = default; // xmm4_4
    float v22 = default; // xmm5_4
    float v23 = default; // xmm7_4
    float v24 = default; // ecx
    float v25 = default; // edx
    //Rotator *v26; // ecx
    Vector *v27; // eax
    float v28 = default; // xmm3_4
    float v29 = default; // xmm1_4
    float v30 = default; // xmm2_4
    float v31 = default; // xmm3_4
    float v32 = default; // xmm0_4
    float v33 = default; // xmm6_4
    float v34 = default; // xmm3_4
    float v35 = default; // xmm0_4
    float v36 = default; // xmm1_4
    int v37 = default; // ecx
    TdMove[] v38; // edx
    Class v39 = default; // eax
    float v40 = default; // ecx
    float v41 = default; // edx
    //Rotator *v42; // ecx
    Vector *v43; // eax
    float v44 = default; // xmm3_4
    float v45 = default; // xmm1_4
    float v46 = default; // xmm2_4
    float v47 = default; // xmm4_4
    float v48 = default; // xmm0_4
    float v49 = default; // xmm2_4
    float v50 = default; // edx
    float v51 = default; // eax
    TdWeapon v53 = default; // esi
    TdWeapon v54 = default; // esi
    Vector a4 = default; // [esp+8h] [ebp-B0h] BYREF
    Vector v56 = default; // [esp+14h] [ebp-A4h]
    Vector a2 = default; // [esp+24h] [ebp-94h] BYREF
    Vector v58 = default; // [esp+30h] [ebp-88h] BYREF
    float v59 = default; // [esp+40h] [ebp-78h]
    Vector a3 = default; // [esp+44h] [ebp-74h] BYREF
    Vector a5 = default; // [esp+50h] [ebp-68h] BYREF
    CheckResult v62 = default; // [esp+5Ch] [ebp-5Ch] BYREF
    int v63 = default; // [esp+A4h] [ebp-14h]
    float v64 = default; // [esp+A8h] [ebp-10h]
  
    if ( this.WeaponAnimState == WS_Reload )
      return 0;
    v2 = EWT_None;
    if ( this.Health <= 0 )
      return 0;
    a5.X = 2.0f;
    a5.Y = 2.0f;
    a5.Z = 5.0f;
    this.Rotation.Vector(&a2);
    v3 = this.Location.Z;
    v4 = this.Location.X;
    v5 = this.Location.Y;
    v6 = this.Velocity.Z;
    v56.Y = (float)(a2.Z * 0.0f) - (float)(a2.X * -1.0f);
    v7 = this.Velocity.X;
    v8 = this.Velocity.Y;
    a4.Z = v3;
    v9 = this.MovementState;
    v10 = (float)((float)((float)((float)(v8 * a2.Y) + (float)(v6 * a2.Z)) + (float)(v7 * a2.X)) * 0.69999999d);
    v56.X = (float)(a2.Y * -1.0f) - (float)(a2.Z * 0.0f);
    v56.Z = (float)(a2.X * 0.0f) - (float)(a2.Y * 0.0f);
    a4.X = v4;
    a4.Y = v5;
    if ( v9 == MOVE_Crouch )
      v11 = a4.Z + 26.0f;
    else
      v11 = a4.Z + 68.0f;
    v12 = (float)(v10 * 0.40000001d);
    v13 = (float)((float)((float)(a2.Y * -1.0f) - (float)(a2.Z * 0.0f)) * 14.0f) + a4.X;
    v14 = (float)((float)((float)(a2.X * 0.0f) - (float)(a2.Y * 0.0f)) * 14.0f) + v11;
    v15 = a4.Y + (float)(v56.Y * 14.0f);
    v16 = 40.0f;
    a4.X = v13;
    a4.Y = v15;
    a4.Z = v14;
    v59 = v12;
    if ( v12 > 40.0f )
      v16 = v12;
    v17 = default;
    v18 = default;
    v19 = this.Controller == null;
    a3.X = (float)(a2.X * v16) + v13;
    a3.Y = (float)(a2.Y * v16) + v15;
    a3.Z = (float)(a2.Z * v16) + v14;
    v62.Next = default;
    v62.Actor = default;
    v62.Location.X = 0.0f;
    v62.Location.Y = 0.0f;
    v62.Location.Z = 0.0f;
    v62.Normal.X = 0.0f;
    v62.Normal.Y = 0.0f;
    v62.Normal.Z = 0.0f;
    v62.Time = 0.0f;
    v62.Item = -1;
    v62.Material = default;
    v62.PhysMaterial = default;
    v62.Component = default;
    v62.BoneName = default;
    v62.Level = default;
    v62.LevelIndex = -1;
    v62.bStartPenetrating = default;
    v63 = default;
    if(v19 != default)
      return 0;
    if ( this.Moves[v9].MovementLineCheck(ref v62, &a3, &a4, &a5, 8902) )
    {
      if ( !v62.Actor || v62.Actor is BlockingVolume == false )
      {
        v21 = a2.Y;
        v22 = a2.Z;
        v23 = a2.X;
        if ( (float)((float)((float)(v62.Normal.Y * a2.Y) + (float)(v62.Normal.Z * a2.Z)) + (float)(v62.Normal.X * a2.X)) >= -0.5f )
          goto LABEL_17;
        v24 = v62.Location.Y;
        v25 = v62.Location.Z;
        this.AgainstWallRightHand.X = v62.Location.X;
        this.AgainstWallRightHand.Y = v24;
        ref var v26 = ref this.Controller.Rotation;
        v18 = 1;
        this.AgainstWallRightHand.Z = v25;
        v27 = v26.Vector(&v58);
        v28 = 0.0f;
        if ( (float)((float)((float)(v27->Y + v27->X) * 0.0f) + v27->Z) < 0.0f )
          v28 = (float)((float)(v27->Y + v27->X) * 0.0f) + v27->Z;
        v29 = (float)(v56.Y * v28) * 15.0f;
        v30 = (float)(v56.Z * v28) * 15.0f;
        v31 = this.AgainstWallRightHand.X - (float)((float)(v28 * v56.X) * 15.0f);
        this.AgainstWallRightHand.Y = this.AgainstWallRightHand.Y - v29;
        v32 = this.AgainstWallRightHand.Z - v30;
        this.AgainstWallRightHand.X = v31;
        this.AgainstWallRightHand.Z = v32;
      }
    }
    v23 = a2.X;
    v21 = a2.Y;
    v22 = a2.Z;
  LABEL_17:
    v33 = 40.0f;
    v34 = a4.X - (float)(v56.X * 28.0f);
    v35 = a4.Y - (float)(v56.Y * 28.0f);
    v36 = a4.Z - (float)(v56.Z * 28.0f);
    a4.X = v34;
    a4.Y = v35;
    a4.Z = v36;
    if ( v59 > 40.0f )
      v33 = v59;
    v58.X = (float)(v23 * v33) + v34;
    a3.X = v58.X;
    v37 = (int)this.MovementState;
    v58.Y = (float)(v21 * v33) + v35;
    a3.Y = v58.Y;
    v38 = this.Moves.Data;
    v58.Z = (float)(v22 * v33) + v36;
    a3.Z = v58.Z;
    if ( !v38[v37].MovementLineCheck(ref v62, &a3, &a4, &a5, 8902)
      || v62.Actor && (v62.Actor is BlockingVolume)
      || (float)((float)((float)(v62.Normal.Y * a2.Y) + (float)(v62.Normal.Z * a2.Z)) + (float)(v62.Normal.X * a2.X)) >= -0.5f )
    {
      if ( v18 == default )
        return 0;
    }
    else
    {
      v40 = v62.Location.Y;
      v41 = v62.Location.Z;
      this.AgainstWallLeftHand.X = v62.Location.X;
      this.AgainstWallLeftHand.Y = v40;
      ref var v42 = ref this.Controller.Rotation;
      v17 = 1;
      this.AgainstWallLeftHand.Z = v41;
      v43 = v42.Vector(&v58);
      v44 = (float)((float)(v43->Y + v43->X) * 0.0f) + v43->Z;
      if ( v44 >= 0.0f )
        v44 = 0.0f;
      v45 = (float)((float)(v56.Y * v44) * 15.0f) + this.AgainstWallLeftHand.Y;
      v46 = (float)((float)(v56.Z * v44) * 15.0f) + this.AgainstWallLeftHand.Z;
      this.AgainstWallLeftHand.X = (float)((float)(v44 * v56.X) * 15.0f) + this.AgainstWallLeftHand.X;
      this.AgainstWallLeftHand.Y = v45;
      this.AgainstWallLeftHand.Z = v46;
    }
    v47 = v62.Location.Z + 0.1f;
    v48 = (float)((float)(v47 * v47) + (float)(v62.Location.Y * v62.Location.Y)) + (float)(v62.Location.X * v62.Location.X);
    v58.X = v62.Location.X;
    v58.Y = v62.Location.Y;
    v58.Z = v62.Location.Z + 0.1f;
    v64 = v48;
    if ( v48 == 1.0f )
    {
      v56 = v58;
    }
    else if ( v48 >= SMALL_NUMBER )
    {
      v59 = 0.5f;
      v49 = 1.0f / fsqrt(v64);
      v58.X = (float)(3.0f - (float)((float)(v49 * v64) * v49)) * (float)(v49 * 0.5f);
      v56.X = v58.X * v62.Location.X;
      v56.Y = v62.Location.Y * v58.X;
      v56.Z = v47 * v58.X;
    }
    else
    {
      v56.X = 0.0f;
      v56.Y = 0.0f;
      v56.Z = 0.0f;
    }
    v50 = v56.Y;
    v51 = v56.Z;
    this.AgainstWallNormal.X = v56.X;
    this.AgainstWallNormal.Y = v50;
    this.AgainstWallNormal.Z = v51;
    if(v17 != default)
    {
      if(v18 != default)
        return (EAgainstWallState)1;
      v53 = this.MyWeapon;
      if(v53 != default)
        v2 = v53.WeaponType;
      return (EAgainstWallState)((v2 != EWT_Heavy ? 1 : 0) + 1);
    }
    if ( !(v18 != default) )
      return 0;
    v54 = this.MyWeapon;
    if(v54 != default)
      v2 = v54.WeaponType;
    return (EAgainstWallState)(2 * (v2 != EWT_Heavy ? 1 : 0) + 1);
  }

  public unsafe bool ComplexEgdeCheck_Maybe(Vector *a2, float a3, float a4, float a5, ref int a6, ref Vector a7)
  {
    float v7 = default; // xmm6_4
    float v8 = default; // xmm7_4
    float v9 = default; // xmm5_4
    float v10 = default; // xmm0_4
    float v12 = default; // xmm0_4
    float v13 = default; // xmm1_4
    float v14 = default; // xmm2_4
    float v15 = default; // xmm0_4
    float v16 = default; // xmm1_4
    float v17 = default; // xmm2_4
    float v18 = default; // xmm3_4
    float v19 = default; // xmm4_4
    int v20 = default; // ecx
    bool v21 = default; // eax
    float v22 = default; // xmm6_4
    float v23 = default; // xmm5_4
    float v24 = default; // xmm0_4
    float v25 = default; // xmm1_4
    float v26 = default; // xmm6_4
    float v27 = default; // xmm2_4
    CheckResult *v28; // ecx
    double v29 = default; // st6
    double v30 = default; // st5
    double v31 = default; // st7
    double v32 = default; // st5
    double v33 = default; // st4
    double v34 = default; // st6
    float v35 = default; // xmm6_4
    float v36 = default; // xmm5_4
    float v37 = default; // xmm0_4
    float v38 = default; // edx
    float v39 = default; // eax
    float v40 = default; // xmm7_4
    float v41 = default; // xmm2_4
    float v42 = default; // xmm0_4
    float v43 = default; // xmm2_4
    float v44 = default; // xmm0_4
    float v45 = default; // xmm0_4
    double v46 = default; // st6
    double v47 = default; // st7
    double v48 = default; // st6
    float v49 = default; // xmm0_4
    float v50 = default; // xmm0_4
    double v51 = default; // st7
    CheckResult *v53; // ecx
    float v54 = default; // xmm3_4
    float v55 = default; // xmm2_4
    float v56 = default; // xmm0_4
    float v57 = default; // edx
    float v58 = default; // eax
    float v59 = default; // xmm5_4
    float v60 = default; // xmm0_4
    double v61 = default; // st7
    double v62 = default; // st6
    float v63 = default; // xmm0_4
    float v64 = default; // xmm0_4
    double v65 = default; // st7
    Vector v66 = default; // [esp+0h] [ebp-F8h] BYREF
    float v67 = default; // [esp+10h] [ebp-E8h]
    float v68 = default; // [esp+14h] [ebp-E4h]
    Vector v69 = default; // [esp+18h] [ebp-E0h] BYREF
    float v70 = default; // [esp+28h] [ebp-D0h]
    float v71 = default; // [esp+2Ch] [ebp-CCh]
    float v72 = default; // [esp+30h] [ebp-C8h]
    float v73 = default; // [esp+34h] [ebp-C4h]
    Vector v74 = default; // [esp+38h] [ebp-C0h] BYREF
    float v75 = default; // [esp+48h] [ebp-B0h]
    float v76 = default; // [esp+4Ch] [ebp-ACh]
    CheckResult v77 = default; // [esp+50h] [ebp-A8h] BYREF
    int v78 = default; // [esp+98h] [ebp-60h]
    CheckResult v79 = default; // [esp+9Ch] [ebp-5Ch] BYREF
    int v80 = default; // [esp+E4h] [ebp-14h]
    float v81 = default; // [esp+E8h] [ebp-10h]
  
    v7 = a2->X;
    v8 = a2->Y;
    v9 = a2->Z - 4.0f;
    v10 = (float)((float)(a5 * a5) + (float)(a4 * a4)) + (float)(a3 * a3);
    v67 = a3 * a3;
    v73 = a4 * a4;
    v69.X = v10;
    if ( v10 == 1.0f )
    {
      v66.X = a3;
      v12 = a3;
      v66.Y = a4;
      v13 = a4;
      v66.Z = a5;
      v14 = a5;
    }
    else if ( v10 >= SMALL_NUMBER )
    {
      v66.X = 3.0f;
      v68 = 0.5f;
      v15 = fsqrt(v69.X);
      v74.X = (float)(3.0f - (float)((float)((float)(1.0f / v15) * v69.X) * (float)(1.0f / v15))) * (float)((float)(1.0f / v15) * 0.5f);
      v12 = v74.X * a3;
      v13 = a4 * v74.X;
      v14 = a5 * v74.X;
    }
    else
    {
      v12 = 0.0f;
      v13 = 0.0f;
      v14 = 0.0f;
    }
    v16 = (float)(v13 * 10.0f) + a4;
    v17 = (float)(v14 * 10.0f) + a5;
    v18 = (float)(v12 * 10.0f) + a3;
    v79.Time = 1.0f;
    v77.Time = 1.0f;
    v76 = v18 + v7;
    v69.X = v18 + v7;
    v75 = v16 + v8;
    v69.Y = v16 + v8;
    v79.Item = -1;
    v79.LevelIndex = -1;
    v77.Item = -1;
    v77.LevelIndex = -1;
    v79.Next = default;
    v79.Actor = default;
    v79.Location.X = 0.0f;
    v79.Location.Y = 0.0f;
    v79.Location.Z = 0.0f;
    v79.Normal.X = 0.0f;
    v79.Normal.Y = 0.0f;
    v79.Normal.Z = 0.0f;
    v79.Material = default;
    v79.PhysMaterial = default;
    v79.Component = default;
    v79.BoneName = default;
    v79.Level = default;
    v79.bStartPenetrating = default;
    v80 = default;
    v77.Next = default;
    v77.Actor = default;
    v77.Location.X = 0.0f;
    v77.Location.Y = 0.0f;
    v77.Location.Z = 0.0f;
    v77.Normal.X = 0.0f;
    v77.Normal.Y = 0.0f;
    v77.Normal.Z = 0.0f;
    v77.Material = default;
    v77.PhysMaterial = default;
    v77.Component = default;
    v77.BoneName = default;
    v77.Level = default;
    v77.bStartPenetrating = default;
    v78 = default;
    v66.X = 0.0f;
    v66.Y = 0.0f;
    v66.Z = 0.0f;
    v71 = v17 + v9;
    v69.Z = v17 + v9;
    v68 = v7 - v18;
    v74.X = v7 - v18;
    v72 = v8 - v16;
    v74.Y = v8 - v16;
    v70 = v9 - v17;
    v74.Z = v9 - v17;
    GWorld.SingleLineCheck(ref v79, this, v74, v69, 8415, v66, 0);
    v74.X = 0.0f;
    v74.Y = 0.0f;
    v74.Z = 0.0f;
    v66.X = v68;
    v66.Y = v72;
    v66.Z = v70;
    v69.X = v76;
    v69.Y = v75;
    v69.Z = v71;
    GWorld.SingleLineCheck(ref v77, this, v69, v66, 8415, v74, 0);
    if ( v79.Time >= 1.0f || this.WalkableFloorZ <= v79.Normal.Z )
    {
      v19 = 0.0f;
      v20 = default;
      goto LABEL_12;
    }
    v19 = 0.0f;
    if ( v79.Time <= 0.0f )
    {
  LABEL_11:
      v20 = default;
      goto LABEL_12;
    }
    v20 = 1;
  LABEL_12:
    v21 = v77.Time < 1.0f && this.WalkableFloorZ > v77.Normal.Z && v77.Time > 0.0f;
    if(v20 != default)
    {
      if ( v21 && (float)((float)((float)(v79.Normal.X * v77.Normal.X) + (float)(v79.Normal.Y * v77.Normal.Y)) + (float)(v77.Normal.Z * v79.Normal.Z)) < 0.0f )
      {
        v22 = v79.Normal.X - v77.Normal.X;
        v23 = v79.Normal.Y - v77.Normal.Y;
        v24 = (float)(v22 * v22) + (float)(v23 * v23);
        v66.X = v79.Normal.X - v77.Normal.X;
        v66.Y = v79.Normal.Y - v77.Normal.Y;
        v66.Z = v79.Normal.Z - v77.Normal.Z;
        v69.X = v24;
        if ( v24 == 1.0f )
        {
          if ( (float)(v79.Normal.Z - v77.Normal.Z) == 0.0f )
          {
            v69 = v66;
            v25 = v66.X;
            v23 = v66.Y;
            v26 = v66.Z;
            goto LABEL_28;
          }
          v25 = v79.Normal.X - v77.Normal.X;
        }
        else if ( v24 >= SMALL_NUMBER )
        {
          v66.X = 3.0f;
          v71 = 0.5f;
          v27 = 1.0f / fsqrt(v69.X);
          v74.X = (float)(3.0f - (float)((float)(v27 * v69.X) * v27)) * (float)(v27 * 0.5f);
          v25 = v74.X * v22;
          v23 = v23 * v74.X;
        }
        else
        {
          v25 = 0.0f;
          v23 = 0.0f;
        }
        v26 = 0.0f;
  LABEL_28:
        if ( (float)((float)((float)((float)(v79.Location.X - v77.Location.X) * v25) + (float)((float)(v79.Location.Z - v77.Location.Z) * v26)) + (float)((float)(v79.Location.Y - v77.Location.Y) * v23)) < 20.0f )
        {
          v28 = &v79;
          v29 = this.Location.Y - v79.Location.Y;
          v30 = this.Location.X - v79.Location.X;
          v31 = sqrt(v30 * v30 + v29 * v29);
          v76 = (float)v31;
          v32 = this.Location.Y - v77.Location.Y;
          v33 = this.Location.X - v77.Location.X;
          v34 = sqrt(v33 * v33 + v32 * v32);
          v75 = (float)v34;
          if ( v34 <= v31 )
            v28 = &v77;
          v35 = v28->Normal.Y;
          v36 = v28->Normal.X;
          v37 = (float)(v36 * v36) + (float)(v35 * v35);
          v69.X = v37;
          if ( v37 == 1.0f )
          {
            if ( v28->Normal.Z == 0.0f )
            {
              v38 = v28->Normal.Y;
              v69.X = v28->Normal.X;
              v39 = v28->Normal.Z;
              v36 = v69.X;
              v69.Y = v38;
              v35 = v38;
              v69.Z = v39;
              v40 = v39;
              goto LABEL_38;
            }
          }
          else if ( v37 >= SMALL_NUMBER )
          {
            v66.X = 3.0f;
            v71 = 0.5f;
            v41 = 1.0f / fsqrt(v69.X);
            v74.X = (float)(3.0f - (float)((float)(v41 * v69.X) * v41)) * (float)(v41 * 0.5f);
            v36 = v74.X * v28->Normal.X;
            v35 = v74.X * v28->Normal.Y;
          }
          else
          {
            v36 = 0.0f;
            v35 = 0.0f;
          }
          v40 = 0.0f;
          v69.X = v36;
          v69.Y = v35;
          v69.Z = 0.0f;
  LABEL_38:
          v81 = v73 + v67;
          if ( (float)(v73 + v67) == 1.0f )
          {
            if ( a5 == 0.0f )
            {
              v66.X = a3;
              v66.Y = a4;
              v66.Z = 0.0f;
              goto LABEL_47;
            }
            v66.X = a3;
            v42 = a4;
          }
          else
          {
            if ( (float)(v73 + v67) < SMALL_NUMBER )
            {
              v66.X = 0.0f;
              v66.Y = 0.0f;
  LABEL_46:
              v66.Z = 0.0f;
              goto LABEL_47;
            }
            v67 = 0.5f;
            v43 = 1.0f / fsqrt(v81);
            v74.X = (float)(3.0f - (float)((float)(v43 * v81) * v43)) * (float)(v43 * 0.5f);
            v66.X = v74.X * a3;
            v42 = a4 * v74.X;
          }
          v66.Y = v42;
          v66.Z = 0.0f;
          goto LABEL_47;
        }
        return false;
      }
      v53 = &v79;
    }
    else
    {
      if ( !v21 )
        return false;
      v53 = &v77;
    }
    v54 = v53->Normal.Y;
    v55 = v53->Normal.X;
    v56 = (float)(v55 * v55) + (float)(v54 * v54);
    v66.X = v56;
    if ( v56 == 1.0f )
    {
      if ( v53->Normal.Z == 0.0f )
      {
        v57 = v53->Normal.Y;
        v66.X = v53->Normal.X;
        v58 = v53->Normal.Z;
        v55 = v66.X;
        v66.Y = v57;
        v54 = v57;
        v66.Z = v58;
        v59 = v58;
        goto LABEL_72;
      }
    }
    else if ( v56 >= SMALL_NUMBER )
    {
      v81 = 3.0f;
      v67 = 0.5f;
      v60 = fsqrt(v66.X);
      v74.X = (float)(3.0f - (float)((float)((float)(1.0f / v60) * v66.X) * (float)(1.0f / v60))) * (float)((float)(1.0f / v60) * 0.5f);
      v55 = v53->Normal.X * v74.X;
      v54 = v53->Normal.Y * v74.X;
    }
    else
    {
      v55 = 0.0f;
      v54 = 0.0f;
    }
    v66.X = v55;
    v66.Y = v54;
    v59 = 0.0f;
  LABEL_72:
    v71 = -0.0f - (float)((float)((float)((float)(v53->Location.Y - this.Location.Y) * v54) + (float)((float)(v53->Location.X - this.Location.X) * v55)) + (float)(v59 * 0.0f));
    if ( v71 <= 10.0f )
      return false;
    v61 = fabs(v66.Y);
    v73 = (float)v61;
    v62 = fabs(v66.X);
    v67 = (float)v62;
    if ( v62 < v61 )
      v63 = v73;
    else
      v63 = v67;
    v72 = v63;
    v64 = v63 * v63;
    if ( v64 < 1.0f )
      v68 = v64;
    else
      v68 = 1.0f;
    v65 = (sqrt(1.0f - v68) * v72 * 0.82842702d + 1.0f) * this.CylinderComponent.CollisionRadius + 2.0f - v71;
    v67 = (float)v65;
    if ( v65 > 0.0f )
      v19 = v67;
    v66.X = v55 * v19;
    a7.X = v55 * v19;
    v66.Y = v54 * v19;
    a7.Y = v54 * v19;
    v66.Z = v59 * v19;
    a7.Z = v59 * v19;
    a6 = 1;
    return true;
    
    
    LABEL_47:
    if ( v75 < v76 )
      v70 = v75;
    else
      v70 = v76;
    v44 = (float)((float)((float)(v28->Location.Y - this.Location.Y) * v35) + (float)((float)(v28->Location.X - this.Location.X) * v36)) + (float)((float)(v28->Location.Z - this.Location.Z) * v40);
    v70 = (float)(fabs(v66.X * v70 * v69.X + v66.Y * v70 * v69.Y + v70 * v66.Z * v69.Z));
    if ( v44 <= 0.0f )
      v45 = 1.0f;
    else
      v45 = -1.0f;
    v46 = fabs(v69.Y);
    v73 = (float)v46;
    v70 = v45 * v70;
    v47 = v46;
    v48 = fabs(v69.X);
    v67 = (float)v48;
    if ( v48 < v47 )
      v49 = v73;
    else
      v49 = v67;
    v68 = v49;
    v50 = v49 * v49;
    if ( v50 < 1.0f )
      v72 = v50;
    else
      v72 = 1.0f;
    v51 = (sqrt(1.0f - v72) * v68 * 0.82842702d + 1.0f) * this.CylinderComponent.CollisionRadius + 2.0f - v70;
    v67 = (float)v51;
    if ( v51 > 0.0f )
      v19 = v67;
    v66.X = v36 * v19;
    a7.X = v36 * v19;
    v66.Y = v35 * v19;
    a7.Y = v35 * v19;
    v66.Z = v40 * v19;
    a7.Z = v40 * v19;
    a6 = 2;
    return true;
  }



  public unsafe bool CheckValidFloor( Vector a1, Vector a5, bool a8 ) => CheckValidFloor(a1, a5, a8 ? 1 : 0);
  public unsafe bool CheckValidFloor(Vector a1, Vector a5, int a8)
  {
    float v5 = default; // xmm0_4
    float v6 = default; // xmm0_4
    Vector *v7; // eax
    float v8 = default; // xmm0_4
    float v9 = default; // edx
    double v10 = default; // st7
    float v11 = default; // edx
    double v12 = default; // st6
    float v13 = default; // xmm0_4
    float v14 = default; // xmm5_4
    float v15 = default; // xmm1_4
    float v16 = default; // xmm0_4
    float v17 = default; // xmm4_4
    float v18 = default; // xmm7_4
    float v19 = default; // xmm3_4
    float v20 = default; // xmm0_4
    float v21 = default; // xmm2_4
    float v22 = default; // xmm0_4
    float v23 = default; // xmm7_4
    float v24 = default; // xmm0_4
    float v25 = default; // xmm3_4
    float v26 = default; // xmm1_4
    float v27 = default; // xmm2_4
    float v28 = default; // xmm4_4
    float v29 = default; // xmm0_4
    float v30 = default; // xmm0_4
    float v31 = default; // xmm4_4
    float v32 = default; // xmm6_4
    float v33 = default; // xmm2_4
    CylinderComponent v34 = default; // eax
    float v35 = default; // xmm0_4
    float v36 = default; // xmm4_4
    float v37 = default; // xmm0_4
    float v38 = default; // xmm0_4
    float v39 = default; // xmm0_4
    double v40 = default; // st7
    double v41 = default; // st6
    // void (__thiscall *v42)(TdPlayerPawn , _DWORD, _DWORD, _DWORD, int); // edx
    Vector v44 = default; // [esp+0h] [ebp-C4h] BYREF
    float v45 = default; // [esp+10h] [ebp-B4h]
    float v46 = default; // [esp+14h] [ebp-B0h]
    float v47 = default; // [esp+18h] [ebp-ACh]
    Vector a2 = default; // [esp+1Ch] [ebp-A8h] BYREF
    Vector a7 = default; // [esp+2Ch] [ebp-98h] BYREF
    Vector v50 = default; // [esp+38h] [ebp-8Ch] BYREF
    Vector v51 = default; // [esp+48h] [ebp-7Ch]
    Vector a5a = default; // [esp+58h] [ebp-6Ch] BYREF
    float a6 = default; // [esp+64h] [ebp-60h] BYREF
    float v54 = default; // [esp+68h] [ebp-5Ch]
    CheckResult Hit = default; // [esp+78h] [ebp-4Ch] BYREF
    int v56 = default; // [esp+C0h] [ebp-4h]

    var Actor = this;
    v5 = Actor.CylinderComponent.CollisionHeight;
    a5a.X = Actor.Location.X;
    a5a.Y = Actor.Location.Y;
    a5a.Z = Actor.Location.Z - v5;
    v6 = (float)(a1.Y * a1.Y) + (float)(a1.X * a1.X);
    if ( v6 <= 0.0f )
    {
      v7 = Actor.Rotation.Vector(&a2);
    }
    else
    {
      v44.X = (float)(a1.Y * a1.Y) + (float)(a1.X * a1.X);
      if ( v6 == 1.0f )
      {
        if ( a1.Z == 0.0f )
        {
          v44.Z = 0.0f;
          v44.X = a1.X;
          v44.Y = a1.Y;
        }
        else
        {
          v44.X = a1.X;
          v44.Y = a1.Y;
          v44.Z = 0.0f;
        }
        v7 = &v44;
      }
      else
      {
        if ( v6 >= SMALL_NUMBER )
        {
          v50.X = 3.0f;
          v46 = 0.5f;
          v8 = fsqrt(v44.X);
          v51.X = (float)(3.0f - (float)((float)((float)(1.0f / v8) * v44.X) * (float)(1.0f / v8))) * (float)((float)(1.0f / v8) * 0.5f);
          v44.X = v51.X * a1.X;
          v44.Y = a1.Y * v51.X;
        }
        else
        {
          v44.X = 0.0f;
          v44.Y = 0.0f;
        }
        v44.Z = 0.0f;
        v7 = &v44;
      }
    }
    v9 = v7->X;
    v50.Y = v7->Y;
    v10 = fabs(v50.Y);
    v50.X = v9;
    v11 = v7->Z;
    v45 = (float)v10;
    v50.Z = v11;
    v12 = fabs(v50.X);
    v46 = (float)v12;
    if ( v12 < v10 )
      v13 = v45;
    else
      v13 = v46;
    v14 = a5.Y;
    v15 = v50.Z;
    v45 = v13;
    v16 = (float)((float)(a5.Y * v50.Y) + (float)(a5.X * v50.X)) + (float)(a5.Z * v50.Z);
    v17 = -0.0f - v50.X;
    v47 = a5.Z * v50.Z;
    v18 = v50.Y - (float)(a5.Y * v16);
    v51.X = v50.X - (float)(v16 * a5.X);
    v19 = v50.Z - (float)(v16 * a5.Z);
    v20 = (float)((float)(v51.X * v51.X) + (float)(v19 * v19)) + (float)(v18 * v18);
    v51.Y = v18;
    v51.Z = v19;
    v54 = v20;
    if ( v20 == 1.0f )
    {
      v44 = v51;
      v21 = v51.X;
    }
    else if ( v20 >= SMALL_NUMBER )
    {
      v44.X = 3.0f;
      v46 = 0.5f;
      v22 = fsqrt(v54);
      a2.X = (float)(3.0f - (float)((float)((float)(1.0f / v22) * v54) * (float)(1.0f / v22))) * (float)((float)(1.0f / v22) * 0.5f);
      v21 = a2.X * v51.X;
      v15 = v50.Z;
      v44.Y = v18 * a2.X;
      v44.Z = v51.Z * a2.X;
    }
    else
    {
      v21 = 0.0f;
      v44.Y = 0.0f;
      v44.Z = 0.0f;
    }
    v23 = 1.0f / v45;
    a2.X = (float)(1.0f / v45) * v21;
    a2.Y = v44.Y * (float)(1.0f / v45);
    a2.Z = v44.Z * (float)(1.0f / v45);
    v24 = (float)((float)(a5.X * v50.Y) + (float)(a5.Y * v17)) + v47;
    v25 = a5.Y * v24;
    v26 = v15 - (float)(v24 * a5.Z);
    v27 = v50.Y - (float)(a5.X * v24);
    v28 = v17 - (float)(a5.Y * v24);
    v29 = (float)((float)(v27 * v27) + (float)(v26 * v26)) + (float)(v28 * v28);
    v50.Y = v25;
    v51.X = v27;
    v51.Y = v28;
    v51.Z = v26;
    v44.X = v29;
    if ( v29 == 1.0f )
    {
      v50 = v51;
      v30 = v51.X;
      v31 = v51.Y;
      v32 = v51.Z;
    }
    else if ( v29 >= SMALL_NUMBER )
    {
      v54 = 3.0f;
      v47 = 0.5f;
      v33 = 1.0f / fsqrt(v44.X);
      v50.X = (float)(3.0f - (float)((float)(v33 * v44.X) * v33)) * (float)(v33 * 0.5f);
      v30 = v50.X * v51.X;
      v31 = v28 * v50.X;
      v32 = v26 * v50.X;
    }
    else
    {
      v30 = 0.0f;
      v31 = 0.0f;
      v32 = 0.0f;
    }
    v34 = Actor.CylinderComponent;
    v50.X = v23 * v30;
    v35 = (float)(a5.X * a5.X) + (float)(a5.Y * a5.Y);
    v50.Y = v31 * v23;
    v36 = v34.CollisionRadius;
    v50.Z = v32 * v23;
    v46 = v36;
    a6 = v35;
    v44.X = v35;
    if ( v35 != 1.0f )
    {
      if ( v35 < SMALL_NUMBER )
        goto LABEL_34;
      v54 = 3.0f;
      v47 = 0.5f;
      v38 = fsqrt(v44.X);
      v51.X = (float)(3.0f - (float)((float)((float)(1.0f / v38) * v44.X) * (float)(1.0f / v38))) * (float)((float)(1.0f / v38) * 0.5f);
      v37 = v51.X * a5.X;
      v14 = a5.Y * v51.X;
      v44.Y = v14;
      v44.X = v37;
      goto LABEL_32;
    }
    if ( a5.Z != 0.0f )
    {
      v37 = a5.X;
  LABEL_31:
      v44.Y = v14;
      v44.X = v37;
      goto LABEL_32;
    }
    v44.X = a5.X;
    v37 = a5.X;
    v44.Z = 0.0f;
    v44.Y = a5.Y;
  LABEL_32:
    if ( v37 != 0.0f || v44.Y != 0.0f )
    {
      v40 = fabs(v44.Y);
      v45 = (float)v40;
      v41 = fabs(v44.X);
      v47 = (float)v41;
      if ( v41 < v40 )
        v39 = v45;
      else
        v39 = v47;
      goto LABEL_38;
    }
  LABEL_34:
    v39 = 1.0f;
  LABEL_38:
    v45 = v39;
    v51.X = a2.X * v36;
    v51.Y = a2.Y * v36;
    v51.Z = a2.Z * v36;
    a7.X = 0.0f;
    a7.Y = 0.0f;
    a7.Z = 0.0f;
    a5a.Z = (float)(a5a.Z - sqrt(a6) * (1.0f / v39 / a5.Z * v46));
    if ( Actor.ComplexEgdeCheck_Maybe(&a5a, a2.X * v36, a2.Y * v36, a2.Z * v36, ref *(int*)&a6, ref a7)
      || ((a2.X = v50.X * v46) is object && (a2.Y = v50.Y * v46) is object && (a2.Z = v50.Z * v46) is object && Actor.ComplexEgdeCheck_Maybe(&a5a, v50.X * v46, v50.Y * v46, v50.Z * v46, ref *(int*)&a6, ref a7)) )
    {
      a5a.X = Actor.Location.X + a7.X;
      a5a.Y = Actor.Location.Y + a7.Y;
      a5a.Z = Actor.Location.Z + a7.Z;
      v51.Z = (float)(-0.0f - Actor.MaxStepHeight) - 2.0f;
      Actor.GetCylinderExtent(&v50);
      Hit.Location.X = 0.0f;
      Hit.Location.Y = 0.0f;
      Hit.Location.Z = 0.0f;
      Hit.Normal.X = 0.0f;
      Hit.Normal.Y = 0.0f;
      Hit.Normal.Z = 0.0f;
      Hit.Time = 1.0f;
      Hit.Item = -1;
      Hit.LevelIndex = -1;
      a2.X = a5a.X;
      a2.Y = a5a.Y;
      Hit.Next = default;
      Hit.Actor = default;
      Hit.Material = default;
      Hit.PhysMaterial = default;
      Hit.Component = default;
      Hit.BoneName = default;
      Hit.Level = default;
      Hit.bStartPenetrating = default;
      v56 = default;
      a2.Z = v51.Z + a5a.Z;
      GWorld.SingleLineCheck(ref Hit, Actor, a2, a5a, 8927, v50, 0);
      if ( Hit.Time >= 1.0f || Hit.Time > 0.0f && Actor.WalkableFloorZ > Hit.Normal.Z )
      {
        if ( !(a8 != default) )
          return false;
        GWorld.MoveActor(Actor, ref a7, ref Actor.Rotation, 0, ref Hit);
        if ( Hit.Time == 1.0f )
        {
          // v42 = *(void (__thiscall **)(TdPlayerPawn , _DWORD, _DWORD, _DWORD, int))(Actor.VfTableObject.Dummy + 1060);
          a2.X = -0.0f - a7.X;
          a2.Y = -0.0f - a7.Y;
          a2.Z = -0.0f - a7.Z;
          Actor.OffsetMeshXY(new Vector(-0.0f - a7.X, -0.0f - a7.Y, -0.0f - a7.Z), 1);// OffsetMeshXY
          Actor.EvadeTimer = 0.2f;
          return false;
        }
        a2.X = (float)(-0.0f - a7.X) * Hit.Time;
        a2.Y = (float)(-0.0f - a7.Y) * Hit.Time;
        a2.Z = (float)(-0.0f - a7.Z) * Hit.Time;
        GWorld.MoveActor(Actor, ref a2, ref Actor.Rotation, 0, ref Hit);
      }
    }
    return true;
  }

  public unsafe bool OnWalkableFloor_orsomething(ref Vector a2, ref Vector a3, ref Vector a4)
  {
    float v5 = default; // xmm0_4
    float v6 = default; // xmm0_4
    float v7 = default; // xmm4_4
    float v8 = default; // xmm2_4
    float v9 = default; // xmm5_4
    float v10 = default; // xmm6_4
    float v11 = default; // xmm1_4
    float v12 = default; // xmm0_4
    float v13 = default; // xmm0_4
    float v14 = default; // xmm0_4
    float v15 = default; // xmm1_4
    float v16 = default; // xmm2_4
    float v17 = default; // xmm0_4
    bool v18 = default; // zf
    double v19 = default; // st7
    float v20 = default; // xmm3_4
    double v21 = default; // st7
    double v22 = default; // st6
    float v24 = default; // [esp+0h] [ebp-84h]
    float v25 = default; // [esp+0h] [ebp-84h]
    float v26 = default; // [esp+4h] [ebp-80h]
    float v27 = default; // [esp+4h] [ebp-80h]
    Vector a7 = default; // [esp+8h] [ebp-7Ch] BYREF
    Vector v29 = default; // [esp+18h] [ebp-6Ch] BYREF
    CheckResult v30 = default; // [esp+28h] [ebp-5Ch] BYREF
    int v31 = default; // [esp+70h] [ebp-14h]
    float v32 = default; // [esp+74h] [ebp-10h]
  
    v30.Next = default;
    v30.Actor = default;
    v30.Location.X = 0.0f;
    v30.Location.Y = 0.0f;
    v30.Location.Z = 0.0f;
    v30.Normal.X = 0.0f;
    v30.Normal.Y = 0.0f;
    v30.Normal.Z = 0.0f;
    v30.Material = default;
    v30.PhysMaterial = default;
    v30.Component = default;
    v30.BoneName = default;
    v30.Level = default;
    v30.bStartPenetrating = default;
    v31 = default;
    a7.X = 0.0f;
    a7.Y = 0.0f;
    a7.Z = 0.0f;
    v5 = a2.X + a3.X;
    v30.Item = -1;
    v30.LevelIndex = -1;
    v29.X = v5;
    v29.Y = a2.Y + a3.Y;
    v6 = a2.Z + a3.Z;
    v30.Time = 1.0f;
    v29.Z = v6;
    GWorld.SingleLineCheck(ref v30, this, v29, a2, 8415, a7, 0);
    if ( v30.Time >= 1.0f )
      return false;
    v7 = 0.0f;
    if ( v30.Time <= 0.0f || this.WalkableFloorZ <= fabs(v30.Normal.Z) )
      return false;
    v8 = v30.Normal.Y;
    v9 = v30.Location.X - (float)(a2.X + a3.X);
    v10 = v30.Location.Y - (float)(a2.Y + a3.Y);
    v11 = v30.Normal.X;
    v12 = (float)(v8 * v8) + (float)(v11 * v11);
    v32 = v12;
    if ( v12 == 1.0f )
    {
      if ( v30.Normal.Z == 0.0f )
      {
        a7.X = v30.Normal.X;
        v11 = v30.Normal.X;
        a7.Y = v30.Normal.Y;
        v8 = v30.Normal.Y;
        a7.Z = 0.0f;
      }
    }
    else if ( v12 >= SMALL_NUMBER )
    {
      a7.X = 3.0f;
      v13 = fsqrt(v32);
      v29.X = (float)(3.0f - (float)((float)((float)(1.0f / v13) * v32) * (float)(1.0f / v13))) * (float)((float)(1.0f / v13) * 0.5f);
      v11 = v29.X * v30.Normal.X;
      v8 = v30.Normal.Y * v29.X;
    }
    else
    {
      v11 = 0.0f;
      v8 = 0.0f;
    }
    v14 = (float)((float)(v8 * v10) + (float)(v11 * v9)) + (float)(0.0f * 0.0f);
    v15 = v11 * v14;
    v16 = v8 * v14;
    v17 = a4.X;
    v18 = a4.X == 0.0f;
    v29.X = v15;
    v19 = v15;
    v29.Y = v16;
    if ( v18 || (
      (v26 = (float)(v17 / fabs(v17))) is object 
       && v15 == 0.0f 
        ? (v20 = 0.0f) 
        : v20 = v24 = (float)(v19 / fabs(v19))
    ) is object && v26 == v20)
    {
      if ( fabs(v19) > fabs(v17) )
        v17 = v15;
      a4.X = v17;
    }
    v21 = v29.Y;
    v22 = a4.Y;
    if ( a4.Y != 0.0f )
    {
      v25 = (float)(v22 / fabs(v22));
      if ( v16 != 0.0f )
      {
        v27 = (float)(v21 / fabs(v21));
        v7 = v27;
      }
      if ( v25 != v7 )
        return true;
    }
    if ( fabs(v21) <= fabs(v22) )
      v16 = a4.Y;
    a4.Y = v16;
    return true;
  }

  public unsafe Vector * CheckForLedges_Maybe(Vector* a2, ref Vector a3, ref Vector a6)
  {
    PrimitiveComponent v5 = default; // eax
    //Vector *v6; // eax
    float v7 = default; // ecx
    float v8 = default; // edx
    float v9 = default; // xmm5_4
    float v10 = default; // xmm0_4
    float v11 = default; // xmm3_4
    float v12 = default; // xmm2_4
    float v13 = default; // xmm0_4
    CylinderComponent v14 = default; // ecx
    float v15 = default; // xmm2_4
    bool v16 = default; // eax
    bool v17 = default; // ebx
    float v18 = default; // xmm0_4
    bool v19 = default; // eax
    int v20 = default; // ebx
    int v21 = default; // ebp
    EMoveActionHint v22 = default; // al
    float v23 = default; // xmm3_4
    bool v24 = default; // eax
    Vector *result; // eax
    EMoveActionHint v26 = default; // al
    CylinderComponent v27 = default; // ecx
    float v28 = default; // xmm0_4
    float v29 = default; // ebp
    float v30 = default; // xmm2_4
    bool v31 = default; // edx
    bool v32 = default; // eax
    float v33 = default; // xmm2_4
    float v34 = default; // xmm1_4
    float v35 = default; // xmm0_4
    float v36 = default; // xmm1_4
    float v37 = default; // xmm2_4
    float v38 = default; // edx
    float v39 = default; // ecx
    float v40 = default; // xmm0_4
    float v41 = default; // xmm6_4
    int v42 = default; // ecx
    float v43 = default; // xmm2_4
    float v44 = default; // xmm6_4
    float v45 = default; // xmm0_4
    float v46 = default; // xmm5_4
    float v47 = default; // xmm0_4
    float v48 = default; // xmm1_4
    float v49 = default; // xmm0_4
    float v50 = default; // xmm0_4
    float v51 = default; // xmm0_4
    float v52 = default; // xmm0_4
    float v53 = default; // xmm2_4
    float v54 = default; // xmm0_4
    float v55 = default; // xmm7_4
    float v56 = default; // xmm0_4
    float v57 = default; // xmm0_4
    float v58 = default; // eax
    float v59 = default; // ecx
    float v60 = default; // edx
    bool v61 = default; // cf
    float v62 = default; // eax
    float v63 = default; // ecx
    float v64 = default; // edx
    float v65 = default; // xmm3_4
    float v66 = default; // xmm5_4
    float v67 = default; // xmm0_4
    float v68 = default; // xmm1_4
    float v69 = default; // xmm3_4
    float v70 = default; // xmm3_4
    float v71 = default; // xmm0_4
    float v72 = default; // xmm2_4
    float v73 = default; // xmm2_4
    float v74 = default; // edx
    float v75 = default; // ecx
    Vector a7 = default; // [esp+24h] [ebp-1ACh] BYREF
    Vector v77 = default; // [esp+34h] [ebp-19Ch] BYREF
    float v78 = default; // [esp+40h] [ebp-190h]
    float v79 = default; // [esp+44h] [ebp-18Ch]
    float v80 = default; // [esp+48h] [ebp-188h]
    Vector v81 = default; // [esp+4Ch] [ebp-184h] BYREF
    float v82 = default; // [esp+58h] [ebp-178h]
    float v83 = default; // [esp+5Ch] [ebp-174h]
    float v84 = default; // [esp+60h] [ebp-170h]
    float v85 = default; // [esp+64h] [ebp-16Ch]
    float v86 = default; // [esp+68h] [ebp-168h]
    float v87 = default; // [esp+6Ch] [ebp-164h]
    float v88 = default; // [esp+70h] [ebp-160h]
    float v89 = default; // [esp+74h] [ebp-15Ch]
    float v90 = default; // [esp+78h] [ebp-158h]
    float v91 = default; // [esp+7Ch] [ebp-154h]
    Vector v92 = default; // [esp+80h] [ebp-150h] BYREF
    float v93 = default; // [esp+90h] [ebp-140h]
    float v94 = default; // [esp+94h] [ebp-13Ch]
    float v95 = default; // [esp+98h] [ebp-138h]
    CheckResult v96 = default; // [esp+A0h] [ebp-130h] BYREF
    int v97 = default; // [esp+E8h] [ebp-E8h]
    CheckResult v98 = default; // [esp+ECh] [ebp-E4h] BYREF
    int v99 = default; // [esp+134h] [ebp-9Ch]
    CheckResult v100 = default; // [esp+138h] [ebp-98h] BYREF
    int v101 = default; // [esp+180h] [ebp-50h]
    CheckResult v102 = default; // [esp+184h] [ebp-4Ch] BYREF
  
    v100.Item = -1;
    v100.LevelIndex = -1;
    v96.Item = -1;
    v96.LevelIndex = -1;
    v98.Item = -1;
    v98.LevelIndex = -1;
    v5 = this.CollisionComponent;
    v100.Next = default;
    v100.Actor = default;
    v100.Location.X = 0.0f;
    v100.Location.Y = 0.0f;
    v100.Location.Z = 0.0f;
    v100.Normal.X = 0.0f;
    v100.Normal.Y = 0.0f;
    v100.Normal.Z = 0.0f;
    v100.Time = 1.0f;
    v100.Material = default;
    v100.PhysMaterial = default;
    v100.Component = default;
    v100.BoneName = default;
    v100.Level = default;
    v100.bStartPenetrating = default;
    v101 = default;
    v96.Next = default;
    v96.Actor = default;
    v96.Location.X = 0.0f;
    v96.Location.Y = 0.0f;
    v96.Location.Z = 0.0f;
    v96.Normal.X = 0.0f;
    v96.Normal.Y = 0.0f;
    v96.Normal.Z = 0.0f;
    v96.Time = 1.0f;
    v96.Material = default;
    v96.PhysMaterial = default;
    v96.Component = default;
    v96.BoneName = default;
    v96.Level = default;
    v96.bStartPenetrating = default;
    v97 = default;
    v98.Next = default;
    v98.Actor = default;
    v98.Location.X = 0.0f;
    v98.Location.Y = 0.0f;
    v98.Location.Z = 0.0f;
    v98.Normal.X = 0.0f;
    v98.Normal.Y = 0.0f;
    v98.Normal.Z = 0.0f;
    v98.Time = 1.0f;
    v98.Material = default;
    v98.PhysMaterial = default;
    v98.Component = default;
    v98.BoneName = default;
    v98.Level = default;
    v98.bStartPenetrating = default;
    v99 = default;
    if(v5 != default)
    {
      a7.X = v5.Translation.X + this.Location.X;
      a7.Y = v5.Translation.Y + this.Location.Y;
      a7.Z = v5.Translation.Z + this.Location.Z;
      v7 = a7.X;
      v8 = a7.Y;
      v90 = a7.Z;
    }
    else
    {
      ref var v6 = ref this.Location;
      v7 = v6.X;
      v8 = v6.Y;
      v90 = v6.Z;
    }
    //v7 = v6->X;
    //v8 = v6->Y;
    v9 = a3.Y;
    v10 = (float)(a3.X * a3.X) + (float)(v9 * v9);
    //v90 = v6->Z;
    v88 = v7;
    v89 = v8;
    v86 = v10;
    v92.X = v10;
    if ( v10 != 1.0f )
    {
      if ( v10 >= SMALL_NUMBER )
      {
        v93 = 3.0f;
        v87 = 0.5f;
        v12 = 1.0f / fsqrt(v92.X);
        a7.X = (float)(3.0f - (float)((float)(v12 * v92.X) * v12)) * (float)(v12 * 0.5f);
        v11 = a7.X * a3.X;
        v9 = a3.Y * a7.X;
      }
      else
      {
        v11 = 0.0f;
        v9 = 0.0f;
      }
      v78 = v11;
      v79 = v9;
      v80 = 0.0f;
      goto LABEL_12;
    }
    if ( a3.Z != 0.0f )
    {
      v11 = a3.X;
  LABEL_11:
      v78 = v11;
      v79 = v9;
      v80 = 0.0f;
      goto LABEL_12;
    }
    v78 = a3.X;
    v11 = a3.X;
    v79 = a3.Y;
    v9 = a3.Y;
    v80 = 0.0f;
  LABEL_12:
    v13 = this.EdgeCheckDistance;
    v77.Y = (float)(v89 + a3.Y) + (float)(v9 * v13);
    v77.X = (float)(v88 + a3.X) + (float)(v11 * v13);
    v81.Y = v77.Y;
    v77.Z = (float)(v90 + a3.Z) + (float)(v80 * v13);
    v81.X = v77.X;
    v14 = this.CylinderComponent;
    v81.Z = v77.Z;
    v15 = v77.Z - (float)((float)(v14.CollisionHeight + this.EdgeStopMinHeight) + 4.0f);
    v85 = (float)(v14.CollisionHeight + this.EdgeStopMinHeight) + 4.0f;
    v81.Z = v15;
    a7.X = 0.0f;
    a7.Y = 0.0f;
    a7.Z = 0.0f;
    GWorld.SingleLineCheck(ref v100, this, v81, v77, 8927, a7, 0);
    v91 = (float)(this.CylinderComponent.CollisionHeight + this.MaxStepHeight) / v85;
    v16 = v100.Time > v91 || this.WalkableFloorZ > v100.Normal.Z;
    v82 = (float)(v80 * 0.0f) - v79;
    v84 = (float)(v79 * 0.0f) - (float)(v78 * 0.0f);
    v83 = v78 - (float)(v80 * 0.0f);
    v94 = v83 + v79;
    v95 = v84 + v80;
    v93 = v82 + v78;
    v17 = v16;
    v87 = (float)(sqrt(v86));
    v87 = v87 * 0.70710677f;
    v18 = v87 + this.EdgeCheckDistance;
    v77.Y = (float)((float)(v83 + v79) * v18) + v89;
    v81.Y = v77.Y;
    a7.Z = (float)((float)(v84 + v80) * v18) + v90;
    v77.Z = a7.Z;
    v77.X = (float)((float)(v82 + v78) * v18) + v88;
    v81.X = v77.X;
    v81.Z = a7.Z - v85;
    a7.X = 0.0f;
    a7.Y = 0.0f;
    a7.Z = 0.0f;
    GWorld.SingleLineCheck(ref v96, this, v81, v77, 8927, a7, 0);
    v19 = v96.Time > v91 || this.WalkableFloorZ > v96.Normal.Z;
    v20 = (v19 ? 1 : 0) + (v17 ? 1 : 0);
    v21 = default;
    if ( v20 == 2 && !this.IsTimerActive("SlideOffLedge") )
    {
      this.SetTimer(0.2f, false, "SlideOffLedge", this);
      if ( (float)((float)(this.Velocity.X * this.Velocity.X) + (float)(this.Velocity.Y * this.Velocity.Y)) > (float)(this.EdgeCheckMaxSpeed * this.EdgeCheckMaxSpeed) || ((v22 = this.MoveActionHint) is object && v22 == MAH_Up) || v22 == MAH_Down )
      {
        goto LABEL_29;
      }
      v21 = 1;
    }
    v23 = v87 + this.EdgeCheckDistance;
    v92.Z = v80 - v84;
    a7.Z = (float)((float)(v80 - v84) * v23) + v90;
    v92.X = v78 - v82;
    v92.Y = v79 - v83;
    v77.Z = a7.Z;
    v77.X = (float)((float)(v78 - v82) * v23) + v88;
    v81.X = v77.X;
    v77.Y = (float)((float)(v79 - v83) * v23) + v89;
    v81.Y = v77.Y;
    v81.Z = a7.Z - v85;
    a7.X = 0.0f;
    a7.Y = 0.0f;
    a7.Z = 0.0f;
    GWorld.SingleLineCheck(ref v98, this, v81, v77, 8927, a7, 0);
    v24 = v98.Time > v91 || this.WalkableFloorZ > v98.Normal.Z;
    if ( !(v21 != default) )
    {
      if ( v20 + v24.AsInt() == 2 && !this.IsTimerActive("SlideOffLedge") )
        this.SetTimer(0.2f, false, "SlideOffLedge", this);
      if ( (float)((float)(this.Velocity.X * this.Velocity.X) + (float)(this.Velocity.Y * this.Velocity.Y)) > (float)(this.EdgeCheckMaxSpeed * this.EdgeCheckMaxSpeed) )
        goto LABEL_29;
      v26 = this.MoveActionHint;
      if ( v26 == MAH_Up || v26 == MAH_Down )
        goto LABEL_29;
    }
    v27 = this.CylinderComponent;
    v28 = v90 - v27.CollisionHeight;
    v29 = v88;
    a7.Y = v89;
    a7.Z = v28;
    if ( v98.Time == 1.0f || ((v30 = this.WalkableFloorZ) is object && (v85 = 0.0f) is object && v30 > v98.Normal.Z) )
      v85.LODWORD(1);
    v31 = v96.Time == 1.0f || this.WalkableFloorZ > v96.Normal.Z;
    v32 = v100.Time == 1.0f || this.WalkableFloorZ > v100.Normal.Z;
    if ( !((LODWORD(v85) | (v31 || v32).AsInt()) != default) )
      goto LABEL_115;
    v33 = v27.CollisionRadius - 4.0f;
    v34 = this.EdgeCheckDistance * this.EdgeCheckDistance;
    v91 = v33;
    v87 = v34;
    if ( (v31.AsInt() & LODWORD(v85)) == default )
    {
      v82 = 0.0f;
      v83 = 0.0f;
      v84 = 0.0f;
      if(v32 != default)
      {
        v62 = v78;
        v63 = v79;
        v64 = v80;
      }
      else if ( v85 == 0.0f )
      {
        if ( !v31 )
        {
          goto LABEL_102;
        }
        v62 = v93;
        v63 = v94;
        v64 = v95;
      }
      else
      {
        v62 = v92.X;
        v63 = v92.Y;
        v64 = v92.Z;
      }
      v82 = v62;
      v83 = v63;
      v84 = v64;
      goto LABEL_102;
    }
    v86 = v28 - 8.0f;
    v35 = v92.X * v33;
    v36 = v92.Y * v33;
    v37 = v92.Z * v33;
    v81.X = v88 - v35;
    v81.Y = a7.Y - v36;
    v81.Z = v86 - v37;
    v77.X = v35 + v88;
    v77.Y = v36 + a7.Y;
    v77.Z = v37 + v86;
    v92.X = 0.0f;
    v92.Y = 0.0f;
    v92.Z = 0.0f;
    GWorld.SingleLineCheck(ref v98, this, v81, v77, 8415, v92, 0);
    if ( v98.Time >= 1.0f || v98.Time <= 0.0f || this.WalkableFloorZ <= v98.Normal.Z )
    {
      v85 = 0.0f;
    }
    else
    {
      v38 = v98.Location.Y;
      a6.X = v98.Location.X;
      v39 = v98.Location.Z;
      a6.Y = v38;
      a6.Z = v39;
      v40 = a6.Z + 8.0f;
      v85.LODWORD(1);
      a6.Z = v40;
    }
    v41 = a7.Y;
    a7.Y = a7.Y - (float)(v94 * v91);
    v81.X = v29 - (float)(v93 * v91);
    v81.Y = a7.Y;
    v81.Z = v86 - (float)(v95 * v91);
    v77.X = (float)(v93 * v91) + v29;
    v77.Y = (float)(v94 * v91) + v41;
    v77.Z = (float)(v95 * v91) + v86;
    a7.X = 0.0f;
    a7.Y = 0.0f;
    a7.Z = 0.0f;
    GWorld.SingleLineCheck(ref v96, this, v81, v77, 8415, a7, 0);
    if ( v96.Time >= 1.0f || v96.Time <= 0.0f || this.WalkableFloorZ <= v96.Normal.Z )
    {
      v42 = default;
    }
    else
    {
      a6 = v96.Location;
      v42 = 1;
      a6.Z = a6.Z + 8.0f;
    }
    v43 = v98.Normal.X;
    v44 = v98.Normal.Y;
    v45 = (float)(v43 * v43) + (float)(v44 * v44);
    v92.X = v45;
    if ( v45 == 1.0f )
    {
      if ( v98.Normal.Z == 0.0f )
      {
        v82 = v98.Normal.X;
        v83 = v98.Normal.Y;
        v46 = v98.Normal.Y;
        v84 = 0.0f;
        goto LABEL_69;
      }
      v82 = v98.Normal.X;
      v46 = v98.Normal.Y;
    }
    else if ( v45 >= SMALL_NUMBER )
    {
      v93 = 3.0f;
      v86 = 0.5f;
      v47 = fsqrt(v92.X);
      a7.X = (float)(3.0f - (float)((float)((float)(1.0f / v47) * v92.X) * (float)(1.0f / v47))) * (float)((float)(1.0f / v47) * 0.5f);
      v43 = v98.Normal.X;
      v44 = v98.Normal.Y;
      v82 = a7.X * v98.Normal.X;
      v46 = v98.Normal.Y * a7.X;
    }
    else
    {
      v82 = 0.0f;
      v46 = 0.0f;
    }
    v84 = 0.0f;
  LABEL_69:
    v48 = v96.Normal.Y;
    v49 = (float)(v96.Normal.X * v96.Normal.X) + (float)(v48 * v48);
    v92.X = v49;
    if ( v49 == 1.0f )
    {
      if ( v96.Normal.Z == 0.0f )
      {
        v78 = v96.Normal.X;
        v79 = v96.Normal.Y;
        v48 = v96.Normal.Y;
        v80 = 0.0f;
        goto LABEL_77;
      }
      v78 = v96.Normal.X;
    }
    else if ( v49 >= SMALL_NUMBER )
    {
      v93 = 3.0f;
      v86 = 0.5f;
      v50 = fsqrt(v92.X);
      a7.X = (float)(3.0f - (float)((float)((float)(1.0f / v50) * v92.X) * (float)(1.0f / v50))) * (float)((float)(1.0f / v50) * 0.5f);
      v44 = v98.Normal.Y;
      v48 = v96.Normal.Y * a7.X;
      v43 = v98.Normal.X;
      v78 = a7.X * v96.Normal.X;
    }
    else
    {
      v78 = 0.0f;
      v48 = 0.0f;
    }
    v80 = 0.0f;
  LABEL_77:
    v51 = (float)((float)(a3.Z * v98.Normal.Z) + (float)(v43 * a3.X)) + (float)(v44 * a3.Y);
    a7.X = a3.X - (float)(v98.Normal.X * v51);
    a7.Y = a3.Y - (float)(v44 * v51);
    a7.Z = a3.Z - (float)(v51 * v98.Normal.Z);
    v52 = (float)((float)(a3.Z * v96.Normal.Z) + (float)(v96.Normal.X * a3.X)) + (float)(v96.Normal.Y * a3.Y);
    v53 = a3.X - (float)(v52 * v96.Normal.X);
    v93 = v53;
    v94 = a3.Y - (float)(v96.Normal.Y * v52);
    v95 = a3.Z - (float)(v52 * v96.Normal.Z);
    if ( v85 == 0.0f )
    {
      v55 = 0.0f;
    }
    else
    {
      v54 = (float)((float)((float)((float)(v98.Location.X - v88) * v82) + (float)((float)(v98.Location.Z - v90) * v84)) + (float)((float)(v98.Location.Y - v89) * v46)) / (float)((float)((float)(v82 * v82) + (float)(v84 * v84)) + (float)(v46 * v46));
      v55 = (float)((float)((float)(v54 * v82) - a7.X) * (float)((float)(v54 * v82) - a7.X)) + (float)((float)((float)(v46 * v54) - a7.Y) * (float)((float)(v46 * v54) - a7.Y));
    }
    if(v42 != default)
    {
      v56 = (float)((float)((float)((float)(v96.Location.X - v88) * v78) + (float)((float)(v96.Location.Z - v90) * v80)) + (float)((float)(v96.Location.Y - v89) * v48)) / (float)((float)((float)(v78 * v78) + (float)(v80 * v80)) + (float)(v48 * v48));
      v57 = (float)((float)((float)(v56 * v78) - v53) * (float)((float)(v56 * v78) - v53)) + (float)((float)((float)(v48 * v56) - v94) * (float)((float)(v48 * v56) - v94));
    }
    else
    {
      v57 = 0.0f;
    }
    if ( v87 >= v57 )
    {
      if ( v87 < v55 )
        goto LABEL_92;
      if( v85 != 0.0f && v42.AsBool() )
      {
        result = a2;
        a2->X = 0.0f;
        a2->Y = 0.0f;
        a2->Z = 0.0f;
        return result;
      }
    }
    if ( v87 >= v55 && v85 != 0.0f )
    {
      v58 = a7.X;
      v59 = a7.Y;
      v60 = a7.Z;
      v61 = v87 < v57;
      goto LABEL_90;
    }
  LABEL_92:
    if ( v87 < v57 || !(v42.AsBool()) )
      goto LABEL_115;
    v58 = v93;
    v59 = v94;
    v60 = v95;
    v61 = v87 < v55;
  LABEL_90:
    a3.Z = v60;
    a3.Y = v59;
    a3.X = v58;
    if ( !v61 )
    {
  LABEL_91:
      result = a2;
      a2->X = 0.0f;
      a2->Y = 0.0f;
      a2->Z = 0.0f;
      return result;
    }
  LABEL_115:
    result = a2;
    *a2 = a3;
    return result;
    
    LABEL_29:
    result = a2;
    *a2 = a3;
    return result;
  LABEL_102:
    v102 = new CheckResult(1.0f, null);
    v65 = a7.Z - 8.0f;
    v66 = a7.Y;
    a7.Y = a7.Y - (float)(v83 * v91);
    v81.X = v29 - (float)(v82 * v91);
    a7.Z = (float)(a7.Z - 8.0f) - (float)(v84 * v91);
    v81.Y = a7.Y;
    v81.Z = a7.Z;
    v77.X = (float)(v82 * v91) + v29;
    v77.Y = (float)(v83 * v91) + v66;
    v77.Z = (float)(v84 * v91) + v65;
    a7.X = 0.0f;
    a7.Y = 0.0f;
    a7.Z = 0.0f;
    GWorld.SingleLineCheck(ref v102, this, v81, v77, 8415, a7, 0);
    if ( v102.Time >= 1.0f || v102.Time <= 0.0f || this.WalkableFloorZ <= v102.Normal.Z )
      goto LABEL_115;
    v67 = v102.Normal.X;
    v68 = v102.Normal.Y;
    v69 = (float)(v67 * v67) + (float)(v68 * v68);
    v92.X = v69;
    if ( v69 == 1.0f )
    {
      if ( v102.Normal.Z == 0.0f )
      {
        a7 = v102.Normal;
        v67 = v102.Normal.X;
        v68 = v102.Normal.Y;
        v70 = v102.Normal.Z;
        goto LABEL_112;
      }
    }
    else if ( v69 >= SMALL_NUMBER )
    {
      v93 = 3.0f;
      v91 = 0.5f;
      v71 = fsqrt(v92.X);
      a7.X = (float)(3.0f - (float)((float)((float)(1.0f / v71) * v92.X) * (float)(1.0f / v71))) * (float)((float)(1.0f / v71) * 0.5f);
      v67 = a7.X * v102.Normal.X;
      v68 = v102.Normal.Y * a7.X;
    }
    else
    {
      v67 = 0.0f;
      v68 = 0.0f;
    }
    v70 = 0.0f;
    goto LABEL_112;
    LABEL_112:
    v72 = (float)((float)((float)((float)(v102.Location.X - v88) * v67) + (float)((float)(v102.Location.Z - v90) * v70)) + (float)((float)(v102.Location.Y - v89) * v68))
          / (float)((float)((float)(v67 * v67) + (float)(v70 * v70)) + (float)(v68 * v68));
    if ( v87 >= (float)((float)((float)((float)(v72 * v67) * (float)(v72 * v67)) + (float)((float)(v68 * v72) * (float)(v68 * v72))) - v86) )
    {
      v73 = (float)((float)(v67 * a3.X) + (float)(v70 * a3.Z)) + (float)(v68 * a3.Y);
      a3.X = a3.X - (float)(v67 * v73);
      a3.Y = a3.Y - (float)(v68 * v73);
      a3.Z = a3.Z - (float)(v70 * v73);
    }
    v74 = v102.Location.Y;
    a6.X = v102.Location.X;
    v75 = v102.Location.Z;
    a6.Y = v74;
    a6.Z = v75;
    a6.Z = a6.Z + 8.0f;
    goto LABEL_115;
  }

  public unsafe void MAT_SetAnimWeights(array<AnimSlotInfo> a)
  {
    //name *v4; // esi
    int i = default; // edi
    AnimNodeSlot v6 = default; // ecx
    int v7 = default; // [esp+8h] [ebp-4h]
    int aa = default; // [esp+10h] [ebp+4h]
  
    v7 = default;
    if ( a.Count > 0 )
    {
      aa = default;
      do
      {
        //v4 = (name *)(aa + a[0].SlotName.Index);
        for ( i = default; i < this.SlotNodes.Count; ++i )
        {
          v6 = this.SlotNodes[i];
          if ( v6 && v6.NodeName == a[i].SlotName )
            v6.MAT_SetAnimWeights( ref a[i] );// UAnimNodeSlot::MAT_SetAnimWeights
        }
        //aa = aa + (20);
        ++v7;
      }
      while ( v7 < a.Count );
    }
  }

  public unsafe void UpdateAgainstWall()
  {
    TdPlayerController v1 = default; // esi
    int v2 = default; // edi
    int v3 = default; // eax
    TdMove v4 = default; // esi
    TdMove v5 = default; // eax
    int v6 = default; // ecx
    TdMove v7 = default; // eax
    int v8 = default; // edx
    int v9 = default; // edi
    EAgainstWallState v11 = default; // al
    Controller v12 = default; // eax
    TdWeapon v13 = default; // esi
    TdPlayerController v14 = default; // eax
    int v15 = default; // [esp+10h] [ebp-8h]
  
    v11 = CheckAgainstWall();
    NativeMarkers.MarkUnimplemented("This is not properly decompiled, likely to not work as expected");
    if(v11 != default)
    {
      this.AgainstWallState = v11;
      this.ClearTimer("StopAgainstWall");
      this.SetTimer(0.15000001f, false, "StopAgainstWall");
      v12 = this.Controller;
      SetFromBitfield(ref this.bDisableSkelControlSpring, 32, this.bDisableSkelControlSpring.AsBitfield(32) | (4u));
      this.MinLookConstraint.Pitch = -5000;
      this.MaxLookConstraint.Pitch = 0x8000;
      if(v12 != default)
      {
        v13 = this.MyWeapon;
        if(v13 != default)
        {
          if ( (v13.bTakingDamage.AsBitfield(9) & 8) != default )
          {
            v14 = E_TryCastTo<TdPlayerController>(v12);
            if(v14 != default)
            {
              v15 = v9;
              v1 = v14;
              v2 = v14.VfTableObject.Dummy;
              v14.UnZoom();
              //CallUFunction(, v1, v3, 0, 0, v15);
            }
          }
        }
      }
    }
    else if ( this.MovementState == MOVE_Walking )
    {
      v4 = this.Moves[1];
      /*if ( !class_TdMove )
      {
        class_TdMove = (Class )sub_11FEB80((int)L"TdGame");
        sub_11F3850();
      }*/
      v5 = ClassT<TdMove>().DefaultAs<TdMove>();
      v6 = v5.MinLookConstraint.Pitch;
      //v5 = (TdMove )((byte *)v5 + 216);
      v4.MinLookConstraint.Pitch = v6;
      v4.MinLookConstraint.Yaw = v5.MinLookConstraint.Yaw;
      v4.MinLookConstraint.Roll = v5.MinLookConstraint.Roll;
      /*if ( !class_TdMove )
      {
        class_TdMove = (Class )sub_11FEB80((int)L"TdGame");
        sub_11F3850();
      }*/
      v7 = ClassT<TdMove>().DefaultAs<TdMove>();//(TdMove )class_TdMove.GetDefaultObject(0);
      v8 = v7.MaxLookConstraint.Pitch;
      //v7 = (TdMove )((byte *)v7 + 0xE4);// Now points to MaxLookConstraint
      v4.MaxLookConstraint.Pitch = v8;
      v4.MaxLookConstraint.Yaw = v7.MaxLookConstraint.Yaw;
      v4.MaxLookConstraint.Roll = v7.MaxLookConstraint.Roll;
    }
  }

  public unsafe Vector * SomethingVertigoRelated(Vector *a2, int a3, int a4, int a5, float a6, float a7, float a8, int a9, int a10, int a11, int* a12, int* a13)
  {
    float v14 = default; // xmm1_4
    Vector *result; // eax
    float v16 = default; // edx
    float v17 = default; // ecx
    float v18 = default; // xmm0_4
    float v19 = default; // xmm2_4
    float v20 = default; // xmm5_4
    float v21 = default; // xmm4_4
    float v22 = default; // xmm6_4
    float v23 = default; // xmm0_4
    float v24 = default; // xmm1_4
    float v25 = default; // xmm2_4
    PrimitiveComponent v26 = default; // eax
    //Vector *v27; // eax
    float v28 = default; // ecx
    float v29 = default; // xmm0_4
    float v30 = default; // edx
    float v31 = default; // xmm0_4
    TdMove_Vertigo v32 = default; // edi
    double v33 = default; // st5
    double v34 = default; // st4
    double v35 = default; // st6
    double v36 = default; // st5
    float v37 = default; // eax
    float v38 = default; // edx
    float v39 = default; // ecx
    float v40 = default; // edx
    int v41 = default; // edi
    int v42 = default; // eax
    int v43 = default; // edi
    int v44 = default; // eax
    Vector v45 = default; // [esp-8h] [ebp-D4h]
    Vector v46 = default; // [esp+18h] [ebp-B4h] BYREF
    Vector v47 = default; // [esp+28h] [ebp-A4h] BYREF
    int v48 = default; // [esp+34h] [ebp-98h]
    Vector v49 = default; // [esp+38h] [ebp-94h] BYREF
    Vector a2a = default; // [esp+44h] [ebp-88h] BYREF
    int v51 = default; // [esp+54h] [ebp-78h]
    Vector v52 = default; // [esp+58h] [ebp-74h] BYREF
    Vector v53 = default; // [esp+64h] [ebp-68h] BYREF
    float v54 = default; // [esp+70h] [ebp-5Ch]
    CheckResult v55 = default; // [esp+80h] [ebp-4Ch] BYREF
  
    if ( (this.bUpAndOut.AsBitfield(32) & 0x8000) == default )
      goto LABEL_29;
    if ( (this.Moves[this.MovementState].bDebugMove.AsBitfield(29) & 0x2000) == default )
      goto LABEL_29;
    v45.X = a6;
    *(_QWORD *)&v45.Y = __PAIR64__(LODWORD(a8), LODWORD(a7));
    CheckForLedges_Maybe(&v46, ref v45, ref v53);
    v14 = v46.Y;
    if ( v46.X == a6 && v46.Y == a7 && v46.Z == a8 )
      goto LABEL_29;
    if ( this.MovementState == MOVE_Crouch )
    {
      result = a2;
      v16 = v46.Y;
      a2->X = v46.X;
      v17 = v46.Z;
      a2->Y = v16;
      a2->Z = v17;
      return result;
    }
    v18 = (float)(v46.Y * v46.Y) + (float)(v46.X * v46.X);
    a2a.X = v18;
    if ( v18 != 1.0f && v18 >= SMALL_NUMBER )
    {
      v47.X = 3.0f;
      v51 = 1056964608;
      v19 = 1.0f / fsqrt(a2a.X);
      v54 = (float)(3.0f - (float)((float)(v19 * a2a.X) * v19)) * (float)(v19 * 0.5f);
      v14 = v46.Y;
    }
    v20 = a8 - v46.Z;
    v21 = a7 - v14;
    v22 = a6 - v46.X;
    v23 = (float)((float)(v20 * v20) + (float)(v21 * v21)) + (float)(v22 * v22);
    v24 = 0.0f;
    a2a.X = a6 - v46.X;
    a2a.Y = v21;
    a2a.Z = a8 - v46.Z;
    v46.X = v23;
    if ( v23 == 1.0f )
    {
      v46 = a2a;
    }
    else
    {
      if ( v23 >= SMALL_NUMBER )
      {
        v54 = 3.0f;
        v51 = 1056964608;
        v25 = 1.0f / fsqrt(v46.X);
        v47.X = (float)(3.0f - (float)((float)(v25 * v46.X) * v25)) * (float)(v25 * 0.5f);
        v24 = v47.X * v22;
        v46.Y = v21 * v47.X;
        v46.Z = v20 * v47.X;
      }
      else
      {
        v46.Y = 0.0f;
        v46.Z = 0.0f;
      }
      v46.X = v24;
    }
    v55 = new CheckResult(1.0f, null);
    v26 = this.CollisionComponent;
    if(v26 != default)
    {
      v47.X = v26.Translation.X + this.Location.X;
      v47.Y = v26.Translation.Y + this.Location.Y;
      v47.Z = v26.Translation.Z + this.Location.Z;
      ref var v27 = ref v47;
      v28 = v27.Y;
      a2a.X = v27.X;
      v30 = v27.Z;
    }
    else
    {
      ref var v27 = ref this.Location;
      v28 = v27.Y;
      a2a.X = v27.X;
      v30 = v27.Z;
    }
    v29 = this.VertigoEdgeProbingDistance;
    v49.X = a2a.X + (float)(v46.X * v29);
    a2a.Y = v28;
    v49.Y = v28 + (float)(v46.Y * v29);
    a2a.Z = v30;
    v52.X = v49.X;
    v49.Z = v30 + (float)(v46.Z * v29);
    v31 = v49.Z - this.VertigoEdgeProbingHeight;
    v52.Y = v49.Y;
    v52.Z = v31;
    v47.X = 0.0f;
    v47.Y = 0.0f;
    v47.Z = 0.0f;
    GWorld.SingleLineCheck(ref v55, this, v52, v49, 8927, v47, 0);
    if ( v55.Time != 1.0f )
    {
      goto LABEL_29;
    }
    else
    {
      v46.X = v49.X - a2a.X;
      v46.Y = v49.Y - a2a.Y;
      v46.Z = v49.Z - a2a.Z;
      v46.Normalize();
      this.Rotation.Vector(&a2a);
      a2a.Normalize();
      if ( fabs(a2a.Z * v46.Z + a2a.Y * v46.Y + v46.X * a2a.X) > this.VertigoEffectThreshold && this.MovementState == MOVE_Walking && this.CurrentWalkingState < WAS_Run )
      {
        v32 = E_TryCastTo<TdMove_Vertigo>(this.Moves[47]);
        v33 = v53.Z - v32.LastActualVertigoEdgePosition.Z;
        v34 = v53.Y - v32.LastActualVertigoEdgePosition.Y;
        v35 = v34 * v34 + v33 * v33;
        v36 = v53.X - v32.LastActualVertigoEdgePosition.X;
        if ( sqrt(v36 * v36 + v35) >= 2.0f )
        {
          if ( this.CanDoMove((EMovement)47) )
          {
            v32.LastVertigoEdgePosition.X = v49.X;
            v37 = v53.X;
            v32.LastVertigoEdgePosition.Y = v49.Y;
            v38 = v49.Z;
            v39 = v53.Y;
            v32.LastActualVertigoEdgePosition.X = v37;
            v32.LastVertigoEdgePosition.Z = v38;
            v40 = v53.Z;
            v32.LastActualVertigoEdgePosition.Y = v39;
            v32.LastActualVertigoEdgePosition.Z = v40;
            v41 = this.VfTableObject.Dummy;
            v48 = default;
            v47.X.LOBYTE(47);
            v47.Y = 0.0f;
            v47.Z = 0.0f;
            this.SetMove((EMovement)47);
          }
        }
      }
      if ( this.MovementState == MOVE_Vertigo )
      {
        result = a2;
        a2->X = 0.0f;
        a2->Y = 0.0f;
        a2->Z = 0.0f;
        return result;
      }
    }
    LABEL_29_Cont:
    result = a2;
    a2->X = a6;
    a2->Y = a7;
    a2->Z = a8;
    return result;
    
    LABEL_29:
    if ( this.MovementState == MOVE_Vertigo )
    {
      v43 = this.VfTableObject.Dummy;
      v48 = default;
      v47.X.LOBYTE(1);
      v47.Y = 0.0f;
      v47.Z = 0.0f;
      this.SetMove((EMovement)1);
      //CallUFunction(this.SetMove, this, v44, &v47, 0);
    }

    goto LABEL_29_Cont;
  }

  // Not Ready
  public unsafe void MAT_BeginAnimControl( in array<AnimSet> a1 )
  {
    NativeMarkers.MarkUnimplemented();
  }
  /*public unsafe void MAT_BeginAnimControl(ref array<AnimSet_ptr> a1)
  {
    ref array<AnimNodeSlot_ptr> v3; // esi
    int v4 = default; // ebx
    bool v5 = default; // zf
    AnimNodeSlot *v6; // edi
    void *v7; // ecx
    int v8 = default; // edi
    int *v9; // eax
    void *v10; // ecx
    int v11 = default; // edi
    int v12 = default; // eax
    int v13 = default; // ecx
    AnimNodeSlot v14 = default; // ebx
    Class v15 = default; // eax
    int v16 = default; // ebp
    bool v17 = default; // cc
    int v18 = default; // eax
    AnimNodeSlot *v19; // edi
    void *v20; // ecx
    int v21 = default; // ebx
    int v22 = default; // eax
    AnimNodeSlot *v23; // eax
    int v24 = default; // esi
    void *v25; // ecx
    int v26 = default; // [esp+1Ch] [ebp-2Ch]
    AnimNodeSlot v27 = default; // [esp+20h] [ebp-28h]
    int v28 = default; // [esp+24h] [ebp-24h] BYREF
    int v29 = default; // [esp+28h] [ebp-20h]
    int v30 = default; // [esp+2Ch] [ebp-1Ch]
    int v31 = default; // [esp+30h] [ebp-18h] BYREF
    int v32 = default; // [esp+34h] [ebp-14h]
    int v33 = default; // [esp+38h] [ebp-10h]
    int v34 = default; // [esp+44h] [ebp-4h]
  
    v3 = ref this.SlotNodes;
    v4 = default;
    v5 = this.SlotNodes.Max == 0;
    this.SlotNodes.Count = default;
    if ( !v5 )
    {
      v6 = v3.Data;
      v5 = v3.Data == 0;
      this.SlotNodes.Max = default;
      if ( !v5 )
      {
        v7 = dword_2018708;
        if ( !dword_2018708 )
        {
          GCreateMalloc_Prob();
          v7 = dword_2018708;
        }
        v3.Data = (AnimNodeSlot *__ptr32)(*(int (__thiscall **)(void *, AnimNodeSlot *__ptr32, _DWORD, int))(*(_DWORD *)v7 + 8))(v7, v6, 0, 8);
      }
    }
    if ( this.Mesh1p.Animations )
    {
      v28 = default;
      v29 = default;
      v30 = default;
      v34 = default;
      if ( !dword_1FFCE34 )
      {
        dword_1FFCE34 = (int)sub_CF7D40((int)L"Engine");
        sub_CFFB70();
      }
      sub_CF4FC0(this.Mesh1p.Animations, &v28, dword_1FFCE34);
      if ( v29 > 0 )
      {
        do
        {
          v8 = sub_D25E00(*(_DWORD *)(v28 + 4 * v4));
          if(v8 != default)
          {
            v9 = (int *)&v3[v3.Add(1, 4, 8)];
            if(v9 != default)
              *v9 = v8;
          }
          ++v4;
        }
        while ( v4 < v29 );
      }
      v34 = -1;
      if(v28 != default)
      {
        v10 = dword_2018708;
        v11 = v28;
        if ( !dword_2018708 )
        {
          GCreateMalloc_Prob();
          v10 = dword_2018708;
        }
        (*(void (__thiscall **)(void *, int))(*(_DWORD *)v10 + 12))(v10, v11);
      }
    }
    if ( this.Mesh3p.Animations )
    {
      v31 = default;
      v32 = default;
      v33 = default;
      v34 = 1;
      if ( !dword_1FFCE34 )
      {
        dword_1FFCE34 = (int)sub_CF7D40((int)L"Engine");
        sub_CFFB70();
      }
      sub_CF4FC0(this.Mesh3p.Animations, &v31, dword_1FFCE34);
      v12 = default;
      v26 = default;
      if ( v32 > 0 )
      {
        v13 = dword_1FFCE34;
        do
        {
          v14 = *(AnimNodeSlot *)(v31 + 4 * v12);
          v27 = v14;
          if(v14 != default)
          {
            if ( !v13 )
            {
              dword_1FFCE34 = (int)sub_CF7D40((int)L"Engine");
              sub_CFFB70();
              v13 = dword_1FFCE34;
            }
            v15 = v14.Class;
            if(v15 != default)
            {
              while ( v15 != (Class )v13 )
              {
                v15 = (Class )v15.Next;
                if ( !v15 )
                  goto LABEL_29;
              }
  LABEL_30:
              v16 = v3.Count;
              v17 = v16 + 1 <= v3.Max;
              v3.Count = v16 + 1;
              if ( !v17 )
              {
                v18 = v3.CalculateSlack(4);
                v19 = v3.Data;
                v5 = v3.Data == 0;
                v3.Max = v18;
                if ( !v5 || v18 )
                {
                  v20 = dword_2018708;
                  v21 = 4 * v18;
                  if ( !dword_2018708 )
                  {
                    GCreateMalloc_Prob();
                    v20 = dword_2018708;
                  }
                  v22 = (*(int (__thiscall **)(void *, AnimNodeSlot *__ptr32, int, int))(*(_DWORD *)v20 + 8))(v20, v19, v21, 8);
                  v14 = v27;
                  v3.Data = (AnimNodeSlot *__ptr32)v22;
                }
              }
              v23 = &v3[v16];
              if(v23 != default)
                *v23 = v14;
              v13 = dword_1FFCE34;
              goto LABEL_39;
            }
  LABEL_29:
            if ( !v13 )
              goto LABEL_30;
          }
  LABEL_39:
          v12 = ++v26;
        }
        while ( v26 < v32 );
      }
      v24 = v31;
      v34 = -1;
      if(v31 != default)
      {
        v25 = dword_2018708;
        if ( !dword_2018708 )
        {
          GCreateMalloc_Prob();
          v25 = dword_2018708;
        }
        (*(void (__thiscall **)(void *, int))(*(_DWORD *)v25 + 12))(v25, v24);
      }
    }
  }*/



  public unsafe void MAT_SetAnimPosition( name a2, int a3, name a4, float a5, bool a6, bool a7 ) => MAT_SetAnimPosition( a2, a3, a4, a5, a6 ? 1 : 0, a7 ? 1 : 0);
  public unsafe void MAT_SetAnimPosition(name a2, int a3, name a4, float a5, int a6, int a7)
  {
    int v7 = default; // edi
    AnimNodeSlot v8 = default; // esi
    TdAnimNodeSlot v9 = default; // eax
    TdAnimNodeSlot v10 = default; // ebp
    int v11 = default; // esi
    int v12 = default; // edi
    AnimNodeSequence v13 = default; // eax
    //TdPlayerPawn v14 = default; // [esp+1Ch] [ebp-8h]
    int i = default; // [esp+20h] [ebp-4h]
  
    v7 = default;
    for ( i = default; v7 < this.SlotNodes.Count; i = v7 )
    {
      v8 = this.SlotNodes[v7];
      if ( v8 && v8.NodeName == a2 )
      {
        v8.MAT_SetAnimPosition( a3, a4, a5, a6.AsBool(), a7.AsBool());// MAT_SetAnimPosition
        v9 = E_TryCastTo<TdAnimNodeSlot>(v8);
        v10 = v9;
        if(v9 != default)
        {
          v11 = v9.Children.Count - 1;
          if ( v11 > 0 )
          {
            v12 = v11 << 6;
            do
            {
              v13 = E_TryCastTo<AnimNodeSequence>(v10.Children[v11].Anim/**(AnimNode *)((byte *)&v10.Children[0].Anim + v12)*/);
              if(v13 != default)
              {
                v13.RootBoneOption[0] = RBA_Translate;
                v13.RootBoneOption[1] = RBA_Translate;
                v13.RootBoneOption[2] = RBA_Translate;
                v13.RootRotationOption[0] = RRO_Extract;
                v13.RootRotationOption[1] = RRO_Extract;
                v13.RootRotationOption[2] = RRO_Extract;
              }
              --v11;
              v12 = v12 - (64);
            }
            while ( v11 > 0 );
            v7 = i;
          }
        }
      }
      ++v7;
    }
  }

  // NOT READY
  public unsafe void MAT_FinishAnimControl(){ NativeMarkers.MarkUnimplemented(); }
//public unsafe void MAT_FinishAnimControl()
//  {
//    int i = default; // edi
//    bool v3 = default; // zf
//    AnimNodeSlot *v4; // edi
//    void *v5; // ecx
//  
//    if(this != default)
//    {
//      for ( i = default; i < this.SlotNodes.Count; ++i )
//        this.SlotNodes[i].SetActiveChild(0, 0.1f);
//      v3 = this.SlotNodes.Max == 0;
//      this.SlotNodes.Count = default;
//      if ( !v3 )
//      {
//        v4 = this.SlotNodes.Data;
//        this.SlotNodes.Max = default;
//        if(v4 != default)
//        {
//          v5 = dword_2018708;
//          if ( !dword_2018708 )
//          {
//            GCreateMalloc_Prob();
//            v5 = dword_2018708;
//          }
//          this.SlotNodes.Data = (AnimNodeSlot *__ptr32)(*(int (__thiscall **)(void *, AnimNodeSlot *__ptr32, _DWORD, int))(*(_DWORD *)v5 + 8))(v5, v4, 0, 8);
//        }
//      }
//    }
//  }
//
  static int dword_205684C;
  public override unsafe void physFalling(float DeltaTime, int Iterations)
  {
    Controller v4 = default; // ecx
    SkeletalMeshComponent Mesh = default; // eax
    bool bDoRootMotionVelocity = default; // ecx
    bool bDoRootMotionAccel = default; // edx
    float DeltaTime2 = default; // xmm7_4
    int bDoRootMotion = default; // ecx
    float v10 = default; // edx
    float v11 = default; // eax
    float v12 = default; // xmm2_4
    float v13 = default; // xmm0_4
    float v14 = default; // edx
    float TickAirControl = default; // xmm5_4
    float v16 = default; // edx
    float v17 = default; // eax
    float nrml_AccelerationX = default; // xmm1_4
    float nrml_AccelerationY = default; // xmm2_4
    float v20 = default; // xmm0_4
    float AccelRate_x_TickAirControl = default; // xmm0_4
    float v22 = default; // xmm2_4
    float TestWalkX = default; // xmm0_4
    float TestWalkY = default; // xmm1_4
    PrimitiveComponent v25 = default; // eax
    float v26 = default; // xmm3_4
    float v27 = default; // xmm4_4
    //Vector *ColLocation; // eax
    float ColLocationX = default; // ecx
    float ColLocationY = default; // edx
    float ColLocationZ = default; // eax
    CylinderComponent v32 = default; // eax
    float v33 = default; // xmm4_4
    float v34 = default; // eax
    float maxAccel = default; // xmm6_4
    double speed2d = default; // st7
    float v37 = default; // xmm0_4
    float v38 = default; // eax
    float v39 = default; // ecx
    float v40 = default; // xmm0_4
    float v41 = default; // xmm1_4
    float v42 = default; // xmm2_4
    float v43 = default; // eax
    float v44 = default; // ecx
    Controller v45 = default; // ecx
    float remainingTime = default; // xmm0_4
    float timeTick2 = default; // xmm1_4
    float v48 = default; // edx
    float v49 = default; // ecx
    float v50 = default; // eax
    float v51 = default; // xmm2_4
    float v52 = default; // xmm0_4
    int v53 = default; // edx
    float v54 = default; // xmm1_4
    float v55 = default; // xmm0_4
    // double (__thiscall *v56)(TdPlayerPawn ); // eax
    float v57 = default; // xmm2_4
    uint v58 = default; // xmm0_4
    float v59 = default; // ebx
    Controller v60 = default; // eax
    int v61 = default; // edi
    float v62 = default; // xmm6_4
    float v63 = default; // ecx
    float v64 = default; // edx
    float v65 = default; // xmm0_4
    float v66 = default; // xmm1_4
    float v67 = default; // xmm2_4
    float v68 = default; // xmm0_4
    float v69 = default; // xmm0_4
    float v70 = default; // xmm0_4
    PhysicsVolume v71 = default; // eax
    float v72 = default; // xmm0_4
    float v73 = default; // xmm1_4
    float v74 = default; // xmm2_4
    float v75 = default; // xmm0_4
    uint v76 = default; // ecx
    uint v77 = default; // edx
    uint v78 = default; // eax
    EMovement v79 = default; // al
    float v80 = default; // xmm4_4
    float v81 = default; // xmm0_4
    float v82 = default; // xmm1_4
    float v83 = default; // xmm0_4
    float v84 = default; // xmm1_4
    float v85 = default; // xmm0_4
    float v86 = default; // xmm1_4
    Controller v87 = default; // ecx
    CylinderComponent v88 = default; // eax
    float v89 = default; // xmm4_4
    float v90 = default; // xmm1_4
    float v91 = default; // xmm0_4
    int v92 = default; // ebp
    uint v93 = default; // ebx
    bool bForceRMVelocity_False = default; // zf
    uint v95 = default; // edi
    float v96 = default; // xmm1_4
    float v97 = default; // xmm3_4
    float v98 = default; // xmm0_4
    //Rotator *v99; // ebx
    int v100 = default; // edi
    float v101 = default; // xmm0_4
    float v102 = default; // xmm0_4
    float v103 = default; // xmm2_4
    float v104 = default; // xmm1_4
    float v105 = default; // xmm2_4
    float v106 = default; // xmm0_4
    uint v107 = default; // ecx
    uint v108 = default; // edx
    uint v109 = default; // eax
    EMovement v110 = default; // al
    float v111 = default; // xmm0_4
    float v112 = default; // xmm0_4
    float v113 = default; // xmm0_4
    float v114 = default; // xmm0_4
    bool v115 = default; // edi
    float v116 = default; // xmm4_4
    float v117 = default; // xmm1_4
    float v118 = default; // xmm2_4
    float v119 = default; // xmm3_4
    float v120 = default; // xmm4_4
    float v121 = default; // xmm0_4
    float v122 = default; // edx
    float v123 = default; // xmm2_4
    float v124 = default; // xmm1_4
    float v125 = default; // xmm2_4
    // double (__thiscall *v126)(TdPlayerPawn ); // eax
    float v127 = default; // xmm0_4
    float v128 = default; // edx
    float v129 = default; // eax
    float v130 = default; // xmm0_4
    float v131 = default; // xmm0_4
    float v132 = default; // xmm2_4
    float v133 = default; // edx
    float v134 = default; // eax
    int v135 = default; // edx
    double v136 = default; // st7
    Controller v137 = default; // ecx
    float v138 = default; // ecx
    float v139 = default; // edx
    Vector timeTick = default; // [esp+5Ch] [ebp-2B4h]
    Vector timeTick_8 = default; // [esp+64h] [ebp-2ACh]
    Vector v142 = default; // [esp+88h] [ebp-288h] BYREF
    Vector v143 = default; // [esp+94h] [ebp-27Ch] BYREF
    float v144 = default; // [esp+A0h] [ebp-270h]
    Vector v145 = default; // [esp+A4h] [ebp-26Ch] BYREF
    float speed2d2 = default; // [esp+B0h] [ebp-260h]
    Vector a4 = default; // [esp+B4h] [ebp-25Ch] BYREF
    float v148 = default; // [esp+C0h] [ebp-250h] BYREF
    float v149 = default; // [esp+C4h] [ebp-24Ch]
    float v150 = default; // [esp+C8h] [ebp-248h]
    float v151 = default; // [esp+CCh] [ebp-244h]
    Vector v152 = default; // [esp+D0h] [ebp-240h] BYREF
    float v153 = default; // [esp+DCh] [ebp-234h]
    Vector ColLocation2 = default; // [esp+E0h] [ebp-230h] BYREF
    Vector v155 = default; // [esp+ECh] [ebp-224h]
    CheckResult Hit = default; // [esp+F8h] [ebp-218h] BYREF
    int v157 = default; // [esp+140h] [ebp-1D0h]
    Vector v158 = default; // [esp+144h] [ebp-1CCh]
    int v159 = default; // [esp+150h] [ebp-1C0h]
    float v160 = default; // [esp+154h] [ebp-1BCh]
    float v161 = default; // [esp+158h] [ebp-1B8h]
    int bDoRootMotion2 = default; // [esp+15Ch] [ebp-1B4h]
    float v163 = default; // [esp+160h] [ebp-1B0h]
    float v164 = default; // [esp+164h] [ebp-1ACh]
    float v165 = default; // [esp+168h] [ebp-1A8h]
    float v166 = default; // [esp+16Ch] [ebp-1A4h]
    float v167 = default; // [esp+170h] [ebp-1A0h]
    float v168 = default; // [esp+174h] [ebp-19Ch]
    Vector v169 = default; // [esp+178h] [ebp-198h] BYREF
    float BoundSpeed = default; // [esp+184h] [ebp-18Ch]
    float v171 = default; // [esp+188h] [ebp-188h]
    float v172 = default; // [esp+18Ch] [ebp-184h]
    float v173 = default; // [esp+190h] [ebp-180h]
    float v174 = default; // [esp+194h] [ebp-17Ch]
    float v175 = default; // [esp+198h] [ebp-178h]
    float v176 = default; // [esp+19Ch] [ebp-174h]
    float v177 = default; // [esp+1A0h] [ebp-170h]
    int v178 = default; // [esp+1A4h] [ebp-16Ch]
    float v179 = default; // [esp+1A8h] [ebp-168h]
    float v180 = default; // [esp+1ACh] [ebp-164h]
    float v181 = default; // [esp+1B0h] [ebp-160h]
    float v182 = default; // [esp+1B4h] [ebp-15Ch]
    Vector a2 = default; // [esp+1B8h] [ebp-158h] BYREF
    float v184 = default; // [esp+1C4h] [ebp-14Ch]
    float v185 = default; // [esp+1C8h] [ebp-148h]
    float v186 = default; // [esp+1CCh] [ebp-144h]
    float v187 = default; // [esp+1D0h] [ebp-140h]
    int v188 = default; // [esp+1D4h] [ebp-13Ch]
    float* v189 = stackalloc float[3]; // [esp+1D8h] [ebp-138h]
    float v190 = default; // [esp+1E4h] [ebp-12Ch]
    float v191 = default; // [esp+1E8h] [ebp-128h]
    float v192 = default; // [esp+1ECh] [ebp-124h]
    int v193 = default; // [esp+1F0h] [ebp-120h]
    float v194 = default; // [esp+1F4h] [ebp-11Ch]
    Vector v195 = default; // [esp+204h] [ebp-10Ch] BYREF
    float v196 = default; // [esp+214h] [ebp-FCh]
    Vector a3 = default; // [esp+224h] [ebp-ECh] BYREF
    Vector v198 = default; // [esp+230h] [ebp-E0h] BYREF
    Vector v199 = default; // [esp+23Ch] [ebp-D4h] BYREF
    Vector v200 = default; // [esp+248h] [ebp-C8h] BYREF
    Vector v201 = default; // [esp+254h] [ebp-BCh]
    //int *v202; // [esp+260h] [ebp-B0h]
    float v203 = default; // [esp+264h] [ebp-ACh]
    float v204 = default; // [esp+274h] [ebp-9Ch]
    float v205 = default; // [esp+284h] [ebp-8Ch]
    float v206 = default; // [esp+294h] [ebp-7Ch]
    int v207 = default; // [esp+2A4h] [ebp-6Ch]
    int v208 = default; // [esp+2B4h] [ebp-5Ch]
    int v209 = default; // [esp+2C4h] [ebp-4Ch]
    float v210 = default; // [esp+2D4h] [ebp-3Ch]
    float v211 = default; // [esp+2E4h] [ebp-2Ch]
    int v212 = default; // [esp+2F4h] [ebp-1Ch]
    int v213 = default; // [esp+30Ch] [ebp-4h]
  
    v4 = this.Controller;
    BoundSpeed = 0.0f;
    if(v4 != default)
      v4.PreAirSteering(DeltaTime);// PreAirSteering
    Mesh = this.Mesh;
    bDoRootMotionVelocity = Mesh && Mesh.RootMotionMode == RMM_Velocity && Mesh.PreviousRMM != RMM_Ignore && (this.bIsFemale.AsBitfield(20) & 0x40000) == 0;
    bDoRootMotionAccel = Mesh && Mesh.RootMotionMode == RMM_Accel && Mesh.PreviousRMM != RMM_Ignore && (this.bIsFemale.AsBitfield(20) & 0x40000) == 0;
    DeltaTime2 = DeltaTime;
    if ( bDoRootMotionVelocity || bDoRootMotionAccel )
    {
      bForceRMVelocity_False = (this.bIsFemale.AsBitfield(20) & 0x20000) == 0;
      bDoRootMotion = 1;
      bDoRootMotion2 = 1;
      if(bForceRMVelocity_False != default)
      {
        v143 = this.Velocity;
        v145 = Mesh.RootMotionDelta.Translation;
        if(bDoRootMotionAccel != default)
        {
          v12 = v145.Y;
          this.Velocity.X = v145.X * (float)(1.0f / DeltaTime);
          this.Velocity.Y = v12 * (float)(1.0f / DeltaTime);
          v145.X = 0.0f;
          this.Acceleration.X = 0.0f;
          v13 = v143.Z;
          v145.Y = 0.0f;
          this.Acceleration.Y = 0.0f;
          v145.Z = 0.0f;
          this.Velocity.Z = v13;
          this.Acceleration.Z = 0.0f;
          this.RMVelocity = this.Velocity;
        }
        v145.X = 0.0f;
        Mesh.RootMotionDelta.Translation.X = 0.0f;
        v145.Y = 0.0f;
        Mesh.RootMotionDelta.Translation.Y = 0.0f;
        v145.Z = 0.0f;
        Mesh.RootMotionDelta.Translation.Z = 0.0f;
      }
      else
      {
        v10 = this.RMVelocity.Y;
        this.Velocity.X = this.RMVelocity.X;
        v11 = this.RMVelocity.Z;
        this.Velocity.Y = v10;
        this.Velocity.Z = v11;
      }
    }
    else
    {
      bDoRootMotion = default;
      bDoRootMotion2 = default;
    }
    v14 = this.Acceleration.Y;
    v148 = this.Acceleration.X;
    v150 = this.Acceleration.Z;
    Hit.Time = 1.0f;
    TickAirControl = this.AirControl;
    v149 = v14;
    Hit.Next = default;
    Hit.Actor = default;
    Hit.Location.X = 0.0f;
    Hit.Location.Y = 0.0f;
    Hit.Location.Z = 0.0f;
    Hit.Normal = default;
    Hit.Item = -1;
    Hit.Material = default;
    Hit.PhysMaterial = default;
    Hit.Component = default;
    Hit.BoneName = default;
    Hit.Level = default;
    Hit.LevelIndex = -1;
    Hit.bStartPenetrating = default;
    v157 = default;
    v160 = TickAirControl;
    this.Acceleration.Z = 0.0f;
    if ( !(bDoRootMotion.AsBool()) )
    {
      if ( TickAirControl > 0.050000001d )
      {
        v196 = (float)((float)(this.Acceleration.X * this.Acceleration.X) + (float)(this.Acceleration.Y * this.Acceleration.Y)) + (float)(0.0f * 0.0f);
        if ( v196 == 1.0f )
        {
          v16 = this.Acceleration.Y;
          v17 = this.Acceleration.Z;
          v143.X = this.Acceleration.X;
          nrml_AccelerationX = v143.X;
          v143.Y = v16;
          nrml_AccelerationY = v16;
          v143.Z = v17;
        }
        else if ( v196 >= SMALL_NUMBER )
        {
          v194 = 3.0f;
          v151 = 0.5f;
          v20 = fsqrt(v196);
          v195.X = (float)(3.0f - (float)((float)((float)(1.0f / v20) * v196) * (float)(1.0f / v20))) * (float)((float)(1.0f / v20) * 0.5f);
          nrml_AccelerationX = v195.X * this.Acceleration.X;
          nrml_AccelerationY = this.Acceleration.Y * v195.X;
        }
        else
        {
          nrml_AccelerationX = 0.0f;
          nrml_AccelerationY = 0.0f;
        }
        AccelRate_x_TickAirControl = this.AccelRate * TickAirControl;
        v22 = nrml_AccelerationY * AccelRate_x_TickAirControl;
        TestWalkX = (float)(this.Velocity.X + (float)(nrml_AccelerationX * AccelRate_x_TickAirControl)) * DeltaTime;
        TestWalkY = (float)(this.Velocity.Y + v22) * DeltaTime;
        if ( TestWalkX != 0.0f || TestWalkY != 0.0f )
        {
          v25 = this.CollisionComponent;
          if(v25 != default)
          {
            v26 = v25.Translation.Y + this.Location.Y;
            v27 = v25.Translation.Z + this.Location.Z;
            v143.X = this.Location.X + v25.Translation.X;
            v143.Y = v26;
            v143.Z = v27;
            //ColLocation = &v143;
            ColLocationX = v143.X;
            ColLocationY = v143.Y;
            ColLocationZ = v143.Z;
          }                     
          else
          {
            ColLocationX = this.Location.X;
            ColLocationY = this.Location.Y;
            ColLocationZ = this.Location.Z;
          }
          ColLocation2.X = ColLocationX;
          ColLocation2.Z = ColLocationZ;
          v32 = this.CylinderComponent;
          ColLocation2.Y = ColLocationY;
          v33 = v32.CollisionHeight;
          v143.Y = v32.CollisionRadius;
          v143.X = v143.Y;
          v143.Z = v33;
          v169.X = ColLocationX + TestWalkX;
          v169.Y = ColLocationY + TestWalkY;
          v169.Z = ColLocation2.Z;
          GWorld.SingleLineCheck(ref Hit, this, v169, ColLocation2, 8838, v143, 0);
          DeltaTime2 = DeltaTime;
          if ( Hit.Actor )
            TickAirControl = 0.0f;
          else
            TickAirControl = v160;
        }
      }
  
      v34 = this.Velocity.Y;
      v143.X = this.Velocity.X;
      v143.Y = v34;
      maxAccel = this.AccelRate * TickAirControl;
      v143.Z = this.Velocity.Z;
      speed2d = sqrt(v143.X * v143.X + v34 * v34);
      speed2d2 = (float)speed2d;
      if ( speed2d >= 10.0f || TickAirControl <= 0.0f )
      {
        if ( speed2d2 >= this.GroundSpeed )
        {
          if ( TickAirControl > 0.050000001d )
            BoundSpeed = speed2d2;
          else
            maxAccel = 1.0f;
        }
      }
      else
      {
        maxAccel = (float)((float)(10.0f - speed2d2) / DeltaTime2) + maxAccel;
      }
      if ( (float)((float)((float)(this.Acceleration.X * this.Acceleration.X) + (float)(this.Acceleration.Y * this.Acceleration.Y)) + (float)(this.Acceleration.Z * this.Acceleration.Z)) > (float)(maxAccel * maxAccel) )
      {
        v37 = (float)((float)(this.Acceleration.X * this.Acceleration.X) + (float)(this.Acceleration.Y * this.Acceleration.Y)) + (float)(this.Acceleration.Z * this.Acceleration.Z);
        v196 = v37;
        if ( v37 == 1.0f )
        {
          v38 = this.Acceleration.Y;
          v39 = this.Acceleration.Z;
          a4.X = this.Acceleration.X;
          a4.Y = v38;
          a4.Z = v39;
        }
        else if ( v37 >= SMALL_NUMBER )
        {
          v194 = 3.0f;
          v151 = 0.5f;
          v40 = fsqrt(v196);
          v195.X = (float)(3.0f - (float)((float)((float)(1.0f / v40) * v196) * (float)(1.0f / v40))) * (float)((float)(1.0f / v40) * 0.5f);
          v41 = this.Acceleration.Y * v195.X;
          v42 = this.Acceleration.Z * v195.X;
          a4.X = this.Acceleration.X * v195.X;
          a4.Y = v41;
          a4.Z = v42;
        }
        else
        {
          a4.X = 0.0f;
          a4.Y = 0.0f;
          a4.Z = 0.0f;
        }
        v43 = a4.Y;
        v44 = a4.Z;
        this.Acceleration.X = a4.X;
        this.Acceleration.Y = v43;
        this.Acceleration.Z = v44;
        this.Acceleration.X = this.Acceleration.X * maxAccel;
        this.Acceleration.Y = this.Acceleration.Y * maxAccel;
        this.Acceleration.Z = this.Acceleration.Z * maxAccel;
      }
    }                                             // Everything is the same as APawn::physFalling
    v45 = this.Controller;
    if(v45 != default)
    {
      v45.PostAirSteering((DeltaTime));// Probably PostAirSteering, nullsub 0xB976E0
      DeltaTime2 = DeltaTime;
    }
    remainingTime = DeltaTime2;
    if ( DeltaTime2 <= 0.0f )
      goto LABEL_190;
    while ( Iterations < 8 )
    {
      ++Iterations;
      timeTick2 = remainingTime;
      if ( remainingTime > 0.050000001d )
      {
        timeTick2 = remainingTime * 0.5f;
        if ( (float)(remainingTime * 0.5f) >= 0.050000001d )
          timeTick2 = (float)(0.050000001d);
      }
      v48 = this.Location.Y;
      v49 = this.Location.X;
      v50 = this.Location.Z;
      SetFromBitfield(ref this.bCollideComplex, 20, this.bCollideComplex.AsBitfield(20) & (0xFFFFFEFF));
      v51 = this.Velocity.Z;
      v52 = remainingTime - timeTick2;
      *(_QWORD *)&v158.Y = __PAIR64__(LODWORD(v50), LODWORD(v48));
      v53 = this.VfTableObject.Dummy;
      v144 = timeTick2;
      v54 = this.Velocity.Y;
      v153 = v52;
      v55 = this.Velocity.X;
      v158.X = v49;
      // v56 = *(double (__thiscall **)(TdPlayerPawn ))(v53 + 308);
      v155.X = v55;
      *(_QWORD *)&v155.Y = __PAIR64__(LODWORD(v51), LODWORD(v54));
      speed2d2 = this.GetGravityZ();
      v57 = this.Acceleration.Y;
      *(float *)&v58 = this.Acceleration.Z + speed2d2;
      v59 = v155.X;
      v172 = this.Acceleration.X;
      timeTick_8.X = v172;
      v173 = v57;
      *(_QWORD *)&timeTick_8.Y = __PAIR64__((int)v58, (int)LODWORD(v57));
      v174 = *(float *)&v58;
      v195 = NewFallVelocity(v155, timeTick_8, v144);
      this.Velocity = v195;
      v60 = this.Controller;
      v61 = default;
      if ( v60 && SLOBYTE(v60.bIsPlayer.AsBitfield(20)) < 0 && this.Velocity.Z <= 0.0f )
      {
        SetFromBitfield(ref this.bCollideComplex, 20, this.bCollideComplex.AsBitfield(20) | (0x100u));
        SetFromBitfield(ref v60.bIsPlayer, 20, v60.bIsPlayer.AsBitfield(20) & (0xFFFFFF7F));
        this.Controller.NotifyJumpApex();// NotifyJumpApex
      }
      if ( !(bDoRootMotion2.AsBool()) )
      {
        v62 = BoundSpeed;
        if ( BoundSpeed != 0.0f )
        {
          v63 = this.Velocity.X;
          v64 = this.Velocity.Y;
          v166 = v63;
          v167 = v64;
          v65 = (float)(v166 * v166) + (float)(v64 * v64);
          v168 = 0.0f;
          if ( v65 > (float)(BoundSpeed * BoundSpeed) )
          {
            v205 = (float)(v166 * v166) + (float)(v64 * v64);
            if ( v65 == 1.0f )
            {
              v175 = v63;
              v66 = v63;
              v176 = v64;
              v67 = v64;
              v177 = v168;
              v68 = v168;
            }
            else if ( v65 >= SMALL_NUMBER )
            {
              v212 = 1077936128;
              v189[2] = 0.5f;
              v69 = fsqrt(v205);
              v204 = (float)(3.0f - (float)((float)((float)(1.0f / v69) * v205) * (float)(1.0f / v69))) * (float)((float)(1.0f / v69) * 0.5f);
              v66 = v204 * v166;
              v67 = v64 * v204;
              v68 = v204 * 0.0f;
            }
            else
            {
              v66 = 0.0f;
              v67 = 0.0f;
              v68 = 0.0f;
            }
            v181 = v68 * BoundSpeed;
            v70 = this.Velocity.Z;
            v179 = v66 * BoundSpeed;
            this.Velocity.X = v66 * BoundSpeed;
            v180 = v67 * v62;
            v168 = v70;
            this.Velocity.Y = v67 * v62;
            this.Velocity.Z = v70;
          }
        }
      }
      v71 = this.PhysicsVolume;
      v72 = v71.ZoneVelocity.X + this.Velocity.X;
      v73 = v71.ZoneVelocity.Y + this.Velocity.Y;
      v74 = v71.ZoneVelocity.Z + this.Velocity.Z;// Here's where it starts to differ
      ++dword_205684C;
      v142.X = v72 * v144;
      v142.Y = v73 * v144;
      v142.Z = v74 * v144;
      //v202 = &dword_205684C;
      v213 = default;
      v159 = default;
      speed2d2 = 0.0f;
      do
      {
        GWorld.MoveActor(this, ref v142, ref this.Rotation, 4u, ref Hit);
        if( ( this.bExludeHandMoves.AsBitfield( 32 ) & 0x40 ) != default )
        {
          --dword_205684C;
          return;
        }

        if ( this.Physics == PHYS_Swimming )
        {
          timeTick.X = v59;
          *(_QWORD *)&timeTick.Y = *(_QWORD *)&v155.Y;
          this.startSwimming(v158, timeTick, v144, (float)((float)(1.0f - Hit.Time) * v144) + v153, Iterations);
  LABEL_194:
          --dword_205684C;
          return;
        }
        if ( Hit.Time < 1.0f )
        {
          if ( Hit.Normal.Z < this.WalkableFloorZ )
          {
            if ( v148 != 0.0f || v149 != 0.0f || v150 != 0.0f || (v87 = this.Controller) == default || !v87.AirControlFromWall(((v144)), ref *(Vector*)&v148) )// AirControlFromWall
            {
              this.processHitWall(
                Hit.Normal,
                Hit.Actor,
                Hit.Component);
              if( ( this.bExludeHandMoves.AsBitfield( 32 ) & 0x40 ) != default || this.Physics != PHYS_Falling )
              {
                --dword_205684C;
                return;
              }
            }
            if ( (float)(-0.0f - this.WalkableFloorZ) >= Hit.Normal.Z && this.Velocity.Z > 0.0f )
            {
              v88 = this.CylinderComponent;
              v89 = this.Location.Y;
              v90 = this.Location.Z + (float)(v88.CollisionHeight + 1.0f);
              a2.X = this.Location.X;
              a2.Y = v89;
              a2.Z = v90;
              v91 = v88.CollisionRadius + 1.0f;
              v92 = default;
              v160 = v91;
              a4.X = 0.0f;
              a4.Y = 0.0f;
              a4.Z = 0.0f;
              v189[0] = -0.0f - v91;
              v189[1] = v91;
              v93 = default;
              while(1 != default)
              {
                bForceRMVelocity_False = v92 == 0;
                if(v92 != default)
                  break;
                v95 = default;
                a3.Z = 0.0f;
                do
                {
                  v96 = v189[v95 >> 1];
                  a3.X = v189[v95 & 1];
                  a3.Y = v96;
                  ++v95;
                  v92 = v92 + (OnWalkableFloor_orsomething(ref a2, ref a3, ref a4).AsInt());
                }
                while ( v95 < 4 );
                ++v93;
                a2.Z = a2.Z + 4.0f;
                *(float *)&v91 = v160;
                if ( v93 >= 2 )
                {
                  bForceRMVelocity_False = v92 == 0;
                  break;
                }
              }
              if ( !bForceRMVelocity_False )
              {
                v191 = (float)((float)(a4.Z * a4.Z) + (float)(a4.Y * a4.Y)) + (float)(a4.X * a4.X);
                if ( (float)(*(float *)&v91 * *(float *)&v91) >= v191 )
                {
                  v97 = 5.0f;
                  v161 = (float)(sqrt(v191));
                  v98 = *(float *)&v91 - v161;
                  if ( v98 < 5.0f )
                    v97 = v98;
                  a4.X = (float)((float)(a4.X * v97) * (float)(1.0f / v161)) + a4.X;
                  a4.Y = a4.Y + (float)((float)(a4.Y * v97) * (float)(1.0f / v161));
                  a4.Z = a4.Z + (float)((float)(a4.Z * v97) * (float)(1.0f / v161));
                  GWorld.MoveActor(this, ref a4, ref this.Rotation, 0, ref Hit);
                  if ( Hit.Time >= 1.0f || Hit.Time < 0.0f )
                  {
                    SetFromBitfield(ref this.bCollideComplex, 20, this.bCollideComplex.AsBitfield(20) | (0x100u));
                  }
                  else
                  {
                    v198.X = (float)(-0.0f - a4.X) * Hit.Time;
                    v198.Y = (float)(-0.0f - a4.Y) * Hit.Time;
                    v198.Z = (float)(-0.0f - a4.Z) * Hit.Time;
                    GWorld.MoveActor(this, ref v198, ref this.Rotation, 0, ref Hit);
                  }
                }
              }
            }
            v145 = Hit.Normal;
            v152 = this.CalculateSlopeSlide( ref v142, ref Hit);// CalculateSlopeSlide
            if( (float) ( (float) ( (float) ( v152.Z * v142.Z ) + (float) ( v152.Y * v142.Y ) ) + (float) ( v152.X * v142.X ) ) < 0.0f )
            {
              v61 = v159;
              v116 = (float)(1.0f / v144) * (float)(this.Location.X - v158.X);
              v117 = (float)(1.0f / v144) * (float)(this.Location.Y - v158.Y);
              v187 = (float)(1.0f / v144) * (float)(this.Location.Z - v158.Z);
              v185 = v116;
              v59 = v116;
              v186 = v117;
              v155.X = v116;
              v155.Y = v117;
              goto LABEL_172;
            }

            v192 = this.Location.X + v152.X;
            //v99 = ref this.Rotation;
            v182 = this.Location.Y + v152.Y;
            v190 = this.Location.Z + v152.Z;
            GWorld.MoveActor(this, ref v152, ref this.Rotation, 0, ref Hit);
            v100 = default;
            v101 = (float)((float)(v152.Y * v152.Y) + (float)(v152.X * v152.X)) + (float)(v152.Z * v152.Z);
            v211 = v101;
            if ( v101 == 1.0f )
            {
              v201 = v152;
              v102 = v152.Z;
            }
            else if ( v101 >= SMALL_NUMBER )
            {
              v207 = 1077936128;
              v178 = 1056964608;
              v103 = 1.0f / fsqrt(v211);
              v203 = (float)(3.0f - (float)((float)(v103 * v211) * v103)) * (float)(v103 * 0.5f);
              v102 = v203 * v152.Z;
            }
            else
            {
              v102 = 0.0f;
            }
            if ( (float)(this.WalkableFloorZ - 1.0f) > v102 )
            {
              if ( Hit.Time < 1.0f )
              {
                v104 = v182 - this.Location.Y;
                v105 = (float)(v190 + 1.9f) - this.Location.Z;
                //v99 = ref this.Rotation;
                v100 = 1;
                v200.X = v192 - this.Location.X;
                v200.Y = v104;
                v200.Z = v105;
                GWorld.MoveActor(this, ref v200, ref this.Rotation, 0, ref Hit);
                goto LABEL_131;
              }
  LABEL_171:
              v61 = v159;
              v116 = (float)(1.0f / v144) * (float)(this.Location.X - v158.X);
              v117 = (float)(1.0f / v144) * (float)(this.Location.Y - v158.Y);
              v187 = (float)(1.0f / v144) * (float)(this.Location.Z - v158.Z);
              v185 = v116;
              v59 = v116;
              v186 = v117;
              v155.X = v116;
              v155.Y = v117;
              goto LABEL_172;
            }
  LABEL_131:
            if ( Hit.Time >= 1.0f )
            {
              if(v100 != default)
              {
                v199.X = 0.0f;
                v199.Y = 0.0f;
                v199.Z = -1.9f;
                GWorld.MoveActor(this, ref v199, ref this.Rotation, 0, ref Hit);
              }
              v61 = v159;
              v116 = (float)(1.0f / v144) * (float)(this.Location.X - v158.X);
              v117 = (float)(1.0f / v144) * (float)(this.Location.Y - v158.Y);
              v187 = (float)(1.0f / v144) * (float)(this.Location.Z - v158.Z);
              v185 = v116;
              v59 = v116;
              v186 = v117;
              v155.X = v116;
              v155.Y = v117;
              goto LABEL_172;
            }
            if ( Hit.Normal.Z < this.WalkableFloorZ )
            {
              this.processHitWall(
                Hit.Normal,
                Hit.Actor,
                Hit.Component);
              if( ( this.bExludeHandMoves.AsBitfield( 32 ) & 0x40 ) != default || this.Physics != PHYS_Falling )
              {
                --dword_205684C;
                return;
              }

              v112 = (float)((float)(v142.X * v142.X) + (float)(v142.Z * v142.Z)) + (float)(v142.Y * v142.Y);
              v206 = v112;
              if ( v112 == 1.0f )
              {
                ColLocation2 = v142;
              }
              else
              {
                if ( v112 >= SMALL_NUMBER )
                {
                  v209 = 1077936128;
                  v188 = 1056964608;
                  v114 = fsqrt(v206);
                  v196 = (float)(3.0f - (float)((float)((float)(1.0f / v114) * v206) * (float)(1.0f / v114))) * (float)((float)(1.0f / v114) * 0.5f);
                  v113 = v196 * v142.Z;
                  ColLocation2.X = v196 * v142.X;
                  ColLocation2.Y = v142.Y * v196;
                }
                else
                {
                  v113 = 0.0f;
                  ColLocation2.X = 0.0f;
                  ColLocation2.Y = 0.0f;
                }
                ColLocation2.Z = v113;
              }
              TwoWallAdjust(ColLocation2, ref v152, Hit.Normal, v145, Hit.Time);
              v115 = v145.Z > 0.0f && Hit.Normal.Z > 0.0f && v152.Z == 0.0f && (float)((float)((float)(v145.Z * Hit.Normal.Z) + (float)(Hit.Normal.Y * v145.Y)) + (float)(v145.X * Hit.Normal.X)) < 0.0f;
              GWorld.MoveActor(this, ref v152, ref this.Rotation, 0, ref Hit);
              if ( v115 || Hit.Normal.Z >= this.WalkableFloorZ )
              {
  LABEL_147:
                this.processLanded(
                  Hit.Normal,
                  Hit.Actor,
                  0.0f,
                  Iterations);
  LABEL_148:
                --dword_205684C;
                return;
              }
              v61 = v159;
              v116 = (float)(1.0f / v144) * (float)(this.Location.X - v158.X);
              v117 = (float)(1.0f / v144) * (float)(this.Location.Y - v158.Y);
              v187 = (float)(1.0f / v144) * (float)(this.Location.Z - v158.Z);
              v185 = v116;
              v59 = v116;
              v186 = v117;
              v155.X = v116;
              v155.Y = v117;
              goto LABEL_172;
            }
            v184 = Hit.Time;
            /*if ( !Class_TdMove_Landing )
            {
              Class_TdMove_Landing = (Object )sub_1200C80((int)L"TdGame");
              sub_1201580();
            }*/
            v106 = ClassT<TdMove_Landing>().DefaultAs<TdMove_Landing>().HardLandingHeight;//(Class .GetDefaultObject()Class_TdMove_Landing, 0)[5].Class;
            v107 = default;
            v108 = default;
            if ( Hit.Actor )
            {
              v107 = (Hit.Actor.bExludeHandMoves.AsBitfield(32) >> 1) & 1;
              v108 = Hit.Actor.bExludeHandMoves.AsBitfield(32) & 1;
            }
            if ( Hit.Component )
            {
              v109 = Hit.Component.bUseViewOwnerDepthPriorityGroup.AsBitfield(21);
              v107 = v107 | ((v109 >> 9) & 1);
              v108 = v108 | ((v109 >> 8) & 1);
            }
            v110 = this.MovementState;
            if ( v110 != MOVE_FallingUncontrolled )
            {
              if ( (float)(this.EnterFallingHeight - this.Location.Z) > v106 || (v108 & v107) != default || v110 == MOVE_180TurnInAir )
              {
                if ( v142.Z != 0.0f
                  && !this.CheckValidFloor(
                        v142,
                        Hit.Normal,
                        1) )
                {
                  this.SetTimer(0.2f, false, "SlideOffLedge", this);
                  v111 = 1.0f - v184;
                  SetFromBitfield(ref this.bCollideComplex, 20, this.bCollideComplex.AsBitfield(20) | (0x100u));
                  v142.X = v111 * v142.X;
                  v142.Y = v142.Y * v111;
                  v142.Z = v111 * v142.Z;
                  v159 = 1;
                  v61 = v159;
                  v116 = (float)(1.0f / v144) * (float)(this.Location.X - v158.X);
                  v117 = (float)(1.0f / v144) * (float)(this.Location.Y - v158.Y);
                  v187 = (float)(1.0f / v144) * (float)(this.Location.Z - v158.Z);
                  v185 = v116;
                  v59 = v116;
                  v186 = v117;
                  v155.X = v116;
                  v155.Y = v117;
                  goto LABEL_172;
                }
              }
              else if ( v142.Z != 0.0f
                     && !this.CheckValidFloor(
                           v142,
                           Hit.Normal,
                           0) )
              {
                this.SetTimer(0.2f, false, "SlideOffLedge", this);
              }
            }

            if( ! (v159.AsBool()) )
            {
              this.processLanded(
                Hit.Normal,
                Hit.Actor,
                0.0f,
                Iterations);
              LABEL_148:
              --dword_205684C;
              return;
            }

            v61 = v159;
            v116 = (float)(1.0f / v144) * (float)(this.Location.X - v158.X);
            v117 = (float)(1.0f / v144) * (float)(this.Location.Y - v158.Y);
            v187 = (float)(1.0f / v144) * (float)(this.Location.Z - v158.Z);
            v185 = v116;
            v59 = v116;
            v186 = v117;
            v155.X = v116;
            v155.Y = v117;
            goto LABEL_172;
          }
          v151 = Hit.Time;
          /*if ( !Class_TdMove_Landing )
          {
            Class_TdMove_Landing = (Object )sub_1200C80((int)L"TdGame");
            sub_1201580();
          }*/
          v75 = ClassT<TdMove_Landing>().DefaultAs<TdMove_Landing>().HardLandingHeight;
          v76 = default;
          v77 = default;
          if ( Hit.Actor )
          {
            v76 = (Hit.Actor.bExludeHandMoves.AsBitfield(32) >> 1) & 1;
            v77 = Hit.Actor.bExludeHandMoves.AsBitfield(32) & 1;
          }
          if ( Hit.Component )
          {
            v78 = Hit.Component.bUseViewOwnerDepthPriorityGroup.AsBitfield(21);
            v76 = v76 | ((v78 >> 9) & 1);
            v77 = v77 | ((v78 >> 8) & 1);
          }
          v79 = this.MovementState;
          if ( v79 != MOVE_FallingUncontrolled )
          {
            if ( (float)(this.EnterFallingHeight - this.Location.Z) > *(float *)&v75 || (v77 & v76) != default || v79 == MOVE_180TurnInAir )
            {
              if ( v142.Z != 0.0f
                && !this.CheckValidFloor(
                      v142,
                      Hit.Normal,
                      1) )
              {
                this.SetTimer(0.2f, false, "SlideOffLedge", this);// FuncName = SlideOffLedge
                v85 = 1.0f - v151;
                v86 = v142.X;
                SetFromBitfield(ref this.bCollideComplex, 20, this.bCollideComplex.AsBitfield(20) | (0x100u));
                v142.X = v86 * v85;
                v61 = 1;
                v142.Y = v142.Y * v85;
                v142.Z = v85 * v142.Z;
                v159 = 1;
                goto LABEL_172;
              }
            }
            else if ( v142.Z != 0.0f
                   && !this.CheckValidFloor(
                         v142,
                         Hit.Normal,
                         0) )                     // CheckValidFloor
            {
              this.SetTimer(0.2f, false, "SlideOffLedge", this);// FuncName = SlideOffLedge
            }
          }
          if ( !(v61.AsBool()) )
          {
            bForceRMVelocity_False = (this.bCollideComplex.AsBitfield(20) & 0x100) == 0;
            v153 = (float)((float)(1.0f - v151) * v144) + v153;
            if ( bForceRMVelocity_False && v151 > 0.1f )
            {
              v80 = v151 * v144;
              if ( (float)(v151 * v144) > 0.003f )
              {
                v81 = this.Location.Y;
                v82 = this.Location.Z;
                v143.X = (float)(1.0f / v80) * (float)(this.Location.X - v158.X);
                v83 = (float)(v81 - v158.Y) * (float)(1.0f / v80);
                v143.Y = v83;
                v84 = (float)(v82 - v158.Z) * (float)(1.0f / v80);
                v143.Z = v84;
                this.Velocity.X = v143.X;
                this.Velocity.Y = v83;
                this.Velocity.Z = v84;
              }
            }
            this.CheckForUncontrolledSlide(ref Hit);
            this.processLanded(
              Hit.Normal,
              Hit.Actor,
              ((v153)),
              Iterations);                        // processLanded
            --dword_205684C;
            return;
          }
        }
  LABEL_172:
        uint dsfsf = (*(uint*) & speed2d2) + 1;
        speed2d2 = * (float*) ( & dsfsf );
      }
      while ( v61.AsBool() && SLODWORD(speed2d2) < 2 && dword_205684C < 2 );
      if ( !(bDoRootMotion2.AsBool()) && (this.bCollideComplex.AsBitfield(20) & 0x100) == default && this.Physics.AsBool() )
      {
        v118 = this.Location.Y - v158.Y;
        v119 = this.Location.Z - v158.Z;
        v169.X = (float)(1.0f / v144) * (float)(this.Location.X - v158.X);
        v120 = v155.Z;
        v121 = (float)(1.0f / v144) * v119;
        v169.Y = (float)(1.0f / v144) * v118;
        v122 = v169.Y;
        this.Velocity.X = v169.X;
        v169.Z = v121;
        this.Velocity.Y = v122;
        this.Velocity.Z = v121;
        if ( v120 > this.Velocity.Z || v120 >= 0.0f )
        {
          v123 = this.Velocity.Z;
          v124 = (float)(this.Velocity.Y * 2.0f) - v155.Y;
          v143.X = (float)(this.Velocity.X * 2.0f) - v155.X;
          v125 = (float)(v123 * 2.0f) - v120;
          v143.Y = v124;
          v143.Z = v125;
          this.Velocity.X = v143.X;
          this.Velocity.Y = v124;
          this.Velocity.Z = v125;
        }
        // v126 = *(double (__thiscall **)(TdPlayerPawn ))(this.VfTableObject.Dummy + 288);
        v171 = (float)((float)(this.Velocity.X * this.Velocity.X) + (float)(this.Velocity.Y * this.Velocity.Y)) + (float)(this.Velocity.Z * this.Velocity.Z);
        v161 = this.GetTerminalVelocity();
        if ( v171 > (float)(v161 * v161) )
        {
          v127 = (float)((float)(this.Velocity.X * this.Velocity.X) + (float)(this.Velocity.Y * this.Velocity.Y)) + (float)(this.Velocity.Z * this.Velocity.Z);
          v210 = v127;
          if ( v127 == 1.0f )
          {
            v128 = this.Velocity.Y;
            v129 = this.Velocity.Z;
            v163 = this.Velocity.X;
            v164 = v128;
            v165 = v129;
          }
          else
          {
            if ( v127 >= SMALL_NUMBER )
            {
              v208 = 1077936128;
              v193 = 1056964608;
              v131 = fsqrt(v210);
              v194 = (float)(3.0f - (float)((float)((float)(1.0f / v131) * v210) * (float)(1.0f / v131))) * (float)((float)(1.0f / v131) * 0.5f);
              v132 = v194 * this.Velocity.Y;
              v130 = v194 * this.Velocity.Z;
              v163 = this.Velocity.X * v194;
              v164 = v132;
            }
            else
            {
              v130 = 0.0f;
              v163 = 0.0f;
              v164 = 0.0f;
            }
            v165 = v130;
          }
          v133 = v164;
          v134 = v165;
          this.Velocity.X = v163;
          this.Velocity.Y = v133;
          v135 = this.VfTableObject.Dummy;
          this.Velocity.Z = v134;
          v136 = this.GetTerminalVelocity();// GetTerminalVelocity
          this.Velocity.X = (float)(v136 * this.Velocity.X);
          this.Velocity.Y = (float)(v136 * this.Velocity.Y);
          this.Velocity.Z = (float)(v136 * this.Velocity.Z);
        }
      }
      --dword_205684C;
      remainingTime = v153;
      v213 = -1;
      if ( v153 <= 0.0f )
        break;
    }
  LABEL_190:
    v137 = this.Controller;
    if(v137 != default)
      v137.PostAirSteering((DeltaTime));// PostAirSteering
    v138 = v149;
    v139 = v150;
    this.Acceleration.X = v148;
    this.Acceleration.Y = v138;
    this.Acceleration.Z = v139;
  }

  // NOT READY
  //public override unsafe void PostBeginPlay(){ NativeMarkers.MarkUnimplemented(); }
//public override unsafe void PostBeginPlay()
//  {
//    int v2 = default; // eax
//    int *v3; // edi
//    int v4 = default; // eax
//    int v5 = default; // eax
//    int v6 = default; // eax
//    int v7 = default; // ebx
//    _E_struct_TArray_int *v8; // esi
//    int *v9; // eax
//    int v10 = default; // eax
//    int v11 = default; // ebx
//    int *v12; // eax
//    int v13 = default; // eax
//    int v14 = default; // edi
//    int *v15; // eax
//    int v16 = default; // esi
//    int v17 = default; // [esp+4h] [ebp-4h] BYREF
//  
//    base.PostBeginPlay();
//    if ( *(_DWORD *)(GEngine + 696) )
//    {
//      v2 = (*(int (__thiscall **)(_DWORD))(**(_DWORD **)(GEngine + 696) + 300))(*(_DWORD *)(GEngine + 696));
//      if(v2 != default)
//      {
//        v3 = (int *)(v2 + 188);
//        sub_590620((int *)(v2 + 188), &v17, dword_2056814);
//        if ( v17 == -1 || (v4 = *v3 + 20 * v17) == default )
//          v5 = default;
//        else
//          v5 = *(_DWORD *)(v4 + 8);
//        this.IndoorSoundGroupIndex = v5;
//        sub_590620(v3, &v17, dword_205681C);
//        if ( v17 == -1 || (v6 = *v3 + 20 * v17) == default )
//          v7 = default;
//        else
//          v7 = *(_DWORD *)(v6 + 8);
//        v8 = ref this.OutdoorSoundGroupIndexes;
//        v9 = ref this.OutdoorSoundGroupIndexes[this.OutdoorSoundGroupIndexes.Add(1, 4, 8)];
//        if(v9 != default)
//          *v9 = v7;
//        sub_590620(v3, &v17, dword_2056824);
//        if ( v17 == -1 || (v10 = *v3 + 20 * v17) == default )
//          v11 = default;
//        else
//          v11 = *(_DWORD *)(v10 + 8);
//        v12 = &v8[this.OutdoorSoundGroupIndexes.Add(1, 4, 8)];
//        if(v12 != default)
//          *v12 = v11;
//        sub_590620(v3, &v17, dword_205682C);
//        if ( v17 == -1 || (v13 = *v3 + 20 * v17) == default )
//          v14 = default;
//        else
//          v14 = *(_DWORD *)(v13 + 8);
//        v15 = &v8[this.OutdoorSoundGroupIndexes.Add(1, 4, 8)];
//        if(v15 != default)
//          *v15 = v14;
//        v16 = *(_DWORD *)((*(int (__thiscall **)(_DWORD))(**(_DWORD **)(GEngine + 696) + 300))(*(_DWORD *)(GEngine + 696)) + 352);
//        if(v16 != default)
//        {
//          this.IndoorMixGroupIndex = (*(int (__thiscall **)(int, int, int))(*(_DWORD *)v16 + 12))(v16, dword_2056834, dword_2056838);
//          this.OutdoorMixGroupIndex = (*(int (__thiscall **)(int, int, int))(*(_DWORD *)v16 + 12))(v16, dword_205683C, dword_2056840);
//        }
//      }
//    }
//  }
//
  // NOT READY
  public unsafe void UpdateReverb_Probably(float a2){ NativeMarkers.MarkUnimplemented(); }
//public unsafe void UpdateReverb_Probably(float a2)
//  {
//    float v3 = default; // xmm0_4
//    bool v4 = default; // cc
//    int v5 = default; // eax
//    WorldInfo v6 = default; // eax
//    int *v7; // eax
//    int v8 = default; // ebx
//    int v9 = default; // eax
//    int v10 = default; // edi
//    int v11 = default; // ebp
//    TdReverbVolume v12 = default; // ecx
//    int *v13; // ebx
//    int *v14; // eax
//    bool v15 = default; // ebx
//    _DWORD *v16; // eax
//    int v17 = default; // ecx
//    float *v18; // eax
//    float *v19; // eax
//    int v20 = default; // ecx
//    _DWORD *v21; // eax
//    float *v22; // eax
//    int v23 = default; // ecx
//    float *v24; // eax
//    _DWORD *v25; // eax
//    _DWORD *v26; // eax
//    int v27 = default; // ecx
//    _DWORD *v28; // eax
//    TdReverbVolume v29 = default; // ecx
//    int* v30 = stackalloc int[3]; // [esp+50h] [ebp-24h] BYREF
//    int* v31 = stackalloc int[3]; // [esp+5Ch] [ebp-18h] BYREF
//    int v32 = default; // [esp+70h] [ebp-4h]
//    int a2a = default; // [esp+78h] [ebp+4h]
//  
//    v3 = a2 + this.ReverbVolumeTimer;
//    v4 = v3 <= this.ReverbVolumePollTime;
//    this.ReverbVolumeTimer = v3;
//    if ( v4 || this.IndoorSoundGroupIndex == -1 || !this.OutdoorSoundGroupIndexes.Count )
//      return;
//    this.ReverbVolumeTimer = 0.0f;
//    v5 = sub_B82C60(GWorld);
//    E_TryCastTo<TdPlayerController>(v5);
//    v6 = GWorld.GetWorldInfo();
//    v7 = sub_C0F170(v6, ref this.Location.X);
//    v8 = sub_1229240((int)v7);
//    a2a = v8;
//    if ( !*(_DWORD *)(GEngine + 696) )
//    {
//      v10 = default;
//      goto LABEL_8;
//    }
//    v9 = (*(int (__thiscall **)(_DWORD))(**(_DWORD **)(GEngine + 696) + 300))(*(_DWORD *)(GEngine + 696));
//    v10 = v9;
//    if ( !v9 )
//    {
//  LABEL_8:
//      v11 = default;
//      goto LABEL_9;
//    }
//    v11 = *(_DWORD *)(v9 + 352);
//  LABEL_9:
//    if ( v10 && v11 )
//    {
//      if(v8 != default)
//      {
//        v12 = this.CurrentReverbVolume;
//        if(v12 != default)
//        {
//          v13 = sub_42E730(v12, v31);
//          v32 = default;
//          v14 = sub_42E730((_DWORD *)a2a, v30);
//          v15 = sub_45ADD0((int)v14, (int)v13);
//          sub_4036D0(v30);
//          v32 = -1;
//          sub_4036D0(v31);
//          if ( !v15 )
//            return;
//          if ( *(_BYTE *)(a2a + 544) )
//          {
//            if ( this.CurrentReverbVolume.vType )
//              goto LABEL_25;
//            v19 = (float *)(*(_DWORD *)(v10 + 284) + 48 * this.IndoorSoundGroupIndex);
//            v20 = default;
//            *v19 = this.OcclusionDuckLevel;
//            for ( v19[2] = this.OcclusionDuckLevel; v20 < this.OutdoorSoundGroupIndexes.Count; v21[2] = 1065353216 )
//            {
//              v21 = (_DWORD *)(*(_DWORD *)(v10 + 284) + 48 * this.OutdoorSoundGroupIndexes[v20++]);
//              *v21 = 1065353216;
//            }
//            *(double *)(v10 + 328) = sub_4083A0();
//            sub_B6D260((int *)(v10 + 248), (int *)(v10 + 260));
//            *(double *)(v10 + 336) = this.OcclusionDuckFadeTime + *(double *)(v10 + 328);
//            sub_B6DB90((int *)v10);
//            (*(void (__thiscall **)(int, int, float, float, _DWORD))(*(_DWORD *)v11 + 16))(v11, this.IndoorMixGroupIndex, this.OcclusionDuckLevel, this.OcclusionDuckFadeTime, 0);
//            (*(void (__thiscall **)(int, int, float, float, _DWORD))(*(_DWORD *)v11 + 32))(v11, this.IndoorMixGroupIndex, this.OcclusionDuckLevel, this.OcclusionDuckFadeTime, 0);
//            (*(void (__thiscall **)(int, int, _DWORD, float, _DWORD))(*(_DWORD *)v11 + 16))(v11, this.OutdoorMixGroupIndex, 1.0f, this.OcclusionDuckFadeTime, 0);
//          }
//          else
//          {
//            if ( this.CurrentReverbVolume.vType == EVT_Small__ )
//            {
//  LABEL_25:
//              if ( sub_12279B0(a2a) )
//              {
//                sub_1227990((int)this.CurrentReverbVolume);
//                this.CurrentReverbVolume = (TdReverbVolume )a2a;
//              }
//              return;
//            }
//            v16 = (_DWORD *)(*(_DWORD *)(v10 + 284) + 48 * this.IndoorSoundGroupIndex);
//            v17 = default;
//            *v16 = 1065353216;
//            for ( v16[2] = 1065353216; v17 < this.OutdoorSoundGroupIndexes.Count; v18[2] = this.OcclusionDuckLevel )
//            {
//              v18 = (float *)(*(_DWORD *)(v10 + 284) + 48 * this.OutdoorSoundGroupIndexes[v17++]);
//              *v18 = this.OcclusionDuckLevel;
//            }
//            *(double *)(v10 + 328) = sub_4083A0();
//            sub_B6D260((int *)(v10 + 248), (int *)(v10 + 260));
//            *(double *)(v10 + 336) = this.OcclusionDuckFadeTime + *(double *)(v10 + 328);
//            sub_B6DB90((int *)v10);
//            (*(void (__thiscall **)(int, int, _DWORD, float, _DWORD))(*(_DWORD *)v11 + 16))(v11, this.IndoorMixGroupIndex, 1.0f, this.OcclusionDuckFadeTime, 0);
//            (*(void (__thiscall **)(int, int, _DWORD, float, _DWORD))(*(_DWORD *)v11 + 32))(v11, this.IndoorMixGroupIndex, 1.0f, this.OcclusionDuckFadeTime, 0);
//            (*(void (__thiscall **)(int, int, float, float, _DWORD))(*(_DWORD *)v11 + 16))(v11, this.OutdoorMixGroupIndex, this.OcclusionDuckLevel, this.OcclusionDuckFadeTime, 0);
//          }
//          (*(void (__thiscall **)(int, int))(*(_DWORD *)v11 + 32))(v11, this.OutdoorMixGroupIndex);
//          goto LABEL_25;
//        }
//        v22 = (float *)(*(_DWORD *)(v10 + 284) + 48 * this.IndoorSoundGroupIndex);
//        v23 = default;
//        if ( *(_BYTE *)(v8 + 544) )
//        {
//          *v22 = this.OcclusionDuckLevel;
//          v22[2] = this.OcclusionDuckLevel;
//          if ( this.OutdoorSoundGroupIndexes.Count > 0 )
//          {
//            do
//            {
//              v25 = (_DWORD *)(*(_DWORD *)(v10 + 284) + 48 * this.OutdoorSoundGroupIndexes[v23++]);
//              *v25 = 1065353216;
//              v25[2] = 1065353216;
//            }
//            while ( v23 < this.OutdoorSoundGroupIndexes.Count );
//          }
//          *(double *)(v10 + 328) = sub_4083A0();
//          sub_B6D260((int *)(v10 + 248), (int *)(v10 + 260));
//          *(double *)(v10 + 336) = this.OcclusionDuckFadeTime + *(double *)(v10 + 328);
//          sub_B6DB90((int *)v10);
//          (*(void (__thiscall **)(int, int, float, float, _DWORD))(*(_DWORD *)v11 + 16))(v11, this.IndoorMixGroupIndex, this.OcclusionDuckLevel, this.OcclusionDuckFadeTime, 0);
//          (*(void (__thiscall **)(int, int, float, float, _DWORD))(*(_DWORD *)v11 + 32))(v11, this.IndoorMixGroupIndex, this.OcclusionDuckLevel, this.OcclusionDuckFadeTime, 0);
//          (*(void (__thiscall **)(int, int, _DWORD, float, _DWORD))(*(_DWORD *)v11 + 16))(v11, this.OutdoorMixGroupIndex, 1.0f, this.OcclusionDuckFadeTime, 0);
//        }
//        else
//        {
//          *v22 = 1.0f;
//          v22[2] = 1.0f;
//          if ( this.OutdoorSoundGroupIndexes.Count > 0 )
//          {
//            do
//            {
//              v24 = (float *)(*(_DWORD *)(v10 + 284) + 48 * this.OutdoorSoundGroupIndexes[v23++]);
//              *v24 = this.OcclusionDuckLevel;
//              v24[2] = this.OcclusionDuckLevel;
//            }
//            while ( v23 < this.OutdoorSoundGroupIndexes.Count );
//          }
//          *(double *)(v10 + 328) = sub_4083A0();
//          sub_B6D260((int *)(v10 + 248), (int *)(v10 + 260));
//          *(double *)(v10 + 336) = this.OcclusionDuckFadeTime + *(double *)(v10 + 328);
//          sub_B6DB90((int *)v10);
//          (*(void (__thiscall **)(int, int, _DWORD, float, _DWORD))(*(_DWORD *)v11 + 16))(v11, this.IndoorMixGroupIndex, 1.0f, this.OcclusionDuckFadeTime, 0);
//          (*(void (__thiscall **)(int, int, _DWORD, float, _DWORD))(*(_DWORD *)v11 + 32))(v11, this.IndoorMixGroupIndex, 1.0f, this.OcclusionDuckFadeTime, 0);
//          (*(void (__thiscall **)(int, int, float, float, _DWORD))(*(_DWORD *)v11 + 16))(v11, this.OutdoorMixGroupIndex, this.OcclusionDuckLevel, this.OcclusionDuckFadeTime, 0);
//        }
//        (*(void (__thiscall **)(int, int))(*(_DWORD *)v11 + 32))(v11, this.OutdoorMixGroupIndex);
//        this.CurrentReverbVolume = (TdReverbVolume )v8;
//        sub_12279B0(v8);
//      }
//      else
//      {
//        if ( this.CurrentReverbVolume )
//        {
//          v26 = (_DWORD *)(*(_DWORD *)(v10 + 284) + 48 * this.IndoorSoundGroupIndex);
//          v27 = default;
//          *v26 = 1065353216;
//          for ( v26[2] = 1065353216; v27 < this.OutdoorSoundGroupIndexes.Count; v28[2] = 1065353216 )
//          {
//            v28 = (_DWORD *)(*(_DWORD *)(v10 + 284) + 48 * this.OutdoorSoundGroupIndexes[v27++]);
//            *v28 = 1065353216;
//          }
//          *(double *)(v10 + 328) = sub_4083A0();
//          sub_B6C1E0((int *)(v10 + 248), (int *)(v10 + 260));
//          *(double *)(v10 + 336) = this.OcclusionDuckFadeTime + *(double *)(v10 + 328);
//          sub_B6DB90((int *)v10);
//          (*(void (__thiscall **)(int, int, _DWORD, float, _DWORD))(*(_DWORD *)v11 + 16))(v11, this.IndoorMixGroupIndex, 1.0f, this.OcclusionDuckFadeTime, 0);
//          (*(void (__thiscall **)(int, int, _DWORD, float, _DWORD))(*(_DWORD *)v11 + 32))(v11, this.IndoorMixGroupIndex, 1.0f, this.OcclusionDuckFadeTime, 0);
//          (*(void (__thiscall **)(int, int, _DWORD, float, _DWORD))(*(_DWORD *)v11 + 16))(v11, this.OutdoorMixGroupIndex, 1.0f, this.OcclusionDuckFadeTime, 0);
//          (*(void (__thiscall **)(int, int, _DWORD, float, _DWORD))(*(_DWORD *)v11 + 32))(v11, this.OutdoorMixGroupIndex, 1.0f, this.OcclusionDuckFadeTime, 0);
//          v29 = this.CurrentReverbVolume;
//          if ( v29.AmbientSoundComponent )
//            sub_1227990((int)v29);
//        }
//        this.CurrentReverbVolume = default;
//      }
//    }
//  }
//
  public override unsafe void TickSpecial(float DeltaSeconds)
  {
    float v3 = default; // xmm0_4
    float v4 = default; // xmm0_4
  
    base.TickSpecial(DeltaSeconds);
    UpdateReverb_Probably(DeltaSeconds);
    v3 = this.GravityModifierTimer;
    if ( v3 > 0.0f )
    {
      v4 = v3 - DeltaSeconds;
      this.GravityModifierTimer = v4;
      if ( v4 < 0.0f )
        this.GravityModifier = 1.0f;
    }
  }
}
}
