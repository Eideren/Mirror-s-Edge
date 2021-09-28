using System;
using System.Collections.Generic;



namespace MEdge.Engine
{
    public partial class Actor
    {
	    public /*event */void Actor_Tick(float DeltaSeconds)
	    {
            // From AActor::TickAuthoritative
            _scheduledStateSwap?.Invoke();
            _scheduledStateSwap = null;
            try
            {
                _insideStateStack = true;
                _currentControlFlow.Delta(DeltaSeconds);
                TryTickState();
            }
            finally
            {
                _insideStateStack = false;
            }
            
            UpdateTimers( DeltaSeconds );
	    }
    }
}



namespace MEdge.Core
{
    public partial class Object
    {
        protected (name name, IEnumerator<Flow> flow, Action<name> begin, Action<name> end) _currentState;
        protected Flow _currentControlFlow;
        protected Action _scheduledStateSwap;
        protected bool _insideStateStack;
        
        
        // Export UObject::execGetStateName(FFrame&, void* const)
        public virtual /*native(284) final function */ name GetStateName() => _currentState.name;
        
        protected virtual void RestoreDefaultFunction(){}

        public void GotoState(name newStateName = default, name? label = null, bool? bForceEvents = null, bool? bKeepStack = null)
        {
            /*
https://wiki.beyondunreal.com/States :

When you use the GotoState command to set an actor's state, the engine can call two special notification functions, if you have defined them: EndState() and BeginState(). 
EndState is called in the current state immediately before the new state is begun, and BeginState is called immediately after the new state begins. [...]

States are executed during an actors tick, [...].
While EndState() and BeginState() execution might happen straight away,
UnrealScript state changes from calls to GotoState('NewStateName') will only take effect once an actor has been Ticked.

Note the fact that the wiki is contradictory here:
> BeginState is called immediately after the new state begins
So StateBegins -> BeginState()
> While EndState() and BeginState() execution might happen straight away, UnrealScript state changes from calls to GotoState('NewStateName') will only take effect once an actor has been Ticked.
But here it says BeginState() -> StateChanges (which is StateBegins right ?) ???

So here's how I'll set this up:
Wait for next tick / execute right away if inside state
var previousState = state
EndState(newState)
state = newState // here we replace both the name and IEnumerator
BeginState(previousState)
... let execution into new state

because it makes the most sense given that BeginState and EndState requires previous and next state names, either one wouldn't need it if the name changes happened in a different order
             */
            
            
            
            var newState = FindState(newStateName);

            if (_insideStateStack)
            {
                SwapState();
                TryTickState();
            }
            else
            {
                _scheduledStateSwap = SwapState;
            }

            void SwapState()
            {
                var previousState = _currentState;
                try
                {
                    previousState.end?.Invoke(newStateName);
                }
                finally
                {
                    RestoreDefaultFunction();
                    // https://wiki.beyondunreal.com/States :
                    // It is possible for an actor to be in "no state" by using GotoState(). When an actor is in "no state", only its global (non-state) functions are called.
                    if (string.IsNullOrWhiteSpace(newStateName))
                        _currentControlFlow = Flow.Stop;
                    _currentState = (newStateName, newState.flow?.Invoke(label ?? default)?.GetEnumerator(), newState.begin, newState.end);
                
                    newState.begin?.Invoke(_currentState.name);
                }
            }
        }

        protected void TryTickState()
        {
            if (_currentControlFlow.CanContinue)
            {
                _currentState.flow?.MoveNext();
                _currentControlFlow = _currentState.flow?.Current ?? default;
            }
        }
        
        public delegate void BeginState_del(name PreviousStateName);
        public virtual BeginState_del BeginState => ( _currentState.begin != null ? new BeginState_del(n => _currentState.begin( n )) : Object_EndState );
        public virtual BeginState_del global_BeginState => Object_BeginState;
        public  /*event */void Object_BeginState(name PreviousStateName) {}
	
        public delegate void EndState_del(name NextStateName);
        public virtual EndState_del EndState => ( _currentState.end != null ? new EndState_del(n => _currentState.end( n )) : Object_EndState );
        public virtual EndState_del global_EndState => Object_EndState;
        public  /*event */void Object_EndState(name NextStateName) {}
        

        protected virtual (System.Action<name> begin, StateFlow flow, System.Action<name> end) FindState(name stateName)
        {
            // https://wiki.beyondunreal.com/States :
            // It is possible for an actor to be in "no state" by using GotoState(). When an actor is in "no state", only its global (non-state) functions are called.
            if (string.IsNullOrWhiteSpace(stateName.Value))
                return (null, null, null);
            if (stateName.Value == "Auto" || stateName.Value == "auto")
                return GetAutoState();
            throw new ArgumentException($"Unknown state:'{stateName}'");
        }

        protected virtual (System.Action<name> begin, StateFlow flow, System.Action<name> end) GetAutoState() => (null, null, null);

        public struct Flow
        {
            float _timeout;
            public bool CanContinue => _timeout <= 0f;

            public void Delta(float delta)
            {
                if(float.IsPositiveInfinity(_timeout))
                    return;
                _timeout -= delta;
                if (_timeout < 0f)
                    _timeout = 0f;
            }

            /// <summary>
            /// State code execution doesn't continue until you go to a new state, or go to a new label within the current state.
            /// </summary>
            public static Flow Stop => new Flow() {_timeout = float.PositiveInfinity};
            public static Flow Sleep(float timeout) => new Flow() {_timeout = timeout};
        }

        public bool IsInState(String state, bool? bTestStateStack = default)
        {
            if (bTestStateStack != default)
                throw new ArgumentException( $"{nameof(bTestStateStack)} is not implemented" );
            return _currentState.name.ToString() == state;
        }

        public delegate System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo);
    }
}