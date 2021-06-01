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
		public/*()*/ /*const localized */String Text;
		public/*()*/ /*const localized */float Time;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003EAEF9
	//		Text = "";
	//		Time = 0.0f;
	//	}
	};
	
	public/*(Compression)*/ int CompressionQuality;
	public/*(Compression)*/ bool bForceRealtimeDecompression;
	public /*const transient */bool bDynamicResource;
	public /*const transient */bool bOneTimeUse;
	public/*(TTS)*/ bool bUseTTS;
	public/*(Subtitles)*/ bool bAlwaysLocalise;
	public/*(Subtitles)*/ bool bSuppressSubtitles;
	public/*(Subtitles)*/ /*const localized */bool bMature;
	public/*(Subtitles)*/ /*const localized */bool bManualWordWrap;
	public/*(Playstation3)*/ bool bUseVolatileMemory;
	public/*(TTS)*/ SoundNodeWave.ETTSSpeaker TTSSpeaker;
	public /*const transient */SoundNodeWave.EDecompressionType DecompressionType;
	public/*(TTS)*/ /*const localized */String SpokenText;
	public/*(Info)*/ /*const editconst */float Volume;
	public/*(Info)*/ /*const editconst */float Pitch;
	public/*(Info)*/ /*const editconst */float Duration;
	public/*(Info)*/ /*const editconst */int NumChannels;
	public/*(Info)*/ /*const editconst */int SampleRate;
	public /*const */int SampleDataSize;
	public /*const */array<int> ChannelOffsets;
	public /*const */array<int> ChannelSizes;
	public /*native const */Object.UntypedBulkData_Mirror RawData;
	public /*native const */Object.Pointer RawPCMData;
	public /*native const */Object.Pointer VorbisDecompressor;
	public /*const transient */array<byte> PCMData;
	public /*native const */Object.UntypedBulkData_Mirror CompressedPCData;
	public /*native const */Object.UntypedBulkData_Mirror CompressedXbox360Data;
	public /*native const */Object.UntypedBulkData_Mirror CompressedPS3Data;
	public /*const transient */int ResourceID;
	public /*const transient */int ResourceSize;
	public /*native const */Object.Pointer ResourceData;
	public/*(Subtitles)*/ /*const localized */array</*localized */SoundNodeWave.SubtitleCue> Subtitles;
	public/*(Subtitles)*/ /*const localized */String Comment;
	
	public SoundNodeWave()
	{
		// Object Offset:0x003EAF69
		CompressionQuality = 40;
		Volume = 0.750f;
		Pitch = 1.0f;
	}
}
}