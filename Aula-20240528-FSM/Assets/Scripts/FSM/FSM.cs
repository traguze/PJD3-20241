using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace FSM {
  public class FSM : MonoBehaviour
  {
    protected State currentState;
    protected FsmAgent fsmAgent;

    protected string nextState;

    protected Dictionary<string, State> states = new Dictionary<string, State>();


    public void SetFsmAgent(FsmAgent fsmAgent) {
      this.fsmAgent = fsmAgent;
    }

    public void RegisterState(State state) {
      states.Add(state.Name, state);
      state.SetChangeState(ChangeState);
    }

    public void StartFSM(string name) {
      currentState = states[name];
      currentState.Phase = StatePhase.Enter;
    }

    protected void ChangeState(string name) {
      if(currentState != null) {
        currentState.Phase = StatePhase.Exit;
        nextState = name;
      }
    }

    protected void FixedUpdate() {
      switch (currentState?.Phase)
      {
        case StatePhase.Enter:
          currentState.Enter();
          currentState.Phase = StatePhase.Update;
          break;
        case StatePhase.Update:
          currentState.Update(Time.fixedDeltaTime);
          break;
        case StatePhase.Exit:
          currentState.Exit();
          currentState = states[nextState];
          currentState.Phase = StatePhase.Enter;
          break;
      }
    }
  }
}
