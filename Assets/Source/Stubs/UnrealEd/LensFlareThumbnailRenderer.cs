namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class LensFlareThumbnailRenderer : TextureThumbnailRenderer/*
		native*/{
	public Texture2D NoImage;
	public Texture2D OutOfDate;
	
	public LensFlareThumbnailRenderer()
	{
		// Object Offset:0x00025123
		NoImage = LoadAsset<Texture2D>("EditorMaterials.ParticleSystems.PSysThumbnail_NoImage")/*Ref Texture2D'EditorMaterials.ParticleSystems.PSysThumbnail_NoImage'*/;
		OutOfDate = LoadAsset<Texture2D>("EditorMaterials.ParticleSystems.PSysThumbnail_OOD")/*Ref Texture2D'EditorMaterials.ParticleSystems.PSysThumbnail_OOD'*/;
	}
}
}