using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM {


  public class WalkState : State
  {
    public WalkState(FsmAgent agent) : base(agent)
    {
    }

    public override string Name => "Walk";

    public Vector3 Destination = Vector3.zero;
    public float DistanceThreshold = 0.02f;

    
    public override void Enter()
    {
      // Must sets Destination
      Debug.Log($"{Name} {Phase} {Destination}");
      Agent.SetDestination(Destination);
    }

    public override void Update(float deltaTime)
    {
      if(ArriveToDestination) {
        Debug.Log($"{Name} {Phase} {Agent.RemainingDistance}");
        ChangeState("Idle");
      }
    }

    public override void Exit()
    {
      Debug.Log($"{Name} {Phase}");
    }

    protected bool ArriveToDestination {
      get => Agent.RemainingDistance <= DistanceThreshold;
    }
  }

}