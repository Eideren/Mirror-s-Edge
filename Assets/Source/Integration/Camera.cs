namespace MEdge.Engine{
	using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

	public partial class Camera
	{
		// Export UCamera::execSetViewTarget(FFrame&, void* const)
		public virtual /*native final function */void SetViewTarget(Actor NewViewTarget, /*optional */Camera.ViewTargetTransitionParams? _TransitionParams = default)
		{
			ViewTarget.Target = NewViewTarget;
		}
		
		public virtual /*native function */void CheckViewTarget(ref Camera.TViewTarget VT)
		{
			if( !VT.Target )
			{
				VT.Target = PCOwner;
			}

			// Update ViewTarget PlayerReplicationInfo (used to follow same player through pawn transitions, etc., when spectating)
			if( VT.Target == PCOwner || (VT.Target as Pawn && (VT.Target == PCOwner.Pawn)) ) 
			{	
				VT.PRI = null;
			}
			else if( VT.Target as Controller )
			{
				VT.PRI = (VT.Target as Controller).PlayerReplicationInfo;
			}
			else if( (VT.Target as Pawn) )
			{
				VT.PRI = (VT.Target as Pawn).PlayerReplicationInfo;
			}
			else if( VT.Target as PlayerReplicationInfo )
			{
				VT.PRI = (VT.Target) as PlayerReplicationInfo;
			}
			else
			{
				VT.PRI = null;
			}

			if( VT.PRI && !VT.PRI.bDeleteMe )
			{
				if( !VT.Target || VT.Target.bDeleteMe || !(VT.Target as Pawn) || ((VT.Target as Pawn).PlayerReplicationInfo != VT.PRI) )
				{
					VT.Target = null;

					// not viewing pawn associated with RealViewTarget, so look for one
					// Assuming on server, so PRI Owner is valid
					if( !VT.PRI.Owner )
					{
						VT.PRI = null;
					}
					else
					{
						Controller PRIOwner = VT.PRI.Owner as Controller;
						if( PRIOwner )
						{
							Actor PRIViewTarget = PRIOwner.Pawn;
							if( PRIViewTarget && !PRIViewTarget.bDeleteMe )
							{
								AssignViewTarget(PRIViewTarget, ref VT);
							}
							else
							{
								VT.PRI = null;
							}
						}
						else
						{
							VT.PRI = null;
						}
					}
				}
			}

			if( !VT.Target || VT.Target.bDeleteMe )
			{
				check(PCOwner);
				if( PCOwner.Pawn && !PCOwner.Pawn.bDeleteMe && !PCOwner.Pawn.bPendingDelete )
				{
					AssignViewTarget(PCOwner.Pawn, ref VT);
				}
				else
				{
					AssignViewTarget(PCOwner, ref VT);
				}
			}

			// Keep PlayerController in synch
			PCOwner.ViewTarget		= VT.Target;
			PCOwner.RealViewTarget	= VT.PRI;
		}
		
		void AssignViewTarget(Actor NewTarget, ref TViewTarget VT/*, struct FViewTargetTransitionParams TransitionParams*/)
		{
			if( !NewTarget || (NewTarget == VT.Target) )
			{
				return;
			}

			Actor OldViewTarget	= VT.Target;
			VT.Target				= NewTarget;
			// Set aspect ratio with default.
			VT.AspectRatio			= DefaultAspectRatio;

			// Set FOV with default.
			VT.POV.FOV				= DefaultFOV;

			VT.Target.BecomeViewTarget(PCOwner);
	
			if( OldViewTarget )
			{
				OldViewTarget.EndViewTarget(PCOwner);
			}

			if( !(PCOwner.Player && PCOwner.Player is LocalPlayer) && (WorldInfo.NetMode != WorldInfo.ENetMode.NM_Client) )
			{
				PCOwner.ClientSetViewTarget(VT.Target/*, TransitionParams*/);
				NativeMarkers.MarkUnimplemented();
			}
		}
	}
}