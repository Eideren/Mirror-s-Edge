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
		[Category] public float Time;
		[Category] [export, editinline] public AnimNotify Notify;
		[Category] public name Comment;
	
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
	[Category] [editinline] public array</*editinline */AnimSequence.AnimNotifyEvent> Notifies;
	public float SequenceLength;
	public int NumFrames;
	[Category] public float RateScale;
	[Category] public bool bNoLoopingInterpolation;
	[Category] [transient] public bool bIgnoreInitialRootOffset;
	[native, Const, transient] public/*private*/ bool bUsesHiMem;
	[Const] public array<AnimSequence.RawAnimSequenceTrack> RawAnimData;
	[Const, transient] public array<AnimSequence.TranslationTrack> TranslationData;
	[Const, transient] public array<AnimSequence.RotationTrack> RotationData;
	[Category] [editoronly, editconst, editinline] public AnimationCompressionAlgorithm CompressionScheme;
	[Const] public AnimSequence.AnimationCompressionFormat TranslationCompressionFormat;
	[Const] public AnimSequence.AnimationCompressionFormat RotationCompressionFormat;
	public array<int> CompressedTrackOffsets;
	[native] public array<byte> CompressedByteStream;
	[native, Const, transient] public/*private*/ Object.Pointer CompressedOffsetPtr;
	[native, Const, transient] public/*private*/ Object.Pointer CompressedStreamPtr;
	[native, Const, transient] public/*private*/ int CompressedStreamSize;
	[native, Const, transient] public/*private*/ int LapsMirror;
	
	public AnimSequence()
	{
		// Object Offset:0x002A09E4
		RateScale = 1.0f;
	}
}
}