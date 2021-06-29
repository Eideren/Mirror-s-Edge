namespace MEdge.NodeEditor
{
	using System.Collections.Generic;
	using System.Runtime.CompilerServices;
	using Reflection;
	using UnityEditor;
	using UnityEngine;



	public class ObjectNodeEditorWindow : NodeEditorWindow
	{
		readonly List<ObjectNodeDrawer> _nodes = new List<ObjectNodeDrawer>();
		readonly ConditionalWeakTable<object, ObjectNodeDrawer> _openedObject = new ConditionalWeakTable<object, ObjectNodeDrawer>();




		[ MenuItem( "Window/Dummy Object Node Editor" ) ]
		static void Init()
		{
			var window = EditorWindow.CreateInstance<ObjectNodeEditorWindow>();
			window.AddObject( window );
			window.Show();
		}

		public ObjectNodeDrawer AddObject( object obj )
		{
			ObjectNodeDrawer outObj = new ObjectNodeDrawer( obj );
			_openedObject.Add( obj, outObj );
			_nodes.Add( outObj );
			this.ScheduleNextRepaint = true;
			return outObj;
		}

		public bool RemoveObj( object obj )
		{
			if( _openedObject.TryGetValue( obj, out var drawer ) )
			{
				_openedObject.Remove( obj );
				_nodes.Remove( drawer );
				this.ScheduleNextRepaint = true;
				return true;
			}

			return false;
		}



		protected override IEnumerable<INode> Nodes() => _nodes;



		public class ObjectNodeDrawer : INode
		{
			readonly HashSet<int> _shownInlineHash = new HashSet<int>();
			object _rootContent;
			NodeDrawer _drawer;




			public Vector2 Pos{ get; set; }



			public ObjectNodeDrawer( object content ) => _rootContent = content;


			public Color? BackgroundColor{ get; } = null;



			ConditionalWeakTable<object, ObjectNodeDrawer> _openedObject => _editor._openedObject;
			ObjectNodeEditorWindow _editor => ( this._drawer.Editor as ObjectNodeEditorWindow );


			public void OnDraw( NodeDrawer drawer )
			{
				_drawer = drawer;
				drawer.MarkNextAsInput( _rootContent );

				if( drawer.IsInView( out var rect, 2f ) )
					GUI.Label( rect, _rootContent.GetType().Name, drawer.Editor.GUIStyleCentered );
				if( drawer.IsInView( out var rectButton ) && GUI.Button( rectButton, "x" ) )
					_editor.RemoveObj( _rootContent );

				drawer.UseRect();
				ReflectionData.ForeachField( ref _rootContent, (this, 0, (int?)null), DrawField );
			}



			static void DrawField( IField field, (ObjectNodeDrawer thisNode, int hash, int? arrayItemIndex) data, CachedContainer cache )
			{
				var drawer = data.thisNode._drawer;
				var editor = data.thisNode._editor;
				var customLabel = data.arrayItemIndex != null ? " -" : null;
				
				data.hash = NewHash( data.hash, field );
				
				if( drawer.Handles( field ) == false && field.IsReferenceType )
				{
					var target = field.GetValueSlowAndBox( cache );
					if( drawer.MarkNextAsReceiver( ( field, cache.ContainerAsObj ), ref target, acceptableTarget: AcceptableTarget ) )
						field.SetValueSlow( cache, target );

					if( target is System.Array array )
					{
						if( VisibilityToggle( drawer, data.hash, data.thisNode._shownInlineHash ) )
						{
							drawer.DrawProperty( field, cache, customLabel );
							ReflectionData.ArrayStaticForeach( array, data, DrawArrayItem );
							return;
						}
					}
					else
					{
						drawer.Split( drawer.NextRect, out _, out var valueRect );
						if( target != null 
						    && data.thisNode._openedObject.TryGetValue( target, out _ ) == false 
						    && GUI.Button( valueRect, "" ) )
						{
							var rect = drawer.NextRect;
							var nodeDrawer = editor.AddObject( target );
							var posInViewport = rect.position + new Vector2( rect.size.x * 1.5f, 0f );
							nodeDrawer.Pos = drawer.Editor.ViewportToWorld( posInViewport );
						}
					}
				}
				else if( drawer.Handles( field ) == false && VisibilityToggle( drawer, data.hash, data.thisNode._shownInlineHash ) )
				{
					drawer.DrawProperty( field, cache, customLabel );
					var newRect = drawer.NextRect;
					var originalRectX = newRect.x;
					newRect.x += newRect.width * 0.05f;
					drawer.NextRect = newRect;
					
					var f = field.GetValueSlowAndBox( cache );
					if( f == null )
					{
						// Not too sure how to handle this elegantly yet
						drawer.DrawLabel( "Nullable: Null" );
					}
					else
					{
						var t = Event.current.type;
						ReflectionData.ForeachField( ref f, (data.thisNode, NewHash( data.hash, field ), (int?)null), DrawField );
						if( t != EventType.Used && Event.current.type == EventType.Used )
							field.SetValueSlow( cache, f );
					}
					
					drawer.NextRect.x = originalRectX;
					return;
				}
				
				drawer.DrawProperty( field, cache, customLabel );
				
				static bool AcceptableTarget( (IField field, object container) key, object value )
				{
					return value == null || key.field.CanAssign( value );
				}
			}
			
			
				
			static void DrawArrayItem( IField field, int index, (ObjectNodeDrawer thisNode, int hash, int? arrayItemIndex) data, CachedContainer container )
			{
				data.hash += index;
				data.arrayItemIndex = index;
				DrawField( field, data, container );
			}



			static bool VisibilityToggle( NodeDrawer drawer, int thisStructHash, HashSet<int> shownStructs )
			{
				drawer.Split( drawer.NextRect, out _, out var valueRect );
				var isShown = shownStructs.Contains( thisStructHash );
				if( GUI.Button( valueRect, "" ) )
				{
					if( isShown )
						shownStructs.Remove( thisStructHash );
					else
						shownStructs.Add( thisStructHash );
				}

				return isShown;
			}



			static int NewHash(int prevHash, IField field)
			{
				return ( prevHash, field.GetHashCode() ).GetHashCode();
			}
		}
	}
}