using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleMovement : MonoBehaviour
{
    // Update is called once per frame
    bool hitStage;
    private void Start()
    {
        hitStage = false;
    }

    void Update()
    {
        float speed = 2.0f;

        if (Input.GetKey(KeyCode.Space)) hitStage = true;
        if (!hitStage)
        {
            if (Input.GetKey(KeyCode.LeftShift)) speed /= 3.0f;
            if (Input.GetKey(KeyCode.D)) transform.Rotate(0, 0, speed);
            if (Input.GetKey(KeyCode.A)) transform.Rotate(0, 0, -speed);

        }
        else
            transform.Translate(-0.03f, 0, 0);
    }
}
