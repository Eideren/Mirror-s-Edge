namespace MEdge.NodeEditor
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

		const int DragAndDropButton = 0;



		public void Reset( Rect newRect, NodeEditorWindow newEditor )
		{
			Editor = newEditor;
			_screenRect = new Rect( Vector2.zero, Editor.ViewportSize );
			_propertiesRects.Clear();
			PreviouslyOutOfView = IsInView( SurfaceCovered ) == false;
			NextRect = newRect;
			SurfaceCovered = newRect;
		}



		public void MarkNextAsInput<T>( T target, bool pointOnRightSide = false, Color? color = default ) where T : class
		{
			bool isDragSource = Editor.Drag.IsFromTargetConnection(out var connData) && target.Equals( connData );
			var rect = ConnectionRect( pointOnRightSide );
			var rRef = Editor.LinkTargets[ target ];
			rRef.rect = rect;
			rRef.upToDate = true;
			
			if( NewConnection( isDragSource, null, rect, color, out _ ) )
			{
				Editor.Drag.NewConnectionDrag( false, target, DragAndDropButton );
				Event.current.Use();
			}
		}
		
		

		/// <summary>
		/// Setup a receiver for a connection, this is an item which draws and receives connection changes.
		/// Draws a connection to a <paramref name="target"/> which is used in a <see cref="MarkNextAsInput{T}"/>.
		/// If this connection is changed by the user, <paramref name="target"/> will be changed to the item this is now connected to.
		/// </summary>
		/// <param name="key">
		/// Can be any kind of object as long as it uniquely identifies this specific call and is stable.
		/// For example, for a field you could use a tuple of (name of the field, object containing that field)
		/// As long as no other <see cref="MarkNextAsReceiver{TKey,TTarget}"/> of this editor are using those two values they won't be problematic
		/// </param>
		/// <param name="target">
		/// The current value that this field contains,
		/// 'will create a line automatically to it if something called <see cref="MarkNextAsInput{T}"/> with this value as parameter
		/// </param>
		/// <param name="pointOnRightSide">Whether to put the link anchor on the right or left side</param>
		/// <param name="color">The color of the link anchor</param>
		/// <param name="acceptableTarget">
		/// Tests whether a new connection is valid,
		/// return true if the potential new target is valid for the given key,
		/// if it was valid and the user finished the connection this method will return true and <paramref name="target"/> will be assigned to the linked value.
		/// Note that the target might be null if user cut the connection, you should return true if you allow null values.
		/// Note also that if this delegate is null this method allows null and all values of type <see cref="TTarget"/>.
		/// </param>
		/// <returns>True when connection has changed - <paramref name="target"/> has been assigned to a new value</returns>
		public bool MarkNextAsReceiver<TKey, TTarget>( TKey key, [ CanBeNull ] ref TTarget target, bool pointOnRightSide = true, Color? color = default, Func<TKey, TTarget, bool> acceptableTarget = null ) where TTarget : class
		{
			var e = Event.current;
			bool isDragSource = Editor.Drag.IsFromKeyConnection(out var connData) && key.Equals( connData );
			var rect = ConnectionRect( pointOnRightSide );
			
			if( NewConnection( isDragSource, target, rect, color, out bool mouseHover ) )
			{
				Editor.Drag.NewConnectionDrag( true, key, DragAndDropButton );
				Event.current.Use();
			}

			{
				if( Editor.Drag.IsFromKeyConnection( out var otherKey ) && key.Equals( otherKey ) )
				{
					foreach( var (k, v) in Editor.LinkTargets )
					{
						if( k is TTarget asTTarget
						    && ( acceptableTarget == null || acceptableTarget( key, asTTarget ) ) )
						{
							var cpyRect = v.rect;
							cpyRect.min -= v.rect.size * 0.2f;
							cpyRect.max += v.rect.size * 0.2f;
							EditorGUI.DrawRect( cpyRect, Color.green );
						}
					}
				}
			}

			{
				if( Editor.Drag.IsFromTargetConnection( out var newTarget ) 
				    && newTarget is TTarget asTTarget
				    && (acceptableTarget == null || acceptableTarget(key, asTTarget))  )
				{
					var cpyRect = rect;
					cpyRect.min -= rect.size * 0.2f;
					cpyRect.max += rect.size * 0.2f;
					EditorGUI.DrawRect( cpyRect, Color.green );
				}
			}


			if( e.type == EventType.MouseUp && Editor.Drag.IsMouseButton( e.button ) )
			{
				bool changedTarget = false;
				// Linking target to this
				{
					if( mouseHover 
					    && Editor.Drag.IsFromTargetConnection( out var newTarget ) 
					    && newTarget is TTarget asTTarget
					    && (acceptableTarget == null || acceptableTarget(key, asTTarget))  )
					{
						target = asTTarget;
						changedTarget = true;
					}
				}

				if( Editor.Drag.IsFromKeyConnection( out var otherKey ) && key.Equals( otherKey ) )
				{
					// Linking this to target under cursor ?
					foreach( var (k, v) in Editor.LinkTargets )
					{
						if( v.rect.Contains( e.mousePosition )
						    && k is TTarget asTTarget
						    && ( acceptableTarget == null || acceptableTarget( key, asTTarget ) ) )
						{
							target = asTTarget;
							changedTarget = true;
						}
					}

					// Released over nothing
					if( changedTarget == false && ( acceptableTarget == null || acceptableTarget( key, null ) ) )
					{
						target = null;
						changedTarget = true;
					}
				}
				
				if( changedTarget )
				{
					Editor.Drag.Clear();
					Editor.ScheduleRepaint = true;
					Event.current.Use();
					return true;
				}
			}

			return false;
		}



		Rect ConnectionRect( bool pointOnRightSide )
		{
			var rect = NextRect;
			rect.height *= 0.66f;
			rect.width = rect.height;
			rect.y += rect.height * 0.25f;
			rect.x += pointOnRightSide ? NextRect.width : - rect.width;
			return rect;
		}



		bool NewConnection( bool isDraggingSource, [ CanBeNull ] object lineTarget, Rect rect, Color? color, out bool hover )
		{
			var e = Event.current;
			hover = false;

			var baseColor = ( color ?? DefaultLine );
			var activeColor = baseColor + Color.white * 0.4f;

			if( isDraggingSource )
			{
				Editor.Lines.Add( ( rect.center, e.mousePosition, activeColor ) );
				hover = true;
			}
			else if( lineTarget != null && Editor.LinkTargets.TryGetValue( lineTarget, out var targetRect ) )
			{
				var origin = rect.center;

				var lineDelta = targetRect.rect.center - origin;
				var mouseDelta = e.mousePosition - origin;

				float deltaDots = Vector3.Dot( mouseDelta, lineDelta );
				var vectorAlongLine = lineDelta * deltaDots / Vector3.Dot( lineDelta, lineDelta );
				var pointOnLine = origin + vectorAlongLine;

				// Is the cursor on this line, note the distance is just a random 10 units constant, not the actual line width, doesn't really matter and could help with low zoom
				hover = hover || Editor.Drag.IsDragging == false && vectorAlongLine.sqrMagnitude <= lineDelta.sqrMagnitude && deltaDots > 0f && Vector2.Distance( pointOnLine, e.mousePosition ) < 10f;

				Editor.Lines.Add( ( rect.center, targetRect.rect.center, ( hover ? activeColor : baseColor ) ) );
			}
			
			hover = hover || rect.Contains( e.mousePosition );

			if( IsInView( rect ) )
				EditorGUI.DrawRect( rect, ( hover ? activeColor : baseColor ) );

			if( hover && e.type == EventType.MouseMove )
			{
				Editor.ScheduleRepaint = true;
				Editor.ScheduleNextRepaint = true; // *Next*Repaint so that we paint when mouse leaves as well
			}

			return hover && e.type == EventType.MouseDown && e.button == DragAndDropButton && Editor.Drag.IsDragging == false;
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



		public void DrawProperty( IField field, CachedContainer cache, string customLabel = null )
		{
			if( IsNextInView() == false || Editor.GUIStyle.fontSize < ClippedFontSize )
			{
				UseRect();
				return;
			}

			EditorGUI.BeginChangeCheck();
			Split( UseRect(), out var labelRect, out var valueRect );
			GUI.Label( labelRect, customLabel ?? field.Info.Name, Editor.GUIStyle );
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
				case IField<System.String> f: f.Ref( cache ) = EditorGUI.TextField(valueRect, f.Ref( cache ), Editor.GUIStyleFields ); break;
				case IField<Core.String> f: f.Ref( cache ) = EditorGUI.TextField(valueRect, f.Ref( cache ), Editor.GUIStyleFields ); break;
				case IField<Core.name> f: f.Ref( cache ) = EditorGUI.TextField(valueRect, f.Ref( cache ), Editor.GUIStyleFields ); break;
				default: GUI.Label(valueRect, field.IsReferenceType && field.GetValueSlowAndBox( cache ) == null ? "null" : field.IsReferenceType ? "obj" : "struct", Editor.GUIStyle ); break;
			}
		}



		public bool Handles( IField field )
		{
			switch( field )
			{
				case IField<Boolean> _:
				case IField<Byte> _:
				case IField<SByte> _:
				case IField<Int16> _:
				case IField<UInt16> _:
				case IField<Int32> _:
				case IField<UInt32> _:
				case IField<Int64> _:
				case IField<UInt64> _:
				case IField<Single> _:
				case IField<Double> _:
				case IField<System.String> _:
				case IField<Core.String> _:
				case IField<Core.name> _: return true;
				default: return false;
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