namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AccessControl : Info/*
		config(Game)
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public /*globalconfig */array</*config */String> IPPolicies;
	public /*globalconfig */array</*config */OnlineSubsystem.UniqueNetId> BannedIDs;
	public /*const localized */String IPBanned;
	public /*const localized */String WrongPassword;
	public /*const localized */String NeedPassword;
	public /*const localized */String SessionBanned;
	public /*const localized */String KickedMsg;
	public /*const localized */String DefaultKickReason;
	public /*const localized */String IdleKickReason;
	public Core.ClassT<Admin> AdminClass;
	public /*private globalconfig */String AdminPassword;
	public /*private globalconfig */String GamePassword;
	public /*const localized */StaticArray<String, String, String>/*[3]*/ ACDisplayText;
	public /*const localized */StaticArray<String, String, String>/*[3]*/ ACDescText;
	public bool bDontAddDefaultAdmin;
	
	public virtual /*function */bool IsAdmin(PlayerController P)
	{
	
		return default;
	}
	
	public virtual /*function */bool SetAdminPassword(String P)
	{
	
		return default;
	}
	
	public virtual /*function */void SetGamePassword(String P)
	{
	
	}
	
	public virtual /*function */bool RequiresPassword()
	{
	
		return default;
	}
	
	public virtual /*function */Controller GetControllerFromString(String Target)
	{
	
		return default;
	}
	
	public virtual /*function */void Kick(String Target)
	{
	
	}
	
	public virtual /*function */void KickBan(String Target)
	{
	
	}
	
	public virtual /*function */bool KickPlayer(PlayerController C, String KickReason)
	{
	
		return default;
	}
	
	public virtual /*function */bool AdminLogin(PlayerController P, String Password)
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
	
	public virtual /*function */bool ParseAdminOptions(String Options)
	{
	
		return default;
	}
	
	public virtual /*function */bool ValidLogin(String UserName, String Password)
	{
	
		return default;
	}
	
	public virtual /*event */void PreLogin(String Options, String Address, ref String OutError, bool bSpectator)
	{
	
	}
	
	public virtual /*function */bool CheckIPPolicy(String Address)
	{
	
		return default;
	}
	
	public virtual /*function */bool IsIDBanned(/*const */ref OnlineSubsystem.UniqueNetId NetID)
	{
	
		return default;
	}
	
	public AccessControl()
	{
		var Default__AccessControl_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__AccessControl.Sprite' */;
		// Object Offset:0x00260271
		IPPolicies = new array</*config */String>
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
		ACDisplayText = new StaticArray<String, String, String>/*[3]*/()
		{ 
			[0] = "Game Password",
			[1] = "Access Policies",
			[2] = "Admin Password",
	 	};
		ACDescText = new StaticArray<String, String, String>/*[3]*/()
		{ 
			[0] = "If this password is set, players will have to enter it to join this server.",
			[1] = "Specifies IP addresses or address ranges which have been banned.",
			[2] = "Password required to login with administrator privileges on this server.",
	 	};
		Components = new array</*export editinline */ActorComponent>
		{
			Default__AccessControl_Sprite/*Ref SpriteComponent'Default__AccessControl.Sprite'*/,
		};
	}
}
}