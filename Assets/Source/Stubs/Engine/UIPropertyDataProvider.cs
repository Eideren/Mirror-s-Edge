namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIPropertyDataProvider : UIDataProvider/*
		abstract
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public /*const */array< Core.ClassT<Property> > ComplexPropertyTypes;
	
	public virtual /*event */bool GetCustomPropertyValue(ref UIRoot.UIProviderScriptFieldValue PropertyValue, /*optional */int? _ArrayIndex = default)
	{
		// stub
		return default;
	}
	
	public UIPropertyDataProvider()
	{
		// Object Offset:0x002F7716
		ComplexPropertyTypes = new array< Core.ClassT<Property> >
		{
			ClassT<StructProperty>(),
			ClassT<MapProperty>(),
			ClassT<ArrayProperty>(),
			ClassT<DelegateProperty>(),
		};
	}
}
}