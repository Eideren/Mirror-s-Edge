// NO OVERWRITE

namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SessionSettingsProvider : UISettingsProvider/* within UIDataStore_SessionSettings*//*
		abstract
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public new UIDataStore_SessionSettings Outer => base.Outer as UIDataStore_SessionSettings;
	
	[Const] public/*private*/ Core.ClassT<UISettingsClient> ProviderClientClass;
	[Const] public Class ProviderClientMetaClass;
	[Const, transient] public Class ProviderClient;
	
	// Export USessionSettingsProvider::execBindProviderClient(FFrame&, void* const)
	public virtual /*native final function */bool BindProviderClient(Class DataSourceClass)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export USessionSettingsProvider::execUnbindProviderClient(FFrame&, void* const)
	public virtual /*native final function */bool UnbindProviderClient()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	public virtual /*event */void ProviderClientBound(Class DataSourceClass)
	{
	
	}
	
	public virtual /*event */void ProviderClientUnbound(Class DataSourceClass)
	{
	
	}
	
	public virtual /*event */bool IsValidDataSourceClass(Class PotentialDataSourceClass)
	{
	
		return default;
	}
	
	public override /*function */bool CleanupDataProvider()
	{
	
		return default;
	}
	
	public SessionSettingsProvider()
	{
		// Object Offset:0x003E1BD6
		#warning commented out impossible to fullfil constraints, ClassT<> requires a class type
		//ProviderClientClass = ClassT<UISettingsClient>()/*Ref Class'UISettingsClient'*/;
		ProviderTag = (name)"SessionSettingsProvider";
	}
}
}