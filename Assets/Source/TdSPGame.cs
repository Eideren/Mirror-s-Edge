namespace MEdge.TdGame
{
	public partial class TdSPGame
	{
		public partial struct OnLevelCompletedAsyncHelper
		{
			public static bool operator ==( OnLevelCompletedAsyncHelper a, OnLevelCompletedAsyncHelper b )
			{
				return a.ControllerId == b.ControllerId && a.PC == b.PC && a.NextCheckpointName == b.NextCheckpointName && a.NextLevelName == b.NextLevelName;
			}



			public static bool operator !=( OnLevelCompletedAsyncHelper a, OnLevelCompletedAsyncHelper b )
			{
				return ( a == b ) == false;
			}
		}
	}
}