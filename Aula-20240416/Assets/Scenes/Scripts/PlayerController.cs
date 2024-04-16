using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : RigidbodyController
{
    protected float Speed = 5f;

    [SerializeField]
    public float Horizontal { get; protected set; }
    [SerializeField]
    public float Vertical { get; protected set; }

    [SerializeField]
    public Vector3 Direction = Vector3.zero;

    public Vector3 Velocity = Vector3.zero;

    private void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        Direction.Set(Horizontal, 0, Vertical);
        Debug.Log(Direction);
        Direction.Normalize();

        Velocity.Set(Direction.x * Speed, rb.velocity.y, Direction.z * Speed);

        rb.velocity = Velocity;
    }
}
