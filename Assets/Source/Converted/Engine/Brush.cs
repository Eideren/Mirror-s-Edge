namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Brush : Actor/*
		native
		notplaceable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public enum ECsgOper 
	{
		CSG_Active,
		CSG_Add,
		CSG_Subtract,
		CSG_Intersect,
		CSG_Deintersect,
		CSG_MAX
	};
	
	public partial struct /*native export */GeomSelection
	{
		public int Type;
		public int Index;
		public int SelectionIndex;
		public float SelStrength;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002B168E
	//		Type = 0;
	//		Index = 0;
	//		SelectionIndex = 0;
	//		SelStrength = 0.0f;
	//	}
	};
	
	public/*()*/ Brush.ECsgOper CsgOper;
	public/*()*/ Object.Color BrushColor;
	public int PolyFlags;
	public/*()*/ bool bColored;
	public bool bSolidWhenSelected;
	public /*const export */Model Brush;
	public /*const editconst export editinline */BrushComponent BrushComponent;
	public array<Brush.GeomSelection> SavedSelections;
	
	public Brush()
	{
		var Default__Brush_BrushComponent0 = new BrushComponent
		{
		}/* Reference: BrushComponent'Default__Brush.BrushComponent0' */;
		// Object Offset:0x002B1736
		BrushComponent = Default__Brush_BrushComponent0/*Ref BrushComponent'Default__Brush.BrushComponent0'*/;
		bStatic = true;
		bHidden = true;
		bNoDelete = true;
		bEdShouldSnap = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__Brush_BrushComponent0/*Ref BrushComponent'Default__Brush.BrushComponent0'*/,
		};
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
		CollisionComponent = Default__Brush_BrushComponent0/*Ref BrushComponent'Default__Brush.BrushComponent0'*/;
	}
}
}