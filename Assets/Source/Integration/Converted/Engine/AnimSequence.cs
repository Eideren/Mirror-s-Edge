namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimSequence : Object/*
		native
		hidecategories(Object)*/{
	public enum AnimationCompressionFormat 
	{
		ACF_None,
		ACF_Float96NoW,
		ACF_Fixed48NoW,
		ACF_IntervalFixed32NoW,
		ACF_Fixed32NoW,
		ACF_Float32NoW,
		ACF_MAX
	};
	
	public partial struct /*native */AnimNotifyEvent
	{
		public/*()*/ float Time;
		public/*()*/ /*export editinline */AnimNotify Notify;
		public/*()*/ name Comment;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00294B8D
	//		Time = 0.0f;
	//		Notify = default;
	//		Comment = (name)"None";
	//	}
	};
	
	public partial struct /*native */RawAnimSequenceTrack
	{
		public array<Object.Vector> PosKeys;
		public array<Object.Quat> RotKeys;
		public array<float> KeyTimes;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00294D39
	//		PosKeys = default;
	//		RotKeys = default;
	//		KeyTimes = default;
	//	}
	};
	
	public partial struct /*native */TranslationTrack
	{
		public array<Object.Vector> PosKeys;
		public array<float> Times;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0029521D
	//		PosKeys = default;
	//		Times = default;
	//	}
	};
	
	public partial struct /*native */RotationTrack
	{
		public array<Object.Quat> RotKeys;
		public array<float> Times;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00295349
	//		RotKeys = default;
	//		Times = default;
	//	}
	};
	
	public partial struct /*native */CompressedTrack
	{
		public array<byte> ByteStream;
		public array<float> Times;
		public StaticArray<float, float, float>/*[3]*/ Mins;
		public StaticArray<float, float, float>/*[3]*/ Ranges;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002A08CC
	//		ByteStream = default;
	//		Times = default;
	//		Mins = new StaticArray<float, float, float>/*[3]*/()
	//		{ 
	//			[0] = 0.0f,
	//			[1] = 0.0f,
	//			[2] = 0.0f,
	// 		};
	//		Ranges = new StaticArray<float, float, float>/*[3]*/()
	//		{ 
	//			[0] = 0.0f,
	//			[1] = 0.0f,
	//			[2] = 0.0f,
	// 		};
	//	}
	};
	
	public name SequenceName;
	public/*()*/ /*editinline */array</*editinline */AnimSequence.AnimNotifyEvent> Notifies;
	public float SequenceLength;
	public int NumFrames;
	public/*()*/ float RateScale;
	public/*()*/ bool bNoLoopingInterpolation;
	public/*()*/ /*transient */bool bIgnoreInitialRootOffset;
	public /*private native const transient */bool bUsesHiMem;
	public /*const */array<AnimSequence.RawAnimSequenceTrack> RawAnimData;
	public /*const transient */array<AnimSequence.TranslationTrack> TranslationData;
	public /*const transient */array<AnimSequence.RotationTrack> RotationData;
	public/*()*/ /*editoronly editconst editinline */AnimationCompressionAlgorithm CompressionScheme;
	public /*const */AnimSequence.AnimationCompressionFormat TranslationCompressionFormat;
	public /*const */AnimSequence.AnimationCompressionFormat RotationCompressionFormat;
	public array<int> CompressedTrackOffsets;
	public /*native */array<byte> CompressedByteStream;
	public /*private native const transient */Object.Pointer CompressedOffsetPtr;
	public /*private native const transient */Object.Pointer CompressedStreamPtr;
	public /*private native const transient */int CompressedStreamSize;
	public /*private native const transient */int LapsMirror;
	
	public AnimSequence()
	{
		// Object Offset:0x002A09E4
		RateScale = 1.0f;
	}
}
}