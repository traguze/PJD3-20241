using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : RigidbodyController
{
    protected Vector3 startPosition;
    public float Speed = 1.0f;
    protected override void Awake()
    {
        base.Awake();

        startPosition = tf.position;
    }

    private void Update()
    {
        Vector3 newPosition = startPosition;
        newPosition.x += Mathf.Sin(Time.time * Speed);
        tf.position = newPosition;
    }
}
