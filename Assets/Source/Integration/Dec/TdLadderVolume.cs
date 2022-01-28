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
    while ( a2 <= *(float *)(this.GetLadderLocation( &v5, v3) + 8) )// GetLadderLocation
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
    for ( i = (float)(fabs(*(float *)(this.GetLadderLocation( &v7, 0) + 8) - a2)); v3 < this.PawnLadderLocations.Count; ++v3 )// GetLadderLocation
    {
      if ( i > fabs(*(float *)(this.GetLadderLocation( &v7, v3) + 8) - a2) )// GetLadderLocation
      {
        v4 = v3;
        i = (float)(fabs(*(float *)(this.GetLadderLocation( &v8, v3) + 8) - a2));// GetLadderLocation
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
      return (int)(this.PawnLadderLocations.Count - 1);
    while ( *(float *)(this.GetLadderLocation( &v5, v3) + 8) <= a2 )// GetLadderLocation
    {
      if ( ++v3 >= this.PawnLadderLocations.Count )
        return (int)(this.PawnLadderLocations.Count - 1);
    }
    return (int)(v3);
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
    int v3 = default; // edx
    int v4 = default; // eax
    ELadderType v5 = default; // dl
    float v6 = default; // xmm1_4
    float v7 = default; // xmm0_4
    float v8 = default; // xmm3_4
    float v9 = default; // xmm5_4
    float v10 = default; // xmm4_4
    float v11 = default; // xmm2_4
    //Vector *v12; // eax
    float v13 = default; // xmm6_4
    float v14 = default; // xmm0_4
    float v15 = default; // xmm1_4
    float v16 = default; // xmm2_4
    Vector *result; // eax
  
    v3 = this.PawnLadderLocations.Count;
    v4 = Index;
    if ( Index >= v3 || Index < 0 )
    {
      v4 = Index < 0 ? 0 : Index;
      if ( v4 > v3 - 1 )
        v4 = v3 - 1;
    }
    v5 = this.LadderType;
    if ( v5 == ELadderType.LT_Pipe )
      v6 = this.XYOffsetPipe;
    else
      v6 = this.XYOffsetLadder;
    if ( v5 == ELadderType.LT_Pipe )
      v7 = this.ZOffsetPipe;
    else
      v7 = this.ZOffsetLadder;
    v8 = this.WallNormal.X * v6;
    v9 = this.WallNormal.Z * v6;
    v10 = this.WallNormal.Y * v6;
    v11 = this.MoveDirection.Y * v7;
    v13 = this.MoveDirection.Z * v7;
    v14 = this.PawnLadderLocations[v4].X + (float)(this.MoveDirection.X * v7);
    v15 = this.PawnLadderLocations[v4].Y + v11;
    v16 = this.PawnLadderLocations[v4].Z;
    result = output;
    output->X = v14 - v8;
    output->Y = v15 - v10;
    output->Z = (float)(v16 + v13) - v9;
    return result;
  }
}
}
