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
	public /*const */String Filename;
	public /*const */FileWriter.FWFileType FileType;
	
	// Export UFileWriter::execOpenFile(FFrame&, void* const)
	public virtual /*native final function */bool OpenFile(/*coerce */String InFilename, /*optional */FileWriter.FWFileType? _InFileType = default, /*optional */String? _InExtension = default, /*optional */bool? _bUnique = default, /*optional */bool? _bIncludeTimeStamp = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UFileWriter::execCloseFile(FFrame&, void* const)
	public virtual /*native final function */void CloseFile()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UFileWriter::execLogf(FFrame&, void* const)
	public virtual /*native final function */void Logf(/*coerce */String logString)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public override /*event */void Destroyed()
	{
		// stub
	}
	
	public FileWriter()
	{
		var Default__FileWriter_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__FileWriter.Sprite' */;
		// Object Offset:0x0031D52C
		Components = new array</*export editinline */ActorComponent>
		{
			Default__FileWriter_Sprite/*Ref SpriteComponent'Default__FileWriter.Sprite'*/,
		};
	}
}
}