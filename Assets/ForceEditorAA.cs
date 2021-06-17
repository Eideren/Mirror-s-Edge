namespace MEdge
{
    using UnityEngine;
    [ExecuteAlways, ImageEffectAllowedInSceneView]
    public class ForceEditorAA : MonoBehaviour
    {
        #if UNITY_EDITOR
        [ImageEffectUsesCommandBuffer]
        void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            Graphics.Blit(source, destination);
        }
        #endif
    }
}
