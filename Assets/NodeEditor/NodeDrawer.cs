namespace MEdge.NodeEditor
{
	using System;
	using System.Collections.Generic;
	using JetBrains.Annotations;
	using UnityEditor;
	using UnityEngine;



	public class NodeDrawer
	{
		public Rect NextRect;
		public Rect SurfaceCovered{ get; private set; }
		public NodeEditorWindow Editor{ get; private set; }
		public Color DefaultLine = new Color( 33 / 255f, 33 / 255f, 33 / 255f );
		List<Rect> _propertiesRects = new List<Rect>();



		public void Reset( Rect newRect, NodeEditorWindow newEditor )
		{
			_propertiesRects.Clear();
			NextRect = newRect;
			SurfaceCovered = newRect;
			Editor = newEditor;
		}



		public void MarkNextAsLinkPoint( object key, [ CanBeNull ] ref object target, bool pointOnRightSide = true, Color? color = default, Func<object, object, bool> acceptableTarget = null )
		{
			var e = Event.current;

			var baseColor = ( color ?? DefaultLine );
			var activeColor = baseColor + Color.white * 0.25f;

			var rect = NextRect;
			rect.height *= 0.66f;
			rect.width = rect.height;
			rect.y += rect.height * 0.25f;
			rect.x += pointOnRightSide ? NextRect.width : - rect.width;

			bool active = rect.Contains( e.mousePosition );

			if( Editor.Links.TryGetValue( key, out var rectHolder ) == false )
				Editor.Links.Add( key, rectHolder = new RectRef() );
			rectHolder.rect = rect;

			if( Editor.Dragging?.connection?.key == key )
			{
				Editor.Lines.Add( ( rect.center, e.mousePosition, activeColor ) );
				active = true;
			}
			else if( target != null && Editor.Links.TryGetValue( target, out var targetRect ) )
			{
				var origin = rect.center;

				var lineDelta = targetRect.rect.center - origin;
				var mouseDelta = e.mousePosition - origin;

				float deltaDots = Vector3.Dot( mouseDelta, lineDelta );
				var vectorAlongLine = lineDelta * deltaDots / Vector3.Dot( lineDelta, lineDelta );
				var pointOnLine = origin + vectorAlongLine;

				// Is the cursor on this line, note the distance is just a random 10 units constant, not the actual line width, doesn't really matter and could help with low zoom
				active |= Editor.Dragging == null && vectorAlongLine.sqrMagnitude <= lineDelta.sqrMagnitude && deltaDots > 0f && Vector2.Distance( pointOnLine, e.mousePosition ) < 10f;

				Editor.Lines.Add( ( rect.center, targetRect.rect.center, ( active ? activeColor : baseColor ) ) );
			}

			// Currently dragging
			if( Editor.Dragging?.connection?.key is object draggingKey )
			{
				// Dropping on a potential connection
				if( active
				    && e.type == EventType.MouseUp
				    && Editor.Dragging?.connection?.markForCompletion != true
				    && draggingKey != key
				    && Editor.Dragging?.connection?.filter?.Invoke( draggingKey, key ) != false )
				{
					Editor.Dragging = ( default, ( draggingKey, null, key, true ) );
				}
				// Marked as completed and this is the receiver, send new target to it 
				else if( draggingKey == key && Editor.Dragging?.connection?.markForCompletion == true )
				{
					target = Editor.Dragging?.connection?.newTarget;
					Editor.Dragging = null;
					Editor.ScheduleNextRepaint = true;
				}
			}
			else if( active && e.type == EventType.MouseDown && Editor.Dragging == null )
			{
				Editor.Dragging = ( null, ( key, acceptableTarget, null, false ) );
			}

			EditorGUI.DrawRect( rect, ( active ? activeColor : baseColor ) );

			if( active && e.type == EventType.MouseMove )
				Editor.ScheduleRepaint = true;
		}



		public Rect UseRect()
		{
			var preRect = NextRect;
			_propertiesRects.Add( preRect );
			var delta = preRect.height * 1.1f;
			NextRect.position -= Vector2.down * delta;
			var s = SurfaceCovered;
			s.height += delta;
			SurfaceCovered = s;

			if( _propertiesRects.Count % 2 == 0 )
				EditorGUI.DrawRect( preRect, new Color( 1f, 1f, 1f, 0.02f ) );

			return preRect;
		}



		public void Split( Rect r, out Rect halfA, out Rect halfB )
		{
			halfA = r;
			halfA.width *= 0.66f;
			halfB = r;
			halfB.x += halfA.width;
			halfB.width *= 0.34f;
		}



		public void DrawLabel( string s )
		{
			var r = UseRect();
			EditorGUI.LabelField( r, s, Editor.GUIStyle );
		}



		public void DrawProperty<T>( string s, ref T obj, out bool valueChanged ) where T : unmanaged
		{
			EditorGUI.BeginChangeCheck();
			Split( UseRect(), out var labelRect, out var valueRect );
			EditorGUI.LabelField( labelRect, s, Editor.GUIStyle );
			try
			{
				unsafe
				{
					fixed( T* ptr = & obj )
					{
						// This whole dance to avoid boxing allocation
						switch( Type.GetTypeCode( typeof(T) ) )
						{
							case TypeCode.Boolean: * (bool*) ptr = EditorGUI.Toggle(valueRect, * (bool*) ptr, Editor.GUIStyleFields ); break;
							case TypeCode.Byte: * (byte*) ptr = (byte)EditorGUI.IntField(valueRect, * (byte*) ptr, Editor.GUIStyleFields ); break;
							case TypeCode.SByte: * (sbyte*) ptr = (sbyte)EditorGUI.IntField(valueRect, * (byte*) ptr, Editor.GUIStyleFields ); break;
							case TypeCode.Int16: * (short*) ptr = (short)EditorGUI.IntField(valueRect, * (short*) ptr, Editor.GUIStyleFields ); break;
							case TypeCode.UInt16: * (ushort*) ptr = (ushort)EditorGUI.IntField(valueRect, * (ushort*) ptr, Editor.GUIStyleFields ); break;
							case TypeCode.Int32: * (int*) ptr = EditorGUI.IntField(valueRect, * (int*) ptr, Editor.GUIStyleFields ); break;
							case TypeCode.UInt32: * (uint*) ptr = (uint)EditorGUI.LongField(valueRect, * (uint*) ptr, Editor.GUIStyleFields ); break;
							case TypeCode.Int64: * (long*) ptr = EditorGUI.LongField(valueRect, * (long*) ptr, Editor.GUIStyleFields ); break;
							case TypeCode.UInt64: * (ulong*) ptr = (ulong)EditorGUI.LongField(valueRect, (long)* (ulong*) ptr, Editor.GUIStyleFields ); break;
							case TypeCode.Single: * (float*) ptr = EditorGUI.FloatField(valueRect, * (float*) ptr, Editor.GUIStyleFields ); break;
							case TypeCode.Double: * (double*) ptr = EditorGUI.DoubleField(valueRect, * (double*) ptr, Editor.GUIStyleFields ); break;
							default: throw new ArgumentException( $"Unimplemented data type '{typeof(T)}'" );
						}
					}
				}
			}
			finally
			{
				valueChanged = EditorGUI.EndChangeCheck();
			}
		}



		public void DrawProperty( string s, ref object obj, out bool valueChanged )
		{
			EditorGUI.BeginChangeCheck();
			Split( UseRect(), out var labelRect, out var valueRect );
			EditorGUI.LabelField( labelRect, s, Editor.GUIStyle );
			try
			{
				switch( obj )
				{
					case Boolean Boolean: obj = EditorGUI.Toggle(valueRect, Boolean, Editor.GUIStyleFields ); break;
					case Byte Byte: obj = (byte)EditorGUI.IntField(valueRect, Byte, Editor.GUIStyleFields ); break;
					case SByte SByte: obj = (sbyte)EditorGUI.IntField(valueRect, SByte, Editor.GUIStyleFields ); break;
					case Int16 Int16: obj = (short)EditorGUI.IntField(valueRect, Int16, Editor.GUIStyleFields ); break;
					case UInt16 UInt16: obj = (ushort)EditorGUI.IntField(valueRect, UInt16, Editor.GUIStyleFields ); break;
					case Int32 Int32: obj = EditorGUI.IntField(valueRect, Int32, Editor.GUIStyleFields ); break;
					case UInt32 UInt32: obj = (uint)EditorGUI.LongField(valueRect, UInt32, Editor.GUIStyleFields ); break;
					case Int64 Int64: obj = EditorGUI.LongField(valueRect, Int64, Editor.GUIStyleFields ); break;
					case UInt64 UInt64: obj = (ulong)EditorGUI.LongField(valueRect, (long)UInt64, Editor.GUIStyleFields ); break;
					case Single Single: obj = EditorGUI.FloatField(valueRect, Single, Editor.GUIStyleFields ); break;
					case Double Double: obj = EditorGUI.DoubleField(valueRect, Double, Editor.GUIStyleFields ); break;
					default: EditorGUI.LabelField(valueRect, obj.ToString() ); break;
				}
			}
			finally
			{
				valueChanged = EditorGUI.EndChangeCheck();
			}
		}
	}
}