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
		[Category] public GameSkelCtrl_Recoil.ERecoilStart X;
		[Category] public GameSkelCtrl_Recoil.ERecoilStart Y;
		[Category] public GameSkelCtrl_Recoil.ERecoilStart Z;
		[Const, transient] public byte Padding;
	
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
		[transient] public float TimeToGo;
		[Category] public float TimeDuration;
		[Category] public Object.Vector RotAmplitude;
		[Category] public Object.Vector RotFrequency;
		public Object.Vector RotSinOffset;
		[Category] public GameSkelCtrl_Recoil.RecoilParams RotParams;
		[transient] public Object.Rotator RotOffset;
		[Category] public Object.Vector LocAmplitude;
		[Category] public Object.Vector LocFrequency;
		public Object.Vector LocSinOffset;
		[Category] public GameSkelCtrl_Recoil.RecoilParams LocParams;
		[transient] public Object.Vector LocOffset;
	
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
	
	[Category] public bool bBoneSpaceRecoil;
	[Category] [transient] public bool bPlayRecoil;
	[transient] public bool bOldPlayRecoil;
	[transient] public bool bApplyControl;
	[Category] public GameSkelCtrl_Recoil.RecoilDef Recoil;
	[Category] public Object.Vector2D Aim;
	
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