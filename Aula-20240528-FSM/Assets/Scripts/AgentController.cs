using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentController : RigidbodyController
{
    [SerializeField]
    protected NavMeshAgent nma;

    protected override void Awake()
    {
        base.Awake();

        nma = GetComponent<NavMeshAgent>();
    }

    protected void Move(Vector3 offset)
    {
        nma.Move(offset);
    }

    protected bool SetDestination(Vector3 target)
    {
        return nma.SetDestination(target);
    }
}
