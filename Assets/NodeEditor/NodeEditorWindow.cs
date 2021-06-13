namespace MEdge.NodeEditor
{
	using System;
	using UnityEditor;
	using UnityEngine;
	using System.Collections.Generic;
	using static UnityEngine.Debug;



	public class NodeEditorWindow : EditorWindow
	{
		protected Color HighlightColor = new Color( 44 / 255f, 93 / 255f, 135 / 255f );
		protected Color TitleColor = new Color( 60 / 255f, 60 / 255f, 60 / 255f );
		protected Color BackgroundColor = new Color( 44 / 255f, 44 / 255f, 44 / 255f );
		protected Vector2 FieldSize = new Vector2( 320, 20 );
		protected int FontSize = 16;
		protected float LineWidth = 5f;

		public readonly List<(Vector2 a, Vector2 b, Color color)> Lines = new List<(Vector2, Vector2, Color)>();
		public readonly WeakCache<INode, NodeDrawer> Drawers = new WeakCache<INode, NodeDrawer>();
		public readonly WeakCache<object, RectRef> LinkTargets = new WeakCache<object, RectRef>();
		public readonly DraggingData Drag = new DraggingData();
		public GUIStyle GUIStyle => _cachedStyle ??= new GUIStyle( EditorStyles.whiteLabel ) { fontSize = FontSize };
		public GUIStyle GUIStyleFields => _cachedStyleFields ??= new GUIStyle( EditorStyles.numberField ) { fontSize = FontSize };
		public GUIStyle GUIStyleCentered => _cachedStyleCentered ??= new GUIStyle( EditorStyles.whiteLabel ) { fontSize = FontSize, alignment = TextAnchor.MiddleCenter };
		public float ZoomLevel
		{
			get => _zoomLevel;
			set
			{
				if(_zoomLevel == value)
					return;

				_zoomLevel = value;
				var scaledFontSize = (int) ( FontSize * ZoomLevel );
				GUIStyleFields.fontSize = scaledFontSize;
				GUIStyle.fontSize = scaledFontSize;
				GUIStyleCentered.fontSize = (int) ( FontSize * ZoomLevel * 1.5f );
				ScheduleRepaint = true;
			}
		}
		public Vector2 ViewportPosition;
		public Vector2 ViewportCenter => ViewportPosition + ViewportSize * 0.5f / ZoomLevel;
		public Vector2 ViewportSize => position.size;


		protected float Separation
		{
			get => _separation;
			set
			{
				if(_separation == value)
					return;
				_separation = value;
				ScheduleNextRepaint = true;
			}
		}
		public bool ScheduleRepaint = false;
		public bool ScheduleNextRepaint = false;

		INode _viewportNode;
		bool _centerOnInit = true;
		float _zoomLevel = 1f;
		float _separation = 1f;
		GUIStyle _cachedStyle;
		GUIStyle _cachedStyleFields;
		GUIStyle _cachedStyleCentered;

		List<INode> _dummyNodes;
		
		(string label, float v) _zoomCache = ("0", 0f);
		
		(string label, float v) _separationCache = ("0", 0f);


		
		static Material _sLineMat;


		[ MenuItem( "Window/Dummy Node Editor" ) ]
		static void Init()
		{
			var window = EditorWindow.CreateInstance<NodeEditorWindow>();
			window.Show();
		}



		public NodeEditorWindow()
		{
			_viewportNode = new ViewportNode { Viewport = this };
			titleContent = new GUIContent( GetType().Name );
		}



		void OnGUI()
		{
			if( ScheduleNextRepaint && Event.current.type == EventType.Repaint )
			{
				ScheduleNextRepaint = false;
				ScheduleRepaint = true;
			}

			OnGUIDraw();
			
			if( ScheduleRepaint )
			{
				ScheduleRepaint = false;
				Repaint();
			}
		}



		protected virtual IEnumerable<INode> Nodes()
		{
			_dummyNodes ??= new List<INode> { new DummyNode(), new DummyNode(), new DummyNode() };
			return _dummyNodes;
		}



		protected virtual void OnGUIDraw()
		{
			if( _centerOnInit )
			{
				_centerOnInit = false;
				CenterView();
			}

			wantsMouseMove = true;
			wantsMouseEnterLeaveWindow = true;

			var e = Event.current;
			
			// Moving the viewport must be done before drawing to avoid input-lag
			if( e.type == EventType.MouseDrag && Drag.IsMouseButton( e.button ) && Drag.IsNode( out var nodeDragged, out var dragOffset ) )
			{
				if( ReferenceEquals( nodeDragged, _viewportNode ) )
				{
					_viewportNode.Pos += ( e.mousePosition - dragOffset ) / ZoomLevel;
					Drag.DraggingOffset = e.mousePosition;
				}
				else
				{
					nodeDragged.Pos = (( e.mousePosition + dragOffset ) / ZoomLevel - ViewportCenter) / Separation;
				}
			}

			if( e.type == EventType.KeyDown && e.keyCode == KeyCode.F )
			{
				CenterView();
				e.Use();
			}

			if( e.type == EventType.Repaint )
			{
				foreach( var line in Lines )
					DrawLine( line.a, line.b, line.color, LineWidth * ZoomLevel );
			}

			Lines.Clear();

			if( e.type == EventType.ScrollWheel )
				ZoomLevel *= e.delta.y < 0 ? 1.1f : 0.9f;

			var viewportCenter = ViewportCenter;

			(INode node, Vector2 offset, int mouseButton)? dragCandidate = null;
			foreach( INode node in Nodes() )
			{
				var drawer = Drawers[ node ];
				var fieldRect = new Rect( (node.Pos * _separation + viewportCenter) * _zoomLevel, FieldSize * _zoomLevel );

				var nodeBG = fieldRect;
				nodeBG.height = drawer.SurfaceCovered.height + fieldRect.height * 0.1f;
				EditorGUI.DrawRect( nodeBG, BackgroundColor );

				var nodeTitle = fieldRect;
				nodeTitle.height /= 2;
				EditorGUI.DrawRect( nodeTitle, Drag.IsNode( out var draggingNode, out _ ) && draggingNode == node ? HighlightColor : TitleColor );

				var titleHighlight = nodeTitle;
				titleHighlight.height /= 10;
				EditorGUI.DrawRect( titleHighlight, HighlightColor );

				if( Drag.IsDragging == false && ( e.type == EventType.MouseDown || e.type == EventType.MouseDrag ) && e.button == 0 && nodeBG.Contains( e.mousePosition ) )
					dragCandidate = ( node, nodeBG.position - e.mousePosition, e.button );

				fieldRect.position += new Vector2(0, nodeTitle.height * 1.3f);
				var preWidth = fieldRect.width;
				fieldRect.width *= 0.975f;
				fieldRect.x -= ( fieldRect.width - preWidth ) * 0.5f;
				drawer.Reset( fieldRect, this );
				node.OnDraw( drawer );
			}

			// Select the topmost (i.e.: last) node candidate to drag when multiple of them are on top of another 
			if( dragCandidate != null && Drag.IsDragging == false )
			{
				var v = dragCandidate.Value;
				Drag.NewNodeDrag( v.node, v.mouseButton, v.offset );
			}

			if( e.type == EventType.MouseDown && Drag.IsDragging == false && e.button == 1 )
			{
				Drag.NewNodeDrag( _viewportNode, e.button, e.mousePosition );
			}

			// Release dragging
			if( e.type == EventType.MouseUp && Drag.IsMouseButton( e.button ) )
			{
				if( Drag.IsNode( out _, out _ ) )
				{
					Drag.Clear();
					ScheduleRepaint = true;
				}
				else if( Drag.IsConnection( out var v ) && v.scheduledConnection == false )
				{
					Drag.MarkBreakConnection();
				}
			}

			if( e.type == EventType.MouseLeaveWindow )
			{
				Drag.Clear();
			}

			// ReSharper disable once CompareOfFloatsByEqualityOperator
			if( _zoomCache.v != ZoomLevel )
			{
				_zoomCache.label = $"Zoom:{ZoomLevel:F}";
				_zoomCache.v = ZoomLevel;
			}
			
			// ReSharper disable once CompareOfFloatsByEqualityOperator
			if( _separationCache.v != Separation )
			{
				_separationCache.label = $"Separation:{Separation:F}";
				_separationCache.v = Separation;
			}
			
			if( GUI.Button( new Rect( 0, 0, 100, 16 ), _zoomCache.label ) )
				ZoomLevel = 1f;
			if( GUI.Button( new Rect( 100, 0, 100, 16 ), _separationCache.label ) )
				Separation = 1f;
			if( GUI.Button( new Rect( 200, 0, 16, 16 ), "+" ) )
				Separation *= 2f;
			if( GUI.Button( new Rect( 216, 0, 16, 16 ), "-" ) )
				Separation *= 0.5f;

			ScheduleRepaint = ScheduleRepaint || (Drag.IsDragging && ( e.type == EventType.MouseMove || e.type == EventType.MouseDrag ));
		}



		public Vector2 WorldToViewport( Vector2 p ) => ( p * _separation + ViewportCenter ) * ZoomLevel;
		public Vector2 ViewportToWorld( Vector2 p ) => (p / ZoomLevel - ViewportCenter) /  _separation;



		public void CenterView()
		{
			var med = Vector2.zero;
			int count = 0;
			foreach( INode node in Nodes() )
			{
				if( Drawers.TryGetValue( node, out var drawer ) )
				{
					// Frequent path, just send center without transforming for perf'
					med += drawer.SurfaceCovered.center;
				}
				else
				{
					// Infrequent path, do inverse transformation to counteract the transformation post average
					med += WorldToViewport(node.Pos);
				}

				count++;
			}

			if( count == 0 )
				return;

			med /= count;
			med = ViewportToWorld( med );

			if( med.magnitude > 100f / Separation )
			{
				LogWarning( "Re-centered nodes around origin, median distance was greater than 100" );
				foreach( INode node in Nodes() )
					node.Pos -= med;
				med = default;
			}

			ViewportPosition = - med;
			ScheduleRepaint = true;
		}



		static void DrawLine( Vector2 pointA, Vector2 pointB, Color color, float width = 5f )
		{
			var perp = pointB - pointA;
			perp = new Vector2( perp.y, perp.x );
			perp = perp.normalized * width;

			if( _sLineMat == null )
			{
				Shader shader = Shader.Find( "Hidden/Internal-Colored" );
				_sLineMat = new Material( shader );
				_sLineMat.hideFlags = HideFlags.HideAndDontSave;
				_sLineMat.SetInt( "_SrcBlend", (int) UnityEngine.Rendering.BlendMode.SrcAlpha );
				_sLineMat.SetInt( "_DstBlend", (int) UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha );
				_sLineMat.SetInt( "_Cull", (int) UnityEngine.Rendering.CullMode.Off );
				_sLineMat.SetInt( "_ZWrite", 0 );
			}

			_sLineMat.SetPass( 0 );
			GL.Begin( GL.QUADS );
			GL.Color( color );
			GL.Vertex3( pointA.x + perp.x, pointA.y - perp.y, 0 );
			GL.Vertex3( pointA.x - perp.x, pointA.y + perp.y, 0 );
			GL.Vertex3( pointB.x - perp.x, pointB.y + perp.y, 0 );
			GL.Vertex3( pointB.x + perp.x, pointB.y - perp.y, 0 );
			GL.End();
		}



		class ViewportNode : INode
		{
			public NodeEditorWindow Viewport;


			public Vector2 Pos
			{
				get => Viewport.ViewportPosition;
				set => Viewport.ViewportPosition = value;
			}


			public void OnDraw( NodeDrawer drawer ) => throw new InvalidOperationException();
		}



		class DummyNode : INode
		{
			public Vector2 Pos{ get; set; }

			float someFloat = 101f;
			object link;
			bool init;



			public void OnDraw( NodeDrawer drawer )
			{
				if( init == false )
				{
					using var v = drawer.Editor.Nodes().GetEnumerator();
					v.MoveNext();
					link ??= v.Current;
					init = true;
				}

				drawer.DrawProperty( nameof( someFloat ), ref someFloat, out _ );
				drawer.MarkNextAsLinkStart( this, ref link );
				drawer.MarkNextAsTarget( this );
				drawer.DrawLabel( "Link" );
				drawer.DrawProperty( nameof( someFloat ), ref someFloat, out _ );
				drawer.DrawProperty( nameof( someFloat ), ref someFloat, out _ );
			}
		}



		public class RectRef
		{
			public Rect rect;
		}



		public class DraggingData
		{
			INode _nodeOrNull;
			public Vector2 DraggingOffset;
			int? _mouseButton;
			(object key, Func<object, object, bool> filter, object scheduledTarget, bool scheduledConnection, bool fromTarget)? _connection;



			public void NewNodeDrag( INode node, int mouseButton, Vector2 offset )
			{
				Clear();
				_nodeOrNull = node;
				_mouseButton = mouseButton;
				DraggingOffset = offset;
			}



			public void NewConnectionDrag( object target, Func<object, object, bool> filter, bool fromTarget, int mouseButton )
			{
				Clear();
				_connection = ( target, filter, null, false, fromTarget );
				_mouseButton = mouseButton;
			}



			public void Clear()
			{
				_nodeOrNull = null;
				_mouseButton = null;
				_connection = null;
				DraggingOffset = default;
			}


			public bool IsDragging => _mouseButton != null;


			public bool MarkedForCompletion => _connection?.scheduledConnection ?? false;



			public bool IsMouseButton( int mouseButton ) => _mouseButton == mouseButton;



			public void ScheduleConnectionBetween( object key, object target )
			{
				if( _connection == null )
					throw new InvalidOperationException( "Not set as connection" );
				var cpy = _connection.Value;
				cpy.key = key;
				cpy.scheduledTarget = target;
				cpy.scheduledConnection = true;
				_connection = cpy;
			}



			/// <summary>
			/// Will set target of this connection to null
			/// </summary>
			public void MarkBreakConnection()
			{
				if( _connection == null )
					throw new InvalidOperationException( "Not set as connection" );
				var cpy = _connection.Value;
				if( cpy.fromTarget )
				{
					Clear();
					return;
				}

				cpy.scheduledTarget = null;
				cpy.scheduledConnection = true;
				_connection = cpy;
			}



			public bool IsConnection(out (object key, Func<object, object, bool> filter, object scheduledTarget, bool scheduledConnection, bool fromTarget) connection)
			{
				if( _connection.HasValue )
				{
					connection = _connection.Value;
					return true;
				}

				connection = default;
				return false;
			}



			public bool IsNode( out INode node, out Vector2 offset )
			{
				node = _nodeOrNull;
				offset = DraggingOffset;
				return _nodeOrNull != null;
			}
		}
	}
}