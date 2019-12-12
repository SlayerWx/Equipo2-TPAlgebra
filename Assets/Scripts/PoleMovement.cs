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
    public Movement ballMovement;
    public float maxForce;
    public Animator myAnimator;
    float speed;
    private bool shotTime;
    private bool animationEnded;
    public GameObject mainMenu;
    public GameObject pause;
    private float timeDurationShotAnimation = 0.90f;
    void Start()
    {
        hitStage = false;
        shotTime = false;
        animationEnded = false;
    }
    void Update()
    {
        speed = 2.0f;
        if (!pause.activeSelf && !mainMenu.activeSelf && ballMovement.GetForce().x == 0.0f 
                                                      && ballMovement.GetForce().y == 0.0f)
        {
            if(Input.GetKey(KeyCode.P))
            {
                pause.SetActive(true);
            }
            if (!hitStage && !animationEnded && !shotTime)
            {
                if (Input.GetKey(KeyCode.LeftShift)) speed /= 3.0f;
                if (Input.GetKey(KeyCode.D)) transform.Rotate(0, 0, speed);
                if (Input.GetKey(KeyCode.A)) transform.Rotate(0, 0, -speed);
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    myAnimator.SetBool("stay", true);
                    hitStage = true;
                }
            }
            else if (hitStage && !animationEnded)
            {

                if (Input.GetKeyUp(KeyCode.Space))
                {
                    hitStage = false;
                    animationEnded = false;
                    shotTime = true;
                    myAnimator.SetBool("stay", false);
                    myAnimator.SetBool("shot", true);
                    StartCoroutine("StopedAnimationShot");
                }
            }
            else if (animationEnded)
            {
                whiteCollision.MyCollision(pole.position);
                animationEnded = false;
                shotTime = false;
                hitStage = false;
                myAnimator.SetBool("shot", false);
                transform.gameObject.SetActive(false);
            }

        }
    }
    IEnumerator StopedAnimationShot()
    {
        yield return new WaitForSeconds(timeDurationShotAnimation);
        animationEnded = true;
    }

}
