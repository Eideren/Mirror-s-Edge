namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RequestedTextureResources : Object/*
		native*/{
	[transient] public/*private*/ String Filename;
	[native, Const] public Object.Map_Mirror TextureResourceInformation;
	
}
}