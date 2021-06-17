namespace MEdge.AnimNodeEditor
{
	using System;
	using System.Collections.Generic;
	using Engine;
	using NodeEditor;
	using Reflection;
	using T3D;
	using UnityEngine;
	using static UnityEngine.Debug;



	public class AnimNodeEditorWindow : NodeEditorWindow
	{
		T3DFile _file;
		List<AnimNodeDrawer> _nodes;



		public object LoadFile(T3DFile file)
		{
			_file = file;
			_nodes = new List<AnimNodeDrawer>();
			return T3DSerialization.Deserialize( file.Root, null, delegate( object deserializedObject )
			{
				if( deserializedObject is AnimNode a )
					_nodes.Add( new AnimNodeDrawer( a ) );
				else if( deserializedObject is SkelControlBase scb )
					_nodes.Add( new AnimNodeDrawer( scb ) );
				else if( deserializedObject is MorphNodeBase mnb )
					_nodes.Add( new AnimNodeDrawer( mnb ) );
			} );
		}



		protected override IEnumerable<INode> Nodes()
		{
			// This is for editor reloads
			if( _nodes == null && _file != null )
			{
				LoadFile(_file);
			}


			return _nodes;
		}



		class AnimNodeDrawer : INode
		{
			static WeakCache<array<AnimNodeBlendBase.AnimBlendChild>, List<BlendChildSlot>> blendChildKeys = new WeakCache<array<AnimNodeBlendBase.AnimBlendChild>, List<BlendChildSlot>>();



			class BlendChildSlot
			{
				public array<AnimNodeBlendBase.AnimBlendChild> Array;
				public int Index;
			}



			object _rootNode;
			NodeDrawer _drawer;
			readonly Dictionary<IField, Key> _linkKeys = new Dictionary<IField, Key>();
			Action<IField, CachedContainer> _cachedInspect;
			Func<object, object, bool> _assignTestCached;



			class Key
			{
				public IField Field;
			}



			public Vector2 Pos
			{
				get
				{
					if( _rootNode is AnimNode an )
						return new Vector2( an.NodePosX, an.NodePosY );
					else if( _rootNode is SkelControlBase scb )
						return new Vector2( scb.ControlPosX, scb.ControlPosY );
					else if( _rootNode is MorphNodeBase mnb )
						return new Vector2( mnb.NodePosX, mnb.NodePosY );
					throw new InvalidOperationException();
				}
				set
				{
					if( _rootNode is AnimNode an )
					{
						an.NodePosX = (int) value.x;
						an.NodePosY = (int) value.y;
					}
					else if( _rootNode is SkelControlBase scb )
					{
						scb.ControlPosX = (int) value.x;
						scb.ControlPosY = (int) value.y;
					}
					else if( _rootNode is MorphNodeBase mnb )
					{
						mnb.NodePosX = (int) value.x;
						mnb.NodePosY = (int) value.y;
					}
					else
					{
						throw new InvalidOperationException();
					}
				}
			}



			public AnimNodeDrawer( AnimNode node ) => _rootNode = node;
			public AnimNodeDrawer( SkelControlBase node ) => _rootNode = node;
			public AnimNodeDrawer( MorphNodeBase node ) => _rootNode = node;



			public Color? BackgroundColor => _rootNode is AnimNode an && an.bRelevant ? new Color(0f, 1f, 0f, 0.1f) : default(Color?);
			
			
			public void OnDraw( NodeDrawer drawer )
			{
				_drawer = drawer;

				drawer.MarkNextAsTarget( _rootNode );
				
				if( _rootNode is AnimNode n && n.NodeName.Value != "" && drawer.IsInView( out var titleRect, 2f ) )
				{
					GUI.Label( titleRect, n.NodeName.ToString(), drawer.Editor.GUIStyleCentered );
				}
				if( drawer.IsInView( out var typeRect, 2f ) )
				{
					GUI.Label( typeRect, _rootNode.GetType().Name, drawer.Editor.GUIStyleCentered );
				}

				drawer.UseRect();
				ReflectionData.ForeachField( ref _rootNode, _cachedInspect ??= DrawField );
			}
			
			

			void DrawField( IField field, CachedContainer cache )
			{
				if( field.Info.ReflectedType == typeof(Core.Object) ) 
					return;

				switch( field )
				{
					case IField<array<AnimNodeBlendBase.AnimBlendChild>> fChildren:
					{
						var children = fChildren.Ref( cache );
						_drawer.DrawLabel( field.Info.Name );
						var blendChildSlots = blendChildKeys[ children ];
						while( blendChildSlots.Count < children.Length ) 
							blendChildSlots.Add( new BlendChildSlot { Array = children, Index = blendChildSlots.Count } );

						for( int i = 0; i < children.Length; i++ )
						{
							var thisTarget = blendChildSlots[ i ];
							ref var child = ref children[ i ];
							_drawer.MarkNextAsLinkStart( thisTarget, ref child.Anim );
							_drawer.DrawLabel( " -" );
						}

						break;
					}
					default:
					{
						if( field.IsReferenceType )
						{
							if( _linkKeys.TryGetValue( field, out var key ) == false )
								_linkKeys.Add( field, key = new Key{ Field = field } );
							
							var target = field.GetValueSlowAndBox( cache );
							_drawer.MarkNextAsLinkStart( key, ref target, acceptableTarget: _assignTestCached ??= AssignTest );
						}

						_drawer.DrawProperty( field, cache );
						break;
					}
				}
			}
			
			
			
			bool AssignTest( object key, object target )
			{
				if( key is Key k )
					return k.Field.CanAssign( target );
				return key is BlendChildSlot && target is AnimNode;
			}
		}
	}
}