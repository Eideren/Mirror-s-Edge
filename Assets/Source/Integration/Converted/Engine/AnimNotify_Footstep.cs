namespace MEdge.Engine{
	using System;using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimNotify_Footstep : AnimNotify/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	[Category] public int FootDown;
	
	public override void Notify( AnimNodeSequence NodeSeq )
	{
		Actor Owner = (NodeSeq && NodeSeq.SkelComponent) ? NodeSeq.SkelComponent.GetOwner() : null;

		if( !Owner )
		{
			// This should not be the case in the game, so generate a warning.
			/*if( GWorld->HasBegunPlay() )
			{
				debugf(TEXT("FOOTSTEP no owner"));
			}*/
		}
		else
		{
			//debugf(TEXT("FOOTSTEP for %s"),*Owner->GetName());

			// Act on footstep...  FootDown signifies which paw hits earth 0=left, 1=right, 2=left-hindleg etc.
			if( (Owner is Pawn) )
			{
				(Owner as Pawn).PlayFootStepSound(FootDown);
			}
		}
	}
}
}