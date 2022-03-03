namespace MEdge.Engine{
	using System;using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimNotify_Sound : AnimNotify/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	[Category] public SoundCue SoundCue;
	[Category] public bool bFollowActor;
	[Category] public name BoneName;



	public override void Notify( AnimNodeSequence NodeSeq )
	{
		SkeletalMeshComponent SkelComp = NodeSeq.SkelComponent;
		check( SkelComp );

		Actor Owner = SkelComp.GetOwner();
		if( BoneName != NAME_None )
		{
			UWorldBridge.GetUWorld().PlaySoundCue(SoundCue, Owner, false, SkelComp.GetBoneLocation( BoneName ) );
		}                  
		else if( !(bFollowActor && Owner) )
		{
			UWorldBridge.GetUWorld().PlaySoundCue(SoundCue, Owner, false, SkelComp.LocalToWorld.GetOrigin() );
		}
		/*AudioComponent AudioComponent = UAudioDevice::CreateComponent( SoundCue, SkelComp.GetScene(), Owner, 0 );
		if( AudioComponent )
		{
			if( BoneName != NAME_None )
			{
				AudioComponent.bUseOwnerLocation	= 0;
				AudioComponent.Location			= SkelComp.GetBoneLocation( BoneName );
			}                  
			else if( !(bFollowActor && Owner) )
			{	
				AudioComponent.bUseOwnerLocation	= 0;
				AudioComponent.Location			= SkelComp->LocalToWorld.GetOrigin();
			}

			AudioComponent.bAllowSpatialization	&= GIsGame;
			AudioComponent.bIsUISound			= !GIsGame;
			AudioComponent.bAutoDestroy			= 1;
			AudioComponent.SubtitlePriority		= SUBTITLE_PRIORITY_ANIMNOTIFY;
			AudioComponent.Play();
		}*/
	}



	public AnimNotify_Sound()
	{
		// Object Offset:0x002A00A3
		bFollowActor = true;
	}
}
}