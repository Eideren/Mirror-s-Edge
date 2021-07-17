namespace MEdge.Engine
{
	using TdGame;
	using UnityEngine;
	using static UnityEngine.Mathf;


	public partial class UWorld
	{
		static Vector3 _previousMouse;
		public static void SampleInput( TdPlayerInput uInput, TdPlayerController controller, float dt )
        {
	        // Variables marked as 'input' are reset every frame afaict
			uInput.aBaseX = default;
			uInput.aBaseY = default;
			uInput.aBaseZ = default;
			uInput.aMouseX = default;
			uInput.aMouseY = default;
			uInput.aForward = default;
			uInput.aTurn = default;
			uInput.aStrafe = default;
			uInput.aUp = default;
			uInput.aLookUp = default;
			uInput.aPS3AccelX = default;
			uInput.aPS3AccelY = default;
			uInput.aPS3AccelZ = default;
			uInput.aPS3Gyro = default;
			uInput.bStrafe = default;
			uInput.bXAxis = default;
			uInput.bYAxis = default;
			
			controller.bFire = default;
			controller.bRun = default;
			controller.bDuck = default;







			var mouseDelta = ( UnityEngine.Input.mousePosition - _previousMouse );// * 0.001f;
	        _previousMouse = UnityEngine.Input.mousePosition;

	        // (Name:"D",Command:"GBA_StrafeRight",Control:false,Shift:false,Alt:false),
	        // (Name:"GBA_StrafeRight",Command:"Axis aStrafe Speed=+1.0",Control:false,Shift:false,Alt:false),
	        // (Name:"A",Command:"GBA_StrafeLeft",Control:false,Shift:false,Alt:false),
	        // (Name:"GBA_StrafeLeft",Command:"Axis aStrafe Speed=-1.0",Control:false,Shift:false,Alt:false),
	        UpdateAxisValue(ref uInput.aStrafe, UnityEngine.Input.GetKey( KeyCode.D ) ? 1f : 0f, dt, Speed:1f);
	        UpdateAxisValue(ref uInput.aStrafe, UnityEngine.Input.GetKey( KeyCode.A ) ? 1f : 0f, dt, Speed:-1f);
	        // (Name:"S",Command:"GBA_MoveBackward",Control:false,Shift:false,Alt:false),
	        // (Name:"GBA_MoveBackward",Command:"Axis aBaseY Speed=-1.0",Control:false,Shift:false,Alt:false),
	        // (Name:"W",Command:"GBA_MoveForward",Control:false,Shift:false,Alt:false),
	        // (Name:"GBA_MoveForward",Command:"Axis aBaseY Speed=1.0",Control:false,Shift:false,Alt:false),
	        UpdateAxisValue(ref uInput.aBaseY, UnityEngine.Input.GetKey( KeyCode.S ) ? 1f : 0f, dt, Speed:-1f);
	        UpdateAxisValue(ref uInput.aBaseY, UnityEngine.Input.GetKey( KeyCode.W ) ? 1f : 0f, dt, Speed:1f);

	        //( Name: "MouseX", Command: "GBA_Look_MouseX", Control: false, Shift: false, Alt: false ),
            //( Name: "GBA_Look_MouseX", Command: "Count bXAxis | Axis aMouseX", Control: false, Shift: false, Alt: false ),
            if(mouseDelta.x != 0f)
				uInput.bXAxis += 1;
            UpdateAxisValue(ref uInput.aMouseX, mouseDelta.x, dt);
            
            //( Name: "MouseY", Command: "GBA_Look_MouseY", Control: false, Shift: false, Alt: false ),
            //( Name: "GBA_Look_MouseY", Command: "Count bYAxis | Axis aMouseY", Control: false, Shift: false, Alt: false ),
            if(mouseDelta.y != 0f)
				uInput.bYAxis += 1;
            UpdateAxisValue(ref uInput.aMouseY, mouseDelta.y, dt);
            
            //( Name: "SpaceBar", Command: "GBA_Jump | SkipCutscene", Control: false, Shift: false, Alt: false ),
            //( Name: "GBA_Jump", Command: "Jump | OnRelease StopJump | Axis aUp Speed=1.0  AbsoluteAxis=100 | PrevStaticViewTarget", Control: false, Shift: false, Alt: false ),
            UpdateAxisValue( ref uInput.aUp, UnityEngine.Input.GetKey( KeyCode.Space ) ? 1f : 0f, dt, Speed: 1f, AbsoluteAxis: 100f );
            
            if( UnityEngine.Input.GetKeyDown( KeyCode.Space ) )
            {
	            controller.PrevStaticViewTarget();
	            uInput.Jump();
	            controller.SkipCutscene();
            }
            if( UnityEngine.Input.GetKeyUp( KeyCode.Space ) )
	            uInput.StopJump();
			
            // (Name:"Q",Command:"GBA_LookBehind",Control:false,Shift:false,Alt:false),
            // (Name:"GBA_LookBehind",Command:"LookBehind ",Control:false,Shift:false,Alt:false),
            if( UnityEngine.Input.GetKeyDown( KeyCode.Q ) )
	            controller.LookBehind();

            // (Name:"LeftShift",Command:"GBA_Crouch",Control:false,Shift:false,Alt:false),
            // (Name:"GBA_Crouch",Command:"Crouch | OnRelease StopCrouch | PrevViewTarget",Control:false,Shift:false,Alt:false),
            if( UnityEngine.Input.GetKeyDown( KeyCode.LeftShift ) )
	            uInput.Crouch();
            if( UnityEngine.Input.GetKeyUp( KeyCode.LeftShift ) )
	            uInput.StopCrouch();

            // (Name:"LeftShift",Command:"Walking",Control:false,Shift:false,Alt:false),
            // (Name:"Walking",Command:"Button bRun",Control:false,Shift:false,Alt:false),
            controller.bRun = (byte)(UnityEngine.Input.GetKey( KeyCode.LeftShift ) ? 1 : 0);
            
            // (Name:"R",Command:"GBA_ReactionTime",Control:false,Shift:false,Alt:false),
            // (Name:"GBA_ReactionTime",Command:"AttemptReactionTime",Control:false,Shift:false,Alt:false),
            if( UnityEngine.Input.GetKeyDown( KeyCode.R ) )
	            controller.AttemptReactionTime();
            
            // (Name:"E",Command:"GBA_Use",Control:false,Shift:false,Alt:false),
            // (Name:"GBA_Use",Command:"UsePress | OnRelease UseRelease",Control:false,Shift:false,Alt:false),
            if( UnityEngine.Input.GetKeyDown( KeyCode.E ) )
	            controller.UsePress();
            if( UnityEngine.Input.GetKeyUp( KeyCode.E ) )
	            controller.UseRelease();
            
            // (Name:"LeftControl",Command:"GBA_WalkMod",Control:false,Shift:false,Alt:false),
            // (Name:"GBA_WalkMod",Command:"WalkMod | OnRelease StopWalkMod",Control:false,Shift:false,Alt:false),
            if( UnityEngine.Input.GetKeyDown( KeyCode.LeftControl ) )
	            uInput.WalkMod();
            if( UnityEngine.Input.GetKeyUp( KeyCode.LeftControl ) )
	            uInput.StopWalkMod();
            
            // (Name:"LeftAlt",Command:"GBA_LookAt",Control:false,Shift:false,Alt:false),
            // (Name:"GBA_LookAt",Command:"LookAtPress | OnRelease LookAtRelease",Control:false,Shift:false,Alt:false),
            if( UnityEngine.Input.GetKeyDown( KeyCode.LeftAlt ) )
	            controller.LookAtPress();
            if( UnityEngine.Input.GetKeyUp( KeyCode.LeftAlt ) )
	            controller.LookAtRelease();
        }



		static void UpdateAxisValue( ref float axis, float axisDelta, float deltaTime, float Speed = 1f, int InvertMultiplier = 1, float DeadZone = 0f, float AbsoluteAxis = 0f )
		{
			if( axisDelta == 0f )
			{
				axis = 0f;
				return;
			}

			var CurrentDelta = axisDelta;
			// Axis is expected to be in -1 .. 1 range if dead zone is used.
			if( DeadZone > 0f && DeadZone < 1f )
			{
				// We need to translate and scale the input to the +/- 1 range after removing the dead zone.
				if( CurrentDelta > 0 )
				{
					CurrentDelta = Max( 0f, CurrentDelta - DeadZone ) / (1f - DeadZone);
				}
				else
				{
					CurrentDelta = -Max( 0f, -CurrentDelta - DeadZone ) / (1f - DeadZone);
				}
			}
				
			// Absolute axis like joysticks need to be scaled by delta time in order to be framerate independent.
			if( AbsoluteAxis != 0f )
			{
				Speed *= deltaTime * AbsoluteAxis;
			}

			axis += Speed * InvertMultiplier * CurrentDelta;
		}



		static (string Name, string Command, bool Control, bool Shift, bool Alt)[] bindings =
        {
			(Name:"SIXAXIS_AccelZ",Command:"Axis aPS3AccelZ",Control:false,Shift:false,Alt:false),
			(Name:"SIXAXIS_AccelY",Command:"Axis aPS3AccelY",Control:false,Shift:false,Alt:false),
			(Name:"SIXAXIS_AccelX",Command:"Axis aPS3AccelX",Control:false,Shift:false,Alt:false),
			//(Name:"Look",Command:"Button bLook",Control:false,Shift:false,Alt:false),
			//(Name:"LookToggle",Command:"Toggle bLook",Control:false,Shift:false,Alt:false),
			//(Name:"LookUp",Command:"Axis aLookUp Speed=+25.0 AbsoluteAxis=100",Control:false,Shift:false,Alt:false),
			//(Name:"LookDown",Command:"Axis aLookUp Speed=-25.0 AbsoluteAxis=100",Control:false,Shift:false,Alt:false),
			//(Name:"CenterView",Command:"Button bSnapLevel",Control:false,Shift:false,Alt:false),
			//(Name:"Strafe",Command:"Button bStrafe",Control:false,Shift:false,Alt:false),
			//(Name:"NextWeapon",Command:"NextWeapon",Control:false,Shift:false,Alt:false),
			//(Name:"ViewTeam",Command:"ViewClass Pawn",Control:false,Shift:false,Alt:false),
			//(Name:"TurnToNearest",Command:"Button bTurnToNearest",Control:false,Shift:false,Alt:false),
			//(Name:"Turn180",Command:"Button bTurn180",Control:false,Shift:false,Alt:false),
			//(Name:"GBA_LookDown",Command:,Control:false,Shift:false,Alt:false),
			//(Name:"GBA_LookUp",Command:,Control:false,Shift:false,Alt:false),
			//(Name:"GBA_TurnRight",Command:"Axis aBaseX Speed=+1500.0 AbsoluteAxis=100",Control:false,Shift:false,Alt:false),
			//(Name:"GBA_TurnLeft",Command:"Axis aBaseX Speed=-1500.0 AbsoluteAxis=100",Control:false,Shift:false,Alt:false),
			//(Name:"P",Command:"TogglePhysicsMode",Control:false,Shift:false,Alt:false),
			(Name:"Pause",Command:"Pause",Control:false,Shift:false,Alt:false),
			(Name:"GBA_Pause",Command:"OnRelease PauseGame",Control:false,Shift:false,Alt:false),
			(Name:"GBA_Strafe_Gamepad",Command:"Axis aStrafe Speed=1.0 DeadZone=0.3",Control:false,Shift:false,Alt:false),
			(Name:"GBA_Look_Gamepad",Command:"Axis aLookup Speed=1.0 DeadZone=0.3",Control:false,Shift:false,Alt:false),
			(Name:"GBA_Move_Gamepad",Command:"Axis aBaseY Speed=1.0 DeadZone=0.3",Control:false,Shift:false,Alt:false),
			(Name:"GBA_ZoomWeapon",Command:"ZoomWeapon",Control:false,Shift:false,Alt:false),
			(Name:"GBA_SwitchWeapon",Command:"PressedSwitchWeapon | OnRelease ReleasedSwitchWeapon",Control:false,Shift:false,Alt:false),
			(Name:"GBA_Turn_Gamepad",Command:"Axis aTurn Speed=1.0 DeadZone=0.3",Control:false,Shift:false,Alt:false),
			(Name:"GBA_InGameMenu",Command:"OnRelease SkipCutscene | OnRelease OpenIngameMenu",Control:false,Shift:false,Alt:false),
			
			(Name:"GBA_Fire",Command:"AttackPress | OnRelease AttackRelease | NextViewTarget",Control:false,Shift:false,Alt:false),

			(Name:"F5",Command:"quicksave",Control:false,Shift:false,Alt:false),
			(Name:"F6",Command:"quickload",Control:false,Shift:false,Alt:false),
			(Name:"F7",Command:"set D3DRenderDevice bUsePostProcessEffects False",Control:false,Shift:false,Alt:false),
			(Name:"F8",Command:"set D3DRenderDevice bUsePostProcessEffects True",Control:false,Shift:false,Alt:false),
			(Name:"F9",Command:"shot",Control:false,Shift:false,Alt:false),
			(Name:"F10",Command:"dumpdynamicshadowstats",Control:false,Shift:false,Alt:false),
			
			(Name:"End",Command:"Camera FirstPerson",Control:false,Shift:false,Alt:false),
			
			(Name:"XboxTypeS_Start",Command:"GBA_Pause",Control:false,Shift:false,Alt:false),
			(Name:"XboxTypeS_DPad_Right",Command:"SwitchToItemInSlot 4 | DropMe | TriggerEmoteMessage 0",Control:false,Shift:false,Alt:false),
			(Name:"XboxTypeS_DPad_Left",Command:"SwitchToItemInSlot 3 | InvertMouseCheat | TriggerEmoteMessage 2",Control:false,Shift:false,Alt:false),
			(Name:"XboxTypeS_DPad_Down",Command:"SwitchToItemInSlot 2 | Jesus | TriggerEmoteMessage 1",Control:false,Shift:false,Alt:false),
			(Name:"XboxTypeS_DPad_Up",Command:"SwitchToItemInSlot 1 | God",Control:false,Shift:false,Alt:false),
			(Name:"XboxTypeS_Back",Command:"GBA_InGameMenu",Control:false,Shift:false,Alt:false),
			(Name:"XboxTypeS_X",Command:"GBA_ReactionTime",Control:false,Shift:false,Alt:false),
			(Name:"XboxTypeS_Y",Command:"GBA_SwitchWeapon",Control:false,Shift:false,Alt:false),
			(Name:"XboxTypeS_B",Command:"GBA_LookAt",Control:false,Shift:false,Alt:false),
			(Name:"XboxTypeS_A",Command:"GBA_Use",Control:false,Shift:false,Alt:false),
			//(Name:"XboxTypeS_LeftThumbstick",Command:,Control:false,Shift:false,Alt:false),
			(Name:"XboxTypeS_RightThumbstick",Command:"GBA_ZoomWeapon",Control:false,Shift:false,Alt:false),
			(Name:"XboxTypeS_LeftTrigger",Command:"GBA_Crouch",Control:false,Shift:false,Alt:false),
			(Name:"XboxTypeS_LeftShoulder",Command:"GBA_Jump",Control:false,Shift:false,Alt:false),
			(Name:"XboxTypeS_RightTrigger",Command:"GBA_Fire",Control:false,Shift:false,Alt:false),
			(Name:"XboxTypeS_RightShoulder",Command:"GBA_LookBehind",Control:false,Shift:false,Alt:false),
			(Name:"XboxTypeS_RightY",Command:"GBA_Look_Gamepad",Control:false,Shift:false,Alt:false),
			(Name:"XboxTypeS_RightX",Command:"GBA_Turn_Gamepad",Control:false,Shift:false,Alt:false),
			(Name:"XboxTypeS_LeftY",Command:"GBA_Move_Gamepad",Control:false,Shift:false,Alt:false),
			(Name:"XboxTypeS_LeftX",Command:"GBA_Strafe_Gamepad",Control:false,Shift:false,Alt:false),
			
			(Name:"F",Command:"GBA_ZoomWeapon",Control:false,Shift:false,Alt:false),
			(Name:"LeftMouseButton",Command:"GBA_Fire",Control:false,Shift:false,Alt:false),
			(Name:"RightMouseButton",Command:"GBA_SwitchWeapon",Control:false,Shift:false,Alt:false),
			
			(Name:"TAB",Command:"GBA_InGameMenu",Control:false,Shift:false,Alt:false),
			(Name:"Escape",Command:"OnRelease PauseGame",Control:false,Shift:false,Alt:false),
        };
	}
}