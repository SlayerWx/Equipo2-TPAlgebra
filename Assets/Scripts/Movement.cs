using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private const int mass = 160;
    private Vector2 acceleration;
    [SerializeField]
    float x;
    [SerializeField]
    float y;
    private Vector2 force;
    public bool collisionWithWall;

    void Start()
    {
        //   acceleration = new Vector2(0.0f, 0.0f);
        force = new Vector2(x, y);
        collisionWithWall = false;
    }
    void Update()
    {
        MyMovement();
    }
    private void MyMovement()
    {
        if (force.x != 0 || force.y != 0)
        {
            transform.position = new Vector3(transform.position.x + (force.x * Time.deltaTime),
                                   transform.position.y + (force.y * Time.deltaTime), transform.position.z);

            force -= acceleration;
        }
        if (Mathf.Abs(force.x) < Mathf.Abs(acceleration.x) && Mathf.Abs(force.y) < Mathf.Abs(acceleration.y))
        {
            force.x = 0;
            force.y = 0;
            acceleration.x = 0;
            acceleration.y = 0;
        }
    }
    public void SetAcceleration(Vector2 newAcceleration)
    {
        acceleration = newAcceleration;

    }
    public void SetForce(Vector2 newForce)
    {
        force = newForce;

    }
    public Vector2 GetForce()
    {
        return force;
    }
    public Vector2 GetAceleration()
    {
        return acceleration;
    }
}
