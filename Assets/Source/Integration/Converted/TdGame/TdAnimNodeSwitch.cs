namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAnimNodeSwitch : TdAnimNodeBlendList/*
		native
		hidecategories(Object,Object,Object)*/{
	// Export UTdAnimNodeSwitch::execGetActiveState(FFrame&, void* const)
	//public virtual /*native function */int GetActiveState()
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	return default;
	//}
	
	// Export UTdAnimNodeSwitch::execGetState(FFrame&, void* const)
	public virtual /*native simulated function */bool GetState()
	{
		// This works like an abstract function afaik, never actually called,
		// just defined for children to override its behavior
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	public virtual /*event */void OnInitialize()
	{
	
	}
	
	public override /*event */void OnBecomeRelevant()
	{
		SetActiveChild(GetActiveState(), 0.0f);
		base.OnBecomeRelevant();
	}
	
	public virtual /*event */bool EditorGetState()
	{
		return true;
	}
	
	public virtual /*event */void StateSwitched()
	{
	
	}
	
	public TdAnimNodeSwitch()
	{
		// Object Offset:0x004FCFF9
		Children = new array</*export editinline */AnimNodeBlendBase.AnimBlendChild>
		{
			new AnimNodeBlendBase.AnimBlendChild
			{
				Name = (name)"Yes",
				Anim = default,
				Weight = 0.0f,
				TotalWeight = 0.0f,
				bHasRootMotion = false,
				RootMotion = new AnimNode.BoneAtom
				{
					Rotation = new Quat
					{
						X=0.0f,
						Y=0.0f,
						Z=0.0f,
						W=0.0f
					},
					Translation = new Vector
					{
						X=0.0f,
						Y=0.0f,
						Z=0.0f
					},
					Scale = 0.0f,
				},
				bMirrorSkeleton = false,
				DrawY = 0,
			},
			new AnimNodeBlendBase.AnimBlendChild
			{
				Name = (name)"No",
				Anim = default,
				Weight = 0.0f,
				TotalWeight = 0.0f,
				bHasRootMotion = false,
				RootMotion = new AnimNode.BoneAtom
				{
					Rotation = new Quat
					{
						X=0.0f,
						Y=0.0f,
						Z=0.0f,
						W=0.0f
					},
					Translation = new Vector
					{
						X=0.0f,
						Y=0.0f,
						Z=0.0f
					},
					Scale = 0.0f,
				},
				bMirrorSkeleton = false,
				DrawY = 0,
			},
		};
		bFixNumChildren = true;
	}
}
}