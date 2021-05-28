namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataProvider_TdStringArray : UIDataProvider_TdSimpleElementProvider/*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public array<string> Strings;
	
	// Export UUIDataProvider_TdStringArray::execGetElementCount(FFrame&, void* const)
	public override /*native function */int GetElementCount()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
}
}