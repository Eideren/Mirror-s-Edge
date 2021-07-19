namespace MEdge.Editor{
using Core; using Engine; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class LightingChannelsObject : Object/*
		native
		hidecategories(Object)*/{
	[Category] [Const] public LightComponent.LightingChannelContainer LightingChannels;
	
	public LightingChannelsObject()
	{
		// Object Offset:0x00012773
		LightingChannels = new LightComponent.LightingChannelContainer
		{
			bInitialized = true,
			BSP = false,
			Static = false,
			Dynamic = false,
			CompositeDynamic = false,
			Skybox = false,
			Unnamed_1 = false,
			Unnamed_2 = false,
			Unnamed_3 = false,
			Unnamed_4 = false,
			Unnamed_5 = false,
			Unnamed_6 = false,
			Cinematic_1 = false,
			Cinematic_2 = false,
			Cinematic_3 = false,
			Cinematic_4 = false,
			Cinematic_5 = false,
			Cinematic_6 = false,
			Gameplay_1 = false,
			Gameplay_2 = false,
			Gameplay_3 = false,
			Gameplay_4 = false,
		};
	}
}
}