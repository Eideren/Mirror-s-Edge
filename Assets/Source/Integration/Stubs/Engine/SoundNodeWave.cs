namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SoundNodeWave : SoundNode/*
		native
		perobjectconfig
		editinlinenew
		hidecategories(Object,Object)*/{
	public enum EDecompressionType 
	{
		DTYPE_Setup,
		DTYPE_Invalid,
		DTYPE_Preview,
		DTYPE_Native,
		DTYPE_RealTime,
		DTYPE_MAX
	};
	
	public enum ETTSSpeaker 
	{
		TTSSPEAKER_Paul,
		TTSSPEAKER_Harry,
		TTSSPEAKER_Frank,
		TTSSPEAKER_Dennis,
		TTSSPEAKER_Kit,
		TTSSPEAKER_Betty,
		TTSSPEAKER_Ursula,
		TTSSPEAKER_Rita,
		TTSSPEAKER_Wendy,
		TTSSPEAKER_MAX
	};
	
	public partial struct /*native */SubtitleCue
	{
		[Category] [Const, localized] public String Text;
		[Category] [Const, localized] public float Time;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003EAEF9
	//		Text = "";
	//		Time = 0.0f;
	//	}
	};
	
	[Category("Compression")] public int CompressionQuality;
	[Category("Compression")] public bool bForceRealtimeDecompression;
	[Const, transient] public bool bDynamicResource;
	[Const, transient] public bool bOneTimeUse;
	[Category("TTS")] public bool bUseTTS;
	[Category("Subtitles")] public bool bAlwaysLocalise;
	[Category("Subtitles")] public bool bSuppressSubtitles;
	[Category("Subtitles")] [Const, localized] public bool bMature;
	[Category("Subtitles")] [Const, localized] public bool bManualWordWrap;
	[Category("Playstation3")] public bool bUseVolatileMemory;
	[Category("TTS")] public SoundNodeWave.ETTSSpeaker TTSSpeaker;
	[Const, transient] public SoundNodeWave.EDecompressionType DecompressionType;
	[Category("TTS")] [Const, localized] public String SpokenText;
	[Category("Info")] [Const, editconst] public float Volume;
	[Category("Info")] [Const, editconst] public float Pitch;
	[Category("Info")] [Const, editconst] public float Duration;
	[Category("Info")] [Const, editconst] public int NumChannels;
	[Category("Info")] [Const, editconst] public int SampleRate;
	[Const] public int SampleDataSize;
	[Const] public array<int> ChannelOffsets;
	[Const] public array<int> ChannelSizes;
	[native, Const] public Object.UntypedBulkData_Mirror RawData;
	[native, Const] public Object.Pointer RawPCMData;
	[native, Const] public Object.Pointer VorbisDecompressor;
	[Const, transient] public array<byte> PCMData;
	[native, Const] public Object.UntypedBulkData_Mirror CompressedPCData;
	[native, Const] public Object.UntypedBulkData_Mirror CompressedXbox360Data;
	[native, Const] public Object.UntypedBulkData_Mirror CompressedPS3Data;
	[Const, transient] public int ResourceID;
	[Const, transient] public int ResourceSize;
	[native, Const] public Object.Pointer ResourceData;
	[Category("Subtitles")] [Const, localized] public array</*localized */SoundNodeWave.SubtitleCue> Subtitles;
	[Category("Subtitles")] [Const, localized] public String Comment;
	
	public SoundNodeWave()
	{
		// Object Offset:0x003EAF69
		CompressionQuality = 40;
		Volume = 0.750f;
		Pitch = 1.0f;
	}
}
}