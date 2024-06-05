using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM {


  public class RetreatState : WalkState
  {
    public RetreatState(FsmAgent agent) : base(agent)
    {
    }

    public override string Name => "Retreat";

    public float RetreatDistance = 5f;
    public Transform playerTf;

    public override void Enter()
    {
      Debug.Log($"{Name} {Phase}");
      playerTf = PlayerController.Instance.Transform;
      Retreat();
    }

    public override void Update(float deltaTime)
    {
      var diff = Vector3.Distance(Agent.transform.position, playerTf.position);
      if(diff > RetreatDistance * 0.5f) {
        Retreat();
      } else if(diff >= RetreatDistance) {
        ChangeState("Idle");
      }
    }

    public override void Exit()
    {
      Debug.Log($"{Name} {Phase}");
    }

    public void Retreat() {
      
      Destination = playerTf.position + playerTf.forward * RetreatDistance;
      Agent.SetDestination(Destination);
    }
  }

}