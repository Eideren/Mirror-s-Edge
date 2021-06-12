namespace MEdge.AnimNodeEditor
{
	using System.Collections.Generic;
	using Engine;
	using NodeEditor;
	using T3D;



	public class AnimNodeEditorWindow : NodeEditorWindow
	{
		T3DFile _file;
		List<AnimNodeDrawer> _nodes;



		public void LoadFile(T3DFile file)
		{
			_file = file;
			_nodes = new List<AnimNodeDrawer>();
			T3DSerialization.Deserialize( file.Root, null, delegate( object deserializedObject )
			{
				if( deserializedObject is AnimNode a )
					_nodes.Add( new AnimNodeDrawer( a ) );
			} );
		}



		protected override IEnumerable<INode> Nodes()
		{
			// This is for editor reloads
			if( _nodes == null && _file != null )
			{
				LoadFile(_file);
			}


			return _nodes;
		}
	}
}