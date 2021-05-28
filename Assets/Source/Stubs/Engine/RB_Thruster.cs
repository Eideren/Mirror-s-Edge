namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_Thruster : Actor/*
		native
		placeable
		hidecategories(Navigation)*/{
	public/*()*/ bool bThrustEnabled;
	public/*()*/ /*interp */float ThrustStrength;
	
	public virtual /*simulated function */void OnToggle(SeqAct_Toggle Action)
	{
	
	}
	
	public RB_Thruster()
	{
		// Object Offset:0x003B01CC
		ThrustStrength = 100.0f;
		bHardAttach = true;
		bEdShouldSnap = true;
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new ArrowComponent
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
			}/* Reference: ArrowComponent'Default__RB_Thruster.ArrowComponent0' */,
			//Components[1]=
			new SpriteComponent
			{
				// Object Offset:0x004D04EA
				Sprite = LoadAsset<Texture2D>("EngineResources.S_Thruster")/*Ref Texture2D'EngineResources.S_Thruster'*/,
				HiddenGame = true,
				AlwaysLoadOnClient = false,
				AlwaysLoadOnServer = false,
			}/* Reference: SpriteComponent'Default__RB_Thruster.Sprite' */,
		};
	}
}
}