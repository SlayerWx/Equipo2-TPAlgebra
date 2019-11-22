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
    public BallCollision whiteCollision;
    public float maxForce;
    float speed;
    float speedLerp;
    public float Timer;
    private bool shotTime;
    private Vector2 positionShot;
    int switchAnimation;
    bool takePosition;

    void Start()
    {
        hitStage = false;
        maxForce = 300.0f;
        shotTime = false;
        speedLerp = 0.03f;
        switchAnimation = 1;
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
            shotTime = false;
            takePosition = false;
        }
        else {
            switch (switchAnimation)
            {
                case 1:
                    pole.localPosition = new Vector3(Mathf.Lerp(transform.position.x - tipPole.localPosition.x,
                    transform.position.x, Timer), 0, 0);
                    Timer += speedLerp;
                    if (Timer > 1.0f) switchAnimation = 2;
                    break;
                case 0:
                case 2:
                    if (switchAnimation == 0 && takePosition) positionShot = pole.position;
                    pole.localPosition = new Vector3(Mathf.Lerp(transform.position.x - tipPole.localPosition.x,
                    transform.position.x, Timer), 0, 0);
                    Timer -= speedLerp;
                    if (switchAnimation == 2 && Timer < 0.05f) switchAnimation = 1;
                    break;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                takePosition = true;
                StartCoroutine("waitAnimationPole");
                
            }
            if(Timer == 3.0f)
            {
              //  shotTime = true;
            }

        }

    }
    IEnumerator waitAnimationPole()
    {
        yield return shotTime;
        whiteCollision.MyCollision(positionShot);
        takePosition = false;
        switchAnimation = 2;
    }
}
