namespace MEdge.AnimNodeEditor
{
	using System.Collections.Generic;
	using System.Reflection;
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

			ReflectionData.ForeachField( ref Node, delegate( FieldInfo info, IField field, CachedContainer cache )
			{
				if( info.ReflectedType == typeof(Core.Object) )
					return;

				if( drawer.PreviouslyOutOfView && info.GetType() != typeof(array<AnimNodeBlendBase.AnimBlendChild>) )
				{
					drawer.UseRect();
					return;
				}

				switch( field )
				{
					case IField<array<AnimNodeBlendBase.AnimBlendChild>> fChildren:
					{
						var children = fChildren.Ref( cache );
						drawer.DrawLabel( info.Name );
						var blendChildSlots = blendChildKeys[ children ];
						while( blendChildSlots.Count < children.Length )
							blendChildSlots.Add( new BlendChildSlot { Array = children, Index = blendChildSlots.Count } );

						for( int i = 0; i < children.Length; i++ )
						{
							var thisTarget = blendChildSlots[ i ];
							ref var child = ref children[ i ];
							drawer.MarkNextAsLinkPoint( thisTarget, ref child.Anim );
							drawer.DrawLabel( " -" );
						}

						break;
					}
					default:
					{
						var v = field.GetValueSlowAndBox( cache );
						drawer.DrawProperty( info.Name, ref v, out var changed );
						if( changed )
							field.SetValueSlow( cache, v );

						break;
					}
				}
			} );
		}
	}
}