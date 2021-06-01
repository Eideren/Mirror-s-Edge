namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SpeechRecognition : Object/*
		native
		collapsecategories
		hidecategories(Object)*/{
	public partial struct /*native */RecognisableWord
	{
		public/*()*/ int Id;
		public/*()*/ String ReferenceWord;
		public/*()*/ String PhoneticWord;
	
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
		public/*()*/ array<SpeechRecognition.RecognisableWord> WhoDictionary;
		public/*()*/ array<SpeechRecognition.RecognisableWord> WhatDictionary;
		public/*()*/ array<SpeechRecognition.RecognisableWord> WhereDictionary;
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
	
	public/*()*/ String Language;
	public/*()*/ float ConfidenceThreshhold;
	public/*()*/ array<SpeechRecognition.RecogVocabulary> Vocabularies;
	public array<byte> VoiceData;
	public array<byte> WorkingVoiceData;
	public array<byte> UserData;
	public StaticArray<SpeechRecognition.RecogUserData, SpeechRecognition.RecogUserData, SpeechRecognition.RecogUserData, SpeechRecognition.RecogUserData>/*[4]*/ InstanceData;
	public /*duplicatetransient transient */bool bDirty;
	public /*duplicatetransient transient */bool bInitialised;
	public /*duplicatetransient native const */Object.Pointer FnxVoiceData;
	
	public SpeechRecognition()
	{
		// Object Offset:0x003EB86F
		Language = "INT";
		ConfidenceThreshhold = 50.0f;
	}
}
}