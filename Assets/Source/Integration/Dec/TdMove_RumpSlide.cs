// NO OVERWRITE

namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdMove_RumpSlide
{
  public override unsafe void UpdateMoveTimer(float a2)
  {
    TdPawn v3 = default; // eax
    TdPawn v4 = default; // edi
    int v5 = default; // ebx
    int v6 = default; // eax
    float v7 = default; // xmm0_4
    float v8 = default; // xmm0_4
    int v9 = default; // edi
    int v10 = default; // eax
    Vector v11 = default; // [esp-30h] [ebp-4Ch]
    Vector v12 = default; // [esp-24h] [ebp-40h]
    Vector v13 = default; // [esp-18h] [ebp-34h]
    long v14 = default; // [esp+Ch] [ebp-10h] BYREF
    float v15 = default; // [esp+14h] [ebp-8h]
    int v16 = default; // [esp+18h] [ebp-4h]
  
    v3 = this.PawnOwner;
    if ( (BYTE2(v3.bDisableSkelControlSpring.AsBitfield(32)) & 1) != default )
      this.TimeFalling = 0.0f;
    else
      this.TimeFalling = this.TimeFalling + a2;
    if ( this.TimeFalling > 0.1f )
    {
      v13.X = 2.0f;
      *(_QWORD *)&v13.Y = 0x4000000040000000L;
      var c = v3.Location;
      v14 = *(_QWORD *)&c.X;
      *(_QWORD *)&v12.X = v14;
      v12.Z = v3.Location.Z;
      *(_QWORD *)&v11.X = v14;
      v15 = v12.Z - 150.0f;
      v11.Z = v12.Z - 150.0f;
      if ( this.MovementTraceForBlocking(v11, v12, v13) )
      {
        this.TimeFalling = 0.0f;
      }
      else
      {
        v4 = this.PawnOwner;
        v5 = v4.VfTableObject.Dummy;
        v16 = default;
        //v14.HIDWORD(default);
        v15 = 0.0f;
        //v14.LOBYTE(2);
        //CallUFunction(v4.SetMove, v4, v6, &v14, 0);
        v4.SetMove((EMovement)2);
      }
    }
    v7 = this.Timer;
    if ( v7 > 0.0f )
    {
      v8 = v7 - a2;
      this.Timer = v8;
      if ( v8 <= 0.0f )
      {
        v9 = this.VfTableObject.Dummy;
        this.Timer = 0.0f;
        CallUFunction(this.OnMoveTimer, this, v10, 0, 0);
      }
    }
    this.MoveActiveTime = this.MoveActiveTime + a2;
  }

  public override unsafe void PrePerformPhysics(float DeltaTime)
  {
    TdPawn v3 = default; // ecx
    float v4 = default; // xmm2_4
    float v5 = default; // xmm1_4
    float v6 = default; // xmm3_4
    float v7 = default; // xmm0_4
    float v8 = default; // xmm4_4
    float v9 = default; // xmm0_4
    float v10 = default; // xmm1_4
    TdPlayerController v11 = default; // eax
    float v12 = default; // xmm0_4
    float v13 = default; // edx
    float v14 = default; // eax
    float v15 = default; // ecx
    float v16 = default; // xmm0_4
    float v17 = default; // xmm1_4
    float v18 = default; // xmm2_4
    float v19 = default; // xmm5_4
    float v20 = default; // xmm4_4
    float v21 = default; // xmm7_4
    float v22 = default; // xmm0_4
    float v23 = default; // xmm0_4
    float v24 = default; // xmm4_4
    float v25 = default; // xmm2_4
    Vector *v26; // eax
    float v27 = default; // [esp+8h] [ebp-44h]
    float v28 = default; // [esp+Ch] [ebp-40h]
    float v29 = default; // [esp+10h] [ebp-3Ch]
    float v30 = default; // [esp+14h] [ebp-38h]
    float v31 = default; // [esp+18h] [ebp-34h]
    float v32 = default; // [esp+20h] [ebp-2Ch]
    float v33 = default; // [esp+2Ch] [ebp-20h]
    float v34 = default; // [esp+2Ch] [ebp-20h]
    float v35 = default; // [esp+30h] [ebp-1Ch]
    float v36 = default; // [esp+34h] [ebp-18h]
  
    base.PrePerformPhysics(DeltaTime);
    v3 = this.PawnOwner;
    if ( (BYTE2(v3.bDisableSkelControlSpring.AsBitfield(32)) & 1) != default )// notice the BYTE2 on this line ! Equivalent to ((byte*)v)[3]
    {
      v4 = v3.UncontrolledSlideNormal.Y;
      v5 = v3.UncontrolledSlideNormal.X;
      v33 = v3.Velocity.X;
      v35 = v3.Velocity.Y;
      v36 = v3.Velocity.Z;
      v6 = 0.0f;
      v7 = v3.UncontrolledSlideNormal.Z * 0.0f;
      v8 = v4 - v7;
      v9 = v7 - v5;
      v10 = (float)(v5 * 0.0f) - (float)(v4 * 0.0f);
      v32 = v9;
      v29 = 0.0f;
      v30 = 0.0f;
      v31 = 0.0f;
      v28 = (float)(sqrt(v35 * v35 + v36 * v36 + v33 * v33));
      if ( v3.MoveActionHint == MAH_Left )
      {
        v13 = v8;
        v14 = v9;
        v15 = v10;
      }
      else if ( v3.MoveActionHint == MAH_Right )
      {
        v13 = -0.0f - v8;
        v14 = -0.0f - v9;
        v15 = -0.0f - v10;
      }
      else
      {
        v11 = E_TryCastTo<TdPlayerController>(v3.Controller);
        v6 = 0.0f;
        if ( default == v11 )
        {
          goto LABEL_12;
        }
        if ( (float)(-0.0f - v11.ActualAccelX) == 0.0f )
        {
          v12 = 0.0f;
        }
        else
        {
          v27 = (float)((float)(-0.0f - v11.ActualAccelX) / fabs((float)(-0.0f - v11.ActualAccelX)));
          v12 = v27;
        }
        v13 = v12 * v8;
        v14 = v32 * v12;
        v15 = v10 * v12;
      }
      v31 = v15;
      v30 = v14;
      v29 = v13;
      goto LABEL_12;
    }
    return;
    LABEL_12:
    
    v16 = this.SideControl * DeltaTime;
    v17 = (float)(v16 * v29) + v33;
    v18 = (float)(v30 * v16) + v35;
    v19 = (float)(v31 * v16) + v36;
    v20 = v18;
    if ( this.MaxSlideSpeed < v28 )
      v21 = this.MaxSlideSpeed;
    else
      v21 = v28;
    v22 = (float)((float)(v19 * v19) + (float)(v18 * v18)) + (float)(v17 * v17);
    if ( v22 == 1.0f )
    {
      v23 = v17;
      v24 = v18;
      v6 = v19;
    }
    else if ( v22 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
    {
      v25 = 1.0f / fsqrt(v22);
      v34 = (float)(3.0f - (float)((float)(v25 * v22) * v25)) * (float)(v25 * 0.5f);
      v23 = v34 * v17;
      v24 = v20 * v34;
      v6 = v19 * v34;
    }
    else
    {
      v23 = 0.0f;
      v24 = 0.0f;
    }
/*fixed(var ptr1 =&)
          v26 =  ptr1;*/
    this.PawnOwner.Velocity.X = v23 * v21;
    this.PawnOwner.Velocity.Y = v24 * v21;
    this.PawnOwner.Velocity.Z = v6 * v21;
    if ( (this.bTouchedFallHeightVolume == false) )
      this.PawnOwner.EnterFallingHeight = this.PawnOwner.Location.Z;
    return;
  }
}
}
