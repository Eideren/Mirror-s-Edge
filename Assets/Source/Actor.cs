namespace MEdge.Engine
{
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
    }
}