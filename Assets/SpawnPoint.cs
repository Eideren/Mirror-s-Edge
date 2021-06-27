namespace MEdge
{
    using Core;
    using Engine;



    public class SpawnPoint : UBehaviour, IUObject
    {
        PlayerStart _playerStart;
        
        public Object GetUObject() => _playerStart ??= new PlayerStart();
    }
}
