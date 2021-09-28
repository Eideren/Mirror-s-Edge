namespace MEdge.TdGame{
  using static MEdge.Source.DecFn;
  using System;
  using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
public partial class TdAnimNodeAgainstWallState
{
  public override float GetBlendValue( int a2, int a3 )
  {
    //_E_struct_ATdPawn *__ptr32 TdPawnOwner; // eax
    //_E_enum_EMovement MovementState; // al
    float v6; // [esp+0h] [ebp-4h]

    //TdPawnOwner = this.TdPawnOwner;
    v6 = 0.0f;
    if ( TdPawnOwner )
    {
      var MovementState = TdPawnOwner.MovementState;
      if ( MovementState == TdPawn.EMovement.MOVE_WallClimbing || MovementState == TdPawn.EMovement.MOVE_VaultOver )
        return 0.1f;
    }
    return v6;
  }
  #region src
  /*float __thiscall UTdAnimNodeAgainstWallState::GetBlendValue(
  _E_struct_UTdAnimNodeAgainstWallState *this,
  int a2,
  int a3)
  {
    _E_struct_ATdPawn *__ptr32 TdPawnOwner; // eax
    _E_enum_EMovement MovementState; // al
    float v6; // [esp+0h] [ebp-4h]

    TdPawnOwner = this->TdPawnOwner;
    v6 = 0.0;
    if ( TdPawnOwner )
    {
      MovementState = TdPawnOwner->MovementState;
      if ( MovementState == MOVE_WallClimbing || MovementState == MOVE_VaultOver )
        return 0.1;
    }
    return v6;
  }*/
  #endregion
  public override int GetState()
  {
    TdPawn  TdPawnOwner; // eax
  
    TdPawnOwner = this.TdPawnOwner;
    if ( TdPawnOwner )
      return (int)TdPawnOwner.AgainstWallState;
    else
      return 0;
  }
#region src
/*
int __thiscall UTdAnimNodeAgainstWallState::GetState(_E_struct_UTdAnimNodeState *this)
{
  _E_struct_ATdPawn *__ptr32 TdPawnOwner; // eax

  TdPawnOwner = this->TdPawnOwner;
  if ( TdPawnOwner )
    return TdPawnOwner->AgainstWallState;
  else
    return 0;
}*/
#endregion
}



public partial class TdAnimNodeAimState
{
  public override int GetActiveState()
  {
    TdPawn  TdPawnOwner; // eax
  
    TdPawnOwner = this.TdPawnOwner;
    if ( TdPawnOwner == null )
      return 0;
    /*if ( this.bOnlyMoveMode )
      return (int)(*(unsigned __int8 (__stdcall **)(_DWORD))(TdPawnOwner.Moves[TdPawnOwner.MovementState].VfTableObject.Dummy
                                                      + 276))(0);
    return (int)ATdPawn::GetAimMode_Maybe(TdPawnOwner, 0);*/
    
    NativeMarkers.MarkUnimplemented();
    return 0;
  }
#region src
/*
int __thiscall UTdAnimNodeAimState::GetActiveState(_E_struct_UTdAnimNodeAimState *this)
{
  _E_struct_ATdPawn *__ptr32 TdPawnOwner; // eax

  TdPawnOwner = this->TdPawnOwner;
  if ( !TdPawnOwner )
    return 0;
  if ( (this->bitfield_bOnlyMoveMode & bOnlyMoveMode) != 0 )
    return (*(unsigned __int8 (__stdcall **)(_DWORD))(TdPawnOwner->Moves.Data[TdPawnOwner->MovementState]->VfTableObject.Dummy
                                                    + 276))(0);
  return ATdPawn::GetAimMode_Maybe(TdPawnOwner, 0);
}*/
#endregion
}



public partial class TdAnimNodeCinematicSwitch
{
  public override bool GetState()
  {
    TdPlayerPawn pawn; // eax
    TdPlayerController controller; // eax
  
    pawn = E_TryCastTo<TdPlayerPawn>(this.TdPawnOwner);
    if ( pawn && (controller = E_TryCastTo<TdPlayerController>(pawn.Controller)) != null )
      return controller.bCinematicMode;
    else
      return false;
  }
#region src
/*
int __thiscall UTdAnimNodeCinematicSwitch::GetState(_E_struct_UTdAnimNodeCinematicSwitch *this)
{
  _E_struct_ATdPlayerPawn *pawn; // eax
  _E_struct_ATdPlayerController *controller; // eax

  pawn = E_TryCastToATdPlayerPawn(this->TdPawnOwner);
  if ( pawn && (controller = E_TryCastToATdPlayerController(pawn->Controller)) != 0 )
    return (controller->bitfield_bFrozen_And25More >> 14) & 1;// bCinematicMode
  else
    return 0;
}*/
#endregion
}



public partial class TdAnimNodeClimb
{
  public override void TickAnim(float DeltaTime, float TotalWeight)
  {
    SkeletalMeshComponent  SkelComponent; // eax
    TdPawn pawn; // eax
    TdPawn pawn2; // esi
    TdMove_Climb moveClimb; // ebx
    TdPlayerController controller; // eax
    uint Yaw; // eax
    int camToPawnDelta; // eax
    int StartTurningAngle; // ecx
    //bitfield_bDisableSkelControlSpring_And31More_ATdPawn bDisableSkelControlSpring_etc; // eax
    int newMove; // eax
  
    SkelComponent = this.SkelComponent;
    if ( SkelComponent )
    {
      pawn = E_TryCastTo<TdPawn>(SkelComponent.Owner);
      pawn2 = pawn;
      if ( pawn )
      {
        moveClimb = E_TryCastTo<TdMove_Climb>(pawn.Moves[21]);
        controller = E_TryCastTo<TdPlayerController>(pawn2.Controller);
        if ( controller )
          Yaw = (uint)controller.Rotation.Yaw;
        else
          Yaw = (uint)pawn2.RemoteViewYaw;
        camToPawnDelta = (ushort)(Yaw - LOWORD(pawn2.Rotation.Yaw));
        if ( camToPawnDelta > 32767 )
          camToPawnDelta -= 65536;
        StartTurningAngle = moveClimb.StartTurningAngle;
        if ( camToPawnDelta <= StartTurningAngle )
        {
          if ( camToPawnDelta >= -StartTurningAngle )
          {
            //bDisableSkelControlSpring_etc = pawn2.bitfield_bDisableSkelControlSpring_And31More;
            if ( pawn2.LadderType == 1 )
            {
              if ( pawn2.bClimbDownFast )
                newMove = 5;
              else
                newMove = 4 - (pawn2.bClimbLeftHand ? 1 : 0);
            }
            else if ( pawn2.bClimbDownFast )
            {
              newMove = 2;
            }
            else
            {
              newMove = (pawn2.bClimbLeftHand ? 0 : 1);
            }

            SetActiveMove( newMove, false );
          }
          else
          {
            SetActiveMove( 6, false );
          }
        }
        else
        {
          SetActiveMove(7, false);
        }
      }
    }
    base.TickAnim(DeltaTime, TotalWeight);
  }
#region src
/*
void __thiscall UTdAnimNodeClimb::TickAnim(_E_struct_UTdAnimNodeClimb *this, float DeltaTime, float TotalWeight)
{
  _E_struct_USkeletalMeshComponent *__ptr32 SkelComponent; // eax
  _E_struct_ATdPawn *pawn; // eax
  _E_struct_ATdPawn *pawn2; // esi
  _E_struct_UTdMove_Climb *moveClimb; // ebx
  _E_struct_ATdPlayerController *controller; // eax
  unsigned int Yaw; // eax
  int camToPawnDelta; // eax
  int StartTurningAngle; // ecx
  _E_enum_bitfield_bDisableSkelControlSpring_And31More_ATdPawn bDisableSkelControlSpring_etc; // eax
  int newMove; // eax

  SkelComponent = this->SkelComponent;
  if ( SkelComponent )
  {
    pawn = E_TryCastToATdPawn(SkelComponent->Owner);
    pawn2 = pawn;
    if ( pawn )
    {
      moveClimb = E_TryCastToUTdMove_Climb(pawn->Moves.Data[21]);
      controller = E_TryCastToATdPlayerController(pawn2->Controller);
      if ( controller )
        Yaw = controller->Rotation.Yaw;
      else
        Yaw = pawn2->RemoteViewYaw;
      camToPawnDelta = (unsigned __int16)(Yaw - LOWORD(pawn2->Rotation.Yaw));
      if ( camToPawnDelta > 32767 )
        camToPawnDelta -= 65536;
      StartTurningAngle = moveClimb->StartTurningAngle;
      if ( camToPawnDelta <= StartTurningAngle )
      {
        if ( camToPawnDelta >= -StartTurningAngle )
        {
          bDisableSkelControlSpring_etc = pawn2->bitfield_bDisableSkelControlSpring_And31More;
          if ( pawn2->LadderType == 1 )
          {
            if ( (bDisableSkelControlSpring_etc & bClimbDownFast) != 0 )
              newMove = 5;
            else
              newMove = 4 - ((bDisableSkelControlSpring_etc & bClimbLeftHand) != 0);
          }
          else if ( (bDisableSkelControlSpring_etc & bClimbDownFast) != 0 )
          {
            newMove = 2;
          }
          else
          {
            newMove = (pawn2->bitfield_bDisableSkelControlSpring_And31More & bClimbLeftHand) == 0;
          }
          (*(void (__stdcall **)(int, _DWORD))(this->VfTableObject.Dummy + 412))(newMove, 0);// 121007F - TdAnimNodeBlendList::SetActiveMove
        }
        else
        {
          (*(void (__stdcall **)(int, _DWORD))(this->VfTableObject.Dummy + 412))(6, 0);
        }
      }
      else
      {
        (*(void (__stdcall **)(int, _DWORD))(this->VfTableObject.Dummy + 412))(7, 0);
      }
    }
  }
  UTdAnimNodeBlendList::TickAnim(this, DeltaTime, TotalWeight);
}*/
#endregion
}



public partial class TdAnimNodeDirBone
{
  public override void TickAnim(float DeltaTime, float TotalWeight)
  {
    TdPawn pawn; // eax
    TdPawn pawn2; // esi
    int GoBackLegAngleLimitMax; // eax
    int GoBackLegAngleLimitMin; // ecx
    float newAimX; // xmm0_4
    float newAimX2; // xmm1_4
    TdAIController tdAiController; // eax
    int Pitch; // eax
    float Y; // xmm0_4
    Controller  Controller; // eax
  
    pawn = E_TryCastTo<TdPawn>(this.SkelComponent.Owner);
    pawn2 = pawn;
    if ( pawn == null )
    {
      if ( this.bUsePitch )
      {
        Y = this.Aim.Y;
        goto LABEL_35;
      }
      Y = 0.0f;
      goto LABEL_35;
    }
    GoBackLegAngleLimitMax = (ushort)(LOWORD(pawn.LegRotation) - LOWORD(pawn.Rotation.Yaw));
    if ( (ushort)(LOWORD(pawn2.LegRotation) - LOWORD(pawn2.Rotation.Yaw)) > 32767u )
      GoBackLegAngleLimitMax -= 65536;
    GoBackLegAngleLimitMin = pawn2.GoBackLegAngleLimitMin;
    if ( GoBackLegAngleLimitMax < GoBackLegAngleLimitMin )
      GoBackLegAngleLimitMax = pawn2.GoBackLegAngleLimitMin;
    if ( GoBackLegAngleLimitMax > pawn2.GoBackLegAngleLimitMax )
      GoBackLegAngleLimitMax = pawn2.GoBackLegAngleLimitMax;
    if ( GoBackLegAngleLimitMax < 0 )
    {
      if ( GoBackLegAngleLimitMin < 0 )
        GoBackLegAngleLimitMin = -GoBackLegAngleLimitMin;
    }
    else
    {
      GoBackLegAngleLimitMin = pawn2.GoBackLegAngleLimitMax;
    }
    if ( GoBackLegAngleLimitMin <= 1 )
      GoBackLegAngleLimitMin = 1;
    newAimX = (float)GoBackLegAngleLimitMax / (float)GoBackLegAngleLimitMin;
    this.Aim.X = newAimX;
    if ( pawn2.MovementState == TdPawn.EMovement.MOVE_Crouch )
    {
      newAimX2 = -0.69999999f;
      if ( newAimX >= -0.69999999d )
      {
        newAimX2 = 0.69999999f;
        if ( newAimX2 >= newAimX )
          goto LABEL_21;
        newAimX = newAimX2;
        goto LABEL_21;
      }
    }
    else
    {
      newAimX2 = -1.0f;
      if ( newAimX >= -1.0f )
      {
        newAimX2 = 1.0f;
  LABEL_19:
        if ( newAimX2 >= newAimX )
          goto LABEL_21;
      }
    }
    newAimX = newAimX2;
  LABEL_21:
    this.Aim.X = newAimX;
    tdAiController = E_TryCastTo<TdAIController>(pawn2.Controller);
    if ( tdAiController == null )
    {
      Controller = pawn2.Controller;
      if ( Controller )
      {
        if ( this.bUsePitch )
        {
          Pitch = Controller.Rotation.Pitch - pawn2.Rotation.Pitch;
          goto LABEL_24;
        }
      }
      else if ( this.bUsePitch )
      {
        Pitch = (pawn2.RemoteViewPitch << 8) - pawn2.Rotation.Pitch;
        goto LABEL_24;
      }
  LABEL_34:
      Y = 0.0f;
      goto LABEL_35;
    }
    if( this.bUsePitch == false )
    {
      Y = 0.0f;
      goto LABEL_35;
    }
    Pitch = tdAiController.AimingRotation.Pitch;
  LABEL_24:
    Pitch = (ushort)Pitch;
    if ( (ushort)Pitch > 32767u )
      Pitch = (ushort)Pitch - 65536;
    Y = (float)Pitch * 0.000061035156f;
  LABEL_35:
    this.Aim.Y = Y;
    base.TickAnim(DeltaTime, TotalWeight);
  }
#region src
/*
void __thiscall UTdAnimNodeDirBone::TickAnim(_E_struct_UTdAnimNodeDirBone *this, float DeltaTime, float TotalWeight)
{
  _E_struct_ATdPawn *pawn; // eax
  _E_struct_ATdPawn *pawn2; // esi
  int GoBackLegAngleLimitMax; // eax
  int GoBackLegAngleLimitMin; // ecx
  float newAimX; // xmm0_4
  float newAimX2; // xmm1_4
  _E_struct_ATdAIController *tdAiController; // eax
  int Pitch; // eax
  float Y; // xmm0_4
  _E_struct_AController *__ptr32 Controller; // eax

  pawn = E_TryCastToATdPawn(this->SkelComponent->Owner);
  pawn2 = pawn;
  if ( !pawn )
  {
    if ( (this->bitfield_bUsePitch_And1More & 1) != 0 )
    {
      Y = this->Aim.Y;
      goto LABEL_35;
    }
    goto LABEL_34;
  }
  GoBackLegAngleLimitMax = (unsigned __int16)(LOWORD(pawn->LegRotation) - LOWORD(pawn->Rotation.Yaw));
  if ( (unsigned __int16)(LOWORD(pawn2->LegRotation) - LOWORD(pawn2->Rotation.Yaw)) > 32767u )
    GoBackLegAngleLimitMax -= 65536;
  GoBackLegAngleLimitMin = pawn2->GoBackLegAngleLimitMin;
  if ( GoBackLegAngleLimitMax < GoBackLegAngleLimitMin )
    GoBackLegAngleLimitMax = pawn2->GoBackLegAngleLimitMin;
  if ( GoBackLegAngleLimitMax > pawn2->GoBackLegAngleLimitMax )
    GoBackLegAngleLimitMax = pawn2->GoBackLegAngleLimitMax;
  if ( GoBackLegAngleLimitMax < 0 )
  {
    if ( GoBackLegAngleLimitMin < 0 )
      GoBackLegAngleLimitMin = -GoBackLegAngleLimitMin;
  }
  else
  {
    GoBackLegAngleLimitMin = pawn2->GoBackLegAngleLimitMax;
  }
  if ( GoBackLegAngleLimitMin <= 1 )
    GoBackLegAngleLimitMin = 1;
  newAimX = (float)GoBackLegAngleLimitMax / (float)GoBackLegAngleLimitMin;
  this->Aim.X = newAimX;
  if ( pawn2->MovementState == MOVE_Crouch )
  {
    newAimX2 = -0.69999999;
    if ( newAimX >= -0.69999999 )
    {
      newAimX2 = 0.69999999;
      goto LABEL_19;
    }
  }
  else
  {
    newAimX2 = -1.0;
    if ( newAimX >= -1.0 )
    {
      newAimX2 = 1.0;
LABEL_19:
      if ( newAimX2 >= newAimX )
        goto LABEL_21;
    }
  }
  newAimX = newAimX2;
LABEL_21:
  this->Aim.X = newAimX;
  tdAiController = E_TryCastToTdAIController(pawn2->Controller);
  if ( !tdAiController )
  {
    Controller = pawn2->Controller;
    if ( Controller )
    {
      if ( (this->bitfield_bUsePitch_And1More & bUsePitch) != 0 )
      {
        Pitch = Controller->Rotation.Pitch - pawn2->Rotation.Pitch;
        goto LABEL_24;
      }
    }
    else if ( (this->bitfield_bUsePitch_And1More & bUsePitch) != 0 )
    {
      Pitch = (pawn2->RemoteViewPitch << 8) - pawn2->Rotation.Pitch;
      goto LABEL_24;
    }
LABEL_34:
    Y = 0.0;
    goto LABEL_35;
  }
  if ( (this->bitfield_bUsePitch_And1More & bUsePitch) == 0 )
    goto LABEL_34;
  Pitch = tdAiController->AimingRotation.Pitch;
LABEL_24:
  Pitch = (unsigned __int16)Pitch;
  if ( (unsigned __int16)Pitch > 32767u )
    Pitch = (unsigned __int16)Pitch - 65536;
  Y = (float)Pitch * 0.000061035156;
LABEL_35:
  this->Aim.Y = Y;
  UAnimNodeBlendBase::TickAnim(this, DeltaTime, TotalWeight);
}*/
#endregion
}



public partial class TdAnimNodeDirBoneAI
{
  public override void TickAnim(float DeltaTime, float TotalWeight)
  {
    base.TickAnim(DeltaTime, TotalWeight);
  }
#region src
/*
void __thiscall UTdAnimNodeDirBoneAI::TickAnim(_E_struct_UTdAnimNodeDirBone *this, float DeltaTime, float TotalWeight)
{
  UTdAnimNodeDirBone::TickAnim(this, DeltaTime, TotalWeight);
}*/
#endregion
}



public partial class TdAnimNodeGrabbing
{
  public override void TickAnim(float DeltaTime, float TotalWeight)
  {
    SkeletalMeshComponent  SkelComponent; // eax
    TdPawn pawn; // eax
    TdPawn pawn2; // edi
    Controller  Controller; // eax
    uint Yaw; // eax
    int newCurrentDeltaYaw; // eax
    TdMove_Grab grabMove; // ebx
    int IsHangingFree; // eax
    int CurrentDeltaYaw; // ecx
    int absDeltaYaw; // edx
    float StartTurningAngle; // xmm1_4
    float v15; // xmm0_4
    //_E_struct_FAnimBlendChild *__ptr32 Data; // ecx
    float v17; // xmm1_4
    float v18; // xmm3_4
    float v19; // xmm2_4
    //_E_struct_FAnimBlendChild *__ptr32 child; // eax
    float v21; // xmm0_4
    //_E_struct_FAnimBlendChild *__ptr32 v22; // eax
    float v23; // xmm3_4
    float v24; // xmm1_4
    float blendWeight; // xmm0_4
    bool newActiveMove; // eax
  
    SkelComponent = this.SkelComponent;
    if ( SkelComponent )
    {
      pawn = E_TryCastTo<TdPawn>(SkelComponent.Owner);
      pawn2 = pawn;
      if ( pawn )
      {
        if ( TotalWeight > 0.0f )
        {
          Controller = pawn.Controller;
          if ( Controller )
            Yaw = (uint)Controller.Rotation.Yaw;
          else
            Yaw = (uint)pawn2.RemoteViewYaw;
          newCurrentDeltaYaw = (ushort)(Yaw - LOWORD(pawn2.Rotation.Yaw));
          if ( newCurrentDeltaYaw > 32767 )
            newCurrentDeltaYaw -= 65536;
          this.CurrentDeltaYaw = newCurrentDeltaYaw;
          grabMove = E_TryCastTo<TdMove_Grab>(pawn2.Moves[3]);
          IsHangingFree = grabMove.IsHangingFree() ? 1 : 0;//(*(int (**)(void))(grabMove.VfTableObject.Dummy + 304))();// UTdMove_Grab::IsHangingFree
          switch ( pawn2.CurrentGrabTurnType )
          {
            case TdPawn.EGrabTurnType.GTT_None:
            case TdPawn.EGrabTurnType.GTT_Start:
              if ( grabMove.GrabType == grabMove.PreviousGrabType )
                blendWeight = 0.0f;
              else
                blendWeight = 0.5f;
              newActiveMove = IsHangingFree != 0;
              this.BlendWeight[newActiveMove ? 1 : 0] = blendWeight;
              SetActiveMove(newActiveMove ? 1 : 0, false);
              break;
            case TdPawn.EGrabTurnType.GTT_End:
            case TdPawn.EGrabTurnType.GTT_Idle:
              CurrentDeltaYaw = this.CurrentDeltaYaw;
              absDeltaYaw = this.CurrentDeltaYaw;
              if ( CurrentDeltaYaw < 0 )
                absDeltaYaw = -absDeltaYaw;
              StartTurningAngle = grabMove.StartTurningAngle;
              v15 = (float)((float)absDeltaYaw - StartTurningAngle) / (float)(32768.0f - StartTurningAngle);
              if ( (float)CurrentDeltaYaw > StartTurningAngle )
              {
                if ( IsHangingFree == 0 )
                {
                  v17 = 0.0f;
                  v18 = 1.0f;
                  this.ActiveChildIndex = 3;
                  this.Children[0].Weight = 0.0f;
                  this.Children[1].Weight = 0.0f;
                  v19 = 1.0f - v15;
                  this.Children[2].Weight = 0.0f;
                  if ( (float)(1.0f - v15) >= 0.0f )
                  {
                    if ( v19 > 1.0f )
                      v19 = 1.0f;
                  }
                  else
                  {
                    v19 = 0.0f;
                  }
                  this.Children[3].Weight = v19;
                  this.Children[4].Weight = 0.0f;
                  v21 = v15 - this.Children[0].Weight;
                  if ( v21 < 0.0f || ((v17 = v21) <= 1.0f) )
                    v18 = v17;
                  this.Children[5].Weight = v18;
                  break;
                }
  LABEL_24:
                SetActiveMove(1, false);
                break;
              }
              if ( (float)(-0.0f - grabMove.StartTurningAngle) <= (float)CurrentDeltaYaw )
                break;
              if( IsHangingFree != 0 )
              {
                SetActiveMove(1, false);
                break;
              }

              v23 = 1.0f;
              this.ActiveChildIndex = 2;
              this.Children[0].Weight = 0.0f;
              v24 = 1.0f - v15;
              this.Children[1].Weight = 0.0f;
              if ( (float)(1.0f - v15) >= 0.0f )
              {
                if ( v24 > 1.0f )
                  v24 = 1.0f;
              }
              else
              {
                v24 = 0.0f;
              }
              this.Children[2].Weight = v24;
              this.Children[3].Weight = 0.0f;
              if ( v15 >= 0.0f )
              {
                if ( v15 > 1.0f )
                {
  LABEL_33:
                  this.Children[4].Weight = v23;
                  this.Children[5].Weight = 0.0f;
                  break;
                }
              }
              else
              {
                v15 = 0.0f;
              }
              v23 = v15;
              this.Children[4].Weight = v23;
              this.Children[5].Weight = 0.0f;
              break;
            default:
              break;
          }
        }
      }
    }
    base.TickAnim(DeltaTime, TotalWeight);
  }
#region src
/*
void __thiscall UTdAnimNodeGrabbing::TickAnim(_E_struct_UTdAnimNodeGrabbing *this, float DeltaTime, float TotalWeight)
{
  _E_struct_USkeletalMeshComponent *__ptr32 SkelComponent; // eax
  _E_struct_ATdPawn *pawn; // eax
  _E_struct_ATdPawn *pawn2; // edi
  _E_struct_AController *__ptr32 Controller; // eax
  unsigned int Yaw; // eax
  int newCurrentDeltaYaw; // eax
  _E_struct_UTdMove_Grab *grabMove; // ebx
  int IsHangingFree; // eax
  int CurrentDeltaYaw; // ecx
  int absDeltaYaw; // edx
  float StartTurningAngle; // xmm1_4
  float v15; // xmm0_4
  _E_struct_FAnimBlendChild *__ptr32 Data; // ecx
  float v17; // xmm1_4
  float v18; // xmm3_4
  float v19; // xmm2_4
  _E_struct_FAnimBlendChild *__ptr32 child; // eax
  float v21; // xmm0_4
  _E_struct_FAnimBlendChild *__ptr32 v22; // eax
  float v23; // xmm3_4
  float v24; // xmm1_4
  float blendWeight; // xmm0_4
  BOOL newActiveMove; // eax

  SkelComponent = this->SkelComponent;
  if ( SkelComponent )
  {
    pawn = E_TryCastToATdPawn(SkelComponent->Owner);
    pawn2 = pawn;
    if ( pawn )
    {
      if ( TotalWeight > 0.0 )
      {
        Controller = pawn->Controller;
        if ( Controller )
          Yaw = Controller->Rotation.Yaw;
        else
          Yaw = pawn2->RemoteViewYaw;
        newCurrentDeltaYaw = (unsigned __int16)(Yaw - LOWORD(pawn2->Rotation.Yaw));
        if ( newCurrentDeltaYaw > 32767 )
          newCurrentDeltaYaw -= 65536;
        this->CurrentDeltaYaw = newCurrentDeltaYaw;
        grabMove = E_TryCastToUTdMove_Grab(pawn2->Moves.Data[3]);
        IsHangingFree = (*(int (**)(void))(grabMove->VfTableObject.Dummy + 304))();// UTdMove_Grab::IsHangingFree
        switch ( pawn2->CurrentGrabTurnType )
        {
          case GTT_None:
          case GTT_Start:
            if ( grabMove->GrabType == grabMove->PreviousGrabType )
              blendWeight = 0.0;
            else
              blendWeight = 0.5;
            newActiveMove = IsHangingFree != 0;
            this->BlendWeight.Data[newActiveMove] = blendWeight;
            (*(void (__stdcall **)(BOOL, _DWORD))(this->VfTableObject.Dummy + 412))(newActiveMove, 0);// SetActiveMove
            break;
          case GTT_End:
          case GTT_Idle:
            CurrentDeltaYaw = this->CurrentDeltaYaw;
            absDeltaYaw = this->CurrentDeltaYaw;
            if ( CurrentDeltaYaw < 0 )
              absDeltaYaw = -absDeltaYaw;
            StartTurningAngle = grabMove->StartTurningAngle;
            v15 = (float)((float)absDeltaYaw - StartTurningAngle) / (float)(32768.0 - StartTurningAngle);
            if ( (float)CurrentDeltaYaw > StartTurningAngle )
            {
              if ( !IsHangingFree )
              {
                Data = this->Children.Data;
                v17 = 0.0;
                v18 = 1.0;
                this->ActiveChildIndex = 3;
                Data->Weight = 0.0;
                this->Children.Data[1].Weight = 0.0;
                v19 = 1.0 - v15;
                this->Children.Data[2].Weight = 0.0;
                if ( (float)(1.0 - v15) >= 0.0 )
                {
                  if ( v19 > 1.0 )
                    v19 = 1.0;
                }
                else
                {
                  v19 = 0.0;
                }
                this->Children.Data[3].Weight = v19;
                this->Children.Data[4].Weight = 0.0;
                child = this->Children.Data;
                v21 = v15 - child->Weight;
                if ( v21 < 0.0 || (v17 = v21, v21 <= 1.0) )
                  v18 = v17;
                child[5].Weight = v18;
                break;
              }
LABEL_24:
              (*(void (__stdcall **)(int, _DWORD))(this->VfTableObject.Dummy + 412))(1, 0);// SetActiveMove
              break;
            }
            if ( (float)(-0.0 - grabMove->StartTurningAngle) <= (float)CurrentDeltaYaw )
              break;
            if ( IsHangingFree )
              goto LABEL_24;
            v22 = this->Children.Data;
            v23 = 1.0;
            this->ActiveChildIndex = 2;
            v22->Weight = 0.0;
            v24 = 1.0 - v15;
            this->Children.Data[1].Weight = 0.0;
            if ( (float)(1.0 - v15) >= 0.0 )
            {
              if ( v24 > 1.0 )
                v24 = 1.0;
            }
            else
            {
              v24 = 0.0;
            }
            this->Children.Data[2].Weight = v24;
            this->Children.Data[3].Weight = 0.0;
            if ( v15 >= 0.0 )
            {
              if ( v15 > 1.0 )
              {
LABEL_33:
                this->Children.Data[4].Weight = v23;
                this->Children.Data[5].Weight = 0.0;
                break;
              }
            }
            else
            {
              v15 = 0.0;
            }
            v23 = v15;
            goto LABEL_33;
          default:
            break;
        }
      }
    }
  }
  UTdAnimNodeBlendList::TickAnim(this, DeltaTime, TotalWeight);
}*/
#endregion
}



public partial class TdAnimNodeGrabSlope
{
  public virtual void UpdateWeights()
  {
    SkeletalMeshComponent  SkelComponent; // eax
    TdPawn pawn; // eax
    float Y; // xmm0_4
    float X; // xmm4_4
    double preAbsDot; // st7
    double preAngle; // st7
    float angle; // xmm1_4
    int v8; // eax
    float angleOrZero; // xmm2_4
    float preAbsDotClamped; // [esp+4h] [ebp-10h]
    float absDot; // [esp+4h] [ebp-10h]
    float zScaled_Y; // [esp+8h] [ebp-Ch]
    float x_ZScaled; // [esp+Ch] [ebp-8h]
    float yScaled_XScaled; // [esp+10h] [ebp-4h]
  
    SkelComponent = this.SkelComponent;
    if ( SkelComponent )
    {
      pawn = E_TryCastTo<TdPawn>(SkelComponent.Owner);
      if ( pawn )
      {
        if ( this.Children.Count == 3 )
        {
          Y = pawn.MoveNormal.Y;
          zScaled_Y = (float)(pawn.MoveNormal.Z * 0.0f) - Y;
          X = pawn.MoveNormal.X;
          yScaled_XScaled = (float)(Y * 0.0f) - (float)(X * 0.0f);
          x_ZScaled = X - (float)(pawn.MoveNormal.Z * 0.0f);
          preAbsDot = fabs(
                        pawn.MoveLedgeNormal.Z * yScaled_XScaled
                      + pawn.MoveLedgeNormal.Y * x_ZScaled
                      + pawn.MoveLedgeNormal.X * zScaled_Y);// MoveLedgeNormal dot (Z*0 - Y, X - Z*0, Y*0 - x*0)
          if ( preAbsDot >= -1.0f )                // Clamp
          {
            preAbsDotClamped = (float)preAbsDot;
            if ( preAbsDotClamped >= 1.0f )
              preAbsDotClamped = 1.0f;
          }
          else
          {
            preAbsDotClamped = -1.0f;
          }
          preAngle = asin(preAbsDotClamped) * 1.2732395d;
          if ( preAngle < -1.0f )                  // Clamp
          {
            angle = -1.0f;
          }
          else
          {
            angle = (float)preAngle;
            absDot = (float)preAngle;
            if ( absDot > 1.0f )
              angle = 1.0f;
          }
          if ( (float)((float)((float)(pawn.MoveLedgeNormal.Z * yScaled_XScaled)
                             + (float)(pawn.MoveLedgeNormal.Y * x_ZScaled))
                     + (float)(pawn.MoveLedgeNormal.X * zScaled_Y)) <= 0.0f )// dot <= 0
          {
            v8 = 0;
            angleOrZero = 0.0f;
          }
          else
          {
            v8 = 1;
            angleOrZero = angle;
          }
          this.Children[2].Weight = angleOrZero;
          if ( v8 != 0 )
            angle = 0.0f;
          this.Children[1].Weight = angle;
          this.Children[0].Weight = (float)(1.0f - this.Children[1].Weight) - this.Children[2].Weight;
        }
      }
    }
  }
#region src
/*
void __thiscall UTdAnimNodeGrabSlope::UpdateWeights(_E_struct_UTdAnimNodeGrabSlope *this)
{
  _E_struct_USkeletalMeshComponent *__ptr32 SkelComponent; // eax
  _E_struct_ATdPawn *pawn; // eax
  float Y; // xmm0_4
  float X; // xmm4_4
  long double preAbsDot; // st7
  long double preAngle; // st7
  float angle; // xmm1_4
  int v8; // eax
  float angleOrZero; // xmm2_4
  float preAbsDotClamped; // [esp+4h] [ebp-10h]
  float absDot; // [esp+4h] [ebp-10h]
  float zScaled_Y; // [esp+8h] [ebp-Ch]
  float x_ZScaled; // [esp+Ch] [ebp-8h]
  float yScaled_XScaled; // [esp+10h] [ebp-4h]

  SkelComponent = this->SkelComponent;
  if ( SkelComponent )
  {
    pawn = E_TryCastToATdPawn(SkelComponent->Owner);
    if ( pawn )
    {
      if ( this->Children.Count == 3 )
      {
        Y = pawn->MoveNormal.Y;
        zScaled_Y = (float)(pawn->MoveNormal.Z * 0.0) - Y;
        X = pawn->MoveNormal.X;
        yScaled_XScaled = (float)(Y * 0.0) - (float)(X * 0.0);
        x_ZScaled = X - (float)(pawn->MoveNormal.Z * 0.0);
        preAbsDot = fabs(
                      pawn->MoveLedgeNormal.Z * yScaled_XScaled
                    + pawn->MoveLedgeNormal.Y * x_ZScaled
                    + pawn->MoveLedgeNormal.X * zScaled_Y);// MoveLedgeNormal dot (Z*0 - Y, X - Z*0, Y*0 - x*0)
        if ( preAbsDot >= -1.0 )                // Clamp
        {
          preAbsDotClamped = preAbsDot;
          if ( preAbsDotClamped >= 1.0 )
            preAbsDotClamped = 1.0;
        }
        else
        {
          preAbsDotClamped = -1.0;
        }
        preAngle = asin(preAbsDotClamped) * 1.2732395;
        if ( preAngle < -1.0 )                  // Clamp
        {
          angle = -1.0;
        }
        else
        {
          angle = preAngle;
          absDot = preAngle;
          if ( absDot > 1.0 )
            angle = 1.0;
        }
        if ( (float)((float)((float)(pawn->MoveLedgeNormal.Z * yScaled_XScaled)
                           + (float)(pawn->MoveLedgeNormal.Y * x_ZScaled))
                   + (float)(pawn->MoveLedgeNormal.X * zScaled_Y)) <= 0.0 )// dot <= 0
        {
          v8 = 0;
          angleOrZero = 0.0;
        }
        else
        {
          v8 = 1;
          angleOrZero = angle;
        }
        this->Children.Data[2].Weight = angleOrZero;
        if ( v8 )
          angle = 0.0;
        this->Children.Data[1].Weight = angle;
        this->Children.Data->Weight = (float)(1.0 - this->Children.Data[1].Weight) - this->Children.Data[2].Weight;
      }
    }
  }
}*/
#endregion
}



public partial class TdAnimNodeIKEffectorController
{
  public virtual void CacheControllers()
  {
    //throw new NotImplementedException();
    AnimTree tree; // eax
    SkelControlBase SkelControl; // eax
    TdPawn pawn; // eax
  
    tree = E_TryCastTo<AnimTree>(this.SkelComponent.Animations);
    if ( tree )
    {
      SkelControl = tree.FindSkelControl(/*tree, dword_205628C, dword_2056290*/"LeftHandLocalIKController"); // Probably something like this ?
      this.LeftHandLocalIKController = E_TryCastTo<SkelControlLimb>(SkelControl);
    }
    pawn = E_TryCastTo<TdPawn>(this.SkelComponent.Owner);
    this.PawnOwner = pawn;
    if ( pawn )
      this.bCached = true;
  }
#region src
/*
void __thiscall UTdAnimNodeIKEffectorController::CacheControllers(_E_struct_UTdAnimNodeIKEffectorController *this)
{
  _E_struct_UAnimTree *tree; // eax
  _E_struct_USkelControlBase *SkelControl; // eax
  _E_struct_ATdPawn *pawn; // eax

  tree = E_TryCastToUAnimTree(this->SkelComponent->Animations);
  if ( tree )
  {
    SkelControl = UAnimTree::FindSkelControl(tree, dword_205628C, dword_2056290);
    this->LeftHandLocalIKController = E_TryCastToUSkelControlLimb(SkelControl);
  }
  pawn = E_TryCastToATdPawn(this->SkelComponent->Owner);
  this->PawnOwner = pawn;
  if ( pawn )
    this->bitfield_bCached_And1More |= 1u;      // bCached, in IDA enum labels cannot be shared between different enums for some reason, this enum's definition is empty because of that
}*/
#endregion
}



public partial class TdAnimNodeInAir
{
  public override void TickAnim(float DeltaTime, float TotalWeight)
  {
    int Dummy; // edi
    int newMove; // eax
  
    if ( TotalWeight >= 0.0000099999997d )
    {
      if ( this.TdPawnOwner )
      {
        Dummy = this.VfTableObject.Dummy;
        newMove = this.GetInAirState();//(*(int (__stdcall **)(_DWORD))(this.VfTableObject.Dummy + 416))(0);// Likely GetInAirState()
        SetActiveMove(newMove);
      }
      base.TickAnim(DeltaTime, TotalWeight);
    }
  }
#region src
/*
void __thiscall UTdAnimNodeInAir::TickAnim(_E_struct_UTdAnimNodeBlendList *this, float DeltaTime, float TotalWeight)
{
  int Dummy; // edi
  int newMove; // eax

  if ( TotalWeight >= 0.0000099999997 )
  {
    if ( this->TdPawnOwner )
    {
      Dummy = this->VfTableObject.Dummy;
      newMove = (*(int (__stdcall **)(_DWORD))(this->VfTableObject.Dummy + 416))(0);// Likely GetInAirState()
      (*(void (__stdcall **)(int))(Dummy + 412))(newMove);// SetActiveMove
    }
    UTdAnimNodeBlendList::TickAnim(this, DeltaTime, TotalWeight);
  }
}*/
#endregion
}



public partial class TdAnimNodeMovementState
{
  public override int GetActiveState()
  {
    TdPawn  tdPawnOwner; // eax
    int oldMovementState; // edx
    TdPawn.EMovement animationMovementState; // al
    int i; // eax
  
    tdPawnOwner = this.TdPawnOwner;
    oldMovementState = 0;
    if ( tdPawnOwner )
    {
      if ( this.bUseOldState )
      {
        oldMovementState = (int)tdPawnOwner.OldMovementState;
      }
      else
      {
        if ( tdPawnOwner.AnimationMovementState != 0 )
          animationMovementState = tdPawnOwner.AnimationMovementState;
        else
          animationMovementState = tdPawnOwner.MovementState;
        oldMovementState = (int)animationMovementState;
      }
    }
    i = 0;
    if ( this.StateMapping.Count > 0 )
    {
      while ( i < this.Children.Count - 1 )
      {
        if ( this.StateMapping[i] == oldMovementState )
        {
          this.SavedEnum = oldMovementState;
          return (int)i + 1;
        }
        if ( ++i >= this.StateMapping.Count )
          break;
      }
    }
    this.SavedEnum = 0;
    return 0;
  }
#region src
/*
int __thiscall UTdAnimNodeMovementState::GetActiveState(_E_struct_UTdAnimNodeMovementState *this)
{
  _E_struct_ATdPawn *__ptr32 tdPawnOwner; // eax
  int oldMovementState; // edx
  _E_enum_EMovement animationMovementState; // al
  int i; // eax

  tdPawnOwner = this->TdPawnOwner;
  oldMovementState = 0;
  if ( tdPawnOwner )
  {
    if ( (this->bitfield_bUseOldState & bUseOldState) != 0 )
    {
      oldMovementState = tdPawnOwner->OldMovementState;
    }
    else
    {
      if ( tdPawnOwner->AnimationMovementState )
        animationMovementState = tdPawnOwner->AnimationMovementState;
      else
        animationMovementState = tdPawnOwner->MovementState;
      oldMovementState = animationMovementState;
    }
  }
  i = 0;
  if ( this->StateMapping.Count > 0 )
  {
    while ( i < this->Children.Count - 1 )
    {
      if ( this->StateMapping.Data[i] == oldMovementState )
      {
        this->SavedEnum = oldMovementState;
        return i + 1;
      }
      if ( ++i >= this->StateMapping.Count )
        break;
    }
  }
  this->SavedEnum = 0;
  return 0;
}*/
#endregion
}



public partial class TdAnimNodeSequence
{
  public double GetScaleValue()
  {
    //bitfield_bSnapToKeyFrames_And11More_UTdAnimNodeSequence bitfield_bSnapToKeyFrames_And11More; // eax
    float playRateDir2; // xmm2_4
    float playRateDir; // xmm3_4
    float RateMax; // xmm4_4
    float RateMin; // xmm0_4
    TdPawn  TdPawnOwner; // edx
    double speed; // st7
    float Z; // xmm0_4
    float rateSelected2; // xmm0_4
    float rateSelected; // [esp+0h] [ebp-Ch]
    float goingForwardDir; // [esp+4h] [ebp-8h]
    float speed2; // [esp+4h] [ebp-8h]
  
    //bitfield_bSnapToKeyFrames_And11More = this.bitfield_bSnapToKeyFrames_And11More;
    playRateDir2 = 1.0f;
    if ( this.InversePlayRate )// InversePlayRate
      playRateDir = -1.0f;
    else
      playRateDir = 1.0f;
    RateMax = this.RateMax;
    RateMin = this.RateMin;
    if ( playRateDir >= RateMin )
      RateMin = playRateDir;
    if ( RateMax < RateMin )
      rateSelected = this.RateMax;
    else
      rateSelected = RateMin;
    if ( ScalePlayRateBySpeed )
    {
      TdPawnOwner = this.TdPawnOwner;
      if ( TdPawnOwner )
      {
        if ( this.BaseSpeed > 0.0001d )
        {
          switch ( this.ScalePlayRateType )
          {
            case EScalePlayRateType.SPRT_GroundSpeed:
              if( TdPawnOwner.bGoingForward )
                goingForwardDir = 1.0f;
              else
                goingForwardDir = -1.0f;
              goto LABEL_22;
            case EScalePlayRateType.SPRT_ZSpeed:
              Z = TdPawnOwner.Velocity.Z;
              goto LABEL_24;
            case EScalePlayRateType.SPRT_AverageActorSpeed:
              Z = TdPawnOwner.AverageSpeed;
              goto LABEL_24;
            case EScalePlayRateType.SPRT_GroundSpeedSize:
              speed = sqrt(
                        TdPawnOwner.Velocity.Y * TdPawnOwner.Velocity.Y
                      + TdPawnOwner.Velocity.X * TdPawnOwner.Velocity.X);
              goto LABEL_23;
            default:
              if( TdPawnOwner.bGoingForward )
                goingForwardDir = 1.0f;
              else
                goingForwardDir = -1.0f;
  LABEL_22:
              speed = fabs(
                        sqrt(
                          TdPawnOwner.Velocity.Y * TdPawnOwner.Velocity.Y
                        + TdPawnOwner.Velocity.X * TdPawnOwner.Velocity.X))
                    * goingForwardDir;
  LABEL_23:
              speed2 = (float)speed;
              Z = speed2;
  LABEL_24:
              if ( this.InversePlayRate )
                playRateDir2 = -1.0f;
              rateSelected2 = (float)((float)(Z / this.BaseSpeed) * this.ScaleByValue) * playRateDir2;
              if ( rateSelected2 < this.RateMin )
                rateSelected2 = this.RateMin;
              if ( RateMax >= rateSelected2 )
                return rateSelected2;
              rateSelected = this.RateMax;
              break;
          }
        }
      }
    }
    return rateSelected;
  }
#region src
/*
double __thiscall UTdAnimNodeSequence::GetScaleValue(_E_struct_UTdAnimNodeSequence *this)
{
  _E_enum_bitfield_bSnapToKeyFrames_And11More_UTdAnimNodeSequence bitfield_bSnapToKeyFrames_And11More; // eax
  float playRateDir2; // xmm2_4
  float playRateDir; // xmm3_4
  float RateMax; // xmm4_4
  float RateMin; // xmm0_4
  _E_struct_ATdPawn *__ptr32 TdPawnOwner; // edx
  long double speed; // st7
  float Z; // xmm0_4
  float rateSelected2; // xmm0_4
  float rateSelected; // [esp+0h] [ebp-Ch]
  float goingForwardDir; // [esp+4h] [ebp-8h]
  float speed2; // [esp+4h] [ebp-8h]

  bitfield_bSnapToKeyFrames_And11More = this->bitfield_bSnapToKeyFrames_And11More;
  playRateDir2 = 1.0;
  if ( ((bitfield_bSnapToKeyFrames_And11More >> 9) & 1) != 0 )// InversePlayRate
    playRateDir = -1.0;
  else
    playRateDir = 1.0;
  RateMax = this->RateMax;
  RateMin = this->RateMin;
  if ( playRateDir >= RateMin )
    RateMin = playRateDir;
  if ( RateMax < RateMin )
    rateSelected = this->RateMax;
  else
    rateSelected = RateMin;
  if ( (bitfield_bSnapToKeyFrames_And11More & ScalePlayRateBySpeed) != 0 )
  {
    TdPawnOwner = this->TdPawnOwner;
    if ( TdPawnOwner )
    {
      if ( this->BaseSpeed > 0.0001 )
      {
        switch ( this->ScalePlayRateType )
        {
          case SPRT_GroundSpeed:
            if ( (TdPawnOwner->bitfield_bDisableSkelControlSpring_And31More & 8) != 0 )// bGoingForward
              goingForwardDir = 1.0;
            else
              goingForwardDir = -1.0;
            goto LABEL_22;
          case SPRT_ZSpeed:
            Z = TdPawnOwner->Velocity.Z;
            goto LABEL_24;
          case SPRT_AverageActorSpeed:
            Z = TdPawnOwner->AverageSpeed;
            goto LABEL_24;
          case SPRT_GroundSpeedSize:
            speed = sqrt(
                      TdPawnOwner->Velocity.Y * TdPawnOwner->Velocity.Y
                    + TdPawnOwner->Velocity.X * TdPawnOwner->Velocity.X);
            goto LABEL_23;
          default:
            if ( (TdPawnOwner->bitfield_bDisableSkelControlSpring_And31More & 8) != 0 )// bGoingForward
              goingForwardDir = 1.0;
            else
              goingForwardDir = -1.0;
LABEL_22:
            speed = fabs(
                      sqrt(
                        TdPawnOwner->Velocity.Y * TdPawnOwner->Velocity.Y
                      + TdPawnOwner->Velocity.X * TdPawnOwner->Velocity.X))
                  * goingForwardDir;
LABEL_23:
            speed2 = speed;
            Z = speed2;
LABEL_24:
            if ( ((bitfield_bSnapToKeyFrames_And11More >> 9) & 1) != 0 )// InversePlayRate
              playRateDir2 = -1.0;
            rateSelected2 = (float)((float)(Z / this->BaseSpeed) * this->ScaleByValue) * playRateDir2;
            if ( rateSelected2 < this->RateMin )
              rateSelected2 = this->RateMin;
            if ( RateMax >= rateSelected2 )
              return rateSelected2;
            rateSelected = this->RateMax;
            break;
        }
      }
    }
  }
  return rateSelected;
}*/
#endregion

  public void CacheAnimNodes_Prob()
  {
    NativeMarkers.MarkUnimplemented();
    /*AnimTree tree; // eax
    void *poseOffset; // eax
  
    tree = E_TryCastTo<AnimTree>(this.SkelComponent.Animations);
    if ( tree )
    {
      poseOffset = (void *)sub_CF0E20(tree, dword_2056284, dword_2056288);// Likely fetch weapon pose offset node from tree
      this.WeaponPoseOffsetNode = E_TryCastTo<TdAnimNodeWeaponPoseOffset>(poseOffset);
    }*/
    this.bCached = true;
  }
#region src
/*
void __thiscall UTdAnimNodeSequence::CacheAnimNodes_Prob(_E_struct_UTdAnimNodeSequence *this)
{
  _E_struct_UAnimTree *tree; // eax
  void *poseOffset; // eax

  tree = E_TryCastToUAnimTree(this->SkelComponent->Animations);
  if ( tree )
  {
    poseOffset = (void *)sub_CF0E20(tree, dword_2056284, dword_2056288);// Likely fetch weapon pose offset node from tree
    this->WeaponPoseOffsetNode = E_TryCastToUTdAnimNodeWeaponPoseOffset(poseOffset);
  }
  this->bitfield_bSnapToKeyFrames_And11More |= bCached;
}*/
#endregion
void SetTdPawnOwner( SkeletalMeshComponent skeletalMesh)
{
  //_E_struct_ATdPawn *v2; // eax
  //_E_struct_ATdWeapon *v3; // eax

  var v2 = skeletalMesh.Owner as TdPawn;//E_TryCastToATdPawn(skeletalMesh->Owner);
  this.TdPawnOwner = v2;
  if ( !v2 )
  {
    var v3 = (skeletalMesh.Owner) as TdWeapon;
    if ( v3 )
      this.TdPawnOwner = v3.Owner as TdPawn;
  }
}
  public override void TickAnim(float DeltaTime, float TotalWeight)
  {
    //bitfield_bSnapToKeyFrames_And11More_UTdAnimNodeSequence bitfield_bSnapToKeyFrames_And11More; // eax
    TdPawn  tdPawnOwner; // eax
    TdPawn  tdPawnOwner2; // eax
    double X; // st7
    float currentTime; // [esp+14h] [ebp+8h]
  
    if ( this.bCached == false )
      CacheAnimNodes_Prob();
    if ( !this.TdPawnOwner )
    {
      if ( this.SkelComponent )
        SetTdPawnOwner(this.SkelComponent);
    }
    //bitfield_bSnapToKeyFrames_And11More = this.bitfield_bSnapToKeyFrames_And11More;
    if ( this.bSnapToKeyFrames )
      this.CurrentTime = this.AccualCurrentTime;
    if( this.ScalePlayRateBySpeed )
      this.Rate = (float)GetScaleValue();//((double (*)(void))*(_DWORD *)(this.VfTableObject.Dummy + 420))();// GetScaleValue()
    base.TickAnim(DeltaTime, TotalWeight);
    if ( this.bForceFullPlayback && TotalWeight > 0.0f )
    {
      if ( this.PreviousTime < 0.050000001d && this.CurrentTime > 0.050000001d )
      {
        tdPawnOwner = this.TdPawnOwner;
        if ( tdPawnOwner )
        {
          ++tdPawnOwner.AnimLockRefCount;
          this.bHasLockedAnimation = true;
          //this.bitfield_bSnapToKeyFrames_And11More |= bHasLockedAnimation;
        }
      }
      if ( this.PreviousTime < 0.94999999d && this.CurrentTime > 0.94999999d )
      {
        tdPawnOwner2 = this.TdPawnOwner;
        if ( tdPawnOwner2 )
        {
          if ( this.bHasLockedAnimation )
            --tdPawnOwner2.AnimLockRefCount;
        }
        this.bHasLockedAnimation = false;
        //this.bitfield_bSnapToKeyFrames_And11More &= ~bHasLockedAnimation;
      }
    }
    if ( this.bSnapToKeyFrames )
    {
      currentTime = this.CurrentTime;
      X = currentTime / 0.033333335d;              // 0.033333335d
      this.AccualCurrentTime = currentTime;
      this.CurrentTime = (float)(floor(X) * 0.033333335d); // 0.033333335d
    }
  }
#region src
/*
void __thiscall UTdAnimNodeSequence::TickAnim(_E_struct_UTdAnimNodeSequence *this, float DeltaTime, float TotalWeight)
{
  _E_enum_bitfield_bSnapToKeyFrames_And11More_UTdAnimNodeSequence bitfield_bSnapToKeyFrames_And11More; // eax
  _E_struct_ATdPawn *__ptr32 tdPawnOwner; // eax
  _E_struct_ATdPawn *__ptr32 tdPawnOwner2; // eax
  double X; // st7
  float currentTime; // [esp+14h] [ebp+8h]

  if ( (this->bitfield_bSnapToKeyFrames_And11More & bCached) == 0 )
    UTdAnimNodeSequence::CacheAnimNodes_Prob(this);
  if ( !this->TdPawnOwner )
  {
    if ( this->SkelComponent )
      UTdAnimNodeSequence::SetTdPawnOwner(this, this->SkelComponent);
  }
  bitfield_bSnapToKeyFrames_And11More = this->bitfield_bSnapToKeyFrames_And11More;
  if ( (bitfield_bSnapToKeyFrames_And11More & bSnapToKeyFrames) != 0 )
    this->CurrentTime = this->AccualCurrentTime;
  if ( (bitfield_bSnapToKeyFrames_And11More & ScalePlayRateBySpeed) != 0 )
    this->Rate = ((double (*)(void))*(_DWORD *)(this->VfTableObject.Dummy + 420))();// GetScaleValue()
  UAnimNodeSequence::TickAnim(this, DeltaTime, TotalWeight);
  if ( (this->bitfield_bSnapToKeyFrames_And11More & bForceFullPlayback) != 0 && TotalWeight > 0.0 )
  {
    if ( this->PreviousTime < 0.050000001 && this->CurrentTime > 0.050000001 )
    {
      tdPawnOwner = this->TdPawnOwner;
      if ( tdPawnOwner )
      {
        ++tdPawnOwner->AnimLockRefCount;
        this->bitfield_bSnapToKeyFrames_And11More |= bHasLockedAnimation;
      }
    }
    if ( this->PreviousTime < 0.94999999 && this->CurrentTime > 0.94999999 )
    {
      tdPawnOwner2 = this->TdPawnOwner;
      if ( tdPawnOwner2 )
      {
        if ( (this->bitfield_bSnapToKeyFrames_And11More & bHasLockedAnimation) != 0 )
          --tdPawnOwner2->AnimLockRefCount;
      }
      this->bitfield_bSnapToKeyFrames_And11More &= ~bHasLockedAnimation;
    }
  }
  if ( (this->bitfield_bSnapToKeyFrames_And11More & bSnapToKeyFrames) != 0 )
  {
    currentTime = this->CurrentTime;
    X = currentTime / flt_1F75D30;              // 0.033333335
    this->AccualCurrentTime = currentTime;
    this->CurrentTime = floor(X) * flt_1F75D30; // 0.033333335
  }
}*/
#endregion
}



public partial class TdAnimNodeState
{
  public override bool SetActiveMove(int ChildIndex, bool? ForceActive = default)
  {
    bool noCustomBlend; // zf
    int SavedEnum; // eax
    float blend; // xmm2_4
    float blendOutWeight; // xmm0_4
    float blendWeight; // xmm1_4
    int ActiveChildIndex; // eax
    float customBlend; // [esp+14h] [ebp+8h]
    float finalBlend; // [esp+14h] [ebp+8h]
  
    if ( ForceActive != true && this.ActiveChildIndex == ChildIndex || this.TargetWeight.Count == 0 )
      return false;
    noCustomBlend = this.bUseCustomBlend == false;
    this.PreviousUsedEnum = this.CurrentUsedEnum;
    SavedEnum = this.SavedEnum;
    this.CurrentUsedEnum = SavedEnum;
    if ( noCustomBlend )
    {
      blend = 0.0f;
    }
    else
    {
      customBlend = GetBlendValue(
                      SavedEnum,
                      this.PreviousUsedEnum);    // UTdAnimNodeState::GetBlendValue
      blend = customBlend;
    }
    blendOutWeight = 0.2f;
    if( ChildIndex >= this.BlendWeight.Count )
      blendWeight = 0.2f;
    else
      blendWeight = this.BlendWeight[ChildIndex];
    ActiveChildIndex = this.ActiveChildIndex;
    if ( ActiveChildIndex < this.BlendOutWeight.Count )
      blendOutWeight = this.BlendOutWeight[ActiveChildIndex];
    if ( blend == 0.0f )
    {
      if ( blendWeight < blendOutWeight )
        finalBlend = blendOutWeight;
      else
        finalBlend = blendWeight;
    }
    else
    {
      finalBlend = blend;
    }
    SetActiveChild( ChildIndex, finalBlend );
    return true;
  }
#region src
/*
int __thiscall UTdAnimNodeState::SetActiveMove(_E_struct_UTdAnimNodeState *this, int ChildIndex, int ForceActive)
{
  bool noCustomBlend; // zf
  int SavedEnum; // eax
  float blend; // xmm2_4
  float blendOutWeight; // xmm0_4
  float blendWeight; // xmm1_4
  int ActiveChildIndex; // eax
  float customBlend; // [esp+14h] [ebp+8h]
  float finalBlend; // [esp+14h] [ebp+8h]

  if ( !ForceActive && this->ActiveChildIndex == ChildIndex || !this->TargetWeight.Count )
    return 0;
  noCustomBlend = (this->bitfield_bUseCustomBlend & bUseCustomBlend) == 0;
  this->PreviousUsedEnum = this->CurrentUsedEnum;
  SavedEnum = this->SavedEnum;
  this->CurrentUsedEnum = SavedEnum;
  if ( noCustomBlend )
  {
    blend = 0.0;
  }
  else
  {
    customBlend = ((double (__stdcall *)(int, int))*(_DWORD *)(this->VfTableObject.Dummy + 424))(
                    SavedEnum,
                    this->PreviousUsedEnum);    // UTdAnimNodeState::GetBlendValue
    blend = customBlend;
  }
  blendOutWeight = 0.2;
  if ( ChildIndex >= this->BlendWeight.Count )
    blendWeight = 0.2;
  else
    blendWeight = this->BlendWeight.Data[ChildIndex];
  ActiveChildIndex = this->ActiveChildIndex;
  if ( ActiveChildIndex < this->BlendOutWeight.Count )
    blendOutWeight = this->BlendOutWeight.Data[ActiveChildIndex];
  if ( blend == 0.0 )
  {
    if ( blendWeight < blendOutWeight )
      finalBlend = blendOutWeight;
    else
      finalBlend = blendWeight;
  }
  else
  {
    finalBlend = blend;
  }
  (*(void (__stdcall **)(int, _DWORD))(this->VfTableObject.Dummy + 408))(ChildIndex, LODWORD(finalBlend));// UAnimNodeBlendList::SetActiveChild
  return 1;
}*/
#endregion

  public virtual int GetActiveState()
  {
    int state; // eax
    int i; // ecx
  
    if ( this.TdPawnOwner )
    {
      state = GetState();//(*(int (**)(void))(this.VfTableObject.Dummy + 428))();// GetState()
      i = 0;
      if ( this.StateMapping.Count > 0 )
      {
        while ( i < this.Children.Count - 1 )
        {
          if ( this.StateMapping[i] == state )
          {
            this.SavedEnum = state;
            return (int)i + 1;
          }
          if ( ++i >= this.StateMapping.Count )
            break;
        }
      }
    }
    this.SavedEnum = 0;
    return 0;
  }
#region src
/*
int __thiscall UTdAnimNodeState::GetActiveState(_E_struct_UTdAnimNodeState *this)
{
  int state; // eax
  int i; // ecx

  if ( this->TdPawnOwner )
  {
    state = (*(int (**)(void))(this->VfTableObject.Dummy + 428))();// GetState()
    i = 0;
    if ( this->StateMapping.Count > 0 )
    {
      while ( i < this->Children.Count - 1 )
      {
        if ( this->StateMapping.Data[i] == state )
        {
          this->SavedEnum = state;
          return i + 1;
        }
        if ( ++i >= this->StateMapping.Count )
          break;
      }
    }
  }
  this->SavedEnum = 0;
  return 0;
}*/
#endregion

  public virtual float GetBlendValue(int PreviousState, int NewState)
  {
    TdPawn  TdPawnOwner; // eax
    float AnimBlendTime; // xmm2_4
    float newStateBlendTime; // xmm0_4
  
    TdPawnOwner = this.TdPawnOwner;
    if ( TdPawnOwner == false )
      return 0.0f;
    if ( PreviousState != 0 )
      AnimBlendTime = TdPawnOwner.Moves[PreviousState].AnimBlendTime;
    else
      AnimBlendTime = 0.0f;
    if ( NewState != 0 )
      newStateBlendTime = TdPawnOwner.Moves[NewState].AnimBlendTime;
    else
      newStateBlendTime = 0.0f;
    if ( AnimBlendTime > newStateBlendTime )
      return AnimBlendTime;
    if ( newStateBlendTime > 0.0f )
      return newStateBlendTime;
    else
      return 0.0f;
  }
#region src
/*
double __thiscall UTdAnimNodeState::GetBlendValue(_E_struct_UTdAnimNodeState *this, int PreviousState, int NewState)
{
  _E_struct_ATdPawn *__ptr32 TdPawnOwner; // eax
  float AnimBlendTime; // xmm2_4
  float newStateBlendTime; // xmm0_4

  TdPawnOwner = this->TdPawnOwner;
  if ( !TdPawnOwner )
    return 0.0;
  if ( PreviousState )
    AnimBlendTime = TdPawnOwner->Moves.Data[PreviousState]->AnimBlendTime;
  else
    AnimBlendTime = 0.0;
  if ( NewState )
    newStateBlendTime = TdPawnOwner->Moves.Data[NewState]->AnimBlendTime;
  else
    newStateBlendTime = 0.0;
  if ( AnimBlendTime > newStateBlendTime )
    return AnimBlendTime;
  if ( newStateBlendTime > 0.0 )
    return newStateBlendTime;
  else
    return 0.0;
}*/
#endregion

  public override void TickAnim(float DeltaTime, float TotalWeight)
  {
    int Dummy; // edi
    int activeState; // eax
  
    if ( this.TdPawnOwner )
    {
      //Dummy = this.VfTableObject.Dummy;
      activeState = GetActiveState(/*0*/);// GetActiveState()
      SetActiveMove(activeState);// 1210870 - UTdAnimNodeState::SetActiveMove
    }
    else// if ( dword_2020740 )
    {
      SetActiveMove(this.EditorSliderIndex, false);
    }
    base.TickAnim(DeltaTime, TotalWeight);
  }
#region src
/*
void __thiscall UTdAnimNodeState::TickAnim(_E_struct_UTdAnimNodeState *this, float DeltaTime, float TotalWeight)
{
  int Dummy; // edi
  int activeState; // eax

  if ( this->TdPawnOwner )
  {
    Dummy = this->VfTableObject.Dummy;
    activeState = (*(int (__stdcall **)(_DWORD))(this->VfTableObject.Dummy + 420))(0);// GetActiveState()
    (*(void (__stdcall **)(int))(Dummy + 412))(activeState);// 1210870 - UTdAnimNodeState::SetActiveMove
  }
  else if ( dword_2020740 )
  {
    (*(void (__stdcall **)(int, _DWORD))(this->VfTableObject.Dummy + 412))(this->EditorSliderIndex, 0);// SetActiveMove
  }
  UTdAnimNodeBlendList::TickAnim(this, DeltaTime, TotalWeight);
}*/
#endregion
}



public partial class TdAnimNodeSwing
{
  public override void TickAnim(float DeltaTime, float TotalWeight)
  {
    SkeletalMeshComponent  SkelComponent; // eax
    TdPawn pawn; // eax
    float swingAngleScaled; // xmm0_4
    float clampedSwingAngle; // xmm2_4
    float negSwingAngleAsPos; // xmm2_4
    //_E_struct_FAnimBlendChild *__ptr32 Data; // eax
    float weightLeft; // xmm1_4
  
    SkelComponent = this.SkelComponent;
    if ( SkelComponent )
    {
      pawn = E_TryCastTo<TdPawn>(SkelComponent.Owner);
      if ( pawn )
      {
        if ( this.Children.Count == 3 )
        {
          swingAngleScaled = (float)((float)(E_TryCastTo<TdMove_Swing>(pawn.Moves[60]).SwingAngle * 2.0f) * 0.31830987d);
          if ( swingAngleScaled < 0.0f )
          {
            clampedSwingAngle = 0.0f;
          }
          else if ( swingAngleScaled < 1.0f )
          {
            clampedSwingAngle = swingAngleScaled;
          }
          else
          {
            clampedSwingAngle = 1.0f;
          }
          this.Children[0].Weight = clampedSwingAngle;
          if ( swingAngleScaled >= 0.0f )
          {
            negSwingAngleAsPos = 0.0f;
          }
          else
          {
            negSwingAngleAsPos = -0.0f - swingAngleScaled;
            if ( (float)(-0.0f - swingAngleScaled) >= 1.0f )
              negSwingAngleAsPos = 1.0f;
          }
          this.Children[2].Weight = negSwingAngleAsPos;
          weightLeft = (float)(1.0f - this.Children[0].Weight) - this.Children[2].Weight;
          if ( weightLeft <= 0.0f )
            weightLeft = 0.0f;
          this.Children[1].Weight = weightLeft;
        }
      }
    }
    base.TickAnim(DeltaTime, TotalWeight);
  }
#region src
/*
void __thiscall UTdAnimNodeSwing::TickAnim(_E_struct_UTdAnimNodeSwing *this, float DeltaTime, float TotalWeight)
{
  _E_struct_USkeletalMeshComponent *__ptr32 SkelComponent; // eax
  _E_struct_ATdPawn *pawn; // eax
  float swingAngleScaled; // xmm0_4
  float clampedSwingAngle; // xmm2_4
  float negSwingAngleAsPos; // xmm2_4
  _E_struct_FAnimBlendChild *__ptr32 Data; // eax
  float weightLeft; // xmm1_4

  SkelComponent = this->SkelComponent;
  if ( SkelComponent )
  {
    pawn = E_TryCastToATdPawn(SkelComponent->Owner);
    if ( pawn )
    {
      if ( this->Children.Count == 3 )
      {
        swingAngleScaled = (float)(E_TryCastToUTdMove_Swing(pawn->Moves.Data[60])->SwingAngle * 2.0) * 0.31830987;
        if ( swingAngleScaled < 0.0 )
        {
          clampedSwingAngle = 0.0;
        }
        else if ( swingAngleScaled < 1.0 )
        {
          clampedSwingAngle = swingAngleScaled;
        }
        else
        {
          clampedSwingAngle = 1.0;
        }
        this->Children.Data->Weight = clampedSwingAngle;
        if ( swingAngleScaled >= 0.0 )
        {
          negSwingAngleAsPos = 0.0;
        }
        else
        {
          negSwingAngleAsPos = -0.0 - swingAngleScaled;
          if ( (float)(-0.0 - swingAngleScaled) >= 1.0 )
            negSwingAngleAsPos = 1.0;
        }
        this->Children.Data[2].Weight = negSwingAngleAsPos;
        Data = this->Children.Data;
        weightLeft = (float)(1.0 - Data->Weight) - Data[2].Weight;
        if ( weightLeft <= 0.0 )
          weightLeft = 0.0;
        Data[1].Weight = weightLeft;
      }
    }
  }
  UTdAnimNodeBlendList::TickAnim(this, DeltaTime, TotalWeight);
}*/
#endregion
}



public partial class TdAnimNodeSwitch
{
  public virtual int GetActiveState()
  {
    // Kind of weird ?
    return GetState() == false ? 1 : 0; //(*(int (**)(void))(this.VfTableObject.Dummy + 420))() == 0;// GetState() UTdAnimNodeCinematicSwitch::GetState
  }
#region src
/*
BOOL __thiscall UTdAnimNodeSwitch::GetActiveState(_E_struct_UTdAnimNodeSwitch *this)
{
  return (*(int (**)(void))(this->VfTableObject.Dummy + 420))() == 0;// GetState() UTdAnimNodeCinematicSwitch::GetState
}*/
#endregion

  public override void TickAnim(float DeltaTime, float TotalWeight)
  {
    int Dummy; // edi
    int activeState; // eax
    int v5; // edi
    int v6; // eax
  
    if ( this.TdPawnOwner )
    {
      Dummy = this.VfTableObject.Dummy;
      activeState = GetActiveState(/*0*/);// GetActiveState
      if ( SetActiveMove(activeState) )//(*(int (__stdcall **)(int))(Dummy + 412))(activeState) )// TdAnimNodeBlendList::SetActiveMove
      {
        this.StateSwitched();
      }
      else //if ( dword_2020740 )                   // In editor
      {
        if ( SetActiveMove(this.EditorSliderIndex/*, 0*/) )// TdAnimNodeBlendList::SetActiveMove
          StateSwitched();                      // Call StateSwitched
      }
    }
    base.TickAnim(DeltaTime, TotalWeight);
  }
#region src
/*
void __thiscall UTdAnimNodeSwitch::TickAnim(_E_struct_UTdAnimNodeSwitch *this, float DeltaTime, float TotalWeight)
{
  int Dummy; // edi
  int activeState; // eax
  int v5; // edi
  int v6; // eax

  if ( this->TdPawnOwner )
  {
    Dummy = this->VfTableObject.Dummy;
    activeState = (*(int (__stdcall **)(_DWORD))(this->VfTableObject.Dummy + 416))(0);// GetActiveState
    if ( (*(int (__stdcall **)(int))(Dummy + 412))(activeState) )// TdAnimNodeBlendList::SetActiveMove
    {
      v5 = this->VfTableObject.Dummy;           // ---------------------------
                                                // Call StateSwitched probably
      v6 = sub_11090D0(this, StateSwitched_1, StateSwitched_2, 0);
      (*(void (__stdcall **)(int, _DWORD, _DWORD))(v5 + 244))(v6, 0, 0);
    }
    else if ( dword_2020740 )                   // In editor
    {
      if ( (*(int (__stdcall **)(int, _DWORD))(this->VfTableObject.Dummy + 412))(this->EditorSliderIndex, 0) )// TdAnimNodeBlendList::SetActiveMove
        sub_120D6F0(this);                      // Call StateSwitched
    }
  }
  UTdAnimNodeBlendList::TickAnim(this, DeltaTime, TotalWeight);
}*/
#endregion
}



public partial class TdAnimNodeTurn
{
  public bool IsExtendedRegion(float a2)
  {
    double v2; // st7
    int result; // eax
    float v4; // [esp+4h] [ebp+4h]
  
    v2 = fabs(a2);
    result = 0;
    if ( v2 > this.SafeRegionLimit )
    {
      v4 = (float)v2;
      if ( this.ExtendedRegionLimit > v4 )
        return true;
    }
    return result != 0;
  }
#region src
/*
BOOL __thiscall UTdAnimNodeTurn::IsExtendedRegion(_E_struct_UTdAnimNodeTurn *this, float a2)
{
  long double v2; // st7
  int result; // eax
  float v4; // [esp+4h] [ebp+4h]

  v2 = fabs(a2);
  result = 0;
  if ( v2 > this->SafeRegionLimit )
  {
    v4 = v2;
    if ( this->ExtendedRegionLimit > v4 )
      return 1;
  }
  return result;
}*/
#endregion

  public bool IsOuterRegion(float a2)
  {
    return fabs(a2) > this.ExtendedRegionLimit;
  }
#region src
/*
BOOL __thiscall UTdAnimNodeTurn::IsOuterRegion(_E_struct_UTdAnimNodeTurn *this, float a2)
{
  return fabs(a2) > this->ExtendedRegionLimit;
}*/
#endregion

  public void PlayTurnAnimation(float legLocalEuler)
  {
    double absLegEuler; // st7
    double ExtendedRegionLimit; // st6
    int activeMove; // eax
    AnimNodeSequence sequence; // eax
    AnimNodeSequence sequence2; // esi
    AnimSequence  AnimSeq; // esi
    float speedMult; // xmm3_4
    float dir; // xmm0_4
    float absLegEuler2; // [esp+18h] [ebp-4h]
  
    absLegEuler = fabs(legLocalEuler);
    absLegEuler2 = (float)absLegEuler;
    ExtendedRegionLimit = this.ExtendedRegionLimit;
    PlayingTurnAnimation = true;
    //this.bitfield_PlayingTurnAnimation |= PlayingTurnAnimation;
    if ( absLegEuler <= ExtendedRegionLimit )
    {
      activeMove = 1;
      if ( legLocalEuler >= 0.0f )
        activeMove = 3;
    }
    else
    {
      activeMove = 2;
      if ( legLocalEuler >= 0.0f )
        activeMove = 4;
    }
    SetActiveMove(activeMove, true);
    sequence = E_TryCastTo<AnimNodeSequence>(this.Children[this.ActiveChildIndex].Anim);
    sequence2 = sequence;
    if ( sequence )
    {
      sequence.PlayAnim( sequence.bLooping, sequence.Rate, 0f );
      AnimSeq = sequence2.AnimSeq;
      if ( AnimSeq )
      {
        if ( absLegEuler2 <= this.ExtendedRegionLimit )
          speedMult = 8192.0f;
        else
          speedMult = 16384.0f;
        if ( legLocalEuler == 0.0f )
          dir = 0.0f;
        else
          dir = legLocalEuler / absLegEuler2;     // weird ... would return -1 or 1, maybe just a weird way to get the sign ...
        this.LegTurnPerSecond = (float)(dir / AnimSeq.SequenceLength) * speedMult;
      }
    }
  }
#region src
/*
void __thiscall UTdAnimNodeTurn::PlayTurnAnimation(_E_struct_UTdAnimNodeTurn *this, float legLocalEuler)
{
  long double absLegEuler; // st7
  long double ExtendedRegionLimit; // st6
  int activeMove; // eax
  _E_struct_UAnimNodeSequence *sequence; // eax
  _E_struct_UAnimNodeSequence *sequence2; // esi
  _E_struct_UAnimSequence *__ptr32 AnimSeq; // esi
  float speedMult; // xmm3_4
  float dir; // xmm0_4
  float absLegEuler2; // [esp+18h] [ebp-4h]

  absLegEuler = fabs(legLocalEuler);
  absLegEuler2 = absLegEuler;
  ExtendedRegionLimit = this->ExtendedRegionLimit;
  this->bitfield_PlayingTurnAnimation |= PlayingTurnAnimation;
  if ( absLegEuler <= ExtendedRegionLimit )
  {
    activeMove = 1;
    if ( legLocalEuler >= 0.0 )
      activeMove = 3;
  }
  else
  {
    activeMove = 2;
    if ( legLocalEuler >= 0.0 )
      activeMove = 4;
  }
  (*(void (__stdcall **)(int, int))(this->VfTableObject.Dummy + 412))(activeMove, 1);// TdAnimNodeBlendList::SetActiveMove
  sequence = E_TryCastToUAnimNodeSequence(this->Children.Data[this->ActiveChildIndex].Anim);
  sequence2 = sequence;
  if ( sequence )
  {
    (*(void (__stdcall **)(unsigned __int32, float, _DWORD))(sequence->VfTableObject.Dummy + 276))(
      (sequence->bitfield_bPlaying_And15More >> 1) & 1,
      sequence->Rate,                           // bLooping
      0.0);                                     // PlayAnim
    AnimSeq = sequence2->AnimSeq;
    if ( AnimSeq )
    {
      if ( absLegEuler2 <= this->ExtendedRegionLimit )
        speedMult = 8192.0;
      else
        speedMult = 16384.0;
      if ( legLocalEuler == 0.0 )
        dir = 0.0;
      else
        dir = legLocalEuler / absLegEuler2;     // weird ... would return -1 or 1, maybe just a weird way to get the sign ...
      this->LegTurnPerSecond = (float)(dir / AnimSeq->SequenceLength) * speedMult;
    }
  }
}*/
#endregion

  public void UpdateLegRotation(float deltaTime)
  {
    SkeletalMeshComponent  SkelComponent; // eax
    TdPawn pawn; // eax
    uint newLegRot; // ecx
  
    SkelComponent = this.SkelComponent;
    if ( SkelComponent )
    {
      pawn = E_TryCastTo<TdPawn>(SkelComponent.Owner);
      if ( pawn )
      {
        if ( this.SkelComponent == pawn.Mesh )
        {
          newLegRot = (ushort)(LOWORD(pawn.LegRotation) + (int)(float)(this.LegTurnPerSecond * deltaTime));
          if ( newLegRot > 32767 )
            newLegRot -= 65536;
          pawn.LegRotation = (int)newLegRot;
        }
      }
    }
  }
#region src
/*
void __thiscall UTdAnimNodeTurn::UpdateLegRotation(_E_struct_UTdAnimNodeTurn *this, float deltaTime)
{
  _E_struct_USkeletalMeshComponent *__ptr32 SkelComponent; // eax
  _E_struct_ATdPawn *pawn; // eax
  unsigned int newLegRot; // ecx

  SkelComponent = this->SkelComponent;
  if ( SkelComponent )
  {
    pawn = E_TryCastToATdPawn(SkelComponent->Owner);
    if ( pawn )
    {
      if ( this->SkelComponent == pawn->Mesh )
      {
        newLegRot = (unsigned __int16)(LOWORD(pawn->LegRotation) + (int)(float)(this->LegTurnPerSecond * deltaTime));
        if ( newLegRot > 32767 )
          newLegRot -= 65536;
        pawn->LegRotation = newLegRot;
      }
    }
  }
}*/
#endregion

  public override void TickAnim(float DeltaTime, float TotalWeight)
  {
    SkeletalMeshComponent  SkelComponent; // eax
    TdPawn pawn; // edi
    int deltaLegToRot; // eax
    TdAIController v6; // edx
    float v7; // xmm0_4
    bool v8; // cc
    float legLocalEuler; // [esp+Ch] [ebp-4h]
  
    SkelComponent = this.SkelComponent;
    if ( SkelComponent )
    {
      pawn = E_TryCastTo<TdPawn>(SkelComponent.Owner);
      if ( pawn )
      {
        if ( this.PlayingTurnAnimation && TotalWeight > 0.1d )
          UpdateLegRotation(DeltaTime);
        deltaLegToRot = (ushort)(LOWORD(pawn.Rotation.Yaw) - LOWORD(pawn.LegRotation));
        if ( (uint)deltaLegToRot > 32767 )
          deltaLegToRot -= 65536;                 // 0x10000
        legLocalEuler = (float)((float)deltaLegToRot * 0.0054931641d);
        v6 = E_TryCastTo<TdAIController>(pawn.Controller);
        if ( this.PlayingTurnAnimation
          || this.SafeRegionLimit > fabs(legLocalEuler) )
        {
          this.TimeStandingStill = 0.0f;
          goto LABEL_17;
        }
        if ( !IsExtendedRegion(legLocalEuler) )
        {
          if ( !IsOuterRegion(legLocalEuler) )
            goto LABEL_17;
          PlayTurnAnimation(legLocalEuler);
          goto LABEL_17;
        }
        if ( v6 )
        {
          v7 = this.TimeStandingStill + DeltaTime;
          v8 = v7 <= this.IdleTimer;
          this.TimeStandingStill = v7;
          if ( v8 == false )
            PlayTurnAnimation(legLocalEuler);
        }
      }
    }
  LABEL_17:
    base.TickAnim(DeltaTime, TotalWeight);
  }
#region src
/*
void __thiscall UTdAnimNodeTurn::TickAnim(_E_struct_UTdAnimNodeTurn *this, float DeltaTime, float TotalWeight)
{
  _E_struct_USkeletalMeshComponent *__ptr32 SkelComponent; // eax
  _E_struct_ATdPawn *pawn; // edi
  int deltaLegToRot; // eax
  _E_struct_ATdAIController *v6; // edx
  float v7; // xmm0_4
  bool v8; // cc
  float legLocalEuler; // [esp+Ch] [ebp-4h]

  SkelComponent = this->SkelComponent;
  if ( SkelComponent )
  {
    pawn = E_TryCastToATdPawn(SkelComponent->Owner);
    if ( pawn )
    {
      if ( (this->bitfield_PlayingTurnAnimation & PlayingTurnAnimation) != 0 && TotalWeight > 0.1 )
        UTdAnimNodeTurn::UpdateLegRotation(this, DeltaTime);
      deltaLegToRot = (unsigned __int16)(LOWORD(pawn->Rotation.Yaw) - LOWORD(pawn->LegRotation));
      if ( (unsigned int)deltaLegToRot > 32767 )
        deltaLegToRot -= 65536;                 // 0x10000
      legLocalEuler = (float)deltaLegToRot * 0.0054931641;
      v6 = E_TryCastToTdAIController(pawn->Controller);
      if ( (this->bitfield_PlayingTurnAnimation & PlayingTurnAnimation) != 0
        || this->SafeRegionLimit > fabs(legLocalEuler) )
      {
        this->TimeStandingStill = 0.0;
        goto LABEL_17;
      }
      if ( !UTdAnimNodeTurn::IsExtendedRegion(this, legLocalEuler) )
      {
        if ( !UTdAnimNodeTurn::IsOuterRegion(this, legLocalEuler) )
          goto LABEL_17;
        goto LABEL_13;
      }
      if ( v6 )
      {
        v7 = this->TimeStandingStill + DeltaTime;
        v8 = v7 <= this->IdleTimer;
        this->TimeStandingStill = v7;
        if ( !v8 )
LABEL_13:
          UTdAnimNodeTurn::PlayTurnAnimation(this, legLocalEuler);
      }
    }
  }
LABEL_17:
  UTdAnimNodeBlendList::TickAnim(this, DeltaTime, TotalWeight);
}*/
#endregion
}



public partial class TdAnimNodeWalkingState
{
  public override int GetState()
  {
    TdPawn  TdPawnOwner; // eax
  
    TdPawnOwner = this.TdPawnOwner;
    if ( TdPawnOwner )
      return (int)TdPawnOwner.CurrentWalkingState;
    else
      return 0;
  }
#region src
/*
int __thiscall UTdAnimNodeWalkingState::GetActiveState(_E_struct_UTdAnimNodeWalkingState *this)
{
  _E_struct_ATdPawn *__ptr32 TdPawnOwner; // eax

  TdPawnOwner = this->TdPawnOwner;
  if ( TdPawnOwner )
    return TdPawnOwner->CurrentWalkingState;
  else
    return 0;
}*/
#endregion
}



public partial class TdAnimNodeWeaponState
{
  public override int GetActiveState()
  {
    TdPawn  TdPawnOwner; // eax
  
    TdPawnOwner = this.TdPawnOwner;
    if ( TdPawnOwner )
      return (int)TdPawnOwner.WeaponAnimState;
    else
      return 0;
  }
#region src
/*
int __thiscall UTdAnimNodeWeaponState::GetActiveState(_E_struct_UTdAnimNodeWeaponState *this)
{
  _E_struct_ATdPawn *__ptr32 TdPawnOwner; // eax

  TdPawnOwner = this->TdPawnOwner;
  if ( TdPawnOwner )
    return TdPawnOwner->WeaponAnimState;
  else
    return 0;
}*/
#endregion
}



public partial class TdAnimNodeWeaponTypeState
{
  public override int GetActiveState()
  {
    TdPawn TdPawnOwner; // ecx
  
    TdPawnOwner = this.TdPawnOwner;
    if( TdPawnOwner )
      return (int) (TdPawnOwner.MyWeapon?.WeaponType ?? 0); //E_ReturnWeaponType(TdPawnOwner);
    else
      return 0;
  }
#region src
/*
int __thiscall UTdAnimNodeWeaponTypeState::GetActiveState(_E_struct_UTdAnimNodeWeaponTypeState *this)
{
  _E_struct_ATdPawn *TdPawnOwner; // ecx

  TdPawnOwner = this->TdPawnOwner;
  if ( TdPawnOwner )
    return E_ReturnWeaponType(TdPawnOwner);
  else
    return 0;
}*/
#endregion
}

public partial class TdAnimNodeBlendList
{
  // Export UTdAnimNodeBlendList::execSetActiveMove(FFrame&, void* const)
  public virtual /*native function */bool SetActiveMove(int ChildIndex, /*optional */bool? _ForceActive = default)
  {
    float activeChildBlendOutWeight; // xmm0_4
    float newChildBlendWeight; // xmm1_4
    int activeChildIndex; // eax
    float maxBlendWeight; // [esp+Ch] [ebp+8h]
	        
    if ( _ForceActive != true && this.ActiveChildIndex == ChildIndex || this.TargetWeight.Count == 0 )
      return false;
    activeChildBlendOutWeight = 0.2f;            // default value if no active
    if ( ChildIndex >= this.BlendWeight.Count )
      newChildBlendWeight = 0.2f;
    else
      newChildBlendWeight = this.BlendWeight[ChildIndex];
    activeChildIndex = this.ActiveChildIndex;
    if ( activeChildIndex < this.BlendOutWeight.Count )
      activeChildBlendOutWeight = this.BlendOutWeight[activeChildIndex];
    if ( newChildBlendWeight < activeChildBlendOutWeight )
      maxBlendWeight = activeChildBlendOutWeight;
    else
      maxBlendWeight = newChildBlendWeight;
    this.SetActiveChild( ChildIndex, maxBlendWeight );
    return true;
  }
}




}
