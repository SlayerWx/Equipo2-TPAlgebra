using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleMovement : MonoBehaviour
{
    // Update is called once per frame
    bool hitStage;
    float backSpeed = 0.02f;
    public Transform tipPole;
    public Transform pole;
    float speed;
    public float Timer;

    void Start()
    {
        hitStage = false;
        
    }

    void Update()
    {
        speed = 2.0f;
        if (!hitStage)
        {
            if (Input.GetKey(KeyCode.LeftShift)) speed /= 3.0f;
            if (Input.GetKey(KeyCode.D)) transform.Rotate(0, 0, speed);
            if (Input.GetKey(KeyCode.A)) transform.Rotate(0, 0, -speed);
            if (Input.GetKeyUp(KeyCode.Space)) hitStage = true;

        }
        else {
            pole.localPosition = new Vector3(Mathf.Lerp(transform.position.x - tipPole.localPosition.x, 
                transform.position.x,Timer),0, 0);

        }

    }
}
