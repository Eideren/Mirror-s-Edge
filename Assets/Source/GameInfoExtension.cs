namespace MEdge.Engine
{
	using MEdge.Core;
	public partial class GameInfo
	{
		public void BroadcastLocalized<T>( Actor Sender, Core.ClassT<LocalMessage> Message, /*optional */int Switch = default, /*optional */PlayerReplicationInfo RelatedPRI_1 = default, /*optional */PlayerReplicationInfo RelatedPRI_2 = default, /*optional */Core.ClassT<T> OptionalObject = default )
		{
			BroadcastLocalized(Sender, Message, Switch, RelatedPRI_1, RelatedPRI_2, OptionalObject);
		}
	}
}