namespace MEdge.AnimNodeEditor
{
	using System;
	using System.Collections.Generic;
	using Engine;
	using UnityEngine;
	using NodeEditor;
	using Reflection;
	using static UnityEngine.Debug;



	public class AnimNodeDrawer : INode
	{
		static WeakCache<array<AnimNodeBlendBase.AnimBlendChild>, List<BlendChildSlot>> blendChildKeys = new WeakCache<array<AnimNodeBlendBase.AnimBlendChild>, List<BlendChildSlot>>();



		class BlendChildSlot
		{
			public array<AnimNodeBlendBase.AnimBlendChild> Array;
			public int Index;
		}



		public AnimNode Node;
		NodeDrawer _drawer;
		Action<IField, CachedContainer> _cachedInspect;


		public Vector2 Pos
		{
			get => new Vector2( Node.NodePosX, Node.NodePosY );
			set
			{
				Node.NodePosX = (int) value.x;
				Node.NodePosY = (int) value.y;
			}
		}



		public AnimNodeDrawer( AnimNode node )
		{
			Node = node;
		}



		public void OnDraw( NodeDrawer drawer )
		{
			_drawer = drawer;
			if( Node is AnimNodeBlendBase anbb )
			{
				BlendChildSlot target = null;
				drawer.MarkNextAsLinkPoint( anbb, ref target, false );
				if( target != null )
				{
					target.Array[ target.Index ].Anim = anbb;
				}
			}

			drawer.DrawLabel( Node.GetType().Name );
			drawer.UseRect();
			ReflectionData.ForeachField( ref Node, _cachedInspect ??= Inspect );
		}
		
		

		void Inspect( IField field, CachedContainer cache )
		{
			if( field.Info.ReflectedType == typeof(Core.Object) ) return;

			if( _drawer.PreviouslyOutOfView && field.Info.GetType() != typeof(array<AnimNodeBlendBase.AnimBlendChild>) )
			{
				_drawer.UseRect();
				return;
			}

			switch( field )
			{
				case IField<array<AnimNodeBlendBase.AnimBlendChild>> fChildren:
				{
					var children = fChildren.Ref( cache );
					_drawer.DrawLabel( field.Info.Name );
					var blendChildSlots = blendChildKeys[ children ];
					while( blendChildSlots.Count < children.Length ) blendChildSlots.Add( new BlendChildSlot { Array = children, Index = blendChildSlots.Count } );

					for( int i = 0; i < children.Length; i++ )
					{
						var thisTarget = blendChildSlots[ i ];
						ref var child = ref children[ i ];
						_drawer.MarkNextAsLinkPoint( thisTarget, ref child.Anim );
						_drawer.DrawLabel( " -" );
					}

					break;
				}
				default:
				{
					_drawer.DrawProperty( field, cache );
					break;
				}
			}
		}
	}
}