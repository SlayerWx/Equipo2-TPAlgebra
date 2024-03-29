﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private const int mass = 500;
    private Vector2 acceleration;
    public float x;
    public float y;
    private Vector2 force;
    public bool collisionWithWall;

    void Start()
    {
        force = new Vector2(x, y);
        collisionWithWall = false;
    }
    void FixedUpdate()
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
            acceleration = acceleration * 1.02f;
        }
        if (Mathf.Abs(force.x) < Mathf.Abs(acceleration.x) && Mathf.Abs(force.y) < Mathf.Abs(acceleration.y))
        {
            force.x = 0.0f;
            force.y = 0.0f;
            acceleration.x = 0.0f;
            acceleration.y = 0.0f;
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
    public int GetMass()
    {
        return mass;
    }

    public Vector2 GetResultAcceleration(Vector2 force, float mass)
    {
        Vector2 resultAcceleration;
        resultAcceleration.x = 0;
        resultAcceleration.y = 0;
        resultAcceleration.x = force.x / mass;
        resultAcceleration.y = force.y / mass;
        return resultAcceleration;
    }
}
