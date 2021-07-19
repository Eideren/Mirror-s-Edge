namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_SetMatInstTexParam : SequenceAction/*
		native
		hidecategories(Object)*/{
	[Category] public MaterialInstanceConstant MatInst;
	[Category] public Texture NewTexture;
	[Category] public name ParamName;
	
	public SeqAct_SetMatInstTexParam()
	{
		// Object Offset:0x003CDEB2
		VariableLinks = default;
		ObjName = "Set TextureParam";
		ObjCategory = "Material Instance";
	}
}
}