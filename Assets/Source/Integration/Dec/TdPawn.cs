namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdPawn
{
  public unsafe int OkToInteract()
  {
    return 0;
  }

  public unsafe void startNewPhysics(float deltaTime, int Iterations)
  {
    int v3 = default; // edx
  
    if ( deltaTime >= 0.00030000001d && Iterations <= 7 )
    {
      v3 = this.Physics;
      SetFromBitfield(ref this.bDisableSkelControlSpring, 32, this.bDisableSkelControlSpring.AsBitfield(32) & (0xFFFEFFFF));
      switch ( (int)v3 )
      {
        case (int)PHYS_None:
          return;
        case (int)PHYS_Walking:
          this.physWalking(LODWORD(deltaTime), Iterations);// physWalking
          break;
        case (int)PHYS_Falling:
          this.physFalling(LODWORD(deltaTime), Iterations);// physFalling
          break;
        case (int)PHYS_Swimming:
          this.physSwimming(deltaTime, Iterations);
          break;
        case (int)PHYS_Flying:
          this.physFlying(deltaTime, Iterations);
          break;
        case (int)PHYS_Interpolating:
          this.physInterpolating(LODWORD(deltaTime));// physInterpolating
          break;
        case (int)PHYS_Spider:
          this.physSpider(deltaTime, Iterations);
          break;
        case (int)PHYS_Ladder:
          this.physLadder(deltaTime, Iterations);
          break;
        case (int)PHYS_RigidBody:
          this.physRigidBody(LODWORD(deltaTime));// physRigidBody
          break;
        case (int)PHYS_WallRunning:
          this.physWallRunning(LODWORD(deltaTime), Iterations);// physWallRunning
          break;
        case (int)PHYS_WallClimbing:
          this.physWallClimbing(LODWORD(deltaTime), Iterations);// physWallClimbing
          break;
        default:
          this.setPhysics( 0, 0, 0, 0, 1065353216);// setPhysics
          break;
      }
    }
  }

  public unsafe void UpdateVelocityVariables()
  {
    double v1 = default; // st7
    float v2 = default; // xmm2_4
    float v3 = default; // edx
    double v4 = default; // st6
    float v5 = default; // xmm1_4
    float v6 = default; // eax
    float v7 = default; // [esp+0h] [ebp-10h]
  
    v1 = sqrt(this.Velocity.Z * this.Velocity.Z + this.Velocity.Y * this.Velocity.Y + this.Velocity.X * this.Velocity.X);
    v7 = (float)v1;
    this.VelocityMagnitude = v1;
    if ( v1 <= 0.00000001f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
    {
      this.VelocityMagnitude = 0.0f;
      *(_QWORD *)&this.VelocityDir.Y = 0L;
      this.VelocityDir.X = 0.0f;
    }
    else
    {
      v2 = this.Velocity.Z;
      v3 = this.Velocity.Y * (float)(1.0f / v7);
      this.VelocityDir.X = this.Velocity.X * (float)(1.0f / v7);
      this.VelocityDir.Y = v3;
      this.VelocityDir.Z = v2 * (float)(1.0f / v7);
      v4 = sqrt(this.Velocity.Y * this.Velocity.Y + this.Velocity.X * this.Velocity.X);
      this.VelocityMagnitude2D = v4;
      if ( v4 > 0.00000001f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
      {
        v5 = 1.0f / this.VelocityMagnitude2D;
        v6 = this.Velocity.Y;
        this.VelocityDir2D.X = this.Velocity.X;
        this.VelocityDir2D.Y = v6;
        this.VelocityDir2D.Z = 0.0f;
        this.VelocityDir2D.X = this.VelocityDir2D.X * v5;
        this.VelocityDir2D.Y = this.VelocityDir2D.Y * v5;
        this.VelocityDir2D.Z = this.VelocityDir2D.Z * v5;
        return;
      }
    }
    this.VelocityDir2D.X = 0.0f;
    this.VelocityDir2D.Y = 0.0f;
    this.VelocityDir2D.Z = 0.0f;
    this.VelocityMagnitude2D = 0.0f;
  }

  public unsafe void setPhysics(byte NewPhysics, Actor NewFloor, Vector NewFloorV)
  {
    EPhysics v5 = default; // al
  
    if ( this.Physics == NewPhysics )
    {
      if ( NewPhysics == 1 )
        goto LABEL_6;
    }
    else if ( NewPhysics == 1 )
    {
      this.NewFloorSmooth = (float)(this.Location.Z - this.CylinderComponent.CollisionHeight) - 2.0f;
      goto LABEL_6;
    }
    this.ClearTimer(*(name *)&FuncName_SlideOffLedge_unknown_EyeJoint, 0);// SlideOffLedge
  LABEL_6:
    v5 = this.Physics;
    if ( v5 != NewPhysics )
    {
      if ( v5 == PHYS_WallClimbing || v5 == PHYS_WallRunning )
        SetFromBitfield(ref this.bDisableSkelControlSpring, 32, this.bDisableSkelControlSpring.AsBitfield(32) & (~1024u));
      if ( v5 != NewPhysics && NewPhysics == 2 )
        this.EnterFallingHeight = this.Location.Z;
    }
    this.AnimLockRefCount = default;
    this.setPhysics(NewPhysics, NewFloor, NewFloorV);
  }

  public unsafe float GetGravityZ()
  {
    return (float)(this.GetGravityZ() * this.GravityModifier);
  }

  public unsafe bool UNKNOWN28(Vector *a2, int a3, int a4, Vector *a5, CheckResult *a6)
  {
    float v6 = default; // xmm1_4
    float v7 = default; // xmm0_4
    float v8 = default; // edx
    Vector *v10; // ebp
    float v11 = default; // eax
    bool v12 = default; // zf
    bool result = default; // eax
    float v14 = default; // eax
    float v15 = default; // edx
    float v16 = default; // xmm0_4
    float v17 = default; // xmm2_4
    float v18 = default; // xmm0_4
    float v19 = default; // xmm3_4
    float v20 = default; // xmm1_4
    float v21 = default; // xmm2_4
    float v22 = default; // xmm1_4
    float v23 = default; // xmm3_4
    float v24 = default; // xmm2_4
    float v25 = default; // eax
    float v26 = default; // ecx
    float v27 = default; // xmm0_4
    float v28 = default; // xmm2_4
    float v29 = default; // xmm0_4
    Vector *v30; // eax
    float v31 = default; // xmm0_4
    float v32 = default; // xmm1_4
    float v33 = default; // xmm3_4
    float v34 = default; // xmm1_4
    float v35 = default; // xmm2_4
    float v36 = default; // xmm5_4
    float v37 = default; // xmm4_4
    float v38 = default; // xmm5_4
    float v39 = default; // xmm0_4
    // void (__thiscall *v40)(TdPawn , _DWORD, _DWORD, _DWORD, int); // edx
    Vector *v41; // [esp-10h] [ebp-9Ch]
    Rotator *v42; // [esp-Ch] [ebp-98h]
    CheckResult *v43; // [esp-4h] [ebp-90h]
    bool v44 = default; // [esp+10h] [ebp-7Ch]
    bool v45 = default; // [esp+14h] [ebp-78h]
    float v46 = default; // [esp+18h] [ebp-74h]
    Actor v47 = default; // [esp+1Ch] [ebp-70h]
    float v48 = default; // [esp+1Ch] [ebp-70h]
    PrimitiveComponent v49 = default; // [esp+20h] [ebp-6Ch]
    Vector v50 = default; // [esp+24h] [ebp-68h]
    Vector Delta = default; // [esp+30h] [ebp-5Ch] BYREF
    float v52 = default; // [esp+40h] [ebp-4Ch]
    float v53 = default; // [esp+44h] [ebp-48h]
    float v54 = default; // [esp+48h] [ebp-44h]
    Vector a2a = default; // [esp+4Ch] [ebp-40h] BYREF
    float v56 = default; // [esp+5Ch] [ebp-30h]
    int v57 = default; // [esp+6Ch] [ebp-20h]
    float v58 = default; // [esp+7Ch] [ebp-10h]
  
    v6 = 0.0f;
    v7 = a6.Time;
    v8 = a6.Normal.Z;
    v50.Y = a6.Normal.Y;
fixed(var ptr1 =&this.Location)
    v10 =  ptr1;
    v50.X = a6.Normal.X;
    v49 = a6.Component;
    v47 = a6.Actor;
    v11 = this.Location.Y;
    v54 = this.Location.Z;
    v46 = v7;
    v12 = a2->X == 0.0f;
    v53 = v11;
    v50.Z = v8;
    v52 = this.Location.X;
    v44 = default;
    if ( v12 && a2->Y == 0.0f && a2->Z == 0.0f )
      return false;
    Delta.X = (float)((float)(a5->X * a5->X) + (float)(a5->Y * a5->Y)) + (float)(a5->Z * a5->Z);
    if ( Delta.X == 1.0f )
    {
      v14 = a5->Y;
      Delta.X = a5->X;
      v15 = a5->Z;
      v16 = Delta.X;
      Delta.Y = v14;
      v6 = v14;
      Delta.Z = v15;
      v17 = v15;
    }
    else if ( Delta.X >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
    {
      v56 = 3.0f;
      v18 = fsqrt(Delta.X);
      a2a.X = (float)(3.0f - (float)((float)((float)(1.0f / v18) * Delta.X) * (float)(1.0f / v18))) * (float)((float)(1.0f / v18) * 0.5f);
      v16 = a5->X * a2a.X;
      v6 = a5->Y * a2a.X;
      v17 = a5->Z * a2a.X;
    }
    else
    {
      v16 = 0.0f;
      v17 = 0.0f;
    }
    if ( (float)(-0.0f - (float)((float)((float)(v50.Y * v6) + (float)(v50.Z * v17)) + (float)(v16 * v50.X))) < 0.70700002d )
      return false;
    Delta.X = a2->X * 32.0f;
    Delta.Y = a2->Y * 32.0f;
    Delta.Z = a2->Z * 32.0f;
fixed(var ptr2 =&this.Rotation)
    GWorld.MoveActor(this, &Delta,  ptr2, 0, a6);
    v19 = a6.Time;
    if ( v19 >= 1.0f || v19 < 0.0f )
    {
      if ( default == a4 )
        goto LABEL_24;
      v22 = a5->Y;
      v23 = a5->X;
      v24 = (float)(v23 * v23) + (float)(v22 * v22);
      v58 = v24;
      if ( v24 == 1.0f )
      {
        if ( a5->Z == 0.0f )
        {
          v25 = a5->Y;
          v26 = a5->Z;
          Delta.X = a5->X;
          v27 = Delta.X;
          Delta.Y = v25;
          v22 = v25;
          Delta.Z = v26;
          v28 = v26;
          goto LABEL_23;
        }
        v27 = v23;
      }
      else if ( v24 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
      {
        v57 = 1077936128;
        v29 = fsqrt(v58);
        v56 = (float)(3.0f - (float)((float)((float)(1.0f / v29) * v58) * (float)(1.0f / v29))) * (float)((float)(1.0f / v29) * 0.5f);
        v27 = a5->X * v56;
        v22 = a5->Y * v56;
      }
      else
      {
        v27 = 0.0f;
        v22 = 0.0f;
      }
      v28 = 0.0f;
  LABEL_23:
      Delta.X = (float)(v27 * 34.0f) + v10->X;
      Delta.Y = this.Location.Y + (float)(v22 * 34.0f);
      Delta.Z = this.Location.Z + (float)(v28 * 34.0f);
      v30 = this.GetCylinderExtent(&a2a);
fixed(var ptr3 =&this.Location)
      GWorld.SingleLineCheck(a6, this, &Delta,  ptr3, 8415, v30, 0);
      if ( a6.Time < 1.0f )
      {
        v44 = default;
  LABEL_32:
        v34 = -0.0f - a2->Y;
        v35 = -0.0f - a2->Z;
        v43 = a6;
fixed(var ptr4 =&this.Rotation)
        v42 =  ptr4;
        a2a.X = (float)(-0.0f - a2->X) * 32.0f;
        a2a.Y = v34 * 32.0f;
        a2a.Z = v35 * 32.0f;
        v41 = &a2a;
        goto LABEL_33;
      }
  LABEL_24:
      Delta.Z = -0.0f - this.MaxStepHeight;
      a5->X = a5->X * (float)(1.0f - v46);
      a5->Y = a5->Y * (float)(1.0f - v46);
      a5->Z = a5->Z * (float)(1.0f - v46);
      Delta.X = 0.0f;
      Delta.Y = 0.0f;
fixed(var ptr5 =&this.Rotation)
      GWorld.MoveActor(this, a5,  ptr5, 0, a6);
      v31 = a6.Time;
      v48 = v31;
      v32 = v31;
      v33 = 0.0f;
      v45 = default;
      if ( v31 <= 0.050000001d )
      {
        if(a3 != default)
        {
fixed(var ptr6 =&this.Rotation)
          GWorld.MoveActor(this, &Delta,  ptr6, 0, a6);
          v33 = a6.Time;
          v31 = v33;
          if ( v33 <= 0.050000001d )
          {
            v32 = v48;
          }
          else
          {
fixed(var ptr7 =&this.Rotation)
            GWorld.MoveActor(this, a5,  ptr7, 0, a6);
            v31 = a6.Time;
            v45 = v31 <= 0.050000001d;
            v32 = v31;
          }
        }
      }
      v50 = a6.Normal;
      v46 = v31;
      v47 = a6.Actor;
      v49 = a6.Component;
      v44 = v32 >= 1.0f;
      if(v45 != default)
      {
        a2a.X = (float)(-0.0f - Delta.X) * v33;
        a2a.Y = (float)(-0.0f - Delta.Y) * v33;
        a2a.Z = (float)(-0.0f - Delta.Z) * v33;
fixed(var ptr8 =&this.Rotation)
        GWorld.MoveActor(this, &a2a,  ptr8, 0, a6);
      }
      goto LABEL_32;
    }
    v20 = -0.0f - a2->Y;
    v21 = -0.0f - a2->Z;
    v43 = a6;
fixed(var ptr9 =&this.Rotation)
    v42 =  ptr9;
    Delta.X = (float)((float)(-0.0f - a2->X) * 32.0f) * v19;
    Delta.Y = (float)(v20 * 32.0f) * v19;
    Delta.Z = (float)(v21 * 32.0f) * v19;
    v41 = &Delta;
  LABEL_33:
    GWorld.MoveActor(this, v41, v42, 0, v43);
    v36 = v53;
    v37 = v52;
    SetFromBitfield(ref this.bCollideComplex, 20, this.bCollideComplex.AsBitfield(20) ^ ((this.bCollideComplex.AsBitfield(20) ^ (((float)((float)((float)(this.Location.Y - v53) * (float)(this.Location.Y - v53)) + (float)((float)(v10->X - v52) * (float)(v10->X - v52))) > (float)((float)(a5->X * a5->X) + (float)(a5->Y * a5->Y))) << 8)) & 0x100));
    if ( (this.bCollideComplex.AsBitfield(20) & 0x100) != 0 )
    {
      v38 = v36 - this.Location.Y;
      v39 = v54 - this.Location.Z;
      // v40 = *(void (__thiscall **)(TdPawn , _DWORD, _DWORD, _DWORD, int))(this.VfTableObject.Dummy + 1060);
      Delta.X = v37 - v10->X;
      Delta.Y = v38;
      Delta.Z = v39;
      v40(this, LODWORD(Delta.X), LODWORD(v38), LODWORD(v39), 1);// OffsetMeshXY
      this.EvadeTimer = 0.2f;
    }
    a6.Normal.X = v50.X;
    a6.Normal.Y = v50.Y;
    a6.Actor = v47;
    result = v44;
    a6.Normal.Z = v50.Z;
    a6.Time = v46;
    a6.Component = v49;
    return result != default;
  }

  public unsafe void SetTargetMeshZ(float BlendTime, int TranslationSpace)
  {
    TdSkeletalMeshComponent v3 = default; // eax
  
    this.TargetMeshTranslationZ = BlendTime;
    if(TranslationSpace != default)
    {
      v3 = this.Mesh1p;
      if ( default == v3 )
        v3 = this.Mesh3p;
      this.OffsetMeshZ(BlendTime - v3.Translation.Z);// OffsetMeshZ
    }
  }

  public unsafe void UpdateWalkingState()
  {
    EWalkingState v1 = default; // al
    TdWeapon v2 = default; // eax
    bool v3 = default; // eax
    float v4 = default; // [esp+0h] [ebp-4h]
  
    v1 = this.OverrideWalkingState;
    v4 = (float)(sqrt(this.Velocity.Y * this.Velocity.Y + this.Velocity.X * this.Velocity.X));
    if ( v1 != WAS_None )
      goto LABEL_10;
    v2 = this.MyWeapon;
    v3 = v2 && v2.WeaponType == EWT_Heavy;
    if ( this.SneakVelocity > v4 )
    {
      this.CurrentWalkingState = WAS_Idle;
      return;
    }
    if ( this.WalkVelocity > v4 )
    {
      v1 = v3 + 1;
  LABEL_10:
      this.CurrentWalkingState = v1;
      return;
    }
    if ( this.JogVelocity <= v4 )
    {
      if ( this.RunVelocity <= v4 )
      {
        if ( this.SprintVelocity <= v4 )
          this.CurrentWalkingState = default == v3 + 4;
        else
          this.CurrentWalkingState = WAS_Run;
      }
      else
      {
        this.CurrentWalkingState = WAS_Jog;
      }
    }
    else
    {
      this.CurrentWalkingState = WAS_Walk;
    }
  }

  public unsafe bool IsInMove(EMovement Move)
  {
    return this.MovementState == (byte)Move;
  }

  public unsafe EMovement GetMove()
  {
    return this.MovementState;
  }

  // NOT READY
  public unsafe void RegenerateHealth(float a2){ NativeMarkers.MarkUnimplemented(); }
//public unsafe void RegenerateHealth(float a2)
//  {
//    float v2 = default; // xmm0_4
//    bool v3 = default; // cf
//    float v4 = default; // xmm1_4
//    int v5 = default; // eax
//    float v6 = default; // xmm0_4
//    int v7 = default; // eax
//    float v8 = default; // xmm1_4
//    int v9 = default; // eax
//    float v10 = default; // xmm0_4
//    float v11 = default; // xmm0_4
//    float v12 = default; // xmm0_4
//    float v13 = default; // xmm0_4
//  
//    v2 = a2 + this.TimeSinceLastDamage;
//    v3 = v2 < this.RegenerateDelay;
//    v4 = a2 + this.TimeSinceLastTaserDamage;
//    this.TimeSinceLastDamage = v2;
//    this.TimeSinceLastTaserDamage = v4;
//    if ( default == v3 )
//    {
//      v5 = this.Health;
//      if ( v5 < this.MaxHealth && v5 >= 0 )
//      {
//        v6 = (float)(this.RegenerateHealthPerSecond * a2) + this.HealthFrac;
//        this.HealthFrac = v6;
//        _mm_setcsr(0x3F80u);
//        v7 = (int)v6;
//        _mm_setcsr(0x1F80u);
//        if ( (int)v6 >= 1 )
//        {
//          v8 = this.HealthFrac;
//          this.Health = this.Health + (v7);
//          this.HealthFrac = v8 - (float)v7;
//        }
//        v9 = this.MaxHealth;
//        if ( this.Health > v9 )
//          this.Health = v9;
//      }
//    }
//    v10 = this.StunDamageLevel;
//    if ( v10 > 0.0f )
//    {
//      v11 = v10 - (float)(this.RegenerateFromStunPerSecond * a2);
//      this.StunDamageLevel = v11;
//      if ( v11 < 0.0f )
//        this.StunDamageLevel = 0.0f;
//    }
//    if ( this.TimeSinceLastTaserDamage >= this.TaserRegenerateDelay )
//    {
//      v12 = this.TaserDamageLevel;
//      if ( v12 > 0.0f )
//      {
//        v13 = v12 - (float)(this.RegenerateFromTaserPerSecond * a2);
//        this.TaserDamageLevel = v13;
//        if ( v13 < 0.0f )
//          this.TaserDamageLevel = 0.0f;
//      }
//    }
//  }
//
  public unsafe void PlayCustomAnim(ECustomNodeType Type, name AnimName, float Rate, float BlendInTime, float BlendOutTime, bool bLooping, bool bOverride, bool bRootMotion, int bRootRotation)
  {
    bool v11 = default; // eax
    bool v12 = default; // eax
    bool v13 = default; // eax
    bool v14 = default; // eax
    bool v15 = default; // eax
    bool v16 = default; // eax
    bool v17 = default; // eax
    bool v18 = default; // eax
    bool v19 = default; // eax
    bool v20 = default; // eax
  
    switch ( (int)Type )
    {
      case (int)CNT_Canned:
        v11 = bRootMotion && this.Mesh1p == this.Mesh;
        this.PlayCustomAnimInternal(
          this.CustomCannedNode1p,
          AnimName,
          LODWORD(Rate),
          LODWORD(BlendInTime),
          LODWORD(BlendOutTime),
          bLooping,
          bOverride,
          v11,
          bRootRotation);
        this.PlayCustomAnimInternal(
          this.CustomCannedNode3p,
          LODWORD(BlendInTime),
          LODWORD(BlendOutTime),
          bLooping,
          bOverride,
          bRootMotion,
          bLooping);
        this.ReplicateCustomAnim(
          Type,
          AnimName,
          LODWORD(Rate),
          LODWORD(BlendInTime),
          LODWORD(BlendOutTime),
          bLooping,
          bOverride,
          bRootMotion,
          bRootRotation);
        break;
      case (int)CNT_CannedUpperBody:
        v12 = bRootMotion && this.Mesh1p == this.Mesh;
        this.PlayCustomAnimInternal(
          this.CustomCannedUpperBodyNode1p,
          AnimName,
          LODWORD(Rate),
          LODWORD(BlendInTime),
          LODWORD(BlendOutTime),
          bLooping,
          bOverride,
          v12,
          bRootRotation);
        this.PlayCustomAnimInternal(
          this.CustomCannedUpperBodyNode3p,
          LODWORD(BlendInTime),
          LODWORD(BlendOutTime),
          bLooping,
          bOverride,
          bRootMotion,
          bLooping);
        this.ReplicateCustomAnim(
          Type,
          AnimName,
          LODWORD(Rate),
          LODWORD(BlendInTime),
          LODWORD(BlendOutTime),
          bLooping,
          bOverride,
          bRootMotion,
          bRootRotation);
        break;
      case (int)CNT_FullBody:
        v13 = bRootMotion && this.Mesh1p == this.Mesh;
        this.PlayCustomAnimInternal(
          this.CustomFullBodyNode1p,
          AnimName,
          LODWORD(Rate),
          LODWORD(BlendInTime),
          LODWORD(BlendOutTime),
          bLooping,
          bOverride,
          v13,
          bRootRotation);
        this.PlayCustomAnimInternal(
          this.CustomFullBodyNode3p,
          LODWORD(BlendInTime),
          LODWORD(BlendOutTime),
          bLooping,
          bOverride,
          bRootMotion,
          bLooping);
        this.ReplicateCustomAnim(
          Type,
          AnimName,
          LODWORD(Rate),
          LODWORD(BlendInTime),
          LODWORD(BlendOutTime),
          bLooping,
          bOverride,
          bRootMotion,
          bRootRotation);
        break;
      case (int)CNT_FullBody_Dir:
        v14 = bRootMotion && this.Mesh1p == this.Mesh;
        this.PlayCustomAnimInternal(
          this.CustomFullBodyDirNode1p,
          AnimName,
          LODWORD(Rate),
          LODWORD(BlendInTime),
          LODWORD(BlendOutTime),
          bLooping,
          bOverride,
          v14,
          bRootRotation);
        this.PlayCustomAnimInternal(
          this.CustomFullBodyDirNode3p,
          LODWORD(BlendInTime),
          LODWORD(BlendOutTime),
          bLooping,
          bOverride,
          bRootMotion,
          bLooping);
        this.ReplicateCustomAnim(
          Type,
          AnimName,
          LODWORD(Rate),
          LODWORD(BlendInTime),
          LODWORD(BlendOutTime),
          bLooping,
          bOverride,
          bRootMotion,
          bRootRotation);
        break;
      case (int)CNT_UpperBody:
        v15 = bRootMotion && this.Mesh1p == this.Mesh;
        this.PlayCustomAnimInternal(
          this.CustomUpperBodyNode1p,
          AnimName,
          LODWORD(Rate),
          LODWORD(BlendInTime),
          LODWORD(BlendOutTime),
          bLooping,
          bOverride,
          v15,
          bRootRotation);
        this.PlayCustomAnimInternal(
          this.CustomUpperBodyNode3p,
          LODWORD(BlendInTime),
          LODWORD(BlendOutTime),
          bLooping,
          bOverride,
          bRootMotion,
          bLooping);
        this.ReplicateCustomAnim(
          Type,
          AnimName,
          LODWORD(Rate),
          LODWORD(BlendInTime),
          LODWORD(BlendOutTime),
          bLooping,
          bOverride,
          bRootMotion,
          bRootRotation);
        break;
      case (int)CNT_LowerBody:
        v16 = bRootMotion && this.Mesh1p == this.Mesh;
        this.PlayCustomAnimInternal(
          this.CustomLowerBodyNode1p,
          AnimName,
          LODWORD(Rate),
          LODWORD(BlendInTime),
          LODWORD(BlendOutTime),
          bLooping,
          bOverride,
          v16,
          bRootRotation);
        this.PlayCustomAnimInternal(
          this.CustomLowerBodyNode3p,
          LODWORD(BlendInTime),
          LODWORD(BlendOutTime),
          bLooping,
          bOverride,
          bRootMotion,
          bLooping);
        this.ReplicateCustomAnim(
          Type,
          AnimName,
          LODWORD(Rate),
          LODWORD(BlendInTime),
          LODWORD(BlendOutTime),
          bLooping,
          bOverride,
          bRootMotion,
          bRootRotation);
        break;
      case (int)CNT_Camera:
        v17 = bRootMotion && this.Mesh1p == this.Mesh;
        this.PlayCustomAnimInternal(
          this.CustomCameraNode,
          AnimName,
          LODWORD(Rate),
          LODWORD(BlendInTime),
          LODWORD(BlendOutTime),
          bLooping,
          bOverride,
          v17,
          bRootRotation);
        break;
      case (int)CNT_Weapon:
        v18 = bRootMotion && this.Mesh1p == this.Mesh;
        this.PlayCustomAnimInternal(
          this.CustomWeaponNode1p,
          AnimName,
          LODWORD(Rate),
          LODWORD(BlendInTime),
          LODWORD(BlendOutTime),
          bLooping,
          bOverride,
          v18,
          bRootRotation);
        v19 = bRootMotion && this.Mesh1p == this.Mesh;
        this.PlayCustomAnimInternal(
          this.CustomWeaponNode3p,
          AnimName,
          LODWORD(Rate),
          LODWORD(BlendInTime),
          LODWORD(BlendOutTime),
          bLooping,
          bOverride,
          v19,
          bRootRotation);
        break;
      case (int)CNT_Face:
        v20 = bRootMotion && this.Mesh3p == this.Mesh;
        this.PlayCustomAnimInternal(
          this.CustomFaceNode,
          AnimName,
          LODWORD(Rate),
          LODWORD(BlendInTime),
          LODWORD(BlendOutTime),
          bLooping,
          bOverride,
          v20,
          bRootRotation);
        break;
      default:
        return;
    }
  }

  public unsafe void SetCustomAnimsBlendOutTime(byte a2, float a3)
  {
    TdAnimNodeSlot v4 = default; // ecx
  
    switch ( (int)a2 )
    {
      case (int)0:
        goto LABEL_9;
      case (int)1:
        goto LABEL_10;
      case (int)2:
        this.CustomFullBodyNode1p.SetBlendOutTime(LODWORD(a3));// SetBlendOutTime
        v4 = this.CustomFullBodyNode3p;
        goto LABEL_11;
      case (int)3:
        this.CustomFullBodyDirNode1p.SetBlendOutTime(LODWORD(a3));// SetBlendOutTime
        v4 = this.CustomFullBodyDirNode3p;
        goto LABEL_11;
      case (int)4:
        this.CustomUpperBodyNode1p.SetBlendOutTime(LODWORD(a3));// SetBlendOutTime
        v4 = this.CustomUpperBodyNode3p;
        goto LABEL_11;
      case (int)5:
        this.CustomLowerBodyNode1p.SetBlendOutTime(LODWORD(a3));// SetBlendOutTime
        v4 = this.CustomLowerBodyNode3p;
        goto LABEL_11;
      case (int)6:
        v4 = this.CustomCameraNode;
        goto LABEL_11;
      case (int)7:
        this.CustomWeaponNode1p.SetBlendOutTime(LODWORD(a3));// SetBlendOutTime
        v4 = this.CustomWeaponNode3p;
        goto LABEL_11;
      case (int)8:
        this.CustomFaceNode.SetBlendOutTime(LODWORD(a3));// SetBlendOutTime
  LABEL_9:
        this.CustomCannedNode1p.SetBlendOutTime(LODWORD(a3));// SetBlendOutTime
        this.CustomCannedNode3p.SetBlendOutTime(LODWORD(a3));// SetBlendOutTime
  LABEL_10:
        this.CustomCannedUpperBodyNode1p.SetBlendOutTime(LODWORD(a3));// SetBlendOutTime
        v4 = this.CustomCannedUpperBodyNode3p;
  LABEL_11:
        v4.SetBlendOutTime(LODWORD(a3));// SetBlendOutTime
        break;
      default:
        return;
    }
  }

  public unsafe int StopAllCustomAnimations(float a2)
  {
    this.StopCustomAnim(0, LODWORD(a2));// StopCustomAnim
    this.StopCustomAnim( 1, LODWORD(a2));// StopCustomAnim
    this.StopCustomAnim( 2, LODWORD(a2));// StopCustomAnim
    this.StopCustomAnim( 3, LODWORD(a2));// StopCustomAnim
    this.StopCustomAnim( 4, LODWORD(a2));// StopCustomAnim
    this.StopCustomAnim( 6, LODWORD(a2));// StopCustomAnim
    this.StopCustomAnim( 7, LODWORD(a2));// StopCustomAnim
    return (int)(this.StopCustomAnim( 8, LODWORD(a2)));// StopCustomAnim
  }

  public unsafe void SetRootOffset(Vector Offset, float BlendTime, EBoneControlSpace TranslationSpace)
  {
    SkelControlSingleBone v5 = default; // eax
    SkelControlSingleBone v6 = default; // eax
    SkelControlSingleBone v7 = default; // ecx
    SkelControlSingleBone v8 = default; // esi
  
    if ( sqrt(Offset.Y * Offset.Y + Offset.X * Offset.X + Offset.Z * Offset.Z) <= 0.1f )
    {
      v7 = this.RootControl1p;
      if(v7 != default)
        v7.SetSkelControlStrength(0.0f, BlendTime);
      v8 = this.RootControl3p;
      if(v8 != default)
        v8.SetSkelControlStrength(0.0f, BlendTime);
    }
    else
    {
      v5 = this.RootControl1p;
      if(v5 != default)
      {
        v5.BoneTranslation = Offset;
        this.RootControl1p.SetSkelControlStrength(1.0f, BlendTime);
        this.RootControl1p.BoneTranslationSpace = TranslationSpace;
      }
      v6 = this.RootControl3p;
      if(v6 != default)
      {
        v6.BoneTranslation = Offset;
        this.RootControl3p.SetSkelControlStrength(1.0f, BlendTime);
        this.RootControl3p.BoneTranslationSpace = TranslationSpace;
      }
    }
  }

  public unsafe void UpdateBasedRotation(Rotator *a2, Rotator *a3)
  {
    this.LegRotation = this.LegRotation + (a3.Yaw);
    this.UpdateBasedRotation(a2, a3);
  }

  public unsafe int SetArmorDifficultyLevel(int a2)
  {
    int result = default; // eax
  
    result = a2;
    if(a2 != default)
    {
      result = a2 - 1;
      if ( a2 == 1 )
      {
        this.ArmorBulletsHead = this.ArmorBulletsHeadSettings.Medium;
        this.ArmorBulletsBody = this.ArmorBulletsBodySettings.Medium;
        this.ArmorBulletsLegs = this.ArmorBulletsLegsSettings.Medium;
        this.ArmorMeleeHead = this.ArmorMeleeHeadSettings.Medium;
        this.ArmorMeleeBody = this.ArmorMeleeBodySettings.Medium;
        this.ArmorMeleeLegs = this.ArmorMeleeLegsSettings.Medium;
      }
      else
      {
        result = a2 - 2;
        if ( a2 == 2 )
        {
          this.ArmorBulletsHead = this.ArmorBulletsHeadSettings.Hard;
          this.ArmorBulletsBody = this.ArmorBulletsBodySettings.Hard;
          this.ArmorBulletsLegs = this.ArmorBulletsLegsSettings.Hard;
          this.ArmorMeleeHead = this.ArmorMeleeHeadSettings.Hard;
          this.ArmorMeleeBody = this.ArmorMeleeBodySettings.Hard;
          this.ArmorMeleeLegs = this.ArmorMeleeLegsSettings.Hard;
        }
      }
    }
    else
    {
      this.ArmorBulletsHead = this.ArmorBulletsHeadSettings.Easy;
      this.ArmorBulletsBody = this.ArmorBulletsBodySettings.Easy;
      this.ArmorBulletsLegs = this.ArmorBulletsLegsSettings.Easy;
      this.ArmorMeleeHead = this.ArmorMeleeHeadSettings.Easy;
      this.ArmorMeleeBody = this.ArmorMeleeBodySettings.Easy;
      this.ArmorMeleeLegs = this.ArmorMeleeLegsSettings.Easy;
    }
    return (int)(result);
  }

  public unsafe void performPhysics(float DeltaTime)
  {
    EMovement v3 = default; // al
    TdMove *v4; // ecx
    bool v5 = default; // zf
    TdMove *v6; // eax
    float v7 = default; // xmm0_4
    int v8 = default; // edi
    int v9 = default; // eax
  
    v3 = this.MovementState;
    if(v3 != default)
    {
      v4 = this.Moves.Data;
      v5 = v4[v3] == 0;
      v6 = &v4[v3];
      if ( default == v5 )
      {
        v6.CheckAutoMoves();// CheckAutoMoves
        this.Moves[this.MovementState].PrePerformPhysics(LODWORD(DeltaTime));// PrePerformPhysics
      }
    }
    if ( (this.bDisableSkelControlSpring.AsBitfield(32) & 131072) != 0 )
    {
      v7 = this.SlideEffectUpdateTimer - DeltaTime;
      this.SlideEffectUpdateTimer = v7;
      if ( v7 < 0.0f )
      {
        v8 = this.VfTableObject.Dummy;
        this.SlideEffectUpdateTimer = 0.2f;
        CallUFunction(this.UpdateSlideEffect, this, v9, 0, 0);
      }
    }
    this.performPhysics(DeltaTime);
  }

  public override unsafe float GetMobilityMultiplier()
  {
    float v1 = default; // xmm0_4
    float v2 = default; // xmm2_4
    double result = default; // st7
  
    v1 = 1.0f - (float)(this.TaserDamageLevel * 0.0099999998d);
    v2 = 0.0f;
    if ( v1 >= 0.0f && (v2 = 1.0f - (float)(this.TaserDamageLevel * 0.0099999998d), v1 > 1.0f) )
      result = 1.0f;
    else
      result = v2;
    return (float)(result);
  }

  public unsafe void CalcVelocity(Vector *a2, float a3, float a4, float a5, int a6, int a7, int a8)
  {
    uint v9 = default; // eax
    SkeletalMeshComponent v10 = default; // eax
    Controller v11 = default; // eax
    TdMove v12 = default; // eax
    float v13 = default; // xmm0_4
    int v14 = default; // eax
    TdMove *v15; // ecx
    bool v16 = default; // zf
    TdMove *v17; // eax
    double v18 = default; // st7
    float v19 = default; // xmm7_4
    float v20 = default; // xmm5_4
    float v21 = default; // edx
    Vector *v22; // edi
    float v23 = default; // xmm0_4
    float v24 = default; // xmm0_4
    float v25 = default; // xmm1_4
    float v26 = default; // xmm2_4
    float v27 = default; // xmm0_4
    float v28 = default; // xmm0_4
    float v29 = default; // xmm2_4
    Vector *v30; // eax
    float v31 = default; // ecx
    float v32 = default; // edx
    float v33 = default; // xmm0_4
    float v34 = default; // xmm2_4
    int v35 = default; // edx
    TdMove *v36; // eax
    TdMove *v37; // eax
    float v38 = default; // xmm1_4
    float v39 = default; // xmm6_4
    float v40 = default; // xmm0_4
    float v41 = default; // xmm2_4
    float v42 = default; // xmm1_4
    float v43 = default; // eax
    float v44 = default; // ecx
    float v45 = default; // xmm0_4
    float v46 = default; // xmm0_4
    float v47 = default; // xmm1_4
    float v48 = default; // xmm2_4
    float v49 = default; // xmm0_4
    EPhysics v50 = default; // al
    float v51 = default; // xmm3_4
    float v52 = default; // xmm5_4
    float v53 = default; // xmm6_4
    float v54 = default; // xmm3_4
    float v55 = default; // xmm0_4
    float v56 = default; // xmm0_4
    float v57 = default; // xmm0_4
    float v58 = default; // xmm1_4
    float v59 = default; // xmm0_4
    float v60 = default; // edx
    float v61 = default; // eax
    float v62 = default; // [esp+1Ch] [ebp-44h]
    float v63 = default; // [esp+1Ch] [ebp-44h]
    Vector v64 = default; // [esp+24h] [ebp-3Ch]
    Vector v65 = default; // [esp+24h] [ebp-3Ch]
    float v66 = default; // [esp+30h] [ebp-30h]
    Vector v67 = default; // [esp+30h] [ebp-30h]
    float v68 = default; // [esp+30h] [ebp-30h]
    float v69 = default; // [esp+30h] [ebp-30h]
    float v70 = default; // [esp+38h] [ebp-28h]
    float v71 = default; // [esp+44h] [ebp-1Ch]
    float v72 = default; // [esp+44h] [ebp-1Ch]
    float v73 = default; // [esp+48h] [ebp-18h]
    float v74 = default; // [esp+48h] [ebp-18h]
    Vector a2a = default; // [esp+50h] [ebp-10h] BYREF
    float AccelDir = default; // [esp+64h] [ebp+4h]
    float a4a = default; // [esp+6Ch] [ebp+Ch]
  
    v9 = this.bIsFemale.AsBitfield(20);
    if ( (v9 & 0x40000) == 0 && ((v9 & 0x20000) != 0 || (v10 = this.Mesh) != 0 && v10.RootMotionMode != RMM_Ignore) || (v11 = this.Controller) != 0 && (v11.bIsPlayer.AsBitfield(20) & 0x20000) != 0 )
    {
      this.CalcVelocity(a2, a3, a4, a5, a6, a7, a8);
      v12 = this.Moves[this.MovementState];
      v13 = this.Velocity.X * v12.RootMotionScale.X;
      v12 = (TdMove )((byte *)v12 + 0xFC);// points to RootMotionScale now
      this.Velocity.X = v13;
      this.Velocity.Y = *(float *)&v12.ObjectInternalInteger * this.Velocity.Y;
      this.Velocity.Z = *(float *)&v12.ObjectFlags_A * this.Velocity.Z;
      return;
    }
    v14 = this.MovementState;
    v15 = this.Moves.Data;
    v16 = v15[v14] == 0;
    v17 = &v15[v14];
    v62 = 1.0f;
    if ( default == v16 )
      v62 = v17.GetSpeedModifier();// GetSpeedModifier
    v18 = this.GetMobilityMultiplier() * v62;// GetMobilityMultiplier
    v19 = 0.0f;
    v63 = this.AccelRate * v18;
    v20 = v63;
    a4a = v18 * a4;
    if ( (BYTE2(this.bIsFemale.AsBitfield(20)) & 1) != 0 || (this.bDisableSkelControlSpring.AsBitfield(32) & 0x4000) != 0 )
    {
      SetFromBitfield(ref this.bDisableSkelControlSpring, 32, this.bDisableSkelControlSpring.AsBitfield(32) & (0xFFFFBFFF));
      if ( fabs(this.Acceleration.X) >= 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ || fabs(this.Acceleration.Y) >= 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ || fabs(this.Acceleration.Z) >= 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
      {
        v21 = a2->Y * v63;
        v70 = a2->Z * v63;
        this.Acceleration.X = v63 * a2->X;
        this.Acceleration.Y = v21;
        this.Acceleration.Z = v70;
        goto LABEL_35;
      }
fixed(var ptr1 =&this.Velocity)
      v22 =  ptr1;
      if ( this.Velocity.AllGreaterThan(0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/) )
      {
        v30 = this.Rotation.Vector(&a2a);
        v20 = v63;
        v31 = v30->Y * v63;
        v32 = v30->Z * v63;
        this.Acceleration.X = v30->X * v63;
        this.Acceleration.Y = v31;
        this.Acceleration.Z = v32;
        v33 = (float)((float)(this.Acceleration.X * this.Acceleration.X) + (float)(this.Acceleration.Y * this.Acceleration.Y)) + (float)(this.Acceleration.Z * this.Acceleration.Z);
        if ( v33 == 1.0f )
        {
          v64.X = this.Acceleration.X;
          v64.Y = this.Acceleration.Y;
          v64.Z = v32;
        }
        else
        {
          if ( v33 < 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
          {
            v19 = 0.0f;
            goto LABEL_31;
          }
          v34 = 1.0f / fsqrt(v33);
          a2a.X = (float)(3.0f - (float)((float)(v34 * v33) * v34)) * (float)(v34 * 0.5f);
          v64.X = this.Acceleration.X * a2a.X;
          v64.Y = a2a.X * this.Acceleration.Y;
          v64.Z = a2a.X * this.Acceleration.Z;
        }
        v19 = 0.0f;
        goto LABEL_34;
      }
      v23 = (float)((float)(v22->X * v22->X) + (float)(this.Velocity.Y * this.Velocity.Y)) + (float)(this.Velocity.Z * this.Velocity.Z);
      v66 = v23;
      if ( v23 == 1.0f )
      {
        v24 = v22->X;
        v25 = this.Velocity.Y;
        v26 = this.Velocity.Z;
      }
      else
      {
        if ( v23 < 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
        {
          v19 = 0.0f;
          v24 = 0.0f;
          v25 = 0.0f;
          v26 = 0.0f;
  LABEL_23:
          v20 = v63;
          this.Acceleration.X = v24 * v63;
          this.Acceleration.Y = v25 * v63;
          this.Acceleration.Z = v26 * v63;
          v28 = (float)((float)(this.Acceleration.X * this.Acceleration.X) + (float)(this.Acceleration.Y * this.Acceleration.Y)) + (float)(this.Acceleration.Z * this.Acceleration.Z);
          if ( v28 == 1.0f )
          {
            v64 = this.Acceleration;
  LABEL_34:
            *a2 = v64;
            goto LABEL_35;
          }
          if ( v28 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
          {
            v29 = 1.0f / fsqrt(v28);
            a2a.X = (float)(3.0f - (float)((float)(v29 * v28) * v29)) * (float)(v29 * 0.5f);
            v64.X = a2a.X * this.Acceleration.X;
            v64.Y = this.Acceleration.Y * a2a.X;
            v64.Z = this.Acceleration.Z * a2a.X;
            goto LABEL_34;
          }
  LABEL_31:
          v64.X = 0.0f;
          v64.Y = 0.0f;
          v64.Z = 0.0f;
          goto LABEL_34;
        }
        v27 = fsqrt(v23);
        a2a.X = (float)(3.0f - (float)((float)((float)(1.0f / v27) * v66) * (float)(1.0f / v27))) * (float)((float)(1.0f / v27) * 0.5f);
        v25 = a2a.X * this.Velocity.Y;
        v24 = v22->X * a2a.X;
        v26 = a2a.X * this.Velocity.Z;
      }
      v19 = 0.0f;
      goto LABEL_23;
    }
  LABEL_35:
    v35 = this.MovementState;
    v36 = this.Moves.Data;
    v16 = v36[v35] == 0;
    v37 = &v36[v35];
    if ( v16 || ((*v37).bDebugMove.AsBitfield(29) & 0x4000) == 0 )
    {
      if ( a7 && this.Acceleration.X == 0.0f && this.Acceleration.Y == 0.0f && this.Acceleration.Z == 0.0f )
      {
        v38 = a3;
        v67 = this.Velocity;
        v65.X = 0.0f;
        v65.Y = 0.0f;
        v65.Z = 0.0f;
        if ( a3 > 0.0f )
        {
          v39 = this.BrakingFrictionStrength;
          while(1 != default)
          {
            v40 = (float)(0.029999999d);
            if ( v38 <= 0.029999999d )
              v40 = v38;
            v41 = this.Velocity.Y;
            AccelDir = v38 - v40;
            v42 = (float)((float)((float)(this.Velocity.X * 2.0f) * v40) * a5) * v39;
            a2a.Z = (float)((float)((float)(this.Velocity.Z * 2.0f) * v40) * a5) * v39;
            v43 = this.Velocity.Y - (float)((float)((float)((float)(v41 * 2.0f) * v40) * a5) * v39);
            v44 = this.Velocity.Z - a2a.Z;
            this.Velocity.X = this.Velocity.X - v42;
            this.Velocity.Y = v43;
            this.Velocity.Z = v44;
            if ( (float)((float)((float)(this.Velocity.Y * v67.Y) + (float)(this.Velocity.Z * v67.Z)) + (float)(this.Velocity.X * v67.X)) > 0.0f )
            {
              v19 = 0.0f;
              v65.X = (float)((float)(this.Velocity.X * v40) * (float)(1.0f / a3)) + v65.X;
              v65.Y = (float)((float)(this.Velocity.Y * v40) * (float)(1.0f / a3)) + v65.Y;
              v65.Z = (float)((float)(this.Velocity.Z * v40) * (float)(1.0f / a3)) + v65.Z;
            }
            if ( AccelDir <= 0.0f )
              break;
            v38 = AccelDir;
          }
          v38 = a3;
        }
        this.Velocity = v65;
        if ( (float)((float)((float)(this.Velocity.Y * v67.Y) + (float)(this.Velocity.Z * v67.Z)) + (float)(this.Velocity.X * v67.X)) < 0.0f
          || (float)((float)((float)(this.Velocity.X * this.Velocity.X) + (float)(this.Velocity.Y * this.Velocity.Y)) + (float)(this.Velocity.Z * this.Velocity.Z)) < 100.0f )
        {
          this.Velocity.X = 0.0f;
          this.Velocity.Y = 0.0f;
          this.Velocity.Z = 0.0f;
        }
        goto LABEL_66;
      }
      if ( (float)((float)((float)(this.Acceleration.X * this.Acceleration.X) + (float)(this.Acceleration.Y * this.Acceleration.Y)) + (float)(this.Acceleration.Z * this.Acceleration.Z)) > (float)(v20 * v20) )
      {
        v45 = (float)((float)(this.Acceleration.X * this.Acceleration.X) + (float)(this.Acceleration.Y * this.Acceleration.Y)) + (float)(this.Acceleration.Z * this.Acceleration.Z);
        v68 = v45;
        if ( v45 == 1.0f )
        {
          v46 = this.Acceleration.X;
          v47 = this.Acceleration.Y;
          v48 = this.Acceleration.Z;
        }
        else if ( v45 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
        {
          v49 = fsqrt(v45);
          a2a.X = (float)(3.0f - (float)((float)((float)(1.0f / v49) * v68) * (float)(1.0f / v49))) * (float)((float)(1.0f / v49) * 0.5f);
          v46 = this.Acceleration.X * a2a.X;
          v47 = this.Acceleration.Y * a2a.X;
          v48 = this.Acceleration.Z * a2a.X;
        }
        else
        {
          v46 = 0.0f;
          v47 = 0.0f;
          v48 = 0.0f;
        }
        this.Acceleration.X = v46 * v20;
        this.Acceleration.Y = v47 * v20;
        this.Acceleration.Z = v48 * v20;
      }
      v50 = this.Physics;
      if ( v50 == PHYS_WallRunning || v50 == PHYS_WallClimbing )
      {
        v51 = this.Velocity.X - (float)((float)(this.Velocity.X * a3) * a5);
        v71 = this.Velocity.Y - (float)((float)(this.Velocity.Y * a3) * a5);
        v73 = this.Velocity.Z - (float)((float)(a3 * 0.0f) * a5);
      }
      else
      {
        v51 = this.Velocity.X - (float)((float)((float)(this.Velocity.X * a3) * a5) * 0.1f);
        v71 = this.Velocity.Y - (float)((float)((float)(this.Velocity.Y * a3) * a5) * 0.1f);
        v73 = this.Velocity.Z - (float)((float)((float)(this.Velocity.Z * a3) * a5) * 0.1f);
      }
      this.Velocity.X = v51;
      this.Velocity.Y = v71;
      this.Velocity.Z = v73;
    }
    v38 = a3;
  LABEL_66:
    v52 = this.Acceleration.X;
    v53 = this.Acceleration.Y;
    v54 = this.Velocity.Z;
    a2a.Z = this.Acceleration.Z * v38;
    v55 = 1.0f - (float)((float)((float)a6 * v38) * a5);
    v72 = (float)(this.Velocity.Y * v55) + (float)(v53 * v38);
    v74 = (float)(v54 * v55) + a2a.Z;
    this.Velocity.X = (float)(v55 * this.Velocity.X) + (float)(v52 * v38);
    this.Velocity.Y = v72;
    this.Velocity.Z = v74;
    if(a8 != default)
    {
      v19 = 0.0f;
      this.Velocity.Z = this.GetGravityZ() * (1.0f - this.Buoyancy) * a3 + this.Velocity.Z;// GetGravityZ
    }
    if ( (float)((float)((float)(this.Velocity.X * this.Velocity.X) + (float)(this.Velocity.Y * this.Velocity.Y)) + (float)(this.Velocity.Z * this.Velocity.Z)) > (float)(a4a * a4a) )
    {
      v56 = (float)((float)(this.Velocity.X * this.Velocity.X) + (float)(this.Velocity.Y * this.Velocity.Y)) + (float)(this.Velocity.Z * this.Velocity.Z);
      v69 = v56;
      if ( v56 == 1.0f )
      {
        v57 = this.Velocity.X;
        v58 = this.Velocity.Y;
        v19 = this.Velocity.Z;
      }
      else if ( v56 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
      {
        v59 = fsqrt(v56);
        a2a.X = (float)(3.0f - (float)((float)((float)(1.0f / v59) * v69) * (float)(1.0f / v59))) * (float)((float)(1.0f / v59) * 0.5f);
        v57 = a2a.X * this.Velocity.X;
        v58 = this.Velocity.Y * a2a.X;
        v19 = this.Velocity.Z * a2a.X;
      }
      else
      {
        v57 = 0.0f;
        v58 = 0.0f;
      }
      this.Velocity.X = v57 * a4a;
      this.Velocity.Y = v58 * a4a;
      this.Velocity.Z = v19 * a4a;
    }
    v60 = this.Velocity.Y;
    v61 = this.Velocity.Z;
    this.RMVelocity.X = this.Velocity.X;
    this.RMVelocity.Y = v60;
    this.RMVelocity.Z = v61;
  }

  public unsafe int UNKNOWN31(TdPawn Actor, Vector *a3, Vector *a4, Vector *a5, CheckResult *a6)
  {
    float v6 = default; // xmm4_4
    float v8 = default; // xmm0_4
    float v9 = default; // xmm1_4
    float v10 = default; // xmm2_4
    float v11 = default; // xmm4_4
    // int (__thiscall *v12)(TdPawn , int, _DWORD, _DWORD, _DWORD, int); // edx
    int v14 = default; // edi
    int v15 = default; // eax
    // int (__thiscall *v16)(TdPawn , int, _DWORD, _DWORD, _DWORD, int); // edx
    float v18 = default; // ecx
    float v19 = default; // edx
    float v20 = default; // ecx
    float v21 = default; // edx
    float v22 = default; // xmm2_4
    float v23 = default; // ecx
    float v24 = default; // edx
    float v25 = default; // xmm3_4
    float v26 = default; // xmm4_4
    float v27 = default; // xmm2_4
    float v28 = default; // xmm0_4
    float v29 = default; // ecx
    float v30 = default; // eax
    float v31 = default; // edx
    float v32 = default; // xmm1_4
    float v33 = default; // xmm3_4
    float v34 = default; // xmm0_4
    float v35 = default; // xmm4_4
    float v36 = default; // xmm2_4
    float v37 = default; // xmm5_4
    float v38 = default; // xmm1_4
    float v39 = default; // xmm4_4
    float v40 = default; // xmm5_4
    float v41 = default; // xmm0_4
    float v42 = default; // xmm1_4
    float v43 = default; // xmm0_4
    Vector v44 = default; // [esp+18h] [ebp-5Ch] BYREF
    float v45 = default; // [esp+24h] [ebp-50h]
    float v46 = default; // [esp+28h] [ebp-4Ch]
    float v47 = default; // [esp+30h] [ebp-44h]
    Vector Delta = default; // [esp+34h] [ebp-40h] BYREF
    Vector v49 = default; // [esp+40h] [ebp-34h] BYREF
    Vector v50 = default; // [esp+4Ch] [ebp-28h]
    Vector v51 = default; // [esp+58h] [ebp-1Ch] BYREF
    float v52 = default; // [esp+64h] [ebp-10h]
    float v53 = default; // [esp+68h] [ebp-Ch]
    float a5a = default; // [esp+80h] [ebp+Ch]
    float Hit = default; // [esp+84h] [ebp+10h]
  
    v6 = Actor.MaxWallStepHeight;
    v8 = (float)(Actor.Floor.X * -1.0f) * v6;
    v9 = (float)(Actor.Floor.Y * -1.0f) * v6;
    v10 = (float)(Actor.Floor.Z * -1.0f) * v6;
    v11 = a6.Normal.Z;
    v51.X = v8;
    v51.Y = v9;
    v51.Z = v10;
    if ( v11 > 0.70700002d && Actor.Physics == PHYS_WallRunning )
    {
      E_CallLanded(Actor, a6.Normal, a6.Actor);
      // v12 = *(int (__thiscall **)(TdPawn , int, _DWORD, _DWORD, _DWORD, int))(Actor.VfTableObject.Dummy + 480);
      v49.Z = 0.0f;
      v50.X = 0.0f;
      v50.Y = 1.0f;
      return (int)(Actor.setPhysics(, 1, 0, 0, 0, 1065353216));
    }
    if ( v11 < -0.70700002d && Actor.Physics == PHYS_WallRunning )
    {
      Actor.processHitWall( a6.Normal, a6.Actor, 0);// processHitWall
      v14 = Actor.VfTableObject.Dummy;
      CallUFunction(Actor.FallingOffWall, Actor, v15, 0, 0);
  LABEL_7:
      // v16 = *(int (__thiscall **)(TdPawn , int, _DWORD, _DWORD, _DWORD, int))(Actor.VfTableObject.Dummy + 480);
      v49.Z = 0.0f;
      v50.X = 0.0f;
      v50.Y = 1.0f;
      return (int)(Actor.setPhysics(, 2, 0, 0, 0, 1065353216));
    }
    if ( (float)((float)((float)(Actor.Floor.Z * a6.Normal.Z) + (float)(Actor.Floor.Y * a6.Normal.Y)) + (float)(Actor.Floor.X * a6.Normal.X)) < 0.1f )
    {
      v49.Z = v8 * -1.0f;
      v50.X = v9 * -1.0f;
      v50.Y = v10 * -1.0f;
fixed(var ptr1 =&Actor.Rotation)
      GWorld.MoveActor(Actor, (Vector *)&v49.Z,  ptr1, 0, a6);
fixed(var ptr2 =&Actor.Rotation)
      GWorld.MoveActor(Actor, a5,  ptr2, 0, a6);
    }
    if ( a6.Time < 1.0f )
    {
      if ( (float)((float)((float)(a6.Normal.Z * Actor.Floor.Z) + (float)(a6.Normal.Y * Actor.Floor.Y)) + (float)(Actor.Floor.X * a6.Normal.X)) < 0.40000001d )
      {
fixed(var ptr3 =&Actor.Rotation)
        GWorld.MoveActor(Actor, &v51,  ptr3, 0, a6);
        Actor.FallingOffWall();
        goto LABEL_7;
      }
      v18 = Actor.Floor.Y;
      v19 = Actor.Floor.Z;
      v47 = Actor.Floor.X;
      Actor.Floor.X = a6.Normal.X;
      Delta.X = v18;
      Actor.Floor.Y = a6.Normal.Y;
      Delta.Y = v19;
      Actor.Floor.Z = a6.Normal.Z;
      a6.Normal.Z = 0.0f;
      v44.Z = (float)((float)(a6.Normal.X * a6.Normal.X) + (float)(a6.Normal.Y * a6.Normal.Y)) + (float)(0.0f * 0.0f);
      if ( v44.Z == 1.0f )
      {
        v20 = a6.Normal.Y;
        v21 = a6.Normal.Z;
        v44.Z = a6.Normal.X;
        v45 = v20;
        v46 = v21;
      }
      else if ( v44.Z >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
      {
        v49.Z = 3.0f;
        v22 = 1.0f / fsqrt(v44.Z);
        v52 = (float)(3.0f - (float)((float)(v22 * v44.Z) * v22)) * (float)(v22 * 0.5f);
        v44.Z = a6.Normal.X * v52;
        v45 = a6.Normal.Y * v52;
        v46 = a6.Normal.Z * v52;
      }
      else
      {
        v44.Z = 0.0f;
        v45 = 0.0f;
        v46 = 0.0f;
      }
      v23 = v45;
      v24 = v46;
      v25 = Delta.Y;
      v26 = Delta.X;
      a6.Normal.X = v44.Z;
      a6.Normal.Y = v23;
      a6.Normal.Z = v24;
      v27 = Actor.Floor.Y;
      v28 = Actor.Floor.Z;
      v29 = a5->Y;
      v30 = a5->X;
      v31 = a5->Z;
      v44.Z = (float)(v27 * v25) - (float)(v28 * v26);
      v32 = Actor.Floor.X;
      v49.X = v29;
      Delta.Z = v30;
      v49.Y = v31;
      v45 = (float)(v28 * v47) - (float)(v32 * v25);
      v46 = (float)(v32 * v26) - (float)(v27 * v47);
      (Vector *.SafeNormal()&v44.Z, 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/);
      v49.Z = (float)(v45 * Delta.Y) - (float)(v46 * Delta.X);
      v50.X = (float)(v46 * v47) - (float)(Delta.Y * v44.Z);
      v50.Y = (float)(Delta.X * v44.Z) - (float)(v45 * v47);
      (Vector *.SafeNormal()&v49.Z, 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/);
      v33 = a5->X;
      v34 = (float)((float)(a5->Y * v50.X) + (float)(a5->Z * v50.Y)) + (float)(a5->X * v49.Z);
      v44.Y = (float)((float)(a5->Y * Delta.X) + (float)(a5->Z * Delta.Y)) + (float)(a5->X * v47);
      v35 = Actor.Floor.Z;
      v36 = (float)((float)(a5->Y * v45) + (float)(a5->Z * v46)) + (float)(a5->X * v44.Z);
      Hit = Actor.Floor.Y;
      a5a = Actor.Floor.X;
      v37 = (float)(a5a * v46) - (float)(v35 * v44.Z);
      v50.Y = (float)(Hit * v44.Z) - (float)(a5a * v45);
      v47 = Actor.Floor.X * v44.Y;
      Delta.X = Actor.Floor.Y * v44.Y;
      v38 = Actor.Floor.Z * v44.Y;
      v53 = v45 * v36;
      v39 = (float)((float)(v35 * v45) - (float)(Hit * v46)) * v34;
      v40 = (float)((float)(v37 * v34) + (float)(v45 * v36)) + Delta.X;
      v41 = (float)((float)(v50.Y * v34) + (float)(v46 * v36)) + v38;
      v42 = a5->Z * v41;
      v50.Y = v41;
      v43 = a5->Y * v40;
      v49.Z = (float)(v39 + (float)(v44.Z * v36)) + v47;
      v50.X = v40;
      Delta.Z = v49.Z;
      v49.X = v40;
      v49.Y = v50.Y;
      if ( (float)((float)(v42 + v43) + (float)(v33 * v49.Z)) >= 0.0f )
      {
        SetFromBitfield(ref Actor.bCollideComplex, 20, Actor.bCollideComplex.AsBitfield(20) | (0x100u));
fixed(var ptr4 =&Actor.Rotation)
        GWorld.MoveActor(Actor, (Vector *)&Delta.Z,  ptr4, 0, a6);
      }
    }
fixed(var ptr5 =&Actor.Rotation)
    return (int)(GWorld.MoveActor(Actor, &v51,  ptr5, 0, a6));
  }

  public unsafe void WallClimbingStepUp_maybe(TdPawn Actor, Vector *a3, Vector *a4, Vector *a5, CheckResult *a6)
  {
    float v6 = default; // xmm0_4
    float v7 = default; // xmm1_4
    float v8 = default; // xmm0_4
    float v9 = default; // xmm4_4
    float v10 = default; // xmm1_4
    float v11 = default; // xmm2_4
    // void (__thiscall *v12)(TdPawn , int, _DWORD, _DWORD, _DWORD, int); // edx
    float v13 = default; // xmm1_4
    float v14 = default; // xmm2_4
    float v15 = default; // xmm5_4
    float v16 = default; // xmm6_4
    float v17 = default; // xmm0_4
    Vector Delta = default; // [esp+Ch] [ebp-18h] BYREF
    Vector v19 = default; // [esp+18h] [ebp-Ch] BYREF
  
    v6 = Actor.MaxWallStepHeight;
    Delta.X = Actor.Floor.X * v6;
    Delta.Y = Actor.Floor.Y * v6;
    v7 = Actor.Floor.Z * v6;
    v8 = Actor.Floor.Z;
    Delta.Z = v7;
    if ( (float)((float)((float)(v8 * a6.Normal.Z) + (float)(Actor.Floor.Y * a6.Normal.Y)) + (float)(Actor.Floor.X * a6.Normal.X)) >= 0.94999999d
fixed(var ptr1 =&Actor.Rotation)
fixed(var ptr5 =&Actor.Rotation)
      || (GWorld.MoveActor(Actor, &Delta,  ptr5, 0, a6), GWorld.MoveActor(Actor, a5,  ptr1, 0, a6), v9 = a6.Time, v9 >= 1.0f)
      || (float)((float)((float)(Actor.Floor.Z * a6.Normal.Z) + (float)(Actor.Floor.Y * a6.Normal.Y)) + (float)(a6.Normal.X * Actor.Floor.X)) >= 0.94999999d )
    {
      if ( a6.Time < 1.0f && (float)((float)((float)(Actor.Floor.Z * a6.Normal.Z) + (float)(Actor.Floor.Y * a6.Normal.Y)) + (float)(a6.Normal.X * Actor.Floor.X)) < 0.94999999d )
      {
        Actor.Floor = a6.Normal;
        v13 = a5->Z;
        v14 = a5->Y;
        v15 = Actor.Floor.Y;
        v16 = Actor.Floor.Z;
        v17 = (float)((float)(v15 * v14) + (float)(v16 * v13)) + (float)(a5->X * Actor.Floor.X);
        v19.X = a5->X - (float)(Actor.Floor.X * v17);
        v19.Y = v14 - (float)(v15 * v17);
        v19.Z = v13 - (float)(v16 * v17);
fixed(var ptr2 =&Actor.Rotation)
        GWorld.MoveActor(Actor, &v19,  ptr2, 0, a6);
      }
    }
    else
    {
      v10 = (float)(-0.0f - a5->Y) * (float)(1.0f - v9);
      v11 = (float)(-0.0f - a5->Z) * (float)(1.0f - v9);
      v19.X = (float)(-0.0f - a5->X) * (float)(1.0f - v9);
      v19.Y = v10;
      v19.Z = v11;
fixed(var ptr3 =&Actor.Rotation)
      GWorld.MoveActor(Actor, &v19,  ptr3, 0, a6);
      v19.X = -0.0f - Delta.X;
      v19.Y = -0.0f - Delta.Y;
      v19.Z = -0.0f - Delta.Z;
fixed(var ptr4 =&Actor.Rotation)
      GWorld.MoveActor(Actor, &v19,  ptr4, 0, a6);
      if ( Actor.Physics == PHYS_WallClimbing )
      {
        Actor.FallingOffWall();
        // v12 = *(void (__thiscall **)(TdPawn , int, _DWORD, _DWORD, _DWORD, int))(Actor.VfTableObject.Dummy + 480);
        v19.X = 0.0f;
        v19.Y = 0.0f;
        v19.Z = 1.0f;
        Actor.setPhysics( 2, 0, 0, 0, 1065353216);
      }
      Actor.Velocity.Z = 0.0f;
    }
  }

  // NOT READY
  public unsafe void GetCameraAnimation(Vector *out_Location, Rotator *out_Rotation){ NativeMarkers.MarkUnimplemented(); }
//public unsafe void GetCameraAnimation(Vector *out_Location, Rotator *out_Rotation)
//  {
//    SkeletalMeshComponent v4 = default; // ecx
//    int v5 = default; // eax
//    SkeletalMeshComponent v6 = default; // edx
//    Matrix *v7; // eax
//    int v8 = default; // esi
//    int v9 = default; // eax
//    uint v10 = default; // edx
//    uint v11 = default; // esi
//    uint v12 = default; // edx
//    uint v13 = default; // ecx
//    int v14 = default; // [esp+14h] [ebp-11Ch] BYREF
//    Rotator a2 = default; // [esp+18h] [ebp-118h] BYREF
//    Rotator v16 = default; // [esp+24h] [ebp-10Ch] BYREF
//    Matrix v17 = default; // [esp+30h] [ebp-100h] BYREF
//    Matrix a1 = default; // [esp+70h] [ebp-C0h] BYREF
//    Matrix SrcMatrix = default; // [esp+B0h] [ebp-80h] BYREF
//    __m128* v20 = stackalloc __m128[4]; // [esp+F0h] [ebp-40h] BYREF
//  
//    v4 = this.Mesh;
//    if(v4 != default)
//    {
//      v5 = E_FindSocketIndex(v4, *(&FuncName_SlideOffLedge_unknown_EyeJoint + 2), dword_2056800);
//      v6 = this.Mesh;
//fixed(var ptr1 =&v6.SpaceBases)
//      qmemcpy(&a1,  ptr1[v5], sizeof(a1));
//fixed(var ptr2 =&this.Mesh.SpaceBases)
//      qmemcpy(&v17,  ptr2[E_FindSocketIndex(v6, dword_2056804, dword_2056808)], sizeof(v17));
//      v7 = VectorMatrixInverse(&a1, &SrcMatrix);
//      qmemcpy(&v17, (__m128 *.Mult()&v17, v20, (__m128 *)v7), sizeof(v17));
//      E_MatrixToRotator(&a1, &a2);
//      E_MatrixToRotator(&v17, &v16);
//      v8 = this.VfTableObject.Dummy;
//      v14 = default;
//      CallUFunction(this.AddCameraDeltaAnimations, this, v9, &v14, 0);
//      if(v14 != default)
//      {
//        v10 = v16.Yaw + a2.Yaw;
//        v11 = a2.Roll + v16.Roll;
//        out_Rotation.Pitch = v16.Pitch + a2.Pitch;
//        out_Rotation.Yaw = v10;
//        out_Rotation.Roll = v11;
//      }
//      else
//      {
//        v12 = a2.Yaw;
//        out_Rotation.Pitch = a2.Pitch;
//        v13 = a2.Roll;
//        out_Rotation.Yaw = v12;
//        out_Rotation.Roll = v13;
//      }
//    }
//  }
//
  public unsafe void stepUp(Vector *GravDir, Vector *DesiredDir, Vector *Delta, CheckResult *Hit)
  {
    Vector *v5; // edi
    float v6 = default; // xmm4_4
    float v7 = default; // xmm5_4
    float v8 = default; // xmm6_4
    float v10 = default; // xmm3_4
    float v11 = default; // xmm2_4
    CheckResult *v12; // eax
    float v13 = default; // xmm1_4
    Vector *v14; // ebp
    float v15 = default; // xmm0_4
    float v16 = default; // xmm3_4
    float v17 = default; // xmm5_4
    bool v18 = default; // cf
    Vector *v19; // esi
    float v20 = default; // xmm1_4
    float v21 = default; // xmm0_4
    float v22 = default; // xmm3_4
    float v23 = default; // xmm4_4
    float v24 = default; // xmm5_4
    float v25 = default; // ecx
    float v26 = default; // edx
    Vector *v27; // esi
    PrimitiveComponent v28 = default; // eax
    float v29 = default; // eax
    float v30 = default; // edx
    Vector *v31; // eax
    float v32 = default; // xmm0_4
    float v33 = default; // xmm0_4
    float v34 = default; // xmm3_4
    float v35 = default; // edx
    float v36 = default; // xmm0_4
    float v37 = default; // ecx
    float v38 = default; // xmm0_4
    // void (__thiscall *v39)(TdPawn , Vector *, Vector *, Vector *, CheckResult *); // edx
    float v40 = default; // xmm1_4
    float v41 = default; // xmm2_4
    float v42 = default; // xmm0_4
    float v43 = default; // xmm6_4
    float v44 = default; // xmm3_4
    float v45 = default; // xmm4_4
    float v46 = default; // xmm0_4
    float v47 = default; // xmm1_4
    float v48 = default; // xmm2_4
    int v49 = default; // ecx
    TdMove *v50; // edx
    int v51 = default; // eax
    bool v52 = default; // eax
    float v53 = default; // edx
    float v54 = default; // ecx
    float v55 = default; // eax
    float v56 = default; // xmm2_4
    float v57 = default; // xmm4_4
    float v58 = default; // xmm5_4
    float v59 = default; // xmm6_4
    float v60 = default; // xmm0_4
    float v61 = default; // xmm1_4
    float v62 = default; // xmm2_4
    float v63 = default; // xmm3_4
    float v64 = default; // xmm0_4
    float v65 = default; // ecx
    float v66 = default; // edx
    float v67 = default; // xmm1_4
    float v68 = default; // xmm2_4
    float v69 = default; // xmm0_4
    float v70 = default; // xmm4_4
    float v71 = default; // xmm5_4
    float v72 = default; // xmm3_4
    float v73 = default; // xmm0_4
    float v74 = default; // xmm2_4
    float v75 = default; // xmm0_4
    float v76 = default; // xmm0_4
    float v77 = default; // xmm0_4
    double v78 = default; // st6
    double v79 = default; // st5
    float v80 = default; // xmm0_4
    float v81 = default; // xmm1_4
    float v82 = default; // xmm2_4
    float v83 = default; // xmm0_4
    float v84 = default; // xmm3_4
    float v85 = default; // xmm0_4
    float v86 = default; // xmm1_4
    float v87 = default; // xmm0_4
    float v88 = default; // xmm2_4
    float v89 = default; // xmm1_4
    float v90 = default; // xmm2_4
    float v91 = default; // xmm0_4
    float v92 = default; // ecx
    float v93 = default; // edx
    float v94 = default; // xmm2_4
    float v95 = default; // xmm0_4
    float v96 = default; // xmm0_4
    float v97 = default; // xmm6_4
    float v98 = default; // xmm5_4
    float v99 = default; // xmm4_4
    float v100 = default; // xmm0_4
    float v101 = default; // xmm0_4
    float v102 = default; // xmm1_4
    float v103 = default; // xmm2_4
    float v104 = default; // eax
    Vector Deltaa = default; // [esp+40h] [ebp-124h] BYREF
    Vector a4a = default; // [esp+50h] [ebp-114h] BYREF
    float v107 = default; // [esp+5Ch] [ebp-108h]
    Vector v108 = default; // [esp+60h] [ebp-104h]
    Vector v109 = default; // [esp+70h] [ebp-F4h] BYREF
    int v110 = default; // [esp+7Ch] [ebp-E8h]
    float v111 = default; // [esp+80h] [ebp-E4h]
    float v112 = default; // [esp+84h] [ebp-E0h]
    int v113 = default; // [esp+94h] [ebp-D0h]
    float v114 = default; // [esp+98h] [ebp-CCh]
    Vector a2a = default; // [esp+9Ch] [ebp-C8h] BYREF
    float v116 = default; // [esp+ACh] [ebp-B8h]
    float v117 = default; // [esp+BCh] [ebp-A8h]
    CheckResult v118 = default; // [esp+CCh] [ebp-98h] BYREF
    int v119 = default; // [esp+114h] [ebp-50h]
    byte* v120 = stackalloc byte[76]; // [esp+118h] [ebp-4Ch] BYREF
  
    v5 = GravDir;
    v6 = GravDir->X;
    v7 = GravDir->Y;
    v8 = GravDir->Z;
    v10 = this.MaxStepHeight + 2.0f;
    v11 = v8 * v10;
    v110 = 1;
    v113 = 1;
    v12 = Hit;
    v13 = v7 * v10;
fixed(var ptr1 =&Hit.Normal)
    v14 =  ptr1;
    v15 = v6 * v10;
    v16 = (float)(Hit.Normal.Z * v8) + (float)(Hit.Normal.Y * v7);
    v17 = Hit.Normal.X * v6;
    v109.X = v15;
    v109.Y = v13;
    v109.Z = v11;
    if ( (float)((float)(v16 + v17) * -1.0f) >= 0.079999998d && (v18 = Hit.Normal.Z < this.WalkableFloorZ, v107 = Hit.Normal.Z, v18) )
    {
      v19 = Delta;
      if ( this.Physics == PHYS_Walking )
        goto LABEL_14;
      v20 = Delta->Y;
      v21 = Delta->Z;
      v111 = Delta->X;
      v110 = LODWORD(v20);
      v114 = v21;
      Deltaa.Y = v20;
      Deltaa.X = v111;
      a2a.Z = sqrt(v111 * v111 + v20 * v20 + v21 * v21) * v107;
      Deltaa.Z = a2a.Z + v21;
fixed(var ptr2 =&this.Rotation)
      GWorld.MoveActor(this, &Deltaa,  ptr2, 0, Hit);
      v110 = default;
    }
    else
    {
      v22 = v14->X;
      v23 = Hit.Normal.Y;
      v24 = Hit.Normal.Z;
      qmemcpy(v120, Hit, sizeof(v120));
      Deltaa.X = (float)(v15 * -1.0f) + (float)(v22 * 0.1f);
      Deltaa.Y = (float)(v13 * -1.0f) + (float)(v23 * 0.1f);
      Deltaa.Z = (float)(v11 * -1.0f) + (float)(v24 * 0.1f);
fixed(var ptr3 =&this.Rotation)
      GWorld.MoveActor(this, &Deltaa,  ptr3, 0, Hit);
      v25 = this.Location.Y;
      v26 = this.Location.Z;
fixed(var ptr4 =&this.Location)
      v27 =  ptr4;
      v108.X = this.Location.X;
      v108.Y = v25;
      v108.Z = v26;
fixed(var ptr5 =&this.Rotation)
      GWorld.MoveActor(this, Delta,  ptr5, 0, Hit);
      if ( Hit.Time >= 1.0f || this.WalkableFloorZ > Hit.Normal.Z )
      {
        v118.Item = -1;
        v118.LevelIndex = -1;
        v28 = this.CollisionComponent;
        v118.Actor = default;
        v118.Location.X = 0.0f;
        v118.Location.Y = 0.0f;
        v118.Location.Z = 0.0f;
        v118.Normal.X = 0.0f;
        v118.Normal.Y = 0.0f;
        v118.Normal.Z = 0.0f;
        v118.Time = 0.0f;
        v118.Material = default;
        v118.PhysMaterial = default;
        v118.Component = default;
        v118.BoneName = default;
        v118.Level = default;
        v118.bStartPenetrating = default;
        v119 = default;
        if(v28 != default)
        {
          a4a.X = v27->X + v28.Translation.X;
          a4a.Y = this.Location.Y + v28.Translation.Y;
          a4a.Z = this.Location.Z + v28.Translation.Z;
          v27 = &a4a;
        }
        v29 = v27->Y;
        Deltaa.X = v27->X;
        v30 = v27->Z;
        a4a.X = Deltaa.X + v109.X;
        Deltaa.Y = v29;
        a4a.Y = v29 + v109.Y;
        Deltaa.Z = v30;
        a4a.Z = v30 + v109.Z;
        v31 = this.GetCylinderExtent(&a2a);
        GWorld.SingleLineCheck(&v118, this, &a4a, &Deltaa, 8415, v31, 0);
        if ( v118.Time < 1.0f && this.WalkableFloorZ > v118.Normal.Z )
        {
          v32 = v108.X;
          qmemcpy(Hit, v120, 0x4Cu);
          a4a.X = v32 - this.Location.X;
          a4a.Y = v108.Y - this.Location.Y;
          v33 = v108.Z - this.Location.Z;
          v113 = default;
          a4a.Z = v33;
fixed(var ptr6 =&this.Rotation)
          GWorld.MoveActor(this, &a4a,  ptr6, 0, &v118);
        }
      }
      v19 = Delta;
      v5 = GravDir;
    }
    v12 = Hit;
  LABEL_14:
    v34 = v12->Time;
    if ( v34 >= 1.0f )
      goto LABEL_98;
    v35 = v19->Y;
    v36 = (float)((float)(Hit.Normal.Z * v5->Z) + (float)(Hit.Normal.Y * v5->Y)) + (float)(v5->X * Hit.Normal.X);
    a4a.X = v19->X;
    v37 = v19->Z;
    v111.LODWORD(1);
    a4a.Y = v35;
    a4a.Z = v37;
    if ( (float)(v36 * -1.0f) < 0.079999998d && (float)((float)((float)((float)(v19->X * v19->X) + (float)(v19->Y * v19->Y)) + (float)(v19->Z * v19->Z)) * v34) > 144.0f )
    {
      if(v110 != default)
      {
fixed(var ptr7 =&this.Rotation)
        GWorld.MoveActor(this, &v109,  ptr7, 0, v12);
        v12 = Hit;
      }
      v38 = 1.0f - v12->Time;
      // v39 = *(void (__thiscall **)(TdPawn , Vector *, Vector *, Vector *, CheckResult *))(this.VfTableObject.Dummy + 528);
      Deltaa.X = v19->X * v38;
      Deltaa.Y = v19->Y * v38;
      Deltaa.Z = v19->Z * v38;
      this.stepUp( v5, DesiredDir, &Deltaa, v12);
      return;
    }
    if ( v113 && this.WalkableFloorZ > v12->Normal.Z )
    {
      if ( !this.IsHitActorTdPawn( v12) )// IsHitActorTdPawn 0x012C3790
      {
  LABEL_37:
        v12 = Hit;
        goto LABEL_38;
      }
      v40 = v19->Z;
      v41 = v19->Y;
      v42 = (float)((float)(Hit.Normal.Y * v41) + (float)(Hit.Normal.Z * v40)) + (float)(Hit.Normal.X * v19->X);
      v43 = Hit.Normal.Z * v42;
      v44 = v19->X - (float)(v14->X * v42);
      v45 = v41 - (float)(Hit.Normal.Y * v42);
      v46 = (float)(v44 * v44) + (float)(v45 * v45);
      v47 = v40 - v43;
      v108.X = v44;
      v108.Y = v45;
      v108.Z = v47;
      Deltaa.X = v46;
      if ( v46 == 1.0f )
      {
        if ( v47 == 0.0f )
        {
          Deltaa = v108;
  LABEL_32:
          v49 = this.MovementState;
          v50 = this.Moves.Data;
          v51 = v50[v49] && (v50[v49].bDebugMove.AsBitfield(29) & 0x200000) != 0;
          v52 = this.UNKNOWN28(&Deltaa, v51, 0, &a4a, Hit);
          v111.LODWORD(default == v52);
          if(v52 != default)
            goto LABEL_97;
          goto LABEL_37;
        }
        Deltaa.X = v44;
      }
      else
      {
        if ( v46 < 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
        {
          Deltaa.X = 0.0f;
          Deltaa.Y = 0.0f;
  LABEL_31:
          Deltaa.Z = 0.0f;
          goto LABEL_32;
        }
        v112 = 3.0f;
        v107 = 0.5f;
        v48 = 1.0f / fsqrt(Deltaa.X);
        a2a.X = (float)(3.0f - (float)((float)(v48 * Deltaa.X) * v48)) * (float)(v48 * 0.5f);
        v45 = v45 * a2a.X;
        Deltaa.X = a2a.X * v44;
      }
      Deltaa.Y = v45;
      goto LABEL_31;
    }
  LABEL_38:
    this.processHitWall(
      Hit.Normal,
      v12->Actor,
      v12->Component);
    if ( this.Physics == PHYS_Falling )
      return;
    Hit.Normal.Z = 0.0f;
    Deltaa.X = (float)((float)(Hit.Normal.X * Hit.Normal.X) + (float)(Hit.Normal.Y * Hit.Normal.Y)) + (float)(Hit.Normal.Z * Hit.Normal.Z);
    if ( Deltaa.X == 1.0f )
    {
      v53 = v14->X;
      v54 = Hit.Normal.Y;
      v55 = Hit.Normal.Z;
    }
    else
    {
      if ( Deltaa.X >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
      {
        v112 = 3.0f;
        v107 = 0.5f;
        v56 = 1.0f / fsqrt(Deltaa.X);
        a2a.X = (float)(3.0f - (float)((float)(v56 * Deltaa.X) * v56)) * (float)(v56 * 0.5f);
        Deltaa.X = a2a.X * v14->X;
        Deltaa.Y = Hit.Normal.Y * a2a.X;
        Deltaa.Z = Hit.Normal.Z * a2a.X;
      }
      else
      {
        Deltaa.X = 0.0f;
        Deltaa.Y = 0.0f;
        Deltaa.Z = 0.0f;
      }
      v53 = Deltaa.X;
      v54 = Deltaa.Y;
      v55 = Deltaa.Z;
    }
    v14->X = v53;
    Hit.Normal.Y = v54;
    Hit.Normal.Z = v55;
    v57 = v19->Z;
    v58 = v19->Y;
    v59 = v19->X;
    v60 = (float)((float)(Hit.Normal.Y * v58) + (float)(Hit.Normal.Z * v57)) + (float)(v19->X * Hit.Normal.X);
    v61 = v58 - (float)(Hit.Normal.Y * v60);
    v62 = v57 - (float)(Hit.Normal.Z * v60);
    v63 = 1.0f - Hit.Time;
    Deltaa.X = (float)(v19->X - (float)(v14->X * v60)) * v63;
    Deltaa.Y = v61 * v63;
    a2a.Z = v55;
    v64 = (float)((float)(v59 * v59) + (float)(v58 * v58)) + (float)(v57 * v57);
    a4a.X = Deltaa.X;
    a2a.X = v53;
    a2a.Y = v54;
    Deltaa.Z = v62 * v63;
    a4a.Y = v61 * v63;
    a4a.Z = v62 * v63;
    Deltaa.X = v64;
    if ( v64 == 1.0f )
    {
      v65 = v19->Y;
      v66 = v19->Z;
      Deltaa.X = v19->X;
      Deltaa.Y = v65;
      Deltaa.Z = v66;
    }
    else
    {
      if ( v64 < 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
      {
        v67 = 0.0f;
        Deltaa.X = 0.0f;
        Deltaa.Y = 0.0f;
        Deltaa.Z = 0.0f;
        goto LABEL_51;
      }
      v112 = 3.0f;
      v107 = 0.5f;
      v68 = 1.0f / fsqrt(Deltaa.X);
      v108.X = (float)(3.0f - (float)((float)(v68 * Deltaa.X) * v68)) * (float)(v68 * 0.5f);
      Deltaa.X = v108.X * v19->X;
      v69 = v108.X * v19->Z;
      Deltaa.Y = v108.X * v19->Y;
      Deltaa.Z = v69;
    }
    v67 = 0.0f;
  LABEL_51:
    v70 = a4a.Z;
    v71 = a4a.Y;
    v72 = a4a.X;
    v73 = (float)((float)(v70 * v70) + (float)(v71 * v71)) + (float)(v72 * v72);
    v116 = v73;
    if ( v73 == 1.0f )
    {
      v108 = a4a;
      v67 = a4a.X;
      v74 = a4a.Y;
      v75 = a4a.Z;
    }
    else if ( v73 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
    {
      v117 = 3.0f;
      v107 = 0.5f;
      v76 = fsqrt(v116);
      v112 = (float)(3.0f - (float)((float)((float)(1.0f / v76) * v116) * (float)(1.0f / v76))) * (float)((float)(1.0f / v76) * 0.5f);
      v71 = a4a.Y;
      v70 = a4a.Z;
      v72 = a4a.X;
      v67 = v112 * a4a.X;
      v74 = a4a.Y * v112;
      v75 = a4a.Z * v112;
    }
    else
    {
      v74 = 0.0f;
      v75 = 0.0f;
    }
    if ( (float)((float)((float)(v75 * Deltaa.Z) + (float)(v74 * Deltaa.Y)) + (float)(v67 * Deltaa.X)) > 0.70700002d )
    {
      v77 = (float)((float)(v70 * v70) + (float)(v71 * v71)) + (float)(v72 * v72);
      v78 = v19->Y * v19->Y + v19->X * v19->X;
      v79 = v19->Z;
      v117 = v77;
      v114 = (float)(sqrt(v79 * v79 + v78));
      if ( v77 == 1.0f )
      {
        Deltaa = a4a;
        v80 = a4a.X;
        v81 = a4a.Y;
        v82 = a4a.Z;
      }
      else if ( v77 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
      {
        v116 = 3.0f;
        v107 = 0.5f;
        v83 = fsqrt(v117);
        v112 = (float)(3.0f - (float)((float)((float)(1.0f / v83) * v117) * (float)(1.0f / v83))) * (float)((float)(1.0f / v83) * 0.5f);
        v80 = v112 * a4a.X;
        v81 = a4a.Y * v112;
        v82 = a4a.Z * v112;
      }
      else
      {
        v80 = 0.0f;
        v81 = 0.0f;
        v82 = 0.0f;
      }
      v84 = v80 * v114;
      v85 = 1.0f - Hit.Time;
      Deltaa.X = v84 * v85;
      Deltaa.Y = (float)(v81 * v114) * v85;
      Deltaa.Z = (float)(v82 * v114) * v85;
      a4a.X = v84 * v85;
      v72 = v84 * v85;
      a4a.Y = Deltaa.Y;
      v71 = Deltaa.Y;
      a4a.Z = Deltaa.Z;
      v70 = Deltaa.Z;
    }
    if ( (float)((float)((float)(v72 * v19->X) + (float)(v70 * v19->Z)) + (float)(v71 * v19->Y)) >= 0.0f )
    {
fixed(var ptr8 =&this.Rotation)
      GWorld.MoveActor(this, &a4a,  ptr8, 0, Hit);
      if(v113 != default)
      {
        if ( Hit.Time < 1.0f )
        {
          v86 = a4a.Y;
          v87 = (float)(v86 * v86) + (float)(a4a.X * a4a.X);
          v117 = v87;
          if ( v87 == 1.0f )
          {
            if ( a4a.Z == 0.0f )
            {
              Deltaa = a4a;
              goto LABEL_75;
            }
            Deltaa.X = a4a.X;
          }
          else
          {
            if ( v87 < 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
            {
              Deltaa.X = 0.0f;
              Deltaa.Y = 0.0f;
  LABEL_74:
              Deltaa.Z = 0.0f;
  LABEL_75:
              v89 = Hit.Normal.Y;
              v90 = v14->X;
              v91 = (float)(v90 * v90) + (float)(v89 * v89);
              v117 = v91;
              if ( v91 == 1.0f )
              {
                if ( Hit.Normal.Z == 0.0f )
                {
                  v92 = Hit.Normal.Y;
                  v93 = Hit.Normal.Z;
                  v108.X = v14->X;
                  v108.Y = v92;
                  v108.Z = v93;
  LABEL_83:
                  if ( v108.Z * Deltaa.Z + v108.Y * Deltaa.Y + v108.X * Deltaa.X < -0.707f && this.IsHitActorTdPawn( Hit) )// IsHitActorTdPawn
                  {
                    v96 = (float)((float)(Hit.Normal.Z * a4a.Z) + (float)(Hit.Normal.Y * a4a.Y)) + (float)(Hit.Normal.X * a4a.X);
                    v97 = Hit.Normal.Z * v96;
                    v98 = a4a.X - (float)(v96 * Hit.Normal.X);
                    v99 = a4a.Y - (float)(Hit.Normal.Y * v96);
                    v100 = (float)(v99 * v99) + (float)(v98 * v98);
                    Deltaa.X = a4a.X - (float)((float)((float)((float)(Hit.Normal.Z * a4a.Z) + (float)(Hit.Normal.Y * a4a.Y)) + (float)(Hit.Normal.X * a4a.X)) * Hit.Normal.X);
                    Deltaa.Y = v99;
                    Deltaa.Z = a4a.Z - v97;
                    v117 = v100;
                    if ( v100 == 1.0f )
                    {
                      if ( (float)(a4a.Z - v97) == 0.0f )
                      {
                        v108 = Deltaa;
                        v101 = Deltaa.X;
                        v99 = Deltaa.Y;
                        v102 = Deltaa.Z;
                      }
                      else
                      {
                        v101 = v98;
                        v102 = 0.0f;
                      }
                    }
                    else if ( v100 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
                    {
                      v116 = 3.0f;
                      v107 = 0.5f;
                      v103 = 1.0f / fsqrt(v117);
                      v112 = (float)(3.0f - (float)((float)(v103 * v117) * v103)) * (float)(v103 * 0.5f);
                      v99 = v99 * v112;
                      v102 = 0.0f;
                      v101 = v112 * v98;
                    }
                    else
                    {
                      v101 = 0.0f;
                      v99 = 0.0f;
                      v102 = 0.0f;
                    }
                    Deltaa.X = -0.0f - v101;
                    Deltaa.Y = -0.0f - v99;
                    Deltaa.Z = -0.0f - v102;
                    v104.LODWORD(default == this.UNKNOWN28(&Deltaa, 0, 1, &a4a, Hit));
                  }
                  else
                  {
                    v104 = v111;
                  }
                  if ( v104 != 0.0f )
                  {
                    this.processHitWall(
                      Hit.Normal,
                      Hit.Actor,
                      Hit.Component);
                    if ( this.Physics == PHYS_Falling )
                      return;
fixed(var ptr9 =&a2a.X)
fixed(var ptr12 =&v14->X)
fixed(var ptr13 =&a4a.X)
fixed(var ptr14 =&DesiredDir->X)
                    TwoWallAdjust( ptr14,  ptr13,  ptr12,  ptr9, Hit.Time);
fixed(var ptr10 =&this.Rotation)
                    GWorld.MoveActor(this, &a4a,  ptr10, 0, Hit);
                    v12 = Hit;
                    goto LABEL_98;
                  }
                  goto LABEL_97;
                }
                v108.X = v90;
                v108.Y = v89;
              }
              else if ( v91 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
              {
                v116 = 3.0f;
                v107 = 0.5f;
                v94 = 1.0f / fsqrt(v117);
                v112 = (float)(3.0f - (float)((float)(v94 * v117) * v94)) * (float)(v94 * 0.5f);
                v95 = v112 * Hit.Normal.Y;
                v108.X = v112 * v14->X;
                v108.Y = v95;
              }
              else
              {
                v108.X = 0.0f;
                v108.Y = 0.0f;
              }
              v108.Z = 0.0f;
              goto LABEL_83;
            }
            v116 = 3.0f;
            v107 = 0.5f;
            v88 = 1.0f / fsqrt(v117);
            v108.X = (float)(3.0f - (float)((float)(v88 * v117) * v88)) * (float)(v88 * 0.5f);
            Deltaa.X = v108.X * a4a.X;
            v86 = a4a.Y * v108.X;
          }
          Deltaa.Y = v86;
          goto LABEL_74;
        }
      }
    }
  LABEL_97:
    v12 = Hit;
  LABEL_98:
    if(v110 != default)
fixed(var ptr11 =&this.Rotation)
      GWorld.MoveActor(this, &v109,  ptr11, 0, v12);
  }

  public unsafe void SyncLegMovement()
  {
    ref array<SynchGroup> v1; // edx
    int v2 = default; // ebp
    ref array<SynchGroup> v3; // edi
    int v4 = default; // esi
    SynchGroup *v5; // eax
    SynchGroup *v6; // ecx
  
fixed(var ptr1 =&this.MasterSync3p.Groups)
    v1 =  ptr1;
    v2 = default;
fixed(var ptr2 =&this.MasterSync1p.Groups)
    v3 =  ptr2;
    if ( this.MasterSync3p.Groups.Count > 0 )
    {
      v4 = default;
      do
      {
        v5 = &v1[v4];
        v6 = &v3[v4];
        if ( (v5->bitfield_bUseSharedMasterControlNode & 1) != 0 )
        {
          v5->SharedMasterRelativePosition = v6->SharedMasterRelativePosition;
          v5->SharedMasterMoveDelta = v6->SharedMasterMoveDelta;
        }
        ++v2;
        ++v4;
      }
      while ( v2 < v1.Count );
    }
  }

  public unsafe void OffsetMeshXY(Vector Offset, int bWorldSpace)
  {
    Vector *v4; // eax
    float v5 = default; // ecx
    TdSkeletalMeshComponent v6 = default; // eax
    float v7 = default; // xmm4_4
    float v8 = default; // xmm0_4
    TdSkeletalMeshComponent v9 = default; // ecx
    float v10 = default; // xmm0_4
    TdSkeletalMeshComponent v11 = default; // eax
    float v12 = default; // xmm0_4
    TdSkeletalMeshComponent v13 = default; // ecx
    float v14 = default; // xmm0_4
    float v15 = default; // [esp+8h] [ebp-98h]
    Vector v16 = default; // [esp+14h] [ebp-8Ch] BYREF
    Matrix SrcMatrix = default; // [esp+20h] [ebp-80h] BYREF
    Matrix DstMatrix = default; // [esp+60h] [ebp-40h] BYREF
  
fixed(var ptr1 =&this.Rotation)
    FRotationMatrix(&DstMatrix,  ptr1);
    if(bWorldSpace != default)
    {
      VectorMatrixInverse(&DstMatrix, &SrcMatrix);
      v16.X = (float)((float)((float)(SrcMatrix.XPlane.X * Offset.X) + (float)(SrcMatrix.ZPlane.X * Offset.Z)) + (float)(SrcMatrix.YPlane.X * Offset.Y)) + SrcMatrix.WPlane.X;
      v16.Y = (float)((float)((float)(SrcMatrix.XPlane.Y * Offset.X) + (float)(SrcMatrix.ZPlane.Y * Offset.Z)) + (float)(SrcMatrix.YPlane.Y * Offset.Y)) + SrcMatrix.WPlane.Y;
      v16.Z = (float)((float)((float)(SrcMatrix.XPlane.Z * Offset.X) + (float)(SrcMatrix.ZPlane.Z * Offset.Z)) + (float)(SrcMatrix.YPlane.Z * Offset.Y)) + SrcMatrix.WPlane.Z;
      v4 = &v16;
    }
    else
    {
      v4 = &Offset;
    }
    v5 = v4->Y;
    v15 = v4->X;
    v6 = this.Mesh1p;
    v7 = v5;
    if(v6 != default)
    {
      v8 = v6.Translation.X + v15;
      if ( v8 >= -32.0f )
      {
        if ( v8 > 32.0f )
          v8 = 32.0f;
      }
      else
      {
        v8 = -32.0f;
      }
      v6.Translation.X = v8;
      v9 = this.Mesh1p;
      v10 = v9.Translation.Y + v7;
      if ( v10 >= -32.0f )
      {
        if ( v10 > 32.0f )
          v10 = 32.0f;
      }
      else
      {
        v10 = -32.0f;
      }
      v9.Translation.Y = v10;
    }
    v11 = this.Mesh3p;
    if(v11 != default)
    {
      v12 = v11.Translation.X + v15;
      if ( v12 >= -32.0f )
      {
        if ( v12 > 32.0f )
          v12 = 32.0f;
      }
      else
      {
        v12 = -32.0f;
      }
      v11.Translation.X = v12;
      v13 = this.Mesh3p;
      v14 = v13.Translation.Y + v7;
      if ( v14 >= -32.0f )
      {
        if ( v14 > 32.0f )
          v14 = 32.0f;
        v13.Translation.Y = v14;
      }
      else
      {
        v13.Translation.Y = -32.0f;
      }
    }
  }

  public unsafe void OffsetMeshZ(float a2)
  {
    TdSkeletalMeshComponent v2 = default; // eax
    float v3 = default; // xmm1_4
    float v4 = default; // xmm0_4
    TdSkeletalMeshComponent v5 = default; // eax
    float v6 = default; // xmm1_4
    float v7 = default; // xmm0_4
  
    v2 = this.Mesh1p;
    if(v2 != default)
    {
      v3 = a2 + v2.Translation.Z;
      v4 = this.TargetMeshTranslationZ + 24.0f;
      if ( v3 < (float)(this.TargetMeshTranslationZ - 24.0f) )
        v3 = this.TargetMeshTranslationZ - 24.0f;
      if ( v4 >= v3 )
        v4 = v3;
      v2.Translation.Z = v4;
    }
    v5 = this.Mesh3p;
    if(v5 != default)
    {
      v6 = v5.Translation.Z + a2;
      v7 = this.TargetMeshTranslationZ + 24.0f;
      if ( v6 < (float)(this.TargetMeshTranslationZ - 24.0f) )
        v6 = this.TargetMeshTranslationZ - 24.0f;
      if ( v7 >= v6 )
        v7 = v6;
      v5.Translation.Z = v7;
    }
  }

  public unsafe void UpdateMeshTranslation_OrSomething(float a2)
  {
    EMovement v2 = default; // al
    float v4 = default; // xmm4_4
    double v5 = default; // st7
    float v6 = default; // xmm0_4
    TdSkeletalMeshComponent v7 = default; // eax
    float v8 = default; // xmm2_4
    double v9 = default; // st6
    float v10 = default; // xmm1_4
    float v11 = default; // xmm0_4
    double v12 = default; // st6
    float v13 = default; // xmm1_4
    float v14 = default; // xmm0_4
    TdSkeletalMeshComponent v15 = default; // edx
    double v16 = default; // st6
    double v17 = default; // st6
    float v18 = default; // xmm3_4
    float v19 = default; // xmm0_4
    TdSkeletalMeshComponent v20 = default; // eax
    double v21 = default; // st6
    float v22 = default; // xmm1_4
    float v23 = default; // xmm0_4
    double v24 = default; // st6
    float v25 = default; // xmm1_4
    float v26 = default; // xmm0_4
    TdSkeletalMeshComponent v27 = default; // edx
    double v28 = default; // st6
    double v29 = default; // st6
    float v30 = default; // xmm0_4
    float v31 = default; // [esp+0h] [ebp-4h]
    float v32 = default; // [esp+0h] [ebp-4h]
    float v33 = default; // [esp+0h] [ebp-4h]
    float v34 = default; // [esp+0h] [ebp-4h]
    float v35 = default; // [esp+0h] [ebp-4h]
    float v36 = default; // [esp+0h] [ebp-4h]
    float a2g = default; // [esp+8h] [ebp+4h]
    float a2a = default; // [esp+8h] [ebp+4h]
    float a2h = default; // [esp+8h] [ebp+4h]
    float a2b = default; // [esp+8h] [ebp+4h]
    float a2i = default; // [esp+8h] [ebp+4h]
    float a2c = default; // [esp+8h] [ebp+4h]
    float a2d = default; // [esp+8h] [ebp+4h]
    float a2j = default; // [esp+8h] [ebp+4h]
    float a2e = default; // [esp+8h] [ebp+4h]
    float a2k = default; // [esp+8h] [ebp+4h]
    float a2f = default; // [esp+8h] [ebp+4h]
  
    v2 = this.MovementState;
    v4 = a2 * 100.0f;
    if ( v2 == MOVE_Walking || v2 == MOVE_Crouch )
    {
      v5 = sqrt(this.Velocity.Y * this.Velocity.Y + this.Velocity.X * this.Velocity.X) * 0.0099999998d;
      if ( v5 < 1.0f )
      {
        a2g = (float)v5;
        v6 = a2g;
      }
      else
      {
        v6 = 1.0f;
      }
      v4 = v6 * v4;
    }
    v7 = this.Mesh1p;
    v8 = 0.0f;
    if(v7 != default)
    {
      a2a = v7.Translation.X;
      v9 = fabs(a2a);
      if ( v9 > 0.0001f )
      {
        if ( a2a == 0.0f )
        {
          v10 = 0.0f;
        }
        else
        {
          a2h = (float)(a2a / fabs(a2a));
          v10 = a2h;
        }
        v11 = (float)v9;
        v31 = (float)v9;
        if ( v4 < v31 )
          v11 = v4;
        this.Mesh1p.Translation.X = this.Mesh1p.Translation.X - (float)(v10 * v11);
      }
      a2b = this.Mesh1p.Translation.Y;
      v12 = fabs(a2b);
      if ( v12 > 0.0001f )
      {
        if ( a2b == 0.0f )
        {
          v13 = 0.0f;
        }
        else
        {
          a2i = (float)(a2b / fabs(a2b));
          v13 = a2i;
        }
        v14 = (float)v12;
        v32 = (float)v12;
        if ( v4 < v32 )
          v14 = v4;
        this.Mesh1p.Translation.Y = this.Mesh1p.Translation.Y - (float)(v13 * v14);
      }
      v15 = this.Mesh1p;
      v16 = this.TargetMeshTranslationZ - v15.Translation.Z;
      a2c = (float)v16;
      v17 = fabs(v16);
      v33 = (float)v17;
      if ( v17 > 0.0001f )
      {
        if ( a2c == 0.0f )
          v18 = 0.0f;
        else
          v18 = a2c / v33;
        v19 = (float)(v33 * a2) * 10.0f;
        if ( v19 <= 1.0f )
          v19 = 1.0f;
        if ( v19 >= v33 )
          v19 = (float)v17;
        v15.Translation.Z = (float)(v18 * v19) + v15.Translation.Z;
      }
    }
    v20 = this.Mesh3p;
    if(v20 != default)
    {
      a2d = v20.Translation.X;
      v21 = fabs(a2d);
      if ( v21 > 0.0001f )
      {
        if ( a2d == 0.0f )
        {
          v22 = 0.0f;
        }
        else
        {
          a2j = (float)(a2d / fabs(a2d));
          v22 = a2j;
        }
        v23 = (float)v21;
        v34 = (float)v21;
        if ( v4 < v34 )
          v23 = v4;
        this.Mesh3p.Translation.X = this.Mesh3p.Translation.X - (float)(v22 * v23);
      }
      a2e = this.Mesh3p.Translation.Y;
      v24 = fabs(a2e);
      if ( v24 > 0.0001f )
      {
        if ( a2e == 0.0f )
        {
          v25 = 0.0f;
        }
        else
        {
          a2k = (float)(a2e / fabs(a2e));
          v25 = a2k;
        }
        v26 = (float)v24;
        v35 = (float)v24;
        if ( v4 < v35 )
          v26 = v4;
        this.Mesh3p.Translation.Y = this.Mesh3p.Translation.Y - (float)(v25 * v26);
      }
      v27 = this.Mesh3p;
      v28 = this.TargetMeshTranslationZ - v27.Translation.Z;
      a2f = (float)v28;
      v29 = fabs(v28);
      v36 = (float)v29;
      if ( v29 > 0.0001f )
      {
        if ( a2f != 0.0f )
          v8 = a2f / v36;
        v30 = (float)(v36 * a2) * 10.0f;
        if ( v30 <= 1.0f )
          v30 = 1.0f;
        if ( v30 >= v36 )
          v30 = (float)v29;
        v27.Translation.Z = (float)(v8 * v30) + v27.Translation.Z;
      }
    }
  }

  public unsafe float GetAverageSpeed(float a2)
  {
    float v2 = default; // xmm2_4
    float v3 = default; // xmm3_4
    float v4 = default; // xmm1_4
    float v5 = default; // xmm0_4
    int v6 = default; // ebx
    int v7 = default; // edx
    double result = default; // st7
    int v9 = default; // eax
    int v10 = default; // eax
    float *v11; // esi
    float *v12; // edi
    int v13 = default; // ebp
    int v14 = default; // eax
    uint v15 = default; // edx
    int v16 = default; // ecx
    float v17 = default; // xmm2_4
    float v18 = default; // xmm4_4
    int v19 = default; // ecx
    float v20 = default; // xmm1_4
    float v21 = default; // xmm3_4
    int v22 = default; // ecx
    int v23 = default; // ebx
    float v24 = default; // xmm0_4
    int v25 = default; // esi
    int v26 = default; // edi
    int v27 = default; // ecx
    int v28 = default; // edx
    int v29 = default; // eax
    int v30 = default; // [esp+0h] [ebp-20h]
    int v31 = default; // [esp+4h] [ebp-1Ch]
    int v32 = default; // [esp+Ch] [ebp-14h]
    int v33 = default; // [esp+10h] [ebp-10h]
    TdPawn v34 = default; // [esp+14h] [ebp-Ch]
    int v35 = default; // [esp+18h] [ebp-8h]
    int v36 = default; // [esp+1Ch] [ebp-4h]
    float *v37; // [esp+1Ch] [ebp-4h]
    int v38 = default; // [esp+24h] [ebp+4h]
    float *v39; // [esp+24h] [ebp+4h]
  
    v2 = this.ASFilterTime;
    v3 = a2;
    v34 = this;
    v4 = 0.0f;
    v5 = 0.0f;
    if ( a2 >= v2 )
      v3 = this.ASFilterTime;
    v6 = this.ASPollSlots;
    v7 = (int)(float)((float)((float)v6 * v3) / v2);
    v38 = v6;
    v35 = v7;
    if ( v7 <= 0 )
      return 0.0f;
    v9 = default;
    if ( v7 >= 4 )
    {
      v10 = this.ASSlotPointer;
      v11 = this.ASTimeData.Data;
      v12 = this.ASDistanceData.Data;
      v31 = v10 - 2;
      v30 = v10;
      v13 = v10 + v6 - 2;
      v14 = 4 * (v10 - 2);
      v32 = 1 - v6;
      v15 = ((uint)(v7 - 4) >> 2) + 1;
      v33 = -1 - v6;
      v36 = 4 * v15;
      do
      {
        v16 = v14 + 8;
        if ( v30 < 0 )
          v16 = v16 + (4 * v6);
        v17 = *(float *__ptr32)((byte *)v11 + v16) + v4;
        v18 = *(float *__ptr32)((byte *)v12 + v16) + v5;
        v19 = v14 + 4;
        if ( v13 + v32 < 0 )
          v19 = v19 + (4 * v38);
        v20 = *(float *__ptr32)((byte *)v11 + v19) + v17;
        v21 = *(float *__ptr32)((byte *)v12 + v19) + v18;
        v22 = v14;
        if ( v31 < 0 )
          v22 = v14 + 4 * v38;
        v23 = v14 - 4;
        if ( v13 + v33 < 0 )
          v23 = v23 + (4 * v38);
        v30 = v30 - (4);
        v31 = v31 - (4);
        v4 = *(float *__ptr32)((byte *)v11 + v23) + (float)(*(float *__ptr32)((byte *)v11 + v22) + v20);
        v24 = *(float *__ptr32)((byte *)v12 + v23);
        v6 = v38;
        v14 = v14 - (16);
        v13 = v13 - (4);
        --v15;
        v5 = v24 + (float)(*(float *__ptr32)((byte *)v12 + v22) + v21);
      }
      while(v15 != default);
      this = v34;
      v7 = v35;
      v9 = v36;
    }
    if ( v9 < v7 )
    {
      v39 = this.ASTimeData.Data;
      v37 = this.ASDistanceData.Data;
      v25 = this.ASSlotPointer - v9;
      v26 = v25 + v6;
      v27 = 4 * v25;
      v28 = v7 - v9;
      do
      {
        v29 = v27;
        if ( v25 < 0 )
          v29 = v27 + 4 * v6;
        v4 = *(float *__ptr32)((byte *)v39 + v29) + v4;
        v27 = v27 - (4);
        --v25;
        --v26;
        --v28;
        v5 = *(float *__ptr32)((byte *)v37 + v29) + v5;
      }
      while(v28 != default);
    }
    if ( v5 == 0.0f )
      result = 0.0f;
    else
      result = (float)(v5 / v4);
    return (float)(result);
  }

  public unsafe void UpdateLegToWorldMatrix(short Yaw)
  {
    uint v3 = default; // eax
    Matrix *v4; // eax
    Matrix *v5; // [esp-4h] [ebp-A4h]
    Rotator a2 = default; // [esp+14h] [ebp-8Ch] BYREF
    __m128* v7 = stackalloc __m128[4]; // [esp+20h] [ebp-80h] BYREF
    Matrix v8 = default; // [esp+60h] [ebp-40h] BYREF
  
    v3 = (ushort)(Yaw - LOWORD(this.Rotation.Yaw));
    if ( v3 > 0x7FFF )
      v3 = v3 - (0x10000);
    a2.Pitch = v3;
    a2.Yaw = default;
    a2.Roll = default;
fixed(var ptr1 =&this.Mesh.LocalToWorld)
    v5 =  ptr1;
    v4 = FRotationMatrix(&v8, &a2);
fixed(var ptr2 =&this.Mesh.LocalToLegRotatedWorld)
    qmemcpy( ptr2, (__m128 *.Mult()v4, v7, (__m128 *)v5), sizeof(this.Mesh.LocalToLegRotatedWorld));
  }

  public unsafe float GetAIAimingPenalty()
  {
    return (float)(this.Moves[this.MovementState].AiAimPenalty);
  }

  public unsafe float GetAIAimingOneShotPenalty()
  {
    EMovement v1 = default; // al
    double result = default; // st7
  
    v1 = this.MovementState;
    if ( this.AIAimOldMovementState == v1 )
      result = 0.0f;
    else
      result = this.Moves[v1].AiAimOneShotPenalty;
    return (float)(result);
  }

  public unsafe float GetAIAimingOneShotPenaltySniper()
  {
    return (float)(this.Moves[this.MovementState].AiAimOneShotPenalty);
  }

  public override unsafe EMoveAimMode GetAimMode(int a2)
  {
    TdMove v3 = default; // ecx
    EMoveAimMode v5 = default; // bl
    TdWeapon v6 = default; // eax
    EWeaponType v7 = default; // al
    EWeaponAnimState v8 = default; // al
    EAgainstWallState v10 = default; // dl
    EWeaponAnimState v11 = default; // cl
    EWeaponType a2a = default; // [esp+10h] [ebp+4h]
  
    v3 = this.Moves[this.MovementState];
    v5 = v3.GetAimMode( a2);// GetAimMode
    v6 = this.MyWeapon;
    if(v6 != default)
    {
      v7 = v6.WeaponType;
      a2a = v7;
    }
    else
    {
      a2a = EWT_None;
      v7 = EWT_None;
    }
    if ( v5 == MAM_Default )
    {
      if(a2 != default)
      {
        if ( this.IsHumanControlled() && this.WeaponAnimState == WS_Reload || this.CurrentWalkingState > WAS_Walk || a2a == EWT_Heavy )
          return 2;
        v8 = this.WeaponAnimState;
        if ( v8 == WS_Ready || v8 == WS_Throwing )
          return 1;
      }
      else
      {
        v10 = this.AgainstWallState;
        if ( v10 == AW_AgainstWall || v7 == EWT_Heavy || ((v11 = this.WeaponAnimState) is object && v11 == WS_Reload) || this.MovementState == MOVE_Vertigo )
        {
          v5 = MAM_TwoHanded;
        }
        else if ( v11 == WS_Ready || v11 == WS_Relaxed )
        {
          v5 = ((((byte)v7 - 1) >> 31) | ((1 - (byte)v7) >> 31)) + 2;
        }
        if ( v10 == AW_AgainstWallLeft )
          return ((((byte)v5 - 3) >> 31) | ((3 - (byte)v5) >> 31)) & 2;
        if ( v10 == AW_AgainstWallRight )
          v5 = v5 + ((1 - v5) & ((((byte)v5 - 2) >> 31) | ((2 - (byte)v5) >> 31)));
      }
    }
    return v5;
  }

  public unsafe int PlayCustomAnimInternal(TdAnimNodeSlot tdSlot, name AnimName, float Rate, float BlendInTime, float BlendOutTime, int bLooping, int bOverride, int bRootMotion, int bRootRotation)
  {
    AnimNodeSequence v11 = default; // eax
    TdAnimNodeSequence v12 = default; // eax
  
    if ( default == tdSlot || tdSlot.PlayCustomAnim(AnimName, Rate, BlendInTime, BlendOutTime, bLooping, bOverride) == 0.0f )
      return 0;
    if ( tdSlot == this.CustomCameraNode || tdSlot == this.CustomWeaponNode1p )
    {
      v11 = tdSlot.GetCustomAnimNodeSeq();
      v12 = E_TryCastTo<TdAnimNodeSequence>(v11);
      SetFromBitfield(ref v12.bSnapToKeyFrames, 12, v12.bSnapToKeyFrames.AsBitfield(12) | (0x40u));
    }
    if(bRootMotion != default)
      tdSlot.SetRootBoneAxisOption(RBA_Translate, RBA_Translate, RBA_Translate);
    else
      tdSlot.SetRootBoneAxisOption(RBA_Default, RBA_Default, RBA_Default);
    if(bRootRotation != default)
      tdSlot.SetRootBoneRotationAxisOption(RRO_Extract, RRO_Extract, RRO_Extract);
    else
      tdSlot.SetRootBoneRotationAxisOption(RRO_Discard, RRO_Discard, RRO_Discard);
    tdSlot.SetActorAnimEndNotification(1);
    tdSlot.SetCauseActorCeaseRelevant( 1);// SetCauseActorCeaseRelevant
    return 1;
  }

  public unsafe void StopCustomAnim(ECustomNodeType Type, float BlendOutTime)
  {
    AnimNodeSequence v3 = default; // edi
    AnimNodeSequence v4 = default; // ebx
    TdAnimNodeSlot v6 = default; // ecx
    TdAnimNodeSlot v7 = default; // ecx
    AnimNodeSequence v8 = default; // eax
    TdAnimNodeSlot v9 = default; // ecx
    TdAnimNodeSlot v10 = default; // ecx
    TdAnimNodeSlot v11 = default; // ecx
    TdAnimNodeSlot v12 = default; // ecx
    TdAnimNodeSlot v13 = default; // ecx
    TdAnimNodeSlot v14 = default; // ecx
    TdAnimNodeSlot v15 = default; // ecx
    TdAnimNodeSlot v16 = default; // ecx
    TdAnimNodeSlot v17 = default; // ecx
    TdAnimNodeSlot v18 = default; // ecx
    TdAnimNodeSlot v19 = default; // ecx
    TdAnimNodeSlot v20 = default; // ecx
    AnimNodeSequence v21 = default; // eax
    TdAnimNodeSlot v22 = default; // ecx
    TdAnimNodeSlot v23 = default; // ecx
    TdAnimNodeSlot v24 = default; // ecx
    TdMove v25 = default; // ecx
  
    v3 = default;
    v4 = default;
    switch ( (int)Type )
    {
      case (int)CNT_Canned:
        v6 = this.CustomCannedNode1p;
        if(v6 != default)
        {
          v3 = v6.GetCustomAnimNodeSeq();
          this.CustomCannedNode1p.StopCustomAnim(BlendOutTime);
        }
        v7 = this.CustomCannedNode3p;
        if(v7 != default)
        {
          v8 = v7.GetCustomAnimNodeSeq();
          v9 = this.CustomCannedNode3p;
          goto LABEL_34;
        }
        break;
      case (int)CNT_CannedUpperBody:
        v10 = this.CustomCannedUpperBodyNode1p;
        if(v10 != default)
        {
          v3 = v10.GetCustomAnimNodeSeq();
          this.CustomCannedUpperBodyNode1p.StopCustomAnim(BlendOutTime);
        }
        v11 = this.CustomCannedUpperBodyNode3p;
        if(v11 != default)
        {
          v8 = v11.GetCustomAnimNodeSeq();
          v9 = this.CustomCannedUpperBodyNode3p;
          goto LABEL_34;
        }
        break;
      case (int)CNT_FullBody:
        v12 = this.CustomFullBodyNode1p;
        if(v12 != default)
        {
          v3 = v12.GetCustomAnimNodeSeq();
          this.CustomFullBodyNode1p.StopCustomAnim(BlendOutTime);
        }
        v13 = this.CustomFullBodyNode3p;
        if(v13 != default)
        {
          v8 = v13.GetCustomAnimNodeSeq();
          v9 = this.CustomFullBodyNode3p;
          goto LABEL_34;
        }
        break;
      case (int)CNT_FullBody_Dir:
        v14 = this.CustomFullBodyDirNode1p;
        if(v14 != default)
        {
          v3 = v14.GetCustomAnimNodeSeq();
          this.CustomFullBodyDirNode1p.StopCustomAnim(BlendOutTime);
        }
        v15 = this.CustomFullBodyDirNode3p;
        if(v15 != default)
        {
          v8 = v15.GetCustomAnimNodeSeq();
          v9 = this.CustomFullBodyDirNode3p;
          goto LABEL_34;
        }
        break;
      case (int)CNT_UpperBody:
        v16 = this.CustomUpperBodyNode1p;
        if(v16 != default)
        {
          v3 = v16.GetCustomAnimNodeSeq();
          this.CustomUpperBodyNode1p.StopCustomAnim(BlendOutTime);
        }
        v17 = this.CustomUpperBodyNode3p;
        if(v17 != default)
        {
          v8 = v17.GetCustomAnimNodeSeq();
          v9 = this.CustomUpperBodyNode3p;
          goto LABEL_34;
        }
        break;
      case (int)CNT_LowerBody:
        v18 = this.CustomLowerBodyNode1p;
        if(v18 != default)
        {
          v3 = v18.GetCustomAnimNodeSeq();
          this.CustomLowerBodyNode1p.StopCustomAnim(BlendOutTime);
        }
        v19 = this.CustomLowerBodyNode3p;
        if(v19 != default)
        {
          v8 = v19.GetCustomAnimNodeSeq();
          v9 = this.CustomLowerBodyNode3p;
          goto LABEL_34;
        }
        break;
      case (int)CNT_Camera:
        v20 = this.CustomCameraNode;
        if(v20 != default)
        {
          v21 = v20.GetCustomAnimNodeSeq();
          v9 = this.CustomCameraNode;
          v3 = v21;
          goto LABEL_35;
        }
        break;
      case (int)CNT_Weapon:
        v22 = this.CustomWeaponNode1p;
        if(v22 != default)
        {
          v3 = v22.GetCustomAnimNodeSeq();
          this.CustomWeaponNode1p.StopCustomAnim(BlendOutTime);
        }
        v23 = this.CustomWeaponNode3p;
        if(v23 != default)
        {
          v8 = v23.GetCustomAnimNodeSeq();
          v9 = this.CustomWeaponNode3p;
          goto LABEL_34;
        }
        break;
      case (int)CNT_Face:
        v24 = this.CustomFaceNode;
        if(v24 != default)
        {
          v8 = v24.GetCustomAnimNodeSeq();
          v9 = this.CustomFaceNode;
  LABEL_34:
          v4 = v8;
  LABEL_35:
          v9.StopCustomAnim(BlendOutTime);
        }
        break;
      default:
        break;
    }
    if ( (uint)v3 | (v3 == 0 ? (uint)v4 : 0) )
    {
      v25 = this.Moves[this.MovementState];
      if ( v25.CurrentCustomAnimName.Index == *(_DWORD *)(((uint)v3 | (v3 == 0 ? (uint)v4 : 0)) + 0xBC) && v25.CurrentCustomAnimName.Number == *(_DWORD *)(((uint)v3 | (v3 == 0 ? (uint)v4 : 0)) + 0xC0) )
        v25.CallOnAnimationStopped((AnimNodeSequence )((uint)v3 | (v3 == 0 ? (uint)v4 : 0)));
    }
  }

  public unsafe bool CanDropWeapon()
  {
    Matrix *v2; // eax
    float v3 = default; // xmm1_4
    float v4 = default; // xmm2_4
    float v5 = default; // xmm3_4
    float v6 = default; // xmm4_4
    float v7 = default; // xmm5_4
    float v8 = default; // xmm6_4
    float v9 = default; // xmm7_4
    float v10 = default; // xmm0_4
    float v11 = default; // xmm2_4
    float v12 = default; // xmm3_4
    Vector a4 = default; // [esp+4h] [ebp-A8h] BYREF
    Vector a3 = default; // [esp+10h] [ebp-9Ch] BYREF
    CheckResult a2 = default; // [esp+1Ch] [ebp-90h] BYREF
    int v17 = default; // [esp+64h] [ebp-48h]
    Matrix v18 = default; // [esp+6Ch] [ebp-40h] BYREF
  
    a2.Next = default;
    a2.Actor = default;
    a2.Material = default;
    a2.PhysMaterial = default;
    a2.Component = default;
    a2.BoneName = default;
    a2.Level = default;
    a2.bStartPenetrating = default;
    v17 = default;
    a2.Item = -1;
    a2.LevelIndex = -1;
    a2.Location.X = 0.0f;
    a2.Location.Y = 0.0f;
    a2.Location.Z = 0.0f;
    a2.Normal.X = 0.0f;
    a2.Normal.Y = 0.0f;
    a2.Normal.Z = 0.0f;
    a2.Time = 0.0f;
fixed(var ptr1 =&this.Rotation)
    v2 = FRotationMatrix(&v18,  ptr1);
    v3 = v2->ZPlane.X;
    v4 = v2->XPlane.X;
    v5 = v2->XPlane.Y;
    v6 = v2->XPlane.Z;
    v7 = v2->YPlane.X;
    v8 = v2->YPlane.Y;
    v9 = v2->YPlane.Z;
    a4.Y = v2->ZPlane.Y;
    a4.Z = v2->ZPlane.Z;
    a3.X = v3 * 20.0f;
    a3.Y = a4.Y * 20.0f;
    v10 = this.Location.X + (float)(v4 * 20.0f);
    v11 = this.Location.Y + (float)(v5 * 20.0f);
    v12 = (float)((float)(this.Location.Z + (float)(v6 * 20.0f)) + (float)(v9 * 30.0f)) + (float)(a4.Z * 20.0f);
    a3.X = (float)(v10 + (float)(v7 * 30.0f)) + (float)(v3 * 20.0f);
    a3.Y = (float)(v11 + (float)(v8 * 30.0f)) + (float)(a4.Y * 20.0f);
    a3.Z = v12;
    a4.X = 30.0f;
    a4.Y = 30.0f;
    a4.Z = 30.0f;
    return GWorld.EncroachingWorldGeometry(&a2, &a3, &a4, 1) == 0;
  }

  // NOT READY
  public unsafe int Spawned(){ NativeMarkers.MarkUnimplemented(); return default; }
//public unsafe int Spawned()
//  {
//    int v2 = default; // ebp
//    DrawFrustumComponent v3 = default; // eax
//    float v4 = default; // xmm0_4
//    float v5 = default; // xmm0_4
//    int i = default; // ebx
//    int v7 = default; // edi
//    int v8 = default; // eax
//    MaterialInterface v9 = default; // edi
//    int j = default; // ebx
//    int v11 = default; // edi
//    int v12 = default; // eax
//    MaterialInterface v13 = default; // edi
//    TdSkeletalMeshComponent v14 = default; // eax
//    SkeletalMesh v15 = default; // eax
//    int v16 = default; // ebx
//    int v17 = default; // edi
//    int v18 = default; // eax
//    MaterialInterface v19 = default; // edi
//    int result = default; // eax
//    int v21 = default; // ebx
//    int v22 = default; // edi
//    int v23 = default; // eax
//    MaterialInterface v24 = default; // edi
//  
//    v2 = sub_F358A0((int)this.SceneCapture);
//    v3 = this.DrawFrustum;
//    if(v3 != default)
//    {
//      if(v2 != default)
//      {
//        v3.FrustumAngle = *(float *)(v2 + 140);
//        v4 = *(float *)(v2 + 144);
//        if ( v4 < 50.0f )
//          v4 = 50.0f;
//        this.DrawFrustum.FrustumStartDist = v4;
//        v5 = *(float *)(v2 + 148);
//        if ( v5 < 200.0f )
//          v5 = 200.0f;
//        this.DrawFrustum.FrustumEndDist = v5;
//        if ( *(_DWORD *)(v2 + 128) )
//          this.DrawFrustum.FrustumAspectRatio = (float)*(int *)(*(_DWORD *)(v2 + 128) + 188) / (float)*(int *)(*(_DWORD *)(v2 + 128) + 192);
//      }
//    }
//    for ( i = default; i < this.Mesh3p.SkeletalMesh.Materials.Count; ++i )
//    {
//      if ( default == dword_1FFD744 )
//      {
//        dword_1FFD744 = (int)sub_E58D70((int)L"Engine");
//        sub_E525E0();
//      }
//      v7 = dword_1FFD744;
//      v8 = sub_1101A90();
//      if ( v8 == -1 )
//        v8 = sub_1101A90();
//      v9 = (MaterialInterface )sub_1110DD0(v7, v8, 0, 0, 0, 0, 0, dword_20186F4, 0, 0);
//      (*(void (__thiscall **)(MaterialInterface , MaterialInterface ))(v9.VfTableObject.Dummy + 356))(v9, this.Mesh3p.SkeletalMesh.Materials[i]);
//      (*(void (__thiscall **)(MaterialInterface , int, int, _DWORD))(v9.VfTableObject.Dummy + 372))(v9, dword_2056844, dword_2056848, *(_DWORD *)(v2 + 128));
//      sub_D36AF0(this.Mesh3p, i, v9);
//    }
//    for ( j = default; j < this.Mesh.SkeletalMesh.Materials.Count; ++j )
//    {
//      if ( default == dword_1FFD744 )
//      {
//        dword_1FFD744 = (int)sub_E58D70((int)L"Engine");
//        sub_E525E0();
//      }
//      v11 = dword_1FFD744;
//      v12 = sub_1101A90();
//      if ( v12 == -1 )
//        v12 = sub_1101A90();
//      v13 = (MaterialInterface )sub_1110DD0(v11, v12, 0, 0, 0, 0, 0, dword_20186F4, 0, 0);
//      (*(void (__thiscall **)(MaterialInterface , MaterialInterface ))(v13.VfTableObject.Dummy + 356))(v13, this.Mesh.SkeletalMesh.Materials[j]);
//      (*(void (__thiscall **)(MaterialInterface , int, int, _DWORD))(v13.VfTableObject.Dummy + 372))(v13, dword_2056844, dword_2056848, *(_DWORD *)(v2 + 128));
//      sub_D36AF0(this.Mesh, j, v13);
//    }
//    v14 = this.Mesh1pLowerBody;
//    if(v14 != default)
//    {
//      v15 = v14.SkeletalMesh;
//      if(v15 != default)
//      {
//        v16 = default;
//        if ( v15.Materials.Count > 0 )
//        {
//          do
//          {
//            if ( default == dword_1FFD744 )
//            {
//              dword_1FFD744 = (int)sub_E58D70((int)L"Engine");
//              sub_E525E0();
//            }
//            v17 = dword_1FFD744;
//            v18 = sub_1101A90();
//            if ( v18 == -1 )
//              v18 = sub_1101A90();
//            v19 = (MaterialInterface )sub_1110DD0(v17, v18, 0, 0, 0, 0, 0, dword_20186F4, 0, 0);
//            (*(void (__thiscall **)(MaterialInterface , MaterialInterface ))(v19.VfTableObject.Dummy + 356))(v19, this.Mesh1pLowerBody.SkeletalMesh.Materials[v16]);
//            (*(void (__thiscall **)(MaterialInterface , int, int, _DWORD))(v19.VfTableObject.Dummy + 372))(v19, dword_2056844, dword_2056848, *(_DWORD *)(v2 + 128));
//            sub_D36AF0(this.Mesh1pLowerBody, v16++, v19);
//          }
//          while ( v16 < this.Mesh1pLowerBody.SkeletalMesh.Materials.Count );
//        }
//      }
//    }
//    result = (int)this.Mesh1p;
//    if(result != default)
//    {
//      result = *(_DWORD *)(result + 456);
//      if(result != default)
//      {
//        v21 = default;
//        if ( *(int *)(result + 92) > 0 )
//        {
//          do
//          {
//            if ( default == dword_1FFD744 )
//            {
//              dword_1FFD744 = (int)sub_E58D70((int)L"Engine");
//              sub_E525E0();
//            }
//            v22 = dword_1FFD744;
//            v23 = sub_1101A90();
//            if ( v23 == -1 )
//              v23 = sub_1101A90();
//            v24 = (MaterialInterface )sub_1110DD0(v22, v23, 0, 0, 0, 0, 0, dword_20186F4, 0, 0);
//            (*(void (__thiscall **)(MaterialInterface , MaterialInterface ))(v24.VfTableObject.Dummy + 356))(v24, this.Mesh1p.SkeletalMesh.Materials[v21]);
//            (*(void (__thiscall **)(MaterialInterface , int, int, _DWORD))(v24.VfTableObject.Dummy + 372))(v24, dword_2056844, dword_2056848, *(_DWORD *)(v2 + 128));
//            sub_D36AF0(this.Mesh1p, v21, v24);
//            result = (int)this.Mesh1p;
//            ++v21;
//          }
//          while ( v21 < *(_DWORD *)(*(_DWORD *)(result + 456) + 92) );
//        }
//      }
//    }
//    return (int)(result);
//  }
//
  public unsafe void DoFootPlacement_Maybe(float a2)
  {
    float v3 = default; // xmm0_4
    float v4 = default; // xmm0_4
    EMovement v5 = default; // cl
    float v6 = default; // eax
    Vector *v7; // eax
    float v8 = default; // edx
    short v9 = default; // cx
    int v10 = default; // eax
    uint v11 = default; // edx
    int v12 = default; // ebx
    uint v13 = default; // edx
    int v14 = default; // edi
    double v15 = default; // st7
    float v16 = default; // xmm0_4
    float v17 = default; // xmm1_4
    float v18 = default; // xmm0_4
    float v19 = default; // xmm0_4
    int v20 = default; // edx
    float v21 = default; // xmm0_4
    int v22 = default; // ecx
    uint v23 = default; // eax
    uint v24 = default; // edx
    int v25 = default; // eax
    int v26 = default; // eax
    float v27 = default; // [esp+Ch] [ebp-28h]
    Vector v28 = default; // [esp+10h] [ebp-24h] BYREF
    Vector v29 = default; // [esp+1Ch] [ebp-18h] BYREF
    Vector a2a = default; // [esp+28h] [ebp-Ch] BYREF
  
    v3 = this.LegRotationSlowTimer;
    if ( v3 > 0.0f )
    {
      v4 = v3 - a2;
      if ( v4 <= 0.0f )
        v4 = 0.0f;
      this.LegRotationSlowTimer = v4;
    }
    v5 = this.MovementState;
    if ( v5 != MOVE_BotStartWalking && v5 != MOVE_BotStartRunning && sqrt(this.Velocity.Y * this.Velocity.Y + this.Velocity.X * this.Velocity.X) > 20.0f || (this.Moves[v5].bDebugMove.AsBitfield(29) & 0x20000) != 0 )
    {
      v6 = this.Velocity.X;
      v28.Y = this.Velocity.Y;
      v28.X = v6;
      v28.Z = 0.0f;
      v28.SafeNormal(0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/);
      if ( this.Physics == PHYS_Falling )
      {
        v7 = this.Rotation.Vector(&a2a);
        v8 = v7->Y;
        v29.X = v7->X;
        v29.Y = v8;
        v29.Z = 0.0f;
        v29.SafeNormal(0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/);
        v28 = v29;
      }
      v9 = E_GetHeadingAngle(&v28);
      v10 = (ushort)(v9 - LOWORD(this.Rotation.Yaw));
      if ( (uint)v10 > 0x7FFF )
        v10 = v10 - (0x10000);
      v11 = this.bDisableSkelControlSpring.AsBitfield(32);
      if ( ((v11 >> 3) & 1) != 0 && (((v12 = this.LegAngleLimitFudge) is object && v10 > v12 + this.GoBackLegAngleLimitMax) || v10 < this.GoBackLegAngleLimitMin - v12) )
      {
        v13 = v11 & 0xFFFFFFF7;
      }
      else
      {
        if ( ((this.bDisableSkelControlSpring.AsBitfield(32) >> 3) & 1) != 0 )
          goto LABEL_22;
        v14 = this.LegAngleLimitFudge;
        if ( v10 >= this.GoBackLegAngleLimitMax - v14 || v10 <= v14 + this.GoBackLegAngleLimitMin )
          goto LABEL_22;
        v13 = v11 | 8;
      }
      SetFromBitfield(ref this.bDisableSkelControlSpring, 32, v13);
      this.LegRotationSlowTimer = 0.40000001d;
  LABEL_22:
      if ( (this.bDisableSkelControlSpring.AsBitfield(32) & 8) == 0 )
        v9 = (short)(v9 + (0x8000));
      v15 = sqrt(this.Velocity.Y * this.Velocity.Y + this.Velocity.X * this.Velocity.X) * 0.0049999999d;
      if ( v15 < 0.1f )
      {
        v16 = 0.1f;
      }
      else
      {
        v16 = (float)v15;
        v27 = (float)v15;
        if ( v27 > 1.0f )
          v16 = 1.0f;
      }
      v17 = v16 * a2;
      if ( this.LegRotationSlowTimer <= 0.0f )
        v18 = 1.0f;
      else
        v18 = (float)(0.40000001d);
      v19 = v18 * v17;
      if ( this.MovementState == MOVE_Crouch )
        v19 = v19 * 0.5f;
      if ( this.Physics == PHYS_Falling )
        v19 = v19 * 0.25f;
      v20 = this.LegRotation;
      v21 = v19 * 8.0f;
      v22 = (ushort)(v9 - v20);
      if ( v22 > 0x7FFF )
        v22 = v22 - (0x10000);
      if ( v21 >= 1.0f )
        v21 = 1.0f;
      v23 = (ushort)(v20 + (int)(float)((float)v22 * v21));
      if ( v23 > 0x7FFF )
        v23 = v23 - (0x10000);
      this.LegRotation = v23;
    }
    v24 = this.Rotation.Yaw;
    v25 = (ushort)(this.LegRotation - v24);
    if ( (uint)v25 > 0x7FFF )
      v25 = v25 - (0x10000);
    if ( v25 < this.GoBackLegAngleLimitMin )
      v25 = this.GoBackLegAngleLimitMin;
    if ( v25 > this.GoBackLegAngleLimitMax )
      v25 = this.GoBackLegAngleLimitMax;
    v26 = (ushort)(v24 + v25);
    if ( v26 > 0x7FFF )
      v26 = v26 - (0x10000);
    this.LegRotation = v26;
  }

  public unsafe void physWallRunning(float a2, int a3)
  {
    Vector *v4; // edi
    double v5 = default; // st7
    int v6 = default; // edi
    int v7 = default; // eax
    // void (__thiscall *v8)(TdPawn , int, _DWORD, _DWORD, _DWORD, int); // edx
    float v9 = default; // xmm2_4
    float v10 = default; // xmm1_4
    float v11 = default; // xmm3_4
    float v12 = default; // xmm2_4
    float v13 = default; // xmm1_4
    float v14 = default; // ecx
    float v15 = default; // edx
    float v16 = default; // xmm2_4
    float v17 = default; // ecx
    float v18 = default; // edx
    float v19 = default; // xmm1_4
    float v20 = default; // eax
    float v21 = default; // xmm0_4
    float v22 = default; // eax
    float v23 = default; // ecx
    float v24 = default; // edx
    float v25 = default; // xmm0_4
    float v26 = default; // xmm0_4
    float v27 = default; // xmm0_4
    float v28 = default; // xmm4_4
    bool v29 = default; // cc
    float v30 = default; // xmm0_4
    float v31 = default; // xmm1_4
    float v32 = default; // xmm0_4
    float v33 = default; // xmm3_4
    float v34 = default; // xmm2_4
    float v35 = default; // xmm1_4
    float v36 = default; // xmm1_4
    float v37 = default; // xmm0_4
    float v38 = default; // edx
    float v39 = default; // eax
    float v40 = default; // xmm1_4
    float v41 = default; // xmm0_4
    float v42 = default; // xmm3_4
    float v43 = default; // ecx
    float v44 = default; // edx
    float v45 = default; // xmm0_4
    float v46 = default; // xmm5_4
    float v47 = default; // xmm6_4
    float v48 = default; // xmm3_4
    float v49 = default; // xmm0_4
    float v50 = default; // xmm2_4
    float v51 = default; // xmm1_4
    float v52 = default; // xmm4_4
    Vector *v53; // eax
    float v54 = default; // xmm0_4
    float v55 = default; // xmm3_4
    float v56 = default; // xmm0_4
    float v57 = default; // xmm1_4
    float v58 = default; // xmm2_4
    float v59 = default; // xmm3_4
    float v60 = default; // edx
    float v61 = default; // eax
    bool v62 = default; // zf
    float v63 = default; // xmm1_4
    float v64 = default; // xmm0_4
    float v65 = default; // xmm3_4
    float v66 = default; // ecx
    float v67 = default; // edx
    float v68 = default; // xmm0_4
    float v69 = default; // xmm6_4
    float v70 = default; // xmm3_4
    float v71 = default; // xmm1_4
    float v72 = default; // xmm5_4
    float v73 = default; // xmm2_4
    float v74 = default; // xmm4_4
    Vector *v75; // eax
    float v76 = default; // xmm0_4
    float v77 = default; // xmm3_4
    float v78 = default; // xmm0_4
    int v79 = default; // ecx
    double v80 = default; // st7
    int v81 = default; // edx
    uint v82 = default; // eax
    float v83 = default; // xmm0_4
    float v84 = default; // xmm2_4
    float v85 = default; // xmm6_4
    float v86 = default; // xmm5_4
    float v87 = default; // xmm4_4
    float v88 = default; // ecx
    float v89 = default; // edx
    float v90 = default; // [esp+1Ch] [ebp-1F4h]
    float v91 = default; // [esp+20h] [ebp-1F0h]
    float v92 = default; // [esp+38h] [ebp-1D8h]
    float v93 = default; // [esp+38h] [ebp-1D8h]
    Vector Delta = default; // [esp+3Ch] [ebp-1D4h] BYREF
    float v95 = default; // [esp+48h] [ebp-1C8h] BYREF
    float v96 = default; // [esp+4Ch] [ebp-1C4h]
    float v97 = default; // [esp+50h] [ebp-1C0h]
    Vector v98 = default; // [esp+54h] [ebp-1BCh] BYREF
    Vector v99 = default; // [esp+60h] [ebp-1B0h] BYREF
    Vector v100 = default; // [esp+6Ch] [ebp-1A4h]
    float v101 = default; // [esp+78h] [ebp-198h]
    float v102 = default; // [esp+7Ch] [ebp-194h]
    int v103 = default; // [esp+80h] [ebp-190h]
    float v104 = default; // [esp+84h] [ebp-18Ch]
    float v105 = default; // [esp+88h] [ebp-188h]
    float v106 = default; // [esp+8Ch] [ebp-184h]
    float v107 = default; // [esp+90h] [ebp-180h]
    float v108 = default; // [esp+94h] [ebp-17Ch]
    float v109 = default; // [esp+98h] [ebp-178h]
    float v110 = default; // [esp+9Ch] [ebp-174h]
    float v111 = default; // [esp+A0h] [ebp-170h]
    Vector v112 = default; // [esp+A4h] [ebp-16Ch] BYREF
    CheckResult Hit = default; // [esp+B0h] [ebp-160h] BYREF
    int v114 = default; // [esp+F8h] [ebp-118h]
    Vector v115 = default; // [esp+FCh] [ebp-114h] BYREF
    Vector v116 = default; // [esp+108h] [ebp-108h] BYREF
    Vector v117 = default; // [esp+114h] [ebp-FCh] BYREF
    Vector a4 = default; // [esp+120h] [ebp-F0h] BYREF
    float v119 = default; // [esp+12Ch] [ebp-E4h]
    float v120 = default; // [esp+130h] [ebp-E0h]
    float v121 = default; // [esp+134h] [ebp-DCh]
    float v122 = default; // [esp+138h] [ebp-D8h]
    float v123 = default; // [esp+13Ch] [ebp-D4h]
    float v124 = default; // [esp+140h] [ebp-D0h]
    Vector a7 = default; // [esp+144h] [ebp-CCh] BYREF
    int v126 = default; // [esp+150h] [ebp-C0h]
    int v127 = default; // [esp+154h] [ebp-BCh]
    Vector a5 = default; // [esp+158h] [ebp-B8h] BYREF
    Vector v129 = default; // [esp+164h] [ebp-ACh] BYREF
    Vector v130 = default; // [esp+170h] [ebp-A0h] BYREF
    Vector v131 = default; // [esp+17Ch] [ebp-94h] BYREF
    Vector v132 = default; // [esp+188h] [ebp-88h] BYREF
    float v133 = default; // [esp+194h] [ebp-7Ch]
    float v134 = default; // [esp+1A4h] [ebp-6Ch]
    Vector v135 = default; // [esp+1B4h] [ebp-5Ch] BYREF
    float v136 = default; // [esp+1C4h] [ebp-4Ch]
    int v137 = default; // [esp+1D4h] [ebp-3Ch]
    float v138 = default; // [esp+1E4h] [ebp-2Ch]
    float v139 = default; // [esp+1F4h] [ebp-1Ch]
    Vector a2a = default; // [esp+204h] [ebp-Ch] BYREF
  
    if ( default == this.Controller && (this.bIsFemale.AsBitfield(20) & 0x8000) == 0 )
      return;
fixed(var ptr1 =&this.Floor)
    v4 =  ptr1;
    v92 = atan2(this.Floor.Y, this.Floor.X) * 10430.222f;
    v5 = this.Floor.X;
    v127 = (int)v92;
    if ( fabs(v5) >= 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ || fabs(this.Floor.Y) >= 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ || fabs(this.Floor.Z) >= 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
    {
      v9 = this.Acceleration.Y;
      v10 = this.Acceleration.Z;
      v108 = this.Moves[this.MovementState].FrictionModifier;
      v11 = v9 * v9;
      v12 = v10 * v10;
      v13 = 0.0f;
      v133 = (float)((float)(this.Acceleration.X * this.Acceleration.X) + v11) + v12;
      if ( v133 == 1.0f )
      {
        v14 = this.Acceleration.Y;
        v15 = this.Acceleration.Z;
        v95 = this.Acceleration.X;
        v96 = v14;
        v97 = v15;
      }
      else
      {
        if ( v133 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
        {
          v134 = 3.0f;
          v16 = 1.0f / fsqrt(v133);
          v135.X = (float)(3.0f - (float)((float)(v16 * v133) * v16)) * (float)(v16 * 0.5f);
          v95 = this.Acceleration.X * v135.X;
          v96 = this.Acceleration.Y * v135.X;
          v13 = this.Acceleration.Z * v135.X;
        }
        else
        {
          v95 = 0.0f;
          v96 = 0.0f;
        }
        v97 = v13;
      }
      this.CalcVelocity( &v95, LODWORD(a2), this.GroundSpeed * 4.0f, COERCE_FLOAT(LODWORD(v108)), 0, 0, 0);// CalcVelocity
      v17 = this.Velocity.Y;
      v18 = this.Velocity.Z;
      v19 = a2;
      ++a3;
      SetFromBitfield(ref this.bCollideComplex, 20, this.bCollideComplex.AsBitfield(20) & (0xFFFFFEFF));
      Hit.Item = -1;
      Hit.LevelIndex = -1;
      v20 = this.Velocity.X;
      Hit.Time = 1.0f;
      v21 = this.MaxStepHeight;
      v105 = v20;
      v22 = this.Location.X;
      v106 = v17;
      v23 = this.Location.Y;
      v107 = v18;
      v24 = this.Location.Z;
      Hit.Next = default;
      Hit.Actor = default;
      Hit.Location.X = 0.0f;
      Hit.Location.Y = 0.0f;
      Hit.Location.Z = 0.0f;
      Hit.Normal.X = 0.0f;
      Hit.Normal.Y = 0.0f;
      Hit.Normal.Z = 0.0f;
      Hit.Material = default;
      Hit.PhysMaterial = default;
      Hit.Component = default;
      Hit.BoneName = default;
      Hit.Level = default;
      Hit.bStartPenetrating = default;
      v114 = default;
      v109 = v22;
      v110 = v23;
      v111 = v24;
      v93 = a2;
      v108 = v21 * v21;
      if ( a2 <= 0.0f )
      {
  LABEL_64:
        if ( this.Physics == PHYS_WallRunning )
        {
          v79 = this.Rotation.Yaw;
          v80 = atan2(this.Floor.Y, v4->X);
          v81 = this.Rotation.Roll;
          v99.X.LODWORD(this.Rotation.Pitch);
          v99.Y.LODWORD(v79);
          v99.Z.LODWORD(v81);
          v104 = v80 * 10430.222f;
          v82 = (ushort)((int)v104 - v127);
          if ( v82 > 0x7FFF )
            v82 = v82 - (0x10000);
          v99.Y.LODWORD(LODWORD(v99.Y) + (v82));
          v117.X = 0.0f;
          v117.Y = 0.0f;
          v117.Z = 0.0f;
          GWorld.MoveActor(this, &v117, (Rotator *)&v99, 0, &Hit);
          v83 = (float)(this.Location.Y - v110) * (float)(1.0f / a2);
          v84 = (float)(1.0f / a2) * (float)(this.Location.X - v109);
          v85 = this.Velocity.X;
          v86 = this.Velocity.Y * this.Velocity.Y;
          v87 = this.Velocity.Z * this.Velocity.Z;
          v111 = (float)(this.Location.Z - v111) * (float)(1.0f / a2);
          v110 = v83;
          v109 = v84;
          if ( (float)((float)((float)(v85 * v85) + v86) + v87) > (float)((float)((float)(v111 * v111) + (float)(v83 * v83)) + (float)(v84 * v84)) && (this.bCollideComplex.AsBitfield(20) & 0x100) == 0 && this.Physics == PHYS_WallRunning )
          {
            v88 = v110;
            v89 = v111;
            this.Velocity.X = v109;
            this.Velocity.Y = v88;
            this.Velocity.Z = v89;
          }
        }
        return;
      }
      while(1 != default)
      {
        if ( a3 >= 8 )
          goto LABEL_64;
        ++a3;
        if ( v19 <= 0.050000001d )
          break;
        if ( this.IsHumanControlled() )
        {
          v19 = v93;
        }
        else
        {
          v25 = this.CylinderComponent.CollisionRadius * this.CylinderComponent.CollisionRadius;
          if ( v108 < v25 )
            v25 = v108;
          v19 = v93;
          if ( (float)((float)((float)((float)((float)(v105 * v105) + (float)(v107 * v107)) + (float)(v106 * v106)) * v93) * v93) <= v25 )
            break;
        }
        v26 = v19 * 0.5f;
        if ( (float)(v19 * 0.5f) >= 0.050000001d )
          v26 = (float)(0.050000001d);
  LABEL_23:
        v93 = v19 - v26;
        Delta.X = v105 * v26;
        Delta.Y = v106 * v26;
        Delta.Z = v107 * v26;
fixed(var ptr2 =&this.Rotation)
        GWorld.MoveActor(this, &Delta,  ptr2, 0, &Hit);
        v27 = Hit.Time;
        if ( Hit.Time >= 1.0f )
          goto LABEL_39;
        if ( (this.bDisableSkelControlSpring.AsBitfield(32) & 0x400) != 0 )
        {
          a5.X = Delta.X * (float)(1.0f - Hit.Time);
          a5.Y = Delta.Y * (float)(1.0f - Hit.Time);
          a5.Z = Delta.Z * (float)(1.0f - Hit.Time);
fixed(var ptr3 =&this.Floor)
          this.UNKNOWN31( ptr3, &Delta, &a5, &Hit);
  LABEL_39:
          v28 = 0.0f;
          goto LABEL_40;
        }
        v28 = 0.0f;
        v112.Z = this.MaxWallStepHeight;
        v29 = Hit.Normal.Z <= this.WalkableFloorZ;
        v100 = Hit.Normal;
        v112.X = 0.0f;
        v112.Y = 0.0f;
        if ( default == v29 )
        {
          v130.X = (float)(1.0f - Hit.Time) * Delta.X;
          v130.Y = Delta.Y * (float)(1.0f - Hit.Time);
          v130.Z = Delta.Z * (float)(1.0f - Hit.Time);
fixed(var ptr4 =&this.Rotation)
          GWorld.MoveActor(this, &v112,  ptr4, 0, &Hit);
fixed(var ptr5 =&this.Rotation)
          GWorld.MoveActor(this, &v130,  ptr5, 0, &Hit);
          if ( this.WalkableFloorZ > Hit.Normal.Z && Hit.Time < 1.0f )
            v100 = Hit.Normal;
          v131.X = -0.0f - v112.X;
          v131.Y = -0.0f - v112.Y;
          v131.Z = -0.0f - v112.Z;
fixed(var ptr6 =&this.Rotation)
          GWorld.MoveActor(this, &v131,  ptr6, 0, &Hit);
          v27 = Hit.Time;
          v28 = 0.0f;
        }
        if ( this.WalkableFloorZ > v100.Z )
        {
          v132.X = Delta.X * (float)(1.0f - v27);
          v132.Y = Delta.Y * (float)(1.0f - v27);
          v132.Z = Delta.Z * (float)(1.0f - v27);
fixed(var ptr7 =&this.Rotation)
          GWorld.MoveActor(this, &v112,  ptr7, 0, &Hit);
fixed(var ptr8 =&this.Rotation)
          GWorld.MoveActor(this, &v132,  ptr8, 0, &Hit);
          if ( this.WalkableFloorZ > Hit.Normal.Z && Hit.Time < 1.0f )
          {
            v30 = (float)((float)(this.Velocity.Y * Hit.Normal.Y) + (float)(this.Velocity.Z * Hit.Normal.Z)) + (float)(this.Velocity.X * Hit.Normal.X);
            v31 = Hit.Normal.Y * v30;
            v32 = v30 * Hit.Normal.Z;
            v33 = this.Velocity.X - (float)((float)((float)((float)(this.Velocity.Y * Hit.Normal.Y) + (float)(this.Velocity.Z * Hit.Normal.Z)) + (float)(this.Velocity.X * Hit.Normal.X)) * Hit.Normal.X);
            v34 = this.Velocity.Y - v31;
            v35 = this.Velocity.Z;
            SetFromBitfield(ref this.bDisableSkelControlSpring, 32, this.bDisableSkelControlSpring.AsBitfield(32) | (0x400u));
            v119 = v33;
            v36 = v35 - v32;
            v37 = this.Velocity.Z;
            this.Velocity.X = v33;
            v120 = v34;
            this.Velocity.Y = v34;
            this.Velocity.Z = v37;
            v38 = this.Velocity.Y;
            v39 = this.Velocity.Z;
            v105 = this.Velocity.X;
            v121 = v36;
            v106 = v38;
            v107 = v39;
            E_CallReachedWall(this);
            SetFromBitfield(ref this.bCollideComplex, 20, this.bCollideComplex.AsBitfield(20) | (0x100u));
          }
          v129.X = -0.0f - v112.X;
          v129.Y = -0.0f - v112.Y;
          v129.Z = -0.0f - v112.Z;
fixed(var ptr9 =&this.Rotation)
          GWorld.MoveActor(this, &v129,  ptr9, 0, &Hit);
          goto LABEL_39;
        }
  LABEL_40:
        if ( (this.bDisableSkelControlSpring.AsBitfield(32) & 0x400) != 0 )
        {
          v40 = this.Velocity.Y;
          v41 = this.Velocity.X;
          v42 = (float)(v41 * v41) + (float)(v40 * v40);
          v136 = v42;
          if ( v42 == 1.0f )
          {
            if ( this.Velocity.Z == 0.0f )
            {
              v43 = this.Velocity.Y;
              v44 = this.Velocity.Z;
              v122 = this.Velocity.X;
              v41 = v122;
              v123 = v43;
              v40 = v43;
              v124 = v44;
              v28 = v44;
            }
          }
          else if ( v42 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
          {
            v139 = 3.0f;
            v126 = 1056964608;
            v45 = fsqrt(v136);
            v133 = (float)(3.0f - (float)((float)((float)(1.0f / v45) * v136) * (float)(1.0f / v45))) * (float)((float)(1.0f / v45) * 0.5f);
            v41 = v133 * this.Velocity.X;
            v40 = this.Velocity.Y * v133;
          }
          else
          {
            v41 = 0.0f;
            v40 = 0.0f;
          }
          v46 = this.Floor.Y;
          v47 = this.Floor.Z;
          v48 = (float)(v41 * 35.0f) + this.Location.X;
          v49 = this.Location.Y + (float)(v40 * 35.0f);
          v50 = this.MaxWallStepHeight + 2.0f;
          v51 = this.Location.Z + (float)(v28 * 35.0f);
          v52 = v4->X;
          v116.X = v48;
          v116.Y = v49;
          v116.Z = v51;
          a4.X = v48 - (float)(v52 * v50);
          a4.Y = v49 - (float)(v46 * v50);
          a4.Z = v51 - (float)(v47 * v50);
          v53 = this.GetCylinderExtent(&a2a);
          v54 = v53->Z;
          v55 = v53->X;
          a7.Y = v53->Y * 0.25f;
          a7.Z = v54 * 0.25f;
          v56 = (float)(v54 * 0.25f) * 0.75f;
          v116.Z = v116.Z - v56;
          a7.X = v55 * 0.25f;
          a4.Z = a4.Z - v56;
          GWorld.SingleLineCheck(&Hit, this, &a4, &v116, 8415, &a7, 0);
          if ( Hit.Time >= 1.0f )
          {
            if ( this.Physics == PHYS_WallRunning )
            {
              v98.X = 0.0f;
              v98.Y = 0.0f;
  LABEL_73:
              v90 = v98.X;
              v98.Z = 1.0f;
              v91 = v98.Y;
  LABEL_74:
              this.setPhysics( 2, 0, COERCE_FLOAT(LODWORD(v90)), COERCE_FLOAT(LODWORD(v91)), 1065353216);// setPhysics
              this.FallingOffWall();
              goto LABEL_8;
            }
          }
          else
          {
            if ( (float)((float)((float)(this.Floor.Y * Hit.Normal.Y) + (float)(this.Floor.Z * Hit.Normal.Z)) + (float)(this.Floor.X * Hit.Normal.X)) < 0.95999998d
              && (float)((float)((float)(Hit.Normal.Y * Delta.Y) + (float)(Delta.Z * Hit.Normal.Z)) + (float)(Hit.Normal.X * Delta.X)) > 0.0f )
            {
              v98.X = 0.0f;
              v98.Y = 0.0f;
              goto LABEL_73;
            }
            v57 = this.Floor.Y;
            v58 = this.Floor.Z;
            v59 = this.MaxWallStepHeight + 2.0f;
            v117.X = (float)(v4->X * -1.0f) * v59;
            v117.Y = (float)(v57 * -1.0f) * v59;
            v117.Z = (float)(v58 * -1.0f) * v59;
fixed(var ptr10 =&this.Rotation)
            GWorld.MoveActor(this, &v117,  ptr10, 0, &Hit);
            v60 = Hit.Normal.Y;
            v61 = Hit.Normal.Z;
            v4->X = Hit.Normal.X;
            v62 = Hit.Actor == this.Base;
            this.Floor.Y = v60;
            this.Floor.Z = v61;
            if ( default == v62 )
              this.SetBase(
                Hit.Actor,
                Hit.Normal,
                1,
                0,
                0,
                0);
          }
        }
        else if ( this.Moves[this.MovementState].MoveActiveTime > 0.2f )
        {
          v63 = this.Velocity.Y;
          v64 = this.Velocity.X;
          v65 = (float)(v64 * v64) + (float)(v63 * v63);
          v138 = v65;
          if ( v65 == 1.0f )
          {
            if ( this.Velocity.Z == 0.0f )
            {
              v66 = this.Velocity.Y;
              v67 = this.Velocity.Z;
              v101 = this.Velocity.X;
              v64 = v101;
              v102 = v66;
              v63 = v66;
              v103 = LODWORD(v67);
              v28 = v67;
            }
          }
          else if ( v65 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
          {
            v137 = 1077936128;
            v104 = 0.5f;
            v68 = fsqrt(v138);
            v134 = (float)(3.0f - (float)((float)((float)(1.0f / v68) * v138) * (float)(1.0f / v68))) * (float)((float)(1.0f / v68) * 0.5f);
            v64 = v134 * this.Velocity.X;
            v63 = this.Velocity.Y * v134;
          }
          else
          {
            v64 = 0.0f;
            v63 = 0.0f;
          }
          v69 = this.Floor.Z;
          v70 = this.MaxWallStepHeight + 2.0f;
          v71 = this.Location.Y + (float)(v63 * 35.0f);
          v72 = this.Floor.Y;
          v73 = this.Location.Z + (float)(v28 * 35.0f);
          v74 = v4->X;
          v115.X = this.Location.X + (float)(v64 * 35.0f);
          v115.Y = v71;
          v115.Z = v73;
          v99.X = v115.X - (float)(v74 * v70);
          v99.Y = v71 - (float)(v72 * v70);
          v99.Z = v73 - (float)(v69 * v70);
          v75 = this.GetCylinderExtent(&v135);
          v76 = v75->Z;
          v77 = v75->X;
          v98.Y = v75->Y * 0.25f;
          v98.Z = v76 * 0.25f;
          v78 = (float)(v76 * 0.25f) * 0.75f;
          v115.Z = v115.Z - v78;
          v98.X = v77 * 0.25f;
          v99.Z = v99.Z - v78;
          GWorld.SingleLineCheck(&Hit, this, &v99, &v115, 8415, &v98, 0);
          if ( Hit.Time >= 1.0f && this.Physics == PHYS_WallRunning )
          {
            v101 = 0.0f;
            v90 = 0.0f;
            v102 = 0.0f;
            v103 = 1065353216;
            v91 = 0.0f;
            goto LABEL_74;
          }
        }
        v19 = v93;
        if ( v93 <= 0.0f )
          goto LABEL_64;
      }
      v26 = v19;
      goto LABEL_23;
    }
    v6 = this.VfTableObject.Dummy;
    CallUFunction(this.FallingOffWall, this, v7, 0, 0);
    if ( this.Physics == PHYS_WallRunning )
    {
      // v8 = *(void (__thiscall **)(TdPawn , int, _DWORD, _DWORD, _DWORD, int))(this.VfTableObject.Dummy + 480);
      v100.X = 0.0f;
      v100.Y = 0.0f;
      v100.Z = 1.0f;
      this.setPhysics( 2, 0, 0, 0, 1065353216);
    }
  LABEL_8:
    this.startNewPhysics( LODWORD(a2), a3);// startNewPhysics
  }

  public unsafe void physWallClimbing(float a2, int a3)
  {
    int v4 = default; // edi
    int v5 = default; // eax
    // void (__thiscall *v6)(TdPawn , int, _DWORD, _DWORD, _DWORD, int); // edx
    float v7 = default; // xmm0_4
    float v8 = default; // ecx
    float v9 = default; // edx
    float v10 = default; // xmm2_4
    float v11 = default; // edx
    float v12 = default; // eax
    float v13 = default; // xmm0_4
    int v14 = default; // ecx
    double v15 = default; // st7
    float v16 = default; // eax
    float v17 = default; // ecx
    float v18 = default; // edx
    float v19 = default; // xmm1_4
    float v20 = default; // xmm0_4
    Vector *v21; // ebx
    float v22 = default; // ecx
    float v23 = default; // edx
    float v24 = default; // eax
    int v25 = default; // edi
    float v26 = default; // xmm0_4
    float v27 = default; // xmm0_4
    float v28 = default; // xmm3_4
    float v29 = default; // xmm1_4
    float v30 = default; // xmm2_4
    float v31 = default; // xmm0_4
    float v32 = default; // xmm2_4
    float v33 = default; // xmm0_4
    float v34 = default; // xmm5_4
    float v35 = default; // xmm2_4
    float v36 = default; // xmm4_4
    float v37 = default; // xmm0_4
    float v38 = default; // xmm7_4
    float v39 = default; // xmm1_4
    float v40 = default; // xmm0_4
    float v41 = default; // xmm2_4
    float v42 = default; // xmm2_4
    int v43 = default; // edi
    int v44 = default; // eax
    float v45 = default; // xmm0_4
    float v46 = default; // xmm2_4
    float v47 = default; // xmm3_4
    Vector *v48; // eax
    float v49 = default; // xmm1_4
    float v50 = default; // xmm2_4
    float v51 = default; // xmm3_4
    float v52 = default; // eax
    float v53 = default; // ecx
    bool v54 = default; // zf
    float v55 = default; // xmm4_4
    float v56 = default; // xmm1_4
    float v57 = default; // xmm2_4
    float v58 = default; // [esp+1Ch] [ebp-17Ch]
    float Delta = default; // [esp+48h] [ebp-150h]
    float Delta_4 = default; // [esp+4Ch] [ebp-14Ch]
    float Delta_8 = default; // [esp+50h] [ebp-148h]
    float Delta_8a = default; // [esp+50h] [ebp-148h]
    float Delta_8b = default; // [esp+50h] [ebp-148h]
    float v64 = default; // [esp+54h] [ebp-144h]
    float v65 = default; // [esp+58h] [ebp-140h] BYREF
    float v66 = default; // [esp+5Ch] [ebp-13Ch]
    float v67 = default; // [esp+60h] [ebp-138h]
    Vector v68 = default; // [esp+64h] [ebp-134h] BYREF
    float v69 = default; // [esp+70h] [ebp-128h]
    float v70 = default; // [esp+74h] [ebp-124h]
    float v71 = default; // [esp+78h] [ebp-120h]
    float v72 = default; // [esp+7Ch] [ebp-11Ch]
    float v73 = default; // [esp+80h] [ebp-118h]
    float v74 = default; // [esp+84h] [ebp-114h]
    Vector a4 = default; // [esp+88h] [ebp-110h] BYREF
    CheckResult Hit = default; // [esp+98h] [ebp-100h] BYREF
    int v77 = default; // [esp+E0h] [ebp-B8h]
    float v78 = default; // [esp+E4h] [ebp-B4h]
    float v79 = default; // [esp+E8h] [ebp-B0h]
    float v80 = default; // [esp+ECh] [ebp-ACh]
    int v81 = default; // [esp+F0h] [ebp-A8h]
    float v82 = default; // [esp+F4h] [ebp-A4h]
    float v83 = default; // [esp+F8h] [ebp-A0h]
    int v84 = default; // [esp+FCh] [ebp-9Ch]
    float v85 = default; // [esp+100h] [ebp-98h]
    float v86 = default; // [esp+104h] [ebp-94h]
    float v87 = default; // [esp+108h] [ebp-90h]
    float v88 = default; // [esp+10Ch] [ebp-8Ch]
    int* v89 = stackalloc int[3]; // [esp+110h] [ebp-88h] BYREF
    Vector v90 = default; // [esp+11Ch] [ebp-7Ch] BYREF
    float v91 = default; // [esp+128h] [ebp-70h]
    Vector a2a = default; // [esp+138h] [ebp-60h] BYREF
    float v93 = default; // [esp+148h] [ebp-50h]
    int v94 = default; // [esp+158h] [ebp-40h]
    float v95 = default; // [esp+168h] [ebp-30h]
    float v96 = default; // [esp+178h] [ebp-20h]
    int v97 = default; // [esp+188h] [ebp-10h]
  
    if ( this.Controller || (this.bIsFemale.AsBitfield(20) & 0x8000) != 0 )
    {
      if ( fabs(this.Floor.X) < 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ && fabs(this.Floor.Y) < 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ && fabs(this.Floor.Z) < 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ || this.Velocity.Z < 0.0f )
      {
        v4 = this.VfTableObject.Dummy;
        CallUFunction(this.FallingOffWall, this, v5, 0, 0);
        if ( this.Physics == PHYS_WallClimbing )
        {
          // v6 = *(void (__thiscall **)(TdPawn , int, _DWORD, _DWORD, _DWORD, int))(this.VfTableObject.Dummy + 480);
          v69 = 0.0f;
          v70 = 0.0f;
          v71 = 1.0f;
          this.setPhysics( 2, 0, 0, 0, 1065353216);
        }
        this.startNewPhysics( LODWORD(a2), a3);// startNewPhysics
      }
      else
      {
        v7 = (float)((float)(this.Acceleration.X * this.Acceleration.X) + (float)(this.Acceleration.Y * this.Acceleration.Y)) + (float)(this.Acceleration.Z * this.Acceleration.Z);
        a4.X = v7;
        if ( v7 == 1.0f )
        {
          v8 = this.Acceleration.Y;
          v9 = this.Acceleration.Z;
          v65 = this.Acceleration.X;
          v66 = v8;
          v67 = v9;
        }
        else if ( v7 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
        {
          v91 = 3.0f;
          v10 = 1.0f / fsqrt(a4.X);
          a2a.X = (float)(3.0f - (float)((float)(v10 * a4.X) * v10)) * (float)(v10 * 0.5f);
          v65 = this.Acceleration.X * a2a.X;
          v66 = this.Acceleration.Y * a2a.X;
          v67 = this.Acceleration.Z * a2a.X;
        }
        else
        {
          v65 = 0.0f;
          v66 = 0.0f;
          v67 = 0.0f;
        }
        v11 = this.Velocity.Z;
        v12 = this.Velocity.X;
        v13 = this.GroundSpeed * 4.0f;
        v70 = this.Velocity.Y;
        v14 = this.MovementState;
        v71 = v11;
        v15 = this.Moves[v14].FrictionModifier;
        v69 = v12;
        v58 = (float)v15;
        this.CalcVelocity( &v65, LODWORD(a2), LODWORD(v13), LODWORD(v58), 0, 0, 0);// CalcVelocity
        v16 = this.Velocity.Z;
        v17 = this.Velocity.X;
        v18 = this.Velocity.Y;
        v19 = a2;
        SetFromBitfield(ref this.bCollideComplex, 20, this.bCollideComplex.AsBitfield(20) & (0xFFFFFEFF));
        v20 = this.MaxStepHeight;
        v74 = v16;
fixed(var ptr1 =&this.Location)
        v21 =  ptr1;
        v72 = v17;
        v22 = this.Location.X;
        v73 = v18;
        v23 = this.Location.Y;
        Hit.Item = -1;
        Hit.LevelIndex = -1;
        v24 = this.Location.Z;
        Hit.Next = default;
        Hit.Actor = default;
        Hit.Location.X = 0.0f;
        Hit.Location.Y = 0.0f;
        Hit.Location.Z = 0.0f;
        Hit.Normal.X = 0.0f;
        Hit.Normal.Y = 0.0f;
        Hit.Normal.Z = 0.0f;
        Hit.Time = 1.0f;
        Hit.Material = default;
        Hit.PhysMaterial = default;
        Hit.Component = default;
        Hit.BoneName = default;
        Hit.Level = default;
        Hit.bStartPenetrating = default;
        v77 = default;
        Delta_4 = v22;
        Delta_8 = v23;
        v64 = v24;
        Delta = a2;
        v83 = v20 * v20;
        if ( a2 > 0.0f )
        {
          while(1 != default)
          {
            if ( a3 >= 8 )
              goto LABEL_48;
            v25 = ++a3;
            if ( v19 <= 0.050000001d )
              break;
            if ( this.IsHumanControlled() )
            {
              v19 = Delta;
            }
            else
            {
              v26 = this.CylinderComponent.CollisionRadius * this.CylinderComponent.CollisionRadius;
              if ( v83 < v26 )
                v26 = v83;
              v19 = Delta;
              if ( (float)((float)((float)((float)((float)(v72 * v72) + (float)(v73 * v73)) + (float)(v74 * v74)) * Delta) * Delta) <= v26 )
                break;
            }
            v27 = v19 * 0.5f;
            if ( (float)(v19 * 0.5f) >= 0.050000001d )
              v27 = (float)(0.050000001d);
  LABEL_24:
            Delta = v19 - v27;
            v68.X = v72 * v27;
            v68.Y = v73 * v27;
            v68.Z = v74 * v27;
fixed(var ptr2 =&this.Rotation)
            GWorld.MoveActor(this, &v68,  ptr2, 0, &Hit);
            if ( Hit.Time < 1.0f )
            {
              if ( (this.bDisableSkelControlSpring.AsBitfield(32) & 1024) != 0 )
              {
                v28 = v68.X;
                v29 = v68.Z;
                v30 = v68.Y;
                v31 = (float)((float)(v28 * v28) + (float)(v29 * v29)) + (float)(v30 * v30);
                v93 = v31;
                if ( v31 != 1.0f && v31 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
                {
                  v97 = 1077936128;
                  v81 = 1056964608;
                  v32 = 1.0f / fsqrt(v93);
                  v96 = (float)(3.0f - (float)((float)(v32 * v93) * v32)) * (float)(v32 * 0.5f);
                  v29 = v68.Z;
                  v30 = v68.Y;
                  v28 = v68.X;
                }
                v90.X = v28 * (float)(1.0f - Hit.Time);
                v90.Y = v30 * (float)(1.0f - Hit.Time);
                v90.Z = v29 * (float)(1.0f - Hit.Time);
                this.WallClimbingStepUp_maybe(&a4, &a4, &v90, &Hit);
              }
              else
              {
                if ( fabs(Hit.Normal.Z) >= 0.2f )
                  goto LABEL_53;
                v33 = (float)((float)(this.Velocity.Z * Hit.Normal.Z) + (float)(this.Velocity.Y * Hit.Normal.Y)) + (float)(Hit.Normal.X * this.Velocity.X);
                v34 = this.Velocity.X - (float)(v33 * Hit.Normal.X);
                v35 = this.Velocity.Z - (float)(v33 * Hit.Normal.Z);
                v36 = this.Velocity.Y - (float)(Hit.Normal.Y * v33);
                v37 = (float)(v34 * v34) + (float)(v36 * v36);
                v82 = v37;
                v38 = this.Velocity.Z;
                v86 = v34;
                v87 = v36;
                v88 = v35;
                v95 = v37;
                v85 = (float)(sqrt(v37));
                if ( v37 == 1.0f )
                {
                  v39 = 0.0f;
                  if ( v35 == 0.0f )
                  {
                    v78 = v86;
                    v40 = v86;
                    v79 = v87;
                    v36 = v87;
                    v80 = v88;
                    v39 = v88;
                  }
                  else
                  {
                    v40 = v34;
                  }
                }
                else if ( v37 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
                {
                  v94 = 1077936128;
                  v84 = 1056964608;
                  v41 = 1.0f / fsqrt(v95);
                  v91 = (float)(3.0f - (float)((float)(v41 * v95) * v41)) * (float)(v41 * 0.5f);
                  v36 = v36 * v91;
                  v39 = 0.0f;
                  v40 = v91 * v34;
                }
                else
                {
                  v40 = 0.0f;
                  v36 = 0.0f;
                  v39 = 0.0f;
                }
                v42 = v85;
                SetFromBitfield(ref this.bCollideComplex, 20, this.bCollideComplex.AsBitfield(20) | (0x100u));
                SetFromBitfield(ref this.bDisableSkelControlSpring, 32, this.bDisableSkelControlSpring.AsBitfield(32) | (0x400u));
                v43 = this.VfTableObject.Dummy;
                this.Velocity.X = v40 * v42;
                this.Velocity.Y = v36 * v42;
                this.Velocity.Z = (float)(v39 * v42) + v38;
                v74 = (float)(v39 * v42) + v38;
                v72 = v40 * v42;
                v73 = v36 * v42;
                CallUFunction(this.ReachedWall, this, v44, 0, 0);
                v25 = a3;
              }
            }
            if ( (this.bDisableSkelControlSpring.AsBitfield(32) & 0x400) != 0 )
            {
              v45 = this.MaxWallStepHeight + 2.0f;
              v46 = this.Floor.Y * v45;
              v47 = this.Floor.Z * v45;
              *(float *)v89 = v21->X - (float)(this.Floor.X * v45);
              *(float *)&v89[1] = this.Location.Y - v46;
              *(float *)&v89[2] = this.Location.Z - v47;
              v48 = this.GetCylinderExtent(&a2a);
fixed(var ptr3 =&this.Location)
              GWorld.SingleLineCheck(&Hit, this, (Vector *)v89,  ptr3, 8415, v48, 0);
              if ( Hit.Time >= 1.0f )
              {
  LABEL_53:
                this.FallingOffWall();
                if ( this.Physics == PHYS_WallClimbing )
                  this.setPhysics( 2, 0, 0, 0, 1065353216);// setPhysics
                (*(void (__thiscall **)(TdPawn , _DWORD, int))(this.VfTableObject.Dummy + 1000))(this, LODWORD(a2), v25);
                return;
              }
              v49 = this.Floor.Y;
              v50 = this.Floor.Z;
              v51 = this.MaxWallStepHeight + 2.0f;
              a4.X = (float)(this.Floor.X * -1.0f) * v51;
              a4.Y = (float)(v49 * -1.0f) * v51;
              a4.Z = (float)(v50 * -1.0f) * v51;
              if ( fabs(Hit.Normal.Z) > 0.2f )
              {
fixed(var ptr4 =&this.Rotation)
                GWorld.MoveActor(this, &a4,  ptr4, 0, &Hit);
                if ( this.Physics == PHYS_WallClimbing )
                  this.setPhysics( 2, 0, 0, 0, 1065353216);// setPhysics
                this.FallingOffWall();
                (*(void (__thiscall **)(TdPawn , _DWORD, int))(this.VfTableObject.Dummy + 1000))(this, LODWORD(a2), v25);
                return;
              }
fixed(var ptr5 =&this.Rotation)
              GWorld.MoveActor(this, &a4,  ptr5, 0, &Hit);
              v52 = Hit.Normal.Y;
              v53 = Hit.Normal.Z;
              this.Floor.X = Hit.Normal.X;
              v54 = Hit.Actor == this.Base;
              this.Floor.Y = v52;
              this.Floor.Z = v53;
              if ( default == v54 )
                this.SetBase(
                  Hit.Actor,
                  Hit.Normal,
                  1,
                  0,
                  0,
                  0);
            }
            v19 = Delta;
            if ( Delta <= 0.0f )
              goto LABEL_48;
          }
          v27 = v19;
          goto LABEL_24;
        }
  LABEL_48:
        if ( (this.bCollideComplex.AsBitfield(20) & 0x100) == 0 && this.Physics == PHYS_WallClimbing )
        {
          v55 = v71;
          Delta_8a = (float)(this.Location.Y - Delta_8) * (float)(1.0f / a2);
          v56 = (float)(this.Location.Z - v64) * (float)(1.0f / a2);
          this.Velocity.X = (float)(1.0f / a2) * (float)(v21->X - Delta_4);
          this.Velocity.Y = Delta_8a;
          this.Velocity.Z = v56;
          if ( v55 > this.Velocity.Z || v55 >= 0.0f )
          {
            Delta_8b = (float)(this.Velocity.Y * 2.0f) - v70;
            v57 = (float)(this.Velocity.Z * 2.0f) - v55;
            this.Velocity.X = (float)(this.Velocity.X * 2.0f) - v69;
            this.Velocity.Y = Delta_8b;
            this.Velocity.Z = v57;
          }
        }
      }
    }
  }

  // NOT READY
  public unsafe void InitMoveObjects(){ NativeMarkers.MarkUnimplemented(); }
//public unsafe void InitMoveObjects()
//  {
//    ref array<TdMove_ptr> v2; // edi
//    bool v3 = default; // zf
//    TdMove *v4; // esi
//    void *v5; // ecx
//    int v6 = default; // esi
//    Class *v7; // eax
//    _DWORD *v8; // eax
//    _DWORD *v9; // eax
//  
//fixed(var ptr1 =&this.Moves)
//    v2 =  ptr1;
//    v3 = this.Moves.Max == 0;
//    this.Moves.Count = default;
//    if ( default == v3 )
//    {
//      v4 = v2.Data;
//      v3 = v2.Data == 0;
//      this.Moves.Max = default;
//      if ( default == v3 )
//      {
//        v5 = dword_2018708;
//        if ( default == dword_2018708 )
//        {
//          GCreateMalloc_Prob();
//          v5 = dword_2018708;
//        }
//        v2.Data = (TdMove *__ptr32)(*(int (__thiscall **)(void *, TdMove *__ptr32, _DWORD, int))(*(_DWORD *)v5 + 8))(v5, v4, 0, 8);
//      }
//    }
//    v2.Add(this.MoveClasses.Count, 4, 8);
//    v6 = default;
//    if ( this.MoveClasses.Count > 0 )
//    {
//      while(1 != default)
//      {
//        v7 = this.MoveClasses.Data;
//        if ( default == v7[v6] )
//        {
//          v2[v6] = default;
//          goto LABEL_16;
//        }
//        if ( v6 == 5 )
//          break;
//        if ( v6 == 4 )
//        {
//          v9 = sub_1110DD0((int)v7[40], (int)this, 0, 0, 0, 0, 0, dword_20186F4, 0, 0);
//          *((_DWORD *)v2.Data + 4) = sub_12B2710((int)v9);
//          *(_DWORD *)(*((_DWORD *)v2.Data + 4) + 60) = this;
//        }
//        else
//        {
//          if ( v6 == 40 )
//            break;
//          v8 = sub_1110DD0((int)v7[v6], (int)this, 0, 0, 0, 0, 0, dword_20186F4, 0, 0);
//          v2[v6] = (TdMove )sub_12B2710((int)v8);
//          v2[v6].PawnOwner = this;
//        }
//  LABEL_16:
//        if ( ++v6 >= this.MoveClasses.Count )
//          return;
//      }
//      v2[v6] = (TdMove )*((_DWORD *)v2.Data + 4);
//      goto LABEL_16;
//    }
//  }
//
  public unsafe void CheckForUncontrolledSlide(CheckResult *a2)
  {
    PhysicalMaterial v3 = default; // eax
    TdPhysicalMaterialProperty v4 = default; // eax
    PhysicalMaterial v5 = default; // eax
  
    if ( this.IsHumanControlled() )
    {
      if ( this.MovementState != MOVE_FallingUncontrolled )
      {
        v3 = a2.PhysMaterial;
        if ( ((v3 || a2.Material && (v3 = (PhysicalMaterial )a2.Material.GetPhysicalMaterial()) != 0)// GetPhysicalMaterial
           && (v4 = E_TryCastTo<TdPhysicalMaterialProperty>(v3.PhysicalMaterialProperty)) != 0
           || (v5 = this.LastFootstepMaterial) != 0 && (v4 = E_TryCastTo<TdPhysicalMaterialProperty>(v5.PhysicalMaterialProperty)) != 0)
          && (v4.bEnableSoftLanding.AsBitfield(4) & 4) != 0 )
        {
          SetFromBitfield(ref this.bDisableSkelControlSpring, 32, this.bDisableSkelControlSpring.AsBitfield(32) | (0x10000u));
          this.UncontrolledSlideNormal = a2.Normal;
        }
      }
    }
  }

  // NOT READY
  public unsafe void ReplicateCustomAnim(ECustomNodeType Type, name AnimName, float Rate, float BlendInTime, float BlendOutTime, bool bLooping, bool bOverride, bool bRootMotion, int bRootRotation){ NativeMarkers.MarkUnimplemented(); }
//public unsafe void ReplicateCustomAnim(ECustomNodeType Type, name AnimName, float Rate, float BlendInTime, float BlendOutTime, bool bLooping, bool bOverride, bool bRootMotion, int bRootRotation)
//  {
//    int *v11; // eax
//    void *v12; // ecx
//    int v13 = default; // edi
//    float v14 = default; // xmm0_4
//    int* v15 = stackalloc int[3]; // [esp+Ch] [ebp-18h] BYREF
//    int v16 = default; // [esp+20h] [ebp-4h]
//  
//    if ( this.Role == ROLE_Authority )
//    {
//      v11 = sub_1113310(&AnimName, v15);
//      v16 = default;
//fixed(var ptr1 =&this.ReplicatedCustomAnim)
//      sub_44D910( ptr1, (int)v11);
//      v16 = -1;
//      if ( v15[0] )
//      {
//        v12 = dword_2018708;
//        v13 = v15[0];
//        if ( default == dword_2018708 )
//        {
//          GCreateMalloc_Prob();
//          v12 = dword_2018708;
//        }
//        (*(void (__thiscall **)(void *, int))(*(_DWORD *)v12 + 12))(v12, v13);
//      }
//      this.ReplicatedCustomAnim.BlendInTime = BlendInTime;
//      v14 = BlendOutTime;
//      this.ReplicatedCustomAnim.NodeType = Type;
//      this.ReplicatedCustomAnim.BlendOutTime = v14;
//      this.ReplicateCustomAnimCount = 1;
//    }
//  }
//
  public override unsafe void TickSpecial(float a2)
  {
    float v3 = default; // xmm0_4
    float v4 = default; // xmm1_4
    float v5 = default; // xmm2_4
    float v6 = default; // xmm0_4
    int v7 = default; // edi
    int v8 = default; // eax
    EMovement v9 = default; // al
    TdMove *v10; // edx
    bool v11 = default; // zf
    TdMove *v12; // eax
    float v13 = default; // xmm2_4
    float v14 = default; // xmm0_4
    double v15 = default; // st7
    float v16 = default; // xmm3_4
    bool v17 = default; // cc
    float v18 = default; // xmm1_4
    float v19 = default; // xmm1_4
    float *v20; // eax
    int v21 = default; // edx
    byte *v22; // ecx
    float v23 = default; // xmm2_4
    byte* v24 = stackalloc byte[4]; // [esp+1Ch] [ebp-10h] BYREF
    int v25 = default; // [esp+20h] [ebp-Ch]
    int v26 = default; // [esp+24h] [ebp-8h]
    int v27 = default; // [esp+28h] [ebp-4h]
    float a2a = default; // [esp+30h] [ebp+4h]
  
    this.TickSpecial(a2);
    this.UpdateMeshTranslation_OrSomething(a2);
    v3 = this.EvadeTimer;
    v4 = a2;
    if ( v3 > 0.0f )
    {
      if ( v3 < a2 )
        v5 = this.EvadeTimer;
      else
        v5 = a2;
      this.EvadeTimer = v3 - v5;
    }
    v6 = this.bIllegalLedgeTimer;
    if ( v6 > 0.0f )
    {
      if ( v6 < a2 )
        v4 = this.bIllegalLedgeTimer;
      this.bIllegalLedgeTimer = v6 - v4;
    }
    if ( (BYTE2(this.bDisableSkelControlSpring.AsBitfield(32)) & 1) != 0 && this.MovementState != MOVE_RumpSlide )
    {
      v7 = this.VfTableObject.Dummy;
      v24[0] = 38;
      v27 = default;
      v25 = default;
      v26 = 1;
      CallUFunction(this.SetMove, this, v8, v24, 0);
    }
    v9 = this.MovementState;
    if(v9 != default)
    {
      v10 = this.Moves.Data;
      v11 = v10[v9] == 0;
      v12 = &v10[v9];
      if ( default == v11 )
        v12.UpdateMoveTimer( LODWORD(a2));// UTdMove::UpdateMoveTimer
    }
    this.DoFootPlacement_Maybe(a2);
    v13 = this.ASPollTimer + a2;
    this.ASPollTimer = v13;
    v14 = 0.0f;
    v15 = fabs(sqrt(this.Velocity.Y * this.Velocity.Y + this.Velocity.X * this.Velocity.X)) * (double)((((signed __int32)-((this.bDisableSkelControlSpring.AsBitfield(32) >> 3) & 1) >> 31) & 2) - 1) * a2;
    if ( v15 > 0.0f )
    {
      a2a = (float)v15;
      v16 = a2a;
    }
    else
    {
      v16 = 0.0f;
    }
    v17 = v13 <= this.ASPollInterval;
    v18 = this.ASDistanceAccum + v16;
    this.ASDistanceAccum = v18;
    if ( default == v17 )
    {
      this.ASDistanceData[this.ASSlotPointer] = v18;
      this.ASTimeData[this.ASSlotPointer++] = this.ASPollTimer;
      v11 = this.ASSlotPointer == this.ASPollSlots;
      this.ASDistanceAccum = 0.0f;
      this.ASPollTimer = 0.0f;
      if(v11 != default)
        this.ASSlotPointer = default;
      v19 = 0.0f;
      if ( this.ASTimeData.Count > 0 )
      {
        v20 = this.ASDistanceData.Data;
        v21 = this.ASTimeData.Count;
        v22 = (byte *)((byte *)this.ASTimeData.Data - (byte *)v20);
        do
        {
          v23 = *(float *)((byte *)v20 + (_DWORD)v22);
          v14 = v14 + *v20++;
          --v21;
          v19 = v23 + v19;
        }
        while(v21 != default);
      }
      this.AverageSpeed = v14 / v19;
    }
  }

  public unsafe void physWalking(float DeltaTime, int Iterations)
  {
    float v4 = default; // xmm1_4
    float v5 = default; // xmm5_4
    float v6 = default; // xmm0_4
    float v7 = default; // ecx
    float v8 = default; // edx
    float v9 = default; // xmm7_4
    float v10 = default; // xmm2_4
    float v11 = default; // xmm3_4
    float v12 = default; // xmm1_4
    float v13 = default; // xmm0_4
    float v14 = default; // ecx
    float v15 = default; // edx
    float v16 = default; // xmm6_4
    float v17 = default; // xmm2_4
    float v18 = default; // xmm0_4
    float v19 = default; // xmm1_4
    EMovement v20 = default; // al
    double v21 = default; // st7
    float v22 = default; // xmm1_4
    float v23 = default; // xmm0_4
    float v24 = default; // xmm5_4
    float v25 = default; // xmm0_4
    float v26 = default; // xmm0_4
    Vector *v27; // ecx
    Vector *v28; // eax
    float v29 = default; // xmm0_4
    float v30 = default; // edx
    float v31 = default; // eax
    float v32 = default; // ecx
    float v33 = default; // xmm2_4
    double v34 = default; // st7
    int v35 = default; // ecx
    int v36 = default; // edx
    // void (__thiscall *v37)(TdPawn , float *, _DWORD, _DWORD, _DWORD, _DWORD, int, _DWORD); // eax
    PhysicsVolume v38 = default; // ecx
    PhysicsVolume v39 = default; // eax
    float v40 = default; // ecx
    float v41 = default; // edx
    float v42 = default; // xmm2_4
    float v43 = default; // xmm3_4
    float v44 = default; // xmm0_4
    float v45 = default; // eax
    float v46 = default; // ecx
    float v47 = default; // edx
    float v48 = default; // eax
    Actor v49 = default; // ecx
    float v50 = default; // xmm1_4
    float v51 = default; // xmm3_4
    Controller v52 = default; // ecx
    float v53 = default; // xmm1_4
    float v54 = default; // eax
    double v55 = default; // st6
    Vector *v56; // ebx
    float v57 = default; // eax
    float v58 = default; // xmm3_4
    float v59 = default; // xmm2_4
    float v60 = default; // eax
    Actor v61 = default; // ebp
    float v62 = default; // xmm1_4
    int v63 = default; // eax
    Controller v64 = default; // ecx
    float v65 = default; // xmm4_4
    // void (__thiscall *v66)(TdPawn , int *, float *, float *, CheckResult *); // edx
    Actor v67 = default; // edi
    float v68 = default; // eax
    float v69 = default; // ecx
    float v70 = default; // edx
    float v71 = default; // xmm0_4
    PrimitiveComponent v72 = default; // eax
    float *v73; // eax
    float v74 = default; // ecx
    float v75 = default; // edx
    float v76 = default; // eax
    Vector *v77; // eax
    float v78 = default; // eax
    float v79 = default; // ecx
    float v80 = default; // xmm5_4
    Actor v81 = default; // edi
    float v82 = default; // xmm7_4
    float v83 = default; // xmm1_4
    float v84 = default; // xmm4_4
    float v85 = default; // ecx
    float v86 = default; // edx
    float v87 = default; // ebp
    float v88 = default; // ebx
    float v89 = default; // xmm1_4
    float v90 = default; // xmm1_4
    float v91 = default; // xmm2_4
    float v92 = default; // xmm0_4
    float v93 = default; // edi
    float v94 = default; // ebx
    float v95 = default; // ebp
    double v96 = default; // st7
    float v97 = default; // xmm1_4
    float v98 = default; // xmm1_4
    double v99 = default; // st6
    double v100 = default; // st5
    double v101 = default; // st7
    float v102 = default; // xmm1_4
    float v103 = default; // xmm1_4
    float v104 = default; // xmm0_4
    float v105 = default; // edx
    Controller v106 = default; // edi
    Actor v107 = default; // edi
    uint v108 = default; // eax
    uint v109 = default; // eax
    Controller v110 = default; // esi
    double v111 = default; // st7
    double v112 = default; // st7
    float v113 = default; // xmm1_4
    TdBotPawn v114 = default; // edi
    // void (__thiscall *v115)(TdPawn , int, _DWORD, _DWORD, _DWORD, int); // edx
    // void (__thiscall *v116)(TdPawn , int, _DWORD, _DWORD, _DWORD, int); // edx
    int v117 = default; // edi
    int v118 = default; // eax
    double v119 = default; // st7
    double v120 = default; // st7
    float v121 = default; // xmm1_4
    float v122 = default; // xmm2_4
    float v123 = default; // xmm1_4
    float v124 = default; // xmm2_4
    Controller v125 = default; // ecx
    float v126 = default; // [esp+3Ch] [ebp-1E8h]
    Vector DestLocation = default; // [esp+5Ch] [ebp-1C8h] BYREF
    float v128 = default; // [esp+68h] [ebp-1BCh]
    float v129 = default; // [esp+6Ch] [ebp-1B8h]
    int v130 = default; // [esp+70h] [ebp-1B4h] BYREF
    int bCheckedFall = default; // [esp+74h] [ebp-1B0h] BYREF
    Actor v132 = default; // [esp+78h] [ebp-1ACh]
    float v133 = default; // [esp+7Ch] [ebp-1A8h]
    float v134 = default; // [esp+80h] [ebp-1A4h]
    float v135 = default; // [esp+84h] [ebp-1A0h]
    float v136 = default; // [esp+88h] [ebp-19Ch]
    float v137 = default; // [esp+8Ch] [ebp-198h]
    float v138 = default; // [esp+90h] [ebp-194h]
    float v139 = default; // [esp+94h] [ebp-190h]
    float v140 = default; // [esp+98h] [ebp-18Ch]
    Vector v141 = default; // [esp+9Ch] [ebp-188h] BYREF
    float v142 = default; // [esp+A8h] [ebp-17Ch]
    float v143 = default; // [esp+ACh] [ebp-178h]
    float v144 = default; // [esp+B0h] [ebp-174h]
    int v145 = default; // [esp+B4h] [ebp-170h]
    float v146 = default; // [esp+B8h] [ebp-16Ch]
    float v147 = default; // [esp+BCh] [ebp-168h]
    float v148 = default; // [esp+C0h] [ebp-164h]
    float v149 = default; // [esp+C4h] [ebp-160h]
    CheckResult Hit = default; // [esp+C8h] [ebp-15Ch] BYREF
    int v151 = default; // [esp+110h] [ebp-114h]
    float v152 = default; // [esp+114h] [ebp-110h] BYREF
    int v153 = default; // [esp+118h] [ebp-10Ch]
    int v154 = default; // [esp+11Ch] [ebp-108h]
    int a7 = default; // [esp+120h] [ebp-104h] BYREF
    int v156 = default; // [esp+124h] [ebp-100h]
    int v157 = default; // [esp+128h] [ebp-FCh]
    float v158 = default; // [esp+12Ch] [ebp-F8h]
    int* a2 = stackalloc int[2]; // [esp+130h] [ebp-F4h] BYREF
    Vector v160 = default; // [esp+138h] [ebp-ECh]
    int v161 = default; // [esp+144h] [ebp-E0h]
    Vector v162 = default; // [esp+148h] [ebp-DCh]
    Vector v163 = default; // [esp+154h] [ebp-D0h] BYREF
    Vector a5 = default; // [esp+160h] [ebp-C4h] BYREF
    float v165 = default; // [esp+16Ch] [ebp-B8h]
    float* v166 = stackalloc float[4]; // [esp+178h] [ebp-ACh] BYREF
    float v167 = default; // [esp+188h] [ebp-9Ch]
    float v168 = default; // [esp+18Ch] [ebp-98h]
    float v169 = default; // [esp+190h] [ebp-94h]
    float* v170 = stackalloc float[4]; // [esp+194h] [ebp-90h] BYREF
    float v171 = default; // [esp+1A4h] [ebp-80h]
    float v172 = default; // [esp+1A8h] [ebp-7Ch]
    int v173 = default; // [esp+1B0h] [ebp-74h] BYREF
    float v174 = default; // [esp+1B4h] [ebp-70h]
    Vector v175 = default; // [esp+1B8h] [ebp-6Ch] BYREF
    float v176 = default; // [esp+1C4h] [ebp-60h]
    Vector a4 = default; // [esp+1C8h] [ebp-5Ch] BYREF
    Vector v178 = default; // [esp+1D4h] [ebp-50h] BYREF
    float* v179 = stackalloc float[5]; // [esp+1E0h] [ebp-44h] BYREF
    float v180 = default; // [esp+1F4h] [ebp-30h]
    float v181 = default; // [esp+200h] [ebp-24h]
    float v182 = default; // [esp+204h] [ebp-20h]
    int v183 = default; // [esp+214h] [ebp-10h]
  
    if ( default == this.Controller && (this.bIsFemale.AsBitfield(20) & 0x8000) == 0 )
    {
      this.Acceleration.X = 0.0f;
      this.Acceleration.Y = 0.0f;
      v138 = 0.0f;
      v139 = 0.0f;
      this.Acceleration.Z = 0.0f;
      v140 = 0.0f;
      this.Velocity.X = 0.0f;
      this.Velocity.Y = 0.0f;
      this.Velocity.Z = 0.0f;
      return;
    }
    v4 = this.Velocity.Y;
    v5 = this.Velocity.X;
    v6 = (float)(v5 * v5) + (float)(v4 * v4);
    v170[0] = v6;
    if ( v6 == 1.0f )
    {
      if ( this.Velocity.Z == 0.0f )
      {
        v7 = this.Velocity.Y;
        v8 = this.Velocity.Z;
        v147 = this.Velocity.X;
        v5 = v147;
        v148 = v7;
        v9 = v7;
        v149 = v8;
        goto LABEL_12;
      }
      v9 = v4;
    }
    else if ( v6 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
    {
      v165 = 3.0f;
      v133 = 0.5f;
      v10 = 1.0f / fsqrt(v170[0]);
      *(float *)a2 = (float)(3.0f - (float)((float)(v10 * v170[0]) * v10)) * (float)(v10 * 0.5f);
      v5 = this.Velocity.X * *(float *)a2;
      v9 = *(float *)a2 * this.Velocity.Y;
    }
    else
    {
      v5 = 0.0f;
      v9 = 0.0f;
    }
    v149 = 0.0f;
  LABEL_12:
    v11 = this.Floor.Y;
    v12 = this.Floor.X;
    v13 = (float)(v12 * v12) + (float)(v11 * v11);
    v170[0] = v13;
    if ( v13 == 1.0f )
    {
      if ( this.Floor.Z == 0.0f )
      {
        v14 = this.Floor.Y;
        v15 = this.Floor.Z;
        v138 = this.Floor.X;
        v12 = v138;
        v139 = v14;
        v11 = v14;
        v140 = v15;
        v16 = v15;
        goto LABEL_19;
      }
    }
    else if ( v13 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
    {
      v165 = 3.0f;
      v133 = 0.5f;
      v17 = 1.0f / fsqrt(v170[0]);
      *(float *)a2 = (float)(3.0f - (float)((float)(v17 * v170[0]) * v17)) * (float)(v17 * 0.5f);
      v12 = *(float *)a2 * this.Floor.X;
      v11 = this.Floor.Y * *(float *)a2;
    }
    else
    {
      v12 = 0.0f;
      v11 = 0.0f;
    }
    v16 = 0.0f;
  LABEL_19:
    v18 = (float)((float)((float)(-0.0f - v12) * v5) + (float)((float)(-0.0f - v16) * v149)) + (float)((float)(-0.0f - v11) * v9);
    v19 = this.Floor.Z * this.Floor.Z;
    v133 = v18;
    if ( v19 >= 0.0f )
    {
      if ( v19 > 1.0f )
        v19 = 1.0f;
    }
    else
    {
      v19 = 0.0f;
    }
    v132 = (Actor )LODWORD(v19);
    v20 = this.MovementState;
    v21 = sqrt(1.0f - v19);
    v22 = this.Moves[v20].FrictionModifier;
    *(float *)&v132 = v21 * v133;
    if ( v20 == MOVE_Slide || v20 == MOVE_RumpSlide || v20 == MOVE_MeleeSlide )
    {
      if ( v18 < 0.0f )
        v26 = this.DownwardSlideFrictionScale;
      else
        v26 = this.UpwardSlideFrictionScale;
      v25 = (float)((float)(v26 * *(float *)&v132) + 1.0f) * v22;
      goto LABEL_37;
    }
    if ( v18 < 0.0f )
      v23 = this.DownwardWalkFrictionScale;
    else
      v23 = this.UpwardWalkFrictionScale;
    v24 = this.MaxWalkFrictionModify;
    v25 = (float)((float)(v23 * *(float *)&v132) + 1.0f) * v22;
    if ( v25 < this.MinWalkFrictionModify )
      v25 = this.MinWalkFrictionModify;
    if ( v24 >= v25 )
  LABEL_37:
      v24 = v25;
fixed(var ptr1 =&this.Acceleration)
    v27 =  ptr1;
    this.Velocity.Z = 0.0f;
    this.Acceleration.Z = 0.0f;
    if ( this.Acceleration.X == 0.0f && this.Acceleration.Y == 0.0f && this.Acceleration.Z == 0.0f )
    {
fixed(var ptr2 =&this.Acceleration)
      v28 =  ptr2;
    }
    else
    {
      v29 = (float)((float)(v27->X * v27->X) + (float)(this.Acceleration.Y * this.Acceleration.Y)) + (float)(this.Acceleration.Z * this.Acceleration.Z);
      v170[0] = v29;
      if ( v29 == 1.0f )
      {
        v30 = v27->X;
        v31 = this.Acceleration.Y;
        v32 = this.Acceleration.Z;
        DestLocation.Y = v30;
        DestLocation.Z = v31;
        v128 = v32;
      }
      else if ( v29 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
      {
        v165 = 3.0f;
        v133 = 0.5f;
        v33 = 1.0f / fsqrt(v170[0]);
        *(float *)a2 = (float)(3.0f - (float)((float)(v33 * v170[0]) * v33)) * (float)(v33 * 0.5f);
        DestLocation.Y = *(float *)a2 * v27->X;
        DestLocation.Z = this.Acceleration.Y * *(float *)a2;
        v128 = this.Acceleration.Z * *(float *)a2;
      }
      else
      {
        DestLocation.Y = 0.0f;
        DestLocation.Z = 0.0f;
        v128 = 0.0f;
      }
      v28 = (Vector *)&DestLocation.Y;
    }
    v34 = this.GroundSpeed;
    v35 = LODWORD(v28->Y);
    v152 = v28->X;
    v36 = LODWORD(v28->Z);
    // v37 = *(void (__thiscall **)(TdPawn , float *, _DWORD, _DWORD, _DWORD, _DWORD, int, _DWORD))(this.VfTableObject.Dummy + 1040);
    v153 = v35;
    v38 = this.PhysicsVolume;
    v154 = v36;
    v126 = (float)v34;
    v37(this, &v152, LODWORD(DeltaTime), LODWORD(v126), v38.GroundFriction * v24, 0, 1, 0);// CalcVelocity
    v39 = this.PhysicsVolume;
    v40 = this.Location.X;
    v41 = this.Location.Y;
    v42 = this.Velocity.Y + (float)((float)(v39.ZoneVelocity.Y * 25.0f) * DeltaTime);
    v43 = this.MaxStepHeight + 2.0f;
    v171 = (float)((float)(v39.ZoneVelocity.X * 25.0f) * DeltaTime) + this.Velocity.X;
    v44 = 0.0f;
    Hit.Item = -1;
    Hit.LevelIndex = -1;
    v45 = this.Location.Z;
    v141.X = v40;
    v46 = this.Floor.X;
    v149 = v43 * -1.0f;
    v172 = v42;
    a7 = default;
    v156 = default;
    v157 = -1082130432;
    v147 = v43 * 0.0f;
    v148 = v43 * 0.0f;
    Hit.Next = default;
    Hit.Actor = default;
    Hit.Location.X = 0.0f;
    Hit.Location.Y = 0.0f;
    Hit.Location.Z = 0.0f;
    Hit.Normal.X = 0.0f;
    Hit.Normal.Y = 0.0f;
    Hit.Normal.Z = 0.0f;
    Hit.Time = 1.0f;
    Hit.Material = default;
    Hit.PhysMaterial = default;
    Hit.Component = default;
    Hit.BoneName = default;
    Hit.Level = default;
    Hit.bStartPenetrating = default;
    v151 = default;
    v141.Y = v41;
    v141.Z = v45;
    v143 = v46;
    v47 = this.Floor.Y;
    v48 = this.Floor.Z;
    v49 = this.Base;
    SetFromBitfield(ref this.bCollideComplex, 20, this.bCollideComplex.AsBitfield(20) & (0xFFFFFEFF));
    v50 = this.Location.Z;
    v144 = v47;
    v145 = LODWORD(v48);
    v132 = v49;
    bCheckedFall = default;
    v130 = default;
    v51 = DeltaTime;
    v133 = v50;
    if ( DeltaTime <= 0.0f )
    {
  LABEL_188:
      if ( this.Physics == PHYS_Walking )
      {
        v119 = this.Location.Z;
        v158 = this.Location.Z;
        v120 = fabs(v119 - v133);
        v146 = (float)v120;
        if ( v120 > 4.0f && this.MaxStepHeight >= v146 )
          this.OffsetMeshZ( v133 - v158);// OffsetMeshZ
        if ( (this.bCollideComplex.AsBitfield(20) & 0x100) == 0 )
        {
          v121 = this.Location.Y;
          v122 = this.Location.Z;
          v143 = (float)(1.0f / DeltaTime) * (float)(this.Location.X - v141.X);
          v123 = (float)(v121 - v141.Y) * (float)(1.0f / DeltaTime);
          v144 = v123;
          v124 = (float)(v122 - v141.Z) * (float)(1.0f / DeltaTime);
          v145 = LODWORD(v124);
          this.Velocity.X = v143;
          this.Velocity.Y = v123;
          this.Velocity.Z = v124;
        }
        this.Velocity.Z = 0.0f;
      }
      v125 = this.Controller;
      if(v125 != default)
        v125.PostPhysWalking(LODWORD(DeltaTime));// PostPhysWalking
      return;
    }
    while(1 != default)
    {
      if ( Iterations >= 8 )
        goto LABEL_188;
      v52 = this.Controller;
      if ( default == v52 && (this.bIsFemale.AsBitfield(20) & 0x8000) == 0 )
        goto LABEL_188;
      ++Iterations;
      v53 = v51;
      if ( v51 > 0.050000001d )
      {
        v53 = v51 * 0.5f;
        if ( (float)(v51 * 0.5f) >= 0.050000001d )
          v53 = (float)(0.050000001d);
      }
      v54 = this.Location.X;
      v137 = v53;
      v55 = v171 * v53;
fixed(var ptr3 =&this.Location)
      v56 =  ptr3;
      v138 = v54;
      v57 = this.Location.Y;
      DestLocation.Y = v55;
      v58 = v51 - v53;
      v59 = v42 * v53;
      v139 = v57;
      v60 = this.Location.Z;
      v61 = default;
      v62 = v53 * 0.0f;
      v129 = v58;
      DestLocation.Z = v59;
      v128 = v62;
      v140 = v60;
      v162.X = 0.0f;
      v162.Y = 0.0f;
      v162.Z = 0.0f;
      if ( fabs(v55) < 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ && fabs(DestLocation.Z) < 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ && fabs(v128) < 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
      {
        v161 = 1;
        v129 = 0.0f;
        goto LABEL_76;
      }
      v161 = default;
      if(v52 != default)
      {
        if ( v52.0x11C29D0()// 0x11C29D0, ATdPlayerController.Pawn != 0
          && (v63 = this.SomethingVertigoRelated(
                      v170,
                      COERCE_FLOAT(LODWORD(v152)),
                      v153,
                      v154,
                      LODWORD(DestLocation.Y),
                      LODWORD(DestLocation.Z),
                      COERCE_FLOAT(LODWORD(v128)),
                      a7,
                      v156,
                      v157,
                      &bCheckedFall,
                      &v130),
              DestLocation.Y = *(float *)v63,
              v64 = this.Controller,
              DestLocation.Z = *(float *)(v63 + 4),
              v128 = *(float *)(v63 + 8),
              v64.MoveTimer == -1.0f) )
        {
          v44 = 0.0f;
          v129 = 0.0f;
        }
        else
        {
          v44 = 0.0f;
        }
        v59 = DestLocation.Z;
        v62 = v128;
      }
      if ( this.Floor.Z < 0.98000002d )
      {
        v65 = DestLocation.Y;
        if ( (float)((float)((float)(this.Floor.Z * v62) + (float)(this.Floor.Y * v59)) + (float)(this.Floor.X * DestLocation.Y)) < 0.0f )
        {
          Hit.Time = 0.0f;
  LABEL_72:
          // v66 = *(void (__thiscall **)(TdPawn , int *, float *, float *, CheckResult *))(this.VfTableObject.Dummy + 528);
          v158 = (float)(sqrt(DestLocation.Y * DestLocation.Y + v128 * v128 + DestLocation.Z * DestLocation.Z));
          v179[0] = (float)(1.0f / v158) * v65;
          v179[1] = v59 * (float)(1.0f / v158);
          v179[2] = v62 * (float)(1.0f / v158);
          v175.Y = (float)(1.0f - v44) * v65;
          v175.Z = v59 * (float)(1.0f - v44);
          v176 = v62 * (float)(1.0f - v44);
fixed(var ptr4 =&v175.Y)
          this.stepUp( &a7, v179,  ptr4, &Hit);
          if ( this.Physics == PHYS_Falling )
          {
            v99 = this.Location.Y - v139;
            v100 = v56->X - v138;
            v101 = sqrt(v100 * v100 + v99 * v99) / v158;
            v146 = (float)v101;
            if ( v101 < 1.0f )
              v102 = v146;
            else
              v102 = 1.0f;
            v129 = (float)((float)(1.0f - v102) * v137) + v129;
            this.Falling();
            if ( this.Physics == PHYS_Flying )
            {
              v136 = this.AirSpeed;
              v103 = v136;
              this.Velocity.X = 0.0f;
              v134 = 0.0f;
              v135 = 0.0f;
              v104 = this.AccelRate;
              this.Velocity.Y = 0.0f;
              v105 = v135;
              this.Velocity.Z = v103;
              v136 = v104;
              this.Acceleration.X = 0.0f;
              this.Acceleration.Y = v105;
              this.Acceleration.Z = v104;
            }
            goto LABEL_142;
          }
          if ( Hit.Time < 1.0f )
          {
            v61 = Hit.Actor;
            v162 = Hit.Normal;
          }
          goto LABEL_75;
        }
      }
fixed(var ptr5 =&this.Rotation)
      GWorld.MoveActor(this, (Vector *)&DestLocation.Y,  ptr5, 0, &Hit);
      v44 = Hit.Time;
      if ( Hit.Time < 1.0f )
      {
        v62 = v128;
        v59 = DestLocation.Z;
        v65 = DestLocation.Y;
        goto LABEL_72;
      }
  LABEL_75:
      if ( this.Physics == PHYS_Swimming )
        goto LABEL_143;
  LABEL_76:
      v67 = this.Base;
      if(v67 != default)
      {
        if ( (v67.bForceDemoRelevant.AsBitfield(32) & 0x40000000) == 0 && v67 != GWorld.GetWorldInfo() )
          SetFromBitfield(ref this.bUpAndOut, 32, this.bUpAndOut.AsBitfield(32) | ((uint)&loc_1000000));// bForceFloorCheck = TRUE;
      }
      if(v61 != default)
      {
        v68 = v162.X;
        v69 = v162.Y;
        v70 = v162.Z;
        Hit.Actor = v61;
  LABEL_82:
        Hit.Time = 0.1f;
        v71 = (float)(2.4000001d);
        Hit.Normal.Y = v69;
        Hit.Normal.X = v68;
        Hit.Normal.Z = v70;
        goto LABEL_95;
      }
      if ( v161
        && v67
        && (v67.bExludeHandMoves.AsBitfield(32) & 0x400) != 0
        && this.RelativeLocation.X == (float)(v56->X - v67.Location.X)
        && this.RelativeLocation.Y == (float)(this.Location.Y - v67.Location.Y)
        && this.RelativeLocation.Z == (float)(this.Location.Z - v67.Location.Z)
        && (HIBYTE(this.bUpAndOut.AsBitfield(32)) & 1) == 0 )
      {
        v68 = this.Floor.X;
        v69 = this.Floor.Y;
        v70 = this.Floor.Z;
        Hit.Actor = v67;
        goto LABEL_82;
      }
      v72 = this.CollisionComponent;
      SetFromBitfield(ref this.bUpAndOut, 32, this.bUpAndOut.AsBitfield(32) & (0xFEFFFFFF));
      if(v72 != default)
      {
        *(float *)&v173 = v56->X + v72.Translation.X;
        v174 = v72.Translation.Y + this.Location.Y;
        v175.X = v72.Translation.Z + this.Location.Z;
        v73 = (float *)&v173;
      }
      else
      {
fixed(var ptr6 =&this.Location.X)
        v73 =  ptr6;
      }
      v74 = *v73;
      v75 = v73[1];
      v76 = v73[2];
      a5.X = v74;
      a4.X = v74 + v147;
      a5.Y = v75;
      a4.Y = v75 + v148;
      a5.Z = v76;
      a4.Z = v76 + v149;
      v77 = this.GetCylinderExtent((Vector *)a2);
      GWorld.SingleLineCheck(&Hit, this, &a4, &a5, 8415, v77, 0);
      v71 = (float)(this.MaxStepHeight + 2.0f) * Hit.Time;
      v78 = Hit.Normal.Y;
      v79 = Hit.Normal.Z;
      this.Floor.X = Hit.Normal.X;
      this.Floor.Y = v78;
      this.Floor.Z = v79;
      v142 = v71;
      this.CheckForUncontrolledSlide(&Hit);
      v80 = Hit.Normal.Z;
      if ( this.WalkableFloorZ <= Hit.Normal.Z )
        goto LABEL_99;
  LABEL_95:
      if ( fabs(DestLocation.Y) >= 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ || fabs(DestLocation.Z) >= 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ || fabs(v128) >= 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
      {
        v44 = 0.0f;
        if ( (float)((float)((float)(Hit.Normal.X * DestLocation.Y) + (float)(Hit.Normal.Y * DestLocation.Z)) + (float)(v128 * Hit.Normal.Z)) < 0.0f )
        {
          v83 = (float)((float)(Hit.Normal.Y + Hit.Normal.X) * 0.0f) + (float)(this.MaxStepHeight * Hit.Normal.Z);
          v84 = this.MaxStepHeight - (float)(v83 * Hit.Normal.Z);
          v178.X = (float)(-0.0f - (float)(v83 * Hit.Normal.X)) * -1.0f;
          v178.Y = (float)(-0.0f - (float)(Hit.Normal.Y * v83)) * -1.0f;
          v178.Z = v84 * -1.0f;
fixed(var ptr7 =&this.Rotation)
          GWorld.MoveActor(this, &v178,  ptr7, 0, &Hit);
          if ( Hit.Actor != this.Base && this.Physics == PHYS_Walking )
            this.SetBase(
              Hit.Actor,
              Hit.Normal,
              1,
              0,
              0,
              0);
          v85 = Hit.Normal.Y;
          v86 = Hit.Normal.Z;
          v44 = 0.0f;
          this.Floor.X = Hit.Normal.X;
          this.Floor.Y = v85;
          this.Floor.Z = v86;
          goto LABEL_122;
        }
      }
      else
      {
  LABEL_99:
        v44 = 0.0f;
      }
      if ( Hit.Time >= 1.0f || ((v81 = Hit.Actor) is object && Hit.Actor == this.Base) && v142 <= 2.4000001d )
      {
        if ( v142 >= 1.9f )
          goto LABEL_123;
        v93 = Hit.Normal.X;
        v94 = Hit.Normal.Y;
        v95 = Hit.Normal.Z;
        v163.X = 0.0f;
        v163.Y = 0.0f;
        v163.Z = 2.1500001d - v142;
fixed(var ptr8 =&this.Rotation)
        GWorld.MoveActor(this, &v163,  ptr8, 0, &Hit);
        v44 = 0.0f;
        Hit.Time = 0.0f;
        Hit.Normal.X = v93;
        Hit.Normal.Y = v94;
        Hit.Normal.Z = v95;
      }
      else
      {
        v82 = (float)(v142 - 2.1500001d) > 0.0f ? v142 - 2.1500001d : 0.0f;
        v87 = Hit.Normal.X;
        v88 = Hit.Normal.Y;
        v89 = (float)((float)(v147 * v147) + (float)(v149 * v149)) + (float)(v148 * v148);
        v181 = Hit.Normal.Z;
        v182 = v89;
        if ( v89 == 1.0f )
        {
          v167 = v147;
          v90 = v147;
          v168 = v148;
          v91 = v148;
          v169 = v149;
          v44 = v149;
        }
        else if ( v89 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
        {
          v183 = 1077936128;
          v146 = 0.5f;
          v92 = fsqrt(v182);
          v165 = (float)(3.0f - (float)((float)((float)(1.0f / v92) * v182) * (float)(1.0f / v92))) * (float)((float)(1.0f / v92) * 0.5f);
          v90 = v165 * v147;
          v91 = v148 * v165;
          v44 = v149 * v165;
        }
        else
        {
          v90 = 0.0f;
          v91 = 0.0f;
        }
        v166[1] = v90 * v82;
        v166[2] = v91 * v82;
        v166[3] = v44 * v82;
fixed(var ptr9 =&this.Rotation)
        GWorld.MoveActor(this, (Vector *)&v166[1],  ptr9, 0, &Hit);
        v44 = 0.0f;
        Hit.Actor = v81;
        Hit.Time = 0.0f;
        Hit.Normal.X = v87;
        Hit.Normal.Y = v88;
        Hit.Normal.Z = v181;
        if(v81 != default)
        {
          if ( v81 != this.Base && this.Physics == PHYS_Walking )
          {
            this.SetBase(
              Hit.Actor,
              Hit.Normal,
              1,
              0,
              0,
              0);                                 // SetBase
            v44 = 0.0f;
          }
        }
      }
  LABEL_122:
      v80 = Hit.Normal.Z;
  LABEL_123:
      if ( this.Physics == PHYS_Swimming )
        goto LABEL_143;
      if(v130 != default)
        goto LABEL_155;
      if ( Hit.Time >= 1.0f || v80 < this.WalkableFloorZ )
        break;
      if ( v80 < 0.99000001d && (float)(this.PhysicsVolume.GroundFriction * v80) < 3.3f )
      {
        v160.Z.LODWORD(this.PhysicsVolume.GroundFriction > 0.5f ? LODWORD(this.PhysicsVolume.GroundFriction) : 1056964608);
        v96 = this.GetGravityZ();// GetGravityZ
        v44 = 0.0f;
        v180 = v96 * DeltaTime / (v160.Z + v160.Z) * DeltaTime;
        v97 = (float)((float)(Hit.Normal.Y + Hit.Normal.X) * 0.0f) + (float)(v180 * Hit.Normal.Z);
        v135 = -0.0f - (float)(Hit.Normal.Y * v97);
        v98 = v97 * Hit.Normal.Z;
        v136 = v180 - v98;
        v134 = -0.0f - (float)((float)((float)((float)(Hit.Normal.Y + Hit.Normal.X) * 0.0f) + (float)(v180 * Hit.Normal.Z)) * Hit.Normal.X);
        DestLocation.Y = v134;
        DestLocation.Z = v135;
        v128 = v180 - v98;
        if ( (float)((float)((float)(v135 + v134) * 0.0f) + (float)((float)(v180 - v98) * v180)) >= 0.0f )
        {
fixed(var ptr10 =&this.Rotation)
          GWorld.MoveActor(this, (Vector *)&DestLocation.Y,  ptr10, 0, &Hit);
          v44 = 0.0f;
        }
        if ( this.Physics == PHYS_Swimming )
        {
  LABEL_143:
          this.startSwimming(v141, this.Velocity, v137, v129, Iterations);
          return;
        }
      }
      v51 = v129;
      if ( v129 <= 0.0f )
        goto LABEL_188;
      v42 = v172;
    }
    if ( (this.bUpAndOut.AsBitfield(32) & 0x200) == 0 )
      goto LABEL_151;
    if ( default == bCheckedFall )
    {
      if ( this.Controller )
      {
        v106 = this.Controller;
        if ( v106.IsProbing(333, 0) )
        {
          bCheckedFall = 1;
          v106.MayFall();
        }
        if(v130 != default)
          goto LABEL_155;
      }
    }
    if ( (this.bUpAndOut.AsBitfield(32) & 0x200) != 0 )
    {
  LABEL_155:
      v107 = v132;
    }
    else
    {
  LABEL_151:
      v107 = v132;
      if ( default == v132 || (v132.bForceDemoRelevant.AsBitfield(32) & 0x40000000) == 0 && v107 != GWorld.GetWorldInfo() )
        v130 = 1;
    }
    if ( bCheckedFall || (this.bCollideComplex.AsBitfield(20) & 0x100) != 0 || v130 || (v108 = this.bUpAndOut.AsBitfield(32), (v108 & 0x200) != 0) && ((v108 & 0x80000) != 0 || (v108 & 0xA) == 0) )
    {
      v163.X = this.Location.X - v138;
      v163.Y = this.Location.Y - v139;
      v111 = sqrt(DestLocation.Y * DestLocation.Y + v128 * v128 + DestLocation.Z * DestLocation.Z);
      if ( v111 == 0.0f )
      {
        v129 = 0.0f;
      }
      else
      {
        v112 = sqrt(v163.Y * v163.Y + v163.X * v163.X) / v111;
        v146 = (float)v112;
        if ( v112 < 1.0f )
          v113 = v146;
        else
          v113 = 1.0f;
        v129 = (float)((float)(1.0f - v113) * v137) + v129;
      }
      this.Velocity.Z = 0.0f;
      this.Falling();
      if ( this.Physics != PHYS_Walking )
        goto LABEL_142;
      v114 = E_TryCastTo<TdBotPawn>(this);
      if(dword_2020740 != default)
      {
        if ( default == HasBegunPlay(GWorld) )
          goto LABEL_142;
        if ( GWorld.GetTimeSeconds() < 1.0f )
          goto LABEL_142;
        // v116 = *(void (__thiscall **)(TdPawn , int, _DWORD, _DWORD, _DWORD, int))(this.VfTableObject.Dummy + 480);
        v143 = 0.0f;
        v144 = 0.0f;
        v145 = 1065353216;
        this.setPhysics( 2, 0, 0, 0, 1065353216);
        if(v114 != default)
        {
          if ( v142 <= 36.0f )
            goto LABEL_142;
        }
        v160.X = 0.0f;
      }
      else
      {
        // v115 = *(void (__thiscall **)(TdPawn , int, _DWORD, _DWORD, _DWORD, int))(this.VfTableObject.Dummy + 480);
        v143 = 0.0f;
        v144 = 0.0f;
        v145 = 1065353216;
        this.setPhysics( 2, 0, 0, 0, 1065353216);
        if ( v114 && (v142 <= 36.0f && this.WalkableFloorZ <= Hit.Normal.Z || this.IsInMove( 77)) )// IsInMove
          goto LABEL_142;
        v160.X.LODWORD(1);
      }
      v117 = this.VfTableObject.Dummy;
      v160.Y = 0.0f;
      LOBYTE(a2[0]) = 2;
      a2[1] = default;
      CallUFunction(this.SetMove, this, v118, a2, 0);
  LABEL_142:
      this.startNewPhysics( COERCE_FLOAT(LODWORD(v129)), Iterations);// startNewPhysics
      return;
    }
    this.Velocity.X = 0.0f;
    v134 = 0.0f;
    this.Acceleration.X = 0.0f;
    this.Velocity.Y = 0.0f;
    this.Velocity.Z = 0.0f;
    v135 = 0.0f;
    v136 = 0.0f;
    this.Acceleration.Y = 0.0f;
    this.Acceleration.Z = 0.0f;
    GWorld.FarMoveActor(this, &v141, 0, 0, 0);
    if(v107 != default)
    {
      v109 = v107.bExludeHandMoves.AsBitfield(32);
      if ( (v109 & 8) != 0 || (v109 & 0x400) != 0 || (v107.bForceDemoRelevant.AsBitfield(32) & 0x100000) == 0 )
        this.SetBase( v107, COERCE_FLOAT(LODWORD(v143)), COERCE_FLOAT(LODWORD(v144)), v145, 1, 0, 0, 0);// SetBase
    }
    v110 = this.Controller;
    if(v110 != default)
      v110.MoveTimer = -1.0f;
  }

  // Not Ready
  public unsafe bool IsHitActorTdPawn(CheckResult *a2)
  {
    Object v2 = default; // ecx
    Class v3 = default; // eax
  
    v2 = TdPawn_Class;
    if ( default == TdPawn_Class )
    {
      TdPawn_Class = (Object )sub_12C2C40((int)L"TdGame");
      sub_12B2BE0();
      v2 = TdPawn_Class;
    }
    v3 = a2.Actor.Class;
    if ( default == v3 )
      return v2 != 0;
    while ( v3 != v2 )
    {
      v3 = (Class )v3.Next;
      if ( default == v3 )
        return v2 != 0;
    }
    return false;
  }

  public unsafe bool ShouldTrace(PrimitiveComponent Primitive, Actor SourceActor, DWORD TraceFlags)
  {
    bool result = default; // eax
  
    if ( this.ActorCylinderComponent != Primitive || (result = (bool)E_TryCastTo<TdPawn>(SourceActor)) )
      result = this.ShouldTrace(Primitive, SourceActor, TraceFlags);
    return result != default;
  }
}
}
