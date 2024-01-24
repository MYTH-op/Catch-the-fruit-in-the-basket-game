using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitMovement : MonoBehaviour
{
   
    public float fallSpeed = 5.0f;

    void Update()
    {
        transform.position -= new Vector3(0, fallSpeed * Time.deltaTime, 0);
    }
}

