﻿namespace MEdge.Engine{
	using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;



	public partial class PlayerController
	{
		// Export UPlayerController::execIsLocalPlayerController(FFrame&, void* const)
		public override /*native function */bool IsLocalPlayerController()
		{
			return this.Player is LocalPlayer;
		}
		
		// Export UPlayerController::execSetViewTarget(FFrame&, void* const)
		public virtual /*native function */void SetViewTarget(Actor NewViewTarget, /*optional */Camera.ViewTargetTransitionParams? _TransitionParams = default)
		{
			this.ViewTarget = NewViewTarget;
			this.PlayerCamera?.SetViewTarget( NewViewTarget ); // Maybe ?
		}
	}
}