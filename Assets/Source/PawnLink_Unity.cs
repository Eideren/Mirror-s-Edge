namespace MEdge.Engine
{
	using System.Linq;
	using Core;
    using Source;
    using TdGame;
	using UnityEngine;
    using Component = UnityEngine.Component;



	public partial class UWorld
	{
        class PawnLink : IProcessor
        {
            public TdPawn Pawn;
            GameObject _1pPlayer, _3pPlayer;
            Transform[] _1pBones, _3pBones;
            SkinnedMeshRenderer _1pLower;
            IAnimNodeEditorWindow _window;
            UnityEngine.Camera _unityCam;



            public void Update(float deltaTime)
            {
                if( _1pPlayer == null )
                {
                    // We don't need the preview mesh
                    Asset.UScriptToUnity.TryGetValue( (Pawn.Mesh1p.Animations as AnimTree)?.PreviewSkelMesh, out var previewMesh );
                    Destroy(((Component)previewMesh).transform.parent.gameObject);
                    
                    
                    // Shouldn't have to do this here, source has some other system making sure it is set
                    Pawn.Mesh1pLowerBody.Owner = Pawn.Mesh1p.Owner = Pawn;
                    
                    Asset.UScriptToUnity.TryGetValue( Pawn.Mesh1p.SkeletalMesh, out var fpMesh );
                    Asset.UScriptToUnity.TryGetValue( Pawn.Mesh1pLowerBody.SkeletalMesh, out var unityObjectLower );
                    
                    var fpUpper = (SkinnedMeshRenderer) fpMesh;
                    _1pLower = (SkinnedMeshRenderer)unityObjectLower;
                    
                    _1pPlayer = fpUpper.transform.parent.gameObject;
                    var clips = Resources.LoadAll<AnimationClip>( "Animations/AS_C1P_Unarmed/" );
                    
                    var gameObject = Instantiate( _1pPlayer );
                    gameObject.SetActive(false);
                    gameObject.name = "AnimTarget1P";
                    // Cleanup hierarchy
                    foreach( Component comp in gameObject.GetComponentsInChildren<Component>() )
                    {
	                    if(comp is Transform == false)
		                    UnityEngine.Object.Destroy(comp);
                    }
                    foreach( var set in Pawn.Mesh1p.AnimSets )
                    {
	                    if(set!=null)
		                    FixRefsForAnimation( clips, set, gameObject );
                    }

                    var hs = Pawn.Mesh1p.AnimSets[ 0 ].TrackBoneNames.ToHashSet();
                    // Merge lower skinned mesh to the same hierarchy as upper
                    var nameToBones = _1pPlayer.GetComponentsInChildren<Transform>().Where( x => hs.Contains(x.name) ).ToDictionary( t => (name)t.name );
                    var oldParent = _1pLower.transform.parent;
                    _1pLower.transform.parent = fpUpper.transform.parent;
                    _1pLower.rootBone = nameToBones[ _1pLower.rootBone.name ];
                    _1pLower.bones = _1pLower.bones.Select( t => nameToBones[t.name] ).ToArray();
                    Destroy(oldParent.gameObject);
                    
                    _1pBones = Pawn.Mesh1p.AnimSets[0].TrackBoneNames.Select( n => nameToBones[ n ] ).ToArray();
                }

                if( _3pPlayer == null )
                {
                    // We don't need the preview mesh
                    Asset.UScriptToUnity.TryGetValue( (Pawn.Mesh3p.Animations as AnimTree)?.PreviewSkelMesh, out var previewMesh );
                    Destroy(((Component)previewMesh).transform.parent.gameObject);
                    
                    var clips = Resources.LoadAll<AnimationClip>( "Animations/AS_F3P_Unarmed/" );
                    Asset.UScriptToUnity.TryGetValue( Pawn.Mesh3p.SkeletalMesh, out var tracker );
                    Pawn.Mesh3p.Owner = Pawn; // Shouldn't have to do this here, source has some other system making sure it is set
                    _3pPlayer = ( (SkinnedMeshRenderer) tracker ).transform.parent.gameObject;
                    
                    var gameObject = Instantiate( _3pPlayer );
                    gameObject.SetActive(false);
                    gameObject.name = "AnimTarget3P";
                    // Cleanup hierarchy
                    foreach( Component comp in gameObject.GetComponentsInChildren<Component>() )
                    {
	                    if(comp is Transform == false)
		                    UnityEngine.Object.Destroy(comp);
                    }
                    
                    foreach( var set in Pawn.Mesh3p.AnimSets )
                    {
	                    if(set!=null)
							FixRefsForAnimation( clips, set, gameObject );
	                }
	                
                    var hs = Pawn.Mesh3p.AnimSets[ 0 ].TrackBoneNames.ToHashSet();
	                var nameToBones = _3pPlayer.GetComponentsInChildren<Transform>().Where( x => hs.Contains(x.name) ).ToDictionary( t => (name)t.name );
	                _3pBones = Pawn.Mesh3p.AnimSets[0].TrackBoneNames.Select( n => nameToBones[ n ] ).ToArray();
	                
                    // Disable rendering for now, let's focus on 1P first
                    ( (SkinnedMeshRenderer)tracker ).enabled = false;
                }

                if( UnityEngine.Input.GetKey( KeyCode.M ) )
                {
	                try
	                {
		                _window?.Close();
		                _window = null;
		                _window = ScriptableObject.CreateInstance(("AnimNodeEditorWindow")/*Type.GetType("MEdge.AnimNodeEditor.AnimNodeEditorWindow")*/) as IAnimNodeEditorWindow;
		                _window.LoadFromNode( Pawn.Mesh1p.Animations );
		                _window.Show();
	                }
	                catch( System.Exception e )
	                {
		                Debug.LogException(e);
	                }
                }

                var basePos = Pawn.Location;
                var baseRot = Pawn.Rotation;
                _1pPlayer.transform.SetPositionAndRotation( (basePos + Pawn.Mesh1p.Translation).ToUnityPos(), (baseRot + Pawn.Mesh1p.Rotation).ToUnityQuat() );
                _3pPlayer.transform.SetPositionAndRotation( (basePos + Pawn.Mesh3p.Translation).ToUnityPos(), (baseRot + Pawn.Mesh3p.Rotation).ToUnityQuat() );

                for( int i = 0; i < Pawn.Mesh1p.LocalAtoms.Length; i++ )
                {
	                ref var atom = ref Pawn.Mesh1p.LocalAtoms[i];
	                // Temporary as world to ensure that transformation differences between unity and unreal are properly dealt with
	                _1pBones[i].position = Pawn.Mesh1p.GetBoneLocation(_1pBones[i].gameObject.name, 0).ToUnityPos();
	                _1pBones[i].rotation = Pawn.Mesh1p.GetBoneQuaternion(_1pBones[i].gameObject.name, 0).ToUnity();
	                
	                //_1pBones[i].localRotation = atom.Rotation.ToUnity();
	                //_1pBones[i].localPosition = atom.Translation.ToUnityPos();
	                _1pBones[i].localScale = Vector3.one * atom.Scale;
                }
                
                for( int i = 0; i < Pawn.Mesh3p.LocalAtoms.Length; i++ )
                {
	                ref var atom = ref Pawn.Mesh3p.LocalAtoms[i];
	                _3pBones[i].localPosition = atom.Translation.ToUnityPos();
	                _3pBones[i].localRotation = atom.Rotation.ToUnity();
	                _3pBones[i].localScale = Vector3.one * atom.Scale;
                }
                
                if( _unityCam == null )
                {
                    _unityCam = UnityEngine.Camera.main;
                    if( _unityCam == null )
                    {
                        GameObject camGo = new GameObject();
                        _unityCam = camGo.AddComponent<UnityEngine.Camera>();
                    }
                    else
                    {
	                    Log($"Hijacking main camera '{_unityCam.name}' to use for player character");
                    }

                    _unityCam.fieldOfView = 59f;// 90 horizontal is around this value vertical for 16/9
                }

                if( ( Pawn.Controller as PlayerController ).PlayerCamera is Camera cam )
                {
	                cam.UpdateCamera(deltaTime);
                    var camPov = cam.CameraCache.POV;
                    _unityCam.transform.SetPositionAndRotation( camPov.Location.ToUnityPos(), camPov.Rotation.ToUnityQuat() * Quaternion.Euler(90f, 0f, 0f)/* Not too sure why we need to change this, perhaps unreal cameras points downwards by default instead of horizontally ? */ );
                }
            }



            public void OnDestroy()
            {
                _window?.Close();
                _window = null;
                PrintUnimplementedDebug();
            }



            public void PrintUnimplementedDebug()
            {
                {
                    var baseString = NativeMarkers.Marked.FirstOrDefault().FilePath;
                    int prefixLength = baseString?.Length ?? 0;
                    foreach( var data in NativeMarkers.Marked )
                    {
                        var comp = data.FilePath;
                        if( comp.Length < prefixLength )
                            prefixLength = comp.Length;

                        for( int i = 0; i < prefixLength; i++ )
                        {
                            if( comp[ i ] != baseString[ i ] )
                                prefixLength = i;
                        }

                        if( prefixLength == 0 )
                            break;
                    }

                    var formattedMarkers = from data in NativeMarkers.Marked
                        select ( data, str:$"{data.FilePath.Remove( 0, prefixLength )}:{data.Line} - {data.Member} {( data.Description != null ? $"- {data.Description}" : "" )}" );
                    
                    string appendedMessage = "Native unimplemented calls:\n" + string.Join( "\n", from marker in formattedMarkers orderby marker.data.Description != null, marker.str select marker.str );
                    LogError(appendedMessage);
                }
                {
                    string appendedMessage = $"{nameof(LoadAsset)} unimplemented for:\n" + string.Join( "\n", Asset.NotImplementedFor.OrderBy( x => x ) );
                    LogError(appendedMessage);
                }
            }



            static void FixRefsForAnimation(AnimationClip[] clips, AnimSet animSet, GameObject gameObject)
            {
	            if(animSet.Sequences.Count == 0)
		            return;
	            
	            var nameToClip = clips.ToDictionary( x => (name)x.name, x => x );
	            var boneHashSet = animSet.TrackBoneNames.ToHashSet();
	            var nameToTransforms = gameObject.GetComponentsInChildren<Transform>().Where( x => boneHashSet.Contains(x.name) ).ToDictionary( x => (name)x.name );
	            var bones = animSet.TrackBoneNames.Select( name => nameToTransforms[ name ] ).ToArray();

	            foreach( AnimSequence sequence in animSet.Sequences )
	            {
		            if( nameToClip.TryGetValue( sequence.SequenceName, out var clip ) == false )
		            {
			            LogError($"Could not find sequence {sequence.SequenceName} in provided clips");
			            continue;
		            }

		            sequence._unityBones = bones;
		            sequence._unityClipTarget = gameObject;
		            sequence._unityClip = clip;
					
		            clip.wrapMode = WrapMode.Default;
		            clip.SampleAnimation( gameObject, 0f );
		            sequence._unityPoses.start = bones.Select( bone => new AnimNode.BoneAtom( bone.localRotation.ToUnrealAnim(), bone.localPosition.ToUnrealAnim(), 1f ) ).ToArray();
					
		            clip.SampleAnimation( gameObject, clip.length );
		            sequence._unityPoses.end = bones.Select( bone => new AnimNode.BoneAtom( bone.localRotation.ToUnrealAnim(), bone.localPosition.ToUnrealAnim(), 1f ) ).ToArray();
	            }
            }


        }
	}
}