namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AccessControl : Info/*
		config(Game)
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	[globalconfig] public array</*config */String> IPPolicies;
	[globalconfig] public array</*config */OnlineSubsystem.UniqueNetId> BannedIDs;
	[Const, localized] public String IPBanned;
	[Const, localized] public String WrongPassword;
	[Const, localized] public String NeedPassword;
	[Const, localized] public String SessionBanned;
	[Const, localized] public String KickedMsg;
	[Const, localized] public String DefaultKickReason;
	[Const, localized] public String IdleKickReason;
	public Core.ClassT<Admin> AdminClass;
	[globalconfig] public/*private*/ String AdminPassword;
	[globalconfig] public/*private*/ String GamePassword;
	[Const, localized] public StaticArray<String, String, String>/*[3]*/ ACDisplayText;
	[Const, localized] public StaticArray<String, String, String>/*[3]*/ ACDescText;
	public bool bDontAddDefaultAdmin;
	
	public virtual /*function */bool IsAdmin(PlayerController P)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool SetAdminPassword(String P)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void SetGamePassword(String P)
	{
		// stub
	}
	
	public virtual /*function */bool RequiresPassword()
	{
		// stub
		return default;
	}
	
	public virtual /*function */Controller GetControllerFromString(String Target)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void Kick(String Target)
	{
		// stub
	}
	
	public virtual /*function */void KickBan(String Target)
	{
		// stub
	}
	
	public virtual /*function */bool KickPlayer(PlayerController C, String KickReason)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool AdminLogin(PlayerController P, String Password)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool AdminLogout(PlayerController P)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void AdminEntered(PlayerController P)
	{
		// stub
	}
	
	public virtual /*function */void AdminExited(PlayerController P)
	{
		// stub
	}
	
	public virtual /*function */bool ParseAdminOptions(String Options)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool ValidLogin(String UserName, String Password)
	{
		// stub
		return default;
	}
	
	public virtual /*event */void PreLogin(String Options, String Address, ref String OutError, bool bSpectator)
	{
		// stub
	}
	
	public virtual /*function */bool CheckIPPolicy(String Address)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool IsIDBanned(/*const */ref OnlineSubsystem.UniqueNetId NetID)
	{
		// stub
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