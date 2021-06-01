namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AmbientSound : Keypoint/*
		native
		placeable
		hidecategories(Navigation)*/{
	public/*()*/ bool bAutoPlay;
	public /*private */bool bIsPlaying;
	public/*(Audio)*/ /*const editconst export editinline */AudioComponent AudioComponent;
	
	public AmbientSound()
	{
		// Object Offset:0x0028F043
		bAutoPlay = true;
		AudioComponent = new AudioComponent
		{
			// Object Offset:0x0028F162
			bStopWhenOwnerDestroyed = true,
			bShouldRemainActiveIfDropped = true,
		}/* Reference: AudioComponent'Default__AmbientSound.AudioComponent0' */;
		Components = new array</*export editinline */ActorComponent>
		{
			new SpriteComponent
			{
				// Object Offset:0x0028F12E
				Sprite = LoadAsset<Texture2D>("EngineResources.S_Ambient")/*Ref Texture2D'EngineResources.S_Ambient'*/,
			}/* Reference: SpriteComponent'Default__AmbientSound.Sprite' */,
			new AudioComponent
			{
				// Object Offset:0x0028F162
				bStopWhenOwnerDestroyed = true,
				bShouldRemainActiveIfDropped = true,
			}/* Reference: AudioComponent'Default__AmbientSound.AudioComponent0' */,
		};
	}
}
}