namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdStashpointManager : Actor/*
		notplaceable
		hidecategories(Navigation)*/{
	public /*private transient */TdPursuitGRI MyGRI;
	
	public virtual /*function */void Initialize(TdPursuitGRI InGRI, TdStashpointListener InListener)
	{
		// stub
	}
	
	public virtual /*function */array<TdStashpoint> GetStashpoints(/*optional */int? _TeamIndex = default, /*optional */int? _StashPointID = default)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnStartMatchInProgress()
	{
		// stub
	}
	
	public virtual /*function */void SendKismetOnStartMatchInProgress()
	{
		// stub
	}
	
	public virtual /*function */int GetFirstRunnerStashPointID()
	{
		// stub
		return default;
	}
	
	public virtual /*function */Actor AddStashPoint(Object.Vector StashLocation, Core.ClassT<TdStashpoint> StashpointClass)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool RemoveStashPoint(TdStashpoint StashpointToRemove)
	{
		// stub
		return default;
	}
	
	public TdStashpointManager()
	{
		// Object Offset:0x00671EBE
		SupportedEvents = new array< Core.ClassT<SequenceEvent> >
		{
			ClassT<SeqEvent_Touch>(),
			ClassT<SeqEvent_Destroyed>(),
			ClassT<SeqEvent_TakeDamage>(),
			ClassT<SeqEvt_TdBeginStashingGame>(),
		};
	}
}
}