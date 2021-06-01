namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataProvider_TdAccountProvider : UIDataProvider_TdResource/*
		transient
		native
		config(Game)
		perobjectconfig
		hidecategories(Object,UIRoot)*/{
	public partial struct /*native */ECountryPair
	{
		public String CountryName;
		public String Tag;
		public int RegisterMinAge;
		public int ParentalControlMinAge;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x006D7E00
	//		CountryName = "";
	//		Tag = "";
	//		RegisterMinAge = -1;
	//		ParentalControlMinAge = -1;
	//	}
	};
	
	public array<UIDataProvider_TdAccountProvider.ECountryPair> Countries;
	
	public virtual /*event */void OnRegister(LocalPlayer InPlayer)
	{
	
	}
	
	public virtual /*event */void OnUnregister()
	{
	
	}
	
	public virtual /*function */void AddCountry(String CountryName, String CountryTag, int RegisterMinAge, int ParentalControlMinAge)
	{
	
	}
	
	public virtual /*function */void ClearCountries()
	{
	
	}
	
	public UIDataProvider_TdAccountProvider()
	{
		// Object Offset:0x006D8152
		WriteAccessType = UIDataProvider.EProviderAccessType.ACCESS_WriteAll;
	}
}
}