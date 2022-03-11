// NO OVERWRITE

namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.Engine.AnimNodeSequence.ERootBoneAxis; using static MEdge.Engine.AnimNodeSequence.ERootRotationOption; using static MEdge.TdGame.TdPawn.EAgainstWallState; using static MEdge.TdGame.TdPawn.EWeaponAnimState; using static MEdge.Engine.SkeletalMeshComponent.ERootMotionMode; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdPawn
{
  public override void PostBeginPlay()
  {
    float filterTime; // xmm0_4
    int slots; // edi
    int i; // eax
    int slots_1; // edi
    //_E_struct_TArray_float *distanceData; // esi

    base.PostBeginPlay();
    HardWrittenSetter(ref this.AccelCurve_LightWeapon, ref this.AccelCurve_HeavyWeapon);
    NativeMarkers.MarkUnimplemented("Replaced with the hard-written setter above");
    //ComputeAccelerationCurve(&this.SpeedCurve_LightWeapon, &this.AccelCurve_LightWeapon, 10);
    //ComputeAccelerationCurve(&this.SpeedCurve_HeavyWeapon, &this.AccelCurve_HeavyWeapon, 10);
    
    filterTime = this.ASFilterTime;
    if ( filterTime < 1.0 )
      filterTime = 1.0f;
    slots = this.ASPollSlots;
    this.ASFilterTime = filterTime;
    if ( slots < 10 )
      slots = 10;
    this.ASPollSlots = slots;
    this.ASPollInterval = filterTime / (float)slots;
    this.ASTimeData.Reset();
    this.ASTimeData.Insert(0, slots);
    //FArray::Insert(&this.ASTimeData, 0, slots, 4, 8);
    //memset(this.ASTimeData.Data, 0, 4 * slots);
    for ( i = 0; i < this.ASTimeData.Count; ++i )
      this.ASTimeData.Data[i] = this.ASPollInterval;
    slots_1 = this.ASPollSlots;
    //distanceData = &this.ASDistanceData;
    //FArray::Insert(distanceData, 0, slots_1, 4, 8);
    //memset(distanceData.Data, 0, 4 * slots_1);
    this.ASDistanceData.Reset();
    this.ASDistanceData.Insert(0, slots_1);


    static void HardWrittenSetter(ref InterpCurveFloat light, ref InterpCurveFloat heavy)
    {
      light.InterpMethod = 0;
      light.Points[0] = Pt(0, 1148846080, 0, 0, 0);
      light.Points[1] = Pt(1116733440, 1148846080, 0, 0, 0);
      light.Points[2] = Pt(1125122048, 1148846080, 0, 0, 0);
      light.Points[3] = Pt(1129840640, 1148846075, 0, 0, 0);
      light.Points[4] = Pt(1133510656, 1148846080, 0, 0, 0);
      light.Points[5] = Pt(1135869952, 1143518640, 0, 0, 0);
      light.Points[6] = Pt(1138229248, 1128792064, 0, 0, 0);
      light.Points[7] = Pt(1140588544, 1128792064, 0, 0, 0);
      light.Points[8] = Pt(1141899264, 1112539008, 0, 0, 0);
      light.Points[9] = Pt(1143078912, 1110603328, 0, 0, 0);
      light.Points[10] = Pt(1144258560, 0, 0, 0, 0);

      heavy.InterpMethod = 0;
      heavy.Points[0] = Pt(0, 1137180672, 0, 0, 0);
      heavy.Points[1] = Pt(1109393408, 1137180674, 0, 0, 0);
      heavy.Points[2] = Pt(1117782016, 1137180672, 0, 0, 0);
      heavy.Points[3] = Pt(1123024896, 1137180677, 0, 0, 0);
      heavy.Points[4] = Pt(1126170624, 1137180672, 0, 0, 0);
      heavy.Points[5] = Pt(1128792064, 1137180672, 0, 0, 0);
      heavy.Points[6] = Pt(1131413504, 1137180682, 0, 0, 0);
      heavy.Points[7] = Pt(1133248512, 1137180672, 0, 0, 0);
      heavy.Points[8] = Pt(1134559232, 1137180672, 0, 0, 0);
      heavy.Points[9] = Pt(1135869952, 1137180672, 0, 0, 0);
      heavy.Points[10] = Pt(1137180672, 0, 0, 0, 0);
    }

    static unsafe InterpCurvePointFloat Pt(int a, int b, int c, int d, int e)
    {
      return new InterpCurvePointFloat() {InVal = * (float*) & a, OutVal = * (float*) & b, ArriveTangent = * (float*) & c, LeaveTangent = * (float*) & d, InterpMode = (EInterpCurveMode) e};
    }
  }
  public virtual unsafe EWeaponType GetWeaponType()
  {
    TdWeapon v1 = default; // eax
    EWeaponType result = default; // al
  
    v1 = this.MyWeapon;
    if(v1 != default)
      result = v1.WeaponType;
    else
      result = EWT_None;
    return result;
  }

  public unsafe bool OkToInteract()
  {
    return false;
  }

  public override unsafe void startNewPhysics(float deltaTime, int Iterations)
  {
    int v3 = default; // edx
  
    if ( deltaTime >= 0.00030000001d && Iterations <= 7 )
    {
      v3 = (int)this.Physics;
      SetFromBitfield(ref this.bDisableSkelControlSpring, 32, this.bDisableSkelControlSpring.AsBitfield(32) & (0xFFFEFFFF));
      switch ( (int)v3 )
      {
        case (int)PHYS_None:
          return;
        case (int)PHYS_Walking:
          this.physWalking((deltaTime), Iterations);// physWalking
          break;
        case (int)PHYS_Falling:
          this.physFalling((deltaTime), Iterations);// physFalling
          break;
        case (int)PHYS_Swimming:
          this.physSwimming(deltaTime, Iterations);
          break;
        case (int)PHYS_Flying:
          this.physFlying(deltaTime, Iterations);
          break;
        case (int)PHYS_Interpolating:
          this.physInterpolating((deltaTime));// physInterpolating
          break;
        case (int)PHYS_Spider:
          this.physSpider(deltaTime, Iterations);
          break;
        case (int)PHYS_Ladder:
          this.physLadder(deltaTime, Iterations);
          break;
        case (int)PHYS_RigidBody:
          this.physRigidBody((deltaTime));// physRigidBody
          break;
        case (int)PHYS_WallRunning:
          this.physWallRunning((deltaTime), Iterations);// physWallRunning
          break;
        case (int)PHYS_WallClimbing:
          this.physWallClimbing((deltaTime), Iterations);// physWallClimbing
          break;
        default:
          this.setPhysics( 0, default, new Vector(0, 0, COERCE_FLOAT(1065353216)));// setPhysics
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
    this.VelocityMagnitude = (float)v1;
    if ( v1 <= 0.00000001f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
    {
      this.VelocityMagnitude = 0.0f;
      this.VelocityDir = default;
    }
    else
    {
      v2 = this.Velocity.Z;
      v3 = this.Velocity.Y * (float)(1.0f / v7);
      this.VelocityDir.X = this.Velocity.X * (float)(1.0f / v7);
      this.VelocityDir.Y = v3;
      this.VelocityDir.Z = v2 * (float)(1.0f / v7);
      v4 = sqrt(this.Velocity.Y * this.Velocity.Y + this.Velocity.X * this.Velocity.X);
      this.VelocityMagnitude2D = (float)v4;
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

  public override unsafe void setPhysics(byte NewPhysics, Actor NewFloor = null, Vector? _NewFloorV = null)
  {
    EPhysics v5 = default; // al

    var NewFloorV = _NewFloorV ?? FVector( 0, 0, 1 );
    if ( this.Physics == (EPhysics)NewPhysics )
    {
      if ( NewPhysics == 1 )
        goto LABEL_6;
    }
    else if ( NewPhysics == 1 )
    {
      this.NewFloorSmooth = (float)(this.Location.Z - this.CylinderComponent.CollisionHeight) - 2.0f;
      goto LABEL_6;
    }
    this.ClearTimer(/**(name *)&FuncName_SlideOffLedge_unknown_EyeJoint*/"SlideOffLedge", null);// SlideOffLedge
  LABEL_6:
    v5 = this.Physics;
    if ( v5 != (EPhysics)NewPhysics )
    {
      if ( v5 == PHYS_WallClimbing || v5 == PHYS_WallRunning )
        SetFromBitfield(ref this.bDisableSkelControlSpring, 32, this.bDisableSkelControlSpring.AsBitfield(32) & (~1024u));
      if ( v5 != (EPhysics)NewPhysics && NewPhysics == 2 )
        this.EnterFallingHeight = this.Location.Z;
    }
    this.AnimLockRefCount = default;
    base.setPhysics(NewPhysics, NewFloor, NewFloorV);
  }

  public override unsafe float GetGravityZ()
  {
    return (float)(base.GetGravityZ() * this.GravityModifier);
  }

  public unsafe bool UNKNOWN28(Vector *a2, bool a3, bool a4, Vector *a5, ref CheckResult a6)
  {
    float v6 = default; // xmm1_4
    float v7 = default; // xmm0_4
    float v8 = default; // edx
    //Vector *v10; // ebp
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
    //Rotator *v42; // [esp-Ch] [ebp-98h]
    //CheckResult *v43; // [esp-4h] [ebp-90h]
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
    else if ( Delta.X >= SMALL_NUMBER )
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
    GWorld.MoveActor(this, ref Delta, ref this.Rotation, 0, ref a6);
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
      else if ( v24 >= SMALL_NUMBER )
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
      Delta.X = (float)(v27 * 34.0f) + this.Location.X;
      Delta.Y = this.Location.Y + (float)(v22 * 34.0f);
      Delta.Z = this.Location.Z + (float)(v28 * 34.0f);
      v30 = this.GetCylinderExtent(&a2a);
      GWorld.SingleLineCheck(ref a6, this, Delta, this.Location, 8415, *v30, 0);
      if ( a6.Time < 1.0f )
      {
        v44 = default;
  LABEL_32:
        v34 = -0.0f - a2->Y;
        v35 = -0.0f - a2->Z;
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
      GWorld.MoveActor(this, ref *a5, ref this.Rotation, 0, ref a6);
      v31 = a6.Time;
      v48 = v31;
      v32 = v31;
      v33 = 0.0f;
      v45 = default;
      if ( v31 <= 0.050000001d )
      {
        if(a3 != default)
        {
          GWorld.MoveActor(this, ref Delta, ref this.Rotation, 0, ref a6);
          v33 = a6.Time;
          v31 = v33;
          if ( v33 <= 0.050000001d )
          {
            v32 = v48;
          }
          else
          {
            GWorld.MoveActor(this, ref *a5, ref this.Rotation, 0, ref a6);
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
        GWorld.MoveActor(this, ref a2a, ref this.Rotation, 0, ref a6);
      }
      v34 = -0.0f - a2->Y;
      v35 = -0.0f - a2->Z;
      a2a.X = (float)(-0.0f - a2->X) * 32.0f;
      a2a.Y = v34 * 32.0f;
      a2a.Z = v35 * 32.0f;
      v41 = &a2a;
      goto LABEL_33;
    }
    v20 = -0.0f - a2->Y;
    v21 = -0.0f - a2->Z;
    Delta.X = (float)((float)(-0.0f - a2->X) * 32.0f) * v19;
    Delta.Y = (float)(v20 * 32.0f) * v19;
    Delta.Z = (float)(v21 * 32.0f) * v19;
    v41 = &Delta;
  LABEL_33:
    GWorld.MoveActor(this, ref *v41, ref this.Rotation, 0, ref a6);
    v36 = v53;
    v37 = v52;
    SetFromBitfield(
      ref this.bCollideComplex, 20, this.bCollideComplex.AsBitfield(20) ^ 
                                                  (
                                                    (
                                                      this.bCollideComplex.AsBitfield(20) ^ 
                                                        (
                                                          (
                                                            ((Location.Y - v53) * (Location.Y - v53) + (Location.X - v52) * (Location.X - v52)) > (a5->X * a5->X + a5->Y * a5->Y)
                                                          ).AsUInt() << 8
                                                        )
                                                    ) & 0x100 
                                                  )
                                    );
    if ( (this.bCollideComplex.AsBitfield(20) & 0x100) != default )
    {
      v38 = v36 - this.Location.Y;
      v39 = v54 - this.Location.Z;
      // v40 = *(void (__thiscall **)(TdPawn , _DWORD, _DWORD, _DWORD, int))(this.VfTableObject.Dummy + 1060);
      Delta.X = v37 - this.Location.X;
      Delta.Y = v38;
      Delta.Z = v39;
      this.OffsetMeshXY(new Vector(Delta.X, v38, v39), 1);// OffsetMeshXY
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

  public unsafe void SetTargetMeshZ(float BlendTime, int bTranslationSpace)
  {
    TdSkeletalMeshComponent v3 = default; // eax
  
    this.TargetMeshTranslationZ = BlendTime;
    if(bTranslationSpace != default)
    {
      v3 = this.Mesh1p;
      if ( default == v3 )
        v3 = this.Mesh3p;
      this.OffsetMeshZ(BlendTime - v3.Translation.Z);// OffsetMeshZ
    }
  }

  public virtual unsafe void UpdateWalkingState()
  {
    WalkingState v1 = default; // al
    TdWeapon v2 = default; // eax
    bool v3 = default; // eax
    float v4 = default; // [esp+0h] [ebp-4h]
  
    v1 = this.OverrideWalkingState;
    v4 = (float)(sqrt(this.Velocity.Y * this.Velocity.Y + this.Velocity.X * this.Velocity.X));
    if( v1 != WAS_None )
    {
      this.CurrentWalkingState = v1;
      return;
    }

    v2 = this.MyWeapon;
    v3 = v2 && v2.WeaponType == EWT_Heavy;
    if ( this.SneakVelocity > v4 )
    {
      this.CurrentWalkingState = WAS_Idle;
      return;
    }
    if ( this.WalkVelocity > v4 )
    {
      v1 = (WalkingState)v3.AsInt() + 1;
  LABEL_10:
      this.CurrentWalkingState = v1;
      return;
    }
    if ( this.JogVelocity <= v4 )
    {
      if ( this.RunVelocity <= v4 )
      {
        if ( this.SprintVelocity <= v4 )
          this.CurrentWalkingState = (WalkingState)((default == v3).AsInt() + 4);
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
    return this.MovementState == Move;
  }

  public unsafe EMovement GetMove()
  {
    return this.MovementState;
  }



  public unsafe AnimNodeSequence GetCustomAnimation( CustomNodeType a2 ) => GetCustomAnimation((byte)a2);
  public unsafe AnimNodeSequence  GetCustomAnimation(byte a2)
  {
    TdAnimNodeSlot v2 = default; // ecx
  
    switch ( (int)a2 )
    {
      case (int)0:
        if ( this.Mesh == this.Mesh1p )
        {
          v2 = this.CustomCannedNode1p;
          if ( default == v2 )
            return default;
        }
        else
        {
          v2 = this.CustomCannedNode3p;
          if ( default == v2 )
            return default;
        }
        return v2.GetCustomAnimNodeSeq();
      case (int)1:
        if ( this.Mesh == this.Mesh1p )
        {
          v2 = this.CustomCannedUpperBodyNode1p;
          if ( default == v2 )
            return default;
        }
        else
        {
          v2 = this.CustomCannedUpperBodyNode3p;
          if ( default == v2 )
            return default;
        }
        return v2.GetCustomAnimNodeSeq();
      case (int)2:
        if ( this.Mesh == this.Mesh1p )
        {
          v2 = this.CustomFullBodyNode1p;
          if ( default == v2 )
            return default;
        }
        else
        {
          v2 = this.CustomFullBodyNode3p;
          if ( default == v2 )
            return default;
        }
        return v2.GetCustomAnimNodeSeq();
      case (int)3:
        if ( this.Mesh == this.Mesh1p )
        {
          v2 = this.CustomFullBodyDirNode1p;
          if ( default == v2 )
            return default;
        }
        else
        {
          v2 = this.CustomFullBodyDirNode3p;
          if ( default == v2 )
            return default;
        }
        return v2.GetCustomAnimNodeSeq();
      case (int)4:
        if ( this.Mesh == this.Mesh1p )
        {
          v2 = this.CustomUpperBodyNode1p;
          if ( default == v2 )
            return default;
        }
        else
        {
          v2 = this.CustomUpperBodyNode3p;
          if ( default == v2 )
            return default;
        }
        return v2.GetCustomAnimNodeSeq();
      case (int)6:
        if ( this.Mesh == this.Mesh1p )
        {
          v2 = this.CustomCameraNode;
          if(v2 != default)
            return v2.GetCustomAnimNodeSeq();
        }
        return default;
      case (int)7:
        if ( this.Mesh == this.Mesh1p )
        {
          v2 = this.CustomWeaponNode1p;
          if(v2 != default)
            return v2.GetCustomAnimNodeSeq();
        }
        else
        {
          v2 = this.CustomWeaponNode3p;
          if(v2 != default)
            return v2.GetCustomAnimNodeSeq();
        }
        return default;
      case (int)8:
        if ( this.Mesh != this.Mesh1p )
        {
          v2 = this.CustomFaceNode;
          if(v2 != default)
            return v2.GetCustomAnimNodeSeq();
        }
        return default;
      default:
        return default;
    }
  }

  // NOT READY
  public unsafe void _RegenerateHealth(float a2){ NativeMarkers.MarkUnimplemented(); }
//public unsafe void _RegenerateHealth(float a2)
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
  public virtual unsafe void PlayCustomAnim(ECustomNodeType Type, name AnimName, float Rate, float BlendInTime, float BlendOutTime, bool bLooping, bool bOverride, bool bRootMotion, bool? _bRootRotation)
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

    var bRootRotation = _bRootRotation ?? false;
    switch ( (int)Type )
    {
      case (int)CNT_Canned:
        v11 = bRootMotion && this.Mesh1p == this.Mesh;
        this.PlayCustomAnimInternal(
          this.CustomCannedNode1p,
          AnimName,
          Rate,
          BlendInTime,
          BlendOutTime,
          bLooping,
          bOverride,
          v11,
          bRootRotation);
        this.PlayCustomAnimInternal(
          this.CustomCannedNode3p,
          AnimName,
          Rate,
          BlendInTime,
          BlendOutTime,
          bLooping,
          bOverride,
          bRootMotion,
          bLooping);
        this.ReplicateCustomAnim(
          Type,
          AnimName,
          Rate,
          BlendInTime,
          BlendOutTime,
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
          (Rate),
          (BlendInTime),
          (BlendOutTime),
          bLooping,
          bOverride,
          v12,
          bRootRotation);
        this.PlayCustomAnimInternal(
          this.CustomCannedUpperBodyNode3p,
          AnimName,
          (Rate),
          (BlendInTime),
          (BlendOutTime),
          bLooping,
          bOverride,
          bRootMotion,
          bLooping);
        this.ReplicateCustomAnim(
          Type,
          AnimName,
          (Rate),
          (BlendInTime),
          (BlendOutTime),
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
          (Rate),
          (BlendInTime),
          (BlendOutTime),
          bLooping,
          bOverride,
          v13,
          bRootRotation);
        this.PlayCustomAnimInternal(
          this.CustomFullBodyNode3p,
          AnimName,
          (Rate),
          (BlendInTime),
          (BlendOutTime),
          bLooping,
          bOverride,
          bRootMotion,
          bLooping);
        this.ReplicateCustomAnim(
          Type,
          AnimName,
          (Rate),
          (BlendInTime),
          (BlendOutTime),
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
          (Rate),
          (BlendInTime),
          (BlendOutTime),
          bLooping,
          bOverride,
          v14,
          bRootRotation);
        this.PlayCustomAnimInternal(
          this.CustomFullBodyDirNode3p,
          AnimName,
          Rate,
          (BlendInTime),
          (BlendOutTime),
          bLooping,
          bOverride,
          bRootMotion,
          bLooping);
        this.ReplicateCustomAnim(
          Type,
          AnimName,
          (Rate),
          (BlendInTime),
          (BlendOutTime),
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
          (Rate),
          (BlendInTime),
          (BlendOutTime),
          bLooping,
          bOverride,
          v15,
          bRootRotation);
        this.PlayCustomAnimInternal(
          this.CustomUpperBodyNode3p,
          AnimName,
          (Rate),
          (BlendInTime),
          (BlendOutTime),
          bLooping,
          bOverride,
          bRootMotion,
          bLooping);
        this.ReplicateCustomAnim(
          Type,
          AnimName,
          (Rate),
          (BlendInTime),
          (BlendOutTime),
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
          (Rate),
          (BlendInTime),
          (BlendOutTime),
          bLooping,
          bOverride,
          v16,
          bRootRotation);
        this.PlayCustomAnimInternal(
          this.CustomLowerBodyNode3p,
          AnimName,
          (Rate),
          (BlendInTime),
          (BlendOutTime),
          bLooping,
          bOverride,
          bRootMotion,
          bLooping);
        this.ReplicateCustomAnim(
          Type,
          AnimName,
          (Rate),
          (BlendInTime),
          (BlendOutTime),
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
          (Rate),
          (BlendInTime),
          (BlendOutTime),
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
          (Rate),
          (BlendInTime),
          (BlendOutTime),
          bLooping,
          bOverride,
          v18,
          bRootRotation);
        v19 = bRootMotion && this.Mesh1p == this.Mesh;
        this.PlayCustomAnimInternal(
          this.CustomWeaponNode3p,
          AnimName,
          (Rate),
          (BlendInTime),
          (BlendOutTime),
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
          (Rate),
          (BlendInTime),
          (BlendOutTime),
          bLooping,
          bOverride,
          v20,
          bRootRotation);
        break;
      default:
        return;
    }
  }



  public virtual unsafe void SetCustomAnimsBlendOutTime( CustomNodeType a2, float a3)
  {
    TdAnimNodeSlot v4 = default; // ecx
  
    switch ( (int)a2 )
    {
      case (int)0:
        goto LABEL_9;
      case (int)1:
        goto LABEL_10;
      case (int)2:
        this.CustomFullBodyNode1p.SetBlendOutTime((a3));// SetBlendOutTime
        v4 = this.CustomFullBodyNode3p;
        goto LABEL_11;
      case (int)3:
        this.CustomFullBodyDirNode1p.SetBlendOutTime((a3));// SetBlendOutTime
        v4 = this.CustomFullBodyDirNode3p;
        goto LABEL_11;
      case (int)4:
        this.CustomUpperBodyNode1p.SetBlendOutTime((a3));// SetBlendOutTime
        v4 = this.CustomUpperBodyNode3p;
        goto LABEL_11;
      case (int)5:
        this.CustomLowerBodyNode1p.SetBlendOutTime((a3));// SetBlendOutTime
        v4 = this.CustomLowerBodyNode3p;
        goto LABEL_11;
      case (int)6:
        v4 = this.CustomCameraNode;
        goto LABEL_11;
      case (int)7:
        this.CustomWeaponNode1p.SetBlendOutTime((a3));// SetBlendOutTime
        v4 = this.CustomWeaponNode3p;
        goto LABEL_11;
      case (int)8:
        this.CustomFaceNode.SetBlendOutTime((a3));// SetBlendOutTime
  LABEL_9:
        this.CustomCannedNode1p.SetBlendOutTime((a3));// SetBlendOutTime
        this.CustomCannedNode3p.SetBlendOutTime((a3));// SetBlendOutTime
  LABEL_10:
        this.CustomCannedUpperBodyNode1p.SetBlendOutTime((a3));// SetBlendOutTime
        v4 = this.CustomCannedUpperBodyNode3p;
  LABEL_11:
        v4.SetBlendOutTime((a3));// SetBlendOutTime
        break;
      default:
        return;
    }
  }

  public unsafe void StopAllCustomAnimations(float a2)
  {
    this.StopCustomAnim(0, (a2));// StopCustomAnim
    this.StopCustomAnim( (CustomNodeType)1, (a2));// StopCustomAnim
    this.StopCustomAnim( (CustomNodeType)2, (a2));// StopCustomAnim
    this.StopCustomAnim( (CustomNodeType)3, (a2));// StopCustomAnim
    this.StopCustomAnim( (CustomNodeType)4, (a2));// StopCustomAnim
    this.StopCustomAnim( (CustomNodeType)6, (a2));// StopCustomAnim
    this.StopCustomAnim( (CustomNodeType)7, (a2));// StopCustomAnim
    this.StopCustomAnim( (CustomNodeType)8, (a2));// StopCustomAnim
  }

  public unsafe void SetRootOffset(Vector Offset, float BlendTime, SkelControlBase.EBoneControlSpace TranslationSpace = default)
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

  public override void UpdateBasedRotation(ref Rotator a2, in Rotator a3)
  {
    this.LegRotation = this.LegRotation + (a3.Yaw);
    base.UpdateBasedRotation(ref a2, a3);
  }

  public virtual unsafe void SetArmorDifficultyLevel(int a2)
  {
    if ( a2 != default )
    {
      if ( a2 == 1 )
      {
        this.ArmorBulletsHead = this.ArmorBulletsHeadSettings.Medium;
        this.ArmorBulletsBody = this.ArmorBulletsBodySettings.Medium;
        this.ArmorBulletsLegs = this.ArmorBulletsLegsSettings.Medium;
        this.ArmorMeleeHead = this.ArmorMeleeHeadSettings.Medium;
        this.ArmorMeleeBody = this.ArmorMeleeBodySettings.Medium;
        this.ArmorMeleeLegs = this.ArmorMeleeLegsSettings.Medium;
      }
      else if ( a2 == 2 )
      {
        this.ArmorBulletsHead = this.ArmorBulletsHeadSettings.Hard;
        this.ArmorBulletsBody = this.ArmorBulletsBodySettings.Hard;
        this.ArmorBulletsLegs = this.ArmorBulletsLegsSettings.Hard;
        this.ArmorMeleeHead = this.ArmorMeleeHeadSettings.Hard;
        this.ArmorMeleeBody = this.ArmorMeleeBodySettings.Hard;
        this.ArmorMeleeLegs = this.ArmorMeleeLegsSettings.Hard;
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
  }

  public override unsafe void performPhysics(float DeltaTime)
  {
    EMovement v3 = default; // al
    TdMove[] v4; // ecx
    bool v5 = default; // zf
    //TdMove *v6; // eax
    float v7 = default; // xmm0_4
    int v8 = default; // edi
    int v9 = default; // eax
  
    v3 = this.MovementState;
    if(v3 != default)
    {
      v4 = this.Moves.Data;
      v5 = v4[(int)v3] == null;
      ref TdMove v6 = ref v4[(int)v3];
      if ( !v5 )
      {
        v6.CheckAutoMoves();// CheckAutoMoves
        this.Moves[this.MovementState].PrePerformPhysics((DeltaTime));// PrePerformPhysics
      }
    }
    if ( (this.bDisableSkelControlSpring.AsBitfield(32) & 131072) != default )
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
    base.performPhysics(DeltaTime);
  }

  public virtual unsafe float GetMobilityMultiplier()
  {
    float v1 = default; // xmm0_4
    float v2 = default; // xmm2_4
    double result = default; // st7
  
    v1 = (float)(1.0f - (float)(this.TaserDamageLevel * 0.0099999998d));
    v2 = 0.0f;
    if ( v1 >= 0.0f && ((v2 = 1.0f - (float)(this.TaserDamageLevel * 0.0099999998d)) is object && v1 > 1.0f) )
      result = 1.0f;
    else
      result = v2;
    return (float)(result);
  }

  public override unsafe void CalcVelocity(ref Vector a2, float a3, float a4, float a5, int a6, int a7, int a8) 
  {
    uint v9 = default; // eax
    SkeletalMeshComponent v10 = default; // eax
    Controller v11 = default; // eax
    TdMove v12 = default; // eax
    float v13 = default; // xmm0_4
    int v14 = default; // eax
    //TdMove *v15; // ecx
    bool v16 = default; // zf
    //TdMove *v17; // eax
    double v18 = default; // st7
    float v19 = default; // xmm7_4
    float v20 = default; // xmm5_4
    float v21 = default; // edx
    //Vector *v22; // edi
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
    //TdMove *v36; // eax
    //TdMove *v37; // eax
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
    if ( (v9 & 0x40000) == default && ((v9 & 0x20000) != default || (v10 = this.Mesh) != default && v10.RootMotionMode != RMM_Ignore) || (v11 = this.Controller) != default && (v11.bIsPlayer.AsBitfield(20) & 0x20000) != default )
    {
      base.CalcVelocity(ref a2, a3, a4, a5, a6, a7, a8);
      v12 = this.Moves[this.MovementState];
      v13 = this.Velocity.X * v12.RootMotionScale.X;
      //v12 = (TdMove )((byte *)v12 + 0xFC);// points to RootMotionScale now
      this.Velocity.X = v13;
      this.Velocity.Y = v12.RootMotionScale.Y * this.Velocity.Y;
      this.Velocity.Z = v12.RootMotionScale.Z * this.Velocity.Z;
      return;
    }
    v14 = (int)this.MovementState;
    var v15 = this.Moves.Data;
    v16 = v15[v14] == null;
    ref var v17 = ref v15[v14];
    v62 = 1.0f;
    if ( !v16 )
      v62 = v17.GetSpeedModifier();// GetSpeedModifier
    v18 = this.GetMobilityMultiplier() * v62;// GetMobilityMultiplier
    v19 = 0.0f;
    v63 = (float)(this.AccelRate * v18);
    v20 = v63;
    a4a = (float)(v18 * a4);
    if ( (BYTE2(this.bIsFemale.AsBitfield(20)) & 1) != default || (this.bDisableSkelControlSpring.AsBitfield(32) & 0x4000) != default )
    {
      SetFromBitfield(ref this.bDisableSkelControlSpring, 32, this.bDisableSkelControlSpring.AsBitfield(32) & (0xFFFFBFFF));
      if ( fabs(this.Acceleration.X) >= 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ || fabs(this.Acceleration.Y) >= 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ || fabs(this.Acceleration.Z) >= 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
      {
        v21 = a2.Y * v63;
        v70 = a2.Z * v63;
        this.Acceleration.X = v63 * a2.X;
        this.Acceleration.Y = v21;
        this.Acceleration.Z = v70;
        goto LABEL_35;
      }
      ref var v22 = ref this.Velocity;
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
          if ( v33 < SMALL_NUMBER )
          {
            v19 = 0.0f;
            v64.X = 0.0f;
            v64.Y = 0.0f;
            v64.Z = 0.0f;
            a2 = v64;
            goto LABEL_35;
          }
          v34 = 1.0f / fsqrt(v33);
          a2a.X = (float)(3.0f - (float)((float)(v34 * v33) * v34)) * (float)(v34 * 0.5f);
          v64.X = this.Acceleration.X * a2a.X;
          v64.Y = a2a.X * this.Acceleration.Y;
          v64.Z = a2a.X * this.Acceleration.Z;
        }
        v19 = 0.0f;
        a2 = v64;
        goto LABEL_35;
      }
      v23 = (float)((float)(v22.X * v22.X) + (float)(this.Velocity.Y * this.Velocity.Y)) + (float)(this.Velocity.Z * this.Velocity.Z);
      v66 = v23;
      if ( v23 == 1.0f )
      {
        v24 = v22.X;
        v25 = this.Velocity.Y;
        v26 = this.Velocity.Z;
      }
      else
      {
        if ( v23 < SMALL_NUMBER )
        {
          v19 = 0.0f;
          v24 = 0.0f;
          v25 = 0.0f;
          v26 = 0.0f;
          goto LABEL_44;

        }
        v27 = fsqrt(v23);
        a2a.X = (float)(3.0f - (float)((float)((float)(1.0f / v27) * v66) * (float)(1.0f / v27))) * (float)((float)(1.0f / v27) * 0.5f);
        v25 = a2a.X * this.Velocity.Y;
        v24 = v22.X * a2a.X;
        v26 = a2a.X * this.Velocity.Z;
      }
      v19 = 0.0f;
      LABEL_44:
      v20 = v63;
      this.Acceleration.X = v24 * v63;
      this.Acceleration.Y = v25 * v63;
      this.Acceleration.Z = v26 * v63;
      v28 = (float)((float)(this.Acceleration.X * this.Acceleration.X) + (float)(this.Acceleration.Y * this.Acceleration.Y)) + (float)(this.Acceleration.Z * this.Acceleration.Z);
      if ( v28 == 1.0f )
      {
        v64 = this.Acceleration;
        a2 = v64;
        goto LABEL_35;
      }
      if ( v28 >= SMALL_NUMBER )
      {
        v29 = 1.0f / fsqrt(v28);
        a2a.X = (float)(3.0f - (float)((float)(v29 * v28) * v29)) * (float)(v29 * 0.5f);
        v64.X = a2a.X * this.Acceleration.X;
        v64.Y = this.Acceleration.Y * a2a.X;
        v64.Z = this.Acceleration.Z * a2a.X;
        a2 = v64;
        goto LABEL_35;
      }
      v64.X = 0.0f;
      v64.Y = 0.0f;
      v64.Z = 0.0f;
      a2 = v64;
      goto LABEL_35;
    }
  LABEL_35:
    v35 = (int)this.MovementState;
    var v36 = this.Moves.Data;
    v16 = v36[v35] == null;
    ref var v37 = ref v36[v35];
    if ( v16 || ((v37).bDebugMove.AsBitfield(29) & 0x4000) == default )
    {
      if ( a7 != default && this.Acceleration.X == 0.0f && this.Acceleration.Y == 0.0f && this.Acceleration.Z == 0.0f )
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
        else if ( v45 >= SMALL_NUMBER )
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
      else if ( v56 >= SMALL_NUMBER )
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
  
  public unsafe void UNKNOWN31(ref Vector a3, ref Vector a4, ref Vector a5, ref CheckResult a6)
  {
    float v6 = default; // xmm4_4
    float v8 = default; // xmm0_4
    float v9 = default; // xmm1_4
    float v10 = default; // xmm2_4
    float v11 = default; // xmm4_4
    // void (__thiscall *v12)(TdPawn , int, _DWORD, _DWORD, _DWORD, int); // edx
    int v13 = default; // edi
    int v14 = default; // eax
    // void (__thiscall *v15)(TdPawn , int, _DWORD, _DWORD, _DWORD, int); // edx
    float v17 = default; // ecx
    float v18 = default; // edx
    float v19 = default; // ecx
    float v20 = default; // edx
    float v21 = default; // xmm2_4
    float v22 = default; // ecx
    float v23 = default; // edx
    float v24 = default; // xmm3_4
    float v25 = default; // xmm4_4
    float v26 = default; // xmm2_4
    float v27 = default; // xmm0_4
    float v28 = default; // ecx
    float v29 = default; // eax
    float v30 = default; // edx
    float v31 = default; // xmm1_4
    float v32 = default; // xmm3_4
    float v33 = default; // xmm0_4
    float v34 = default; // xmm4_4
    float v35 = default; // xmm2_4
    float v36 = default; // xmm5_4
    float v37 = default; // xmm1_4
    float v38 = default; // xmm4_4
    float v39 = default; // xmm5_4
    float v40 = default; // xmm0_4
    float v41 = default; // xmm1_4
    float v42 = default; // xmm0_4
    float v43 = default; // [esp+14h] [ebp-58h]
    Vector v44 = default; // [esp+18h] [ebp-54h] BYREF
    float v45 = default; // [esp+28h] [ebp-44h]
    float v46 = default; // [esp+2Ch] [ebp-40h]
    float v47 = default; // [esp+30h] [ebp-3Ch]
    Vector v48 = default; // [esp+34h] [ebp-38h] BYREF
    Vector Delta = default; // [esp+40h] [ebp-2Ch] BYREF
    Vector v50 = default; // [esp+50h] [ebp-1Ch] BYREF
    float v51 = default; // [esp+5Ch] [ebp-10h]
    float v52 = default; // [esp+60h] [ebp-Ch]
    float v53 = default; // [esp+78h] [ebp+Ch]
    float Hit = default; // [esp+7Ch] [ebp+10h]

    var Actor = this;
    v6 = Actor.MaxWallStepHeight;
    v8 = (float)(Actor.Floor.X * -1.0f) * v6;
    v9 = (float)(Actor.Floor.Y * -1.0f) * v6;
    v10 = (float)(Actor.Floor.Z * -1.0f) * v6;
    v11 = a6.Normal.Z;
    v50.X = v8;
    v50.Y = v9;
    v50.Z = v10;
    if ( v11 > 0.70700002d && Actor.Physics == PHYS_WallRunning )
    {
      Actor.Landed(a6.Normal, a6.Actor);
      // v12 = *(void (__thiscall **)(TdPawn , int, _DWORD, _DWORD, _DWORD, int))(Actor.VfTableObject.Dummy + 480);
      Delta.X = 0.0f;
      Delta.Y = 0.0f;
      Delta.Z = 1.0f;
      Actor.setPhysics(1, default, new Vector(0, 0, COERCE_FLOAT(1065353216)));
      return;
    }
    if ( v11 < -0.70700002d && Actor.Physics == PHYS_WallRunning )
    {
      Actor.processHitWall(a6.Normal, a6.Actor, null);
      v13 = Actor.VfTableObject.Dummy;
      CallUFunction(Actor.FallingOffWall, Actor, v14, 0, 0);
  LABEL_7:
      // v15 = *(void (__thiscall **)(TdPawn , int, _DWORD, _DWORD, _DWORD, int))(Actor.VfTableObject.Dummy + 480);
      Delta.X = 0.0f;
      Delta.Y = 0.0f;
      Delta.Z = 1.0f;
      Actor.setPhysics( 2, default, new Vector(0, 0, COERCE_FLOAT(1065353216)));
      return;
    }
    if ( (float)((float)((float)(Actor.Floor.Z * a6.Normal.Z) + (float)(Actor.Floor.Y * a6.Normal.Y)) + (float)(Actor.Floor.X * a6.Normal.X)) < 0.1f )
    {
      Delta.X = v8 * -1.0f;
      Delta.Y = v9 * -1.0f;
      Delta.Z = v10 * -1.0f;
      GWorld.MoveActor(Actor, ref Delta, ref Actor.Rotation, 0, ref a6);
      GWorld.MoveActor(Actor, ref a5, ref Actor.Rotation, 0, ref a6);
    }
    if ( a6.Time < 1.0f )
    {
      if ( (float)((float)((float)(a6.Normal.Z * Actor.Floor.Z) + (float)(a6.Normal.Y * Actor.Floor.Y)) + (float)(Actor.Floor.X * a6.Normal.X)) < 0.40000001d )
      {
        GWorld.MoveActor(Actor, ref v50, ref Actor.Rotation, 0, ref a6);
        Actor.FallingOffWall();
        // v15 = *(void (__thiscall **)(TdPawn , int, _DWORD, _DWORD, _DWORD, int))(Actor.VfTableObject.Dummy + 480);
        Delta.X = 0.0f;
        Delta.Y = 0.0f;
        Delta.Z = 1.0f;
        Actor.setPhysics( 2, default, new Vector(0, 0, COERCE_FLOAT(1065353216)));
        return;
      }
      v17 = Actor.Floor.Y;
      v18 = Actor.Floor.Z;
      v45 = Actor.Floor.X;
      Actor.Floor.X = a6.Normal.X;
      v46 = v17;
      Actor.Floor.Y = a6.Normal.Y;
      v47 = v18;
      Actor.Floor.Z = a6.Normal.Z;
      a6.Normal.Z = 0.0f;
      v44.X = (float)((float)(a6.Normal.X * a6.Normal.X) + (float)(a6.Normal.Y * a6.Normal.Y)) + (float)(0.0f * 0.0f);
      if ( v44.X == 1.0f )
      {
        v19 = a6.Normal.Y;
        v20 = a6.Normal.Z;
        v44.X = a6.Normal.X;
        v44.Y = v19;
        v44.Z = v20;
      }
      else if ( v44.X >= SMALL_NUMBER )
      {
        Delta.X = 3.0f;
        v21 = 1.0f / fsqrt(v44.X);
        v51 = (float)(3.0f - (float)((float)(v21 * v44.X) * v21)) * (float)(v21 * 0.5f);
        v44.X = a6.Normal.X * v51;
        v44.Y = a6.Normal.Y * v51;
        v44.Z = a6.Normal.Z * v51;
      }
      else
      {
        v44.X = 0.0f;
        v44.Y = 0.0f;
        v44.Z = 0.0f;
      }
      v22 = v44.Y;
      v23 = v44.Z;
      v24 = v47;
      v25 = v46;
      a6.Normal.X = v44.X;
      a6.Normal.Y = v22;
      a6.Normal.Z = v23;
      v26 = Actor.Floor.Y;
      v27 = Actor.Floor.Z;
      v28 = a5.Y;
      v29 = a5.X;
      v30 = a5.Z;
      v44.X = (float)(v26 * v24) - (float)(v27 * v25);
      v31 = Actor.Floor.X;
      v48.Y = v28;
      v48.X = v29;
      v48.Z = v30;
      v44.Y = (float)(v27 * v45) - (float)(v31 * v24);
      v44.Z = (float)(v31 * v25) - (float)(v26 * v45);
      v44.Normalize();
      Delta.X = (float)(v44.Y * v47) - (float)(v44.Z * v46);
      Delta.Y = (float)(v44.Z * v45) - (float)(v47 * v44.X);
      Delta.Z = (float)(v46 * v44.X) - (float)(v44.Y * v45);
      Delta.Normalize();
      v32 = a5.X;
      v33 = (float)((float)(a5.Y * Delta.Y) + (float)(a5.Z * Delta.Z)) + (float)(a5.X * Delta.X);
      v43 = (float)((float)(a5.Y * v46) + (float)(a5.Z * v47)) + (float)(a5.X * v45);
      v34 = Actor.Floor.Z;
      v35 = (float)((float)(a5.Y * v44.Y) + (float)(a5.Z * v44.Z)) + (float)(a5.X * v44.X);
      Hit = Actor.Floor.Y;
      v53 = Actor.Floor.X;
      v36 = (float)(v53 * v44.Z) - (float)(v34 * v44.X);
      Delta.Z = (float)(Hit * v44.X) - (float)(v53 * v44.Y);
      v45 = Actor.Floor.X * v43;
      v46 = Actor.Floor.Y * v43;
      v37 = Actor.Floor.Z * v43;
      v52 = v44.Y * v35;
      v38 = (float)((float)(v34 * v44.Y) - (float)(Hit * v44.Z)) * v33;
      v39 = (float)((float)(v36 * v33) + (float)(v44.Y * v35)) + v46;
      v40 = (float)((float)(Delta.Z * v33) + (float)(v44.Z * v35)) + v37;
      v41 = a5.Z * v40;
      Delta.Z = v40;
      v42 = a5.Y * v39;
      Delta.X = (float)(v38 + (float)(v44.X * v35)) + v45;
      Delta.Y = v39;
      v48.X = Delta.X;
      v48.Y = v39;
      v48.Z = Delta.Z;
      if ( (float)((float)(v41 + v42) + (float)(v32 * Delta.X)) >= 0.0f )
      {
        SetFromBitfield(ref Actor.bCollideComplex, 20, Actor.bCollideComplex.AsBitfield(20) | (0x100u));
        GWorld.MoveActor(Actor, ref v48, ref Actor.Rotation, 0, ref a6);
      }
    }
    GWorld.MoveActor(Actor, ref v50,  ref Actor.Rotation, 0, ref a6);
  }

  public unsafe void WallClimbingStepUp_maybe(ref Vector a3, ref Vector a4, ref Vector a5, ref CheckResult a6)
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

    TdPawn Actor = this;
    v6 = Actor.MaxWallStepHeight;
    Delta.X = Actor.Floor.X * v6;
    Delta.Y = Actor.Floor.Y * v6;
    v7 = Actor.Floor.Z * v6;
    v8 = Actor.Floor.Z;
    Delta.Z = v7;
    if ( (float)((float)((float)(v8 * a6.Normal.Z) + (float)(Actor.Floor.Y * a6.Normal.Y)) + (float)(Actor.Floor.X * a6.Normal.X)) >= 0.94999999d
      || ((GWorld.MoveActor(Actor, ref Delta, ref Actor.Rotation, 0, ref a6) is object) && (GWorld.MoveActor(Actor, ref a5, ref Actor.Rotation, 0, ref a6) is object) && (v9 = a6.Time) is object && v9 >= 1.0f)
      || (float)((float)((float)(Actor.Floor.Z * a6.Normal.Z) + (float)(Actor.Floor.Y * a6.Normal.Y)) + (float)(a6.Normal.X * Actor.Floor.X)) >= 0.94999999d )
    {
      if ( a6.Time < 1.0f && (float)((float)((float)(Actor.Floor.Z * a6.Normal.Z) + (float)(Actor.Floor.Y * a6.Normal.Y)) + (float)(a6.Normal.X * Actor.Floor.X)) < 0.94999999d )
      {
        Actor.Floor = a6.Normal;
        v13 = a5.Z;
        v14 = a5.Y;
        v15 = Actor.Floor.Y;
        v16 = Actor.Floor.Z;
        v17 = (float)((float)(v15 * v14) + (float)(v16 * v13)) + (float)(a5.X * Actor.Floor.X);
        v19.X = a5.X - (float)(Actor.Floor.X * v17);
        v19.Y = v14 - (float)(v15 * v17);
        v19.Z = v13 - (float)(v16 * v17);
        GWorld.MoveActor(Actor, ref v19, ref Actor.Rotation, 0, ref a6);
      }
    }
    else
    {
      v10 = (float)(-0.0f - a5.Y) * (float)(1.0f - v9);
      v11 = (float)(-0.0f - a5.Z) * (float)(1.0f - v9);
      v19.X = (float)(-0.0f - a5.X) * (float)(1.0f - v9);
      v19.Y = v10;
      v19.Z = v11;
      GWorld.MoveActor(Actor, ref v19, ref Actor.Rotation, 0, ref a6);
      v19.X = -0.0f - Delta.X;
      v19.Y = -0.0f - Delta.Y;
      v19.Z = -0.0f - Delta.Z;
      GWorld.MoveActor(Actor, ref v19, ref Actor.Rotation, 0, ref a6);
      if ( Actor.Physics == PHYS_WallClimbing )
      {
        Actor.FallingOffWall();
        // v12 = *(void (__thiscall **)(TdPawn , int, _DWORD, _DWORD, _DWORD, int))(Actor.VfTableObject.Dummy + 480);
        v19.X = 0.0f;
        v19.Y = 0.0f;
        v19.Z = 1.0f;
        Actor.setPhysics( 2, default, new Vector(0, 0, COERCE_FLOAT(1065353216)));
      }
      Actor.Velocity.Z = 0.0f;
    }
  }

  public unsafe void GetCameraAnimation(ref Vector out_Location, ref Rotator out_Rotation)
  {
    SkeletalMeshComponent v4; // ecx
    int v5; // eax
    SkeletalMeshComponent v6; // edx
    Matrix *v7; // eax
    int v8; // esi
    int v9; // eax
    int v10; // edx
    int v11; // esi
    int v12; // edx
    int v13; // ecx
    int v14; // [esp+14h] [ebp-11Ch] BYREF
    Rotator a2; // [esp+18h] [ebp-118h] BYREF
    Rotator v16; // [esp+24h] [ebp-10Ch] BYREF
    Matrix v17; // [esp+30h] [ebp-100h] BYREF
    Matrix a1; // [esp+70h] [ebp-C0h] BYREF
    Matrix SrcMatrix; // [esp+B0h] [ebp-80h] BYREF
    Matrix outval; // [esp+F0h] [ebp-40h] BYREF

    v4 = this.Mesh;
    if ( v4 )
    {
      v5 = v4.MatchRefBone("EyeJoint");
      v6 = this.Mesh;
      a1 = v6.SpaceBases.Data[v5];
      //qmemcpy(&a1, &v6.SpaceBases.Data[v5], sizeof(a1));
      v17 = this.Mesh.SpaceBases.Data[v6.MatchRefBone("CameraJoint")];
      //qmemcpy(&v17, &this.Mesh.SpaceBases.Data[v6.MatchRefBone("CameraJoint")], sizeof(v17));
      v7 = VectorMatrixInverse(&a1, &SrcMatrix);
      v17 = v17.Mult(&outval, v7);
      //qmemcpy(&v17, v17.Mult(&out, v7), sizeof(v17));
      E_MatrixToRotator(&a1, &a2);
      E_MatrixToRotator(&v17, &v16);
      /*v8 = this.VfTableObject.Dummy;
      v14 = 0;
      v9 = UObject::FindFunctionChecked(this, AddCameraDeltaAnimations1, AddCameraDeltaAnimations2, 0);
      (*(void (__stdcall **)(int, int *, _DWORD))(v8 + 244))(v9, &v14, 0);*/
      v14 = this.AddCameraDeltaAnimations() ? 1 : 0;
      if ( v14.AsBool() )
      {
        v10 = v16.Yaw + a2.Yaw;
        v11 = a2.Roll + v16.Roll;
        out_Rotation.Pitch = v16.Pitch + a2.Pitch;
        out_Rotation.Yaw = v10;
        out_Rotation.Roll = v11;
      }
      else
      {
        v12 = a2.Yaw;
        out_Rotation.Pitch = a2.Pitch;
        v13 = a2.Roll;
        out_Rotation.Yaw = v12;
        out_Rotation.Roll = v13;
      }
    }
  }

  
  public unsafe Vector GetWalkAcceleration( float aForward, float aStrafe, int deltaRotation, float deltaTime )
  {
    Vector v = default;
    return * GetWalkAcceleration( & v, aForward, aStrafe, deltaRotation, deltaTime );
  }



  public unsafe Vector * GetWalkAcceleration(Vector *retval, float aForward, float aStrafe, int deltaRotation, float deltaTime)
  {
    Matrix *v7; // eax
    float YY = default; // xmm6_4
    float YZ = default; // xmm7_4
    float XY = default; // xmm4_4
    float XZ = default; // xmm5_4
    float sqrLngth = default; // xmm0_4
    float v13 = default; // xmm3_4
    float v14 = default; // xmm1_4
    float v15 = default; // xmm0_4
    float invSqrt = default; // xmm2_4
    float v17 = default; // xmm1_4
    float v18 = default; // xmm0_4
    float v19 = default; // xmm0_4
    float v20 = default; // xmm3_4
    float v21 = default; // xmm2_4
    float v22 = default; // xmm0_4
    float v23 = default; // xmm1_4
    float v24 = default; // xmm0_4
    float v25 = default; // xmm6_4
    float v26 = default; // xmm7_4
    float v27 = default; // xmm5_4
    float v28 = default; // xmm0_4
    float v29 = default; // xmm4_4
    float v30 = default; // xmm0_4
    float v31 = default; // xmm2_4
    float v32 = default; // xmm6_4
    Vector *result; // eax
    float XX_YX2 = default; // [esp+10h] [ebp-98h]
    Vector v35 = default; // [esp+10h] [ebp-98h]
    float v36 = default; // [esp+10h] [ebp-98h]
    float v37 = default; // [esp+10h] [ebp-98h]
    float v38 = default; // [esp+14h] [ebp-94h]
    float v39 = default; // [esp+14h] [ebp-94h]
    float v40 = default; // [esp+14h] [ebp-94h]
    float XZ_YZ = default; // [esp+18h] [ebp-90h]
    float v42 = default; // [esp+18h] [ebp-90h]
    float v43 = default; // [esp+18h] [ebp-90h]
    float XX_YX = default; // [esp+1Ch] [ebp-8Ch]
    float XY_YY = default; // [esp+20h] [ebp-88h]
    float v46 = default; // [esp+20h] [ebp-88h]
    float XZ_YZ_ = default; // [esp+24h] [ebp-84h]
    float v48 = default; // [esp+24h] [ebp-84h]
    float v49 = default; // [esp+2Ch] [ebp-7Ch]
    float v50 = default; // [esp+2Ch] [ebp-7Ch]
    float XX = default; // [esp+30h] [ebp-78h]
    float YX = default; // [esp+3Ch] [ebp-6Ch]
    float v53 = default; // [esp+48h] [ebp-60h]
    float v54 = default; // [esp+50h] [ebp-58h]
    float v55 = default; // [esp+5Ch] [ebp-4Ch]
    float v56 = default; // [esp+60h] [ebp-48h]
    Matrix v57 = default; // [esp+68h] [ebp-40h] BYREF
  
    v7 = FRotationMatrix(&v57, this.Rotation);
    YY = v7->YPlane.Y;
    YZ = v7->YPlane.Z;
    XY = v7->XPlane.Y;
    XZ = v7->XPlane.Z;
    YX = v7->YPlane.X;
    XX = v7->XPlane.X;
    XZ_YZ = (XZ * aForward) + (YZ * aStrafe);
    sqrLngth = ((XZ_YZ * XZ_YZ) + (((XY * aForward) + (YY * aStrafe)) * ((XY * aForward) + (YY * aStrafe))))
        + (((v7->XPlane.X * aForward) + (YX * aStrafe)) * ((v7->XPlane.X * aForward) + (YX * aStrafe)));
    XX_YX2 = (v7->XPlane.X * aForward) + (YX * aStrafe);
    if ( sqrLngth == 1.0f )
    {
      XX_YX = (v7->XPlane.X * aForward) + (YX * aStrafe);
      v13 = XX_YX;
      XZ_YZ_ = (XZ * aForward) + (YZ * aStrafe);
      v14 = XZ_YZ_;
      XY_YY = (XY * aForward) + (YY * aStrafe);
      v15 = 0.0f;
    }
    else if ( sqrLngth >= SMALL_NUMBER )
    {
      invSqrt = 1.0f / fsqrt(sqrLngth);
      v53 = (3.0f - ((invSqrt * sqrLngth) * invSqrt)) * (invSqrt * 0.5f);
      XY_YY = ((XY * aForward) + (YY * aStrafe)) * v53;
      v13 = v53 * XX_YX2;
      v14 = XZ_YZ * v53;
      XX_YX = v53 * XX_YX2;
      XZ_YZ_ = XZ_YZ * v53;
      v15 = 0.0f;
    }
    else
    {
      v15 = 0.0f;
      v13 = 0.0f;
      v14 = 0.0f;
      XX_YX = 0.0f;
      XY_YY = 0.0f;
      XZ_YZ_ = 0.0f;
    }
    v35.X = 0.0f;
    v35.Y = 0.0f;
    v35.Z = 0.0f;
    if ( fabs(XX_YX) >= 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ || fabs(XY_YY) >= 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ || fabs(XZ_YZ_) >= 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
    {
      if ( this.SpeedSprintEnergy > 0.0f )
      {
        v17 = ((v14 * XZ) + (XY_YY * XY)) + (v13 * XX);
        v49 = v17;
        if ( v17 < 0.0f || ((v15 = 0.89999998f) is object && v17 > 0.89999998d) )
          v49 = v15;
        v50 = (float)(this.SpeedSprintEnergy - (1.0f - pow(v49, this.SpeedEnergyDecelerationExponent)) * (this.GroundSpeed - this.SpeedMaxBaseVelocity) / this.SpeedEnergyDecelerationTime * deltaTime);
        v18 = v50;
        this.SpeedSprintEnergy = v50;
        if ( v50 < 0.0f )
          v18 = 0.0f;
        v13 = XX_YX;
        v14 = XZ_YZ_;
        this.SpeedSprintEnergy = v18;
      }
      v19 = ((((v14 * YZ) + (XY_YY * YY)) + (v13 * YX)) * this.SpeedMinBaseVelocity) + (((this.SpeedMaxBaseVelocity - this.SpeedMinBaseVelocity) + this.SpeedSprintEnergy) * aStrafe);
      v55 = YY * v19;
      v56 = YZ * v19;
      v20 = v19 * YX;
      v21 = ((((v14 * XZ) + (XY_YY * XY)) + (XX_YX * XX)) * this.SpeedMinBaseVelocity) + (((this.SpeedMaxBaseVelocity - this.SpeedMinBaseVelocity) + this.SpeedSprintEnergy) * aForward);
      v54 = XZ * v21;
      v22 = ((this.Velocity.Z * YZ) + (this.Velocity.Y * YY)) + (this.Velocity.X * YX);
      v46 = YY * v22;
      v23 = v22;
      v48 = YZ * v22;
      v24 = ((this.Velocity.Z * XZ) + (this.Velocity.Y * XY)) + (this.Velocity.X * XX);
      v25 = v24 * XX;
      v26 = this.SpeedStrafeVelocityAccelerationFactor;
      v27 = XZ * v24;
      v28 = (XY * v21) - (XY * v24);
      v29 = this.SpeedWalkVelocityAccelerationFactor;
      v30 = (v28 * v29) + ((v55 - v46) * v26);
      v31 = (((v21 * XX) - v25) * v29) + ((v20 - (v23 * YX)) * v26);
      v36 = v31;
      v38 = v30;
      v42 = ((v54 - v27) * v29) + ((v56 - v48) * v26);
      if ( this.Physics != PHYS_Falling )
      {
        v32 = this.PhysicsVolume.GroundFriction;
        v36 = ((this.Velocity.X * v32) * 0.1f) + v31;
        v38 = ((this.Velocity.Y * v32) * 0.1f) + v30;
        v42 = ((this.Velocity.Z * v32) * 0.1f) + (((v54 - v27) * v29) + ((v56 - v48) * v26));
      }
      v39 = v38 * 10.0f;
      v43 = 10.0f * v42;
      v37 = (float)floor(v36 * 10.0f + 0.5f);
      v40 = (float)floor(v39 + 0.5f);
      v35.X = v37 * 0.1f;
      v35.Y = v40 * 0.1f;
      v35.Z = (float)floor(v43 + 0.5f) * 0.1f;
    }
    else
    {
      this.SpeedSprintEnergy = 0.0f;
    }
    result = retval;
    *retval = v35;
    return result;
  }

  public unsafe SoundCue  GetCharacterSound_Maybe(uint a2, int a3)
  {
    uint v3 = default; // edi
    uint v4 = default; // eax
    uint v5 = default; // edx
    uint v6 = default; // eax
    SoundCue result = default; // eax
  
    v3 = this.bDisableSkelControlSpring.AsBitfield(32);
    if ( (v3 & 0x100000) != 0 )
      return default;
    v4 = this.NoOfBreathingSounds;

    if( a2 >= v4 )
      v5 = v4 + a2;
    else if( ( v3 & 0x80000 ) == 0 )
    {
      v5 = 2 * a2 + 1;
    }
    else
    {
      v5 = 2 * a2;
    }

    if( a3 == default )
      v6 = (( v3 & 0x80000 ) != 0) ? 1u : 0u;
    else
      v6 = (( v3 & 0x80000 ) == 0) ? 1u : 0u;
    SetFromBitfield( ref this.bDisableSkelControlSpring, 32, v3 ^ ( v3 ^ ( v6 << 19 ) ) & 0x80000 );
    if( v5 >= this.CharacterSoundCues.Count)
    {
      return default;
    }
    else
    {
      return this.CharacterSoundCues[v5];
    }
  }

  public override unsafe void stepUp(in Vector GravDir, in Vector DesiredDir, in Vector Delta, ref CheckResult Hit)
  {
    //Vector *v5; // edi
    float v6 = default; // xmm4_4
    float v7 = default; // xmm5_4
    float v8 = default; // xmm6_4
    float v10 = default; // xmm3_4
    float v11 = default; // xmm2_4
    //CheckResult *v12; // eax
    float v13 = default; // xmm1_4
    //Vector *v14; // ebp
    float v15 = default; // xmm0_4
    float v16 = default; // xmm3_4
    float v17 = default; // xmm5_4
    bool v18 = default; // cf
    float v20 = default; // xmm1_4
    float v21 = default; // xmm0_4
    float v22 = default; // xmm3_4
    float v23 = default; // xmm4_4
    float v24 = default; // xmm5_4
    float v25 = default; // ecx
    float v26 = default; // edx
    PrimitiveComponent v28 = default; // eax
    float v29 = default; // eax
    float v30 = default; // edx
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
    //TdMove *v50; // edx
    bool v51 = default; // eax
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
    uint v110 = default; // [esp+7Ch] [ebp-E8h]
    float v111 = default; // [esp+80h] [ebp-E4h]
    float v112 = default; // [esp+84h] [ebp-E0h]
    int v113 = default; // [esp+94h] [ebp-D0h]
    float v114 = default; // [esp+98h] [ebp-CCh]
    Vector a2a = default; // [esp+9Ch] [ebp-C8h] BYREF
    float v116 = default; // [esp+ACh] [ebp-B8h]
    float v117 = default; // [esp+BCh] [ebp-A8h]
    CheckResult v118 = default; // [esp+CCh] [ebp-98h] BYREF
    int v119 = default; // [esp+114h] [ebp-50h]
    CheckResult v120 = default;//byte* v120 = stackalloc byte[76]; // [esp+118h] [ebp-4Ch] BYREF
  
    var v5 = GravDir;
    v6 = GravDir.X;
    v7 = GravDir.Y;
    v8 = GravDir.Z;
    v10 = this.MaxStepHeight + 2.0f;
    v11 = v8 * v10;
    v110 = 1;
    v113 = 1;
    ref var v12 = ref Hit;
    v13 = v7 * v10;
    ref var v14 = ref Hit.Normal;
    v15 = v6 * v10;
    v16 = (float)(Hit.Normal.Z * v8) + (float)(Hit.Normal.Y * v7);
    v17 = Hit.Normal.X * v6;
    v109.X = v15;
    v109.Y = v13;
    v109.Z = v11;
    if ( (float)((float)(v16 + v17) * -1.0f) >= 0.079999998d && ((v18 = Hit.Normal.Z < this.WalkableFloorZ) is object && (v107 = Hit.Normal.Z, v18) is object) )
    {
      if ( this.Physics == PHYS_Walking )
        goto LABEL_14;
      v20 = Delta.Y;
      v21 = Delta.Z;
      v111 = Delta.X;
      v110 = _LODWORD(v20);
      v114 = v21;
      Deltaa.Y = v20;
      Deltaa.X = v111;
      a2a.Z = (float)sqrt(v111 * v111 + v20 * v20 + v21 * v21) * v107;
      Deltaa.Z = a2a.Z + v21;
      GWorld.MoveActor(this, ref Deltaa, ref this.Rotation, 0, ref Hit);
      v110 = default;
    }
    else
    {
      v22 = v14.X;
      v23 = Hit.Normal.Y;
      v24 = Hit.Normal.Z;
      qmemcpy(ref v120, Hit, 0x4Cu);
      Deltaa.X = (float)(v15 * -1.0f) + (float)(v22 * 0.1f);
      Deltaa.Y = (float)(v13 * -1.0f) + (float)(v23 * 0.1f);
      Deltaa.Z = (float)(v11 * -1.0f) + (float)(v24 * 0.1f);
      GWorld.MoveActor(this, Deltaa, this.Rotation, 0, ref Hit);
      v25 = this.Location.Y;
      v26 = this.Location.Z;
      v108.X = this.Location.X;
      v108.Y = v25;
      v108.Z = v26;
      UWorldBridge.GetUWorld().DrawDebugTraces = true;
      GWorld.MoveActor(this, Delta, this.Rotation, 0, ref Hit);
      UWorldBridge.GetUWorld().DrawDebugTraces = false;
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
          a4a.X = this.Location.X + v28.Translation.X;
          a4a.Y = this.Location.Y + v28.Translation.Y;
          a4a.Z = this.Location.Z + v28.Translation.Z;
          this.Location = a4a;
        }
        v29 = this.Location.Y;
        Deltaa.X = this.Location.X;
        v30 = this.Location.Z;
        a4a.X = Deltaa.X + v109.X;
        Deltaa.Y = v29;
        a4a.Y = v29 + v109.Y;
        Deltaa.Z = v30;
        a4a.Z = v30 + v109.Z;
        GWorld.SingleLineCheck(ref v118, this, a4a, Deltaa, 8415, *this.GetCylinderExtent(&a2a), 0);
        if ( v118.Time < 1.0f && this.WalkableFloorZ > v118.Normal.Z )
        {
          v32 = v108.X;
          qmemcpy(ref Hit, v120, 0x4Cu);
          a4a.X = v32 - this.Location.X;
          a4a.Y = v108.Y - this.Location.Y;
          v33 = v108.Z - this.Location.Z;
          v113 = default;
          a4a.Z = v33;
          GWorld.MoveActor(this, ref a4a, ref this.Rotation, 0, ref v118);
        }
      }
      v5 = GravDir;
    }
    v12 = Hit;
  LABEL_14:
    v34 = v12.Time;
    if ( v34 >= 1.0f )
      goto LABEL_98; // Supposed to go through this to move above obsticle
    v35 = Delta.Y;
    v36 = (float)((float)(Hit.Normal.Z * v5.Z) + (float)(Hit.Normal.Y * v5.Y)) + (float)(v5.X * Hit.Normal.X);
    a4a.X = Delta.X;
    v37 = Delta.Z;
    v111.LODWORD(1);
    a4a.Y = v35;
    a4a.Z = v37;
    if ( (float)(v36 * -1.0f) < 0.079999998d && (float)((float)((float)((float)(Delta.X * Delta.X) + (float)(Delta.Y * Delta.Y)) + (float)(Delta.Z * Delta.Z)) * v34) > 144.0f )
    {
      if(v110 != default)
      {
        GWorld.MoveActor(this, ref v109, ref this.Rotation, 0, ref v12);
        v12 = Hit;
      }
      v38 = 1.0f - v12.Time;
      // v39 = *(void (__thiscall **)(TdPawn , Vector *, Vector *, Vector *, CheckResult *))(this.VfTableObject.Dummy + 528);
      Deltaa.X = Delta.X * v38;
      Deltaa.Y = Delta.Y * v38;
      Deltaa.Z = Delta.Z * v38;
      this.stepUp( v5, DesiredDir, Deltaa, ref v12);
      return;
    }
    if ( v113 != default && this.WalkableFloorZ > v12.Normal.Z )
    {
      if ( !this.IsHitActorTdPawn( ref v12 ) )// IsHitActorTdPawn 0x012C3790
      {
  LABEL_37:
        v12 = Hit;
        goto LABEL_38;
      }
      v40 = Delta.Z;
      v41 = Delta.Y;
      v42 = (float)((float)(Hit.Normal.Y * v41) + (float)(Hit.Normal.Z * v40)) + (float)(Hit.Normal.X * Delta.X);
      v43 = Hit.Normal.Z * v42;
      v44 = Delta.X - (float)(v14.X * v42);
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
          v49 = (int)this.MovementState;
          v51 = this.Moves.Data[v49] != null && (this.Moves.Data[v49].bDebugMove.AsBitfield(29) & 0x200000) != 0;
          v52 = UNKNOWN28(&Deltaa, v51, false, &a4a, ref Hit);
          v111.LODWORD(!v52 ? 1 : 0);
          if(v52 != default)
            goto LABEL_97;
          v12 = Hit;
          goto LABEL_38;
        }
        Deltaa.X = v44;
      }
      else
      {
        if ( v46 < SMALL_NUMBER )
        {
          Deltaa.X = 0.0f;
          Deltaa.Y = 0.0f;
  LABEL_31:
          Deltaa.Z = 0.0f;
          v49 = (int)this.MovementState;
          v51 = this.Moves.Data[v49] != null && (this.Moves.Data[v49].bDebugMove.AsBitfield(29) & 0x200000) != 0;
          v52 = UNKNOWN28(&Deltaa, v51, false, &a4a, ref Hit);
          v111.LODWORD(!v52 ? 1 : 0);
          if(v52 != default)
            goto LABEL_97;
          v12 = Hit;
          goto LABEL_38;
        }
        v112 = 3.0f;
        v107 = 0.5f;
        v48 = 1.0f / fsqrt(Deltaa.X);
        a2a.X = (float)(3.0f - (float)((float)(v48 * Deltaa.X) * v48)) * (float)(v48 * 0.5f);
        v45 = v45 * a2a.X;
        Deltaa.X = a2a.X * v44;
      }
      Deltaa.Y = v45;
      Deltaa.Z = 0.0f;
      v49 = (int)this.MovementState;
      var v50 = this.Moves.Data;
      v51 = v50[v49] != null && (v50[v49].bDebugMove.AsBitfield(29) & 0x200000) != 0;
      v52 = UNKNOWN28(&Deltaa, v51, false, &a4a, ref Hit);
      v111.LODWORD(!v52 ? 1 : 0);
      if(v52 != default)
        goto LABEL_97;
      v12 = Hit;
      goto LABEL_38;
    }
  LABEL_38:
    this.processHitWall(
      Hit.Normal,
      v12.Actor,
      v12.Component);
    if ( this.Physics == PHYS_Falling )
      return;
    Hit.Normal.Z = 0.0f;
    Deltaa.X = (float)((float)(Hit.Normal.X * Hit.Normal.X) + (float)(Hit.Normal.Y * Hit.Normal.Y)) + (float)(Hit.Normal.Z * Hit.Normal.Z);
    if ( Deltaa.X == 1.0f )
    {
      v53 = v14.X;
      v54 = Hit.Normal.Y;
      v55 = Hit.Normal.Z;
    }
    else
    {
      if ( Deltaa.X >= SMALL_NUMBER )
      {
        v112 = 3.0f;
        v107 = 0.5f;
        v56 = 1.0f / fsqrt(Deltaa.X);
        a2a.X = (float)(3.0f - (float)((float)(v56 * Deltaa.X) * v56)) * (float)(v56 * 0.5f);
        Deltaa.X = a2a.X * v14.X;
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
    v14.X = v53;
    Hit.Normal.Y = v54;
    Hit.Normal.Z = v55;
    v57 = Delta.Z;
    v58 = Delta.Y;
    v59 = Delta.X;
    v60 = (float)((float)(Hit.Normal.Y * v58) + (float)(Hit.Normal.Z * v57)) + (float)(Delta.X * Hit.Normal.X);
    v61 = v58 - (float)(Hit.Normal.Y * v60);
    v62 = v57 - (float)(Hit.Normal.Z * v60);
    v63 = 1.0f - Hit.Time;
    Deltaa.X = (float)(Delta.X - (float)(v14.X * v60)) * v63;
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
      v65 = Delta.Y;
      v66 = Delta.Z;
      Deltaa.X = Delta.X;
      Deltaa.Y = v65;
      Deltaa.Z = v66;
    }
    else
    {
      if ( v64 < SMALL_NUMBER )
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
      Deltaa.X = v108.X * Delta.X;
      v69 = v108.X * Delta.Z;
      Deltaa.Y = v108.X * Delta.Y;
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
    else if ( v73 >= SMALL_NUMBER )
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
      v78 = Delta.Y * Delta.Y + Delta.X * Delta.X;
      v79 = Delta.Z;
      v117 = v77;
      v114 = (float)(sqrt(v79 * v79 + v78));
      if ( v77 == 1.0f )
      {
        Deltaa = a4a;
        v80 = a4a.X;
        v81 = a4a.Y;
        v82 = a4a.Z;
      }
      else if ( v77 >= SMALL_NUMBER )
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
    if ( (float)((float)((float)(v72 * Delta.X) + (float)(v70 * Delta.Z)) + (float)(v71 * Delta.Y)) >= 0.0f )
    {
      GWorld.MoveActor(this, ref a4a, ref this.Rotation, 0, ref Hit);
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
            if ( v87 < SMALL_NUMBER )
            {
              Deltaa.X = 0.0f;
              Deltaa.Y = 0.0f;
              goto LABEL_74;
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
      GWorld.MoveActor(this, ref v109, ref this.Rotation, 0, ref v12);
    return;
    LABEL_74:
    Deltaa.Z = 0.0f;
    LABEL_75:
    v89 = Hit.Normal.Y;
    v90 = v14.X;
    v91 = (float)(v90 * v90) + (float)(v89 * v89);
    v117 = v91;
    if ( v91 == 1.0f )
    {
      if ( Hit.Normal.Z == 0.0f )
      {
        v92 = Hit.Normal.Y;
        v93 = Hit.Normal.Z;
        v108.X = v14.X;
        v108.Y = v92;
        v108.Z = v93;
        goto LABEL_83;
      }
      v108.X = v90;
      v108.Y = v89;
    }
    else if ( v91 >= SMALL_NUMBER )
    {
      v116 = 3.0f;
      v107 = 0.5f;
      v94 = 1.0f / fsqrt(v117);
      v112 = (float)(3.0f - (float)((float)(v94 * v117) * v94)) * (float)(v94 * 0.5f);
      v95 = v112 * Hit.Normal.Y;
      v108.X = v112 * v14.X;
      v108.Y = v95;
    }
    else
    {
      v108.X = 0.0f;
      v108.Y = 0.0f;
    }
    v108.Z = 0.0f;
    goto LABEL_83;
  LABEL_83:
    if ( v108.Z * Deltaa.Z + v108.Y * Deltaa.Y + v108.X * Deltaa.X < -0.707f && this.IsHitActorTdPawn( ref Hit) )// IsHitActorTdPawn
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
      else if ( v100 >= SMALL_NUMBER )
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
      v104.LODWORD(!UNKNOWN28(&Deltaa, false, true, &a4a, ref Hit));
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
      TwoWallAdjust(DesiredDir, ref a4a, v14, a2a, Hit.Time);
      GWorld.MoveActor(this, ref a4a, ref this.Rotation, 0, ref Hit);
      v12 = Hit;
      goto LABEL_98;
    }
    goto LABEL_97;
  }

  public unsafe void SyncLegMovement()
  {
    //ref array<AnimNodeSynch.SynchGroup> v1; // edx
    int v2 = default; // ebp
    //ref array<AnimNodeSynch.SynchGroup> v3; // edi
    int v4 = default; // esi
    //AnimNodeSynch.SynchGroup *v5; // eax
    //AnimNodeSynch.SynchGroup *v6; // ecx
  
    ref var v1 = ref this.MasterSync3p.Groups;
    v2 = default;
    ref var v3 = ref this.MasterSync1p.Groups;
    if ( this.MasterSync3p.Groups.Count > 0 )
    {
      v4 = default;
      do
      {
        ref var v5 = ref v1[v4];
        ref var v6 = ref v3[v4];
        if ( (v5.bUseSharedMasterControlNode.AsBitfield(1) & 1) != default )
        {
          v5.SharedMasterRelativePosition = v6.SharedMasterRelativePosition;
          v5.SharedMasterMoveDelta = v6.SharedMasterMoveDelta;
        }
        ++v2;
        ++v4;
      }
      while ( v2 < v1.Count );
    }
  }



  public unsafe void OffsetMeshXY( Vector Offset, bool bWorldSpace ) => OffsetMeshXY(Offset, bWorldSpace ? 1 : 0);
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
  
    FRotationMatrix(&DstMatrix, this.Rotation);
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
    int v15 = default; // edx
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

    fixed( float* timePtr = ASTimeData.Data )
    {
      fixed( float* distPtr = ASDistanceData.Data )
      {
      

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
          v11 = timePtr;
          v12 = distPtr;
          v31 = v10 - 2;
          v30 = v10;
          v13 = v10 + v6 - 2;
          v14 = 4 * (v10 - 2);
          v32 = 1 - v6;
          v15 = (int)(((uint)(v7 - 4) >> 2) + 1);
          v33 = -1 - v6;
          v36 = 4 * v15;
          do
          {
            v16 = v14 + 8;
            if ( v30 < 0 )
              v16 = v16 + (4 * v6);
            v17 = *(float *)((byte *)v11 + v16) + v4;
            v18 = *(float *)((byte *)v12 + v16) + v5;
            v19 = v14 + 4;
            if ( v13 + v32 < 0 )
              v19 = v19 + (4 * v38);
            v20 = *(float *)((byte *)v11 + v19) + v17;
            v21 = *(float *)((byte *)v12 + v19) + v18;
            v22 = v14;
            if ( v31 < 0 )
              v22 = v14 + 4 * v38;
            v23 = v14 - 4;
            if ( v13 + v33 < 0 )
              v23 = v23 + (4 * v38);
            v30 = v30 - (4);
            v31 = v31 - (4);
            v4 = *(float *)((byte *)v11 + v23) + (float)(*(float *)((byte *)v11 + v22) + v20);
            v24 = *(float *)((byte *)v12 + v23);
            v6 = v38;
            v14 = v14 - (16);
            v13 = v13 - (4);
            --v15;
            v5 = v24 + (float)(*(float *)((byte *)v12 + v22) + v21);
          }
          while(v15 != default);
          v7 = v35;
          v9 = v36;
        }
        if ( v9 < v7 )
        {
          v39 = timePtr;
          v37 = distPtr;
          v25 = this.ASSlotPointer - v9;
          v26 = v25 + v6;
          v27 = 4 * v25;
          v28 = v7 - v9;
          do
          {
            v29 = v27;
            if ( v25 < 0 )
              v29 = v27 + 4 * v6;
            v4 = *(float *)((byte *)v39 + v29) + v4;
            v27 = v27 - (4);
            --v25;
            --v26;
            --v28;
            v5 = *(float *)((byte *)v37 + v29) + v5;
          }
          while(v28 != default);
        }
        if ( v5 == 0.0f )
          result = 0.0f;
        else
          result = (float)(v5 / v4);
        return (float)(result);
      }
    }
  }



  public unsafe void UpdateLegToWorldMatrix( int Yaw ) => UpdateLegToWorldMatrix((short)Yaw);
  public unsafe void UpdateLegToWorldMatrix(short Yaw)
  {
    uint v3 = default; // eax
    Matrix *v4; // eax
    Matrix *v5; // [esp-4h] [ebp-A4h]
    Rotator a2 = default; // [esp+14h] [ebp-8Ch] BYREF
    Matrix outM = default; // [esp+20h] [ebp-80h] BYREF
    Matrix v8 = default; // [esp+60h] [ebp-40h] BYREF
  
    v3 = (ushort)(Yaw - LOWORD(this.Rotation.Yaw));
    if ( v3 > 0x7FFF )
      v3 = v3 - (0x10000);
    a2.Pitch = (int)v3;
    a2.Yaw = default;
    a2.Roll = default;
    fixed( Matrix* ptr = & this.Mesh.LocalToWorld )
    {
      v5 = ptr;
      v4 = FRotationMatrix(&v8, a2);
      qmemcpy(ref this.Mesh.LocalToLegRotatedWorld, v4->Mult(&outM, v5), sizeof(Matrix));
    }
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

  public unsafe EMoveAimMode GetAimMode(bool a2)
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
          return (EMoveAimMode)2;
        v8 = this.WeaponAnimState;
        if ( v8 == WS_Ready || v8 == WS_Throwing )
          return (EMoveAimMode)1;
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
          v5 = (MoveAimMode)(((((byte)v7 - 1) >> 31) | ((1 - (byte)v7) >> 31)) + 2);
        }
        if ( v10 == AW_AgainstWallLeft )
          return (MoveAimMode)(((((byte)v5 - 3) >> 31) | ((3 - (byte)v5) >> 31)) & 2);
        if ( v10 == AW_AgainstWallRight )
          v5 = (MoveAimMode)((int)v5 + ((1 - (int)v5) & ((((byte)v5 - 2) >> 31) | ((2 - (byte)v5) >> 31))));
      }
    }
    return v5;
  }

  public unsafe int PlayCustomAnimInternal(TdAnimNodeSlot tdSlot, name AnimName, float Rate, float BlendInTime, float BlendOutTime, bool bLooping, bool bOverride, bool bRootMotion, bool bRootRotation)
  {
    AnimNodeSequence v11 = default; // eax
    TdAnimNodeSequence v12 = default; // eax
    AnimNodeSequence.ERootBoneAxis v14 = default; // [esp+8h] [ebp-14h]
    AnimNodeSequence.ERootRotationOption v15 = default; // [esp+8h] [ebp-14h]
    AnimNodeSequence.ERootBoneAxis v16 = default; // [esp+Ch] [ebp-10h]
    AnimNodeSequence.ERootRotationOption v17 = default; // [esp+Ch] [ebp-10h]
    AnimNodeSequence.ERootBoneAxis v18 = default; // [esp+10h] [ebp-Ch]
    AnimNodeSequence.ERootRotationOption v19 = default; // [esp+10h] [ebp-Ch]
  
    if ( !tdSlot || tdSlot.PlayCustomAnim(AnimName, Rate, BlendInTime, BlendOutTime, bLooping, bOverride) == 0.0f )
      return 0;
    if ( tdSlot == this.CustomCameraNode || tdSlot == this.CustomWeaponNode1p )
    {
      v11 = tdSlot.GetCustomAnimNodeSeq();
      v12 = E_TryCastTo<TdAnimNodeSequence>(v11);
      SetFromBitfield(ref v12.bSnapToKeyFrames, 12, v12.bSnapToKeyFrames.AsBitfield(12) | (0x40u));
    }
    if(bRootMotion != default)
    {
      v18 = RBA_Translate;
      v16 = RBA_Translate;
      v14 = RBA_Translate;
    }
    else
    {
      v18 = RBA_Default;
      v16 = RBA_Default;
      v14 = RBA_Default;
    }
    tdSlot.SetRootBoneAxisOption(v14, v16, v18);
    if(bRootRotation != default)
    {
      v19 = RRO_Extract;
      v17 = RRO_Extract;
      v15 = RRO_Extract;
    }
    else
    {
      v19 = RRO_Discard;
      v17 = RRO_Discard;
      v15 = RRO_Discard;
    }
    tdSlot.SetRootBoneRotationAxisOption(v15, v17, v19);
    tdSlot.SetActorAnimEndNotification(true);
    tdSlot.SetCauseActorCeaseRelevant(true);// SetCauseActorCeaseRelevant
    return 1;
  }

  public unsafe void _StopCustomAnim(ECustomNodeType Type, float BlendOutTime)
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
          v4 = v8;
          v9.StopCustomAnim(BlendOutTime);
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
          v4 = v8;
          v9.StopCustomAnim(BlendOutTime);
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
          v4 = v8;
          v9.StopCustomAnim(BlendOutTime);
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
          v4 = v8;
          v9.StopCustomAnim(BlendOutTime);
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
          v4 = v8;
          v9.StopCustomAnim(BlendOutTime);
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
          v4 = v8;
          v9.StopCustomAnim(BlendOutTime);
        }
        break;
      case (int)CNT_Camera:
        v20 = this.CustomCameraNode;
        if(v20 != default)
        {
          v21 = v20.GetCustomAnimNodeSeq();
          v9 = this.CustomCameraNode;
          v3 = v21;
          v4 = v8;
          v9.StopCustomAnim(BlendOutTime);
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
          v4 = v8;
          v9.StopCustomAnim(BlendOutTime);
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

    var anim = v3 ?? v4; // equivalent to: (uint)v3 | (v3 == default ? (uint)v4 : 0)
    if ( anim )
    {
      v25 = this.Moves[this.MovementState];
      if ( v25.CurrentCustomAnimName == anim.AnimSeqName )
        v25.CallOnAnimationStopped(anim);
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
    v2 = FRotationMatrix(&v18, this.Rotation);
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
    return GWorld.EncroachingWorldGeometry(ref a2, a3, a4, true) == false;
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
//    Class v7 = default; // edi
//    int v8 = default; // eax
//    MaterialInterface v9 = default; // edi
//    int j = default; // ebx
//    Class v11 = default; // edi
//    int v12 = default; // eax
//    MaterialInterface v13 = default; // edi
//    TdSkeletalMeshComponent v14 = default; // eax
//    SkeletalMesh v15 = default; // eax
//    int v16 = default; // ebx
//    Class v17 = default; // edi
//    int v18 = default; // eax
//    MaterialInterface v19 = default; // edi
//    int result = default; // eax
//    int v21 = default; // ebx
//    Class v22 = default; // edi
//    int v23 = default; // eax
//    MaterialInterface v24 = default; // edi
//  
//    v2 = sub_F358A0((int)this.SceneCapture);
//    v3 = this.DrawFrustum;
//    if ( v3 && v2 )
//    {
//      v3.FrustumAngle = *(float *)(v2 + 140);
//      v4 = *(float *)(v2 + 144);
//      if ( v4 < 50.0f )
//        v4 = 50.0f;
//      this.DrawFrustum.FrustumStartDist = v4;
//      v5 = *(float *)(v2 + 148);
//      if ( v5 < 200.0f )
//        v5 = 200.0f;
//      this.DrawFrustum.FrustumEndDist = v5;
//      if ( *(_DWORD *)(v2 + 128) )
//        this.DrawFrustum.FrustumAspectRatio = (float)*(int *)(*(_DWORD *)(v2 + 128) + 188) / (float)*(int *)(*(_DWORD *)(v2 + 128) + 192);
//    }
//    for ( i = default; i < this.Mesh3p.SkeletalMesh.Materials.Count; ++i )
//    {
//      if ( !dword_1FFD744 )
//      {
//        dword_1FFD744 = (Class )sub_E58D70((int)L"Engine");
//        sub_E525E0();
//      }
//      v7 = dword_1FFD744;
//      v8 = sub_1101A90();
//      if ( v8 == -1 )
//        v8 = sub_1101A90();
//      v9 = (MaterialInterface )sub_1110DD0((int)v7, v8, 0, 0, 0, 0, 0, dword_20186F4, 0, 0);
//      (*(void (__thiscall **)(MaterialInterface , MaterialInterface ))(v9.VfTableObject.Dummy + 356))(v9, this.Mesh3p.SkeletalMesh.Materials[i]);
//      (*(void (__thiscall **)(MaterialInterface , int, int, _DWORD))(v9.VfTableObject.Dummy + 372))(v9, dword_2056844, dword_2056848, *(_DWORD *)(v2 + 128));
//      sub_D36AF0(this.Mesh3p, i, v9);
//    }
//    for ( j = default; j < this.Mesh.SkeletalMesh.Materials.Count; ++j )
//    {
//      if ( !dword_1FFD744 )
//      {
//        dword_1FFD744 = (Class )sub_E58D70((int)L"Engine");
//        sub_E525E0();
//      }
//      v11 = dword_1FFD744;
//      v12 = sub_1101A90();
//      if ( v12 == -1 )
//        v12 = sub_1101A90();
//      v13 = (MaterialInterface )sub_1110DD0((int)v11, v12, 0, 0, 0, 0, 0, dword_20186F4, 0, 0);
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
//            if ( !dword_1FFD744 )
//            {
//              dword_1FFD744 = (Class )sub_E58D70((int)L"Engine");
//              sub_E525E0();
//            }
//            v17 = dword_1FFD744;
//            v18 = sub_1101A90();
//            if ( v18 == -1 )
//              v18 = sub_1101A90();
//            v19 = (MaterialInterface )sub_1110DD0((int)v17, v18, 0, 0, 0, 0, 0, dword_20186F4, 0, 0);
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
//            if ( !dword_1FFD744 )
//            {
//              dword_1FFD744 = (Class )sub_E58D70((int)L"Engine");
//              sub_E525E0();
//            }
//            v22 = dword_1FFD744;
//            v23 = sub_1101A90();
//            if ( v23 == -1 )
//              v23 = sub_1101A90();
//            v24 = (MaterialInterface )sub_1110DD0((int)v22, v23, 0, 0, 0, 0, 0, dword_20186F4, 0, 0);
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
  public unsafe void DoFootPlacement_Maybe(float DeltaSeconds)
  {
    float v3 = default; // xmm0_4
    float v4 = default; // xmm0_4
    EMovement v5 = default; // cl
    float v6 = default; // eax
    Vector *rotationFacingDir; // eax
    float v8 = default; // edx
    short headingAngleOf = default; // cx
    int v10 = default; // eax
    uint v11 = default; // edx
    int v12 = default; // ebx
    uint v13 = default; // edx
    int v14 = default; // edi
    double velMult = default; // st7
    float velMultClamped = default; // xmm0_4
    float timeAndVelMult = default; // xmm1_4
    float rotSlowT = default; // xmm0_4
    float timeVelAndSlowMult = default; // xmm0_4
    int legRotCurrent = default; // edx
    float timeVelStateAndSlowMult = default; // xmm0_4
    int currentToHeadingDiff = default; // ecx
    uint newRotFromVel = default; // eax
    int v24 = default; // edx
    int v25 = default; // eax
    int v26 = default; // eax
    float v27 = default; // [esp+Ch] [ebp-28h]
    Vector horVel = default; // [esp+10h] [ebp-24h] BYREF
    Vector horDir = default; // [esp+1Ch] [ebp-18h] BYREF
    Vector a2a = default; // [esp+28h] [ebp-Ch] BYREF
  
    v3 = this.LegRotationSlowTimer;
    if ( v3 > 0.0f )
    {
      v4 = v3 - DeltaSeconds;
      if ( v4 <= 0.0f )
        v4 = 0.0f;
      this.LegRotationSlowTimer = v4;
    }
    v5 = this.MovementState;
    if ( v5 != MOVE_BotStartWalking && v5 != MOVE_BotStartRunning && sqrt(this.Velocity.Y * this.Velocity.Y + this.Velocity.X * this.Velocity.X) > 20.0f || (this.Moves[v5].bDebugMove.AsBitfield(29) & 0x20000) != default )
    {
      v6 = this.Velocity.X;
      horVel.Y = this.Velocity.Y;
      horVel.X = v6;
      horVel.Z = 0.0f;
      horVel.Normalize();
      if ( this.Physics == PHYS_Falling )
      {
        rotationFacingDir = this.Rotation.Vector(&a2a);
        v8 = rotationFacingDir->Y;
        horDir.X = rotationFacingDir->X;
        horDir.Y = v8;
        horDir.Z = 0.0f;
        horDir.Normalize();
        horVel = horDir;
      }
      headingAngleOf = (short)E_GetHeadingAngle(&horVel);
      v10 = (ushort)(headingAngleOf - LOWORD(this.Rotation.Yaw));
      if ( (uint)v10 > 0x7FFF )
        v10 = v10 - (0x10000);
      v11 = this.bDisableSkelControlSpring.AsBitfield(32);
      if ( ((v11 >> 3) & 1) != default && (((v12 = this.LegAngleLimitFudge) is object && v10 > v12 + this.GoBackLegAngleLimitMax) || v10 < this.GoBackLegAngleLimitMin - v12) )
      {
        v13 = v11 & 0xFFFFFFF7;
      }
      else
      {
        if ( ((this.bDisableSkelControlSpring.AsBitfield(32) >> 3) & 1) != default )
          goto LABEL_22;
        v14 = this.LegAngleLimitFudge;
        if ( v10 >= this.GoBackLegAngleLimitMax - v14 || v10 <= v14 + this.GoBackLegAngleLimitMin )
          goto LABEL_22;
        v13 = v11 | 8;
      }
      SetFromBitfield(ref this.bDisableSkelControlSpring, 32, v13);
      this.LegRotationSlowTimer = 0.40000001f;
  LABEL_22:
      if ( (this.bDisableSkelControlSpring.AsBitfield(32) & 8) == default )
        headingAngleOf = (short)(headingAngleOf + (0x8000));
      velMult = sqrt(this.Velocity.Y * this.Velocity.Y + this.Velocity.X * this.Velocity.X) * 0.0049999999d;
      if ( velMult < 0.1f )
      {
        velMultClamped = 0.1f;
      }
      else
      {
        velMultClamped = (float)velMult;
        v27 = (float)velMult;
        if ( v27 > 1.0f )
          velMultClamped = 1.0f;
      }
      timeAndVelMult = velMultClamped * DeltaSeconds;
      if ( this.LegRotationSlowTimer <= 0.0f )
        rotSlowT = 1.0f;
      else
        rotSlowT = (float)(0.40000001d);
      timeVelAndSlowMult = rotSlowT * timeAndVelMult;
      if ( this.MovementState == MOVE_Crouch )
        timeVelAndSlowMult = timeVelAndSlowMult * 0.5f;
      if ( this.Physics == PHYS_Falling )
        timeVelAndSlowMult = timeVelAndSlowMult * 0.25f;
      legRotCurrent = this.LegRotation;
      timeVelStateAndSlowMult = timeVelAndSlowMult * 8.0f;
      currentToHeadingDiff = (ushort)(headingAngleOf - legRotCurrent);
      if ( currentToHeadingDiff > 0x7FFF )
        currentToHeadingDiff = currentToHeadingDiff - (0x10000);
      if ( timeVelStateAndSlowMult >= 1.0f )
        timeVelStateAndSlowMult = 1.0f;
      newRotFromVel = (ushort)(legRotCurrent + (int)(float)((float)currentToHeadingDiff * timeVelStateAndSlowMult));
      if ( newRotFromVel > 0x7FFF )
        newRotFromVel = newRotFromVel - (0x10000);
      this.LegRotation = (int)newRotFromVel;
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
    //Vector *v4; // edi
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
    Vector v95 = default; // [esp+48h] [ebp-1C8h] BYREF
    Vector v96 = default; // [esp+54h] [ebp-1BCh] BYREF
    Vector v97 = default; // [esp+60h] [ebp-1B0h] BYREF
    Vector v98 = default; // [esp+6Ch] [ebp-1A4h]
    float v99 = default; // [esp+78h] [ebp-198h]
    float v100 = default; // [esp+7Ch] [ebp-194h]
    uint v101 = default; // [esp+80h] [ebp-190h]
    float v102 = default; // [esp+84h] [ebp-18Ch]
    float v103 = default; // [esp+88h] [ebp-188h]
    float v104 = default; // [esp+8Ch] [ebp-184h]
    float v105 = default; // [esp+90h] [ebp-180h]
    float v106 = default; // [esp+94h] [ebp-17Ch]
    float v107 = default; // [esp+98h] [ebp-178h]
    float v108 = default; // [esp+9Ch] [ebp-174h]
    float v109 = default; // [esp+A0h] [ebp-170h]
    Vector v110 = default; // [esp+A4h] [ebp-16Ch] BYREF
    CheckResult Hit = default; // [esp+B0h] [ebp-160h] BYREF
    int v112 = default; // [esp+F8h] [ebp-118h]
    Vector v113 = default; // [esp+FCh] [ebp-114h] BYREF
    Vector v114 = default; // [esp+108h] [ebp-108h] BYREF
    Vector v115 = default; // [esp+114h] [ebp-FCh] BYREF
    Vector a4 = default; // [esp+120h] [ebp-F0h] BYREF
    float v117 = default; // [esp+12Ch] [ebp-E4h]
    float v118 = default; // [esp+130h] [ebp-E0h]
    float v119 = default; // [esp+134h] [ebp-DCh]
    float v120 = default; // [esp+138h] [ebp-D8h]
    float v121 = default; // [esp+13Ch] [ebp-D4h]
    float v122 = default; // [esp+140h] [ebp-D0h]
    Vector a7 = default; // [esp+144h] [ebp-CCh] BYREF
    int v124 = default; // [esp+150h] [ebp-C0h]
    int v125 = default; // [esp+154h] [ebp-BCh]
    Vector a5 = default; // [esp+158h] [ebp-B8h] BYREF
    Vector v127 = default; // [esp+164h] [ebp-ACh] BYREF
    Vector v128 = default; // [esp+170h] [ebp-A0h] BYREF
    Vector v129 = default; // [esp+17Ch] [ebp-94h] BYREF
    Vector v130 = default; // [esp+188h] [ebp-88h] BYREF
    float v131 = default; // [esp+194h] [ebp-7Ch]
    float v132 = default; // [esp+1A4h] [ebp-6Ch]
    Vector v133 = default; // [esp+1B4h] [ebp-5Ch] BYREF
    float v134 = default; // [esp+1C4h] [ebp-4Ch]
    int v135 = default; // [esp+1D4h] [ebp-3Ch]
    float v136 = default; // [esp+1E4h] [ebp-2Ch]
    float v137 = default; // [esp+1F4h] [ebp-1Ch]
    Vector a2a = default; // [esp+204h] [ebp-Ch] BYREF
  
    if ( !this.Controller && (this.bIsFemale.AsBitfield(20) & 0x8000) == default )
      return;
    ref var v4 = ref this.Floor;
    v92 = (float)(atan2(this.Floor.Y, this.Floor.X) * 10430.222f);
    v5 = this.Floor.X;
    v125 = (int)v92;
    if ( fabs(v5) >= 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ || fabs(this.Floor.Y) >= 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ || fabs(this.Floor.Z) >= 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
    {
      v9 = this.Acceleration.Y;
      v10 = this.Acceleration.Z;
      v106 = this.Moves[this.MovementState].FrictionModifier;
      v11 = v9 * v9;
      v12 = v10 * v10;
      v13 = 0.0f;
      v131 = (float)((float)(this.Acceleration.X * this.Acceleration.X) + v11) + v12;
      if ( v131 == 1.0f )
      {
        v14 = this.Acceleration.Y;
        v15 = this.Acceleration.Z;
        v95.X = this.Acceleration.X;
        v95.Y = v14;
        v95.Z = v15;
      }
      else
      {
        if ( v131 >= SMALL_NUMBER )
        {
          v132 = 3.0f;
          v16 = 1.0f / fsqrt(v131);
          v133.X = (float)(3.0f - (float)((float)(v16 * v131) * v16)) * (float)(v16 * 0.5f);
          v95.X = this.Acceleration.X * v133.X;
          v95.Y = this.Acceleration.Y * v133.X;
          v13 = this.Acceleration.Z * v133.X;
        }
        else
        {
          v95.X = 0.0f;
          v95.Y = 0.0f;
        }
        v95.Z = v13;
      }
      this.CalcVelocity( ref v95, (a2), this.GroundSpeed * 4.0f, ((v106)), 0, 0, 0);// CalcVelocity
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
      v103 = v20;
      v22 = this.Location.X;
      v104 = v17;
      v23 = this.Location.Y;
      v105 = v18;
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
      v112 = default;
      v107 = v22;
      v108 = v23;
      v109 = v24;
      v93 = a2;
      v106 = v21 * v21;
      if( a2 <= 0.0f )
      {
        goto LABEL_64;
      }

      LABEL_LOOP:
      //while(1 != default)
      //{
        if ( a3 >= 8 )
          goto LABEL_64;
        ++a3;
        if ( v19 <= 0.050000001d )
          goto LABEL_OUTLOOP;
        if ( this.IsHumanControlled() )
        {
          v19 = v93;
        }
        else
        {
          v25 = this.CylinderComponent.CollisionRadius * this.CylinderComponent.CollisionRadius;
          if ( v106 < v25 )
            v25 = v106;
          v19 = v93;
          if ( (float)((float)((float)((float)((float)(v103 * v103) + (float)(v105 * v105)) + (float)(v104 * v104)) * v93) * v93) <= v25 )
            goto LABEL_OUTLOOP;
        }
        v26 = v19 * 0.5f;
        if ( (float)(v19 * 0.5f) >= 0.050000001d )
          v26 = (float)(0.050000001d);
  LABEL_23:
        v93 = v19 - v26;
        Delta.X = v103 * v26;
        Delta.Y = v104 * v26;
        Delta.Z = v105 * v26;
        GWorld.MoveActor(this, ref Delta, ref this.Rotation, 0, ref Hit);
        v27 = Hit.Time;
        if( Hit.Time >= 1.0f )
        {
          v28 = 0.0f;
          goto LABEL_40;
        }
        if ( (this.bDisableSkelControlSpring.AsBitfield(32) & 0x400) != default )
        {
          a5.X = Delta.X * (float)(1.0f - Hit.Time);
          a5.Y = Delta.Y * (float)(1.0f - Hit.Time);
          a5.Z = Delta.Z * (float)(1.0f - Hit.Time);
          UNKNOWN31(ref this.Floor, ref Delta, ref a5, ref Hit);
  LABEL_39:
          v28 = 0.0f;
          goto LABEL_40;
        }
        v28 = 0.0f;
        v110.Z = this.MaxWallStepHeight;
        v29 = Hit.Normal.Z <= this.WalkableFloorZ;
        v98 = Hit.Normal;
        v110.X = 0.0f;
        v110.Y = 0.0f;
        if ( !v29 )
        {
          v128.X = (float)(1.0f - Hit.Time) * Delta.X;
          v128.Y = Delta.Y * (float)(1.0f - Hit.Time);
          v128.Z = Delta.Z * (float)(1.0f - Hit.Time);
          GWorld.MoveActor(this, ref v110, ref this.Rotation, 0, ref Hit);
          GWorld.MoveActor(this, ref v128, ref this.Rotation, 0, ref Hit);
          if ( this.WalkableFloorZ > Hit.Normal.Z && Hit.Time < 1.0f )
            v98 = Hit.Normal;
          v129.X = -0.0f - v110.X;
          v129.Y = -0.0f - v110.Y;
          v129.Z = -0.0f - v110.Z;
          GWorld.MoveActor(this, ref v129, ref this.Rotation, 0, ref Hit);
          v27 = Hit.Time;
          v28 = 0.0f;
        }
        if ( this.WalkableFloorZ > v98.Z )
        {
          v130.X = Delta.X * (float)(1.0f - v27);
          v130.Y = Delta.Y * (float)(1.0f - v27);
          v130.Z = Delta.Z * (float)(1.0f - v27);
          GWorld.MoveActor(this, ref v110, ref this.Rotation, 0, ref Hit);
          GWorld.MoveActor(this, ref v130, ref this.Rotation, 0, ref Hit);
          if ( this.WalkableFloorZ > Hit.Normal.Z && Hit.Time < 1.0f )
          {
            v30 = (float)((float)(this.Velocity.Y * Hit.Normal.Y) + (float)(this.Velocity.Z * Hit.Normal.Z)) + (float)(this.Velocity.X * Hit.Normal.X);
            v31 = Hit.Normal.Y * v30;
            v32 = v30 * Hit.Normal.Z;
            v33 = this.Velocity.X - (float)((float)((float)((float)(this.Velocity.Y * Hit.Normal.Y) + (float)(this.Velocity.Z * Hit.Normal.Z)) + (float)(this.Velocity.X * Hit.Normal.X)) * Hit.Normal.X);
            v34 = this.Velocity.Y - v31;
            v35 = this.Velocity.Z;
            SetFromBitfield(ref this.bDisableSkelControlSpring, 32, this.bDisableSkelControlSpring.AsBitfield(32) | (0x400u));
            v117 = v33;
            v36 = v35 - v32;
            v37 = this.Velocity.Z;
            this.Velocity.X = v33;
            v118 = v34;
            this.Velocity.Y = v34;
            this.Velocity.Z = v37;
            v38 = this.Velocity.Y;
            v39 = this.Velocity.Z;
            v103 = this.Velocity.X;
            v119 = v36;
            v104 = v38;
            v105 = v39;
            this.ReachedWall();
            SetFromBitfield(ref this.bCollideComplex, 20, this.bCollideComplex.AsBitfield(20) | (0x100u));
          }
          v127.X = -0.0f - v110.X;
          v127.Y = -0.0f - v110.Y;
          v127.Z = -0.0f - v110.Z;
          GWorld.MoveActor(this, ref v127, ref this.Rotation, 0, ref Hit);
          v28 = 0.0f;
          goto LABEL_40;
        }
  LABEL_40:
        if ( (this.bDisableSkelControlSpring.AsBitfield(32) & 0x400) != default )
        {
          v40 = this.Velocity.Y;
          v41 = this.Velocity.X;
          v42 = (float)(v41 * v41) + (float)(v40 * v40);
          v134 = v42;
          if ( v42 == 1.0f )
          {
            if ( this.Velocity.Z == 0.0f )
            {
              v43 = this.Velocity.Y;
              v44 = this.Velocity.Z;
              v120 = this.Velocity.X;
              v41 = v120;
              v121 = v43;
              v40 = v43;
              v122 = v44;
              v28 = v44;
            }
          }
          else if ( v42 >= SMALL_NUMBER )
          {
            v137 = 3.0f;
            v124 = 1056964608;
            v45 = fsqrt(v134);
            v131 = (float)(3.0f - (float)((float)((float)(1.0f / v45) * v134) * (float)(1.0f / v45))) * (float)((float)(1.0f / v45) * 0.5f);
            v41 = v131 * this.Velocity.X;
            v40 = this.Velocity.Y * v131;
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
          v52 = v4.X;
          v114.X = v48;
          v114.Y = v49;
          v114.Z = v51;
          a4.X = v48 - (float)(v52 * v50);
          a4.Y = v49 - (float)(v46 * v50);
          a4.Z = v51 - (float)(v47 * v50);
          v53 = this.GetCylinderExtent(&a2a);
          v54 = v53->Z;
          v55 = v53->X;
          a7.Y = v53->Y * 0.25f;
          a7.Z = v54 * 0.25f;
          v56 = (float)(v54 * 0.25f) * 0.75f;
          v114.Z = v114.Z - v56;
          a7.X = v55 * 0.25f;
          a4.Z = a4.Z - v56;
          GWorld.SingleLineCheck(ref Hit, this, a4, v114, 8415, a7, 0);
          if ( Hit.Time >= 1.0f )
          {
            if ( this.Physics == PHYS_WallRunning )
            {
              v96.X = 0.0f;
              v96.Y = 0.0f;
  LABEL_73:
              v90 = v96.X;
              v96.Z = 1.0f;
              v91 = v96.Y;
  LABEL_74:
              this.setPhysics( 2, default, new Vector(v90, v91, 1065353216));// setPhysics
              this.FallingOffWall();
              goto LABEL_8;
            }
          }
          else
          {
            if ( (float)((float)((float)(this.Floor.Y * Hit.Normal.Y) + (float)(this.Floor.Z * Hit.Normal.Z)) + (float)(this.Floor.X * Hit.Normal.X)) < 0.95999998d
              && (float)((float)((float)(Hit.Normal.Y * Delta.Y) + (float)(Delta.Z * Hit.Normal.Z)) + (float)(Hit.Normal.X * Delta.X)) > 0.0f )
            {
              v96.X = 0.0f;
              v96.Y = 0.0f;
              v90 = v96.X;
              v96.Z = 1.0f;
              v91 = v96.Y;
              this.setPhysics( 2, default, new Vector(v90, v91, COERCE_FLOAT(1065353216)));// setPhysics
              this.FallingOffWall();
              goto LABEL_8;
            }
            v57 = this.Floor.Y;
            v58 = this.Floor.Z;
            v59 = this.MaxWallStepHeight + 2.0f;
            v115.X = (float)(v4.X * -1.0f) * v59;
            v115.Y = (float)(v57 * -1.0f) * v59;
            v115.Z = (float)(v58 * -1.0f) * v59;
            GWorld.MoveActor(this, ref v115, ref this.Rotation, 0, ref Hit);
            v60 = Hit.Normal.Y;
            v61 = Hit.Normal.Z;
            v4.X = Hit.Normal.X;
            v62 = Hit.Actor == this.Base;
            this.Floor.Y = v60;
            this.Floor.Z = v61;
            if ( !v62 )
              this.SetBase(
                Hit.Actor,
                Hit.Normal,
                1,
                default,
                default);
          }
        }
        else if ( this.Moves[this.MovementState].MoveActiveTime > 0.2f )
        {
          v63 = this.Velocity.Y;
          v64 = this.Velocity.X;
          v65 = (float)(v64 * v64) + (float)(v63 * v63);
          v136 = v65;
          if ( v65 == 1.0f )
          {
            if ( this.Velocity.Z == 0.0f )
            {
              v66 = this.Velocity.Y;
              v67 = this.Velocity.Z;
              v99 = this.Velocity.X;
              v64 = v99;
              v100 = v66;
              v63 = v66;
              v101 = LODWORD(v67);
              v28 = v67;
            }
          }
          else if ( v65 >= SMALL_NUMBER )
          {
            v135 = 1077936128;
            v102 = 0.5f;
            v68 = fsqrt(v136);
            v132 = (float)(3.0f - (float)((float)((float)(1.0f / v68) * v136) * (float)(1.0f / v68))) * (float)((float)(1.0f / v68) * 0.5f);
            v64 = v132 * this.Velocity.X;
            v63 = this.Velocity.Y * v132;
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
          v74 = v4.X;
          v113.X = this.Location.X + (float)(v64 * 35.0f);
          v113.Y = v71;
          v113.Z = v73;
          v97.X = v113.X - (float)(v74 * v70);
          v97.Y = v71 - (float)(v72 * v70);
          v97.Z = v73 - (float)(v69 * v70);
          v75 = this.GetCylinderExtent(&v133);
          v76 = v75->Z;
          v77 = v75->X;
          v96.Y = v75->Y * 0.25f;
          v96.Z = v76 * 0.25f;
          v78 = (float)(v76 * 0.25f) * 0.75f;
          v113.Z = v113.Z - v78;
          v96.X = v77 * 0.25f;
          v97.Z = v97.Z - v78;
          GWorld.SingleLineCheck(ref Hit, this, v97, v113, 8415, v96, 0);
          if ( Hit.Time >= 1.0f && this.Physics == PHYS_WallRunning )
          {
            v99 = 0.0f;
            v90 = 0.0f;
            v100 = 0.0f;
            v101 = 1065353216;
            v91 = 0.0f;
            this.setPhysics( 2, default, new Vector(v90, v91, COERCE_FLOAT(1065353216)));// setPhysics
            this.FallingOffWall();
            goto LABEL_8;
          }
        }
        v19 = v93;
        if ( v93 <= 0.0f )
          goto LABEL_64;
        goto LABEL_LOOP;
      //}
      LABEL_OUTLOOP:
      v26 = v19;
      goto LABEL_23;
    }
    v6 = this.VfTableObject.Dummy;
    CallUFunction(this.FallingOffWall, this, v7, 0, 0);
    if ( this.Physics == PHYS_WallRunning )
    {
      // v8 = *(void (__thiscall **)(TdPawn , int, _DWORD, _DWORD, _DWORD, int))(this.VfTableObject.Dummy + 480);
      v98.X = 0.0f;
      v98.Y = 0.0f;
      v98.Z = 1.0f;
      this.setPhysics( 2, default, new Vector(0, 0, COERCE_FLOAT(1065353216)));
    }
  LABEL_8:
    this.startNewPhysics( a2, a3);// startNewPhysics
    return;
    
    LABEL_64:
    if ( this.Physics == PHYS_WallRunning )
    {
      v79 = this.Rotation.Yaw;
      v80 = atan2(this.Floor.Y, v4.X);
      v81 = this.Rotation.Roll;
      v97.X.LODWORD(this.Rotation.Pitch);
      v97.Y.LODWORD(v79);
      v97.Z.LODWORD(v81);
      v102 = (float)(v80 * 10430.222f);
      v82 = (ushort)((int)v102 - v125);
      if ( v82 > 0x7FFF )
        v82 = v82 - (0x10000);
      v97.Y.LODWORD(LODWORD(v97.Y) + v82);
      v115.X = 0.0f;
      v115.Y = 0.0f;
      v115.Z = 0.0f;
      GWorld.MoveActor(this, ref v115, ref *((Rotator *)&v97), 0, ref Hit);
      v83 = (float)(this.Location.Y - v108) * (float)(1.0f / a2);
      v84 = (float)(1.0f / a2) * (float)(this.Location.X - v107);
      v85 = this.Velocity.X;
      v86 = this.Velocity.Y * this.Velocity.Y;
      v87 = this.Velocity.Z * this.Velocity.Z;
      v109 = (float)(this.Location.Z - v109) * (float)(1.0f / a2);
      v108 = v83;
      v107 = v84;
      if ( (float)((float)((float)(v85 * v85) + v86) + v87) > (float)((float)((float)(v109 * v109) + (float)(v83 * v83)) + (float)(v84 * v84)) && (this.bCollideComplex.AsBitfield(20) & 0x100) == default && this.Physics == PHYS_WallRunning )
      {
        v88 = v108;
        v89 = v109;
        this.Velocity.X = v107;
        this.Velocity.Y = v88;
        this.Velocity.Z = v89;
      }
    }
    return;
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
    //Vector *v21; // ebx
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
    Vector v65 = default; // [esp+58h] [ebp-140h] BYREF
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
    Vector v89 = default; // [esp+110h] [ebp-88h] BYREF
    Vector v90 = default; // [esp+11Ch] [ebp-7Ch] BYREF
    float v91 = default; // [esp+128h] [ebp-70h]
    Vector a2a = default; // [esp+138h] [ebp-60h] BYREF
    float v93 = default; // [esp+148h] [ebp-50h]
    int v94 = default; // [esp+158h] [ebp-40h]
    float v95 = default; // [esp+168h] [ebp-30h]
    float v96 = default; // [esp+178h] [ebp-20h]
    int v97 = default; // [esp+188h] [ebp-10h]
  
    if ( this.Controller || (this.bIsFemale.AsBitfield(20) & 0x8000) != default )
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
          this.setPhysics( 2, default, new Vector(0, 0, COERCE_FLOAT(1065353216)));
        }
        this.startNewPhysics( (a2), a3);// startNewPhysics
      }
      else
      {
        v7 = (float)((float)(this.Acceleration.X * this.Acceleration.X) + (float)(this.Acceleration.Y * this.Acceleration.Y)) + (float)(this.Acceleration.Z * this.Acceleration.Z);
        a4.X = v7;
        if ( v7 == 1.0f )
        {
          v8 = this.Acceleration.Y;
          v9 = this.Acceleration.Z;
          v65 = this.Acceleration;
        }
        else if ( v7 >= SMALL_NUMBER )
        {
          v91 = 3.0f;
          v10 = 1.0f / fsqrt(a4.X);
          a2a.X = (float)(3.0f - (float)((float)(v10 * a4.X) * v10)) * (float)(v10 * 0.5f);
          v65 = this.Acceleration * a2a.X;
        }
        else
        {
          v65 = default;
        }
        v11 = this.Velocity.Z;
        v12 = this.Velocity.X;
        v13 = this.GroundSpeed * 4.0f;
        v70 = this.Velocity.Y;
        v14 = (int)this.MovementState;
        v71 = v11;
        v15 = this.Moves[v14].FrictionModifier;
        v69 = v12;
        v58 = (float)v15;
        this.CalcVelocity( ref v65, (a2), (v13), (v58), 0, 0, 0);// CalcVelocity
        v16 = this.Velocity.Z;
        v17 = this.Velocity.X;
        v18 = this.Velocity.Y;
        v19 = a2;
        SetFromBitfield(ref this.bCollideComplex, 20, this.bCollideComplex.AsBitfield(20) & (0xFFFFFEFF));
        v20 = this.MaxStepHeight;
        v74 = v16;
        ref var v21 = ref this.Location;
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
          LABEL_LOOP:
          //while(1 != default)
          //{
            if ( a3 >= 8 )
              goto LABEL_48;
            v25 = ++a3;
            if ( v19 <= 0.050000001d )
              goto LABEL_OUTLOOP;
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
                goto LABEL_OUTLOOP;
            }
            v27 = v19 * 0.5f;
            if ( (float)(v19 * 0.5f) >= 0.050000001d )
              v27 = (float)(0.050000001d);
  LABEL_24:
            Delta = v19 - v27;
            v68.X = v72 * v27;
            v68.Y = v73 * v27;
            v68.Z = v74 * v27;
            GWorld.MoveActor(this, ref v68, ref this.Rotation, 0, ref Hit);
            if ( Hit.Time < 1.0f )
            {
              if ( (this.bDisableSkelControlSpring.AsBitfield(32) & 1024) != default )
              {
                v28 = v68.X;
                v29 = v68.Z;
                v30 = v68.Y;
                v31 = (float)((float)(v28 * v28) + (float)(v29 * v29)) + (float)(v30 * v30);
                v93 = v31;
                if ( v31 != 1.0f && v31 >= SMALL_NUMBER )
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
                WallClimbingStepUp_maybe(ref a4, ref a4, ref v90, ref Hit);
              }
              else
              {
                if( fabs( Hit.Normal.Z ) >= 0.2f )
                {
                  this.FallingOffWall();
                  if ( this.Physics == PHYS_WallClimbing )
                    this.setPhysics( 2, default, new Vector(0, 0, COERCE_FLOAT(1065353216)));// setPhysics
                  startNewPhysics((a2), v25);
                  return;
                }

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
                else if ( v37 >= SMALL_NUMBER )
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
            if ( (this.bDisableSkelControlSpring.AsBitfield(32) & 0x400) != default )
            {
              v45 = this.MaxWallStepHeight + 2.0f;
              v46 = this.Floor.Y * v45;
              v47 = this.Floor.Z * v45;
              v89.X = v21.X - (float)(this.Floor.X * v45);
              v89.Y = this.Location.Y - v46;
              v89.Z = this.Location.Z - v47;
              v48 = this.GetCylinderExtent(&a2a);
              GWorld.SingleLineCheck(ref Hit, this, v89, this.Location, 8415, *v48, 0);
              if ( Hit.Time >= 1.0f )
              {
  LABEL_53:
                this.FallingOffWall();
                if ( this.Physics == PHYS_WallClimbing )
                  this.setPhysics( 2, default, new Vector(0, 0, COERCE_FLOAT(1065353216)));// setPhysics
                startNewPhysics((a2), v25);
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
                GWorld.MoveActor(this, ref a4, ref this.Rotation, 0, ref Hit);
                if ( this.Physics == PHYS_WallClimbing )
                  this.setPhysics( 2, default, new Vector(0, 0, COERCE_FLOAT(1065353216)));// setPhysics
                this.FallingOffWall();
                startNewPhysics((a2), v25);
                return;
              }
              GWorld.MoveActor(this, ref a4, ref this.Rotation, 0, ref Hit);
              v52 = Hit.Normal.Y;
              v53 = Hit.Normal.Z;
              this.Floor.X = Hit.Normal.X;
              v54 = Hit.Actor == this.Base;
              this.Floor.Y = v52;
              this.Floor.Z = v53;
              if ( !v54 )
                this.SetBase(
                  Hit.Actor,
                  Hit.Normal,
                  1,
                  default,
                  default);
            }
            v19 = Delta;
            if ( Delta <= 0.0f )
              goto LABEL_48;
            goto LABEL_LOOP;
          //}
          LABEL_OUTLOOP:
          v27 = v19;
          goto LABEL_24;
        }
  LABEL_48:
        if ( (this.bCollideComplex.AsBitfield(20) & 0x100) == default && this.Physics == PHYS_WallClimbing )
        {
          v55 = v71;
          Delta_8a = (float)(this.Location.Y - Delta_8) * (float)(1.0f / a2);
          v56 = (float)(this.Location.Z - v64) * (float)(1.0f / a2);
          this.Velocity.X = (float)(1.0f / a2) * (float)(v21.X - Delta_4);
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



  public unsafe Vector GetSprintAcceleration( float aForward, float aStrafe, int DeltaRotation, float DeltaTime )
  {
    Vector v = default;
    return *GetSprintAcceleration(&v, aForward, aStrafe, DeltaRotation, DeltaTime);
  }



  public unsafe Vector * GetSprintAcceleration(Vector *outputVec, float aForward, float aStrafe, int DeltaRotation, float DeltaTime)
  {
    Matrix *v7; // eax
    double v8 = default; // st7
    float v9 = default; // xmm6_4
    float v10 = default; // xmm4_4
    float v11 = default; // xmm5_4
    float v12 = default; // xmm0_4
    float v13 = default; // xmm2_4
    Vector *result; // eax
    float v15 = default; // edx
    float v16 = default; // ecx
    float v17 = default; // xmm0_4
    double v18 = default; // st7
    TdWeapon v19 = default; // eax
    float v20 = default; // xmm5_4
    float v21 = default; // xmm7_4
    float v22 = default; // xmm6_4
    float v23 = default; // xmm0_4
    float v24 = default; // xmm4_4
    double v25 = default; // st7
    float v26 = default; // xmm4_4
    float v27 = default; // xmm6_4
    float v28 = default; // xmm5_4
    float v29 = default; // xmm1_4
    float v30 = default; // xmm0_4
    float v31 = default; // xmm3_4
    float v32 = default; // xmm0_4
    float v33 = default; // xmm6_4
    float v34 = default; // xmm0_4
    float v35 = default; // xmm2_4
    float v36 = default; // xmm3_4
    float v37 = default; // xmm4_4
    float v38 = default; // xmm5_4
    float v39 = default; // xmm1_4
    float v40 = default; // xmm4_4
    float v41 = default; // xmm3_4
    float v42 = default; // xmm6_4
    float v43 = default; // xmm5_4
    float v44 = default; // xmm4_4
    float v45 = default; // xmm3_4
    float v46 = default; // xmm1_4
    float v47 = default; // xmm2_4
    float v48 = default; // xmm0_4
    double v49 = default; // st7
    double v50 = default; // st5
    float a2 = default; // [esp+0h] [ebp-ACh]
    float a3 = default; // [esp+14h] [ebp-98h] BYREF
    float v53 = default; // [esp+18h] [ebp-94h]
    float v54 = default; // [esp+1Ch] [ebp-90h]
    float v55 = default; // [esp+20h] [ebp-8Ch]
    float v56 = default; // [esp+28h] [ebp-84h]
    float v57 = default; // [esp+2Ch] [ebp-80h]
    float v58 = default; // [esp+30h] [ebp-7Ch]
    float v59 = default; // [esp+38h] [ebp-74h]
    float v60 = default; // [esp+3Ch] [ebp-70h]
    float v61 = default; // [esp+40h] [ebp-6Ch]
    float v62 = default; // [esp+48h] [ebp-64h]
    int v63 = default; // [esp+4Ch] [ebp-60h]
    float v64 = default; // [esp+5Ch] [ebp-50h]
    Matrix v65 = default; // [esp+6Ch] [ebp-40h] BYREF
  
    v7 = FRotationMatrix(&v65, this.Rotation);
    v8 = sqrt(this.Velocity.Y * this.Velocity.Y + this.Velocity.X * this.Velocity.X);
    v9 = (float)(v7->XPlane.X * aForward) + (float)(v7->YPlane.X * aStrafe);
    v10 = (float)(v7->XPlane.Y * aForward) + (float)(v7->YPlane.Y * aStrafe);
    v11 = (float)(v7->XPlane.Z * aForward) + (float)(v7->YPlane.Z * aStrafe);
    v12 = (float)((float)(v11 * v11) + (float)(v10 * v10)) + (float)(v9 * v9);
    v59 = v9;
    v60 = v10;
    v61 = v11;
    v56 = v12;
    v62 = (float)v8;
    if ( v12 == 1.0f )
    {
      v53 = v59;
      v54 = v60;
      v55 = v61;
    }
    else if ( v12 >= SMALL_NUMBER )
    {
      a3 = 0.5f;
      v13 = 1.0f / fsqrt(v56);
      v59 = (float)(3.0f - (float)((float)(v13 * v56) * v13)) * (float)(v13 * 0.5f);
      v53 = v59 * v9;
      v54 = v10 * v59;
      v55 = v11 * v59;
    }
    else
    {
      v53 = 0.0f;
      v54 = 0.0f;
      v55 = 0.0f;
    }
    v56 = 0.0f;
    v57 = 0.0f;
    v58 = 0.0f;
    if ( fabs(v53) < 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ && fabs(v54) < 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ && fabs(v55) < 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
    {
      result = outputVec;
      v15 = v57;
      outputVec->X = v56;
      v16 = v58;
      outputVec->Y = v15;
      this.SpeedSprintEnergy = 0.0f;
      outputVec->Z = v16;
      return result;
    }
    v17 = v62 - this.SpeedMaxBaseVelocity;
    this.SpeedSprintEnergy = v17;
    if ( v17 < 0.0f )
      v17 = 0.0f;
    a2 = (float)v8;
    this.SpeedSprintEnergy = v17;
    a3 = 0.0f;
    v18 = this.AccelCurve_LightWeapon.Eval(a2, ref a3, default);
    v59 = (float)(v53 * v18);
    v56 = v59;
    v19 = this.MyWeapon;
    v60 = (float)(v54 * v18);
    v57 = v60;
    v61 = (float)(v18 * v55);
    v58 = v61;
    if ( v19 && v19.WeaponType == EWT_Heavy )
    {
      v20 = v62;
      v21 = this.AccelCurve_HeavyWeapon.Points[this.AccelCurve_HeavyWeapon.Points.Count - 1].InVal;
      if ( v62 > v21 )
      {
        v22 = v55;
        v23 = v53;
        v24 = v54;
        v55 = -0.0f - v55;
        v59 = (float)(-0.0f - v53) * (float)(v62 - v21);
        v60 = (float)(-0.0f - v54) * (float)(v62 - v21);
        v61 = v55 * (float)(v62 - v21);
        v56 = v59;
        v57 = v60;
        v58 = v61;
        goto LABEL_18;
      }
      a3 = 0.0f;
      v25 = this.AccelCurve_HeavyWeapon.Eval(v62, ref a3, default);
      v59 = (float)(v53 * v25);
      v56 = v59;
      v60 = (float)(v54 * v25);
      v57 = v60;
      v61 = (float)(v25 * v55);
      v58 = v61;
    }
    v20 = v62;
    v22 = v55;
    v24 = v54;
    v23 = v53;
  LABEL_18:
    if ( this.Physics == PHYS_Falling )
    {
      v44 = v58;
      v43 = v57;
      v42 = v56;
      goto LABEL_33;
    }
    v26 = (float)(v24 * v20) - this.Velocity.Y;
    v27 = v22 * v20;
    v28 = (float)(v23 * v20) - this.Velocity.X;
    v29 = (float)(v26 * v26) + (float)(v28 * v28);
    a3 = v29;
    v30 = this.SpeedSprintVelocityAccelerationFactor;
    v31 = v27;
    v59 = v28;
    v60 = v26;
    v61 = v27;
    a3 = (float)(sqrt(v29));
    v32 = v30 * a3;
    if ( (float)(a3 / DeltaTime) < v32 )
      v33 = a3 / DeltaTime;
    else
      v33 = v32;
    v64 = (float)(v26 * v26) + (float)(v28 * v28);
    if ( v29 != 1.0f )
    {
      if ( v29 < SMALL_NUMBER )
      {
        v34 = 0.0f;
        v54 = 0.0f;
        v55 = 0.0f;
  LABEL_30:
        v53 = v34;
        goto LABEL_31;
      }
      v63 = 1077936128;
      a3 = 0.5f;
      v35 = 1.0f / fsqrt(v64);
      v53 = (float)(3.0f - (float)((float)(v35 * v64) * v35)) * (float)(v35 * 0.5f);
      v26 = v26 * v53;
      v34 = v53 * v28;
  LABEL_29:
      v55 = 0.0f;
      v54 = v26;
      v53 = v34;
      goto LABEL_31;
    }
    if ( v31 != 0.0f )
    {
      v34 = v28;
      v55 = 0.0f;
      v54 = v26;
      v53 = v34;
      goto LABEL_31;
    }
    v53 = v59;
    v34 = v59;
    v54 = v60;
    v55 = v61;
  LABEL_31:
    v36 = this.Velocity.Y;
    v37 = this.Velocity.Z;
    v59 = v53;
    v38 = this.PhysicsVolume.GroundFriction;
    v60 = v54;
    v61 = v55;
    v39 = (float)(v55 * v33) + v58;
    v40 = (float)(v37 * v38) * 0.1f;
    v41 = (float)((float)(v36 * v38) * 0.1f) + (float)((float)(v54 * v33) + v57);
    v42 = (float)((float)(v38 * this.Velocity.X) * 0.1f) + (float)((float)(v34 * v33) + v56);
    v43 = v41;
    v44 = v40 + v39;
  LABEL_33:
    v45 = this.SpeedTurnDecelerationFactor;
    v46 = this.Velocity.Y;
    v47 = this.Velocity.Z;
    v48 = this.Velocity.X * v45;
    a3 = (float)(fabs((double)DeltaRotation));
    v56 = (float)(v42 - (float)((float)(v48 * a3) * 0.000030517578f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/)) * 10.0f;
    v57 = (float)(v43 - (float)((float)((float)(v46 * v45) * a3) * 0.000030517578f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/)) * 10.0f;
    v58 = (float)(v44 - (float)((float)((float)(v47 * v45) * a3) * 0.000030517578f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/)) * 10.0f;
    v56 = (float)floor(v56 + 0.5f);
    v57 = (float)floor(v57 + 0.5f);
    v49 = floor(v58 + 0.5f);
    result = outputVec;
    v56 = v56 * 0.1f;
    v50 = v57;
    outputVec->X = v56;
    v57 = (float)(v50 * 0.1f);
    outputVec->Y = v57;
    v58 = (float)(v49 * 0.1f);
    outputVec->Z = v58;
    return result;
  }

  // NOT READY
  //public unsafe void InitMoveObjects(){ NativeMarkers.MarkUnimplemented(); }
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
//    v2 = ref this.Moves;
//    v3 = this.Moves.Max == 0;
//    this.Moves.Count = default;
//    if ( !v3 )
//    {
//      v4 = v2.Data;
//      v3 = v2.Data == 0;
//      this.Moves.Max = default;
//      if ( !v3 )
//      {
//        v5 = dword_2018708;
//        if ( !dword_2018708 )
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
//        if ( !v7[v6] )
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
  public unsafe void CheckForUncontrolledSlide(ref CheckResult a2)
  {
    PhysicalMaterial v3 = default; // eax
    TdPhysicalMaterialProperty v4 = default; // eax
    PhysicalMaterial v5 = default; // eax
  
    if ( this.IsHumanControlled()
      && this.MovementState != MOVE_FallingUncontrolled
      && (((v3 = a2.PhysMaterial) != default || a2.Material && (v3 = (PhysicalMaterial )a2.Material.GetPhysicalMaterial()) != default)// GetPhysicalMaterial
       && (v4 = E_TryCastTo<TdPhysicalMaterialProperty>(v3.PhysicalMaterialProperty)) != default
       || (v5 = this.LastFootstepMaterial) != default && (v4 = E_TryCastTo<TdPhysicalMaterialProperty>(v5.PhysicalMaterialProperty)) != default)
      && (v4.bEnableSoftLanding.AsBitfield(4) & 4) != default )
    {
      SetFromBitfield(ref this.bDisableSkelControlSpring, 32, this.bDisableSkelControlSpring.AsBitfield(32) | (0x10000u));
      this.UncontrolledSlideNormal = a2.Normal;
    }
  }

  // NOT READY
  public unsafe void ReplicateCustomAnim(ECustomNodeType Type, name AnimName, float Rate, float BlendInTime, float BlendOutTime, bool bLooping, bool bOverride, bool bRootMotion, bool bRootRotation){ NativeMarkers.MarkUnimplemented("Most likely only online related"); }
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
//      sub_44D910(ref this.ReplicatedCustomAnim, (int)v11);
//      v16 = -1;
//      if ( v15[0] )
//      {
//        v12 = dword_2018708;
//        v13 = v15[0];
//        if ( !dword_2018708 )
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
  public override unsafe void TickSpecial(float DeltaSeconds)
  {
    float v3 = default; // xmm0_4
    float v4 = default; // xmm1_4
    float v5 = default; // xmm2_4
    float v6 = default; // xmm0_4
    int v7 = default; // edi
    int v8 = default; // eax
    EMovement v9 = default; // al
    //TdMove *v10; // edx
    bool v11 = default; // zf
    //TdMove *v12; // eax
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
  
    base.TickSpecial(DeltaSeconds);
    UpdateMeshTranslation_OrSomething(DeltaSeconds);
    v3 = this.EvadeTimer;
    v4 = DeltaSeconds;
    if ( v3 > 0.0f )
    {
      if ( v3 < DeltaSeconds )
        v5 = this.EvadeTimer;
      else
        v5 = DeltaSeconds;
      this.EvadeTimer = v3 - v5;
    }
    v6 = this.bIllegalLedgeTimer;
    if ( v6 > 0.0f )
    {
      if ( v6 < DeltaSeconds )
        v4 = this.bIllegalLedgeTimer;
      this.bIllegalLedgeTimer = v6 - v4;
    }
    if ( (BYTE2(this.bDisableSkelControlSpring.AsBitfield(32)) & 1) != default && this.MovementState != MOVE_RumpSlide )
    {
      v7 = this.VfTableObject.Dummy;
      v24[0] = 38;
      v27 = default;
      v25 = default;
      v26 = 1;
      this.SetMove((EMovement)38);
    }
    v9 = this.MovementState;
    if(v9 != default)
    {
      var v10 = this.Moves.Data;
      v11 = v10[(int)v9] == null;
      ref var v12 = ref v10[(int)v9];
      if ( !v11 )
        v12.UpdateMoveTimer( (DeltaSeconds));// UTdMove::UpdateMoveTimer
    }
    DoFootPlacement_Maybe(DeltaSeconds);
    v13 = this.ASPollTimer + DeltaSeconds;
    this.ASPollTimer = v13;
    v14 = 0.0f;
    v15 = fabs(sqrt(this.Velocity.Y * this.Velocity.Y + this.Velocity.X * this.Velocity.X)) * (double)((((int)-((this.bDisableSkelControlSpring.AsBitfield(32) >> 3) & 1) >> 31) & 2) - 1) * DeltaSeconds;
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
    if ( !v17 )
    {
      this.ASDistanceData[this.ASSlotPointer] = v18;
      this.ASTimeData[this.ASSlotPointer++] = this.ASPollTimer;
      v11 = this.ASSlotPointer == this.ASPollSlots;
      this.ASDistanceAccum = 0.0f;
      this.ASPollTimer = 0.0f;
      if(v11 != default)
        this.ASSlotPointer = default;
      v19 = 0.0f;
      if( this.ASTimeData.Count > 0 )
      {
        for( int i = 0; i < ASTimeData.Count; i++ )
        {
          v14 += this.ASDistanceData.Data[ i ];
          v19 += this.ASTimeData.Data[ i ];
        }
        // Basically this ?
        /*v20 = this.ASDistanceData.Data;
        v21 = this.ASTimeData.Count;
        v22 = (byte *)((byte *)this.ASTimeData.Data - (byte *)v20);
        do
        {
          v23 = *(float *)((byte *)v20 + (_DWORD)v22);
          v14 = v14 + *v20++;
          --v21;
          v19 = v23 + v19;
        }
        while(v21 != default);*/
      }
      this.AverageSpeed = v14 / v19;
    }
  }

  public override unsafe void physWalking(float DeltaTime, int Iterations)
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
    float v29 = default; // xmm0_4
    float v30 = default; // edx
    float v31 = default; // eax
    float v32 = default; // ecx
    float v33 = default; // xmm2_4
    double v34 = default; // st7
    float v35 = default; // ecx
    float v36 = default; // edx
    // void (__stdcall *v37)(float *, _DWORD, _DWORD, _DWORD, _DWORD, int, _DWORD); // eax
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
    //Vector *v56; // ebx
    float v57 = default; // eax
    float v58 = default; // xmm3_4
    float v59 = default; // xmm2_4
    float v60 = default; // eax
    Actor v61 = default; // ebp
    float v62 = default; // xmm1_4
    Vector *v63; // eax
    Controller v64 = default; // ecx
    float v65 = default; // xmm4_4
    // void (__stdcall *v66)(int *, float *, Vector *, CheckResult *); // edx
    Actor v67 = default; // edi
    float v68 = default; // eax
    float v69 = default; // ecx
    float v70 = default; // edx
    float v71 = default; // xmm0_4
    PrimitiveComponent v72 = default; // eax
    float v74 = default; // ecx
    float v75 = default; // edx
    float v76 = default; // eax
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
    float v96 = default; // xmm1_4
    float v97 = default; // xmm1_4
    double v98 = default; // st6
    double v99 = default; // st5
    double v100 = default; // st7
    float v101 = default; // xmm1_4
    float v102 = default; // xmm1_4
    float v103 = default; // xmm0_4
    float v104 = default; // edx
    Controller v105 = default; // edi
    Actor v106 = default; // edi
    uint v107 = default; // eax
    uint v108 = default; // eax
    Controller v109 = default; // esi
    double v110 = default; // st7
    double v111 = default; // st7
    float v112 = default; // xmm1_4
    TdBotPawn v113 = default; // edi
    // void (__stdcall *v114)(int, _DWORD, _DWORD, _DWORD, int); // edx
    // void (__stdcall *v115)(int, _DWORD, _DWORD, _DWORD, int); // edx
    int v116 = default; // edi
    int v117 = default; // eax
    double v118 = default; // st7
    double v119 = default; // st7
    float v120 = default; // xmm1_4
    float v121 = default; // xmm2_4
    float v122 = default; // xmm1_4
    float v123 = default; // xmm2_4
    Controller v124 = default; // ecx
    float v125 = default; // [esp+28h] [ebp-1E8h]
    Vector Delta = default; // [esp+4Ch] [ebp-1C4h] BYREF
    float remainingTime = default; // [esp+58h] [ebp-1B8h]
    int v128 = default; // [esp+5Ch] [ebp-1B4h] BYREF
    int v129 = default; // [esp+60h] [ebp-1B0h] BYREF
    //Actor v130_floatThenActor = default; // [esp+64h] [ebp-1ACh]
    float v131 = default; // [esp+68h] [ebp-1A8h]
    float v132 = default; // [esp+6Ch] [ebp-1A4h]
    float v133 = default; // [esp+70h] [ebp-1A0h]
    float v134 = default; // [esp+74h] [ebp-19Ch]
    float timeTick = default; // [esp+78h] [ebp-198h]
    float v136 = default; // [esp+7Ch] [ebp-194h]
    float v137 = default; // [esp+80h] [ebp-190h]
    float v138 = default; // [esp+84h] [ebp-18Ch]
    Vector DestLocation = default; // [esp+88h] [ebp-188h] BYREF
    float v140 = default; // [esp+94h] [ebp-17Ch]
    float v141 = default; // [esp+98h] [ebp-178h]
    float v142 = default; // [esp+9Ch] [ebp-174h]
    float v143 = default; // [esp+A0h] [ebp-170h]
    float v144 = default; // [esp+A4h] [ebp-16Ch]
    float v145 = default; // [esp+A8h] [ebp-168h]
    float v146 = default; // [esp+ACh] [ebp-164h]
    float v147 = default; // [esp+B0h] [ebp-160h]
    CheckResult Hit = default; // [esp+B4h] [ebp-15Ch] BYREF
    float v149 = default; // [esp+FCh] [ebp-114h]
    Vector v150 = default; // [esp+100h] [ebp-110h] BYREF
    Vector v153 = default; // [esp+10Ch] [ebp-104h] BYREF
    float v156 = default; // [esp+118h] [ebp-F8h]
    Vector a2 = default; // [esp+11Ch] [ebp-F4h] BYREF
    int v158 = default; // [esp+128h] [ebp-E8h]
    float v159 = default; // [esp+12Ch] [ebp-E4h]
    int v160 = default; // [esp+130h] [ebp-E0h]
    Vector v161 = default; // [esp+134h] [ebp-DCh]
    Vector v162 = default; // [esp+140h] [ebp-D0h] BYREF
    Vector a5 = default; // [esp+14Ch] [ebp-C4h] BYREF
    float v164 = default; // [esp+158h] [ebp-B8h]
    Vector v165 = default; // [esp+168h] [ebp-A8h] BYREF
    float v166 = default; // [esp+174h] [ebp-9Ch]
    float v167 = default; // [esp+178h] [ebp-98h]
    float v168 = default; // [esp+17Ch] [ebp-94h]
    //float* v169 = stackalloc float[4]; // [esp+180h] [ebp-90h] BYREF
    Vector v169 = default;
    float v169_4 = default;
    float v170 = default; // [esp+190h] [ebp-80h]
    float v171 = default; // [esp+194h] [ebp-7Ch]
    Vector v172 = default; // [esp+19Ch] [ebp-74h] BYREF
    Vector v173 = default; // [esp+1A8h] [ebp-68h] BYREF
    Vector a4 = default; // [esp+1B4h] [ebp-5Ch] BYREF
    Vector v175 = default; // [esp+1C0h] [ebp-50h] BYREF
    //float* v176 = stackalloc float[5]; // [esp+1CCh] [ebp-44h] BYREF
    Vector v176 = default;
    float v176_4 = default;
    float v176_5 = default;
    float v177 = default; // [esp+1E0h] [ebp-30h]
    float v178 = default; // [esp+1ECh] [ebp-24h]
    float v179 = default; // [esp+1F0h] [ebp-20h]
    int v180 = default; // [esp+200h] [ebp-10h]
  
    if ( !this.Controller && (this.bIsFemale.AsBitfield(20) & 0x8000) == default )
    {
      this.Acceleration.X = 0.0f;
      this.Acceleration.Y = 0.0f;
      v136 = 0.0f;
      v137 = 0.0f;
      this.Acceleration.Z = 0.0f;
      v138 = 0.0f;
      this.Velocity.X = 0.0f;
      this.Velocity.Y = 0.0f;
      this.Velocity.Z = 0.0f;
      return;
    }
    v4 = this.Velocity.Y;
    v5 = this.Velocity.X;
    v6 = (float)(v5 * v5) + (float)(v4 * v4);
    v169.X = v6;
    if ( v6 == 1.0f )
    {
      if ( this.Velocity.Z == 0.0f )
      {
        v7 = this.Velocity.Y;
        v8 = this.Velocity.Z;
        v145 = this.Velocity.X;
        v5 = v145;
        v146 = v7;
        v9 = v7;
        v147 = v8;
        goto LABEL_12;
      }
      v9 = v4;
    }
    else if ( v6 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
    {
      v164 = 3.0f;
      v131 = 0.5f;
      v10 = 1.0f / fsqrt(v169.X);
      a2.X = (float)(3.0f - (float)((float)(v10 * v169.X) * v10)) * (float)(v10 * 0.5f);
      v5 = this.Velocity.X * a2.X;
      v9 = a2.X * this.Velocity.Y;
    }
    else
    {
      v5 = 0.0f;
      v9 = 0.0f;
    }
    v147 = 0.0f;
  LABEL_12:
    v11 = this.Floor.Y;
    v12 = this.Floor.X;
    v13 = (float)(v12 * v12) + (float)(v11 * v11);
    v169.X = v13;
    if ( v13 == 1.0f )
    {
      if ( this.Floor.Z == 0.0f )
      {
        v14 = this.Floor.Y;
        v15 = this.Floor.Z;
        v136 = this.Floor.X;
        v12 = v136;
        v137 = v14;
        v11 = v14;
        v138 = v15;
        v16 = v15;
        goto LABEL_19;
      }
    }
    else if ( v13 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
    {
      v164 = 3.0f;
      v131 = 0.5f;
      v17 = 1.0f / fsqrt(v169.X);
      a2.X = (float)(3.0f - (float)((float)(v17 * v169.X) * v17)) * (float)(v17 * 0.5f);
      v12 = a2.X * this.Floor.X;
      v11 = this.Floor.Y * a2.X;
    }
    else
    {
      v12 = 0.0f;
      v11 = 0.0f;
    }
    v16 = 0.0f;
  LABEL_19:
    v18 = (float)((float)((float)(-0.0f - v12) * v5) + (float)((float)(-0.0f - v16) * v147)) + (float)((float)(-0.0f - v11) * v9);
    v19 = this.Floor.Z * this.Floor.Z;
    v131 = v18;
    if ( v19 >= 0.0f )
    {
      if ( v19 > 1.0f )
        v19 = 1.0f;
    }
    else
    {
      v19 = 0.0f;
    }
    float v130_float_cpy = v19;
    v20 = this.MovementState;
    v21 = sqrt(1.0f - v19);
    v22 = this.Moves[v20].FrictionModifier;
    v130_float_cpy = (float)(v21 * v131);
    if ( v20 == MOVE_Slide || v20 == MOVE_RumpSlide || v20 == MOVE_MeleeSlide )
    {
      if ( v18 < 0.0f )
        v26 = this.DownwardSlideFrictionScale;
      else
        v26 = this.UpwardSlideFrictionScale;
      v25 = (float)((float)(v26 * v130_float_cpy) + 1.0f) * v22;
  LABEL_37:
      v24 = v25;
      goto LABEL_38;
    }
    if ( v18 < 0.0f )
      v23 = this.DownwardWalkFrictionScale;
    else
      v23 = this.UpwardWalkFrictionScale;
    v24 = this.MaxWalkFrictionModify;
    v25 = (float)((float)(v23 * v130_float_cpy) + 1.0f) * v22;
    if ( v25 < this.MinWalkFrictionModify )
      v25 = this.MinWalkFrictionModify;
    if ( v24 >= v25 )
      v24 = v25;
  LABEL_38:
    this.Velocity.Z = 0.0f;
    this.Acceleration.Z = 0.0f;
    Vector v28_cpy;
    if ( this.Acceleration.X == 0.0f && this.Acceleration.Y == 0.0f && this.Acceleration.Z == 0.0f )
    {
      v28_cpy = this.Acceleration;
    }
    else
    {
      v29 = (float)((float)(this.Acceleration.X * this.Acceleration.X) + (float)(this.Acceleration.Y * this.Acceleration.Y)) + (float)(this.Acceleration.Z * this.Acceleration.Z);
      v169.X = v29;
      if ( v29 == 1.0f )
      {
        v30 = this.Acceleration.X;
        v31 = this.Acceleration.Y;
        v32 = this.Acceleration.Z;
        Delta.X = v30;
        Delta.Y = v31;
        Delta.Z = v32;
      }
      else if ( v29 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
      {
        v164 = 3.0f;
        v131 = 0.5f;
        v33 = 1.0f / fsqrt(v169.X);
        a2.X = (float)(3.0f - (float)((float)(v33 * v169.X) * v33)) * (float)(v33 * 0.5f);
        Delta.X = a2.X * this.Acceleration.X;
        Delta.Y = this.Acceleration.Y * a2.X;
        Delta.Z = this.Acceleration.Z * a2.X;
      }
      else
      {
        Delta.X = 0.0f;
        Delta.Y = 0.0f;
        Delta.Z = 0.0f;
      }
      v28_cpy = Delta;
    }
    v34 = this.GroundSpeed;
    v35 = v28_cpy.Y;
    v150.X = v28_cpy.X;
    v36 = v28_cpy.Z;
    v150.Y = v35;
    v38 = this.PhysicsVolume;
    v150.Z = v36;
    v125 = (float)v34;
    this.CalcVelocity(ref v150, (DeltaTime), (v125), v38.GroundFriction * v24, 0, 1, 0);// CalcVelocity
    v39 = this.PhysicsVolume;
    v40 = this.Location.X;
    v41 = this.Location.Y;
    v42 = this.Velocity.Y + (float)((float)(v39.ZoneVelocity.Y * 25.0f) * DeltaTime);
    v43 = this.MaxStepHeight + 2.0f;
    v170 = (float)((float)(v39.ZoneVelocity.X * 25.0f) * DeltaTime) + this.Velocity.X;
    v44 = 0.0f;
    Hit.Item = -1;
    Hit.LevelIndex = -1;
    v45 = this.Location.Z;
    DestLocation.X = v40;
    v46 = this.Floor.X;
    v147 = v43 * -1.0f;
    v171 = v42;
    v153.X = default;
    v153.Y = default;
    v153.Z = -1f;
    v145 = v43 * 0.0f;
    v146 = v43 * 0.0f;
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
    v149 = 0.0f;
    DestLocation.Y = v41;
    DestLocation.Z = v45;
    v141 = v46;
    v47 = this.Floor.Y;
    v48 = this.Floor.Z;
    v49 = this.Base;
    SetFromBitfield(ref this.bCollideComplex, 20, this.bCollideComplex.AsBitfield(20) & (0xFFFFFEFF));
    v50 = this.Location.Z;
    v142 = v47;
    v143 = v48;
    var v130_Actor = v49;
    v129 = default;
    v128 = default;
    v51 = DeltaTime;
    v131 = v50;
    if ( DeltaTime <= 0.0f )
    {
      goto LABEL_188;
    }
    while(1 != default)
    {
      if ( Iterations >= 8 )
        goto LABEL_188;
      v52 = this.Controller;
      if ( !v52 && (this.bIsFemale.AsBitfield(20) & 0x8000) == default )
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
      timeTick = v53;
      v55 = v170 * v53;
      v136 = v54;
      v57 = this.Location.Y;
      Delta.X = (float)v55;
      v58 = v51 - v53;
      v59 = v42 * v53;
      v137 = v57;
      v60 = this.Location.Z;
      v61 = default;
      v62 = v53 * 0.0f;
      remainingTime = v58;
      Delta.Y = v59;
      Delta.Z = v62;
      v138 = v60;
      v161.X = 0.0f;
      v161.Y = 0.0f;
      v161.Z = 0.0f;
      if ( fabs(v55) < 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ && fabs(Delta.Y) < 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ && fabs(Delta.Z) < 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
      {
        v160 = 1;
        remainingTime = 0.0f;
        goto LABEL_76;
      }
      v160 = default;
      if(v52 != default)
      {
        if ( (v52 as TdPlayerController).Unknown2()// ATdPlayerController::Unknown2
          && (((v63 = (this as TdPlayerPawn).SomethingVertigoRelated(&v169, v150, Delta, v153, ref v129, ref v128)) == v63 && (Delta.X = v63->X) is object && (v64 = this.Controller) is object && (Delta.Y = v63->Y) is object && (Delta.Z = v63->Z) is object) &&
              v64.MoveTimer == -1.0f) )
        {
          v44 = 0.0f;
          remainingTime = 0.0f;
        }
        else
        {
          v44 = 0.0f;
        }
        v59 = Delta.Y;
        v62 = Delta.Z;
      }
      if ( this.Floor.Z < 0.98000002d )
      {
        v65 = Delta.X;
        if ( (float)((float)((float)(this.Floor.Z * v62) + (float)(this.Floor.Y * v59)) + (float)(this.Floor.X * Delta.X)) < 0.0f )
        {
          Hit.Time = 0.0f;
  LABEL_72:
          //v66 = *(void (__stdcall **)(int *, float *, Vector *, CheckResult *))(this.VfTableObject.Dummy + 528);
          v156 = (float)(sqrt(Delta.X * Delta.X + Delta.Z * Delta.Z + Delta.Y * Delta.Y));
          v176.X = (float)(1.0f / v156) * v65;
          v176.Y = v59 * (float)(1.0f / v156);
          v176.Z = v62 * (float)(1.0f / v156);
          v173.X = (float)(1.0f - v44) * v65;
          v173.Y = v59 * (float)(1.0f - v44);
          v173.Z = v62 * (float)(1.0f - v44);
          this.stepUp(v153, v176, v173, ref Hit);
          if ( this.Physics == PHYS_Falling )
          {
            v98 = this.Location.Y - v137;
            v99 = this.Location.X - v136;
            v100 = sqrt(v99 * v99 + v98 * v98) / v156;
            v144 = (float)v100;
            if ( v100 < 1.0f )
              v101 = v144;
            else
              v101 = 1.0f;
            remainingTime = (float)((float)(1.0f - v101) * timeTick) + remainingTime;
            this.Falling();
            if ( this.Physics == PHYS_Flying )
            {
              v134 = this.AirSpeed;
              v102 = v134;
              this.Velocity.X = 0.0f;
              v132 = 0.0f;
              v133 = 0.0f;
              v103 = this.AccelRate;
              this.Velocity.Y = 0.0f;
              v104 = v133;
              this.Velocity.Z = v102;
              v134 = v103;
              this.Acceleration.X = 0.0f;
              this.Acceleration.Y = v104;
              this.Acceleration.Z = v103;
            }
            goto LABEL_142;
          }
          if ( Hit.Time < 1.0f )
          {
            v61 = Hit.Actor;
            v161 = Hit.Normal;
          }
          goto LABEL_75;
        }
      }
      GWorld.MoveActor(this, Delta, this.Rotation, 0, ref Hit);
      v44 = Hit.Time;
      if ( Hit.Time < 1.0f )
      {
        v62 = Delta.Z;
        v59 = Delta.Y;
        v65 = Delta.X;
        //v66 = *(void (__stdcall **)(int *, float *, Vector *, CheckResult *))(this.VfTableObject.Dummy + 528);
        v156 = (float)(sqrt(Delta.X * Delta.X + Delta.Z * Delta.Z + Delta.Y * Delta.Y));
        v176.X = (float)(1.0f / v156) * v65;
        v176.Y = v59 * (float)(1.0f / v156);
        v176.Z = v62 * (float)(1.0f / v156);
        v173.X = (float)(1.0f - v44) * v65;
        v173.Y = v59 * (float)(1.0f - v44);
        v173.Z = v62 * (float)(1.0f - v44);
        this.stepUp(v153, v176, v173, ref Hit);
        if ( this.Physics == PHYS_Falling )
        {
          v98 = this.Location.Y - v137;
          v99 = this.Location.X - v136;
          v100 = sqrt(v99 * v99 + v98 * v98) / v156;
          v144 = (float)v100;
          if ( v100 < 1.0f )
            v101 = v144;
          else
            v101 = 1.0f;
          remainingTime = (float)((float)(1.0f - v101) * timeTick) + remainingTime;
          this.Falling();
          if ( this.Physics == PHYS_Flying )
          {
            v134 = this.AirSpeed;
            v102 = v134;
            this.Velocity.X = 0.0f;
            v132 = 0.0f;
            v133 = 0.0f;
            v103 = this.AccelRate;
            this.Velocity.Y = 0.0f;
            v104 = v133;
            this.Velocity.Z = v102;
            v134 = v103;
            this.Acceleration.X = 0.0f;
            this.Acceleration.Y = v104;
            this.Acceleration.Z = v103;
          }
          goto LABEL_142;
        }
        if ( Hit.Time < 1.0f )
        {
          v61 = Hit.Actor;
          v161 = Hit.Normal;
        }
        goto LABEL_75;
      }
  LABEL_75:
      if ( this.Physics == PHYS_Swimming )
        goto LABEL_143;
  LABEL_76:
      v67 = this.Base;
      if ( v67 && (v67.bForceDemoRelevant.AsBitfield(32) & 0x40000000) == default && v67 != GWorld.GetWorldInfo() )
        bForceFloorCheck = TRUE;
      if(v61 != default)
      {
        v68 = v161.X;
        v69 = v161.Y;
        v70 = v161.Z;
        Hit.Actor = v61;
  LABEL_82:
        Hit.Time = 0.1f;
        v71 = (float)(2.4000001d);
        Hit.Normal.Y = v69;
        Hit.Normal.X = v68;
        Hit.Normal.Z = v70;
        goto LABEL_95;
      }
      if ( v160 != default
        && v67 != default
        && (v67.bExludeHandMoves.AsBitfield(32) & 0x400) != 0
        && this.RelativeLocation.X == (float)(this.Location.X - v67.Location.X)
        && this.RelativeLocation.Y == (float)(this.Location.Y - v67.Location.Y)
        && this.RelativeLocation.Z == (float)(this.Location.Z - v67.Location.Z)
        && (HIBYTE(this.bUpAndOut.AsBitfield(32)) & 1) == default )
      {
        v68 = this.Floor.X;
        v69 = this.Floor.Y;
        v70 = this.Floor.Z;
        Hit.Actor = v67;
        Hit.Time = 0.1f;
        v71 = (float)(2.4000001d);
        Hit.Normal.Y = v69;
        Hit.Normal.X = v68;
        Hit.Normal.Z = v70;
        goto LABEL_95;
      }
      v72 = this.CollisionComponent;
      SetFromBitfield(ref this.bUpAndOut, 32, this.bUpAndOut.AsBitfield(32) & (0xFEFFFFFF));
      if(v72 != default)
      {
        v172.X = this.Location.X + v72.Translation.X;
        v172.Y = v72.Translation.Y + this.Location.Y;
        v172.Z = v72.Translation.Z + this.Location.Z;
        v74 = v172.X;
        v75 = v172.Y;
        v76 = v172.Z;
      }
      else
      {
        v74 = this.Location.X;
        v75 = this.Location.Y;
        v76 = this.Location.Z;
      }
      a5.X = v74;
      a4.X = v74 + v145;
      a5.Y = v75;
      a4.Y = v75 + v146;
      a5.Z = v76;
      a4.Z = v76 + v147;
      GWorld.SingleLineCheck(ref Hit, this, a4, a5, 8415, *this.GetCylinderExtent(&a2), 0);
      v71 = (float)(this.MaxStepHeight + 2.0f) * Hit.Time;
      v78 = Hit.Normal.Y;
      v79 = Hit.Normal.Z;
      this.Floor.X = Hit.Normal.X;
      this.Floor.Y = v78;
      this.Floor.Z = v79;
      v140 = v71;
      CheckForUncontrolledSlide(ref Hit);
      v80 = Hit.Normal.Z;
      if( this.WalkableFloorZ <= Hit.Normal.Z )
      {
        v44 = 0.0f;
        goto POST_LABEL_99;
      }

      LABEL_95:
      if ( fabs(Delta.X) >= 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ || fabs(Delta.Y) >= 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ || fabs(Delta.Z) >= 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
      {
        v44 = 0.0f;
        if ( (float)((float)((float)(Hit.Normal.X * Delta.X) + (float)(Hit.Normal.Y * Delta.Y)) + (float)(Delta.Z * Hit.Normal.Z)) < 0.0f )
        {
          v83 = (float)((float)(Hit.Normal.Y + Hit.Normal.X) * 0.0f) + (float)(this.MaxStepHeight * Hit.Normal.Z);
          v84 = this.MaxStepHeight - (float)(v83 * Hit.Normal.Z);
          v175.X = (float)(-0.0f - (float)(v83 * Hit.Normal.X)) * -1.0f;
          v175.Y = (float)(-0.0f - (float)(Hit.Normal.Y * v83)) * -1.0f;
          v175.Z = v84 * -1.0f;
          GWorld.MoveActor(this, v175, this.Rotation, 0, ref Hit);
          if ( Hit.Actor != this.Base && this.Physics == PHYS_Walking )
            this.SetBase(Hit.Actor, Hit.Normal, 1, default, default);// SetBase
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
      POST_LABEL_99:
      if ( Hit.Time >= 1.0f || ((v81 = Hit.Actor) is object && Hit.Actor == this.Base) && v140 <= 2.4000001d )
      {
        if ( v140 >= 1.9f )
          goto LABEL_123;
        v93 = Hit.Normal.X;
        v94 = Hit.Normal.Y;
        v95 = Hit.Normal.Z;
        v162.X = 0.0f;
        v162.Y = 0.0f;
        v162.Z = (float)(2.1500001d - v140);
        GWorld.MoveActor(this, v162, this.Rotation, 0, ref Hit);
        v44 = 0.0f;
        Hit.Time = 0.0f;
        Hit.Normal.X = v93;
        Hit.Normal.Y = v94;
        Hit.Normal.Z = v95;
      }
      else
      {
        if ( (float)(v140 - 2.1500001d) > 0.0f )
          v82 = (float)(v140 - 2.1500001d);
        else
          v82 = 0.0f;
        v87 = Hit.Normal.X;
        v88 = Hit.Normal.Y;
        v89 = (float)((float)(v145 * v145) + (float)(v147 * v147)) + (float)(v146 * v146);
        v178 = Hit.Normal.Z;
        v179 = v89;
        if ( v89 == 1.0f )
        {
          v166 = v145;
          v90 = v145;
          v167 = v146;
          v91 = v146;
          v168 = v147;
          v44 = v147;
        }
        else if ( v89 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
        {
          v180 = 1077936128;
          v144 = 0.5f;
          v92 = fsqrt(v179);
          v164 = (float)(3.0f - (float)((float)((float)(1.0f / v92) * v179) * (float)(1.0f / v92))) * (float)((float)(1.0f / v92) * 0.5f);
          v90 = v164 * v145;
          v91 = v146 * v164;
          v44 = v147 * v164;
        }
        else
        {
          v90 = 0.0f;
          v91 = 0.0f;
        }
        v165.X = v90 * v82;
        v165.Y = v91 * v82;
        v165.Z = v44 * v82;
        GWorld.MoveActor(this, v165, this.Rotation, 0, ref Hit);
        v44 = 0.0f;
        Hit.Actor = v81;
        Hit.Time = 0.0f;
        Hit.Normal.X = v87;
        Hit.Normal.Y = v88;
        Hit.Normal.Z = v178;
        if ( v81 && v81 != this.Base && this.Physics == PHYS_Walking )
        {
          this.SetBase(Hit.Actor, Hit.Normal, 1, default, default);// SetBase
          v44 = 0.0f;
        }
      }
  LABEL_122:
      v80 = Hit.Normal.Z;
  LABEL_123:
      if ( this.Physics == PHYS_Swimming )
        goto LABEL_143;
      if(v128 != default)
        goto LABEL_155;
      if ( Hit.Time >= 1.0f || v80 < this.WalkableFloorZ )
        break;
      if ( v80 < 0.99000001d && (float)(this.PhysicsVolume.GroundFriction * v80) < 3.3f )
      {
        if ( this.PhysicsVolume.GroundFriction > 0.5f )
          v159 = this.PhysicsVolume.GroundFriction;
        else
          v159 = 0.5f;
        v44 = 0.0f;
        v177 = this.GetGravityZ() * DeltaTime / (v159 + v159) * DeltaTime;// GetGravityZ
        v96 = (float)((float)(Hit.Normal.Y + Hit.Normal.X) * 0.0f) + (float)(v177 * Hit.Normal.Z);
        v133 = -0.0f - (float)(Hit.Normal.Y * v96);
        v97 = v96 * Hit.Normal.Z;
        v134 = v177 - v97;
        v132 = -0.0f - (float)((float)((float)((float)(Hit.Normal.Y + Hit.Normal.X) * 0.0f) + (float)(v177 * Hit.Normal.Z)) * Hit.Normal.X);
        Delta.X = v132;
        Delta.Y = v133;
        Delta.Z = v177 - v97;
        if ( (float)((float)((float)(v133 + v132) * 0.0f) + (float)((float)(v177 - v97) * v177)) >= 0.0f )
        {
          GWorld.MoveActor(this, Delta, this.Rotation, 0, ref Hit);
          v44 = 0.0f;
        }
        if ( this.Physics == PHYS_Swimming )
        {
          goto LABEL_143;
        }
      }
      v51 = remainingTime;
      if ( remainingTime <= 0.0f )
        goto LABEL_188;
      v42 = v171;
    }
    if ( (this.bUpAndOut.AsBitfield(32) & 0x200) == default )
      goto LABEL_151;
    if ( !(v129 != default) && this.Controller )
    {
      v105 = this.Controller;
      if ( v105.IsProbing(333, 0) )
      {
        v129 = 1;
        v105.MayFall();
      }
      if(v128 != default)
        goto LABEL_155;
    }
    if ( (this.bUpAndOut.AsBitfield(32) & 0x200) != default )
    {
      goto LABEL_155;
    }
    else
    {
      goto LABEL_151;
    }
  POST_LABEL_155:
    if ( v129 != default || (this.bCollideComplex.AsBitfield(20) & 0x100) != default || v128 != default || ((v107 = this.bUpAndOut.AsBitfield(32)) is object && (v107 & 0x200) != 0) && ((v107 & 0x80000) != default || (v107 & 0xA) == 0) )
    {
      v162.X = this.Location.X - v136;
      v162.Y = this.Location.Y - v137;
      v110 = sqrt(Delta.X * Delta.X + Delta.Z * Delta.Z + Delta.Y * Delta.Y);
      if ( v110 == 0.0f )
      {
        remainingTime = 0.0f;
      }
      else
      {
        v111 = sqrt(v162.Y * v162.Y + v162.X * v162.X) / v110;
        v144 = (float)v111;
        if ( v111 < 1.0f )
          v112 = v144;
        else
          v112 = 1.0f;
        remainingTime = (float)((float)(1.0f - v112) * timeTick) + remainingTime;
      }
      this.Velocity.Z = 0.0f;
      this.Falling();
      if ( this.Physics != PHYS_Walking )
        goto LABEL_142;
      v113 = E_TryCastTo<TdBotPawn>(this);
      if(GIsEditor != default)
      {
        if ( !GWorld.HasBegunPlay() )
          goto LABEL_142;
        if ( GWorld.GetTimeSeconds() < 1.0f )
          goto LABEL_142;
        v141 = 0.0f;
        v142 = 0.0f;
        v143 = 1.0f;
        this.setPhysics( 2, null, new Vector(0, 0, 1f));
        if(v113 != default)
        {
          if ( v140 <= 36.0f )
            goto LABEL_142;
        }
        a2.Z = 0.0f;
      }
      else
      {
        v141 = 0.0f;
        v142 = 0.0f;
        v143 = 1.0f;
        this.setPhysics( 2, null, new Vector(0, 0, 1f));
        if ( v113 && (v140 <= 36.0f && this.WalkableFloorZ <= Hit.Normal.Z || this.IsInMove((EMovement)77)) )// IsInMove
          goto LABEL_142;
        a2.Z.LODWORD(1);
      }
      v116 = this.VfTableObject.Dummy;
      v158 = default;
      a2.X.LOBYTE(2);
      a2.Y = 0.0f;
      this.SetMove( (EMovement)2 );
      goto LABEL_142;
    }
    this.Velocity.X = 0.0f;
    v132 = 0.0f;
    this.Acceleration.X = 0.0f;
    this.Velocity.Y = 0.0f;
    this.Velocity.Z = 0.0f;
    v133 = 0.0f;
    v134 = 0.0f;
    this.Acceleration.Y = 0.0f;
    this.Acceleration.Z = 0.0f;
    GWorld.FarMoveActor(this, DestLocation, false, false, false);
    if(v106 != default)
    {
      v108 = v106.bExludeHandMoves.AsBitfield(32);
      if ( (v108 & 8) != default || (v108 & 0x400) != default || (v106.bForceDemoRelevant.AsBitfield(32) & 0x100000) == default )
        this.SetBase(v106, new Vector(v141, v142, v143), 1, null, default);// SetBase
    }
    v109 = this.Controller;
    if(v109 != default)
      v109.MoveTimer = -1.0f;
    return;
    
    LABEL_188:
    if ( this.Physics == PHYS_Walking )
    {
      v118 = this.Location.Z;
      v156 = this.Location.Z;
      v119 = fabs(v118 - v131);
      v144 = (float)v119;
      if ( v119 > 4.0f && this.MaxStepHeight >= v144 )
        this.OffsetMeshZ(v131 - v156);// OffsetMeshZ
      if ( (this.bCollideComplex.AsBitfield(20) & 0x100) == default )
      {
        v120 = this.Location.Y;
        v121 = this.Location.Z;
        v141 = (float)(1.0f / DeltaTime) * (float)(this.Location.X - DestLocation.X);
        v122 = (float)(v120 - DestLocation.Y) * (float)(1.0f / DeltaTime);
        v142 = v122;
        v123 = (float)(v121 - DestLocation.Z) * (float)(1.0f / DeltaTime);
        v143 = v123;
        this.Velocity.X = v141;
        this.Velocity.Y = v122;
        this.Velocity.Z = v123;
      }
      this.Velocity.Z = 0.0f;
    }
    v124 = this.Controller;
    if(v124 != default)
      v124.PostPhysWalking(DeltaTime);// PostPhysWalking
    return;
    
    
    LABEL_155:
    v106 = v130_Actor;
    goto POST_LABEL_155;
    
    
    LABEL_151:
    v106 = v130_Actor;
    if ( !v130_Actor || (v130_Actor.bForceDemoRelevant.AsBitfield(32) & 0x40000000) == default && v106 != GWorld.GetWorldInfo() )
      v128 = 1;
    goto POST_LABEL_155;
    
    
    LABEL_143:
    this.startSwimming(DestLocation, this.Velocity, timeTick, remainingTime, Iterations);
    return;
    
    
    LABEL_142:
    this.startNewPhysics(remainingTime, Iterations);// startNewPhysics
    return;
  }

  public override unsafe Vector CalculateSlopeSlide(ref Vector a3, ref CheckResult a4)
  {
    CheckForUncontrolledSlide(ref a4);
    return base.CalculateSlopeSlide(ref a3, ref a4);;
  }

  public unsafe bool IsHitActorTdPawn(ref CheckResult a2)
  {
    Object v2 = default; // ecx
    Class v3 = default; // eax

    return a2.Actor is TdPawn;
    /*v2 = TdPawn_Class;
    if ( !TdPawn_Class )
    {
      TdPawn_Class = (Object )sub_12C2C40((int)L"TdGame");
      sub_12B2BE0();
      v2 = TdPawn_Class;
    }
    v3 = a2.Actor.Class;
    if ( !v3 )
      return v2 != default;
    while ( v3 != v2 )
    {
      v3 = (Class )v3.Next;
      if ( !v3 )
        return v2 != 0;
    }
    return false;*/
  }

  public override unsafe bool ShouldTrace(PrimitiveComponent Primitive, Actor SourceActor, ETraceFlags TraceFlags)
  {
    bool result = default; // eax
  
    if ( this.ActorCylinderComponent != Primitive || (result = (bool)E_TryCastTo<TdPawn>(SourceActor)) )
      result = base.ShouldTrace(Primitive, SourceActor, TraceFlags);
    return result != default;
  }

  // NOT READY
  public unsafe int * UNKNOWN21(int a2, int a3, int *a4, int a5, int a6){ NativeMarkers.MarkUnimplemented(); return default; }
//public unsafe int * UNKNOWN21(int a2, int a3, int *a4, int a5, int a6)
//  {
//    int *v8; // ebx
//    Class v9 = default; // ebx
//    int v10 = default; // eax
//    bool v11 = default; // zf
//    int v12 = default; // ecx
//    Object v13 = default; // eax
//    uint v14 = default; // eax
//    Object v15 = default; // eax
//    int *a4a; // [esp+2Ch] [ebp+Ch]
//    Class a6a = default; // [esp+34h] [ebp+14h]
//  
//    v8 = sub_BA2990((int)this, a2, a3, a4, a5, a6);
//    a4a = v8;
//    if ( ((this.bExludeHandMoves.AsBitfield(32) >> 30) & 1) != default || (this.bCollideComplex.AsBitfield(20) & 0x400) == default && this.Role == ROLE_Authority )
//    {
//      if ( ((uint)&_ImageBase & this.bExludeHandMoves.AsBitfield(32)) != default )
//      {
//        if ( ((this.bExludeHandMoves.AsBitfield(32) >> 30) & 1) == default )
//        {
//          v9 = *(Class *)(a2 + 1888);
//          a6a = this.ReplicatedWeaponClass;
//          if ( (*(int (__thiscall **)(int, Class ))(*(_DWORD *)a5 + 276))(a5, a6a) )
//          {
//            v10 = default;
//            v11 = a6a == v9;
//          }
//          else
//          {
//            *(_DWORD *)(a6 + 140) = 140) | (4u);
//            v10 = default;
//            v11 = v9 == 0;
//          }
//          v10.LOBYTE(!v11);
//          if(v10 != default)
//          {
//            if ( (dword_2056888 & 1) == default )
//            {
//              dword_2056888 = dword_2056888 | (1u);
//              sub_11A95E0();
//              sub_11A95E0();
//              dword_2056884 = sub_12C4BC0(L"ReplicatedWeaponClass");
//            }
//            *a4a = *(ushort *)(dword_2056884 + 94);
//            v8 = a4a + 1;
//          }
//          else
//          {
//            v8 = a4a;
//          }
//        }
//        v12 = a2;
//        if ( this.ReplicatedMovementState != *(_BYTE *)(a2 + 1279) )
//        {
//          if ( (dword_2056888 & 2) == default )
//          {
//            dword_2056888 = dword_2056888 | (2u);
//            sub_11A95E0();
//            sub_11A95E0();
//            dword_2056880 = sub_12C4BC0(L"ReplicatedMovementState");
//          }
//          v12 = a2;
//          *v8++ = *(ushort *)(dword_2056880 + 94);
//        }
//        if ( this.AnimationMovementState != *(_BYTE *)(v12 + 1274) )
//        {
//          if ( (dword_2056888 & 4) == default )
//          {
//            dword_2056888 = dword_2056888 | (4u);
//            sub_11A95E0();
//            sub_11A95E0();
//            dword_205687C = sub_12C4BC0(L"AnimationMovementState");
//          }
//          v12 = a2;
//          *v8++ = *(ushort *)(dword_205687C + 94);
//        }
//        if ( this.ReloadCount != *(_BYTE *)(v12 + 1286) )
//        {
//          if ( (dword_2056888 & 8) == default )
//          {
//            dword_2056888 = dword_2056888 | (8u);
//            sub_11A95E0();
//            sub_11A95E0();
//            dword_2056878 = sub_12C4BC0(L"ReloadCount");
//          }
//          v12 = a2;
//          *v8++ = *(ushort *)(dword_2056878 + 94);
//        }
//        if ( this.RemoteViewYaw != *(_DWORD *)(v12 + 1676) )
//        {
//          if ( (dword_2056888 & 0x10) == default )
//          {
//            dword_2056888 = dword_2056888 | (0x10u);
//            sub_11A95E0();
//            sub_11A95E0();
//            dword_2056874 = sub_12C4BC0(L"RemoteViewYaw");
//          }
//          v12 = a2;
//          *v8++ = *(ushort *)(dword_2056874 + 94);
//        }
//        if ( (this.bExludeHandMoves.AsBitfield(32) & 0x40000000) == 0
//          && (this.LastPhysHitInfo.HitLocation.X != *(float *)(v12 + 1892) || this.LastPhysHitInfo.HitLocation.Y != *(float *)(v12 + 1896) || this.LastPhysHitInfo.HitLocation.Z != *(float *)(v12 + 1900)) )
//        {
//          if ( (dword_2056888 & 0x20) == default )
//          {
//            dword_2056888 = dword_2056888 | (0x20u);
//            sub_11A95E0();
//            sub_11A95E0();
//            dword_2056870 = sub_12C4BC0(L"LastPhysHitInfo");
//          }
//          *v8 = *(ushort *)(dword_2056870 + 94);
//          v12 = a2;
//          ++v8;
//        }
//        if ( ((*(_BYTE *)(v12 + 1052) ^ LOBYTE(this.bDisableSkelControlSpring.AsBitfield(32))) & 0x10) != default )
//        {
//          if ( (dword_2056888 & 0x40) == default )
//          {
//            dword_2056888 = dword_2056888 | (0x40u);
//            sub_11A95E0();
//            sub_11A95E0();
//            dword_205686C = sub_12C4BC0(L"bClimbLeftHand");
//          }
//          *v8 = *(ushort *)(dword_205686C + 94);
//          v12 = a2;
//          ++v8;
//        }
//        if ( this.CurrentGrabTurnType != *(_BYTE *)(v12 + 1272) )
//        {
//          if ( (dword_2056888 & 0x80u) == default )
//          {
//            dword_2056888 = dword_2056888 | (0x80u);
//            sub_11A95E0();
//            sub_11A95E0();
//            dword_2056868 = sub_12C4BC0(L"CurrentGrabTurnType");
//          }
//          *v8 = *(ushort *)(dword_2056868 + 94);
//          v12 = a2;
//          ++v8;
//        }
//        if ( ((*(_BYTE *)(v12 + 1052) ^ LOBYTE(this.bDisableSkelControlSpring.AsBitfield(32))) & 0x20) != default )
//        {
//          if ( (dword_2056888 & 0x100) == default )
//          {
//            dword_2056888 = dword_2056888 | (0x100u);
//            sub_11A95E0();
//            sub_11A95E0();
//            dword_2056864 = sub_12C4BC0(L"bClimbDownFast");
//          }
//          *v8 = *(ushort *)(dword_2056864 + 94);
//          v12 = a2;
//          ++v8;
//        }
//        if ( this.LadderType != *(_BYTE *)(v12 + 1273) )
//        {
//          if ( (dword_2056888 & 0x200) == default )
//          {
//            dword_2056888 = dword_2056888 | (0x200u);
//            sub_11A95E0();
//            sub_11A95E0();
//            dword_2056860 = sub_12C4BC0(L"LadderType");
//          }
//          *v8++ = *(ushort *)(dword_2056860 + 94);
//        }
//      }
//      if ( this.ReplicateCustomAnimCount )
//      {
//        if ( (dword_2056888 & 0x400) == default )
//        {
//          dword_2056888 = dword_2056888 | (0x400u);
//          v13 = TdPawn_Class;
//          if ( !TdPawn_Class )
//          {
//            TdPawn_Class = (Object )sub_12C2C40((int)L"TdGame");
//            sub_12B2BE0();
//            v13 = TdPawn_Class;
//          }
//          if ( !v13 )
//          {
//            TdPawn_Class = (Object )sub_12C2C40((int)L"TdGame");
//            sub_12B2BE0();
//          }
//          dword_205685C = sub_12C4BC0(L"ReplicatedCustomAnim");
//        }
//        *v8++ = *(ushort *)(dword_205685C + 94);
//        ++this.ReplicateCustomAnimCount;
//      }
//    }
//    v14 = this.bExludeHandMoves.AsBitfield(32);
//    if ( ((v14 & 0x40000000) != default || (this.bCollideComplex.AsBitfield(20) & 0x400) != default && ((uint)&_ImageBase & v14) != default && this.Role == ROLE_Authority) && LODWORD(this.TaserDamageLevel) != *(_DWORD *)(a2 + 2184) )
//    {
//      if ( (dword_2056888 & 0x800) == default )
//      {
//        dword_2056888 = dword_2056888 | (0x800u);
//        v15 = TdPawn_Class;
//        if ( !TdPawn_Class )
//        {
//          TdPawn_Class = (Object )sub_12C2C40((int)L"TdGame");
//          sub_12B2BE0();
//          v15 = TdPawn_Class;
//        }
//        if ( !v15 )
//        {
//          TdPawn_Class = (Object )sub_12C2C40((int)L"TdGame");
//          sub_12B2BE0();
//        }
//        dword_2056858 = sub_12C4BC0(L"TaserDamageLevel");
//      }
//      *v8++ = *(ushort *)(dword_2056858 + 94);
//    }
//    return v8;
//  }
  }
}
