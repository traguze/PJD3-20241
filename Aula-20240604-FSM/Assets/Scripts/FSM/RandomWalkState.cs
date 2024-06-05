using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM {


  public class RandomWalkState : WalkState
  {
    public RandomWalkState(FsmAgent agent) : base(agent)
    {
    }

    public override string Name => "RandomWalk";


    
    public override void Enter()
    {
      // Must sets Destination
      Destination = new Vector3(Random.Range(-5f,5f),0,Random.Range(-5f,5f));

      base.Enter();
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
  }

}