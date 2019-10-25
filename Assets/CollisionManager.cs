using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    const int cantBalls = 2;
    [SerializeField]
    private Transform[] balls;
    void Start()
    {
    }
    void Update()
    {
        CheckCollisions();
    }
    private void CheckCollisions()
    {
        Vector2 positionBall1;
        Vector2 positionBall2;
        float distance = 0.0f;
        float comparation;
        for (ushort i = 0; i < balls.Length; i++)
        {
            positionBall1 = balls[i].position;
            for (ushort t = 0; t < balls.Length; t++)
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
                        balls[i].GetComponent<BallCollision>().MyCollision();
                        balls[t].GetComponent<BallCollision>().MyCollision();
                    }
                }
            }
        }
    }
}
