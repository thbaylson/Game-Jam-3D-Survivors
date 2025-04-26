using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    public float speed = 15f;

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
