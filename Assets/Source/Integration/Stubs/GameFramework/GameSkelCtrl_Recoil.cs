namespace MEdge.GameFramework{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class GameSkelCtrl_Recoil : SkelControlBase/*
		native
		hidecategories(Object)*/{
	public enum ERecoilStart 
	{
		ERS_Zero,
		ERS_Random,
		ERS_MAX
	};
	
	public partial struct /*native */RecoilParams
	{
		public/*()*/ GameSkelCtrl_Recoil.ERecoilStart X;
		public/*()*/ GameSkelCtrl_Recoil.ERecoilStart Y;
		public/*()*/ GameSkelCtrl_Recoil.ERecoilStart Z;
		public /*const transient */byte Padding;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0000790E
	//		X = GameSkelCtrl_Recoil.ERecoilStart.ERS_Zero;
	//		Y = GameSkelCtrl_Recoil.ERecoilStart.ERS_Zero;
	//		Z = GameSkelCtrl_Recoil.ERecoilStart.ERS_Zero;
	//		Padding = 0;
	//	}
	};
	
	public partial struct /*native */RecoilDef
	{
		public /*transient */float TimeToGo;
		public/*()*/ float TimeDuration;
		public/*()*/ Object.Vector RotAmplitude;
		public/*()*/ Object.Vector RotFrequency;
		public Object.Vector RotSinOffset;
		public/*()*/ GameSkelCtrl_Recoil.RecoilParams RotParams;
		public /*transient */Object.Rotator RotOffset;
		public/*()*/ Object.Vector LocAmplitude;
		public/*()*/ Object.Vector LocFrequency;
		public Object.Vector LocSinOffset;
		public/*()*/ GameSkelCtrl_Recoil.RecoilParams LocParams;
		public /*transient */Object.Vector LocOffset;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00007BF7
	//		TimeToGo = 0.0f;
	//		TimeDuration = 0.330f;
	//		RotAmplitude = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		RotFrequency = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		RotSinOffset = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		RotParams = new GameSkelCtrl_Recoil.RecoilParams
	//		{
	//			X = GameSkelCtrl_Recoil.ERecoilStart.ERS_Zero,
	//			Y = GameSkelCtrl_Recoil.ERecoilStart.ERS_Zero,
	//			Z = GameSkelCtrl_Recoil.ERecoilStart.ERS_Zero,
	//			Padding = 0,
	//		};
	//		RotOffset = new Rotator
	//		{
	//			Pitch=0,
	//			Yaw=0,
	//			Roll=0
	//		};
	//		LocAmplitude = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		LocFrequency = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		LocSinOffset = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		LocParams = new GameSkelCtrl_Recoil.RecoilParams
	//		{
	//			X = GameSkelCtrl_Recoil.ERecoilStart.ERS_Zero,
	//			Y = GameSkelCtrl_Recoil.ERecoilStart.ERS_Zero,
	//			Z = GameSkelCtrl_Recoil.ERecoilStart.ERS_Zero,
	//			Padding = 0,
	//		};
	//		LocOffset = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//	}
	};
	
	public/*()*/ bool bBoneSpaceRecoil;
	public/*()*/ /*transient */bool bPlayRecoil;
	public /*transient */bool bOldPlayRecoil;
	public /*transient */bool bApplyControl;
	public/*()*/ GameSkelCtrl_Recoil.RecoilDef Recoil;
	public/*()*/ Object.Vector2D Aim;
	
	public GameSkelCtrl_Recoil()
	{
		// Object Offset:0x00008019
		Recoil = new GameSkelCtrl_Recoil.RecoilDef
		{
			TimeToGo = 0.0f,
			TimeDuration = 0.330f,
			RotAmplitude = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			RotFrequency = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			RotSinOffset = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			RotParams = new GameSkelCtrl_Recoil.RecoilParams
			{
				X = GameSkelCtrl_Recoil.ERecoilStart.ERS_Zero,
				Y = GameSkelCtrl_Recoil.ERecoilStart.ERS_Zero,
				Z = GameSkelCtrl_Recoil.ERecoilStart.ERS_Zero,
				Padding = 0,
			},
			RotOffset = new Rotator
			{
				Pitch=0,
				Yaw=0,
				Roll=0
			},
			LocAmplitude = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			LocFrequency = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			LocSinOffset = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			LocParams = new GameSkelCtrl_Recoil.RecoilParams
			{
				X = GameSkelCtrl_Recoil.ERecoilStart.ERS_Zero,
				Y = GameSkelCtrl_Recoil.ERecoilStart.ERS_Zero,
				Z = GameSkelCtrl_Recoil.ERecoilStart.ERS_Zero,
				Padding = 0,
			},
			LocOffset = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
		};
	}
}
}