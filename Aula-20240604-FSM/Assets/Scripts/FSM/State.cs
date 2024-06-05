using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace FSM {

  public enum StatePhase {
    None, Enter, Update, Exit,
  }

  public class State : IState
  {
    public StatePhase Phase {get; set;}
    protected FsmAgent Agent;
    protected Action<string> ChangeState;

    public State(FsmAgent agent) {
      Agent = agent;
    }

    public void SetChangeState(Action<string> changeState) {
      ChangeState = changeState;
    }

    public virtual string Name { get => "StateDefault"; }
    
    public virtual void Enter() {
      
    }

    public virtual void Update(float deltaTime) {
      
    }

    public virtual void Exit() {

    }
  }

}