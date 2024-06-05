using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM {

  public class FsmAgent : AgentController
  {

    protected FSM fsm;
    protected override void Awake()
    {
      base.Awake();

      fsm = gameObject.AddComponent<FSM>();
      fsm.SetFsmAgent(this);

      fsm.RegisterState(new IdleState(this));
    }

    protected void Start() {
      fsm.StartFSM("Idle");
    }

    public new void Move(Vector3 offset) {
      base.Move(offset);
    }

    public new bool SetDestination(Vector3 target) {
      return base.SetDestination(target);
    }
  }

}