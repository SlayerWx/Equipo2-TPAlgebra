using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleMovement : MonoBehaviour
{
    // Update is called once per frame
    bool hitStage;
    float backSpeed = 0.02f;
    public Transform whiteBall;

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
        else {
            transform.Translate(-backSpeed, 0, 0);

            if (transform.position.x < -5.0f)
            {
                backSpeed = 0;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                transform.localPosition = whiteBall.transform.localPosition;
            }
            float yPosition =  Mathf.Abs(transform.position.y);
            if(yPosition==5)
            {
                Mathf.Lerp(0, -5, 1);
            }
            else
                Mathf.Lerp(0, 5, 1);
        }
        
    }
}
