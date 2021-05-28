namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UISettingsProvider : UIPropertyDataProvider/*
		abstract
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public /*const */name ProviderTag;
	
	public virtual /*function */void LoadPropertyValue(name PropertyName, UIObject Widget)
	{
	
	}
	
	public virtual /*function */void SavePropertyValue(name PropertyName, UIObject Widget)
	{
	
	}
	
	public virtual /*function */bool OnModifiedProperty(name PropertyName, UIObject Widget)
	{
	
		return default;
	}
	
	public virtual /*function */bool CleanupDataProvider()
	{
	
		return default;
	}
	
	public UISettingsProvider()
	{
		// Object Offset:0x003A212E
		ProviderTag = (name)"SettingsProvider";
	}
}
}