// NO OVERWRITE

namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdPlayerController
{
  /*public unsafe bool Unknown2()
  {
    return this.Pawn != 0;
  }*/

  public unsafe double Unknown5(TdPawn a2, float a3, Vector *a4, Rotator *a5)
  {
    float v5 = default; // xmm0_4
    float v6 = default; // xmm0_4
    float v7 = default; // xmm2_4
    float v8 = default; // xmm4_4
    float v9 = default; // xmm0_4
    float v10 = default; // xmm1_4
    float v11 = default; // xmm1_4
    double result = default; // st7
    float v13 = default; // [esp+4h] [ebp-3Ch]
    float v14 = default; // [esp+8h] [ebp-38h]
    float v15 = default; // [esp+Ch] [ebp-34h]
    float v16 = default; // [esp+14h] [ebp-2Ch]
    Vector a2a = default; // [esp+24h] [ebp-1Ch] BYREF
    float v18 = default; // [esp+30h] [ebp-10h]
    float a4a = default; // [esp+4Ch] [ebp+Ch]

    if( default == a2 )
      return 0f;
    if ( default == this.Pawn )
      return 0f;
    v13 = a2.Location.X - a4->X;
    v14 = a2.Location.Y - a4->Y;
    v15 = a2.Location.Z - a4->Z;
    a5->Vector(&a2a);
    v5 = (float)((float)(v15 * v15) + (float)(v14 * v14)) + (float)(v13 * v13);
    v18 = v5;
    a4a = (float)((a3 - sqrt(v5)) / a3 * 0.19999999f);
    if ( v5 == 1.0f )
    {
      v6 = v13;
      v7 = v14;
      v8 = v15;
    }
    else if ( v5 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
    {
      v9 = fsqrt(v18);
      v16 = (float)(3.0f - (float)((float)((float)(1.0f / v9) * v18) * (float)(1.0f / v9))) * (float)((float)(1.0f / v9) * 0.5f);
      v6 = v16 * v13;
      v7 = v16 * v14;
      v8 = v15 * v16;
    }
    else
    {
      v6 = 0.0f;
      v7 = 0.0f;
      v8 = 0.0f;
    }
    v10 = (float)((float)(a2a.Z * v8) + (float)(a2a.Y * v7)) + (float)(v6 * a2a.X);
    if ( v10 <= 0.0f )
      v10 = 0.0f;
    v11 = (float)(v10 * 0.80000001d);
    if ( v11 <= a3 && v11 != 0.0f )
      result = (float)(v11 + a4a);
    else
      result = 0.0f;
    return result;
  }

  public unsafe TdPawn GetAATarget(float a2)
  {
    float v3 = default; // eax
    float v4 = default; // ecx
    float v5 = default; // edx
    int v6 = default; // eax
    int v7 = default; // ecx
    int v8 = default; // ebp
    int v9 = default; // ebx
    LocalEnemy[] v10; // esi
    TdPawn v11 = default; // eax
    //LocalEnemy *v12; // esi
    double v13 = default; // st7
    float v15 = default; // [esp+1Ch] [ebp-24h]
    TdPawn v16 = default; // [esp+20h] [ebp-20h]
    float v17 = default; // [esp+24h] [ebp-1Ch]
    Rotator a3 = default; // [esp+28h] [ebp-18h] BYREF
    Vector a4 = default; // [esp+34h] [ebp-Ch] BYREF
  
    v3 = this.Location.X;
    v4 = this.Location.Y;
    v5 = this.Location.Z;
    a4.X = v3;
    v6 = this.Rotation.Pitch;
    a4.Y = v4;
    v7 = this.Rotation.Yaw;
    a3.Pitch = v6;
    a3.Yaw = v7;
    a4.Z = v5;
    v16 = default;
    v15 = 0.0f;
    a3.Roll = this.Rotation.Roll;
    this.GetPlayerViewPoint(ref a4, ref a3);
    if ( this.LocalEnemies.Count <= 0 )
      return null;
    v8 = default;
    v9 = this.LocalEnemies.Count;
    do
    {
      v10 = this.LocalEnemies.Data;
      v11 = v10[v8].Enemy;
      ref var v12 = ref v10[v8];
      if(v11 != default)
      {
        if ( (v12.bVisible.AsBitfield(1) & 1) != default )
        {
          v13 = this.Unknown5(v11, a2, &a4, &a3);
          if ( v13 > v15 )
          {
            v17 = (float)v13;
            v15 = v17;
            v16 = v12.Enemy;
          }
        }
      }
      ++v8;
      --v9;
    }
    while(v9 != default);
    return v16;
  }

  public unsafe TdPawn  GetMeleeTarget(float a2)
  {
    int v3 = default; // ebp
    int v4 = default; // ebx
    LocalEnemy[] v5; // esi
    TdPawn v6 = default; // eax
    //LocalEnemy *v7; // esi
    double v8 = default; // st7
    float v10 = default; // [esp+1Ch] [ebp-Ch]
    TdPawn v11 = default; // [esp+20h] [ebp-8h]
    float v12 = default; // [esp+24h] [ebp-4h]
  
    v11 = default;
    v10 = 0.0f;
    if ( this.LocalEnemies.Count <= 0 )
      return null;
    v3 = default;
    v4 = this.LocalEnemies.Count;
    do
    {
      v5 = this.LocalEnemies.Data;
      v6 = v5[v3].Enemy;
      ref var v7 = ref v5[v3];
      if(v6 != default)
      {
        if ( (v7.bVisible.AsBitfield(1) & 1) != default )
        {
          fixed( Vector* ptr1 = & this.Pawn.Location )
          {
            fixed( Rotator* ptr2 = & this.Pawn.Rotation )
            {
              v8 = this.Unknown5(v6, a2, ptr1, ptr2);
            }
          }
          if ( v8 > v10 )
          {
            v12 = (float)v8;
            v10 = v12;
            v11 = v7.Enemy;
          }
        }
      }
      ++v3;
      --v4;
    }
    while(v4 != default);
    return v11;
  }
/*
  public unsafe int Unknown3()
  {
    int v2 = default; // esi
    int v3 = default; // eax
    int v4 = default; // eax
    int v6 = default; // [esp+Ch] [ebp-8h] BYREF
    int v7 = default; // [esp+10h] [ebp-4h]
  
    if ( (this.bFrozen.AsBitfield(26) & 0x4000) != default )
    {
      v2 = this.VfTableObject.Dummy;
      v6 = default;
      CallUFunction(this.IsCutsceneSkippable, this, v3, &v6, 0);
      if(v6 != default)
      {
        sub_B3B560(&v6);
        while ( v7 >= 0 && v7 < dword_204A348 )
        {
          v4 = *(_DWORD *)(*(_DWORD *)(dword_204A344 + 4 * v7) + 308);
          if ( (v4 & 1) != default && (v4 & 0x1000) != default && ((v4 & 0x400) != default || sub_B81700(GWorld)) )
            return 1;
          sub_B3AB20(&v6);
        }
      }
    }
    return 0;
  }

  public unsafe int Unknown()
  {
    int v2 = default; // edi
    int v3 = default; // esi
    int v4 = default; // eax
    int v5 = default; // esi
    int v6 = default; // ecx
    int v7 = default; // eax
    int v8 = default; // eax
    Object v9 = default; // eax
    int v11 = default; // [esp+24h] [ebp-8h] BYREF
    int v12 = default; // [esp+28h] [ebp-4h]
  
    v2 = default;
    if ( (this.bFrozen.AsBitfield(26) & 0x4000) != default )
    {
      v3 = this.VfTableObject.Dummy;
      v11 = default;
      CallUFunction(this.IsCutsceneSkippable, this, v4, &v11, 0);
      if(v11 != default)
      {
        sub_B3B560(&v11);
        while(1 != default)
        {
          v5 = v12;
          if ( v12 < 0 || v12 >= dword_204A348 )
          {
            if(v2 != default)
            {
              if(GWorld != default)
              {
                if ( sub_B82C40(GWorld) )
                {
                  v9 = (Object )sub_B82C40(GWorld);
                  sub_B37950(v9);
                  sub_11C3470(this, 0.5f, 0, 0);
                }
              }
            }
            return 0;
          }
          v6 = dword_204A344;
          v7 = *(_DWORD *)(*(_DWORD *)(dword_204A344 + 4 * v12) + 308);
          if ( (v7 & 1) != default && (v7 & 0x1000) != default )
          {
            if ( (v7 & 0x400) == default )
            {
              if ( default == sub_B81700(GWorld) )
                goto LABEL_13;
              v6 = dword_204A344;
            }
            v8 = *(_DWORD *)(v6 + 4 * v5);
            if ( (float)(*(float *)(*(_DWORD *)(v8 + 324) + 140) - 0.0099999998d) > *(float *)(v8 + 300) )
            {
              sub_E4F960((int *)v8, *(float *)(*(_DWORD *)(v8 + 324) + 140) - 0.0099999998d, 1);
              (*(void (__thiscall **)(int, int, _DWORD))(*(_DWORD *)dword_2018710 + 12))(dword_2018710, 48, *(_DWORD *)(dword_204A344 + 4 * v5));
              v2 = 1;
            }
          }
  LABEL_13:
          sub_B3AB20(&v11);
        }
      }
    }
    return 0;
  }*/
}
}
