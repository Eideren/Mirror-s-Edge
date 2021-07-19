namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Input : Interaction/*
		transient
		native
		config(Input)
		hidecategories(Object,UIRoot)*/{
	public partial struct /*native */KeyBind
	{
		[config] public name Name;
		[config] public String Command;
		[config] public bool Control;
		[config] public bool Shift;
		[config] public bool Alt;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002FFCDB
	//		Name = (name)"None";
	//		Command = "";
	//		Control = false;
	//		Shift = false;
	//		Alt = false;
	//	}
	};
	
	public partial struct /*native */InputOverridePair
	{
		[config] public name Key;
		[config] public Input.KeyBind Binding;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002FFF7B
	//		Key = (name)"None";
	//		Binding = new Input.KeyBind
	//		{
	//			Name = (name)"None",
	//			Command = "",
	//			Control = false,
	//			Shift = false,
	//			Alt = false,
	//		};
	//	}
	};
	
	[config] public array</*config */Input.KeyBind> Bindings;
	[config] public array</*config */Input.InputOverridePair> OverrideBindings;
	[Const] public array<name> PressedKeys;
	[Const] public Object.EInputEvent CurrentEvent;
	[Const] public float CurrentDelta;
	[Const] public float CurrentDeltaTime;
	[native, Const] public /*map<0,0>*/map<object, object> NameToPtr;
	[init, native, Const] public array</*init */Object.Pointer> AxisArray;
	
	// Export UInput::execResetInput(FFrame&, void* const)
	public virtual /*native function */void ResetInput()
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UInput::execGetBind(FFrame&, void* const)
	public virtual /*native function */String GetBind(name Key)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	public virtual /*exec function */void SetBind(name BindName, String Command)
	{
		/*local */Input.KeyBind NewBind = default;
		/*local */int BindIndex = default;
	
		BindIndex = Bindings.Length - 1;
		J0x0F:{}
		if(BindIndex >= 0)
		{
			if(Bindings[BindIndex].Name == BindName)
			{
				Bindings.Remove(BindIndex, 1);
				goto J0x53;
			}
			-- BindIndex;
			goto J0x0F;
		}
		J0x53:{}
		NewBind.Name = BindName;
		NewBind.Command = Command;
		Bindings[Bindings.Length] = NewBind;
		SaveConfig();
	}
	
}
}