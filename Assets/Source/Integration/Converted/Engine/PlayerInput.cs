// NO OVERWRITE

namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PlayerInput : Input/* within PlayerController*//*
		transient
		native
		config(Input)
		hidecategories(Object,UIRoot)*/{
	public new PlayerController Outer => base.Outer as PlayerController;
	
	public /*const */bool bUsingGamepad;
	public /*globalconfig */bool bInvertMouse;
	public /*globalconfig */bool bInvertTurn;
	public bool bWasForward;
	public bool bWasBack;
	public bool bWasLeft;
	public bool bWasRight;
	public bool bEdgeForward;
	public bool bEdgeBack;
	public bool bEdgeLeft;
	public bool bEdgeRight;
	public /*globalconfig */bool bEnableMouseSmoothing;
	public bool bEnableFOVScaling;
	public /*const */name LastAxisKeyName;
	public float DoubleClickTimer;
	public /*globalconfig */float DoubleClickTime;
	public /*globalconfig */float MouseSensitivity;
	public /*input */float aBaseX;
	public /*input */float aBaseY;
	public /*input */float aBaseZ;
	public /*input */float aMouseX;
	public /*input */float aMouseY;
	public /*input */float aForward;
	public /*input */float aTurn;
	public /*input */float aStrafe;
	public /*input */float aUp;
	public /*input */float aLookUp;
	public /*input */float aPS3AccelX;
	public /*input */float aPS3AccelY;
	public /*input */float aPS3AccelZ;
	public /*input */float aPS3Gyro;
	public /*transient */float RawJoyUp;
	public /*transient */float RawJoyRight;
	public /*transient */float RawJoyLookRight;
	public /*transient */float RawJoyLookUp;
	public/*()*/ /*config */float MoveForwardSpeed;
	public/*()*/ /*config */float MoveStrafeSpeed;
	public/*()*/ /*config */float LookRightScale;
	public/*()*/ /*config */float LookUpScale;
	public /*input */byte bStrafe;
	public /*input */byte bXAxis;
	public /*input */byte bYAxis;
	public StaticArray<float, float>/*[2]*/ ZeroTime;
	public StaticArray<float, float>/*[2]*/ SmoothedMouse;
	public int MouseSamples;
	public float MouseSamplingTotal;
	
	public virtual /*exec function */bool InvertMouse()
	{
		bInvertMouse = !bInvertMouse;
		SaveConfig();
		return bInvertMouse;
	}
	
	public virtual /*exec function */bool InvertTurn()
	{
		bInvertTurn = !bInvertTurn;
		SaveConfig();
		return bInvertTurn;
	}
	
	public virtual /*exec function */void SetSensitivity(float F)
	{
		MouseSensitivity = F;
	}
	
	public virtual /*function */void DrawHUD(HUD H)
	{
	
	}
	
	public virtual /*function */void PreProcessInput(float DeltaTime)
	{
	
	}
	
	public virtual /*function */void PostProcessInput(float DeltaTime)
	{
	
	}
	
	public virtual /*function */void AdjustMouseSensitivity(float FOVScale)
	{
		aMouseX *= (MouseSensitivity * FOVScale);
		aMouseY *= (MouseSensitivity * FOVScale);
	}
	
	public virtual /*event */void PlayerInput_(float DeltaTime)
	{
		// Initially 'PlayerInput', renamed to 'PlayerInput_' as c#'s naming scheme doesn't allow members with the same name as their class
		
		/*local */float FOVScale = default, TimeScale = default;
	
		RawJoyUp = aBaseY;
		RawJoyRight = aStrafe;
		RawJoyLookRight = aTurn;
		RawJoyLookUp = aLookUp;
		DeltaTime /= Outer.WorldInfo.TimeDilation;
		if(Outer.bDemoOwner && ((int)Outer.WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_Client/*3*/))
		{
			DeltaTime /= Outer.WorldInfo.DemoPlayTimeDilation;
		}
		PreProcessInput(DeltaTime);
		TimeScale = 100.0f * DeltaTime;
		aBaseY *= (TimeScale * MoveForwardSpeed);
		aStrafe *= (TimeScale * MoveStrafeSpeed);
		aUp *= (TimeScale * MoveStrafeSpeed);
		aTurn *= (TimeScale * LookRightScale);
		aLookUp *= (TimeScale * LookUpScale);
		PostProcessInput(DeltaTime);
		ProcessInputMatching(DeltaTime);
		CatchDoubleClickInput();
		if(bEnableFOVScaling)
		{
			FOVScale = Outer.GetFOVAngle() * 0.011110f;		
		}
		else
		{
			FOVScale = 1.0f;
		}
		AdjustMouseSensitivity(FOVScale);
		if(bEnableMouseSmoothing)
		{
			aMouseX = SmoothMouse(aMouseX, DeltaTime, ref/*probably?*/ bXAxis, 0);
			aMouseY = SmoothMouse(aMouseY, DeltaTime, ref/*probably?*/ bYAxis, 1);
		}
		aLookUp *= FOVScale;
		aTurn *= FOVScale;
		if(((int)bStrafe) > ((int)0))
		{
			aStrafe += (aBaseX + aMouseX);		
		}
		else
		{
			aTurn += (aBaseX + aMouseX);
		}
		aLookUp += aMouseY;
		if(bInvertMouse)
		{
			aLookUp *= -1.0f;
		}
		if(bInvertTurn)
		{
			aTurn *= -1.0f;
		}
		aForward += aBaseY;
		Outer.HandleWalking();
		if(Outer.IsMoveInputIgnored())
		{
			aForward = 0.0f;
			aStrafe = 0.0f;
			aUp = 0.0f;
		}
		if(Outer.IsLookInputIgnored())
		{
			aTurn = 0.0f;
			aLookUp = 0.0f;
		}
	}
	
	public virtual /*function */void CatchDoubleClickInput()
	{
		if(!Outer.IsMoveInputIgnored())
		{
			bEdgeForward = bWasForward ^ (aBaseY > ((float)(0)));
			bEdgeBack = bWasBack ^ (aBaseY < ((float)(0)));
			bEdgeLeft = bWasLeft ^ (aStrafe < ((float)(0)));
			bEdgeRight = bWasRight ^ (aStrafe > ((float)(0)));
			bWasForward = aBaseY > ((float)(0));
			bWasBack = aBaseY < ((float)(0));
			bWasLeft = aStrafe < ((float)(0));
			bWasRight = aStrafe > ((float)(0));
		}
	}
	
	public virtual /*function */Actor.EDoubleClickDir CheckForDoubleClickMove(float DeltaTime)
	{
		/*local */Actor.EDoubleClickDir DoubleClickMove = default, OldDoubleClick = default;
	
		if(((int)Outer.DoubleClickDir) == ((int)Actor.EDoubleClickDir.DCLICK_Active/*5*/))
		{
			DoubleClickMove = Actor.EDoubleClickDir.DCLICK_Active/*5*/;		
		}
		else
		{
			DoubleClickMove = Actor.EDoubleClickDir.DCLICK_None/*0*/;
		}
		if(DoubleClickTime > 0.0f)
		{
			if(((int)Outer.DoubleClickDir) == ((int)Actor.EDoubleClickDir.DCLICK_Active/*5*/))
			{
				if((Outer.Pawn != default) && ((int)Outer.Pawn.Physics) == ((int)Actor.EPhysics.PHYS_Walking/*1*/))
				{
					DoubleClickTimer = 0.0f;
					Outer.DoubleClickDir = Actor.EDoubleClickDir.DCLICK_Done/*6*/;
				}			
			}
			else
			{
				if(((int)Outer.DoubleClickDir) != ((int)Actor.EDoubleClickDir.DCLICK_Done/*6*/))
				{
					OldDoubleClick = ((Actor.EDoubleClickDir)Outer.DoubleClickDir);
					Outer.DoubleClickDir = Actor.EDoubleClickDir.DCLICK_None/*0*/;
					if(bEdgeForward && bWasForward)
					{
						Outer.DoubleClickDir = Actor.EDoubleClickDir.DCLICK_Forward/*3*/;					
					}
					else
					{
						if(bEdgeBack && bWasBack)
						{
							Outer.DoubleClickDir = Actor.EDoubleClickDir.DCLICK_Back/*4*/;						
						}
						else
						{
							if(bEdgeLeft && bWasLeft)
							{
								Outer.DoubleClickDir = Actor.EDoubleClickDir.DCLICK_Left/*1*/;							
							}
							else
							{
								if(bEdgeRight && bWasRight)
								{
									Outer.DoubleClickDir = Actor.EDoubleClickDir.DCLICK_Right/*2*/;
								}
							}
						}
					}
					if(((int)Outer.DoubleClickDir) == ((int)Actor.EDoubleClickDir.DCLICK_None/*0*/))
					{
						Outer.DoubleClickDir = ((Actor.EDoubleClickDir)OldDoubleClick);					
					}
					else
					{
						if(((int)Outer.DoubleClickDir) != ((int)OldDoubleClick))
						{
							DoubleClickTimer = DoubleClickTime + (0.50f * DeltaTime);						
						}
						else
						{
							DoubleClickMove = ((Actor.EDoubleClickDir)Outer.DoubleClickDir);
						}
					}
				}
			}
			if(((int)Outer.DoubleClickDir) == ((int)Actor.EDoubleClickDir.DCLICK_Done/*6*/))
			{
				DoubleClickTimer = FMin(DoubleClickTimer - DeltaTime, 0.0f);
				if(DoubleClickTimer < -0.350f)
				{
					Outer.DoubleClickDir = Actor.EDoubleClickDir.DCLICK_None/*0*/;
					DoubleClickTimer = DoubleClickTime;
				}			
			}
			else
			{
				if((((int)Outer.DoubleClickDir) != ((int)Actor.EDoubleClickDir.DCLICK_None/*0*/)) && ((int)Outer.DoubleClickDir) != ((int)Actor.EDoubleClickDir.DCLICK_Active/*5*/))
				{
					DoubleClickTimer -= DeltaTime;
					if(DoubleClickTimer < ((float)(0)))
					{
						Outer.DoubleClickDir = Actor.EDoubleClickDir.DCLICK_None/*0*/;
						DoubleClickTimer = DoubleClickTime;
					}
				}
			}
		}
		return ((Actor.EDoubleClickDir)DoubleClickMove);
	}
	
	public virtual /*final function */void ProcessInputMatching(float DeltaTime)
	{
		/*local */float Value = default;
		/*local */int I = default, MatchIdx = default;
		/*local */bool bMatch = default;
	
		I = 0;
		J0x07:{}
		if(I < Outer.InputRequests.Length)
		{
			if(((Outer.InputRequests[I].MatchActor != default) && Outer.InputRequests[I].MatchIdx >= 0) && Outer.InputRequests[I].MatchIdx < Outer.InputRequests[I].Inputs.Length)
			{
				MatchIdx = Outer.InputRequests[I].MatchIdx;
				if((MatchIdx != 0) && (Outer.WorldInfo.TimeSeconds - Outer.InputRequests[I].LastMatchTime) >= Outer.InputRequests[I].Inputs[MatchIdx].TimeDelta)
				{
					Outer.InputRequests[I].LastMatchTime = 0.0f;
					Outer.InputRequests[I].MatchIdx = 0;
					if(Outer.InputRequests[I].FailedFuncName != "None")
					{
						Outer.InputRequests[I].MatchActor.SetTimer(0.010f, false, Outer.InputRequests[I].FailedFuncName, default(Object?));
					}
					goto J0x4C0;
				}
				Value = 0.0f;
				switch(Outer.InputRequests[I].Inputs[MatchIdx].Type)
				{
					case PlayerController.EInputTypes.IT_XAxis/*0*/:
						Value = aStrafe;
						break;
					case PlayerController.EInputTypes.IT_YAxis/*1*/:
						Value = aBaseY;
						break;
					default:
						break;
				}
				switch(Outer.InputRequests[I].Inputs[MatchIdx].Action)
				{
					case PlayerController.EInputMatchAction.IMA_GreaterThan/*0*/:
						bMatch = Value >= Outer.InputRequests[I].Inputs[MatchIdx].Value;
						break;
					case PlayerController.EInputMatchAction.IMA_LessThan/*1*/:
						bMatch = Value <= Outer.InputRequests[I].Inputs[MatchIdx].Value;
						break;
					default:
						break;
				}
				if(bMatch)
				{
					Outer.InputRequests[I].LastMatchTime = Outer.WorldInfo.TimeSeconds;
					++ Outer.InputRequests[I].MatchIdx;
					if(Outer.InputRequests[I].MatchIdx >= Outer.InputRequests[I].Inputs.Length)
					{
						if(Outer.InputRequests[I].MatchFuncName != "None")
						{
							Outer.InputRequests[I].MatchActor.SetTimer(0.010f, false, Outer.InputRequests[I].MatchFuncName, default(Object?));
						}
						Outer.InputRequests[I].LastMatchTime = 0.0f;
						Outer.InputRequests[I].MatchIdx = 0;
					}
				}
			}
			J0x4C0:{}
			++ I;
			goto J0x07;
		}
	}
	
	public virtual /*exec function */void Jump()
	{
		if(Outer.WorldInfo.Pauser == Outer.PlayerReplicationInfo)
		{
			Outer.SetPause(false, default(/*delegate*/PlayerController.CanUnpause?));		
		}
		else
		{
			Outer.bPressedJump = true;
		}
	}
	
	public virtual /*exec function */void SmartJump()
	{
		Jump();
	}
	
	public virtual /*exec function */void ClearSmoothing()
	{
		/*local */int I = default;
	
		I = 0;
		J0x07:{}
		if(I < 2)
		{
			ZeroTime[I] = 0.0f;
			SmoothedMouse[I] = 0.0f;
			++ I;
			goto J0x07;
		}
		MouseSamplingTotal = DefaultAs<PlayerInput>().MouseSamplingTotal;
		MouseSamples = DefaultAs<PlayerInput>().MouseSamples;
	}
	
	public virtual /*function */float SmoothMouse(float aMouse, float DeltaTime, ref byte SampleCount, int Index)
	{
		/*local */float MouseSamplingTime = default;
	
		if(DeltaTime < 0.250f)
		{
			MouseSamplingTime = MouseSamplingTotal / ((float)(MouseSamples));
			if(aMouse == ((float)(0)))
			{
				ZeroTime[Index] += DeltaTime;
				if(ZeroTime[Index] < MouseSamplingTime)
				{
					aMouse = (SmoothedMouse[Index] * DeltaTime) / MouseSamplingTime;				
				}
				else
				{
					SmoothedMouse[Index] = 0.0f;
				}			
			}
			else
			{
				ZeroTime[Index] = 0.0f;
				if(SmoothedMouse[Index] != ((float)(0)))
				{
					if(DeltaTime < (MouseSamplingTime * ((float)(((int)SampleCount) + ((int)1)))))
					{
						aMouse = (aMouse * DeltaTime) / (MouseSamplingTime * ((float)(SampleCount)));					
					}
					else
					{
						SampleCount = (byte)((byte)(DeltaTime / MouseSamplingTime));
					}
				}
				SmoothedMouse[Index] = aMouse / ((float)(SampleCount));
			}		
		}
		else
		{
			ClearSmoothing();
		}
		SampleCount = (byte)0;
		return aMouse;
	}
	
	public PlayerInput()
	{
		// Object Offset:0x0030216D
		bEnableMouseSmoothing = true;
		DoubleClickTime = 0.250f;
		MouseSensitivity = 18.0f;
		MoveForwardSpeed = 1200.0f;
		MoveStrafeSpeed = 1200.0f;
		LookRightScale = 12000.0f;
		LookUpScale = -12000.0f;
		MouseSamples = 1;
		MouseSamplingTotal = 0.00830f;
		Bindings = new array</*config */Input.KeyBind>
		{
			new Input.KeyBind
			{
				Name = (name)"D",
				Command = "GBA_StrafeRight",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"A",
				Command = "GBA_StrafeLeft",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"S",
				Command = "GBA_MoveBackward",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"W",
				Command = "GBA_MoveForward",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"SpaceBar",
				Command = "GBA_Jump | SkipCutscene",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"SIXAXIS_AccelZ",
				Command = "Axis aPS3AccelZ",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"SIXAXIS_AccelY",
				Command = "Axis aPS3AccelY",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"SIXAXIS_AccelX",
				Command = "Axis aPS3AccelX",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"XboxTypeS_DPad_Right",
				Command = "SwitchToItemInSlot 4 | DropMe | TriggerEmoteMessage 0",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"Duck",
				Command = "Button bDuck | Axis aUp Speed=-1.0  AbsoluteAxis=100",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"Look",
				Command = "Button bLook",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"Pause",
				Command = "Pause",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"LookToggle",
				Command = "Toggle bLook",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"LookUp",
				Command = "Axis aLookUp Speed=+25.0 AbsoluteAxis=100",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"LookDown",
				Command = "Axis aLookUp Speed=-25.0 AbsoluteAxis=100",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"CenterView",
				Command = "Button bSnapLevel",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"Walking",
				Command = "Button bRun",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"Strafe",
				Command = "Button bStrafe",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"NextWeapon",
				Command = "NextWeapon",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"ViewTeam",
				Command = "ViewClass Pawn",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"TurnToNearest",
				Command = "Button bTurnToNearest",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"Turn180",
				Command = "Button bTurn180",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"GBA_Strafe_Gamepad",
				Command = "Axis aStrafe Speed=1.0 DeadZone=0.3",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"GBA_Pause",
				Command = "OnRelease PauseGame",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"GBA_LookDown",
				Command = "",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"GBA_LookUp",
				Command = "",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"GBA_TurnRight",
				Command = "Axis aBaseX Speed=+1500.0 AbsoluteAxis=100",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"MouseX",
				Command = "Count bXAxis | Axis aMouseX",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"MouseY",
				Command = "Count bYAxis | Axis aMouseY",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"GBA_Look_Gamepad",
				Command = "Axis aLookup Speed=1.0 DeadZone=0.3",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"GBA_TurnLeft",
				Command = "Axis aBaseX Speed=-1500.0 AbsoluteAxis=100",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"GBA_Look_MouseY",
				Command = "Count bYAxis | Axis aMouseY",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"GBA_Look_MouseX",
				Command = "Count bXAxis | Axis aMouseX",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"GBA_WalkMod",
				Command = "WalkMod | OnRelease StopWalkMod",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"XboxTypeS_Start",
				Command = "GBA_Pause",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"GBA_Move_Gamepad",
				Command = "Axis aBaseY Speed=1.0 DeadZone=0.3",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"GBA_ZoomWeapon",
				Command = "ZoomWeapon",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"GBA_SwitchWeapon",
				Command = "PressedSwitchWeapon | OnRelease ReleasedSwitchWeapon",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"GBA_Turn_Gamepad",
				Command = "Axis aTurn Speed=1.0 DeadZone=0.3",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"P",
				Command = "TogglePhysicsMode",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"GBA_StrafeRight",
				Command = "Axis aStrafe Speed=+1.0",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"GBA_StrafeLeft",
				Command = "Axis aStrafe Speed=-1.0",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"GBA_MoveBackward",
				Command = "Axis aBaseY Speed=-1.0",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"GBA_MoveForward",
				Command = "Axis aBaseY Speed=1.0",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"LeftShift",
				Command = "Walking",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"GBA_ReactionTime",
				Command = "AttemptReactionTime",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"GBA_LookBehind",
				Command = "LookBehind ",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"GBA_InGameMenu",
				Command = "OnRelease SkipCutscene | OnRelease OpenIngameMenu",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"F5",
				Command = "quicksave",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"F6",
				Command = "quickload",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"F7",
				Command = "set D3DRenderDevice bUsePostProcessEffects False",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"F8",
				Command = "set D3DRenderDevice bUsePostProcessEffects True",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"F9",
				Command = "shot",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"F10",
				Command = "dumpdynamicshadowstats",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"GBA_LookAt",
				Command = "LookAtPress | OnRelease LookAtRelease",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"End",
				Command = "Camera FirstPerson",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"GBA_Use",
				Command = "UsePress | OnRelease UseRelease",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"GBA_Crouch",
				Command = "Crouch | OnRelease StopCrouch | PrevViewTarget",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"GBA_Jump",
				Command = "Jump | OnRelease StopJump | Axis aUp Speed=1.0  AbsoluteAxis=100 | PrevStaticViewTarget",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"GBA_Fire",
				Command = "AttackPress | OnRelease AttackRelease | NextViewTarget",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"XboxTypeS_DPad_Left",
				Command = "SwitchToItemInSlot 3 | InvertMouseCheat | TriggerEmoteMessage 2",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"XboxTypeS_DPad_Down",
				Command = "SwitchToItemInSlot 2 | Jesus | TriggerEmoteMessage 1",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"XboxTypeS_DPad_Up",
				Command = "SwitchToItemInSlot 1 | God",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"XboxTypeS_Back",
				Command = "GBA_InGameMenu",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"XboxTypeS_X",
				Command = "GBA_ReactionTime",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"XboxTypeS_Y",
				Command = "GBA_SwitchWeapon",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"XboxTypeS_B",
				Command = "GBA_LookAt",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"XboxTypeS_A",
				Command = "GBA_Use",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"XboxTypeS_LeftThumbstick",
				Command = "",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"XboxTypeS_RightThumbstick",
				Command = "GBA_ZoomWeapon",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"XboxTypeS_LeftTrigger",
				Command = "GBA_Crouch",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"XboxTypeS_LeftShoulder",
				Command = "GBA_Jump",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"XboxTypeS_RightTrigger",
				Command = "GBA_Fire",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"XboxTypeS_RightShoulder",
				Command = "GBA_LookBehind",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"XboxTypeS_RightY",
				Command = "GBA_Look_Gamepad",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"XboxTypeS_RightX",
				Command = "GBA_Turn_Gamepad",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"XboxTypeS_LeftY",
				Command = "GBA_Move_Gamepad",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"XboxTypeS_LeftX",
				Command = "GBA_Strafe_Gamepad",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"E",
				Command = "GBA_Use",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"LeftMouseButton",
				Command = "GBA_Fire",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"RightMouseButton",
				Command = "GBA_SwitchWeapon",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"F",
				Command = "GBA_ZoomWeapon",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"LeftShift",
				Command = "GBA_Crouch",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"TAB",
				Command = "GBA_InGameMenu",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"Q",
				Command = "GBA_LookBehind",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"R",
				Command = "GBA_ReactionTime",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"LeftAlt",
				Command = "GBA_LookAt",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"LeftControl",
				Command = "GBA_WalkMod",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"MouseX",
				Command = "GBA_Look_MouseX",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"MouseY",
				Command = "GBA_Look_MouseY",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"Escape",
				Command = "OnRelease PauseGame",
				Control = false,
				Shift = false,
				Alt = false,
			},
		};
		OverrideBindings = new array</*config */Input.InputOverridePair>
		{
			new Input.InputOverridePair
			{
				Key = (name)"FRA",
				Binding = new Input.KeyBind
				{
					Name = (name)"Z",
					Command = "GBA_MoveForward",
					Control = false,
					Shift = false,
					Alt = false,
				},
			},
			new Input.InputOverridePair
			{
				Key = (name)"FRA",
				Binding = new Input.KeyBind
				{
					Name = (name)"S",
					Command = "GBA_MoveBackward",
					Control = false,
					Shift = false,
					Alt = false,
				},
			},
			new Input.InputOverridePair
			{
				Key = (name)"FRA",
				Binding = new Input.KeyBind
				{
					Name = (name)"Q",
					Command = "GBA_StrafeLeft",
					Control = false,
					Shift = false,
					Alt = false,
				},
			},
			new Input.InputOverridePair
			{
				Key = (name)"FRA",
				Binding = new Input.KeyBind
				{
					Name = (name)"D",
					Command = "GBA_StrafeRight",
					Control = false,
					Shift = false,
					Alt = false,
				},
			},
			new Input.InputOverridePair
			{
				Key = (name)"FRA",
				Binding = new Input.KeyBind
				{
					Name = (name)"A",
					Command = "GBA_LookBehind",
					Control = false,
					Shift = false,
					Alt = false,
				},
			},
		};
	}
}
}