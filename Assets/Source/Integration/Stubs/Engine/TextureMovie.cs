namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TextureMovie : Texture/*
		native
		hidecategories(Object)*/{
	public enum EMovieStreamSource 
	{
		MovieStream_File,
		MovieStream_Memory,
		MovieStream_MAX
	};
	
	[Const] public int SizeX;
	[Const] public int SizeY;
	[Const] public Texture.EPixelFormat Format;
	[Category] public Texture.TextureAddress AddressX;
	[Category] public Texture.TextureAddress AddressY;
	[Category] public TextureMovie.EMovieStreamSource MovieStreamSource;
	[Const] public Core.ClassT<CodecMovie> DecoderClass;
	[Const, transient] public CodecMovie Decoder;
	[Const] public bool Paused;
	[Const] public bool Stopped;
	[Category] public bool Looping;
	[Category] public bool AutoPlay;
	[native, Const] public Object.UntypedBulkData_Mirror Data;
	[native, Const, transient] public Object.Pointer ReleaseCodecFence;
	
	// Export UTextureMovie::execPlay(FFrame&, void* const)
	public virtual /*native function */void Play()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTextureMovie::execPause(FFrame&, void* const)
	public virtual /*native function */void Pause()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTextureMovie::execStop(FFrame&, void* const)
	public virtual /*native function */void Stop()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public TextureMovie()
	{
		// Object Offset:0x003FE965
		DecoderClass = ClassT<CodecMovieFallback>()/*Ref Class'CodecMovieFallback'*/;
		Stopped = true;
		Looping = true;
		AutoPlay = true;
		NeverStream = true;
	}
}
}