namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ModelComponent : PrimitiveComponent/*
		native
		noexport*/{
	[native, Const, noexport, transient] public Object Model;
	[native, Const, noexport, transient] public int ZoneIndex;
	[native, Const, noexport, transient] public int ComponentIndex;
	[native, Const, noexport, transient] public array<Object.Pointer> Nodes;
	[native, Const, noexport, transient] public array<Object.Pointer> Edges;
	[native, Const, noexport, transient] public array<Object.Pointer> Elements;
	
	public ModelComponent()
	{
		// Object Offset:0x0035CACC
		bUseAsOccluder = true;
		bAcceptsDecals = true;
		CastShadow = true;
		bAcceptsLights = true;
		LightingChannels = new LightComponent.LightingChannelContainer
		{
			bInitialized = true,
			BSP = true,
		};
		bUsePrecomputedShadows = true;
		bCullModulatedShadowOnBackfaces = true;
	}
}
}