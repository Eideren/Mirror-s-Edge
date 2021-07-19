namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_Thruster : Actor/*
		native
		placeable
		hidecategories(Navigation)*/{
	[Category] public bool bThrustEnabled;
	[Category] [interp] public float ThrustStrength;
	
	public virtual /*simulated function */void OnToggle(SeqAct_Toggle Action)
	{
		// stub
	}
	
	public RB_Thruster()
	{
		var Default__RB_Thruster_ArrowComponent0 = new ArrowComponent
		{
			// Object Offset:0x00465D77
			ArrowColor = new Color
			{
				R=255,
				G=180,
				B=0,
				A=255
			},
			ArrowSize = 1.70f,
		}/* Reference: ArrowComponent'Default__RB_Thruster.ArrowComponent0' */;
		var Default__RB_Thruster_Sprite = new SpriteComponent
		{
			// Object Offset:0x004D04EA
			Sprite = LoadAsset<Texture2D>("EngineResources.S_Thruster")/*Ref Texture2D'EngineResources.S_Thruster'*/,
			HiddenGame = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: SpriteComponent'Default__RB_Thruster.Sprite' */;
		// Object Offset:0x003B01CC
		ThrustStrength = 100.0f;
		bHardAttach = true;
		bEdShouldSnap = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__RB_Thruster_ArrowComponent0/*Ref ArrowComponent'Default__RB_Thruster.ArrowComponent0'*/,
			Default__RB_Thruster_Sprite/*Ref SpriteComponent'Default__RB_Thruster.Sprite'*/,
		};
	}
}
}