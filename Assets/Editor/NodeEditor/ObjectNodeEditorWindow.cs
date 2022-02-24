namespace MEdge.NodeEditor
{
	using System.Collections.Generic;
	using System.Runtime.CompilerServices;
	using Reflection;
	using UnityEditor;
	using UnityEngine;



	public class ObjectGraphWindow : NodeEditorWindow
	{
		protected readonly List<ObjectNodeDrawer> _nodes = new List<ObjectNodeDrawer>();
		protected readonly ConditionalWeakTable<object, ObjectNodeDrawer> _openedObject = new ConditionalWeakTable<object, ObjectNodeDrawer>();
		protected string _searchTerm;
		
		
		
		[ MenuItem( "CONTEXT/Component/Inspect with node graph" ) ]
		static void InspectComponentWithNodeEditor(MenuCommand command)
		{
			Component comp = (Component)command.context;
			var window = EditorWindow.CreateInstance<ObjectGraphWindow>();
			window.AddObject( comp );
			window.Show();
		}
		
		
		
		[ MenuItem( "CONTEXT/Component/Add to current node graph" ) ]
		static void AddComponentToInspectionWithNodeEditor(MenuCommand command)
		{
			Component comp = (Component)command.context;
			var window = (ObjectGraphWindow)EditorWindow.GetWindow(typeof(ObjectGraphWindow));
			window.AddObject( comp );
			window.Show();
		}
		
		

		public virtual ObjectNodeDrawer AddObject( object obj )
		{
			if( _openedObject.TryGetValue( obj, out var d ) )
				return d;
			
			ObjectNodeDrawer outObj = new ObjectNodeDrawer( obj );
			_openedObject.Add( obj, outObj );
			_nodes.Add( outObj );
			this.ScheduleNextRepaint = true;
			return outObj;
		}
		
		

		public virtual bool RemoveObj( object obj )
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



		protected override void OnGUIDraw()
		{
			// Have to draw textfield before otherwise focus will be modified when amount of text field on screen changes
			if( string.IsNullOrEmpty( _searchTerm ) )
			{
				var temp = EditorGUI.TextField(new Rect( 232, 0, 100, 16 ), "Search..." );
				if( temp != "Search..." )
					_searchTerm = temp;
			}
			else
			{
				_searchTerm = EditorGUI.TextField(new Rect( 232, 0, 100, 16 ), _searchTerm );
			}
			base.OnGUIDraw();
		}



		protected override IEnumerable<INode> Nodes() => _nodes;



		public class ObjectNodeDrawer : INode
		{
			public readonly HashSet<int> ShownInlineHash = new HashSet<int>();
			protected object _observedObject;
			protected NodeDrawer _drawer;
			string _name;




			public virtual Vector2 Pos{ get; set; }


			public virtual Color? BackgroundColor{ get; } = null;

			protected virtual string Title => _name ??= _observedObject.GetType().Name;


			ConditionalWeakTable<object, ObjectNodeDrawer> _openedObject => _editor._openedObject;
			ObjectGraphWindow _editor => ( this._drawer.Editor as ObjectGraphWindow );

			
			public ObjectNodeDrawer( object content ) => _observedObject = content;
			
			public virtual void OnDraw( NodeDrawer drawer )
			{
				_drawer = drawer;
				drawer.MarkNextAsInput( _observedObject );

				if( drawer.IsInView( out var rect, 2f ) )
					GUI.Label( rect, Title, drawer.Editor.GUIStyleCentered );
				if( drawer.IsInView( out var rectButton ) && GUI.Button( rectButton, "x" ) )
					_editor.RemoveObj( _observedObject );

				drawer.UseRect();
				ReflectionData.ForeachField( ref _observedObject, (this, HashInitValue, (int?)null), StaticDrawField );

				static void StaticDrawField( IField field, (ObjectNodeDrawer thisNode, int hash, int? arrayItemIndex) data, CachedContainer cache )
				{
					data.thisNode.DrawField( field, data, cache );
				}
			}



			protected virtual void DrawField( IField field, (ObjectNodeDrawer thisNode, int hash, int? arrayItemIndex) data, CachedContainer cache )
			{
				var drawer = data.thisNode._drawer;
				var editor = data.thisNode._editor;
				var customLabel = data.arrayItemIndex != null ? " -" : null;
				
				if( data.hash == 0 
					&& string.IsNullOrWhiteSpace( editor._searchTerm ) == false 
					&& (field.Info.Name.Contains( editor._searchTerm ) || editor._searchTerm.Contains( field.Info.Name )) == false )
				{
					return;
				}

				data.hash = data.arrayItemIndex != null ? data.hash + data.arrayItemIndex.Value : NewHash( data.hash, field );

				var noDefaultHandler = drawer.Handles( field ) == false;
				if( noDefaultHandler && field.IsReferenceType )
				{
					var target = field.GetValueSlowAndBox( cache );
					if( drawer.MarkNextAsReceiver( ( field, cache.ContainerAsObj ), ref target, acceptableTarget: AcceptableTarget, color:LineColorFor( field, cache ) ) )
						field.SetValueSlow( cache, target );

					if( target is System.Array array )
					{
						if( VisibilityToggle( drawer, data.hash, data.thisNode.ShownInlineHash ) )
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
						    && drawer.IsInView( valueRect ) 
						    && GUI.Button( valueRect, "" ) )
						{
							var rect = drawer.NextRect;
							var nodeDrawer = editor.AddObject( target );
							var posInViewport = rect.position + new Vector2( rect.size.x * 1.5f, 0f );
							nodeDrawer.Pos = drawer.Editor.ViewportToWorld( posInViewport );
						}
					}
				}
				else if( noDefaultHandler && VisibilityToggle( drawer, data.hash, data.thisNode.ShownInlineHash ) )
				{
					drawer.DrawProperty( field, cache, customLabel );
					var newRect = drawer.NextRect;
					var originalRectX = newRect.x;
					var originalRectWidth = newRect.width;
					
					var delta = newRect.width * 0.05f;
					newRect.x += delta;
					newRect.width -= delta;
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
						ReflectionData.ForeachField( ref f, (data.thisNode, data.hash, (int?)null), DrawField );
						if( t != EventType.Used && Event.current.type == EventType.Used )
							field.SetValueSlow( cache, f );
					}
					
					drawer.NextRect.x = originalRectX;
					drawer.NextRect.width = originalRectWidth;
					return;
				}
				
				drawer.DrawProperty( field, cache, customLabel );
				
				static bool AcceptableTarget( (IField field, object container) key, object value )
				{
					return value == null || key.field.CanAssign( value );
				}
			}



			protected virtual Color? LineColorFor( IField field, CachedContainer container ) => null;
			
			
			
			protected static void DrawArrayItem( IField field, int index, (ObjectNodeDrawer thisNode, int hash, int? arrayItemIndex) data, CachedContainer container )
			{
				data.arrayItemIndex = index;
				data.thisNode.DrawField( field, data, container );
			}



			protected static bool VisibilityToggle( NodeDrawer drawer, int thisStructHash, HashSet<int> shownStructs )
			{
				drawer.Split( drawer.NextRect, out _, out var valueRect );
				var isShown = shownStructs.Contains( thisStructHash );
				if( drawer.IsInView( valueRect ) && GUI.Button( valueRect, "" ) )
				{
					if( isShown )
						shownStructs.Remove( thisStructHash );
					else
						shownStructs.Add( thisStructHash );
				}

				return isShown;
			}



			public const int HashInitValue = 1009;
			public static int NewHash(int prevHash, IField field) => prevHash * 9176 + field.Hash;
		}
	}
}