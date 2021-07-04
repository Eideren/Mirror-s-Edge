namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdTeamInfo : TeamInfo/*
		native
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public partial struct /*native */VisibleEnemy
	{
		public Pawn Enemy;
		public float LastNetReceiveTime;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x005389C9
	//		Enemy = default;
	//		LastNetReceiveTime = -2.0f;
	//	}
	};
	
	public array<Controller> TeamMembers;
	public int MaxTeamMembers;
	public array<Object.Color> TeamBaseColor;
	public array<String> TeamColorNames;
	public bool bCanSeeBag;
	public array<TdTeamInfo.VisibleEnemy> VisibleEnemies;
	
	public override /*function */bool AddToTeam(Controller Other)
	{
		// stub
		return default;
	}
	
	public override /*function */void RemoveFromTeam(Controller Other)
	{
		// stub
	}
	
	public override /*simulated function */Object.Color GetTextColor()
	{
		// stub
		return default;
	}
	
	public TdTeamInfo()
	{
		// Object Offset:0x00538C5A
		MaxTeamMembers = 8;
		TeamBaseColor = new array<Object.Color>
		{
		}
		#warning Exception thrown while deserializing TeamBaseColor
		/*System.ArgumentOutOfRangeException: Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')
		   at System.Collections.Generic.List`1.get_Item(Int32 index)
		   at UELib.UName.Deserialize(IUnrealStream stream) in D:\MirrorsEdge\Sources\Unreal-Library\src\Core\Types\UName.cs:line 65
		   at UELib.UName..ctor(IUnrealStream stream) in D:\MirrorsEdge\Sources\Unreal-Library\src\Core\Types\UName.cs:line 46
		   at UELib.UObjectStream.ReadNameReference() in D:\MirrorsEdge\Sources\Unreal-Library\src\UnrealStream.cs:line 961
		   at UELib.Core.UDefaultProperty.Deserialize() in D:\MirrorsEdge\Sources\Unreal-Library\src\Core\Classes\UDefaultProperty.cs:line 151
		   at UELib.Core.UDefaultProperty.DeserializeDefaultPropertyValue(PropertyType type, DeserializeFlags& deserializeFlags) in D:\MirrorsEdge\Sources\Unreal-Library\src\Core\Classes\UDefaultProperty.cs:line 646
		   at UELib.Core.UDefaultProperty.DeserializeDefaultPropertyValue(PropertyType type, DeserializeFlags& deserializeFlags) in D:\MirrorsEdge\Sources\Unreal-Library\src\Core\Classes\UDefaultProperty.cs:line 762 */;
		TeamColorNames = new array<String>
		{
			"Red",
			"Blue",
		};
	}
}
}