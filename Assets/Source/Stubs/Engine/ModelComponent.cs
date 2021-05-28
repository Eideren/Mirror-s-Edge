namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ModelComponent : PrimitiveComponent/*
		native
		noexport*/{
	public /*native const noexport transient */Object Model;
	public /*native const noexport transient */int ZoneIndex;
	public /*native const noexport transient */int ComponentIndex;
	public /*native const noexport transient */array<Object.Pointer> Nodes;
	public /*native const noexport transient */array<Object.Pointer> Edges;
	public /*native const noexport transient */array<Object.Pointer> Elements;
	
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