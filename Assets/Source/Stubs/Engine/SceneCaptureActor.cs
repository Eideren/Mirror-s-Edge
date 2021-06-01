namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SceneCaptureActor : Actor/*
		abstract
		native
		notplaceable
		hidecategories(Navigation)*/{
	public/*()*/ /*const export editinline */SceneCaptureComponent SceneCapture;
	
	public SceneCaptureActor()
	{
		// Object Offset:0x003A327D
		bNoDelete = true;
		Components = new array</*export editinline */ActorComponent>
		{
			new SpriteComponent
			{
				// Object Offset:0x003A335C
				HiddenGame = true,
				AlwaysLoadOnClient = false,
				AlwaysLoadOnServer = false,
			}/* Reference: SpriteComponent'Default__SceneCaptureActor.Sprite' */,
		};
		RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy;
	}
}
}