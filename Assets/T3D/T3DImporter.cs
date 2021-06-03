#if CSHARP_7_3_OR_NEWER
using System.IO;
using UnityEngine;
using UnityEditor.AssetImporters;

namespace MEdge.T3D
{
[ScriptedImporter(1, "T3D")]
public class T3DImporter : ScriptedImporter
{
    public override void OnImportAsset(AssetImportContext ctx)
    {
        T3DNode node;
        using(var f = File.OpenText(ctx.assetPath))
            node = new T3DNode(f);

        
        var file = ScriptableObject.CreateInstance<T3DFile>();
        file.Root = node;
        ctx.AddObjectToAsset("main obj", file);
        ctx.SetMainObject(file);
    }
}
}
#endif