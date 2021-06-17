namespace MEdge.Editor
{
	using System.IO;
	using UnityEditor;
	using UnityEngine;



	public static class EditorTools
	{
		[MenuItem("Tools/Extract selected animations")]
		public static void ExtractAnimations()
		{
			foreach (var o in Selection.objects)
			{
				AnimationClip clip = o as AnimationClip;
				if( clip == null )
					continue;

				var path = AssetDatabase.GetAssetPath( clip );
				Debug.LogWarning( $"{nameof(ExtractAnimations)} on '{clip.name}'" );

				var original = clip;
				clip = AnimationClip.Instantiate( clip );
				clip.name = original.name;

				AnimationClipSettings settings = AnimationUtility.GetAnimationClipSettings(clip);
				settings.loopTime = true;
				settings.loopBlend = true;
				settings.loopBlendOrientation = true;
				
				AnimationUtility.SetAnimationClipSettings(clip, settings);


				var newDirName = "Extracted";
				var baseDir = Path.GetDirectoryName( path );
				var newDir = Path.Combine( baseDir, newDirName );
				
				if( AssetDatabase.IsValidFolder( newDir ) == false )
					AssetDatabase.CreateFolder( baseDir, newDirName );
				AssetDatabase.CreateAsset(clip, Path.Combine( newDir, $"{clip.name}.anim" ) );
			}
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
		}
	}
}