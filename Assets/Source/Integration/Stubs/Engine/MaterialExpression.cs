namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialExpression : Object/* within Material*//*
		abstract
		native*/{
	public partial struct ExpressionInput
	{
		public MaterialExpression Expression;
		public int Mask;
		public int MaskR;
		public int MaskG;
		public int MaskB;
		public int MaskA;
		public int GCC64_Padding;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00355ACC
	//		Expression = default;
	//		Mask = 0;
	//		MaskR = 0;
	//		MaskG = 0;
	//		MaskB = 0;
	//		MaskA = 0;
	//		GCC64_Padding = 0;
	//	}
	};
	
	public new Material Outer => base.Outer as Material;
	
	public int EditorX;
	public int EditorY;
	[Category] public bool bRealtimePreview;
	public bool bIsParameterExpression;
	[Const] public MaterialExpressionCompound Compound;
	[Category] public String Desc;
	
}
}