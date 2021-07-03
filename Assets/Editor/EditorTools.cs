namespace MEdge.Editor
{
	using System.IO;
	using System.Linq;
	using UnityEditor;
	using UnityEngine;
	using static UnityEngine.Debug;



	public class FixupRootRotationWindow : EditorWindow
	{
		public string RootName = "root";
		public string PropName = "m_LocalRotation.";
		public Vector3 RotateBy = new Vector3(90f, 0f, 0f);
		void OnGUI()
		{
			EditorGUILayout.TextField( nameof( RootName ), RootName );
			EditorGUILayout.TextField( nameof( PropName ), PropName );
			EditorGUILayout.Vector3Field( nameof( RotateBy ), RotateBy );
			if( GUILayout.Button( "Apply" ) )
			{
				Close();
				EditorTools.FixupRootRotation( RootName, PropName, RotateBy );
			}
		}
	}



	public static class EditorTools
	{
		[MenuItem("Tools/Animations/Extract selected clips out of asset")]
		public static void ExtractAnimations()
		{
			foreach (var o in Selection.objects)
			{
				AnimationClip clip = o as AnimationClip;
				if( clip == null )
					continue;

				var path = AssetDatabase.GetAssetPath( clip );
				LogWarning( $"{nameof(ExtractAnimations)} on '{clip.name}'" );

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



		[ MenuItem( "Tools/Animations/Rotate upright root of selected clips" ) ]
		public static void ShowModalFixupRootRotation()
		{
			var window = EditorWindow.CreateInstance<FixupRootRotationWindow>();
			window.ShowModal();
		}



		public static void FixupRootRotation(string rootName, string propName, Vector3 rotateBy)
		{
			foreach (var o in Selection.objects)
			{
				AnimationClip clip = o as AnimationClip;
				if( clip == null )
					continue;

				EditorCurveBinding[] bindings = new EditorCurveBinding[ 4 ];
				AnimationCurve[] curves = new AnimationCurve[ 4 ];
				foreach( var binding in AnimationUtility.GetCurveBindings( clip ) )
				{
					if( rootName != binding.path || binding.propertyName.StartsWith( propName ) == false || binding.propertyName.Length - 1 != propName.Length )
						continue;
					
					var curve = AnimationUtility.GetEditorCurve( clip, binding );
					int index = binding.propertyName[ binding.propertyName.Length - 1 ] switch
					{
						'x' => 0,
						'y' => 1,
						'z' => 2,
						'w' => 3,
						_ => throw new System.InvalidOperationException()
					};
					curves[ index ] = curve;
					bindings[ index ] = binding;
					if( curves.All( x => x != null ) )
						break;
				}
				
				if( curves.Any( x => x == null ) )
				{
					LogError( $"{nameof(FixupRootRotation)}: Found {curves.Count( x => x != null )}/4 curves when looking for {rootName} {propName} in {curves}" );
					continue;
				}

				// Check curves to avoid losing data when converting
				for( int i = 1; i < curves.Length; i++ )
				{
					var prev = curves[ i - 1 ];
					var current = curves[ i ];
					if( prev.keys.Length != current.keys.Length )
					{
						LogError( $"{nameof(FixupRootRotation)}: {clip} {propName}'s curves, properties of this struct don't have the same amount of keys in the curve" );
						goto NEXT_CLIP;
					}

					for( int j = 0; j < current.keys.Length; j++ )
					{
						if( current.keys[ j ].time != prev.keys[ j ].time )
						{
							LogError( $"{nameof(FixupRootRotation)}: {clip} {propName}'s curves, properties of this struct don't have keys set on the same time ({current.keys[ j ].time}, {prev.keys[ j ].time})" );
							goto NEXT_CLIP;
						}
					}
				}

				AnimationCurve[] outCurves = new AnimationCurve[ 4 ];

				for( int i = 0; i < curves.Length; i++ )
				{
					outCurves[ i ] = new AnimationCurve
					{
						postWrapMode = curves[ i ].postWrapMode, 
						preWrapMode = curves[ i ].preWrapMode
					};
				}
				
				foreach( var key in curves[0].keys )
				{
					var time = key.time;
					Quaternion quat = default;
					for( int i = 0; i < 4; i++ )
						quat[ i ] = curves[ i ].Evaluate( time );
					quat = quat.normalized;
					quat *= Quaternion.Euler( rotateBy );
					
					var copyKey = new Keyframe
					{
						time = time,
						weightedMode = key.weightedMode,
					};
					for( int i = 0; i < 4; i++ )
					{
						copyKey.value = quat[ i ];
						outCurves[ i ].AddKey( copyKey );
					}
				}

				foreach( var outCurve in outCurves )
				{
					for( int i = 0; i < outCurve.keys.Length; i++ )
					{
						outCurve.SmoothTangents(i, 0f);
					}
				}

				for( int i = 0; i < bindings.Length; i++ )
				{
					AnimationUtility.SetEditorCurve( clip, bindings[i], outCurves[i] );
				}
				Log( $"Done with {clip}" );
				NEXT_CLIP:
				continue;
			}
			AssetDatabase.SaveAssets();
		}
	}
}