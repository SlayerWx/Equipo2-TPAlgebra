using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectCollider : MonoBehaviour
{
    public Rect collider;
    public GameObject anotherGO;
    private float correctionColliderError;
    public bool changeOrientation;
    private float timeToWait;

    // Start is called before the first frame update
    void Start()
    {
        correctionColliderError = 0.3f;
        timeToWait = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (collider.Contains(new Vector2(anotherGO.transform.position.x - anotherGO.transform.localScale.x + correctionColliderError, 
                                          anotherGO.transform.position.y)) ||
            collider.Contains(new Vector2(anotherGO.transform.position.x + anotherGO.transform.localScale.x - correctionColliderError,
                                          anotherGO.transform.position.y)) ||
            collider.Contains(new Vector2(anotherGO.transform.position.x ,
                                          anotherGO.transform.position.y - anotherGO.transform.localScale.y + correctionColliderError)) ||
            collider.Contains(new Vector2(anotherGO.transform.position.x,
                                          anotherGO.transform.position.y + anotherGO.transform.localScale.y - correctionColliderError)))
        {
            Movement anotherMovement = anotherGO.GetComponent<Movement>();
            if (changeOrientation && !anotherMovement.collisionWithWall)
            {
                anotherMovement.SetAcceleration(new Vector2(anotherMovement.GetAceleration().x *-1,
                                                            anotherMovement.GetAceleration().y));
                anotherMovement.SetForce(new Vector2(anotherMovement.GetForce().x*-1,
                                                    anotherMovement.GetForce().y));
            }
            else if (!anotherMovement.collisionWithWall)
            {
                anotherMovement.SetAcceleration(new Vector2(anotherMovement.GetAceleration().x,
                                                            anotherMovement.GetAceleration().y*-1));
                anotherMovement.SetForce(new Vector2(anotherMovement.GetForce().x,
                                                    anotherMovement.GetForce().y*-1));
            }
            anotherMovement.collisionWithWall = true;
            StartCoroutine("outColliderWall", anotherMovement);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(collider.min, new Vector2(collider.max.x, collider.min.y));
        Gizmos.DrawLine(collider.min, new Vector2(collider.min.x, collider.max.y));
        Gizmos.DrawLine(new Vector2(collider.max.x, collider.min.y), collider.max);
        Gizmos.DrawLine(new Vector2(collider.min.x, collider.max.y), collider.max);
    }
    IEnumerator outColliderWall(Movement anotherMovement)
    {
        yield return new WaitForSeconds(timeToWait);
        anotherMovement.collisionWithWall = false;
    }
}
