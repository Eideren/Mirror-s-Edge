namespace MEdge
{
    using UnityEditor;
    using UnityEngine;



    public class ModelAssetProcessing : AssetPostprocessor
    {
        void OnPostprocessModel(GameObject g)
        {
            // Not sure why I wrote this class ... don't remember when I needed such a thing
            
            if(g.GetComponentInChildren<SkinnedMeshRenderer>() == null)
                return;
            
            bool changed = false;
            for( int i = 0; i < g.transform.childCount; i++ )
            {
                var c = g.transform.GetChild( i ).transform;
                if( c.localRotation != Quaternion.identity )
                {
                    c.localRotation = Quaternion.identity;
                    changed = true;
                }
            }

            if( changed )
            {
                LogWarning( $"{nameof(ModelAssetProcessing)}: Zero-ed {g.name}'s children imported rotation" );
            }
        }
    }
}
