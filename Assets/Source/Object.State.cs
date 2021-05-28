using System;
using System.Collections.Generic;

namespace MEdge.Core
{
    public partial class Object
    {
        (name name, IEnumerator<Flow> flow, Action<name> end) _currentState;
        Flow _currentControlFlow;
        Action _scheduledStateSwap;
        bool _insideStateStack;
        
        
        // Export UObject::execGetStateName(FFrame&, void* const)
        public virtual /*native(284) final function */ name GetStateName() => _currentState.name;
        
        protected virtual void RestoreDefaultFunction(){}

        protected void Tick(float deltaTime)
        {
            #error verify that this is how it works
            #error link this with game engine
            _scheduledStateSwap?.Invoke();
            _scheduledStateSwap = null;
            try
            {
                _insideStateStack = true;
                _currentControlFlow.Delta(deltaTime);
                TryTickState();
            }
            finally
            {
                _insideStateStack = false;
            }
        }

        void TryTickState()
        {
            if (_currentControlFlow.CanContinue)
            {
                _currentState.flow?.MoveNext();
                _currentControlFlow = _currentState.flow?.Current ?? default;
            }
        }

        public void GotoState(name newStateName = default, name label = null, bool bForceEvents = false, bool bKeepStack = false)
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
                    _currentState = (newStateName, newState.flow(label).GetEnumerator(), newState.end);
                
                    newState.begin?.Invoke(_currentState.name);
                }
            }
        }

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

        public bool IsInState(string state, bool bTestStateStack = default)
        {
            if (bTestStateStack != default)
                throw new ArgumentException( $"{nameof(bTestStateStack)} is not implemented" );
            return _currentState.name == state;
        }

        public delegate System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo);
    }
}