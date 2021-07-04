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
	
	public /*const */int SizeX;
	public /*const */int SizeY;
	public /*const */Texture.EPixelFormat Format;
	public/*()*/ Texture.TextureAddress AddressX;
	public/*()*/ Texture.TextureAddress AddressY;
	public/*()*/ TextureMovie.EMovieStreamSource MovieStreamSource;
	public /*const */Core.ClassT<CodecMovie> DecoderClass;
	public /*const transient */CodecMovie Decoder;
	public /*const */bool Paused;
	public /*const */bool Stopped;
	public/*()*/ bool Looping;
	public/*()*/ bool AutoPlay;
	public /*native const */Object.UntypedBulkData_Mirror Data;
	public /*native const transient */Object.Pointer ReleaseCodecFence;
	
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