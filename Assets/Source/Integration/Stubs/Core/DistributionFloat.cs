namespace MEdge.Core{
using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DistributionFloat : Component/*
		abstract
		native
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	public partial struct /*native */RawDistributionFloat// extends RawDistribution
	{
		public byte Type;
		public byte Op;
		public byte LookupTableNumElements;
		public byte LookupTableChunkSize;
		public array<float> LookupTable;
		public float LookupTableTimeScale;
		public float LookupTableStartTime;
	
		public/*()*/ /*noclear export editinline */DistributionFloat Distribution;
			// Object Offset:0x0001FDC8
	//		Type = 0;
	//		Op = 0;
	//		LookupTableNumElements = 0;
	//		LookupTableChunkSize = 0;
	//		LookupTable = default;
	//		LookupTableTimeScale = 0.0f;
	//		LookupTableStartTime = 0.0f;
	//
	//	structdefaultproperties
	//	{
	//	}
	};
	
	public /*private native const noexport */Object.Pointer VfTable_FCurveEdInterface;
	public/*(Baked)*/ bool bCanBeBaked;
	public bool bIsDirty;
	
	public DistributionFloat()
	{
		// Object Offset:0x0002DF60
		bCanBeBaked = true;
		bIsDirty = true;
	}
}
}