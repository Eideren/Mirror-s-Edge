namespace MEdge.Engine
{
	using System.Collections.Generic;
	using Core;



	public partial class WorldInfo
	{
		public HashSet<Actor> _allActors = new HashSet<Actor>();

		bool _gravitySet = false;
		
		// Export UWorldInfo::execGetGravityZ(FFrame&, void* const)
		public override /*native function */float GetGravityZ()
		{
			if( _gravitySet == false )
				this.GlobalGravityZ = this.WorldGravityZ = this.DefaultGravityZ;
			return this.WorldGravityZ;
		}
		
		// Export UWorldInfo::execAllNavigationPoints(FFrame&, void* const)
		public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<NavigationPoint/* N*/> AllNavigationPoints(Core.ClassT<NavigationPoint> BaseClass)
		{
			foreach( var actor in _allActors )
			{
				if( BaseClass.IsBaseOf( actor.Class ) )
					yield return actor as NavigationPoint;
			}
		}
		
		// Export UWorldInfo::execAllControllers(FFrame&, void* const)
        public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<Controller/* C*/> AllControllers(Core.ClassT<Controller> BaseClass)
        {
	        foreach( var actor in _allActors )
	        {
		        if( BaseClass.IsBaseOf( actor.Class ) )
			        yield return actor as Controller;
	        }
        }
        
        
		// Export UWorldInfo::execAllPawns(FFrame&, void* const)
        public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<Pawn/* P*/> AllPawns(Core.ClassT<Pawn> BaseClass, /*optional */Object.Vector? _TestLocation = default, /*optional */float? _TestRadius = default)
        {
	        if( _TestLocation != null && _TestRadius != null )
	        {
		        var l = _TestLocation.Value;
		        var r = _TestRadius.Value;
		        foreach( var actor in _allActors )
		        {
			        if( BaseClass.IsBaseOf( actor.Class ) && (actor.Location - l).Size() < r )
				        yield return actor as Pawn;
		        }
	        }
	        else
	        {
		        foreach( var actor in _allActors )
		        {
			        if( BaseClass.IsBaseOf( actor.Class ) )
				        yield return actor as Pawn;
		        }
	        }
        }
	}
}