namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdMovementVolume
{
  public unsafe void FindClosestPointOnDSpline(Vector InLocation, Vector *ClosestLocation, float *NParamT, int LowestIndexHint)
  {
    float v5 = default; // xmm3_4
    TdMovementVolume v6 = default; // edi
    int v7 = default; // edx
    int v8 = default; // ebx
    int v9 = default; // eax
    Vector *v10; // esi
    float *v11; // edi
    float *v12; // esi
    float v13 = default; // xmm4_4
    float *v14; // esi
    float v15 = default; // xmm4_4
    int v16 = default; // eax
    int v17 = default; // esi
    float *v18; // edi
    int v19 = default; // ebx
    float *v20; // esi
    float v21 = default; // xmm4_4
    float *v22; // esi
    float v23 = default; // xmm4_4
    int v24 = default; // ecx
    int v25 = default; // eax
    Vector *v26; // esi
    float *v27; // edi
    int v28 = default; // ebx
    float *v29; // esi
    float *v30; // esi
    int v31 = default; // eax
    Vector *v32; // ecx
    float v33 = default; // xmm5_4
    float v34 = default; // xmm7_4
    float v35 = default; // xmm4_4
    float v36 = default; // xmm5_4
    float v37 = default; // xmm6_4
    Vector *v38; // ecx
    float v39 = default; // xmm3_4
    float v40 = default; // xmm4_4
    float v41 = default; // xmm5_4
    Vector *v42; // eax
    float v43 = default; // xmm6_4
    float v44 = default; // xmm0_4
    float v45 = default; // xmm1_4
    double v46 = default; // st6
    float v47 = default; // xmm0_4
    float v48 = default; // ecx
    int v49 = default; // xmm1_4
    float v50 = default; // xmm0_4
    float v52 = default; // [esp+8h] [ebp-8h]
    float v53 = default; // [esp+Ch] [ebp-4h]
    float a3a = default; // [esp+18h] [ebp+8h]
    float a5a = default; // [esp+20h] [ebp+10h]
  
    v5 = 3.4028235e38;
    v6 = this;
    v7 = default;
    if ( LowestIndexHint < 0 )
    {
      v24 = this.NumSplineSegments;
      v25 = default;
      if ( v24 >= 4 )
      {
        v26 = v6.SplineLocations.Data;
fixed(var ptr1 =&v26->Z)
        v27 =  ptr1;
        v28 = 2;
        v29 = &v26[1].Z;
        do
        {
          if ( v5 > (float)((float)((float)((float)(*v27 - InLocation.Z) * (float)(*v27 - InLocation.Z)) + (float)((float)(*(v27 - 1) - InLocation.Y) * (float)(*(v27 - 1) - InLocation.Y)))
                          + (float)((float)(*(v27 - 2) - InLocation.X) * (float)(*(v27 - 2) - InLocation.X))) )
          {
            v5 = (float)((float)((float)(*v27 - InLocation.Z) * (float)(*v27 - InLocation.Z)) + (float)((float)(*(v27 - 1) - InLocation.Y) * (float)(*(v27 - 1) - InLocation.Y)))
               + (float)((float)(*(v27 - 2) - InLocation.X) * (float)(*(v27 - 2) - InLocation.X));
            v7 = v25;
          }
          if ( v5 > (float)((float)((float)((float)(*v29 - InLocation.Z) * (float)(*v29 - InLocation.Z)) + (float)((float)(*(v29 - 1) - InLocation.Y) * (float)(*(v29 - 1) - InLocation.Y)))
                          + (float)((float)(v27[1] - InLocation.X) * (float)(v27[1] - InLocation.X))) )
          {
            v5 = (float)((float)((float)(*v29 - InLocation.Z) * (float)(*v29 - InLocation.Z)) + (float)((float)(*(v29 - 1) - InLocation.Y) * (float)(*(v29 - 1) - InLocation.Y))) + (float)((float)(v27[1] - InLocation.X) * (float)(v27[1] - InLocation.X));
            v7 = v28 - 1;
          }
          if ( v5 > (float)((float)((float)((float)(v29[3] - InLocation.Z) * (float)(v29[3] - InLocation.Z)) + (float)((float)(v29[2] - InLocation.Y) * (float)(v29[2] - InLocation.Y))) + (float)((float)(v27[4] - InLocation.X) * (float)(v27[4] - InLocation.X))) )
          {
            v5 = (float)((float)((float)(v29[3] - InLocation.Z) * (float)(v29[3] - InLocation.Z)) + (float)((float)(v29[2] - InLocation.Y) * (float)(v29[2] - InLocation.Y))) + (float)((float)(v27[4] - InLocation.X) * (float)(v27[4] - InLocation.X));
            v7 = v28;
          }
          if ( v5 > (float)((float)((float)((float)(v29[6] - InLocation.Z) * (float)(v29[6] - InLocation.Z)) + (float)((float)(v29[5] - InLocation.Y) * (float)(v29[5] - InLocation.Y))) + (float)((float)(v27[7] - InLocation.X) * (float)(v27[7] - InLocation.X))) )
          {
            v5 = (float)((float)((float)(v29[6] - InLocation.Z) * (float)(v29[6] - InLocation.Z)) + (float)((float)(v29[5] - InLocation.Y) * (float)(v29[5] - InLocation.Y))) + (float)((float)(v27[7] - InLocation.X) * (float)(v27[7] - InLocation.X));
            v7 = v28 + 1;
          }
          v25 = v25 + (4);
          v27 = v27 + (12);
          v29 = v29 + (12);
          v28 = v28 + (4);
        }
        while ( v25 < v24 - 3 );
        v6 = this;
      }
      if ( v25 < v24 )
      {
fixed(var ptr2 =&v6.SplineLocations)
        v30 =  ptr2[v25].X;
        do
        {
          if ( v5 > (float)((float)((float)((float)(v30[2] - InLocation.Z) * (float)(v30[2] - InLocation.Z)) + (float)((float)(v30[1] - InLocation.Y) * (float)(v30[1] - InLocation.Y))) + (float)((float)(*v30 - InLocation.X) * (float)(*v30 - InLocation.X))) )
          {
            v5 = (float)((float)((float)(v30[2] - InLocation.Z) * (float)(v30[2] - InLocation.Z)) + (float)((float)(v30[1] - InLocation.Y) * (float)(v30[1] - InLocation.Y))) + (float)((float)(*v30 - InLocation.X) * (float)(*v30 - InLocation.X));
            v7 = v25;
          }
          ++v25;
          v30 = v30 + (3);
        }
        while ( v25 < v24 );
      }
    }
    else
    {
      v8 = this.NumSplineSegments;
      v9 = LowestIndexHint;
      if ( v8 - LowestIndexHint < 4 )
      {
  LABEL_10:
        if ( v9 < v8 )
        {
fixed(var ptr3 =&v6.SplineLocations)
          v14 =  ptr3[v9].X;
          do
          {
            v15 = (float)((float)((float)(v14[2] - InLocation.Z) * (float)(v14[2] - InLocation.Z)) + (float)((float)(v14[1] - InLocation.Y) * (float)(v14[1] - InLocation.Y))) + (float)((float)(*v14 - InLocation.X) * (float)(*v14 - InLocation.X));
            if ( v5 <= v15 )
              break;
            v7 = v9++;
            v14 = v14 + (3);
            v5 = v15;
          }
          while ( v9 < v8 );
        }
      }
      else
      {
fixed(var ptr4 =&this.SplineLocations)
        v10 =  ptr4[LowestIndexHint];
fixed(var ptr5 =&v10->Z)
        v11 =  ptr5;
        v12 = &v10[1].Z;
        while ( v5 > (float)((float)((float)((float)(*v11 - InLocation.Z) * (float)(*v11 - InLocation.Z)) + (float)((float)(*(v11 - 1) - InLocation.Y) * (float)(*(v11 - 1) - InLocation.Y)))
                           + (float)((float)(*(v11 - 2) - InLocation.X) * (float)(*(v11 - 2) - InLocation.X))) )
        {
          v5 = (float)((float)((float)(*v11 - InLocation.Z) * (float)(*v11 - InLocation.Z)) + (float)((float)(*(v11 - 1) - InLocation.Y) * (float)(*(v11 - 1) - InLocation.Y))) + (float)((float)(*(v11 - 2) - InLocation.X) * (float)(*(v11 - 2) - InLocation.X));
          v7 = v9;
          if ( v5 <= (float)((float)((float)((float)(*v12 - InLocation.Z) * (float)(*v12 - InLocation.Z)) + (float)((float)(*(v12 - 1) - InLocation.Y) * (float)(*(v12 - 1) - InLocation.Y)))
                           + (float)((float)(v11[1] - InLocation.X) * (float)(v11[1] - InLocation.X))) )
            break;
          v5 = (float)((float)((float)(*v12 - InLocation.Z) * (float)(*v12 - InLocation.Z)) + (float)((float)(*(v12 - 1) - InLocation.Y) * (float)(*(v12 - 1) - InLocation.Y))) + (float)((float)(v11[1] - InLocation.X) * (float)(v11[1] - InLocation.X));
          v7 = v9 + 1;
          if ( v5 <= (float)((float)((float)((float)(v12[3] - InLocation.Z) * (float)(v12[3] - InLocation.Z)) + (float)((float)(v12[2] - InLocation.Y) * (float)(v12[2] - InLocation.Y)))
                           + (float)((float)(v11[4] - InLocation.X) * (float)(v11[4] - InLocation.X))) )
            break;
          v5 = (float)((float)((float)(v12[3] - InLocation.Z) * (float)(v12[3] - InLocation.Z)) + (float)((float)(v12[2] - InLocation.Y) * (float)(v12[2] - InLocation.Y))) + (float)((float)(v11[4] - InLocation.X) * (float)(v11[4] - InLocation.X));
          v13 = (float)((float)((float)(v12[6] - InLocation.Z) * (float)(v12[6] - InLocation.Z)) + (float)((float)(v12[5] - InLocation.Y) * (float)(v12[5] - InLocation.Y))) + (float)((float)(v11[7] - InLocation.X) * (float)(v11[7] - InLocation.X));
          v7 = v9 + 2;
          if ( v5 <= v13 )
            break;
          v7 = v9 + 3;
          v9 = v9 + (4);
          v11 = v11 + (12);
          v12 = v12 + (12);
          v5 = v13;
          if ( v9 >= v8 - 3 )
          {
            v6 = this;
            goto LABEL_10;
          }
        }
        v6 = this;
      }
      v16 = LowestIndexHint - 1;
      if ( LowestIndexHint < 4 )
      {
  LABEL_24:
        if ( v16 >= 0 )
        {
fixed(var ptr6 =&v6.SplineLocations)
          v22 =  ptr6[v16].X;
          do
          {
            v23 = (float)((float)((float)(v22[2] - InLocation.Z) * (float)(v22[2] - InLocation.Z)) + (float)((float)(v22[1] - InLocation.Y) * (float)(v22[1] - InLocation.Y))) + (float)((float)(*v22 - InLocation.X) * (float)(*v22 - InLocation.X));
            if ( v5 <= v23 )
              break;
            v7 = v16--;
            v22 = v22 - (3);
            v5 = v23;
          }
          while ( v16 >= 0 );
        }
      }
      else
      {
        v17 = (int)&v6.SplineLocations[v16];
        v18 = (float *)(v17 + 8);
        v19 = LowestIndexHint - 3;
        v20 = (float *)(v17 - 4);
        while(1 != default)
        {
          v21 = (float)((float)((float)(*v18 - InLocation.Z) * (float)(*v18 - InLocation.Z)) + (float)((float)(*(v18 - 1) - InLocation.Y) * (float)(*(v18 - 1) - InLocation.Y)))
              + (float)((float)(*(v18 - 2) - InLocation.X) * (float)(*(v18 - 2) - InLocation.X));
          if ( v5 <= v21 )
            break;
          v7 = v16;
          if ( v21 <= (float)((float)((float)((float)(*v20 - InLocation.Z) * (float)(*v20 - InLocation.Z)) + (float)((float)(*(v20 - 1) - InLocation.Y) * (float)(*(v20 - 1) - InLocation.Y)))
                            + (float)((float)(*(v18 - 5) - InLocation.X) * (float)(*(v18 - 5) - InLocation.X))) )
            break;
          v7 = v19 + 1;
          if ( (float)((float)((float)((float)(*v20 - InLocation.Z) * (float)(*v20 - InLocation.Z)) + (float)((float)(*(v20 - 1) - InLocation.Y) * (float)(*(v20 - 1) - InLocation.Y)))
                     + (float)((float)(*(v18 - 5) - InLocation.X) * (float)(*(v18 - 5) - InLocation.X))) <= (float)((float)((float)((float)(*(v20 - 3) - InLocation.Z) * (float)(*(v20 - 3) - InLocation.Z))
                                                                                                                          + (float)((float)(*(v20 - 4) - InLocation.Y) * (float)(*(v20 - 4) - InLocation.Y)))
                                                                                                                  + (float)((float)(*(v18 - 8) - InLocation.X) * (float)(*(v18 - 8) - InLocation.X))) )
            break;
          v5 = (float)((float)((float)(*(v20 - 6) - InLocation.Z) * (float)(*(v20 - 6) - InLocation.Z)) + (float)((float)(*(v20 - 7) - InLocation.Y) * (float)(*(v20 - 7) - InLocation.Y)))
             + (float)((float)(*(v18 - 11) - InLocation.X) * (float)(*(v18 - 11) - InLocation.X));
          v7 = v19;
          if ( (float)((float)((float)((float)(*(v20 - 3) - InLocation.Z) * (float)(*(v20 - 3) - InLocation.Z)) + (float)((float)(*(v20 - 4) - InLocation.Y) * (float)(*(v20 - 4) - InLocation.Y)))
                     + (float)((float)(*(v18 - 8) - InLocation.X) * (float)(*(v18 - 8) - InLocation.X))) <= v5 )
            break;
          v7 = v19 - 1;
          v16 = v16 - (4);
          v18 = v18 - (12);
          v20 = v20 - (12);
          v19 = v19 - (4);
          if ( v16 < 3 )
          {
            v6 = this;
            goto LABEL_24;
          }
        }
        v6 = this;
      }
    }
    v31 = v6.SplineLocations.Count;
    if ( default == v31 )
    {
      ClosestLocation->X = 0.0f;
      ClosestLocation->Y = 0.0f;
      ClosestLocation->Z = 0.0f;
      *NParamT = -1.0f;
      return;
    }
    if ( v31 < 2 )
    {
      *ClosestLocation = *v6.SplineLocations.Data;
      *NParamT = 0.0f;
      return;
    }
    if ( default == v7 )
    {
      v7 = 1;
  LABEL_55:
      if ( v7 != v31 - 1 )
      {
        v32 = v6.SplineLocations.Data;
        v33 = v32[v7 - 1].Z - InLocation.Z;
        v34 = (float)((float)(v33 * v33) + (float)((float)(v32[v7 - 1].Y - InLocation.Y) * (float)(v32[v7 - 1].Y - InLocation.Y))) + (float)((float)(v32[v7 - 1].X - InLocation.X) * (float)(v32[v7 - 1].X - InLocation.X));
        v35 = v32[v7 + 1].Z - InLocation.Z;
        v36 = v32[v7 + 1].Y - InLocation.Y;
        v37 = v32[v7 + 1].X - InLocation.X;
        if ( v34 > (float)((float)((float)(v35 * v35) + (float)(v36 * v36)) + (float)(v37 * v37)) )
          ++v7;
      }
      goto LABEL_58;
    }
    if ( v7 > 0 )
      goto LABEL_55;
  LABEL_58:
    v38 = v6.SplineLocations.Data;
    v39 = v38[v7].Y - v38[v7 - 1].Y;
    v40 = v38[v7].Z - v38[v7 - 1].Z;
    v41 = v38[v7].X - v38[v7 - 1].X;
    v42 = &v38[v7];
    v43 = (float)((float)(v40 * v40) + (float)(v39 * v39)) + (float)(v41 * v41);
    v44 = (float)((float)((float)((float)(InLocation.Z - v42[-1].Z) * v40) + (float)((float)(InLocation.Y - v42[-1].Y) * v39)) + (float)((float)(InLocation.X - v42[-1].X) * v41)) / v43;
    v53 = v40 * v44;
    v52 = v39 * v44;
    v45 = (float)(v44 * v41) + v42[-1].X;
    v46 = (float)(v44 * v41) * (float)(v44 * v41);
    a3a = v42[-1].Y + (float)(v39 * v44);
    v47 = v42[-1].Z;
    v48 = v45;
    *(float *)&v49 = 0.0f;
    ClosestLocation->X = v48;
    ClosestLocation->Y = a3a;
    ClosestLocation->Z = v47 + v53;
    a5a = (float)(sqrt((v53 * v53 + v52 * v52 + v46) / v43));
    *NParamT = a5a;
    v50 = a5a;
    if ( a5a < 0.0f || (*(float *)&v49 = 1.0f, a5a > 1.0f) )
      v50 = *(float *)&v49;
    *NParamT = (float)(v7 - 1) + v50;
  }

  public unsafe int IsSplineMarkerSelected()
  {
    int v2 = default; // esi
    TdMovementSplineMarker *v3; // eax
    bool v4 = default; // zf
    TdMovementSplineMarker *v5; // eax
  
    v2 = default;
    if ( this.SplineMarkers.Count <= 0 )
      return 0;
    while(1 != default)
    {
      v3 = this.SplineMarkers.Data;
      v4 = v3[v2] == 0;
      v5 = &v3[v2];
      if ( default == v4 )
      {
        if ( (*(int (__thiscall **)(TdMovementSplineMarker ))((*v5).VfTableObject.Dummy + 204))(*v5) )
          break;
      }
      if ( ++v2 >= this.SplineMarkers.Count )
        return 0;
    }
    return 1;
  }
}
}
