namespace MEdge.Tp{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TpUoSystem : TpSystemHandler, 
		OnlineSystemInterface/*
		transient
		native*/{
	public /*private */array< /*delegate*/OnlineSystemInterface.OnControllerChange > __OnControllerChange__Multicaster;
	public /*private */array< /*delegate*/OnlineSystemInterface.OnStorageDeviceChange > __OnStorageDeviceChange__Multicaster;
	public /*private */array< /*delegate*/OnlineSystemInterface.OnLinkStatusChange > __OnLinkStatusChange__Multicaster;
	public /*private */array< /*delegate*/OnlineSystemInterface.OnConnectionStatusChange > __OnConnectionStatusChange__Multicaster;
	public /*private */array< /*delegate*/OnlineSystemInterface.OnExternalUIChange > __OnExternalUIChange__Multicaster;
	public int LastInputDeviceConnectedMask;
	public /*delegate*/OnlineSystemInterface.OnLinkStatusChange __OnLinkStatusChange__Delegate{ get; set; }
	public /*delegate*/OnlineSystemInterface.OnExternalUIChange __OnExternalUIChange__Delegate{ get; set; }
	public /*delegate*/OnlineSystemInterface.OnControllerChange __OnControllerChange__Delegate{ get; set; }
	public /*delegate*/OnlineSystemInterface.OnConnectionStatusChange __OnConnectionStatusChange__Delegate{ get; set; }
	public /*delegate*/OnlineSystemInterface.OnStorageDeviceChange __OnStorageDeviceChange__Delegate{ get; set; }
	
	public override /*simulated function */void Initialize(TpSystemBase InSystemBase)
	{
		// stub
	}
	
	// Export UTpUoSystem::execInitializeNative(FFrame&, void* const)
	public virtual /*native function */void InitializeNative()
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTpUoSystem::execHasLinkConnection(FFrame&, void* const)
	public virtual /*native function */bool HasLinkConnection()
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public virtual /*final simulated event */void OnLinkStatusChange_Invoke(bool bIsConnected)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnLinkStatusChange_Add(/*delegate*/OnlineSystemInterface.OnLinkStatusChange D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnLinkStatusChange_Remove(/*delegate*/OnlineSystemInterface.OnLinkStatusChange D)
	{
		// stub
	}
	
	public virtual /*function */void AddLinkStatusChangeDelegate(/*delegate*/OnlineSystemInterface.OnLinkStatusChange LinkStatusDelegate)
	{
		// stub
	}
	
	public virtual /*function */void ClearLinkStatusChangeDelegate(/*delegate*/OnlineSystemInterface.OnLinkStatusChange LinkStatusDelegate)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnExternalUIChange_Invoke(bool bIsOpening)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnExternalUIChange_Add(/*delegate*/OnlineSystemInterface.OnExternalUIChange D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnExternalUIChange_Remove(/*delegate*/OnlineSystemInterface.OnExternalUIChange D)
	{
		// stub
	}
	
	public virtual /*function */void DispatchExternalUIChange(bool bIsOpening)
	{
		// stub
	}
	
	public virtual /*function */void AddExternalUIChangeDelegate(/*delegate*/OnlineSystemInterface.OnExternalUIChange ExternalUIDelegate)
	{
		// stub
	}
	
	public virtual /*function */void ClearExternalUIChangeDelegate(/*delegate*/OnlineSystemInterface.OnExternalUIChange ExternalUIDelegate)
	{
		// stub
	}
	
	public virtual /*function */OnlineSubsystem.ENetworkNotificationPosition GetNetworkNotificationPosition()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void SetNetworkNotificationPosition(OnlineSubsystem.ENetworkNotificationPosition NewPos)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnControllerChange_Invoke(int ControllerId, bool bIsConnected)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnControllerChange_Add(/*delegate*/OnlineSystemInterface.OnControllerChange D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnControllerChange_Remove(/*delegate*/OnlineSystemInterface.OnControllerChange D)
	{
		// stub
	}
	
	public virtual /*function */void AddControllerChangeDelegate(/*delegate*/OnlineSystemInterface.OnControllerChange ControllerChangeDelegate)
	{
		// stub
	}
	
	public virtual /*function */void ClearControllerChangeDelegate(/*delegate*/OnlineSystemInterface.OnControllerChange ControllerChangeDelegate)
	{
		// stub
	}
	
	public virtual /*function */bool IsControllerConnected(int ControllerId)
	{
		// stub
		return default;
	}
	
	public virtual /*final simulated event */void OnConnectionStatusChange_Invoke(OnlineSubsystem.EOnlineServerConnectionStatus ConnectionStatus)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnConnectionStatusChange_Add(/*delegate*/OnlineSystemInterface.OnConnectionStatusChange D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnConnectionStatusChange_Remove(/*delegate*/OnlineSystemInterface.OnConnectionStatusChange D)
	{
		// stub
	}
	
	public virtual /*function */void OnConnectionChange(bool bConnected)
	{
		// stub
	}
	
	public virtual /*function */void AddConnectionStatusChangeDelegate(/*delegate*/OnlineSystemInterface.OnConnectionStatusChange ConnectionStatusDelegate)
	{
		// stub
	}
	
	public virtual /*function */void ClearConnectionStatusChangeDelegate(/*delegate*/OnlineSystemInterface.OnConnectionStatusChange ConnectionStatusDelegate)
	{
		// stub
	}
	
	public virtual /*function */OnlineSubsystem.ENATType GetNATType()
	{
		// stub
		return default;
	}
	
	public virtual /*final simulated event */void OnStorageDeviceChange_Invoke()
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnStorageDeviceChange_Add(/*delegate*/OnlineSystemInterface.OnStorageDeviceChange D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnStorageDeviceChange_Remove(/*delegate*/OnlineSystemInterface.OnStorageDeviceChange D)
	{
		// stub
	}
	
	public virtual /*function */void AddStorageDeviceChangeDelegate(/*delegate*/OnlineSystemInterface.OnStorageDeviceChange StorageDeviceChangeDelegate)
	{
		// stub
	}
	
	public virtual /*function */void ClearStorageDeviceChangeDelegate(/*delegate*/OnlineSystemInterface.OnStorageDeviceChange StorageDeviceChangeDelegate)
	{
		// stub
	}
	
	// Export UTpUoSystem::execProcessTick(FFrame&, void* const)
	public virtual /*native function */void ProcessTick(float DeltaSeconds)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
}
}