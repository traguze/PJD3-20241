using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM {


  public class IdleState : State
  {
    public IdleState(FsmAgent agent) : base(agent)
    {
    }

    public override string Name => "Idle";

    protected float idleTime;

    public override void Enter()
    {
      Debug.Log($"{Name} {Phase}");
      idleTime = Random.Range(1f,3f);
    }

    public override void Update(float deltaTime)
    {
      idleTime -= deltaTime;
      Debug.Log($"{Name} {Phase} {idleTime}");
      if(idleTime <= 0f) {
        ChangeState("Idle");
      }
    }

    public override void Exit()
    {
      Debug.Log($"{Name} {Phase}");
    }
  }

}