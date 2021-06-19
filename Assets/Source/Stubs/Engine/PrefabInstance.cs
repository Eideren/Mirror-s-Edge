namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PrefabInstance : Actor/*
		native
		notplaceable
		hidecategories(Navigation)*/{
	public /*const */Prefab TemplatePrefab;
	public /*const */int TemplateVersion;
	public /*native const *//*map<0,0>*/map<object, object> ArchetypeToInstanceMap;
	public /*const */Sequence SequenceInstance;
	public /*const */int PI_PackageVersion;
	public /*const */int PI_LicenseePackageVersion;
	public /*const */array<byte> PI_Bytes;
	public /*const */array<Object> PI_CompleteObjects;
	public /*const */array<Object> PI_ReferencedObjects;
	public /*const */array<String> PI_SavedNames;
	public /*native const *//*map<0,0>*/map<object, object> PI_ObjectMap;
	
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