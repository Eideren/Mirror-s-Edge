// NO OVERWRITE

namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Canvas : Object/*
		transient
		native
		noexport*/{
	public partial struct CanvasIcon
	{
		public Texture2D Texture;
		public float U;
		public float V;
		public float UL;
		public float VL;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002B7F36
	//		Texture = default;
	//		U = 0.0f;
	//		V = 0.0f;
	//		UL = 0.0f;
	//		VL = 0.0f;
	//	}
	};
	
	public Font Font;
	public float OrgX;
	public float OrgY;
	public float ClipX;
	public float ClipY;
	public float CurX;
	public float CurY;
	public float CurYL;
	public Object.Color DrawColor;
	public bool bCenter;
	public bool bNoSmooth;
	public /*const */int SizeX;
	public /*const */int SizeY;
	public /*native const */Object.Pointer Canvas_; // c# naming scheme renamed
	public /*native const */Object.Pointer SceneView;
	public Object.Plane ColorModulate;
	public Texture2D DefaultTexture;
	
	// Export UCanvas::execDrawTile(FFrame&, void* const)
	public virtual /*native final function */void DrawTile(Texture2D Tex, float XL, float YL, float U, float V, float UL, float VL)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UCanvas::execDrawMaterialTile(FFrame&, void* const)
	public virtual /*native final function */void DrawMaterialTile(MaterialInterface Mat, float XL, float YL, /*optional */float? _U = default, /*optional */float? _V = default, /*optional */float? _UL = default, /*optional */float? _VL = default)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UCanvas::execDrawMaterialTileClipped(FFrame&, void* const)
	public virtual /*native final function */void DrawMaterialTileClipped(MaterialInterface Mat, float XL, float YL, /*optional */float? _U = default, /*optional */float? _V = default, /*optional */float? _UL = default, /*optional */float? _VL = default)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UCanvas::execStrLen(FFrame&, void* const)
	public virtual /*native final function */void StrLen(/*coerce */String String, ref float XL, ref float YL)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UCanvas::execTextSize(FFrame&, void* const)
	public virtual /*native final function */void TextSize(/*coerce */String String, ref float XL, ref float YL)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UCanvas::execDrawText(FFrame&, void* const)
	public virtual /*native final function */void DrawText(/*coerce */String Text, /*optional */bool? _CR = default, /*optional */float? _XScale = default, /*optional */float? _YScale = default)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UCanvas::execDrawTextClipped(FFrame&, void* const)
	public virtual /*native final function */void DrawTextClipped(/*coerce */String Text, /*optional */bool? _bCheckHotKey = default, /*optional */float? _XScale = default, /*optional */float? _YScale = default)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	public virtual /*final function */void DrawTextRA(/*coerce */String Text, /*optional */bool? _CR = default)
	{
	
	}
	
	// Export UCanvas::execDrawTileClipped(FFrame&, void* const)
	public virtual /*native(468) final function */void DrawTileClipped(Texture2D Tex, float XL, float YL, float U, float V, float UL, float VL)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UCanvas::execProject(FFrame&, void* const)
	public virtual /*native final function */Object.Vector Project(Object.Vector Location)
	{
		 NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UCanvas::execPushTranslationMatrix(FFrame&, void* const)
	public virtual /*native final function */void PushTranslationMatrix(Object.Vector TranslationVector)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UCanvas::execPopTransform(FFrame&, void* const)
	public virtual /*native final function */void PopTransform()
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UCanvas::execDrawTileStretched(FFrame&, void* const)
	public virtual /*native final function */void DrawTileStretched(Texture2D Tex, float XL, float YL, float U, float V, float UL, float VL, Object.LinearColor LColor, /*optional */bool? _bStretchHorizontally = default, /*optional */bool? _bStretchVertically = default, /*optional */float? _ScalingFactor = default)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UCanvas::execDrawColorizedTile(FFrame&, void* const)
	public virtual /*native final function */void DrawColorizedTile(Texture2D Tex, float XL, float YL, float U, float V, float UL, float VL, Object.LinearColor LColor)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	public virtual /*event */void Reset(/*optional */bool? _bKeepOrigin = default)
	{
	
	}
	
	// Export UCanvas::execSetPos(FFrame&, void* const)
	public virtual /*native final function */void SetPos(float PosX, float PosY)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	public virtual /*final function */void SetOrigin(float X, float Y)
	{
	
	}
	
	public virtual /*final function */void SetClip(float X, float Y)
	{
	
	}
	
	public virtual /*final function */void DrawTexture(Texture2D Tex, float Scale)
	{
	
	}
	
	public virtual /*final function */Canvas.CanvasIcon MakeIcon(Texture2D Texture, /*optional */float? _U = default, /*optional */float? _V = default, /*optional */float? _UL = default, /*optional */float? _VL = default)
	{
	
		return default;
	}
	
	public virtual /*final function */void DrawIcon(Canvas.CanvasIcon Icon, float X, float Y, /*optional */float? _Scale = default)
	{
	
	}
	
	public virtual /*final function */void DrawIconSection(Canvas.CanvasIcon Icon, float X, float Y, float UStartPct, float VStartPct, float UEndPct, float VEndPct, /*optional */float? _Scale = default)
	{
	
	}
	
	public virtual /*final function */void DrawRect(float RectX, float RectY, /*optional */Texture2D _Tex = default)
	{
	
	}
	
	public virtual /*final simulated function */void DrawBox(float Width, float Height)
	{
	
	}
	
	// Export UCanvas::execSetDrawColor(FFrame&, void* const)
	public virtual /*native final function */void SetDrawColor(byte R, byte G, byte B, /*optional */byte? _A = default)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UCanvas::execDrawRotatedTile(FFrame&, void* const)
	public virtual /*native final function */void DrawRotatedTile(Texture2D Tex, Object.Rotator Rotation, float XL, float YL, float U, float V, float UL, float VL, /*optional */float? _AnchorX = default, /*optional */float? _AnchorY = default)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UCanvas::execDrawRotatedMaterialTile(FFrame&, void* const)
	public virtual /*native final function */void DrawRotatedMaterialTile(MaterialInterface Mat, Object.Rotator Rotation, float XL, float YL, /*optional */float? _U = default, /*optional */float? _V = default, /*optional */float? _UL = default, /*optional */float? _VL = default, /*optional */float? _AnchorX = default, /*optional */float? _AnchorY = default)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UCanvas::execDraw2DLine(FFrame&, void* const)
	public virtual /*native final function */void Draw2DLine(float X1, float Y1, float X2, float Y2, Object.Color LineColor)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UCanvas::execDrawTextureLine(FFrame&, void* const)
	public virtual /*native final function */void DrawTextureLine(Object.Vector StartPoint, Object.Vector EndPoint, float Perc, float Width, Object.Color LineColor, Texture2D LineTexture, float U, float V, float UL, float VL)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UCanvas::execDrawTextureDoubleLine(FFrame&, void* const)
	public virtual /*native final function */void DrawTextureDoubleLine(Object.Vector StartPoint, Object.Vector EndPoint, float Perc, float Spacing, float Width, Object.Color LineColor, Object.Color AltLineColor, Texture2D Tex, float U, float V, float UL, float VL)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	public Canvas()
	{
		// Object Offset:0x002BAE06
		Font = LoadAsset<Font>("EngineFonts.SmallFont")/*Ref Font'EngineFonts.SmallFont'*/;
		DrawColor = new Color
		{
			R=127,
			G=127,
			B=127,
			A=255
		};
		ColorModulate = new Plane
		{
			X=1.0f,
			Y=1.0f,
			Z=1.0f,
			W=1.0f
		};
		DefaultTexture = LoadAsset<Texture2D>("EngineResources.WhiteSquareTexture")/*Ref Texture2D'EngineResources.WhiteSquareTexture'*/;
	}
}
}