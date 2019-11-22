using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BallCollision : MonoBehaviour
{
    private Vector2 firstCollitionPosition;
    private Vector2 finalCollitionPosition;
    private bool collisionReady;
    private Vector2 distanceTravelled;
    public Movement myMovement;
    private float timeToWait = 0.2f;

    /// //////////////
    private Vector2 direccion;
    private Vector2 reDireccion;
    void Start()
    {
        direccion = new Vector2(0, 0);
        reDireccion = new Vector2(0, 0);
        firstCollitionPosition = transform.position;
        collisionReady = true;
    }
    void Update()
    {
        if(myMovement.GetForce().x == 0.0f && myMovement.GetForce().x == 0.0f)
        {
            direccion.x = 0;
            direccion.y = 0;
        }
    }
    public void MyCollision(Vector2 collisionEnemy)
    {
        Debug.Log("collision");
        if (collisionReady)
        {
            reDireccion.x = transform.position.x - collisionEnemy.x;
            reDireccion.y = transform.position.y - collisionEnemy.y;

            direccion += reDireccion;
            myMovement.SetForce(direccion);
            myMovement.SetAcceleration(myMovement.GetResultAcceleration(direccion, myMovement.GetMass()));
            StartCoroutine("NotCollisionTime");
        }

    }
    IEnumerator NotCollisionTime()
    {
        collisionReady = false;
        yield return new WaitForSeconds(timeToWait);
        collisionReady = true;
    }
}
