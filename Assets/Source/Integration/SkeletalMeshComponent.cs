namespace MEdge.Engine
{
	using System.Collections.Generic;
	using System.Linq;
	using Core;
	using JetBrains.Annotations;
	using UnityEngine;
	using Object = Core.Object;



	public partial class SkeletalMeshComponent
	{
		IEnumerable<AnimNode> EnumerateAllNodes( AnimNode n )
		{
			if( n == null )
				yield break; 
			yield return n;
			if( n is AnimNodeBlendBase anbb )
			{
				foreach( var child in anbb.Children )
				{
					foreach( var node in EnumerateAllNodes( child.Anim ) )
					{
						yield return node;
					}
				}
			}
		}



		[CanBeNull] SkinnedMeshRenderer _associatedRenderer;
		[CanBeNull] Dictionary<name, Transform> _bones;



		// Export USkeletalMeshComponent::execForceSkelUpdate(FFrame&, void* const)
		public virtual /*native final function */void ForceSkelUpdate()
		{
			NativeMarkers.MarkUnimplemented();
		}

		// Export USkeletalMeshComponent::execUpdateAnimations(FFrame&, void* const)
		public virtual /*native final function */void UpdateAnimations()
		{
			NativeMarkers.MarkUnimplemented();
		}
		
		// Export USkeletalMeshComponent::execFindAnimNode(FFrame&, void* const)
		public virtual /*native final function */AnimNode FindAnimNode(name InNodeName)
		{
			foreach( var node in EnumerateAllNodes( Animations ) )
			{
				if( node.NodeName == InNodeName )
					return node;
			}

			return default;
		}

		public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<AnimNode/* Node*/> AllAnimNodes(Core.ClassT<AnimNode> BaseClass)
		{
			foreach( var node in EnumerateAllNodes( Animations ) )
			{
				if( BaseClass.IsBaseOf( node.Class ) )
					yield return node;
			}
		}
		
		// Export USkeletalMeshComponent::execFindSkelControl(FFrame&, void* const)
		public virtual /*native final function */SkelControlBase FindSkelControl(name InControlName)
		{
			var tree = EnumerateAllNodes( Animations ).First( x => x is AnimTree ) as AnimTree;
			foreach( var skelControl in tree.SkelControlLists )
			{
				if( skelControl.ControlHead == null )
					continue;

				for( var c = skelControl.ControlHead; c != null; c = c.NextControl )
				{
					if( c.ControlName == InControlName )
						return c;
				}
			}
			
			return default;
		}
	
		// Export USkeletalMeshComponent::execFindMorphNode(FFrame&, void* const)
		public virtual /*native final function */MorphNodeBase FindMorphNode(name InNodeName)
		{
			NativeMarkers.MarkUnimplemented();
			return default;
		}
	
		// Export USkeletalMeshComponent::execGetBoneQuaternion(FFrame&, void* const)
		public virtual /*native final function */Object.Quat GetBoneQuaternion(name BoneName, /*optional */int? _Space = default)
		{
			#warning not implemented yet
			return default;
		}
	
		// Export USkeletalMeshComponent::execGetBoneLocation(FFrame&, void* const)
		public virtual /*native final function */Object.Vector GetBoneLocation(name BoneName, /*optional */int? _Space = default) // 0 == World, 1 == Local (Component)
		{
			var renderer = _associatedRenderer ??= UWorldBridge.GetUWorld().UScriptToUnity.TryGetValue( this.SkeletalMesh, out var smr ) ? (SkinnedMeshRenderer) smr : throw new System.NullReferenceException();
			_bones ??= BuildBonesDictionary( renderer.transform.parent );
			return (_Space == 1 ? _bones![ BoneName ].localPosition : _bones![ BoneName ].position).ToUnrealPos();
		}



		static Dictionary<name, Transform> BuildBonesDictionary( Transform parent )
		{
			var buff = new Dictionary<name, Transform>();
			foreach( var children in parent.GetComponentsInChildren<Transform>() )
			{
				if( buff.ContainsKey( children.name ) == false )
					buff[ children.name ] = children;
				else
					Debug.LogWarning( $"Non-unique bone name ({children.name}) found in hierarchy of {parent.name}, might mess with internal logic" );
			}

			return buff;
		}



		// Export USkeletalMeshComponent::execMatchRefBone(FFrame&, void* const)
		public virtual /*native final function */int MatchRefBone(name BoneName)
		{
			NativeMarkers.MarkUnimplemented();
			return default;
		}
	}
}