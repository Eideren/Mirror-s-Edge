// NO OVERWRITE

namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimNotify_Scripted : AnimNotify/*
		abstract
		native
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	public virtual /*event */void Notify(Actor Owner, AnimNodeSequence AnimSeqInstigator)
	{
		
	}



	public override /*event */ void Notify( AnimNodeSequence NodeSeq )
	{
		Actor Owner = NodeSeq.SkelComponent.GetOwner();
		if( Owner )
		{
			/*if( !GWorld->HasBegunPlay() )
			{
				debugf( NAME_Log, TEXT("Editor: skipping AnimNotify_Scripted %s"), *GetName() );
			}
			else*/
			{
				Notify( Owner, NodeSeq );
			}
		}
	}

}
}