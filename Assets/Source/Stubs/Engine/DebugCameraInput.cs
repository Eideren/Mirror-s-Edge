namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DebugCameraInput : PlayerInput/* within PlayerController*//*
		transient
		config(Input)
		hidecategories(Object,UIRoot)*/{
	public new PlayerController Outer => base.Outer as PlayerController;
	
	public DebugCameraInput()
	{
		// Object Offset:0x003066AC
		Bindings = new array</*config */Input.KeyBind>
		{
			new Input.KeyBind
			{
				Name = (name)"MoveUp",
				Command = "Axis aUp Speed=1.0",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"MoveDown",
				Command = "Axis aUp Speed=-1.0",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"MoveForward",
				Command = "Axis aBaseY Speed=1.0",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"MoveBackward",
				Command = "Axis aBaseY Speed=-1.0",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"TurnLeft",
				Command = "Axis aBaseX Speed=-200.0 AbsoluteAxis=100",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"TurnRight",
				Command = "Axis aBaseX  Speed=+200.0 AbsoluteAxis=100",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"StrafeLeft",
				Command = "Axis aStrafe Speed=-1.0",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"StrafeRight",
				Command = "Axis aStrafe Speed=+1.0",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"Q",
				Command = "MoveDown",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"E",
				Command = "MoveUp",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"W",
				Command = "MoveForward",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"S",
				Command = "MoveBackward",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"A",
				Command = "StrafeLeft",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"D",
				Command = "StrafeRight",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"F",
				Command = "FreezeRendering",
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
				Name = (name)"Left",
				Command = "TurnLeft",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"Right",
				Command = "TurnRight",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"C",
				Command = "ToggleDebugCamera",
				Control = false,
				Shift = false,
				Alt = true,
			},
			new Input.KeyBind
			{
				Name = (name)"LeftShift",
				Command = "MoreSpeed | OnRelease NormalSpeed",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"XboxTypeS_LeftThumbstick",
				Command = "ToggleDebugCamera",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"XboxTypeS_LeftX",
				Command = "Axis aStrafe Speed=1.0 DeadZone=0.3",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"XboxTypeS_LeftY",
				Command = "Axis aBaseY Speed=1.0 DeadZone=0.3",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"XboxTypeS_RightX",
				Command = "Axis aTurn Speed=1.0 DeadZone=0.2",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"XboxTypeS_RightY",
				Command = "Axis aLookup Speed=0.8 DeadZone=0.2",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"XboxTypeS_LeftTrigger",
				Command = "MoveDown",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"XboxTypeS_RightTrigger",
				Command = "MoveUp",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"XboxTypeS_A",
				Command = "SetFreezeRendering",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"XboxTypeS_B",
				Command = "MoreSpeed | OnRelease NormalSpeed",
				Control = false,
				Shift = false,
				Alt = false,
			},
		};
	}
}
}