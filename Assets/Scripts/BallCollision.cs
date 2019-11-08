using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BallCollision : MonoBehaviour
{
    private Vector2 firstCollitionPosition;
    private Vector2 finalCollitionPosition;
    private bool moving;
    private Vector2 distanceTravelled;
    void Start()
    {
        firstCollitionPosition = transform.position;
        moving = false;
    }
    void Update()
    {
        
    }
    public void MyCollision(Vector2 collisionEnemy)
    {
        Debug.Log("COLISION");
        Vector2 distance;
        float angle;
        Vector2 aux;
        if (!moving)
        {
            firstCollitionPosition = transform.position;
        }
        else
        {
            finalCollitionPosition = collisionEnemy;
            distanceTravelled = finalCollitionPosition - firstCollitionPosition;
            distance = new Vector2(transform.position.x - collisionEnemy.x , transform.position.y - collisionEnemy.y);
            angle = Mathf.Acos(distanceTravelled.x * distance.x + distanceTravelled.y * distance.y / 
                    ((Mathf.Pow(distanceTravelled.x, 2) + Mathf.Pow(distanceTravelled.y, 2)) *
                     (Mathf.Pow(distance.x, 2) + Mathf.Pow(distance.y, 2))));
            aux.x = (distanceTravelled.x + distanceTravelled.y) * Mathf.Cos(angle);
            aux.y = (distance.x + distance.y) * Mathf.Sin(angle);
        }
        


    }
}
