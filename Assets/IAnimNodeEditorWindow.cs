namespace MEdge
{
	public interface IAnimNodeEditorWindow
	{
		public void Close();
		public void LoadFromNode(Engine.AnimNode node);
		public void Show();
	}
}