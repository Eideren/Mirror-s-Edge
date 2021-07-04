namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_CrossFadeMusicTracks : SeqAct_Latent/*
		native
		hidecategories(Object)*/{
	public/*()*/ name TrackBankName;
	public name CurrTrackType;
	public /*export editinline */AudioComponent CurrPlayingTrack;
	public float AdjustVolumeDuration;
	public float AdjustVolumeLevel;
	public float NextTrackToPlayAt;
	public MusicTrackDataStructures.MusicTrackStruct NextTrackToPlay;
	
	// Export USeqAct_CrossFadeMusicTracks::execCrossFadeTrack(FFrame&, void* const)
	public virtual /*native final function */void CrossFadeTrack(/*const */ref MusicTrackDataStructures.MusicTrackStruct TrackToPlay)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export USeqAct_CrossFadeMusicTracks::execClientSideCrossFadeTrackImmediately(FFrame&, void* const)
	public virtual /*native final function */void ClientSideCrossFadeTrackImmediately(/*const */ref MusicTrackDataStructures.MusicTrackStruct TrackToPlay)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export USeqAct_CrossFadeMusicTracks::execStopAllMusicManagerSounds(FFrame&, void* const)
	public /*native function */static void StopAllMusicManagerSounds()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public SeqAct_CrossFadeMusicTracks()
	{
		// Object Offset:0x003BC2AF
		NextTrackToPlay = new MusicTrackDataStructures.MusicTrackStruct
		{
			Params = new MusicTrackDataStructures.MusicTrackParamStruct
			{
				FadeInTime = 5.0f,
				FadeInVolumeLevel = 1.0f,
				DelayBetweenOldAndNewTrack = 0.0f,
				FadeOutTime = 5.0f,
				FadeOutVolumeLevel = 0.0f,
			},
			TrackType = (name)"None",
			TheSoundCue = default,
			bAutoPlay = false,
		};
		InputLinks = new array<SequenceOp.SeqOpInputLink>
		{
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "CrossFade",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "CrossFade To Custom",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "CrossFade To Track's FadeOutVolumeLevel",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Adjust Volume of Currently Playing Track",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
		};
		OutputLinks = new array<SequenceOp.SeqOpOutputLink>
		{
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Out",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				ActivateDelay = 0.0f,
				DrawY = 0,
				bHidden = false,
			},
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Aborted",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				ActivateDelay = 0.0f,
				DrawY = 0,
				bHidden = false,
			},
		};
		VariableLinks = new array<SequenceOp.SeqVarLink>
		{
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_String>()/*Ref Class'SeqVar_String'*/,
				LinkedVariables = default,
				LinkDesc = "TrackTypeToFadeTo",
				LinkVar = (name)"None",
				PropertyName = (name)"None",
				bWriteable = false,
				bHidden = false,
				MinVars = 1,
				MaxVars = 1,
				DrawX = 0,
				CachedProperty = default,
			},
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_MusicTrackBank>()/*Ref Class'SeqVar_MusicTrackBank'*/,
				LinkedVariables = default,
				LinkDesc = "MusicTrackBank",
				LinkVar = (name)"None",
				PropertyName = (name)"None",
				bWriteable = false,
				bHidden = false,
				MinVars = 1,
				MaxVars = 1,
				DrawX = 0,
				CachedProperty = default,
			},
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_MusicTrack>()/*Ref Class'SeqVar_MusicTrack'*/,
				LinkedVariables = default,
				LinkDesc = "CustomMusicTrack",
				LinkVar = (name)"None",
				PropertyName = (name)"None",
				bWriteable = false,
				bHidden = false,
				MinVars = 1,
				MaxVars = 1,
				DrawX = 0,
				CachedProperty = default,
			},
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Float>()/*Ref Class'SeqVar_Float'*/,
				LinkedVariables = default,
				LinkDesc = "AdjustVolumeDuration",
				LinkVar = (name)"None",
				PropertyName = (name)"None",
				bWriteable = false,
				bHidden = false,
				MinVars = 1,
				MaxVars = 1,
				DrawX = 0,
				CachedProperty = default,
			},
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Float>()/*Ref Class'SeqVar_Float'*/,
				LinkedVariables = default,
				LinkDesc = "AdjustVolumeLevel",
				LinkVar = (name)"None",
				PropertyName = (name)"None",
				bWriteable = false,
				bHidden = false,
				MinVars = 1,
				MaxVars = 1,
				DrawX = 0,
				CachedProperty = default,
			},
		};
		ObjClassVersion = 5;
		ObjName = "CrossFadeMusicTracks";
		ObjCategory = "Sound";
	}
}
}