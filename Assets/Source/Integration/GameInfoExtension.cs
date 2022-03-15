namespace MEdge.Engine
{
	public partial class GameInfo
	{
		public void BroadcastLocalized<T>( Actor Sender, Core.ClassT<LocalMessage> Message, /*optional */int Switch = default, /*optional */PlayerReplicationInfo RelatedPRI_1 = default, /*optional */PlayerReplicationInfo RelatedPRI_2 = default, /*optional */Core.ClassT<T> OptionalObject = default )
		{
			Core.NativeMarkers.MarkUnimplemented();
			// recursive call to same method, not sure what I should forward this to
			//BroadcastLocalized(Sender, Message, Switch, RelatedPRI_1, RelatedPRI_2, OptionalObject);
		}
	}
}