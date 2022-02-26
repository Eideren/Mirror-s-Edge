// NO OVERWRITE

namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdMove_Barge
{
  public unsafe void FindAdditionalTargets(Vector a2, Vector a5, Actor a8, ref array<BargeHitInfo> ImpactList)
  {
    NativeMarkers.MarkUnimplemented("");
    CheckResult *v5; // esi
    Actor v6 = default; // ebx
    ref array<BargeHitInfo> v7 = ref ImpactList; // edi
    Actor v8 = default; // ebp
    //ref BargeHitInfo v9; // eax
    //ref BargeHitInfo v10; // ecx
    float v11 = default; // xmm1_4
    float v12 = default; // xmm1_4
    float v13 = default; // xmm2_4
    TdPawn v14 = default; // [esp-Ch] [ebp-54h]
    Vector v15 = default; // [esp+0h] [ebp-48h]
    Vector a5a = default; // [esp+Ch] [ebp-3Ch] BYREF
    float v17 = default; // [esp+18h] [ebp-30h]
    int v18 = default; // [esp+28h] [ebp-20h]
    float v19 = default; // [esp+38h] [ebp-10h]
  
    v14 = this.PawnOwner;
    a5a.X = 20.0f;
    a5a.Y = 20.0f;
    a5a.Z = 20.0f;
    v5 = GWorld.MultiLineCheck(ref GMem, a5, a2, a5a, 0x209Fu, v14, default);
    if(v5 == default)
      return;
    
    v6 = a8;
    v7 = ImpactList;
    while(1 != default)
    {
      v8 = v5->Actor;
      if ( default == v8 || SLOBYTE(v8.bForceDemoRelevant.AsBitfield(32)) >= 0 || v6 == v8 )
        goto LABEL_16;
      ref var v9 = ref v7[v7.Add(1, 32, 8)];
      v9.BargeActor = default;
      v9.HitNormal.X = 0.0f;
      v9.HitNormal.Y = 0.0f;
      v9.HitNormal.Z = 0.0f;
      v9.HitLocation.X = 0.0f;
      v9.HitLocation.Y = 0.0f;
      v9.HitLocation.Z = 0.0f;
      v9.HitPhysMaterial = default;
      ref var v10 = ref v7[v7.Count - 1];
      v10.BargeActor = v8;
      v11 = v5->Normal.X;
      v19 = (float)(v11 * v11) + (float)(v5->Normal.Y * v5->Normal.Y);
      if( v19 != 1.0f )
      {
        if ( v19 >= SMALL_NUMBER )
        {
          v18 = 1077936128;
          #warning  This is very weird
          ImpactList = default;//(ref array<BargeHitInfo> )1056964608;
          #warning  So is this, but it might just be an empty array
          v13 = 1.0f / fsqrt(v19);
          v17 = (float)(3.0f - (float)((float)(v13 * v19) * v13)) * (float)(v13 * 0.5f);
          v15.X = v5->Normal.X * v17;
          v12 = v5->Normal.Y * v17;
          v15.Y = v12;
        }
        else
        {
          v15.X = 0.0f;
          v15.Y = 0.0f;
        }
        v15.Z = 0.0f;
        goto LABEL_15;
      }

      if ( v5->Normal.Z != 0.0f )
      {
        v15.X = v11;
        v12 = v5->Normal.Y;
        v15.Y = v12;
        v15.Z = 0.0f;
        goto LABEL_15;
      }
      v15 = v5->Normal;
LABEL_15:
      v10.HitNormal = v15;
      v10.HitLocation = v5->Location;
LABEL_16:
      v5 = (CheckResult *)v5->Next;
      if ( default == v5 )
        return;
    }
  }

  public override unsafe void PrePerformPhysics(float DeltaTime)
  {
    TdPawn v3 = default; // eax
    uint v4 = default; // eax
  
    base.PrePerformPhysics(DeltaTime);
    v3 = this.PawnOwner;
    if(v3 != default)
    {
      if ( v3.MoveActionHint == MAH_Down )
      {
        v4 = this.bHasDealtDamage.AsBitfield(2);
        if ( (v4 & 1) == 0 && (v4 & 2) != 0 )
          this.AbortBarge();
      }
    }
  }
}
}
