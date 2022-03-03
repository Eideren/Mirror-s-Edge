namespace MEdge.Engine{
using Source; using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DistributionFloatUniform : DistributionFloat/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	[Category] public float Min;
	[Category] public float Max;
	
	public override float GetValue( float F, Object Data )
	{
		if( Min == 0f && Max == 0f )
		{
			// This is a workaround, not sure why but min and max are zero when that's not expected, perhaps through t3d export
			Min = 0.95f;
			Max = 1.05f;
		}

		return Max + (Min - Max) * DecFn.appSRand();
	}
	
}
}