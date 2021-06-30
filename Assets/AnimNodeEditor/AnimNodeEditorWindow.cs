namespace MEdge.AnimNodeEditor
{
	using System.Collections.Generic;
	using Engine;
	using NodeEditor;
	using Reflection;
	using T3D;
	using UnityEngine;
	using static UnityEngine.Debug;



	public class AnimNodeEditorWindow : ObjectGraphWindow
	{
		T3DFile _file;



		public AnimNodeEditorWindow()
		{
			Separation = 8.0f;
		}



		public object LoadFile(T3DFile file)
		{
			_file = file;
			return T3DSerialization.Deserialize( file.Root, null, delegate( object deserializedObject )
			{
				if( deserializedObject is AnimNode a )
					AddObject( a );
				else if( deserializedObject is SkelControlBase scb )
					AddObject( scb );
				else if( deserializedObject is MorphNodeBase mnb )
					AddObject( mnb );
			} );
		}



		public void LoadFromNode( AnimNode node )
		{
			AddObject( node );
		}
		
		

		public override ObjectNodeDrawer AddObject( object obj )
		{
			if( _openedObject.TryGetValue( obj, out var d ) )
				return d;
			
			var outObj = new AnimNodeDrawer( obj );
			_openedObject.Add( obj, outObj );
			_nodes.Add( outObj );
			this.ScheduleNextRepaint = true;

			if( obj is AnimNodeBlendBase a )
			{
				var uArrayHash = ObjectNodeDrawer.NewHash( ObjectNodeDrawer.HashInitValue, 
					ReflectionData.GetDataFor(obj.GetType()).FindField( nameof( AnimNodeBlendBase.Children ) ) );
				var arrayHash = ObjectNodeDrawer.NewHash(uArrayHash, 
					ReflectionData.GetDataFor(a.Children.GetType()).FindField( "__items" ));
				outObj.ShownInlineHash.Add( uArrayHash );
				outObj.ShownInlineHash.Add( arrayHash );
				for( int i = 0; i < a.Children.Length; i++ )
				{
					var aChild = a.Children[ i ];
					if( aChild.Anim != null )
					{
						AddObject( aChild.Anim );
						outObj.ShownInlineHash.Add( arrayHash + i );
					}
				}
			}

			if( obj is AnimTree tree )
			{
				var uArrayHash = ObjectNodeDrawer.NewHash( ObjectNodeDrawer.HashInitValue, 
					ReflectionData.GetDataFor(obj.GetType()).FindField( nameof( AnimTree.SkelControlLists ) ) );
				var arrayHash = ObjectNodeDrawer.NewHash(uArrayHash, 
					ReflectionData.GetDataFor(tree.SkelControlLists.GetType()).FindField( "__items" ));
				outObj.ShownInlineHash.Add( uArrayHash );
				outObj.ShownInlineHash.Add( arrayHash );
				for( int i = 0; i < tree.SkelControlLists.Length; i++ )
				{
					var head = tree.SkelControlLists[ i ];
					if( head.ControlHead != null )
					{
						AddObject( head.ControlHead );
						outObj.ShownInlineHash.Add( arrayHash + i );
					}
				}
			}
			
			return outObj;
		}
		
		

		public override bool RemoveObj( object obj )
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



		protected override IEnumerable<INode> Nodes()
		{
			// This is for editor reloads
			if( _nodes == null && _file != null )
			{
				LoadFile(_file);
			}


			return _nodes;
		}



		class AnimNodeDrawer : ObjectGraphWindow.ObjectNodeDrawer
		{
			protected override string Title => _observedObject is AnimNode n && n.NodeName.Value.ToString() != "" ? n.NodeName.Value.ToString() : base.Title;
			
			public override Vector2 Pos
			{
				get
				{
					if( _observedObject is AnimNode an )
						return new Vector2( an.NodePosX, an.NodePosY );
					else if( _observedObject is SkelControlBase scb )
						return new Vector2( scb.ControlPosX, scb.ControlPosY );
					else if( _observedObject is MorphNodeBase mnb )
						return new Vector2( mnb.NodePosX, mnb.NodePosY );
					return base.Pos;
				}
				set
				{
					if( _observedObject is AnimNode an )
					{
						an.NodePosX = (int) value.x;
						an.NodePosY = (int) value.y;
					}
					else if( _observedObject is SkelControlBase scb )
					{
						scb.ControlPosX = (int) value.x;
						scb.ControlPosY = (int) value.y;
					}
					else if( _observedObject is MorphNodeBase mnb )
					{
						mnb.NodePosX = (int) value.x;
						mnb.NodePosY = (int) value.y;
					}
					else
					{
						base.Pos = value;
					}
				}
			}



			public override Color? BackgroundColor => (_observedObject as AnimNode)?.bRelevant == true ? new Color(0f, 1f, 0f, 0.1f) : default(Color?);



			public AnimNodeDrawer( object content ) : base( content )
			{
				
			}



			protected override void DrawField( IField field, (ObjectGraphWindow.ObjectNodeDrawer thisNode, int hash, int? arrayItemIndex) data, CachedContainer cache )
			{
				if( field.Info.ReflectedType == typeof(Core.Object) ) 
					return;
				base.DrawField( field, data, cache );
			}
		}
	}
}