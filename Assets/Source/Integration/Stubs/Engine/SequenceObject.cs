namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SequenceObject : Object/*
		abstract
		native
		hidecategories(Object)*/{
	public /*const */int ObjClassVersion;
	public /*const */int ObjInstanceVersion;
	public /*noimport const */Sequence ParentSequence;
	public int ObjPosX;
	public int ObjPosY;
	public String ObjName;
	public String ObjCategory;
	public Object.Color ObjColor;
	public/*()*/ String ObjComment;
	public bool bDeletable;
	public bool bDrawFirst;
	public bool bDrawLast;
	public/*()*/ bool bOutputObjCommentToScreen;
	public/*()*/ bool bSuppressAutoComment;
	public int DrawWidth;
	public int DrawHeight;
	
	// Export USequenceObject::execScriptLog(FFrame&, void* const)
	public virtual /*native final function */void ScriptLog(String LogText, /*optional */bool? _bWarning = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export USequenceObject::execGetWorldInfo(FFrame&, void* const)
	public virtual /*native final function */WorldInfo GetWorldInfo()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*event */bool IsValidLevelSequenceObject()
	{
		// stub
		return default;
	}
	
	public virtual /*event */bool IsValidUISequenceObject(/*optional */UIScreenObject _TargetObject = default)
	{
		// stub
		return default;
	}
	
	public SequenceObject()
	{
		// Object Offset:0x002D8BAA
		ObjClassVersion = 1;
		ObjName = "Undefined";
		ObjColor = new Color
		{
			R=255,
			G=255,
			B=255,
			A=255
		};
		bDeletable = true;
		bSuppressAutoComment = true;
	}
}
}