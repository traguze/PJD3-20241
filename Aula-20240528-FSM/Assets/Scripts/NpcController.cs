using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : AgentController
{
    public List<Vector3> PatrolPoints = new List<Vector3>();

    [SerializeField]
    protected int currentPoint = -1;

    [SerializeField]
    protected Transform Target;

    public float ChaseDistance = 5f;

    protected Vector3 NextPoint
    {
        get { 
            return PatrolPoints[currentPoint = ++currentPoint % PatrolPoints.Count];
        }
    }

    protected override void Awake()
    {
        base.Awake();
        Debug.Log($"NpcController {Time.time}");
        PatrolPoints = CheckPointsGroup.GetCheckPointsByName("npc1");

        
    }

    private void Start()
    {
        Target = PlayerController.Instance.Transform;

        SetDestination(NextPoint);
    }

    private void Update()
    {
        if(Vector3.Distance(tf.position, Target.position) <= ChaseDistance)
        {
            SetDestination(Target.position);
        }

        if (nma.remainingDistance <= 0)
        {
            Debug.Log("Get NextPoint");
            SetDestination(NextPoint);
        }
    }
}
