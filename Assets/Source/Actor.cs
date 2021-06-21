namespace MEdge.Engine
{
	using Core;
	using static UnityEngine.Debug;
    using Object = Core.Object;



    public partial class Actor
    {
        // Export UActor::execSpawn(FFrame&, void* const)
        public virtual /*native final function */ T Spawn<T>(Core.ClassT<T> SpawnClass, /*optional */
            Actor SpawnOwner = default, /*optional */Core.name? SpawnTag = default, /*optional */
            Object.Vector? SpawnLocation = default, /*optional */Object.Rotator? SpawnRotation = default, /*optional */
            Actor ActorTemplate = default, /*optional */bool? bNoCollisionFail = default) where T : Actor
        {
            // Decompiled from _E_UActor_execSpawn
            var result = UWorld.Instance.E_UWorld_SpawnActor( SpawnClass, 0, 0, SpawnLocation ?? Location, SpawnRotation ?? Rotation, ActorTemplate, bNoCollisionFail ?? false /* probably */, 0, SpawnOwner, this.Instigator, false );
            if( result != null && SpawnTag != null )
            {
                result.Tag = SpawnTag.Value;
            }
            return result;
        }
        
	
        // Export UActor::execDestroy(FFrame&, void* const)
        public virtual /*native(279) final function */bool Destroy()
        {
            LogWarning( "Destroy not implemented yet" );
            return true;
        }
        
        // Export UActor::execAllActors(FFrame&, void* const)
        public virtual /*native(304) final iterator function */System.Collections.Generic.IEnumerable<Actor/* Actor*/> AllActors(Core.ClassT<Actor> BaseClass)
        {
	        foreach( var actor in WorldInfo._allActors )
	        {
		        if( BaseClass.IsBaseOf( actor.Class ) )
			        yield return actor;
	        }
        }

        // Export UActor::execDynamicActors(FFrame&, void* const)
        public virtual /*native(313) final iterator function */System.Collections.Generic.IEnumerable<Actor/* Actor*/> DynamicActors(Core.ClassT<Actor> BaseClass)
        {
	        foreach( var actor in WorldInfo._allActors )
	        {
		        if( actor.bStatic == false && BaseClass.IsBaseOf( actor.Class ) )
			        yield return actor;
	        }
        }
        
        // Export UActor::execLocalPlayerControllers(FFrame&, void* const)
        public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<PlayerController/* PC*/> LocalPlayerControllers(Core.ClassT<PlayerController> BaseClass)
        {
	        foreach( var actor in WorldInfo._allActors )
	        {
		        if( BaseClass.IsBaseOf( actor.Class ) )
			        yield return actor as PlayerController;
	        }
        }
        
        public virtual /*native(305) final iterator function */System.Collections.Generic.IEnumerable<Actor/* Actor*/> ChildActors(Core.ClassT<Actor> BaseClass)
        {
	        foreach( var component in this.Children )
	        {
		        if( BaseClass.IsBaseOf( component.Class ) )
			        yield return component;
	        }
        }
	
        // Export UActor::execBasedActors(FFrame&, void* const)
        public virtual /*native(306) final iterator function */System.Collections.Generic.IEnumerable<Actor/* Actor*/> BasedActors(Core.ClassT<Actor> BaseClass)
        {
	        foreach( var component in this.Attached )
	        {
		        if( BaseClass.IsBaseOf( component.Class ) )
			        yield return component;
	        }
        }
	
        // Export UActor::execTouchingActors(FFrame&, void* const)
        public virtual /*native(307) final iterator function */System.Collections.Generic.IEnumerable<Actor/* Actor*/> TouchingActors(Core.ClassT<Actor> BaseClass)
        {
	        foreach( var component in this.Touching )
	        {
		        if( BaseClass.IsBaseOf( component.Class ) )
			        yield return component;
	        }
        }

		// Export UActor::execComponentList(FFrame&, void* const)
		public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<ActorComponent/* out_Component*/> ComponentList(Class BaseClass)
		{
			foreach( var component in this.Components )
			{
				if( BaseClass.IsBaseOf( component.Class ) )
					yield return component;
			}
		}

		// Export UActor::execAllOwnedComponents(FFrame&, void* const)
		public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<ActorComponent/* OutComponent*/> AllOwnedComponents(Core.ClassT<Component> BaseClass)
		{
			foreach( var component in this.AllComponents )
			{
				if( BaseClass.IsBaseOf( component.Class ) )
					yield return component;
			}
		}
        
		// Export UActor::execTraceActors(FFrame&, void* const)
		public virtual /*native(309) final iterator function */System.Collections.Generic.IEnumerable<(Actor/* Actor*/,Object.Vector/* HitLoc*/,Object.Vector/* HitNorm*/,Actor.TraceHitInfo/* HitInfo*/)> TraceActors(Core.ClassT<Actor> BaseClass, Object.Vector End, /*optional */Object.Vector? _Start/* = default*/, /*optional */Object.Vector? _Extent/* = default*/, /*optional */int? _ExtraTraceFlags = default)
		{
			 // #warning NATIVE FUNCTION !
			yield break;
		}

		// Export UActor::execVisibleActors(FFrame&, void* const)
		public virtual /*native(311) final iterator function */System.Collections.Generic.IEnumerable<Actor/* Actor*/> VisibleActors(Core.ClassT<Actor> BaseClass, /*optional */float? _Radius = default, /*optional */Object.Vector? _Loc = default)
		{
			 // #warning NATIVE FUNCTION !
			yield break;
		}

		// Export UActor::execVisibleCollidingActors(FFrame&, void* const)
		public virtual /*native(312) final iterator function */System.Collections.Generic.IEnumerable<Actor/* Actor*/> VisibleCollidingActors(Core.ClassT<Actor> BaseClass, float Radius, /*optional */Object.Vector? _Loc = default, /*optional */bool? _bIgnoreHidden = default)
		{
			 // #warning NATIVE FUNCTION !
			yield break;
		}

		// Export UActor::execCollidingActors(FFrame&, void* const)
		public virtual /*native(321) final iterator function */System.Collections.Generic.IEnumerable<Actor/* Actor*/> CollidingActors(Core.ClassT<Actor> BaseClass, float Radius, /*optional */Object.Vector? _Loc = default, /*optional */bool? _bUseOverlapCheck = default)
		{
			 // #warning NATIVE FUNCTION !
			yield break;
		}

		// Export UActor::execOverlappingActors(FFrame&, void* const)
		public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<Actor/* out_Actor*/> OverlappingActors(Core.ClassT<Actor> BaseClass, float Radius, /*optional */Object.Vector? _Loc = default, /*optional */bool? _bIgnoreHidden = default)
		{
			 // #warning NATIVE FUNCTION !
			yield break;
		}

    }
}