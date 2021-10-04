namespace MEdge.TdGame
{
  public partial class TdMove_Grab
  {
    public virtual /*native simulated function */bool IsHangingFree()
    {
      int result; // eax
  
      result = 1;
      if ( this.GrabType != EGrabType.GT_LegsFree || this.bSlopedLedge )// 4 => bSlopedLedge
        return false;
      return true;
    }
    #region src
/*
int __thiscall UTdMove_Grab::IsHangingFree(_E_struct_UTdMove_Grab *this)
{
  int result; // eax

  result = 1;
  if ( this->GrabType != GT_LegsFree || (this->bitfield_bIsWithinForwardView_And7More & 4) != 0 )// 4 => bSlopedLedge
    return 0;
  return result;
}*/
    #endregion
  }
  public partial class TdMove
  {
    public virtual TdPawn.MoveAimMode GetAimMode( bool aimingOnly )
    {
      TdPawn PawnOwner; // eax
      TdPawn PawnOwner2; // ecx
      //Controller  Controller; // eax
      int pitchDiff; // edx
      int yawDiff; // edx
      int rollDiff; // eax
      int Yaw; // eax
      int someKindOfAimRange; // ecx
      Rotator rotDiff; // [esp+4h] [ebp-18h] BYREF
      Rotator a5; // [esp+10h] [ebp-Ch] BYREF

      if( aimingOnly == false )
        return this.AimMode;
      PawnOwner = this.PawnOwner;
      if( ! PawnOwner.Controller )
        return this.AimMode;
      PawnOwner2 = this.PawnOwner;

      pitchDiff = PawnOwner.Controller.Rotation.Pitch - PawnOwner2.Rotation.Pitch;
      var Controller = PawnOwner.Controller.Rotation;
      rotDiff.Pitch = pitchDiff;
      yawDiff = Controller.Yaw - PawnOwner2.Rotation.Yaw;
      rollDiff = Controller.Roll - PawnOwner2.Rotation.Roll;
      rotDiff.Yaw = yawDiff;
      rotDiff.Roll = rollDiff;
      Yaw = E_ClipAmountOfTurns( rotDiff ).Yaw;
      // !the cast here is a bit weird; this method is defined inside 'TdMove' but looking at the source the logic below
      // would fetch a field outside/undefined within 'TdMove', the only class that actually calls this method is TdMove_Climb
      // so it *seems* safe that this is expected behavior.
      someKindOfAimRange = ( this as TdMove_Climb ).StartTurningAngle;
      if( Yaw > someKindOfAimRange )
        return TdPawn.MoveAimMode.MAM_Right;
      if( Yaw < - someKindOfAimRange )
        return 0;
      else
        return this.AimMode;
    }



    static Rotator E_ClipAmountOfTurns( Rotator a )
    {
      uint p = (ushort) a.Pitch;
      if( p > 32767 )
        p -= 65536;
      a.Pitch = (int) p;
      uint y = (ushort) a.Yaw;
      if( y > 32767 )
        y -= 65536;
      a.Yaw = (int) y;
      uint r = (ushort) a.Roll;
      if( r > 32767 )
        r -= 65536;
      a.Roll = (int) r;
      return a;
    }
      #region src
/*
char __thiscall UTdMove::GetAimMode(_E_struct_UTdMove_Climb *this, int aimingOnly)
{
  _E_struct_ATdPawn *__ptr32 PawnOwner; // eax
  _E_struct_ATdPawn *__ptr32 PawnOwner2; // ecx
  _E_struct_AController *__ptr32 Controller; // eax
  unsigned int pitchDiff; // edx
  unsigned int yawDiff; // edx
  unsigned int rollDiff; // eax
  signed int Yaw; // eax
  int someKindOfAimRange; // ecx
  _E_struct_FRotator rotDiff; // [esp+4h] [ebp-18h] BYREF
  _E_struct_FRotator a5; // [esp+10h] [ebp-Ch] BYREF

  if ( !aimingOnly )
    return this->AimMode;
  PawnOwner = this->PawnOwner;
  if ( !PawnOwner->Controller )
    return this->AimMode;
  PawnOwner2 = this->PawnOwner;
  Controller = PawnOwner->Controller;
  pitchDiff = Controller->Rotation.Pitch - PawnOwner2->Rotation.Pitch;
  Controller = (_E_struct_AController *__ptr32)((char *)Controller + 244);// Controller ptr to Controller.Rotation.Pitch ptr
  rotDiff.Pitch = pitchDiff;
  yawDiff = Controller->ObjectInternalInteger - PawnOwner2->Rotation.Yaw;
  rollDiff = Controller->ObjectFlags_A - PawnOwner2->Rotation.Roll;
  rotDiff.Yaw = yawDiff;
  rotDiff.Roll = rollDiff;
  Yaw = E_ClipAmountOfTurns(&rotDiff, &a5)->Yaw;
  someKindOfAimRange = this->StartTurningAngle;
  if ( Yaw > someKindOfAimRange )
    return 1;
  if ( Yaw < -someKindOfAimRange )
    return 0;
  else
    return this->AimMode;
}*/
#endregion
	}
}