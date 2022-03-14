namespace MEdge
{
    using Core;
    using Engine;



    public class SpawnPoint : UBehaviour, IUObject
    {
        PlayerStart _playerStart;
        public bool AllowImprovements;


        protected override void Update()
        {
            base.Update();
            IUWorld.AllowImprovements = AllowImprovements;
        }



        public Object GetUObject() => _playerStart ??= new PlayerStart();
    }
}
