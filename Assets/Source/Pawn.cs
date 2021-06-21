namespace MEdge.Engine
{
	public partial class Pawn
	{
		// Export UPawn::execIsHumanControlled(FFrame&, void* const)
        public virtual /*native final simulated function */bool IsHumanControlled()
        {
	        // IsHumanControlled() return true if controlled by a real live human on the local machine. On client, only local player's pawn returns true
	        return this.Controller is PlayerController;
        }
        
        // Export UPawn::execIsLocallyControlled(FFrame&, void* const)
        public virtual /*native final simulated function */ bool IsLocallyControlled()
        {
	        // IsLocallyControlled() return true if controlled by local (not network) player
	        return ( this.Controller as PlayerController )?.Player is LocalPlayer;
        }
        
        // Export UPawn::execIsPlayerPawn(FFrame&, void* const)
        public virtual /*native simulated function */bool IsPlayerPawn()
        {
	        // IsPlayerPawn() return true if controlled by a Player (AI or human) on local machine (any controller on server, localclient's pawn on client)
        	return true;
        }
	}
}