namespace MEdge.Ts{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TsSystem : Object/*
		transient
		native*/{
	public enum ETsSaveType 
	{
		TSST_Ghost,
		TSST_Checkpoint,
		TSST_TimeTrialData,
		TSST_Test,
		TSST_Profile,
		TSST_MAX
	};
	
	public enum ETsResult 
	{
		TSR_Ok,
		TSR_Error,
		TSR_Canceled,
		TSR_Pending,
		TSR_Busy,
		TSR_DoesNotExist,
		TSR_NotSignedIn,
		TSR_Corrupt,
		TSR_DeviceRemoved,
		TSR_BadOwner,
		TSR_MAX
	};
	
	public enum ETsError 
	{
		TSE_Ok,
		TSE_NoSpace,
		TSE_FailedToOpen,
		TSE_FileDoesNotExist,
		TSE_FailedToSeek,
		TSE_AccessDenied,
		TSE_Corrupt,
		TSE_DeviceRemoved,
		TSE_Unknown,
		TSE_MAX
	};
	
	public enum ETsDiskAccess 
	{
		TSD_None,
		TSD_ShortRead,
		TSD_LongRead,
		TSD_ShortWrite,
		TSD_LongWrite,
		TSD_Download,
		TSD_Upload,
		TSD_CreatingSave,
		TSD_LoadingSave,
		TSD_CheckingSave,
		TSD_LoadingLevel,
		TSD_MAX
	};
	
	public partial struct /*native */TsSaveData
	{
		public TsSystem.ETsSaveType SaveType;
		public int Id;
		public array<byte> Data;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x000046DC
	//		SaveType = TsSystem.ETsSaveType.TSST_Ghost;
	//		Id = 0;
	//		Data = default;
	//	}
	};
	
	public partial struct /*native */TsToCEntry
	{
		public TsSystem.ETsSaveType SaveType;
		public int Id;
		public int MaxSize;
		public bool IsUsed;
		public int StoredSize;
		public Object.Pointer CachedBytes;
		public StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/ Digest;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00004CF0
	//		SaveType = TsSystem.ETsSaveType.TSST_Ghost;
	//		Id = 0;
	//		MaxSize = 0;
	//		IsUsed = false;
	//		StoredSize = 0;
	//		CachedBytes = default;
	//		Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
	//		{ 
	//			[0] = 0,
	//			[1] = 0,
	//			[2] = 0,
	//			[3] = 0,
	//			[4] = 0,
	//			[5] = 0,
	//			[6] = 0,
	//			[7] = 0,
	//			[8] = 0,
	//			[9] = 0,
	//			[10] = 0,
	//			[11] = 0,
	//			[12] = 0,
	//			[13] = 0,
	//			[14] = 0,
	//			[15] = 0,
	// 		};
	//	}
	};
	
	public /*private transient */bool UseCache;
	public /*private transient */bool SystemReady;
	public /*private transient */bool bCorruptProfileDetected;
	public /*private transient */bool bNoSaving;
	public /*private transient */bool SystemsDisabled;
	public /*private transient */array<byte> WriteBuffer;
	public /*private transient */array<byte> ToCWriteBuffer;
	public /*private transient */array<byte> SPDataCached;
	public /*private transient */OnlineProfileSettings CachedProfile;
	public /*private transient */byte CachedProfileUserNum;
	public /*private transient */TsSystem.ETsError LastErrorCode;
	public /*transient */byte ActiveControllerId;
	public /*private transient */int CurrentIdx;
	public /*private transient */String LastErrorMessage;
	public /*private const transient */array<TsSystem.TsToCEntry> ToC;
	public /*private const transient */int SavefileVersion;
	public /*private const transient */int HeaderSize;
	public /*delegate*/TsSystem.OnInitializeComplete __OnInitializeComplete__Delegate;
	public /*delegate*/TsSystem.OnWriteDataComplete __OnWriteDataComplete__Delegate;
	public /*delegate*/TsSystem.OnReadDataComplete __OnReadDataComplete__Delegate;
	public /*delegate*/TsSystem.OnWriteProfileSettingsComplete __OnWriteProfileSettingsComplete__Delegate;
	public /*delegate*/TsSystem.OnReadProfileSettingsComplete __OnReadProfileSettingsComplete__Delegate;
	public /*delegate*/TsSystem.OnDiskAccess __OnDiskAccess__Delegate;
	
	// Export UTsSystem::execSetTsSystem(FFrame&, void* const)
	public /*native final function */static void SetTsSystem(TsSystem Ts)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTsSystem::execGetTsSystem(FFrame&, void* const)
	public /*native final function */static TsSystem GetTsSystem()
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UTsSystem::execHasPendingSaveTasks(FFrame&, void* const)
	public virtual /*native final function */bool HasPendingSaveTasks()
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UTsSystem::execGetLastError(FFrame&, void* const)
	public /*native final function */static TsSystem.ETsError GetLastError(ref String ErrorString)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UTsSystem::execDisableSystem(FFrame&, void* const)
	public virtual /*native function */void DisableSystem()
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTsSystem::execProcessTick(FFrame&, void* const)
	public virtual /*native function */void ProcessTick(float DeltaTime)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	public delegate void OnInitializeComplete(TsSystem.ETsResult Result);
	
	public delegate void OnWriteDataComplete(TsSystem.ETsResult Result);
	
	public delegate void OnReadDataComplete(TsSystem.ETsResult Result, array<byte> ReadBuffer);
	
	public delegate void OnWriteProfileSettingsComplete(TsSystem.ETsResult Result);
	
	public delegate void OnReadProfileSettingsComplete(TsSystem.ETsResult Result);
	
	public virtual /*function */void RegisterWriteProfileSettingsDelegate(/*delegate*/TsSystem.OnWriteProfileSettingsComplete WriteDelegate)
	{
		// stub
	}
	
	public virtual /*function */void UnRegisterWriteProfileSettingsDelegate(/*delegate*/TsSystem.OnWriteProfileSettingsComplete WriteDelegate)
	{
		// stub
	}
	
	public virtual /*function */void RegisterReadProfileSettingsDelegate(/*delegate*/TsSystem.OnReadProfileSettingsComplete ReadDelegate)
	{
		// stub
	}
	
	public virtual /*function */void UnRegisterReadProfileSettingsDelegate(/*delegate*/TsSystem.OnReadProfileSettingsComplete ReadDelegate)
	{
		// stub
	}
	
	// Export UTsSystem::execClearCachedProfile(FFrame&, void* const)
	public virtual /*native function */void ClearCachedProfile()
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	public virtual /*function */bool IsCorruptProfileDetected()
	{
		// stub
		return default;
	}
	
	// Export UTsSystem::execSetNoSaving(FFrame&, void* const)
	public virtual /*native function */void SetNoSaving(bool bValue)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	public virtual /*function */bool IsNoSaving()
	{
		// stub
		return default;
	}
	
	public delegate void OnDiskAccess(bool IsAccessing, TsSystem.ETsDiskAccess AccessType);
	
	public virtual /*function */void RegisterOnDiskAccessDelegate(/*delegate*/TsSystem.OnDiskAccess DiskAccessDelegate)
	{
		// stub
	}
	
	public virtual /*function */void UnRegisterOnDiskAccessDelegate(/*delegate*/TsSystem.OnDiskAccess DiskAccessDelegate)
	{
		// stub
	}
	
	// Export UTsSystem::execInitialize(FFrame&, void* const)
	public virtual /*native function */void Initialize()
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTsSystem::execCheckStorageDevice(FFrame&, void* const)
	public virtual /*native function */bool CheckStorageDevice()
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UTsSystem::execInitializeToC(FFrame&, void* const)
	public virtual /*native function */void InitializeToC(byte LocalUserNum, bool bAutoReplaceCorrupt, /*delegate*/TsSystem.OnInitializeComplete InitializeComplete)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTsSystem::execWriteSaveData(FFrame&, void* const)
	public virtual /*native function */void WriteSaveData(ref TsSystem.TsSaveData InData, /*delegate*/TsSystem.OnWriteDataComplete AddComplete)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTsSystem::execReadSaveData(FFrame&, void* const)
	public virtual /*native function */void ReadSaveData(TsSystem.ETsSaveType SaveType, int Id, /*delegate*/TsSystem.OnReadDataComplete ReadComplete)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTsSystem::execWriteSPData(FFrame&, void* const)
	public virtual /*native function */void WriteSPData(ref TsSystem.TsSaveData InData, /*delegate*/TsSystem.OnWriteDataComplete SaveComplete)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTsSystem::execReadSPData(FFrame&, void* const)
	public virtual /*native function */void ReadSPData(/*delegate*/TsSystem.OnReadDataComplete ReadComplete)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTsSystem::execWriteProfileSettings(FFrame&, void* const)
	public virtual /*native function */bool WriteProfileSettings(byte LocalUserNum, ref OnlineProfileSettings ProfileSettings)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UTsSystem::execReadProfileSettings(FFrame&, void* const)
	public virtual /*native function */bool ReadProfileSettings(byte LocalUserNum, ref OnlineProfileSettings ProfileSettings)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UTsSystem::execCopyProfileSettings(FFrame&, void* const)
	public virtual /*native function */void CopyProfileSettings(OnlineProfileSettings Src, OnlineProfileSettings Dest)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTsSystem::execInitTrophyAsync(FFrame&, void* const)
	public virtual /*native final function */void InitTrophyAsync(int InContext, int InHandle)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTsSystem::execUnlockTrophyAsync(FFrame&, void* const)
	public virtual /*native final function */void UnlockTrophyAsync(int InContext, int InHandle, int InTrophyId)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	public TsSystem()
	{
		// Object Offset:0x000061C3
		ToC = new array<TsSystem.TsToCEntry>
		{
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Ghost,
				Id = 1,
				MaxSize = 300000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Ghost,
				Id = 2,
				MaxSize = 300000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Ghost,
				Id = 3,
				MaxSize = 300000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Ghost,
				Id = 4,
				MaxSize = 300000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Ghost,
				Id = 5,
				MaxSize = 300000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Ghost,
				Id = 6,
				MaxSize = 300000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Ghost,
				Id = 7,
				MaxSize = 300000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Ghost,
				Id = 8,
				MaxSize = 300000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Ghost,
				Id = 9,
				MaxSize = 300000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Ghost,
				Id = 10,
				MaxSize = 300000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Ghost,
				Id = 11,
				MaxSize = 300000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Ghost,
				Id = 12,
				MaxSize = 300000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Ghost,
				Id = 13,
				MaxSize = 300000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Ghost,
				Id = 14,
				MaxSize = 300000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Ghost,
				Id = 15,
				MaxSize = 300000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Ghost,
				Id = 16,
				MaxSize = 300000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Ghost,
				Id = 17,
				MaxSize = 300000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Ghost,
				Id = 18,
				MaxSize = 300000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Ghost,
				Id = 19,
				MaxSize = 300000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Ghost,
				Id = 20,
				MaxSize = 300000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Ghost,
				Id = 21,
				MaxSize = 300000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Ghost,
				Id = 22,
				MaxSize = 300000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Ghost,
				Id = 23,
				MaxSize = 300000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Ghost,
				Id = 24,
				MaxSize = 300000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Ghost,
				Id = 25,
				MaxSize = 300000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Ghost,
				Id = 26,
				MaxSize = 300000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Ghost,
				Id = 27,
				MaxSize = 300000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Ghost,
				Id = 28,
				MaxSize = 300000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Ghost,
				Id = 29,
				MaxSize = 300000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Ghost,
				Id = 30,
				MaxSize = 300000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Test,
				Id = 0,
				MaxSize = 10000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Test,
				Id = 1,
				MaxSize = 10000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Test,
				Id = 2,
				MaxSize = 10000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Profile,
				Id = 0,
				MaxSize = 4000,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
			new TsSystem.TsToCEntry
			{
				SaveType = TsSystem.ETsSaveType.TSST_Checkpoint,
				Id = 1,
				MaxSize = 256,
				IsUsed = false,
				StoredSize = 0,
				CachedBytes = default,
				Digest = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte, byte>/*[16]*/()
				{
					[0] = 0,
					[1] = 0,
					[2] = 0,
					[3] = 0,
					[4] = 0,
					[5] = 0,
					[6] = 0,
					[7] = 0,
					[8] = 0,
					[9] = 0,
					[10] = 0,
					[11] = 0,
					[12] = 0,
					[13] = 0,
					[14] = 0,
					[15] = 0,
				},
			},
		};
		SavefileVersion = 3;
		HeaderSize = 100000;
	}
}
}