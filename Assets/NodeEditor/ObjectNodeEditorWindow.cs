namespace MEdge.NodeEditor
{
	using System;
	using System.Collections.Generic;
	using Reflection;
	using UnityEngine;



	public class ObjectNodeEditorWindow : NodeEditorWindow
	{
		readonly List<ObjectNodeDrawer> _nodes = new List<ObjectNodeDrawer>();



		public void AddObject( object obj )
		{
			_nodes.Add( new ObjectNodeDrawer( obj ) );
		}



		protected override IEnumerable<INode> Nodes() => _nodes;



		class ObjectNodeDrawer : INode
		{
			object _rootContent;
			NodeDrawer _drawer;
			readonly Dictionary<IField, Key> _linkKeys = new Dictionary<IField, Key>();
			Action<IField, CachedContainer> _cachedInspect;
			Func<object, object, bool> _assignTestCached;



			class Key
			{
				public IField Field;
			}



			public Vector2 Pos{ get; set; }



			public ObjectNodeDrawer( object content ) => _rootContent = content;



			public void OnDraw( NodeDrawer drawer )
			{
				_drawer = drawer;
				drawer.MarkNextAsTarget( _rootContent );

				if( drawer.IsInView( out var rect, 2f ) )
					GUI.Label( rect, _rootContent.GetType().Name, drawer.Editor.GUIStyleCentered );

				drawer.UseRect();
				ReflectionData.ForeachField( ref _rootContent, _cachedInspect ??= DrawField );
			}
		
		

			void DrawField( IField field, CachedContainer cache )
			{
				if( field.IsReferenceType )
				{
					if( _linkKeys.TryGetValue( field, out var key ) == false )
						_linkKeys.Add( field, key = new Key{ Field = field } );
						
					var target = field.GetValueSlowAndBox( cache );
					_drawer.MarkNextAsLinkStart( key, ref target, acceptableTarget: _assignTestCached ??= AssignTest );
				}

				_drawer.DrawProperty( field, cache );
			}
		
		
		
			bool AssignTest( object key, object target ) => key is Key k && k.Field.CanAssign( target );
		}
	}
}