namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SampleClass : Actor/*
		native
		config(Game)
		placeable
		hidecategories(Navigation)*/{
	public int MyInteger;
	public /*config */String MyString;
	public bool MyBool;
	public Object.Vector MyVector;
	public /*native */Object.Pointer MyPointer;
	
	// Export USampleClass::execSampleNativeFunction(FFrame&, void* const)
	public virtual /*native function */int SampleNativeFunction(int I, String S, Object.Vector V)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*event */void SampleEvent(int I)
	{
	
	}
	
	public override /*function */void PostBeginPlay()
	{
	
	}
	
	public override Timer_del Timer { get => bfield_Timer ?? SampleClass_Timer; set => bfield_Timer = value; } Timer_del bfield_Timer;
	public override Timer_del global_Timer => SampleClass_Timer;
	public /*function */void SampleClass_Timer()
	{
	
	}
	protected override void RestoreDefaultFunction()
	{
		Timer = null;
	
	}
	public SampleClass()
	{
		// Object Offset:0x0048EB1B
		MyString = "Test";
		Components = new array</*export editinline */ActorComponent>
		{
			new SpriteComponent
			{
				// Object Offset:0x02E51BF1
				HiddenGame = true,
				AlwaysLoadOnClient = false,
				AlwaysLoadOnServer = false,
			}/* Reference: SpriteComponent'Default__SampleClass.Sprite' */,
		};
	}
}
}