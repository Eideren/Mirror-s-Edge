namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Note : Actor/*
		native
		placeable
		hidecategories(Navigation)*/{
	public/*()*/ String Text;
	
	public Note()
	{
		var Default__Note_Arrow = new ArrowComponent
		{
			// Object Offset:0x00465BD7
			ArrowColor = new Color
			{
				R=150,
				G=200,
				B=255,
				A=255
			},
			ArrowSize = 0.50f,
		}/* Reference: ArrowComponent'Default__Note.Arrow' */;
		var Default__Note_Sprite = new SpriteComponent
		{
			// Object Offset:0x004CFE6A
			Sprite = LoadAsset<Texture2D>("EngineResources.S_Note")/*Ref Texture2D'EngineResources.S_Note'*/,
			HiddenGame = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: SpriteComponent'Default__Note.Sprite' */;
		// Object Offset:0x0035EC72
		bStatic = true;
		bHidden = true;
		bNoDelete = true;
		bMovable = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__Note_Arrow,
			Default__Note_Sprite,
		};
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
	}
}
}