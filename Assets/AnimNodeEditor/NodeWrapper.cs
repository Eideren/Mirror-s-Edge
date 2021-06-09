namespace MEdge.AnimNodeEditor
{
	using System.Collections.Generic;
	using System.Reflection;
	using Engine;
	using UnityEngine;
	using NodeEditor;



	public class NodeWrapper : INode
	{
		static WeakCache<array<AnimNodeBlendBase.AnimBlendChild>, List<BlendChildSlot>> blendChildKeys = new WeakCache<array<AnimNodeBlendBase.AnimBlendChild>, List<BlendChildSlot>>();
		class BlendChildSlot
		{
			public array<AnimNodeBlendBase.AnimBlendChild> Array;
			public int Index;
		}



		public AnimNode Node = new AnimTree();


		public Vector2 Pos
		{
			get => new Vector2( Node.NodePosX, Node.NodePosY );
			set
			{
				Node.NodePosX = (int) value.x;
				Node.NodePosY = (int) value.y;
			}
		}



		public void OnDraw( NodeDrawer drawer )
		{
			if( Node is AnimNodeBlendBase anbb )
			{
				BlendChildSlot target = null;
				drawer.MarkNextAsLinkPoint( anbb, ref target, false );
				if( target != null )
				{
					target.Array[target.Index].Anim = anbb;
				}
			}
			
			drawer.DrawLabel( Node.GetType().Name );
			drawer.UseRect();
			
			var fields = ReflectionCache.GetAllFieldsForSerialization( Node.GetType() );

			foreach( (FieldInfo info, var get, var set) in fields )
			{
				if( info.ReflectedType == typeof(Core.Object) )
					continue;
				
				

				var v = get(Node);
				if( v is array<AnimNodeBlendBase.AnimBlendChild> children )
				{
					drawer.DrawLabel(info.Name);
					var blendChildSlots = blendChildKeys[ children ];
					while( blendChildSlots.Count < children.Length )
						blendChildSlots.Add( new BlendChildSlot { Array = children, Index = blendChildSlots.Count } );
					
					for( int i = 0; i < children.Length; i++ )
					{
						var thisTarget = blendChildSlots[i];
						ref var child = ref children[ i ];
						drawer.MarkNextAsLinkPoint(thisTarget, ref child.Anim);
						drawer.DrawLabel(" -");
					}
				}
				else
				{
					drawer.DrawProperty( info.Name, ref v, out var changed );
					if( changed )
					{
						var c = (object)Node;
						set(ref c, v);
					}
				}
			}
		}
	}
}