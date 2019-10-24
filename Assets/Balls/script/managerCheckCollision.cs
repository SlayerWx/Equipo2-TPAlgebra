using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerCheckCollision : MonoBehaviour
{
    [SerializeField]
    private Transform[] balls;
    [SerializeField]
    private collision[] ballsCollision;
    void Start()
    {
        for(int i = 0; i < balls.Length;i++)
        {
            ballsCollision[i] = balls[i].GetComponent<collision>();
        }
    }

    void Update()
    {
        CheckCollisions();
    }
    private void CheckCollisions()
    {
        Vector2 positionBall1;
        Vector2 positionBall2;
        float distance = 0;
        float comparation;
        for (ushort i = 0; i < balls.Length;i++)
        {
            positionBall1 = balls[i].position;
            for(ushort t = 0; t < balls.Length;t++)
            {
                if (t != i)
                {
                    positionBall2 = balls[t].position;
                    distance = Mathf.Pow(Mathf.Abs(positionBall1.x - positionBall2.x), 2) + 
                               Mathf.Pow(Mathf.Abs(positionBall1.y - positionBall2.y), 2);

                    comparation = distance - (Mathf.Max(balls[i].localScale.x, balls[i].localScale.y) +
                    (Mathf.Max(balls[t].localScale.x, balls[t].localScale.y)));
                    if (comparation <= 0)
                    {
                        ballsCollision[i].myCollision();
                        ballsCollision[t].myCollision();
                    }
                }
            }
        }
    }
}
