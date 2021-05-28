namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AccessControl : Info/*
		config(Game)
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public /*globalconfig */array</*config */string> IPPolicies;
	public /*globalconfig */array</*config */OnlineSubsystem.UniqueNetId> BannedIDs;
	public /*const localized */string IPBanned;
	public /*const localized */string WrongPassword;
	public /*const localized */string NeedPassword;
	public /*const localized */string SessionBanned;
	public /*const localized */string KickedMsg;
	public /*const localized */string DefaultKickReason;
	public /*const localized */string IdleKickReason;
	public Core.ClassT<Admin> AdminClass;
	public /*private globalconfig */string AdminPassword;
	public /*private globalconfig */string GamePassword;
	public /*const localized */StaticArray<string, string, string>/*[3]*/ ACDisplayText;
	public /*const localized */StaticArray<string, string, string>/*[3]*/ ACDescText;
	public bool bDontAddDefaultAdmin;
	
	public virtual /*function */bool IsAdmin(PlayerController P)
	{
	
		return default;
	}
	
	public virtual /*function */bool SetAdminPassword(string P)
	{
	
		return default;
	}
	
	public virtual /*function */void SetGamePassword(string P)
	{
	
	}
	
	public virtual /*function */bool RequiresPassword()
	{
	
		return default;
	}
	
	public virtual /*function */Controller GetControllerFromString(string Target)
	{
	
		return default;
	}
	
	public virtual /*function */void Kick(string Target)
	{
	
	}
	
	public virtual /*function */void KickBan(string Target)
	{
	
	}
	
	public virtual /*function */bool KickPlayer(PlayerController C, string KickReason)
	{
	
		return default;
	}
	
	public virtual /*function */bool AdminLogin(PlayerController P, string Password)
	{
	
		return default;
	}
	
	public virtual /*function */bool AdminLogout(PlayerController P)
	{
	
		return default;
	}
	
	public virtual /*function */void AdminEntered(PlayerController P)
	{
	
	}
	
	public virtual /*function */void AdminExited(PlayerController P)
	{
	
	}
	
	public virtual /*function */bool ParseAdminOptions(string Options)
	{
	
		return default;
	}
	
	public virtual /*function */bool ValidLogin(string UserName, string Password)
	{
	
		return default;
	}
	
	public virtual /*event */void PreLogin(string Options, string Address, ref string OutError, bool bSpectator)
	{
	
	}
	
	public virtual /*function */bool CheckIPPolicy(string Address)
	{
	
		return default;
	}
	
	public virtual /*function */bool IsIDBanned(/*const */ref OnlineSubsystem.UniqueNetId NetID)
	{
	
		return default;
	}
	
	public AccessControl()
	{
		// Object Offset:0x00260271
		IPPolicies = new array</*config */string>
		{
			"ACCEPT;*",
		};
		IPBanned = "Your IP address has been banned on this server.";
		WrongPassword = "The password you entered is incorrect.";
		NeedPassword = "You need to enter a password to join this game.";
		SessionBanned = "Your IP address has been banned from the current game session.";
		KickedMsg = "You have been forcibly removed from the game.";
		DefaultKickReason = "None specified";
		IdleKickReason = "Kicked for idling.";
		AdminClass = ClassT<Admin>()/*Ref Class'Admin'*/;
		ACDisplayText = new StaticArray<string, string, string>/*[3]*/()
		{ 
			[0] = "Game Password",
			[1] = "Access Policies",
			[2] = "Admin Password",
	 	};
		ACDescText = new StaticArray<string, string, string>/*[3]*/()
		{ 
			[0] = "If this password is set, players will have to enter it to join this server.",
			[1] = "Specifies IP addresses or address ranges which have been banned.",
			[2] = "Password required to login with administrator privileges on this server.",
	 	};
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__AccessControl.Sprite")/*Ref SpriteComponent'Default__AccessControl.Sprite'*/,
		};
	}
}
}