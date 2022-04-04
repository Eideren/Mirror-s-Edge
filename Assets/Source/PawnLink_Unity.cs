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
            Vector3 _lastPos;
            Quaternion _lastRot;



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

                    var uol = _1pPlayer.AddComponent<UnrealObjectLink>();
                    uol.Object = Pawn;
                    
                    _lastPos = _1pPlayer.transform.position;
                    _lastRot = _1pPlayer.transform.rotation;
                }

                if( _3pPlayer == null )
                {
                    // We don't need the preview mesh
                    Asset.UScriptToUnity.TryGetValue( (Pawn.Mesh3p.Animations as AnimTree)?.PreviewSkelMesh, out var previewMesh );
                    try
                    {
	                    Destroy( ( (Component) previewMesh ).transform.parent.gameObject );
                    }
                    catch(System.Exception)
                    {
	                    System.Diagnostics.Debugger.Break();
                    }

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
                    
                    var uol = _3pPlayer.AddComponent<UnrealObjectLink>();
                    uol.Object = Pawn;
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


                var unityTransform = _1pPlayer.transform;
                if( _lastPos != unityTransform.position || _lastRot != unityTransform.rotation )
                {
	                DecFn.CheckResult _chck = new DecFn.CheckResult();
	                UWorldBridge.GetUWorld().MoveActor( Pawn, (unityTransform.position - _lastPos).ToUnrealPos(), unityTransform.rotation.ToUnrealRot(), 0, ref _chck );
                }

                var basePos = Pawn.Location;
                var baseRot = Pawn.Rotation;
                
                _1pPlayer.transform.SetPositionAndRotation( basePos.ToUnityPos(), baseRot.ToUnityQuat() );
                _3pPlayer.transform.SetPositionAndRotation( basePos.ToUnityPos(), baseRot.ToUnityQuat() );

                _lastPos = _1pPlayer.transform.position;
                _lastRot = _1pPlayer.transform.rotation;


                for( int i = 0; i < Pawn.Mesh1p.LocalAtoms.Length; i++ )
                {
	                ref var atom = ref Pawn.Mesh1p.LocalAtoms[i];
	                _1pBones[i].localPosition = atom.Translation.ToUnityAnim();
	                _1pBones[i].localRotation = atom.Rotation.ToUnityAnim();
	                _1pBones[i].localScale = Vector3.one * atom.Scale;
                }
                
                for( int i = 1; i < Pawn.Mesh3p.LocalAtoms.Length; i++ )
                {
	                ref var atom = ref Pawn.Mesh3p.LocalAtoms[i];
	                _3pBones[i].localPosition = atom.Translation.ToUnityAnim().LogAndZeroNaN();
	                _3pBones[i].localRotation = atom.Rotation.ToUnityAnim().LogAndZeroNaN();
	                _3pBones[i].localScale = Vector3.one * atom.Scale;
                }
                
                // Skeleton has a base offset inside of their owner, just makes sure it's taken care of here
                _1pBones[ 0 ].position = Pawn.Mesh1p.GetBoneLocation(_1pBones[ 0 ].name).ToUnityPos();
                _3pBones[ 0 ].position = Pawn.Mesh3p.GetBoneLocation(_3pBones[ 0 ].name).ToUnityPos();
                
                if( _unityCam == null )
                {
                    _unityCam = UnityEngine.Camera.main;
                    if( _unityCam == null )
                    {
                        GameObject camGo = new GameObject();
                        _unityCam = camGo.AddComponent<UnityEngine.Camera>();
                        camGo.AddComponent<AudioListener>();
                    }
                    else
                    {
	                    Log($"Hijacking main camera '{_unityCam.name}' to use for player character");
                    }

                    _unityCam.nearClipPlane = _unityCam.nearClipPlane > 0.1f ? 0.1f : _unityCam.nearClipPlane;
                    _unityCam.fieldOfView = 59f;// 90 horizontal is around this value vertical for 16/9
                }

                if( ( Pawn.Controller as PlayerController ).PlayerCamera is Camera cam )
                {
                    var camPov = cam.CameraCache.POV;
                    _unityCam.transform.SetPositionAndRotation( camPov.Location.ToUnityPos(), camPov.Rotation.ToUnityQuat() );
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