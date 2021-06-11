namespace MEdge.AnimNodeEditor
{
	using System.Collections.Generic;
	using Engine;
	using NodeEditor;
	using T3D;
	using UnityEditor;
	using static UnityEngine.Debug;



	public class AnimNodeEditorWindow : NodeEditorWindow
	{
		public T3DFile File;
		List<AnimNodeDrawer> nodes;



		[ MenuItem( "Window/Anim Node Editor" ) ]
		static void Init()
		{
			var window = GetWindow<AnimNodeEditorWindow>();
			window.Show();
		}



		public AnimNodeEditorWindow()
		{
		}



		public AnimNodeEditorWindow( T3DFile f )
		{
			File = f;
			Show();
		}



		public void ShowContent(T3DFile file)
		{
			File = file;
			nodes = new List<AnimNodeDrawer>();
			T3DSerialization.Deserialize( file.Root, null, delegate( object deserializedObject )
			{
				if( deserializedObject is AnimNode a )
					nodes.Add( new AnimNodeDrawer( a ) );
			} );
		}



		public override IEnumerable<INode> Nodes()
		{
			if( nodes == null && File != null )
			{
				ShowContent(File);
			}


			return nodes;
		}
	}
}