namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FileLog : FileWriter/*
		native
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public virtual /*function */void OpenLog(/*coerce */String LogFilename, /*optional */String? _extension = default, /*optional */bool? _bUnique = default)
	{
	
	}
	
	public virtual /*function */void CloseLog()
	{
	
	}
	
	public FileLog()
	{
		// Object Offset:0x0031D748
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__FileLog.Sprite")/*Ref SpriteComponent'Default__FileLog.Sprite'*/,
		};
	}
}
}