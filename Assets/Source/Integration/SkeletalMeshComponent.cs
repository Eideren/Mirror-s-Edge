namespace MEdge.Engine
{
	using System.Collections.Generic;
	using System.Linq;
	using Core;
	using JetBrains.Annotations;
	using Source;
	using UnityEngine;
	using Object = Core.Object;
	using static Source.DecFn;



	public partial class SkeletalMeshComponent
	{
		[CanBeNull] SkinnedMeshRenderer _associatedRenderer;
		[CanBeNull] Dictionary<name, Transform> _bones;
		
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

		// Export USkeletalMeshComponent::execUpdateAnimations(FFrame&, void* const)
		public virtual /*native final function */void UpdateAnimations()
		{
			if( Animations )
			{
				// Force all nodes in the AnimTree to re-look up their animations.
				TickTag++;
				Animations.AnimSetsUpdated();
			}
		}
		
		public bool LegLineCheck(in Vector Start, in Vector End, ref Vector HitLocation, ref Vector HitNormal)
		{
			if(Owner)
			{
				DecFn.CheckResult Hit = new(1f);
				var bHit = !GWorld.SingleLineCheck( ref Hit, Owner, End, Start, (int)ETraceFlags.TRACE_AllBlocking );
				if(bHit)
				{
					HitLocation = Hit.Location;
					HitNormal = Hit.Normal;
					return true;
				}
			}

			return false;
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
			AnimTree AnimTree = Animations as AnimTree;
			if(AnimTree)
			{
				return AnimTree.FindSkelControl(InControlName);
			}

			return null;
		}
	
		// Export USkeletalMeshComponent::execFindAnimSequence(FFrame&, void* const)
		public virtual /*native final function */AnimSequence FindAnimSequence(name AnimSeqName)
		{
			for( int i = AnimSets.Length - 1; i >= 0; i-- )
			{
				var set = AnimSets[ i ];
				if( set == null )
					continue;
				
				for( int j = 0; j < set.Sequences.Length; j++ )
				{
					var seq = set.Sequences[ j ];
					if( seq.SequenceName == AnimSeqName )
						return seq;
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
			var bone = HACK_GetUnityBone( BoneName );
			return (Quat)(_Space == 1 ? bone.localRotation : bone.rotation);
		}
	
		// Export USkeletalMeshComponent::execGetBoneLocation(FFrame&, void* const)
		public virtual /*native final function */Object.Vector GetBoneLocation(name BoneName, /*optional */int? _Space = default) // 0 == World, 1 == Local (Component)
		{
			var bone = HACK_GetUnityBone( BoneName );
			return (_Space == 1 ? bone.localPosition : bone.position).ToUnrealPos();
		}



		Transform HACK_GetUnityBone( name BoneName )
		{
			var renderer = _associatedRenderer ??= UWorldBridge.GetUWorld().UScriptToUnity.TryGetValue( this.SkeletalMesh, out var smr ) ? (SkinnedMeshRenderer) smr : throw new System.NullReferenceException();
			_bones ??= BuildBonesDictionary( renderer.transform.parent );
			return _bones![ BoneName ];
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
	}
}