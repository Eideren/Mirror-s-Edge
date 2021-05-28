namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdDebugOutput : Object/*
		native*/{
	// Export UTdDebugOutput::execDrawGraph(FFrame&, void* const)
	public /*native final function */static void DrawGraph(Canvas C)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdDebugOutput::execAddGraphValue(FFrame&, void* const)
	public /*native final function */static void AddGraphValue(name graph, float Val, /*optional */float DisplayValue = default, /*optional */bool bDisplayValue = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	public /*final function */static void DrawVector(Object.Vector startPos, Object.Vector Direction, /*optional */float Size = default, /*optional */byte R = default, /*optional */byte G = default, /*optional */byte B = default, /*optional */bool persistentLines = default)
	{
	
	}
	
	public /*final function */static void DrawLine(Object.Vector startPos, Object.Vector EndPos, /*optional */byte R = default, /*optional */byte G = default, /*optional */byte B = default, /*optional */bool persistentLines = default)
	{
	
	}
	
	public /*final function */static void DrawMovementTrace(Object.Vector Start, Object.Vector End, Object.Vector Extent, /*optional */byte R = default, /*optional */byte G = default, /*optional */byte B = default, /*optional */bool persistentLines = default)
	{
	
	}
	
	public /*final function */static void DrawExtent(Object.Vector Location, Object.Vector Extent, /*optional */byte R = default, /*optional */byte G = default, /*optional */byte B = default, /*optional */bool persistentLines = default)
	{
	
	}
	
	public /*final function */static void DrawLineVector(Object.Vector startPos, Object.Vector EndPos, /*optional */byte R = default, /*optional */byte G = default, /*optional */byte B = default, /*optional */bool persistentLines = default)
	{
	
	}
	
	public /*final function */static void DrawSizedVector(Object.Vector startPos, Object.Vector Direction, float SizeMultiplier, /*optional */byte R = default, /*optional */byte G = default, /*optional */byte B = default, /*optional */bool persistentLines = default)
	{
	
	}
	
	public /*final function */static void DrawDistanceMarker(PlayerController Controller, Canvas C, Object.Vector startPos, Object.Vector EndPos, /*optional */byte R = default, /*optional */byte G = default, /*optional */byte B = default, /*optional */bool persistentLines = default)
	{
	
	}
	
	public /*final function */static void DrawLoc(Object.Vector Location, float Size, /*optional */byte R = default, /*optional */byte G = default, /*optional */byte B = default, /*optional */bool persistentLines = default)
	{
	
	}
	
	public /*final function */static void DrawLocAdvanced(Object.Vector Location, float Size, PlayerController Controller, Canvas C, string Text, /*optional */byte R = default, /*optional */byte G = default, /*optional */byte B = default, /*optional */bool persistentLines = default)
	{
	
	}
	
	public /*final function */static void DrawLocAndValue(Object.Vector Location, float Size, PlayerController Controller, Canvas C, string Text, float Value, /*optional */byte R = default, /*optional */byte G = default, /*optional */byte B = default, /*optional */bool persistentLines = default)
	{
	
	}
	
	public /*final function */static void DrawCoordinateAxis(Object.Vector inLoc, Object.Rotator inRot, float Size, /*optional */bool persistentLines = default)
	{
	
	}
	
	public /*final function */static void DrawText3dPos(PlayerController Player, Canvas C, string Text, Object.Vector pos, /*optional */bool pinBottomLeft = default, /*optional */string lineBreaker = default, /*optional */bool bClearText = default)
	{
	
	}
	
	public /*final function */static void DrawText(Canvas C, string Text, float X, float Y, /*optional */bool pinBottomLeft = default, /*optional */string lineBreaker = default)
	{
	
	}
	
}
}