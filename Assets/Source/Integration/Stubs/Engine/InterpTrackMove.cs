namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InterpTrackMove : InterpTrack/*
		native
		collapsecategories
		hidecategories(Object)*/{
	public enum EInterpTrackMoveFrame 
	{
		IMF_World,
		IMF_RelativeToInitial,
		IMF_MAX
	};
	
	public enum EInterpTrackMoveRotMode 
	{
		IMR_Keyframed,
		IMR_LookAtGroup,
		IMR_MAX
	};
	
	public partial struct /*native */InterpLookupPoint
	{
		public name GroupName;
		public float Time;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00343945
	//		GroupName = (name)"None";
	//		Time = 0.0f;
	//	}
	};
	
	public partial struct /*native */InterpLookupTrack
	{
		public array<InterpTrackMove.InterpLookupPoint> Points;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00343A19
	//		Points = default;
	//	}
	};
	
	public Object.InterpCurveVector PosTrack;
	public Object.InterpCurveVector EulerTrack;
	public InterpTrackMove.InterpLookupTrack LookupTrack;
	[Category] public name LookAtGroupName;
	[Category] public float LinCurveTension;
	[Category] public float AngCurveTension;
	[Category] public bool bUseQuatInterpolation;
	[Category] public bool bShowArrowAtKeys;
	[Category] public bool bDisableMovement;
	[Category] public bool bShowTranslationOnCurveEd;
	[Category] public bool bShowRotationOnCurveEd;
	[Category] public bool bHide3DTrack;
	[Category] [editconst] public InterpTrackMove.EInterpTrackMoveFrame MoveFrame;
	[Category] public InterpTrackMove.EInterpTrackMoveRotMode RotMode;
	
	public InterpTrackMove()
	{
		// Object Offset:0x00343ACD
		bShowTranslationOnCurveEd = true;
		TrackInstClass = ClassT<InterpTrackInstMove>()/*Ref Class'InterpTrackInstMove'*/;
		TrackTitle = "Movement";
		bOnePerGroup = true;
	}
}
}