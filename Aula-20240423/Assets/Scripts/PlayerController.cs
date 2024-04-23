using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : AgentController
{
    protected float Speed = 5f;

    [SerializeField]
    public float Horizontal { get; protected set; }
    [SerializeField]
    public float Vertical { get; protected set; }

    

    [SerializeField]
    public Vector3 Direction = Vector3.zero;

    public Vector3 Velocity = Vector3.zero;

    public Vector3 pointPosition;

    public Transform sphereTf;

    static public PlayerController Instance {  get; protected set; }

    public Transform Transform { get; protected set; }

    protected override void Awake()
    {
        base.Awake();

        Instance = this;
        Transform = tf;
    }

    private void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        Direction.Set(Horizontal, 0, Vertical);
        //Debug.Log(Direction);
        Direction.Normalize();

        Velocity.Set(Direction.x * Speed, rb.velocity.y, Direction.z * Speed);

        //rb.velocity = Velocity;

        Move(Velocity * Time.deltaTime);

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo))
            {
                pointPosition = hitInfo.point;
                sphereTf.position = pointPosition;

                SetDestination(pointPosition);
            }
        }

        Vector3[] paths = nma.path.corners;
        for(int i = 1; i < paths.Length; i++) {
            Debug.DrawLine(paths[i - 1], paths[i], Color.green);
        }
        
    }
}
