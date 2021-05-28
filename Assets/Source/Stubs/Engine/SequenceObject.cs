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
	public string ObjName;
	public string ObjCategory;
	public Object.Color ObjColor;
	public/*()*/ string ObjComment;
	public bool bDeletable;
	public bool bDrawFirst;
	public bool bDrawLast;
	public/*()*/ bool bOutputObjCommentToScreen;
	public/*()*/ bool bSuppressAutoComment;
	public int DrawWidth;
	public int DrawHeight;
	
	// Export USequenceObject::execScriptLog(FFrame&, void* const)
	public virtual /*native final function */void ScriptLog(string LogText, /*optional */bool bWarning = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USequenceObject::execGetWorldInfo(FFrame&, void* const)
	public virtual /*native final function */WorldInfo GetWorldInfo()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*event */bool IsValidLevelSequenceObject()
	{
	
		return default;
	}
	
	public virtual /*event */bool IsValidUISequenceObject(/*optional */UIScreenObject TargetObject = default)
	{
	
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