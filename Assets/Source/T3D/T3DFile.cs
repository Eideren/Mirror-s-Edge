namespace MEdge.T3D
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEditor;
	using UnityEngine;



	public class T3DFile : ScriptableObject, ISerializationCallbackReceiver, MEdge.Source.IAsset
	{
		public T3DNode Root;



		[ Serializable ]
		public struct SerializableNode
		{
			public string Definition;
			public List<string> Properties;
			public int childCount;
			public string End;
		}



		public List<SerializableNode> serializedNodes;



		public void OnBeforeSerialize()
		{
			if( serializedNodes == null ) serializedNodes = new List<SerializableNode>();
			if( Root == null ) Root = new T3DNode();
			serializedNodes.Clear();
			AddNodeToSerializedNodes( Root );
		}



		public void OnAfterDeserialize()
		{
			if( serializedNodes.Count > 0 )
				ReadNodeFromSerializedNodes( 0, out Root );
			else
				Root = new T3DNode();
		}



		void AddNodeToSerializedNodes( T3DNode n )
		{
			serializedNodes.Add( new SerializableNode
			{
				Definition = n.Definition,
				Properties = n.Properties.ToList(),
				childCount = n.Children.Count,
				End = n.End
			} );
			foreach( var child in n.Children )
				AddNodeToSerializedNodes( child );
		}



		int ReadNodeFromSerializedNodes( int index, out T3DNode node )
		{
			var n = serializedNodes[ index ];
			T3DNode newNode = new T3DNode
			{
				Definition = n.Definition,
				Properties = n.Properties.ToList(),
				Children = new List<T3DNode>(),
				End = n.End,
			};
			for( int i = 0; i != n.childCount; i++ )
			{
				index = ReadNodeFromSerializedNodes( ++index, out var childNode );
				newNode.Children.Add( childNode );
			}

			node = newNode;
			return index;
		}



		public object GetRuntimeAsset() => T3DSerialization.Deserialize( Root, null, null );
	}
}