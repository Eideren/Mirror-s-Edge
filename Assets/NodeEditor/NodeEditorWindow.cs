namespace MEdge.NodeEditor
{
    using System;
    using UnityEditor;
    using UnityEngine;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using static UnityEngine.Debug;


    public class Node
    {
        public Vector2 Pos;

        float someFloat = 101f;
        object link;
        bool init;


        public void OnDraw(NodeDrawer drawer)
        {
            if( init == false )
            {

                link ??= drawer.Editor.Nodes[ 0 ];
                init = true;
            }
            
            drawer.DrawProperty( nameof(someFloat), ref someFloat, out _ );
            drawer.MarkNextAsLinkPoint(this, ref link);
            drawer.DrawLabel("Link");
            drawer.DrawProperty( nameof(someFloat), ref someFloat, out _ );
            drawer.DrawProperty( nameof(someFloat), ref someFloat, out _ );
        }
    }





    public class RectHolder
    {
        public Rect rect;
    }

    public class NodeEditorWindow : EditorWindow
    {
        public Color HighlightColor{ get; set; } = new Color( 44 / 255f, 93 / 255f, 135 / 255f );
        public Color TitleColor{ get; set; } = new Color( 60 / 255f, 60 / 255f, 60 / 255f );
        public Color BackgroundColor{ get; set; } = new Color( 44 / 255f, 44 / 255f, 44 / 255f );
        public List<Node> Nodes = new List<Node>{ new Node(), new Node(), new Node() };
        public readonly List<(Vector2 a, Vector2 b, Color c)> Lines = new List<(Vector2 a, Vector2 b, Color c)>();
        public readonly ConditionalWeakTable<Node, NodeDrawer> Drawers = new ConditionalWeakTable<Node, NodeDrawer>();
        public readonly ConditionalWeakTable<object, RectHolder> Links = new ConditionalWeakTable<object, RectHolder>();
        public (Node? node, (object key, Func<object, object, bool> filter, object newTarget, bool markForCompletion)? connection)? Dragging;
        public GUIStyle GUIStyleFields => _cachedStyleFields ??= new GUIStyle(EditorStyles.numberField){ fontSize = BaseFontSize };
        public GUIStyle GUIStyle => _cachedStyle ??= new GUIStyle(EditorStyles.whiteLabel){ fontSize = BaseFontSize };

        public int BaseFontSize = 16;
        public float ZoomLevel = 1f;
        public Vector2 ViewportPosition
        {
            get => _viewportNode.Pos;
            set => _viewportNode.Pos = value;
        }
        public Vector2 ViewportSize => position.size;
        public bool ScheduleRepaint = false;
        public bool ScheduleNextRepaint = false;
        
        Node _viewportNode = new Node();
        bool _centerOnInit = true;
        
        Vector2 _draggingOffset;
        GUIStyle _cachedStyleFields;
        GUIStyle _cachedStyle;



        [MenuItem("Window/TestNodeEditor")]
        static void Init()
        {
            var window = EditorWindow.GetWindow<NodeEditorWindow>();
            window.Show();
        }

        void OnGUI()
        {
            if( _centerOnInit )
            {
                _viewportNode.Pos = ViewportSize * 0.5f;
                _centerOnInit = false;
                CenterView();
            }

            if( ScheduleNextRepaint )
            {
                ScheduleNextRepaint = false;
                ScheduleRepaint = true;
            }

            wantsMouseMove = true;
            wantsMouseEnterLeaveWindow = true;
            
            var e = Event.current;

            foreach( var line in Lines )
                DrawLine( line.a, line.b, line.c, 5f*ZoomLevel );
            Lines.Clear();

            if( e.type == EventType.ScrollWheel )
            {
                ZoomLevel *= e.delta.y < 0 ? 1.1f : 0.9f;
                GUIStyleFields.fontSize = GUIStyle.fontSize = (int)(BaseFontSize * ZoomLevel);
                ScheduleRepaint = true;
            }

            foreach( Node node in Nodes )
            {
                if( Drawers.TryGetValue( node, out var drawer ) == false )
                    Drawers.Add( node, drawer = new NodeDrawer() );

                var fieldRect = new Rect( (node.Pos + _viewportNode.Pos) * ZoomLevel, new Vector2( 200, 20 ) * ZoomLevel );

                var nodeBG = fieldRect;
                nodeBG.height = (drawer.NextRect.y - fieldRect.y) + fieldRect.height * 0.1f;
                //nodeBG.y += nodeBG.height;
                EditorGUI.DrawRect( nodeBG, BackgroundColor );
                
                var nodeTitle = fieldRect;
                nodeTitle.height /= 2;
                EditorGUI.DrawRect( nodeTitle, TitleColor );
                
                var titleHighlight = nodeTitle;
                titleHighlight.height /= 10;
                EditorGUI.DrawRect( titleHighlight, HighlightColor );
                
                if( Dragging == null && (e.type == EventType.MouseDown || e.type == EventType.MouseDrag) && e.button == 0 && nodeBG.Contains( e.mousePosition ) )
                {
                    Dragging = (node, null);
                    _draggingOffset = nodeTitle.position - e.mousePosition;
                }
                
                fieldRect.position -= Vector2.down * nodeTitle.height * 1.3f;
                var preWidth = fieldRect.width;
                fieldRect.width *= 0.975f;
                fieldRect.x -= ( fieldRect.width - preWidth ) * 0.5f;
                drawer.Reset(fieldRect, this);
                node.OnDraw(drawer);
            }

            if( e.type == EventType.KeyDown && e.keyCode == KeyCode.F && Nodes.Count > 0 )
            {
                CenterView();
                ScheduleRepaint = true;
                e.Use();
            }

            if( Dragging == null && e.type == EventType.MouseDown && e.button == 0 )
            {
                Dragging = (_viewportNode, null);
                _draggingOffset = e.mousePosition;
            }

            if( Dragging?.node is Node nodeDragged && e.type == EventType.MouseDrag )
            {
                if( ReferenceEquals( nodeDragged, _viewportNode ) )
                {
                    _viewportNode.Pos += (e.mousePosition - _draggingOffset)/ZoomLevel;
                    _draggingOffset = e.mousePosition;
                }
                else
                {
                    nodeDragged.Pos = (e.mousePosition + _draggingOffset)/ZoomLevel - _viewportNode.Pos;
                }
            }
            
            // Release dragging
            if( e.type == EventType.MouseUp && e.button == 0 && Dragging?.connection?.markForCompletion == false )
            {
                var c = Dragging.Value.connection.Value;
                c.markForCompletion = true;
                Dragging = ( null, c );
            }
            else if( e.type == EventType.MouseLeaveWindow || ( Dragging != null && e.type == EventType.MouseUp && e.button == 0 && Dragging?.connection?.markForCompletion != true ) )
            {
                Dragging = null;
                ScheduleRepaint = true;
                _draggingOffset = default;
            }

            if( Dragging != null && (e.type == EventType.MouseMove || e.type == EventType.MouseDrag) )
            {
                ScheduleRepaint = true;
            }

            if( ScheduleRepaint )
            {
                ScheduleRepaint = false;
                Repaint();
            }
        }



        public void CenterView()
        {
            var med = Vector2.zero;
            foreach( Node node in Nodes )
                med += node.Pos;

            med /= Nodes.Count;

            if( med.magnitude > 100f )
            {
                LogWarning( "Re-centered nodes around origin, median distance was greater than 100" );
                foreach( Node node in Nodes )
                    node.Pos -= med;
                med = default;
            }

            _viewportNode.Pos = -med + ViewportSize * 0.5f;
        }



        private static Material LineMat
        {
            get
            {
                if( _sLineMat != null )
                    return _sLineMat;
                Shader shader = Shader.Find("Hidden/Internal-Colored");
                _sLineMat = new Material(shader);
                _sLineMat.hideFlags = HideFlags.HideAndDontSave;
                _sLineMat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                _sLineMat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                _sLineMat.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
                _sLineMat.SetInt("_ZWrite", 0);
                return _sLineMat;
            }
        }
        private static Material _sLineMat;
        
        static void DrawLine(Vector2 pointA, Vector2 pointB, Color color, float width = 5f)
        {
            var perp = pointB - pointA;
            perp = new Vector2( perp.y, perp.x );
            perp = perp.normalized * width;
            
            LineMat.SetPass(0);   
            GL.Begin(GL.QUADS);
            GL.Color(color);
            GL.Vertex3(pointA.x+perp.x, pointA.y-perp.y, 0);
            GL.Vertex3(pointA.x-perp.x, pointA.y+perp.y, 0);
            GL.Vertex3(pointB.x-perp.x, pointB.y+perp.y, 0);
            GL.Vertex3(pointB.x+perp.x, pointB.y-perp.y, 0);
            GL.End();
        }
    }
}
