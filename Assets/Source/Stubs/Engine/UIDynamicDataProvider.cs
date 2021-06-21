namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDynamicDataProvider : UIPropertyDataProvider/*
		abstract
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public /*const */Class DataClass;
	public /*protected const transient */Object DataSource;
	
	// Export UUIDynamicDataProvider::execBindProviderInstance(FFrame&, void* const)
	public virtual /*native final function */bool BindProviderInstance(Object DataSourceInstance)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UUIDynamicDataProvider::execUnbindProviderInstance(FFrame&, void* const)
	public virtual /*native final function */bool UnbindProviderInstance()
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public virtual /*event */void ProviderInstanceBound(Object DataSourceInstance)
	{
		// stub
	}
	
	public virtual /*event */void ProviderInstanceUnbound(Object DataSourceInstance)
	{
		// stub
	}
	
	public virtual /*event */bool IsValidDataSourceClass(Class PotentialDataSourceClass)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */Object GetDataSource()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool CleanupDataProvider()
	{
		// stub
		return default;
	}
	
}
}