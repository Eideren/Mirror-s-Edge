namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FileWriter : Info/*
		native
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public enum FWFileType 
	{
		FWFT_Log,
		FWFT_Stats,
		FWFT_HTML,
		FWFT_User,
		FWFT_Debug,
		FWFT_MAX
	};
	
	public /*native const */Object.Pointer ArchivePtr;
	public /*const */string Filename;
	public /*const */FileWriter.FWFileType FileType;
	
	// Export UFileWriter::execOpenFile(FFrame&, void* const)
	public virtual /*native final function */bool OpenFile(/*coerce */string InFilename, /*optional */FileWriter.FWFileType InFileType = default, /*optional */string InExtension = default, /*optional */bool bUnique = default, /*optional */bool bIncludeTimeStamp = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UFileWriter::execCloseFile(FFrame&, void* const)
	public virtual /*native final function */void CloseFile()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UFileWriter::execLogf(FFrame&, void* const)
	public virtual /*native final function */void Logf(/*coerce */string logString)
	{
		#warning NATIVE FUNCTION !
	}
	
	public override /*event */void Destroyed()
	{
	
	}
	
	public FileWriter()
	{
		// Object Offset:0x0031D52C
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__FileWriter.Sprite")/*Ref SpriteComponent'Default__FileWriter.Sprite'*/,
		};
	}
}
}