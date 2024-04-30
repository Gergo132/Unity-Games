using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] GameObject player;
    void LateUpdate()
    {
        transform.LookAt(player.transform.position);
    }
}
