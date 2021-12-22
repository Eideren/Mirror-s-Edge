namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdLadderVolume
{
  public unsafe int GetClosestStepDown(float a2)
  {
    int v3 = default; // esi
    byte* v5 = stackalloc byte[12]; // [esp+8h] [ebp-Ch] BYREF
  
    v3 = (*(int (__thiscall **)(void *))(*(_DWORD *)this + 856))(this);
    if ( v3 < 0 )
      return 0;
    while ( a2 <= *(float *)((*(int (__thiscall **)(void *, byte *, int))(*(_DWORD *)this + 840))(this, v5, v3) + 8) )
    {
      if ( --v3 < 0 )
        return 0;
    }
    return (int)(v3);
  }

  public unsafe int GetClosestStep(float a2)
  {
    int v3 = default; // edi
    int v4 = default; // ebx
    float i = default; // [esp+18h] [ebp-1Ch]
    byte* v7 = stackalloc byte[12]; // [esp+1Ch] [ebp-18h] BYREF
    float* v8 = stackalloc float[3]; // [esp+28h] [ebp-Ch] BYREF
  
    v3 = 1;
    v4 = default;
    for ( i = (float)(fabs(*(float *)((*(int (__thiscall **)(_DWORD *, byte *, _DWORD))(*this + 840))(this, v7, 0) + 8) - a2)); v3 < this[187]; ++v3 )
    {
      if ( i > fabs(*(float *)((*(int (__thiscall **)(_DWORD *, byte *, int))(*this + 840))(this, v7, v3) + 8) - a2) )
      {
        v4 = v3;
        i = (float)(fabs(*(float *)((*(int (__thiscall **)(_DWORD *, float *, int))(*this + 840))(this, v8, v3) + 8) - a2));
      }
    }
    return (int)(v4);
  }

  public unsafe int GetClosestStepUp(float a2)
  {
    int v3 = default; // edi
    byte* v5 = stackalloc byte[12]; // [esp+8h] [ebp-Ch] BYREF
  
    v3 = default;
    if ( (int)this[187] <= 0 )
      return (int)(this[187] - 1);
    while ( *(float *)((*(int (__thiscall **)(_DWORD *, byte *, int))(*this + 840))(this, v5, v3) + 8) <= a2 )
    {
      if ( ++v3 >= this[187] )
        return (int)(this[187] - 1);
    }
    return (int)(v3);
  }

  public unsafe int GetLastStep(int this)
  {
    int v1 = default; // eax
    int result = default; // eax
  
    v1 = *(_DWORD *)(this + 748);
    if ( *(_BYTE *)(this + 768) )
      result = v1 - 4 <= 0 ? 0 : v1 - 4;
    else
      result = v1 - 1 <= 0 ? 0 : v1 - 1;
    return (int)(result);
  }
}
}
