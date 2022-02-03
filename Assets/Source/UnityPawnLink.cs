namespace MEdge.Engine
{
    using System.Linq;
    using Core;
    using Source;
    using TdGame;
    using UnityEngine;
    using Object = MEdge.Core.Object;
    using static UnityEngine.Debug;
    using Component = UnityEngine.Component;



    public partial class UWorld
	{
        class PawnLink : IProcessor
        {
            public TdPawn Pawn;
            AnimationPlayer _1pPlayer, _3pPlayer;
            SkinnedMeshRenderer _1pLower;
            AnimNodeEditor.AnimNodeEditorWindow _window;
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
                    var fpUpper = (SkinnedMeshRenderer) fpMesh;
                    Asset.UScriptToUnity.TryGetValue( Pawn.Mesh1pLowerBody.SkeletalMesh, out var unityObjectLower );
                    _1pLower = (SkinnedMeshRenderer)unityObjectLower;
                    
                    _1pPlayer = new AnimationPlayer(Pawn.Mesh1p, 
                        Resources.LoadAll<AnimationClip>( "Animations/AS_C1P_Unarmed/" ), 
                        Asset.Get_AS_C1P_Unarmed(),  
                        fpUpper.transform.parent.gameObject );
                    
                    // Merge lower skinned mesh to the same hierarchy as upper
                    var oldParent = _1pLower.transform.parent;
                    _1pLower.transform.parent = fpUpper.transform.parent;
                    _1pLower.rootBone = _1pPlayer.Bones[ _1pPlayer.NameToIndex[ _1pLower.rootBone.name ] ];
                    var tempBones = _1pLower.bones;
                    for( int i = 0; i < tempBones.Length; i++ )
                    {
                        tempBones[ i ] = _1pPlayer.Bones[ _1pPlayer.NameToIndex[ tempBones[i].name ] ];
                    }
                    _1pLower.bones = tempBones;
                    Destroy(oldParent.gameObject);
                    
                    _window = AnimNodeEditor.AnimNodeEditorWindow.CreateInstance<AnimNodeEditor.AnimNodeEditorWindow>();
                    _window.LoadFromNode( Pawn.Mesh1p.Animations );
                    _window.Show();
                }

                if( _3pPlayer == null )
                {
                    // We don't need the preview mesh
                    Asset.UScriptToUnity.TryGetValue( (Pawn.Mesh3p.Animations as AnimTree)?.PreviewSkelMesh, out var previewMesh );
                    Destroy(((Component)previewMesh).transform.parent.gameObject);
                    
                    var clips = Resources.LoadAll<AnimationClip>( "Animations/AS_F3P_Unarmed/" );
                    Asset.UScriptToUnity.TryGetValue( Pawn.Mesh3p.SkeletalMesh, out var tracker );
                    Pawn.Mesh3p.Owner = Pawn; // Shouldn't have to do this here, source has some other system making sure it is set
                    _3pPlayer = new AnimationPlayer( Pawn.Mesh3p, clips, Asset.Get_AS_F3P_Unarmed(), ((SkinnedMeshRenderer)tracker).transform.parent.gameObject );
                    // Disable rendering for now, let's focus on 1P first
                    ( (SkinnedMeshRenderer)tracker ).enabled = false;
                }

                //_3pPlayer.Sample( deltaTime );
                _1pPlayer.Sample( deltaTime );
                var (pos, rot) = ( Pawn.Location.ToUnityPos(), (Quaternion)Pawn.Rotation );
                _1pPlayer.GameObject.transform.SetPositionAndRotation( pos, rot );
                _3pPlayer.GameObject.transform.SetPositionAndRotation( pos, rot );
                
                if( _unityCam == null )
                {
                    _unityCam = UnityEngine.Camera.main;
                    if( _unityCam == null )
                    {
                        GameObject camGo = new GameObject();
                        _unityCam = camGo.AddComponent<UnityEngine.Camera>();
                    }

                    _unityCam.fieldOfView = 59f;// 90 horizontal is around this value vertical for 16/9
                }

                if( ( Pawn.Controller as PlayerController ).PlayerCamera is Camera cam )
                {
                    //cam.UpdateCamera(deltaTime);
                    var camPov = cam.CameraCache.POV;
                    _unityCam.transform.SetPositionAndRotation( camPov.Location.ToUnityPos(), (Quaternion)camPov.Rotation );
                    #warning probably switch things around to ensure camera doesn't lag one frame behind animation
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
        }
	}
}