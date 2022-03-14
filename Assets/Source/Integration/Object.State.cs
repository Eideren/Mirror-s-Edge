using System;
using System.Collections.Generic;

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

        bool RF_InEndState = false;
        bool RF_StateChanged = false;
        public void GotoState(name newStateName = default, name? label = null, bool? bForceEvents = false, bool? bKeepStack = false)
        {
	        /*// check to see if this object even supports states
			if (StateFrame == NULL) 
			{
				return GOTOSTATE_NotFound;
			}*/
	        
			// find the new state
			var newState = FindState(newStateName);
			
			//UState* StateNode = NULL;
			var OldStateName = _currentState.name;
			/*if (NewState != NAME_Auto) 
			{
				// Find regular state.
				StateNode = FindState( NewState );
			}
			else
			{
				// find the auto state.
		        // the script compiler marks the class itself as auto when no state is so we can skip the iterator
				if (!(GetClass()->StateFlags & STATE_Auto))
				{
					for (TFieldIterator<UState, CLASS_IsAUState> It(GetClass()); It && !StateNode; ++It)
					{
						if (It->StateFlags & STATE_Auto)
						{
							StateNode = *It;
						}
					}
				}
			}
			// if no state was found, then go to the default class state
			if (!StateNode) 
			{
				NewState  = NAME_None;
				StateNode = GetClass();
			}
			else
			if (NewState == NAME_Auto)
			{
				// going to auto state.
				NewState = StateNode->GetFName();
			}*/

			// Clear the nested state stack
			/*if( !bKeepStack )
			{
				// If we had a built up state stack
				if( StateFrame->StateNode != NULL &&
					StateFrame->StateStack.Num() )
				{
					// Pop all states
					PopState( TRUE );
				}
				else
				{
					// Otherwise, just empty the stack
					StateFrame->StateStack.Empty();
				}
			}*/

			// Send EndState notification.
			if (bForceEvents == true ||
				(OldStateName!=newStateName) )
			{
				if ( _currentState.end != null && !RF_InEndState )
				{
					RF_StateChanged = false;
					RF_InEndState = true;
					_currentState.end.Invoke(newStateName);//eventEndState(NewState);
					RF_InEndState = false;
					if( RF_StateChanged )
					{
						return;
					}
				}
			
				/*
				When changing states from within state code, the UDebugger must be notified about the state change
				in order to clear the debugger stack node that entered this state.  The PREVSTACK debugger opcode
				that would normally handle this will not be processed since it is part of the old state node's bytecode,
				which will not be processed after the state node is changed (AActor::ProcessState() would simply start
				processing the new state's bytecode).  By using the DI_PrevStackState opcode, the UDebugger will defer removal
				of the debugger stack node corresponding to this state if the debugger node is not currently the top node, such
				as when a state change happens inside a function called from state code.
				-- UDebugger */
				/*if ( GDebugger && StateFrame->Node == StateFrame->StateNode )
				{
					GDebugger->DebugInfo(this, StateFrame, DI_PrevStackState, 0, 0);
				}*/
			}

			// clear the previous latent action if any
			/*StateFrame->LatentAction = 0;
			// set the new state
			StateFrame->Node = StateNode;
			StateFrame->StateNode = StateNode;
			StateFrame->Code = NULL;
			StateFrame->ProbeMask = (StateNode->ProbeMask | GetClass()->ProbeMask) & StateNode->IgnoreMask;*/
			
			RestoreDefaultFunction();
			// https://wiki.beyondunreal.com/States :
			// It is possible for an actor to be in "no state" by using GotoState(). When an actor is in "no state", only its global (non-state) functions are called.
			if( newStateName == default )
				_currentControlFlow = Flow.Stop;
			else
				_currentControlFlow = new Flow();
			_currentState = (newStateName, newState.flow?.Invoke(label ?? default)?.GetEnumerator(), newState.begin, newState.end);
			
			// Send BeginState notification.
			if (bForceEvents == true ||
				(newStateName!=NAME_None &&
				 newStateName!=OldStateName &&
				 newState.begin != null))
			{
				RF_StateChanged = false;
				newState.begin(OldStateName);
				// check to see if a new state change was instigated
				if( RF_StateChanged ) 
				{
					return;
				}
			}
			// Return result.
			if( newStateName != NAME_None )
			{
				RF_StateChanged = true;
				return;
			}
			return;
        }
	
		public void ProcessState( float DeltaSeconds )
		{
			NativeMarkers.MarkUnimplemented("Does not reflect source but works well enough");
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
			/*if
			(	GetStateFrame()
			&&	GetStateFrame()->Code
			&&	(Role>=ROLE_Authority || (GetStateFrame()->StateNode->StateFlags & STATE_Simulated))
			&&	!IsPendingKill() )
			{
				// If a latent action is in progress, update it.
				if (GetStateFrame()->LatentAction != 0)
				{
					(this->*GNatives[GetStateFrame()->LatentAction])(*GetStateFrame(), (BYTE*)&DeltaSeconds);
				}

				if (GetStateFrame()->LatentAction == 0)
				{
					// Execute code.
					INT NumStates = 0;
					BYTE Buffer[MAX_SIMPLE_RETURN_VALUE_SIZE];
					// create a copy of the state frame to execute state code from so that if the state is changed from within the code, the executing frame's code pointer isn't modified while it's being used
					FStateFrame ExecStateFrame(*GetStateFrame());
					while (!bDeleteMe && ExecStateFrame.Code != NULL && GetStateFrame()->LatentAction == 0)
					{
						// remember old starting point (+1 for the about-to-be-executed byte so we can detect a state/label jump back to the same byte we're at now)
						BYTE* OldCode = ++GetStateFrame()->Code;

						ExecStateFrame.Step( this, Buffer ); 
						// if a state was pushed onto the stack, we need to correct the originally executing state's code pointer to reflect the code *after* the last state command was executed
						if (GetStateFrame()->StateStack.Num() > ExecStateFrame.StateStack.Num())
						{
							GetStateFrame()->StateStack(ExecStateFrame.StateStack.Num()).Code = ExecStateFrame.Code;
						}
						// if the state frame's code pointer was directly modified by a state or label change, we need to update our copy
						if (GetStateFrame()->Node != ExecStateFrame.Node)
						{
							// we have changed states
							if( ++NumStates > 4 )
							{
								//debugf(TEXT("%s pause going from state %s to %s"), *ExecStateFrame.StateNode->GetName(), *GetStateFrame()->StateNode->GetName());
								// shouldn't do any copying as the StateFrame was modified for the new state/label
								break;
							}
							else
							{
								//debugf(TEXT("%s went from state %s to %s"), *GetName(), *ExecStateFrame.StateNode->GetName(), *GetStateFrame()->StateNode->GetName());
								ExecStateFrame = *GetStateFrame();
							}
						}
						else if (GetStateFrame()->Code != OldCode)
						{
							// transitioned to a new label
							//debugf(TEXT("%s went to new label in state %s"), *GetName(), *GetStateFrame()->StateNode->GetName());
							ExecStateFrame = *GetStateFrame();
						}
						else
						{
							// otherwise, copy the new code pointer back to the original state frame
							GetStateFrame()->Code = ExecStateFrame.Code;
						}
					}
				}
			}*/
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
            if (stateName == "Auto" || stateName == "auto")
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
                if( _timeout <= delta )
                {
	                _timeout = 0f;
	                return;
                }
                _timeout -= delta;
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