namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ShadowMap2D : Object/*
		native
		noexport*/{
	[Const] public/*private*/ ShadowMapTexture2D Texture;
	[Const] public/*private*/ Object.Vector2D CoordinateScale;
	[Const] public/*private*/ Object.Vector2D CoordinateBias;
	[Const] public/*private*/ Object.Guid LightGuid;
	
}
}