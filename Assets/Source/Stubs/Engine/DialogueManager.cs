namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DialogueManager : Actor/*
		notplaceable
		hidecategories(Navigation)*/{
	public virtual /*function */bool TriggerDialogueEvent(Core.ClassT<SequenceEvent> InEventClass, Actor InInstigator, Actor InOriginator)
	{
	
		return default;
	}
	
	public DialogueManager()
	{
		// Object Offset:0x0030CD12
		Components = new array</*export editinline */ActorComponent>
		{
			new SpriteComponent
			{
				// Object Offset:0x004CF8D6
				HiddenGame = true,
				AlwaysLoadOnClient = false,
				AlwaysLoadOnServer = false,
			}/* Reference: SpriteComponent'Default__DialogueManager.Sprite' */,
		};
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
	}
}
}