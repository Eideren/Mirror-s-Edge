namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ObjectEditorViewportInput : EditorViewportInput/*
		transient
		native
		config(Input)
		hidecategories(Object,UIRoot)*/{
	public ObjectEditorViewportInput()
	{
		// Object Offset:0x00026F0A
		Bindings = new array</*config */Input.KeyBind>
		{
			new Input.KeyBind
			{
				Name = (name)"Y",
				Command = "TRANSACTION REDO",
				Control = true,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"Z",
				Command = "TRANSACTION REDO",
				Control = true,
				Shift = true,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"Z",
				Command = "TRANSACTION UNDO",
				Control = true,
				Shift = false,
				Alt = false,
			},
		};
	}
}
}