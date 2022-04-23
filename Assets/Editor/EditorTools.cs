namespace MEdge.Editor
{
	using System;
	using System.IO;
	using System.Linq;
	using UnityEditor;
	using UnityEngine;
	using static UnityEngine.Debug;



	public class FixupRootRotationWindow : EditorWindow
	{
		public string RootName = "root";
		public string PropName = "m_LocalRotation.";
		public string PropName2 = "m_LocalPosition.";
		public Vector3 RotateBy = new Vector3(90f, 0f, 0f);
		void OnGUI()
		{
			RootName = EditorGUILayout.TextField( nameof( RootName ), RootName );
			PropName = EditorGUILayout.TextField( nameof( PropName ), PropName );
			PropName2 = EditorGUILayout.TextField( nameof( PropName2 ), PropName2 );
			RotateBy = EditorGUILayout.Vector3Field( nameof( RotateBy ), RotateBy );
			if( GUILayout.Button( "Apply" ) )
			{
				Close();
				EditorTools.FixupRootRotation( RootName, PropName, PropName2, RotateBy );
			}
		}
	}



	public static class EditorTools
	{
		[MenuItem("Tools/Animations/Extract selected clips out of model")]
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



		[MenuItem("Tools/Animations/Rotate root of selected clips upright")]
		public static void ShowModalFixupRootRotation()
		{
			var window = EditorWindow.CreateInstance<FixupRootRotationWindow>();
			window.ShowModal();
		}



		public static void FixupRootRotation(string rootName, string propName, string propNamePos, Vector3 rotateBy)
		{
			foreach (var o in Selection.objects)
			{
				AnimationClip clip = o as AnimationClip;
				if( clip == null )
					continue;

				EditorCurveBinding[] bindingsQuat = new EditorCurveBinding[ 4 ];
				EditorCurveBinding[] bindingsPos = new EditorCurveBinding[ 3 ];
				int count = 0;
				foreach( var binding in AnimationUtility.GetCurveBindings( clip ) )
				{
					if( rootName != binding.path || binding.propertyName.StartsWith( propName ) == false || binding.propertyName.Length - 1 != propName.Length )
						continue;
					
					int index = binding.propertyName[ binding.propertyName.Length - 1 ] switch
					{
						'x' => 0,
						'y' => 1,
						'z' => 2,
						'w' => 3,
						_ => throw new System.InvalidOperationException()
					};
					
					bindingsQuat[ index ] = binding;
					if( ++count >= 4 )
						break;
				}
				count = 0;
				foreach( var binding in AnimationUtility.GetCurveBindings( clip ) )
				{
					if( rootName != binding.path || binding.propertyName.StartsWith( propNamePos ) == false || binding.propertyName.Length - 1 != propNamePos.Length )
						continue;
					
					int index = binding.propertyName[ binding.propertyName.Length - 1 ] switch
					{
						'x' => 0,
						'y' => 1,
						'z' => 2,
						_ => throw new System.InvalidOperationException()
					};
					
					bindingsPos[ index ] = binding;
					if( ++count >= 3 )
						break;
				}

				AnimationCurve[] curvesQuat = bindingsQuat.Select( x => AnimationUtility.GetEditorCurve( clip, x ) ).ToArray();
				AnimationCurve[] curvesPos = bindingsPos.Select( x => AnimationUtility.GetEditorCurve( clip, x ) ).ToArray();
				
				if( curvesQuat.Any( x => x == null ) || curvesPos.Any( x => x == null ) )
				{
					LogError( $"{nameof(FixupRootRotation)}: Found {curvesQuat.Count( x => x != null )}/4 curves when looking for {rootName} {propName} in {curvesQuat}" );
					continue;
				}

				// Check curves to avoid losing data when converting
				if(curvesQuat.Any(x => x.keys.Length != curvesQuat[ 0 ].keys.Length) || curvesPos.Any(x => x.keys.Length != curvesPos[ 0 ].keys.Length))
				{
					LogError( $"{nameof(FixupRootRotation)}: {clip} {propName}'s curves, properties of this struct don't have the same amount of keys in the curve" );
					goto NEXT_CLIP;
				}

				
				var times = curvesQuat[ 0 ].keys.Select( y => y.time ).ToArray();
				var times2 = curvesPos[ 0 ].keys.Select( y => y.time ).ToArray();
				if( curvesQuat.Any( x => x.keys.Select( y => y.time ).Any( x => Array.IndexOf( times, x ) == -1 ) ) || 
				    curvesPos.Any( x => x.keys.Select( y => y.time ).Any( x => Array.IndexOf( times2, x ) == -1 ) ) )
				{
					LogError( $"{nameof(FixupRootRotation)}: {clip} {propName}'s curves, properties of this struct don't have keys set on the same time:{string.Join( ",", curvesPos.SelectMany( x => x.keys.Select( x => x.time) ) )} || {string.Join( ",", curvesQuat.SelectMany( x => x.keys.Select( x => x.time) ) )} != {string.Join( ",", times )}" );
					goto NEXT_CLIP;
				}

				AnimationCurve[] outCurvesQuat = curvesQuat.Select( x => new AnimationCurve
				{
					postWrapMode = x.postWrapMode, 
					preWrapMode = x.preWrapMode
				} ).ToArray();
				AnimationCurve[] outCurvesPos = curvesPos.Select( x => new AnimationCurve
				{
					postWrapMode = x.postWrapMode, 
					preWrapMode = x.preWrapMode
				} ).ToArray();

				var rotationOffset = Quaternion.Euler( rotateBy );
				foreach( var key in curvesQuat[0].keys )
				{
					var copyKey = new Keyframe
					{
						time = key.time,
						weightedMode = key.weightedMode,
					};
					Quaternion quat = default;
					for( int i = 0; i < 4; i++ )
						quat[ i ] = curvesQuat[ i ].Evaluate( copyKey.time );
					quat = quat.normalized;
					quat = rotationOffset * quat;
					for( int i = 0; i < 4; i++ )
					{
						copyKey.value = quat[ i ];
						outCurvesQuat[ i ].AddKey( copyKey );
					}
				}
				
				foreach( var key in curvesPos[0].keys )
				{
					var copyKey = new Keyframe
					{
						time = key.time,
						weightedMode = key.weightedMode,
					};
					Vector3 pos = default;
					for( int i = 0; i < 3; i++ )
						pos[ i ] = curvesPos[ i ].Evaluate( copyKey.time );
					pos = rotationOffset * pos;
					for( int i = 0; i < 3; i++ )
					{
						copyKey.value = pos[ i ];
						outCurvesPos[ i ].AddKey( copyKey );
					}
				}

				foreach( var outCurve in outCurvesQuat )
				{
					for( int i = 0; i < outCurve.keys.Length; i++ )
					{
						outCurve.SmoothTangents(i, 0f);
					}
				}
				foreach( var outCurve in outCurvesPos )
				{
					for( int i = 0; i < outCurve.keys.Length; i++ )
					{
						outCurve.SmoothTangents(i, 0f);
					}
				}

				for( int i = 0; i < bindingsQuat.Length; i++ )
				{
					AnimationUtility.SetEditorCurve( clip, bindingsQuat[i], outCurvesQuat[i] );
				}
				for( int i = 0; i < bindingsPos.Length; i++ )
				{
					AnimationUtility.SetEditorCurve( clip, bindingsPos[i], outCurvesPos[i] );
				}
				Log( $"Done with {clip}" );
				NEXT_CLIP:
				continue;
			}
			AssetDatabase.SaveAssets();
		}
	}
}