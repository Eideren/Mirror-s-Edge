namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_ForceMaterialMipsResident : SeqAct_Latent/*
		native
		hidecategories(Object)*/{
	public/*()*/ float ForceDuration;
	public/*()*/ array<MaterialInterface> ForceMaterials;
	public float RemainingTime;
	public array<Texture2D> ModifiedTextures;
	
	public SeqAct_ForceMaterialMipsResident()
	{
		// Object Offset:0x003C2979
		ForceDuration = 1.0f;
		InputLinks = new array<SequenceOp.SeqOpInputLink>
		{
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Start",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
		};
		VariableLinks = default;
		ObjName = "Force Material Mips Resident";
		ObjCategory = "Misc";
	}
}
}