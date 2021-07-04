// NO OVERWRITE

namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPlayerInput : PlayerInput/* within TdPlayerController*//*
		transient
		native
		config(Input)
		hidecategories(Object,UIRoot)*/{
	public new TdPlayerController Outer => base.Outer as TdPlayerController;
	
	public/*()*/ bool bViewAccelEnabled;
	public bool bWalkButtonPressed;
	public bool bInvertGamepadYAxis;
	public/*()*/ float YawAccelThreshold;
	public /*config */float MaxSensitivityMultiplier;
	public /*config */float MinSensitivityMultiplier;
	public float SensitivityMultiplier;
	public /*config */float WalkButtonMultiplier;
	
	public virtual /*simulated function */void InitInputSystem(Class GameInfoClass)
	{
	
	}
	
	public virtual /*exec function */void InvertGamepadYAxis(bool InvertYAxis)
	{
		bInvertGamepadYAxis = InvertYAxis;
	}
	
	public virtual /*exec function */void Crouch()
	{
		if(Outer.IsButtonInputIgnored())
		{
			return;
		}
		Outer.bDuck = (byte)1;
	}
	
	public virtual /*exec function */void StopCrouch()
	{
		if(Outer.IsButtonInputIgnored())
		{
			return;
		}
		Outer.bDuck = (byte)0;
	}
	
	public virtual /*exec function */void WalkMod()
	{
		if(Outer.IsButtonInputIgnored())
		{
			return;
		}
		bWalkButtonPressed = true;
	}
	
	public virtual /*exec function */void StopWalkMod()
	{
		if(Outer.IsButtonInputIgnored())
		{
			return;
		}
		bWalkButtonPressed = false;
	}
	
	public override /*exec function */void Jump()
	{
		if(Outer.IsButtonInputIgnored())
		{
			return;
		}
		Outer.TimePressedJump = Outer.WorldInfo.TimeSeconds;
		Outer.bPressedJump = true;
	}
	
	public virtual /*exec function */void StopJump()
	{
		if(Outer.IsButtonInputIgnored())
		{
			return;
		}
		Outer.bReleasedJump = true;
	}
	
	public virtual /*exec function */void PressButton(name buttonname)
	{
		if(Outer.IsButtonInputIgnored())
		{
			return;
		}
		switch(buttonname)
		{
			case "Jump":
				Outer.bPressedJump = true;
				break;
			default:
				break;
		}
	}
	
	public virtual /*exec function */void ReleaseButton(name buttonname)
	{
		if(Outer.IsButtonInputIgnored())
		{
			return;
		}
		switch(buttonname)
		{
			case "Jump":
				Outer.bReleasedJump = true;
				break;
			default:
				break;
		}
	}
	
	public virtual /*exec function */void CycleWeapon()
	{
	
	}
	
	public virtual /*function */void SetRangedSensitivityMultiplier(float RangeVal)
	{
		SensitivityMultiplier = Lerp(MinSensitivityMultiplier, MaxSensitivityMultiplier, RangeVal);
		MouseSensitivity = 28.0f * SensitivityMultiplier;
	}
	
	public override /*function */void PreProcessInput(float DeltaTime)
	{
		Outer.SetInputHint();
		if(bViewAccelEnabled && aTurn != ((float)(0)))
		{
			ViewAcceleration(DeltaTime);
		}
		aTurn *= SensitivityMultiplier;
		aLookUp *= SensitivityMultiplier;
	}
	
	public virtual /*function */void ViewAcceleration(float DeltaTime)
	{
		/*local */float absturn = default;
	
		absturn = Abs(aTurn);
		if(absturn > YawAccelThreshold)
		{
			absturn -= YawAccelThreshold;
			absturn /= (1.0f - YawAccelThreshold);
			absturn = Exponentiation(absturn, 2.0f);
			aTurn *= (1.0f + (absturn * 1.50f));		
		}
		else
		{
			aTurn = ((aTurn < ((float)(0))) ? ((float)(-1)) * Square(aTurn) : Square(aTurn));
			aLookUp = ((aLookUp < ((float)(0))) ? ((float)(-1)) * Square(aLookUp) : Square(aLookUp));
		}
	}
	
	public override /*function */Actor.EDoubleClickDir CheckForDoubleClickMove(float DeltaTime)
	{
		return Actor.EDoubleClickDir.DCLICK_None/*0*/;
	}
	
	public override /*event */void PlayerInput_(float DeltaTime)
	{
		// Initially 'PlayerInput', renamed to 'PlayerInput_' as c#'s naming scheme doesn't allow members with the same name as their class
		
		/*local */float FOVScale = default, MovementHandicap = default;
	
		RawJoyUp = aBaseY;
		RawJoyRight = aStrafe;
		RawJoyLookRight = aTurn;
		RawJoyLookUp = aLookUp;
		DeltaTime /= Outer.WorldInfo.TimeDilation;
		PreProcessInput(DeltaTime);
		if(bEnableMouseSmoothing)
		{
			aMouseX = SmoothMouse(aMouseX, DeltaTime, ref/*probably?*/ bXAxis, 0);
			aMouseY = SmoothMouse(aMouseY, DeltaTime, ref/*probably?*/ bYAxis, 1);
		}
		aTurn *= (DeltaTime * LookRightScale);
		aLookUp *= (DeltaTime * LookUpScale);
		aMouseX *= MouseSensitivity;
		aMouseY *= MouseSensitivity;
		aTurn += aMouseX;
		aForward = aBaseY;
		Outer.InputSize = Sqrt((aForward * aForward) + (aStrafe * aStrafe));
		if(Outer.InputSize > 1.0f)
		{
			aForward /= Outer.InputSize;
			aStrafe /= Outer.InputSize;
		}
		aLookUp += aMouseY;
		if(bUsingGamepad && bInvertGamepadYAxis)
		{
			aLookUp *= -1.0f;
		}
		if(bInvertMouse)
		{
			aLookUp *= -1.0f;
		}
		PostProcessInput(DeltaTime);
		ProcessInputMatching(DeltaTime);
		FOVScale = Outer.GetFOVAngle() * 0.011110f;
		aLookUp *= (FOVScale * 1.780f);
		aTurn *= FOVScale;
		Outer.HandleWalking();
		if(bUsingGamepad && bInvertGamepadYAxis)
		{
			aForward = -aForward;
		}
		MovementHandicap = 1.0f;
		if(Outer.myPawn != default)
		{
			MovementHandicap = Outer.myPawn.GetMobilityMultiplier();
		}
		if(bWalkButtonPressed)
		{
			MovementHandicap *= WalkButtonMultiplier;
		}
		if(Outer.IsMoveInputIgnored())
		{
			aForward = 0.0f;
			aStrafe = 0.0f;
			aUp = 0.0f;		
		}
		else
		{
			aForward *= MovementHandicap;
			aStrafe *= MovementHandicap;
			aUp *= MovementHandicap;
		}
		if(Outer.IsLookInputIgnored())
		{
			aTurn = 0.0f;
			aLookUp = 0.0f;		
		}
		else
		{
			aTurn *= MovementHandicap;
			aLookUp *= MovementHandicap;
		}
	}
	
	public override /*function */void PostProcessInput(float DeltaTime)
	{
	
	}
	
	// Export UTdPlayerInput::execGetTdBindNameFromCommand(FFrame&, void* const)
	public virtual /*native function */String GetTdBindNameFromCommand(String BindCommand, /*optional */bool? _bForceUsingGamepad = default)
	{
		 NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	public override /*exec function */void SetBind(name BindName, String Command)
	{
		/*local */int Idx = default;
		/*local */Input.KeyBind NewBind = default;
		/*local */bool bSpaceBarExist = default;
	
		if(BindName == "SpaceBar")
		{
			base.SetBind(BindName, Command + " " + "| SkipCutscene");		
		}
		else
		{
			base.SetBind(BindName, Command);
			Idx = 0;
			J0x4F:{}
			if(Idx < Bindings.Length)
			{
				if(Bindings[Idx].Name == "SpaceBar")
				{
					bSpaceBarExist = true;
					goto J0x98;
				}
				++ Idx;
				goto J0x4F;
			}
			J0x98:{}
			if(!bSpaceBarExist)
			{
				NewBind.Name = "SpaceBar";
				NewBind.Command = "SkipCutscene";
				Bindings[Bindings.Length] = NewBind;
				SaveConfig();
			}
		}
	}
	
	public TdPlayerInput()
	{
		// Object Offset:0x00627225
		bViewAccelEnabled = true;
		YawAccelThreshold = 0.90f;
		MaxSensitivityMultiplier = 1.80f;
		MinSensitivityMultiplier = 0.20f;
		SensitivityMultiplier = 1.0f;
		WalkButtonMultiplier = 0.30f;
	}
}
}