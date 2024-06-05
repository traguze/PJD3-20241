using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM {


  public class FollowPlayerState : WalkState
  {
    public FollowPlayerState(FsmAgent agent) : base(agent)
    {
    }

    public override string Name => "FollowPlayer";


    
    public override void Enter()
    {
      // Must sets Destination
      Destination = PlayerController.Instance.Transform.position;

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