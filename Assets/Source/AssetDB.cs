using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MEdge.Source
{
    [CreateAssetMenu(fileName = "AssetDB", menuName = "AssetDB", order = 1)]
    public class AssetDB : ScriptableObject
    {
        public string InspectingPathAt = "Assets/Source/Resources/";
        public string[] Paths;

        public Dictionary<Core.name, string> NameToPath
        {
            get
            {
                _nameToPath = new(Paths.Length);
                foreach (string path in Paths)
                {
                    var fName = System.IO.Path.GetFileNameWithoutExtension(path);
                    if(_banned.Contains(fName))
                        continue;

                    // Name conflicts are automatically removed and prevented to avoid/highlight issues 
                    if (_nameToPath.ContainsKey(fName))
                    {
                        _banned.Add(fName);
                        _nameToPath.Remove(fName);
                        continue;
                    }
                    
                    _nameToPath.Add( fName, path[..^System.IO.Path.GetExtension(path).Length] );
                }
                
                return _nameToPath;
            }
        }

        private Dictionary<Core.name, string> _nameToPath;
        private HashSet<Core.name> _banned = new();

        public void OnEnable()
        {
            #if UNITY_EDITOR
            hideFlags = HideFlags.DontUnloadUnusedAsset;

            Paths = (
                from x in UnityEditor.AssetDatabase.FindAssets("", new[] {InspectingPathAt})
                let path = UnityEditor.AssetDatabase.GUIDToAssetPath(x).Remove(0, InspectingPathAt.Length)
                where path.Contains('.')
                select path
                ).ToArray();
            Debug.Log($"AssetDB reset with {Paths.Length} items");
            #endif
        }
    }
}
