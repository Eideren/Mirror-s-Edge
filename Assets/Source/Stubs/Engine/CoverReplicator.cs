namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CoverReplicator : ReplicationInfo/*
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public partial struct ManualCoverTypeInfo
	{
		public byte SlotIndex;
		public CoverLink.ECoverType ManualCoverType;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002E96C7
	//		SlotIndex = 0;
	//		ManualCoverType = CoverLink.ECoverType.CT_None;
	//	}
	};
	
	public partial struct CoverReplicationInfo
	{
		public CoverLink Link;
		public array<byte> SlotsEnabled;
		public array<byte> SlotsDisabled;
		public array<byte> SlotsAdjusted;
		public array<CoverReplicator.ManualCoverTypeInfo> SlotsCoverTypeChanged;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002E98E8
	//		Link = default;
	//		SlotsEnabled = default;
	//		SlotsDisabled = default;
	//		SlotsAdjusted = default;
	//		SlotsCoverTypeChanged = default;
	//	}
	};
	
	public array<CoverReplicator.CoverReplicationInfo> CoverReplicationData;
	
	public virtual /*function */void PurgeOldEntries()
	{
	
	}
	
	public virtual /*function */void ReplicateInitialCoverInfo()
	{
	
	}
	
	public virtual /*reliable server function */void ServerSendInitialCoverReplicationInfo(int Index)
	{
	
	}
	
	public virtual /*reliable client simulated function */void ClientReceiveInitialCoverReplicationInfo(int Index, CoverLink Link, byte NumSlotsEnabled, StaticArray<byte, byte, byte, byte, byte, byte, byte, byte>/*[8]*/ SlotsEnabled, byte NumSlotsDisabled, StaticArray<byte, byte, byte, byte, byte, byte, byte, byte>/*[8]*/ SlotsDisabled, byte NumSlotsAdjusted, StaticArray<byte, byte, byte, byte, byte, byte, byte, byte>/*[8]*/ SlotsAdjusted, byte NumCoverTypesChanged, StaticArray<CoverReplicator.ManualCoverTypeInfo, CoverReplicator.ManualCoverTypeInfo, CoverReplicator.ManualCoverTypeInfo, CoverReplicator.ManualCoverTypeInfo, CoverReplicator.ManualCoverTypeInfo, CoverReplicator.ManualCoverTypeInfo, CoverReplicator.ManualCoverTypeInfo, CoverReplicator.ManualCoverTypeInfo>/*[8]*/ SlotsCoverTypeChanged, bool bDone)
	{
	
	}
	
	public virtual /*function */void NotifyEnabledSlots(CoverLink Link, /*const */ref array<int> SlotIndices)
	{
	
	}
	
	public virtual /*reliable server function */void ServerSendEnabledSlots(int Index)
	{
	
	}
	
	public virtual /*reliable client simulated function */void ClientReceiveEnabledSlots(int Index, CoverLink Link, byte NumSlotsEnabled, StaticArray<byte, byte, byte, byte, byte, byte, byte, byte>/*[8]*/ SlotsEnabled, bool bDone)
	{
	
	}
	
	public virtual /*function */void NotifyDisabledSlots(CoverLink Link, /*const */ref array<int> SlotIndices)
	{
	
	}
	
	public virtual /*reliable server function */void ServerSendDisabledSlots(int Index)
	{
	
	}
	
	public virtual /*reliable client simulated function */void ClientReceiveDisabledSlots(int Index, CoverLink Link, byte NumSlotsDisabled, StaticArray<byte, byte, byte, byte, byte, byte, byte, byte>/*[8]*/ SlotsDisabled, bool bDone)
	{
	
	}
	
	public virtual /*function */void NotifyAutoAdjustSlots(CoverLink Link, /*const */ref array<int> SlotIndices)
	{
	
	}
	
	public virtual /*reliable server function */void ServerSendAdjustedSlots(int Index)
	{
	
	}
	
	public virtual /*reliable client simulated function */void ClientReceiveAdjustedSlots(int Index, CoverLink Link, byte NumSlotsAdjusted, StaticArray<byte, byte, byte, byte, byte, byte, byte, byte>/*[8]*/ SlotsAdjusted, bool bDone)
	{
	
	}
	
	public virtual /*function */void NotifySetManualCoverTypeForSlots(CoverLink Link, /*const */ref array<int> SlotIndices, CoverLink.ECoverType NewCoverType)
	{
	
	}
	
	public virtual /*reliable server function */void ServerSendManualCoverTypeSlots(int Index)
	{
	
	}
	
	public virtual /*reliable client simulated function */void ClientReceiveManualCoverTypeSlots(int Index, CoverLink Link, byte NumCoverTypesChanged, StaticArray<CoverReplicator.ManualCoverTypeInfo, CoverReplicator.ManualCoverTypeInfo, CoverReplicator.ManualCoverTypeInfo, CoverReplicator.ManualCoverTypeInfo, CoverReplicator.ManualCoverTypeInfo, CoverReplicator.ManualCoverTypeInfo, CoverReplicator.ManualCoverTypeInfo, CoverReplicator.ManualCoverTypeInfo>/*[8]*/ SlotsCoverTypeChanged, bool bDone)
	{
	
	}
	
	public CoverReplicator()
	{
		// Object Offset:0x002EC908
		bOnlyRelevantToOwner = true;
		bAlwaysRelevant = false;
		NetUpdateFrequency = 0.10f;
	}
}
}