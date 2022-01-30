// NO OVERWRITE

namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdMove_ZipLine
{
  public override unsafe void PrePerformPhysics(float DeltaTime)
  {
    TdPawn v3 = default; // ecx
    float v4 = default; // xmm0_4
    float v5 = default; // edx
    float v6 = default; // xmm0_4
    float v7 = default; // xmm2_4
    TdPawn v8 = default; // edi
    TdPawn v9 = default; // eax
    float v10 = default; // ebx
    TdPawn v11 = default; // edi
    float v12 = default; // xmm0_4
    int v13 = default; // ecx
    TdZiplineVolume v14 = default; // ebx
    int v15 = default; // edx
    Vector[] v16; // eax
    double v17 = default; // st3
    //Vector *v18; // eax
    int v19 = default; // eax
    Vector[] v20; // ecx
    float v21 = default; // xmm6_4
    float v22 = default; // xmm5_4
    float v23 = default; // xmm4_4
    float v24 = default; // xmm1_4
    float v25 = default; // xmm3_4
    float v26 = default; // xmm2_4
    float v27 = default; // xmm0_4
    float v28 = default; // xmm2_4
    float v29 = default; // xmm3_4
    float v30 = default; // xmm1_4
    float v31 = default; // xmm0_4
    float v32 = default; // xmm4_4
    float v33 = default; // xmm5_4
    float v34 = default; // xmm0_4
    //Vector *v35; // eax
    TdPawn v36 = default; // ecx
    float v37 = default; // edx
    float v38 = default; // eax
    float v39 = default; // xmm0_4
    float v40 = default; // xmm2_4
    float v41 = default; // xmm3_4
    float v42 = default; // xmm0_4
    float v43 = default; // xmm4_4
    //Vector *v44; // eax
    float v45 = default; // xmm3_4
    TdPawn v46 = default; // ecx
    float v47 = default; // xmm3_4
    float v48 = default; // xmm2_4
    float v49 = default; // xmm0_4
    //Vector *v50; // ecx
    float v51 = default; // xmm0_4
    float v52 = default; // edx
    float v53 = default; // eax
    float v54 = default; // ecx
    float v55 = default; // xmm2_4
    float v56 = default; // ecx
    //Vector *v57; // eax
    float v58 = default; // edx
    TdPawn v59 = default; // edi
    double v60 = default; // st7
    float v61 = default; // xmm0_4
    float v62 = default; // ebp
    float v63 = default; // edi
    float v64 = default; // ebx
    TdPawn v65 = default; // ecx
    EZipLineStatus v66 = default; // al
    TdPawn v67 = default; // ecx
    float v68 = default; // xmm2_4
    float v69 = default; // xmm1_4
    float v70 = default; // xmm0_4
    //float *v71; // ecx
    float v72 = default; // xmm0_4
    float v73 = default; // edx
    float v74 = default; // eax
    float v75 = default; // ecx
    float v76 = default; // xmm0_4
    float v77 = default; // xmm1_4
    float v78 = default; // xmm2_4
    float v79 = default; // xmm0_4
    float v80 = default; // xmm3_4
    float v81 = default; // xmm2_4
    float v82 = default; // xmm1_4
    float v83 = default; // xmm0_4
    //Vector *v84; // ecx
    float v85 = default; // xmm0_4
    float v86 = default; // edx
    float v87 = default; // eax
    float v88 = default; // ecx
    float v89 = default; // xmm3_4
    float v90 = default; // xmm0_4
    float v91 = default; // xmm1_4
    float v92 = default; // xmm2_4
    float v93 = default; // xmm0_4
    float v94 = default; // edx
    float v95 = default; // eax
    float v96 = default; // ecx
    float v97 = default; // xmm0_4
    EZipLineStatus v98 = default; // al
    float v99 = default; // xmm0_4
    TdPawn v100 = default; // ecx
    float v101 = default; // xmm2_4
    float v102 = default; // xmm1_4
    float v103 = default; // xmm3_4
    //Vector *v104; // ecx
    float v105 = default; // xmm3_4
    float v106 = default; // edx
    float v107 = default; // eax
    float v108 = default; // ecx
    float v109 = default; // xmm1_4
    float v110 = default; // xmm2_4
    //Vector *v111; // eax
    //Vector *v112; // eax
    float v113 = default; // xmm0_4
    float v114 = default; // xmm2_4
    float v115 = default; // eax
    int v116 = default; // esi
    int v117 = default; // eax
    Vector v118 = default; // [esp-1Ch] [ebp-A0h]
    Vector v119 = default; // [esp-10h] [ebp-94h]
    float v120 = default; // [esp+18h] [ebp-6Ch]
    float v121 = default; // [esp+18h] [ebp-6Ch]
    float v122 = default; // [esp+18h] [ebp-6Ch]
    float v123 = default; // [esp+1Ch] [ebp-68h]
    float v124 = default; // [esp+1Ch] [ebp-68h]
    float v125 = default; // [esp+20h] [ebp-64h]
    float v126 = default; // [esp+24h] [ebp-60h]
    (float, float) v127 = default; // [esp+24h] [ebp-60h]
    float v128 = default; // [esp+28h] [ebp-5Ch]
    float v129 = default; // [esp+28h] [ebp-5Ch]
    Vector Extent = default; // [esp+2Ch] [ebp-58h] BYREF
    Vector a2 = default; // [esp+38h] [ebp-4Ch] BYREF
    Vector v132 = default; // [esp+44h] [ebp-40h]
    float v133 = default; // [esp+54h] [ebp-30h]
    float v134 = default; // [esp+58h] [ebp-2Ch]
    float v135 = default; // [esp+5Ch] [ebp-28h]
    float v136 = default; // [esp+64h] [ebp-20h] BYREF
    float v137 = default; // [esp+68h] [ebp-1Ch]
    int v138 = default; // [esp+6Ch] [ebp-18h]
    int v139 = default; // [esp+70h] [ebp-14h]
    float v140 = default; // [esp+74h] [ebp-10h]
    float DeltaTimea = default; // [esp+88h] [ebp+4h]
  
    v3 = this.PawnOwner;
    if ( v3.Role < ROLE_AutonomousProxy )
    {
      base.PrePerformPhysics(DeltaTime);
      return;
    }
    if ( this.ZipLine )
    {
      v4 = (float)((float)(v3.Velocity.X * v3.Velocity.X) + (float)(v3.Velocity.Y * v3.Velocity.Y)) + (float)(v3.Velocity.Z * v3.Velocity.Z);
      v132.X = v4;
      if ( v4 == 1.0f )
      {
        v5 = v3.Velocity.Y;
        v132.X = v3.Velocity.X;
        *(_QWORD *)&v132.Y = __PAIR64__(LODWORD(v3.Velocity.Z), LODWORD(v5));
      }
      else
      {
        if ( v4 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
        {
          v133 = 3.0f;
          v7 = 1.0f / fsqrt(v132.X);
          v136 = (float)(3.0f - (float)((float)(v7 * v132.X) * v7)) * (float)(v7 * 0.5f);
          v6 = v136 * v3.Velocity.Z;
        }
        else
        {
          v6 = 0.0f;
        }
        v132.Z = v6;
      }
      v8 = this.PawnOwner;
      v8.Velocity.Z = (float)(v8.GetGravityZ() * fabs(v132.Z) * DeltaTime// GetGravityZ
                      + v8.Velocity.Z);
      v9 = this.PawnOwner;
      v10 = v9.Location.X;
      v128 = v9.Location.Z - this.HangOffset.Z;
      v125 = v10;
      v126 = v9.Location.Y;
      fixed(float* ptr1 =&this.CurrentParamOnCurve)
      this.ZipLine.FindClosestPointOnDSpline(new Vector(
        v10,
        v126,
        v128),
        ref Extent,
         ref *ptr1,
        (int)this.CurrentParamOnCurve);          // ATdMovementVolume::FindClosestPointOnDSpline
      v11 = this.PawnOwner;
      v12 = this.MinZipVelocity;
      v13 = (int)this.CurrentParamOnCurve;
      v123 = (float)(sqrt(v11.Velocity.Z * v11.Velocity.Z + v11.Velocity.Y * v11.Velocity.Y + v11.Velocity.X * v11.Velocity.X));
      if ( v123 >= v12 )
        v12 = v123;
      v120 = v12 * DeltaTime;
      if ( (float)(v12 * DeltaTime) > 0.0f )
      {
        v14 = this.ZipLine;
        v15 = v13;
        while(1 != default)
        {
          ++v13;
          ++v15;
          if ( v13 >= v14.SplineLocations.Count )
            break;
          v16 = v14.SplineLocations.Data;
          v17 = v16[v15].X;
          if ( v120 <= sqrt((v17 - v125) * (v17 - v125) + (v16[v15].Z - v128) * (v16[v15].Z - v128) + (v16[v15].Y - v126) * (v16[v15].Y - v126)) )
          {
            v10 = v125;
            goto LABEL_17;
          }
        }
        v116 = v11.VfTableObject.Dummy;
        v139 = default;
        v137 = 0.0f;
        v138 = default;
        v136.LOBYTE(2);
        v11.SetMove((EMovement)2);
        return;
      }
  LABEL_17:
      v19 = v13;
      v20 = this.ZipLine.SplineLocations.Data;
      v21 = v20[v19].X - v20[v19 - 1].X;
      v22 = v20[v19].Z - v20[v19 - 1].Z;
      v23 = v20[v19].Y - v20[v19 - 1].Y;
      v24 = v20[v19].X - v125;
      v25 = v20[v19].Z - v128;
      v26 = v20[v19].Y - v126;
      v124 = (float)((float)(v21 * v21) + (float)(v22 * v22)) + (float)(v23 * v23);
      v27 = (float)((float)((float)(v24 * v21) + (float)(v25 * v22)) + (float)(v26 * v23)) / v124;
      v133 = v27 * v21;
      v134 = v23 * v27;
      v28 = v26 - (float)(v23 * v27);
      v29 = v25 - (float)(v22 * v27);
      v136 = v24 - (float)(v27 * v21);
      v30 = 0.0f;
      v132.X = v21;
      *(_QWORD *)&v132.Y = __PAIR64__(LODWORD(v22), LODWORD(v23));
      v137 = v28;
      if ( (float)((float)(v120 * v120) - (float)((float)((float)(v136 * v136) + (float)(v29 * v29)) + (float)(v28 * v28))) < 0.0f )
        v121 = 0.0f;
      else
        v121 = (float)(v120 * v120) - (float)((float)((float)(v136 * v136) + (float)(v29 * v29)) + (float)(v28 * v28));
      v140 = (float)((float)(v21 * v21) + (float)(v22 * v22)) + (float)(v23 * v23);
      v122 = (float)(sqrt(v121));
      if ( v124 == 1.0f )
      {
        a2 = v132;
        v31 = v132.X;
        v32 = v132.Y;
        v33 = v132.Z;
      }
      else if ( v124 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
      {
        v132.X = 3.0f;
        v34 = fsqrt(v140);
        v133 = (float)(3.0f - (float)((float)((float)(1.0f / v34) * v140) * (float)(1.0f / v34))) * (float)((float)(1.0f / v34) * 0.5f);
        v28 = v137;
        v32 = v23 * v133;
        v33 = v22 * v133;
        v30 = 0.0f;
        v31 = v133 * v21;
      }
      else
      {
        v31 = 0.0f;
        v32 = 0.0f;
        v33 = 0.0f;
      }
      v132.X = (float)(1.0f / DeltaTime) * (float)((float)(v31 * v122) + v136);
      this.PawnOwner.Velocity.X = v132.X;
      v132.Y = (float)((float)(v32 * v122) + v28) * (float)(1.0f / DeltaTime);
      this.PawnOwner.Velocity.Y = v132.Y;
      v132.Z = (float)((float)(v33 * v122) + v29) * (float)(1.0f / DeltaTime);
      this.PawnOwner.Velocity.Z = v132.Z;
      v36 = this.PawnOwner;
      if ( this.MinZipVelocity > sqrt(v36.Velocity.Z * v36.Velocity.Z + v36.Velocity.Y * v36.Velocity.Y + v36.Velocity.X * v36.Velocity.X) )
      {
        v133 = (float)((float)(v36.Velocity.X * v36.Velocity.X) + (float)(v36.Velocity.Y * v36.Velocity.Y)) + (float)(v36.Velocity.Z * v36.Velocity.Z);
        if ( v133 == 1.0f )
        {
          v37 = v36.Velocity.Y;
          v132.X = v36.Velocity.X;
          v38 = v36.Velocity.Z;
          v39 = v132.X;
          *(_QWORD *)&v132.Y = __PAIR64__(LODWORD(v38), LODWORD(v37));
          v40 = v37;
          v41 = v38;
        }
        else if ( v133 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
        {
          v140 = 3.0f;
          v42 = fsqrt(v133);
          v136 = (float)(3.0f - (float)((float)((float)(1.0f / v42) * v133) * (float)(1.0f / v42))) * (float)((float)(1.0f / v42) * 0.5f);
          v39 = v136 * v36.Velocity.X;
          v40 = v36.Velocity.Y * v136;
          v41 = v36.Velocity.Z * v136;
          v30 = 0.0f;
        }
        else
        {
          v39 = 0.0f;
          v40 = 0.0f;
          v41 = 0.0f;
        }
        v43 = this.MinZipVelocity;
        v132.X = v39 * v43;
        this.PawnOwner.Velocity.X = v39 * v43;
        v132.Y = v40 * v43;
        v45 = v41 * v43;
        v132.Z = v45;
        this.PawnOwner.Velocity.Y = v40 * v43;
        this.PawnOwner.Velocity.Z = v45;
      }
      v46 = this.PawnOwner;
      v47 = v46.Velocity.X;
      v48 = v46.Velocity.Y;
      v49 = v46.Velocity.Z;
      v51 = (float)((float)(v49 * v49) + (float)(v47 * v47)) + (float)(v48 * v48);
      v133 = v51;
      if ( v51 == 1.0f )
      {
        v52 = v46.Velocity.X;
        v53 = v46.Velocity.Y;
        v54 = v46.Velocity.Z;
        v132.X = v52;
        *(_QWORD *)&v132.Y = __PAIR64__(LODWORD(v54), LODWORD(v53));
      }
      else
      {
        if ( v51 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
        {
          v140 = 3.0f;
          v55 = 1.0f / fsqrt(v133);
          v136 = (float)(3.0f - (float)((float)(v55 * v133) * v55)) * (float)(v55 * 0.5f);
          v132.X = v46.Velocity.X * v136;
          v132.Y = v46.Velocity.Y * v136;
          v30 = v46.Velocity.Z * v136;
        }
        else
        {
          v132.X = 0.0f;
          v132.Y = 0.0f;
        }
        v132.Z = v30;
      }
      v56 = v132.Y;
      this.PawnOwner.Acceleration.X = v132.X;
      v58 = v132.Z;
      this.PawnOwner.Acceleration.Y = v56;
      this.PawnOwner.Acceleration.Z = v58;
      v59 = this.PawnOwner;
      v60 = v59.GetGravityZ();// GetGravityZ
      v61 = this.MinZipAcceleration;
      DeltaTimea = (float)(fabs(v60 * v59.Acceleration.Z));
      if ( v61 < DeltaTimea )
        v61 = DeltaTimea;
      v62 = v126;
      v59.Acceleration.X = v59.Acceleration.X * v61;
      v59.Acceleration.Y = v59.Acceleration.Y * v61;
      v59.Acceleration.Z = v59.Acceleration.Z * v61;
      v63 = v10;
      v132.Z = v128 - 40.0f;
      v64 = v128 - 40.0f;
      v65 = this.PawnOwner;
      v132.X = v63;
      v132.Y = v126;
      v129 = v128 - 40.0f;
      v65.GetCylinderExtent(&a2);
      v66 = this.ZipLineStatus;
      v67 = this.PawnOwner;
      a2.Z = a2.Z * 0.5f;
      if(v66 != default)
      {
        v81 = v67.Velocity.Y;
        v82 = v67.Velocity.Z;
        v83 = v67.Velocity.X;
        v85 = (float)((float)(v83 * v83) + (float)(v81 * v81)) + (float)(v82 * v82);
        v133 = v85;
        if ( v66 == ZLS_Impact )
        {
          if ( v85 == 1.0f )
          {
            v86 = v67.Velocity.X;
            v87 = v67.Velocity.Y;
            v88 = v67.Velocity.Z;
            v89 = 2.0f;
            v133 = v86;
            v90 = v86;
            v134 = v87;
            v91 = v87;
            v135 = v88;
            v92 = v88;
          }
          else if ( v85 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
          {
            v140 = 3.0f;
            v93 = fsqrt(v133);
            v136 = (float)(3.0f - (float)((float)((float)(1.0f / v93) * v133) * (float)(1.0f / v93))) * (float)((float)(1.0f / v93) * 0.5f);
            v90 = v67.Velocity.X * v136;
            v91 = v67.Velocity.Y * v136;
            v92 = v67.Velocity.Z * v136;
            v89 = 2.0f;
          }
          else
          {
            v90 = 0.0f;
            v89 = 2.0f;
            v91 = 0.0f;
            v92 = 0.0f;
          }
        }
        else
        {
          if ( v85 == 1.0f )
          {
            v94 = v67.Velocity.X;
            v95 = v67.Velocity.Y;
            v96 = v67.Velocity.Z;
            v133 = v94;        
            v90 = v94;
            v134 = v95;
            v91 = v95;
            v135 = v96;
            v92 = v96;
          }
          else if ( v85 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
          {
            v140 = 3.0f;
            v97 = fsqrt(v133);
            v136 = (float)(3.0f - (float)((float)((float)(1.0f / v97) * v133) * (float)(1.0f / v97))) * (float)((float)(1.0f / v97) * 0.5f);
            v90 = v136 * v67.Velocity.X;
            v91 = v67.Velocity.Y * v136;
            v92 = v67.Velocity.Z * v136;
          }
          else
          {
            v90 = 0.0f;
            v91 = 0.0f;
            v92 = 0.0f;
          }
          v89 = 20.0f;
        }
        *((float *)&v127 + 1) = (float)(v92 * v89) + v129;
        *(float *)&v127 = (float)(v91 * v89) + v126;
        v80 = v132.X + (float)(v90 * v89);
      }
      else
      {
        v68 = v67.Velocity.Y;
        v69 = v67.Velocity.Z;
        v70 = v67.Velocity.X;
        v72 = (float)((float)(v70 * v70) + (float)(v68 * v68)) + (float)(v69 * v69);
        v133 = v72;
        if ( v72 == 1.0f )
        {
          v73 = v67.Velocity.X;
          v74 = v67.Velocity.Y;
          v75 = v67.Velocity.Z;
          v133 = v73;
          v76 = v73;
          v134 = v74;
          v77 = v74;
          v135 = v75;
          v78 = v75;
        }
        else if ( v72 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
        {
          v140 = 3.0f;
          v79 = fsqrt(v133);
          v136 = (float)(3.0f - (float)((float)((float)(1.0f / v79) * v133) * (float)(1.0f / v79))) * (float)((float)(1.0f / v79) * 0.5f);
          v77 = v136 * v67.Velocity.Y;
          v76 = v67.Velocity.X * v136;
          v78 = v136 * v67.Velocity.Z;
        }
        else
        {
          v76 = 0.0f;
          v77 = 0.0f;
          v78 = 0.0f;
        }
        v80 = v132.X + (float)(v76 * 600.0f);
        v127 = (v126 + (float)(v77 * 600.0f), v129 + (float)(v78 * 600.0f));
      }
      v119.X = v63;
      *(_QWORD *)&v119.Y = __PAIR64__(LODWORD(v64), LODWORD(v62));
      v118.X = v80;
      v118.Y = v127.Item1;
      v118.Z = v127.Item2;
      if ( this.MovementTraceForBlocking(v118, v119, a2) )
      {
        v98 = this.ZipLineStatus;
        if ( v98 == ZLS_CloseToEnd )
        {
          this.PlayForwardImpact();
        }
        else if(v98 != default)
        {
          if ( v98 == ZLS_Impact )
          {
            v99 = 0.0f;
            v133 = 0.0f;
            this.PawnOwner.Velocity.X = 0.0f;
            v134 = 0.0f;
            this.PawnOwner.Velocity.Y = 0.0f;
            v135 = 0.0f;
            this.PawnOwner.Velocity.Z = 0.0f;
            v133 = 0.0f;
            this.PawnOwner.Acceleration.X = 0.0f;
            v134 = 0.0f;
            v135 = 0.0f;
            this.PawnOwner.Acceleration.Y = 0.0f;
            this.PawnOwner.Acceleration.Z = 0.0f;
            goto LABEL_64;
          }
        }
        else
        {
          this.PrepareForForwardImpact();
          this.ZipLineStatus = ZLS_CloseToEnd;
        }
      }
      v99 = 0.0f;
  LABEL_64:
      v100 = this.PawnOwner;
      v101 = v100.Velocity.Y;
      v102 = v100.Velocity.Z;
      v103 = v100.Velocity.X;
      v105 = (float)((float)(v103 * v103) + (float)(v101 * v101)) + (float)(v102 * v102);
      v133 = v105;
      if ( v105 == 1.0f )
      {
        v106 = v100.Velocity.X;
        v107 = v100.Velocity.Y;
        v108 = v100.Velocity.Z;
        v133 = v106;
        v99 = v106;
        v134 = v107;
        v109 = v107;
        v135 = v108;
        v110 = v108;
      }
      else if ( v105 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
      {
        v140 = 3.0f;
        v113 = fsqrt(v133);
        v136 = (float)(3.0f - (float)((float)((float)(1.0f / v113) * v133) * (float)(1.0f / v113))) * (float)((float)(1.0f / v113) * 0.5f);
        v109 = v136 * v100.Velocity.Y;
        v99 = v100.Velocity.X * v136;
        v110 = v136 * v100.Velocity.Z;
      }
      else
      {
        v109 = 0.0f;
        v110 = 0.0f;
      }
      v133 = (float)(v99 * 600.0f) + v132.X;
      v114 = (float)(v110 * 600.0f) + v132.Z;
      v134 = v132.Y + (float)(v109 * 600.0f);
      v115 = v134;
      v135 = v114;
      this.CurrentLookAtPoint.X = v133;
      this.CurrentLookAtPoint.Y = v115;
      this.CurrentLookAtPoint.Z = v114;
    }
  }
}
}
