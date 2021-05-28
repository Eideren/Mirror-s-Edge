// NO OVERWRITE

namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Admin : PlayerController/*
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public override /*simulated event */void PostBeginPlay()
	{
	
	}
	
	#warning Renamed member, c# naming scheme
	public virtual /*exec function */void Admin_(string CommandLine)
	{
	
	}
	
	public virtual /*reliable server function */void ServerAdmin(string CommandLine)
	{
	
	}
	
	public virtual /*exec function */void KickBan(string S)
	{
	
	}
	
	public virtual /*reliable server function */void ServerKickBan(string S)
	{
	
	}
	
	public virtual /*exec function */void Kick(string S)
	{
	
	}
	
	public virtual /*reliable server function */void ServerKick(string S)
	{
	
	}
	
	public virtual /*exec function */void PlayerList()
	{
	
	}
	
	public virtual /*exec function */void RestartMap()
	{
	
	}
	
	public virtual /*reliable server function */void ServerRestartMap()
	{
	
	}
	
	public virtual /*exec function */void Switch(string URL)
	{
	
	}
	
	public virtual /*reliable server function */void ServerSwitch(string URL)
	{
	
	}
	
	public Admin()
	{
		// Object Offset:0x0028B0A1
		CylinderComponent = LoadAsset<CylinderComponent>("Default__Admin.CollisionCylinder")/*Ref CylinderComponent'Default__Admin.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__Admin.Sprite")/*Ref SpriteComponent'Default__Admin.Sprite'*/,
			LoadAsset<CylinderComponent>("Default__Admin.CollisionCylinder")/*Ref CylinderComponent'Default__Admin.CollisionCylinder'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__Admin.CollisionCylinder")/*Ref CylinderComponent'Default__Admin.CollisionCylinder'*/;
	}
}
}