using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private const int mass = 160; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private Vector2 BallMovement(Vector2 force,float meters)
    {
        Vector2 resultAcceleration;
        resultAcceleration.x = 0;
        resultAcceleration.y = 0;

        resultAcceleration.x = force.x / mass;
        resultAcceleration.y = force.y / mass;

        resultAcceleration.x = resultAcceleration.x / Mathf.Pow(Time.deltaTime, 2);
        resultAcceleration.y = resultAcceleration.y / Mathf.Pow(Time.deltaTime, 2);
        Debug.Log("aceleracion conseguida: x:" + resultAcceleration.x + " y:" + resultAcceleration.y);
        return resultAcceleration;
    }
}
