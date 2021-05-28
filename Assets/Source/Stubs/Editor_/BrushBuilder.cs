namespace MEdge.Editor{
using Core; using Engine; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class BrushBuilder : Object/*
		abstract
		native
		hidecategories(Object,BrushBuilder)*/{
	public partial struct BuilderPoly
	{
		public array<int> VertexIndices;
		public int Direction;
		public name Item;
		public int PolyFlags;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0000AB5C
	//		VertexIndices = default;
	//		Direction = 0;
	//		Item = (name)"None";
	//		PolyFlags = 0;
	//	}
	};
	
	public/*()*/ string BitmapFilename;
	public/*()*/ string ToolTip;
	public /*private */array<Object.Vector> Vertices;
	public /*private */array<BrushBuilder.BuilderPoly> Polys;
	public /*private */name Group;
	public /*private */bool MergeCoplanars;
	
	// Export UBrushBuilder::execBeginBrush(FFrame&, void* const)
	public virtual /*native function */void BeginBrush(bool InMergeCoplanars, name InGroup)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UBrushBuilder::execEndBrush(FFrame&, void* const)
	public virtual /*native function */bool EndBrush()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UBrushBuilder::execGetVertexCount(FFrame&, void* const)
	public virtual /*native function */int GetVertexCount()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UBrushBuilder::execGetVertex(FFrame&, void* const)
	public virtual /*native function */Object.Vector GetVertex(int I)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UBrushBuilder::execGetPolyCount(FFrame&, void* const)
	public virtual /*native function */int GetPolyCount()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UBrushBuilder::execBadParameters(FFrame&, void* const)
	public virtual /*native function */bool BadParameters(/*optional */string msg = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UBrushBuilder::execVertexv(FFrame&, void* const)
	public virtual /*native function */int Vertexv(Object.Vector V)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UBrushBuilder::execVertex3f(FFrame&, void* const)
	public virtual /*native function */int Vertex3f(float X, float Y, float Z)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UBrushBuilder::execPoly3i(FFrame&, void* const)
	public virtual /*native function */void Poly3i(int Direction, int I, int J, int K, /*optional */name ItemName = default, /*optional */bool bIsTwoSidedNonSolid = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UBrushBuilder::execPoly4i(FFrame&, void* const)
	public virtual /*native function */void Poly4i(int Direction, int I, int J, int K, int L, /*optional */name ItemName = default, /*optional */bool bIsTwoSidedNonSolid = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UBrushBuilder::execPolyBegin(FFrame&, void* const)
	public virtual /*native function */void PolyBegin(int Direction, /*optional */name ItemName = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UBrushBuilder::execPolyi(FFrame&, void* const)
	public virtual /*native function */void Polyi(int I)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UBrushBuilder::execPolyEnd(FFrame&, void* const)
	public virtual /*native function */void PolyEnd()
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*event */bool Build()
	{
	
		return default;
	}
	
	public BrushBuilder()
	{
		// Object Offset:0x0000B563
		BitmapFilename = "BBGeneric";
		ToolTip = "Generic Builder";
	}
}
}