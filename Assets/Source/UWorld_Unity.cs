namespace MEdge.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using Core;
    using Source;
    using TdGame;
    using UnityEngine.Events;
    using UnityEngine.SceneManagement;



    public partial class UWorld : UnityEngine.MonoBehaviour
	{
        static UnityAction<UnityEngine.SceneManagement.Scene, LoadSceneMode> _onSceneLoadedCached;
        static ConditionalWeakTable<Actor, IProcessor> _processors = new ConditionalWeakTable<Actor, IProcessor>();
        static UWorld _instance;
        
        SortedList<Actor, Actor> _actorsThisFrame = new SortedList<Actor, Actor>(new ActorTickComparer());
        /// <summary> The maximum amount of frames before an action is processed </summary>
        public static int MaxFramesForLowFreqUpdate = 10;
        public readonly List<Action> LowFrequencyUpdate = new();
        int _lowFreqIndx;



        public static void EnsureStart()
        {
            var v = Instance;
        }

        
        
        public static UWorld Instance
        {
            get
            {
                if( _instance != null && _instance.gameObject != null )
                {
                    _instance.transform.parent = null;
                    return _instance;
                }

                _instance = new UnityEngine.GameObject( nameof( UWorld ) ).AddComponent<UWorld>();
                DontDestroyOnLoad( _instance.gameObject );
                
                InitWorld();

                if(_onSceneLoadedCached != null)
                    SceneManager.sceneLoaded -= _onSceneLoadedCached;
                SceneManager.sceneLoaded += _onSceneLoadedCached = OnSceneLoaded;
                return _instance;
            }
        }



        static void OnSceneLoaded( UnityEngine.SceneManagement.Scene arg0, LoadSceneMode arg1 )
        {
            #warning not implemented yet
        }

        

        void LoadDataFromEngine( ICollection<(Actor, Core.Object.Vector, Core.Object.Rotator)> actors )
        {
            for( int i = 0; i < SceneManager.sceneCount; i++ )
            {
                var scene = SceneManager.GetSceneAt( i );
                foreach( var comp in 
                    from r in scene.GetRootGameObjects()
                    from c in r.GetComponentsInChildren<UnityEngine.Component>()
                    select c)
                {
                    if( comp is IUObject uObject )
                    {
                        if(uObject.GetUObject() is Actor a)
                            actors.Add(( a, comp.gameObject.transform.position.ToUnrealPos(), comp.gameObject.transform.rotation.ToUnrealRot() ) );
                    }
                }
            }
        }



        void OnDestroy()
        {
            var actors = WorldInfo._allActors;
            foreach( var actor in actors )
            {
                if( _processors.TryGetValue( actor, out IProcessor p ) )
                {
                    p?.OnDestroy();
                }
            }
        }

        

        void Update()
        {
            // Amount of iterations is at least one
            var actionsThisFrame = Math.Max( LowFrequencyUpdate.Count / MaxFramesForLowFreqUpdate, 1 );
            actionsThisFrame = Math.Min( LowFrequencyUpdate.Count, actionsThisFrame);
            for( int count = 0; count < actionsThisFrame; count++, _lowFreqIndx = (_lowFreqIndx+1) % LowFrequencyUpdate.Count )
            {
                LowFrequencyUpdate[_lowFreqIndx]();
            }
            
            
            // See UWorld::Tick
            
	        DecFn.CheckResult.Clear();

	        if(ReferenceEquals( this, _instance ) == false)
                Destroy(this);

            if( this.WorldInfo.TimeDilation != 1f )
                throw new NotImplementedException();
            //UnityEngine.Time.timeScale = this.WorldInfo.TimeDilation;
            var deltaTime = UnityEngine.Time.deltaTime;// * this._worldInfo.TimeDilation;
            deltaTime = deltaTime > 0.4f ? 0.4f : deltaTime < 0.0005f ? 0.0005f : deltaTime;
            this.WorldInfo.RealTimeSeconds = UnityEngine.Time.realtimeSinceStartup;
            this.WorldInfo.DeltaSeconds = deltaTime;
            this.WorldInfo.SavedDeltaSeconds = deltaTime; // no clue for this one
            this.WorldInfo.TimeSeconds += deltaTime;
            this.WorldInfo.AudioTimeSeconds += deltaTime;
            

            _actorsThisFrame.Clear();
            foreach( var actor in WorldInfo._allActors )
                _actorsThisFrame.Add(actor, actor);
            
            foreach( var actor in _actorsThisFrame.Values )
            {
                if( actor is PlayerController pc )
                {
                    #warning debug only
                    Input_Unity.SampleInput( pc.PlayerInput as TdPlayerInput, pc as TdPlayerController, deltaTime );
                }
            }

            TickActors(this, deltaTime, ELevelTick.LEVELTICK_All, _actorsThisFrame.Values);

            foreach( var actor in _actorsThisFrame.Values )
                actor.ConditionalUpdateComponents();

            foreach( var actor in _actorsThisFrame.Values )
            {
                if( actor is PlayerController PC && PC.PlayerCamera )
                {
                    PC.PlayerCamera.UpdateCamera(deltaTime);
                }
            }
            
            foreach( var actor in _actorsThisFrame.Values )
            {
                IProcessor p;
                if( _processors.TryGetValue( actor, out p ) == false )
                {
                    p = actor switch
                    {
                        TdPawn pawn => new PawnLink{ Pawn = pawn },
                        _ => null
                    };
                    
                    if( p != null )
                        _processors.Add( actor, p );
                }
                p?.Update(deltaTime);
            }

            UpdateMixes(deltaTime);
            
            _actorsThisFrame.Clear();
        }


        public Actor.Timer_del BuildCallableFunction(string name, object TimerObj)
        {
            // We should build something better here, quite unoptimized.
            var flags = BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic;
            if( TimerObj is Actor a && name == "Timer" )
            {
                return a.Timer;
            } 
            else if( TimerObj.GetType().GetProperty( name, flags ) is PropertyInfo p && p.GetValue( TimerObj ) is Delegate d )
            {
                return () => d.DynamicInvoke();
            }
            else if( TimerObj.GetType().GetMethod( name, flags ) is MethodInfo m )
            {
                return () => m.Invoke( TimerObj, null );
            }
            else
            {
                throw new Exception();
            }
        }



        static void LogWarning( string str ) => UnityEngine.Debug.LogWarning( str );
        static void Log( string str ) => UnityEngine.Debug.Log( str );
        static void LogError( string str ) => UnityEngine.Debug.LogError( str );
        
        
        
        class ActorTickComparer : IComparer<Actor>
        {
            public int Compare(Actor x, Actor y)
            {
                if(ReferenceEquals(x, y))
                    return 0;
		        
                int result = x.TickGroup.CompareTo(y.TickGroup);

                if (result == 0) // Same tickgroup, compare hashcode instead, possible equality but doesn't really matter
                    result = x.GetHashCode().CompareTo(y.GetHashCode());
		        
                return result;
            }
        }
	}
}