namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TeamInfo : ReplicationInfo/*
		native
		nativereplication
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	[databinding, Const, localized] public String TeamName;
	[databinding] public int Size;
	[databinding] public float Score;
	[repnotify, databinding] public int TeamIndex;
	[databinding] public Object.Color TeamColor;
	
	//replication
	//{
	//	 if(bNetDirty && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		Score;
	//
	//	 if(bNetInitial && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		TeamIndex, TeamName;
	//}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
		// stub
	}
	
	public override /*simulated event */void Destroyed()
	{
		// stub
	}
	
	public virtual /*function */bool AddToTeam(Controller Other)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void RemoveFromTeam(Controller Other)
	{
		// stub
	}
	
	public override /*simulated function */String GetHumanReadableName()
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */Object.Color GetHUDColor()
	{
		// stub
		return default;
	}
	
	public virtual /*function */Object.Color GetTextColor()
	{
		// stub
		return default;
	}
	
	// Export UTeamInfo::execGetTeamNum(FFrame&, void* const)
	public override /*native simulated function */byte GetTeamNum()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public TeamInfo()
	{
		// Object Offset:0x003F93A2
		TeamName = "Team";
		TeamIndex = -1;
		TeamColor = new Color
		{
			R=255,
			G=64,
			B=64,
			A=255
		};
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
		NetUpdateFrequency = 2.0f;
	}
}
}