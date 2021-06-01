namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Input : Interaction/*
		transient
		native
		config(Input)
		hidecategories(Object,UIRoot)*/{
	public partial struct /*native */KeyBind
	{
		public /*config */name Name;
		public /*config */String Command;
		public /*config */bool Control;
		public /*config */bool Shift;
		public /*config */bool Alt;
	
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
		public /*config */name Key;
		public /*config */Input.KeyBind Binding;
	
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
	
	public /*config */array</*config */Input.KeyBind> Bindings;
	public /*config */array</*config */Input.InputOverridePair> OverrideBindings;
	public /*const */array<name> PressedKeys;
	public /*const */Object.EInputEvent CurrentEvent;
	public /*const */float CurrentDelta;
	public /*const */float CurrentDeltaTime;
	public /*native const *//*map<0,0>*/map<object, object> NameToPtr;
	public /*init native const */array</*init */Object.Pointer> AxisArray;
	
	// Export UInput::execResetInput(FFrame&, void* const)
	public virtual /*native function */void ResetInput()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UInput::execGetBind(FFrame&, void* const)
	public virtual /*native function */String GetBind(name Key)
	{
		#warning NATIVE FUNCTION !
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