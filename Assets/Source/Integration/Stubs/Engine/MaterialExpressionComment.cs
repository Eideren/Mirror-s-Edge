namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialExpressionComment : MaterialExpression/* within Material*//*
		native*/{
	public new Material Outer => base.Outer as Material;
	
	public int PosX;
	public int PosY;
	public int SizeX;
	public int SizeY;
	public/*()*/ String Text;
	
}
}