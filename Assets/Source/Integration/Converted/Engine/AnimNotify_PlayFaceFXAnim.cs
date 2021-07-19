namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimNotify_PlayFaceFXAnim : AnimNotify_Scripted/*
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	[Category] public FaceFXAnimSet FaceFXAnimSetRef;
	[Category] public String GroupName;
	[Category] public String AnimName;
	[Category] public bool bOverridePlayingAnim;
	[Category] public float PlayFrequency;
	
	public override /*event */void Notify(Actor Owner, AnimNodeSequence AnimSeqInstigator)
	{
		if(PlayFrequency < 1.0f)
		{
			if(FRand() > PlayFrequency)
			{
				return;
			}		
		}
		else
		{
			if(PlayFrequency > 1.0f)
			{
			}
		}
		if(Owner != default)
		{
			if(!bOverridePlayingAnim && Owner.IsActorPlayingFaceFXAnim())
			{
				return;
			}
			Owner.PlayActorFaceFXAnim(FaceFXAnimSetRef, GroupName, AnimName);
		}
	}
	
	public AnimNotify_PlayFaceFXAnim()
	{
		// Object Offset:0x0029FEBD
		bOverridePlayingAnim = true;
		PlayFrequency = 1.0f;
	}
}
}