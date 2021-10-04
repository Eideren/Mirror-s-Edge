namespace MEdge.AnimNodeEditor
{
	using System.Collections.Generic;
	using Engine;
	using NodeEditor;
	using Reflection;
	using T3D;
	using TdGame;
	using UnityEngine;



	public class AnimNodeEditorWindow : ObjectGraphWindow
	{
		T3DFile _file;



		public AnimNodeEditorWindow()
		{
			Separation = 4.0f;
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



		TdPawn _inEditModeFor;
		
		protected override void OnGUIDraw()
		{
			bool isInEditMode = _inEditModeFor != null;
			if( GUI.Button( new Rect( 332, 0, 100, 16 ), isInEditMode ? "Edit->Gameplay" : "Gameplay->Edit" ) )
				SwapModeTo(!isInEditMode);
			
			base.OnGUIDraw();
		}



		public void SwapModeTo( bool edit )
		{
			bool isInEditMode = _inEditModeFor != null;
			if( edit == isInEditMode )
				return;
			
			isInEditMode = !isInEditMode;
			var setNodesPawnTo = isInEditMode ? null : _inEditModeFor;
			TdPawn nodesPawn = null;
			foreach( ObjectNodeDrawer drawerNode in _nodes )
			{
				var animNode = ( (AnimNodeDrawer) drawerNode ).GetContent as AnimNode;
				if( animNode == null )
					continue;
				nodesPawn ??= animNode.SkelComponent.Owner as TdPawn;
				animNode.SkelComponent.Owner = setNodesPawnTo;
				switch( animNode )
				{
					case TdAnimNodeBlendList n:
					{
						nodesPawn = n.TdPawnOwner ?? nodesPawn;
						n.TdPawnOwner = setNodesPawnTo;
						break;
					}
					case TdAnimNodeSequence n:
					{
						nodesPawn = n.TdPawnOwner ?? nodesPawn;
						n.TdPawnOwner = setNodesPawnTo;
						break;
					}
					case TdAnimNodeIKEffectorController n:
					{
						nodesPawn = n.PawnOwner ?? nodesPawn;
						n.PawnOwner = setNodesPawnTo;
						break;
					}
				}
			}

			_inEditModeFor = isInEditMode ? nodesPawn : null;
		}



		class AnimNodeDrawer : ObjectGraphWindow.ObjectNodeDrawer
		{
			public object GetContent => this._observedObject;
			
			protected override string Title
			{
				get
				{
					if( _observedObject is AnimNode n && n.NodeName.Value.ToString() != "" )
						return n.NodeName.Value.ToString();
					if( _observedObject is AnimNodeSequence seq && seq.AnimSeqName.Value.ToString() != "" )
						return seq.AnimSeqName.Value.ToString();
					
					return base.Title;
				}
			}
			
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
			
			bool _foldedOut;
			bool _isHovered;
			


			public AnimNodeDrawer( object content ) : base( content )
			{
				
			}



			public override void OnDraw( NodeDrawer drawer )
			{
				if( drawer.IsInView( out var rectButton ) && GUI.Button( rectButton, _foldedOut ? "Fold" : "Unfold" ) )
					_foldedOut = ! _foldedOut;

				if( _observedObject is TdAnimNodeBlendList bl )
				{
					if( drawer.IsNextInView() && drawer.Editor.GUIStyle.fontSize >= NodeDrawer.ClippedFontSize )
					{
						var rect = drawer.UseRect();
						// Weird, I know but that's how it works AFAICT
						var prev = bl.ActiveChildIndex;
						var newSI = Mathf.RoundToInt( GUI.HorizontalSlider( rect, prev, 0, bl.Children.Length - 1 ) );
						if( prev != newSI )
						{
							bl.EditorSliderIndex = newSI;
							bl.SetActiveMove(bl.EditorSliderIndex);
						}
					}
					else
					{
						drawer.UseRect();
					}
				}
				else if( _observedObject is AnimNodeSequence seq && seq.AnimSeq )
				{
					if( drawer.IsNextInView() && drawer.Editor.GUIStyle.fontSize >= NodeDrawer.ClippedFontSize )
					{
						var rect = drawer.UseRect();
						var prev = seq.CurrentTime;
						var curr = GUI.HorizontalSlider( rect, prev, 0f, seq.AnimSeq.SequenceLength );
						if( curr != prev )
							seq.AdvanceBy( curr - prev, 1f, false );
					}
					else
					{
						drawer.UseRect();
					}
				}

				base.OnDraw( drawer );
				_isHovered = drawer.SurfaceCovered.Contains( Event.current.mousePosition );
			}



			protected override void DrawField( IField field, (ObjectGraphWindow.ObjectNodeDrawer thisNode, int hash, int? arrayItemIndex) data, CachedContainer cache )
			{
				if( field.Info.ReflectedType == typeof(Core.Object) ) 
					return;

				if( _isHovered == false && _foldedOut == false )
				{
					if( field.Info.FieldType == typeof(array<AnimNodeBlendBase.AnimBlendChild>)  
					    || field.Info.FieldType == typeof(AnimNodeBlendBase.AnimBlendChild) 
					    || field.Info.FieldType == typeof(AnimNodeBlendBase.AnimBlendChild[])
					    || (field.Info.ReflectedType == typeof(AnimNodeBlendBase.AnimBlendChild) 
					        && field.Info.Name == nameof(AnimNodeBlendBase.AnimBlendChild.Anim)) )
					{
						base.DrawField( field, data, cache );
					}
					return;
				}

				base.DrawField( field, data, cache );
			}



			protected override Color? LineColorFor( IField field, CachedContainer container )
			{
				return container.ContainerAsObj is AnimNodeBlendBase.AnimBlendChild abc ? abc.TotalWeight > 0f ? new Color(0, 1, 0, 0.25f) : null : null;
			}
		}
	}
}