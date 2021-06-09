namespace MEdge.NodeEditor
{
	using UnityEngine;



	public interface INode
	{
		public Vector2 Pos{ get; set; }
		public void OnDraw( NodeDrawer drawer );
	}
}