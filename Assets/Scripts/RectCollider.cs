using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectCollider : MonoBehaviour
{
    public Rect collider;
    public GameObject anotherGO;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (collider.Contains(anotherGO.transform.position))
        {
            Debug.Log("zdfbkzgzsi");
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
