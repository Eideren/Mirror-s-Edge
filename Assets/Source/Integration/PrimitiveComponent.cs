namespace MEdge.Engine
{
	using Core;
	using Editor;
	using UnrealEd;
	using Fp;
	using Tp;
	using Ts;
	using IpDrv;
	using GameFramework;
	using TdGame;
	using TdMenuContent;
	using TdMpContent;
	using TdSharedContent;
	using TdSpBossContent;
	using TdSpContent;
	using TdTTContent;
	using TdTuContent;
	using TdEditor;



	public partial class PrimitiveComponent
	{
		public bool IsValidComponent()
		{
			NativeMarkers.MarkUnimplemented();
			return true;
		}
		
		public Vector GetOrigin()
		{
			return LocalToWorld.GetOrigin();
		}



		public static int CurrentTag;
	}
}