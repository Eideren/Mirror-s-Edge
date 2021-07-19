namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SpeechRecognition : Object/*
		native
		collapsecategories
		hidecategories(Object)*/{
	public partial struct /*native */RecognisableWord
	{
		[Category] public int Id;
		[Category] public String ReferenceWord;
		[Category] public String PhoneticWord;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003EB22B
	//		Id = 0;
	//		ReferenceWord = "";
	//		PhoneticWord = "";
	//	}
	};
	
	public partial struct /*native */RecogVocabulary
	{
		[Category] public array<SpeechRecognition.RecognisableWord> WhoDictionary;
		[Category] public array<SpeechRecognition.RecognisableWord> WhatDictionary;
		[Category] public array<SpeechRecognition.RecognisableWord> WhereDictionary;
		public String VocabName;
		public array<byte> VocabData;
		public array<byte> WorkingVocabData;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003EB4C3
	//		WhoDictionary = default;
	//		WhatDictionary = default;
	//		WhereDictionary = default;
	//		VocabName = "";
	//		VocabData = default;
	//		WorkingVocabData = default;
	//	}
	};
	
	public partial struct /*native */RecogUserData
	{
		public int ActiveVocabularies;
		public array<byte> UserData;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003EB62F
	//		ActiveVocabularies = 0;
	//		UserData = default;
	//	}
	};
	
	[Category] public String Language;
	[Category] public float ConfidenceThreshhold;
	[Category] public array<SpeechRecognition.RecogVocabulary> Vocabularies;
	public array<byte> VoiceData;
	public array<byte> WorkingVoiceData;
	public array<byte> UserData;
	public StaticArray<SpeechRecognition.RecogUserData, SpeechRecognition.RecogUserData, SpeechRecognition.RecogUserData, SpeechRecognition.RecogUserData>/*[4]*/ InstanceData;
	[duplicatetransient, transient] public bool bDirty;
	[duplicatetransient, transient] public bool bInitialised;
	[duplicatetransient, native, Const] public Object.Pointer FnxVoiceData;
	
	public SpeechRecognition()
	{
		// Object Offset:0x003EB86F
		Language = "INT";
		ConfidenceThreshhold = 50.0f;
	}
}
}