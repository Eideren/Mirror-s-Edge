// NO OVERWRITE

namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdLadderVolume
{
  public unsafe int GetClosestStepDown(float a2)
  {
    int v3 = default; // esi
    Vector v5 = default; // [esp+8h] [ebp-Ch] BYREF
  
    v3 = this.GetLastStep();// GetLastStep
    if ( v3 < 0 )
      return 0;
    while ( a2 <= this.GetLadderLocation( &v5, v3)->Z )// GetLadderLocation
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
    Vector v7 = default; // [esp+1Ch] [ebp-18h] BYREF
    Vector v8 = default; // [esp+28h] [ebp-Ch] BYREF
  
    v3 = 1;
    v4 = default;
    for ( i = (float)(fabs(this.GetLadderLocation( &v7, 0)->Z - a2)); v3 < this.PawnLadderLocations.Count; ++v3 )// GetLadderLocation
    {
      if ( i > fabs(this.GetLadderLocation( &v7, v3)->Z - a2) )// GetLadderLocation
      {
        v4 = v3;
        i = (float)(fabs(this.GetLadderLocation( &v8, v3)->Z - a2));// GetLadderLocation
      }
    }
    return (int)(v4);
  }

  public unsafe int GetClosestStepUp(float a2)
  {
    int v3 = default; // edi
    Vector v5 = default; // [esp+8h] [ebp-Ch] BYREF
  
    v3 = default;
    if ( this.PawnLadderLocations.Count <= 0 )
      return this.PawnLadderLocations.Count - 1;
    while ( this.GetLadderLocation( &v5, v3)->Z <= a2 )// GetLadderLocation
    {
      if ( ++v3 >= this.PawnLadderLocations.Count )
        return this.PawnLadderLocations.Count - 1;
    }
    return v3;
  }

  public unsafe int GetLastStep()
  {
    int v1 = default; // eax
    int result = default; // eax
  
    v1 = this.PawnLadderLocations.Count;
    if ( this.LadderType != default )
      result = v1 - 4 <= 0 ? 0 : v1 - 4;
    else
      result = v1 - 1 <= 0 ? 0 : v1 - 1;
    return (int)(result);
  }



  public unsafe Vector GetLadderLocation( int Index )
  {
    Vector v = default;
    return *GetLadderLocation( &v, Index );
  }



  public unsafe Vector * GetLadderLocation(Vector *output, int Index)
  {
    int ladderLocCount = default; // edx
    int clampIndex = default; // eax
    ELadderType v5 = default; // dl
    float offsetXY = default; // xmm1_4
    float offsetZ = default; // xmm0_4
    //float v8 = default; // xmm3_4
    //float v9 = default; // xmm5_4
    //float v10 = default; // xmm4_4
    //float v11 = default; // xmm2_4
    //Vector *v12; // eax
    //float v13 = default; // xmm6_4
    //float v14 = default; // xmm0_4
    //float v15 = default; // xmm1_4
    //float v16 = default; // xmm2_4
    Vector *result; // eax
  
    ladderLocCount = this.PawnLadderLocations.Count;
    clampIndex = Index;
    if ( Index >= ladderLocCount || Index < 0 )
    {
      clampIndex = Index < 0 ? 0 : Index;
      if ( clampIndex > ladderLocCount - 1 )
        clampIndex = ladderLocCount - 1;
    }
    v5 = this.LadderType;
    if ( v5 == ELadderType.LT_Pipe )
      offsetXY = this.XYOffsetPipe;
    else
      offsetXY = this.XYOffsetLadder;
    if ( v5 == ELadderType.LT_Pipe )
      offsetZ = this.ZOffsetPipe;
    else
      offsetZ = this.ZOffsetLadder;
    result = output;
    *output = this.PawnLadderLocations[clampIndex] + this.MoveDirection * offsetZ - this.WallNormal * offsetXY;
    return result;
  }
}
}
