// NO OVERWRITE

namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPlayerMoveManager : TdMoveManager/* within TdPawn*/{
	public new TdPawn Outer => base.Outer as TdPawn;
	
	public override /*simulated function */void HandleMoveAction(TdPawn.EMovementAction Action)
	{
		/*local */TdPawn.EMovement PrevState = default;
	
		PrevState = ((TdPawn.EMovement)Outer.MovementState);
		Outer.Moves[((int)Outer.MovementState)].HandleMoveAction(((TdPawn.EMovementAction)Action));
		if(((int)PrevState) != ((int)Outer.MovementState))
		{
			return;
		}
		switch(Outer.MovementState)
		{
			case TdPawn.EMovement.MOVE_Vertigo/*47*/:
			case TdPawn.EMovement.MOVE_Walking/*1*/:
			case TdPawn.EMovement.MOVE_180Turn/*24*/:
				if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Jump/*1*/))
				{
					Outer.bFoundLedge = Outer.Moves[((int)Outer.MovementState)].FindLedgeInFrontOfPlayer(ref/*probably?*/ Outer.MoveLedgeLocation, ref/*probably?*/ Outer.MoveLedgeNormal, ref/*probably?*/ Outer.MoveNormal);
					if(Outer.Moves[33].CanDoMove())
					{
						Outer.SetMove(TdPawn.EMovement.MOVE_DodgeJump/*33*/, default, default);					
					}
					else
					{
						if(Outer.Moves[7].CanDoMove())
						{
							Outer.SetMove(TdPawn.EMovement.MOVE_SpringBoarding/*7*/, default, default);						
						}
						else
						{
							if(Outer.Moves[11].CanDoMove())
							{
								Outer.SetMove(TdPawn.EMovement.MOVE_Jump/*11*/, default, default);
							}
						}
					}				
				}
				else
				{
					if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Crouch/*5*/))
					{
						if(Outer.Moves[16].CanDoMove())
						{
							Outer.SetMove(TdPawn.EMovement.MOVE_Slide/*16*/, default, default);						
						}
						else
						{
							if(Outer.Moves[15].CanDoMove())
							{
								Outer.SetMove(TdPawn.EMovement.MOVE_Crouch/*15*/, default, default);
							}
						}					
					}
					else
					{
						if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Melee/*3*/))
						{
							if(Outer.Moves[19].CanDoMove())
							{
								Outer.SetMove(TdPawn.EMovement.MOVE_Barge/*19*/, default, default);							
							}
							else
							{
								if(Outer.Moves[17].CanDoMove())
								{
									Outer.SetMove(TdPawn.EMovement.MOVE_Melee/*17*/, default, default);
								}
							}						
						}
						else
						{
							if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Snatch/*4*/))
							{
								if(Outer.Moves[18].CanDoMove())
								{
									Outer.SetMove(TdPawn.EMovement.MOVE_Snatch/*18*/, default, default);
								}							
							}
							else
							{
								if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Turn/*16*/))
								{
									if(Outer.Moves[24].CanDoMove())
									{
										Outer.SetMove(TdPawn.EMovement.MOVE_180Turn/*24*/, default, default);
									}								
								}
								else
								{
									if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Stumble/*17*/))
									{
										if(Outer.Moves[35].CanDoMove())
										{
											Outer.SetMove(TdPawn.EMovement.MOVE_Stumble/*35*/, default, default);
										}									
									}
									else
									{
										if(((int)Action) == ((int)TdPawn.EMovementAction.MA_StumbleHard/*18*/))
										{
											if(Outer.Moves[55].CanDoMove())
											{
												Outer.SetMove(TdPawn.EMovement.MOVE_StumbleHard/*55*/, default, default);
											}
										}
									}
								}
							}
						}
					}
				}
				break;
			case TdPawn.EMovement.MOVE_180TurnInAir/*25*/:
				if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Turn/*16*/))
				{
					if(Outer.Moves[24].CanDoMove())
					{
						Outer.SetMove(TdPawn.EMovement.MOVE_180Turn/*24*/, default, default);
					}
				}
				break;
			case TdPawn.EMovement.MOVE_SpringBoarding/*7*/:
				if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Crouch/*5*/))
				{
					if(Outer.Moves[61].CanDoMove())
					{
						Outer.SetMove(TdPawn.EMovement.MOVE_Coil/*61*/, default, default);
					}
				}
				break;
			case TdPawn.EMovement.MOVE_IntoGrab/*14*/:
			case TdPawn.EMovement.MOVE_Jump/*11*/:
			case TdPawn.EMovement.MOVE_WallRunJump/*12*/:
			case TdPawn.EMovement.MOVE_GrabJump/*13*/:
			case TdPawn.EMovement.MOVE_SwingJump/*73*/:
			case TdPawn.EMovement.MOVE_WallClimb180TurnJump/*50*/:
			case TdPawn.EMovement.MOVE_Falling/*2*/:
				if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Crouch/*5*/))
				{
					if(Outer.Moves[61].CanDoMove())
					{
						Outer.SetMove(TdPawn.EMovement.MOVE_Coil/*61*/, default, default);
					}				
				}
				else
				{
					if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Jump/*1*/))
					{
						if(Outer.Moves[23].CanDoMove())
						{
							Outer.SetMove(TdPawn.EMovement.MOVE_WallKick/*23*/, default, default);
						}					
					}
					else
					{
						if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Melee/*3*/))
						{
							if(Outer.Moves[85].CanDoMove())
							{
								Outer.SetMove(TdPawn.EMovement.MOVE_AirBarge/*85*/, default, default);							
							}
							else
							{
								if(Outer.Moves[32].CanDoMove())
								{
									Outer.SetMove(TdPawn.EMovement.MOVE_MeleeAir/*32*/, default, default);
								}
							}						
						}
						else
						{
							if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Turn/*16*/))
							{
								if(Outer.Moves[25].CanDoMove())
								{
									Outer.SetMove(TdPawn.EMovement.MOVE_180TurnInAir/*25*/, default, default);
								}							
							}
							else
							{
								if((((int)Action) == ((int)TdPawn.EMovementAction.MA_Stumble/*17*/)) || ((int)Action) == ((int)TdPawn.EMovementAction.MA_StumbleHard/*18*/))
								{
									if(Outer.Moves[35].CanDoMove())
									{
										if(((Outer.Moves[35]) as TdMove_Stumble) != default)
										{
											((Outer.Moves[35]) as TdMove_Stumble).bInAir = true;
										}
										Outer.SetMove(TdPawn.EMovement.MOVE_Stumble/*35*/, default, default);
									}
								}
							}
						}
					}
				}
				break;
			case TdPawn.EMovement.MOVE_Slide/*16*/:
				if(((int)Action) == ((int)TdPawn.EMovementAction.MA_StopCrouch/*6*/))
				{
					if(Outer.Moves[16].CanStopMove())
					{
						if(Outer.Moves[1].CanDoMove())
						{
							Outer.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default, default);						
						}
						else
						{
							if(Outer.Moves[15].CanDoMove())
							{
								Outer.SetMove(TdPawn.EMovement.MOVE_Crouch/*15*/, default, default);
							}
						}
					}				
				}
				else
				{
					if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Melee/*3*/))
					{
						if(Outer.Moves[48].CanDoMove())
						{
							Outer.SetMove(TdPawn.EMovement.MOVE_MeleeSlide/*48*/, default, default);
						}
					}
				}
				break;
			case TdPawn.EMovement.MOVE_RumpSlide/*38*/:
				if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Jump/*1*/))
				{
					if(Outer.Moves[11].CanDoMove())
					{
						Outer.SetMove(TdPawn.EMovement.MOVE_Jump/*11*/, default, default);
					}
				}
				break;
			case TdPawn.EMovement.MOVE_Crouch/*15*/:
				if(((int)Action) == ((int)TdPawn.EMovementAction.MA_StopCrouch/*6*/))
				{
					if(((int)Outer.Physics) == ((int)Actor.EPhysics.PHYS_Falling/*2*/))
					{
						if(Outer.Moves[2].CanDoMove())
						{
							Outer.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default, default);
						}					
					}
					else
					{
						if(Outer.Moves[1].CanDoMove())
						{
							Outer.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default, default);
						}
					}				
				}
				else
				{
					if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Melee/*3*/))
					{
						if(Outer.Moves[63].CanDoMove())
						{
							Outer.SetMove(TdPawn.EMovement.MOVE_MeleeCrouch/*63*/, default, default);
						}					
					}
					else
					{
						if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Stumble/*17*/))
						{
							if(Outer.Moves[35].CanDoMove())
							{
								Outer.SetMove(TdPawn.EMovement.MOVE_Stumble/*35*/, default, default);
							}						
						}
						else
						{
							if(((int)Action) == ((int)TdPawn.EMovementAction.MA_StumbleHard/*18*/))
							{
								if(Outer.Moves[55].CanDoMove())
								{
									Outer.SetMove(TdPawn.EMovement.MOVE_StumbleHard/*55*/, default, default);
								}
							}
						}
					}
				}
				break;
			#warning Duplicate definition, requires in-game testing to confirm which one is the right one
			//case TdPawn.EMovement.MOVE_MeleeCrouch/*63*/:
			//case TdPawn.EMovement.MOVE_MeleeCrouch/*63*/:
			//	if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Stumble/*17*/))
			//	{
			//		if(Outer.Moves[35].CanDoMove())
			//		{
			//			Outer.SetMove(TdPawn.EMovement.MOVE_Stumble/*35*/, default, default);
			//		}
			//	}
			//	break;
			case TdPawn.EMovement.MOVE_Grabbing/*3*/:
				if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Jump/*1*/))
				{
					if(Outer.Moves[31].CanDoMove())
					{
						Outer.SetMove(TdPawn.EMovement.MOVE_GrabTransfer/*31*/, default, default);					
					}
					else
					{
						if(Outer.Moves[10].CanDoMove())
						{
							Outer.SetMove(TdPawn.EMovement.MOVE_GrabPullUp/*10*/, default, default);						
						}
						else
						{
							if(Outer.Moves[13].CanDoMove())
							{
								Outer.SetMove(TdPawn.EMovement.MOVE_GrabJump/*13*/, default, default);
							}
						}
					}				
				}
				else
				{
					if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Crouch/*5*/))
					{
						((Outer.Moves[3]) as TdMove_Grab).RequestDropDown();					
					}
					else
					{
						if(((int)Action) == ((int)TdPawn.EMovementAction.MA_ClimbUpLong/*9*/))
						{
							if(Outer.Moves[10].CanDoMove())
							{
								Outer.SetMove(TdPawn.EMovement.MOVE_GrabPullUp/*10*/, default, default);
							}
						}
					}
				}
				break;
			case TdPawn.EMovement.MOVE_Climb/*21*/:
				if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Jump/*1*/))
				{
					if(Outer.Moves[31].CanDoMove())
					{
						Outer.SetMove(TdPawn.EMovement.MOVE_GrabTransfer/*31*/, default, default);					
					}
					else
					{
						if(Outer.Moves[13].CanDoMove())
						{
							Outer.SetMove(TdPawn.EMovement.MOVE_GrabJump/*13*/, default, default);
						}
					}
				}
				break;
			case TdPawn.EMovement.MOVE_WallRunningLeft/*5*/:
			case TdPawn.EMovement.MOVE_WallRunningRight/*4*/:
				if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Jump/*1*/))
				{
					if(Outer.Moves[34].CanDoMove())
					{
						Outer.SetMove(TdPawn.EMovement.MOVE_WallRunDodgeJump/*34*/, default, default);					
					}
					else
					{
						if(Outer.Moves[12].CanDoMove())
						{
							Outer.SetMove(TdPawn.EMovement.MOVE_WallRunJump/*12*/, default, default);
						}
					}				
				}
				else
				{
					if((((int)Action) == ((int)TdPawn.EMovementAction.MA_ClimbDown/*8*/)) || ((int)Action) == ((int)TdPawn.EMovementAction.MA_Crouch/*5*/))
					{
						if(Outer.Moves[2].CanDoMove())
						{
							Outer.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default, default);
						}					
					}
					else
					{
						if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Melee/*3*/))
						{
							if(Outer.Moves[62].CanDoMove())
							{
								Outer.SetMove(TdPawn.EMovement.MOVE_MeleeWallrun/*62*/, default, default);
							}
						}
					}
				}
				break;
			case TdPawn.EMovement.MOVE_WallClimbing/*6*/:
				if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Jump/*1*/))
				{
					if(Outer.Moves[49].CanDoMove())
					{
						Outer.SetMove(TdPawn.EMovement.MOVE_WallClimbDodgeJump/*49*/, default, default);
					}				
				}
				else
				{
					if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Turn/*16*/))
					{
						if(Outer.Moves[50].CanDoMove())
						{
							Outer.SetMove(TdPawn.EMovement.MOVE_WallClimb180TurnJump/*50*/, default, default);
						}
					}
				}
				break;
			case TdPawn.EMovement.MOVE_ZipLine/*28*/:
				if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Crouch/*5*/))
				{
					if(Outer.Moves[2].CanDoMove())
					{
						Outer.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default, default);
					}
				}
				break;
			case TdPawn.EMovement.MOVE_Stumble/*35*/:
				if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Stumble/*17*/))
				{
					if(Outer.Moves[35].CanDoMove())
					{
						Outer.Moves[35].StartMove();
					}				
				}
				else
				{
					if(((int)Action) == ((int)TdPawn.EMovementAction.MA_StumbleHard/*18*/))
					{
						if(Outer.Moves[55].CanDoMove())
						{
							Outer.SetMove(TdPawn.EMovement.MOVE_StumbleHard/*55*/, default, default);
						}
					}
				}
				break;
			case TdPawn.EMovement.MOVE_Melee/*17*/:
				if((((int)Action) == ((int)TdPawn.EMovementAction.MA_Snatch/*4*/)) && Outer.Moves[18].CanDoMove())
				{
					Outer.SetMove(TdPawn.EMovement.MOVE_Snatch/*18*/, default, default);				
				}
				else
				{
					if((((int)Action) == ((int)TdPawn.EMovementAction.MA_Stumble/*17*/)) && Outer.Moves[35].CanDoMove())
					{
						Outer.SetMove(TdPawn.EMovement.MOVE_Stumble/*35*/, default, default);					
					}
					else
					{
						if((((int)Action) == ((int)TdPawn.EMovementAction.MA_StumbleHard/*18*/)) && Outer.Moves[55].CanDoMove())
						{
							Outer.SetMove(TdPawn.EMovement.MOVE_StumbleHard/*55*/, default, default);
						}
					}
				}
				break;
			case TdPawn.EMovement.MOVE_MeleeAir/*32*/:
			case TdPawn.EMovement.MOVE_MeleeCrouch/*63*/:
				if((((int)Action) == ((int)TdPawn.EMovementAction.MA_Stumble/*17*/)) && Outer.Moves[35].CanDoMove())
				{
					Outer.SetMove(TdPawn.EMovement.MOVE_Stumble/*35*/, default, default);				
				}
				else
				{
					if((((int)Action) == ((int)TdPawn.EMovementAction.MA_StumbleHard/*18*/)) && Outer.Moves[55].CanDoMove())
					{
						Outer.SetMove(TdPawn.EMovement.MOVE_StumbleHard/*55*/, default, default);
					}
				}
				break;
			case TdPawn.EMovement.MOVE_Snatch/*18*/:
				if(((int)((Outer.Moves[18]) as TdMOVE_Disarm).DisarmState) == ((int)TdAIController.EDisarmState.DS_Miss/*1*/))
				{
					if((((int)Action) == ((int)TdPawn.EMovementAction.MA_Stumble/*17*/)) && Outer.Moves[35].CanDoMove())
					{
						Outer.SetMove(TdPawn.EMovement.MOVE_Stumble/*35*/, default, default);					
					}
					else
					{
						if((((int)Action) == ((int)TdPawn.EMovementAction.MA_StumbleHard/*18*/)) && Outer.Moves[55].CanDoMove())
						{
							Outer.SetMove(TdPawn.EMovement.MOVE_StumbleHard/*55*/, default, default);
						}
					}
				}
				break;
			case TdPawn.EMovement.MOVE_DodgeJump/*33*/:
				if(((int)Action) == ((int)TdPawn.EMovementAction.MA_Stumble/*17*/))
				{
					if(Outer.Moves[35].CanDoMove())
					{
						if(((Outer.Moves[35]) as TdMove_Stumble) != default)
						{
							((Outer.Moves[35]) as TdMove_Stumble).bInAir = true;
						}
						Outer.SetMove(TdPawn.EMovement.MOVE_Stumble/*35*/, default, default);
					}
				}
				break;
			default:
				break;
		}
	}
	
}
}