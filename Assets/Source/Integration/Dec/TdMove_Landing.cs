// NO OVERWRITE

namespace MEdge.TdGame{
using static MEdge.TdGame.TdPawn; using static MEdge.TdGame.TdPawn.EMovement; using static MEdge.TdGame.TdMove_ZipLine.EZipLineStatus; using static MEdge.TdGame.TdMove.EPreciseLocationMode; using static MEdge.Engine.Actor.EPhysics; using static MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Engine.Actor.ENetRole; using LedgeHitInfo = MEdge.TdGame.TdPawn.LedgeHitInfo; using ECustomNodeType = MEdge.TdGame.TdPawn.CustomNodeType; using static MEdge.TdGame.TdPawn.WalkingState; using static MEdge.TdGame.TdPawn.EWeaponType;using static MEdge.TdGame.TdPawn.EMoveActionHint; using EMoveAimMode = MEdge.TdGame.TdPawn.MoveAimMode; using static MEdge.Source.DecFn; using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdMove_Landing
{
  public override unsafe void UpdateMoveTimer(float a2)
  {
    MaterialInstance v3 = default; // eax
    int v4 = default; // edi
    int *v5; // eax
    float v6 = default; // xmm0_4
    float v7 = default; // xmm2_4
    float v8 = default; // xmm0_4
    int v9 = default; // edi
    int v10 = default; // eax
    float v11 = default; // [esp+Ch] [ebp-Ch]
    int v12 = default; // [esp+10h] [ebp-8h] BYREF
  
    v3 = this.SoftLandingMaterialInstance;
    if(v3 != default)
    {
      if ( (float)(1.0f - this.MoveActiveTime) < 0.0f )
        v11 = 0.0f;
      else
        v11 = 1.0f - this.MoveActiveTime;
      v4 = v3.VfTableObject.Dummy;
      //v5 = v12.FName((wchar_t *)L"FXM_SoftlandingWaves_01", 1, 1);
      this.SoftLandingMaterialInstance.SetScalarParameterValue( /**v5, v5[1]*/"FXM_SoftlandingWaves_01", ((v11)));// UMaterialInstance::SetScalarParameterValue
    }
    v6 = this.Timer;
    v7 = a2;
    if ( v6 > 0.0f )
    {
      v8 = v6 - a2;
      this.Timer = v8;
      if ( v8 <= 0.0f )
      {
        v9 = this.VfTableObject.Dummy;
        this.Timer = 0.0f;
        CallUFunction(this.OnMoveTimer, this, v10, 0, 0);
        v7 = a2;
      }
    }
    this.MoveActiveTime = v7 + this.MoveActiveTime;
  }

  public unsafe bool IsLandingOnSoftObject()
  {
    TdPawn v2 = default; // ecx
    float v3 = default; // ebx
    float v4 = default; // xmm0_4
    PhysicalMaterial v5 = default; // eax
    MaterialInterface v6 = default; // ebx
    TdPhysicalMaterialProperty v7 = default; // eax
    MaterialInstance v8 = default; // eax
    StaticMeshActor v9 = default; // eax
    MaterialInterface v10 = default; // eax
    StaticMeshComponent v11 = default; // eax
    MaterialInterface v12 = default; // eax
    Vector a4 = default; // [esp+0h] [ebp-70h] BYREF
    Vector a3 = default; // [esp+Ch] [ebp-64h] BYREF
    Vector a5 = default; // [esp+18h] [ebp-58h] BYREF
    CheckResult a2 = default; // [esp+24h] [ebp-4Ch] BYREF
    int v18 = default; // [esp+6Ch] [ebp-4h]
  
    v2 = this.PawnOwner;
    a2.Item = -1;
    a2.LevelIndex = -1;
    a4.X = v2.Location.X;
    a4.Y = v2.Location.Y;
    v3 = v2.Location.Z;
    a2.Location.X = 0.0f;
    a2.Location.Y = 0.0f;
    a2.Location.Z = 0.0f;
    a2.Normal.X = 0.0f;
    a2.Normal.Y = 0.0f;
    a2.Normal.Z = 0.0f;
    a4.Z = v3;
    a3.Y = a4.Y;
    a3.Z = v3;
    a2.Time = 1.0f;
    a3.X = a4.X;
    v4 = (float)(v3 - v2.CylinderComponent.CollisionHeight) - 20.0f;
    a2.Next = default;
    a2.Actor = default;
    a2.Material = default;
    a2.PhysMaterial = default;
    a2.Component = default;
    a2.BoneName = default;
    a2.Level = default;
    a2.bStartPenetrating = default;
    v18 = default;
    a3.Z = v4;
    v2.GetCylinderExtent(&a5);
    a5.Z = 5.0f;
    if ( default == this.MovementLineCheck(ref a2, &a3, &a4, &a5, 9414) )
      return false;
    if ( a2.Normal.Z <= 0.89999998d )
      return false;
    v5 = a2.PhysMaterial;
    v6 = a2.Material;
    if ( default == a2.PhysMaterial )
    {
      if ( default == a2.Material )
        return false;
      v5 = (PhysicalMaterial )a2.Material.GetPhysicalMaterial();// UMaterial::GetPhysicalMaterial
      if ( default == v5 )
        return false;
    }
    v7 = E_TryCastTo<TdPhysicalMaterialProperty>(v5.PhysicalMaterialProperty);
    if ( default == v7 || (v7.bEnableSoftLanding.AsBitfield(4) & 1) == default )
      return false;
    SetFromBitfield(ref this.bForceLandBack, 2, this.bForceLandBack.AsBitfield(2) | (2u));
    v8 = E_TryCastTo<MaterialInstance>(v6);
    this.SoftLandingMaterialInstance = v8;
    if ( default == v8 )
    {
      v9 = E_TryCastTo<StaticMeshActor>(a2.Actor);
      if(v9 != default)
      {
        v10 = (MaterialInterface )v9.StaticMeshComponent.GetMaterial( 0);// UStaticMeshComponent::GetMaterial
        this.SoftLandingMaterialInstance = E_TryCastTo<MaterialInstanceConstant>(v10);
      }
      if ( default == this.SoftLandingMaterialInstance )
      {
        v11 = E_TryCastTo<StaticMeshComponent>(a2.Component);
        if(v11 != default)
        {
          v12 = (MaterialInterface )v11.GetMaterial( 0);// UStaticMeshComponent::GetMaterial
          this.SoftLandingMaterialInstance = E_TryCastTo<MaterialInstanceConstant>(v12);
        }
      }
    }
    return true;
  }
}
}
