namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSwanNeck : Object/*
		native
		config(Game)
		hidecategories(Object)*/{
	public enum ESwanNeckType 
	{
		ESNT_Linear,
		ESNT_Quadratic,
		ESNT_MAX
	};
	
	public Object.Vector WantedTranslation;
	public Object.Vector Translation;
	public Object.Vector PreviousTranslation;
	public/*(SwanNeckSettings)*/ /*config */float LinearForwardTranslation;
	public/*(SwanNeckSettings)*/ /*config */float LinearDownwardTranslation;
	public/*(SwanNeckSettings)*/ /*config */float QuadraticForwardTranslation;
	public/*(SwanNeckSettings)*/ /*config */float QuadraticDownwardTranslation;
	public/*(SwanNeckSettings)*/ /*config */float StartTranslateAtDegree;
	public /*const */int ForwardPitchWorld;
	public /*const */int DownwardPitchWorld;
	public /*const */float DegToUnDeg;
	public/*(SwanNeckSettings)*/ /*config */TdSwanNeck.ESwanNeckType Type;
	
	// Export UTdSwanNeck::execGetSwanNeckPos(FFrame&, void* const)
	public virtual /*native function */Object.Vector GetSwanNeckPos(/*const */Object.Rotator FrameOfRefRotation)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	public virtual /*function */void UpdateSwanNeck(float DeltaTime, int ControllerPitch)
	{
		/*local */Object.Vector Diff = default;
	
		WantedTranslation = GetSwanNeckTranslation(ControllerPitch);
		Diff = WantedTranslation - Translation;
		Translation.X += FMin(Diff.X * FMin(1.0f, DeltaTime / 0.070f), QuadraticForwardTranslation);
		Translation.Y += FMin(Diff.Y * FMin(1.0f, DeltaTime / 0.070f), QuadraticDownwardTranslation);
	}
	
	public virtual /*function */Object.Vector GetSwanNeckTranslation(int ControllerPitch)
	{
		/*local */int StartTranslationPitchThreshold = default, StartTranslateDownwardsPitchThreshold = default, LimitDeltaPitch = default, DeltaPitch = default, TranslationPitch = default;
	
		/*local */float ForwardTranslation = default, DownwardTranslation = default;
		/*local */Object.Vector SwanNeckTranslation = default;
	
		ForwardTranslation = ((((int)Type) == ((int)TdSwanNeck.ESwanNeckType.ESNT_Linear/*0*/)) ? LinearForwardTranslation : QuadraticForwardTranslation);
		DownwardTranslation = ((((int)Type) == ((int)TdSwanNeck.ESwanNeckType.ESNT_Linear/*0*/)) ? LinearDownwardTranslation : QuadraticDownwardTranslation);
		StartTranslationPitchThreshold = ((int)(StartTranslateAtDegree * DegToUnDeg));
		StartTranslateDownwardsPitchThreshold = ((int)(StartTranslateAtDegree * DegToUnDeg));
		if((ControllerPitch > DownwardPitchWorld) && ControllerPitch < ForwardPitchWorld)
		{
			PreviousTranslation = Translation;
			ControllerPitch = ForwardPitchWorld - ControllerPitch;
			LimitDeltaPitch = ForwardPitchWorld - DownwardPitchWorld;
			if(ControllerPitch > StartTranslationPitchThreshold)
			{
				DeltaPitch = LimitDeltaPitch - StartTranslationPitchThreshold;
				TranslationPitch = ControllerPitch - StartTranslationPitchThreshold;
				SwanNeckTranslation.X = (ForwardTranslation / ((float)(DeltaPitch))) * ((float)(TranslationPitch));
				SwanNeckTranslation.X *= Cos(((((float)(TranslationPitch)) / ((float)(DeltaPitch))) * 3.1415930f) * 0.250f);			
			}
			else
			{
				SwanNeckTranslation.X = 0.0f;
			}
			if(ControllerPitch > StartTranslateDownwardsPitchThreshold)
			{
				DeltaPitch = LimitDeltaPitch - StartTranslateDownwardsPitchThreshold;
				TranslationPitch = ControllerPitch - StartTranslateDownwardsPitchThreshold;
				SwanNeckTranslation.Y = (DownwardTranslation / ((float)(DeltaPitch))) * ((float)(TranslationPitch));
				SwanNeckTranslation.Y *= Sin(((((float)(TranslationPitch)) / ((float)(DeltaPitch))) * 3.1415930f) * 0.250f);			
			}
			else
			{
				SwanNeckTranslation.Y = 0.0f;
			}		
		}
		else
		{
			SwanNeckTranslation.X = 0.0f;
			SwanNeckTranslation.Y = 0.0f;
		}
		return SwanNeckTranslation;
	}
	
	public TdSwanNeck()
	{
		// Object Offset:0x00673DC3
		LinearForwardTranslation = 25.0f;
		LinearDownwardTranslation = 25.0f;
		QuadraticForwardTranslation = 35.0f;
		QuadraticDownwardTranslation = 30.0f;
		StartTranslateAtDegree = 15.0f;
		ForwardPitchWorld = 65536;
		DownwardPitchWorld = 48151;
		DegToUnDeg = 182.0440f;
		Type = TdSwanNeck.ESwanNeckType.ESNT_Quadratic;
	}
}
}