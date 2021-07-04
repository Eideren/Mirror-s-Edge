namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class OnlineSubsystem : Object/*
		abstract
		native*/{
	public enum ELoginStatus 
	{
		LS_NotLoggedIn,
		LS_UsingLocalProfile,
		LS_LoggedIn,
		LS_MAX
	};
	
	public enum EFeaturePrivilegeLevel 
	{
		FPL_Disabled,
		FPL_EnabledFriendsOnly,
		FPL_Enabled,
		FPL_MAX
	};
	
	public enum ENetworkNotificationPosition 
	{
		NNP_TopLeft,
		NNP_TopCenter,
		NNP_TopRight,
		NNP_CenterLeft,
		NNP_Center,
		NNP_CenterRight,
		NNP_BottomLeft,
		NNP_BottomCenter,
		NNP_BottomRight,
		NNP_MAX
	};
	
	public enum EOnlineGameState 
	{
		OGS_NoSession,
		OGS_Pending,
		OGS_InProgress,
		OGS_Ending,
		OGS_Ended,
		OGS_MAX
	};
	
	public enum EOnlineEnumerationReadState 
	{
		OERS_NotStarted,
		OERS_InProgress,
		OERS_Done,
		OERS_Failed,
		OERS_MAX
	};
	
	public enum PlayGroupLeaveReason 
	{
		kPGLR_Disconnected,
		kPGLR_Kicked,
		kPGLR_MAX
	};
	
	public enum EOnlineServerConnectionStatus 
	{
		OSCS_NotConnected,
		OSCS_Connected,
		OSCS_ConnectionDropped,
		OSCS_NoNetworkConnection,
		OSCS_ServiceUnavailable,
		OSCS_UpdateRequired,
		OSCS_ServersTooBusy,
		OSCS_DuplicateLoginDetected,
		OSCS_InvalidUser,
		OSCS_MAX
	};
	
	public enum ENATType 
	{
		NAT_Unknown,
		NAT_Open,
		NAT_Moderate,
		NAT_Strict,
		NAT_MAX
	};
	
	public enum ELanBeaconState 
	{
		LANB_NotUsingLanBeacon,
		LANB_Hosting,
		LANB_Searching,
		LANB_MAX
	};
	
	public enum EOnlineAccountCreateStatus 
	{
		OACS_CreateSuccessful,
		OACS_UnknownError,
		OACS_InvalidUserName,
		OACS_InvalidPassword,
		OACS_InvalidUniqueUserName,
		OACS_UniqueUserNameInUse,
		OACS_ServiceUnavailable,
		OACS_MAX
	};
	
	public partial struct /*native */UniqueNetId
	{
		public StaticArray<byte, byte, byte, byte, byte, byte, byte, byte>/*[8]*/ Uid;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0026006A
	//		Uid = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte>/*[8]*/()
	//		{ 
	//			[0] = 0,
	//			[1] = 0,
	//			[2] = 0,
	//			[3] = 0,
	//			[4] = 0,
	//			[5] = 0,
	//			[6] = 0,
	//			[7] = 0,
	// 		};
	//	}
	};
	
	public partial struct /*native */FriendsQuery
	{
		public OnlineSubsystem.UniqueNetId UniqueId;
		public bool bIsFriend;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0028607B
	//		UniqueId = new OnlineSubsystem.UniqueNetId
	//		{
	//			Uid = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte>/*[8]*/()
	//			{
	//				[0] = 0,
	//				[1] = 0,
	//				[2] = 0,
	//				[3] = 0,
	//				[4] = 0,
	//				[5] = 0,
	//				[6] = 0,
	//				[7] = 0,
	//			},
	//		};
	//		bIsFriend = false;
	//	}
	};
	
	public partial struct /*native */OnlineFriend
	{
		public /*const */OnlineSubsystem.UniqueNetId UniqueId;
		public /*const */String NickName;
		public /*const */String PresenceInfo;
		public /*const */bool bIsOnline;
		public /*const */bool bIsPlaying;
		public /*const */bool bIsPlayingThisGame;
		public /*const */bool bIsJoinable;
		public /*const */bool bHasVoiceSupport;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00286413
	//		UniqueId = new OnlineSubsystem.UniqueNetId
	//		{
	//			Uid = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte>/*[8]*/()
	//			{
	//				[0] = 0,
	//				[1] = 0,
	//				[2] = 0,
	//				[3] = 0,
	//				[4] = 0,
	//				[5] = 0,
	//				[6] = 0,
	//				[7] = 0,
	//			},
	//		};
	//		NickName = "";
	//		PresenceInfo = "";
	//		bIsOnline = false;
	//		bIsPlaying = false;
	//		bIsPlayingThisGame = false;
	//		bIsJoinable = false;
	//		bHasVoiceSupport = false;
	//	}
	};
	
	public partial struct /*native */OnlinePlayer
	{
		public /*const */OnlineSubsystem.UniqueNetId UniqueId;
		public /*const */String NickName;
		public /*const */String PresenceInfo;
		public /*const */bool bIsOnline;
		public /*const */bool bIsPlaying;
		public /*const */bool bIsPlayingThisGame;
		public /*const */bool bIsJoinable;
		public /*const */bool bHasVoiceSupport;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00286763
	//		UniqueId = new OnlineSubsystem.UniqueNetId
	//		{
	//			Uid = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte>/*[8]*/()
	//			{
	//				[0] = 0,
	//				[1] = 0,
	//				[2] = 0,
	//				[3] = 0,
	//				[4] = 0,
	//				[5] = 0,
	//				[6] = 0,
	//				[7] = 0,
	//			},
	//		};
	//		NickName = "";
	//		PresenceInfo = "";
	//		bIsOnline = false;
	//		bIsPlaying = false;
	//		bIsPlayingThisGame = false;
	//		bIsJoinable = false;
	//		bHasVoiceSupport = false;
	//	}
	};
	
	public partial struct /*native */PlayGroupListEntry
	{
		public OnlineSubsystem.UniqueNetId UserId;
		public bool IsLeader;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002869DB
	//		UserId = new OnlineSubsystem.UniqueNetId
	//		{
	//			Uid = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte>/*[8]*/()
	//			{
	//				[0] = 0,
	//				[1] = 0,
	//				[2] = 0,
	//				[3] = 0,
	//				[4] = 0,
	//				[5] = 0,
	//				[6] = 0,
	//				[7] = 0,
	//			},
	//		};
	//		IsLeader = false;
	//	}
	};
	
	public partial struct /*native */PlayGroupCreateParams
	{
		public int Size;
		public bool bInviteOnly;
		public bool bAutoJoinFriends;
		public bool bAutoJoinRecentPlayers;
		public bool bAutoJoinMembersFriends;
		public bool bAutoJoinMembersRecentPlayers;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00286C27
	//		Size = 6;
	//		bInviteOnly = true;
	//		bAutoJoinFriends = false;
	//		bAutoJoinRecentPlayers = false;
	//		bAutoJoinMembersFriends = false;
	//		bAutoJoinMembersRecentPlayers = false;
	//	}
	};
	
	public partial struct /*native */OnlineFileLockerFileInfo
	{
		public String Filename;
		public String Description;
		public int Meta;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00286D8B
	//		Filename = "";
	//		Description = "";
	//		Meta = 0;
	//	}
	};
	
	public partial struct /*native */OnlineFileLockerFile
	{
		public array<byte> Bytes;
		public OnlineSubsystem.OnlineFileLockerFileInfo Info;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00286EA7
	//		Bytes = default;
	//		Info = new OnlineSubsystem.OnlineFileLockerFileInfo
	//		{
	//			Filename = "",
	//			Description = "",
	//			Meta = 0,
	//		};
	//	}
	};
	
	public partial struct /*native */OnlineContent
	{
		public int UserIndex;
		public String FriendlyName;
		public String ContentPath;
		public array<String> ContentPackages;
		public array<String> ContentFiles;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002870B3
	//		UserIndex = 0;
	//		FriendlyName = "";
	//		ContentPath = "";
	//		ContentPackages = default;
	//		ContentFiles = default;
	//	}
	};
	
	public partial struct /*native */OnlineArbitrationRegistrant
	{
		public /*const */Object.QWord MachineId;
		public /*const */OnlineSubsystem.UniqueNetId PlayerId;
		public /*const */int Trustworthiness;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002872AB
	//		MachineId = default;
	//		PlayerId = new OnlineSubsystem.UniqueNetId
	//		{
	//			Uid = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte>/*[8]*/()
	//			{
	//				[0] = 0,
	//				[1] = 0,
	//				[2] = 0,
	//				[3] = 0,
	//				[4] = 0,
	//				[5] = 0,
	//				[6] = 0,
	//				[7] = 0,
	//			},
	//		};
	//		Trustworthiness = 0;
	//	}
	};
	
	public partial struct SpeechRecognizedWord
	{
		public int WordId;
		public String WordText;
		public float Confidence;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0028749B
	//		WordId = 0;
	//		WordText = "";
	//		Confidence = 0.0f;
	//	}
	};
	
	public partial struct /*native */OnlinePlayerScore
	{
		public OnlineSubsystem.UniqueNetId PlayerId;
		public int TeamId;
		public int Score;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002875E7
	//		PlayerId = new OnlineSubsystem.UniqueNetId
	//		{
	//			Uid = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte>/*[8]*/()
	//			{
	//				[0] = 0,
	//				[1] = 0,
	//				[2] = 0,
	//				[3] = 0,
	//				[4] = 0,
	//				[5] = 0,
	//				[6] = 0,
	//				[7] = 0,
	//			},
	//		};
	//		TeamId = 0;
	//		Score = 0;
	//	}
	};
	
	public partial struct /*native */LocalTalker
	{
		public bool bHasVoice;
		public bool bHasNetworkedVoice;
		public bool bIsRecognizingSpeech;
		public bool bWasTalking;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0036B0DA
	//		bHasVoice = false;
	//		bHasNetworkedVoice = false;
	//		bIsRecognizingSpeech = false;
	//		bWasTalking = false;
	//	}
	};
	
	public partial struct /*native */RemoteTalker
	{
		public OnlineSubsystem.UniqueNetId TalkerId;
		public bool bWasTalking;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0036B1DE
	//		TalkerId = new OnlineSubsystem.UniqueNetId
	//		{
	//			Uid = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte>/*[8]*/()
	//			{
	//				[0] = 0,
	//				[1] = 0,
	//				[2] = 0,
	//				[3] = 0,
	//				[4] = 0,
	//				[5] = 0,
	//				[6] = 0,
	//				[7] = 0,
	//			},
	//		};
	//		bWasTalking = false;
	//	}
	};
	
	public partial struct /*native */OnlineFriendMessage
	{
		public OnlineSubsystem.UniqueNetId SendingPlayerId;
		public String SendingPlayerNick;
		public bool bIsFriendInvite;
		public bool bIsGameInvite;
		public bool bWasAccepted;
		public bool bWasDenied;
		public String Message;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0036B45A
	//		SendingPlayerId = new OnlineSubsystem.UniqueNetId
	//		{
	//			Uid = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte>/*[8]*/()
	//			{
	//				[0] = 0,
	//				[1] = 0,
	//				[2] = 0,
	//				[3] = 0,
	//				[4] = 0,
	//				[5] = 0,
	//				[6] = 0,
	//				[7] = 0,
	//			},
	//		};
	//		SendingPlayerNick = "";
	//		bIsFriendInvite = false;
	//		bIsGameInvite = false;
	//		bWasAccepted = false;
	//		bWasDenied = false;
	//		Message = "";
	//	}
	};
	
	public /*private native const noexport */Object.Pointer VfTable_FTickableObject;
	public OnlineAccountInterface AccountInterface;
	public OnlinePlayerInterface PlayerInterface;
	public OnlinePlayerInterfaceEx PlayerInterfaceEx;
	public OnlineSystemInterface SystemInterface;
	public OnlineGameInterface GameInterface;
	public OnlineContentInterface ContentInterface;
	public OnlineVoiceInterface VoiceInterface;
	public OnlineStatsInterface StatsInterface;
	public OnlineNewsInterface NewsInterface;
	public OnlinePlayGroupInterface PlayGroupInterface;
	public OnlineFileLockerInterface FileLockerInterface;
	
	public virtual /*event */bool Init()
	{
		// stub
		return default;
	}
	
	public virtual /*event */bool SetAccountInterface(Object NewInterface)
	{
		// stub
		return default;
	}
	
	public virtual /*event */bool SetPlayerInterface(Object NewInterface)
	{
		// stub
		return default;
	}
	
	public virtual /*event */bool SetPlayerInterfaceEx(Object NewInterface)
	{
		// stub
		return default;
	}
	
	public virtual /*event */bool SetSystemInterface(Object NewInterface)
	{
		// stub
		return default;
	}
	
	public virtual /*event */bool SetGameInterface(Object NewInterface)
	{
		// stub
		return default;
	}
	
	public virtual /*event */bool SetContentInterface(Object NewInterface)
	{
		// stub
		return default;
	}
	
	public virtual /*event */bool SetVoiceInterface(Object NewInterface)
	{
		// stub
		return default;
	}
	
	public virtual /*event */bool SetStatsInterface(Object NewInterface)
	{
		// stub
		return default;
	}
	
	public virtual /*event */bool SetNewsInterface(Object NewInterface)
	{
		// stub
		return default;
	}
	
	// Export UOnlineSubsystem::execUniqueNetIdToString(FFrame&, void* const)
	public /*native final function */static String UniqueNetIdToString(/*const */ref OnlineSubsystem.UniqueNetId IdToConvert)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UOnlineSubsystem::execStringToUniqueNetId(FFrame&, void* const)
	public /*native final function */static bool StringToUniqueNetId(String UniqueNetIdString, ref OnlineSubsystem.UniqueNetId out_UniqueId)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
}
}