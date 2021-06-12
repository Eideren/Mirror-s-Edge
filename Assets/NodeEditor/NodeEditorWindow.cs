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
		public readonly WeakCache<object, RectRef> Links = new WeakCache<object, RectRef>();
		public (INode nodeOrNull, (object key, Func<object, object, bool> filter, object newTarget, bool markForCompletion)? connection, int mouseButton)? Dragging;
		public GUIStyle GUIStyle => _cachedStyle ??= new GUIStyle( EditorStyles.whiteLabel ) { fontSize = FontSize };
		public GUIStyle GUIStyleFields => _cachedStyleFields ??= new GUIStyle( EditorStyles.numberField ) { fontSize = FontSize };
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
				ScheduleRepaint = true;
			}
		}
		public bool ScheduleRepaint = false;
		public bool ScheduleNextRepaint = false;

		INode _viewportNode;
		bool _centerOnInit = true;
		float _zoomLevel = 1f;
		float _separation = 1f;

		Vector2 _draggingOffset;
		GUIStyle _cachedStyle;
		GUIStyle _cachedStyleFields;

		List<INode> _dummyNodes;
		
		(string s, float v) _zoomCache = ("0", 0f);
		
		(string s, float v) _separationCache = ("0", 0f);



		[ MenuItem( "Window/Dummy Node Editor" ) ]
		static void Init()
		{
			var window = new NodeEditorWindow();
			window.Show();
		}



		public NodeEditorWindow()
		{
			_viewportNode = new ViewportNode { Viewport = this };
			titleContent = new GUIContent( GetType().Name );
		}



		void OnGUI()
		{
			if( ScheduleNextRepaint )
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
			if( e.type == EventType.MouseDrag && Dragging?.nodeOrNull is {} nodeDragged )
			{
				if( ReferenceEquals( nodeDragged, _viewportNode ) )
				{
					_viewportNode.Pos += ( e.mousePosition - _draggingOffset ) / ZoomLevel;
					_draggingOffset = e.mousePosition;
				}
				else
				{
					nodeDragged.Pos = (( e.mousePosition + _draggingOffset ) / ZoomLevel - ViewportCenter) / Separation;
				}
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

			(INode node, Vector2 offset)? dragCandidate = null;
			foreach( INode node in Nodes() )
			{
				var drawer = Drawers[ node ];
				var fieldRect = new Rect( (node.Pos * _separation + viewportCenter) * _zoomLevel, FieldSize * _zoomLevel );

				var nodeBG = fieldRect;
				nodeBG.height = drawer.SurfaceCovered.height + fieldRect.height * 0.1f;
				EditorGUI.DrawRect( nodeBG, BackgroundColor );

				var nodeTitle = fieldRect;
				nodeTitle.height /= 2;
				EditorGUI.DrawRect( nodeTitle, Dragging?.nodeOrNull == node ? HighlightColor : TitleColor );

				var titleHighlight = nodeTitle;
				titleHighlight.height /= 10;
				EditorGUI.DrawRect( titleHighlight, HighlightColor );

				if( Dragging == null && ( e.type == EventType.MouseDown || e.type == EventType.MouseDrag ) && e.button == 0 && nodeBG.Contains( e.mousePosition ) )
					dragCandidate = ( node, nodeBG.position - e.mousePosition );

				fieldRect.position += new Vector2(0, nodeTitle.height * 1.3f);
				var preWidth = fieldRect.width;
				fieldRect.width *= 0.975f;
				fieldRect.x -= ( fieldRect.width - preWidth ) * 0.5f;
				drawer.Reset( fieldRect, this );
				node.OnDraw( drawer );
			}

			// Select the topmost (i.e.: last) node candidate to drag when multiple of them are on top of another 
			if( dragCandidate != null && Dragging == null )
			{
				var v = dragCandidate.Value;
				Dragging = (v.node, null, 0);
				_draggingOffset = v.offset;
			}

			if( e.type == EventType.KeyDown && e.keyCode == KeyCode.F )
			{
				CenterView();
				e.Use();
			}

			if( e.type == EventType.MouseDown && Dragging == null && e.button == 1 )
			{
				Dragging = ( _viewportNode, null, e.button );
				_draggingOffset = e.mousePosition;
			}

			// Release dragging
			if( e.type == EventType.MouseUp && e.button == 0 && Dragging?.connection?.markForCompletion == false )
			{
				var c = Dragging.Value.connection.Value;
				c.markForCompletion = true;
				Dragging = ( null, c, 0 );
			}
			else if( e.type == EventType.MouseLeaveWindow 
			         || ( e.type == EventType.MouseUp && Dragging?.mouseButton == e.button && Dragging?.connection?.markForCompletion != true ) )
			{
				Dragging = null;
				_draggingOffset = default;
				ScheduleRepaint = true;
			}

			ScheduleRepaint |= Dragging != null && ( e.type == EventType.MouseMove || e.type == EventType.MouseDrag );
			// ReSharper disable once CompareOfFloatsByEqualityOperator
			if( _zoomCache.v != ZoomLevel )
			{
				_zoomCache.s = $"Zoom:{ZoomLevel:F}";
				_zoomCache.v = ZoomLevel;
			}

			if( GUI.Button( new Rect( 0, 0, 100, 16 ), _zoomCache.s ) )
				ZoomLevel = 1f;
			
			
			// ReSharper disable once CompareOfFloatsByEqualityOperator
			if( _separationCache.v != Separation )
			{
				_separationCache.s = $"Separation:{Separation:F}";
				_separationCache.v = Separation;
			}


			if( GUI.Button( new Rect( 100, 0, 100, 16 ), _separationCache.s ) )
				Separation = 1f;
			if( GUI.Button( new Rect( 200, 0, 16, 16 ), "+" ) )
				Separation *= 2f;
			if( GUI.Button( new Rect( 216, 0, 16, 16 ), "-" ) )
				Separation *= 0.5f;
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



		private static Material LineMat
		{
			get
			{
				if( _sLineMat != null )
					return _sLineMat;
				Shader shader = Shader.Find( "Hidden/Internal-Colored" );
				_sLineMat = new Material( shader );
				_sLineMat.hideFlags = HideFlags.HideAndDontSave;
				_sLineMat.SetInt( "_SrcBlend", (int) UnityEngine.Rendering.BlendMode.SrcAlpha );
				_sLineMat.SetInt( "_DstBlend", (int) UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha );
				_sLineMat.SetInt( "_Cull", (int) UnityEngine.Rendering.CullMode.Off );
				_sLineMat.SetInt( "_ZWrite", 0 );
				return _sLineMat;
			}
		}


		static Material _sLineMat;



		static void DrawLine( Vector2 pointA, Vector2 pointB, Color color, float width = 5f )
		{
			var perp = pointB - pointA;
			perp = new Vector2( perp.y, perp.x );
			perp = perp.normalized * width;

			LineMat.SetPass( 0 );
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
				drawer.MarkNextAsLinkPoint( this, ref link );
				drawer.DrawLabel( "Link" );
				drawer.DrawProperty( nameof( someFloat ), ref someFloat, out _ );
				drawer.DrawProperty( nameof( someFloat ), ref someFloat, out _ );
			}
		}



		public class RectRef
		{
			public Rect rect;
		}
	}
}