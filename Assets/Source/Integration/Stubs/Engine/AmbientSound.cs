namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AmbientSound : Keypoint/*
		native
		placeable
		hidecategories(Navigation)*/{
	[Category] public bool bAutoPlay;
	public/*private*/ bool bIsPlaying;
	[Category("Audio")] [Const, editconst, export, editinline] public AudioComponent AudioComponent;
	
	public AmbientSound()
	{
		var Default__AmbientSound_AudioComponent0 = new AudioComponent
		{
			// Object Offset:0x0028F162
			bStopWhenOwnerDestroyed = true,
			bShouldRemainActiveIfDropped = true,
		}/* Reference: AudioComponent'Default__AmbientSound.AudioComponent0' */;
		var Default__AmbientSound_Sprite = new SpriteComponent
		{
			// Object Offset:0x0028F12E
			Sprite = LoadAsset<Texture2D>("EngineResources.S_Ambient")/*Ref Texture2D'EngineResources.S_Ambient'*/,
		}/* Reference: SpriteComponent'Default__AmbientSound.Sprite' */;
		// Object Offset:0x0028F043
		bAutoPlay = true;
		AudioComponent = Default__AmbientSound_AudioComponent0/*Ref AudioComponent'Default__AmbientSound.AudioComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__AmbientSound_Sprite/*Ref SpriteComponent'Default__AmbientSound.Sprite'*/,
			Default__AmbientSound_AudioComponent0/*Ref AudioComponent'Default__AmbientSound.AudioComponent0'*/,
		};
	}
}
}