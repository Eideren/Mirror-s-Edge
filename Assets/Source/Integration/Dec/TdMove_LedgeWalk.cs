namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdMove_LedgeWalk
{
  public override unsafe void PrePerformPhysics(float DeltaTime)
  {
    TdPawn v3 = default; // eax
    float v4 = default; // edx
    float v5 = default; // ebx
    float v6 = default; // xmm0_4
    float v7 = default; // eax
    Vector *v8; // eax
    float v9 = default; // ecx
    float v10 = default; // edx
    float v11 = default; // ebx
    TdLedgeWalkVolume v12 = default; // eax
    float v13 = default; // xmm7_4
    float v14 = default; // xmm2_4
    float v15 = default; // xmm0_4
    float v16 = default; // xmm3_4
    float v17 = default; // xmm1_4
    float v18 = default; // xmm6_4
    float v19 = default; // xmm5_4
    float v20 = default; // xmm3_4
    float v21 = default; // xmm0_4
    float v22 = default; // xmm2_4
    float v23 = default; // xmm5_4
    float v24 = default; // xmm0_4
    float v25 = default; // xmm0_4
    float v26 = default; // xmm1_4
    float v27 = default; // xmm2_4
    float v28 = default; // xmm2_4
    Vector *v29; // eax
    TdPawn v30 = default; // ecx
    float v31 = default; // edx
    Vector *v32; // eax
    float v33 = default; // xmm5_4
    float v34 = default; // xmm6_4
    float v35 = default; // xmm7_4
    float v36 = default; // xmm0_4
    float v37 = default; // xmm0_4
    float v38 = default; // xmm6_4
    float v39 = default; // xmm7_4
    float v40 = default; // xmm2_4
    TdPawn v41 = default; // eax
    float v42 = default; // xmm0_4
    float v43 = default; // xmm1_4
    float v44 = default; // xmm2_4
    float v45 = default; // xmm3_4
    float v46 = default; // xmm1_4
    float v47 = default; // xmm2_4
    Rotator v48 = default; // [esp+10h] [ebp-DCh]
    Vector v49 = default; // [esp+30h] [ebp-BCh] BYREF
    Vector a2 = default; // [esp+3Ch] [ebp-B0h] BYREF
    Vector a4 = default; // [esp+4Ch] [ebp-A0h] BYREF
    Vector Delta = default; // [esp+58h] [ebp-94h] BYREF
    Vector v53 = default; // [esp+64h] [ebp-88h]
    float v54 = default; // [esp+74h] [ebp-78h]
    float v55 = default; // [esp+78h] [ebp-74h]
    float v56 = default; // [esp+7Ch] [ebp-70h]
    CheckResult Hit = default; // [esp+80h] [ebp-6Ch] BYREF
    int v58 = default; // [esp+C8h] [ebp-24h]
    float v59 = default; // [esp+CCh] [ebp-20h]
    float v60 = default; // [esp+DCh] [ebp-10h]
  
    base.PrePerformPhysics(DeltaTime);
    v3 = this.PawnOwner;
    v4 = v3.Location.X;
    v5 = v3.Location.Y;
    v6 = this.CurrentParamOnCurve;
    v7 = v3.Location.Z;
    v54 = v4;
    v55 = v5;
    v56 = v7;
    this.Volume.FindClosestPointOnDSpline(
      COERCE_FLOAT(LODWORD(v4)),
      COERCE_FLOAT(LODWORD(v5)),
      COERCE_FLOAT(LODWORD(v7)),
      &a4,
fixed(var ptr1 =&this.CurrentParamOnCurve)
       ptr1,
      (int)v6);                                   // ATdMovementVolume::FindClosestPointOnDSpline
    v8 = (Vector *)this.Volume.GetSlopeOnSpline(&a2, this.CurrentParamOnCurve / (float)this.Volume.SplineLocations.Count);// ATdMovementVolume::GetSlopeOnSpline
    v9 = v8->X;
    v10 = v8->Y;
    v11 = v8->Z;
    v53.X = v8->X;
    v53.Y = v10;
    v53.Z = v11;
    v12 = this.Volume;
    v13 = v10;
    a4.Z = v56;
    v14 = (float)(v12.FloorNormal.Z * v10) - (float)(v12.FloorNormal.Y * v11);
    v15 = (float)(v12.FloorNormal.X * v11) - (float)(v12.FloorNormal.Z * v53.X);
    v16 = (float)(v12.FloorNormal.Y * v53.X) - (float)(v12.FloorNormal.X * v10);
    v17 = (float)((float)((float)(v12.WallNormal.Z * v16) + (float)(v12.WallNormal.Y * v15)) + (float)(v12.WallNormal.X * v14)) / (float)((float)((float)(v15 * v15) + (float)(v14 * v14)) + (float)(v16 * v16));
    v18 = v15 * v17;
    v19 = v17 * v14;
    v20 = v16 * v17;
    v21 = (float)(v19 * v19) + (float)(v18 * v18);
    a2.X = v17 * v14;
    a2.Y = v18;
    a2.Z = v20;
    v60 = v21;
    if ( v21 == 1.0f )
    {
      if ( v20 == 0.0f )
      {
        v49 = a2;
        goto LABEL_10;
      }
      v49.X = v17 * v14;
      goto LABEL_8;
    }
    if ( v21 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
    {
      v59 = 3.0f;
      v22 = 1.0f / fsqrt(v60);
      a2.X = (float)(3.0f - (float)((float)(v22 * v60) * v22)) * (float)(v22 * 0.5f);
      v49.X = a2.X * v19;
      v18 = v18 * a2.X;
  LABEL_8:
      v49.Y = v18;
      goto LABEL_9;
    }
    v49.X = 0.0f;
    v49.Y = 0.0f;
  LABEL_9:
    v49.Z = 0.0f;
  LABEL_10:
    v23 = v53.X;
    v24 = (float)(v10 * v10) + (float)(v23 * v23);
    v59 = v24;
    if ( v24 == 1.0f )
    {
      if ( v53.Z == 0.0f )
      {
        a2.X = v9;
        v25 = v9;
        a2.Y = v10;
        v13 = v10;
        a2.Z = v11;
        v26 = v11;
        goto LABEL_18;
      }
      v25 = v53.X;
    }
    else if ( v24 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
    {
      v60 = 3.0f;
      v27 = 1.0f / fsqrt(v59);
      v53.X = (float)(3.0f - (float)((float)(v27 * v59) * v27)) * (float)(v27 * 0.5f);
      v25 = v53.X * v23;
      v13 = v53.X * v10;
    }
    else
    {
      v25 = 0.0f;
      v13 = 0.0f;
    }
    v26 = 0.0f;
  LABEL_18:
    v28 = this.StrafeSpeed;
fixed(var ptr2 =&this.PawnOwner.Velocity)
    v29 =  ptr2;
    a2.X = v25 * v28;
    v29->X = v25 * v28;
    a2.Y = v13 * v28;
    v29->Y = v13 * v28;
    a2.Z = v26 * v28;
    v29->Z = v26 * v28;
    v30 = this.PawnOwner;
    v31 = v30.Velocity.X;
fixed(var ptr3 =&v30.Velocity)
    v32 =  ptr3;
    v30 = (TdPawn )((byte *)v30 + 0x10C);// v31 now points to Acceleration
    *(float *)&v30.VfTableObject.Dummy = v31;
    v30.ObjectInternalInteger = LODWORD(v32->Y);
    v30.ObjectFlags_A = LODWORD(v32->Z);
    if ( (this.bDebugMove.AsBitfield(29) & bUsePreciseRotation) == 0 )
    {
      v48 = *E_DirToRotator(&v49, (Rotator *)&a2);// a2 re-used as rotator to be written to and read inside of SetRotation below
      this.PawnOwner.SetRotation(v48);
    }
    v33 = (float)(v49.Y * -1.0f) - (float)(v49.Z * 0.0f);
    v34 = (float)(v49.Z * 0.0f) - (float)(v49.X * -1.0f);
    v35 = (float)(v49.X * 0.0f) - (float)(v49.Y * 0.0f);
    v36 = (float)((float)(v33 * v33) + (float)(v35 * v35)) + (float)(v34 * v34);
    a2.X = v33;
    a2.Y = v34;
    a2.Z = v35;
    v59 = v36;
    if ( v36 == 1.0f )
    {
      v53 = a2;
      v37 = a2.X;
      v38 = a2.Y;
      v39 = a2.Z;
    }
    else if ( v36 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
    {
      v60 = 3.0f;
      v40 = 1.0f / fsqrt(v59);
      a2.X = (float)(3.0f - (float)((float)(v40 * v59) * v40)) * (float)(v40 * 0.5f);
      v37 = a2.X * v33;
      v38 = v34 * a2.X;
      v39 = v35 * a2.X;
    }
    else
    {
      v37 = 0.0f;
      v38 = 0.0f;
      v39 = 0.0f;
    }
    v41 = this.PawnOwner;
    v42 = v37 * v41.Acceleration.X;
    v43 = v41.Acceleration.Y;
    v44 = v41.Acceleration.Z;
    v45 = a4.Z - v56;
    Hit.Item = -1;
    Hit.LevelIndex = -1;
    v46 = (float)(v43 * v38) + (float)(v44 * v39);
    v47 = a4.Y - v55;
    Hit.Next = default;
    Hit.Actor = default;
    Hit.Material = default;
    Hit.PhysMaterial = default;
    Hit.Component = default;
    Hit.BoneName = default;
    Hit.Level = default;
    Hit.bStartPenetrating = default;
    v58 = default;
    this.StrafeFactor = v46 + v42;
    Delta.X = (float)(a4.X - v54) * (float)(DeltaTime * 10.0f);
    Delta.Y = v47 * (float)(DeltaTime * 10.0f);
    Delta.Z = v45 * (float)(DeltaTime * 10.0f);
    Hit.Location.X = 0.0f;
    Hit.Location.Y = 0.0f;
    Hit.Location.Z = 0.0f;
    Hit.Normal.X = 0.0f;
    Hit.Normal.Y = 0.0f;
    Hit.Normal.Z = 0.0f;
    Hit.Time = 1.0f;
fixed(var ptr4 =&v41.Rotation)
    GWorld.MoveActor(v41, &Delta,  ptr4, 0, &Hit);
  }
}
}
