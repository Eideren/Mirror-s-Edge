namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TextureRenderTarget : Texture/*
		abstract
		native*/{
	public /*transient */bool bUpdateImmediate;
	public/*()*/ bool bNeedsTwoCopies;
	public/*()*/ bool bRenderOnce;
	
	public TextureRenderTarget()
	{
		// Object Offset:0x003FEB10
		bNeedsTwoCopies = true;
		CompressionNone = true;
		NeverStream = true;
		LODGroup = Texture.TextureGroup.TEXTUREGROUP_RenderTarget;
	}
}
}