using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed=5;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (transform.position.z < -15 )
        {
            Destroy(gameObject);
        }
        if(transform.position.z > 50)
        {
            Destroy(gameObject);
        }
    }
}
