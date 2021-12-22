namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdPlayerController
{
  public unsafe bool Unknown2()
  {
    return this.Pawn != 0;
  }

  public unsafe int UNKNOWN2(float a2)
  {
    int v3 = default; // ebp
    int v4 = default; // ebx
    LocalEnemy *v5; // esi
    int v6 = default; // eax
    LocalEnemy *v7; // esi
    double v8 = default; // st7
    float v10 = default; // [esp+1Ch] [ebp-Ch]
    int v11 = default; // [esp+20h] [ebp-8h]
    float v12 = default; // [esp+24h] [ebp-4h]
  
    v11 = default;
    v10 = 0.0f;
    if ( this.LocalEnemies.Count <= 0 )
      return 0;
    v3 = default;
    v4 = this.LocalEnemies.Count;
    do
    {
      v5 = this.LocalEnemies.Data;
      v6 = (int)v5[v3].Enemy;
      v7 = &v5[v3];
      if(v6 != default)
      {
        if ( (v7->bitfield_bVisible & 1) != 0 )
        {
          v8 = sub_11C2DC0(
                 this,
                 v6,
                 a2,
                 (int)&this.Pawn.PlayerController::Controller::Location,
                 (int)&this.Pawn.PlayerController::Controller::Rotation);
          if ( v8 > v10 )
          {
            v12 = (float)v8;
            v10 = v12;
            v11 = (int)v7->Enemy;
          }
        }
      }
      ++v3;
      --v4;
    }
    while(v4 != default);
    return (int)(v11);
  }

  public override unsafe int Unknown()
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
    if ( (this.bFrozen.AsBitfield(26) & 0x4000) != 0 )
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
          if ( (v7 & 1) != 0 && (v7 & 0x1000) != 0 )
          {
            if ( (v7 & 0x400) == 0 )
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
  }
}
}
