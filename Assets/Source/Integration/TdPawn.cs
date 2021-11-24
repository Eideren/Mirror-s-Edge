namespace MEdge.TdGame
{
    using static MEdge.Source.DecFn;
    using Core;
    using Engine;
    using _E_struct_FRotator = Core.Object.Rotator;
    using _E_struct_Quat = Core.Object.Quat;
    using _E_struct_FVector = Core.Object.Vector;
    using _E_struct_FMatrix = Core.Object.Matrix;
    using _E_struct_FInterpCurveFloat = Core.Object.InterpCurveFloat;
    using _E_struct_FInterpCurvePointFloat = Core.Object.InterpCurvePointFloat;
    using static UnityEngine.Debug;
	public partial class TdPawn
	{
        
        // Export UTdPawn::execStopCustomAnim(FFrame&, void* const)
        public /*native simulated function */void TdPawn_StopCustomAnim(TdPawn.CustomNodeType Type, float BlendOutTime)
        {
            AnimNodeSequence CustomSequence; // edi
            AnimNodeSequence v4; // ebx
            TdAnimNodeSlot CustomCannedNode1p; // ecx
            TdAnimNodeSlot CustomCannedNode3p; // ecx
            AnimNodeSequence v8; // eax
            TdAnimNodeSlot v9; // ecx
            TdAnimNodeSlot CustomCannedUpperBodyNode1p; // ecx
            TdAnimNodeSlot CustomCannedUpperBodyNode3p; // ecx
            TdAnimNodeSlot CustomFullBodyNode1p; // ecx
            TdAnimNodeSlot CustomFullBodyNode3p; // ecx
            TdAnimNodeSlot CustomFullBodyDirNode1p; // ecx
            TdAnimNodeSlot CustomFullBodyDirNode3p; // ecx
            TdAnimNodeSlot CustomUpperBodyNode1p; // ecx
            TdAnimNodeSlot CustomUpperBodyNode3p; // ecx
            TdAnimNodeSlot CustomLowerBodyNode1p; // ecx
            TdAnimNodeSlot CustomLowerBodyNode3p; // ecx
            TdAnimNodeSlot CustomCameraNode; // ecx
            AnimNodeSequence v21; // eax
            TdAnimNodeSlot CustomWeaponNode1p; // ecx
            TdAnimNodeSlot CustomWeaponNode3p; // ecx
            TdAnimNodeSlot CustomFaceNode; // ecx
            TdMove movementStateMove; // ecx

            CustomSequence = null;
            v4 = null;
            switch( Type )
            {
                case CustomNodeType.CNT_Canned:
                    CustomCannedNode1p = this.CustomCannedNode1p;
                    if( CustomCannedNode1p )
                    {
                        CustomSequence = CustomCannedNode1p .GetCustomAnimNodeSeq( );
                        this.CustomCannedNode1p.StopCustomAnim(BlendOutTime );
                    }

                    CustomCannedNode3p = this.CustomCannedNode3p;
                    if( CustomCannedNode3p )
                    {
                        v8 = CustomCannedNode3p .GetCustomAnimNodeSeq( );
                        v9 = this.CustomCannedNode3p;
                        v4 = v8;
                        v9.StopCustomAnim( BlendOutTime );
                        break;
                    }

                    break;
                case CustomNodeType.CNT_CannedUpperBody:
                    CustomCannedUpperBodyNode1p = this.CustomCannedUpperBodyNode1p;
                    if( CustomCannedUpperBodyNode1p )
                    {
                        CustomSequence = CustomCannedUpperBodyNode1p .GetCustomAnimNodeSeq( );
                        this.CustomCannedUpperBodyNode1p.StopCustomAnim( BlendOutTime );
                    }

                    CustomCannedUpperBodyNode3p = this.CustomCannedUpperBodyNode3p;
                    if( CustomCannedUpperBodyNode3p )
                    {
                        v8 = CustomCannedUpperBodyNode3p .GetCustomAnimNodeSeq( );
                        v9 = this.CustomCannedUpperBodyNode3p;
                        v4 = v8;
                        v9.StopCustomAnim( BlendOutTime );
                        break;
                    }

                    break;
                case CustomNodeType.CNT_FullBody:
                    CustomFullBodyNode1p = this.CustomFullBodyNode1p;
                    if( CustomFullBodyNode1p )
                    {
                        CustomSequence = CustomFullBodyNode1p .GetCustomAnimNodeSeq( );
                        this.CustomFullBodyNode1p.StopCustomAnim( BlendOutTime );
                    }

                    CustomFullBodyNode3p = this.CustomFullBodyNode3p;
                    if( CustomFullBodyNode3p )
                    {
                        v8 = CustomFullBodyNode3p .GetCustomAnimNodeSeq( );
                        v9 = this.CustomFullBodyNode3p;
                        v4 = v8;
                        v9.StopCustomAnim( BlendOutTime );
                        break;
                    }

                    break;
                case CustomNodeType.CNT_FullBody_Dir:
                    CustomFullBodyDirNode1p = this.CustomFullBodyDirNode1p;
                    if( CustomFullBodyDirNode1p )
                    {
                        CustomSequence = CustomFullBodyDirNode1p .GetCustomAnimNodeSeq( );
                        this.CustomFullBodyDirNode1p.StopCustomAnim( BlendOutTime );
                    }

                    CustomFullBodyDirNode3p = this.CustomFullBodyDirNode3p;
                    if( CustomFullBodyDirNode3p )
                    {
                        v8 = CustomFullBodyDirNode3p .GetCustomAnimNodeSeq( );
                        v9 = this.CustomFullBodyDirNode3p;
                        v4 = v8;
                        v9.StopCustomAnim( BlendOutTime );
                        break;
                    }

                    break;
                case CustomNodeType.CNT_UpperBody:
                    CustomUpperBodyNode1p = this.CustomUpperBodyNode1p;
                    if( CustomUpperBodyNode1p )
                    {
                        CustomSequence = CustomUpperBodyNode1p .GetCustomAnimNodeSeq( );
                        this.CustomUpperBodyNode1p.StopCustomAnim( BlendOutTime );
                    }

                    CustomUpperBodyNode3p = this.CustomUpperBodyNode3p;
                    if( CustomUpperBodyNode3p )
                    {
                        v8 = CustomUpperBodyNode3p .GetCustomAnimNodeSeq( );
                        v9 = this.CustomUpperBodyNode3p;
                        v4 = v8;
                        v9.StopCustomAnim( BlendOutTime );
                        break;
                    }

                    break;
                case CustomNodeType.CNT_LowerBody:
                    CustomLowerBodyNode1p = this.CustomLowerBodyNode1p;
                    if( CustomLowerBodyNode1p )
                    {
                        CustomSequence = CustomLowerBodyNode1p .GetCustomAnimNodeSeq( );
                        this.CustomLowerBodyNode1p.StopCustomAnim( BlendOutTime );
                    }

                    CustomLowerBodyNode3p = this.CustomLowerBodyNode3p;
                    if( CustomLowerBodyNode3p )
                    {
                        v8 = CustomLowerBodyNode3p .GetCustomAnimNodeSeq( );
                        v9 = this.CustomLowerBodyNode3p;
                        v4 = v8;
                        v9.StopCustomAnim( BlendOutTime );
                        break;
                    }

                    break;
                case CustomNodeType.CNT_Camera:
                    CustomCameraNode = this.CustomCameraNode;
                    if( CustomCameraNode )
                    {
                        v21 = CustomCameraNode .GetCustomAnimNodeSeq( );
                        v9 = this.CustomCameraNode;
                        CustomSequence = v21;
                        v9.StopCustomAnim( BlendOutTime );
                        break;
                    }

                    break;
                case CustomNodeType.CNT_Weapon:
                    CustomWeaponNode1p = this.CustomWeaponNode1p;
                    if( CustomWeaponNode1p )
                    {
                        CustomSequence = CustomWeaponNode1p .GetCustomAnimNodeSeq( );
                        this.CustomWeaponNode1p.StopCustomAnim( BlendOutTime );
                    }

                    CustomWeaponNode3p = this.CustomWeaponNode3p;
                    if( CustomWeaponNode3p )
                    {
                        v8 = CustomWeaponNode3p .GetCustomAnimNodeSeq( );
                        v9 = this.CustomWeaponNode3p;
                        v4 = v8;
                        v9.StopCustomAnim( BlendOutTime );
                        break;
                    }

                    break;
                case CustomNodeType.CNT_Face:
                    CustomFaceNode = this.CustomFaceNode;
                    if( CustomFaceNode )
                    {
                        v8 = CustomFaceNode .GetCustomAnimNodeSeq( );
                        v9 = this.CustomFaceNode;
                        LABEL_34:
                        v4 = v8;
                        LABEL_35:
                        v9.StopCustomAnim( BlendOutTime );
                    }

                    break;
                default:
                    break;
            }

            CustomSequence ??= v4;
            if( CustomSequence )
            {
                movementStateMove = this.Moves[ (int)this.MovementState ];
                if( movementStateMove.CurrentCustomAnimName == CustomSequence.AnimSeqName )
                {
                    movementStateMove.OnAnimationStopped( CustomSequence );
                }
            }
        }
        
        #region src
        /*
void __thiscall ATdPawn::StopCustomAnim(_E_struct_ATdPawn *this, _E_enum_ECustomNodeType Type, float BlendOutTime)
{
  _E_struct_UAnimNodeSequence *CustomSequence; // edi
  _E_struct_UAnimNodeSequence *v4; // ebx
  _E_struct_UTdAnimNodeSlot *__ptr32 CustomCannedNode1p; // ecx
  _E_struct_UTdAnimNodeSlot *__ptr32 CustomCannedNode3p; // ecx
  _E_struct_UAnimNodeSequence *v8; // eax
  _E_struct_UTdAnimNodeSlot *__ptr32 v9; // ecx
  _E_struct_UTdAnimNodeSlot *__ptr32 CustomCannedUpperBodyNode1p; // ecx
  _E_struct_UTdAnimNodeSlot *__ptr32 CustomCannedUpperBodyNode3p; // ecx
  _E_struct_UTdAnimNodeSlot *__ptr32 CustomFullBodyNode1p; // ecx
  _E_struct_UTdAnimNodeSlot *__ptr32 CustomFullBodyNode3p; // ecx
  _E_struct_UTdAnimNodeSlot *__ptr32 CustomFullBodyDirNode1p; // ecx
  _E_struct_UTdAnimNodeSlot *__ptr32 CustomFullBodyDirNode3p; // ecx
  _E_struct_UTdAnimNodeSlot *__ptr32 CustomUpperBodyNode1p; // ecx
  _E_struct_UTdAnimNodeSlot *__ptr32 CustomUpperBodyNode3p; // ecx
  _E_struct_UTdAnimNodeSlot *__ptr32 CustomLowerBodyNode1p; // ecx
  _E_struct_UTdAnimNodeSlot *__ptr32 CustomLowerBodyNode3p; // ecx
  _E_struct_UTdAnimNodeSlot *__ptr32 CustomCameraNode; // ecx
  _E_struct_UAnimNodeSequence *v21; // eax
  _E_struct_UTdAnimNodeSlot *__ptr32 CustomWeaponNode1p; // ecx
  _E_struct_UTdAnimNodeSlot *__ptr32 CustomWeaponNode3p; // ecx
  _E_struct_UTdAnimNodeSlot *__ptr32 CustomFaceNode; // ecx
  _E_struct_UTdMove *__ptr32 movementStateMove; // ecx

  CustomSequence = 0;
  v4 = 0;
  switch ( Type )
  {
    case CNT_Canned:
      CustomCannedNode1p = this->CustomCannedNode1p;
      if ( CustomCannedNode1p )
      {
        CustomSequence = UAnimNodeSlot::GetCustomSequence(CustomCannedNode1p);
        UAnimNodeSlot::StopCustomAnim(this->CustomCannedNode1p, BlendOutTime);
      }
      CustomCannedNode3p = this->CustomCannedNode3p;
      if ( CustomCannedNode3p )
      {
        v8 = UAnimNodeSlot::GetCustomSequence(CustomCannedNode3p);
        v9 = this->CustomCannedNode3p;
        goto LABEL_34;
      }
      break;
    case CNT_CannedUpperBody:
      CustomCannedUpperBodyNode1p = this->CustomCannedUpperBodyNode1p;
      if ( CustomCannedUpperBodyNode1p )
      {
        CustomSequence = UAnimNodeSlot::GetCustomSequence(CustomCannedUpperBodyNode1p);
        UAnimNodeSlot::StopCustomAnim(this->CustomCannedUpperBodyNode1p, BlendOutTime);
      }
      CustomCannedUpperBodyNode3p = this->CustomCannedUpperBodyNode3p;
      if ( CustomCannedUpperBodyNode3p )
      {
        v8 = UAnimNodeSlot::GetCustomSequence(CustomCannedUpperBodyNode3p);
        v9 = this->CustomCannedUpperBodyNode3p;
        goto LABEL_34;
      }
      break;
    case CNT_FullBody:
      CustomFullBodyNode1p = this->CustomFullBodyNode1p;
      if ( CustomFullBodyNode1p )
      {
        CustomSequence = UAnimNodeSlot::GetCustomSequence(CustomFullBodyNode1p);
        UAnimNodeSlot::StopCustomAnim(this->CustomFullBodyNode1p, BlendOutTime);
      }
      CustomFullBodyNode3p = this->CustomFullBodyNode3p;
      if ( CustomFullBodyNode3p )
      {
        v8 = UAnimNodeSlot::GetCustomSequence(CustomFullBodyNode3p);
        v9 = this->CustomFullBodyNode3p;
        goto LABEL_34;
      }
      break;
    case CNT_FullBody_Dir:
      CustomFullBodyDirNode1p = this->CustomFullBodyDirNode1p;
      if ( CustomFullBodyDirNode1p )
      {
        CustomSequence = UAnimNodeSlot::GetCustomSequence(CustomFullBodyDirNode1p);
        UAnimNodeSlot::StopCustomAnim(this->CustomFullBodyDirNode1p, BlendOutTime);
      }
      CustomFullBodyDirNode3p = this->CustomFullBodyDirNode3p;
      if ( CustomFullBodyDirNode3p )
      {
        v8 = UAnimNodeSlot::GetCustomSequence(CustomFullBodyDirNode3p);
        v9 = this->CustomFullBodyDirNode3p;
        goto LABEL_34;
      }
      break;
    case CNT_UpperBody:
      CustomUpperBodyNode1p = this->CustomUpperBodyNode1p;
      if ( CustomUpperBodyNode1p )
      {
        CustomSequence = UAnimNodeSlot::GetCustomSequence(CustomUpperBodyNode1p);
        UAnimNodeSlot::StopCustomAnim(this->CustomUpperBodyNode1p, BlendOutTime);
      }
      CustomUpperBodyNode3p = this->CustomUpperBodyNode3p;
      if ( CustomUpperBodyNode3p )
      {
        v8 = UAnimNodeSlot::GetCustomSequence(CustomUpperBodyNode3p);
        v9 = this->CustomUpperBodyNode3p;
        goto LABEL_34;
      }
      break;
    case CNT_LowerBody:
      CustomLowerBodyNode1p = this->CustomLowerBodyNode1p;
      if ( CustomLowerBodyNode1p )
      {
        CustomSequence = UAnimNodeSlot::GetCustomSequence(CustomLowerBodyNode1p);
        UAnimNodeSlot::StopCustomAnim(this->CustomLowerBodyNode1p, BlendOutTime);
      }
      CustomLowerBodyNode3p = this->CustomLowerBodyNode3p;
      if ( CustomLowerBodyNode3p )
      {
        v8 = UAnimNodeSlot::GetCustomSequence(CustomLowerBodyNode3p);
        v9 = this->CustomLowerBodyNode3p;
        goto LABEL_34;
      }
      break;
    case CNT_Camera:
      CustomCameraNode = this->CustomCameraNode;
      if ( CustomCameraNode )
      {
        v21 = UAnimNodeSlot::GetCustomSequence(CustomCameraNode);
        v9 = this->CustomCameraNode;
        CustomSequence = v21;
        goto LABEL_35;
      }
      break;
    case CNT_Weapon:
      CustomWeaponNode1p = this->CustomWeaponNode1p;
      if ( CustomWeaponNode1p )
      {
        CustomSequence = UAnimNodeSlot::GetCustomSequence(CustomWeaponNode1p);
        UAnimNodeSlot::StopCustomAnim(this->CustomWeaponNode1p, BlendOutTime);
      }
      CustomWeaponNode3p = this->CustomWeaponNode3p;
      if ( CustomWeaponNode3p )
      {
        v8 = UAnimNodeSlot::GetCustomSequence(CustomWeaponNode3p);
        v9 = this->CustomWeaponNode3p;
        goto LABEL_34;
      }
      break;
    case CNT_Face:
      CustomFaceNode = this->CustomFaceNode;
      if ( CustomFaceNode )
      {
        v8 = UAnimNodeSlot::GetCustomSequence(CustomFaceNode);
        v9 = this->CustomFaceNode;
LABEL_34:
        v4 = v8;
LABEL_35:
        UAnimNodeSlot::StopCustomAnim(v9, BlendOutTime);
      }
      break;
    default:
      break;
  }
  if ( (unsigned int)CustomSequence | (CustomSequence == 0 ? (unsigned int)v4 : 0) )
  {
    movementStateMove = this->Moves.Data[this->MovementState];
    if ( movementStateMove->CurrentCustomAnimName.Index == *(_DWORD *)(((unsigned int)CustomSequence | (CustomSequence == 0 ? (unsigned int)v4 : 0))
                                                                     + 0xBC)// Compare names
      && movementStateMove->CurrentCustomAnimName.Number == *(_DWORD *)(((unsigned int)CustomSequence | (CustomSequence == 0 ? (unsigned int)v4 : 0))
                                                                      + 0xC0) )
    {
      UTdMove::CallOnAnimationStopped(
        movementStateMove,
        (_E_struct_UAnimNodeSequence *)((unsigned int)CustomSequence | (CustomSequence == 0 ? (unsigned int)v4 : 0)));
    }
  }
}
         */
        #endregion
        
        
        // Export UTdPawn::execGetCameraAnimation(FFrame&, void* const)
        public virtual /*native final function */void GetCameraAnimation(ref Object.Vector out_Location, ref Object.Rotator out_Rotation)
        {
            if ( Mesh )
            {
                var eyeRotator = QuatToRotator(Mesh.GetBoneQuaternion( "EyeJoint", 1 ));
                if ( AddCameraDeltaAnimations() )
                {
                    var cameraRotator = QuatToRotator(Mesh.GetBoneQuaternion( "CameraJoint", 1 ));
                    out_Rotation.Pitch = cameraRotator.Pitch + eyeRotator.Pitch;
                    out_Rotation.Yaw = cameraRotator.Yaw + eyeRotator.Yaw;
                    out_Rotation.Roll = eyeRotator.Roll + cameraRotator.Roll;
                }
                else
                {
                    out_Rotation.Pitch = eyeRotator.Pitch;
                    out_Rotation.Yaw = eyeRotator.Yaw;
                    out_Rotation.Roll = eyeRotator.Roll;
                }
            }
        }
        #region src
        /*
void __thiscall ATdPawn::GetCameraAnimation(
        _E_struct_ATdPawn *this,
        _E_struct_FVector *out_Location,
        _E_struct_FRotator *out_Rotation)
{
  _E_struct_USkeletalMeshComponent *Mesh; // ecx
  int eyeSocketIndex; // eax
  _E_struct_USkeletalMeshComponent *__ptr32 thisMesh; // edx
  _E_struct_FMatrix *v7; // eax
  int Dummy; // esi
  int func_AddCameraDeltaAnimations; // eax
  unsigned int v10; // edx
  unsigned int v11; // esi
  unsigned int Yaw; // edx
  unsigned int Roll; // ecx
  int addCameraDeltaAnimations; // [esp+14h] [ebp-11Ch] BYREF
  _E_struct_FRotator eyeRotator; // [esp+18h] [ebp-118h] BYREF
  _E_struct_FRotator cameraRotator; // [esp+24h] [ebp-10Ch] BYREF
  _E_struct_FMatrix cameraSpaceBase; // [esp+30h] [ebp-100h] BYREF
  _E_struct_FMatrix eyeSpaceBase; // [esp+70h] [ebp-C0h] BYREF
  _E_struct_FMatrix v19; // [esp+B0h] [ebp-80h] BYREF
  _E_struct_FMatrix v20; // [esp+F0h] [ebp-40h] BYREF

  Mesh = this->Mesh;
  if ( Mesh )
  {
    eyeSocketIndex = E_FindSocketIndex(Mesh, EyeJoint_dword_20567FC, dword_2056800);
    thisMesh = this->Mesh;
    qmemcpy(&eyeSpaceBase, &thisMesh->SpaceBases.Data[eyeSocketIndex], sizeof(eyeSpaceBase));
    qmemcpy(
      &cameraSpaceBase,
      &this->Mesh->SpaceBases.Data[E_FindSocketIndex(thisMesh, CameraJoint_dword_2056804, dword_2056808)],
      sizeof(cameraSpaceBase));
    v7 = VectorMatrixInverse(&eyeSpaceBase, &v19);
    qmemcpy(
      &cameraSpaceBase,
      sub_4465B0((__m128 *)&cameraSpaceBase, (__m128 *)&v20, (__m128 *)v7),
      sizeof(cameraSpaceBase));
    E_MatrixToRotator(&eyeSpaceBase, &eyeRotator);
    E_MatrixToRotator(&cameraSpaceBase, &cameraRotator);
    Dummy = this->VfTableObject.Dummy;
    addCameraDeltaAnimations = 0;
    func_AddCameraDeltaAnimations = sub_11090D0(
                                      this,
                                      AddCameraDeltaAnimations1_dword_20554B0,
                                      AddCameraDeltaAnimations2_dword_20554B4,
                                      0);
    (*(void (__stdcall **)(int, int *, _DWORD))(Dummy + 244))(
      func_AddCameraDeltaAnimations,
      &addCameraDeltaAnimations,
      0);                                       // Call UScript AddCameraDeltaAnimations
    if ( addCameraDeltaAnimations )
    {
      v10 = cameraRotator.Yaw + eyeRotator.Yaw;
      v11 = eyeRotator.Roll + cameraRotator.Roll;
      out_Rotation->Pitch = cameraRotator.Pitch + eyeRotator.Pitch;
      out_Rotation->Yaw = v10;
      out_Rotation->Roll = v11;
    }
    else
    {
      Yaw = eyeRotator.Yaw;
      out_Rotation->Pitch = eyeRotator.Pitch;
      Roll = eyeRotator.Roll;
      out_Rotation->Yaw = Yaw;
      out_Rotation->Roll = Roll;
    }
  }
}
         */
        #endregion
        
        // Export UTdPawn::execSyncLegMovement(FFrame&, void* const)
        public virtual void SyncLegMovement()
        {
            //_E_struct_TArray_FSynchGroup *p_Groups; // edx
            //int32_t v2; // ebp
            //_E_struct_TArray_FSynchGroup *v3; // edi
            //int v4; // esi
            //_E_struct_FSynchGroup *v5; // eax
            //_E_struct_FSynchGroup *v6; // ecx

            var p_Groups = this.MasterSync3p.Groups;
            var v2 = 0;
            var v3 = this.MasterSync1p.Groups;
            if ( this.MasterSync3p.Groups.Count > 0 )
            {
                var v4 = 0;
                do
                {
                    ref var v5 = ref p_Groups[v4];
                    ref var v6 = ref v3[v4];
                    if ( (v5.bUseSharedMasterControlNode) != false )
                    {
                        v5.SharedMasterRelativePosition = v6.SharedMasterRelativePosition;
                        v5.SharedMasterMoveDelta = v6.SharedMasterMoveDelta;
                    }
                    ++v2;
                    ++v4;
                }
                while ( v2 < p_Groups.Count );
            }
        }
        #region src
        /*
void __thiscall ATdPawn::SyncLegMovement(_E_struct_ATdPawn *this)
{
  _E_struct_TArray_FSynchGroup *p_Groups; // edx
  int32_t v2; // ebp
  _E_struct_TArray_FSynchGroup *v3; // edi
  int v4; // esi
  _E_struct_FSynchGroup *v5; // eax
  _E_struct_FSynchGroup *v6; // ecx

  p_Groups = &this->MasterSync3p->Groups;
  v2 = 0;
  v3 = &this->MasterSync1p->Groups;
  if ( this->MasterSync3p->Groups.Count > 0 )
  {
    v4 = 0;
    do
    {
      v5 = &p_Groups->Data[v4];
      v6 = &v3->Data[v4];
      if ( (v5->bitfield_bUseSharedMasterControlNode & 1) != 0 )
      {
        v5->SharedMasterRelativePosition = v6->SharedMasterRelativePosition;
        v5->SharedMasterMoveDelta = v6->SharedMasterMoveDelta;
      }
      ++v2;
      ++v4;
    }
    while ( v2 < p_Groups->Count );
  }
}
         */
        #endregion



        // Export UTdPawn::execGetCustomAnimation(FFrame&, void* const)
        public virtual /*native simulated function */AnimNodeSequence GetCustomAnimation(TdPawn.CustomNodeType Type)
        {
            TdAnimNodeSlot CustomCannedNode1p;
            switch( (int) Type )
            {
                case 0:
                    if( this.Mesh == this.Mesh1p )
                    {
                        CustomCannedNode1p = this.CustomCannedNode1p;
                        if( ! CustomCannedNode1p )
                            return null;
                    }
                    else
                    {
                        CustomCannedNode1p = this.CustomCannedNode3p;
                        if( ! CustomCannedNode1p )
                            return null;
                    }

                    return CustomCannedNode1p.GetCustomAnimNodeSeq();
                case 1:
                    if( this.Mesh == this.Mesh1p )
                    {
                        CustomCannedNode1p = this.CustomCannedUpperBodyNode1p;
                        if( ! CustomCannedNode1p )
                            return null;
                    }
                    else
                    {
                        CustomCannedNode1p = this.CustomCannedUpperBodyNode3p;
                        if( ! CustomCannedNode1p )
                            return null;
                    }

                    return CustomCannedNode1p.GetCustomAnimNodeSeq();
                case 2:
                    if( this.Mesh == this.Mesh1p )
                    {
                        CustomCannedNode1p = this.CustomFullBodyNode1p;
                        if( ! CustomCannedNode1p )
                            return null;
                    }
                    else
                    {
                        CustomCannedNode1p = this.CustomFullBodyNode3p;
                        if( ! CustomCannedNode1p )
                            return null;
                    }

                    return CustomCannedNode1p.GetCustomAnimNodeSeq();
                case 3:
                    if( this.Mesh == this.Mesh1p )
                    {
                        CustomCannedNode1p = this.CustomFullBodyDirNode1p;
                        if( ! CustomCannedNode1p )
                            return null;
                    }
                    else
                    {
                        CustomCannedNode1p = this.CustomFullBodyDirNode3p;
                        if( ! CustomCannedNode1p )
                            return null;
                    }

                    return CustomCannedNode1p.GetCustomAnimNodeSeq();
                case 4:
                    if( this.Mesh == this.Mesh1p )
                    {
                        CustomCannedNode1p = this.CustomUpperBodyNode1p;
                        if( ! CustomCannedNode1p )
                            return null;
                    }
                    else
                    {
                        CustomCannedNode1p = this.CustomUpperBodyNode3p;
                        if( ! CustomCannedNode1p )
                            return null;
                    }

                    return CustomCannedNode1p.GetCustomAnimNodeSeq();
                case 6:
                    if( this.Mesh == this.Mesh1p )
                    {
                        CustomCannedNode1p = this.CustomCameraNode;
                        if( CustomCannedNode1p )
                            return CustomCannedNode1p.GetCustomAnimNodeSeq();
                    }

                    return null;
                case 7:
                    if( this.Mesh == this.Mesh1p )
                    {
                        CustomCannedNode1p = this.CustomWeaponNode1p;
                        if( CustomCannedNode1p )
                            return CustomCannedNode1p.GetCustomAnimNodeSeq();
                    }
                    else
                    {
                        CustomCannedNode1p = this.CustomWeaponNode3p;
                        if( CustomCannedNode1p )
                            return CustomCannedNode1p.GetCustomAnimNodeSeq();
                    }

                    return null;
                case 8:
                    if( this.Mesh != this.Mesh1p )
                    {
                        CustomCannedNode1p = this.CustomFaceNode;
                        if( CustomCannedNode1p )
                            return CustomCannedNode1p.GetCustomAnimNodeSeq();
                    }

                    return null;
                default:
                    return null;
            }
        }
        
        // Export UTdPawn::execSetRootOffset(FFrame&, void* const)
        public virtual /*native simulated function */void SetRootOffset(Object.Vector Offset, float BlendTime, /*optional */SkelControlBase.EBoneControlSpace? _TranslationSpace = default)
        {
            NativeMarkers.MarkUnimplemented(); // Controls aren't implemented at all
            var TranslationSpace = _TranslationSpace ?? SkelControlBase.EBoneControlSpace.BCS_ActorSpace;
            if ( sqrt(Offset.Y * Offset.Y + Offset.X * Offset.X + Offset.Z * Offset.Z) <= 0.1 )
            {
                if ( this.RootControl1p )
                    RootControl1p.SetSkelControlStrength(0.0f, BlendTime);
                if ( this.RootControl3p )
                    RootControl3p.SetSkelControlStrength(0.0f, BlendTime);
            }
            else
            {
                if ( this.RootControl1p )
                {
                    this.RootControl1p.BoneTranslation = Offset;
                    this.RootControl1p.SetSkelControlStrength(1.0f, BlendTime);
                    this.RootControl1p.BoneTranslationSpace = TranslationSpace;
                }
                if ( this.RootControl3p )
                {
                    this.RootControl3p.BoneTranslation = Offset;
                    this.RootControl3p.SetSkelControlStrength(1.0f, BlendTime);
                    this.RootControl3p.BoneTranslationSpace = TranslationSpace;
                }
            }
        }

        // Export UTdPawn::execPlayCustomAnim(FFrame&, void* const)
        public virtual /*native simulated function */void PlayCustomAnim(TdPawn.CustomNodeType Type, name AnimName, float Rate, float BlendInTime, float BlendOutTime, bool bLooping, bool bOverride, bool bRootMotion, /*optional */bool? _bRootRotation = default)
        {
            int v10; // ebx
  int v11; // ebp
  int v12; // edi
  bool v13; // eax
  bool v14; // eax
  bool v15; // eax
  bool v16; // eax
  bool v17; // eax
  bool v18; // eax
  bool v19; // eax
  bool v20; // eax
  bool v21; // eax
  bool v22; // eax
  
  var bRootRotation = _bRootRotation ?? false;
  switch ( Type )
  {
    case CustomNodeType.CNT_Canned:
      v13 = bRootMotion && this.Mesh1p == this.Mesh;// PlayCustomAnimInternal
      PlayCustomAnimInternal(
        this.CustomCannedNode1p,
        AnimName,
        Rate,
        BlendInTime,
        BlendOutTime,
        bLooping,
        bOverride,
        v13,
        bRootRotation);
      PlayCustomAnimInternal(
        this.CustomCannedNode3p,
        AnimName,
        Rate,
        BlendInTime,
        BlendOutTime,
        bLooping,
        bOverride,
        bRootMotion,
        bLooping);
      ReplicateCustomAnim(
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
    case CustomNodeType.CNT_CannedUpperBody:
      v14 = bRootMotion && this.Mesh1p == this.Mesh;
      PlayCustomAnimInternal(
        this.CustomCannedUpperBodyNode1p,
        AnimName,
        Rate,
        BlendInTime,
        BlendOutTime,
        bLooping,
        bOverride,
        v14,
        bRootRotation);
      PlayCustomAnimInternal(
        this.CustomCannedUpperBodyNode3p,
        AnimName,
        Rate,
        BlendInTime,
        BlendOutTime,
        bLooping,
        bOverride,
        bRootMotion,
        bLooping);
      ReplicateCustomAnim(
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
    case CustomNodeType.CNT_FullBody:
      v15 = bRootMotion && this.Mesh1p == this.Mesh;
      PlayCustomAnimInternal(
        this.CustomFullBodyNode1p,
        AnimName,
        Rate,
        BlendInTime,
        BlendOutTime,
        bLooping,
        bOverride,
        v15,
        bRootRotation);
      PlayCustomAnimInternal(
        this.CustomFullBodyNode3p,
        AnimName,
        Rate,
        BlendInTime,
        BlendOutTime,
        bLooping,
        bOverride,
        bRootMotion,
        bLooping);
      ReplicateCustomAnim(
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
    case CustomNodeType.CNT_FullBody_Dir:
      v16 = bRootMotion && this.Mesh1p == this.Mesh;
      PlayCustomAnimInternal(
        this.CustomFullBodyDirNode1p,
        AnimName,
        Rate,
        BlendInTime,
        BlendOutTime,
        bLooping,
        bOverride,
        v16,
        bRootRotation);                                   // PlayCustomAnimInternal
      PlayCustomAnimInternal(
        this.CustomFullBodyDirNode3p,
        AnimName,
        Rate,
        BlendInTime,
        BlendOutTime,
        bLooping,
        bOverride,
        bRootMotion,
        bLooping);                              // ATdPawn::PlayCustomAnimInternal ?!?!
      ReplicateCustomAnim(
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
    case CustomNodeType.CNT_UpperBody:
      v17 = bRootMotion && this.Mesh1p == this.Mesh;
      PlayCustomAnimInternal(
        this.CustomUpperBodyNode1p,
        AnimName,
        Rate,
        BlendInTime,
        BlendOutTime,
        bLooping,
        bOverride,
        v17,
        bRootRotation);
      PlayCustomAnimInternal(
        this.CustomUpperBodyNode3p,
        AnimName,
        Rate,
        BlendInTime,
        BlendOutTime,
        bLooping,
        bOverride,
        bRootMotion,
        bLooping);
      ReplicateCustomAnim(
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
    case CustomNodeType.CNT_LowerBody:
      v18 = bRootMotion && this.Mesh1p == this.Mesh;
      PlayCustomAnimInternal(
        this.CustomLowerBodyNode1p,
        AnimName,
        Rate,
        BlendInTime,
        BlendOutTime,
        bLooping,
        bOverride,
        v18,
        bRootRotation);                                   // PlayCustomAnimInternal
      PlayCustomAnimInternal(
        this.CustomLowerBodyNode3p,
        AnimName,
        Rate,
        BlendInTime,
        BlendOutTime,
        bLooping,
        bOverride,
        bRootMotion,
        bLooping);
      ReplicateCustomAnim(
        Type,
        AnimName,
        Rate,
        BlendInTime,
        BlendOutTime,
        bLooping,
        bOverride,
        bRootMotion,
        bRootRotation);                         // ATdPawn::ReplicateCustomAnim_Maybe
      break;
    case CustomNodeType.CNT_Camera:
      v19 = bRootMotion && this.Mesh1p == this.Mesh;
      PlayCustomAnimInternal(
        this.CustomCameraNode,
        AnimName,
        Rate,
        BlendInTime,
        BlendOutTime,
        bLooping,
        bOverride,
        v19,
        bRootRotation);
      break;
    case CustomNodeType.CNT_Weapon:
      v20 = bRootMotion && this.Mesh1p == this.Mesh;
      PlayCustomAnimInternal(
        this.CustomWeaponNode1p,
        AnimName,
        Rate,
        BlendInTime,
        BlendOutTime,
        bLooping,
        bOverride,
        v20,
        bRootRotation);
      v21 = bRootMotion && this.Mesh1p == this.Mesh;
      PlayCustomAnimInternal(
        this.CustomWeaponNode3p,
        AnimName,
        Rate,
        BlendInTime,
        BlendOutTime,
        bLooping,
        bOverride,
        v21,
        bRootRotation);
      break;
    case CustomNodeType.CNT_Face:
      v22 = bRootMotion && this.Mesh3p == this.Mesh;
      PlayCustomAnimInternal(
        this.CustomFaceNode,
        AnimName,
        Rate,
        BlendInTime,
        BlendOutTime,
        bLooping,
        bOverride,
        v22,
        bRootRotation);
      break;
    default:
      return;
  }
        }
        
        
        // Export UTdPawn::execPlayCustomAnimInternal(FFrame&, void* const)
        public virtual /*native simulated function */bool PlayCustomAnimInternal(TdAnimNodeSlot tdSlot, name AnimName, float Rate, float BlendInTime, float BlendOutTime, bool bLooping, bool bOverride, bool bRootMotion, /*optional */bool? _bRootRotation = default)
        {
            if ( !tdSlot
                 || tdSlot.PlayCustomAnim(AnimName, Rate, BlendInTime, BlendOutTime, bLooping, bOverride) == 0.0 )
            {
                return false;
            }
            if ( tdSlot == this.CustomCameraNode || tdSlot == this.CustomWeaponNode1p )
            {
                var CustomAnimNodeSeq = tdSlot.GetCustomAnimNodeSeq();
                var asTdSeq = (CustomAnimNodeSeq) as TdAnimNodeSequence;
                asTdSeq.bDeltaCameraAnimation = true;
            }
            if ( bRootMotion )
                tdSlot.SetRootBoneAxisOption(AnimNodeSequence.ERootBoneAxis.RBA_Translate, AnimNodeSequence.ERootBoneAxis.RBA_Translate, AnimNodeSequence.ERootBoneAxis.RBA_Translate);
            else
                tdSlot.SetRootBoneAxisOption(AnimNodeSequence.ERootBoneAxis.RBA_Default, AnimNodeSequence.ERootBoneAxis.RBA_Default, AnimNodeSequence.ERootBoneAxis.RBA_Default);
            if ( _bRootRotation ?? false )
                tdSlot.SetRootBoneRotationAxisOption(AnimNodeSequence.ERootRotationOption.RRO_Extract, AnimNodeSequence.ERootRotationOption.RRO_Extract, AnimNodeSequence.ERootRotationOption.RRO_Extract);
            else
                tdSlot.SetRootBoneRotationAxisOption(AnimNodeSequence.ERootRotationOption.RRO_Discard, AnimNodeSequence.ERootRotationOption.RRO_Discard, AnimNodeSequence.ERootRotationOption.RRO_Discard);
            tdSlot.SetActorAnimEndNotification(true);
            tdSlot.SetCauseActorCeaseRelevant(true);
            return true;
        }
        
        // Export UTdPawn::execSetCustomAnimsBlendOutTime(FFrame&, void* const)
        public virtual /*native simulated function */void SetCustomAnimsBlendOutTime(TdPawn.CustomNodeType Type, float BlendOutTime)
        {
            TdAnimNodeSlot node; // ecx

            switch ( (int)Type )
            {
                case 0:
                    goto LABEL_9;
                case 1:
                    goto LABEL_10;
                case 2:
                    CustomFullBodyNode1p.SetBlendOutTime(BlendOutTime);// SetBlendOutTime
                    node = this.CustomFullBodyNode3p;
                    goto LABEL_11;
                case 3:
                    CustomFullBodyDirNode1p.SetBlendOutTime(BlendOutTime);
                    node = this.CustomFullBodyDirNode3p;
                    goto LABEL_11;
                case 4:
                    CustomUpperBodyNode1p.SetBlendOutTime(BlendOutTime);
                    node = this.CustomUpperBodyNode3p;
                    goto LABEL_11;
                case 5:
                    CustomLowerBodyNode1p.SetBlendOutTime(BlendOutTime);
                    node = this.CustomLowerBodyNode3p;
                    goto LABEL_11;
                case 6:
                    node = this.CustomCameraNode;
                    goto LABEL_11;
                case 7:
                    CustomWeaponNode1p.SetBlendOutTime(BlendOutTime);
                    node = this.CustomWeaponNode3p;
                    goto LABEL_11;
                case 8:
                    CustomFaceNode.SetBlendOutTime(BlendOutTime);
                    LABEL_9:
                    CustomCannedNode1p.SetBlendOutTime(BlendOutTime);
                    CustomCannedNode3p.SetBlendOutTime(BlendOutTime);
                    LABEL_10:
                    CustomCannedUpperBodyNode1p.SetBlendOutTime(BlendOutTime);
                    node = this.CustomCannedUpperBodyNode3p;
                    LABEL_11:
                    node.SetBlendOutTime(BlendOutTime);
                    break;
                default:
                    return;
            }
        }
	
        // Export UTdPawn::execInitMoveObjects(FFrame&, void* const)
        public virtual /*native function */void InitMoveObjects()
        {
            NativeMarkers.MarkUnimplemented();
            // Not verified
            for( int i = 0; i < this.MoveClasses.Length; i++ )
            {
                var c = this.MoveClasses[ i ];
                if( c == null )
                    continue;
                this.Moves[ i ] = this.MoveClasses[ i ].New( this );
                this.Moves[ i ].PawnOwner = this;
            }

            this.Mesh3p.Animations = this.Mesh3p.AnimTreeTemplate;
            this.Mesh1p.Animations = this.Mesh1p.AnimTreeTemplate;
            LogWarning( $"Need to implement clone for {nameof(this.Mesh3p.AnimTreeTemplate)} instead of straight assign" );
        }


        
        public virtual void UpdateVelocityVariables()
        {
            NativeMarkers.MarkUnimplemented();
            float velSqrt; // st7
            float v2; // xmm2_4
            float v3; // edx
            int result; // eax
            float velSqrt2D; // st6
            float v6; // xmm1_4
            float velSqrtB; // [esp+0h] [ebp-10h]

            velSqrt = (float)sqrt(this.Velocity.Z * this.Velocity.Z + this.Velocity.Y * this.Velocity.Y + this.Velocity.X * this.Velocity.X);
            velSqrtB = velSqrt;
            this.VelocityMagnitude = velSqrt;
            if ( velSqrt <= 0.00000001f )
            {
                this.VelocityMagnitude = 0.0f;
                //*(_QWORD *)&this.VelocityDir.Y = 0i64;
                this.VelocityDir.Y = 0f;
                this.VelocityDir.Z = 0f;
                
                this.VelocityDir.X = 0.0f;
            }
            else
            {
                v2 = this.Velocity.Z;
                v3 = this.Velocity.Y * (float)(1.0f / velSqrtB);
                this.VelocityDir.X = this.Velocity.X * (float)(1.0f / velSqrtB);
                this.VelocityDir.Y = v3;
                this.VelocityDir.Z = v2 * (float)(1.0f / velSqrtB);
                velSqrt2D = (float)sqrt(this.Velocity.Y * this.Velocity.Y + this.Velocity.X * this.Velocity.X);
                this.VelocityMagnitude2D = velSqrt2D;
                if ( velSqrt2D > 0.00000001f )
                {
                    v6 = 1.0f / this.VelocityMagnitude2D;
                    this.VelocityDir2D.X = this.Velocity.X;
                    this.VelocityDir2D.Y = this.Velocity.Y;
                    this.VelocityDir2D.Z = 0.0f;
                    this.VelocityDir2D.X = this.VelocityDir2D.X * v6;
                    this.VelocityDir2D.Y = this.VelocityDir2D.Y * v6;
                    this.VelocityDir2D.Z = this.VelocityDir2D.Z * v6;
                    return;
                }
            }
            this.VelocityDir2D.X = 0.0f;
            this.VelocityDir2D.Y = 0.0f;
            this.VelocityDir2D.Z = 0.0f;
            this.VelocityMagnitude2D = 0.0f;
            return;
        }
        
        
        
        public virtual void UpdateWalkingState()
        {
            NativeMarkers.MarkUnimplemented();
            WalkingState v1; // eax
            TdWeapon ptrToWeapon; // eax
            float v4; // [esp+0h] [ebp-4h]

            v1 = this.OverrideWalkingState;
            v4 = (float)sqrt(this.Velocity.Y * this.Velocity.Y + this.Velocity.X * this.Velocity.X);
            if( v1 != (WalkingState) 6 )
            {
                this.CurrentWalkingState = (WalkingState)v1;
                return;
            }

            ptrToWeapon = this.MyWeapon;
            v1 = (WalkingState)(ptrToWeapon != null && ptrToWeapon.WeaponType == (EWeaponType)1 ? 1 : 0);
            if ( this.SneakVelocity > v4 )
            {
                this.CurrentWalkingState = (WalkingState)0;
                return;
            }
            if ( this.WalkVelocity > v4 )
            {
                v1 = (WalkingState)(v1 != 0 ? 1 : 0) + 1;
                this.CurrentWalkingState = (WalkingState)v1;
                return;
            }
            if ( this.JogVelocity <= v4 )
            {
                if ( this.RunVelocity <= v4 )
                {
                    if( this.SprintVelocity <= v4 )
                        this.CurrentWalkingState = (WalkingState)(v1 == 0 ? 1 : 0) + 4; //(v1 == 0) + 4;
                    else
                        this.CurrentWalkingState = (WalkingState) 4;
                }
                else
                {
                    this.CurrentWalkingState = (WalkingState)3;
                }
            }
            else
            {
                this.CurrentWalkingState = (WalkingState)2;
            }
        }
        
        public virtual /*native function */bool IsInMove(TdPawn.EMovement Move)
        {
            return MovementState == Move;
        }
        
        
        public virtual float GetMobilityMultiplier()
        {
            float v1; // xmm0_4
            float v2; // xmm2_4
            double result; // st7

            /*v1 = 1.0f - (float)(this.TaserDamageLevel * 0.0099999998f);
            v2 = 0.0f;
            if ( v1 >= 0.0f && (v2 = 1.0f - (float)(this.TaserDamageLevel * 0.0099999998f), v1 > 1.0f) )
                return 1.0f;
            else
                return v2;*/
            
            // No idea what happened with optimization+decompilation above but this is what the logic translates to:
            
            v1 = 1.0f - (float)(this.TaserDamageLevel * 0.0099999998f);
            if( v1 < 0 )
                return 0f;
            if( v1 > 1.0f )
                return 1.0f;
            return v1;
        }
        
        
        
        public virtual Vector /*E_ATdPawn_GetWalkAcceleration*/GetWalkAcceleration(float aForward, float aStrafe, int deltaRotation, float deltaTime)
        {
            NativeMarkers.MarkUnimplemented();
            unsafe
            {
                _E_struct_FMatrix *v7; // eax
                float v8; // xmm6_4
                float v9; // xmm7_4
                float v10; // xmm4_4
                float v11; // xmm5_4
                float v12; // xmm0_4
                float v13; // xmm3_4
                float v14; // xmm1_4
                float v15; // xmm0_4
                float v16; // xmm2_4
                float v17; // xmm1_4
                float v18; // xmm0_4
                float v19; // xmm0_4
                float v20; // xmm3_4
                float v21; // xmm2_4
                float v22; // xmm0_4
                float v23; // xmm1_4
                float v24; // xmm0_4
                float v25; // xmm6_4
                float v26; // xmm7_4
                float v27; // xmm5_4
                float v28; // xmm0_4
                float v29; // xmm4_4
                float v30; // xmm0_4
                float v31; // xmm2_4
                float groundFriction; // xmm6_4
                _E_struct_FVector *result; // eax
                float v34; // [esp+10h] [ebp-98h]
                _E_struct_FVector v35; // [esp+10h] [ebp-98h]
                float v36; // [esp+10h] [ebp-98h]
                float v37; // [esp+10h] [ebp-98h]
                float v38; // [esp+14h] [ebp-94h]
                float v39; // [esp+14h] [ebp-94h]
                float v40; // [esp+14h] [ebp-94h]
                float v41; // [esp+18h] [ebp-90h]
                float v42; // [esp+18h] [ebp-90h]
                float v43; // [esp+18h] [ebp-90h]
                float v44; // [esp+1Ch] [ebp-8Ch]
                float v45; // [esp+20h] [ebp-88h]
                float v46; // [esp+20h] [ebp-88h]
                float v47; // [esp+24h] [ebp-84h]
                float v48; // [esp+24h] [ebp-84h]
                float v49; // [esp+2Ch] [ebp-7Ch]
                float v50; // [esp+2Ch] [ebp-7Ch]
                float v51; // [esp+30h] [ebp-78h]
                float v52; // [esp+3Ch] [ebp-6Ch]
                float v53; // [esp+48h] [ebp-60h]
                float v54; // [esp+50h] [ebp-58h]
                float v55; // [esp+5Ch] [ebp-4Ch]
                float v56; // [esp+60h] [ebp-48h]
                _E_struct_FMatrix thisMatrix; // [esp+68h] [ebp-40h] BYREF

                var r = this.Rotation;
                var v = FRotationMatrix( r );
                v7 = &v;
                v8 = v7->M[5];
                v9 = v7->M[6];
                v10 = v7->M[1];
                v11 = v7->M[2];
                v52 = v7->M[4];
                v51 = v7->M[0];
                v41 = (float)(v11 * aForward) + (float)(v9 * aStrafe);
                v12 = (float)((float)(v41 * v41) + (float)((float)((float)(v10 * aForward) + (float)(v8 * aStrafe)) * (float)((float)(v10 * aForward) + (float)(v8 * aStrafe))))
                    + (float)((float)((float)(v7->M[0] * aForward) + (float)(v52 * aStrafe)) * (float)((float)(v7->M[0] * aForward) + (float)(v52 * aStrafe)));
                v34 = (float)(v7->M[0] * aForward) + (float)(v52 * aStrafe);
                if ( v12 == 1.0f )
                {
                    v44 = (float)(v7->M[0] * aForward) + (float)(v52 * aStrafe);
                    v13 = v44;
                    v47 = (float)(v11 * aForward) + (float)(v9 * aStrafe);
                    v14 = v47;
                    v45 = (float)(v10 * aForward) + (float)(v8 * aStrafe);
            LABEL_6:
                    v15 = 0.0f;
                    goto LABEL_7;
                }
                if ( v12 >= 0.0000000099999999f )
                {
                    v16 = 1.0f / fsqrt(v12);
                    v53 = (float)(3.0f - (float)((float)(v16 * v12) * v16)) * (float)(v16 * 0.5f);
                    v45 = (float)((float)(v10 * aForward) + (float)(v8 * aStrafe)) * v53;
                    v13 = v53 * v34;
                    v14 = v41 * v53;
                    v44 = v53 * v34;
                    v47 = v41 * v53;
                    v15 = 0.0f;
                    goto LABEL_7;
                }
                v15 = 0.0f;
                v13 = 0.0f;
                v14 = 0.0f;
                v44 = 0.0f;
                v45 = 0.0f;
                v47 = 0.0f;
            LABEL_7:
                v35.X = 0.0f;
                v35.Y = 0.0f;
                v35.Z = 0.0f;
                if ( fabs(v44) >= 0.000099999997f || fabs(v45) >= 0.000099999997f || fabs(v47) >= 0.000099999997f )
                {
                    if ( this.SpeedSprintEnergy > 0.0f )
                    {
                        v17 = (float)((float)(v14 * v11) + (float)(v45 * v10)) + (float)(v13 * v51);
                        v49 = v17;
                        /*if ( v17 < 0.0f || (v15 = 0.89999998f, v17 > 0.89999998f) )
                            v49 = v15;*/
                        if ( v17 < 0.0f )
                            v49 = v15;
                        else
                        {
                            v15 = 0.89999998f;
                            if(v17 > 0.89999998f)
                                v49 = v15;
                        }

                        v50 = (float)(this.SpeedSprintEnergy - (1.0f - pow(v49, this.SpeedEnergyDecelerationExponent)) * (this.GroundSpeed - this.SpeedMaxBaseVelocity) / this.SpeedEnergyDecelerationTime * deltaTime);
                        v18 = v50;
                        this.SpeedSprintEnergy = v50;
                        if ( v50 < 0.0f )
                            v18 = 0.0f;
                        v13 = v44;
                        v14 = v47;
                        this.SpeedSprintEnergy = v18;
                    }
                    v19 = (float)((float)((float)((float)(v14 * v9) + (float)(v45 * v8)) + (float)(v13 * v52)) * this.SpeedMinBaseVelocity) + (float)((float)((float)(this.SpeedMaxBaseVelocity - this.SpeedMinBaseVelocity) + this.SpeedSprintEnergy) * aStrafe);
                    v55 = v8 * v19;
                    v56 = v9 * v19;
                    v20 = v19 * v52;
                    v21 = (float)((float)((float)((float)(v14 * v11) + (float)(v45 * v10)) + (float)(v44 * v51)) * this.SpeedMinBaseVelocity) + (float)((float)((float)(this.SpeedMaxBaseVelocity - this.SpeedMinBaseVelocity) + this.SpeedSprintEnergy) * aForward);
                    v54 = v11 * v21;
                    v22 = (float)((float)(this.Velocity.Z * v9) + (float)(this.Velocity.Y * v8)) + (float)(this.Velocity.X * v52);
                    v46 = v8 * v22;
                    v23 = v22;
                    v48 = v9 * v22;
                    v24 = (float)((float)(this.Velocity.Z * v11) + (float)(this.Velocity.Y * v10)) + (float)(this.Velocity.X * v51);
                    v25 = v24 * v51;
                    v26 = this.SpeedStrafeVelocityAccelerationFactor;
                    v27 = v11 * v24;
                    v28 = (float)(v10 * v21) - (float)(v10 * v24);
                    v29 = this.SpeedWalkVelocityAccelerationFactor;
                    v30 = (float)(v28 * v29) + (float)((float)(v55 - v46) * v26);
                    v31 = (float)((float)((float)(v21 * v51) - v25) * v29) + (float)((float)(v20 - (float)(v23 * v52)) * v26);
                    v36 = v31;
                    v38 = v30;
                    v42 = (float)((float)(v54 - v27) * v29) + (float)((float)(v56 - v48) * v26);
                    if ( this.Physics != (EPhysics)2 )
                    {
                        groundFriction = this.PhysicsVolume.GroundFriction;
                        v36 = (float)((float)(this.Velocity.X * groundFriction) * 0.1f) + v31;
                        v38 = (float)((float)(this.Velocity.Y * groundFriction) * 0.1f) + v30;
                        v42 = (float)((float)(this.Velocity.Z * groundFriction) * 0.1f) + (float)((float)((float)(v54 - v27) * v29) + (float)((float)(v56 - v48) * v26));
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

                return v35;
                /*result = outputVec;
                *outputVec = v35;
                return result;*/
            }
        }
        
        
        public virtual Vector GetSprintAcceleration(float aForward, float aStrafe, int DeltaRotation, float deltaTime)
        {
            NativeMarkers.MarkUnimplemented();
            unsafe
            {
                _E_struct_FVector ____;
                _E_struct_FVector* vecOutput = &____;
                _E_struct_FMatrix *v7; // eax
                double v8; // st7
                float v9; // xmm6_4
                float v10; // xmm4_4
                float v11; // xmm5_4
                float v12; // xmm0_4
                float v13; // xmm2_4
                _E_struct_FVector *result; // eax
                float v15; // edx
                float v16; // ecx
                float v17; // xmm0_4
                double v18; // st7
                TdWeapon ptrToWeapon; // eax
                float v20; // xmm5_4
                float v21; // xmm7_4
                float v22; // xmm6_4
                float v23; // xmm0_4
                float v24; // xmm4_4
                double v25; // st7
                float v26; // xmm4_4
                float v27; // xmm6_4
                float v28; // xmm5_4
                float v29; // xmm1_4
                float v30; // xmm0_4
                float v31; // xmm3_4
                float v32; // xmm0_4
                float v33; // xmm6_4
                float v34; // xmm0_4
                float v35; // xmm2_4
                float v36; // xmm3_4
                float v37; // xmm4_4
                float v38; // xmm2_4
                float v39; // xmm5_4
                float v40; // xmm0_4
                float v41; // xmm1_4
                float v42; // xmm4_4
                float v43; // xmm6_4
                float v44; // xmm5_4
                float v45; // xmm4_4
                float v46; // xmm3_4
                float v47; // xmm1_4
                float v48; // xmm2_4
                float v49; // xmm0_4
                double v50; // st7
                double v51; // st5
                float v52; // [esp+0h] [ebp-ACh]
                float v53; // [esp+14h] [ebp-98h] BYREF
                _E_struct_FVector v54; // [esp+18h] [ebp-94h]
                _E_struct_FVector v55; // [esp+28h] [ebp-84h]
                _E_struct_FVector v56; // [esp+38h] [ebp-74h]
                float v57; // [esp+48h] [ebp-64h]
                int v58; // [esp+4Ch] [ebp-60h]
                float v59; // [esp+5Ch] [ebp-50h]
                _E_struct_FMatrix thisMatrix; // [esp+6Ch] [ebp-40h] BYREF

                var r = this.Rotation;
                var v = FRotationMatrix( r );
                v7 = &v;
                v8 = sqrt(this.Velocity.Y * this.Velocity.Y + this.Velocity.X * this.Velocity.X);
                v9 = (float)(v7->M[0] * aForward) + (float)(v7->M[4] * aStrafe);
                v10 = (float)(v7->M[1] * aForward) + (float)(v7->M[5] * aStrafe);
                v11 = (float)(v7->M[2] * aForward) + (float)(v7->M[6] * aStrafe);
                v12 = (float)((float)(v11 * v11) + (float)(v10 * v10)) + (float)(v9 * v9);
                v56.X = v9;
                v56.Y = v10;
                v56.Z = v11;
                v55.X = v12;
                v57 = (float)v8;
                if ( v12 == 1.0f )
                {
                    v54 = v56;
                }
                else if ( v12 >= 0.0000000099999999f )
                {
                    v53 = 0.5f;
                    v13 = 1.0f / fsqrt(v55.X);
                    v56.X = (float)(3.0f - (float)((float)(v13 * v55.X) * v13)) * (float)(v13 * 0.5f);
                    v54.X = v56.X * v9;
                    v54.Y = v10 * v56.X;
                    v54.Z = v11 * v56.X;
                }
                else
                {
                    v54.X = 0.0f;
                    v54.Y = 0.0f;
                    v54.Z = 0.0f;
                }
                v55.X = 0.0f;
                v55.Y = 0.0f;
                v55.Z = 0.0f;
                if ( fabs(v54.X) < 0.000099999997f && fabs(v54.Y) < 0.000099999997f && fabs(v54.Z) < 0.000099999997f )
                {
                    result = vecOutput;
                    v15 = v55.Y;
                    vecOutput->X = v55.X;
                    v16 = v55.Z;
                    vecOutput->Y = v15;
                    this.SpeedSprintEnergy = 0.0f;
                    vecOutput->Z = v16;
                    return *result;
                }
                v17 = v57 - this.SpeedMaxBaseVelocity;
                this.SpeedSprintEnergy = v17;
                if ( v17 < 0.0f )
                    v17 = 0.0f;
                v52 = (float)v8;
                this.SpeedSprintEnergy = v17;
                v53 = 0.0f;
                v18 = E_sampleCurveMaybe(ref this.AccelCurve_LightWeapon, v52, /*COERCE_FLOAT(&*/v53/*)*/, 0.0f);
                v56.X = (float)(v54.X * v18);
                v55.X = v56.X;
                ptrToWeapon = this.MyWeapon;
                v56.Y = (float)(v54.Y * v18);
                v55.Y = v56.Y;
                v56.Z = (float)(v18 * v54.Z);
                v55.Z = v56.Z;
                if ( ptrToWeapon != null && ptrToWeapon.WeaponType == (EWeaponType)1 )
                {
                    v20 = v57;
                    //v21 = *((float *)this.AccelCurve_HeavyWeapon.Points.Data + 5 * this.AccelCurve_HeavyWeapon.Points.Count - 5);
                    fixed( void* ptrToData = & this.AccelCurve_HeavyWeapon.Points._items[ 0 ] )
                        v21 = *((float *)ptrToData + 5 * this.AccelCurve_HeavyWeapon.Points.Length - 5);

                    if ( v57 > v21 )
                    {
                        v22 = v54.Z;
                        v23 = v54.X;
                        v24 = v54.Y;
                        v54.Z = -0.0f - v54.Z;
                        v56.X = (float)(-0.0f - v54.X) * (float)(v57 - v21);
                        v56.Y = (float)(-0.0f - v54.Y) * (float)(v57 - v21);
                        v56.Z = v54.Z * (float)(v57 - v21);
                        v55 = v56;
                        goto LABEL_18;
                    }
                    v53 = 0.0f;
                    v25 = E_sampleCurveMaybe(ref this.AccelCurve_HeavyWeapon, v57, /*COERCE_FLOAT(&*/v53/*)*/, 0.0f);
                    v56.X = (float)(v54.X * v25);
                    v56.Y = (float)(v54.Y * v25);
                    v56.Z = (float)(v25 * v54.Z);
                    v55 = v56;
                }
                v20 = v57;
                v22 = v54.Z;
                v24 = v54.Y;
                v23 = v54.X;
            LABEL_18:
                if ( this.Physics == (EPhysics)2 )
                {
                    v45 = v55.Z;
                    v44 = v55.Y;
                    v43 = v55.X;
                    goto LABEL_33;
                }
                v26 = (float)(v24 * v20) - this.Velocity.Y;
                v27 = v22 * v20;
                v28 = (float)(v23 * v20) - this.Velocity.X;
                v29 = (float)(v26 * v26) + (float)(v28 * v28);
                v53 = v29;
                v30 = this.SpeedSprintVelocityAccelerationFactor;
                v31 = v27;
                v56.X = v28;
                v56.Y = v26;
                v56.Z = v27;
                v53 = (float)sqrt(v29);
                v32 = v30 * v53;
                if ( (float)(v53 / deltaTime) < v32 )
                    v33 = v53 / deltaTime;
                else
                    v33 = v32;
                v59 = (float)(v26 * v26) + (float)(v28 * v28);
                if ( v29 != 1.0f )
                {
                    if ( v29 < 0.0000000099999999f )
                    {
                        v34 = 0.0f;
                        v54.Y = 0.0f;
                        v54.Z = 0.0f;
            LABEL_30:
                        v54.X = v34;
                        goto LABEL_31;
                    }
                    v58 = 1077936128;
                    v53 = 0.5f;
                    v35 = 1.0f / fsqrt(v59);
                    v54.X = (float)(3.0f - (float)((float)(v35 * v59) * v35)) * (float)(v35 * 0.5f);
                    v26 = v26 * v54.X;
                    v34 = v54.X * v28;
            LABEL_29:
                    v54.Z = 0.0f;
                    v54.Y = v26;
                    v54.X = v34;
                    goto LABEL_31;
                }
                if ( v31 != 0.0f )
                {
                    v34 = v28;
                    v54.Z = 0.0f;
                    v54.Y = v26;
                    v54.X = v34;
                    goto LABEL_31;
                }
                v54 = v56;
                v34 = v56.X;
            LABEL_31:
                v36 = this.Velocity.Y;
                v37 = this.Velocity.Z;
                v38 = (float)(v34 * v33) + v55.X;
                v56.X = v54.X;
                v39 = this.PhysicsVolume.GroundFriction;
                v56.Y = v54.Y;
                v56.Z = v54.Z;
                v40 = (float)(v54.Y * v33) + v55.Y;
                v41 = (float)(v54.Z * v33) + v55.Z;
                v42 = (float)(v37 * v39) * 0.1f;
                v43 = (float)((float)(v39 * this.Velocity.X) * 0.1f) + v38;
                v44 = (float)((float)(v36 * v39) * 0.1f) + v40;
                v45 = v42 + v41;
            LABEL_33:
                v46 = this.SpeedTurnDecelerationFactor;
                v47 = this.Velocity.Y;
                v48 = this.Velocity.Z;
                v49 = this.Velocity.X * v46;
                v53 = (float)fabs(DeltaRotation);
                v55.X = (float)(v43 - (float)((float)(v49 * v53) * 0.000030517578f)) * 10.0f;
                v55.Y = (float)(v44 - (float)((float)((float)(v47 * v46) * v53) * 0.000030517578f)) * 10.0f;
                v55.Z = (float)(v45 - (float)((float)((float)(v48 * v46) * v53) * 0.000030517578f)) * 10.0f;
                v55.X = (float)floor(v55.X + 0.5f);
                v55.Y = (float)floor(v55.Y + 0.5f);
                v50 = floor(v55.Z + 0.5f);
                result = vecOutput;
                v55.X = v55.X * 0.1f;
                v51 = v55.Y;
                vecOutput->X = v55.X;
                v55.Y = (float)(v51 * 0.1f);
                vecOutput->Y = v55.Y;
                v55.Z = (float)(v50 * 0.1f);
                vecOutput->Z = v55.Z;
                return *result;
            }
        }
        
        static unsafe double E_sampleCurveMaybe(ref _E_struct_FInterpCurveFloat _this, float currentTMaybe, float a3, float a4)
        {
            NativeMarkers.MarkUnimplemented();
            // There's a fair amount of weird stuff going on here, do not fully trust this method
            // All assign to a4 have been removed
            
             
            int v4; // edx
            double result; // st7
            _E_struct_FInterpCurvePointFloat *v6; // edi
            int v7; // ebx
            int v8; // eax
            float *i; // esi
            int v10; // edx
            float v11; // xmm2_4
            float v12; // xmm1_4
            _E_struct_FInterpCurvePointFloat *v13; // eax

            v4 = _this.Points.Length;
            if ( v4 != 0 )
            {
            fixed( _E_struct_FInterpCurvePointFloat* _this_Data = & _this.Points._items[ 0 ] )
            {
                // Moved out of the if
                v6 = _this_Data;
                if ( v4 < 2 || (/*v6 = _this_Data,*/ _this_Data->InVal >= currentTMaybe) )
                {
                    /*if ( a4 != 0.0 )
                        *(_DWORD *)LODWORD(a4) = 0;*/
                    result = _this_Data->OutVal;
                }
                else
                {
                    v7 = v4;
                    if ( currentTMaybe < v6[v4 - 1].InVal )
                    {
                        v8 = 1;
                        for ( i = &v6[1].InVal; *i <= currentTMaybe; i += 5 )
                        {
                            if ( ++v8 >= v4 )
                            {
                                /*if ( a4 != 0.0 )
                                    *(_DWORD *)LODWORD(a4) = v4 - 1;*/
                                return _this_Data[v7 - 1].OutVal;
                            }
                        }
                        v10 = v8;
                        v11 = v6[v8 - 1].InVal;
                        v12 = v6[v8].InVal - v11;
                        if ( v12 <= 0.0 || v6[v10 - 1].InterpMode == (EInterpCurveMode)2 )
                        {
                            /*if ( a4 != 0.0 )
                                *(_DWORD *)LODWORD(a4) = v8 - 1;*/
                            result = _this_Data[v10 - 1].OutVal;
                        }
                        else
                        {
                            a3 = (float)(currentTMaybe - v11) / v12;
                            /*if ( a4 != 0.0 )
                                *(_DWORD *)LODWORD(a4) = v8 - 1;*/
                            v13 = &_this_Data[v10];
                            if ( v13[-1].InterpMode != 0 )
                            {
                                if ( _this.InterpMethod == (EInterpMethodType)1 )
                                {
                                    result = E_someKindOfInterpolation(&v13[-1].OutVal, &v13[-1].LeaveTangent, &v13->OutVal, &v13->ArriveTangent, &a3);
                                }
                                else
                                {
                                    a4 = v13->ArriveTangent * v12;
                                    currentTMaybe = v13[-1].LeaveTangent * v12;
                                    result = E_someKindOfInterpolation(&v13[-1].OutVal, &currentTMaybe, &v13->OutVal, &a4, &a3);
                                }
                            }
                            else
                            {
                                result = v13[-1].OutVal + (v13->OutVal - v13[-1].OutVal) * a3;
                            }
                        }
                    }
                    else
                    {
                        /*if( a4 != 0.0 )
                            *(_DWORD *)LODWORD(a4) = v4 - 1;*/
                        result = _this_Data[v7 - 1].OutVal;
                    }
                }
            }
            }
            else
            {
                /* not too sure what's going on here
                if ( a4 != 0.0 )
                    *(_DWORD *)LODWORD(a4) = -1;
                result = *(float *)LODWORD(a3);
                */// Replaced with this
                result = a3;
            }
            return result;
        }
        
        static unsafe double E_someKindOfInterpolation(float *a1, float *a2, float *a3, float *a4, float *a5)
        {
            float v5; // xmm0_4
            float v7; // [esp+0h] [ebp-Ch]

            v5 = *a5;
            v7 = v5 * (float)(v5 * v5);
            return (v7 - (float)(v5 * v5) * 2.0 + *a5) * *a2 + (2.0 * v7 - (float)((float)(v5 * v5) * 3.0) + 1.0) * *a1 + ((float)((float)(v5 * v5) * 3.0) + v7 * -2.0) * *a3 + (v7 - (float)(v5 * v5)) * *a4;
        }
        
        
        
        public virtual /*native function */float GetAverageSpeed(float Time)
        {
            NativeMarkers.MarkUnimplemented();
            #warning need to populate those arrays before this works, have a dummy return for now
            return Velocity.Size();
            
            float paramFloat = Time;
            
            float v2; // xmm2_4
            float v3; // xmm3_4
            float v4; // xmm1_4
            float v5; // xmm0_4
            int v6; // ebx
            int v7; // edx
            double result; // st7
            int v9; // eax
            int v10; // eax
            array<float> v11; // esi
            array<float> v12; // edi
            int v13; // ebp
            int v14; // eax
            int v15; // edx
            int v16; // ecx
            float v17; // xmm2_4
            float v18; // xmm4_4
            int v19; // ecx
            float v20; // xmm1_4
            float v21; // xmm3_4
            int v22; // ecx
            int v23; // ebx
            float v24; // xmm0_4
            int v25; // esi
            int v26; // edi
            int v27; // ecx
            int v28; // edx
            int v29; // eax
            int v30; // [esp+0h] [ebp-20h]
            int v31; // [esp+4h] [ebp-1Ch]
            int v32; // [esp+Ch] [ebp-14h]
            int v33; // [esp+10h] [ebp-10h]
            TdPawn v34; // [esp+14h] [ebp-Ch]
            int v35; // [esp+18h] [ebp-8h]
            int v36; // [esp+1Ch] [ebp-4h]
            array<float> asDistanceData; // [esp+1Ch] [ebp-4h]
            int paramFloata; // [esp+24h] [ebp+4h]
            array<float> asTimeData; // [esp+24h] [ebp+4h]

            v2 = this.ASFilterTime;
            v3 = paramFloat;
            v34 = this;
            v4 = 0.0f;
            v5 = 0.0f;
            if ( paramFloat >= v2 )
                v3 = this.ASFilterTime;
            v6 = this.ASPollSlots;
            v7 = (int)(float)((float)((float)v6 * v3) / v2);
            paramFloata = v6;
            v35 = v7;
            if ( v7 <= 0 )
                return 0.0f;
            v9 = 0;
            if ( v7 >= 4 )
            {
                v10 = this.ASSlotPointer;
                v11 = this.ASTimeData;
                v12 = this.ASDistanceData;
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
                        v16 += 4 * v6;
                    v17 = v11[v16 / 4] + v4;
                    v18 = v12[v16 / 4] + v5;
                    v19 = v14 + 4;
                    if ( v13 + v32 < 0 )
                        v19 += 4 * paramFloata;
                    v20 = v11[v19 / 4] + v17;
                    v21 = v12[v19 / 4] + v18;
                    v22 = v14;
                    if ( v31 < 0 )
                        v22 = v14 + 4 * paramFloata;
                    v23 = v14 - 4;
                    if ( v13 + v33 < 0 )
                        v23 += 4 * paramFloata;
                    v30 -= 4;
                    v31 -= 4;
                    v4 = v11[v23 / 4] + (v11[v22 / 4] + v20);
                    v24 = v12[v23 / 4];
                    v6 = paramFloata;
                    v14 -= 16;
                    v13 -= 4;
                    --v15;
                    v5 = v24 + v12[v22 / 4] + v21;
                }
                while ( v15>0 );
                v7 = v35;
                v9 = v36;
            }
            if ( v9 < v7 )
            {
                asTimeData = this.ASTimeData;
                asDistanceData = this.ASDistanceData;
                v25 = this.ASSlotPointer - v9;
                v26 = v25 + v6;
                v27 = 4 * v25;
                v28 = v7 - v9;
                do
                {
                    v29 = v27;
                    if ( v25 < 0 )
                        v29 = v27 + 4 * v6;
                    v4 = asTimeData[v29 / 4] + v4;
                    v27 -= 4;
                    --v25;
                    --v26;
                    --v28;
                    v5 = asDistanceData[v29 / 4] + v5;
                }
                while ( v28 > 0 );
            }

            if( v5 == 0.0f )
                return 0f;
            else
                return (v5 / v4);
        }
	}
}