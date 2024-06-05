using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM {

  public interface IState
  {
    string Name { get; }
    void Enter();
    void Update(float deltaTime);
    void Exit();
  }

}