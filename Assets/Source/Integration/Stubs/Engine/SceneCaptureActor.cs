namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SceneCaptureActor : Actor/*
		abstract
		native
		notplaceable
		hidecategories(Navigation)*/{
	[Category] [Const, export, editinline] public SceneCaptureComponent SceneCapture;
	
	public SceneCaptureActor()
	{
		var Default__SceneCaptureActor_Sprite = new SpriteComponent
		{
			// Object Offset:0x003A335C
			HiddenGame = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: SpriteComponent'Default__SceneCaptureActor.Sprite' */;
		// Object Offset:0x003A327D
		bNoDelete = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__SceneCaptureActor_Sprite/*Ref SpriteComponent'Default__SceneCaptureActor.Sprite'*/,
		};
		RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy;
	}
}
}