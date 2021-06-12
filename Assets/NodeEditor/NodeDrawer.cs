﻿namespace MEdge.NodeEditor
{
	using System;
	using System.Collections.Generic;
	using JetBrains.Annotations;
	using Reflection;
	using UnityEditor;
	using UnityEngine;



	public class NodeDrawer
	{
		public const int ClippedFontSize = 4;
		public Rect NextRect;
		public Rect SurfaceCovered{ get; private set; }
		public NodeEditorWindow Editor{ get; private set; }
		public bool PreviouslyOutOfView{ get; private set; }
		public Color DefaultLine = new Color( 33 / 255f, 33 / 255f, 33 / 255f );
		List<Rect> _propertiesRects = new List<Rect>();
		Rect _screenRect;



		public void Reset( Rect newRect, NodeEditorWindow newEditor )
		{
			Editor = newEditor;
			_screenRect = new Rect( Vector2.zero, Editor.ViewportSize );
			_propertiesRects.Clear();
			PreviouslyOutOfView = IsInView( SurfaceCovered ) == false;
			NextRect = newRect;
			SurfaceCovered = newRect;
		}



		public void MarkNextAsLinkPoint<T>( object key, [ CanBeNull ] ref T target, bool pointOnRightSide = true, Color? color = default, Func<object, object, bool> acceptableTarget = null ) where T : class
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

			Editor.Links[ key ].rect = rect;

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
					Editor.Dragging = ( default, ( draggingKey, null, key, true ), -1 );
				}
				// Marked as completed and this is the receiver, send new target to it 
				else if( draggingKey == key && active/* Active here might cause some issues but ensures that the key doesn't have to be unique*/ && Editor.Dragging?.connection?.markForCompletion == true )
				{
					target = Editor.Dragging?.connection?.newTarget as T;
					Editor.Dragging = null;
					Editor.ScheduleNextRepaint = true;
				}
			}
			else if( active && e.type == EventType.MouseDown && e.button == 0 && Editor.Dragging == null )
			{
				Editor.Dragging = ( null, ( key, acceptableTarget, null, false ), e.button );
			}

			if( IsInView( rect ) )
				EditorGUI.DrawRect( rect, ( active ? activeColor : baseColor ) );

			if( active && e.type == EventType.MouseMove )
				Editor.ScheduleRepaint = true;
		}



		public Rect UseRect(float heightMult = 1f)
		{
			var outRect = NextRect;
			outRect.height *= heightMult;
			var delta = outRect.height * 1.1f;
			
			NextRect.position += new Vector2(0, delta);
			
			var s = SurfaceCovered;
			s.height += delta;
			SurfaceCovered = s;

			_propertiesRects.Add( outRect );
			if( _propertiesRects.Count % 2 == 0 && IsInView( outRect ) )
			{
				EditorGUI.DrawRect( outRect, new Color( 1f, 1f, 1f, 0.02f ) );
			}

			return outRect;
		}



		public bool IsNextInView() => PreviouslyOutOfView == false && IsInView( NextRect );



		public bool IsInView( Rect r ) => _screenRect.Overlaps( r );



		public bool IsInView( out Rect r, float heightMul = 1f )
		{
			r = UseRect( heightMul );
			return IsInView( r );
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
			if( IsNextInView() == false || Editor.GUIStyle.fontSize < ClippedFontSize )
			{
				UseRect();
				return;
			}
			var r = UseRect();
			GUI.Label( r, s, Editor.GUIStyle );
		}



		public void DrawProperty( IField field, CachedContainer cache )
		{
			if( IsNextInView() == false || Editor.GUIStyle.fontSize < ClippedFontSize )
			{
				UseRect();
				return;
			}

			EditorGUI.BeginChangeCheck();
			Split( UseRect(), out var labelRect, out var valueRect );
			GUI.Label( labelRect, field.Info.Name, Editor.GUIStyle );
			switch( field )
			{
				case IField<Boolean> f:
					if( GUI.Button(valueRect, f.Ref( cache ) ? "True" : "False", Editor.GUIStyleFields ) )
						f.Ref( cache ) = !f.Ref( cache ); 
					break;
				case IField<Byte> f: f.Ref( cache ) = (byte)EditorGUI.IntField(valueRect, f.Ref( cache ), Editor.GUIStyleFields ); break;
				case IField<SByte> f: f.Ref( cache ) = (sbyte)EditorGUI.IntField(valueRect, f.Ref( cache ), Editor.GUIStyleFields ); break;
				case IField<Int16> f: f.Ref( cache ) = (short)EditorGUI.IntField(valueRect, f.Ref( cache ), Editor.GUIStyleFields ); break;
				case IField<UInt16> f: f.Ref( cache ) = (ushort)EditorGUI.IntField(valueRect, f.Ref( cache ), Editor.GUIStyleFields ); break;
				case IField<Int32> f: f.Ref( cache ) = EditorGUI.IntField(valueRect, f.Ref( cache ), Editor.GUIStyleFields ); break;
				case IField<UInt32> f: f.Ref( cache ) = (uint)EditorGUI.LongField(valueRect, f.Ref( cache ), Editor.GUIStyleFields ); break;
				case IField<Int64> f: f.Ref( cache ) = EditorGUI.LongField(valueRect, f.Ref( cache ), Editor.GUIStyleFields ); break;
				case IField<UInt64> f: f.Ref( cache ) = (ulong)EditorGUI.LongField(valueRect, (long)f.Ref( cache ), Editor.GUIStyleFields ); break;
				case IField<Single> f: f.Ref( cache ) = EditorGUI.FloatField(valueRect, f.Ref( cache ), Editor.GUIStyleFields ); break;
				case IField<Double> f: f.Ref( cache ) = EditorGUI.DoubleField(valueRect, f.Ref( cache ), Editor.GUIStyleFields ); break;
				default: GUI.Label(valueRect, field.IsReferenceType && field.GetValueSlowAndBox( cache ) == null ? "null" : "obj", Editor.GUIStyle ); break;
			}
		}



		public void DrawProperty<T>( string s, ref T obj, out bool valueChanged ) where T : unmanaged
		{
			if( IsNextInView() == false || Editor.GUIStyle.fontSize < ClippedFontSize )
			{
				UseRect();
				valueChanged = false;
				return;
			}

			EditorGUI.BeginChangeCheck();
			Split( UseRect(), out var labelRect, out var valueRect );
			GUI.Label( labelRect, s, Editor.GUIStyle );
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
	}
}