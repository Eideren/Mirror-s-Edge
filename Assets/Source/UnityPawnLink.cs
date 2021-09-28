namespace MEdge.Engine
{
    using System.Linq;
    using Core;
    using Source;
    using TdGame;
    using UnityEngine;
    using Object = MEdge.Core.Object;
    using static UnityEngine.Debug;



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
                ComputeVelocity_Stub(Pawn, deltaTime, Pawn.GroundSpeed, Pawn.PhysicsVolume.GroundFriction, 0, true );
                // Not exactly like this, depends on more stuff, but good approximation
                Pawn.Location += (Pawn.Velocity + Pawn.PhysicsVolume.ZoneVelocity * 25f) * deltaTime;

                if( _1pPlayer == null )
                {
                    // Shouldn't have to do this here, source has some other system making sure it is set
                    Pawn.Mesh1pLowerBody.Owner = Pawn.Mesh1p.Owner = Pawn;
                    var clips = Resources.LoadAll<AnimationClip>( "Animations/AS_C1P_Unarmed/" );
                    
                    Asset.UScriptToUnity.TryGetValue( Pawn.Mesh1p.SkeletalMesh, out var fpMesh );
                    var fpUpper = (SkinnedMeshRenderer) fpMesh;
                    Asset.UScriptToUnity.TryGetValue( Pawn.Mesh1pLowerBody.SkeletalMesh, out var unityObjectLower );
                    _1pLower = (SkinnedMeshRenderer)unityObjectLower;
                    
                    _1pPlayer = new AnimationPlayer( clips, Asset.Get_AS_C1P_Unarmed(), Pawn.Mesh1p.Animations, fpUpper.transform.parent.gameObject, Pawn, Pawn.Mesh1p );
                    
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
                    var clips = Resources.LoadAll<AnimationClip>( "Animations/AS_F3P_Unarmed/" );
                    Asset.UScriptToUnity.TryGetValue( Pawn.Mesh3p.SkeletalMesh, out var unityObject );
                    Pawn.Mesh3p.Owner = Pawn; // Shouldn't have to do this here, source has some other system making sure it is set
                    _3pPlayer = new AnimationPlayer( clips, Asset.Get_AS_F3P_Unarmed(), Pawn.Mesh3p.Animations, ((SkinnedMeshRenderer)unityObject).transform.parent.gameObject, Pawn, Pawn.Mesh3p );
                    // Disable rendering for now, let's focus on 1P first
                    ( (SkinnedMeshRenderer)unityObject ).enabled = false;
                    /*_window = AnimNodeEditor.AnimNodeEditorWindow.CreateInstance<AnimNodeEditor.AnimNodeEditorWindow>();
                    _window.LoadFromNode( Pawn.Mesh1p.Animations );
                    _window.Show();*/
                }

                _3pPlayer.Sample( deltaTime );
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

                    ( Pawn.Controller as PlayerController ).SpawnPlayerCamera();
                }

                if( ( Pawn.Controller as PlayerController ).PlayerCamera is Camera cam )
                {
                    cam.UpdateCamera(deltaTime);
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
                    string appendedMessage = "Native unimplemented calls:\n" + string.Join( "\n", NativeMarkers.Marked.Select( x => $"{x.FilePath} - {x.Member}:{x.Line}" ).OrderBy( x => x ) );
                    LogError(appendedMessage);
                }
                {
                    string appendedMessage = $"{nameof(LoadAsset)} unimplemented for:\n" + string.Join( "\n", Asset.NotImplementedFor.OrderBy( x => x ) );
                    LogError(appendedMessage);
                }
            }




            void ComputeVelocity_Stub( TdPawn p, float likelyTimeDelta, float mod_param_speed, float param_friction, int param_bStdDeceleration, bool bFixedTimeDeceleration )
            {
                var mod_currentMove__PawnMobility = p.GetMobilityMultiplier() * ( p.Moves[ (int) p.MovementState ]?.SpeedModifier ?? 1f );
                var mod_currentMove__PawnMobility__paramSpeed = mod_currentMove__PawnMobility * mod_param_speed;
                if ( bFixedTimeDeceleration && p.Acceleration.X == 0.0 && p.Acceleration.Y == 0.0 && p.Acceleration.Z == 0.0 )
                {                                       // 
                                                        // deceleration == true && acceleration == 0
                                                        // 
                    var remainingTime = likelyTimeDelta;    // Apply deceleration logic, also runs when idle
                    var velocityBeforeDeceleration = p.Velocity;
                    var velocityAfterDeceleration = new Object.Vector();
                    if ( likelyTimeDelta > 0.0 )
                    {
                        var brakingFrictionStrength = p.BrakingFrictionStrength;
                        while ( true )
                        {                               // 
                                                        // Every loop reduce by 0.0299999 until 'loop*0.0299999' >= 'someVectorMult' at which point reduce by the rest and stop loop
                                                        // This might be because decelerating using just the deltatime might diverge widely based on the deltatime value
                                                        // 
                            var timeSlice = 0.029999999f;
                            if ( remainingTime <= 0.029999999f )
                                timeSlice = remainingTime;// 
                                                        // Take the minimum between 0.0299... and remainingTime
                                                        // 
                            var tempVelY2 = p.Velocity.Y;
                            var reductionLeft = remainingTime - timeSlice;// 
                                                        // 
                                                        // 
                            var tempVelX = (float)((float)((float)(p.Velocity.X * 2.0) * timeSlice) * param_friction) * brakingFrictionStrength;
                            var miscUtility3Float = (float)((float)((float)(p.Velocity.Z * 2.0) * timeSlice) * param_friction) * brakingFrictionStrength;
                            var tempVelY = p.Velocity.Y - (float)((float)((float)((float)(tempVelY2 * 2.0) * timeSlice) * param_friction) * brakingFrictionStrength);
                            var tempVelZ2 = p.Velocity.Z - miscUtility3Float;
                            p.Velocity.X = p.Velocity.X - tempVelX;
                            p.Velocity.Y = tempVelY;
                            p.Velocity.Z = tempVelZ2;// 
                                                        // 
                                                        // p.Velocity -= p.Velocity * 2.0 * timeSlice * anotherVectorMult * brakingFrictionStrength
                                                        // 
                                                        // 
                            if ( (float)((float)((float)(p.Velocity.Y * velocityBeforeDeceleration.Y) + (float)(p.Velocity.Z * velocityBeforeDeceleration.Z)) + (float)(p.Velocity.X * velocityBeforeDeceleration.X)) > 0.0 )
                            {                           // 
                                                        // That's a dot comp, if previous velocity and current are in the same direction:
                                var scaledVelZ = 0.0;
                                velocityAfterDeceleration.X = (float)((float)(p.Velocity.X * timeSlice) * (float)(1.0 / likelyTimeDelta)) + velocityAfterDeceleration.X;
                                velocityAfterDeceleration.Y = (float)((float)(p.Velocity.Y * timeSlice) * (float)(1.0 / likelyTimeDelta)) + velocityAfterDeceleration.Y;
                                velocityAfterDeceleration.Z = (float)((float)(p.Velocity.Z * timeSlice) * (float)(1.0 / likelyTimeDelta)) + velocityAfterDeceleration.Z;// 
                                                        // velocityAfterDeceleration += (p.Velocity * timeSlice) * (1.0 / likelyTimeDelta);
                                                        // 
                            }
                            if ( reductionLeft <= 0.0 )
                                break;
                            remainingTime = reductionLeft;
                        }
                    }
                    p.Velocity = velocityAfterDeceleration;
                    if ( (float)((float)((float)(p.Velocity.Y * velocityBeforeDeceleration.Y) + (float)(p.Velocity.Z * velocityBeforeDeceleration.Z)) + (float)(p.Velocity.X * velocityBeforeDeceleration.X)) < 0.0
                      || (float)((float)((float)(p.Velocity.X * p.Velocity.X) + (float)(p.Velocity.Y * p.Velocity.Y)) + (float)(p.Velocity.Z * p.Velocity.Z)) < 100.0 )
                    {                                   // 
                                                        // velocity flipped direction or is lower than 100
                                                        // => set velocity to zero
                        p.Velocity.X = 0.0f;
                        p.Velocity.Y = 0.0f;
                        p.Velocity.Z = 0.0f;
                    }
                }
                p.Velocity *= 1.0f - (param_bStdDeceleration * likelyTimeDelta * param_friction);
                p.Velocity += p.Acceleration * likelyTimeDelta;
                if( (float) ( (float) ( (float) ( p.Velocity.X * p.Velocity.X ) + (float) ( p.Velocity.Y * p.Velocity.Y ) ) + (float) ( p.Velocity.Z * p.Velocity.Z ) ) > (float) ( mod_currentMove__PawnMobility__paramSpeed * mod_currentMove__PawnMobility__paramSpeed ) )
                {
                    p.Velocity = p.Velocity.SafeNormal() * mod_currentMove__PawnMobility__paramSpeed;
                }
            }
        }
	}
}