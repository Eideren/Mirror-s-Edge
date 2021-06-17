namespace MEdge.NodeEditor
{
	using UnityEngine;



	public interface INode
	{
		public Vector2 Pos{ get; set; }
		public Color? BackgroundColor{ get; }
		public void OnDraw( NodeDrawer drawer );
	}
}