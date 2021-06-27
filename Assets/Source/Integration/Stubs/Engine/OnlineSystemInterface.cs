namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public interface OnlineSystemInterface : Interface/*
		abstract*/{
	public /*delegate*/OnlineSystemInterface.OnLinkStatusChange __OnLinkStatusChange__Delegate{ get; }
	public /*delegate*/OnlineSystemInterface.OnExternalUIChange __OnExternalUIChange__Delegate{ get; }
	public /*delegate*/OnlineSystemInterface.OnControllerChange __OnControllerChange__Delegate{ get; }
	public /*delegate*/OnlineSystemInterface.OnConnectionStatusChange __OnConnectionStatusChange__Delegate{ get; }
	public /*delegate*/OnlineSystemInterface.OnStorageDeviceChange __OnStorageDeviceChange__Delegate{ get; }
	
	public /*function */bool HasLinkConnection();
	
	public delegate void OnLinkStatusChange(bool bIsConnected);
	
	public /*function */void AddLinkStatusChangeDelegate(/*delegate*/OnlineSystemInterface.OnLinkStatusChange LinkStatusDelegate);
	
	public /*function */void ClearLinkStatusChangeDelegate(/*delegate*/OnlineSystemInterface.OnLinkStatusChange LinkStatusDelegate);
	
	public delegate void OnExternalUIChange(bool bIsOpening);
	
	public /*function */void DispatchExternalUIChange(bool bIsOpening);
	
	public /*function */void AddExternalUIChangeDelegate(/*delegate*/OnlineSystemInterface.OnExternalUIChange ExternalUIDelegate);
	
	public /*function */void ClearExternalUIChangeDelegate(/*delegate*/OnlineSystemInterface.OnExternalUIChange ExternalUIDelegate);
	
	public /*function */OnlineSubsystem.ENetworkNotificationPosition GetNetworkNotificationPosition();
	
	public /*function */void SetNetworkNotificationPosition(OnlineSubsystem.ENetworkNotificationPosition NewPos);
	
	public delegate void OnControllerChange(int ControllerId, bool bIsConnected);
	
	public /*function */void AddControllerChangeDelegate(/*delegate*/OnlineSystemInterface.OnControllerChange ControllerChangeDelegate);
	
	public /*function */void ClearControllerChangeDelegate(/*delegate*/OnlineSystemInterface.OnControllerChange ControllerChangeDelegate);
	
	public /*function */bool IsControllerConnected(int ControllerId);
	
	public delegate void OnConnectionStatusChange(OnlineSubsystem.EOnlineServerConnectionStatus ConnectionStatus);
	
	public /*function */void AddConnectionStatusChangeDelegate(/*delegate*/OnlineSystemInterface.OnConnectionStatusChange ConnectionStatusDelegate);
	
	public /*function */void ClearConnectionStatusChangeDelegate(/*delegate*/OnlineSystemInterface.OnConnectionStatusChange ConnectionStatusDelegate);
	
	public /*function */OnlineSubsystem.ENATType GetNATType();
	
	public delegate void OnStorageDeviceChange();
	
	public /*function */void AddStorageDeviceChangeDelegate(/*delegate*/OnlineSystemInterface.OnStorageDeviceChange StorageDeviceChangeDelegate);
	
	public /*function */void ClearStorageDeviceChangeDelegate(/*delegate*/OnlineSystemInterface.OnStorageDeviceChange StorageDeviceChangeDelegate);
	
}
}