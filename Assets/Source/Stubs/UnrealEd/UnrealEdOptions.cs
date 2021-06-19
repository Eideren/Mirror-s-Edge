namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UnrealEdOptions : Object/*
		native
		config(Editor)*/{
	public partial struct /*native */EditorCommandCategory
	{
		public name Parent;
		public name Name;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0002F73E
	//		Parent = (name)"None";
	//		Name = (name)"None";
	//	}
	};
	
	public partial struct /*native */EditorCommand
	{
		public name Parent;
		public name CommandName;
		public String ExecCommand;
		public String Description;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0002F866
	//		Parent = (name)"None";
	//		CommandName = (name)"None";
	//		ExecCommand = "";
	//		Description = "";
	//	}
	};
	
	public /*config */array</*config */UnrealEdOptions.EditorCommandCategory> EditorCategories;
	public /*config */array</*config */UnrealEdOptions.EditorCommand> EditorCommands;
	public UnrealEdKeyBindings EditorKeyBindings;
	public /*native *//*map<0,0>*/map<object, object> CommandMap;
	
	public UnrealEdOptions()
	{
		var Default__UnrealEdOptions_EditorKeyBindingsInst = new UnrealEdKeyBindings
		{
		}/* Reference: UnrealEdKeyBindings'Default__UnrealEdOptions.EditorKeyBindingsInst' */;
		// Object Offset:0x0002F9DA
		EditorCategories = new array</*config */UnrealEdOptions.EditorCommandCategory>
		{
			new UnrealEdOptions.EditorCommandCategory
			{
				Parent = (name)"None",
				Name = (name)"Matinee",
			},
			new UnrealEdOptions.EditorCommandCategory
			{
				Parent = (name)"None",
				Name = (name)"CurveEditor",
			},
		};
		EditorCommands = new array</*config */UnrealEdOptions.EditorCommand>
		{
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"Matinee",
				CommandName = (name)"Matinee_TogglePlayPause",
				ExecCommand = "Matinee TogglePlayPause",
				Description = "Matinee_TogglePlayPause_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"Matinee",
				CommandName = (name)"Matinee_DeleteSelection",
				ExecCommand = "Matinee DeleteSelection",
				Description = "Matinee_DeleteSelection_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"Matinee",
				CommandName = (name)"Matinee_Undo",
				ExecCommand = "Matinee Undo",
				Description = "Matinee_Undo_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"Matinee",
				CommandName = (name)"Matinee_Redo",
				ExecCommand = "Matinee Redo",
				Description = "Matinee_Redo_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"Matinee",
				CommandName = (name)"Matinee_Copy",
				ExecCommand = "Matinee Copy",
				Description = "Matinee_Copy_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"Matinee",
				CommandName = (name)"Matinee_Cut",
				ExecCommand = "Matinee Cut",
				Description = "Matinee_Cut_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"Matinee",
				CommandName = (name)"Matinee_Paste",
				ExecCommand = "Matinee Paste",
				Description = "Matinee_Paste_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"Matinee",
				CommandName = (name)"Matinee_MarkInSection",
				ExecCommand = "Matinee MarkInSection",
				Description = "Matinee_MarkInSection_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"Matinee",
				CommandName = (name)"Matinee_MarkOutSection",
				ExecCommand = "Matinee MarkOutSection",
				Description = "Matinee_MarkOutSection_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"Matinee",
				CommandName = (name)"Matinee_IncrementPosition",
				ExecCommand = "Matinee IncrementPosition",
				Description = "Matinee_IncrementPosition_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"Matinee",
				CommandName = (name)"Matinee_DecrementPosition",
				ExecCommand = "Matinee DecrementPosition",
				Description = "Matinee_DecrementPosition_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"Matinee",
				CommandName = (name)"Matinee_MoveToNextKey",
				ExecCommand = "Matinee MoveToNextKey",
				Description = "Matinee_MoveToNextKey_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"Matinee",
				CommandName = (name)"Matinee_MoveToPrevKey",
				ExecCommand = "Matinee MoveToPrevKey",
				Description = "Matinee_MoveToPrevKey_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"Matinee",
				CommandName = (name)"Matinee_SplitAnimKey",
				ExecCommand = "Matinee SplitAnimKey",
				Description = "Matinee_SplitAnimKey_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"Matinee",
				CommandName = (name)"Matinee_ToggleSnap",
				ExecCommand = "Matinee ToggleSnap",
				Description = "Matinee_ToggleSnap_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"Matinee",
				CommandName = (name)"Matinee_MoveActiveUp",
				ExecCommand = "Matinee MoveActiveUp",
				Description = "Matinee_MoveActiveUp_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"Matinee",
				CommandName = (name)"Matinee_MoveActiveDown",
				ExecCommand = "Matinee MoveActiveDown",
				Description = "Matinee_MoveActiveDown_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"Matinee",
				CommandName = (name)"Matinee_AddKey",
				ExecCommand = "Matinee AddKey",
				Description = "Matinee_AddKey_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"Matinee",
				CommandName = (name)"Matinee_DuplicateSelectedKeys",
				ExecCommand = "Matinee DuplicateSelectedKeys",
				Description = "Matinee_DuplicateSelectedKeys_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"Matinee",
				CommandName = (name)"Matinee_CropAnimationBeginning",
				ExecCommand = "Matinee CropAnimationBeginning",
				Description = "Matinee_CropAnimationBeginning_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"Matinee",
				CommandName = (name)"Matinee_CropAnimationEnd",
				ExecCommand = "Matinee CropAnimationEnd",
				Description = "Matinee_CropAnimationEnd_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"Matinee",
				CommandName = (name)"Matinee_ViewFitSequence",
				ExecCommand = "Matinee ViewFitSequence",
				Description = "Matinee_ViewFitSequence_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"Matinee",
				CommandName = (name)"Matinee_ViewFitLoop",
				ExecCommand = "Matinee ViewFitLoop",
				Description = "Matinee_ViewFitLoop_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"Matinee",
				CommandName = (name)"Matinee_ViewFitLoopSequence",
				ExecCommand = "Matinee ViewFitLoopSequence",
				Description = "Matinee_ViewFitLoopSequence_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"Matinee",
				CommandName = (name)"Matinee_ChangeKeyInterpModeAUTO",
				ExecCommand = "Matinee ChangeKeyInterpModeAUTO",
				Description = "Matinee_ChangeKeyInterpModeAUTO_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"Matinee",
				CommandName = (name)"Matinee_ChangeKeyInterpModeUSER",
				ExecCommand = "Matinee ChangeKeyInterpModeUSER",
				Description = "Matinee_ChangeKeyInterpModeUSER_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"Matinee",
				CommandName = (name)"Matinee_ChangeKeyInterpModeBREAK",
				ExecCommand = "Matinee ChangeKeyInterpModeBREAK",
				Description = "Matinee_ChangeKeyInterpModeBREAK_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"Matinee",
				CommandName = (name)"Matinee_ChangeKeyInterpModeLINEAR",
				ExecCommand = "Matinee ChangeKeyInterpModeLINEAR",
				Description = "Matinee_ChangeKeyInterpModeLINEAR_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"Matinee",
				CommandName = (name)"Matinee_ChangeKeyInterpModeCONSTANT",
				ExecCommand = "Matinee ChangeKeyInterpModeCONSTANT",
				Description = "Matinee_ChangeKeyInterpModeCONSTANT_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"CurveEditor",
				CommandName = (name)"CurveEditor_ChangeInterpModeAUTO",
				ExecCommand = "CurveEditor ChangeInterpModeAUTO",
				Description = "CurveEditor_ChangeInterpModeAUTO_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"CurveEditor",
				CommandName = (name)"CurveEditor_ChangeInterpModeUSER",
				ExecCommand = "CurveEditor ChangeInterpModeUSER",
				Description = "CurveEditor_ChangeInterpModeUSER_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"CurveEditor",
				CommandName = (name)"CurveEditor_ChangeInterpModeBREAK",
				ExecCommand = "CurveEditor ChangeInterpModeBREAK",
				Description = "CurveEditor_ChangeInterpModeBREAK_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"CurveEditor",
				CommandName = (name)"CurveEditor_ChangeInterpModeLINEAR",
				ExecCommand = "CurveEditor ChangeInterpModeLINEAR",
				Description = "CurveEditor_ChangeInterpModeLINEAR_Desc",
			},
			new UnrealEdOptions.EditorCommand
			{
				Parent = (name)"CurveEditor",
				CommandName = (name)"CurveEditor_ChangeInterpModeCONSTANT",
				ExecCommand = "CurveEditor ChangeInterpModeCONSTANT",
				Description = "CurveEditor_ChangeInterpModeCONSTANT_Desc",
			},
		};
		EditorKeyBindings = Default__UnrealEdOptions_EditorKeyBindingsInst/*Ref UnrealEdKeyBindings'Default__UnrealEdOptions.EditorKeyBindingsInst'*/;
	}
}
}