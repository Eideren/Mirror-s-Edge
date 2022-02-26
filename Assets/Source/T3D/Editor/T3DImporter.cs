#if CSHARP_7_3_OR_NEWER
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor.AssetImporters;

namespace MEdge.T3D
{
	using System;
	using System.Linq;
	using UnityEditor;



	[ScriptedImporter(1, "T3D")]
public class T3DImporter : ScriptedImporter
{
    public override void OnImportAsset(AssetImportContext ctx)
    {
        T3DNode node;
        using(var f = File.OpenText(ctx.assetPath))
            node = new T3DNode(f);

        
        var file = ScriptableObject.CreateInstance<T3DFile>();
        file.Root = node;
        ctx.AddObjectToAsset("main obj", file);
        ctx.SetMainObject(file);
    }
}



	[ CustomEditor( typeof(T3DFile) ) ]
	public class T3DEditor : UnityEditor.Editor
	{
		public String SearchContent = "";
		HashSet<T3DNode> _foldedOut = new HashSet<T3DNode>();



		public override void OnInspectorGUI()
		{
			var prevState = GUI.enabled;
			GUI.enabled = true;
			var newSearch = EditorGUILayout.TextField( "Filter properties", SearchContent );
			if( newSearch != SearchContent )
			{
				_foldedOut.Clear();
				UpdateSearch( ( target as T3DFile ).Root );
			}

			SearchContent = newSearch;
			GUI.enabled = prevState;
			Do( ( target as T3DFile ).Root );
		}



		void Do( T3DNode n )
		{
			var prevS = _foldedOut.Contains( n );
			var currS = EditorGUILayout.Foldout( prevS, n.Definition );
			if( prevS != currS )
			{
				if( currS )
					_foldedOut.Add( n );
				else
					_foldedOut.Remove( n );
			}

			if( currS )
			{
				EditorGUI.indentLevel++;
				foreach( var child in n.Children )
					Do( child );
				foreach( var child in n.Properties )
				{
					if( String.IsNullOrWhiteSpace( SearchContent ) || child.Contains( SearchContent ) )
						EditorGUILayout.LabelField( child );
				}

				EditorGUI.indentLevel--;
			}
		}



		bool UpdateSearch( T3DNode n )
		{
			bool contains = n.Definition.Contains( SearchContent ) 
			                || n.Properties.FirstOrDefault( x => x.Contains( SearchContent ) ) != null;
			foreach( T3DNode child in n.Children )
			{
				if( UpdateSearch( child ) )
					contains = true;
			}
			
			if( contains )
				_foldedOut.Add( n );

			return contains;
		}
	}
}
#endif