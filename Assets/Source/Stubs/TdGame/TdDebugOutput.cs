namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdDebugOutput : Object/*
		native*/{
	// Export UTdDebugOutput::execDrawGraph(FFrame&, void* const)
	public /*native final function */static void DrawGraph(Canvas C)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTdDebugOutput::execAddGraphValue(FFrame&, void* const)
	public /*native final function */static void AddGraphValue(name graph, float Val, /*optional */float? _DisplayValue = default, /*optional */bool? _bDisplayValue = default)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	public /*final function */static void DrawVector(Object.Vector startPos, Object.Vector Direction, /*optional */float? _Size = default, /*optional */byte? _R = default, /*optional */byte? _G = default, /*optional */byte? _B = default, /*optional */bool? _persistentLines = default)
	{
		// stub
	}
	
	public /*final function */static void DrawLine(Object.Vector startPos, Object.Vector EndPos, /*optional */byte? _R = default, /*optional */byte? _G = default, /*optional */byte? _B = default, /*optional */bool? _persistentLines = default)
	{
		// stub
	}
	
	public /*final function */static void DrawMovementTrace(Object.Vector Start, Object.Vector End, Object.Vector Extent, /*optional */byte? _R = default, /*optional */byte? _G = default, /*optional */byte? _B = default, /*optional */bool? _persistentLines = default)
	{
		// stub
	}
	
	public /*final function */static void DrawExtent(Object.Vector Location, Object.Vector Extent, /*optional */byte? _R = default, /*optional */byte? _G = default, /*optional */byte? _B = default, /*optional */bool? _persistentLines = default)
	{
		// stub
	}
	
	public /*final function */static void DrawLineVector(Object.Vector startPos, Object.Vector EndPos, /*optional */byte? _R = default, /*optional */byte? _G = default, /*optional */byte? _B = default, /*optional */bool? _persistentLines = default)
	{
		// stub
	}
	
	public /*final function */static void DrawSizedVector(Object.Vector startPos, Object.Vector Direction, float SizeMultiplier, /*optional */byte? _R = default, /*optional */byte? _G = default, /*optional */byte? _B = default, /*optional */bool? _persistentLines = default)
	{
		// stub
	}
	
	public /*final function */static void DrawDistanceMarker(PlayerController Controller, Canvas C, Object.Vector startPos, Object.Vector EndPos, /*optional */byte? _R = default, /*optional */byte? _G = default, /*optional */byte? _B = default, /*optional */bool? _persistentLines = default)
	{
		// stub
	}
	
	public /*final function */static void DrawLoc(Object.Vector Location, float Size, /*optional */byte? _R = default, /*optional */byte? _G = default, /*optional */byte? _B = default, /*optional */bool? _persistentLines = default)
	{
		// stub
	}
	
	public /*final function */static void DrawLocAdvanced(Object.Vector Location, float Size, PlayerController Controller, Canvas C, String Text, /*optional */byte? _R = default, /*optional */byte? _G = default, /*optional */byte? _B = default, /*optional */bool? _persistentLines = default)
	{
		// stub
	}
	
	public /*final function */static void DrawLocAndValue(Object.Vector Location, float Size, PlayerController Controller, Canvas C, String Text, float Value, /*optional */byte? _R = default, /*optional */byte? _G = default, /*optional */byte? _B = default, /*optional */bool? _persistentLines = default)
	{
		// stub
	}
	
	public /*final function */static void DrawCoordinateAxis(Object.Vector inLoc, Object.Rotator inRot, float Size, /*optional */bool? _persistentLines = default)
	{
		// stub
	}
	
	public /*final function */static void DrawText3dPos(PlayerController Player, Canvas C, String Text, Object.Vector pos, /*optional */bool? _pinBottomLeft = default, /*optional */String? _lineBreaker = default, /*optional */bool? _bClearText = default)
	{
		// stub
	}
	
	public /*final function */static void DrawText(Canvas C, String Text, float X, float Y, /*optional */bool? _pinBottomLeft = default, /*optional */String? _lineBreaker = default)
	{
		// stub
	}
	
}
}