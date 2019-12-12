using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PoleMovement : MonoBehaviour
{
    // Update is called once per frame
    bool hitStage;
    public Transform pole;
    public BallCollision whiteCollision;
    public float maxForce;
    public Animator myAnimator;
    float speed;
    private bool shotTime;
    private bool animationEnded;

    void Start()
    {
        hitStage = false;
        shotTime = false;
        animationEnded = false;
    }
    void Update()
    {
        speed = 2.0f;
        if (!hitStage)
        {
            if (Input.GetKey(KeyCode.LeftShift)) speed /= 3.0f;
            if (Input.GetKey(KeyCode.D)) transform.Rotate(0, 0, speed);
            if (Input.GetKey(KeyCode.A)) transform.Rotate(0, 0, -speed);
            if (Input.GetKeyUp(KeyCode.Space))
            {
                myAnimator.SetBool("stay", true);
                hitStage = true;
            }
            shotTime = false;
        }
        else if(hitStage && !shotTime)
        {

            if (Input.GetKeyUp(KeyCode.Space))
            {
                shotTime = true;

                myAnimator.SetBool("shot", true);
            }
        }
        else if (hitStage && shotTime)
        {
            myAnimator.SetBool("stay", false);
            myAnimator.SetBool("shot", false);
        }
        else if(animationEnded && shotTime && hitStage)
        {
            whiteCollision.MyCollision(pole.position);
            shotTime = false;
            hitStage = false;
            animationEnded = false;
        }

    }

}
