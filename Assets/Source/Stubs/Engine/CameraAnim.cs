namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CameraAnim : Object/*
		native*/{
	public InterpGroup CameraInterpGroup;
	public float AnimLength;
	
	public CameraAnim()
	{
		// Object Offset:0x002B58A4
		AnimLength = 3.0f;
	}
}
}