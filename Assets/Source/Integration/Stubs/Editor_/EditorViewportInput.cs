namespace MEdge.Editor{
using Core; using Engine; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class EditorViewportInput : Input/*
		transient
		native
		config(Input)
		hidecategories(Object,UIRoot)*/{
	public EditorEngine Editor;
	
	public EditorViewportInput()
	{
		// Object Offset:0x0000F7B4
		Bindings = new array</*config */Input.KeyBind>
		{
			new Input.KeyBind
			{
				Name = (name)"SpaceBar",
				Command = "MODE WIDGETMODECYCLE",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"Tilde",
				Command = "MODE WIDGETCOORDSYSTEMCYCLE",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"Delete",
				Command = "DELETE",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"F4",
				Command = "EDCALLBACK ACTORPROPS",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"F4",
				Command = "QUIT_EDITOR",
				Control = false,
				Shift = false,
				Alt = true,
			},
			new Input.KeyBind
			{
				Name = (name)"F5",
				Command = "EDCALLBACK SURFPROPS",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"F6",
				Command = "EDCALLBACK LEVELPROPS",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"A",
				Command = "ACTOR SELECT ALL",
				Control = false,
				Shift = true,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"B",
				Command = "POLY SELECT MATCHING BRUSH",
				Control = false,
				Shift = true,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"C",
				Command = "POLY SELECT ADJACENT COPLANARS",
				Control = false,
				Shift = true,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"D",
				Command = "DUPLICATE",
				Control = false,
				Shift = true,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"E",
				Command = "ACTOR SELECT MATCHINGSTATICMESH",
				Control = false,
				Shift = true,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"F",
				Command = "POLY SELECT ADJACENT FLOORS",
				Control = false,
				Shift = true,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"F",
				Command = "EDCALLBACK FITTEXTURETOSURFACE",
				Control = true,
				Shift = true,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"G",
				Command = "POLY SELECT MATCHING GROUPS",
				Control = false,
				Shift = true,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"I",
				Command = "POLY SELECT MATCHING ITEMS",
				Control = false,
				Shift = true,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"J",
				Command = "POLY SELECT ADJACENT ALL",
				Control = false,
				Shift = true,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"M",
				Command = "POLY SELECT MEMORY SET",
				Control = false,
				Shift = true,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"M",
				Command = "ACTOR LEVELCURRENT",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"M",
				Command = "ACTOR MOVETOCURRENT",
				Control = true,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"N",
				Command = "SELECT NONE",
				Control = false,
				Shift = true,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"O",
				Command = "POLY SELECT MEMORY INTERSECT",
				Control = false,
				Shift = true,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"Q",
				Command = "POLY SELECT REVERSE",
				Control = false,
				Shift = true,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"R",
				Command = "POLY SELECT MEMORY RECALL",
				Control = false,
				Shift = true,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"S",
				Command = "POLY SELECT ALL",
				Control = false,
				Shift = true,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"T",
				Command = "POLY SELECT MATCHING TEXTURE",
				Control = false,
				Shift = true,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"U",
				Command = "POLY SELECT MEMORY UNION",
				Control = false,
				Shift = true,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"W",
				Command = "POLY SELECT ADJACENT WALLS",
				Control = false,
				Shift = true,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"X",
				Command = "POLY SELECT MEMORY XOR",
				Control = false,
				Shift = true,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"Y",
				Command = "POLY SELECT ADJACENT SLANTS",
				Control = false,
				Shift = true,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"Z",
				Command = "ACTOR SELECT MATCHINGSTATICMESH ALLCLASSES",
				Control = false,
				Shift = true,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"C",
				Command = "EDIT COPY",
				Control = true,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"V",
				Command = "EDIT PASTE",
				Control = true,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"W",
				Command = "DUPLICATE",
				Control = true,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"X",
				Command = "EDIT CUT",
				Control = true,
				Shift = false,
				Alt = false,
			},
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
				Command = "TRANSACTION UNDO",
				Control = true,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"A",
				Command = "BRUSH ADD",
				Control = true,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"S",
				Command = "BRUSH SUBTRACT",
				Control = true,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"I",
				Command = "BRUSH FROM INTERSECTION",
				Control = true,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"D",
				Command = "BRUSH FROM DEINTERSECTION",
				Control = true,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"P",
				Command = "PREFAB SELECTACTORSINPREFABS",
				Control = false,
				Shift = true,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"End",
				Command = "ACTOR ALIGN SNAPTOFLOOR ALIGN=0",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"End",
				Command = "ACTOR ALIGN MOVETOGRID",
				Control = true,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"Home",
				Command = "CAMERA ALIGN",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"Home",
				Command = "CAMERA ALIGN ACTIVEVIEWPORTONLY",
				Control = false,
				Shift = true,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"P",
				Command = "MAP BRUSH GET",
				Control = true,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"K",
				Command = "ACTOR FIND KISMET",
				Control = true,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"A",
				Command = "ACTOR SELECT ALL FROMOBJ",
				Control = true,
				Shift = true,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"B",
				Command = "ACTOR SYNCBROWSER",
				Control = true,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"Escape",
				Command = "ACTOR DESELECT",
				Control = false,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"TAB",
				Command = "CTRLTAB SHIFTDOWN=FALSE",
				Control = true,
				Shift = false,
				Alt = false,
			},
			new Input.KeyBind
			{
				Name = (name)"D",
				Command = "SELECT NONE",
				Control = false,
				Shift = false,
				Alt = false,
			},
		};
	}
}
}