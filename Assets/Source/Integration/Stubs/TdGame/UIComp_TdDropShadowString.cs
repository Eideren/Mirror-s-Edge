namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIComp_TdDropShadowString : UIComp_DrawString/* within UIObject*//*
		native
		editinlinenew
		hidecategories(Object)*/{
	public new UIObject Outer => base.Outer as UIObject;
	
	public/*(DropShadow)*/ UIRoot.UIStyleReference DropShadowStyle;
	public/*(DropShadow)*/ float VerticalPctOffset;
	public/*(DropShadow)*/ float HorizontalPctOffset;
	
	public UIComp_TdDropShadowString()
	{
		// Object Offset:0x006808D9
		DropShadowStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"DefaultDropShadowStyle",
			RequiredStyleClass = ClassT<UIStyle_Combo>()/*Ref Class'UIStyle_Combo'*/,
			AssignedStyleID = new UIRoot.STYLE_ID
			{
				A = 0,
				B = 0,
				C = 0,
				D = 0,
			},
			ResolvedStyle = default,
		};
		VerticalPctOffset = 0.060f;
		HorizontalPctOffset = 0.060f;
	}
}
}