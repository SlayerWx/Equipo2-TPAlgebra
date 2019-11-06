using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleMovement : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))transform.Rotate(0,0,1);
        if (Input.GetKey(KeyCode.D))transform.Rotate(0, 0, -1); ;
    }
}
