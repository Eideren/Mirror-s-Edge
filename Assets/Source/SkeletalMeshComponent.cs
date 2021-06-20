﻿namespace MEdge.Engine
{
	using System.Collections.Generic;
	using System.Linq;
	using Core;
	using JetBrains.Annotations;
	using Source;
	using UnityEngine;
	using Object = Core.Object;
	using static UnityEngine.Debug;



	public partial class SkeletalMeshComponent
	{
		IEnumerable<AnimNode> EnumerateAllNodes( AnimNode n )
		{
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



		// Export USkeletalMeshComponent::execForceSkelUpdate(FFrame&, void* const)
		public virtual /*native final function */void ForceSkelUpdate()
		{
			// Not implemented yet
		}

		// Export USkeletalMeshComponent::execUpdateAnimations(FFrame&, void* const)
		public virtual /*native final function */void UpdateAnimations()
		{
			Animations = AnimTreeTemplate;
			LogWarning( $"Need to implement clone for {nameof(AnimTreeTemplate)} instead of straight assign" );
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
				if( BaseClass.IsParentOf( node.Class ) )
					yield return node;
			}
		}
		
		// Export USkeletalMeshComponent::execFindSkelControl(FFrame&, void* const)
		public virtual /*native final function */SkelControlBase FindSkelControl(name InControlName)
		{
			var tree = EnumerateAllNodes( Animations ).First( x => x is AnimTree ) as AnimTree;
			foreach( var skelControl in tree.SkelControlLists )
			{
				if( skelControl.ControlHead.ControlName == InControlName )
					return skelControl.ControlHead;
			}
			
			return default;
		}
	
		// Export USkeletalMeshComponent::execFindMorphNode(FFrame&, void* const)
		public virtual /*native final function */MorphNodeBase FindMorphNode(name InNodeName)
		{
			// Not implemented yet
			return default;
		}
	
		// Export USkeletalMeshComponent::execGetBoneQuaternion(FFrame&, void* const)
		public virtual /*native final function */Object.Quat GetBoneQuaternion(name BoneName, /*optional */int? _Space = default)
		{
			#warning not implemented yet
			return default;
		}
	
		// Export USkeletalMeshComponent::execGetBoneLocation(FFrame&, void* const)
		public virtual /*native final function */Object.Vector GetBoneLocation(name BoneName, /*optional */int? _Space = default)
		{
			_associatedRenderer ??= Asset.UScriptToUnity.TryGetValue( this, out var smr ) ? (SkinnedMeshRenderer) smr : throw new System.NullReferenceException();
			foreach( var bone in _associatedRenderer.bones )
			{
				if( bone.name == BoneName )
					return (Object.Vector)bone.position;
			}
			
			return default;
		}
	
		// Export USkeletalMeshComponent::execMatchRefBone(FFrame&, void* const)
		public virtual /*native final function */int MatchRefBone(name BoneName)
		{
			// Not implemented yet
			return default;
		}
	}
}