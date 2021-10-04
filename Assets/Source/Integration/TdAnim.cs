namespace MEdge.TdGame
{
    using Engine;



    public partial class TdAnimNodeBlendList
    {
        public override void InitAnim( SkeletalMeshComponent meshComp, AnimNodeBlendBase Parent )
        {
            base.InitAnim( meshComp, Parent );
            TdPawnOwner = meshComp.Owner as TdPawn;
        }
    }



    public partial class TdAnimNodeIKEffectorController
    {
        public override void InitAnim( SkeletalMeshComponent meshComp, AnimNodeBlendBase Parent )
        {
            base.InitAnim( meshComp, Parent );
            PawnOwner = meshComp.Owner as TdPawn;
        }
    }
}