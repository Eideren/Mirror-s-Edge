using UnityEngine;

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


        public void OnDrawGizmos()
        {
            // This is not exact, just an idea of how large of an area the player character likely needs to spawn properly
            var size = new Vector3(1, 2, 1);
            var pos = this.transform.position + Vector3.up * size.y * 0.5f;
            Gizmos.color = (Physics.CheckBox(pos, size * 0.5f) ? Color.red : Color.yellow) * new Color(1f, 1f, 1f, 0.25f);
            Gizmos.DrawCube( pos, size );
            Gizmos.DrawWireCube( pos, size );
        }
    }
}
