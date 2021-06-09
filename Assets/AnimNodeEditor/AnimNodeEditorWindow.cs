namespace MEdge.AnimNodeEditor
{
	using System.Collections.Generic;
	using Engine;
	using NodeEditor;
	using T3D;
	using TdGame;
	using UnityEditor;



	public class AnimNodeEditorWindow : NodeEditorWindow
	{
		NodeWrapper[] nodes;
		
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
			//f.Root
		}



		public override IEnumerable<INode> Nodes()
		{
			nodes ??= new[] { new NodeWrapper(){ Node = new AnimTree() }, new NodeWrapper(){ Node = new TdAnimNodeSequence() }, new NodeWrapper(){ Node = new TdAnimNodeWalkingState() } };
			return nodes;
		}
	}
}