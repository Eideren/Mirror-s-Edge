namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PrefabInstance : Actor/*
		native
		notplaceable
		hidecategories(Navigation)*/{
	[Const] public Prefab TemplatePrefab;
	[Const] public int TemplateVersion;
	[native, Const] public /*map<0,0>*/map<object, object> ArchetypeToInstanceMap;
	[Const] public Sequence SequenceInstance;
	[Const] public int PI_PackageVersion;
	[Const] public int PI_LicenseePackageVersion;
	[Const] public array<byte> PI_Bytes;
	[Const] public array<Object> PI_CompleteObjects;
	[Const] public array<Object> PI_ReferencedObjects;
	[Const] public array<String> PI_SavedNames;
	[native, Const] public /*map<0,0>*/map<object, object> PI_ObjectMap;
	
	public PrefabInstance()
	{
		var Default__PrefabInstance_Sprite = new SpriteComponent
		{
			// Object Offset:0x004D00EE
			Sprite = LoadAsset<Texture2D>("EngineResources.PrefabSprite")/*Ref Texture2D'EngineResources.PrefabSprite'*/,
			HiddenGame = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: SpriteComponent'Default__PrefabInstance.Sprite' */;
		// Object Offset:0x003A7FF2
		PI_PackageVersion = -1;
		PI_LicenseePackageVersion = -1;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__PrefabInstance_Sprite/*Ref SpriteComponent'Default__PrefabInstance.Sprite'*/,
		};
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
	}
}
}