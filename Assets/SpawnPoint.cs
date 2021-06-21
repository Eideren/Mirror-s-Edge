using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MEdge
{
    using Core;
    using Engine;



    public class SpawnPoint : MonoBehaviour, IUObject
    {
        PlayerStart _playerStart;
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }



        public Object GetUObject() => _playerStart ??= new PlayerStart();
    }
}
