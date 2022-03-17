// NO OVERWRITE

namespace MEdge.TdGame{
  using Core; using ECustomNodeType = TdPawn.CustomNodeType; using EMoveAimMode = TdPawn.MoveAimMode; using static Source.DecFn;



public partial class TdMovementVolume
{
  public unsafe Vector * GetLocationOnSpline(Vector *a2, float a3)
  {
    float v3 = default; // xmm2_4
    float v4 = default; // xmm3_4
    Vector *result; // eax
    float v6 = default; // xmm0_4
    float v7 = default; // xmm5_4
    float v8 = default; // xmm6_4
    float v9 = default; // xmm4_4
    float v10 = default; // xmm0_4
    float v11 = default; // xmm1_4
    float v12 = default; // xmm7_4
    float v13 = default; // xmm0_4
    float v14 = default; // xmm2_4
    float v15 = default; // [esp+0h] [ebp-8h]
  
    v3 = 0.0f;
    if ( a3 >= 0.0f )
    {
      v3 = a3;
      if ( a3 > 1.0f )
        v3 = 1.0f;
    }
    v4 = End.Z;
    result = a2;
    v6 = 1.0f - v3;
    v7 = Start.Y * (v6 * v6);
    v8 = Start.Z * (v6 * v6);
    v9 = Start.X * (v6 * v6);
    v10 = (1.0f - v3) * v3 * 2.0f;
    v15 = Middle.Y * v10;
    v11 = Middle.Z * v10;
    v12 = Middle.X * v10;
    v13 = v3 * v3;
    v14 = End.Y * (v3 * v3) + v15 + v7;
    a2->X = End.X * v13 + v12 + v9;
    a2->Y = v14;
    a2->Z = v4 * v13 + v11 + v8;
    return result;
  }



  public unsafe Vector GetSlopeOnSpline( float ParamT )
  {
    Vector v = default;
    return *GetSlopeOnSpline( & v, ParamT );
  }



  public unsafe Vector * GetSlopeOnSpline(Vector *returnValue, float ParamT)
  {
    float v3 = default; // xmm7_4
    float v4 = default; // xmm4_4
    float v5 = default; // xmm5_4
    float v6 = default; // xmm6_4
    float v7 = default; // xmm0_4
    Vector *result; // eax
    float v9 = default; // xmm0_4
    float v10 = default; // [esp+0h] [ebp-30h]
    float v11 = default; // [esp+20h] [ebp-10h]
  
    v3 = 0.0f;
    if ( ParamT >= 0.0f )
    {
      v3 = ParamT;
      if ( ParamT > 1.0f )
        v3 = 1.0f;
    }
    v4 = (Middle.Y - Start.Y) * (1.0f - v3) + (End.Y - Middle.Y) * v3;
    v5 = (Middle.Z - Start.Z) * (1.0f - v3) + (End.Z - Middle.Z) * v3;
    v6 = (Middle.X - Start.X) * (1.0f - v3) + (End.X - Middle.X) * v3;
    v7 = v5 * v5 + v4 * v4 + v6 * v6;
    v11 = v7;
    if ( v7 == 1.0f )
    {
      result = returnValue;
      returnValue->X = (Middle.X - Start.X) * (1.0f - v3) + (End.X - Middle.X) * v3;
      returnValue->Y = v4;
      returnValue->Z = v5;
    }
    else if ( v7 >= SMALL_NUMBER )
    {
      v9 = fsqrt(v7);
      v10 = (3.0f - 1.0f / v9 * v11 * (1.0f / v9)) * (1.0f / v9 * 0.5f);
      result = returnValue;
      returnValue->X = v10 * v6;
      returnValue->Y = v4 * v10;
      returnValue->Z = v5 * v10;
    }
    else
    {
      result = returnValue;
      returnValue->X = 0.0f;
      returnValue->Y = 0.0f;
      returnValue->Z = 0.0f;
    }
    return result;
  }

  public unsafe void FindClosestPointOnDSpline(Vector InLocation, ref Vector ClosestLocation, ref float NParamT, int LowestIndexHint)
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
    Vector* v17 = default; // esi
    float *v18; // edi
    int v19 = default; // ebx
    float *v20; // esi
    float v21 = default; // xmm4_4
    float *v22; // esi
    float v23 = default; // xmm4_4
    int v24 = default; // ecx
    int v25 = default; // eax
    //Vector *v26; // esi
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
    float v49 = default; // xmm1_4
    float v50 = default; // xmm0_4
    float v52 = default; // [esp+8h] [ebp-8h]
    float v53 = default; // [esp+Ch] [ebp-4h]
    float a3a = default; // [esp+18h] [ebp+8h]
    float a5a = default; // [esp+20h] [ebp+10h]


    fixed( Vector* splineDataPtr = SplineLocations.Data )
    {

      v5 = 3.4028235e38f;
      v6 = this;
      v7 = default;
      if( LowestIndexHint < 0 )
      {
        v24 = NumSplineSegments;
        v25 = default;
        if( v24 >= 4 )
        {
          v27 = &splineDataPtr->Z;
          v28 = 2;
          v29 = & splineDataPtr[ 1 ].Z;
          do
          {
            if( v5 > (* v27 - InLocation.Z) * (* v27 - InLocation.Z) + (* ( v27 - 1 ) - InLocation.Y) * (* ( v27 - 1 ) - InLocation.Y)
                                                                     + (* ( v27 - 2 ) - InLocation.X) * (* ( v27 - 2 ) - InLocation.X) )
            {
              v5 = (* v27 - InLocation.Z) * (* v27 - InLocation.Z) + (* ( v27 - 1 ) - InLocation.Y) * (* ( v27 - 1 ) - InLocation.Y)
                                                                   + (* ( v27 - 2 ) - InLocation.X) * (* ( v27 - 2 ) - InLocation.X);
              v7 = v25;
            }

            if( v5 > (* v29 - InLocation.Z) * (* v29 - InLocation.Z) + (* ( v29 - 1 ) - InLocation.Y) * (* ( v29 - 1 ) - InLocation.Y)
                                                                     + (v27[ 1 ] - InLocation.X) * (v27[ 1 ] - InLocation.X) )
            {
              v5 = (* v29 - InLocation.Z) * (* v29 - InLocation.Z) + (* ( v29 - 1 ) - InLocation.Y) * (* ( v29 - 1 ) - InLocation.Y) + (v27[ 1 ] - InLocation.X) * (v27[ 1 ] - InLocation.X);
              v7 = v28 - 1;
            }

            if( v5 > (v29[ 3 ] - InLocation.Z) * (v29[ 3 ] - InLocation.Z) + (v29[ 2 ] - InLocation.Y) * (v29[ 2 ] - InLocation.Y) + (v27[ 4 ] - InLocation.X) * (v27[ 4 ] - InLocation.X) )
            {
              v5 = (v29[ 3 ] - InLocation.Z) * (v29[ 3 ] - InLocation.Z) + (v29[ 2 ] - InLocation.Y) * (v29[ 2 ] - InLocation.Y) + (v27[ 4 ] - InLocation.X) * (v27[ 4 ] - InLocation.X);
              v7 = v28;
            }

            if( v5 > (v29[ 6 ] - InLocation.Z) * (v29[ 6 ] - InLocation.Z) + (v29[ 5 ] - InLocation.Y) * (v29[ 5 ] - InLocation.Y) + (v27[ 7 ] - InLocation.X) * (v27[ 7 ] - InLocation.X) )
            {
              v5 = (v29[ 6 ] - InLocation.Z) * (v29[ 6 ] - InLocation.Z) + (v29[ 5 ] - InLocation.Y) * (v29[ 5 ] - InLocation.Y) + (v27[ 7 ] - InLocation.X) * (v27[ 7 ] - InLocation.X);
              v7 = v28 + 1;
            }

            v25 = v25 + ( 4 );
            v27 = v27 + ( 12 );
            v29 = v29 + ( 12 );
            v28 = v28 + ( 4 );
          } while( v25 < v24 - 3 );

          v6 = this;
        }

        if( v25 < v24 )
        {
          v30 = &splineDataPtr[ v25 ].X;
          do
          {
            if( v5 > (v30[ 2 ] - InLocation.Z) * (v30[ 2 ] - InLocation.Z) + (v30[ 1 ] - InLocation.Y) * (v30[ 1 ] - InLocation.Y) + (* v30 - InLocation.X) * (* v30 - InLocation.X) )
            {
              v5 = (v30[ 2 ] - InLocation.Z) * (v30[ 2 ] - InLocation.Z) + (v30[ 1 ] - InLocation.Y) * (v30[ 1 ] - InLocation.Y) + (* v30 - InLocation.X) * (* v30 - InLocation.X);
              v7 = v25;
            }

            ++v25;
            v30 = v30 + ( 3 );
          } while( v25 < v24 );
        }
      }
      else
      {
        v8 = NumSplineSegments;
        v9 = LowestIndexHint;
        if( v8 - LowestIndexHint < 4 )
        {
          if( v9 < v8 )
          {
            v14 = &splineDataPtr[ v9 ].X;
            do
            {
              v15 = (v14[ 2 ] - InLocation.Z) * (v14[ 2 ] - InLocation.Z) + (v14[ 1 ] - InLocation.Y) * (v14[ 1 ] - InLocation.Y) + (* v14 - InLocation.X) * (* v14 - InLocation.X);
              if( v5 <= v15 )
                break;
              v7 = v9++;
              v14 = v14 + ( 3 );
              v5 = v15;
            } while( v9 < v8 );
          }
        }
        else
        {
          v10 = &splineDataPtr[ LowestIndexHint ];
          v11 = & v10 -> Z;
          v12 = & v10[ 1 ].Z;
          while( v5 > (* v11 - InLocation.Z) * (* v11 - InLocation.Z) + (* ( v11 - 1 ) - InLocation.Y) * (* ( v11 - 1 ) - InLocation.Y)
                                                                      + (* ( v11 - 2 ) - InLocation.X) * (* ( v11 - 2 ) - InLocation.X) )
          {
            v5 = (* v11 - InLocation.Z) * (* v11 - InLocation.Z) + (* ( v11 - 1 ) - InLocation.Y) * (* ( v11 - 1 ) - InLocation.Y) + (* ( v11 - 2 ) - InLocation.X) * (* ( v11 - 2 ) - InLocation.X);
            v7 = v9;
            if( v5 <= (* v12 - InLocation.Z) * (* v12 - InLocation.Z) + (* ( v12 - 1 ) - InLocation.Y) * (* ( v12 - 1 ) - InLocation.Y)
                                                                      + (v11[ 1 ] - InLocation.X) * (v11[ 1 ] - InLocation.X) )
              break;
            v5 = (* v12 - InLocation.Z) * (* v12 - InLocation.Z) + (* ( v12 - 1 ) - InLocation.Y) * (* ( v12 - 1 ) - InLocation.Y) + (v11[ 1 ] - InLocation.X) * (v11[ 1 ] - InLocation.X);
            v7 = v9 + 1;
            if( v5 <= (v12[ 3 ] - InLocation.Z) * (v12[ 3 ] - InLocation.Z) + (v12[ 2 ] - InLocation.Y) * (v12[ 2 ] - InLocation.Y)
                                                                            + (v11[ 4 ] - InLocation.X) * (v11[ 4 ] - InLocation.X) )
              break;
            v5 = (v12[ 3 ] - InLocation.Z) * (v12[ 3 ] - InLocation.Z) + (v12[ 2 ] - InLocation.Y) * (v12[ 2 ] - InLocation.Y) + (v11[ 4 ] - InLocation.X) * (v11[ 4 ] - InLocation.X);
            v13 = (v12[ 6 ] - InLocation.Z) * (v12[ 6 ] - InLocation.Z) + (v12[ 5 ] - InLocation.Y) * (v12[ 5 ] - InLocation.Y) + (v11[ 7 ] - InLocation.X) * (v11[ 7 ] - InLocation.X);
            v7 = v9 + 2;
            if( v5 <= v13 )
              break;
            v7 = v9 + 3;
            v9 = v9 + ( 4 );
            v11 = v11 + ( 12 );
            v12 = v12 + ( 12 );
            v5 = v13;
            if( v9 >= v8 - 3 )
            {
              v6 = this;
              if( v9 < v8 )
              {
                v14 = &splineDataPtr[ v9 ].X;
                do
                {
                  v15 = (v14[ 2 ] - InLocation.Z) * (v14[ 2 ] - InLocation.Z) + (v14[ 1 ] - InLocation.Y) * (v14[ 1 ] - InLocation.Y) + (* v14 - InLocation.X) * (* v14 - InLocation.X);
                  if( v5 <= v15 )
                    break;
                  v7 = v9++;
                  v14 = v14 + ( 3 );
                  v5 = v15;
                } while( v9 < v8 );
              }

              break;
            }
          }

          v6 = this;
        }

        v16 = LowestIndexHint - 1;
        if( LowestIndexHint < 4 )
        {
          if( v16 >= 0 )
          {
            v22 = &splineDataPtr[ v16 ].X;
            do
            {
              v23 = (v22[ 2 ] - InLocation.Z) * (v22[ 2 ] - InLocation.Z) + (v22[ 1 ] - InLocation.Y) * (v22[ 1 ] - InLocation.Y) + (* v22 - InLocation.X) * (* v22 - InLocation.X);
              if( v5 <= v23 )
                break;
              v7 = v16--;
              v22 = v22 - ( 3 );
              v5 = v23;
            } while( v16 >= 0 );
          }
        }
        else
        {
          v17 = & splineDataPtr[ v16 ];
          v18 = &v17->Z;
          v19 = LowestIndexHint - 3;
          v20 = &v17[-1].Z;
          while( 1 != default )
          {
            v21 = (* v18 - InLocation.Z) * (* v18 - InLocation.Z) + (* ( v18 - 1 ) - InLocation.Y) * (* ( v18 - 1 ) - InLocation.Y)
                                                                  + (* ( v18 - 2 ) - InLocation.X) * (* ( v18 - 2 ) - InLocation.X);
            if( v5 <= v21 )
              break;
            v7 = v16;
            if( v21 <= (* v20 - InLocation.Z) * (* v20 - InLocation.Z) + (* ( v20 - 1 ) - InLocation.Y) * (* ( v20 - 1 ) - InLocation.Y)
                                                                       + (* ( v18 - 5 ) - InLocation.X) * (* ( v18 - 5 ) - InLocation.X) )
              break;
            v7 = v19 + 1;
            if( (* v20 - InLocation.Z) * (* v20 - InLocation.Z) + (* ( v20 - 1 ) - InLocation.Y) * (* ( v20 - 1 ) - InLocation.Y)
                                                                + (* ( v18 - 5 ) - InLocation.X) * (* ( v18 - 5 ) - InLocation.X) <= (* ( v20 - 3 ) - InLocation.Z) * (* ( v20 - 3 ) - InLocation.Z)
              + (* ( v20 - 4 ) - InLocation.Y) * (* ( v20 - 4 ) - InLocation.Y)
              + (* ( v18 - 8 ) - InLocation.X) * (* ( v18 - 8 ) - InLocation.X) )
              break;
            v5 = (* ( v20 - 6 ) - InLocation.Z) * (* ( v20 - 6 ) - InLocation.Z) + (* ( v20 - 7 ) - InLocation.Y) * (* ( v20 - 7 ) - InLocation.Y)
                                                                                 + (* ( v18 - 11 ) - InLocation.X) * (* ( v18 - 11 ) - InLocation.X);
            v7 = v19;
            if( (* ( v20 - 3 ) - InLocation.Z) * (* ( v20 - 3 ) - InLocation.Z) + (* ( v20 - 4 ) - InLocation.Y) * (* ( v20 - 4 ) - InLocation.Y)
                                                                                + (* ( v18 - 8 ) - InLocation.X) * (* ( v18 - 8 ) - InLocation.X) <= v5 )
              break;
            v7 = v19 - 1;
            v16 = v16 - ( 4 );
            v18 = v18 - ( 12 );
            v20 = v20 - ( 12 );
            v19 = v19 - ( 4 );
            if( v16 < 3 )
            {
              v6 = this;
              if( v16 >= 0 )
              {
                v22 = &splineDataPtr[ v16 ].X;
                do
                {
                  v23 = (v22[ 2 ] - InLocation.Z) * (v22[ 2 ] - InLocation.Z) + (v22[ 1 ] - InLocation.Y) * (v22[ 1 ] - InLocation.Y) + (* v22 - InLocation.X) * (* v22 - InLocation.X);
                  if( v5 <= v23 )
                    break;
                  v7 = v16--;
                  v22 = v22 - ( 3 );
                  v5 = v23;
                } while( v16 >= 0 );
              }

              break;
            }
          }

          v6 = this;
        }
      }

      v31 = v6.SplineLocations.Count;
      if( default == v31 )
      {
        ClosestLocation.X = 0.0f;
        ClosestLocation.Y = 0.0f;
        ClosestLocation.Z = 0.0f;
        NParamT = - 1.0f;
        return;
      }

      if( v31 < 2 )
      {
        ClosestLocation = * splineDataPtr;
        NParamT = 0.0f;
        return;
      }

      if( default == v7 )
      {
        v7 = 1;
      }

      if( v7 > 0 )
      {
        if( v7 != v31 - 1 )
        {
          v32 = splineDataPtr;
          v33 = v32[ v7 - 1 ].Z - InLocation.Z;
          v34 = v33 * v33 + (v32[ v7 - 1 ].Y - InLocation.Y) * (v32[ v7 - 1 ].Y - InLocation.Y) + (v32[ v7 - 1 ].X - InLocation.X) * (v32[ v7 - 1 ].X - InLocation.X);
          v35 = v32[ v7 + 1 ].Z - InLocation.Z;
          v36 = v32[ v7 + 1 ].Y - InLocation.Y;
          v37 = v32[ v7 + 1 ].X - InLocation.X;
          if( v34 > v35 * v35 + v36 * v36 + v37 * v37 )
            ++v7;
        }
      }

      v38 = splineDataPtr;
      v39 = v38[ v7 ].Y - v38[ v7 - 1 ].Y;
      v40 = v38[ v7 ].Z - v38[ v7 - 1 ].Z;
      v41 = v38[ v7 ].X - v38[ v7 - 1 ].X;
      v42 = & v38[ v7 ];
      v43 = v40 * v40 + v39 * v39 + v41 * v41;
      v44 = ((InLocation.Z - v42[ - 1 ].Z) * v40 + (InLocation.Y - v42[ - 1 ].Y) * v39 + (InLocation.X - v42[ - 1 ].X) * v41) / v43;
      v53 = v40 * v44;
      v52 = v39 * v44;
      v45 = v44 * v41 + v42[ - 1 ].X;
      v46 = v44 * v41 * (v44 * v41);
      a3a = v42[ - 1 ].Y + v39 * v44;
      v47 = v42[ - 1 ].Z;
      v48 = v45;
      v49 = 0.0f;
      ClosestLocation.X = v48;
      ClosestLocation.Y = a3a;
      ClosestLocation.Z = v47 + v53;
      a5a = (float) ( sqrt( ( v53 * v53 + v52 * v52 + v46 ) / v43 ) );
      NParamT = a5a;
      v50 = a5a;
      if( a5a < 0.0f || ( (v49 = 1.0f) is object && a5a > 1.0f ) )
        v50 = v49;
      NParamT = v7 - 1 + v50;
    }
  }

  public int IsSplineMarkerSelected()
  {
    NativeMarkers.MarkUnimplemented();
    return default;
    /*int v2 = default; // esi
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
    return 1;*/
  }
}
}
