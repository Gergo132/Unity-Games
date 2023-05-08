using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
