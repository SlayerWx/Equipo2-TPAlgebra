using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectCollider : MonoBehaviour
{
    public Rect collider;
    public GameObject anotherGO;
    public bool changeOrientation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (collider.Contains(anotherGO.transform.position))
        {
            Movement anotherMovement = anotherGO.GetComponent<Movement>();
            if(changeOrientation)
            {
                anotherMovement.SetAcceleration(new Vector2(anotherMovement.GetAceleration().x *-1,
                                                            anotherMovement.GetAceleration().y));
                anotherMovement.SetForce(new Vector2(anotherMovement.GetForce().x*-1,
                                                    anotherMovement.GetForce().y));
            }
            else
            {
                anotherMovement.SetAcceleration(new Vector2(anotherMovement.GetAceleration().x,
                                                            anotherMovement.GetAceleration().y*-1));
                anotherMovement.SetForce(new Vector2(anotherMovement.GetForce().x,
                                                    anotherMovement.GetForce().y*-1));
            }
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
}
