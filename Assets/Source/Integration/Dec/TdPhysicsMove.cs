namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdPhysicsMove
{
  public unsafe void CallFoundReachableHandPlant()
  {
    int v2 = default; // edi
    int v3 = default; // eax
  
    v2 = this.VfTableObject.Dummy;
    CallUFunction(this.FoundReachableHandPlant, this, v3, 0, 0);
  }

  public unsafe int FindSoftLanding(Vector *hitLoc)
  {
    Vector *v3; // eax
    float v4 = default; // ecx
    float v5 = default; // edx
    float v6 = default; // eax
    TdPawn v7 = default; // ecx
    int v8 = default; // edx
    // double (__thiscall *v9)(TdPawn ); // eax
    TdPawn v10 = default; // eax
    float v11 = default; // xmm4_4
    float v12 = default; // xmm5_4
    float v13 = default; // xmm3_4
    float v14 = default; // xmm5_4
    PhysicalMaterial v15 = default; // eax
    TdPhysicalMaterialProperty v16 = default; // eax
    float v17 = default; // ecx
    float v18 = default; // edx
    Vector a4 = default; // [esp+0h] [ebp-7Ch] BYREF
    float v21 = default; // [esp+Ch] [ebp-70h]
    float v22 = default; // [esp+10h] [ebp-6Ch]
    float v23 = default; // [esp+14h] [ebp-68h]
    Vector a5 = default; // [esp+18h] [ebp-64h] BYREF
    Vector a3 = default; // [esp+24h] [ebp-58h] BYREF
    CheckResult a2a = default; // [esp+30h] [ebp-4Ch] BYREF
    int v27 = default; // [esp+78h] [ebp-4h]
  
    a2a.Item = -1;
    a2a.LevelIndex = -1;
fixed(var ptr1 =&this.PawnOwner.Acceleration)
    v3 =  ptr1;
    a5.X = 0.0f;
    a5.Y = 0.0f;
    a5.Z = 0.0f;
    v4 = v3->X;
    v5 = v3->Y;
    v6 = v3->Z;
    v21 = v4;
    v7 = this.PawnOwner;
    v22 = v5;
    v8 = v7.VfTableObject.Dummy;
    v23 = v6;
    // v9 = *(double (__thiscall **)(TdPawn ))(v8 + 308);
    a2a.Next = default;
    a2a.Actor = default;
    a2a.Location.X = 0.0f;
    a2a.Location.Y = 0.0f;
    a2a.Location.Z = 0.0f;
    a2a.Normal.X = 0.0f;
    a2a.Normal.Y = 0.0f;
    a2a.Normal.Z = 0.0f;
    a2a.Time = 1.0f;
    a2a.Material = default;
    a2a.PhysMaterial = default;
    a2a.Component = default;
    a2a.BoneName = default;
    a2a.Level = default;
    a2a.bStartPenetrating = default;
    v27 = default;
    v23 = v7.GetGravityZ();
    v10 = this.PawnOwner;
    v11 = v10.Velocity.Y;
    v12 = v10.Velocity.Z;
    v13 = v10.Velocity.X;
    a4 = v10.Location;
    v14 = (float)((float)(v12 * 2.0f) + (float)((float)(v23 * 4.0f) * 0.5f)) + (float)(a4.Z - v10.CylinderComponent.CollisionHeight);
    a4.Z = a4.Z - v10.CylinderComponent.CollisionHeight;
    a3.X = (float)((float)(v13 * 2.0f) + (float)((float)(v21 * 4.0f) * 0.5f)) + a4.X;
    a3.Y = a4.Y + (float)((float)(v11 * 2.0f) + (float)((float)(v22 * 4.0f) * 0.5f));
    a3.Z = v14;
    if ( default == this.MovementLineCheck(&a2a, &a3, &a4, &a5, 9422) )
      return 0;
    if ( a2a.Normal.Z <= 0.89999998d )
      return 0;
    v15 = a2a.PhysMaterial;
    if ( default == a2a.PhysMaterial )
    {
      if ( default == a2a.Material )
        return 0;
      v15 = (PhysicalMaterial )a2a.Material.GetPhysicalMaterial();// GetPhysicalMaterial
      if ( default == v15 )
        return 0;
    }
    v16 = E_TryCastTo<TdPhysicalMaterialProperty>(v15.PhysicalMaterialProperty);
    if ( default == v16 || (v16.bEnableSoftLanding.AsBitfield(4) & 1) == 0 )
      return 0;
    v17 = a2a.Location.Y;
    hitLoc.X = a2a.Location.X;
    v18 = a2a.Location.Z;
    hitLoc.Y = v17;
    hitLoc.Z = v18;
    return 1;
  }

  public unsafe int FindAutoMoveLedge(Vector *out_Location, Vector *out_ledgeNormal, Vector *out_MoveNormal, Vector a5, Rotator a8, float a11, int a12)
  {
    Vector *v9; // ecx
    float v10 = default; // xmm1_4
    float v11 = default; // edx
    float v12 = default; // eax
    float v13 = default; // ecx
    float v14 = default; // xmm2_4
    float v15 = default; // xmm1_4
    int v16 = default; // edi
    Actor v17 = default; // eax
    TdPawn v18 = default; // eax
    TdPawn v19 = default; // ebp
    TdPawn v20 = default; // ecx
    float v21 = default; // xmm2_4
    float v22 = default; // xmm1_4
    float v23 = default; // xmm0_4
    Vector *v24; // ecx
    float v25 = default; // xmm0_4
    float v26 = default; // edx
    float v27 = default; // xmm0_4
    float v28 = default; // xmm2_4
    Vector *v29; // ecx
    float v30 = default; // xmm2_4
    float v31 = default; // edx
    float v32 = default; // eax
    float v33 = default; // ecx
    float v34 = default; // xmm3_4
    float v35 = default; // xmm1_4
    float v36 = default; // xmm0_4
    float v37 = default; // xmm6_4
    float v38 = default; // xmm1_4
    float v39 = default; // xmm0_4
    float v40 = default; // xmm1_4
    float v41 = default; // xmm6_4
    float v42 = default; // ebx
    float v43 = default; // eax
    float v44 = default; // ecx
    float v45 = default; // edx
    CylinderComponent v46 = default; // eax
    float v47 = default; // xmm2_4
    float v48 = default; // xmm0_4
    float v49 = default; // xmm1_4
    float v50 = default; // xmm0_4
    TdPawn v51 = default; // eax
    bool v52 = default; // zf
    TdMovementExclusionVolume v53 = default; // eax
    bool v54 = default; // zf
    CylinderComponent v55 = default; // eax
    float v56 = default; // xmm0_4
    float v57 = default; // xmm0_4
    float v58 = default; // xmm7_4
    float v59 = default; // xmm4_4
    float v60 = default; // xmm5_4
    float v61 = default; // xmm0_4
    float v62 = default; // xmm2_4
    float v63 = default; // xmm0_4
    float v64 = default; // xmm2_4
    float v65 = default; // xmm4_4
    float v66 = default; // xmm0_4
    float v67 = default; // xmm2_4
    float v68 = default; // xmm5_4
    float v69 = default; // xmm4_4
    float v70 = default; // xmm2_4
    float v71 = default; // xmm1_4
    float v72 = default; // edx
    float v73 = default; // ecx
    float v74 = default; // edx
    float v75 = default; // ecx
    float v76 = default; // edx
    float v77 = default; // ecx
    uint v78 = default; // ecx
    Vector v80 = default; // [esp-24h] [ebp-20Ch]
    Vector v81 = default; // [esp-24h] [ebp-20Ch]
    Vector v82 = default; // [esp-18h] [ebp-200h]
    Vector v83 = default; // [esp-Ch] [ebp-1F4h]
    TdMovementExclusionVolume v84 = default; // [esp+10h] [ebp-1D8h]
    Vector a2 = default; // [esp+14h] [ebp-1D4h] BYREF
    float v86 = default; // [esp+20h] [ebp-1C8h]
    float v87 = default; // [esp+24h] [ebp-1C4h]
    float v88 = default; // [esp+28h] [ebp-1C0h]
    float v89 = default; // [esp+2Ch] [ebp-1BCh]
    float v90 = default; // [esp+30h] [ebp-1B8h]
    float v91 = default; // [esp+34h] [ebp-1B4h]
    Vector v92 = default; // [esp+38h] [ebp-1B0h]
    float v93 = default; // [esp+44h] [ebp-1A4h]
    float v94 = default; // [esp+48h] [ebp-1A0h]
    float v95 = default; // [esp+4Ch] [ebp-19Ch]
    int v96 = default; // [esp+50h] [ebp-198h]
    float v97 = default; // [esp+54h] [ebp-194h]
    float v98 = default; // [esp+58h] [ebp-190h]
    float v99 = default; // [esp+5Ch] [ebp-18Ch]
    float v100 = default; // [esp+60h] [ebp-188h]
    float v101 = default; // [esp+64h] [ebp-184h]
    float v102 = default; // [esp+68h] [ebp-180h]
    float v103 = default; // [esp+6Ch] [ebp-17Ch]
    float v104 = default; // [esp+70h] [ebp-178h]
    float v105 = default; // [esp+74h] [ebp-174h]
    int v106 = default; // [esp+78h] [ebp-170h]
    float v107 = default; // [esp+7Ch] [ebp-16Ch]
    LedgeHitInfo out_LedgeHit = default; // [esp+8Ch] [ebp-15Ch] BYREF
    Vector v109 = default; // [esp+B8h] [ebp-130h]
    Vector v110 = default; // [esp+C4h] [ebp-124h]
    float v111 = default; // [esp+D0h] [ebp-118h]
    float v112 = default; // [esp+D4h] [ebp-114h]
    float v113 = default; // [esp+D8h] [ebp-110h]
    float v114 = default; // [esp+DCh] [ebp-10Ch]
    float v115 = default; // [esp+E0h] [ebp-108h]
    float v116 = default; // [esp+E4h] [ebp-104h]
    float v117 = default; // [esp+E8h] [ebp-100h]
    float v118 = default; // [esp+F8h] [ebp-F0h]
    float v119 = default; // [esp+108h] [ebp-E0h]
    float v120 = default; // [esp+10Ch] [ebp-DCh]
    float v121 = default; // [esp+110h] [ebp-D8h]
    TdPawn v122 = default; // [esp+114h] [ebp-D4h]
    int v123 = default; // [esp+118h] [ebp-D0h]
    float v124 = default; // [esp+11Ch] [ebp-CCh]
    int v125 = default; // [esp+120h] [ebp-C8h]
    int v126 = default; // [esp+124h] [ebp-C4h]
    float v127 = default; // [esp+128h] [ebp-C0h]
    float v128 = default; // [esp+12Ch] [ebp-BCh]
    float v129 = default; // [esp+130h] [ebp-B8h]
    float v130 = default; // [esp+134h] [ebp-B4h]
    int v131 = default; // [esp+138h] [ebp-B0h]
    float v132 = default; // [esp+13Ch] [ebp-ACh]
    float v133 = default; // [esp+140h] [ebp-A8h]
    float v134 = default; // [esp+144h] [ebp-A4h]
    float v135 = default; // [esp+148h] [ebp-A0h]
    float v136 = default; // [esp+14Ch] [ebp-9Ch]
    float v137 = default; // [esp+150h] [ebp-98h]
    float v138 = default; // [esp+154h] [ebp-94h]
    float v139 = default; // [esp+158h] [ebp-90h]
    LedgeHitInfo v140 = default; // [esp+15Ch] [ebp-8Ch] BYREF
    int v141 = default; // [esp+188h] [ebp-60h]
    float v142 = default; // [esp+198h] [ebp-50h]
    float v143 = default; // [esp+1A8h] [ebp-40h]
    float v144 = default; // [esp+1B8h] [ebp-30h]
    int v145 = default; // [esp+1C8h] [ebp-20h]
    int v146 = default; // [esp+1D8h] [ebp-10h]
  
    v9 = a8.Vector(&a2);
    v10 = v9->X;
    v117 = (float)(v10 * v10) + (float)(v9->Y * v9->Y);
    if ( v117 == 1.0f )
    {
      if ( v9->Z == 0.0f )
      {
        v11 = v9->X;
        v12 = v9->Y;
        v13 = v9->Z;
        v86 = v11;
        v87 = v12;
        v88 = v13;
        goto LABEL_9;
      }
      v86 = v10;
      v87 = v9->Y;
    }
    else if ( v117 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
    {
      v118 = 3.0f;
      v14 = 1.0f / fsqrt(v117);
      v107 = (float)(3.0f - (float)((float)(v14 * v117) * v14)) * (float)(v14 * 0.5f);
      v15 = v9->X * v107;
      v87 = v107 * v9->Y;
      v86 = v15;
    }
    else
    {
      v86 = 0.0f;
      v87 = 0.0f;
    }
    v88 = 0.0f;
  LABEL_9:
    v16 = default;
    v17 = (Actor )this.PawnOwner.Class.GetDefaultObject(0);
    v18 = E_TryCastTo<TdPawn>(v17);
    v52 = (this.bCheckForGrab.AsBitfield(7) & bCheckForEdgeInVelDir) == 0;
    v19 = v18;
    v122 = v18;
    if ( default == v52 )
    {
      v20 = this.PawnOwner;
      v21 = v20.Velocity.Y;
      v22 = v20.Velocity.Z;
      v23 = v20.Velocity.X;
fixed(var ptr1 =&v20.Velocity)
      v24 =  ptr1;
      v25 = (float)((float)(v23 * v23) + (float)(v21 * v21)) + (float)(v22 * v22);
      v117 = v25;
      if ( v25 == 1.0f )
      {
        v26 = v24->Y;
        a2.X = v24->X;
        a2.Z = v24->Z;
        v27 = a2.Z;
        a2.Y = v26;
      }
      else if ( v25 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
      {
        v118 = 3.0f;
        v28 = 1.0f / fsqrt(v117);
        v107 = (float)(3.0f - (float)((float)(v28 * v117) * v28)) * (float)(v28 * 0.5f);
        v27 = v107 * v24->Z;
      }
      else
      {
        v27 = 0.0f;
      }
      v88 = v27 + v88;
    }
    v110.X = this.HandPlantExtentCheckWidth * 0.5f;
    v110.Y = v110.X;
    v110.Z = this.HandPlantExtentCheckHeight;
    v29 = a8.Vector(&a2);
    v30 = v29->X;
    v117 = (float)(v30 * v30) + (float)(v29->Y * v29->Y);
    if ( v117 == 1.0f )
    {
      if ( v29->Z == 0.0f )
      {
        v31 = v29->X;
        v32 = v29->Y;
        v33 = v29->Z;
        v97 = v31;
        v30 = v31;
        v98 = v32;
        v34 = v32;
        v99 = v33;
        v35 = v33;
        goto LABEL_24;
      }
      v34 = v29->Y;
    }
    else if ( v117 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
    {
      v118 = 3.0f;
      v36 = fsqrt(v117);
      v107 = (float)(3.0f - (float)((float)((float)(1.0f / v36) * v117) * (float)(1.0f / v36))) * (float)((float)(1.0f / v36) * 0.5f);
      v30 = v107 * v29->X;
      v34 = v29->Y * v107;
    }
    else
    {
      v30 = 0.0f;
      v34 = 0.0f;
    }
    v35 = 0.0f;
  LABEL_24:
    v37 = v19.CylinderComponent.CollisionRadius;
    v38 = v35 * 0.0f;
    v39 = v34 - v38;
    v40 = v38 - v30;
    v113 = (float)(v30 * 0.0f) - (float)(v34 * 0.0f);
    v41 = v37 - (float)(this.HandPlantExtentCheckWidth * 0.5f);
    v111 = v39;
    v112 = v40;
    v106 = default;
    v84 = default;
    v120 = v41;
    v96 = default;
    v131 = 2 * (a12 != 0) + 1;
    if ( v131 > 0 )
    {
      v42 = v110.Z;
      while(1 != default)
      {
        if(v106 != default)
        {
  LABEL_84:
          v68 = out_LedgeHit.LedgeLocation.Y;
          v69 = out_LedgeHit.LedgeLocation.Z;
          v70 = v140.LedgeLocation.Z - out_LedgeHit.LedgeLocation.Z;
          v71 = (float)(v140.LedgeLocation.Y - out_LedgeHit.LedgeLocation.Y) * 0.5f;
          a2.X = (float)((float)(v140.LedgeLocation.X - out_LedgeHit.LedgeLocation.X) * 0.5f) + out_LedgeHit.LedgeLocation.X;
          out_Location->X = a2.X;
          a2.Y = v71 + v68;
          out_Location->Y = v71 + v68;
          v72 = out_LedgeHit.MoveNormal.X;
          a2.Z = (float)(v70 * 0.5f) + v69;
          out_Location->Z = a2.Z;
          v73 = out_LedgeHit.MoveNormal.Y;
          out_MoveNormal->X = v72;
          v74 = out_LedgeHit.MoveNormal.Z;
          out_MoveNormal->Y = v73;
          v75 = out_LedgeHit.LedgeNormal.X;
          out_MoveNormal->Z = v74;
          v76 = out_LedgeHit.LedgeNormal.Y;
          out_ledgeNormal->X = v75;
          v77 = out_LedgeHit.LedgeNormal.Z;
          out_ledgeNormal->Y = v76;
          out_ledgeNormal->Z = v77;
          v78 = out_LedgeHit.FeetExcluded.AsBitfield(2);
          this.PawnOwner.MovementActor = out_LedgeHit.MoveActor;
          SetFromBitfield(ref this.PawnOwner.bDisableSkelControlSpring, 32, this.PawnOwner.bDisableSkelControlSpring.AsBitfield(32) ^ ((this.PawnOwner.bDisableSkelControlSpring.AsBitfield(32) ^ (v78 << 7)) & 0x100));
          SetFromBitfield(ref this.PawnOwner.bDisableSkelControlSpring, 32, this.PawnOwner.bDisableSkelControlSpring.AsBitfield(32) ^ ((this.PawnOwner.bDisableSkelControlSpring.AsBitfield(32) ^ (v78 << 9)) & 0x200));
          this.PawnOwner.MovementExclusionVolume = v84;
          return (int)(v16);
        }
        if(v96 != default)
        {
          if ( v96 == 1 )
          {
            v128 = a5.Y - (float)(v40 * 30.0f);
            v44 = v128;
            v127 = a5.X - (float)(v39 * 30.0f);
            v43 = v127;
            v129 = a5.Z - (float)(v113 * 30.0f);
            v45 = v129;
          }
          else
          {
            if ( v96 != 2 )
              goto LABEL_35;
            v137 = (float)(v39 * 30.0f) + a5.X;
            v43 = v137;
            v138 = (float)(v40 * 30.0f) + a5.Y;
            v44 = v138;
            v139 = (float)(v113 * 30.0f) + a5.Z;
            v45 = v139;
          }
        }
        else
        {
          v43 = a5.X;
          v44 = a5.Y;
          v45 = a5.Z;
        }
        v93 = v43;
        v94 = v44;
        v95 = v45;
  LABEL_35:
        v46 = v19.CylinderComponent;
        v130 = v40 * v41;
        v47 = v94 - (float)(v40 * v41);
        v48 = v39 * v41;
        v121 = v113 * v41;
        v49 = v93 - v48;
        v124 = v48;
        v50 = (float)(this.HandPlantCheckHeight - v46.CollisionHeight) + (float)(v95 - (float)(v113 * v41));
        v83.X = v110.X;
        *(_QWORD *)&v83.Y = __PAIR64__(LODWORD(v42), LODWORD(v110.Y));
        v119 = v86 * a11;
        v132 = v87 * a11;
        v109.X = (float)(v86 * a11) + v49;
        v133 = v88 * a11;
        v109.Y = (float)(v87 * a11) + v47;
        v109.Z = (float)(v88 * a11) + v50;
        v100 = v49;
        v80.X = v49;
        v101 = v47;
        v102 = v50;
        *(_QWORD *)&v80.Y = __PAIR64__(LODWORD(v50), LODWORD(v47));
        v16 = this.FindLedgeEx(&out_LedgeHit, v80, v109, v83);
        if ( default == v16 || v96 > 0 && out_LedgeHit.MoveNormal.Z < 0.98000002d )
          goto LABEL_82;
        if ( out_LedgeHit.MoveNormal.Z > 0.2f )
          goto LABEL_82;
        v51 = this.PawnOwner;
        if ( v51.bIllegalLedgeTimer > 0.0f
          && (float)((float)((float)(v51.IllegalLedgeNormal.Z * out_LedgeHit.MoveNormal.Z) + (float)(v51.IllegalLedgeNormal.Y * out_LedgeHit.MoveNormal.Y)) + (float)(v51.IllegalLedgeNormal.X * out_LedgeHit.MoveNormal.X)) > 0.98000002d )
        {
          goto LABEL_82;
        }
        if ( v16 == 2 )
        {
          v52 = (out_LedgeHit.FeetExcluded.AsBitfield(2) & HandsExcluded) == 0;
        }
        else
        {
          if ( v16 != 1 )
            goto LABEL_46;
          v52 = (out_LedgeHit.FeetExcluded.AsBitfield(2) & FeetExcluded) == 0;
        }
        if ( default == v52 )
          goto LABEL_82;
  LABEL_46:
        v53 = this.GetMovementExclusionVolume(out_LedgeHit.LedgeLocation);
        v84 = v53;
        if(v53 != default)
        {
          if ( v16 == 2 )
          {
            v54 = (v53.bExcludeFootMoves.AsBitfield(2) & bExcludeHandMoves) == 0;
            goto LABEL_51;
          }
          if ( v16 == 1 )
          {
            v54 = (v53.bExludeHandMoves.AsBitfield(32) & bExludeFootMoves) == 0;
  LABEL_51:
            if ( default == v54 )
              return 0;
            goto LABEL_52;
          }
        }
  LABEL_52:
        v136 = v121 + v95;
        v102 = v121 + v95;
        v55 = v19.CylinderComponent;
        v134 = v124 + v93;
        v56 = this.HandPlantCheckHeight - v55.CollisionHeight;
        v135 = v130 + v94;
        v57 = v56 + (float)(v121 + v95);
        v101 = v130 + v94;
        v115 = v132 + (float)(v130 + v94);
        v109.Y = v115;
        v116 = v133 + v57;
        v109.Z = v133 + v57;
        v42 = v110.Z;
        v100 = v124 + v93;
        v114 = v119 + (float)(v124 + v93);
        v82.X = v114;
        v109.X = v114;
        v82.Y = v115;
        v82.Z = v133 + v57;
        v81.X = v124 + v93;
        v102 = v57;
        v81.Y = v130 + v94;
        v81.Z = v57;
        if ( this.FindLedgeEx(&v140, v81, v82, v110) == v16 )
        {
          v58 = v140.LedgeLocation.Z - out_LedgeHit.LedgeLocation.Z;
          v59 = v140.LedgeLocation.X - out_LedgeHit.LedgeLocation.X;
          v60 = v140.LedgeLocation.Y - out_LedgeHit.LedgeLocation.Y;
          v97 = v140.LedgeLocation.X - out_LedgeHit.LedgeLocation.X;
          v99 = v140.LedgeLocation.Z - out_LedgeHit.LedgeLocation.Z;
          v61 = (float)((float)(v97 * v97) + (float)(v58 * v58)) + (float)(v60 * v60);
          v98 = v140.LedgeLocation.Y - out_LedgeHit.LedgeLocation.Y;
          v144 = v61;
          if ( v61 == 1.0f )
          {
            v103 = v97;
            v104 = v98;
            v105 = v99;
          }
          else if ( v61 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
          {
            v141 = 1077936128;
            v125 = 1056964608;
            v62 = 1.0f / fsqrt(v144);
            v117 = (float)(3.0f - (float)((float)(v62 * v144) * v62)) * (float)(v62 * 0.5f);
            v103 = v117 * v97;
            v104 = v60 * v117;
            v105 = v99 * v117;
          }
          else
          {
            v103 = 0.0f;
            v104 = 0.0f;
            v105 = 0.0f;
          }
          if ( fabs(v103 * out_LedgeHit.LedgeNormal.X + v105 * out_LedgeHit.LedgeNormal.Z + v104 * out_LedgeHit.LedgeNormal.Y) > 0.25f )
            return 0;
          if ( v140.MoveNormal.Z <= 0.2f
            && fabs(out_LedgeHit.LedgeNormal.Y * v140.LedgeNormal.Y + out_LedgeHit.LedgeNormal.X * v140.LedgeNormal.X + out_LedgeHit.LedgeNormal.Z * v140.LedgeNormal.Z) >= 0.99000001d
            && fabs(v140.MoveNormal.X * out_LedgeHit.MoveNormal.X + v140.MoveNormal.Y * out_LedgeHit.MoveNormal.Y + v140.MoveNormal.Z * out_LedgeHit.MoveNormal.Z) >= 0.94999999d )
          {
            v63 = (float)(v60 * v60) + (float)(v59 * v59);
            a2.X = v140.LedgeLocation.X - out_LedgeHit.LedgeLocation.X;
            a2.Y = v140.LedgeLocation.Y - out_LedgeHit.LedgeLocation.Y;
            a2.Z = v140.LedgeLocation.Z - out_LedgeHit.LedgeLocation.Z;
            v143 = v63;
            if ( v63 == 1.0f )
            {
              if ( v58 == 0.0f )
              {
                v92 = a2;
                goto LABEL_71;
              }
              v92.X = v140.LedgeLocation.X - out_LedgeHit.LedgeLocation.X;
  LABEL_69:
              v92.Y = v60;
            }
            else
            {
              if ( v63 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
              {
                v146 = 1077936128;
                v126 = 1056964608;
                v64 = 1.0f / fsqrt(v143);
                v107 = (float)(3.0f - (float)((float)(v64 * v143) * v64)) * (float)(v64 * 0.5f);
                v92.X = v107 * v59;
                v60 = v60 * v107;
                goto LABEL_69;
              }
              v92.X = 0.0f;
              v92.Y = 0.0f;
            }
            v92.Z = 0.0f;
  LABEL_71:
            v65 = out_LedgeHit.MoveNormal.Y;
            v66 = (float)(out_LedgeHit.MoveNormal.X * out_LedgeHit.MoveNormal.X) + (float)(v65 * v65);
            v142 = v66;
            if ( v66 == 1.0f )
            {
              if ( out_LedgeHit.MoveNormal.Z == 0.0f )
              {
                v89 = out_LedgeHit.MoveNormal.X;
                v90 = out_LedgeHit.MoveNormal.Y;
                v91 = 0.0f;
                goto LABEL_80;
              }
              v89 = out_LedgeHit.MoveNormal.X;
  LABEL_78:
              v90 = v65;
            }
            else
            {
              if ( v66 >= 0.0000000099999999f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ )
              {
                v145 = 1077936128;
                v123 = 1056964608;
                v67 = 1.0f / fsqrt(v142);
                v118 = (float)(3.0f - (float)((float)(v67 * v142) * v67)) * (float)(v67 * 0.5f);
                v89 = v118 * out_LedgeHit.MoveNormal.X;
                v65 = out_LedgeHit.MoveNormal.Y * v118;
                goto LABEL_78;
              }
              v89 = 0.0f;
              v90 = 0.0f;
            }
            v91 = 0.0f;
  LABEL_80:
            if ( fabs(v91 * v92.Z + v90 * v92.Y + v89 * v92.X) <= 0.25f )
              v106 = 1;
            goto LABEL_82;
          }
        }
  LABEL_82:
        if ( ++v96 >= v131 )
        {
          if ( default == v106 )
            return 0;
          goto LABEL_84;
        }
        v39 = v111;
        v40 = v112;
        v41 = v120;
        v19 = v122;
      }
    }
    return 0;
  }

  public override unsafe void PrePerformPhysics(float DeltaTime)
  {
    bool v3 = default; // zf
    TdPawn v4 = default; // eax
    TdPawn v5 = default; // ecx
    TdPawn v6 = default; // esi
    uint v7 = default; // eax
    TdPawn v8 = default; // edi
    int v9 = default; // esi
    int v10 = default; // eax
    int v11 = default; // edi
    int v12 = default; // eax
    Vector a2 = default; // [esp+Ch] [ebp-10h] BYREF
    int v14 = default; // [esp+18h] [ebp-4h]
  
    base.PrePerformPhysics(DeltaTime);
    v3 = (this.bCheckForGrab.AsBitfield(7) & bCheckForSoftLanding) == 0;
    a2.Z = 0.0f;
    if ( default == v3 )
    {
      v4 = this.PawnOwner;
      if ( this.SoftLandingZSpeedThreshold > v4.Velocity.Z && (((uint)&loc_7FFFFE + 2) & v4.bDisableSkelControlSpring.AsBitfield(32)) == 0 )
      {
        if ( FindSoftLanding(&a2) )
        {
          v5 = this.PawnOwner;
          if ( fabs(a2.Z - v5.Location.Z) > v5.CylinderComponent.CollisionHeight + v5.CylinderComponent.CollisionHeight )
          {
            if ( E_TryCastTo<TdMove_SoftLanding>(v5.Moves[78]) )
            {
              v6 = this.PawnOwner;
              LOBYTE(a2.X) = 78;
  LABEL_14:
              v11 = v6.VfTableObject.Dummy;
              v14 = default;
              a2.Y = 0.0f;
              a2.Z = 0.0f;
              CallUFunction(v6.SetMove, v6, v12, &a2, 0);
              return;
            }
          }
        }
      }
    }
    v7 = this.bCheckForGrab.AsBitfield(7);
    if ( (v7 & bCheckExitToFalling) != 0 )
    {
      v8 = this.PawnOwner;
      if ( this.ExitToFallingZSpeed > v8.Velocity.Z )
      {
        v9 = v8.VfTableObject.Dummy;
        v14 = default;
        a2.Y = 0.0f;
        a2.Z = 0.0f;
        LOBYTE(a2.X) = 2;
        CallUFunction(v8.SetMove, v8, v10, &a2, 0);
        return;
      }
    }
    if ( (v7 & 0x20) != 0 && (float)(this.PawnOwner.EnterFallingHeight - this.PawnOwner.Location.Z) > this.PawnOwner.FallingUncontrolledHeight )
    {
      v6 = this.PawnOwner;
      LOBYTE(a2.X) = 72;
      goto LABEL_14;
    }
  }

  public override unsafe void CheckAutoMoves()
  {
    TdPawn v2 = default; // ecx
    TdMove_WallRun v3 = default; // eax
    TdPawn v4 = default; // edx
    TdPawn v5 = default; // eax
    int v6 = default; // ecx
    TdPawn v7 = default; // esi
    int v8 = default; // ebx
    int v9 = default; // eax
    int v10 = default; // [esp-Ch] [ebp-34h]
    int v11 = default; // [esp-8h] [ebp-30h]
    byte* scriptFuncParam = stackalloc byte[4]; // [esp+18h] [ebp-10h] BYREF
    int v13 = default; // [esp+1Ch] [ebp-Ch]
    int v14 = default; // [esp+20h] [ebp-8h]
    int v15 = default; // [esp+24h] [ebp-4h]
  
    v2 = this.PawnOwner;
    if ( (fabs(v2.Velocity.X) >= 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ || fabs(v2.Velocity.Y) >= 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/ || fabs(v2.Velocity.Z) >= 0.000099999997f/*Doesn't fit in float nor double, dec might not follow IEEE conventions*/) && E_ReturnWeaponType(v2) != EWT_Heavy )
    {
      if ( (this.bCheckForGrab.AsBitfield(7) & bCheckForWallClimb) != 0 )
      {
        if ( this.PawnOwner.Moves[40].CallOnCanDoMove() )
        {
          v3 = E_TryCastTo<TdMove_WallRun>(this.PawnOwner.Moves[40]);
          if(v3 != default)
          {
            scriptFuncParam[0] = v3.NextMove;
  LABEL_26:
            v11 = fnSetMove2;
            v10 = fnSetMove1;
            goto LABEL_27;
          }
        }
      }
      this.PawnOwner.MoveLedgeResult = default;
      if ( this.MoveActiveTime > this.bDelayTimeCheckAutoMoves && ((LOBYTE(this.bCheckForGrab.AsBitfield(7)) | (byte)((this.bCheckForGrab.AsBitfield(7) | (this.bCheckForGrab.AsBitfield(7) >> 1)) >> 1)) & 1) != 0 )
      {
        v4 = this.PawnOwner;
fixed(var ptr1 =&v4.MoveNormal)
fixed(var ptr2 =&v4.MoveLedgeNormal)
fixed(var ptr3 =&v4.MoveLedgeLocation)
        v4.MoveLedgeResult = FindAutoMoveLedge( ptr3,  ptr2,  ptr1, v4.Location, v4.Rotation, this.HandPlantCheckDistance, 1);
      }
      v5 = this.PawnOwner;
      if ( v5.MoveLedgeResult > 0 )
      {
        if ( (this.bCheckForGrab.AsBitfield(7) & bCheckForWallClimb) != 0 && (*(int (__thiscall **)(_DWORD))(**((_DWORD **)v5.Moves.Data + 6) + 296))(*((_DWORD *)v5.Moves.Data + 6)) )// CanDoMove
        {
          scriptFuncParam[0] = 6;
          goto LABEL_26;
        }
        if ( this.PawnOwner.MoveLedgeResult != 2 )
          return;
        CallFoundReachableHandPlant();
        SetFromBitfield(ref this.PawnOwner.bDisableSkelControlSpring, 32, this.PawnOwner.bDisableSkelControlSpring.AsBitfield(32) | (bFoundLedge));
        if ( (this.bCheckForGrab.AsBitfield(7) & 2) != 0 )
        {
          if ( this.PawnOwner.Moves[81].CallOnCanDoMove() )
          {
            v11 = fnSetMove2;
            scriptFuncParam[0] = 81;
            v10 = fnSetMove1;
  LABEL_27:
            v7 = this.PawnOwner;
            v8 = v7.VfTableObject.Dummy;
            v15 = default;
            v13 = default;
            v14 = default;
            CallUFunction(v7.v1, v7, v9, scriptFuncParam, 0);
            return;
          }
          if ( (this.bCheckForGrab.AsBitfield(7) & 2) != 0 && this.PawnOwner.Moves[9].CallOnCanDoMove() )
          {
            scriptFuncParam[0] = 9;
            goto LABEL_26;
          }
        }
        if ( (this.bCheckForGrab.AsBitfield(7) & bCheckForGrab) != 0 )
        {
          v6 = *((_DWORD *)this.PawnOwner.Moves.Data + 14);
          if ( (*(int (__thiscall **)(int))(*(_DWORD *)v6 + 296))(v6) )// CanDoMove
          {
            scriptFuncParam[0] = 14;
            goto LABEL_26;
          }
        }
      }
    }
  }
}
}
